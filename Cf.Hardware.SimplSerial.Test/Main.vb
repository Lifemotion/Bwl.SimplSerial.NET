Module Main

    Sub Main()
        Dim sserial = New SimplSerialBus("COM12")
        sserial.SerialDevice.Connect()

        Dim pins As New SimplSerialBus.Pins
        pins.Port4.PinDirection = 16 + 8
        pins.Port4.PinOutput = 8 '16-red, 8-green, 0-off
        sserial.RequestPinsChange(0, pins)


        Return
        Do
			' Dim tt = sserial.Read
			If sserial.Read.ResponseState = ResponseState.ok Then
				Stop
			End If
        Loop


        Crc16.Test()
        'StandardTests.DeviceSelfTest(sserial, 300)
        StandardTests.AddressSetupTest(sserial)
    End Sub

End Module
