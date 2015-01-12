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
        uname = XmlDoc.GetElementsByTagName("Username").Item(0).InnerText
        passwd = XmlDoc.GetElementsByTagName("Password").Item(0).InnerText
        url = XmlDoc.GetElementsByTagName("Server").Item(0).InnerText
    End Sub

    Public Overrides Function upload(filePath As String) As String
        Return MySFTP(filePath)
        'Module1.addToMail(Msg)
    End Function
    'Syndesh me to sftp server , dhmiourgeia tou katalogou
    'MySQLBackup kai apostolh tou zipparismenou arxeiou
    'pou periexei tis entoles ths mysql
    Private Function MySFTP(ByVal ZippedBackupfile As String)
        Dim Msg As String = String.Empty
        Try
            'url = "ewedwedwe"
            'uname = "fyhqd"
            'passwd = "***"
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
            sshCp.Put(ZippedBackupfile, RemoteDirectory & "backup.zip") ''''''''''''''''''''''
            sshCp.Close()
            Msg += "File Succesfully Uploaded @ FTP SERVER " & url & " !!!<br/>"
        Catch ex As Exception
            Msg += "!!!!!!!!!!ERROR @ FILE Uploaded @ FTP SERVER " & url & "!!!!<br>"
            Msg += ex.Message & "<br/>"
        End Try
        Return Msg
    End Function
End Class
