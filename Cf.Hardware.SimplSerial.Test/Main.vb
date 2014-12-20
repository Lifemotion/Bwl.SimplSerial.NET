Module Main

    Sub Main()
        Dim sserial = New SimplSerialBus("COM6")
        sserial.SerialDevice.Connect()
        Do
            Dim tt = sserial.Read
            If tt.ResponseState = ResponseState.ok Then
                Stop
            End If
        Loop


        Crc16.Test()
        'StandardTests.DeviceSelfTest(sserial, 300)
        StandardTests.AddressSetupTest(sserial)
    End Sub

End Module
