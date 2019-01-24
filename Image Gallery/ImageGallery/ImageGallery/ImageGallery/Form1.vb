Imports System.IO
Imports System.Drawing.Imaging

Public Class Form1
    'Variable to hold the directory containing images
    Dim directoryName As String
    'Variable to hold the current image shown in the slideshow
    Dim cur_slideshow_images As Integer
    'Array to hold the names of all the image files in the directory
    Dim files() As String
    'Variable to hold the page number of the thumbnails
    Dim page As Integer = 0
    Dim oldsize As Size
    Dim oldlocaion As Point
    'Variables to hold the row and column of the images in thumbnails
    Dim rowImage, colImage As Integer
    'Variable to store the total number of images
    Dim no_images As Integer = 0
    Dim bmp01, bmp02, bmpTemp As Bitmap
    Dim clr, clrTemp As Color
    Dim intR, intG, intB, intTemp As Integer
    Dim globalimage As Image


    Private Sub GetImage_Click(sender As Object, e As EventArgs) Handles GetImage.Click
        Try
            'Set the directory and initialize all variables
            directoryName = DirectoryTextBox.Text
            ImageListBox.Enabled = False
            ImageListBox.Visible = False
            Timer1.Enabled = False
            page = 0

            'If the directory is not a valid one then print an error
            If (Not Directory.Exists(directoryName)) Then
                MessageBox.Show("Enter a valid Directory", "Error")
                Exit Sub
            End If

            'Variables to store all the file names in the directory and the extension
            Dim all_files() As String
            Dim extension As String
            'Get all the file names in the given directory
            all_files = Directory.GetFiles(directoryName)

            'Set next and prev buttons invisible
            NextButton.Visible = False
            Previous.Visible = False
            'Initialize number of images to 0
            no_images = 0
            'Empty the global array
            Erase files

            'Loop through all the files
            For Each file As String In all_files
                'Get the extension of the file
                extension = Path.GetExtension(file)
                'If the extension is that of an image add it to the files array and imcrement total images
                If (extension = ".jpg" Or extension = ".jpeg" Or extension = ".png" Or extension = ".gif" Or extension = ".ico") Then
                    ReDim Preserve files(no_images)
                    files(no_images) = file
                    no_images += 1
                End If
            Next

            'In case there are no images then print that there are no images to display
            If (no_images = 0) Then
                MessageBox.Show("There are no image files in this directory")
                Exit Sub
            End If
            ImagePictureBox.Visible = False
            'According to the radio button that is selected, call different functions
            If (ListRadioButton.Checked = True) Then
                populate_list()
            ElseIf (ThumbnailRadioButton.Checked = True) Then
                ImagePictureBox.AllowDrop = False
                DropDownList.Visible = False
                DropDownList.Enabled = False
                DropDownList.Items.Clear()
                TextBox2.Enabled = False
                TextBox2.Visible = False
                Save.Enabled = False
                Save.Visible = False
                BrowseButton2.Enabled = False
                BrowseButton2.Visible = False
                populate_thumbnails()
            ElseIf (SlideShowRadioButton.Checked = True) Then
                ImagePictureBox.AllowDrop = False
                DropDownList.Visible = False
                DropDownList.Enabled = False
                DropDownList.Items.Clear()
                TextBox2.Enabled = False
                TextBox2.Visible = False
                Save.Enabled = False
                Save.Visible = False
                BrowseButton2.Enabled = False
                BrowseButton2.Visible = False
                start_slideshow()
            Else
                ImagePictureBox.AllowDrop = False
                DropDownList.Visible = False
                DropDownList.Enabled = False
                DropDownList.Items.Clear()
                TextBox2.Enabled = False
                TextBox2.Visible = False
                Save.Enabled = False
                Save.Visible = False
                BrowseButton2.Enabled = False
                BrowseButton2.Visible = False
                img_filters()
            End If
            BackButton.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub img_filters()
        Try
            RemoveThumbnails()
            ImageListBox.Enabled = True
            ImageListBox.Visible = True
            ImagePictureBox.Visible = True
            ImagePictureBox.Image = Nothing
            ImageListBox.Items.Clear()

            For Each file As String In files
                ImageListBox.Items.Add(Path.GetFileName(file))

            Next
            NextButton.Visible = False
            Previous.Visible = False

            bGray.Visible = True
            bXRay.Visible = True
            bSepia.Visible = True
            bNegative.Visible = True
            bEdge.Visible = True


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub start_slideshow()
        'This will enable timer and start slide show.
        Try
            RemoveThumbnails()
            ImagePictureBox.Visible = True
            ImagePictureBox.Image = Nothing
            cur_slideshow_images = 0
            Timer1.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub populate_list()
        'This will enter the names of images in files() in ImageListBox
        Try
            RemoveThumbnails()
            ImageListBox.Enabled = True
            ImageListBox.Visible = True
            ImagePictureBox.Visible = True
            ImagePictureBox.Image = Nothing
            DropDownList.Visible = True
            DropDownList.Enabled = True
            TextBox2.Enabled = True
            TextBox2.Visible = True
            Save.Enabled = True
            Save.Visible = True
            BrowseButton2.Enabled = True
            BrowseButton2.Visible = True
            ImagePictureBox.AllowDrop = True
            ImageListBox.Items.Clear()

            For Each file As String In files
                ImageListBox.Items.Add(Path.GetFileName(file))
                'MessageBox.Show(file)
            Next
            NextButton.Visible = False
            Previous.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub populate_thumbnails()
        'This will load 9 images according to the page number on th ImagePictureBox
        Try
            ImagePictureBox.Visible = True
            ImagePictureBox.Image = Nothing
            NextButton.Visible = True
            RemoveThumbnails()
            rowImage = 1
            colImage = 1

            Dim countpics As Integer = 0
            ' A while loop to count the number of pics added
            While (countpics < 9)
                If (page * 9 + countpics >= files.Length) Then
                    NextButton.Visible = False
                    Return
                End If
                ' A function to add images
                addImage(files(page * 9 + countpics))
                countpics += 1
            End While
            BackButton.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub addImage(ByVal file As String)
        ' This function adds images row-wise.
        Try
            Dim width, height, Xloc, Yloc As Decimal
            ' Allocating the size to image
            width = (ImagePictureBox.Width) / 3
            width -= 10
            height = (width * 9) / 16
            ' Allocating the location to image
            Xloc = (colImage - 1) * (width + 10) + 5
            Yloc = (rowImage - 1) * (height + 10) + 5
            'Allocating picturebox to image
            Dim newPic As New PictureBox
            newPic.Location = New System.Drawing.Point(Xloc, Yloc)
            newPic.Size = New System.Drawing.Size(width, height)
            newPic.BorderStyle = BorderStyle.None
            newPic.Image = Image.FromFile(file)
            newPic.SizeMode = PictureBoxSizeMode.Zoom
            ImagePictureBox.Controls.Add(newPic)
            ' Declaration of function on dynamically declared newPic
            AddHandler newPic.Click, AddressOf Me.newPic_click
            AddHandler newPic.MouseEnter, AddressOf Me.newPic_MouseEnter
            AddHandler newPic.MouseLeave, AddressOf Me.newPic_MouseLeave
            'Ensuring that at most 9 images form a grid in the box
            colImage = colImage + 1
            If (colImage = 4) Then
                colImage = 1
                rowImage = rowImage + 1
                If (rowImage = 4) Then
                    Return
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub RemoveThumbnails()
        ' Clears all the newPic pictureboxes added 
Again:  For Each ctrl In ImagePictureBox.Controls
            ImagePictureBox.Controls.Remove(ctrl)
        Next
        If ImagePictureBox.Controls.Count > 0 Then
            GoTo Again
        End If
        bGray.Visible = False
        bXRay.Visible = False
        bSepia.Visible = False
        bNegative.Visible = False
        bEdge.Visible = False
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' The very first function which will run and intialize our variables as needed
        Try
            ImageListBox.HorizontalScrollbar = True
            DropDownList.HorizontalScrollbar = True
            Me.AutoScroll = True
            ImagePictureBox.Visible = True
            DropDownList.Visible = True
            DropDownList.Enabled = True
            ImagePictureBox.BorderStyle = BorderStyle.FixedSingle
            ImagePictureBox.AllowDrop = True
            Previous.Visible = False
            NextButton.Visible = False
            bGray.Visible = False
            bXRay.Visible = False
            bSepia.Visible = False
            bNegative.Visible = False
            bEdge.Visible = False
            page = 0

            BackButton.Visible = False
            'Disabling he scroll of Panel1
            Panel1.AutoScroll = False
            Panel1.HorizontalScroll.Enabled = False
            Panel1.HorizontalScroll.Visible = False
            Panel1.HorizontalScroll.Maximum = 0
            Panel1.AutoScroll = False
            ' Limiting the resizing of Form1
            Me.MaximizeBox = False
            Me.MaximumSize = Me.Size
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub ImageListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ImageListBox.SelectedIndexChanged
        'This will show chosen pic on ImagePictureBox
        Try
            Dim file As String = directoryName & "/" & ImageListBox.SelectedItem.ToString
            Dim img As Image
            img = Image.FromFile(file)
            ImagePictureBox.Image = img
            globalimage = img
            ImagePictureBox.SizeMode = PictureBoxSizeMode.Zoom
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

    End Sub

    Private Sub BrowserButton_Click(sender As Object, e As EventArgs) Handles BrowserButton.Click
        'This will assist user to select directory without erring
        If (FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            DirectoryTextBox.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub bGray_Click(sender As Object, e As EventArgs) Handles bGray.Click
        Try
            Dim iX As Integer
            Dim iY As Integer

            'Dim bmpImage As Bitmap 'Source '
            'Dim picModified As Bitmap 'Source '
            ' Dim picOriginal As Bitmap 'Source '
            'Bitmap picOriginal = New Bitmap(ImagePictureBox.Image)
            Dim picOriginal As New Bitmap(globalimage)
            Dim bmpImage As New Bitmap(globalimage)
            Dim intPrevColor As Integer

            For iX = 0 To bmpImage.Width - 1

                For iY = 0 To bmpImage.Height - 1

                    intPrevColor = (CInt(bmpImage.GetPixel(iX, iY).R) +
                       bmpImage.GetPixel(iX, iY).G +
                       bmpImage.GetPixel(iX, iY).B) \ 3

                    bmpImage.SetPixel(iX, iY, _
                       Color.FromArgb(intPrevColor, intPrevColor, _
                       intPrevColor))

                Next iY
                ImagePictureBox.Image = bmpImage
            Next iX
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub BackButton_Click(sender As Object, e As EventArgs) Handles BackButton.Click
        'This will quit full screen mode and reload thumbnails
        RemoveThumbnails()
        populate_thumbnails()
        BackButton.Visible = False
    End Sub

    Private Sub NextButton_Click(sender As Object, e As EventArgs) Handles NextButton.Click
        'This will load next page of Thumbnails
        page += 1
        populate_thumbnails()
        Previous.Visible = True
        BackButton.Visible = False
    End Sub

    Private Sub Previous_Click(sender As Object, e As EventArgs) Handles Previous.Click
        'This will load previous page of Thumbnails
        Try
            If (page < 1) Then
                MessageBox.Show("There is no preious page", "Error")
                Return
            End If
            page -= 1
            populate_thumbnails()
            If (page = 0) Then
                Previous.Visible = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub newPic_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'This will remove Thumbnails and enter the full screen mode for the selected picture
        Try
            RemoveThumbnails()
            ImagePictureBox.Image = sender.Image
            BackButton.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub newPic_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'This will enable the interactive hover feature when mise hovers over the picture
        Try
            'storing the original size and locatin
            oldsize = sender.size
            oldlocaion = sender.Location
            ' creating and assigning new size and location
            Dim boxsize As Size = New Size(200, 130)
            sender.size = boxsize
            Dim newlocation As Point = sender.Location
            newlocation.Y = newlocation.Y - 10
            newlocation.X = newlocation.X - 10
            sender.Location = newlocation
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub newPic_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'This will disable the hover over feature 
        Try
            sender.size = oldsize
            sender.Location = oldlocaion
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'This will update the picture every second in slide show mode 
        Try
            'End the show if number of files end
            If (cur_slideshow_images = files.Length) Then
                Timer1.Enabled = False
                Exit Sub
            End If
            'Assigning the picture
            ImagePictureBox.Image = Image.FromFile(files(cur_slideshow_images))
            cur_slideshow_images += 1

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ImagePictureBox_DragDrop(sender As Object, e As DragEventArgs) Handles ImagePictureBox.DragDrop
        Try
            Dim imagesDragDrop As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
            Dim extension As String
            For Each imagepath As String In imagesDragDrop
                extension = Path.GetExtension(imagepath)
                If (extension = ".jpg" Or extension = ".jpeg" Or extension = ".png" Or extension = ".gif" Or extension = ".ico") Then
                    ImagePictureBox.Image = Image.FromFile(imagepath)
                    ImagePictureBox.SizeMode = PictureBoxSizeMode.Zoom
                    If (DropDownList.Enabled) Then
                        DropDownList.Items.Add(imagepath)
                    End If
                Else
                    MessageBox.Show("Please Drag and Drop an image")
                End If
            Next
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub ImagePictureBox_DragEnter(sender As Object, e As DragEventArgs) Handles ImagePictureBox.DragEnter
        Try
            If e.Data.GetDataPresent(DataFormats.FileDrop) Then
                e.Effect = DragDropEffects.Copy
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub DropDownList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList.SelectedIndexChanged
        Try
            Dim file As String = DropDownList.SelectedItem.ToString
            Dim img As Image
            img = Image.FromFile(file)
            ImagePictureBox.Image = img
            ImagePictureBox.SizeMode = PictureBoxSizeMode.Zoom
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub


    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click
        Try
            If DropDownList.Items.Count = 0 Then
                MessageBox.Show("There are no images to save!")
                Exit Sub
            End If
            If (Not Directory.Exists(TextBox2.Text)) Then
                MessageBox.Show("Enter a valid Directory", "Error")
                Exit Sub
            End If
            For index As Integer = 0 To DropDownList.Items.Count - 1
                Dim path1 As String = CStr(DropDownList.Items(index))
                Dim path2 As String = TextBox2.Text & "/" & Path.GetFileName(DropDownList.Items(index))
                My.Computer.FileSystem.CopyFile(path1, path2,
                                                Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
                                                Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
            Next
            MessageBox.Show("Files Saved!")
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub BrowseButton2_Click(sender As Object, e As EventArgs) Handles BrowseButton2.Click
        If (FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            TextBox2.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub bSepia_Click(sender As Object, e As EventArgs) Handles bSepia.Click
        Try
            Dim picOriginal As New Bitmap(globalimage)
            Dim bmpImage As New Bitmap(globalimage)

            Dim cCurrColor As Color

            For iY As Integer = 0 To bmpImage.Height - 1

                For iX As Integer = 0 To bmpImage.Width - 1

                    cCurrColor = bmpImage.GetPixel(iX, iY)

                    Dim intAlpha As Integer = cCurrColor.A
                    Dim intRed As Integer = cCurrColor.R
                    Dim intGreen As Integer = cCurrColor.G
                    Dim intBlue As Integer = cCurrColor.B

                    Dim intSRed As Integer = CInt((0.393 * intRed + _
                       0.769 * intGreen + 0.189 * intBlue))
                    Dim intSGreen As Integer = CInt((0.349 * intRed + _
                       0.686 * intGreen + 0.168 * intBlue))
                    Dim intSBlue As Integer = CInt((0.272 * intRed + _
                       0.534 * intGreen + 0.131 * intBlue))

                    If intSRed > 255 Then

                        intRed = 255

                    Else

                        intRed = intSRed

                    End If

                    If intSGreen > 255 Then

                        intGreen = 255

                    Else

                        intGreen = intSGreen

                    End If

                    If intSBlue > 255 Then

                        intBlue = 255

                    Else

                        intBlue = intSBlue

                    End If

                    bmpImage.SetPixel(iX, iY, Color.FromArgb(intAlpha, _
                       intRed, intGreen, intBlue))

                Next

            Next

            ImagePictureBox.Image = bmpImage
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub bNegative_Click(sender As Object, e As EventArgs) Handles bNegative.Click
        Try
            Dim iaAttributes As New ImageAttributes

            Dim cmMatrix As New ColorMatrix

            cmMatrix.Matrix00 = -1 : cmMatrix.Matrix11 = -1 _
             : cmMatrix.Matrix22 = -1
            cmMatrix.Matrix40 = 1 : cmMatrix.Matrix41 = 1 _
             : cmMatrix.Matrix42 = 1

            iaAttributes.SetColorMatrix(cmMatrix)
            Dim picOriginal As New Bitmap(globalimage)
            Dim bmpImage As New Bitmap(globalimage)

            Dim rect As New Rectangle(0, 0, bmpImage.Width, _
               bmpImage.Height)

            Dim graph As Graphics = Graphics.FromImage(bmpImage)

            graph.DrawImage(bmpImage, rect, rect.X, rect.Y, rect.Width, _
               rect.Height, GraphicsUnit.Pixel, iaAttributes)

            ImagePictureBox.Image = bmpImage
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub bEdge_Click(sender As Object, e As EventArgs) Handles bEdge.Click
        Try
            Dim picOriginal As New Bitmap(globalimage)
            Dim tmpImage As New Bitmap(globalimage)
            Dim bmpImage As New Bitmap(globalimage)


            Dim intWidth As Integer = tmpImage.Width
            Dim intHeight As Integer = tmpImage.Height

            Dim intOldX As Integer(,) = New Integer(,) {{-1, 0, 1}, _
               {-2, 0, 2}, {-1, 0, 1}}
            Dim intOldY As Integer(,) = New Integer(,) {{1, 2, 1}, _
               {0, 0, 0}, {-1, -2, -1}}

            Dim intR As Integer(,) = New Integer(intWidth - 1, _
               intHeight - 1) {}
            Dim intG As Integer(,) = New Integer(intWidth - 1, _
               intHeight - 1) {}
            Dim intB As Integer(,) = New Integer(intWidth - 1, _
               intHeight - 1) {}

            Dim intMax As Integer = 128 * 128

            For i As Integer = 0 To intWidth - 1

                For j As Integer = 0 To intHeight - 1

                    intR(i, j) = tmpImage.GetPixel(i, j).R
                    intG(i, j) = tmpImage.GetPixel(i, j).G
                    intB(i, j) = tmpImage.GetPixel(i, j).B

                Next

            Next

            Dim intRX As Integer = 0
            Dim intRY As Integer = 0
            Dim intGX As Integer = 0
            Dim intGY As Integer = 0
            Dim intBX As Integer = 0
            Dim intBY As Integer = 0

            Dim intRTot As Integer
            Dim intGTot As Integer
            Dim intBTot As Integer

            For i As Integer = 1 To tmpImage.Width - 1 - 1

                For j As Integer = 1 To tmpImage.Height - 1 - 1

                    intRX = 0
                    intRY = 0
                    intGX = 0
                    intGY = 0
                    intBX = 0
                    intBY = 0

                    intRTot = 0
                    intGTot = 0
                    intBTot = 0

                    For width As Integer = -1 To 2 - 1

                        For height As Integer = -1 To 2 - 1

                            intRTot = intR(i + height, j + width)
                            intRX += intOldX(width + 1, height + 1) * intRTot
                            intRY += intOldY(width + 1, height + 1) * intRTot

                            intGTot = intG(i + height, j + width)
                            intGX += intOldX(width + 1, height + 1) * intGTot
                            intGY += intOldY(width + 1, height + 1) * intGTot

                            intBTot = intB(i + height, j + width)
                            intBX += intOldX(width + 1, height + 1) * intBTot
                            intBY += intOldY(width + 1, height + 1) * intBTot

                        Next

                    Next

                    If intRX * intRX + intRY * intRY > intMax OrElse
                       intGX * intGX + intGY * intGY > intMax OrElse
                       intBX * intBX + intBY * intBY > intMax Then

                        bmpImage.SetPixel(i, j, Color.Black)

                    Else

                        bmpImage.SetPixel(i, j, Color.Transparent)

                    End If

                Next

            Next

            ImagePictureBox.Image = bmpImage
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub bXRay_Click(sender As Object, e As EventArgs) Handles bXRay.Click
        Try
            Dim iX As Integer
            Dim iY As Integer


            Dim picOriginal As New Bitmap(globalimage)
            Dim bmpImage As New Bitmap(globalimage)

            Dim intPrevColor As Integer

            For iX = 0 To bmpImage.Width - 1

                For iY = 0 To bmpImage.Height - 1

                    intPrevColor = (CInt(bmpImage.GetPixel(iX, iY).R) +
                       bmpImage.GetPixel(iX, iY).G +
                       bmpImage.GetPixel(iX, iY).B) \ 3

                    bmpImage.SetPixel(iX, iY, _
                       Color.FromArgb(intPrevColor, intPrevColor, _
                       intPrevColor))

                Next iY

            Next iX

            Dim iaAttributes As New ImageAttributes

            Dim cmMatrix As New ColorMatrix

            cmMatrix.Matrix00 = -1 : cmMatrix.Matrix11 = -1 _
             : cmMatrix.Matrix22 = -1
            cmMatrix.Matrix40 = 1 : cmMatrix.Matrix41 = 1 _
             : cmMatrix.Matrix42 = 1

            iaAttributes.SetColorMatrix(cmMatrix)

            Dim rect As New Rectangle(0, 0, bmpImage.Width, _
               bmpImage.Height)

            Dim graph As Graphics = Graphics.FromImage(bmpImage)

            graph.DrawImage(bmpImage, rect, rect.X, rect.Y, rect.Width, _
               rect.Height, GraphicsUnit.Pixel, iaAttributes)

            ImagePictureBox.Image = bmpImage
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class



