Imports MySql.Data.MySqlClient
Imports System.Net.NetworkInformation
Imports System.Collections.ObjectModel
Imports System.Text
Imports System.IO

Public Class Form12
    Dim bcvbBE As String = "ase=sql81"
    Dim j4BE As String = "fizYSQR; da"
    Dim nbBE As String = "225"
    Dim j4B3E As String = "pas"
    Dim cdxhBE As String = "14"
    Dim fdfgdBE As String = "tab"
    Dim jxsrE As String = "sword=IKF"

    Dim con As MySqlConnection = New MySqlConnection("server=sql8.freesqldatabase.com; user id=sql8122514; " & j4B3E & jxsrE & j4BE & fdfgdBE & bcvbBE & nbBE & cdxhBE)

    Dim cmd As New MySqlCommand

    Dim da As New MySqlDataAdapter

    Dim dt As New DataTable
    Dim sqlQuery1 As String
    Dim sqlQuery2 As String
    Dim result As Integer
    Dim mac As String
    Public outfile As String = ""
    Public file As String
    Public dfile As String

    Public Sub login(ByVal sqlQuery1 As String)
        Try
            con.Open()
            With cmd
                .Connection = con
                .CommandText = sqlQuery1
            End With
            'FILLING THE DATA IN A SPICIFIC TABLE OF THE DATABASE
            da.SelectCommand = cmd
            dt = New DataTable
            da.Fill(dt)
            'DECLARING AN INTEGER TO SET THE MAXROWS OF THE TABLE
            Dim maxrow As Integer = dt.Rows.Count
            'CHECKING IF THE DATA EXISTS IN THE ROW OF THE TABLE
            If maxrow > 0 Then
                Form11.Show()
            Else
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox("Error#1c! Please contact support")
            Me.Close()

        End Try
        con.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Function getMacAddress() As String
        Dim nics() As NetworkInterface = NetworkInterface.GetAllNetworkInterfaces()
        Return nics(0).GetPhysicalAddress.ToString
    End Function

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        mac = getMacAddress()
    End Sub

    Private Sub updateMAC(ByVal sqlQuery2 As String)
        Try
            'OPENING THE CONNECTION
            con.Open()
            'HOLDS THE DATA TO BE EXECUTED
            With cmd
                .Connection = con
                .CommandText = sqlQuery2
            End With
            'EXECUTE THE DATA
            result = cmd.ExecuteNonQuery
            'CHECKING IF THE DATA HAS EXECUTED OR NOT
            If result > 0 Then

            Else
                MsgBox("Error#3a! Please contact support")
                Me.Close()

            End If
            con.Close()
        Catch ex As Exception
            MsgBox("Error#3b! Please contact support")
            Me.Close()

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        

        sqlQuery2 = "UPDATE users SET mac='" + mac + "' WHERE email ='" & TextBox1.Text & "'"
        updateMAC(sqlQuery2)
        sqlQuery1 = "SELECT * FROM users WHERE email ='" & TextBox1.Text & "' "
        login(sqlQuery1)
        Me.Close()

    End Sub

    Private Sub Button2_MouseHover(sender As Object, e As EventArgs) Handles Button2.MouseHover
        Button2.BackColor = Color.SeaGreen
    End Sub

    Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave
        Button2.BackColor = Color.MediumSeaGreen
    End Sub

    Private Sub Button1_MouseHover(sender As Object, e As EventArgs) Handles Button1.MouseHover
        Button1.BackColor = Color.DarkGray
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Button1.BackColor = Color.Black
    End Sub
End Class