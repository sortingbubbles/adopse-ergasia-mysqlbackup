Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports Microsoft.Live

Public Class Form1


    Private Const scope As String = "wl.skydrive_update" ' scope για upload/download
    Private Const cliend_id As String = "0000000040139D3E" ' cliend id της εφαρμογής

    'Διεύθυνση για αυθεντικοποίηση και request για token
    Public Const address As String = "https://login.live.com/oauth20_authorize.srf?client_id=0000000040139D3E&scope=wl.skydrive_update&response_type=token&redirect_uri=https://login.live.com/oauth20_desktop.srf"


   
    'Dim request As HttpWebRequest
    'Dim response As HttpWebResponse = Nothing
    'Dim reader As StreamReader

    'Είσοδος στο one drive για αυθεντικοποίηση και token
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            ' Καλεί την 2η φόρμα που είναι ο web browser 
            webBrowser.Show()
            ' request = DirectCast(WebRequest.Create(address), HttpWebRequest)
            '  response = DirectCast(request.GetResponse(), HttpWebResponse)
            '  reader = New StreamReader(response.GetResponseStream())
            ' Console.WriteLine(reader.ReadToEnd())
        Catch ex As Exception
            Console.WriteLine("You fool!")
        Finally
            'If Not response Is Nothing Then response.Close()
        End Try
    End Sub


    'Ανέβασμα αρχείων
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        webBrowser.Show()
        webBrowser.uploadFile()
    End Sub




   
End Class
