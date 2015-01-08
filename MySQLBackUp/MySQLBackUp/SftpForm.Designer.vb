<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SftpForm
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
        Me.SFTPOKButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SFTPUsername = New System.Windows.Forms.TextBox()
        Me.SFTPPassword = New System.Windows.Forms.TextBox()
        Me.SFTPServer = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'SFTPOKButton
        '
        Me.SFTPOKButton.Location = New System.Drawing.Point(104, 226)
        Me.SFTPOKButton.Name = "SFTPOKButton"
        Me.SFTPOKButton.Size = New System.Drawing.Size(75, 23)
        Me.SFTPOKButton.TabIndex = 0
        Me.SFTPOKButton.Text = "OK"
        Me.SFTPOKButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Username : "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Password : "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 149)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Server : "
        '
        'SFTPUsername
        '
        Me.SFTPUsername.Location = New System.Drawing.Point(145, 45)
        Me.SFTPUsername.Name = "SFTPUsername"
        Me.SFTPUsername.Size = New System.Drawing.Size(100, 20)
        Me.SFTPUsername.TabIndex = 4
        '
        'SFTPPassword
        '
        Me.SFTPPassword.Location = New System.Drawing.Point(145, 97)
        Me.SFTPPassword.Name = "SFTPPassword"
        Me.SFTPPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(64)
        Me.SFTPPassword.Size = New System.Drawing.Size(100, 20)
        Me.SFTPPassword.TabIndex = 5
        '
        'SFTPServer
        '
        Me.SFTPServer.Location = New System.Drawing.Point(145, 149)
        Me.SFTPServer.Name = "SFTPServer"
        Me.SFTPServer.Size = New System.Drawing.Size(100, 20)
        Me.SFTPServer.TabIndex = 6
        '
        'SftpForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.SFTPServer)
        Me.Controls.Add(Me.SFTPPassword)
        Me.Controls.Add(Me.SFTPUsername)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SFTPOKButton)
        Me.Name = "SftpForm"
        Me.Text = "SFTP CREDENTIALS"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SFTPOKButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SFTPUsername As System.Windows.Forms.TextBox
    Friend WithEvents SFTPPassword As System.Windows.Forms.TextBox
    Friend WithEvents SFTPServer As System.Windows.Forms.TextBox
End Class
