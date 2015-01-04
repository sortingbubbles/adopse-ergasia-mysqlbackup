Imports System.Xml

Public MustInherit Class CloudService
    Private _appID As String

    Property AppID() As Integer
        Get
            Return _appID
        End Get
        Set(value As Integer)
            _appID = value
        End Set
    End Property

    Public MustOverride Sub Save(ByRef xmlDoc As XmlDocument)

    Public MustOverride Sub Authenticate()

End Class
