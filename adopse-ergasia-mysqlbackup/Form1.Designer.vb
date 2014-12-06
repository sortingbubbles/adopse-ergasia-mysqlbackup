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
        Me.Button2 = New System.Windows.Forms.Button
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripLabelFile = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripLabelTools = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripLabelHelp = New System.Windows.Forms.ToolStripLabel
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButtonNew = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButtonOpen = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButtonSave = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButtonJobs = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButtonLog = New System.Windows.Forms.ToolStripButton
        Me.GroupBoxStrorage = New System.Windows.Forms.GroupBox
        Me.GroupBoxEmail = New System.Windows.Forms.GroupBox
        Me.GroupBoxJobs = New System.Windows.Forms.GroupBox
        Me.CheckedListBoxDatabases = New System.Windows.Forms.CheckedListBox
        Me.ButtonConnectToMySQLServer = New System.Windows.Forms.Button
        Me.ToolStrip1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(261, 365)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(213, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "PRESS 2 CREATE BACKUP"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabelFile, Me.ToolStripLabelTools, Me.ToolStripLabelHelp})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(522, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStripSimple"
        '
        'ToolStripLabelFile
        '
        Me.ToolStripLabelFile.Name = "ToolStripLabelFile"
        Me.ToolStripLabelFile.Size = New System.Drawing.Size(30, 22)
        Me.ToolStripLabelFile.Text = "Files"
        '
        'ToolStripLabelTools
        '
        Me.ToolStripLabelTools.Name = "ToolStripLabelTools"
        Me.ToolStripLabelTools.Size = New System.Drawing.Size(36, 22)
        Me.ToolStripLabelTools.Text = "Tools"
        '
        'ToolStripLabelHelp
        '
        Me.ToolStripLabelHelp.Name = "ToolStripLabelHelp"
        Me.ToolStripLabelHelp.Size = New System.Drawing.Size(32, 22)
        Me.ToolStripLabelHelp.Text = "Help"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(50, 50)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonNew, Me.ToolStripButtonOpen, Me.ToolStripButtonSave, Me.ToolStripSeparator1, Me.ToolStripButtonJobs, Me.ToolStripButtonLog})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 25)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(522, 38)
        Me.ToolStrip2.TabIndex = 3
        Me.ToolStrip2.Text = "ToolStripIcons"
        '
        'ToolStripButtonNew
        '
        Me.ToolStripButtonNew.Image = Global.adopse_ergasia_mysqlbackup.My.Resources.Resources.download__3_
        Me.ToolStripButtonNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonNew.Name = "ToolStripButtonNew"
        Me.ToolStripButtonNew.Size = New System.Drawing.Size(35, 35)
        Me.ToolStripButtonNew.Text = "New"
        Me.ToolStripButtonNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolStripButtonNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripButtonOpen
        '
        Me.ToolStripButtonOpen.Image = Global.adopse_ergasia_mysqlbackup.My.Resources.Resources.images__1_
        Me.ToolStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonOpen.Name = "ToolStripButtonOpen"
        Me.ToolStripButtonOpen.Size = New System.Drawing.Size(40, 35)
        Me.ToolStripButtonOpen.Text = "Open"
        Me.ToolStripButtonOpen.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolStripButtonOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripButtonSave
        '
        Me.ToolStripButtonSave.Image = Global.adopse_ergasia_mysqlbackup.My.Resources.Resources.download__2_
        Me.ToolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonSave.Name = "ToolStripButtonSave"
        Me.ToolStripButtonSave.Size = New System.Drawing.Size(35, 35)
        Me.ToolStripButtonSave.Text = "Save"
        Me.ToolStripButtonSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolStripButtonSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 38)
        '
        'ToolStripButtonJobs
        '
        Me.ToolStripButtonJobs.Image = Global.adopse_ergasia_mysqlbackup.My.Resources.Resources.download__6_
        Me.ToolStripButtonJobs.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonJobs.Name = "ToolStripButtonJobs"
        Me.ToolStripButtonJobs.Size = New System.Drawing.Size(34, 35)
        Me.ToolStripButtonJobs.Text = "Jobs"
        Me.ToolStripButtonJobs.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolStripButtonJobs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripButtonLog
        '
        Me.ToolStripButtonLog.Image = Global.adopse_ergasia_mysqlbackup.My.Resources.Resources.download__5_
        Me.ToolStripButtonLog.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonLog.Name = "ToolStripButtonLog"
        Me.ToolStripButtonLog.Size = New System.Drawing.Size(31, 35)
        Me.ToolStripButtonLog.Text = "Log"
        Me.ToolStripButtonLog.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolStripButtonLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'GroupBoxStrorage
        '
        Me.GroupBoxStrorage.Location = New System.Drawing.Point(261, 94)
        Me.GroupBoxStrorage.Name = "GroupBoxStrorage"
        Me.GroupBoxStrorage.Size = New System.Drawing.Size(233, 71)
        Me.GroupBoxStrorage.TabIndex = 4
        Me.GroupBoxStrorage.TabStop = False
        Me.GroupBoxStrorage.Text = "Storage"
        '
        'GroupBoxEmail
        '
        Me.GroupBoxEmail.Location = New System.Drawing.Point(261, 198)
        Me.GroupBoxEmail.Name = "GroupBoxEmail"
        Me.GroupBoxEmail.Size = New System.Drawing.Size(233, 63)
        Me.GroupBoxEmail.TabIndex = 5
        Me.GroupBoxEmail.TabStop = False
        Me.GroupBoxEmail.Text = "Email"
        '
        'GroupBoxJobs
        '
        Me.GroupBoxJobs.Location = New System.Drawing.Point(261, 290)
        Me.GroupBoxJobs.Name = "GroupBoxJobs"
        Me.GroupBoxJobs.Size = New System.Drawing.Size(233, 55)
        Me.GroupBoxJobs.TabIndex = 6
        Me.GroupBoxJobs.TabStop = False
        Me.GroupBoxJobs.Text = "Jobs"
        '
        'CheckedListBoxDatabases
        '
        Me.CheckedListBoxDatabases.FormattingEnabled = True
        Me.CheckedListBoxDatabases.Location = New System.Drawing.Point(12, 126)
        Me.CheckedListBoxDatabases.Name = "CheckedListBoxDatabases"
        Me.CheckedListBoxDatabases.Size = New System.Drawing.Size(194, 244)
        Me.CheckedListBoxDatabases.TabIndex = 7
        '
        'ButtonConnectToMySQLServer
        '
        Me.ButtonConnectToMySQLServer.Location = New System.Drawing.Point(12, 85)
        Me.ButtonConnectToMySQLServer.Name = "ButtonConnectToMySQLServer"
        Me.ButtonConnectToMySQLServer.Size = New System.Drawing.Size(127, 23)
        Me.ButtonConnectToMySQLServer.TabIndex = 8
        Me.ButtonConnectToMySQLServer.Text = "Connect to MySQL Server"
        Me.ButtonConnectToMySQLServer.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(522, 394)
        Me.Controls.Add(Me.ButtonConnectToMySQLServer)
        Me.Controls.Add(Me.CheckedListBoxDatabases)
        Me.Controls.Add(Me.GroupBoxJobs)
        Me.Controls.Add(Me.GroupBoxEmail)
        Me.Controls.Add(Me.GroupBoxStrorage)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Button2)
        Me.Name = "Form1"
        Me.Text = "mysqlbackup"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents GroupBoxStrorage As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBoxEmail As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBoxJobs As System.Windows.Forms.GroupBox
    Friend WithEvents CheckedListBoxDatabases As System.Windows.Forms.CheckedListBox
    Friend WithEvents ButtonConnectToMySQLServer As System.Windows.Forms.Button
    Friend WithEvents ToolStripLabelFile As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabelTools As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabelHelp As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButtonSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButtonNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonOpen As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonJobs As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonLog As System.Windows.Forms.ToolStripButton

End Class
