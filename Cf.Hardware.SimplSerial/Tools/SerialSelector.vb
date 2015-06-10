Public Class SerialSelector

    Private Sub SerialSelector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.AddRange(IO.Ports.SerialPort.GetPortNames)
        If ComboBox1.Items.Count > 0 Then ComboBox1.SelectedIndex = 0
    End Sub

    Public Property AssociatedISerialDevice As ISerialDevice


    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged, ComboBox1.SelectedValueChanged
        If AssociatedISerialDevice IsNot Nothing Then
            With AssociatedISerialDevice
                Try
                    Dim wasConnected = .IsConnected
                    .Disconnect()
                    .DeviceAddress = ComboBox1.Text
                    .DeviceSpeed = Val(ComboBox2.Text)
                    '  If wasConnected Then .Connect()
                Catch ex As Exception
                End Try
            End With
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim text = ComboBox1.Text
        ComboBox1.Items.Clear()
        ComboBox1.Items.AddRange(IO.Ports.SerialPort.GetPortNames)
        ComboBox1.Text = text
    End Sub
End Class
