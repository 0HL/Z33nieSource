
Imports System.Collections
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.IO
Imports EAGetMail 'imports EAGetMail namespace

Public Class Form18

    Private Sub ConvertMailToHtml(ByVal fileName As String)
        Try
            Dim pos As Integer = fileName.LastIndexOf(".")
            Dim mainName As String = fileName.Substring(0, pos)
            Dim htmlName As String = mainName & ".htm"

            Dim tempFolder As String = mainName
            If Not File.Exists(htmlName) Then

                ' We haven't generate the html for this email, generate it now.
                _GenerateHtmlForEmail(htmlName, fileName, tempFolder)
            End If

            Console.WriteLine("Please open {0} to browse your email", htmlName)
        Catch ep As Exception
            Console.WriteLine(ep.Message)
        End Try
    End Sub

    Private Function _FormatHtmlTag(ByVal src As String) As String
        src = src.Replace(">", "&gt;")
        src = src.Replace("<", "&lt;")
        Return src
    End Function

    ' We generate a html + attachment folder for every email, once the html is create,
    ' next time we don't need to parse the email again.
    Private Sub _GenerateHtmlForEmail(ByVal htmlName As String, _
            ByVal emlFile As String, ByVal tempFolder As String)
        Dim oMail As New Mail("TryIt")
        oMail.Load(emlFile, False)

        If oMail.IsEncrypted Then
            Try

                ' This email is encrypted, we decrypt it by user default certificate.
                oMail = oMail.Decrypt(Nothing)
            Catch ep As Exception
                Console.WriteLine(ep.Message)
                oMail.Load(emlFile, False)
            End Try
        End If

        If oMail.IsSigned Then
            Try
                ' This email is digital signed.
                Dim cert As EAGetMail.Certificate = oMail.VerifySignature()
                Console.WriteLine("This email contains a valid digital signature.")
            Catch ep As Exception
                Console.WriteLine(ep.Message)
            End Try
        End If

        ' Decode winmail.dat (TNEF) and RTF body automatically
        ' also convert RTF body to HTML automatically.
        oMail.DecodeTNEF()

        ' Parse html body
        Dim html As String = oMail.HtmlBody
        Dim hdr As New StringBuilder()

        ' Parse sender
        hdr.Append("<font face=""Courier New,Arial"" size=2>")
        hdr.Append("<b>From:</b> " & _FormatHtmlTag(oMail.From.ToString()) & "<br>")

        ' Parse to
        Dim addrs As MailAddress() = oMail.[To]
        Dim count As Integer = addrs.Length
        If count > 0 Then
            hdr.Append("<b>To:</b> ")
            For i As Integer = 0 To count - 1
                hdr.Append(_FormatHtmlTag(addrs(i).ToString()))
                If i < count - 1 Then
                    hdr.Append(";")
                End If
            Next
            hdr.Append("<br>")
        End If

        ' Parse cc
        addrs = oMail.Cc

        count = addrs.Length
        If count > 0 Then
            hdr.Append("<b>Cc:</b> ")
            For i As Integer = 0 To count - 1
                hdr.Append(_FormatHtmlTag(addrs(i).ToString()))
                If i < count - 1 Then
                    hdr.Append(";")
                End If
            Next
            hdr.Append("<br>")
        End If

        hdr.Append([String].Format("<b>Subject:</b>{0}<br>" & vbCr & vbLf, _
            _FormatHtmlTag(oMail.Subject)))

        ' Parse attachments and save to local folder
        Dim atts As Attachment() = oMail.Attachments
        count = atts.Length
        If count > 0 Then
            If Not Directory.Exists(tempFolder) Then
                Directory.CreateDirectory(tempFolder)
            End If

            hdr.Append("<b>Attachments:</b>")
            For i As Integer = 0 To count - 1
                Dim att As Attachment = atts(i)

                Dim attname As String = String.Format("{0}\{1}", tempFolder, att.Name)
                att.SaveAs(attname, True)
                hdr.Append(String.Format("<a href=""{0}"" target=""_blank"">{1}</a> ", _
                        attname, att.Name))
                If att.ContentID.Length > 0 Then

                    ' Show embedded images.
                    html = html.Replace("cid:" + att.ContentID, attname)
                ElseIf [String].Compare(att.ContentType, 0, "image/", 0, _
                        "image/".Length, True) = 0 Then

                    ' Show attached images.
                    html = html & String.Format("<hr><img src=""{0}"">", attname)
                End If
            Next
        End If

        Dim reg As New Regex("(<meta[^>]*charset[ " & vbTab & "]*=[ " _
            & vbTab & """]*)([^<> " & vbCr & vbLf & """]*)", _
            RegexOptions.Multiline Or RegexOptions.IgnoreCase)
        html = reg.Replace(html, "$1utf-8")
        If Not reg.IsMatch(html) Then
            hdr.Insert(0, _
            "<meta HTTP-EQUIV=""Content-Type"" Content=""text-html; charset=utf-8"">")
        End If

        ' Write html to file
        html = hdr.ToString() & "<hr>" & html
        Dim fs As New FileStream(htmlName, FileMode.Create, FileAccess.Write, FileShare.None)

        Dim data As Byte() = System.Text.UTF8Encoding.UTF8.GetBytes(html)
        fs.Write(data, 0, data.Length)
        fs.Close()
        oMail.Clear()
    End Sub

    Sub Main()

        

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dGVzdHBhdGg As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        ' Create a folder named "inbox" under current directory
        ' to save the email retrieved.
        Dim curpath As String = Directory.GetCurrentDirectory()
        Dim mailbox As String = dGVzdHBhdGg & "\Z33nie\Keylogs"

        '[String].Format("{0}\inbox", curpath)

        ' If the folder is not existed, create it.
        If Not Directory.Exists(mailbox) Then
            Directory.CreateDirectory(mailbox)
        End If

        ' Get all *.eml files in specified folder and parse it one by one.
        Dim files As String() = Directory.GetFiles(mailbox, "*.eml")
        For i As Integer = 0 To files.Length - 1
            ConvertMailToHtml(files(i))
        Next

    End Sub
End Class