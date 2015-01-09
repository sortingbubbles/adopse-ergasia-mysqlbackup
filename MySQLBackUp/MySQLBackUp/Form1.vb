#Region "Libraries"
Imports System.IO
Imports Microsoft.Win32.TaskScheduler
Imports System.Xml

#End Region
Public Class Form1
    Private username As String
    Private tokenPath As String
    Private CloudeServices As List(Of CloudService)
    Private xmlDocument As XmlDocument
    Private Hours() As String = {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23"}
    Private Minutes(60) As String
    Private Seconds(60) As String
    '8etei stous antistoixous pinakes ta lepta kai ta deyterolepta 
    'apo 0-9
    Private Sub fillMyfirstMinutesSeconds()
        For i As Integer = 0 To 9
            Minutes(i) = "0" & i
            Seconds(i) = "0" & i
        Next
    End Sub
    '8etei stous antistoixous pinakes ta lepta kai ta deyterolepta 
    'apo 10-59
    Private Sub FillMinutesSeconds()
        For i As Integer = 10 To 59
            Minutes(i) = i
            Seconds(i) = i
        Next
    End Sub

    ''Emfanizei to Tabpage.Text orizontia anti ka8eta pou einai to default
    Private Sub TabControl1_DrawItem(sender As Object, e As DrawItemEventArgs) Handles TabControl1.DrawItem
        Dim g As Graphics
        Dim sText As String

        Dim iX As Integer
        Dim iY As Integer
        Dim sizeText As SizeF

        Dim ctlTab As TabControl

        ctlTab = CType(sender, TabControl)

        g = e.Graphics

        sText = ctlTab.TabPages(e.Index).Text
        sizeText = g.MeasureString(sText, ctlTab.Font)

        iX = e.Bounds.Left + 6
        iY = e.Bounds.Top + (e.Bounds.Height - sizeText.Height) / 2

        g.DrawString(sText, ctlTab.Font, Brushes.Black, iX, iY)
    End Sub

#Region "Navigation Between Tabs & Assigning Values From Tabs"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabControl1.TabPages("TabPage2").Enabled = False
        TabControl1.TabPages("TabPage3").Enabled = False
        TabControl1.TabPages("TabPage4").Enabled = False

        fillMyfirstMinutesSeconds()
        FillMinutesSeconds()

        HourCombo.DataSource = Hours
        MinuteCombo.DataSource = Minutes
        SecondsCombo.DataSource = Seconds

        HourCombo.DisplayMember = Hours(1)
        MinuteCombo.DisplayMember = Minutes(1)
        SecondsCombo.DataSource = Seconds

        HourCombo.SelectedIndex = 0
        MinuteCombo.SelectedIndex = 0
        SecondsCombo.SelectedIndex = 0
    End Sub

    Private Sub FirstTab_Click(sender As Object, e As EventArgs) Handles FirstTab.Click
        username = FirstTabUsername.Text
        My.Computer.FileSystem.CreateDirectory("C:\TEMP\" & username)
        xmlDocument = createXmlDoc()
        TabControl1.TabPages("TabPage2").Enabled = True
        TabControl1.TabPages("TabPage1").Enabled = False
        TabControl1.SelectedTab = TabControl1.TabPages("TabPage2")
    End Sub

    Private Sub SecondTab_Click(sender As Object, e As EventArgs) Handles SecondTab.Click
        ' Dim constring As String = "Server=192.168.6.153;Database=adopse;Uid=mysqlBackup;Pwd=;"
        Dim constring As String = "Server=" & Tab2Server.Text & Tab2DataBase.Text & ";Uid=" & Tab2Uid.Text & ";Pwd=" & Tab2Pwd.Text & ";Database="
        createNode("connection")
        createNodeWithText("conString", constring, "connection")
        createNodeWithText("databases", Tab2DataBase.Text, "connection")
        TabControl1.TabPages("TabPage3").Enabled = True
        TabControl1.TabPages("TabPage2").Enabled = False
        TabControl1.SelectedTab = TabControl1.TabPages("TabPage3")
    End Sub

    Private Sub ThirdTab_Click(sender As Object, e As EventArgs) Handles ThirdTab.Click
        createNodeWithText("email", Tab3Email.Text)
        createNode("tasks")
        TabControl1.TabPages("TabPage4").Enabled = True
        TabControl1.TabPages("TabPage3").Enabled = False
        TabControl1.SelectedTab = TabControl1.TabPages("TabPage4")
    End Sub

    Private Sub FourtTab_Click(sender As Object, e As EventArgs) Handles FourtTab.Click
        'grapse ta trela sou

        For i As Integer = 0 To CloudeServices.Count - 1
            CloudeServices.Item(i).Save(xmlDocument)
        Next
        'trela start 
        TabControl1.TabPages("TabPage4").Enabled = False
        TabControl1.TabPages("TabPage5").Enabled = True
        TabControl1.SelectedTab = TabControl1.TabPages("TabPage5")
        'trela end
    End Sub
#Region "Call auth classes and add @ CloudeServices List"
    Private Sub GoogleDriveButton_Click(sender As Object, e As EventArgs) Handles GoogleDriveButton.Click
        Dim GDrive As GoogleDrive = New GoogleDrive(username)
        GDrive.Authenticate()
        CloudeServices.Add(GDrive)
    End Sub

    Private Sub OneDriveButton_Click(sender As Object, e As EventArgs) Handles OneDriveButton.Click
        Dim myserv As OneDrive = New OneDrive()
        myserv.Authenticate()
        CloudeServices.Add(myserv)
    End Sub

    Private Sub SFTPButton_Click(sender As Object, e As EventArgs) Handles SFTPButton.Click
        Dim sftp As MyNewSftpClient = New MyNewSftpClient()
        sftp.Authenticate()
        CloudeServices.Add(sftp)
    End Sub

    Private Sub DropBoxButton_Click(sender As Object, e As EventArgs) Handles DropBoxButton.Click
        Dim dropBox As DropBox = New DropBox(username)
        dropBox.Authenticate()
        CloudeServices.Add(dropBox)
    End Sub

    Private Sub BoxButton_Click(sender As Object, e As EventArgs) Handles BoxButton.Click
        Dim box As MyBoxClient = New MyBoxClient(username)
        box.Authenticate()
        CloudeServices.Add(box)
    End Sub
#End Region
#End Region

#Region "Authentication Methods"
    'Private Sub MyDropBox()
    '    Dim nj As New DropBox()
    '    nj.AuthorizeMe()
    '    nj.saveMyAuth()
    'End Sub

    'Private Sub MyBox()
    '    tokenPath = "C:\TEMP\BoxToken.txt"
    '    Dim br As New BoxAuth(tokenPath)
    '    br.wb.Url = New Uri("https://app.box.com/api/oauth2/authorize?response_type=code&client_id=0sl2q9wxpjq6cun6khctch1sg0g86g2u")
    '    br.ShowDialog()
    'End Sub

    Private Sub MyOneDrive()
        'tokenPath = "c:\TEMP\OneDriveRefreshToken.txt"
        'Dim clientID As String = "***********" ' client id της εφαρμογής
        'Dim clientSecret As String = "*******************" ' client secret της εφαρμογής

        'Dim url As String = String.Format("https://login.live.com/oauth20_authorize.srf?client_id={0}&scope=wl.skydrive_update%20wl.offline_access&response_type=code&redirect_uri=https://login.live.com/oauth20_desktop.srf", clientID)
        'OneDriveBrowser.OneDriveAuth.Url = New Uri(url)
        'OneDriveBrowser.Show()

        Dim myserv As OneDrive = New OneDrive()

        myserv.Authenticate()

    End Sub

    'Private Sub MySFTP()

    '    Dim mysftpform As New SftpForm
    '    mysftpform.Show()
    'End Sub

#End Region

    Private Function createXmlDoc() As XmlDocument
        Dim xmlDoc As XmlDocument = New XmlDocument()
        ' Write down the XML declaration
        Dim xmlDeclaration As XmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", Nothing)
        ' Create the root element
        Dim rootNode As XmlElement = xmlDoc.CreateElement("user")
        rootNode.SetAttribute("username", username)
        xmlDoc.InsertBefore(xmlDeclaration, xmlDoc.DocumentElement)
        xmlDoc.AppendChild(rootNode)
        Return xmlDoc
    End Function

    Private Sub createNode(ByVal nodeName As String, Optional ByVal parentName As String = "user")
        Dim parentNode As XmlNode = xmlDocument.GetElementsByTagName(parentName).Item(0)
        Dim newNode As XmlElement = xmlDocument.CreateElement(nodeName)
        parentNode.AppendChild(newNode)
    End Sub

    Private Sub createNodeWithText(ByVal nodeName As String, ByVal noteValue As String, Optional ByVal parentName As String = "user")
        Dim parentNode As XmlNode = xmlDocument.GetElementsByTagName(parentName).Item(0)
        Dim newNode As XmlElement = xmlDocument.CreateElement(nodeName)
        Dim newNodeText As XmlText = xmlDocument.CreateTextNode(noteValue)
        parentNode.AppendChild(newNode)
        newNode.AppendChild(newNodeText)
    End Sub

    Private Sub CreateTaskAtWTS_Click(sender As Object, e As EventArgs) Handles CreateTaskAtWTS.Click
        Dim strtime As String = " " & HourCombo.SelectedItem.ToString & ":" & MinuteCombo.SelectedItem.ToString & ":" & SecondsCombo.SelectedItem.ToString
        Using ts As New TaskService()
            Dim td As TaskDefinition = ts.NewTask()
            td.RegistrationInfo.Description = "This task is for the backup process for user : " + username
            td.Principal.RunLevel = TaskRunLevel.Highest
            Dim daily As New DailyTrigger()
            daily.StartBoundary = Convert.ToDateTime(DateTime.Today.ToShortDateString() + strtime) '" 19:38:00")
            daily.DaysInterval = 1 'na balw to value apo to numbox
            td.Triggers.Add(daily)
            td.Settings.MultipleInstances = TaskInstancesPolicy.Parallel
            td.Settings.DisallowStartIfOnBatteries = False
            td.Actions.Add(New ExecAction("C:\Users\ILIAS\Documents\Visual Studio 2013\Projects\Base Application  For The Process\Base Application  For The Process\bin\Debug\Base Application  For The Process.exe", "ilias", Nothing))
            td.Settings.WakeToRun = True
            td.Settings.Hidden = True
            td.Settings.StartWhenAvailable = True
            td.Settings.Priority = ProcessPriorityClass.High
            ts.RootFolder.RegisterTaskDefinition(username, td)

        End Using
        MessageBox.Show("Task Created!!!")
        Me.Close()
    End Sub


End Class


