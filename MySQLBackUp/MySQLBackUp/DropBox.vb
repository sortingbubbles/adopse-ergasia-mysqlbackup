Imports AppLimit.CloudComputing.SharpBox
Imports AppLimit.CloudComputing.SharpBox.StorageProvider.DropBox
Imports System.IO
Imports System.Threading
Public Class DropBox
    Dim ConsumerKey As String = "************"
    Dim ConsumerSecret As String = "**********"
    Dim config As DropBoxConfiguration = TryCast(CloudStorage.GetCloudConfigurationEasy(nSupportedCloudConfigurations.DropBox), DropBoxConfiguration)
    Dim requestToken As DropBoxRequestToken
    '8etoume  to url ths selidas pou 8a odhgh8ei o xrhsths meta to auth
    'kai sth synexeia dhmiourgoume ena request token pou exei 
    'plhrofories gia ton provider a.k.a thn efarmogh mas
    'kai anoigoume ton default WebBrowser gia na ginei h aythentikopoihsh
    Public Sub AuthorizeMe()
        config.AuthorizationCallBack = New Uri("http://www.google.com")
        requestToken = DropBoxStorageProviderTools.GetDropBoxRequestToken(config, ConsumerKey, ConsumerSecret)
        Dim AuthorizationUrl As String = DropBoxStorageProviderTools.GetDropBoxAuthorizationUrl(config, requestToken)
        Process.Start(AuthorizationUrl)
        Thread.Sleep(30000)
    End Sub
    'pairnoume to requestToken apo to prohgoumeno  bhma kai
    'to metasxhmatizoume se accessToken etsi wste na exoume prosbash ston 
    'fakelo tou xrhsth sto cloudstorage ,sth synexeia afou epalh8eysoume
    'ta credential tou user kai sth synexeia apo8hkeyoume se ena arxeio 
    'tis plhrofories pou xreiazomaste
    Public Sub saveMyAuth()
        Dim accessToken As ICloudStorageAccessToken = DropBoxStorageProviderTools.ExchangeDropBoxRequestTokenIntoAccessToken(config, ConsumerKey, ConsumerSecret, requestToken)
        Dim DropboxStorage As New CloudStorage()
        DropboxStorage.Open(config, accessToken)
        Dim File As FileStream = New FileStream("C:\TEMP\MyDropBoxToken.txt", FileMode.Create, System.IO.FileAccess.Write)
        DropboxStorage.SerializeSecurityTokenToStream(accessToken, File)
        File.Close()
    End Sub
 
End Class
