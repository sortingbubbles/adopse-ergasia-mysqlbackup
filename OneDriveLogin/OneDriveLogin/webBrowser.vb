Imports System.Net
Imports System.IO
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Public Class webBrowser


    Public token As String = ""
    Public code As String = ""
    Private refreshToken As String = ""


    'Μετά το φόρτωμα της σελίδας ελέγχεται εάν το url έχει το access token
    'Εάν υπάρχει το αποθηκεύει στη μεταβλητή token
    Private Sub WebBrowser1_Navigated(sender As Object, e As WebBrowserNavigatedEventArgs) Handles WebBrowser1.Navigated
        Dim uriString() As String
        If (WebBrowser1.Url.ToString.Contains("?code")) Then
            uriString = WebBrowser1.Url.ToString.Split("=&".ToCharArray)
            code = uriString(1)
            WebBrowser1.Visible = False

            Dim url As String = String.Format("https://login.live.com/oauth20_token.srf?client_id={0}&client_secret=qkMMeEhpLbM5GAfVJRWVPfo9PzuIjEGD&code={1}&grant_type=authorization_code&redirect_uri=https://login.live.com/oauth20_desktop.srf", Form1.client_id, code)

            GetTokens(url)
        End If


        ' για debugging του upload
        'Console.WriteLine(WebBrowser1.Url.ToString())


    End Sub

    Private Sub GetTokens(url As String)
        Dim req As HttpWebRequest
        req = HttpWebRequest.Create(url)

        Dim objStream As Stream

        objStream = req.GetResponse().GetResponseStream()

        Dim objReader As New StreamReader(objStream)

        Dim json As String = objReader.ReadLine()
        Dim ser As JObject = JObject.Parse(json)
        Dim data As List(Of JToken) = ser.Children().ToList



        For Each item As JProperty In data
            'Console.WriteLine(item.Name.ToString + " " + item.Value.ToString)
            If (item.Name.ToString.Equals("refresh_token")) Then
                refreshToken = item.Value
            ElseIf (item.Name.ToString.Equals("access_token")) Then
                token = item.Value
            End If
        Next

        SaveRefreshToken()

    End Sub


    Private Sub SaveRefreshToken()
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter("C:\Users\Annie\Desktop\refresh_token.txt", True)
        file.WriteLine(refreshToken)
        file.Close()
    End Sub


    Private Sub refreshTokens()
        Dim url As String = String.Format("https://login.live.com/oauth20_token.srf?client_id={0}&client_secret=qkMMeEhpLbM5GAfVJRWVPfo9PzuIjEGD&code={1}&refresh_token={2}&grant_type=refresh_token&redirect_uri=https://login.live.com/oauth20_desktop.srf", Form1.client_id, code, refreshToken)

        GetTokens(url)
    End Sub

End Class