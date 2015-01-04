#Region "Libraries"
Imports System.IO
Imports Microsoft.Win32.TaskScheduler
#End Region
Public Class Form1
    Private username As String
    Private email As String
    Private tokenPath As String
    Private constring As String
    Private sftpClient As MyNewSftpClient
    Private CloudeServices As List(Of CloudService)
    Private Hours() As String = {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23"}
    Private Minutes(60) As String
    Private Seconds(60) As String
    Private Sub fillMyfirstMinutes()
        For i As Integer = 0 To 9
            Minutes(i) = "0" & i
        Next
    End Sub
    Private Sub fillMyfirstSeconds()
        For i As Integer = 0 To 9
            Seconds(i) = "0" & i
        Next
    End Sub

    Private Sub FillMinutes()
        For i As Integer = 10 To 59
            Minutes(i) = i
        Next
    End Sub
    Private Sub FillSeconds()
        For i As Integer = 0 To 59
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
        fillMyfirstMinutes()
        fillMyfirstSeconds()
        FillMinutes()
        FillSeconds()
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
        TabControl1.TabPages("TabPage2").Enabled = True
        TabControl1.TabPages("TabPage1").Enabled = False
        TabControl1.SelectedTab = TabControl1.TabPages("TabPage2")
    End Sub

    Private Sub SecondTab_Click(sender As Object, e As EventArgs) Handles SecondTab.Click
        ' Dim constring As String = "Server=192.168.6.153;Database=adopse;Uid=mysqlBackup;Pwd=;"
        constring = "Server=" & Tab2Server.Text & Tab2DataBase.Text & ";Uid=" & Tab2Uid.Text & ";Pwd=" & Tab2Pwd.Text & ";Database="
        Dim databases As String = Tab2DataBase.Text
        TabControl1.TabPages("TabPage3").Enabled = True
        TabControl1.TabPages("TabPage2").Enabled = False
        TabControl1.SelectedTab = TabControl1.TabPages("TabPage3")
    End Sub

    Private Sub ThirdTab_Click(sender As Object, e As EventArgs) Handles ThirdTab.Click
        email = Tab3Email.Text
        TabControl1.TabPages("TabPage4").Enabled = True
        TabControl1.TabPages("TabPage3").Enabled = False
        TabControl1.SelectedTab = TabControl1.TabPages("TabPage4")
    End Sub

    Private Sub FourtTab_Click(sender As Object, e As EventArgs) Handles FourtTab.Click
        If DropBox.Checked Then
            MyDropBox()
        ElseIf Box.Checked Then
            MyBox()
        ElseIf OneDrive.Checked Then
            MyOneDrive()
        ElseIf GoogleDrive.Checked Then
            MyGoogleDrive()
        ElseIf SFTP.Checked Then
            MySFTP()
        End If
        TabControl1.TabPages("TabPage5").Enabled = True
        TabControl1.TabPages("TabPage4").Enabled = False
        TabControl1.SelectedTab = TabControl1.TabPages("TabPage5")
    End Sub

#End Region

#Region "Authentication Methods"
    Private Sub MyDropBox()
        Dim nj As New DropBox()
        nj.AuthorizeMe()
        nj.saveMyAuth()
    End Sub

    Private Sub MyBox()
        tokenPath = "C:\TEMP\BoxToken.txt"
        Dim br As New BoxAuth(tokenPath)
        br.wb.Url = New Uri("https://app.box.com/api/oauth2/authorize?response_type=code&client_id=0sl2q9wxpjq6cun6khctch1sg0g86g2u")
        br.ShowDialog()
    End Sub

    Private Sub MyOneDrive()
        tokenPath = "c:\TEMP\OneDriveRefreshToken.txt"
        Dim clientID As String = "***********" ' client id της εφαρμογής
        Dim clientSecret As String = "*******************" ' client secret της εφαρμογής

        Dim url As String = String.Format("https://login.live.com/oauth20_authorize.srf?client_id={0}&scope=wl.skydrive_update%20wl.offline_access&response_type=code&redirect_uri=https://login.live.com/oauth20_desktop.srf", clientID)
        OneDriveBrowser.OneDriveAuth.Url = New Uri(url)
        OneDriveBrowser.Show()
    End Sub

    Private Sub MyGoogleDrive()
        Throw New NotImplementedException
    End Sub
    ''' <summary>
    ''' ''''''''''''''''
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MySFTP()
        sftpClient.Server = ""
        sftpClient.Username = ""
        sftpClient.Password = ""
    End Sub

#End Region

    Private Sub CreateEverything_Click(sender As Object, e As EventArgs) Handles CreateEverything.Click
        Dim str123 As String = " " & HourCombo.SelectedItem.ToString & ":" & MinuteCombo.SelectedItem.ToString & ":" & SecondsCombo.SelectedItem.ToString
        Using ts As New TaskService()
            Dim td As TaskDefinition = ts.NewTask()
            td.RegistrationInfo.Description = "This task is for the backup process for user " + username
            td.Principal.RunLevel = TaskRunLevel.Highest
            Dim daily As New DailyTrigger()
            daily.StartBoundary = Convert.ToDateTime(DateTime.Today.ToShortDateString() + str123) '" 19:38:00")
            daily.DaysInterval = 1
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
