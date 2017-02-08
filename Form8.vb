Public Class Form8

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form15.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form9.Show()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Me.Close()

    End Sub


    Private Sub Button1_MouseHover(sender As Object, e As EventArgs) Handles Button1.MouseHover
        Button1.BackColor = Color.Turquoise
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Button1.BackColor = Color.MediumTurquoise
    End Sub

    Private Sub Button2_MouseHover(sender As Object, e As EventArgs) Handles Button2.MouseHover
        Button2.BackColor = Color.SpringGreen
    End Sub

    Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave
        Button2.BackColor = Color.Lime
    End Sub
End Class