Imports System.Xml

Public Class OneDrive
    Inherits CloudService
    Private clientID As String = "********************" ' client id της εφαρμογής
    Private clientSecret As String = "**************************" ' client secret της εφαρμογής
    'Φυλλομετρητής που εμφανίζεται για την ταυτοποίηση του χρήστη
    Private userName As String
    Private oneDriveBrowser As OneDriveBrowser

    Sub New(ByVal _username As String)
        Me.AppID = "onedrive"
        username = _username
        oneDriveBrowser = New OneDriveBrowser(clientID, clientSecret, username)
    End Sub

    'Μέθοδος για την αυθευντικοποίηση του χρήστη στο OneDrive
    'Κληρονομείται από τη baseclass CloudService
    Public Overrides Sub Authenticate()
        'Προετοιμασία url για αίτηση αυθεντικοποίησης
        Dim url As String = String.Format("https://login.live.com/oauth20_authorize.srf?client_id={0}&scope=wl.skydrive_update%20wl.offline_access&response_type=code&redirect_uri=https://login.live.com/oauth20_desktop.srf", clientID)
        oneDriveBrowser.OneDriveAuth.Url = New Uri(url)
        'Εμφάνιση του browser για την εισαγωγή των στοιχείων του χρήστη
        oneDriveBrowser.ShowDialog()
    End Sub


    'Μέθοδος για την αποθήκευση των απαραίτητων πεδίων για το upload στο OneDrive
    'Κληρονομείται από τη baseclass CloudService
    Public Overrides Sub Save(ByRef XmlDoc As XmlDocument)
        Dim tasksNode As XmlNode = XmlDoc.GetElementsByTagName("cloudServices").Item(0)
        Dim taskNode As XmlElement = XmlDoc.CreateElement("cloudService")
        taskNode.SetAttribute("id", Me.AppID)
        tasksNode.AppendChild(taskNode)

        Dim authCodePathNode As XmlElement = XmlDoc.CreateElement("authCodePath")
        Dim refreshTokenPathNode As XmlElement = XmlDoc.CreateElement("refreshTokenPath")
        Dim authCodePathText As XmlText = XmlDoc.CreateTextNode("C:\TEMP\" & userName & "\authCode.txt")
        Dim refreshTokenPathText As XmlText = XmlDoc.CreateTextNode("C:\TEMP\" & userName & "\OneDriveRefreshToken.txt")

        taskNode.AppendChild(authCodePathNode)
        taskNode.AppendChild(refreshTokenPathNode)
        authCodePathNode.AppendChild(authCodePathText)
        refreshTokenPathNode.AppendChild(refreshTokenPathText)
    End Sub

End Class
