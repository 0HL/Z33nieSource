Imports MySql.Data.MySqlClient
Imports System.Net.NetworkInformation
Imports System.CodeDom.Compiler
Imports System.Collections.ObjectModel
Imports System.Text
Imports System.IO

Public Class Form2
    Public dGVzdHBhdGg As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
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
    Dim outfile As String = ""
    Dim tempoutfile As String = ""
    Dim filenm As String
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
                Dim sfd As New SaveFileDialog
                sfd.Filter = "Exe Files|*.exe"

                ' Dim IconFile As String = ""
                If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
                    outfile = sfd.FileName
                    dfile = System.IO.Path.GetFileName(outfile)
                    tempoutfile = Path.GetTempPath & dfile
                    filenm = outfile.Replace(".exe", "")

                Else
                    Exit Sub
                End If
                Form1.createFileforCompile(tempoutfile)
                Dim ultrcs As String() = {Form1.dGVzdHBhdGg & "\Z33nie\errors.ps1", Form1.dGVzdHBhdGg & "\Z33nie\eventmanager.ps1", Form1.dGVzdHBhdGg & "\Z33nie\ExceptionHandlers.ps1", Form1.dGVzdHBhdGg & "\Z33nie\SysConfigDataInt.xml"}
                Form1.CreateExe(tempoutfile, ultrcs)

                Using crx2 As StreamWriter = New StreamWriter(dGVzdHBhdGg & "\Z33nie\cryptxml.crproj")

                    crx2.WriteLine("<project baseDir=""" + Path.GetDirectoryName(tempoutfile) + """ outputDir=""" + Path.GetDirectoryName(outfile) + "\Output" + """ xmlns=""" + "http://confuser.codeplex.com""" + ">")
                    crx2.WriteLine("<packer id=""" + "compressor""" + " />")
                    crx2.WriteLine("<module path=""" + tempoutfile + """>")
                    crx2.WriteLine("<rule preset=""" + "normal""" + " pattern=""" + "true""" + " inherit=""" + "false""" + "/>")
                    crx2.WriteLine("</module>")
                    crx2.WriteLine(" </project>")

                    crx2.Close()

                End Using


                Try

                    Dim cryptxmlpath As String = dGVzdHBhdGg & "\Z33nie\cryptxml.crproj"

                    Shell("cmd.exe /c cd " & dGVzdHBhdGg & "\Z33nie\Confuser & Confuser.CLI.exe " & cryptxmlpath, AppWinStyle.Hide)
                    System.Threading.Thread.Sleep(10000)

                Catch ex As Exception
                    MsgBox("Something Went wrong in creating EXE. Please contact Support. Error#CX1")
                End Try
            Else
                MsgBox("Error#1a! Please contact support")
            End If
        Catch ex As Exception
            MsgBox("Error#1b! Please contact support")
        End Try
        con.Close()
        Try
            File.Delete(tempoutfile)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        

        sqlQuery2 = "UPDATE users SET mac='" + mac + "' WHERE email ='" & TextBox1.Text & "'"
        updateMAC(sqlQuery2)
        sqlQuery1 = "SELECT * FROM users WHERE email ='" & TextBox1.Text & "' "
        login(sqlQuery1)
        Me.Hide()
    End Sub

    Function getMacAddress() As String
        Dim nics() As NetworkInterface = NetworkInterface.GetAllNetworkInterfaces()
        Return nics(0).GetPhysicalAddress.ToString
    End Function

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
                MsgBox("Error#2a! Please contact support")
            End If
            con.Close()
        Catch ex As Exception
            MsgBox("Error#2b! Please contact support")
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()

    End Sub

    Private Sub Button1_MouseHover(sender As Object, e As EventArgs) Handles Button1.MouseHover
        Button1.BackColor = Color.SeaGreen
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Button1.BackColor = Color.MediumSeaGreen
    End Sub

    Private Sub Button2_MouseHover(sender As Object, e As EventArgs) Handles Button2.MouseHover
        Button2.BackColor = Color.DarkGray
    End Sub

    Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave
        Button2.BackColor = Color.Black
    End Sub
End Class