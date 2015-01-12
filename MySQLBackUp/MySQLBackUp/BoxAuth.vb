Imports Newtonsoft.Json.Linq
Imports System.Web
Imports System.Collections.Specialized
Imports System.Net
Imports System.Text
Imports System.IO
Imports System.Xml
Public Class BoxAuth
    Private tokenPath As String
    Private xmlD As XmlDocument
    Private _MyBoxClient As MyBoxClient
    Public Sub New(ByRef MBox As MyBoxClient)
        InitializeComponent()
        _MyBoxClient = MBox
    End Sub
    'me th me8odo wb_Navigated perimenoume o xrhsths na paei sth
    'selida ths opoias to url periexei to pedio "code"
    'tote to epistrefoume sthn klash MyBoxClient
    Private Sub wb_Navigated(sender As Object, e As WebBrowserNavigatedEventArgs) Handles wb.Navigated
        If (wb.Url.ToString.Contains("code=")) Then

            Dim parms As NameValueCollection = HttpUtility.ParseQueryString(e.Url.Query)
            If (parms.AllKeys.Contains("error")) Then
                MessageBox.Show("ERROR")
            Else
                _MyBoxClient.Code = parms("code")
            End If
            Me.Close()
        End If
    End Sub
End Class