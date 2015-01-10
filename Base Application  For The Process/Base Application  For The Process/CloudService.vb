Imports System.Xml

Public MustInherit Class CloudService
    Private _appID As String

    Property AppID() As String
        Get
            Return _appID
        End Get
        Set(value As String)
            _appID = value
        End Set
    End Property

    'Diavasma apo to arxeio XmlDocument pou perniete parametrika
    Public MustOverride Sub read(ByRef XmlDoc As XmlDocument)

    'Anevasma arxeiou pou vriskete stin thesi filePath
    Public MustOverride Sub upload(ByVal filePath As String)

End Class
