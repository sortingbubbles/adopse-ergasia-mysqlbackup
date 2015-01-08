Public Class SftpForm
    Private _sftp As MyNewSftpClient
    Sub New(ByVal sftp As MyNewSftpClient)
        InitializeComponent()
        _sftp = sftp
    End Sub
    Private Sub SFTPOKButton_Click(sender As Object, e As EventArgs) Handles SFTPOKButton.Click
        _sftp.Server = SFTPServer.Text
        _sftp.Username = SFTPUsername.Text
        _sftp.Password = SFTPPassword.Text
        Me.Close()
    End Sub
End Class