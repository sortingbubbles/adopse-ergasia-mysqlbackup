#Region "Libraries"
Imports System.IO
Imports Microsoft.Win32.TaskScheduler
Imports System.Xml
Imports Ionic.Zip
Imports MySql.Data.MySqlClient
Imports System.Threading
Imports Google.Apis.Drive.v2
Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Auth.OAuth2.ComputeCredential
Imports Google.Apis.Util.Store
Imports Google
Imports Google.Apis.Drive.v2.Data
Imports Google.Apis.Services

#End Region
Public Class Form1
#Region "Variables"
    Private username As String
    Private CloudServices As List(Of CloudService) = New List(Of CloudService)
    Private xmlDocument As XmlDocument
    Private Hours() As String = {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23"}
    Private Minutes(60) As String
    Private Seconds(60) As String
    Private Cloudservice As Boolean
    Private databasesCount As Boolean = False
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
#End Region

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
        If My.Computer.FileSystem.FileExists("C:\TEMP\" & username & ".zip") Then
            MessageBox.Show("Enter a different username !!")
        Else
            My.Computer.FileSystem.CreateDirectory("C:\TEMP\" & username)
            xmlDocument = createXmlDoc()
            TabControl1.TabPages("TabPage2").Enabled = True
            TabControl1.TabPages("TabPage1").Enabled = False
            TabControl1.SelectedTab = TabControl1.TabPages("TabPage2")
        End If
    End Sub

    Private Sub SecondTab_Click(sender As Object, e As EventArgs) Handles SecondTab.Click
        If databasesCount Then
            If DatabasesCheckedListBox.CheckedItems.Count > 0 Then
                Dim databases As String = String.Empty
                ' Dim constring As String = "Server=192.168.6.153;Database=adopse;Uid=mysqlBackup;Pwd=;"
                Dim constring As String = "Server=" & Tab2Server.Text & ";Uid=" & Tab2Uid.Text & ";Pwd=" & Tab2Pwd.Text & ";Database="
                For Each _object As Object In DatabasesCheckedListBox.CheckedItems
                    databases += _object.ToString & ","
                Next
                '''''''''
                createNode("connection")
                createNodeWithText("conString", constring, "connection")
                createNodeWithText("databases", databases, "connection")
                TabControl1.TabPages("TabPage3").Enabled = True
                TabControl1.TabPages("TabPage2").Enabled = False
                TabControl1.SelectedTab = TabControl1.TabPages("TabPage3")
            Else
                MessageBox.Show("Please Check At Least one Database To Continue")
            End If
        Else
            MessageBox.Show("Please Fill TextBoxes Server,Username,Password To Continue")
        End If
    End Sub

    Private Sub ThirdTab_Click(sender As Object, e As EventArgs) Handles ThirdTab.Click
        createNodeWithText("email", Tab3Email.Text)
        createNode("cloudServices")
        TabControl1.TabPages("TabPage4").Enabled = True
        TabControl1.TabPages("TabPage3").Enabled = False
        TabControl1.SelectedTab = TabControl1.TabPages("TabPage4")
    End Sub
    'gia ka8e epilogh tou xrhsth
    '(Google drive, One Drive, DropBox, Box, Sftp)
    'swzoume ta token tou ka8e xrhsth
    Private Sub FourtTab_Click(sender As Object, e As EventArgs) Handles FourtTab.Click
        If Cloudservice = False Then
            MessageBox.Show("Please select at Least One Upload Provider!")
        Else
            For i As Integer = 0 To CloudServices.Count - 1
                CloudServices.Item(i).Save(xmlDocument)
            Next
            TabControl1.TabPages("TabPage4").Enabled = False
            TabControl1.TabPages("TabPage5").Enabled = True
            TabControl1.SelectedTab = TabControl1.TabPages("TabPage5")
        End If
    End Sub
    Private Sub FifthTab_Click(sender As Object, e As EventArgs) Handles FifthTab.Click
        CreateTaskAtWTS()
        xmlDocument.Save("C:\TEMP\" & username & "\" & username & ".xml")
        ZipMe() '' na to energopoihsw sto telos
        TabControl1.TabPages("TabPage5").Enabled = False
        TabControl1.TabPages("TabPage6").Enabled = True
        TabControl1.SelectedTab = TabControl1.TabPages("TabPage6")
    End Sub
    Private Sub ShowDB_Click(sender As Object, e As EventArgs) Handles ShowDB.Click
        If (Not String.IsNullOrEmpty(Tab2Server.Text)) And (Not String.IsNullOrEmpty(Tab2Uid.Text)) And (Not String.IsNullOrEmpty(Tab2Pwd.Text)) Then
            ShowDatabases()
            databasesCount = True
        Else
            MessageBox.Show("Please Fill TextBoxes Server,Username,Password To Continue")
        End If
    End Sub

    Private Sub gplus()
        Dim GDrive As GoogleDrive = New GoogleDrive(username)
        GDrive.Authenticate()
        ' CloudServices.Add(GDrive)
        GDrive.Save(xmlDocument)
    End Sub
#Region "Call auth classes and add @ CloudeServices List"
    Private Sub GoogleDriveButton_Click(sender As Object, e As EventArgs) Handles GoogleDriveButton.Click
        'Dim onedrivethread As Thread = New Thread(New ThreadStart(AddressOf gplus))
        'onedrivethread.SetApartmentState(ApartmentState.STA)
        'onedrivethread.Start()

        '  Dim GDrive As GoogleDrive = New GoogleDrive(username)
        'GDrive.Authenticate()
        'CloudServices.Add(GDrive)
        'GDrive.Save(xmlDocument)
        'Cloudservice = True

        GoogleDriveButton.Enabled = False
    End Sub

    Private Sub OneDriveButton_Click(sender As Object, e As EventArgs) Handles OneDriveButton.Click

        Dim onedrivethread As Thread = New Thread(New ThreadStart(AddressOf OneDriveHelp))
        onedrivethread.SetApartmentState(ApartmentState.STA)
        onedrivethread.Start()
       
        OneDriveButton.Enabled = False
    End Sub

    Private Sub OneDriveHelp()
        Dim oneDRive As OneDrive = New OneDrive(username)
        oneDRive.Authenticate()
        CloudServices.Add(oneDRive)
        Cloudservice = True
    End Sub


    Private Sub SFTPButton_Click(sender As Object, e As EventArgs) Handles SFTPButton.Click
        Dim sftp As MyNewSftpClient = New MyNewSftpClient()
        sftp.Authenticate()
        CloudServices.Add(sftp)
        Cloudservice = True
        SFTPButton.Enabled = False
    End Sub

    Private Sub DropBoxButton_Click(sender As Object, e As EventArgs) Handles DropBoxButton.Click
        Dim dropBox As DropBox = New DropBox(username)
        dropBox.Authenticate()
        CloudServices.Add(dropBox)
        Cloudservice = True
        DropBoxButton.Enabled = False
    End Sub
    Private Sub BoxHelp()
        Dim box As MyBoxClient = New MyBoxClient(username)
        box.Authenticate()
        CloudServices.Add(box)
        Cloudservice = True
    End Sub
    Private Sub BoxButton_Click(sender As Object, e As EventArgs) Handles BoxButton.Click

        Dim onedrivethread As Thread = New Thread(New ThreadStart(AddressOf BoxHelp))
        onedrivethread.SetApartmentState(ApartmentState.STA)
        onedrivethread.Start()
        BoxButton.Enabled = False

        'Dim box As MyBoxClient = New MyBoxClient(username)
        'box.Authenticate()
        'CloudServices.Add(box)
        'Cloudservice = True
        'BoxButton.Enabled = False
    End Sub
#End Region
#End Region
#Region "XML Document Creation & Saving"
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
#End Region

    Private Sub CreateTaskAtWTS()
        Dim strtime As String = " " & HourCombo.SelectedItem.ToString & ":" & MinuteCombo.SelectedItem.ToString & ":" & SecondsCombo.SelectedItem.ToString
        Using ts As New TaskService()
            Dim td As TaskDefinition = ts.NewTask()
            td.RegistrationInfo.Description = "This task is for the backup process for user : " + username
            td.Principal.RunLevel = TaskRunLevel.Highest
            Dim daily As New DailyTrigger()
            daily.StartBoundary = Convert.ToDateTime(DateTime.Today.ToShortDateString() + strtime) '" 19:38:00")
            daily.DaysInterval = CType(DaysInterval.Value, Integer)
            td.Triggers.Add(daily)
            td.Settings.MultipleInstances = TaskInstancesPolicy.Parallel
            td.Settings.DisallowStartIfOnBatteries = False
            'edwwwwww
            td.Actions.Add(New ExecAction("C:\Users\Annie\Documents\Visual Studio 2013\Projects\Base Application  For The Process\Base Application  For The Process\Base Application  For The Process\bin\Debug\Base Application  For The Process.exe", username, Nothing))
            td.Settings.WakeToRun = True
            td.Settings.Hidden = True
            td.Settings.StartWhenAvailable = True
            td.Settings.Priority = ProcessPriorityClass.High
            ts.RootFolder.RegisterTaskDefinition(username, td)

        End Using
    End Sub

    'Zip for data protection
    Private Sub ZipMe()
        Dim Userfolder As String = "C:\TEMP\" & username
        Dim ZippedUserfolder As String = "C:\TEMP\" & username & ".zip"
        Using zip As ZipFile = New ZipFile()
            zip.Encryption = EncryptionAlgorithm.WinZipAes256
            zip.Password = "AsprhPetra3e3asprhKaiApoTonHlio3e3asproterh"
            zip.AddDirectory(Userfolder)
            zip.Save(ZippedUserfolder)
        End Using
        My.Computer.FileSystem.DeleteDirectory(Userfolder, FileIO.DeleteDirectoryOption.DeleteAllContents)

    End Sub
#Region "Social Media"
    Private Sub GooglePlus_Click(sender As Object, e As EventArgs) Handles GooglePlus.Click
        Process.Start("https://plus.google.com/100757218376615905273/about")
    End Sub

    Private Sub Facebook_Click(sender As Object, e As EventArgs) Handles Facebook.Click
        Process.Start("https://www.facebook.com/mysqlbackupgr")
    End Sub

    Private Sub Twitter_Click(sender As Object, e As EventArgs) Handles Twitter.Click
        Process.Start("https://twitter.com/mysqlbackupgr")
    End Sub
#End Region
    'syndesh me th bash me ta creds pou edwse o xrhsths 
    'kai sth synexeia an den yparxei la8os 8a emfanizei 
    ' se ena CheckedListBox tis baseis pou yparxoun
    Private Sub ShowDatabases()
        Dim dt As DataTable = New DataTable()
        Dim con As String = "server=" & Tab2Server.Text & ";user=" & Tab2Uid.Text & ";pwd=" & Tab2Pwd.Text & ";"
        Try
            Dim conn As MySqlConnection = New MySqlConnection(con)
            Dim cmd As MySqlCommand = New MySqlCommand()
            cmd.Connection = conn
            conn.Open()
            cmd.CommandText = "show databases;"
            Dim da As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            da.Fill(dt)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        DatabasesCheckedListBox.Visible = True
        For Each _row As DataRow In dt.Rows
            DatabasesCheckedListBox.Items.Add(_row(0))
        Next _row
    End Sub

   


End Class


