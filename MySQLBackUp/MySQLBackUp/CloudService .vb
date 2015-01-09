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

    'Methodos pou apothikevei to antikeimeno sto XmlDocument pou perniete parametrika
    Public MustOverride Sub Save(ByRef XmlDoc As XmlDocument)

    'Authentikopoiisi tou xristi gia to Cloud Service
    Public MustOverride Sub Authenticate()

End Class
