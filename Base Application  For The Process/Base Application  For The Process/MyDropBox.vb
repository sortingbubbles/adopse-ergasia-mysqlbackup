Imports Newtonsoft.Json.Linq
Imports AppLimit.CloudComputing.SharpBox
Imports AppLimit.CloudComputing.SharpBox.StorageProvider.DropBox
Imports System.IO
Imports System.Xml

Public Class MyDropBox
    Inherits CloudService
    Private _username As String = String.Empty
    Private msg As String = String.Empty
    Private tokenPath As String = String.Empty
    Sub New(ByVal username As String)
        _username = username
        Me.AppID = "dropbox"
    End Sub

    Public Overrides Sub read(ByRef XmlDoc As Xml.XmlDocument)
        Dim taskNode As XmlNode = XmlDoc.GetElementById(Me.AppID)
        tokenPath = taskNode.ChildNodes.Item(0).InnerText
    End Sub

    Public Overrides Sub upload(filePath As String)
        MySQLDropbox(filePath)
        Module1.addToMail(msg)
    End Sub
    'Apostolh tou zip arxeiou pou periexei to backup ston
    'logariasmo tou xrhsth ston katalogo "MySQLBackUp"
    'ka8ws kai thn diagrafh prohgoumenou backup
    Private Sub MySQLDropbox(ByVal ZippedBackupfile As String)
        Try
            Dim config As DropBoxConfiguration = TryCast(CloudStorage.GetCloudConfigurationEasy(nSupportedCloudConfigurations.DropBox), DropBoxConfiguration)
            Dim DropboxStorage As New CloudStorage()
            Dim accessToken As ICloudStorageAccessToken
            Using fs = System.IO.File.Open(tokenPath, FileMode.Open, FileAccess.Read, FileShare.None)
                accessToken = DropboxStorage.DeserializeSecurityToken(fs)
            End Using
            DropboxStorage.Open(config, accessToken)
            DropboxStorage.CreateFolder("/MySQLBackUp")
            DropboxStorage.DeleteFileSystemEntry("/MySQLBackUp")
            DropboxStorage.CreateFolder("/MySQLBackUp")
            DropboxStorage.UploadFile(ZippedBackupfile, "/MySQLBackUp")
            DropboxStorage.Close()
            msg += "File Succesfully Uploaded @ DropBox !!!<br/>"
        Catch ex As Exception
            msg += "!!!!!!!!!!ERROR @ FILE Uploaded @ DropBox !!!!<br>"
            msg += ex.Message & "<br/>"
        End Try
    End Sub
End Class
