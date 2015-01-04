Imports AppLimit.CloudComputing.SharpBox
Imports AppLimit.CloudComputing.SharpBox.StorageProvider.DropBox
Imports System.IO
Public Class Form1
    Private username As String
    Private email As String
    Private tokenPath As String
    Private constring As String
    Private sftpClient As MyNewSftpClient
    Private CloudeServices As List(Of CloudService)

    ''Emfanizei to Tabpage.Text orizontia anti ka8eta pou einai to default
    Private Sub TabControl1_DrawItem(sender As Object, e As DrawItemEventArgs) Handles TabControl1.DrawItem
        Dim g As Graphics
        Dim sText As String

        Dim iX As Integer
        Dim iY As Integer
        Dim sizeText As SizeF

        Dim ctlTab As TabControl

        ctlTab = CType(sender, TabControl)

        g = e.Graphics

        sText = ctlTab.TabPages(e.Index).Text
        sizeText = g.MeasureString(sText, ctlTab.Font)

        iX = e.Bounds.Left + 6
        iY = e.Bounds.Top + (e.Bounds.Height - sizeText.Height) / 2

        g.DrawString(sText, ctlTab.Font, Brushes.Black, iX, iY)
    End Sub
#Region "Navigation Between Tabs & Assigning Values From Tabs"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabControl1.TabPages("TabPage2").Enabled = False
        TabControl1.TabPages("TabPage3").Enabled = False
        TabControl1.TabPages("TabPage4").Enabled = False
    End Sub

    Private Sub FirstTab_Click(sender As Object, e As EventArgs) Handles FirstTab.Click
        username = FirstTabUsername.Text
        TabControl1.TabPages("TabPage2").Enabled = True
        TabControl1.TabPages("TabPage1").Enabled = False
        TabControl1.SelectedTab = TabControl1.TabPages("TabPage2")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Dim constring As String = "Server=192.168.6.153;Database=adopse;Uid=mysqlBackup;Pwd=;"
        constring = "Server=" & Tab2Server.Text & ";Database=" & Tab2DataBase.Text & ";Uid=" & Tab2Uid.Text & ";Pwd=" & Tab2Pwd.Text & ";"
        TabControl1.TabPages("TabPage3").Enabled = True
        TabControl1.TabPages("TabPage2").Enabled = False
        TabControl1.SelectedTab = TabControl1.TabPages("TabPage3")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        email = Tab3Email.Text
        TabControl1.TabPages("TabPage4").Enabled = True
        TabControl1.TabPages("TabPage3").Enabled = False
        TabControl1.SelectedTab = TabControl1.TabPages("TabPage4")
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If DropBox.Checked Then
            MyDropBox()
        ElseIf Box.Checked Then
            MyBox()
        ElseIf OneDrive.Checked Then
            MyOneDrive()
        ElseIf GoogleDrive.Checked Then
            MyGoogleDrive()
        ElseIf SFTP.Checked Then
            MySFTP()
        End If
    End Sub

#End Region

#Region "Authentication Methods"
    Private Sub MyDropBox()
        tokenPath = "c:\TEMP\DropBoxToken.txt"
        Dim ConsumerKey As String = "****************"
        Dim ConsumerSecret As String = "****************"
        Dim config As DropBoxConfiguration = TryCast(CloudStorage.GetCloudConfigurationEasy(nSupportedCloudConfigurations.DropBox), DropBoxConfiguration)
        Dim requestToken As DropBoxRequestToken
        config.AuthorizationCallBack = New Uri("http://www.google.com")
        requestToken = DropBoxStorageProviderTools.GetDropBoxRequestToken(config, ConsumerKey, ConsumerSecret)
        Dim AuthorizationUrl As String = DropBoxStorageProviderTools.GetDropBoxAuthorizationUrl(config, requestToken)
        Process.Start(AuthorizationUrl)
        Dim accessToken As ICloudStorageAccessToken = DropBoxStorageProviderTools.ExchangeDropBoxRequestTokenIntoAccessToken(config, ConsumerKey, ConsumerSecret, requestToken)
        Dim DropboxStorage As New CloudStorage()
        DropboxStorage.Open(config, accessToken)
        Dim File As FileStream = New FileStream(tokenPath, FileMode.Create, System.IO.FileAccess.Write)
        DropboxStorage.SerializeSecurityTokenToStream(accessToken, File)
        File.Close()
    End Sub

    Private Sub MyBox()
        tokenPath = "C:\TEMP\BoxToken.txt"
        Dim br As New BoxAuth(tokenPath)
        br.wb.Url = New Uri("https://app.box.com/api/oauth2/authorize?response_type=code&client_id=0sl2q9wxpjq6cun6khctch1sg0g86g2u")
        br.ShowDialog()
    End Sub

    Private Sub MyOneDrive()
        tokenPath = "c:\TEMP\OneDriveRefreshToken.txt"
        Dim clientID As String = "***********" ' client id της εφαρμογής
        Dim clientSecret As String = "*******************" ' client secret της εφαρμογής

        Dim url As String = String.Format("https://login.live.com/oauth20_authorize.srf?client_id={0}&scope=wl.skydrive_update%20wl.offline_access&response_type=code&redirect_uri=https://login.live.com/oauth20_desktop.srf", clientID)
        OneDriveBrowser.OneDriveAuth.Url = New Uri(url)
        OneDriveBrowser.Show()
    End Sub

    Private Sub MyGoogleDrive()
        Throw New NotImplementedException
    End Sub
    ''' <summary>
    ''' ''''''''''''''''
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MySFTP()
        sftpClient.Server = ""
        sftpClient.Username = ""
        sftpClient.Password = ""
    End Sub

#End Region

End Class
