﻿Imports Newtonsoft.Json.Linq
Imports AppLimit.CloudComputing.SharpBox
Imports AppLimit.CloudComputing.SharpBox.StorageProvider.DropBox
Imports System.IO
Imports System.Xml

Public Class MyDropBox
    Inherits CloudService
    Private _username As String = String.Empty
    Private tokenPath As String = String.Empty
    Sub New(ByVal username As String)
        _username = username
        Me.AppID = "dropbox"
    End Sub

    Public Overrides Sub read(ByRef XmlDoc As Xml.XmlDocument)
        Dim taskNode As XmlNode = XmlDoc.SelectSingleNode("//*[@id='" & Me.AppID & "']")
        tokenPath = taskNode.ChildNodes.Item(0).InnerText
    End Sub

    Public Overrides Function upload(ByVal filePath As String) As String
        Return MySQLDropbox(filePath)
    End Function
    'Apostolh tou zip arxeiou pou periexei to backup ston
    'logariasmo tou xrhsth ston katalogo "MySQLBackUp"
    'ka8ws kai thn diagrafh prohgoumenou backup
    Private Function MySQLDropbox(ByVal ZippedBackupfile As String) As String
        Dim Msg As String = String.Empty
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
            Msg += "File Succesfully Uploaded @ DropBox !!!<br/>"
        Catch ex As Exception
            Msg += "!!!!!!!!!!ERROR @ FILE Uploaded @ DropBox !!!!<br>"
            Msg += ex.Message & "<br/>"
        End Try
        Return Msg
    End Function
End Class
