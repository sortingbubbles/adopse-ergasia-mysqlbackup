Imports System.Xml
Imports Newtonsoft.Json.Linq
Imports System.Web
Imports System.Collections.Specialized
Imports System.Net
Imports System.Text
Imports System.IO

Public Class MyBoxClient
    Inherits CloudService
    Private _tokenPath As String
    Private _code As String
    Sub New(ByVal username As String)
        _tokenPath = "C:\TEMP\" & username & "\BoxToken.txt"
    End Sub

    Public Property Code() As String
        Get
            Return _code
        End Get
        Set(value As String)
            _code = value
        End Set
    End Property

    Public Overrides Sub Authenticate()
        Dim br As New BoxAuth(Me)
        br.wb.Url = New Uri("https://app.box.com/api/oauth2/authorize?response_type=code&client_id=0sl2q9wxpjq6cun6khctch1sg0g86g2u")
        br.ShowDialog()
    End Sub

    Public Overrides Sub Save(XmlDocPath As String)
        boxContinue()
        Dim myXmlDocument As XmlDocument = New XmlDocument()
        myXmlDocument.Load(XmlDocPath)
        Dim root As XmlNode = myXmlDocument.DocumentElement
        For Each node As XmlNode In root.ChildNodes
            If node.Name = "tasks" Then
                Dim taskNode As XmlElement = myXmlDocument.CreateElement("task")
                taskNode.SetAttribute("app_id", "box")
                node.AppendChild(taskNode)
                Dim tokenPathNode As XmlElement = myXmlDocument.CreateElement("tokenPath")
                Dim tokenPathText As XmlText = myXmlDocument.CreateTextNode(_tokenPath)
                taskNode.AppendChild(tokenPathNode)
                tokenPathNode.AppendChild(tokenPathText)
            End If
        Next
        myXmlDocument.Save(XmlDocPath)
    End Sub
    'me th me8odo boxContinue metatrepoume to code pou phrame 
    'apo to prohgoumeno bhma kai to metatrepoume se access_token 
    'kai se refresh_token ta opoia 8a xrhsimopoih8oun gia 
    'thn syndesh sto box 
    Private Sub boxContinue()
        Dim BoxClientId As String = "*************************" '''''''''''''''''''''
        Dim BoxSecret As String = "***************************" '''''''''''''''''''''
        Dim json As String = postToUrl("https://www.box.com/api/oauth2/token", "grant_type=authorization_code&code=" + _code + "&client_id=" + BoxClientId + "&client_secret=" + BoxSecret)
        'postToUrl("https://www.box.com/api/oauth2/token", "client_id=" & BoxClientId & "&client_secret=" & BoxSecret & "&grant_type=urn:box:oauth2:grant-type:provision&username=mysqlbackupgr.adopse@gmail.com")
        Dim token As JToken = JObject.Parse(json)
        Dim access_token As String = token.SelectToken("access_token").ToString
        Dim refresh_token As String = token.SelectToken("refresh_token").ToString
        ' Dim path As String = "C:\TEMP\BoxToken.txt"

        ' Create or overwrite the file. 
        Dim fs As FileStream = File.Create(_tokenPath)

        ' Add text to the file. 
        Dim info As Byte() = New UTF8Encoding(True).GetBytes(access_token & vbCrLf & refresh_token)
        fs.Write(info, 0, info.Length)
        fs.Close()
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

End Class
