Imports System.Data.SqlClient
Imports System.IO
Imports AxWMPLib

Public Class Dashboard
    Private ReadOnly connectionString As String = "Server=NARRA\NARRA; Database=music; Integrated Security=true"

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadMusicFiles()
    End Sub

    Private Sub LoadMusicFiles()
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT FileName FROM music"
                Using command As New SqlCommand(query, connection)
                    Using reader As SqlDataReader = command.ExecuteReader()
                        ListViewMusic.Items.Clear() ' Clear existing items
                        While reader.Read()
                            Dim fileName As String = reader("FileName").ToString()
                            Dim listViewItem As New ListViewItem(fileName)
                            ListViewMusic.Items.Add(listViewItem)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As SqlException
            MessageBox.Show("An error occurred while retrieving the music list: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Using openFileDialog As New OpenFileDialog()
            openFileDialog.Filter = "Music Files|*.mp3;*.wav;*.flac"
            If openFileDialog.ShowDialog() = DialogResult.OK Then
                music.Text = openFileDialog.FileName
            End If
        End Using
    End Sub

    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        If String.IsNullOrWhiteSpace(music.Text) OrElse Not File.Exists(music.Text) Then
            MessageBox.Show("Please select a valid file.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim fileName As String = Path.GetFileName(music.Text)
        Dim fileData As Byte()

        Try
            fileData = File.ReadAllBytes(music.Text)
        Catch ex As IOException
            MessageBox.Show("An error occurred while reading the file: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Dim query As String = "INSERT INTO music (FileName, FileData) VALUES (@FileName, @FileData)"
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@FileName", fileName)
                    command.Parameters.AddWithValue("@FileData", fileData)
                    command.ExecuteNonQuery()
                End Using
            End Using

            ' Clear the input fields
            music.Clear()

            ' Reload the music list
            LoadMusicFiles()

            ' Confirmation message
            MessageBox.Show("File uploaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As SqlException
            MessageBox.Show("An error occurred while uploading the file: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click
        If ListViewMusic.SelectedItems.Count > 0 Then
            Dim selectedFileName As String = ListViewMusic.SelectedItems(0).Text

            Try
                Using connection As New SqlConnection(connectionString)
                    connection.Open()
                    Dim query As String = "SELECT FileData FROM music WHERE FileName = @FileName"
                    Using command As New SqlCommand(query, connection)
                        command.Parameters.AddWithValue("@FileName", selectedFileName)
                        Dim fileData As Byte() = CType(command.ExecuteScalar(), Byte())

                        If fileData IsNot Nothing Then
                            Dim tempFilePath As String = Path.Combine(Path.GetTempPath(), selectedFileName)
                            File.WriteAllBytes(tempFilePath, fileData)
                            AxWindowsMediaPlayer1.URL = tempFilePath
                            AxWindowsMediaPlayer1.Ctlcontrols.play()
                        Else
                            MessageBox.Show("File data not found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            Catch ex As SqlException
                MessageBox.Show("An error occurred while retrieving the file data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Please select a file from the list to play.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


End Class
