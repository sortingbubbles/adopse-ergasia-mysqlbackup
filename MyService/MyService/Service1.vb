Imports MySql.Data.MySqlClient
'Imports System.IO.Packaging
Imports System.IO
Imports Rebex.IO.Compression
Imports Rebex.IO
Imports System.Net.Mail
Imports System.Collections
Imports System.Threading
Imports Tamir.SharpSsh
Imports Tamir.Streams
Imports System
Public Class Service1

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This me
        'thod should set things
        ' in motion so your service can do its work.
        Backup()
        ZipMe()
        MySFTP()
        'MySQLDropbox()
        ' MyBox()
        SentMail()
        'Timer1.Enabled = True
    End Sub

    Protected Overrides Sub OnStop()
        Timer1.Enabled = False
        ' Add code here to perform any tear-down necessary to stop your service.
    End Sub

    Private msg As String = String.Empty
    Private Backupfile As String = String.Empty
    Private ZippedBackupfile As String = String.Empty
    '!!!!!!!kante syndesh me vpn me to tmhma!!!!!!!!
    'syndesh me ton server 192.168.6.153 sth bash adopse 
    'me uid mysqlbackup sthn default port 3306
    'kanei backup me thn entolh mb.exporttofile(file) 
    'kai sth synexeia ap8hkeyei to .sql arxeio 
    'ston katalogo c:\temp me onoma arxeiou backup
    'kai to timestamp ths dhmiourgeias me format
    'yyyy-mm-dd hh-mm-ss
    Private Sub Backup()
        Dim constring As String = "Server=192.168.6.153;Database=adopse;Uid=mysqlBackup;Pwd=;"
        Backupfile = "C:\TEMP\backup(" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ").sql"
        Try
            Dim conn As MySqlConnection = New MySqlConnection(constring)
            Dim cmd As MySqlCommand = New MySqlCommand()
            Dim mb As MySqlBackup = New MySqlBackup(cmd)
            cmd.Connection = conn
            conn.Open()
            mb.ExportToFile(Backupfile)
            'MessageBox.Show("Backup Done !!!!" & vbCrLf + Backupfile)
            conn.Close()
            msg = "File Succesfully Copied !!!<br/>"
        Catch ex As Exception
            msg = "!!!!!!!!!!ERROR @ FILE COPY!!!!<br>"
            msg += ex.Message & "<br/>"
            ' MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ZipMe()
        Try
            ZippedBackupfile = "C:\TEMP\backup.zip"
            Rebex.Licensing.Key = "==AK7pEwbc99VIOGsKjqXcVCEnDcqGMuBimRnxXjfMk7oQ=="
            ZipArchive.Add(ZippedBackupfile, Backupfile, "/", TraversalMode.NonRecursive, TransferMethod.Copy, ActionOnExistingFiles.OverwriteAll)
            msg += "File Succesfully Zipped !!!<br/>"
        Catch ex As Exception
            msg += "!!!!!!!!!!ERROR @ FILE ZIP!!!!<br>"
            msg += ex.Message & "<br/>"
        End Try
    End Sub
    'syndesh me ton smtp server ths google 
    'dhmiourgeia tou mail me 8ema mysqlbackup service report
    'kai san body ta mhnymata (epityxeias/sfalmatos) ka8
    'olh th diadikasia tou backup
    Private Sub SentMail()
        Try
            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential("mysqlbackupgr.adopse@gmail.com", "ADOPSE8adopse")
            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "smtp.gmail.com"
            msg += Backupfile & " <br/> BackUp Succesfully Done !!!!<br/> Wait for the next Report<br/> Thank you for your preference "
            e_mail = New MailMessage()
            e_mail.From = New MailAddress("mysqlbackupgr.adopse@gmail.com")
            e_mail.To.Add("iliasseitanidis@gmail.com") ''
            e_mail.To.Add("tazzyannie@gmail.com")
            e_mail.To.Add("gcharita@it.teithe.gr")
            e_mail.Subject = "MySQLBackUp Service Report"
            e_mail.IsBodyHtml = True
            e_mail.Body = msg
            Smtp_Server.Send(e_mail)
        Catch ex As Exception
        End Try
    End Sub
    'Syndesh me to sftp server , dhmiourgeia tou katalogou
    'MySQLBackup kai apostolh tou zipparismenou arxeiou
    'pou periexei tis entoles ths mysql
    Private Sub MySFTP()
        Dim url As String = String.Empty
        Try
            url = "ftpserver"
            Dim uname As String = "username"
            Dim passwd As String = "passwd"
            'Dim port As Integer = 22
            Dim RemoteDirectory As String = "MySQLBackup"
            Dim sshCp As SshTransferProtocolBase
            sshCp = New Sftp(url, uname)
            sshCp.Password = passwd
            sshCp.Connect()
            'sshCp.Mkdir(RemoteDirectory)

            sshCp.Put(ZippedBackupfile, RemoteDirectory & "/" & "backup.zip") ''
            sshCp.Close()
            msg += "File Succesfully Uploaded @ FTP SERVER " & url & " !!!<br/>"
        Catch ex As Exception
            msg += "!!!!!!!!!!ERROR @ FILE Uploaded @ FTP SERVER " & url & "!!!!<br>"
            msg += ex.Message & "<br/>"
        End Try
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim MyLog As New EventLog() ' create a new event log
        ' Check if the the Event Log Exists
        If Not Diagnostics.EventLog.SourceExists("MyService") Then
            Diagnostics.EventLog.CreateEventSource("MyService", "Myservice Log")
            ' Create Log
        End If
        MyLog.Source = "MyService"
        ' Write to the Log
        Diagnostics.EventLog.WriteEntry("MyService Log", "This is log on " & _
                          CStr(TimeOfDay), _
                          EventLogEntryType.Information)
    End Sub
End Class
