Imports System.Data.SqlClient
Imports Google.Protobuf.WellKnownTypes

Public Class Form2
    Private thisconnection As String = "Server= NARRA\NARRA; Database = music; Integrated Security = true"
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Me.Hide()
        Form1.Show()
        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim username As String = TextBox1.Text
        Dim password As String = TextBox2.Text

        ' Insert user into the database
        Using connection As New SqlConnection(thisconnection)
            connection.Open()
            Dim query As String = "INSERT INTO [user] (username, password) VALUES (@username, @password)"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@username", username)
                command.Parameters.AddWithValue("@password", password)

                command.ExecuteNonQuery()
            End Using
        End Using

        ' Clear input fields
        TextBox1.Clear()
        TextBox2.Clear()
  
        ' Confirmation message
        MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)



    End Sub
End Class