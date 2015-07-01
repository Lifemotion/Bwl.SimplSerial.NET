﻿Imports Bwl.Hardware.Serial
Imports System.Numerics

''' <summary>
''' Реализация базового интерфейса шины SimplSerial.
''' </summary>
''' <remarks></remarks>
Public Class SimplSerialBus
    Public Class Tests
        Public Shared Sub AddressSetupTest(sserial As SimplSerialBus)
            Dim rnd As New Random
            Dim startinfo = sserial.RequestDeviceInfo(0)
            If startinfo.Response.ResponseState <> ResponseState.ok Then Throw New Exception("Device Not Respond")
            If startinfo.DeviceDate.Length < 6 Then Throw New Exception("Bad DeviceDate")
            If startinfo.DeviceName.Length < 6 Then Throw New Exception("Bad DeviceName")
            '   If startinfo.DeviceGuid. Then Throw New Exception("Bad DeviceDate")

            Dim addr1 = rnd.Next(2, UInt16.MaxValue - 2)
            sserial.RequestSetAddress(startinfo.DeviceGuid, addr1)
            Dim info1 = sserial.RequestDeviceInfo(0)
            Dim addr1real = info1.Response.FromAddress
            If addr1 <> addr1real Then Throw New Exception("Bad RequestSetAddress 1")

            Dim resp1a = sserial.RequestDeviceInfo(addr1)
            If resp1a.Response.ResponseState <> ResponseState.ok Then Throw New Exception("Not respond to set addr 1")

            Dim resp1b = sserial.RequestDeviceInfo(addr1 - 1)
            If resp1b.Response.ResponseState <> ResponseState.errorTimeout Then Throw New Exception("Respond to wronad addr addr 1 - 1")

            Dim resp1c = sserial.RequestDeviceInfo(addr1 + 1)
            If resp1c.Response.ResponseState <> ResponseState.errorTimeout Then Throw New Exception("Respond to wronad addr addr 1 + 1")

            Dim addr2 = rnd.Next(2, UInt16.MaxValue - 2)
            sserial.RequestSetAddress(startinfo.DeviceGuid, addr2)
            Dim info2 = sserial.RequestDeviceInfo(0)
            Dim addr2real = info2.Response.FromAddress
            If addr2 <> addr2real Then Throw New Exception("Bad RequestSetAddress 2")

            Dim resp2a = sserial.RequestDeviceInfo(addr2)
            If resp2a.Response.ResponseState <> ResponseState.ok Then Throw New Exception("Not respond to set addr 2")

            Dim resp2b = sserial.RequestDeviceInfo(addr1)
            If resp2b.Response.ResponseState <> ResponseState.errorTimeout Then Throw New Exception("Respond to previous addr 1")

        End Sub
    End Class

    Private _serial As ISerialDevice
    Private _lastPacket As SSRequest
    Private _syncRoot As New Object
    Private _readBufferPos As Integer
    Private _readBuffer(1024) As Byte
    Private _deviceNameSetting As StringSetting
    Private _deviceSpeedSetting As IntegerSetting
    Public Property RequestTimeout As Integer = 1000
    Public Property ReadBytes As Long

    ' 9600 - стандарт, 1200 - low, 115200 - fast
    Public Sub New(serial As ISerialDevice)
        _serial = serial
        _serial.AutoReadBytes = False
    End Sub

    Public Sub New(storage As SettingsStorage)
        _deviceNameSetting = storage.CreateStringSetting("DeviceAddress", "COM1")
        _deviceSpeedSetting = storage.CreateIntegerSetting("DeviceSpeed", 9600, , "9600 - нормальная, 1200 - медленная, 115200 - быстрая")
        _serial = New FastSerialPort
        _serial.AutoReadBytes = False

    End Sub

    Public Sub New(serialPortName As String)
        _serial = New FastSerialPort
        _serial.DeviceAddress = serialPortName
        _serial.DeviceSpeed = 9600
        _serial.AutoReadBytes = False
    End Sub

    Public Sub Connect()
        If _deviceNameSetting IsNot Nothing Then
            _serial.DeviceAddress = _deviceNameSetting.Value
            _serial.DeviceSpeed = _deviceSpeedSetting.Value
        End If
        _serial.Connect()
    End Sub

    Public Sub Disconnect()
        _serial.Disconnect()
    End Sub

    Public ReadOnly Property IsConnected()
        Get
            Return _serial.IsConnected
        End Get
    End Property
    ''' <summary>
    ''' Устройство последовательной связи.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SerialDevice As ISerialDevice
        Get
            Return _serial
        End Get
    End Property
    Private Sub AddBytes(list As List(Of Byte), val As Byte, crc As Crc16)
        list.Add(val)
        crc.Update(val)
        If val = &H98 Then list.Add(0)
    End Sub

    Public Function MakeRequestBytes(request As SSRequest) As Byte()
        Dim datalength = request.Data.Length
        Dim address = request.Address
        Dim command = request.Command

        If datalength > 127 Then datalength = 127
        Dim bytes As New List(Of Byte)
        Dim crc16 As New Crc16
        bytes.Add(0)
        bytes.AddRange({&H98, 1})
        Dim crcstart = bytes.Count
        AddBytes(bytes, (address >> 8) And 255, crc16)
        AddBytes(bytes, (address) And 255, crc16)
        AddBytes(bytes, (command), crc16)
        For Each b In request.Data
            AddBytes(bytes, (b), crc16)
        Next
        Dim crcsend = bytes.Count - 1
        Dim crc As UInt16 = crc16.GetCrc
        AddBytes(bytes, (crc >> 8) And 255, crc16)
        AddBytes(bytes, (crc) And 255, crc16)
        bytes.AddRange({&H98, 2})
        '  bytes.Add(0)
        Return bytes.ToArray
    End Function

    Public Sub Send(request As SSRequest)
        Dim bytes = MakeRequestBytes(request)
        _serial.Write(bytes.ToArray)
    End Sub

    Public Function Read() As SSResponse
        SyncLock _syncRoot
            Dim result As New SSResponse
            result.ResponseState = ResponseState.errorNotRequested
            SyncLock _serial
                Dim time = Now
                Dim readSuccess As Boolean = True
                Do While result.ResponseState <> ResponseState.ok And readSuccess
                    Dim currbyte As Byte
                    Dim lastData As Byte
                    readSuccess = False
                    Try
                        If _serial.ReceivedBufferCount > 0 Then
                            currbyte = _serial.Read()
                            readSuccess = True
                        End If
                    Catch ex As Exception
                        result.ResponseState = ResponseState.errorPortError
                        Return result
                    End Try

                    If readSuccess Then
                        If _readBufferPos > _readBuffer.Length - 1 Then
                            _readBufferPos = 0
                        End If

                        If lastData = &H98 Then
                            Select Case currbyte
                                Case 0
                                    _readBuffer(_readBufferPos) = &H98 : _readBufferPos += 1
                                Case &H3
                                    _readBufferPos = 0
                                Case &H4
                                    If _readBufferPos > 4 Then
                                        Dim recvCrc As UShort = _readBuffer(_readBufferPos - 2) * 256 + _readBuffer(_readBufferPos - 1)
                                        Dim realCrc = Crc16.ComputeCrc(_readBuffer, 0, _readBufferPos - 3)
                                        If recvCrc = realCrc Then
                                            result.FromAddress = _readBuffer(0) * 256 + _readBuffer(1)
                                            result.Result = _readBuffer(2)
                                            Dim length = _readBufferPos - 5
                                            result.Data = Array.CreateInstance(GetType(Byte), length)
                                            Array.ConstrainedCopy(_readBuffer, 3, result.Data, 0, length)
                                            result.ResponseState = ResponseState.ok
                                            Return result
                                        Else
                                            result.ResponseState = ResponseState.errorCrc
                                            Return result
                                        End If
                                    End If
                                Case &H98
                                    _readBuffer(_readBufferPos) = currbyte : _readBufferPos += 1
                                Case Else
                            End Select
                        Else
                            If currbyte <> &H98 Then _readBuffer(_readBufferPos) = currbyte : _readBufferPos += 1
                        End If
                        lastData = currbyte
                    Else
                        Threading.Thread.Sleep(10)
                    End If
                Loop

            End SyncLock
            If result.ResponseState = ResponseState.ok Then
                Return result
            Else
                Return Nothing
            End If
        End SyncLock
    End Function

    Public Class Port
        Public Property PinDirection As Byte
        Public Property PinInput As Byte
        Public Property PinOutput As Byte
        Public Property PinSetMask As Byte
    End Class

    Public Class Pins
        Public Property Port1 As New Port
        Public Property Port2 As New Port
        Public Property Port3 As New Port
        Public Property Port4 As New Port
    End Class

    Public Function RequestPinsRead(address As Integer) As Pins
        Dim pins As New Pins
        Dim bytes(2) As Byte
        bytes(0) = 2
        Dim req As New SSRequest(address, 250, bytes)
        Dim resp = RequestWithRetries(req, 10)
        If resp.ResponseState <> ResponseState.ok Then Throw New Exception(resp.ResponseState.ToString)

        pins.Port1.PinDirection = (resp.Data(1))
        pins.Port1.PinOutput = (resp.Data(2))
        pins.Port1.PinInput = (resp.Data(3))

        pins.Port2.PinDirection = (resp.Data(4))
        pins.Port2.PinOutput = (resp.Data(5))
        pins.Port2.PinInput = (resp.Data(6))

        pins.Port3.PinDirection = (resp.Data(7))
        pins.Port3.PinOutput = (resp.Data(8))
        pins.Port3.PinInput = (resp.Data(9))

        pins.Port4.PinDirection = (resp.Data(10))
        pins.Port4.PinOutput = (resp.Data(11))
        pins.Port4.PinInput = (resp.Data(12))

        Return pins
    End Function

    Public Sub RequestPinsChange(address As Integer, pins As Pins)
        Dim bytes(13) As Byte
        bytes(0) = 1

        bytes(1) = pins.Port1.PinDirection
        bytes(2) = pins.Port1.PinOutput
        bytes(3) = pins.Port1.PinSetMask

        bytes(4) = pins.Port2.PinDirection
        bytes(5) = pins.Port2.PinOutput
        bytes(6) = pins.Port2.PinSetMask

        bytes(7) = pins.Port3.PinDirection
        bytes(8) = pins.Port3.PinOutput
        bytes(9) = pins.Port3.PinSetMask

        bytes(10) = pins.Port4.PinDirection
        bytes(11) = pins.Port4.PinOutput
        bytes(12) = pins.Port4.PinSetMask

        Dim req As New SSRequest(address, 250, bytes)
        Dim resp = Request(req)
        If resp.ResponseState <> ResponseState.ok Then Throw New Exception(resp.ResponseState.ToString)
    End Sub

    Public Function RequestWithRetries(requestPacket As SSRequest, retries As Integer) As SSResponse
        For i = 1 To retries - 1
            Dim result = Request(requestPacket)
            If result.ResponseState = ResponseState.ok Then Return result
            Debug.WriteLine("Retry " + Command.ToString)
            Threading.Thread.Sleep(200)
        Next
        Return Request(requestPacket)
    End Function

    ''' <summary>
    ''' Выполнить запрос и получить ответ. 
    ''' </summary>
    ''' <param name="requestPacket">Пакет данных запроса</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Request(requestPacket As SSRequest) As SSResponse
        SyncLock _syncRoot
            Dim result As New SSResponse
            SyncLock _serial
                Try
                    Do While _serial.ReceivedBufferCount > 0
                        _serial.Read()
                    Loop
                Catch ex As Exception
                End Try
                Send(requestPacket)
                result.ResponseState = ResponseState.errorTimeout
                Dim time = Now
                Dim receivedLength As Integer
                Dim receivedBuffer(1024) As Byte

                Do While (Now - time).TotalMilliseconds < RequestTimeout And result.ResponseState = ResponseState.errorTimeout

                    Dim readSuccess As Boolean = False
                    Dim currbyte As Byte
                    Dim lastData As Byte
                    Try
                        If _serial.ReceivedBufferCount > 0 Then
                            currbyte = _serial.Read()
                            readSuccess = True
                        End If
                    Catch ex As Exception
                        result.ResponseState = ResponseState.errorPortError
                        Return result
                    End Try

                    If readSuccess Then
                        If receivedLength > receivedBuffer.Length - 1 Then
                            receivedLength = 0
                        End If

                        If lastData = &H98 Then
                            Select Case currbyte
                                Case 0
                                    receivedBuffer(receivedLength) = &H98 : receivedLength += 1
                                Case &H3
                                    receivedLength = 0
                                Case &H4
                                    If receivedLength > 4 Then
                                        Dim recvCrc As UShort = receivedBuffer(receivedLength - 2) * 256 + receivedBuffer(receivedLength - 1)
                                        Dim realCrc = Crc16.ComputeCrc(receivedBuffer, 0, receivedLength - 3)
                                        If recvCrc = realCrc Then
                                            result.FromAddress = receivedBuffer(0) * 256 + receivedBuffer(1)
                                            result.Result = receivedBuffer(2)
                                            Dim length = receivedLength - 5
                                            result.Data = Array.CreateInstance(GetType(Byte), length)
                                            Array.ConstrainedCopy(receivedBuffer, 3, result.Data, 0, length)
                                            result.ResponseState = ResponseState.ok
                                            Return result
                                        Else
                                            result.ResponseState = ResponseState.errorCrc
                                            Return result
                                        End If
                                    End If
                                Case &H98
                                    receivedBuffer(receivedLength) = currbyte : receivedLength += 1
                                Case Else
                            End Select
                        Else
                            If currbyte <> &H98 Then receivedBuffer(receivedLength) = currbyte : receivedLength += 1
                        End If
                        lastData = currbyte
                    Else
                        Threading.Thread.Sleep(10)
                    End If
                Loop
                ' If result.ResponseState = ResponseState.errorTimeout Then Stop
                Return result
            End SyncLock
        End SyncLock
    End Function

    ''' <summary>
    ''' Самотестирование устройства на произвольных данных (не менее 1 байта и не более буфера устройства).
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RequestTestDevice(address As Integer, testData As Byte())
        If testData Is Nothing OrElse testData.Length < 1 Then Throw New Exception("Data must be 1 byte at least")
        Dim request As New SSRequest(address, 252, testData)
        Dim response = Me.Request(request)
        If response.ResponseState = ResponseState.ok Then
            If response.Result <> request.Data(0) Then Throw New Exception("RequestTestDevice: error response")
            If response.Data.Length + 1 <> request.Data.Length Then Throw New Exception("RequestTestDevice: error data length")
            For i = 0 To response.Data.Length - 1
                Dim data = request.Data(i + 1) - 1
                If data = -1 Then data = 255
                If response.Data(i) <> data Then Throw New Exception("RequestTestDevice: error data byte")
            Next
        Else
            Throw New Exception("RequestTestDevice: bad response: " + response.ResponseState.ToString)
        End If
    End Sub

    Public Function UInt16ToBytes(uint As UInt16) As Byte()
        Dim result(1) As Byte
        result(0) = (uint >> 8) And 255
        result(1) = uint And 255
        Return result
    End Function

    Public Sub RequestSetAddress(guid As Guid, address As Integer)
        Dim bytes = New List(Of Byte)
        bytes.AddRange(guid.ToByteArray)
        bytes.AddRange(UInt16ToBytes(address))
        Dim result = Request(New SSRequest(0, 253, bytes.ToArray))
        If result.ResponseState = ResponseState.ok AndAlso result.Result = 0 Then Return
        Throw New Exception("RequestSetAddress: bad response: " + result.ResponseState.ToString + " " + result.Result.ToString)
    End Sub

    Public Sub RequestGoToBootloader(address As Integer)
        Dim result = Request(New SSRequest(address, 251, {2}))
        If result.ResponseState = ResponseState.ok AndAlso result.Result = 0 Then Return
        Throw New Exception("RequestGoToBootloader: bad response: " + result.ResponseState.ToString + " " + result.Result.ToString)
    End Sub
    Public Sub RequestGoToMain(address As Integer)
        Dim result = Request(New SSRequest(address, 251, {1}))
        If result.ResponseState = ResponseState.ok AndAlso result.Result = 0 Then Return
        Throw New Exception("RequestGoToMain: bad response: " + result.ResponseState.ToString + " " + result.Result.ToString)
    End Sub
    ''' <summary>
    ''' Запросить базовую информацию устройства (команда 120).
    ''' </summary>
    ''' <param name="address">Адрес устройства.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RequestDeviceInfo(address As Integer) As DeviceInfo
        Dim result = Request(New SSRequest(address, 254, {}))
        Dim ascii = Text.ASCIIEncoding.ASCII
        Dim info As New DeviceInfo With {.Response = result}
        If result.ResponseState = ResponseState.ok Then
            If result.Result = 0 And result.Data.Length >= 38 Then
                Dim arr(15) As Byte
                For i = 0 To 15
                    arr(i) = result.Data(i)
                Next
                info.DeviceGuid = New Guid(arr)
                info.DeviceName = ascii.GetString(result.Data, 16, 32)
                info.DeviceDate = ascii.GetString(result.Data, 48, 6)
                Return info
            End If
        End If
        Return info
    End Function

    Public Function FindDevices(seed As Integer) As Guid()
        Dim result = Request(New SSRequest(0, 255, {0, seed And 255}))
        If result.ResponseState = ResponseState.ok Then
            Dim arr(15) As Byte
            For i = 0 To 15
                arr(i) = result.Data(i)
            Next
            Dim sg = New Guid(arr)
            Return {sg}
        End If
        Return {}
    End Function

    Public Function FindDevices() As DeviceInfo()
        Dim start() As Byte = {}
        Dim result = FindDevices(start, 0, 255)
        Throw New NotImplementedException
    End Function
    Private Function FindDevices(start As Byte(), v1 As Byte, v2 As Byte) As Byte()()
        Debug.WriteLine(start.Length.ToString + ", " + v1.ToString + ", " + v2.ToString)
        If FindDevicesRequest(start, v1, v2, 3, 100) Then
            Dim startNew As New List(Of Byte)(start)
            If v1 = v2 Then
                startNew.Add(v1)
                If start.Length = 15 Then
                    Return {startNew.ToArray()}
                Else
                    Return FindDevices(startNew.ToArray(), 0, 255)
                End If
            Else
                If v2 - v1 > 1 Then
                    Dim divide = CInt(Math.Floor(CDbl(v1) + CDbl(v2)) / 2)
                    Dim list As New List(Of Byte())
                    list.AddRange(FindDevices(start, v1, divide))
                    list.AddRange(FindDevices(start, divide + 1, v2))
                    Return list.ToArray
                Else
                    Dim list As New List(Of Byte())
                    list.AddRange(FindDevices(start, v1, v1))
                    list.AddRange(FindDevices(start, v2, v2))
                    Return list.ToArray
                End If
            End If
        Else
            Return {}
        End If
    End Function

    Private Function FindDevicesRequest(start As Byte(), v1 As Byte, v2 As Byte, repeats As Byte, timeout As Double) As Boolean
        Dim list As New List(Of Byte)
        list.AddRange(start)
        list.Add(v1)
        Do While list.Count < 16 : list.Add(0) : Loop
        list.AddRange(start)
        list.Add(v2)
        Do While list.Count < 32 : list.Add(255) : Loop
        Dim marker As Byte = 1
        list.Add(marker)
        For i = 1 To repeats
            Do While _serial.ReceivedBufferCount > 0
                _serial.Read()
            Loop
            Send(New SSRequest(0, 249, list.ToArray))
            Dim time = Now
            Dim read As Byte
            Do While (Now - time).TotalMilliseconds < timeout And read = 0
                If _serial.ReceivedBufferCount > 0 Then read = _serial.Read
                Threading.Thread.Sleep(1)
            Loop
            If read > 0 Then Return True
        Next
        Return False
    End Function

End Class


