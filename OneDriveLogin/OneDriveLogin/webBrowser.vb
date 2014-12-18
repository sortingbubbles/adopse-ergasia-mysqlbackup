Public Class webBrowser


    Public token As String = ""

    'Μετά το φόρτωμα της σελίδας ελέγχεται εάν το url έχει το access token
    'Εάν υπάρχει το αποθηκεύει στη μεταβλητή token
    Private Sub WebBrowser1_Navigated(sender As Object, e As WebBrowserNavigatedEventArgs) Handles WebBrowser1.Navigated
        Dim uriString() As String
        If (WebBrowser1.Url.ToString.Contains("#access_token")) Then
            uriString = WebBrowser1.Url.Fragment.Split("=&".ToCharArray)
            token = uriString(1)
            Console.WriteLine(token)
            WebBrowser1.Visible = False
        End If


        ' για debugging του upload
        Console.WriteLine(WebBrowser1.Url.ToString())
        Console.WriteLine(WebBrowser1.DocumentText)

    End Sub


    ' Ανέβασμα αρχείων, καλείται από την Form1 μόλις πατηθεί το 2ο κουμπί 
    ' Δεν έχω καταλάβει ακόμη που πρέπει να βρίσκεται το αρχείο που θέλουμε να ανεβάσουμε... 
    Public Sub uploadFile()
        Dim fileToUpload As String = "fuckthis.txt"
        Dim uploadAddress As String = "https://apis.live.net/v5.0/me/skydrive/files/" + fileToUpload + "?access_token=" + token

        WebBrowser1.Navigate(uploadAddress)
    End Sub
End Class