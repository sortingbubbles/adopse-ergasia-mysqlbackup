Imports AppLimit.CloudComputing.SharpBox
Imports AppLimit.CloudComputing.SharpBox.StorageProvider.DropBox
Imports System.IO
Public Class DropBox
    Dim ConsumerKey As String = "68xr051z5i36xkb"
    Dim ConsumerSecret As String = "gk2ser4kp2igk7g"
    Dim config As DropBoxConfiguration = TryCast(CloudStorage.GetCloudConfigurationEasy(nSupportedCloudConfigurations.DropBox), DropBoxConfiguration)
    Dim requestToken As DropBoxRequestToken
    Private Sub AuthorizeMe()
        config.AuthorizationCallBack = New Uri("http://www.google.com")
        requestToken = DropBoxStorageProviderTools.GetDropBoxRequestToken(config, ConsumerKey, ConsumerSecret)
        Dim AuthorizationUrl As String = DropBoxStorageProviderTools.GetDropBoxAuthorizationUrl(config, requestToken)
        Process.Start(AuthorizationUrl)
    End Sub
    Private Sub saveMyAuth()
        Dim accessToken As ICloudStorageAccessToken = DropBoxStorageProviderTools.ExchangeDropBoxRequestTokenIntoAccessToken(config, ConsumerKey, ConsumerSecret, requestToken)
        Dim DropboxStorage As New CloudStorage()
        DropboxStorage.Open(config, accessToken)
        'Dim srcFile = Environment.ExpandEnvironmentVariables("C:\TEMP\mysqlbackup.xml")
        'DropboxStorage.UploadFile(srcFile, "/")
        'DropboxStorage.Close()
        Dim File As FileStream = New FileStream("c:\TEMP\DropBoxToken.txt", FileMode.Create, System.IO.FileAccess.Write)
        DropboxStorage.SerializeSecurityTokenToStream(accessToken, File)
        File.Close()
    End Sub
    Private Sub uploadme()
        Dim configio As DropBoxConfiguration = CloudStorage.GetCloudConfigurationEasy(nSupportedCloudConfigurations.DropBox)
        'Dim accessToken As ICloudStorageAccessToken = DropBoxStorageProviderTools.ExchangeDropBoxRequestTokenIntoAccessToken(configio, ConsumerKey, ConsumerSecret, requestToken)
        Dim DropboxStorage As New CloudStorage()
        Dim accessToken As ICloudStorageAccessToken
        Using fs = File.Open("C:\TEMP\MyDropBoxToken.txt", FileMode.Open, FileAccess.Read, FileShare.None)
            accessToken = DropboxStorage.DeserializeSecurityToken(fs)
        End Using
        Console.Beep()

        'Dim storageToken As DropBoxRequestToken = 
        DropboxStorage.Open(configio, accessToken)
        Console.Beep()
        Console.Beep()
        DropboxStorage.CreateFolder("/MySQLBackUp")
        DropboxStorage.DeleteFileSystemEntry("/MySQLBackUp")
        DropboxStorage.CreateFolder("/MySQLBackUp")
        Dim srcFile As String = "C:\TEMP\backup.zip"
        DropboxStorage.UploadFile(srcFile, "/MySQLBackUp")
        Console.Beep()
        Console.Beep()
        Console.Beep()
        DropboxStorage.Close()
    End Sub
End Class
