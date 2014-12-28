Imports Newtonsoft.Json.Linq
Imports System.Web
Imports System.Collections.Specialized
Imports System.Net
Imports System.Text
Imports System.IO
Public Class BoxAuth
    Private path As String
    Public Sub New(ByVal value As String)
        InitializeComponent()
        path = value
    End Sub
    '''''''START OF TAKING THE TOKEN
    Private Sub wb_Navigated(sender As Object, e As WebBrowserNavigatedEventArgs) Handles wb.Navigated
        If (wb.Url.ToString.Contains("code=")) Then

            Dim parms As NameValueCollection = HttpUtility.ParseQueryString(e.Url.Query)
            If (parms.AllKeys.Contains("error")) Then
                MessageBox.Show("ERROR")
                Else
                boxContinue(parms("code"))
            End If
        End If
    End Sub

    Private Sub boxContinue(code As String)
        Dim BoxClientId As String = "*************************" '''''''''''''''''''''
        Dim BoxSecret As String = "***************************" '''''''''''''''''''''
        Dim json As String = postToUrl("https://www.box.com/api/oauth2/token", "grant_type=authorization_code&code=" + code + "&client_id=" + BoxClientId + "&client_secret=" + BoxSecret)
        'postToUrl("https://www.box.com/api/oauth2/token", "client_id=" & BoxClientId & "&client_secret=" & BoxSecret & "&grant_type=urn:box:oauth2:grant-type:provision&username=mysqlbackupgr.adopse@gmail.com")
        Dim token As JToken = JObject.Parse(json)
        Dim access_token As String = token.SelectToken("access_token").ToString
        Dim refresh_token As String = token.SelectToken("refresh_token").ToString
        ' Dim path As String = "C:\TEMP\BoxToken.txt"

        ' Create or overwrite the file. 
        Dim fs As FileStream = File.Create(path)

        ' Add text to the file. 
        Dim info As Byte() = New UTF8Encoding(True).GetBytes(access_token & vbCrLf & refresh_token)
        fs.Write(info, 0, info.Length)
        fs.Close()
        Me.Close()
    End Sub

    Private Function postToUrl(url As String, data As String) As String
        Dim results As String = String.Empty
        Dim req As WebRequest = WebRequest.Create(url)
        req.Method = WebRequestMethods.Http.Post
        Dim byteArray() As Byte = Encoding.UTF8.GetBytes(data)
        req.ContentType = "application/x-www-form-urlencoded"
        req.ContentLength = byteArray.Length
        Dim dataStream As Stream = req.GetRequestStream()
        dataStream.Write(byteArray, 0, byteArray.Length)
        dataStream.Close()
        Dim res As WebResponse = req.GetResponse()
        dataStream = res.GetResponseStream()
        Dim reader As StreamReader = New StreamReader(dataStream)
        results = reader.ReadToEnd()
        Return results
    End Function
    '''''''END OF TAKING THE TOKEN
End Class