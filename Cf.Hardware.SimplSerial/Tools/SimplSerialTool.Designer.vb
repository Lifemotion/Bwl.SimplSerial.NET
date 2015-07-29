<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SimplSerialTool
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SimplSerialTool))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.portReadButton = New System.Windows.Forms.Button()
        Me.portWriteButton = New System.Windows.Forms.Button()
        Me._setAddressValueTextbox = New System.Windows.Forms.TextBox()
        Me._setAddressGuidTextbox = New System.Windows.Forms.TextBox()
        Me.setAddressButton = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.selectFirmwarePathButton = New System.Windows.Forms.Button()
        Me.firmwarePathTextbox = New System.Windows.Forms.TextBox()
        Me.eraseProgramButton = New System.Windows.Forms.Button()
        Me.gotoMain = New System.Windows.Forms.Button()
        Me.programMemButton = New System.Windows.Forms.Button()
        Me.goToBootloader = New System.Windows.Forms.Button()
        Me.signature = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.progmemSizeTextbox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.reqBootInfoButton = New System.Windows.Forms.Button()
        Me.spmSizeTextbox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.queryAllGuidsButton = New System.Windows.Forms.Button()
        Me.guidCommentTextbox = New System.Windows.Forms.TextBox()
        Me.addGuidButton = New System.Windows.Forms.Button()
        Me.getCurrentGuidButton = New System.Windows.Forms.Button()
        Me.guidToAddTextbox = New System.Windows.Forms.TextBox()
        Me.identifiersList = New System.Windows.Forms.ListBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.Button1 = New System.Windows.Forms.Button()
        Me._searchingEnabled = New System.Windows.Forms.CheckBox()
        Me.searchDevicesResult = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.devAddressTextbox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.devDateTextbox = New System.Windows.Forms.TextBox()
        Me.reqAddressTextbox = New System.Windows.Forms.TextBox()
        Me.selfTestBustton = New System.Windows.Forms.Button()
        Me.getDevInfoButton = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.devguidTextbox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.devnameTextbox = New System.Windows.Forms.TextBox()
        Me.connectTimer = New System.Windows.Forms.Timer(Me.components)
        Me.DatagridLogWriter1 = New Bwl.Framework.DatagridLogWriter()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.НастройкиToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.reqGuidTextbox = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.bootstateTextbox = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.addInfoTextbox = New System.Windows.Forms.TextBox()
        Me.SerialSelector1 = New Bwl.Hardware.SimplSerial.SerialSelector()
        Me.PortMonitor4 = New Bwl.Hardware.SimplSerial.PortMonitor()
        Me.PortMonitor3 = New Bwl.Hardware.SimplSerial.PortMonitor()
        Me.PortMonitor2 = New Bwl.Hardware.SimplSerial.PortMonitor()
        Me.PortMonitor1 = New Bwl.Hardware.SimplSerial.PortMonitor()
        Me.CodeExecutor1 = New Bwl.Hardware.SimplSerial.CodeExecutor()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Location = New System.Drawing.Point(2, 151)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(865, 277)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label17)
        Me.TabPage1.Controls.Add(Me.PortMonitor4)
        Me.TabPage1.Controls.Add(Me.PortMonitor3)
        Me.TabPage1.Controls.Add(Me.PortMonitor2)
        Me.TabPage1.Controls.Add(Me.PortMonitor1)
        Me.TabPage1.Controls.Add(Me.Label21)
        Me.TabPage1.Controls.Add(Me.Label20)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.portReadButton)
        Me.TabPage1.Controls.Add(Me.portWriteButton)
        Me.TabPage1.Controls.Add(Me._setAddressValueTextbox)
        Me.TabPage1.Controls.Add(Me._setAddressGuidTextbox)
        Me.TabPage1.Controls.Add(Me.setAddressButton)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(857, 251)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Основное"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(682, 151)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(129, 31)
        Me.Label17.TabIndex = 39
        Me.Label17.Text = "Удерживайте Shift для немедленной записи "
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(304, 4)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(41, 13)
        Me.Label21.TabIndex = 34
        Me.Label21.Text = "Адрес:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(31, 4)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(90, 13)
        Me.Label20.TabIndex = 33
        Me.Label20.Text = "Идентификатор:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(540, 45)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(34, 13)
        Me.Label16.TabIndex = 29
        Me.Label16.Text = "PortD"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(369, 47)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(33, 13)
        Me.Label15.TabIndex = 28
        Me.Label15.Text = "PortC"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(201, 47)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(33, 13)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "PortB"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(31, 47)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(33, 13)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "PortA"
        '
        'portReadButton
        '
        Me.portReadButton.Location = New System.Drawing.Point(680, 185)
        Me.portReadButton.Name = "portReadButton"
        Me.portReadButton.Size = New System.Drawing.Size(124, 27)
        Me.portReadButton.TabIndex = 13
        Me.portReadButton.Text = "Считать все"
        Me.portReadButton.UseVisualStyleBackColor = True
        '
        'portWriteButton
        '
        Me.portWriteButton.Location = New System.Drawing.Point(680, 216)
        Me.portWriteButton.Name = "portWriteButton"
        Me.portWriteButton.Size = New System.Drawing.Size(124, 27)
        Me.portWriteButton.TabIndex = 13
        Me.portWriteButton.Text = "Записать все"
        Me.portWriteButton.UseVisualStyleBackColor = True
        '
        '_setAddressValueTextbox
        '
        Me._setAddressValueTextbox.Location = New System.Drawing.Point(305, 21)
        Me._setAddressValueTextbox.Name = "_setAddressValueTextbox"
        Me._setAddressValueTextbox.Size = New System.Drawing.Size(61, 20)
        Me._setAddressValueTextbox.TabIndex = 12
        Me._setAddressValueTextbox.Text = "0"
        '
        '_setAddressGuidTextbox
        '
        Me._setAddressGuidTextbox.Location = New System.Drawing.Point(34, 21)
        Me._setAddressGuidTextbox.Name = "_setAddressGuidTextbox"
        Me._setAddressGuidTextbox.Size = New System.Drawing.Size(265, 20)
        Me._setAddressGuidTextbox.TabIndex = 11
        Me._setAddressGuidTextbox.Text = "0"
        '
        'setAddressButton
        '
        Me.setAddressButton.Location = New System.Drawing.Point(372, 20)
        Me.setAddressButton.Name = "setAddressButton"
        Me.setAddressButton.Size = New System.Drawing.Size(89, 22)
        Me.setAddressButton.TabIndex = 10
        Me.setAddressButton.Text = "Установить"
        Me.setAddressButton.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.selectFirmwarePathButton)
        Me.TabPage2.Controls.Add(Me.firmwarePathTextbox)
        Me.TabPage2.Controls.Add(Me.eraseProgramButton)
        Me.TabPage2.Controls.Add(Me.gotoMain)
        Me.TabPage2.Controls.Add(Me.programMemButton)
        Me.TabPage2.Controls.Add(Me.goToBootloader)
        Me.TabPage2.Controls.Add(Me.signature)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.progmemSizeTextbox)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.reqBootInfoButton)
        Me.TabPage2.Controls.Add(Me.spmSizeTextbox)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(814, 251)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Загрузчик"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 7)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(187, 13)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Путь к файлу прошивки (*.hex; *.bin)"
        '
        'selectFirmwarePathButton
        '
        Me.selectFirmwarePathButton.Location = New System.Drawing.Point(501, 23)
        Me.selectFirmwarePathButton.Name = "selectFirmwarePathButton"
        Me.selectFirmwarePathButton.Size = New System.Drawing.Size(28, 22)
        Me.selectFirmwarePathButton.TabIndex = 19
        Me.selectFirmwarePathButton.Text = "..."
        Me.selectFirmwarePathButton.UseVisualStyleBackColor = True
        '
        'firmwarePathTextbox
        '
        Me.firmwarePathTextbox.Location = New System.Drawing.Point(9, 24)
        Me.firmwarePathTextbox.Name = "firmwarePathTextbox"
        Me.firmwarePathTextbox.Size = New System.Drawing.Size(486, 20)
        Me.firmwarePathTextbox.TabIndex = 18
        '
        'eraseProgramButton
        '
        Me.eraseProgramButton.Location = New System.Drawing.Point(112, 56)
        Me.eraseProgramButton.Name = "eraseProgramButton"
        Me.eraseProgramButton.Size = New System.Drawing.Size(206, 26)
        Me.eraseProgramButton.TabIndex = 17
        Me.eraseProgramButton.Text = "Очистка"
        Me.eraseProgramButton.UseVisualStyleBackColor = True
        '
        'gotoMain
        '
        Me.gotoMain.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gotoMain.Location = New System.Drawing.Point(622, 125)
        Me.gotoMain.Name = "gotoMain"
        Me.gotoMain.Size = New System.Drawing.Size(179, 26)
        Me.gotoMain.TabIndex = 16
        Me.gotoMain.Text = "Вызвать основной код"
        Me.gotoMain.UseVisualStyleBackColor = True
        '
        'programMemButton
        '
        Me.programMemButton.Location = New System.Drawing.Point(324, 56)
        Me.programMemButton.Name = "programMemButton"
        Me.programMemButton.Size = New System.Drawing.Size(205, 26)
        Me.programMemButton.TabIndex = 15
        Me.programMemButton.Text = "Прошивка"
        Me.programMemButton.UseVisualStyleBackColor = True
        '
        'goToBootloader
        '
        Me.goToBootloader.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.goToBootloader.Location = New System.Drawing.Point(622, 91)
        Me.goToBootloader.Name = "goToBootloader"
        Me.goToBootloader.Size = New System.Drawing.Size(179, 26)
        Me.goToBootloader.TabIndex = 14
        Me.goToBootloader.Text = "Вызвать загрузчик"
        Me.goToBootloader.UseVisualStyleBackColor = True
        '
        'signature
        '
        Me.signature.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.signature.Location = New System.Drawing.Point(714, 62)
        Me.signature.Name = "signature"
        Me.signature.ReadOnly = True
        Me.signature.Size = New System.Drawing.Size(87, 20)
        Me.signature.TabIndex = 8
        Me.signature.Text = "0"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(619, 65)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Signature"
        '
        'progmemSizeTextbox
        '
        Me.progmemSizeTextbox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.progmemSizeTextbox.Location = New System.Drawing.Point(714, 36)
        Me.progmemSizeTextbox.Name = "progmemSizeTextbox"
        Me.progmemSizeTextbox.ReadOnly = True
        Me.progmemSizeTextbox.Size = New System.Drawing.Size(87, 20)
        Me.progmemSizeTextbox.TabIndex = 8
        Me.progmemSizeTextbox.Text = "0"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(619, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "PROGMEM size"
        '
        'reqBootInfoButton
        '
        Me.reqBootInfoButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.reqBootInfoButton.Location = New System.Drawing.Point(622, 157)
        Me.reqBootInfoButton.Name = "reqBootInfoButton"
        Me.reqBootInfoButton.Size = New System.Drawing.Size(179, 26)
        Me.reqBootInfoButton.TabIndex = 5
        Me.reqBootInfoButton.Text = "Запрос парам. загрузчика"
        Me.reqBootInfoButton.UseVisualStyleBackColor = True
        '
        'spmSizeTextbox
        '
        Me.spmSizeTextbox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spmSizeTextbox.Location = New System.Drawing.Point(714, 10)
        Me.spmSizeTextbox.Name = "spmSizeTextbox"
        Me.spmSizeTextbox.ReadOnly = True
        Me.spmSizeTextbox.Size = New System.Drawing.Size(87, 20)
        Me.spmSizeTextbox.TabIndex = 6
        Me.spmSizeTextbox.Text = "0"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(619, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "SPM size"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.queryAllGuidsButton)
        Me.TabPage3.Controls.Add(Me.guidCommentTextbox)
        Me.TabPage3.Controls.Add(Me.addGuidButton)
        Me.TabPage3.Controls.Add(Me.getCurrentGuidButton)
        Me.TabPage3.Controls.Add(Me.guidToAddTextbox)
        Me.TabPage3.Controls.Add(Me.identifiersList)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(814, 251)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Идентификаторы"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'queryAllGuidsButton
        '
        Me.queryAllGuidsButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.queryAllGuidsButton.Location = New System.Drawing.Point(582, 85)
        Me.queryAllGuidsButton.Name = "queryAllGuidsButton"
        Me.queryAllGuidsButton.Size = New System.Drawing.Size(224, 21)
        Me.queryAllGuidsButton.TabIndex = 8
        Me.queryAllGuidsButton.Text = "Опросить все"
        Me.queryAllGuidsButton.UseVisualStyleBackColor = True
        '
        'guidCommentTextbox
        '
        Me.guidCommentTextbox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.guidCommentTextbox.Location = New System.Drawing.Point(582, 32)
        Me.guidCommentTextbox.Name = "guidCommentTextbox"
        Me.guidCommentTextbox.Size = New System.Drawing.Size(224, 20)
        Me.guidCommentTextbox.TabIndex = 7
        '
        'addGuidButton
        '
        Me.addGuidButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.addGuidButton.Location = New System.Drawing.Point(706, 58)
        Me.addGuidButton.Name = "addGuidButton"
        Me.addGuidButton.Size = New System.Drawing.Size(100, 21)
        Me.addGuidButton.TabIndex = 6
        Me.addGuidButton.Text = "Добавить"
        Me.addGuidButton.UseVisualStyleBackColor = True
        '
        'getCurrentGuidButton
        '
        Me.getCurrentGuidButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.getCurrentGuidButton.Location = New System.Drawing.Point(582, 58)
        Me.getCurrentGuidButton.Name = "getCurrentGuidButton"
        Me.getCurrentGuidButton.Size = New System.Drawing.Size(100, 21)
        Me.getCurrentGuidButton.TabIndex = 5
        Me.getCurrentGuidButton.Text = "Текущий"
        Me.getCurrentGuidButton.UseVisualStyleBackColor = True
        '
        'guidToAddTextbox
        '
        Me.guidToAddTextbox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.guidToAddTextbox.Location = New System.Drawing.Point(582, 6)
        Me.guidToAddTextbox.Name = "guidToAddTextbox"
        Me.guidToAddTextbox.Size = New System.Drawing.Size(224, 20)
        Me.guidToAddTextbox.TabIndex = 1
        '
        'identifiersList
        '
        Me.identifiersList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.identifiersList.FormattingEnabled = True
        Me.identifiersList.Location = New System.Drawing.Point(6, 6)
        Me.identifiersList.Name = "identifiersList"
        Me.identifiersList.Size = New System.Drawing.Size(570, 199)
        Me.identifiersList.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.CodeExecutor1)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(814, 251)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Скрипт"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.Button1)
        Me.TabPage5.Controls.Add(Me._searchingEnabled)
        Me.TabPage5.Controls.Add(Me.searchDevicesResult)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(814, 251)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Поиск"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(627, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(179, 22)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Запрос информации у всех"
        Me.Button1.UseVisualStyleBackColor = True
        '
        '_searchingEnabled
        '
        Me._searchingEnabled.AutoSize = True
        Me._searchingEnabled.Location = New System.Drawing.Point(6, 12)
        Me._searchingEnabled.Name = "_searchingEnabled"
        Me._searchingEnabled.Size = New System.Drawing.Size(89, 17)
        Me._searchingEnabled.TabIndex = 1
        Me._searchingEnabled.Text = "Вести поиск"
        Me._searchingEnabled.UseVisualStyleBackColor = True
        '
        'searchDevicesResult
        '
        Me.searchDevicesResult.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.searchDevicesResult.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.searchDevicesResult.Location = New System.Drawing.Point(6, 35)
        Me.searchDevicesResult.Multiline = True
        Me.searchDevicesResult.Name = "searchDevicesResult"
        Me.searchDevicesResult.Size = New System.Drawing.Size(802, 186)
        Me.searchDevicesResult.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(682, 105)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Адрес:"
        '
        'devAddressTextbox
        '
        Me.devAddressTextbox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.devAddressTextbox.Location = New System.Drawing.Point(726, 99)
        Me.devAddressTextbox.Name = "devAddressTextbox"
        Me.devAddressTextbox.ReadOnly = True
        Me.devAddressTextbox.Size = New System.Drawing.Size(129, 20)
        Me.devAddressTextbox.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(485, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Дата прошивки:"
        '
        'devDateTextbox
        '
        Me.devDateTextbox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.devDateTextbox.Location = New System.Drawing.Point(580, 99)
        Me.devDateTextbox.Name = "devDateTextbox"
        Me.devDateTextbox.ReadOnly = True
        Me.devDateTextbox.Size = New System.Drawing.Size(101, 20)
        Me.devDateTextbox.TabIndex = 6
        '
        'reqAddressTextbox
        '
        Me.reqAddressTextbox.Location = New System.Drawing.Point(148, 45)
        Me.reqAddressTextbox.Multiline = True
        Me.reqAddressTextbox.Name = "reqAddressTextbox"
        Me.reqAddressTextbox.Size = New System.Drawing.Size(100, 21)
        Me.reqAddressTextbox.TabIndex = 5
        Me.reqAddressTextbox.Text = "0"
        '
        'selfTestBustton
        '
        Me.selfTestBustton.Location = New System.Drawing.Point(374, 99)
        Me.selfTestBustton.Name = "selfTestBustton"
        Me.selfTestBustton.Size = New System.Drawing.Size(101, 22)
        Me.selfTestBustton.TabIndex = 4
        Me.selfTestBustton.Text = "Тест передачи"
        Me.selfTestBustton.UseVisualStyleBackColor = True
        '
        'getDevInfoButton
        '
        Me.getDevInfoButton.Location = New System.Drawing.Point(374, 72)
        Me.getDevInfoButton.Name = "getDevInfoButton"
        Me.getDevInfoButton.Size = New System.Drawing.Size(101, 22)
        Me.getDevInfoButton.TabIndex = 4
        Me.getDevInfoButton.Text = "Запрос инф."
        Me.getDevInfoButton.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(485, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Идентификатор:"
        '
        'devguidTextbox
        '
        Me.devguidTextbox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.devguidTextbox.Location = New System.Drawing.Point(580, 72)
        Me.devguidTextbox.Name = "devguidTextbox"
        Me.devguidTextbox.ReadOnly = True
        Me.devguidTextbox.Size = New System.Drawing.Size(275, 20)
        Me.devguidTextbox.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(485, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Имя устройства:"
        '
        'devnameTextbox
        '
        Me.devnameTextbox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.devnameTextbox.Location = New System.Drawing.Point(580, 45)
        Me.devnameTextbox.Name = "devnameTextbox"
        Me.devnameTextbox.ReadOnly = True
        Me.devnameTextbox.Size = New System.Drawing.Size(153, 20)
        Me.devnameTextbox.TabIndex = 0
        '
        'connectTimer
        '
        Me.connectTimer.Enabled = True
        Me.connectTimer.Interval = 500
        '
        'DatagridLogWriter1
        '
        Me.DatagridLogWriter1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DatagridLogWriter1.FilterText = ""
        Me.DatagridLogWriter1.Location = New System.Drawing.Point(1, 429)
        Me.DatagridLogWriter1.LogEnabled = True
        Me.DatagridLogWriter1.Margin = New System.Windows.Forms.Padding(0)
        Me.DatagridLogWriter1.Name = "DatagridLogWriter1"
        Me.DatagridLogWriter1.ShowDebug = False
        Me.DatagridLogWriter1.ShowErrors = True
        Me.DatagridLogWriter1.ShowInformation = True
        Me.DatagridLogWriter1.ShowMessages = True
        Me.DatagridLogWriter1.ShowWarnings = True
        Me.DatagridLogWriter1.Size = New System.Drawing.Size(865, 208)
        Me.DatagridLogWriter1.TabIndex = 10
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.НастройкиToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(867, 24)
        Me.MenuStrip1.TabIndex = 11
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'НастройкиToolStripMenuItem
        '
        Me.НастройкиToolStripMenuItem.Name = "НастройкиToolStripMenuItem"
        Me.НастройкиToolStripMenuItem.Size = New System.Drawing.Size(88, 20)
        Me.НастройкиToolStripMenuItem.Text = "Настройки..."
        '
        'reqGuidTextbox
        '
        Me.reqGuidTextbox.Location = New System.Drawing.Point(254, 45)
        Me.reqGuidTextbox.Multiline = True
        Me.reqGuidTextbox.Name = "reqGuidTextbox"
        Me.reqGuidTextbox.Size = New System.Drawing.Size(220, 21)
        Me.reqGuidTextbox.TabIndex = 12
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 26)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(101, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Параметры порта:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(147, 26)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 13)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Адрес:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(254, 28)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(90, 13)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Идентификатор:"
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(485, 27)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(151, 13)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Информация об устройстве:"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(267, 72)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(101, 22)
        Me.Button2.TabIndex = 25
        Me.Button2.Text = "Перезагрузка"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'bootstateTextbox
        '
        Me.bootstateTextbox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bootstateTextbox.Location = New System.Drawing.Point(580, 126)
        Me.bootstateTextbox.Name = "bootstateTextbox"
        Me.bootstateTextbox.ReadOnly = True
        Me.bootstateTextbox.Size = New System.Drawing.Size(275, 20)
        Me.bootstateTextbox.TabIndex = 26
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(485, 133)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(62, 13)
        Me.Label18.TabIndex = 27
        Me.Label18.Text = "Загрузчик:"
        '
        'addInfoTextbox
        '
        Me.addInfoTextbox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.addInfoTextbox.Location = New System.Drawing.Point(739, 45)
        Me.addInfoTextbox.Name = "addInfoTextbox"
        Me.addInfoTextbox.ReadOnly = True
        Me.addInfoTextbox.Size = New System.Drawing.Size(116, 20)
        Me.addInfoTextbox.TabIndex = 28
        '
        'SerialSelector1
        '
        Me.SerialSelector1.AllowPortChange = True
        Me.SerialSelector1.AllowSpeedChange = True
        Me.SerialSelector1.AssociatedISerialDevice = Nothing
        Me.SerialSelector1.Location = New System.Drawing.Point(10, 45)
        Me.SerialSelector1.Name = "SerialSelector1"
        Me.SerialSelector1.Size = New System.Drawing.Size(132, 63)
        Me.SerialSelector1.TabIndex = 13
        '
        'PortMonitor4
        '
        Me.PortMonitor4.Location = New System.Drawing.Point(510, 60)
        Me.PortMonitor4.Name = "PortMonitor4"
        Me.PortMonitor4.Port = Nothing
        Me.PortMonitor4.Size = New System.Drawing.Size(166, 187)
        Me.PortMonitor4.TabIndex = 38
        '
        'PortMonitor3
        '
        Me.PortMonitor3.Location = New System.Drawing.Point(339, 60)
        Me.PortMonitor3.Name = "PortMonitor3"
        Me.PortMonitor3.Port = Nothing
        Me.PortMonitor3.Size = New System.Drawing.Size(166, 187)
        Me.PortMonitor3.TabIndex = 37
        '
        'PortMonitor2
        '
        Me.PortMonitor2.Location = New System.Drawing.Point(169, 60)
        Me.PortMonitor2.Name = "PortMonitor2"
        Me.PortMonitor2.Port = Nothing
        Me.PortMonitor2.Size = New System.Drawing.Size(166, 187)
        Me.PortMonitor2.TabIndex = 36
        '
        'PortMonitor1
        '
        Me.PortMonitor1.Location = New System.Drawing.Point(2, 60)
        Me.PortMonitor1.Name = "PortMonitor1"
        Me.PortMonitor1.Port = Nothing
        Me.PortMonitor1.Size = New System.Drawing.Size(166, 187)
        Me.PortMonitor1.TabIndex = 35
        '
        'CodeExecutor1
        '
        Me.CodeExecutor1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CodeExecutor1.ImportsList = CType(resources.GetObject("CodeExecutor1.ImportsList"), System.Collections.Generic.List(Of String))
        Me.CodeExecutor1.Location = New System.Drawing.Point(6, 6)
        Me.CodeExecutor1.Name = "CodeExecutor1"
        Me.CodeExecutor1.ReferencesList = CType(resources.GetObject("CodeExecutor1.ReferencesList"), System.Collections.Generic.List(Of String))
        Me.CodeExecutor1.Size = New System.Drawing.Size(802, 218)
        Me.CodeExecutor1.SourceText = ""
        Me.CodeExecutor1.TabIndex = 0
        Me.CodeExecutor1.Template = "Imports Bwl.Hardware.SimplSerial.SimplSerialBus'importsPublic Class TestProgram'c" & _
    "odeEnd Class"
        '
        'SimplSerialTool
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(867, 638)
        Me.Controls.Add(Me.addInfoTextbox)
        Me.Controls.Add(Me.bootstateTextbox)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.SerialSelector1)
        Me.Controls.Add(Me.reqGuidTextbox)
        Me.Controls.Add(Me.DatagridLogWriter1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.devguidTextbox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.devnameTextbox)
        Me.Controls.Add(Me.devAddressTextbox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.devDateTextbox)
        Me.Controls.Add(Me.getDevInfoButton)
        Me.Controls.Add(Me.reqAddressTextbox)
        Me.Controls.Add(Me.selfTestBustton)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(840, 560)
        Me.Name = "SimplSerialTool"
        Me.Text = "SimplSerialTool"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents devDateTextbox As System.Windows.Forms.TextBox
    Friend WithEvents reqAddressTextbox As System.Windows.Forms.TextBox
    Friend WithEvents getDevInfoButton As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents devguidTextbox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents devnameTextbox As System.Windows.Forms.TextBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents devAddressTextbox As System.Windows.Forms.TextBox
    Friend WithEvents connectTimer As System.Windows.Forms.Timer
    Friend WithEvents _setAddressValueTextbox As System.Windows.Forms.TextBox
    Friend WithEvents _setAddressGuidTextbox As System.Windows.Forms.TextBox
    Friend WithEvents setAddressButton As System.Windows.Forms.Button
    Friend WithEvents selfTestBustton As System.Windows.Forms.Button
    Friend WithEvents reqBootInfoButton As System.Windows.Forms.Button
    Friend WithEvents progmemSizeTextbox As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents spmSizeTextbox As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents signature As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents programMemButton As System.Windows.Forms.Button
    Friend WithEvents goToBootloader As System.Windows.Forms.Button
    Friend WithEvents gotoMain As System.Windows.Forms.Button
    Friend WithEvents eraseProgramButton As System.Windows.Forms.Button
    Friend WithEvents portWriteButton As System.Windows.Forms.Button
    Friend WithEvents DatagridLogWriter1 As Bwl.Framework.DatagridLogWriter
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents НастройкиToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents portReadButton As System.Windows.Forms.Button
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents identifiersList As System.Windows.Forms.ListBox
    Friend WithEvents queryAllGuidsButton As System.Windows.Forms.Button
    Friend WithEvents guidCommentTextbox As System.Windows.Forms.TextBox
    Friend WithEvents addGuidButton As System.Windows.Forms.Button
    Friend WithEvents getCurrentGuidButton As System.Windows.Forms.Button
    Friend WithEvents guidToAddTextbox As System.Windows.Forms.TextBox
    Friend WithEvents reqGuidTextbox As System.Windows.Forms.TextBox
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents CodeExecutor1 As Bwl.Hardware.SimplSerial.CodeExecutor
    Friend WithEvents SerialSelector1 As Bwl.Hardware.SimplSerial.SerialSelector
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents searchDevicesResult As System.Windows.Forms.TextBox
    Friend WithEvents _searchingEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents selectFirmwarePathButton As System.Windows.Forms.Button
    Friend WithEvents firmwarePathTextbox As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents PortMonitor4 As Bwl.Hardware.SimplSerial.PortMonitor
    Friend WithEvents PortMonitor3 As Bwl.Hardware.SimplSerial.PortMonitor
    Friend WithEvents PortMonitor2 As Bwl.Hardware.SimplSerial.PortMonitor
    Friend WithEvents PortMonitor1 As Bwl.Hardware.SimplSerial.PortMonitor
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents bootstateTextbox As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents addInfoTextbox As System.Windows.Forms.TextBox

End Class
