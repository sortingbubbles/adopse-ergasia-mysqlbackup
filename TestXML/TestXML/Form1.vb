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
        FileIO.SpecialDirectories.MyDocuments.ToString()
        xmlDoc.Save(FileIO.SpecialDirectories.MyDocuments.ToString() & "\categories.xml")

        MessageBox.Show("XML file Created !!")
    End Sub

End Class
