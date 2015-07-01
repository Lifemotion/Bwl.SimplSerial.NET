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

    Public Sub New()
        Me.New(Nothing)
    End Sub

    Public Sub New(sserial As SimplSerialBus)
        Me.New(sserial, New SettingsStorageRoot, New Logger)
    End Sub

    Public Sub New(sserial As SimplSerialBus, storage As SettingsStorage, logger As Logger)
        InitializeComponent()
        _sserial = sserial
        _logger = logger
        _storage = storage
        Dim allowChangePort As Boolean
        If _sserial Is Nothing Then
            _sserial = New SimplSerialBus(New SerialPort)
            allowChangePort = True
        Else
            SerialSelector1.AllowPortChange = False
            allowChangePort = False
        End If
        SerialSelector1.AssociatedISerialDevice = _sserial.SerialDevice
        SerialSelector1.LoadFromDevice()
        SerialSelector1.Enabled = True
        SerialSelector1.AllowPortChange = allowChangePort
        Dim thread As New Threading.Thread(AddressOf SearchingThread)
        thread.IsBackground = True
        thread.Name = "Searching"
        thread.Start()
    End Sub

    Private Sub Tool_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _logger.ConnectWriter(DatagridLogWriter1)
        ShowGuidInfo()
        'CodeExecutor1.ReferencesList.Add("Bwl.Hardware.SimplSerial.Tool.exe")

        '  CodeExecutor1.ImportsList.Add("SimplSerialTool")
        CodeExecutor.Logger = _logger
        CodeExecutor1.SourceText += "Sub Main()" + vbCrLf
        CodeExecutor1.SourceText += "Dim result = SimplSerialTool.SSerial.Request(New SSRequest(0, 254, {}))" + vbCrLf
        CodeExecutor1.SourceText += "CodeExecutor.Output(result.ToString)" + vbCrLf
        CodeExecutor1.SourceText += "End Sub" + vbCrLf
    End Sub

    Private Sub connectTimer_Tick(sender As Object, e As EventArgs) Handles connectTimer.Tick
        If _sserial.IsConnected = False Then
            Try
                If _sserial.SerialDevice.DeviceAddress > "" Then
                    _sserial.Connect()
                    _logger.AddMessage("Подключено: " + _sserial.SerialDevice.DeviceAddress + ", " + _sserial.SerialDevice.DeviceSpeed.ToString)
                End If
            Catch ex As Exception
                _logger.AddWarning("Не могу подключиться к " + _sserial.SerialDevice.DeviceAddress + ", " + ex.Message)
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

    Private Sub goToBootloader_Click() Handles goToBootloader.Click
        TryThis(Sub()
                    _sserial.RequestGoToBootloader(Val(reqAddressTextbox.Text))
                End Sub)
    End Sub

    Private Sub reqBootInfoButton_Click() Handles reqBootInfoButton.Click
        Try
            goToBootloader_Click()

        Catch ex As Exception

        End Try
        TryThis(Sub()
                    _flasher = New FirmwareUploader(_sserial, _logger)
                    _flasher.RequestBootInfo(Val(reqAddressTextbox.Text))
                    spmSizeTextbox.Text = _flasher.SpmSize.ToString
                    progmemSizeTextbox.Text = _flasher.ProgmemSize.ToString
                    signature.Text = _flasher.Signature
                End Sub)
    End Sub

    Private _flasher As FirmwareUploader

    Private Sub programMemButton_Click(sender As Object, e As EventArgs) Handles programMemButton.Click
        reqBootInfoButton_Click()

        TryThis(Sub()
                    _flasher.EraseAndFlashAll(Val(reqAddressTextbox.Text), FirmwareUploader.LoadFirmwareFromFile(firmwarePathTextbox.Text))
                End Sub)
    End Sub

    Private Sub gotoMain_Click(sender As Object, e As EventArgs) Handles gotoMain.Click
        TryThis(Sub()
                    _sserial.RequestGoToMain(Val(reqAddressTextbox.Text))
                End Sub)
    End Sub

    Private Sub eraseProgramButton_Click(sender As Object, e As EventArgs) Handles eraseProgramButton.Click
        reqBootInfoButton_Click()
        TryThis(Sub()
                    _flasher.EraseAll(Val(reqAddressTextbox.Text))
                End Sub)
    End Sub

    Private Sub portWriteButton_Click() Handles portWriteButton.Click
        TryThis(Sub()
                    Dim bytes(15) As Byte
                    Dim pins As New SimplSerialBus.Pins
                    PortMonitor1.ToPort() : pins.Port1 = PortMonitor1.Port
                    PortMonitor2.ToPort() : pins.Port2 = PortMonitor2.Port
                    PortMonitor3.ToPort() : pins.Port3 = PortMonitor3.Port
                    PortMonitor4.ToPort() : pins.Port4 = PortMonitor4.Port
                    _sserial.RequestPinsChange(CInt(Val(reqAddressTextbox.Text)), pins)
                End Sub)
        portReadButton_Click()
    End Sub

    Private Sub PortMonitorHandler() Handles PortMonitor1.PortChanged, PortMonitor2.PortChanged, PortMonitor3.PortChanged, PortMonitor4.PortChanged
        If My.Computer.Keyboard.ShiftKeyDown Then portWriteButton_Click()
    End Sub

    Private Sub НастройкиToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles НастройкиToolStripMenuItem.Click
        _storage.ShowSettingsForm()
    End Sub

    Private Sub portReadButton_Click() Handles portReadButton.Click
        TryThis(Sub()
                    Dim pins = _sserial.RequestPinsRead(CInt(Val(reqAddressTextbox.Text)))
                    PortMonitor1.Port = pins.Port1 : PortMonitor1.Refresh()
                    PortMonitor2.Port = pins.Port2 : PortMonitor2.Refresh()
                    PortMonitor3.Port = pins.Port3 : PortMonitor3.Refresh()
                    PortMonitor4.Port = pins.Port4 : PortMonitor4.Refresh()
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

    Private Sub searchDevicesButton_Click(sender As Object, e As EventArgs)
        'TryThis(Sub()
        Dim info = _sserial.FindDevices
        'End Sub)
    End Sub

    Private Sub SearchingThread()
        Dim rnd As New Random
        Do
            Try
                If Me.Invoke(Function() _searchingEnabled.Checked) = True Then
                    For i = 1 To 10
                        Dim randi = rnd.Next
                        Dim results = _sserial.FindDevices(randi)
                        For Each result In results
                            Dim str = result.ToString + " " + (randi And 255).ToString
                            Dim lines As String() = Me.Invoke(Function() searchDevicesResult.Lines)
                            If lines.Contains(str) = False Then Me.Invoke(Sub() searchDevicesResult.Text = searchDevicesResult.Text + vbCrLf + str)
                        Next
                    Next
                End If
            Catch ex As Exception

            End Try

            Threading.Thread.Sleep(100)
        Loop
    End Sub

    Private Sub selectFirmwarePathButton_Click(sender As Object, e As EventArgs) Handles selectFirmwarePathButton.Click
        firmwarePathTextbox.Text = FirmwareUploader.SelectFirmwareFile
    End Sub
End Class
