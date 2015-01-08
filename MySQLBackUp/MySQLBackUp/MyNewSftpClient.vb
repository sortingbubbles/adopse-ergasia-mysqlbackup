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

    Public Overrides Sub Save(XmlDocPath As String)
        Dim myXmlDocument As XmlDocument = New XmlDocument()
        myXmlDocument.Load(XmlDocPath)
        Dim root As XmlNode = myXmlDocument.DocumentElement
        For Each node As XmlNode In root.ChildNodes
            If node.Name = "tasks" Then
                Dim taskNode As XmlElement = myXmlDocument.CreateElement("task")
                taskNode.SetAttribute("app_id", "sftp")
                node.AppendChild(taskNode)
                Dim serverNode As XmlElement = myXmlDocument.CreateElement("Server")
                Dim usernameNode As XmlElement = myXmlDocument.CreateElement("Username")
                Dim passwordNode As XmlElement = myXmlDocument.CreateElement("Password")
                Dim serverText As XmlText = myXmlDocument.CreateTextNode(_server)
                Dim usernameText As XmlText = myXmlDocument.CreateTextNode(_username)
                Dim passwordText As XmlText = myXmlDocument.CreateTextNode(_password)
                taskNode.AppendChild(serverNode)
                taskNode.AppendChild(usernameNode)
                taskNode.AppendChild(passwordNode)
                serverNode.AppendChild(serverText)
                usernameNode.AppendChild(usernameText)
                passwordNode.AppendChild(passwordText)
            End If
        Next
        myXmlDocument.Save(XmlDocPath)
    End Sub
End Class
