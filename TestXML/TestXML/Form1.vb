Imports System.Xml

Public Class Form1
    ''sygroush
    Private k As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        xmlexample()
    End Sub

    Private Sub xmlexample()
        Dim xmlDoc As XmlDocument = New XmlDocument()

        ' Write down the XML declaration
        Dim xmlDeclaration As XmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", Nothing)

        ' Create the root element
        Dim rootNode As XmlElement = xmlDoc.CreateElement("CategoryList")
        xmlDoc.InsertBefore(xmlDeclaration, xmlDoc.DocumentElement)
        xmlDoc.AppendChild(rootNode)

        ' Create a new <Category> element and add it to the root node
        Dim parentNode As XmlElement = xmlDoc.CreateElement("Category")

        ' Set attribute name and value!
        parentNode.SetAttribute("ID", "01")

        xmlDoc.DocumentElement.PrependChild(parentNode)

        ' Create the required nodes
        Dim mainNode As XmlElement = xmlDoc.CreateElement("MainCategory")
        Dim descNode As XmlElement = xmlDoc.CreateElement("Description")
        Dim activeNode As XmlElement = xmlDoc.CreateElement("Active")

        ' retrieve the text 
        Dim categoryText As XmlText = xmlDoc.CreateTextNode("XML")
        Dim descText As XmlText = xmlDoc.CreateTextNode("This is a list my XML articles.")
        Dim activeText As XmlText = xmlDoc.CreateTextNode("true")

        'append the nodes to the parentNode without the value
        parentNode.AppendChild(mainNode)
        parentNode.AppendChild(descNode)
        parentNode.AppendChild(activeNode)

        'save the value of the fields into the nodes
        mainNode.AppendChild(categoryText)
        descNode.AppendChild(descText)
        activeNode.AppendChild(activeText)

        'Save to the XML file
        xmlDoc.Save(FileIO.SpecialDirectories.MyDocuments.ToString() & "\categories.xml")

        MessageBox.Show("XML file Created !!")
    End Sub

    Private Sub testEditXMLFile(ByRef XmlDocPath As XmlDocument)
        'Dim myXmlDocument As XmlDocument = New XmlDocument()
        'myXmlDocument.Load(XmlDocPath)
        Dim root As XmlNodeList = XmlDocPath.GetElementsByTagName("tasks")

        Dim node As XmlNode = root.Item(0)

        Dim taskNode As XmlElement = XmlDocPath.CreateElement("task")
        taskNode.SetAttribute("app_id", "googledrive")
        node.AppendChild(taskNode)

        Dim folderIDNode As XmlElement = XmlDocPath.CreateElement("folderID")
        Dim tokenPathNode As XmlElement = XmlDocPath.CreateElement("tokenPath")

        Dim folderID As String = "test_folderID"
        Dim tokenPath As String = "test_tokenPath"

        Dim folderIDText As XmlText = XmlDocPath.CreateTextNode(folderID)
        Dim tokenPathText As XmlText = XmlDocPath.CreateTextNode(tokenPath)

        taskNode.AppendChild(folderIDNode)
        taskNode.AppendChild(tokenPathNode)

        folderIDNode.AppendChild(folderIDText)
        tokenPathNode.AppendChild(tokenPathText)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim myXmlDocument As XmlDocument = New XmlDocument()
        myXmlDocument.Load("C:\Users\Charitakis\Desktop\testXmlFile.xml")
        testEditXMLFile(myXmlDocument)
        myXmlDocument.Save("C:\Users\Charitakis\Desktop\testXmlFile.xml")
    End Sub
End Class
