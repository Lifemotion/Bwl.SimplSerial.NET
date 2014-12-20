Public Class SSResponse
    Sub New()

    End Sub
    Public Property Result As Byte
    Public Property ResponseState As ResponseState
    Public Property FromAddress As UInt16
    Public Property Data As Byte() = {}
End Class

Public Enum ResponseState
    ok
    errorTimeout
    errorFormat
    errorCrc
    errorPacketType
    errorNotRequested
    errorPortError
End Enum
