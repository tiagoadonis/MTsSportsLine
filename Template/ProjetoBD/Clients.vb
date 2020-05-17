Imports System.Data.SqlClient

Public Class Clients
    Dim CMD As SqlCommand
    Dim CN As SqlConnection = New SqlConnection("Data Source = localhost;" &
                                                "Initial Catalog = LojaDesporto; Integrated Security = true;")

    'Client's Insert Button
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If TextBox1.Text.Length <> 9 Then
            MsgBox("Client's NIF Must Have 9 Numbers!", MsgBoxStyle.Information, "ERROR")
        End If
        If TextBox4.Text.Length <> 9 Then
            MsgBox("Client's Phone Number Must Have 9 Numbers!", MsgBoxStyle.Information, "ERROR")
        End If
    End Sub

    'Client's NIF TextBox
    Private Sub TextBox1_KeyPress(sender As Object, e As EventArgs) Handles TextBox1.KeyPress
        NumberOnly(e)
    End Sub
    Private Sub NumberOnly(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Then
        Else
            e.Handled = True
            MsgBox("Only Numeric Characteres are Allowed!", MsgBoxStyle.Information, "ERROR")
        End If
    End Sub

    'Client's Name TextBox
    Private Sub TextBox2_KeyPress(sender As Object, e As EventArgs) Handles TextBox2.KeyPress
        LettersOnly(e)
    End Sub
    Private Sub LettersOnly(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Then
            e.Handled = True
            MsgBox("Only Alphabetic Characteres are Allowed!", MsgBoxStyle.Information, "ERROR")
        End If
    End Sub

    'Client's Phone Number TextBox
    Private Sub TextBox4_KeyPress(sender As Object, e As EventArgs) Handles TextBox4.KeyPress
        NumberOnly(e)
    End Sub

    'Edit Button
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim EditClient As New EditClient
        EditClient.StartPosition = FormStartPosition.CenterScreen
        EditClient.ShowDialog()
    End Sub

    Public Sub loadClients()
        Dim adapter As New SqlDataAdapter("SELECT NIF, Nome AS Name, Morada AS Address, NumTelem AS Phone 
                                          FROM Projeto.Cliente", CN)
        Dim table As New DataTable()
        adapter.Fill(table)

        'Dá erro
        With ClientsDataGridView
            .Columns(0).Width = 80
            .Columns(1).Width = 100
            .Columns(2).Width = 100
            .Columns(3).Width = 100
            .DataSource = table
        End With
    End Sub
End Class