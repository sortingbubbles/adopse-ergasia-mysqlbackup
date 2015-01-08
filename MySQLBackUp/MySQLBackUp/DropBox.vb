Imports AppLimit.CloudComputing.SharpBox
Imports AppLimit.CloudComputing.SharpBox.StorageProvider.DropBox
Imports System.IO
Imports System.Threading
Imports System.Xml

Public Class DropBox
    Inherits CloudService
    Dim ConsumerKey As String = "************"
    Dim ConsumerSecret As String = "**********"
    Dim config As DropBoxConfiguration = TryCast(CloudStorage.GetCloudConfigurationEasy(nSupportedCloudConfigurations.DropBox), DropBoxConfiguration)
    Dim requestToken As DropBoxRequestToken
    Dim tokenPath As String


    Sub New(ByVal username As String)
        tokenPath = "C:\TEMP\" & username & "\MyDropBoxToken.txt"
    End Sub


    '8etoume  to url ths selidas pou 8a odhgh8ei o xrhsths meta to auth
    'kai sth synexeia dhmiourgoume ena request token pou exei 
    'plhrofories gia ton provider a.k.a thn efarmogh mas
    'kai anoigoume ton default WebBrowser gia na ginei h aythentikopoihsh
    Public Overrides Sub Authenticate()
        config.AuthorizationCallBack = New Uri("http://www.google.com")
        requestToken = DropBoxStorageProviderTools.GetDropBoxRequestToken(config, ConsumerKey, ConsumerSecret)
        Dim AuthorizationUrl As String = DropBoxStorageProviderTools.GetDropBoxAuthorizationUrl(config, requestToken)
        Process.Start(AuthorizationUrl)
        Thread.Sleep(50000)
    End Sub
    'pairnoume to requestToken apo to prohgoumeno  bhma kai
    'to metasxhmatizoume se accessToken etsi wste na exoume prosbash ston 
    'fakelo tou xrhsth sto cloudstorage ,sth synexeia afou epalh8eysoume
    'ta credential tou user kai sth synexeia apo8hkeyoume se ena arxeio 
    'tis plhrofories pou xreiazomaste
    Private Sub saveMyAuth()
        '  tokenPath = "C:\TEMP\" & & "\MyDropBoxToken.txt"
        Dim accessToken As ICloudStorageAccessToken = DropBoxStorageProviderTools.ExchangeDropBoxRequestTokenIntoAccessToken(config, ConsumerKey, ConsumerSecret, requestToken)
        Dim DropboxStorage As New CloudStorage()
        DropboxStorage.Open(config, accessToken)
        Dim File As FileStream = New FileStream(tokenPath, FileMode.Create, System.IO.FileAccess.Write)
        DropboxStorage.SerializeSecurityTokenToStream(accessToken, File)
        File.Close()
    End Sub

    Public Overrides Sub Save(XmlDocPath As String)
        saveMyAuth()
        Dim myXmlDocument As XmlDocument = New XmlDocument()
        myXmlDocument.Load(XmlDocPath)
        Dim root As XmlNode = myXmlDocument.DocumentElement
        For Each node As XmlNode In root.ChildNodes
            If node.Name = "tasks" Then
                Dim taskNode As XmlElement = myXmlDocument.CreateElement("task")
                taskNode.SetAttribute("app_id", "dropbox")
                node.AppendChild(taskNode)
                Dim tokenPathNode As XmlElement = myXmlDocument.CreateElement("tokenPath")
                Dim tokenPathText As XmlText = myXmlDocument.CreateTextNode(tokenPath)
                taskNode.AppendChild(tokenPathNode)
                tokenPathNode.AppendChild(tokenPathText)
            End If
        Next
        myXmlDocument.Save(XmlDocPath)
    End Sub
End Class
