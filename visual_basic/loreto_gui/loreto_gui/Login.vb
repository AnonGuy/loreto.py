Public Class Login
    Public curDir As String = FileSystem.CurDir

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim args As String = ""
        Me.Text = "Login to Loreto.py"
        Dim path As String = curDir + "\loreto_data\auth"
        If System.IO.File.Exists(path) Then
            Me.Visible = False
            Dim auth As String = My.Computer.FileSystem.ReadAllText(path)
            Dim key As String() = auth.Split(vbCr)
            args = curDir + "\loreto.pyw "
            args += curDir + " " + key(0) + " " + key(1)
            Dim loreto As Process = Process.Start(curDir + "\python\python.exe", args)
            loreto.WaitForExit()
            Manager.loadManager()
        Else
            Me.Visible = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim args As String = ""
        If Me.username.Text <> "" And Me.password.Text <> "" Then
            args = curDir + "\loreto.pyw " + curDir
            args += " " + username.Text.Replace(ControlChars.Quote, "\""") + " " + password.Text.Replace(ControlChars.Quote, "\""")
            Dim path As String = curDir + "\python\python.exe"
            Dim loreto As Process = Process.Start(path, args)
            Me.Visible = False
            loreto.WaitForExit()
            Manager.loadManager()
        Else
            MsgBox("Please enter a username and password.")
        End If
    End Sub
End Class
