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

    Private Sub readXMLDoc(ByVal path As String)
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
    'h me8odos sthn opoia kaleitai h
    'antistoixh me8odos gia na ginei upload to arxeio
    'kai epistrefontai ta success/error messages apo 
    'tis klaseis pou ylopoioyn thn CloudService kai ta 
    'pros8etei sto msg poy 8a apostalei
    'ston xrhsth
    Private Sub uploadBackUpFile()
        For Each service As CloudService In CloudServices
            msg += service.upload(ZippedBackupfile)
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

        Dim tempconString As String
        Try
            Dim databases() As String = Split(_databases, ",")
            For Each database As String In databases
                If Not String.IsNullOrEmpty(database) Then
                    tempconString = _conString + database + ";"
                    Dim Backupfile As String = "C:\TEMP\backup(" + database + "  " + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ").sql"
                    Dim conn As MySqlConnection = New MySqlConnection(tempconString)
                    Dim cmd As MySqlCommand = New MySqlCommand()
                    Dim mb As MySqlBackup = New MySqlBackup(cmd)
                    cmd.Connection = conn
                    conn.Open()
                    mb.ExportToFile(Backupfile)
                    conn.Close()
                End If
            Next


            msg = "File Succesfully Copied !!!<br/>"
        Catch ex As Exception
            msg = "<strong><span style='color: red;'>!!!!!!!!!!ERROR @ FILE COPY!!!!</span></strong><br>"
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
            Dim mydir As String = "C:\TEMP\"
            For Each myFile In Directory.GetFiles(mydir, "back*.sql")
                My.Computer.FileSystem.DeleteFile(myFile)
            Next
            msg += "File Succesfully Zipped !!!<br/>"
        Catch ex As Exception
            msg += "<strong><span style='color: red;'>!!!!!!!!!!ERROR @ FILE ZIP!!!!</span></strong><br>"
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
        My.Computer.FileSystem.DeleteFile(ZippedBackupfile)
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
            Smtp_Server.Credentials = New Net.NetworkCredential("mysqlbackupgr.adopse@gmail.com", "************") ''''''
            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "smtp.gmail.com"

            e_mail = New MailMessage()
            e_mail.From = New MailAddress("mysqlbackupgr.adopse@gmail.com")
            Dim mails() As String = Split(email, ",")
            For Each _email As String In mails
                If Not String.IsNullOrEmpty(_email) Then
                    e_mail.To.Add(_email)
                End If
            Next

            e_mail.Subject = "MySQLBackUp Service Report"
            e_mail.IsBodyHtml = True
            e_mail.Body = createEmailBody()
            Smtp_Server.Send(e_mail)
        Catch ex As Exception
        End Try
    End Sub


    'Μέθοδος που δημιουργεί το σώμα του html email
    'Το html mail έχει χωριστεί σε δύο text αρχεία και ενδιάμεσα τους μπαίνουν τα μηνύματα του report (msg)
    Private Function createEmailBody()
        Dim mailBody As String = String.Empty
        'Φόρτωση του πρώτου κομματιού από αρχείο
        mailBody = System.IO.File.ReadAllText("C:\Debug\htmlpart1.txt")
        'Προσθήκη όλων των μηνυμάτων από τις παραπάνω λειτουργίες
        mailBody += msg
        'Φόρτωση και πρόσθεση του τελευταίου κομματιού από αρχείο
        mailBody += System.IO.File.ReadAllText("C:\Debug\htmlpart2.txt")
        Return mailBody
    End Function

#End Region

End Module
