Imports System.Xml

Public Class OneDrive
    Inherits CloudService
    Private clientID As String = "*********************" ' client id της εφαρμογής
    Private clientSecret As String = "*************************" ' client secret της εφαρμογής
    Private oneDriveBrowser As OneDriveBrowser = New OneDriveBrowser(clientID, clientSecret)


    Public Overrides Sub Authenticate()
        Dim url As String = String.Format("https://login.live.com/oauth20_authorize.srf?client_id={0}&scope=wl.skydrive_update%20wl.offline_access&response_type=code&redirect_uri=https://login.live.com/oauth20_desktop.srf", clientID)
        oneDriveBrowser.OneDriveAuth.Url = New Uri(url)
        oneDriveBrowser.Show()
    End Sub

    Public Overrides Sub Save(XmlDocPath As String)
        Dim myXmlDocument As XmlDocument = New XmlDocument()
        myXmlDocument.Load(XmlDocPath)
        Dim root As XmlNode = myXmlDocument.DocumentElement
        For Each node As XmlNode In root.ChildNodes
            If node.Name = "tasks" Then
                Dim taskNode As XmlElement = myXmlDocument.CreateElement("task")
                taskNode.SetAttribute("app_id", "onedrive")
                node.AppendChild(taskNode)

                Dim authCodePathNode As XmlElement = myXmlDocument.CreateElement("authCodePath")
                Dim refreshTokenPathNode As XmlElement = myXmlDocument.CreateElement("refreshTokenPath")
                Dim authCodePathText As XmlText = myXmlDocument.CreateTextNode("C:\TEMP\authCode.txt")
                Dim refreshTokenPathText As XmlText = myXmlDocument.CreateTextNode("C:\TEMP\OneDriveRefreshToken.txt")

                taskNode.AppendChild(authCodePathNode)
                taskNode.AppendChild(refreshTokenPathNode)
                authCodePathNode.AppendChild(authCodePathText)
                refreshTokenPathNode.AppendChild(refreshTokenPathText)
            End If
        Next

        myXmlDocument.Save(XmlDocPath)
    End Sub


End Class
