Module StandardTests
    Public Sub DeviceSelfTest(sserial As SimplSerialBus, maxSize As Integer)
        Do
            Dim rnd As New Random
            Dim n = 0, errs = 0
            Do
                Dim length = rnd.Next(1, maxSize)
                Dim list As New List(Of Byte)
                For i = 1 To length
                    list.Add(rnd.Next(0, 255))
                Next
                Try
                    sserial.RequestTestDevice(0, list.ToArray)
                Catch ex As Exception
                    Console.WriteLine(ex.Message) : errs += 1
                End Try
                n += 1
                If n Mod 10 = 0 Then Console.WriteLine("Exps: " + n.ToString + ", errs: " + errs.ToString + ", last " + length.ToString)
            Loop
        Loop
    End Sub

    Public Sub AddressSetupTest(sserial As SimplSerialBus)
        Dim n = 0, errs = 0
        Do
            Try
                SimplSerialBus.Tests.AddressSetupTest(sserial)
            Catch ex As Exception
                Console.WriteLine(ex.Message) : errs += 1
            End Try
            n += 1
            If n Mod 2 = 0 Then Console.WriteLine("Exps: " + n.ToString + ", errs: " + errs.ToString)
        Loop
    End Sub
End Module
