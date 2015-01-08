Imports Newtonsoft.Json.Linq
Imports System.Web
Imports System.Collections.Specialized
Imports System.Net
Imports System.Text
Imports System.IO
Public Class BoxAuth
    'Private tokenPath As String
    Private _MyBoxClient As MyBoxClient
    Public Sub New(ByVal MBox As MyBoxClient)
        InitializeComponent()
        '    tokenPath = value
        _MyBoxClient = MBox
    End Sub
    '''''''START OF TAKING THE TOKEN
    'me th me8odo wb_Navigated perimenoume o xrhsths na paei sth
    'selida ths opoias to url periexei to pedio "code"
    'tote to epistrefoume sthn klash MyBoxClient
    Private Sub wb_Navigated(sender As Object, e As WebBrowserNavigatedEventArgs) Handles wb.Navigated
        If (wb.Url.ToString.Contains("code=")) Then

            Dim parms As NameValueCollection = HttpUtility.ParseQueryString(e.Url.Query)
            If (parms.AllKeys.Contains("error")) Then
                MessageBox.Show("ERROR")
                Else
                'boxContinue(parms("code"))
                _MyBoxClient.Code = parms("code")
            End If
            Me.Close()
        End If
    End Sub
    ''me th me8odo boxContinue metatrepoume to code pou phrame 
    ''apo to prohgoumeno bhma kai to metatrepoume se access_token 
    ''kai se refresh_token ta opoia 8a xrhsimopoih8oun gia 
    ''thn syndesh sto box 
    'Public Sub boxContinue(code As String)
    '    Dim BoxClientId As String = "*************************" '''''''''''''''''''''
    '    Dim BoxSecret As String = "***************************" '''''''''''''''''''''
    '    Dim json As String = postToUrl("https://www.box.com/api/oauth2/token", "grant_type=authorization_code&code=" + code + "&client_id=" + BoxClientId + "&client_secret=" + BoxSecret)
    '    'postToUrl("https://www.box.com/api/oauth2/token", "client_id=" & BoxClientId & "&client_secret=" & BoxSecret & "&grant_type=urn:box:oauth2:grant-type:provision&username=mysqlbackupgr.adopse@gmail.com")
    '    Dim token As JToken = JObject.Parse(json)
    '    Dim access_token As String = token.SelectToken("access_token").ToString
    '    Dim refresh_token As String = token.SelectToken("refresh_token").ToString
    '    ' Dim path As String = "C:\TEMP\BoxToken.txt"

    '    ' Create or overwrite the file. 
    '    Dim fs As FileStream = File.Create(tokenPath)

    '    ' Add text to the file. 
    '    Dim info As Byte() = New UTF8Encoding(True).GetBytes(access_token & vbCrLf & refresh_token)
    '    fs.Write(info, 0, info.Length)
    '    fs.Close()
    '    Me.Close()
    'End Sub

    'Private Function postToUrl(url As String, data As String) As String
    '    Dim results As String = String.Empty
    '    Dim req As WebRequest = WebRequest.Create(url)
    '    req.Method = WebRequestMethods.Http.Post
    '    Dim byteArray() As Byte = Encoding.UTF8.GetBytes(data)
    '    req.ContentType = "application/x-www-form-urlencoded"
    '    req.ContentLength = byteArray.Length
    '    Dim dataStream As Stream = req.GetRequestStream()
    '    dataStream.Write(byteArray, 0, byteArray.Length)
    '    dataStream.Close()
    '    Dim res As WebResponse = req.GetResponse()
    '    dataStream = res.GetResponseStream()
    '    Dim reader As StreamReader = New StreamReader(dataStream)
    '    results = reader.ReadToEnd()
    '    Return results
    'End Function
    '''''''END OF TAKING THE TOKEN
End Class