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
Imports System.Xml

#End Region

Public Module Module1

#Region "Variables"

    Private msg As String = String.Empty
    Private ZippedBackupfile As String = String.Empty
    Private username As String = String.Empty
    Private CloudServices As List(Of CloudService) = New List(Of CloudService)
    Private email As String
    Private _conString As String
    Private _databases As String
#End Region

    Sub Main(ByVal sArgs() As String)
        If sArgs.Length > 0 Then  'elegxoume an yparxoun parametroi
            username = sArgs(0).ToString() 'to username pou tha pername
            UnZipMe()
            readXMLDoc("C:\TEMP\" & username & "\" & username & ".xml")
            Backup()
            ZipBackUpFile()
            uploadBackUpFile()
            SendMail()
            ZipMe()
        End If
    End Sub
    'boh8htikh me8odos sthn opoia epistrefontai
    'ta success/error messages apo tis klaseis
    'pou ylopoioyn thn CloudService kai ta 
    'pros8etei sto msg poy 8a apostalei
    'ston xrhsth
    Public Sub addToMail(ByVal _msg As String)
        msg += _msg
    End Sub
    Private Sub readXMLDoc(ByVal path As String)
        '
        Dim xmlDoc As XmlDocument = New XmlDocument()
        xmlDoc.Load(path)
        email = xmlDoc.GetElementsByTagName("email").Item(0).InnerText
        _conString = xmlDoc.GetElementsByTagName("conString").Item(0).InnerText
        _databases = xmlDoc.GetElementsByTagName("databases").Item(0).InnerText

        Dim taskNodes As XmlNodeList = xmlDoc.GetElementsByTagName("cloudService")
        For Each node As XmlNode In taskNodes
            Select Case node.Attributes.Item(0).Value
                Case "sftp"
                    'dimiourgia sftp antikeimenou kai klisi methodou read
                    Dim _sftpClient As MySFTPClient = New MySFTPClient(username)
                    _sftpClient.read(xmlDoc)
                    CloudServices.Add(_sftpClient)
                Case "dropbox"
                    'dimiourgia sftp antikeimenou kai klisi methodou read
                    Dim _dropboxClient As MyDropBox = New MyDropBox(username)
                    _dropboxClient.read(xmlDoc)
                    CloudServices.Add(_dropboxClient)
                Case "box"
                    'dimiourgia sftp antikeimenou kai klisi methodou read
                    Dim _boxClient As MyBox = New MyBox(username)
                    _boxClient.read(xmlDoc)
                    CloudServices.Add(_boxClient)
                Case "googledrive"
                    Dim GDrive As GoogleDrive = New GoogleDrive(username)
                    GDrive.read(xmlDoc)
                    CloudServices.Add(GDrive)
                Case "onedrive"
                    Dim oneDRive As ΟneDrive = New ΟneDrive(username)
                    oneDRive.read(xmlDoc)
                    CloudServices.Add(oneDRive)
            End Select
        Next
    End Sub

    Private Sub uploadBackUpFile()
        For Each service As CloudService In CloudServices
            service.upload(ZippedBackupfile)
        Next
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
        '  Dim constring As String = "Server=192.168.6.153;Uid=mysqlBackup;Pwd=;Database=;"
        ' Backupfile = "C:\TEMP\backup(" + database + "  " + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ").sql"
        Dim tempconString As String
        Try
            Dim databases() As String = Split(_databases, ",")
            For Each database As String In databases
                tempconString = _conString + database + ";"
                ' constring = "Server=192.168.6.153;Uid=mysqlBackup;Pwd=;Database=" + database + ";"
                Dim Backupfile As String = "C:\TEMP\backup(" + database + "  " + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ").sql"
                Dim conn As MySqlConnection = New MySqlConnection(tempconString)
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

#Region "Zip The BackUp.sql File And Zip & Unzip the user folder"

    'Me8odos gia th dhmiourgeia 
    'sympiesmenou arxeiou 
    'pou periexei ta backup Files
    'diagrafh olwn twn .sql arxeiwn pou yparxoun ston katalogo 
    '  C:\TEMP\<username>
    Private Sub ZipBackUpFile()
        ZippedBackupfile = "C:\TEMP\" & username & "\backup.zip"
        Try
            Dim zip As ZipFile = New ZipFile()
            zip.AddSelectedFiles("*.sql", "C:\TEMP")
            zip.Save(ZippedBackupfile)
            Dim myFile As String
            Dim mydir As String = "C:\TEMP\" & username
            For Each myFile In Directory.GetFiles(mydir, "*.sql")
                'File.Delete(myFile)
                System.IO.File.Delete(myFile)
            Next
            msg += "File Succesfully Zipped !!!<br/>"
        Catch ex As Exception
            msg += "!!!!!!!!!!ERROR @ FILE ZIP!!!!<br>"
            msg += ex.Message & "<br/>"
        End Try
    End Sub

    Private Sub UnZipMe()
        Dim UnZippedUserFolder As String = "C:\TEMP\" & username
        Dim ZippedUserFolder As String = "C:\TEMP\" & username & ".zip"
        Using zip1 As ZipFile = ZipFile.Read(ZippedUserFolder)
            zip1.Password = "AsprhPetra3e3asprhKaiApoTonHlio3e3asproterh"
            Dim e As ZipEntry
            For Each e In zip1
                e.Extract(UnZippedUserFolder, ExtractExistingFileAction.OverwriteSilently)
            Next
        End Using
        My.Computer.FileSystem.DeleteFile(ZippedUserFolder)
    End Sub

    Private Sub ZipMe()
        Dim Userfolder As String = "C:\TEMP\" & username
        Dim ZippedUserfolder As String = "C:\TEMP\" & username & ".zip"
        Using zip As ZipFile = New ZipFile()
            zip.Encryption = EncryptionAlgorithm.WinZipAes256
            zip.Password = "AsprhPetra3e3asprhKaiApoTonHlio3e3asproterh"
            zip.AddDirectory(Userfolder)
            zip.Save(ZippedUserfolder)
        End Using
        My.Computer.FileSystem.DeleteDirectory(Userfolder, FileIO.DeleteDirectoryOption.DeleteAllContents)

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
            msg += " <br/> Wait for the next Report<br/> Thank you for your preference "
            e_mail = New MailMessage()
            e_mail.From = New MailAddress("mysqlbackupgr.adopse@gmail.com")
            Dim mails() As String = Split(email, ",")
            For Each _email As String In mails
                e_mail.To.Add(_email)
            Next
            ' e_mail.To.Add("iliasseitanidis@gmail.com") ''
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

    ''Syndesh me to sftp server , dhmiourgeia tou katalogou
    ''MySQLBackup kai apostolh tou zipparismenou arxeiou
    ''pou periexei tis entoles ths mysql
    'Private Sub MySFTP(ByVal url As String, ByVal uname As String, ByVal passwd As String)
    '    '  Dim url As String = String.Empty
    '    Try
    '        'url = "***********"
    '        'Dim uname As String = "***********"
    '        'Dim passwd As String = "**********"
    '        'Dim port As Integer = 22
    '        Dim RemoteDirectory As String = "MySQLBackup"
    '        Dim sshCp As SshTransferProtocolBase
    '        sshCp = New Sftp(url, uname)
    '        sshCp.Password = passwd
    '        sshCp.Connect()
    '        Try
    '            sshCp.Mkdir(RemoteDirectory)
    '        Catch ex As Exception

    '        End Try
    '        sshCp.Put(ZippedBackupfile, RemoteDirectory & "/" & "backup.zip") ''''''''''''''''''''''
    '        sshCp.Close()
    '        msg += "File Succesfully Uploaded @ FTP SERVER " & url & " !!!<br/>"
    '    Catch ex As Exception
    '        msg += "!!!!!!!!!!ERROR @ FILE Uploaded @ FTP SERVER " & url & "!!!!<br>"
    '        msg += ex.Message & "<br/>"
    '    End Try
    'End Sub

#End Region

#Region "DropBox"

    ''Apostolh tou zip arxeiou pou periexei to backup ston
    ''logariasmo tou xrhsth ston katalogo "MySQLBackUp"
    ''ka8ws kai thn diagrafh prohgoumenou backup
    'Private Sub MySQLDropbox()
    '    Try
    '        Dim config As DropBoxConfiguration = TryCast(CloudStorage.GetCloudConfigurationEasy(nSupportedCloudConfigurations.DropBox), DropBoxConfiguration)
    '        Dim DropboxStorage As New CloudStorage()
    '        Dim accessToken As ICloudStorageAccessToken
    '        Using fs = System.IO.File.Open("C:\TEMP\" & username & "DropBoxToken.txt", FileMode.Open, FileAccess.Read, FileShare.None)
    '            accessToken = DropboxStorage.DeserializeSecurityToken(fs)
    '        End Using
    '        DropboxStorage.Open(config, accessToken)
    '        DropboxStorage.CreateFolder("/MySQLBackUp")
    '        DropboxStorage.DeleteFileSystemEntry("/MySQLBackUp")
    '        DropboxStorage.CreateFolder("/MySQLBackUp")
    '        DropboxStorage.UploadFile(ZippedBackupfile, "/MySQLBackUp")
    '        DropboxStorage.Close()
    '        msg += "File Succesfully Uploaded @ DropBox !!!<br/>"
    '    Catch ex As Exception
    '        msg += "!!!!!!!!!!ERROR @ FILE Uploaded @ DropBox !!!!<br>"
    '        msg += ex.Message & "<br/>"
    '    End Try
    'End Sub

#End Region

#Region "Box"

    ''h me8odos pou ekkinei th diadikasia tou upload sto box.com
    ''opou metatrepoume se System.IO.Stream to arxeio pou 8eloume 
    ''na anebasoume
    'Private Sub MySQLBox()
    '    Try
    '        Dim fileName As String = "C:\TEMP\" & username & "\backup.zip"
    '        Dim currentFileStream As System.IO.Stream = System.IO.File.Open(fileName, FileMode.Open)
    '        UploadToBox(fileName, currentFileStream)
    '        currentFileStream.Close()
    '        msg += "File Succesfully Uploaded @ Box !!!<br/>"
    '    Catch ex As Exception
    '        msg += "!!!!!!!!!!ERROR @ FILE Uploaded @ Box !!!!<br>"
    '        msg += ex.Message & "<br/>"
    '    End Try
    'End Sub

    ''h basikh me8odos me thn opoia ginetai to upload
    ''tou zipped backup file sto box.com ston katalogo MySQLBackUp
    ''psaxnoume ton root folder tou xrhsth gia na doume an 
    ''yparxei hdh o katalogos MySQLBackUp kai ton diagrafoume mazi me to
    ''periexomeno tou (recursive=true) kai sth synexeia dhmiourgoume
    ''ek neou ton katalogo MySQLBackUp kai anebazoume to zipped backup file
    'Function UploadToBox(ByVal attachedFilename As String, ByVal stream As System.IO.Stream) As Boolean
    '    Dim newToken As BoxApi.V2.Authentication.OAuth2.OAuthToken = GetToken()
    '    Dim boxManager As New BoxManager(newToken.AccessToken)
    '    Dim rootFolder As Folder
    '    'Dim Fid As String
    '    For Each Fold As Folder In boxManager.GetFolder(Folder.Root).Folders
    '        If Fold.Name = "MySQLBackUp" Then
    '            'Fid = Fold.Id
    '            boxManager.DeleteFolder(Fold.Id, True)
    '        End If
    '    Next
    '    rootFolder = boxManager.CreateFolder(boxManager.GetFolder(Folder.Root), "MySQLBackUp")
    '    boxManager.CreateFile(rootFolder, attachedFilename, ConvertStreamToByteArray(stream))
    '    Return True
    'End Function
    ''boh8htikh me8odos ths UploadToBox gia thn metatroph tou 
    ''arxeiou se byte etsi wste na metafer8oun sto box
    'Private Function ConvertStreamToByteArray(ByVal stream As System.IO.Stream) As Byte()
    '    Dim streamLength As Long = Convert.ToInt64(stream.Length)
    '    Dim fileData As Byte() = New Byte(streamLength) {}
    '    stream.Position = 0
    '    stream.Read(fileData, 0, streamLength)
    '    stream.Close()
    '    Return fileData
    'End Function
    ''boh8htikh me8odos ths UploadToBox gia th dhmiourgeia enos nou RefreshToken
    ''me bash to palio RefreshToken po exoume apo8hkeysei sto arxeio C:\TEMP\MyTest12.txt 
    ''sth synexeia apo8hkeyoume to neo RefreshToken gia to epomeno backup
    'Function GetToken() As BoxApi.V2.Authentication.OAuth2.OAuthToken
    '    Dim clientID As String = "*************************" ''''''''''''''
    '    Dim clientSecret As String = "***********************" '''''''''''''''
    '    Dim oldRefreshToken As String
    '    Dim newToken As BoxApi.V2.Authentication.OAuth2.OAuthToken
    '    Dim tokenProvider As New TokenProvider(clientID, clientSecret)
    '    Dim streamReader As StreamReader
    '    streamReader = System.IO.File.OpenText("C:\TEMP\" & username & "\BoxToken.txt")
    '    oldRefreshToken = streamReader.ReadToEnd()
    '    streamReader.Close()
    '    newToken = tokenProvider.RefreshAccessToken(oldRefreshToken)
    '    Dim streamWriter As New StreamWriter("C:\TEMP\" & username & "\BoxToken.txt")
    '    streamWriter.Write(newToken.RefreshToken)
    '    streamWriter.Close()
    '    Return newToken
    'End Function

#End Region

#Region "OneDrive"

#End Region


#Region "Google Drive"

#End Region



#End Region

End Module
