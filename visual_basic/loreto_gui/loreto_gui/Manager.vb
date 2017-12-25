Public Class Manager
    Private Sub Manager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Visible = False
    End Sub
    Public Sub loadManager()
        Me.Visible = True
        Login.Visible = False
        Dim curDir As String = Login.curDir
        If System.IO.File.Exists(curDir + "/loreto_data/dump") Then
            Dim contents As String = My.Computer.FileSystem.ReadAllText(curDir + "/loreto_data/dump")
            Dim full As String() = contents.Split(vbCr)
            Dim name As String = full(0)
            Dim timetable As New List(Of String)
            For Each item In full(1).Split("|")
                timetable.Add(item)
            Next
            Title.Text = name.Split("|")(0) + "'s Loreto.py:"
            Avatar.BackgroundImage = Image.FromFile(curDir + "/downloads/avatar.jpeg")
            Avatar.BackgroundImageLayout = ImageLayout.Stretch
            For Each item In timetable
                Me.Timetable.Items.Add(item)
            Next
        Else
            MsgBox("The login attempt failed.")
            Me.Visible = False
            Login.Visible = True
        End If
    End Sub
End Class