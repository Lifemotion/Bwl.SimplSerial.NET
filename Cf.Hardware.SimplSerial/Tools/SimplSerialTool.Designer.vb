﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.pinD = New System.Windows.Forms.TextBox()
        Me.pinC = New System.Windows.Forms.TextBox()
        Me.pinB = New System.Windows.Forms.TextBox()
        Me.pinA = New System.Windows.Forms.TextBox()
        Me.ddrD = New System.Windows.Forms.TextBox()
        Me.ddrC = New System.Windows.Forms.TextBox()
        Me.ddrB = New System.Windows.Forms.TextBox()
        Me.ddrA = New System.Windows.Forms.TextBox()
        Me.portD = New System.Windows.Forms.TextBox()
        Me.portC = New System.Windows.Forms.TextBox()
        Me.portB = New System.Windows.Forms.TextBox()
        Me.portA = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me._setAddressValueTextbox = New System.Windows.Forms.TextBox()
        Me._setAddressGuidTextbox = New System.Windows.Forms.TextBox()
        Me.setAddressButton = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
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
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(2, 110)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(779, 256)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.pinD)
        Me.TabPage1.Controls.Add(Me.pinC)
        Me.TabPage1.Controls.Add(Me.pinB)
        Me.TabPage1.Controls.Add(Me.pinA)
        Me.TabPage1.Controls.Add(Me.ddrD)
        Me.TabPage1.Controls.Add(Me.ddrC)
        Me.TabPage1.Controls.Add(Me.ddrB)
        Me.TabPage1.Controls.Add(Me.ddrA)
        Me.TabPage1.Controls.Add(Me.portD)
        Me.TabPage1.Controls.Add(Me.portC)
        Me.TabPage1.Controls.Add(Me.portB)
        Me.TabPage1.Controls.Add(Me.portA)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me._setAddressValueTextbox)
        Me.TabPage1.Controls.Add(Me._setAddressGuidTextbox)
        Me.TabPage1.Controls.Add(Me.setAddressButton)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(771, 230)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Основное"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'pinD
        '
        Me.pinD.Location = New System.Drawing.Point(693, 31)
        Me.pinD.Name = "pinD"
        Me.pinD.Size = New System.Drawing.Size(62, 20)
        Me.pinD.TabIndex = 25
        Me.pinD.Text = "00000000"
        '
        'pinC
        '
        Me.pinC.Location = New System.Drawing.Point(626, 31)
        Me.pinC.Name = "pinC"
        Me.pinC.Size = New System.Drawing.Size(62, 20)
        Me.pinC.TabIndex = 24
        Me.pinC.Text = "00000000"
        '
        'pinB
        '
        Me.pinB.Location = New System.Drawing.Point(558, 31)
        Me.pinB.Name = "pinB"
        Me.pinB.Size = New System.Drawing.Size(62, 20)
        Me.pinB.TabIndex = 23
        Me.pinB.Text = "00000000"
        '
        'pinA
        '
        Me.pinA.Location = New System.Drawing.Point(490, 32)
        Me.pinA.Name = "pinA"
        Me.pinA.Size = New System.Drawing.Size(62, 20)
        Me.pinA.TabIndex = 22
        Me.pinA.Text = "00000000"
        '
        'ddrD
        '
        Me.ddrD.Location = New System.Drawing.Point(392, 58)
        Me.ddrD.Name = "ddrD"
        Me.ddrD.Size = New System.Drawing.Size(62, 20)
        Me.ddrD.TabIndex = 21
        Me.ddrD.Text = "00000000"
        '
        'ddrC
        '
        Me.ddrC.Location = New System.Drawing.Point(325, 58)
        Me.ddrC.Name = "ddrC"
        Me.ddrC.Size = New System.Drawing.Size(62, 20)
        Me.ddrC.TabIndex = 20
        Me.ddrC.Text = "00000000"
        '
        'ddrB
        '
        Me.ddrB.Location = New System.Drawing.Point(257, 58)
        Me.ddrB.Name = "ddrB"
        Me.ddrB.Size = New System.Drawing.Size(62, 20)
        Me.ddrB.TabIndex = 19
        Me.ddrB.Text = "00000000"
        '
        'ddrA
        '
        Me.ddrA.Location = New System.Drawing.Point(189, 59)
        Me.ddrA.Name = "ddrA"
        Me.ddrA.Size = New System.Drawing.Size(62, 20)
        Me.ddrA.TabIndex = 18
        Me.ddrA.Text = "00000000"
        '
        'portD
        '
        Me.portD.Location = New System.Drawing.Point(392, 32)
        Me.portD.Name = "portD"
        Me.portD.Size = New System.Drawing.Size(62, 20)
        Me.portD.TabIndex = 17
        Me.portD.Text = "00000000"
        '
        'portC
        '
        Me.portC.Location = New System.Drawing.Point(325, 32)
        Me.portC.Name = "portC"
        Me.portC.Size = New System.Drawing.Size(62, 20)
        Me.portC.TabIndex = 16
        Me.portC.Text = "00000000"
        '
        'portB
        '
        Me.portB.Location = New System.Drawing.Point(257, 32)
        Me.portB.Name = "portB"
        Me.portB.Size = New System.Drawing.Size(62, 20)
        Me.portB.TabIndex = 15
        Me.portB.Text = "00000000"
        '
        'portA
        '
        Me.portA.Location = New System.Drawing.Point(189, 33)
        Me.portA.Name = "portA"
        Me.portA.Size = New System.Drawing.Size(62, 20)
        Me.portA.TabIndex = 14
        Me.portA.Text = "00000000"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(6, 58)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(177, 21)
        Me.Button2.TabIndex = 13
        Me.Button2.Text = "Считать входы-выходы"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(6, 32)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(177, 21)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "Записать входы-выходы"
        Me.Button1.UseVisualStyleBackColor = True
        '
        '_setAddressValueTextbox
        '
        Me._setAddressValueTextbox.Location = New System.Drawing.Point(353, 6)
        Me._setAddressValueTextbox.Name = "_setAddressValueTextbox"
        Me._setAddressValueTextbox.Size = New System.Drawing.Size(62, 20)
        Me._setAddressValueTextbox.TabIndex = 12
        Me._setAddressValueTextbox.Text = "0"
        '
        '_setAddressGuidTextbox
        '
        Me._setAddressGuidTextbox.Location = New System.Drawing.Point(111, 6)
        Me._setAddressGuidTextbox.Name = "_setAddressGuidTextbox"
        Me._setAddressGuidTextbox.Size = New System.Drawing.Size(236, 20)
        Me._setAddressGuidTextbox.TabIndex = 11
        Me._setAddressGuidTextbox.Text = "0"
        '
        'setAddressButton
        '
        Me.setAddressButton.Location = New System.Drawing.Point(5, 5)
        Me.setAddressButton.Name = "setAddressButton"
        Me.setAddressButton.Size = New System.Drawing.Size(100, 21)
        Me.setAddressButton.TabIndex = 10
        Me.setAddressButton.Text = "Уст. адрес"
        Me.setAddressButton.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
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
        Me.TabPage2.Size = New System.Drawing.Size(771, 230)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Бутлоадер"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'eraseProgramButton
        '
        Me.eraseProgramButton.Location = New System.Drawing.Point(6, 62)
        Me.eraseProgramButton.Name = "eraseProgramButton"
        Me.eraseProgramButton.Size = New System.Drawing.Size(98, 23)
        Me.eraseProgramButton.TabIndex = 17
        Me.eraseProgramButton.Text = "Очистить"
        Me.eraseProgramButton.UseVisualStyleBackColor = True
        '
        'gotoMain
        '
        Me.gotoMain.Location = New System.Drawing.Point(112, 7)
        Me.gotoMain.Name = "gotoMain"
        Me.gotoMain.Size = New System.Drawing.Size(100, 21)
        Me.gotoMain.TabIndex = 16
        Me.gotoMain.Text = "В основную"
        Me.gotoMain.UseVisualStyleBackColor = True
        '
        'programMemButton
        '
        Me.programMemButton.Location = New System.Drawing.Point(112, 62)
        Me.programMemButton.Name = "programMemButton"
        Me.programMemButton.Size = New System.Drawing.Size(99, 23)
        Me.programMemButton.TabIndex = 15
        Me.programMemButton.Text = "Прошивка"
        Me.programMemButton.UseVisualStyleBackColor = True
        '
        'goToBootloader
        '
        Me.goToBootloader.Location = New System.Drawing.Point(6, 6)
        Me.goToBootloader.Name = "goToBootloader"
        Me.goToBootloader.Size = New System.Drawing.Size(100, 21)
        Me.goToBootloader.TabIndex = 14
        Me.goToBootloader.Text = "В бутлоадер"
        Me.goToBootloader.UseVisualStyleBackColor = True
        '
        'signature
        '
        Me.signature.Location = New System.Drawing.Point(673, 59)
        Me.signature.Name = "signature"
        Me.signature.ReadOnly = True
        Me.signature.Size = New System.Drawing.Size(87, 20)
        Me.signature.TabIndex = 8
        Me.signature.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(578, 62)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Signature"
        '
        'progmemSizeTextbox
        '
        Me.progmemSizeTextbox.Location = New System.Drawing.Point(673, 33)
        Me.progmemSizeTextbox.Name = "progmemSizeTextbox"
        Me.progmemSizeTextbox.ReadOnly = True
        Me.progmemSizeTextbox.Size = New System.Drawing.Size(87, 20)
        Me.progmemSizeTextbox.TabIndex = 8
        Me.progmemSizeTextbox.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(578, 36)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "PROGMEM size"
        '
        'reqBootInfoButton
        '
        Me.reqBootInfoButton.Location = New System.Drawing.Point(6, 34)
        Me.reqBootInfoButton.Name = "reqBootInfoButton"
        Me.reqBootInfoButton.Size = New System.Drawing.Size(206, 21)
        Me.reqBootInfoButton.TabIndex = 5
        Me.reqBootInfoButton.Text = "Запрос парам. бутлоадера"
        Me.reqBootInfoButton.UseVisualStyleBackColor = True
        '
        'spmSizeTextbox
        '
        Me.spmSizeTextbox.Location = New System.Drawing.Point(673, 7)
        Me.spmSizeTextbox.Name = "spmSizeTextbox"
        Me.spmSizeTextbox.ReadOnly = True
        Me.spmSizeTextbox.Size = New System.Drawing.Size(87, 20)
        Me.spmSizeTextbox.TabIndex = 6
        Me.spmSizeTextbox.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(578, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "SPM size"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(644, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Адрес"
        '
        'devAddressTextbox
        '
        Me.devAddressTextbox.Location = New System.Drawing.Point(688, 87)
        Me.devAddressTextbox.Name = "devAddressTextbox"
        Me.devAddressTextbox.ReadOnly = True
        Me.devAddressTextbox.Size = New System.Drawing.Size(78, 20)
        Me.devAddressTextbox.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(447, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Дата прошивки"
        '
        'devDateTextbox
        '
        Me.devDateTextbox.Location = New System.Drawing.Point(542, 87)
        Me.devDateTextbox.Name = "devDateTextbox"
        Me.devDateTextbox.ReadOnly = True
        Me.devDateTextbox.Size = New System.Drawing.Size(87, 20)
        Me.devDateTextbox.TabIndex = 6
        '
        'reqAddressTextbox
        '
        Me.reqAddressTextbox.Location = New System.Drawing.Point(11, 35)
        Me.reqAddressTextbox.Name = "reqAddressTextbox"
        Me.reqAddressTextbox.Size = New System.Drawing.Size(100, 20)
        Me.reqAddressTextbox.TabIndex = 5
        Me.reqAddressTextbox.Text = "0"
        '
        'selfTestBustton
        '
        Me.selfTestBustton.Location = New System.Drawing.Point(11, 84)
        Me.selfTestBustton.Name = "selfTestBustton"
        Me.selfTestBustton.Size = New System.Drawing.Size(100, 21)
        Me.selfTestBustton.TabIndex = 4
        Me.selfTestBustton.Text = "Тест передачи"
        Me.selfTestBustton.UseVisualStyleBackColor = True
        '
        'getDevInfoButton
        '
        Me.getDevInfoButton.Location = New System.Drawing.Point(10, 60)
        Me.getDevInfoButton.Name = "getDevInfoButton"
        Me.getDevInfoButton.Size = New System.Drawing.Size(100, 21)
        Me.getDevInfoButton.TabIndex = 4
        Me.getDevInfoButton.Text = "Запрос инф."
        Me.getDevInfoButton.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(447, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Идентификатор"
        '
        'devguidTextbox
        '
        Me.devguidTextbox.Location = New System.Drawing.Point(542, 61)
        Me.devguidTextbox.Name = "devguidTextbox"
        Me.devguidTextbox.ReadOnly = True
        Me.devguidTextbox.Size = New System.Drawing.Size(224, 20)
        Me.devguidTextbox.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(447, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Имя устройства"
        '
        'devnameTextbox
        '
        Me.devnameTextbox.Location = New System.Drawing.Point(542, 35)
        Me.devnameTextbox.Name = "devnameTextbox"
        Me.devnameTextbox.ReadOnly = True
        Me.devnameTextbox.Size = New System.Drawing.Size(224, 20)
        Me.devnameTextbox.TabIndex = 0
        '
        'connectTimer
        '
        Me.connectTimer.Enabled = True
        Me.connectTimer.Interval = 2000
        '
        'DatagridLogWriter1
        '
        Me.DatagridLogWriter1.FilterText = ""
        Me.DatagridLogWriter1.Location = New System.Drawing.Point(1, 372)
        Me.DatagridLogWriter1.LogEnabled = True
        Me.DatagridLogWriter1.Margin = New System.Windows.Forms.Padding(0)
        Me.DatagridLogWriter1.Name = "DatagridLogWriter1"
        Me.DatagridLogWriter1.ShowDebug = False
        Me.DatagridLogWriter1.ShowErrors = True
        Me.DatagridLogWriter1.ShowInformation = True
        Me.DatagridLogWriter1.ShowMessages = True
        Me.DatagridLogWriter1.ShowWarnings = True
        Me.DatagridLogWriter1.Size = New System.Drawing.Size(778, 184)
        Me.DatagridLogWriter1.TabIndex = 10
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.НастройкиToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(781, 24)
        Me.MenuStrip1.TabIndex = 11
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'НастройкиToolStripMenuItem
        '
        Me.НастройкиToolStripMenuItem.Name = "НастройкиToolStripMenuItem"
        Me.НастройкиToolStripMenuItem.Size = New System.Drawing.Size(88, 20)
        Me.НастройкиToolStripMenuItem.Text = "Настройки..."
        '
        'SimplSerialTool
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(781, 562)
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
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "SimplSerialTool"
        Me.Text = "SimplSerialTool"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
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
    Friend WithEvents pinD As System.Windows.Forms.TextBox
    Friend WithEvents pinC As System.Windows.Forms.TextBox
    Friend WithEvents pinB As System.Windows.Forms.TextBox
    Friend WithEvents pinA As System.Windows.Forms.TextBox
    Friend WithEvents ddrD As System.Windows.Forms.TextBox
    Friend WithEvents ddrC As System.Windows.Forms.TextBox
    Friend WithEvents ddrB As System.Windows.Forms.TextBox
    Friend WithEvents ddrA As System.Windows.Forms.TextBox
    Friend WithEvents portD As System.Windows.Forms.TextBox
    Friend WithEvents portC As System.Windows.Forms.TextBox
    Friend WithEvents portB As System.Windows.Forms.TextBox
    Friend WithEvents portA As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DatagridLogWriter1 As Bwl.Framework.DatagridLogWriter
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents НастройкиToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button2 As System.Windows.Forms.Button

End Class
