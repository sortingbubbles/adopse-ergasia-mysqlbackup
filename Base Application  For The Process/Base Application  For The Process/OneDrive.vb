Imports System.Net
Imports System.Text
Imports Newtonsoft.Json.Linq
Imports System.IO

Public Class ΟneDrive
    Inherits CloudService
    Private refreshTokenPath As String = String.Empty
    Private authCodePath As String = String.Empty
    Private userName As String

    Sub New(ByVal username As String)
        username = username
        Me.AppID = "onedrive"
    End Sub

    Public Overrides Sub read(ByRef XmlDoc As Xml.XmlDocument)
        refreshTokenPath = XmlDoc.GetElementsByTagName("refreshTokenPath").Item(0).InnerText
        authCodePath = XmlDoc.GetElementsByTagName("authCodePath").Item(0).InnerText

    End Sub

    Public Overrides Function upload(filePath As String) As String
        Dim Msg As String = String.Empty
        Try
            'Αποθήκευση του αναγνωριστικού του φακέλου στον οποίο θέλουμε να ανεβεί το αρχείο backup.zip
            'Σε περίπτωση που δεν υπάρχει, επιστρέφει κενό String ("")
            Dim accessToken As String = getOneDriveAccessToken()

            'Αποθήκευση του αναγνωριστικού του φακέλου στον οποίο θέλουμε να ανεβεί το αρχείο backup.zip
            'Σε περίπτωση που δεν υπάρχει, επιστρέφει κενό String ("")
            Dim folderID As String = checkFolder(accessToken)

            'Σε περίπτωση που δεν υπάρχει ο φάκελος "MySQLBackUP", καλείται η μέθοδος για δημιουργήσει τον φάκελο
            If folderID.Equals("") Then
                folderID = createFolder(accessToken)
            End If

            'Προετοιμασία της διεύθυνσης για το ανέβασμα του αρχείου
            Dim url As String = String.Format("https://apis.live.net/v5.0/{0}/files/{1}?access_token={2}", folderID, Path.GetFileName(filePath), accessToken)

            'Το αρχείο ανεβαίνει με ένα PUT request
            Using client = New WebClient()
                client.UploadDataAsync(New Uri(url), "PUT", System.IO.File.ReadAllBytes(filePath))
                client.GetType()
            End Using
            Msg += "File Succesfully Uploaded @ OneDrive !!!<br/>"
        Catch ex As Exception
            Msg += "!!!!!!!!!!ERROR @ FILE Uploaded @ OneDrive !!!!<br>"
            Msg += ex.Message & "<br/>"
        End Try
        Return Msg
    End Function




    'Μέθοδος για την απόκτηση του access token 
    Private Function getOneDriveAccessToken() As String

        'Πεδίο που επιστρέφεται κατά τη διάρκεια της αυθεντικοποίησης
        Dim authCode As String = File.ReadAllText(authCodePath)

        'Πεδίο για τη ανανέωση του access token
        Dim refreshToken As String = File.ReadAllText(refreshTokenPath)
        'Αναγνωριστικό της εφαρμογής MySQLBackUP
        Dim clientID As String = "*******************"
        'Αναγνωριστικό της εφαρμογής MySQLBackUP
        Dim clientSecret As String = "************************************"

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
        file = My.Computer.FileSystem.OpenTextFileWriter("C:\TEMP\" & userName & "\OneDriveRefreshToken.txt", False)
        file.WriteLine(refreshToken)
        file.Close()
    End Sub

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
End Class
