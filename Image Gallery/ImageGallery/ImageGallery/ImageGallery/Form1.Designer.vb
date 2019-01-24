<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Me.DirectoryTextBox = New System.Windows.Forms.TextBox()
        Me.GetImage = New System.Windows.Forms.Button()
        Me.ListRadioButton = New System.Windows.Forms.RadioButton()
        Me.ThumbnailRadioButton = New System.Windows.Forms.RadioButton()
        Me.StyleGroupBox = New System.Windows.Forms.GroupBox()
        Me.ImageFilterRadioButton = New System.Windows.Forms.RadioButton()
        Me.SlideShowRadioButton = New System.Windows.Forms.RadioButton()
        Me.ImageListBox = New System.Windows.Forms.ListBox()
        Me.DirectoryLabel = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.BrowserButton = New System.Windows.Forms.Button()
        Me.ImagePictureBox = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.bXRay = New System.Windows.Forms.Button()
        Me.bEdge = New System.Windows.Forms.Button()
        Me.bNegative = New System.Windows.Forms.Button()
        Me.bSepia = New System.Windows.Forms.Button()
        Me.bGray = New System.Windows.Forms.Button()
        Me.BackButton = New System.Windows.Forms.Button()
        Me.Previous = New System.Windows.Forms.Button()
        Me.NextButton = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.DropDownList = New System.Windows.Forms.ListBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.BrowseButton2 = New System.Windows.Forms.Button()
        Me.Save = New System.Windows.Forms.Button()
        Me.StyleGroupBox.SuspendLayout()
        CType(Me.ImagePictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DirectoryTextBox
        '
        Me.DirectoryTextBox.Location = New System.Drawing.Point(38, 41)
        Me.DirectoryTextBox.Name = "DirectoryTextBox"
        Me.DirectoryTextBox.Size = New System.Drawing.Size(554, 22)
        Me.DirectoryTextBox.TabIndex = 1
        '
        'GetImage
        '
        Me.GetImage.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GetImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GetImage.Location = New System.Drawing.Point(840, 36)
        Me.GetImage.Name = "GetImage"
        Me.GetImage.Size = New System.Drawing.Size(122, 31)
        Me.GetImage.TabIndex = 4
        Me.GetImage.Text = "Get Images"
        Me.GetImage.UseVisualStyleBackColor = False
        '
        'ListRadioButton
        '
        Me.ListRadioButton.AutoSize = True
        Me.ListRadioButton.Checked = True
        Me.ListRadioButton.Location = New System.Drawing.Point(6, 21)
        Me.ListRadioButton.Name = "ListRadioButton"
        Me.ListRadioButton.Size = New System.Drawing.Size(51, 21)
        Me.ListRadioButton.TabIndex = 5
        Me.ListRadioButton.TabStop = True
        Me.ListRadioButton.Text = "List"
        Me.ListRadioButton.UseVisualStyleBackColor = True
        '
        'ThumbnailRadioButton
        '
        Me.ThumbnailRadioButton.AutoSize = True
        Me.ThumbnailRadioButton.Location = New System.Drawing.Point(6, 46)
        Me.ThumbnailRadioButton.Name = "ThumbnailRadioButton"
        Me.ThumbnailRadioButton.Size = New System.Drawing.Size(95, 21)
        Me.ThumbnailRadioButton.TabIndex = 6
        Me.ThumbnailRadioButton.TabStop = True
        Me.ThumbnailRadioButton.Text = "Thumbnail"
        Me.ThumbnailRadioButton.UseVisualStyleBackColor = True
        '
        'StyleGroupBox
        '
        Me.StyleGroupBox.Controls.Add(Me.ImageFilterRadioButton)
        Me.StyleGroupBox.Controls.Add(Me.SlideShowRadioButton)
        Me.StyleGroupBox.Controls.Add(Me.ListRadioButton)
        Me.StyleGroupBox.Controls.Add(Me.ThumbnailRadioButton)
        Me.StyleGroupBox.Location = New System.Drawing.Point(668, -3)
        Me.StyleGroupBox.Name = "StyleGroupBox"
        Me.StyleGroupBox.Size = New System.Drawing.Size(166, 118)
        Me.StyleGroupBox.TabIndex = 7
        Me.StyleGroupBox.TabStop = False
        Me.StyleGroupBox.Text = "Style"
        '
        'ImageFilterRadioButton
        '
        Me.ImageFilterRadioButton.AutoSize = True
        Me.ImageFilterRadioButton.Location = New System.Drawing.Point(6, 89)
        Me.ImageFilterRadioButton.Name = "ImageFilterRadioButton"
        Me.ImageFilterRadioButton.Size = New System.Drawing.Size(101, 21)
        Me.ImageFilterRadioButton.TabIndex = 10
        Me.ImageFilterRadioButton.TabStop = True
        Me.ImageFilterRadioButton.Text = "Imagefilters"
        Me.ImageFilterRadioButton.UseVisualStyleBackColor = True
        '
        'SlideShowRadioButton
        '
        Me.SlideShowRadioButton.AutoSize = True
        Me.SlideShowRadioButton.Location = New System.Drawing.Point(6, 68)
        Me.SlideShowRadioButton.Name = "SlideShowRadioButton"
        Me.SlideShowRadioButton.Size = New System.Drawing.Size(98, 21)
        Me.SlideShowRadioButton.TabIndex = 7
        Me.SlideShowRadioButton.TabStop = True
        Me.SlideShowRadioButton.Text = "Slide Show"
        Me.SlideShowRadioButton.UseVisualStyleBackColor = True
        '
        'ImageListBox
        '
        Me.ImageListBox.Enabled = False
        Me.ImageListBox.FormattingEnabled = True
        Me.ImageListBox.ItemHeight = 16
        Me.ImageListBox.Location = New System.Drawing.Point(38, 136)
        Me.ImageListBox.Name = "ImageListBox"
        Me.ImageListBox.Size = New System.Drawing.Size(161, 308)
        Me.ImageListBox.TabIndex = 8
        Me.ImageListBox.Visible = False
        '
        'DirectoryLabel
        '
        Me.DirectoryLabel.AutoSize = True
        Me.DirectoryLabel.Location = New System.Drawing.Point(35, 21)
        Me.DirectoryLabel.Name = "DirectoryLabel"
        Me.DirectoryLabel.Size = New System.Drawing.Size(197, 17)
        Me.DirectoryLabel.TabIndex = 10
        Me.DirectoryLabel.Text = "Enter the directory name here"
        '
        'BrowserButton
        '
        Me.BrowserButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BrowserButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BrowserButton.Location = New System.Drawing.Point(598, 40)
        Me.BrowserButton.Name = "BrowserButton"
        Me.BrowserButton.Size = New System.Drawing.Size(40, 23)
        Me.BrowserButton.TabIndex = 12
        Me.BrowserButton.Text = "..."
        Me.BrowserButton.UseVisualStyleBackColor = False
        '
        'ImagePictureBox
        '
        Me.ImagePictureBox.Location = New System.Drawing.Point(3, 16)
        Me.ImagePictureBox.Name = "ImagePictureBox"
        Me.ImagePictureBox.Size = New System.Drawing.Size(780, 430)
        Me.ImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ImagePictureBox.TabIndex = 9
        Me.ImagePictureBox.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.bXRay)
        Me.Panel1.Controls.Add(Me.bEdge)
        Me.Panel1.Controls.Add(Me.bNegative)
        Me.Panel1.Controls.Add(Me.bSepia)
        Me.Panel1.Controls.Add(Me.bGray)
        Me.Panel1.Controls.Add(Me.ImagePictureBox)
        Me.Panel1.Location = New System.Drawing.Point(209, 120)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(786, 454)
        Me.Panel1.TabIndex = 11
        '
        'bXRay
        '
        Me.bXRay.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.bXRay.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.bXRay.Location = New System.Drawing.Point(708, 341)
        Me.bXRay.Name = "bXRay"
        Me.bXRay.Size = New System.Drawing.Size(75, 23)
        Me.bXRay.TabIndex = 14
        Me.bXRay.Text = "XRay"
        Me.bXRay.UseVisualStyleBackColor = False
        '
        'bEdge
        '
        Me.bEdge.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.bEdge.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.bEdge.Location = New System.Drawing.Point(708, 274)
        Me.bEdge.Name = "bEdge"
        Me.bEdge.Size = New System.Drawing.Size(75, 23)
        Me.bEdge.TabIndex = 13
        Me.bEdge.Text = "Edge"
        Me.bEdge.UseVisualStyleBackColor = False
        '
        'bNegative
        '
        Me.bNegative.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.bNegative.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.bNegative.Location = New System.Drawing.Point(708, 204)
        Me.bNegative.Name = "bNegative"
        Me.bNegative.Size = New System.Drawing.Size(75, 23)
        Me.bNegative.TabIndex = 12
        Me.bNegative.Text = "Negative"
        Me.bNegative.UseVisualStyleBackColor = False
        '
        'bSepia
        '
        Me.bSepia.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.bSepia.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.bSepia.Location = New System.Drawing.Point(708, 132)
        Me.bSepia.Name = "bSepia"
        Me.bSepia.Size = New System.Drawing.Size(75, 23)
        Me.bSepia.TabIndex = 11
        Me.bSepia.Text = "Sepia"
        Me.bSepia.UseVisualStyleBackColor = False
        '
        'bGray
        '
        Me.bGray.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.bGray.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.bGray.Location = New System.Drawing.Point(708, 52)
        Me.bGray.Name = "bGray"
        Me.bGray.Size = New System.Drawing.Size(75, 23)
        Me.bGray.TabIndex = 10
        Me.bGray.Text = "Gray"
        Me.bGray.UseVisualStyleBackColor = False
        '
        'BackButton
        '
        Me.BackButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BackButton.Location = New System.Drawing.Point(840, 78)
        Me.BackButton.Name = "BackButton"
        Me.BackButton.Size = New System.Drawing.Size(122, 23)
        Me.BackButton.TabIndex = 13
        Me.BackButton.Text = "Back"
        Me.BackButton.UseVisualStyleBackColor = False
        '
        'Previous
        '
        Me.Previous.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Previous.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Previous.Location = New System.Drawing.Point(212, 74)
        Me.Previous.Name = "Previous"
        Me.Previous.Size = New System.Drawing.Size(103, 31)
        Me.Previous.TabIndex = 14
        Me.Previous.Text = "Previous"
        Me.Previous.UseVisualStyleBackColor = False
        '
        'NextButton
        '
        Me.NextButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.NextButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.NextButton.Location = New System.Drawing.Point(321, 74)
        Me.NextButton.Name = "NextButton"
        Me.NextButton.Size = New System.Drawing.Size(103, 31)
        Me.NextButton.TabIndex = 15
        Me.NextButton.Text = "Next"
        Me.NextButton.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'DropDownList
        '
        Me.DropDownList.Enabled = False
        Me.DropDownList.FormattingEnabled = True
        Me.DropDownList.ItemHeight = 16
        Me.DropDownList.Location = New System.Drawing.Point(38, 450)
        Me.DropDownList.Name = "DropDownList"
        Me.DropDownList.Size = New System.Drawing.Size(161, 116)
        Me.DropDownList.TabIndex = 16
        Me.DropDownList.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(209, 588)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(554, 22)
        Me.TextBox2.TabIndex = 18
        '
        'BrowseButton2
        '
        Me.BrowseButton2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BrowseButton2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BrowseButton2.Location = New System.Drawing.Point(783, 587)
        Me.BrowseButton2.Name = "BrowseButton2"
        Me.BrowseButton2.Size = New System.Drawing.Size(40, 23)
        Me.BrowseButton2.TabIndex = 19
        Me.BrowseButton2.Text = "..."
        Me.BrowseButton2.UseVisualStyleBackColor = False
        '
        'Save
        '
        Me.Save.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Save.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Save.Location = New System.Drawing.Point(840, 581)
        Me.Save.Name = "Save"
        Me.Save.Size = New System.Drawing.Size(122, 31)
        Me.Save.TabIndex = 20
        Me.Save.Text = "Save"
        Me.Save.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightCyan
        Me.ClientSize = New System.Drawing.Size(1045, 653)
        Me.Controls.Add(Me.Save)
        Me.Controls.Add(Me.BrowseButton2)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.DropDownList)
        Me.Controls.Add(Me.NextButton)
        Me.Controls.Add(Me.Previous)
        Me.Controls.Add(Me.BackButton)
        Me.Controls.Add(Me.BrowserButton)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DirectoryLabel)
        Me.Controls.Add(Me.ImageListBox)
        Me.Controls.Add(Me.StyleGroupBox)
        Me.Controls.Add(Me.GetImage)
        Me.Controls.Add(Me.DirectoryTextBox)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.StyleGroupBox.ResumeLayout(False)
        Me.StyleGroupBox.PerformLayout()
        CType(Me.ImagePictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DirectoryTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GetImage As System.Windows.Forms.Button
    Friend WithEvents ListRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents ThumbnailRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents StyleGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents ImageListBox As System.Windows.Forms.ListBox
    Friend WithEvents DirectoryLabel As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents BrowserButton As System.Windows.Forms.Button
    Friend WithEvents ImagePictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BackButton As System.Windows.Forms.Button
    Friend WithEvents Previous As System.Windows.Forms.Button
    Friend WithEvents NextButton As System.Windows.Forms.Button
    Friend WithEvents SlideShowRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents DropDownList As System.Windows.Forms.ListBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents BrowseButton2 As System.Windows.Forms.Button
    Friend WithEvents Save As System.Windows.Forms.Button
    Friend WithEvents ImageFilterRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents bXRay As System.Windows.Forms.Button
    Friend WithEvents bEdge As System.Windows.Forms.Button
    Friend WithEvents bNegative As System.Windows.Forms.Button
    Friend WithEvents bSepia As System.Windows.Forms.Button
    Friend WithEvents bGray As System.Windows.Forms.Button

End Class
