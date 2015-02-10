Imports System.Windows.Forms

Public Class SimplSerialTool
    Inherits Form
    Private Shared _sserial As SimplSerialBus
    Private _logger As Logger
    Private _storage As SettingsStorage
    Public Shared ReadOnly Property SSerial As SimplSerialBus
        Get
            Return _sserial
        End Get
    End Property
    Public Sub New(sserial As SimplSerialBus, storage As SettingsStorage, logger As Logger)
        InitializeComponent()
        _sserial = sserial
        _logger = logger
        _storage = storage
        If _sserial Is Nothing Then
            _sserial = New SimplSerialBus(storage.CreateChildStorage("SimplSerial"))
        End If
    End Sub

    Private Sub Tool_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _logger.ConnectWriter(DatagridLogWriter1)
        ShowGuidInfo()
        CodeExecutor1.ReferencesList.Add("Bwl.Hardware.SimplSerial.Tool.exe")
        CodeExecutor1.ImportsList.Add("SimplSerialTool")
		CodeExecutor.Logger = _logger
        CodeExecutor1.SourceText += "Sub Main()" + vbCrLf
        CodeExecutor1.SourceText += "Dim result = SimplSerialTool.SSerial.Request(New SSRequest(0, 254, {}))" + vbCrLf
        CodeExecutor1.SourceText += "CodeExecutor.Output(result.ToString)" + vbCrLf
        CodeExecutor1.SourceText += "End Sub" + vbCrLf
	End Sub

    Private Sub connectTimer_Tick(sender As Object, e As EventArgs) Handles connectTimer.Tick
        If _sserial.IsConnected = False Then
            Try
                _sserial.Connect()
                _logger.AddMessage("Подключено")
            Catch ex As Exception
                _logger.AddWarning("Не могу подключиться, " + ex.Message)
            End Try
        End If
    End Sub

    Private Sub getDevInfoButton_Click(sender As Object, e As EventArgs) Handles getDevInfoButton.Click
        TryThis(Sub()
                    Dim info = _sserial.RequestDeviceInfo(Val(reqAddressTextbox.Text))
                    If info.Response.ResponseState = ResponseState.ok Then
                        devAddressTextbox.Text = info.Response.FromAddress.ToString
                        devDateTextbox.Text = info.DeviceDate
                        devguidTextbox.Text = info.DeviceGuid.ToString
                        devnameTextbox.Text = info.DeviceName
                    Else
                        Throw New Exception(info.Response.ResponseState.ToString)
                    End If
                End Sub)
    End Sub

    Public Delegate Sub TryThisDelegate()
    Public Sub TryThis(dlg As TryThisDelegate)
        Try
            dlg.Invoke()
            _logger.AddMessage("OK")
        Catch ex As Exception
            _logger.AddWarning(ex.Message)
        End Try
    End Sub

    Private Sub setAddressButton_Click(sender As Object, e As EventArgs) Handles setAddressButton.Click
        Dim g As Guid
        If Guid.TryParse(_setAddressGuidTextbox.Text, g) Then
            TryThis(Sub()
                        _sserial.RequestSetAddress(g, Val(_setAddressValueTextbox.Text))
                    End Sub)
        Else
            _logger.AddError("guid incorrect")
        End If
    End Sub

    Private Sub selfTestBustton_Click(sender As Object, e As EventArgs) Handles selfTestBustton.Click
        Const maxsize = 128

		TryThis(Sub()
					For n = 1 To 50
						Dim rnd As New Random
						Dim length = rnd.Next(1, maxsize)
						Dim list As New List(Of Byte)
						For i = 1 To length
							list.Add(rnd.Next(0, 255))
						Next
						_sserial.RequestTestDevice(Val(_setAddressValueTextbox.Text), list.ToArray)
						If n Mod 10 = 0 Then _logger.AddMessage("Проведено тестов: " + n.ToString)
						Application.DoEvents()
					Next
				End Sub)
    End Sub

    Private Sub goToBootloader_Click(sender As Object, e As EventArgs) Handles goToBootloader.Click
        TryThis(Sub()
                    _sserial.RequestGoToBootloader(Val(reqAddressTextbox.Text))
                End Sub)
    End Sub

    Private Sub reqBootInfoButton_Click(sender As Object, e As EventArgs) Handles reqBootInfoButton.Click
		TryThis(Sub()
					Dim info = _sserial.RequestWithRetries(New SSRequest(Val(reqAddressTextbox.Text), 100, {}), 1)
					If info.ResponseState = ResponseState.ok Then
						Dim spm = info.Data(16) * 256 + info.Data(17)
						Dim pgmsize = info.Data(18) * 256 * 256 + info.Data(19) * 256 + info.Data(10)
						Dim sign = info.Data(11) * 256 * 256 + info.Data(13) * 256 + info.Data(5)

						spmSizeTextbox.Text = spm.ToString
						progmemSizeTextbox.Text = pgmsize.ToString.ToString
						signature.Text = Hex(sign)
					Else
						Throw New Exception(info.ResponseState.ToString)
					End If
				End Sub)
    End Sub


    Private Sub programMemButton_Click(sender As Object, e As EventArgs) Handles programMemButton.Click
		TryThis(Sub()
					Dim fd As New OpenFileDialog()
					fd.Filter = "HEX|*.hex|BIN|*.bin"
					If fd.ShowDialog = Windows.Forms.DialogResult.OK Then
						Dim file = fd.FileName

						Dim bin As Byte()
						Dim ext = (file.ToLower.Substring(file.ToLower.Length - 4, 4))
						Select Case ext
							Case ".hex"
								Dim str = IO.File.ReadAllLines(file)
								Dim converter = New HexToBinConverter()
								bin = converter.Hex2Bin(str)
							Case ".bin"
								bin = IO.File.ReadAllBytes(file)
						End Select

						Dim spm = CInt(Val(spmSizeTextbox.Text))
						Dim size = CInt(Val(progmemSizeTextbox.Text)) - 1024 * 4
						If spm < 64 Then Throw New Exception("SPM = 0")
						ReDim Preserve bin(size - 1) '

						For i = 0 To bin.Length - 1 Step spm
							Dim page As Integer = Math.Floor(i \ spm)
							_logger.AddMessage("Program: " + i.ToString + "\" + size.ToString)
							Application.DoEvents()
							EraseFillWritePage(Val(reqAddressTextbox.Text), page, bin, i, spm)
						Next
					End If
				End Sub)
    End Sub

    Public Sub ErasePage(address As Integer, page As Integer)
        Dim page0 = (page >> 8) And 255
        Dim page1 = page Mod 256
        Dim test = _sserial.RequestWithRetries(New SSRequest(address, 102, {page0, page1, 0}), 50)
        If test.ResponseState <> ResponseState.ok Then Throw New Exception(test.ResponseState.ToString)
        If test.Result <> 103 Then Throw New Exception(test.ResponseState.ToString)
        _logger.AddDebug("ErasePage")
    End Sub

    Public Sub FillPageBuffer(address As Integer, page As Integer, offset As Integer, bytes As Byte())
        If bytes.Length <> 8 Then Throw New Exception("FillPageBuffer <> 8")
        Dim page0 = (page >> 8) And 255
        Dim page1 = page Mod 256
        Dim offset0 = (offset >> 8) And 255
        Dim offset1 = offset Mod 256
        Dim test = _sserial.RequestWithRetries(New SSRequest(address, 104, {page0, page1, offset0, offset1, bytes(0), bytes(1), bytes(2), bytes(3), bytes(4), bytes(5), bytes(6), bytes(7)}), 50)
        If test.ResponseState <> ResponseState.ok Then Throw New Exception(test.ResponseState.ToString)
        If test.Result <> 105 Then Throw New Exception(test.ResponseState.ToString)

        _logger.AddDebug("FillPage")
    End Sub

    Public Sub WritePage(address As Integer, page As Integer)
        Dim page0 = (page >> 8) And 255
        Dim page1 = page Mod 256
        Dim test = _sserial.RequestWithRetries(New SSRequest(address, 106, {page0, page1}), 50)
        If test.ResponseState <> ResponseState.ok Then Throw New Exception(test.ResponseState.ToString)
        If test.Result <> 107 Then Throw New Exception(test.ResponseState.ToString)

		'_logger.AddDebug("Write")
    End Sub

    Public Sub EraseFillWritePage(address As Integer, page As Integer, data As Byte(), offset As Integer, size As Integer)
        If size <> 128 And size <> 64 Then Throw New Exception("EraseFillWritePage:  size <> 128, size <> 64")

        If data.Length < offset + size Then
            Throw New Exception("EraseFillWritePage: Data not enough")

        End If

        Dim buffer(size - 1) As Integer
        Dim datapresent As Boolean
        For i = 0 To buffer.Length - 1
            buffer(i) = data(offset + i)
            ' buffer(i) = i
            If buffer(i) <> 0 And buffer(i) <> 255 Then datapresent = True
        Next
        If datapresent Then
            ErasePage(address, page)

            For i = 0 To size - 1 Step 8
                FillPageBuffer(address, page, i, {buffer(i), buffer(i + 1), buffer(i + 2), buffer(i + 3), buffer(i + 4), buffer(i + 5), buffer(i + 6), buffer(i + 7)})
            Next
            WritePage(address, page)
        End If
    End Sub

    Private Sub goToBootloader_Click_1(sender As Object, e As EventArgs) Handles goToBootloader.Click

    End Sub

    Private Sub gotoMain_Click(sender As Object, e As EventArgs) Handles gotoMain.Click
        TryThis(Sub()
                    _sserial.RequestGoToMain(Val(reqAddressTextbox.Text))
                End Sub)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles eraseProgramButton.Click
		TryThis(Sub()
					Dim spm = CInt(Val(spmSizeTextbox.Text))
					Dim size = CInt(Val(progmemSizeTextbox.Text)) - 1024 * 4

					For i = 0 To size - 1 Step spm
						Dim page As Integer = Math.Floor(i \ spm)
						_logger.AddMessage("Erase: " + i.ToString + "\" + size.ToString)
						Application.DoEvents()
						ErasePage(Val(reqAddressTextbox.Text), page)
					Next
				End Sub)
    End Sub


    Public Function String2Byte(str As String) As Byte
        str = str.PadLeft(8)
        Dim val As Byte
        For i = 0 To 7
            Dim bit = 0
            If str(7 - i) = "1" Then bit = 1
            val += (2 ^ i) * bit
        Next
        Return val
    End Function

    Public Function Byte2String(val As Byte) As String
        Dim str As String = ""
        For i = 0 To 7
            If val And 128 Then str += "1" Else str += "0"
            val = val << 1
        Next
        Return str
    End Function


    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        TryThis(Sub()
                    Dim bytes(15) As Byte
                    Dim pins As New SimplSerialBus.Pins

                    pins.Port1.PinDirection = String2Byte(ddrA.Text)
                    pins.Port1.PinOutput = String2Byte(portA.Text)

                    pins.Port2.PinDirection = String2Byte(ddrB.Text)
                    pins.Port2.PinOutput = String2Byte(portB.Text)

                    pins.Port3.PinDirection = String2Byte(ddrC.Text)
                    pins.Port3.PinOutput = String2Byte(portC.Text)

                    pins.Port4.PinDirection = String2Byte(ddrD.Text)
                    pins.Port4.PinOutput = String2Byte(portD.Text)

                    _sserial.RequestPinsChange(CInt(Val(reqAddressTextbox.Text)), pins)

                End Sub)
    End Sub

    Private Sub НастройкиToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles НастройкиToolStripMenuItem.Click
        _storage.ShowSettingsForm()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TryThis(Sub()

                    Dim pins = _sserial.RequestPinsRead(CInt(Val(reqAddressTextbox.Text)))

                    ddrA.Text = Byte2String(pins.Port1.PinDirection)
                    portA.Text = Byte2String(pins.Port1.PinOutput)
                    pinA.Text = Byte2String(pins.Port1.PinInput)

                    ddrB.Text = Byte2String(pins.Port2.PinDirection)
                    portB.Text = Byte2String(pins.Port2.PinOutput)
                    pinB.Text = Byte2String(pins.Port2.PinInput)

                    ddrC.Text = Byte2String(pins.Port3.PinDirection)
                    portC.Text = Byte2String(pins.Port3.PinOutput)
                    pinC.Text = Byte2String(pins.Port3.PinInput)

                    ddrD.Text = Byte2String(pins.Port4.PinDirection)
                    portD.Text = Byte2String(pins.Port4.PinOutput)
                    pinD.Text = Byte2String(pins.Port4.PinInput)
                End Sub)
    End Sub

    Private Sub getCurrentGuidButton_Click(sender As Object, e As EventArgs) Handles getCurrentGuidButton.Click
        guidToAddTextbox.Text = devguidTextbox.Text
        guidCommentTextbox.Text = devnameTextbox.Text
    End Sub

    Private Function GetGuidInfo(guid As String) As String
        If IO.File.Exists(guid.ToLower + ".guid.txt") Then
            Return IO.File.ReadAllText(guid.ToLower + ".guid.txt", System.Text.UTF8Encoding.UTF8)
        Else
            Return ""
        End If
    End Function

    Private Sub SaveGuidInfo(guid As String, info As String)
        If guid.Length <> 36 Then Return
        IO.File.WriteAllText(guid.ToLower + ".guid.txt", info, System.Text.UTF8Encoding.UTF8)
        ShowGuidInfo()
    End Sub

    Private Sub addGuidButton_Click(sender As Object, e As EventArgs) Handles addGuidButton.Click
        If GetGuidInfo(guidToAddTextbox.Text) = "" Then SaveGuidInfo(guidToAddTextbox.Text, guidCommentTextbox.Text)
    End Sub

    Private Sub ShowGuidInfo()
        Dim files = IO.Directory.GetFiles(".", "*.guid.txt")
        identifiersList.Items.Clear()
        For Each f In files
            Dim guid = f.Split(IO.Path.DirectorySeparatorChar).Last().ToLower.Replace(".guid.txt", "")
            If guid.Length = 36 Then
                identifiersList.Items.Add(guid + " " + GetGuidInfo(guid))
            End If
        Next
    End Sub



    Private Sub guidCommentTextbox_KeyDown(sender As Object, e As KeyEventArgs) Handles guidCommentTextbox.KeyDown
        If e.KeyCode = Keys.Enter Then
            SaveGuidInfo(guidToAddTextbox.Text, guidCommentTextbox.Text)
            ShowGuidInfo()
        End If
    End Sub

    Private Sub identifiersList_Click(sender As Object, e As EventArgs) Handles identifiersList.Click
        Dim guid = identifiersList.Text.Split(" ")(0)
        If guid.Length = 36 Then
            guidToAddTextbox.Text = guid
            guidCommentTextbox.Text = GetGuidInfo(guid)
        End If
    End Sub

    Private Sub CodeExecutor1_Load(sender As Object, e As EventArgs) Handles CodeExecutor1.Load

    End Sub

	Private Sub identifiersList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles identifiersList.SelectedIndexChanged

		If identifiersList.SelectedItem IsNot Nothing Then
			Dim g = identifiersList.SelectedItem.ToString.Split(" ")(0)
			Try

				'If guid.Length = 36 Then
				'	guidToAddTextbox.Text = guid
				'	guidCommentTextbox.Text = GetGuidInfo(guid)
				'End If

				_sserial.RequestSetAddress(Guid.Parse(g), 255)
				_logger.AddInformation(g + " _ good")

			Catch ex As Exception
				_logger.AddError(g + " _ " + ex.ToString)
			End Try
		End If
	End Sub

	Private Sub queryAllGuidsButton_Click(sender As Object, e As EventArgs) Handles queryAllGuidsButton.Click
		Try
			For Each it In identifiersList.Items
				Dim g = it.ToString.Split(" ")(0)
				Try

					'If guid.Length = 36 Then
					'	guidToAddTextbox.Text = guid
					'	guidCommentTextbox.Text = GetGuidInfo(guid)
					'End If

					_sserial.RequestSetAddress(Guid.Parse(g), 255)
					_logger.AddInformation(g + " _ good")

				Catch ex As Exception

				End Try
			Next
		Catch ex As Exception
			_logger.AddError(ex.ToString)
		End Try
		
	End Sub
End Class
