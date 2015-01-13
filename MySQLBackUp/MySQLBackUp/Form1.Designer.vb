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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.FirstTabUsername = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FirstTab = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ShowDB = New System.Windows.Forms.Button()
        Me.DatabasesCheckedListBox = New System.Windows.Forms.CheckedListBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.SecondTab = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Tab2Pwd = New System.Windows.Forms.TextBox()
        Me.Tab2Uid = New System.Windows.Forms.TextBox()
        Me.Tab2Server = New System.Windows.Forms.TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Tab3Email = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ThirdTab = New System.Windows.Forms.Button()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.DropBoxButton = New System.Windows.Forms.Button()
        Me.BoxButton = New System.Windows.Forms.Button()
        Me.SFTPButton = New System.Windows.Forms.Button()
        Me.OneDriveButton = New System.Windows.Forms.Button()
        Me.GoogleDriveButton = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.FourtTab = New System.Windows.Forms.Button()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.DaysInterval = New System.Windows.Forms.NumericUpDown()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.FifthTab = New System.Windows.Forms.Button()
        Me.SecondsCombo = New System.Windows.Forms.ComboBox()
        Me.MinuteCombo = New System.Windows.Forms.ComboBox()
        Me.HourCombo = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Hour = New System.Windows.Forms.Label()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Twitter = New System.Windows.Forms.Button()
        Me.Facebook = New System.Windows.Forms.Button()
        Me.GooglePlus = New System.Windows.Forms.Button()
        Me.ToolTipEmail = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        CType(Me.DaysInterval, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage6.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabControl1.ItemSize = New System.Drawing.Size(30, 120)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(451, 295)
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
        Me.TabPage1.Size = New System.Drawing.Size(323, 287)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "STEP 1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'FirstTabUsername
        '
        Me.FirstTabUsername.Location = New System.Drawing.Point(100, 64)
        Me.FirstTabUsername.Name = "FirstTabUsername"
        Me.FirstTabUsername.Size = New System.Drawing.Size(180, 20)
        Me.FirstTabUsername.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "username :"
        '
        'FirstTab
        '
        Me.FirstTab.Location = New System.Drawing.Point(120, 200)
        Me.FirstTab.Name = "FirstTab"
        Me.FirstTab.Size = New System.Drawing.Size(75, 23)
        Me.FirstTab.TabIndex = 1
        Me.FirstTab.Text = "Next"
        Me.FirstTab.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Monotype Corsiva", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(285, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Define a username to identify the process"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ShowDB)
        Me.TabPage2.Controls.Add(Me.DatabasesCheckedListBox)
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Controls.Add(Me.SecondTab)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.Tab2Pwd)
        Me.TabPage2.Controls.Add(Me.Tab2Uid)
        Me.TabPage2.Controls.Add(Me.Tab2Server)
        Me.TabPage2.Location = New System.Drawing.Point(124, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(323, 287)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "STEP 2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ShowDB
        '
        Me.ShowDB.Location = New System.Drawing.Point(125, 142)
        Me.ShowDB.Name = "ShowDB"
        Me.ShowDB.Size = New System.Drawing.Size(158, 23)
        Me.ShowDB.TabIndex = 11
        Me.ShowDB.Text = "Show Databases"
        Me.ShowDB.UseVisualStyleBackColor = True
        '
        'DatabasesCheckedListBox
        '
        Me.DatabasesCheckedListBox.CheckOnClick = True
        Me.DatabasesCheckedListBox.FormattingEnabled = True
        Me.DatabasesCheckedListBox.Location = New System.Drawing.Point(125, 177)
        Me.DatabasesCheckedListBox.Name = "DatabasesCheckedListBox"
        Me.DatabasesCheckedListBox.Size = New System.Drawing.Size(158, 64)
        Me.DatabasesCheckedListBox.TabIndex = 10
        Me.DatabasesCheckedListBox.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Monotype Corsiva", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label16.Location = New System.Drawing.Point(62, 5)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(192, 22)
        Me.Label16.TabIndex = 9
        Me.Label16.Text = "MySQL Databases Info"
        '
        'SecondTab
        '
        Me.SecondTab.Location = New System.Drawing.Point(125, 256)
        Me.SecondTab.Name = "SecondTab"
        Me.SecondTab.Size = New System.Drawing.Size(75, 23)
        Me.SecondTab.TabIndex = 8
        Me.SecondTab.Text = "Next"
        Me.SecondTab.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(26, 109)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Password :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(26, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Username :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(26, 177)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "DataBase :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Server :"
        '
        'Tab2Pwd
        '
        Me.Tab2Pwd.Location = New System.Drawing.Point(125, 106)
        Me.Tab2Pwd.Name = "Tab2Pwd"
        Me.Tab2Pwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Tab2Pwd.Size = New System.Drawing.Size(158, 20)
        Me.Tab2Pwd.TabIndex = 3
        '
        'Tab2Uid
        '
        Me.Tab2Uid.Location = New System.Drawing.Point(125, 70)
        Me.Tab2Uid.Name = "Tab2Uid"
        Me.Tab2Uid.Size = New System.Drawing.Size(158, 20)
        Me.Tab2Uid.TabIndex = 2
        '
        'Tab2Server
        '
        Me.Tab2Server.Location = New System.Drawing.Point(125, 34)
        Me.Tab2Server.Name = "Tab2Server"
        Me.Tab2Server.Size = New System.Drawing.Size(158, 20)
        Me.Tab2Server.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Tab3Email)
        Me.TabPage3.Controls.Add(Me.Label8)
        Me.TabPage3.Controls.Add(Me.Label7)
        Me.TabPage3.Controls.Add(Me.ThirdTab)
        Me.TabPage3.Location = New System.Drawing.Point(124, 4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(323, 287)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "STEP 3"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Tab3Email
        '
        Me.Tab3Email.Location = New System.Drawing.Point(91, 67)
        Me.Tab3Email.Name = "Tab3Email"
        Me.Tab3Email.Size = New System.Drawing.Size(194, 20)
        Me.Tab3Email.TabIndex = 3
        Me.ToolTipEmail.SetToolTip(Me.Tab3Email, "Seperate the databases  with a ','")
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(40, 70)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Email :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Monotype Corsiva", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label7.Location = New System.Drawing.Point(58, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(206, 18)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Define the confirmation email"
        '
        'ThirdTab
        '
        Me.ThirdTab.Location = New System.Drawing.Point(124, 198)
        Me.ThirdTab.Name = "ThirdTab"
        Me.ThirdTab.Size = New System.Drawing.Size(75, 23)
        Me.ThirdTab.TabIndex = 0
        Me.ThirdTab.Text = "Next"
        Me.ThirdTab.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.DropBoxButton)
        Me.TabPage4.Controls.Add(Me.BoxButton)
        Me.TabPage4.Controls.Add(Me.SFTPButton)
        Me.TabPage4.Controls.Add(Me.OneDriveButton)
        Me.TabPage4.Controls.Add(Me.GoogleDriveButton)
        Me.TabPage4.Controls.Add(Me.Label9)
        Me.TabPage4.Controls.Add(Me.FourtTab)
        Me.TabPage4.Location = New System.Drawing.Point(124, 4)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(323, 287)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "STEP 4"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'DropBoxButton
        '
        Me.DropBoxButton.Image = Global.MySQLBackUp.My.Resources.Resources.dropbox
        Me.DropBoxButton.Location = New System.Drawing.Point(91, 140)
        Me.DropBoxButton.Name = "DropBoxButton"
        Me.DropBoxButton.Size = New System.Drawing.Size(54, 50)
        Me.DropBoxButton.TabIndex = 11
        Me.DropBoxButton.UseVisualStyleBackColor = True
        '
        'BoxButton
        '
        Me.BoxButton.Image = Global.MySQLBackUp.My.Resources.Resources.box
        Me.BoxButton.Location = New System.Drawing.Point(176, 140)
        Me.BoxButton.Name = "BoxButton"
        Me.BoxButton.Size = New System.Drawing.Size(56, 50)
        Me.BoxButton.TabIndex = 10
        Me.BoxButton.UseVisualStyleBackColor = True
        '
        'SFTPButton
        '
        Me.SFTPButton.Image = Global.MySQLBackUp.My.Resources.Resources.sftp
        Me.SFTPButton.Location = New System.Drawing.Point(225, 68)
        Me.SFTPButton.Name = "SFTPButton"
        Me.SFTPButton.Size = New System.Drawing.Size(53, 55)
        Me.SFTPButton.TabIndex = 9
        Me.SFTPButton.UseVisualStyleBackColor = True
        '
        'OneDriveButton
        '
        Me.OneDriveButton.Image = Global.MySQLBackUp.My.Resources.Resources.onedrive
        Me.OneDriveButton.Location = New System.Drawing.Point(127, 68)
        Me.OneDriveButton.Name = "OneDriveButton"
        Me.OneDriveButton.Size = New System.Drawing.Size(65, 55)
        Me.OneDriveButton.TabIndex = 8
        Me.OneDriveButton.UseVisualStyleBackColor = True
        '
        'GoogleDriveButton
        '
        Me.GoogleDriveButton.Image = Global.MySQLBackUp.My.Resources.Resources.googledrive
        Me.GoogleDriveButton.Location = New System.Drawing.Point(43, 68)
        Me.GoogleDriveButton.Name = "GoogleDriveButton"
        Me.GoogleDriveButton.Size = New System.Drawing.Size(52, 55)
        Me.GoogleDriveButton.TabIndex = 7
        Me.GoogleDriveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.GoogleDriveButton.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Monotype Corsiva", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label9.Location = New System.Drawing.Point(67, 14)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(165, 18)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Select the cloud storage"
        '
        'FourtTab
        '
        Me.FourtTab.Location = New System.Drawing.Point(127, 217)
        Me.FourtTab.Name = "FourtTab"
        Me.FourtTab.Size = New System.Drawing.Size(75, 23)
        Me.FourtTab.TabIndex = 5
        Me.FourtTab.Text = "Next"
        Me.FourtTab.UseVisualStyleBackColor = True
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.Label17)
        Me.TabPage5.Controls.Add(Me.DaysInterval)
        Me.TabPage5.Controls.Add(Me.Label13)
        Me.TabPage5.Controls.Add(Me.Label10)
        Me.TabPage5.Controls.Add(Me.FifthTab)
        Me.TabPage5.Controls.Add(Me.SecondsCombo)
        Me.TabPage5.Controls.Add(Me.MinuteCombo)
        Me.TabPage5.Controls.Add(Me.HourCombo)
        Me.TabPage5.Controls.Add(Me.Label12)
        Me.TabPage5.Controls.Add(Me.Label11)
        Me.TabPage5.Controls.Add(Me.Hour)
        Me.TabPage5.Location = New System.Drawing.Point(124, 4)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(323, 287)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "STEP 5"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Monotype Corsiva", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(26, 15)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(261, 25)
        Me.Label17.TabIndex = 10
        Me.Label17.Text = "Create The BackUp Scheduler"
        '
        'DaysInterval
        '
        Me.DaysInterval.Location = New System.Drawing.Point(138, 151)
        Me.DaysInterval.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.DaysInterval.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.DaysInterval.Name = "DaysInterval"
        Me.DaysInterval.ReadOnly = True
        Me.DaysInterval.Size = New System.Drawing.Size(42, 20)
        Me.DaysInterval.TabIndex = 9
        Me.DaysInterval.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(200, 153)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(31, 13)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "Days"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(48, 153)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(85, 13)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "BackUp Every : "
        '
        'FifthTab
        '
        Me.FifthTab.Location = New System.Drawing.Point(121, 223)
        Me.FifthTab.Name = "FifthTab"
        Me.FifthTab.Size = New System.Drawing.Size(75, 23)
        Me.FifthTab.TabIndex = 6
        Me.FifthTab.Text = "Finish"
        Me.FifthTab.UseVisualStyleBackColor = True
        '
        'SecondsCombo
        '
        Me.SecondsCombo.FormattingEnabled = True
        Me.SecondsCombo.Location = New System.Drawing.Point(224, 97)
        Me.SecondsCombo.Name = "SecondsCombo"
        Me.SecondsCombo.Size = New System.Drawing.Size(42, 21)
        Me.SecondsCombo.TabIndex = 5
        '
        'MinuteCombo
        '
        Me.MinuteCombo.FormattingEnabled = True
        Me.MinuteCombo.Location = New System.Drawing.Point(138, 97)
        Me.MinuteCombo.Name = "MinuteCombo"
        Me.MinuteCombo.Size = New System.Drawing.Size(42, 21)
        Me.MinuteCombo.TabIndex = 4
        '
        'HourCombo
        '
        Me.HourCombo.FormattingEnabled = True
        Me.HourCombo.Location = New System.Drawing.Point(63, 97)
        Me.HourCombo.Name = "HourCombo"
        Me.HourCombo.Size = New System.Drawing.Size(42, 21)
        Me.HourCombo.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(222, 56)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 13)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Second"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(135, 56)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Minute"
        '
        'Hour
        '
        Me.Hour.AutoSize = True
        Me.Hour.Location = New System.Drawing.Point(60, 56)
        Me.Hour.Name = "Hour"
        Me.Hour.Size = New System.Drawing.Size(30, 13)
        Me.Hour.TabIndex = 0
        Me.Hour.Text = "Hour"
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.Label15)
        Me.TabPage6.Controls.Add(Me.Label14)
        Me.TabPage6.Controls.Add(Me.Twitter)
        Me.TabPage6.Controls.Add(Me.Facebook)
        Me.TabPage6.Controls.Add(Me.GooglePlus)
        Me.TabPage6.Location = New System.Drawing.Point(124, 4)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(323, 287)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "STEP 6"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Monotype Corsiva", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label15.Location = New System.Drawing.Point(83, 65)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(133, 25)
        Me.Label15.TabIndex = 4
        Me.Label15.Text = "Find  us  on  :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Monotype Corsiva", 14.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label14.Location = New System.Drawing.Point(84, 21)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(117, 22)
        Me.Label14.TabIndex = 3
        Me.Label14.Text = "Task Created !!!"
        '
        'Twitter
        '
        Me.Twitter.Image = Global.MySQLBackUp.My.Resources.Resources.twitter
        Me.Twitter.Location = New System.Drawing.Point(131, 181)
        Me.Twitter.Name = "Twitter"
        Me.Twitter.Size = New System.Drawing.Size(57, 59)
        Me.Twitter.TabIndex = 2
        Me.Twitter.UseVisualStyleBackColor = True
        '
        'Facebook
        '
        Me.Facebook.Image = Global.MySQLBackUp.My.Resources.Resources.facebook
        Me.Facebook.Location = New System.Drawing.Point(186, 102)
        Me.Facebook.Name = "Facebook"
        Me.Facebook.Size = New System.Drawing.Size(62, 62)
        Me.Facebook.TabIndex = 1
        Me.Facebook.UseVisualStyleBackColor = True
        '
        'GooglePlus
        '
        Me.GooglePlus.Image = Global.MySQLBackUp.My.Resources.Resources.googlePlus
        Me.GooglePlus.Location = New System.Drawing.Point(80, 102)
        Me.GooglePlus.Name = "GooglePlus"
        Me.GooglePlus.Size = New System.Drawing.Size(58, 63)
        Me.GooglePlus.TabIndex = 0
        Me.GooglePlus.UseVisualStyleBackColor = True
        '
        'ToolTipEmail
        '
        Me.ToolTipEmail.ToolTipTitle = "Seperate the emails  with a ','"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(451, 295)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
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
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        CType(Me.DaysInterval, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage6.PerformLayout()
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
    Friend WithEvents SecondTab As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Tab2Pwd As System.Windows.Forms.TextBox
    Friend WithEvents Tab2Uid As System.Windows.Forms.TextBox
    Friend WithEvents Tab2Server As System.Windows.Forms.TextBox
    Friend WithEvents Tab3Email As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ThirdTab As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents FourtTab As System.Windows.Forms.Button
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents FifthTab As System.Windows.Forms.Button
    Friend WithEvents SecondsCombo As System.Windows.Forms.ComboBox
    Friend WithEvents MinuteCombo As System.Windows.Forms.ComboBox
    Friend WithEvents HourCombo As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Hour As System.Windows.Forms.Label
    Friend WithEvents DropBoxButton As System.Windows.Forms.Button
    Friend WithEvents BoxButton As System.Windows.Forms.Button
    Friend WithEvents SFTPButton As System.Windows.Forms.Button
    Friend WithEvents OneDriveButton As System.Windows.Forms.Button
    Friend WithEvents GoogleDriveButton As System.Windows.Forms.Button
    Friend WithEvents DaysInterval As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ToolTipEmail As System.Windows.Forms.ToolTip
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Twitter As System.Windows.Forms.Button
    Friend WithEvents Facebook As System.Windows.Forms.Button
    Friend WithEvents GooglePlus As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents DatabasesCheckedListBox As System.Windows.Forms.CheckedListBox
    Friend WithEvents ShowDB As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label

End Class
