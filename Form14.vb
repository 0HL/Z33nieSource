Imports System.CodeDom.Compiler
Public Class Form14
    Dim silentfile As String = ""
    Dim silstring() As String
    Dim silCode As String
    Public dGVzdHBhdGg As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
  

    Sub Compilesil(ByVal silentfile As String)
        Dim codeline0 As String = "Imports System.Windows.Forms"
        Dim codeline1 As String = "Imports System"
        Dim codeline2 As String = "Imports System.Environment"
        Dim codeline3 As String = "Imports System.Net"
        Dim codeline4 As String = "Imports System.Diagnostics"
        Dim codeline5 As String = "Imports Microsoft.VisualBasic"
        Dim codeline6 As String = "Imports System.Runtime.InteropServices"
        Dim codeline7 As String = "Namespace S1l3x3ncie"
        Dim codeline8 As String = "Public Class Initiate"
        Dim codeline9 As String = " "
        Dim codeline14 As String = "Public Shared Sub Main(argob As [String]())"
        Dim codeline15 As String = "Dim FrmMainS1l3x3ncie As New Form1"
        Dim codeline16 As String = "Application.Run(FrmMainS1l3x3ncie)"
        Dim codeline17 As String = "End Sub"
        Dim codeline18 As String = "End Class"
        Dim codeline19 As String = "Public Class Form1"
        Dim codeline20 As String = "Inherits System.Windows.Forms.Form"
        Dim codeline21 As String = "Private Enum ShowWindowCommand As Integer"
        Dim codeline22 As String = "Hide = 0"
        Dim codeline23 As String = "Show = 5"
        Dim codeline24 As String = "Minimize = 6"
        Dim codeline25 As String = "Restore = 9"
        Dim codeline26 As String = "End Enum"
        Dim codeline27 As String = "<DllImport(""" + "user32.dll""" + ", SetLastError:=True, CharSet:=CharSet.Auto)> _"
        Dim codeline28 As String = "Private Shared Function ShowWindow(ByVal hwnd As IntPtr, ByVal nCmdShow As ShowWindowCommand) As Boolean"
        Dim codeline29 As String = "End Function"
        Dim codeline30 As String = "<DllImport(""" + "user32.dll""" + ", CharSet:=CharSet.Auto, SetLastError:=True)> _"
        Dim codeline31 As String = "Private Shared Function IsWindow(ByVal hWnd As IntPtr) As Boolean"
        Dim codeline32 As String = "End Function"
        Dim codeline33 As String = "Private Declare Auto Function IsIconic Lib """ + "user32.dll""" + " (ByVal hwnd As IntPtr) As Boolean"
        Dim codeline34 As String = "Private proc_hWnd As IntPtr"
        Dim codeline35 As String = "Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load"
        Dim codeline36 As String = " "
        Dim codeline37 As String = "Me.Hide()"
        Dim codeline38 As String = "Me.ShowInTaskbar = False"
        Dim codeline39 As String = "Me.WindowState = FormWindowState.Minimized"
        Dim codeline40 As String = "Dim slp As New Process"
        Dim codeline41 As String = "Try"
        Dim codeline42 As String = "slp.StartInfo.FileName =" + """" + TextBox1.Text + """"
        Dim codeline43 As String = " "
        Dim codeline44 As String = "slp.StartInfo.WindowStyle = ProcessWindowStyle.Minimized"
        Dim codeline45 As String = "slp.Start()"
        Dim codeline46 As String = "slp.WaitForInputIdle(-1)"
        Dim codeline47 As String = "Dim tmp_hWnd As IntPtr"
        Dim codeline48 As String = "For i As Integer = 1 To 1000"
        Dim codeline49 As String = "tmp_hWnd = slp.MainWindowHandle"
        Dim codeline50 As String = "If Not tmp_hWnd.Equals(IntPtr.Zero) Then Exit For "
        Dim codeline51 As String = "Threading.Thread.Sleep(100)"
        Dim codeline52 As String = "Next "
        Dim codeline53 As String = "If Not tmp_hWnd.Equals(IntPtr.Zero) Then"
        Dim codeline54 As String = "ShowWindow(tmp_hWnd, 0)"
        Dim codeline55 As String = " "
        Dim codeline56 As String = "proc_hWnd = tmp_hWnd"
        Dim codeline57 As String = "End If"
        Dim codeline58 As String = "Catch ex As Exception"
        Dim codeline59 As String = "End Try"
        Dim codeline60 As String = ""
        Dim codeline61 As String = "End Sub"
        Dim codeline62 As String = "End Class"
        Dim codeline63 As String = "End Namespace "


        silstring = New String(59) {codeline0, codeline1, codeline2, codeline3, codeline4, codeline5, codeline6, codeline7, codeline8, codeline9, codeline14, codeline15, codeline16, codeline17, codeline18, codeline19, codeline20, codeline21, codeline22, codeline23, codeline24, codeline25, codeline26, codeline27, codeline28, codeline29, codeline30, codeline31, codeline32, codeline33, codeline34, codeline35, codeline36, codeline37, codeline38, codeline39, codeline40, codeline41, codeline42, codeline43, codeline44, codeline45, codeline46, codeline47, codeline48, codeline49, codeline50, codeline51, codeline52, codeline53, codeline54, codeline55, codeline56, codeline57, codeline58, codeline59, codeline60, codeline61, codeline62, codeline63}

        silCode = String.Join(vbNewLine, silstring)


        

    End Sub

    Sub Executesil(ByVal Destination As String, ByVal obResources As String())
        Dim cpsil As New CompilerParameters


        cpsil.ReferencedAssemblies.Add("System.dll")
        cpsil.ReferencedAssemblies.Add(dGVzdHBhdGg & "\Z33nie\System.Windows.Forms.dll")
        cpsil.ReferencedAssemblies.Add(dGVzdHBhdGg & "\Z33nie\System.Drawing.dll")

        cpsil.CompilerOptions = " /target:winexe /optimize"

        Dim Provider As VBCodeProvider

        For Each psr As String In obResources
            cpsil.EmbeddedResources.Add(psr)
        Next

        cpsil.GenerateExecutable = True
        cpsil.OutputAssembly = Destination
        cpsil.GenerateInMemory = False

        Dim errors As System.CodeDom.Compiler.CompilerResults = Provider.CompileAssemblyFromSource(cpsil, silCode)
        If errors.Errors.HasErrors Then
            MessageBox.Show(errors.Errors(0).ToString)
        End If


    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Then
            MsgBox("Input File not selected! ")

        Else
            Dim sfd As New SaveFileDialog
            sfd.Filter = "Exe Files|*.exe"

            If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
                silentfile = sfd.FileName
            Else
                Exit Sub
            End If
            Try
                Compilesil(silentfile)
                Dim ersil As String() = {TextBox1.Text}
                Executesil(silentfile, ersil)

            Catch ex As Exception
                MsgBox("Something Went wrong in creating slient EXE. Please contact Support. Error#CXS")
            End Try
            Me.Close()

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim silofd As New OpenFileDialog
        silofd.Filter = "Exe Files|*.exe"
        If silofd.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextBox1.Text = silofd.FileName
        Else
            Exit Sub
        End If
    End Sub

    Private Sub Button1_MouseHover(sender As Object, e As EventArgs) Handles Button1.MouseHover
        Button1.BackColor = Color.DarkGray

    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Button1.BackColor = Color.DimGray

    End Sub

    Private Sub Button2_MouseHover(sender As Object, e As EventArgs) Handles Button2.MouseHover
        Button2.BackColor = Color.Gold
        Button2.ForeColor = Color.Black

    End Sub

    Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave
        Button2.BackColor = Color.Black
        Button2.ForeColor = Color.Gold


    End Sub

   
End Class