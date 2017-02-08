<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form15
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form15))
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.RichTextBox2 = New System.Windows.Forms.RichTextBox()
        Me.RichTextBox3 = New System.Windows.Forms.RichTextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.docmfile = New System.Windows.Forms.SaveFileDialog()
        Me.docfile = New System.Windows.Forms.SaveFileDialog()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.Color.Black
        Me.RichTextBox1.ForeColor = System.Drawing.Color.Lime
        Me.RichTextBox1.Location = New System.Drawing.Point(6, 6)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(263, 270)
        Me.RichTextBox1.TabIndex = 0
        Me.RichTextBox1.Text = ">_"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Black
        Me.Button1.ForeColor = System.Drawing.Color.SpringGreen
        Me.Button1.Location = New System.Drawing.Point(138, 209)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(122, 82)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "EXE2VBA"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(138, 47)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(295, 23)
        Me.TextBox1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(60, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "File URL"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(138, 137)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(295, 23)
        Me.TextBox2.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(135, 162)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 15)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Download Location"
        '
        'TabControl1
        '
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(474, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(280, 307)
        Me.TabControl1.TabIndex = 6
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.RichTextBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 27)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(272, 276)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Info"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.RichTextBox2)
        Me.TabPage2.Controls.Add(Me.RichTextBox3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 27)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(272, 276)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Macro Inputs"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'RichTextBox2
        '
        Me.RichTextBox2.BackColor = System.Drawing.Color.Black
        Me.RichTextBox2.ForeColor = System.Drawing.Color.Lime
        Me.RichTextBox2.Location = New System.Drawing.Point(6, 3)
        Me.RichTextBox2.Name = "RichTextBox2"
        Me.RichTextBox2.Size = New System.Drawing.Size(263, 136)
        Me.RichTextBox2.TabIndex = 7
        Me.RichTextBox2.Text = "Macro Code"
        '
        'RichTextBox3
        '
        Me.RichTextBox3.BackColor = System.Drawing.Color.Black
        Me.RichTextBox3.ForeColor = System.Drawing.Color.Lime
        Me.RichTextBox3.Location = New System.Drawing.Point(6, 141)
        Me.RichTextBox3.Name = "RichTextBox3"
        Me.RichTextBox3.Size = New System.Drawing.Size(263, 137)
        Me.RichTextBox3.TabIndex = 8
        Me.RichTextBox3.Text = "Payload Data"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Black
        Me.Button2.ForeColor = System.Drawing.Color.DeepPink
        Me.Button2.Location = New System.Drawing.Point(311, 209)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(122, 38)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "DOC"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Black
        Me.Button3.ForeColor = System.Drawing.Color.DarkTurquoise
        Me.Button3.Location = New System.Drawing.Point(311, 253)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(122, 38)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "DOCM"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(53, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 15)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "File Name"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(138, 85)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(295, 23)
        Me.TextBox3.TabIndex = 10
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Black
        Me.Button4.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(103, 137)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(29, 23)
        Me.Button4.TabIndex = 11
        Me.Button4.Text = ">"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(25, 329)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 15)
        Me.Label4.TabIndex = 12
        '
        'LinkLabel1
        '
        Me.LinkLabel1.ActiveLinkColor = System.Drawing.Color.White
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkColor = System.Drawing.Color.DimGray
        Me.LinkLabel1.Location = New System.Drawing.Point(3, 329)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(756, 15)
        Me.LinkLabel1.TabIndex = 13
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Please watch the Youtube Video if you have any issues with this option or message" & _
    " on XMPP: Z33nie@xabber.de"
        Me.LinkLabel1.VisitedLinkColor = System.Drawing.Color.Gray
        '
        'Form15
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(766, 352)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.White
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form15"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Word Macro Exploit Offline Method"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents RichTextBox2 As System.Windows.Forms.RichTextBox
    Friend WithEvents RichTextBox3 As System.Windows.Forms.RichTextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents docmfile As System.Windows.Forms.SaveFileDialog
    Friend WithEvents docfile As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
End Class
