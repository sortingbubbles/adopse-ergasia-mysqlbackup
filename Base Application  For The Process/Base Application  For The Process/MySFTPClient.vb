Imports Tamir.SharpSsh
Public Class MySFTPClient
    Inherits CloudService
    Private _username As String = String.Empty
    Private uname As String = String.Empty
    Private url As String = String.Empty
    Private passwd As String = String.Empty
    Sub New(ByVal username As String)
        Me.AppID = "sftp"
        _username = username
    End Sub

    Public Overrides Sub read(ByRef XmlDoc As Xml.XmlDocument)
        uname = XmlDoc.GetElementsByTagName("username").Item(0).InnerText
        passwd = XmlDoc.GetElementsByTagName("password").Item(0).InnerText
        url = XmlDoc.GetElementsByTagName("url").Item(0).InnerText
    End Sub

    Public Overrides Sub upload(filePath As String)
        MySFTP(filePath)
        'Module1.addToMail(msg)
    End Sub
    'Syndesh me to sftp server , dhmiourgeia tou katalogou
    'MySQLBackup kai apostolh tou zipparismenou arxeiou
    'pou periexei tis entoles ths mysql
    Private Sub MySFTP(ByVal ZippedBackupfile As String)
        '  Dim url As String = String.Empty
        Try
            'url = "***********"
            'Dim uname As String = "***********"
            'Dim passwd As String = "**********"
            'Dim port As Integer = 22
            Dim RemoteDirectory As String = "MySQLBackup"
            Dim sshCp As SshTransferProtocolBase
            sshCp = New Sftp(url, uname)
            sshCp.Password = passwd
            sshCp.Connect()
            Try
                sshCp.Mkdir(RemoteDirectory)
            Catch ex As Exception

            End Try
            sshCp.Put(ZippedBackupfile, RemoteDirectory & "/" & "backup.zip") ''''''''''''''''''''''
            sshCp.Close()
            msg += "File Succesfully Uploaded @ FTP SERVER " & url & " !!!<br/>"
        Catch ex As Exception
            msg += "!!!!!!!!!!ERROR @ FILE Uploaded @ FTP SERVER " & url & "!!!!<br>"
            msg += ex.Message & "<br/>"
        End Try
    End Sub
End Class
