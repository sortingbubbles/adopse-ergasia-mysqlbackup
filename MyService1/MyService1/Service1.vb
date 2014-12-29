Imports MySql.Data.MySqlClient
'Imports System.IO.Packaging
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
Imports Google
Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Drive.v2
Imports Google.Apis.Drive.v2.Data
Imports Google.Apis.Services
Imports Google.Apis.Util.Store
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json.Linq

Public Class Service1
    Private msg As String = String.Empty
    Private Backupfile As String = String.Empty
    Private ZippedBackupfile As String = String.Empty
    'Epikoinwnia me thn Efarmogh(Windows Form)
    'gia to pote na diabasei to xml arxeio
    Protected Overrides Sub OnCustomCommand(command As Integer)
        Select Case command
            Case 129
                CreateBackUp()
            Case 130
                ' ReadXML()
        End Select
        'MyBase.OnCustomCommand(command)
    End Sub
    Protected Overrides Sub OnStart(ByVal args() As String)
        'CreateBackUp()
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.
    End Sub


    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.
    End Sub

    '!!!!!!!kante syndesh me vpn me to tmhma!!!!!!!!
    'syndesh me ton server 192.168.6.153 sth bash adopse 
    'me uid mysqlbackup sthn default port 3306
    'kanei backup me thn entolh mb.exporttofile(file) 
    'kai sth synexeia ap8hkeyei to .sql arxeio 
    'ston katalogo c:\temp me onoma arxeiou backup
    'kai to timestamp ths dhmiourgeias me format
    'yyyy-mm-dd hh-mm-ss
    Private Sub Backup()
        ' Dim constring As String = "Server=192.168.6.153;Database=adopse;Uid=mysqlBackup;Pwd=;"
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
    'Me8odos gia th dhmiourgeia 
    'sympiesmenou arxeiou 
    'pou periexei to backup File
    Private Sub ZipMe()
        ZippedBackupfile = "C:\TEMP\backup.zip" ''''''''''''''''''''''''''''''''
        Try
            Dim zip As ZipFile = New ZipFile()
            zip.AddFile(Backupfile)
            zip.Save(ZippedBackupfile)
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
            Smtp_Server.Credentials = New Net.NetworkCredential("mysqlbackupgr.adopse@gmail.com", "**************")
            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "smtp.gmail.com"
            msg += Backupfile & " <br/> BackUp Succesfully Done !!!!<br/> Wait for the next Report<br/> Thank you for your preference "
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

    Private Sub CreateBackUp()
        Backup()
        ZipMe()
        ' MySFTP()
        ' MySQLDropbox()
        'MySQLBox()
        'MySQLGoogleDrive()
        SentMail()
    End Sub
#Region "UPLOAD ZIPPEDFILE"
    'Apostolh tou zip arxeiou pou periexei to backup ston
    'logariasmo tou xrhsth ston katalogo "MySQLBackUp"
    'ka8ws kai thn diagrafh prohgoumenou backup
    Private Sub MySQLDropbox()
        Try
            Dim config As DropBoxConfiguration = TryCast(CloudStorage.GetCloudConfigurationEasy(nSupportedCloudConfigurations.DropBox), DropBoxConfiguration)
            Dim DropboxStorage As New CloudStorage()
            Dim accessToken As ICloudStorageAccessToken
            Using fs = System.IO.File.Open("C:\TEMP\MyToken.txt", FileMode.Open, FileAccess.Read, FileShare.None)
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
    'h me8odos pou ekkinei th diadikasia tou upload sto box.com
    'opou metatrepoume se System.IO.Stream to arxeio pou 8eloume 
    'na anebasoume
    Private Sub MySQLBox()
        Try
            Dim fileName As String = "C:\TEMP\backup.zip"
            Dim currentFileStream As System.IO.Stream = System.IO.File.Open(fileName, FileMode.Open)
            Me.UploadToBox(fileName, currentFileStream)
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
    'I vasiki methodos me tin opoia ginete to upload
    'tou zipped backup file sto Google Drive ston katalogo MySQLBackUp
    'Dimiourgoume to protipo arxeio zip, orizoume ton parent iso me to
    'id tou katalogou MySQLBackUp, kanoume upload to arxeio backup.zip
    'kai diagrafoume to palio arxeio zip (me xrisi tou id tou)
    Private Sub MySQLGoogleDrive()
        Try
            Dim service As DriveService = getGoogleDriveService()
            Dim Title As String = "Backup.zip"
            Dim Description As String = "The backup of your mysql database"
            Dim MimeType As String = "application/zip"
            ' Dim FileName As String = "C:\TEMP\backup.zip" ''''''''''
            Dim folderId As String = getFolderId()
            DeleteFilesFromFolder(service, folderId)
            Dim file As Google.Apis.Drive.v2.Data.File = insertFile(service, Title, Description, folderId, MimeType, ZippedBackupfile)
            msg += "!!!!!!!!!! FILE Uploaded @ GoogleDrive !!!!<br>"
        Catch ex As Exception
            msg += "!!!!!!!!!!ERROR @ FILE Uploaded @ GoogleDrive !!!!<br>"
            msg += ex.Message & "<br/>"
        End Try
    End Sub
    'Voithitiki methodos tis MySQLGoogleDrive i opoia kanei to authorization
    'kai epistrefei antikeimeno tupou DriveService me to opoio 
    'mporoume na diaxiristoume to Google Drive
    Private Function getGoogleDriveService() As DriveService
        Dim CLIENT_ID As String = "**********************************************"
        Dim CLIENT_SECRET As String = "************************"
        Dim APP_USER_AGENT As String = "Drive API Sample"
        Dim SCOPES As String() = New String() {DriveService.Scope.Drive}
        Dim credential As UserCredential = GoogleWebAuthorizationBroker.AuthorizeAsync(New ClientSecrets() With { _
                .ClientId = CLIENT_ID, _
                .ClientSecret = CLIENT_SECRET _
            }, SCOPES, getUserId(), CancellationToken.None, getPersistentCredentialStore()).Result
        Dim service As DriveService = New DriveService(New BaseClientService.Initializer() With { _
                .HttpClientInitializer = credential, _
                .ApplicationName = APP_USER_AGENT _
            })
        Return service
    End Function
    'Voithitiki methodos i opoia epistrefei to anagnoristiko tou xristi
    '(den exei na kanei me gmail, apla einai katei tou prosdiorizei
    'monadika ton xristi)
    Private Shared Function getUserId() As String
        Return "user"
    End Function
    'Voithitiki methodos i opoia epistrefei ena antikeimeno IDataStore
    'Me tin xrisi autou tou antikeimenou ginete i apothikeusi ton
    'tokens se enan fakelo (Dimiourgite ena arxeio gia kathe xristi)
    'kathos episis kai i anaktisi oson einai apothikeumena
    Private Shared Function getPersistentCredentialStore() As IDataStore
        Return New FileDataStore("C:\TEMP\TestGoogleDrive", True)
    End Function
    'Voithitiki methodos i opoia kanei to upload tou arxeiou pou vriskete 
    'stin topothesia <filename> me titlo <title>, perigrafi <description> kai
    'tupo <mimeType> kato apo ton fakelo me id <parentId>. Epistrefete 
    'ena antikeimeno tupou File pou periexei to id tou arxeiou pou molis anevike
    Private Shared Function insertFile(ByVal service As DriveService, ByVal title As String, ByVal description As String, _
                                    ByVal parentId As String, ByVal mimeType As String, ByVal filename As String) As Google.Apis.Drive.v2.Data.File
        Dim body As Google.Apis.Drive.v2.Data.File = New Google.Apis.Drive.v2.Data.File
        body.Title = title
        body.Description = description
        body.MimeType = mimeType
        If Not String.IsNullOrEmpty(parentId) Then
            body.Parents = {New ParentReference() With {.Id = parentId}}
        End If
        Dim byteArray() As Byte = System.IO.File.ReadAllBytes(filename)
        Dim stream As MemoryStream = New MemoryStream(byteArray)
        Dim request As FilesResource.InsertMediaUpload = service.Files.Insert(body, stream, mimeType)
        request.Upload()
        Dim file As Google.Apis.Drive.v2.Data.File = request.ResponseBody
        Return file
    End Function
    'Voithitiki methodos i opoia diagrafei to arxeio me id <fileId>
    Public Shared Sub DeleteFile(ByVal service As DriveService, ByVal fileId As String)
        service.Files.Delete(fileId).Execute()
    End Sub
    'Voithitiki methodos i opoia diagrafei ola ta arxeia apo ton katalogo
    'me id <folderId>
    Public Shared Sub DeleteFilesFromFolder(ByVal service As DriveService, ByVal folderId As String)
        Dim request As ChildrenResource.ListRequest = service.Children.List(folderId)
        Dim children As ChildList = request.Execute
        For Each child As ChildReference In children.Items
            DeleteFile(service, child.Id)
        Next
    End Sub
    'Voithitiki methodos i opoia epistrefei to id tou katalogou MySQLBackUp
    '(apo to xml arxeio) pou dimiourgite mia fora stin arxi
    Private Function getFolderId() As String
        Dim folderId As String = ""
        Return folderId
    End Function


    'Ανέβασμα του backup.zip στο onedrive
    Private Sub MySQLOneDrive()
        'Πεδίο κλειδί για την δημιουργία αιτημάτων προς το onedrive
        Dim accessToken As String = getOneDriveAccessToken()
        'Αρχείο προς ανέβασμα
        Dim fileName As String = "C:\TEMP\backup.zip"

        'Αποθήκευση του αναγνωριστικού του φακέλου στον οποίο θέλουμε να ανεβεί το αρχείο backup.zip
        'Σε περίπτωση που δεν υπάρχει, επιστρέφει κενό String ("")
        Dim folderID As String = checkFolder(accessToken)

        'Σε περίπτωση που δεν υπάρχει ο φάκελος "MySQLBackUP", καλείται η μέθοδος για δημιουργήσει τον φάκελο
        If folderID.Equals("") Then
            folderID = createFolder(accessToken)
        End If

        'Προετοιμασία της διεύθυνσης για το ανέβασμα του αρχείου
        Dim url As String = String.Format("https://apis.live.net/v5.0/{0}/files/{1}?access_token={2}", folderID, Path.GetFileName(fileName), accessToken)

        'Το αρχείο ανεβαίνει με ένα PUT request
        Using client = New WebClient()
            client.UploadDataAsync(New Uri(url), "PUT", System.IO.File.ReadAllBytes(fileName))
            client.GetType()
        End Using
    End Sub

    'Μέθοδος για την απόκτηση του access token 
    Private Function getOneDriveAccessToken() As String
        'Πεδίο που επιστρέφεται κατά τη διάρκεια της αυθεντικοποίησης
        Dim authCode As String = readFromFile("C:\TEMP\authCode.txt")
        'Πεδίο για τη ανανέωση του access token
        Dim refreshToken As String = readFromFile("C:\TEMP\OneDriveRefreshToken.txt")
        'Αναγνωριστικό της εφαρμογής MySQLBackUP
        Dim clientID As String = "*****************************"
        'Αναγνωριστικό της εφαρμογής MySQLBackUP
        Dim clientSecret As String = "**************************"

        'Προετοιμασία της διεύθυνσης για το αίτημα ανανέωσης των tokens (
        Dim url As String = String.Format("https://login.live.com/oauth20_token.srf?client_id={0}&client_secret={1}&code={2}&refresh_token={3}&grant_type=refresh_token&redirect_uri=https://login.live.com/oauth20_desktop.srf", clientID, clientSecret, authCode, refreshToken)

        'Ανανέωση και αποθήκευση των tokens.
        'Στη 1η θέση επιστρέφεται το refresh token και στη 2η το access token
        Dim tokens() As String = getOneDriveTokens(url)

        'Αποθήκευση του νέου refresh token στο αρχείο "C:\TEMP\OneDriveRefreshToken.txt"
        saveNewRefreshToken(tokens(0))

        'Επιστροφή του access token
        Return tokens(1)
    End Function

    'Μέθοδος που κάνει το αίτημα για απόκτηση νέων tokens
    Private Function getOneDriveTokens(url As String) As String()
        Dim tokens() As String = {"", ""}
        Dim req As HttpWebRequest
        req = HttpWebRequest.Create(url)

        'Αίτηση απάντησης
        Dim objStream As Stream
        objStream = req.GetResponse().GetResponseStream()
        Dim objReader As New StreamReader(objStream)

        'Η απάντηση επιστρέφεται σε μορφή json 
        Dim json As String = objReader.ReadLine()
        Dim ser As JObject = JObject.Parse(json)
        Dim data As List(Of JToken) = ser.Children().ToList

        'Αποθήκευση των tokens από το json
        For Each item As JProperty In data
            If (item.Name.ToString.Equals("refresh_token")) Then
                tokens(0) = item.Value
            ElseIf (item.Name.ToString.Equals("access_token")) Then
                tokens(1) = item.Value
            End If
        Next

        Return tokens
    End Function

    'Μέθοδος που αποθηκεύει το νέο refresh token σε αρχείο text
    Private Sub saveNewRefreshToken(refreshToken As String)
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter("C:\TEMP\OneDriveRefreshToken.txt", True)
        file.WriteLine(refreshToken)
        file.Close()
    End Sub

    'Μέθοδος ανάγνωσης text αρχείων
    'Χρησιμοποιείται για την ανάγνωση του authorization code και του refresh token 
    'Τα αρχεία αυτά (authCode.txt και OneDriveRefreshToken.txt) δημιουργούνται κατά τη διάρκεια της αρχικής αυθεντικοποίησης
    Private Function readFromFile(fileName As String) As String
        Dim fileReader As String
        fileReader = My.Computer.FileSystem.ReadAllText(fileName)
        Return fileReader
    End Function

    'Βοηθητική μέθοδος για την εύρυση του folder id του φακέλου "ΜySQLBackUp" στο onedrive
    'Πραγματοποιείται ένα αίτημα το οποίο επιστρέφει τη λίστα με όλα τα αντικείμενα του χρήστη στο onedrive
    Private Function checkFolder(accessToken As String) As String
        Dim url As String = String.Format("https://apis.live.net/v5.0/me/skydrive/files?access_token={0}", accessToken)
        Try

            Dim req As HttpWebRequest
            req = HttpWebRequest.Create(url)
            req.Method = "GET"

            Dim objStream As Stream
            objStream = req.GetResponse().GetResponseStream()
            Dim objReader As New StreamReader(objStream)
            Dim json As String = objReader.ReadToEnd()


            Dim ser As JObject = JObject.Parse(json)

            'Αναζήτηση του folder id στο json
            For Each item In ser("data")
                If (item("name").Value(Of String).Equals("MySQLBackUp")) Then
                    Return item("id").Value(Of String)()
                End If
            Next

        Catch ex As WebException
            Return ""
        End Try
        Return ""
    End Function


    'Μέθοδος για τη δημιουργία του φακέλου "MySQLBackUp" σε περίπτωση που δεν υπάρχει
    Private Function createFolder(accessToken As String)
        Try
            'Μετατροπή σε bytes των οδηγιών που πρέπει να στείλουμε για τη δημιουργία του φακέλου
            Dim jsonData() As Byte = Encoding.ASCII.GetBytes(createJsonStructure())
            Dim request As HttpWebRequest = HttpWebRequest.Create("https://apis.live.net/v5.0/me/skydrive")
            'Πραγματοποιείται ένα POST αίτημα με συγκεκριμενες κεφαλίδες
            request.Method = "POST"
            'Κεφαλίδα για την αυθεντικοποίηση
            request.Headers.Add("Authorization: Bearer " + accessToken)
            request.ContentLength = jsonData.Length
            'Οι οδηγίες για τη δημιουργία του φάκέλου ειναι σε μορφή json
            request.ContentType = "application/json"

            Dim dataStream = request.GetRequestStream()
            dataStream.Write(jsonData, 0, jsonData.Length)
            dataStream.Close()

            'Αποδοχή απάντησης
            Dim response As HttpWebResponse = request.GetResponse()
            Dim responseStream As Stream = response.GetResponseStream
            Dim reader As New StreamReader(responseStream)
            'Αναζήτηση του folder id από την απάντηση 
            Return getFolderIDFromJson(reader.ReadToEnd())

            reader.Close()
            responseStream.Close()
            response.Close()
        Catch ex As WebException
            Return ""
        End Try
        Return ""
    End Function

    'Μέθοδος που δημιουργεί τη σύνταξη του json αρχείου για τη αποστολή του στο αίτημα
    Private Function createJsonStructure() As String

        Dim json As StringBuilder = New StringBuilder()
        json.AppendLine("{")
        json.AppendLine("""name"": ""MySQLBackUp""")
        json.AppendLine("}")

        Return json.ToString()
    End Function

    'Μέθοδος που επιστρέφει το folder id από την απάντηση που δίνεται μετά τη δημιουργία του φακέλου
    Private Function getFolderIDFromJson(json As String) As String
        Dim ser As JObject = JObject.Parse(json)
        Dim data As List(Of JToken) = ser.Children().ToList
        For Each item As JProperty In data
            Console.WriteLine(item.Name.ToString + " " + item.Value.ToString)
            If (item.Name.ToString.Equals("id")) Then
                Return item.Value
            End If
        Next
        Return ""
    End Function

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
End Class

