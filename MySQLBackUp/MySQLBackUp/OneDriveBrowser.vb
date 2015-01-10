Imports System.Net
Imports System.IO
Imports Newtonsoft.Json.Linq

Public Class OneDriveBrowser
    Private clientID As String
    Private clientSecret As String
    Private userName As String
    Sub New(_clientID As String, _clientSecret As String, _username As String)

        clientID = _clientID
        clientSecret = _clientSecret
        userName = _username
        InitializeComponent()

    End Sub


    Private Sub OneDriveAuth_Navigated(sender As Object, e As WebBrowserNavigatedEventArgs) Handles OneDriveAuth.Navigated
        Dim uriString() As String
        If (OneDriveAuth.Url.ToString.Contains("?code")) Then
            uriString = OneDriveAuth.Url.ToString.Split("=&".ToCharArray)
            Dim authCode As String = uriString(1)
            'Αποθήκευση του authorization code σε αρχείο για μελλοντική χρήση
            saveToFile(authCode, "c:\TEMP\" & userName & "\authCode.txt")

            OneDriveAuth.Visible = False
            Dim url As String = String.Format("https://login.live.com/oauth20_token.srf?client_id={0}&client_secret={1}&code={2}&grant_type=authorization_code&redirect_uri=https://login.live.com/oauth20_desktop.srf", clientID, clientSecret, authCode)

            'Προετοιμασία διεύθυνσης για αίτηση των tokens
            'Αίτηση για tokens
            GetToken(url)
            Me.Visible = False
            Form1.Show()
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
        saveToFile(refreshToken, "c:\TEMP\" & userName & "\OneDriveRefreshToken.txt")

    End Sub

    'Βοηθητική μέθοδος που δημιουργεί text αρχεία
    'Χρησιμοποιείται για την αποθήκευση του authorization code και του refresh token
    Private Sub saveToFile(text As String, fileName As String)
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(fileName, False)
        file.WriteLine(text)
        file.Close()
    End Sub

End Class