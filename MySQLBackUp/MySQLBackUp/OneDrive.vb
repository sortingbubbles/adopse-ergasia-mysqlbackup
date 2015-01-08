Imports System.Xml

Public Class OneDrive
    Inherits CloudService
    Private clientID As String = "*********************" ' client id της εφαρμογής
    Private clientSecret As String = "*************************" ' client secret της εφαρμογής
    Private oneDriveBrowser As OneDriveBrowser = New OneDriveBrowser(clientID, clientSecret)

    Private authorizationCode As String
    Private refreshToken As String


    Public Overrides Sub Authenticate()
        Dim url As String = String.Format("https://login.live.com/oauth20_authorize.srf?client_id={0}&scope=wl.skydrive_update%20wl.offline_access&response_type=code&redirect_uri=https://login.live.com/oauth20_desktop.srf", clientID)
        oneDriveBrowser.OneDriveAuth.Url = New Uri(url)
        oneDriveBrowser.Show()
    End Sub

    Public Overrides Sub Save(XmlDocPath As String)

    End Sub


End Class
