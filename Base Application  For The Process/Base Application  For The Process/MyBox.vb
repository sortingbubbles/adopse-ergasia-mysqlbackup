Imports System.IO
Imports BoxApi.V2
Imports BoxApi.V2.Model
Imports BoxApi.V2.Authentication.OAuth2
Imports System.Xml

Public Class MyBox
    Inherits CloudService
    Private _username As String = String.Empty
    Private tokenPath As String = String.Empty

    Sub New(ByVal username As String)
        _username = username
        Me.AppID = "box"
    End Sub

    Public Overrides Sub read(ByRef XmlDoc As Xml.XmlDocument)
        Dim taskNode As XmlNode = XmlDoc.GetElementById(Me.AppID)
        tokenPath = taskNode.ChildNodes.Item(0).InnerText
    End Sub

    Public Overrides Function upload(filePath As String) As String
        Return MySQLBox(filePath)
        'Module1.addToMail(msg)
    End Function
    'h me8odos pou ekkinei th diadikasia tou upload sto box.com
    'opou metatrepoume se System.IO.Stream to arxeio pou 8eloume 
    'na anebasoume
    Private Function MySQLBox(ByVal fileName As String) As String
        Dim Msg As String = String.Empty
        Try
            Dim currentFileStream As System.IO.Stream = System.IO.File.Open(fileName, FileMode.Open)
            UploadToBox(fileName, currentFileStream)
            currentFileStream.Close()
            Msg += "File Succesfully Uploaded @ Box !!!<br/>"
        Catch ex As Exception
            Msg += "!!!!!!!!!!ERROR @ FILE Uploaded @ Box !!!!<br>"
            Msg += ex.Message & "<br/>"
        End Try
        Return Msg
    End Function

    'h basikh me8odos me thn opoia ginetai to upload
    'tou zipped backup file sto box.com ston katalogo MySQLBackUp
    'psaxnoume ton root folder tou xrhsth gia na doume an 
    'yparxei hdh o katalogos MySQLBackUp kai ton diagrafoume mazi me to
    'periexomeno tou (recursive=true) kai sth synexeia dhmiourgoume
    'ek neou ton katalogo MySQLBackUp kai anebazoume to zipped backup file
    Private Function UploadToBox(ByVal attachedFilename As String, ByVal stream As System.IO.Stream) As Boolean
        Dim newToken As BoxApi.V2.Authentication.OAuth2.OAuthToken = GetToken()
        Dim boxManager As New BoxManager(newToken.AccessToken)
        Dim rootFolder As Folder
        'Dim Fid As String
        For Each Fold As Folder In boxManager.GetFolder(Folder.Root).Folders
            If Fold.Name = "MySQLBackUp" Then
                'Fid = Fold.Id
                boxManager.DeleteFolder(Fold.Id, True)
            End If
        Next
        rootFolder = boxManager.CreateFolder(boxManager.GetFolder(Folder.Root), "MySQLBackUp")
        boxManager.CreateFile(rootFolder, attachedFilename, ConvertStreamToByteArray(stream))
        Return True
    End Function
    'boh8htikh me8odos ths UploadToBox gia thn metatroph tou 
    'arxeiou se byte etsi wste na metafer8oun sto box
    Private Function ConvertStreamToByteArray(ByVal stream As System.IO.Stream) As Byte()
        Dim streamLength As Long = Convert.ToInt64(stream.Length)
        Dim fileData As Byte() = New Byte(streamLength) {}
        stream.Position = 0
        stream.Read(fileData, 0, streamLength)
        stream.Close()
        Return fileData
    End Function
    'boh8htikh me8odos ths UploadToBox gia th dhmiourgeia enos nou RefreshToken
    'me bash to palio RefreshToken po exoume apo8hkeysei sto arxeio C:\TEMP\MyTest12.txt 
    'sth synexeia apo8hkeyoume to neo RefreshToken gia to epomeno backup
    Private Function GetToken() As BoxApi.V2.Authentication.OAuth2.OAuthToken
        Dim clientID As String = "*************************" ''''''''''''''
        Dim clientSecret As String = "***********************" '''''''''''''''
        Dim oldRefreshToken As String
        Dim newToken As BoxApi.V2.Authentication.OAuth2.OAuthToken
        Dim tokenProvider As New TokenProvider(clientID, clientSecret)
        Dim streamReader As StreamReader
        streamReader = System.IO.File.OpenText(tokenPath)
        oldRefreshToken = streamReader.ReadToEnd()
        streamReader.Close()
        newToken = tokenProvider.RefreshAccessToken(oldRefreshToken)
        Dim streamWriter As New StreamWriter(tokenPath)
        streamWriter.Write(newToken.RefreshToken)
        streamWriter.Close()
        Return newToken
    End Function
End Class
