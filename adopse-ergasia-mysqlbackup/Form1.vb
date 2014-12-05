Imports MySql.Data.MySqlClient

Public Class Form1


    '!!!!!!!KANTE SYNDESH ME VPN ME TO TMHMA!!!!!!!!
    'Syndesh me ton server 192.168.6.153 sth bash adopse 
    'me uid mysqlBackup sthn default port 3306
    'Kanei backup me thn entolh mb.ExportToFile(file) 
    'kai sth synexeia ap8hkeyei to .sql arxeio 
    'ston katalogo Documents me onoma arxeiou backup
    'kai to timestamp ths dhmiourgeias me format
    'yyyy-MM-dd HH-mm-ss
    Private Sub Backup()
        Dim constring As String = "Server=192.168.6.153;Database=adopse;Uid=mysqlBackup;Pwd=;"
        Dim file As String = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\backup(" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ").sql"
        Try
            Dim conn As MySqlConnection = New MySqlConnection(constring)
            Dim cmd As MySqlCommand = New MySqlCommand()
            Dim mb As MySqlBackup = New MySqlBackup(cmd)
            cmd.Connection = conn
            conn.Open()
            mb.ExportToFile(file)
            MessageBox.Show("Backup Done !!!!" & vbCrLf + file)
            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Backup()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class
