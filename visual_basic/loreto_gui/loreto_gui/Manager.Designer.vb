<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Manager
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Manager))
        Me.Title = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Avatar = New System.Windows.Forms.PictureBox()
        Me.Timetable = New System.Windows.Forms.ListBox()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        CType(Me.Avatar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Title
        '
        Me.Title.AutoSize = True
        Me.Title.Font = New System.Drawing.Font("Century Gothic", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title.Location = New System.Drawing.Point(125, 9)
        Me.Title.Name = "Title"
        Me.Title.Size = New System.Drawing.Size(198, 23)
        Me.Title.TabIndex = 0
        Me.Title.Text = "Jeremiah's Loreto.py"
        Me.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Avatar
        '
        Me.Avatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Avatar.InitialImage = Nothing
        Me.Avatar.Location = New System.Drawing.Point(12, 44)
        Me.Avatar.Name = "Avatar"
        Me.Avatar.Size = New System.Drawing.Size(98, 124)
        Me.Avatar.TabIndex = 1
        Me.Avatar.TabStop = False
        '
        'Timetable
        '
        Me.Timetable.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Timetable.FormattingEnabled = True
        Me.Timetable.ItemHeight = 20
        Me.Timetable.Location = New System.Drawing.Point(126, 44)
        Me.Timetable.Name = "Timetable"
        Me.Timetable.Size = New System.Drawing.Size(325, 124)
        Me.Timetable.TabIndex = 2
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'Manager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(463, 181)
        Me.Controls.Add(Me.Timetable)
        Me.Controls.Add(Me.Avatar)
        Me.Controls.Add(Me.Title)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Manager"
        Me.Text = "Manager"
        CType(Me.Avatar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Title As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Avatar As PictureBox
    Friend WithEvents Timetable As ListBox
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents HelpProvider1 As HelpProvider
End Class
