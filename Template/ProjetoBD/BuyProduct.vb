Imports System.Data.SqlClient
Imports System.Security.Cryptography

Public Class BuyProduct
    Dim CMD As SqlCommand
    Dim CN As SqlConnection = New SqlConnection("Data Source = localhost;" &
                                                "Initial Catalog = LojaDesporto; Integrated Security = true;")

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        NIFTextBox.Text = ""
        ClientsNameTextBox.Text = ""
        WorkersNameTextBox.Text = ""
        CodeTextBox.Text = ""
        UnitsTextBox.Text = ""
    End Sub

    'Client's NIF TextBox (KeyPressed)
    Private Sub TextBox1_KeyPress(sender As Object, e As EventArgs) Handles NIFTextBox.KeyPress
        NumberOnly(e)
    End Sub
    Private Sub NumberOnly(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Then
        Else
            e.Handled = True
            MsgBox("Only numeric characteres are allowed!", MsgBoxStyle.Information, "ERROR")
        End If
    End Sub

    'Worker's Code TextBox (KeyPressed)
    Private Sub TextBox4_KeyPress(sender As Object, e As EventArgs) Handles CodeTextBox.KeyPress
        NumberOnly(e)
    End Sub

    'Nº Units TextBox (KeyPressed)
    Private Sub TextBox5_KeyPress(sender As Object, e As EventArgs) Handles UnitsTextBox.KeyPress
        NumberOnly(e)
    End Sub

    'Confirm Button
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If NIFTextBox.Text.Length <> 9 Then
            MsgBox("Client's NIF must have 9 numbers!", MsgBoxStyle.Information, "ERROR")
        ElseIf CodeTextBox.Text.Length <> 6 Then
            MsgBox("Worker's code must have 6 numbers!", MsgBoxStyle.Information, "ERROR")
        ElseIf UnitsTextBox.Text = "" Then
            MsgBox("Nº units is needed!", MsgBoxStyle.Information, "ERROR")
        Else
            Dim nif As Integer = NIFTextBox.Text
            Dim code As Integer = CodeTextBox.Text
            Dim units As Integer = UnitsTextBox.Text
            Stores.BuyProduct(nif, code, units)
            Me.Close()
        End If
    End Sub

    'Client's NIF TextBox (TextChanged)
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles NIFTextBox.TextChanged
        If (NIFTextBox.Text.Length = 9) Then
            getClient()
        Else
            ClientsNameTextBox.Text = ""
        End If
    End Sub

    Private Sub getClient()
        Dim nif As Integer = NIFTextBox.Text
        CMD = New SqlCommand()
        CMD.Connection = CN
        CMD.CommandText = "SELECT Cliente.Nome FROM Projeto.Cliente WHERE Cliente.NIF = @NIF"
        CMD.Parameters.Add("@NIF", SqlDbType.Int)
        CMD.Parameters("@NIF").Value = nif
        CN.Open()

        Dim clientName As Object = CMD.ExecuteScalar()

        If clientName Is Nothing Then
            MsgBox("The client's NIF inserted does not exist!", MsgBoxStyle.Information, "ERROR")
        Else
            ClientsNameTextBox.Text = clientName.ToString
        End If
        CN.Close()
    End Sub

    'Worker's code TextBox (TextChanged)
    Private Sub CodeTextBox_TextChanged(sender As Object, e As EventArgs) Handles CodeTextBox.TextChanged
        If (CodeTextBox.Text.Length = 6) Then
            getWorker()
        Else
            WorkersNameTextBox.Text = ""
        End If
    End Sub

    Private Sub getWorker()
        Dim index As Integer = Stores.StoresDataGridView.CurrentRow.Index
        Dim selectedRow As DataGridViewRow = Stores.StoresDataGridView.Rows(index)
        Dim numStore As Integer = selectedRow.Cells(0).Value
        Dim code As Integer = CodeTextBox.Text

        CMD = New SqlCommand()
        CMD.Connection = CN
        CMD.CommandText = "SELECT Funcionario.Nome FROM Projeto.Funcionario WHERE Funcionario.NumFunc = @Code
                          AND Funcionario.NumLoja = @Store"
        CMD.Parameters.Add("@Code", SqlDbType.Int)
        CMD.Parameters.Add("@Store", SqlDbType.Int)
        CMD.Parameters("@Code").Value = code
        CMD.Parameters("@Store").Value = numStore
        CN.Open()

        Dim workersName As Object = CMD.ExecuteScalar()

        If workersName Is Nothing Then
            MsgBox("The worker's code inserted does not exist or this worker does not work in the " +
                   "selected store!", MsgBoxStyle.Information, "ERROR")
        Else
            WorkersNameTextBox.Text = workersName.ToString
        End If
        CN.Close()
    End Sub
End Class