Imports System.Xml

Public MustInherit Class CloudService
    Private _appID As String
    Private _msg As String = String.Empty

    Property Msg() As String
        Get
            Return _msg
        End Get
        Set(value As String)
            _msg = value
        End Set
    End Property
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
