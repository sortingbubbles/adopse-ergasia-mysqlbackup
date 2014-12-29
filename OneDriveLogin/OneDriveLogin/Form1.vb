Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports Microsoft.Live
Imports Newtonsoft.Json.Linq

Public Class Form1
    Public Const client_id As String = "0000000040139D3E" ' client id της εφαρμογής
    Private Const client_secret As String = "qkMMeEhpLbM5GAfVJRWVPfo9PzuIjEGD" ' client secret της εφαρμογής



    'Είσοδος στο one drive για αυθεντικοποίηση και token
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        webBrowser.WebBrowser1.Url = New Uri("https://login.live.com/oauth20_authorize.srf?client_id=0000000040139D3E&scope=wl.skydrive_update%20wl.offline_access&response_type=code&redirect_uri=https://login.live.com/oauth20_desktop.srf")
        webBrowser.Show()
    End Sub



    'Ανέβασμα αρχείων
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Dialog για επιλογή αρχείου

        Dim fileName As String = String.Empty
        Using dlg = New OpenFileDialog()
            dlg.Filter = "All Files|*.*"
            If dlg.ShowDialog(Me) = DialogResult.OK Then
                fileName = dlg.FileName
            End If
        End Using

        Dim folder_id As String = checkFolder()
        'Δοκιμαστικό για δημιουργία φακέλου


        If folder_id.Equals("") then 
            folder_id = createFolder()
        End If


        'PUT Request για ανέβασμα αρχείου
        Dim url As String = String.Format("https://apis.live.net/v5.0/{0}/files/{1}?access_token={2}", folder_id, Path.GetFileName(fileName), webBrowser.token)
        Using client = New WebClient()

            client.UploadDataAsync(New Uri(url), "PUT", File.ReadAllBytes(fileName))
            client.GetType()

        End Using


    End Sub





    Private Function checkFolder() As String
        Dim url As String = String.Format("https://apis.live.net/v5.0/me/skydrive/files?access_token={0}", webBrowser.token)
        Try

            Dim req As HttpWebRequest
            req = HttpWebRequest.Create(url)
            req.Method = "GET"

            Dim objStream As Stream
            objStream = req.GetResponse().GetResponseStream()
            Dim objReader As New StreamReader(objStream)
            Dim json As String = objReader.ReadToEnd()

            webBrowser.saveToFile(json, "C:\Users\Annie\Desktop\listing.json")

            Dim ser As JObject = JObject.Parse(json)


            For Each item In ser("data")
                If (item("name").Value(Of String).Equals("MySQLBackUp")) Then
                    Return item("id").Value(Of String)()
                End If
            Next
        Catch ex As WebException
            Using response As WebResponse = ex.Response
                Dim httpResponse = DirectCast(response, HttpWebResponse)

                Using data As Stream = response.GetResponseStream()
                    Dim sr As New StreamReader(data)
                    Throw New Exception(sr.ReadToEnd())
                End Using
            End Using
        End Try
        Return ""
    End Function


    'μέθοδος για δημιουργία φακέλου
    Private Function createFolder() As String

        Try
            Dim jsonData() As Byte = Encoding.ASCII.GetBytes(createJsonStructure())
            Dim request As HttpWebRequest = HttpWebRequest.Create("https://apis.live.net/v5.0/me/skydrive")

            request.Method = "POST"
            request.Headers.Add("Authorization: Bearer " + webBrowser.token)
            request.ContentLength = jsonData.Length
            request.ContentType = "application/json"

            Dim dataStream = request.GetRequestStream()
            dataStream.Write(jsonData, 0, jsonData.Length)
            dataStream.Close()
            Dim response As HttpWebResponse = request.GetResponse()
            Dim responseStream As Stream = response.GetResponseStream
            Dim reader As New StreamReader(responseStream)

            Return getFolderIDFromJson(reader.ReadToEnd())

            reader.Close()
            responseStream.Close()
            response.Close()
        Catch ex As WebException
            Using response As WebResponse = ex.Response
                Dim httpResponse = DirectCast(response, HttpWebResponse)

                Using data As Stream = response.GetResponseStream()
                    Dim sr As New StreamReader(data)
                    Throw New Exception(sr.ReadToEnd())
                End Using
            End Using
        End Try

    End Function

    Private Function getFolderIDFromJson(json As String) As String
        Dim ser As JObject = JObject.Parse(json)
        Dim data As List(Of JToken) = ser.Children().ToList
        For Each item As JProperty In data
            Console.WriteLine(item.Name.ToString + " " + item.Value.ToString)
            If (item.Name.ToString.Equals("id")) Then
                Return item.Value
            End If
        Next
        Return ""
    End Function


    Private Function createJsonStructure() As String

        Dim json As StringBuilder = New StringBuilder()
        json.AppendLine("{")
        json.AppendLine("""name"": ""MySQLBackUp""")
        json.AppendLine("}")

        Return json.ToString()
    End Function



End Class
