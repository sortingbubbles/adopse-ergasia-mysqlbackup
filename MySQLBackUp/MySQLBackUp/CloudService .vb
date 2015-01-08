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

    'Methodos pou apothikevei to antikeimeno sto XmlDocument pou perniete parametrika
    Public MustOverride Sub Save(ByVal XmlDocPath As String)

    'Authentikopoiisi tou xristi gia to Cloud Service
    Public MustOverride Sub Authenticate()

End Class
