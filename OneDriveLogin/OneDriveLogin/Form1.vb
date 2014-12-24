Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports Microsoft.Live

Public Class Form1
    Private Const scope As String = "wl.skydrive_update" ' scope για upload/download
    Public Const cliend_id As String = "0000000040139D3E" ' cliend id της εφαρμογής

    'Διεύθυνση για αυθεντικοποίηση και request για token
    Public Const address As String = "https://login.live.com/oauth20_authorize.srf?client_id=0000000040139D3E&scope=wl.skydrive_update%20wl.offline_access&response_type=code&redirect_uri=https://login.live.com/oauth20_desktop.srf"


    'Είσοδος στο one drive για αυθεντικοποίηση και token
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        webBrowser.Show()
    End Sub

   

    'Ανέβασμα αρχείων
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim fileName As String = String.Empty
        Using dlg = New OpenFileDialog()
            dlg.Filter = "All Files|*.*"
            If dlg.ShowDialog(Me) = DialogResult.OK Then
                fileName = dlg.FileName
            End If
        End Using
        Dim url As String = String.Format("https://apis.live.net/v5.0/me/skydrive/Files/{0}?access_token={1}", Path.GetFileName(fileName), webBrowser.token)
        Using client = New WebClient()
            client.UploadDataAsync(New Uri(url), "PUT", File.ReadAllBytes(fileName))
        End Using
    End Sub





End Class
