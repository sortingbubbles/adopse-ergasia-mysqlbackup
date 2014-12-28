
Class MyNewSftpClient
    Private _code As Integer = 0
    Private _server As String
    Private _username As String
    Private _password As String
    Property Code() As Integer
        Get
            Return _code
        End Get
        Set(value As Integer)
            _code = value
        End Set
    End Property
    Property Server() As String
        Get
            Return _server
        End Get
        Set(value As String)
            _server = value
        End Set
    End Property
    Property Username() As String
        Get
            Return _username
        End Get
        Set(value As String)
            _username = value
        End Set
    End Property
    Property Password() As String
        Get
            Return _password
        End Get
        Set(value As String)
            _password = value
        End Set
    End Property
End Class
