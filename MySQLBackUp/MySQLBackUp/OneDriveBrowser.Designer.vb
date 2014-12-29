<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OneDriveBrowser
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
        Me.OneDriveAuth = New System.Windows.Forms.WebBrowser()
        Me.SuspendLayout()
        '
        'OneDriveAuth
        '
        Me.OneDriveAuth.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OneDriveAuth.Location = New System.Drawing.Point(0, 0)
        Me.OneDriveAuth.MinimumSize = New System.Drawing.Size(20, 20)
        Me.OneDriveAuth.Name = "OneDriveAuth"
        Me.OneDriveAuth.Size = New System.Drawing.Size(484, 513)
        Me.OneDriveAuth.TabIndex = 0
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 513)
        Me.Controls.Add(Me.OneDriveAuth)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "OneDriveAuth"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OneDriveAuth As System.Windows.Forms.WebBrowser
End Class
