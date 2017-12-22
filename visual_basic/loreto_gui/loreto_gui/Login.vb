Public Class Login
    Dim curDir As String = FileSystem.CurDir

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MsgBox(curDir)
        Me.Text = "Login to Loreto.py"
        Dim path As String = curDir + "\loreto_data\auth"
        Dim script As String = ""
        If System.IO.File.Exists(path) Then
            Me.Visible = False
            Dim auth As String = My.Computer.FileSystem.ReadAllText(path)
            Dim key As String() = auth.Split(vbCr)
            script = curDir + "\python\python.exe " + curDir + "\loreto.py "
            script += curDir + " " + key(0) + " " + key(1)
            MsgBox(script)
            MsgBox(Shell(script))
            End
        Else
            Me.Visible = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim script As String = ""
        If Me.username.Text <> "" And Me.password.Text <> "" Then
            script += curDir + "\python\python.exe " + curDir + "\loreto.py " + curDir
            script += " " + username.Text + " " + password.Text
            MsgBox(script)
            MsgBox(Shell(script))
        Else
            MsgBox("Please enter a username and password.")
        End If
    End Sub
End Class
