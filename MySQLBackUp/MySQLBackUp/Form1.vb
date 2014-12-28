Public Class Form1

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

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabControl1.TabPages("TabPage2").Enabled = False
        TabControl1.TabPages("TabPage3").Enabled = False
        TabControl1.TabPages("TabPage4").Enabled = False
    End Sub

    Private Sub FirstTab_Click(sender As Object, e As EventArgs) Handles FirstTab.Click
        TabControl1.TabPages("TabPage2").Enabled = True
        TabControl1.TabPages("TabPage1").Enabled = False
        TabControl1.SelectedTab = TabControl1.TabPages("TabPage2")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TabControl1.TabPages("TabPage3").Enabled = True
        TabControl1.TabPages("TabPage2").Enabled = False
        TabControl1.SelectedTab = TabControl1.TabPages("TabPage3")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TabControl1.TabPages("TabPage4").Enabled = True
        TabControl1.TabPages("TabPage3").Enabled = False
        TabControl1.SelectedTab = TabControl1.TabPages("TabPage4")
    End Sub
End Class
