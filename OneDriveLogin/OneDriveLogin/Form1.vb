Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports Microsoft.Live

Public Class Form1
    Public Const client_id As String = "0000000040139D3E" ' client id της εφαρμογής
    Private Const client_secret As String = "qkMMeEhpLbM5GAfVJRWVPfo9PzuIjEGD" ' client secret της εφαρμογής
    ' Διεύθυνση για αυθεντικοποίηση και request για tokens
    Public address As String = "https://login.live.com/oauth20_authorize.srf?client_id=0000000040139D3E&scope=wl.skydrive_update%20wl.photos%20wl.offline_access&response_type=code&redirect_uri=https://login.live.com/oauth20_desktop.srf"

    'Είσοδος στο one drive για αυθεντικοποίηση και token
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        webBrowser.WebBrowser1.Url = New Uri("https://login.live.com/oauth20_authorize.srf?client_id=0000000040139D3E&scope=wl.skydrive_update%20wl.offline_access&response_type=code&redirect_uri=https://login.live.com/oauth20_desktop.srf")
        webBrowser.Show()
    End Sub

   

    'Ανέβασμα αρχείων
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Dialog για επιλογή αρχείου
        Dim fileName As String = String.Empty
        Using dlg = New OpenFileDialog()
            dlg.Filter = "All Files|*.*"
            If dlg.ShowDialog(Me) = DialogResult.OK Then
                fileName = dlg.FileName
            End If
        End Using

        'PUT Request για ανέβασμα αρχείου
        Dim url As String = String.Format("https://apis.live.net/v5.0/me/skydrive/Files/{0}?access_token={1}", Path.GetFileName(fileName), webBrowser.token)
        Using client = New WebClient()
            client.UploadDataAsync(New Uri(url), "PUT", File.ReadAllBytes(fileName))
        End Using

        'Δοκιμαστικό για δημιουργία φακέλου
        Dim folder_id As String = checkFolder()
    End Sub

    'Γενικές οδηγίες για τη δημιουργία του φακέλου με REST από http://msdn.microsoft.com/en-us/library/dn659743.aspx
    'POST https://apis.live.net/v5.0/me/skydrive

    'Authorization: Bearer ACCESS_TOKEN
    'Content-Type: application/json

    '{
    '   "name": "My example folder"
    '}

    'μέθοδος για δημιουργία φακέλου
    Private Function checkFolder() As String
        Dim f_id As String = ""

        'Aρχείο json για τον φάκελο MySQLBackUp
        'Περιέχει τα εξής:
        ' {
        '       "MySQLBackUp": "MySQL databases backup folder"
        ' }
        Dim fileName As String = "C:\Users\Annie\Desktop\folder.json"

        'Μετατροπή σε bytes
        Dim data() As Byte = File.ReadAllBytes(fileName)

        Dim url As String = String.Format("https://apis.live.net/v5.0/me/skydrive")
        Dim request As HttpWebRequest = HttpWebRequest.Create(url)
        request.Credentials = CredentialCache.DefaultNetworkCredentials
        request.Method = "POST"

        'request.Headers.Add("Authorization: Bearer " + webBrowser.token)
        request.Headers.Add("Authorization", webBrowser.token)

        request.ContentLength = data.Length

        request.ContentType = "application/json"

        Dim dataStream = request.GetRequestStream()
        dataStream.Write(data, 0, data.Length)
        dataStream.Close()

        'Εδώ πέρα βγάζει σφάλμα 400 (bad request) ή 401 (no authorization) ανάλογα με το τι έχω στο Authorization Header
        Dim response As HttpWebResponse = request.GetResponse()

        Console.WriteLine(response.StatusDescription)

        Dim datas As Stream = response.GetResponseStream


        Dim reader As New StreamReader(dataStream)
        Dim responseFromServer As String = reader.ReadToEnd()
        Console.WriteLine(responseFromServer)


        reader.Close()
        datas.Close()
        response.Close()


    
        Return f_id

      
    End Function


End Class
