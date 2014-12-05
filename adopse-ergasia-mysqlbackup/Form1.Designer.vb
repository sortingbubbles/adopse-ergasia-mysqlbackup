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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Button2 = New System.Windows.Forms.Button
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox
        Me.ButtonConnectToMySQLServer = New System.Windows.Forms.Button
        Me.ToolStripLabelFile = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripLabelTools = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripLabelHelp = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripButtonSave = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButtonOpen = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButtonLog = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButtonJobs = New System.Windows.Forms.ToolStripButton
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
        Me.ToolStrip1.Size = New System.Drawing.Size(506, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2, Me.ToolStripButtonOpen, Me.ToolStripButtonSave, Me.ToolStripSeparator1, Me.ToolStripButtonJobs, Me.ToolStripButtonLog})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 25)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(506, 38)
        Me.ToolStrip2.TabIndex = 3
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(261, 66)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(233, 71)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Storage"
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(261, 164)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(233, 75)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Email"
        '
        'GroupBox3
        '
        Me.GroupBox3.Location = New System.Drawing.Point(261, 267)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(233, 83)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Jobs"
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Location = New System.Drawing.Point(12, 126)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(194, 244)
        Me.CheckedListBox1.TabIndex = 7
        '
        'ButtonConnectToMySQLServer
        '
        Me.ButtonConnectToMySQLServer.Location = New System.Drawing.Point(12, 79)
        Me.ButtonConnectToMySQLServer.Name = "ButtonConnectToMySQLServer"
        Me.ButtonConnectToMySQLServer.Size = New System.Drawing.Size(116, 23)
        Me.ButtonConnectToMySQLServer.TabIndex = 8
        Me.ButtonConnectToMySQLServer.Text = "Connect to MySQL Server"
        Me.ButtonConnectToMySQLServer.UseVisualStyleBackColor = True
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
        'ToolStripButtonSave
        '
        Me.ToolStripButtonSave.Image = CType(resources.GetObject("ToolStripButtonSave.Image"), System.Drawing.Image)
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
        'ToolStripButtonOpen
        '
        Me.ToolStripButtonOpen.Image = CType(resources.GetObject("ToolStripButtonOpen.Image"), System.Drawing.Image)
        Me.ToolStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonOpen.Name = "ToolStripButtonOpen"
        Me.ToolStripButtonOpen.Size = New System.Drawing.Size(40, 35)
        Me.ToolStripButtonOpen.Text = "Open"
        Me.ToolStripButtonOpen.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolStripButtonOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(35, 35)
        Me.ToolStripButton2.Text = "New"
        Me.ToolStripButton2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripButtonLog
        '
        Me.ToolStripButtonLog.Image = CType(resources.GetObject("ToolStripButtonLog.Image"), System.Drawing.Image)
        Me.ToolStripButtonLog.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonLog.Name = "ToolStripButtonLog"
        Me.ToolStripButtonLog.Size = New System.Drawing.Size(31, 35)
        Me.ToolStripButtonLog.Text = "Log"
        Me.ToolStripButtonLog.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolStripButtonLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripButtonJobs
        '
        Me.ToolStripButtonJobs.Image = CType(resources.GetObject("ToolStripButtonJobs.Image"), System.Drawing.Image)
        Me.ToolStripButtonJobs.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonJobs.Name = "ToolStripButtonJobs"
        Me.ToolStripButtonJobs.Size = New System.Drawing.Size(34, 35)
        Me.ToolStripButtonJobs.Text = "Jobs"
        Me.ToolStripButtonJobs.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolStripButtonJobs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(506, 394)
        Me.Controls.Add(Me.ButtonConnectToMySQLServer)
        Me.Controls.Add(Me.CheckedListBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
    Friend WithEvents ButtonConnectToMySQLServer As System.Windows.Forms.Button
    Friend WithEvents ToolStripLabelFile As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabelTools As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabelHelp As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButtonSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonOpen As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonJobs As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonLog As System.Windows.Forms.ToolStripButton

End Class
