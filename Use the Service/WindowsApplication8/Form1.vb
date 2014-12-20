Imports System.ServiceProcess
Imports System.Threading

Public Class Form1
    Private myController As ServiceController
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        myController = New ServiceController("MyService1")
        Try
            myController.Start()
        Catch
            Console.Beep()

        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        myController.ExecuteCommand(129)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If myController.CanStop Then
            myController.Stop()
        End If
    End Sub
End Class
