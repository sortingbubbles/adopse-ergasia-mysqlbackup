Imports System.Xml
Imports Google
Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Drive.v2
Imports Google.Apis.Drive.v2.Data
Imports Google.Apis.Services

Imports Google.Apis.Util.Store
Imports System.Threading

Public Class GoogleDrive
    Inherits CloudService

    Private folderID As String
    Private tokenPath As String
    Private UserID As String

    Private CLIENT_ID As String = "*******************************************************"
    Private CLIENT_SECRET As String = "************************"
    Private APP_USER_AGENT As String = "MySQLBackUpGr"
    Private SCOPES As String() = New String() {DriveService.Scope.Drive}

    'Domitis. Me tin dimiourgeia tou antikeimenou pernountai san parametroi
    'to TokenPath: O fakelos opou tha topothetithoun ta token (json arxeia) kai
    'to Username: To onoma xristi pou exei eisagei o xristis stin forma
    Sub New(ByVal Username As String)
        Me.AppID = "googledrive"
        Me.tokenPath = "C:\TEMP\" & Username
        Me.UserID = Username
    End Sub


#Region "Utilities methods"

    'Voithitiki methodos tis MySQLGoogleDrive i opoia kanei to authorization
    'kai epistrefei antikeimeno tupou DriveService me to opoio 
    'mporoume na diaxiristoume to Google Drive
    Private Function getGoogleDriveService() As DriveService
        Dim credential As UserCredential = GoogleWebAuthorizationBroker.AuthorizeAsync(New ClientSecrets() With { _
                .ClientId = CLIENT_ID, _
                .ClientSecret = CLIENT_SECRET _
            }, SCOPES, UserID, CancellationToken.None, getPersistentCredentialStore()).Result
        Dim service As DriveService = New DriveService(New BaseClientService.Initializer() With { _
                .HttpClientInitializer = credential, _
                .ApplicationName = APP_USER_AGENT _
            })
        Return service
    End Function

    'Voithitiki methodos i opoia epistrefei ena antikeimeno IDataStore
    'Me tin xrisi autou tou antikeimenou ginete i apothikeusi ton
    'tokens se enan fakelo (Dimiourgite ena arxeio gia kathe xristi)
    'kathos episis kai i anaktisi oson einai apothikeumena
    Private Function getPersistentCredentialStore() As IDataStore
        Return New FileDataStore(tokenPath, True)
    End Function

    Private Sub DeleteFilesFromFolder(ByVal service As DriveService, ByVal folderId As String)
        Dim request As ChildrenResource.ListRequest = service.Children.List(folderId)
        Dim children As ChildList = request.Execute
        For Each child As ChildReference In children.Items
            DeleteFile(service, child.Id)
        Next
    End Sub

    Private Sub DeleteFile(ByVal service As DriveService, ByVal fileId As String)
        service.Files.Delete(fileId).Execute()
    End Sub

#End Region


    Public Overrides Sub read(ByRef XmlDoc As XmlDocument)
        Dim taskNode As XmlNode = XmlDoc.GetElementById(Me.AppID)
        Dim folderIDNode = taskNode.ChildNodes.Item(0)
        folderID = folderIDNode.InnerText
    End Sub

    Public Overrides Function upload(filePath As String) As String
        Dim Msg As String = String.Empty
        Try
            Dim service As DriveService = getGoogleDriveService()
            DeleteFilesFromFolder(service, folderID)
            Dim body As New File()
            body.Title = "Backup.zip"
            body.Description = "MySQLBackUpGr backup file"
            body.MimeType = "application/zip"

            Dim newParent As ParentReference = New ParentReference
            newParent.Id = folderID

            body.Parents = {newParent}

            Dim byteArray As Byte() = System.IO.File.ReadAllBytes(filePath)
            Dim stream As New System.IO.MemoryStream(byteArray)
            Dim request As FilesResource.InsertMediaUpload = service.Files.Insert(body, stream, "application/zip")
            request.Upload()

            Dim file As File = request.ResponseBody
            Msg += "File Succesfully Uploaded @ Google Drive !!!<br/>"
        Catch ex As Exception
            Msg += "!!!!!!!!!!ERROR @ FILE Uploaded @ Google Drive !!!!<br>"
            Msg += ex.Message & "<br/>"

        End Try
        Return Msg
    End Function
End Class
