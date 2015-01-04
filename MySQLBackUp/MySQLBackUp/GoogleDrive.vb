Imports System.Xml

Public Class GoogleDrive
    Inherits CloudService

    Private ReadOnly _folderID As String

    Sub New()
        Me.AppID = "googledrive"
    End Sub

    Public Overrides Sub Authenticate()

    End Sub

    Public Overrides Sub Save(ByRef xmlDoc As XmlDocument)

    End Sub
End Class
