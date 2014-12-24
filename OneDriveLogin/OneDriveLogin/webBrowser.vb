Imports System.Net
Imports System.IO
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Public Class webBrowser


    Public token As String = "EwBwAq1DBAAUGCCXc8wU/zFu9QnLdZXy+YnElFkAAbty5U6w4KguEyqJx4HcGJsMUKd/24zRHR4fI7b7lOAXHDPFh1i8JCxLFvI9Y7M2wsAROBduEtz2L1dAKtx6/OX2ifWlTHXcqS5SR7QRKjRbfk+TXQvhNGC4u5DfverP/Wzo9Kis+kaibmyzrff8lyLM57MmZkANEZIae/TbiXY5Cx6ha+whi9gIQFPRCBQIiX/U0v+VAUHrKleZ6VsF4Vr9xsByl6g1n1cYz3cUBN/MBLNVCJ6/BchkP01G0gpxc2IHsoY7LrkDCd4jrDVL1mKYaTB5uMsmSznNf3ZRIqOtr++EoTICL0i0WzJ2GHefZNfO/406jkF4FyJWmneKwDMDZgAACF1cchVch34OQAHhy0Y9ZeCwH4Z3ZLv59aXot18tm6DO8B9XkUpu9vxGfM3eYLK1MXS90FN9kiM/AQLpQlVDY3311nXKv6AI4Q89ozdfr4ikQQJikpjzii9tEi5GwppEDAJiSwl0Imv/ufWALCw3d6ld4CtXnf+EBcJnPOwyVLDGtYY3re9NpTxUY0PnyAWu2mZ9hSkKMEEWeV/2ndSfvUGXf35CFaPaBd0POPm0/DKjtOLITVlwOEj7lC1r2fWYd7t9epUNUpyFt3WztCMmupJByqtG3n26+F4tenSM2Cs3MSjLw/aokVbzoYrSnl13fUingxBNyBOq9bgkFho9iQHbeKOc+igvsNZ6thKbEbKiZQQsiPB22X4J9nNwiOCJQTOxiS7XRZhAaHPEkYs5nTaHxQslAg56K4lY2Wd7AknPPFK4PF1kz0hM/1YB"
    Public code As String = ""


    'Μετά το φόρτωμα της σελίδας ελέγχεται εάν το url έχει το access token
    'Εάν υπάρχει το αποθηκεύει στη μεταβλητή token
    Private Sub WebBrowser1_Navigated(sender As Object, e As WebBrowserNavigatedEventArgs) Handles WebBrowser1.Navigated
        Dim uriString() As String
        If (WebBrowser1.Url.ToString.Contains("?code")) Then
            uriString = WebBrowser1.Url.ToString.Split("=&".ToCharArray)
            code = uriString(1)
            Console.WriteLine(token)
            WebBrowser1.Visible = False
            GetTokens()



        End If


        ' για debugging του upload
        Console.WriteLine(WebBrowser1.Url.ToString())


    End Sub

    Private Sub GetTokens()



        Dim url As String = String.Format("https://login.live.com/oauth20_token.srf?client_id={0}&client_secret=qkMMeEhpLbM5GAfVJRWVPfo9PzuIjEGD&code={1}&grant_type=authorization_code&redirect_uri=https://login.live.com/oauth20_desktop.srf", Form1.cliend_id, code)

        Dim req As HttpWebRequest
        req = HttpWebRequest.Create(url)

        Dim objStream As Stream

        objStream = req.GetResponse().GetResponseStream()

        Dim objReader As New StreamReader(objStream)

        Dim json As String = objReader.ReadLine()
        Dim ser As JObject = JObject.Parse(json)
        Dim data As List(Of JToken) = ser.Children().ToList
        For Each item As JProperty In data
            Console.WriteLine(item.Value)

        Next




    End Sub


End Class