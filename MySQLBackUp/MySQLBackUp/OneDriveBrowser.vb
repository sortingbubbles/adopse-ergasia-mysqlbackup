Imports System.Net
Imports System.IO
Imports Newtonsoft.Json.Linq

Public Class OneDriveBrowser

    Private Sub OneDriveAuth_Navigated(sender As Object, e As WebBrowserNavigatedEventArgs) Handles OneDriveAuth.Navigated
        Dim uriString() As String
        Dim authCode As String = ""
        Dim clientID As String = "*****************" ' client id της εφαρμογής
        Dim clientSecret As String = "*******************" ' client secret της εφαρμογής
        If (OneDriveAuth.Url.ToString.Contains("?code")) Then
            uriString = OneDriveAuth.Url.ToString.Split("=&".ToCharArray)
            authCode = uriString(1)
            'Αποθήκευση του authorization code σε αρχείο για μελλοντική χρήση
            saveToFile(authCode, "c:\TEMP\authCode.txt")

            OneDriveAuth.Visible = False

            'Προετοιμασία διεύθυνσης για αίτηση των tokens
            Dim url As String = String.Format("https://login.live.com/oauth20_token.srf?client_id={0}&client_secret=qkMMeEhpLbM5GAfVJRWVPfo9PzuIjEGD&code={1}&grant_type=authorization_code&redirect_uri=https://login.live.com/oauth20_desktop.srf", clientID, authCode)
            'Αίτηση για tokens
            GetToken(url)
        End If
    End Sub

    'Μέθοδος που κάνει ένα GET αίτημα έτσι ώστε να δεχθεί το refresh token και να το αποθηκεύσει για μελλοντική χρήση
    Private Sub GetToken(url As String)
        Dim req As HttpWebRequest
        req = HttpWebRequest.Create(url)
        Dim refreshToken As String = ""

        'Η απάντηση έρχεται σε μορφή json
        Dim objStream As Stream
        objStream = req.GetResponse().GetResponseStream()
        Dim objReader As New StreamReader(objStream)
        Dim json As String = objReader.ReadLine()
        Dim ser As JObject = JObject.Parse(json)
        Dim data As List(Of JToken) = ser.Children().ToList

        'Επεξεργασία της απάντησης για την εξαγωγή του refresh token
        For Each item As JProperty In data
            If (item.Name.ToString.Equals("refresh_token")) Then
                refreshToken = item.Value
            End If
        Next

        'Αποθηκευση του refresh token σε αρχείο
        saveToFile(refreshToken, "c:\TEMP\OneDriveRefreshToken.txt")

    End Sub

    'Βοηθητική μέθοδος που δημιουργεί text αρχεία
    'Χρησιμοποιείται για την αποθήκευση του authorization code και του refresh token
    Private Sub saveToFile(text As String, fileName As String)
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(fileName, True)
        file.WriteLine(text)
        file.Close()
    End Sub

End Class