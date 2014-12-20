Public Class Main
    Public Shared AppBase As New AppBase(True)
    Public Shared Sub Main()

        Dim tool = New SimplSerialTool(Nothing, AppBase.RootStorage, AppBase.RootLogger)
        Application.EnableVisualStyles()
        Application.Run(tool)
    End Sub
End Class
