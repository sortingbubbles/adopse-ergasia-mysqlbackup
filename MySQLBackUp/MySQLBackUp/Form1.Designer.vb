<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.FirstTabUsername = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FirstTab = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Tab2Pwd = New System.Windows.Forms.TextBox()
        Me.Tab2Uid = New System.Windows.Forms.TextBox()
        Me.Tab2DataBase = New System.Windows.Forms.TextBox()
        Me.Tab2Server = New System.Windows.Forms.TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Tab3Email = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.SFTP = New System.Windows.Forms.RadioButton()
        Me.GoogleDrive = New System.Windows.Forms.RadioButton()
        Me.OneDrive = New System.Windows.Forms.RadioButton()
        Me.Box = New System.Windows.Forms.RadioButton()
        Me.DropBox = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabControl1.ItemSize = New System.Drawing.Size(30, 120)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(371, 267)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.FirstTabUsername)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.FirstTab)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(124, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(243, 259)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "STEP 1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'FirstTabUsername
        '
        Me.FirstTabUsername.Location = New System.Drawing.Point(72, 67)
        Me.FirstTabUsername.Name = "FirstTabUsername"
        Me.FirstTabUsername.Size = New System.Drawing.Size(154, 20)
        Me.FirstTabUsername.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "username :"
        '
        'FirstTab
        '
        Me.FirstTab.Location = New System.Drawing.Point(81, 192)
        Me.FirstTab.Name = "FirstTab"
        Me.FirstTab.Size = New System.Drawing.Size(75, 23)
        Me.FirstTab.TabIndex = 1
        Me.FirstTab.Text = "Next"
        Me.FirstTab.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(232, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Define a username to identify the process"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Button1)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.Tab2Pwd)
        Me.TabPage2.Controls.Add(Me.Tab2Uid)
        Me.TabPage2.Controls.Add(Me.Tab2DataBase)
        Me.TabPage2.Controls.Add(Me.Tab2Server)
        Me.TabPage2.Location = New System.Drawing.Point(124, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(243, 259)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "STEP 2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(65, 218)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Next"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(25, 179)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 15)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Password :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(25, 125)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 15)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Username :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(25, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 15)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "DataBase :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Server :"
        '
        'Tab2Pwd
        '
        Me.Tab2Pwd.Location = New System.Drawing.Point(135, 172)
        Me.Tab2Pwd.Name = "Tab2Pwd"
        Me.Tab2Pwd.Size = New System.Drawing.Size(100, 20)
        Me.Tab2Pwd.TabIndex = 3
        '
        'Tab2Uid
        '
        Me.Tab2Uid.Location = New System.Drawing.Point(135, 125)
        Me.Tab2Uid.Name = "Tab2Uid"
        Me.Tab2Uid.Size = New System.Drawing.Size(100, 20)
        Me.Tab2Uid.TabIndex = 2
        '
        'Tab2DataBase
        '
        Me.Tab2DataBase.Location = New System.Drawing.Point(135, 77)
        Me.Tab2DataBase.Name = "Tab2DataBase"
        Me.Tab2DataBase.Size = New System.Drawing.Size(100, 20)
        Me.Tab2DataBase.TabIndex = 1
        '
        'Tab2Server
        '
        Me.Tab2Server.Location = New System.Drawing.Point(135, 37)
        Me.Tab2Server.Name = "Tab2Server"
        Me.Tab2Server.Size = New System.Drawing.Size(100, 20)
        Me.Tab2Server.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Tab3Email)
        Me.TabPage3.Controls.Add(Me.Label8)
        Me.TabPage3.Controls.Add(Me.Label7)
        Me.TabPage3.Controls.Add(Me.Button2)
        Me.TabPage3.Location = New System.Drawing.Point(124, 4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(243, 259)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "STEP 3"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Tab3Email
        '
        Me.Tab3Email.Location = New System.Drawing.Point(63, 86)
        Me.Tab3Email.Name = "Tab3Email"
        Me.Tab3Email.Size = New System.Drawing.Size(172, 20)
        Me.Tab3Email.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(19, 86)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 15)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Email :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(50, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(168, 15)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Define the confirmation email"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(67, 223)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 0
        Me.Button2.Text = "Next"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.SFTP)
        Me.TabPage4.Controls.Add(Me.GoogleDrive)
        Me.TabPage4.Controls.Add(Me.OneDrive)
        Me.TabPage4.Controls.Add(Me.Box)
        Me.TabPage4.Controls.Add(Me.DropBox)
        Me.TabPage4.Controls.Add(Me.Label9)
        Me.TabPage4.Controls.Add(Me.Button8)
        Me.TabPage4.Location = New System.Drawing.Point(124, 4)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(243, 259)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "STEP 4"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'SFTP
        '
        Me.SFTP.Appearance = System.Windows.Forms.Appearance.Button
        Me.SFTP.AutoSize = True
        Me.SFTP.Image = Global.MySQLBackUp.My.Resources.Resources.sftp
        Me.SFTP.Location = New System.Drawing.Point(25, 146)
        Me.SFTP.Name = "SFTP"
        Me.SFTP.Size = New System.Drawing.Size(54, 38)
        Me.SFTP.TabIndex = 11
        Me.SFTP.TabStop = True
        Me.SFTP.UseVisualStyleBackColor = True
        '
        'GoogleDrive
        '
        Me.GoogleDrive.Appearance = System.Windows.Forms.Appearance.Button
        Me.GoogleDrive.AutoSize = True
        Me.GoogleDrive.Image = Global.MySQLBackUp.My.Resources.Resources.googledrive
        Me.GoogleDrive.Location = New System.Drawing.Point(165, 72)
        Me.GoogleDrive.Name = "GoogleDrive"
        Me.GoogleDrive.Size = New System.Drawing.Size(54, 54)
        Me.GoogleDrive.TabIndex = 10
        Me.GoogleDrive.TabStop = True
        Me.GoogleDrive.UseVisualStyleBackColor = True
        '
        'OneDrive
        '
        Me.OneDrive.Appearance = System.Windows.Forms.Appearance.Button
        Me.OneDrive.AutoSize = True
        Me.OneDrive.Image = Global.MySQLBackUp.My.Resources.Resources.onedrive
        Me.OneDrive.Location = New System.Drawing.Point(154, 142)
        Me.OneDrive.Name = "OneDrive"
        Me.OneDrive.Size = New System.Drawing.Size(56, 46)
        Me.OneDrive.TabIndex = 9
        Me.OneDrive.TabStop = True
        Me.OneDrive.UseVisualStyleBackColor = True
        '
        'Box
        '
        Me.Box.Appearance = System.Windows.Forms.Appearance.Button
        Me.Box.AutoSize = True
        Me.Box.Image = Global.MySQLBackUp.My.Resources.Resources.box
        Me.Box.Location = New System.Drawing.Point(95, 72)
        Me.Box.Name = "Box"
        Me.Box.Size = New System.Drawing.Size(46, 46)
        Me.Box.TabIndex = 8
        Me.Box.TabStop = True
        Me.Box.UseVisualStyleBackColor = True
        '
        'DropBox
        '
        Me.DropBox.Appearance = System.Windows.Forms.Appearance.Button
        Me.DropBox.AutoSize = True
        Me.DropBox.Image = Global.MySQLBackUp.My.Resources.Resources.dropbox
        Me.DropBox.Location = New System.Drawing.Point(25, 68)
        Me.DropBox.Name = "DropBox"
        Me.DropBox.Size = New System.Drawing.Size(54, 54)
        Me.DropBox.TabIndex = 7
        Me.DropBox.TabStop = True
        Me.DropBox.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(61, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(138, 15)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Select the cloud storage"
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(80, 217)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 23)
        Me.Button8.TabIndex = 5
        Me.Button8.Text = "Next"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(371, 267)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Form1"
        Me.Text = "MySQLBackUp"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents FirstTabUsername As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents FirstTab As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Tab2Pwd As System.Windows.Forms.TextBox
    Friend WithEvents Tab2Uid As System.Windows.Forms.TextBox
    Friend WithEvents Tab2DataBase As System.Windows.Forms.TextBox
    Friend WithEvents Tab2Server As System.Windows.Forms.TextBox
    Friend WithEvents Tab3Email As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents SFTP As System.Windows.Forms.RadioButton
    Friend WithEvents GoogleDrive As System.Windows.Forms.RadioButton
    Friend WithEvents OneDrive As System.Windows.Forms.RadioButton
    Friend WithEvents Box As System.Windows.Forms.RadioButton
    Friend WithEvents DropBox As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button8 As System.Windows.Forms.Button

End Class
