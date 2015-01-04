#Region "Libraries"
Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Net.Mail
Imports System.Collections
Imports System.Threading
Imports Tamir.SharpSsh
Imports Tamir.Streams
Imports System
Imports Ionic.Zip
Imports AppLimit.CloudComputing.SharpBox
Imports AppLimit.CloudComputing.SharpBox.StorageProvider.DropBox
Imports BoxApi.V2
Imports BoxApi.V2.Authentication.OAuth2
Imports BoxApi.V2.Model
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json.Linq
#End Region

Module Module1

#Region "Variables"

    Private msg As String = String.Empty
    Private Backupfile As String = String.Empty
    Private ZippedBackupfile As String = String.Empty

#End Region

    Sub Main(ByVal sArgs() As String)
        If sArgs.Length > 0 Then  'elegxoume an yparxoun parametroi
            Dim i As Integer = 0
            sArgs(0).ToString() 'to path pou tha pername 
            Backup()
            ZipMe()
            MySQLDropbox()
            SendMail()
        End If
    End Sub

#Region "MySQLBackUp"

    'syndesh me ton server pou 8eloume sth bash pou 8eloume 
    'me uid To_username sthn default port 3306
    'kanei backup me thn entolh mb.exporttofile(file) 
    'kai sth synexeia ap8hkeyei to .sql arxeio 
    'ston katalogo c:\temp me onoma arxeiou backup
    'kai to timestamp ths dhmiourgeias me format
    'yyyy-mm-dd hh-mm-ss
    Private Sub Backup()
        ' Dim constring As String = "Server=192.168.6.153;Database=adopse;Uid=mysqlBackup;Pwd=;"
        Dim constring As String = "Server=192.168.6.153;Uid=mysqlBackup;Pwd=;Database=;"
        Backupfile = "C:\TEMP\backup(" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ").sql"
        Try
            Dim databases() As String = Split("databases", ",")
            For Each database As String In databases
                constring = "Server=192.168.6.153;Uid=mysqlBackup;Pwd=;Database=" + database + ";"
                Backupfile = "C:\TEMP\backup(" + database + "  " + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ").sql"
                Dim conn As MySqlConnection = New MySqlConnection(constring)
                Dim cmd As MySqlCommand = New MySqlCommand()
                Dim mb As MySqlBackup = New MySqlBackup(cmd)
                cmd.Connection = conn
                conn.Open()
                mb.ExportToFile(Backupfile)
                conn.Close()
            Next
            

            msg = "File Succesfully Copied !!!<br/>"
        Catch ex As Exception
            msg = "!!!!!!!!!!ERROR @ FILE COPY!!!!<br>"
            msg += ex.Message & "<br/>"
        End Try
    End Sub

#End Region

#Region "Zip The BackUp.sql File"

    'Me8odos gia th dhmiourgeia 
    'sympiesmenou arxeiou 
    'pou periexei ta backup Files
    'diagrafh olwn twn .sql arxeiwn pou yparxoun ston katalogo 
    '  C:\TEMP
    Private Sub ZipMe()
        ZippedBackupfile = "C:\TEMP\backup.zip"
        Try
            Dim zip As ZipFile = New ZipFile()
            zip.AddSelectedFiles("*.sql", "C:\TEMP")
            zip.Save(ZippedBackupfile)
            msg += "File Succesfully Zipped !!!<br/>"
            Dim myFile As String
            Dim mydir As String = "C:\TEMP"
            For Each myFile In Directory.GetFiles(mydir, "*.sql")
                File.Delete(myFile)
            Next
        Catch ex As Exception
            msg += "!!!!!!!!!!ERROR @ FILE ZIP!!!!<br>"
            msg += ex.Message & "<br/>"
        End Try
    End Sub

#End Region

#Region "Send Confirmation Mail"

    'syndesh me ton smtp server ths google 
    'dhmiourgeia tou mail me 8ema mysqlbackup service report
    'kai san body ta mhnymata (epityxeias/sfalmatos) ka8
    'olh th diadikasia tou backup
    Private Sub SendMail()
        Try
            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential("mysqlbackupgr.adopse@gmail.com", "***********")
            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "smtp.gmail.com"
            msg += Backupfile & " <br/> Wait for the next Report<br/> Thank you for your preference "
            e_mail = New MailMessage()
            e_mail.From = New MailAddress("mysqlbackupgr.adopse@gmail.com")
            e_mail.To.Add("iliasseitanidis@gmail.com") ''
            'e_mail.To.Add("tazzyannie@gmail.com")
            'e_mail.To.Add("gcharita@it.teithe.gr")
            e_mail.Subject = "MySQLBackUp Service Report"
            e_mail.IsBodyHtml = True
            e_mail.Body = msg
            Smtp_Server.Send(e_mail)
        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region "Upload The Zipped BackUp File"

#Region "SFTP"

    'Syndesh me to sftp server , dhmiourgeia tou katalogou
    'MySQLBackup kai apostolh tou zipparismenou arxeiou
    'pou periexei tis entoles ths mysql
    Private Sub MySFTP()
        Dim url As String = String.Empty
        Try
            url = "***********"
            Dim uname As String = "***********"
            Dim passwd As String = "**********"
            'Dim port As Integer = 22
            Dim RemoteDirectory As String = "MySQLBackup"
            Dim sshCp As SshTransferProtocolBase
            sshCp = New Sftp(url, uname)
            sshCp.Password = passwd
            sshCp.Connect()
            'sshCp.Mkdir(RemoteDirectory)
            sshCp.Put(ZippedBackupfile, RemoteDirectory & "/" & "backup.zip") ''''''''''''''''''''''
            sshCp.Close()
            msg += "File Succesfully Uploaded @ FTP SERVER " & url & " !!!<br/>"
        Catch ex As Exception
            msg += "!!!!!!!!!!ERROR @ FILE Uploaded @ FTP SERVER " & url & "!!!!<br>"
            msg += ex.Message & "<br/>"
        End Try
    End Sub

#End Region

#Region "DropBox"

    'Apostolh tou zip arxeiou pou periexei to backup ston
    'logariasmo tou xrhsth ston katalogo "MySQLBackUp"
    'ka8ws kai thn diagrafh prohgoumenou backup
    Private Sub MySQLDropbox()
        Try
            Dim config As DropBoxConfiguration = TryCast(CloudStorage.GetCloudConfigurationEasy(nSupportedCloudConfigurations.DropBox), DropBoxConfiguration)
            Dim DropboxStorage As New CloudStorage()
            Dim accessToken As ICloudStorageAccessToken
            Using fs = System.IO.File.Open("C:\TEMP\DropBoxToken.txt", FileMode.Open, FileAccess.Read, FileShare.None)
                accessToken = DropboxStorage.DeserializeSecurityToken(fs)
            End Using
            DropboxStorage.Open(config, accessToken)
            DropboxStorage.CreateFolder("/MySQLBackUp")
            DropboxStorage.DeleteFileSystemEntry("/MySQLBackUp")
            DropboxStorage.CreateFolder("/MySQLBackUp")
            DropboxStorage.UploadFile(ZippedBackupfile, "/MySQLBackUp")
            DropboxStorage.Close()
            msg += "File Succesfully Uploaded @ DropBox !!!<br/>"
        Catch ex As Exception
            msg += "!!!!!!!!!!ERROR @ FILE Uploaded @ DropBox !!!!<br>"
            msg += ex.Message & "<br/>"
        End Try
    End Sub

#End Region

#Region "Box"

    'h me8odos pou ekkinei th diadikasia tou upload sto box.com
    'opou metatrepoume se System.IO.Stream to arxeio pou 8eloume 
    'na anebasoume
    Private Sub MySQLBox()
        Try
            Dim fileName As String = "C:\TEMP\backup.zip"
            Dim currentFileStream As System.IO.Stream = System.IO.File.Open(fileName, FileMode.Open)
            UploadToBox(fileName, currentFileStream)
            currentFileStream.Close()
            msg += "File Succesfully Uploaded @ Box !!!<br/>"
        Catch ex As Exception
            msg += "!!!!!!!!!!ERROR @ FILE Uploaded @ Box !!!!<br>"
            msg += ex.Message & "<br/>"
        End Try
    End Sub

    'h basikh me8odos me thn opoia ginetai to upload
    'tou zipped backup file sto box.com ston katalogo MySQLBackUp
    'psaxnoume ton root folder tou xrhsth gia na doume an 
    'yparxei hdh o katalogos MySQLBackUp kai ton diagrafoume mazi me to
    'periexomeno tou (recursive=true) kai sth synexeia dhmiourgoume
    'ek neou ton katalogo MySQLBackUp kai anebazoume to zipped backup file
    Function UploadToBox(ByVal attachedFilename As String, ByVal stream As System.IO.Stream) As Boolean
        Dim newToken As BoxApi.V2.Authentication.OAuth2.OAuthToken = GetToken()
        Dim boxManager As New BoxManager(newToken.AccessToken)
        Dim rootFolder As Folder
        'Dim Fid As String
        For Each Fold As Folder In boxManager.GetFolder(Folder.Root).Folders
            If Fold.Name = "MySQLBackUp" Then
                'Fid = Fold.Id
                boxManager.DeleteFolder(Fold.Id, True)
            End If
        Next
        rootFolder = boxManager.CreateFolder(boxManager.GetFolder(Folder.Root), "MySQLBackUp")
        boxManager.CreateFile(rootFolder, attachedFilename, ConvertStreamToByteArray(stream))
        Return True
    End Function
    'boh8htikh me8odos ths UploadToBox gia thn metatroph tou 
    'arxeiou se byte etsi wste na metafer8oun sto box
    Private Function ConvertStreamToByteArray(ByVal stream As System.IO.Stream) As Byte()
        Dim streamLength As Long = Convert.ToInt64(stream.Length)
        Dim fileData As Byte() = New Byte(streamLength) {}
        stream.Position = 0
        stream.Read(fileData, 0, streamLength)
        stream.Close()
        Return fileData
    End Function
    'boh8htikh me8odos ths UploadToBox gia th dhmiourgeia enos nou RefreshToken
    'me bash to palio RefreshToken po exoume apo8hkeysei sto arxeio C:\TEMP\MyTest12.txt 
    'sth synexeia apo8hkeyoume to neo RefreshToken gia to epomeno backup
    Function GetToken() As BoxApi.V2.Authentication.OAuth2.OAuthToken
        Dim clientID As String = "*************************" ''''''''''''''
        Dim clientSecret As String = "***********************" '''''''''''''''
        Dim oldRefreshToken As String
        Dim newToken As BoxApi.V2.Authentication.OAuth2.OAuthToken
        Dim tokenProvider As New TokenProvider(clientID, clientSecret)
        Dim streamReader As StreamReader
        streamReader = System.IO.File.OpenText("C:\TEMP\BoxToken.txt")
        oldRefreshToken = streamReader.ReadToEnd()
        streamReader.Close()
        newToken = tokenProvider.RefreshAccessToken(oldRefreshToken)
        Dim streamWriter As New StreamWriter("C:\TEMP\BoxToken.txt")
        streamWriter.Write(newToken.RefreshToken)
        streamWriter.Close()
        Return newToken
    End Function

#End Region

#Region "OneDrive"

#End Region


#Region "Google Drive"

#End Region



#End Region 'teliko region'

End Module
