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
    Private APP_USER_AGENT As String = "Drive API Sample"
    Private SCOPES As String() = New String() {DriveService.Scope.Drive}

    'Domitis. Me tin dimiourgeia tou antikeimenou pernountai san parametroi
    'to TokenPath: O fakelos opou tha topothetithoun ta token (json arxeia) kai
    'to Username: To onoma xristi pou exei eisagei o xristis stin forma
    Sub New(ByVal TokenPath As String, ByVal Username As String)
        Me.AppID = "googledrive"
        Me.tokenPath = TokenPath
        Me.UserID = Username
    End Sub

    'Authentikopoiisi tou xristi kai dimiourgeia tou fakelou "MySQLBackup"
    Public Overrides Sub Authenticate()
        Dim service As DriveService = getGoogleDriveService()
        Dim folderBody As File = New File
        folderBody.Title = "MySQLBackup"
        folderBody.Description = "Backups from MySQLBackup application"
        folderBody.MimeType = "application/vnd.google-apps.folder"
        folderBody = service.Files.Insert(folderBody).Execute()
        folderID = folderBody.Id
    End Sub

#Region "Utilities methods"
    'Voithitiki methodos tis MySQLGoogleDrive i opoia kanei to authorization
    'kai epistrefei antikeimeno tupou DriveService me to opoio 
    'mporoume na diaxiristoume to Google Drive
    Private Function getGoogleDriveService() As DriveService
        Dim CLIENT_ID As String = "**********************************************"
        Dim CLIENT_SECRET As String = "************************"
        Dim APP_USER_AGENT As String = "Drive API Sample"
        Dim SCOPES As String() = New String() {DriveService.Scope.Drive}
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
#End Region

    Public Overrides Sub Save(ByVal XmlDocPath As String)
        'Anoigma tou XML arxeiou
        Dim myXmlDocument As XmlDocument = New XmlDocument()
        myXmlDocument.Load(XmlDocPath)

        'Pernoume ton root node
        Dim root As XmlNode = myXmlDocument.DocumentElement

        'Anazitoume se olous tou komvous paidia tou root
        For Each node As XmlNode In root.ChildNodes

            'Poios exei Name = "tasks" (<tasks>). Se auton ton komvo tha prosthesoume enan
            'komvo <task> pou tha exei san paidia tou allois 2 komvous (ta pedia pou theloume na apothikeusoume)
            If node.Name = "tasks" Then

                'Dimiourgeia komvou <task>
                Dim taskNode As XmlElement = myXmlDocument.CreateElement("task")
                'Orismos enos atribute ston komvo
                taskNode.SetAttribute("app_id", "googledrive")
                'Emfanisi tou komvou <task> kato apo ton komvo <tasks>
                node.AppendChild(taskNode)

                'Dimiourgeia komvon paidia tou komvou <task>
                Dim folderIDNode As XmlElement = myXmlDocument.CreateElement("folderID")
                Dim tokenPathNode As XmlElement = myXmlDocument.CreateElement("tokenPath")

                'Dimiourgeia ton timon tou kathe komvou (text)
                Dim folderIDText As XmlText = myXmlDocument.CreateTextNode(folderID)
                Dim tokenPathText As XmlText = myXmlDocument.CreateTextNode(tokenPath)

                'Eisagogei ton komvon kato apo ton patera (komvos <task>) xoris tis times tous
                taskNode.AppendChild(folderIDNode)
                taskNode.AppendChild(tokenPathNode)

                'Eisagogi timon tou kathe komvou
                folderIDNode.AppendChild(folderIDText)
                tokenPathNode.AppendChild(tokenPathText)
            End If
        Next

        'Apothikeusi kai Overrid tou arxikou XML arxeiou
        myXmlDocument.Save(XmlDocPath)
    End Sub
End Class
