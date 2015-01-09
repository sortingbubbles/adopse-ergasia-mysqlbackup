Imports System.Xml

Public Class MyNewSftpClient
    Inherits CloudService
    Private _server As String
    Private _username As String
    Private _password As String
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

    Public Overrides Sub Authenticate()
        Dim mysftpform As New SftpForm(Me)
        mysftpform.Show()
    End Sub

    Sub New()
        Me.AppID = "sftp"
    End Sub

    Public Overrides Sub Save(ByRef XmlDoc As XmlDocument)
        Dim tasksNode As XmlNode = XmlDoc.GetElementsByTagName("tasks").Item(0)
        Dim taskNode As XmlElement = XmlDoc.CreateElement("task")
        taskNode.SetAttribute("app_id", Me.AppID)
        tasksNode.AppendChild(taskNode)
        Dim serverNode As XmlElement = XmlDoc.CreateElement("Server")
        Dim usernameNode As XmlElement = XmlDoc.CreateElement("Username")
        Dim passwordNode As XmlElement = XmlDoc.CreateElement("Password")
        Dim serverText As XmlText = XmlDoc.CreateTextNode(_server)
        Dim usernameText As XmlText = XmlDoc.CreateTextNode(_username)
        Dim passwordText As XmlText = XmlDoc.CreateTextNode(_password)
        taskNode.AppendChild(serverNode)
        taskNode.AppendChild(usernameNode)
        taskNode.AppendChild(passwordNode)
        serverNode.AppendChild(serverText)
        usernameNode.AppendChild(usernameText)
        passwordNode.AppendChild(passwordText)
    End Sub
End Class
