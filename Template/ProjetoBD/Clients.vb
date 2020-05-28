Imports System.Data.SqlClient

Public Class Clients
    Dim CMD As SqlCommand
    Dim CN As SqlConnection = New SqlConnection("Data Source = localhost;" &
                                                "Initial Catalog = LojaDesporto; Integrated Security = true;")

    'Client's Insert Button
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If NIFTextBox.Text.Length <> 9 Then
            MsgBox("Client's NIF Must Have 9 Numbers!", MsgBoxStyle.Information, "ERROR")
        ElseIf NameTextBox.Text.Equals("") Then
            MsgBox("Please Insert Client's Name!", MsgBoxStyle.Information, "ERROR")
        ElseIf PhoneTextBox.Text.Length <> 9 Then
            MsgBox("Client's Phone Number Must Have 9 Numbers!", MsgBoxStyle.Information, "ERROR")
        Else
            Dim NIF As Integer = NIFTextBox.Text
            Dim name As String = NameTextBox.Text.ToString
            Dim address As String = AddressTextBox.Text.ToString()
            Dim phone As Integer = PhoneTextBox.Text
            addClient(NIF, name, address, phone)
            NIFTextBox.Text = ""
            NameTextBox.Text = ""
            AddressTextBox.Text = ""
            PhoneTextBox.Text = ""
        End If
    End Sub

    'Client's NIF TextBox
    Private Sub TextBox1_KeyPress(sender As Object, e As EventArgs) Handles NIFTextBox.KeyPress
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
    Private Sub TextBox2_KeyPress(sender As Object, e As EventArgs) Handles NameTextBox.KeyPress
        LettersOnly(e)
    End Sub
    Private Sub LettersOnly(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Then
            e.Handled = True
            MsgBox("Only Alphabetic Characteres are Allowed!", MsgBoxStyle.Information, "ERROR")
        End If
    End Sub

    'Client's Phone Number TextBox
    Private Sub TextBox4_KeyPress(sender As Object, e As EventArgs) Handles PhoneTextBox.KeyPress
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

        With ClientsDataGridView
            .DataSource = table
            .Columns(0).Width = 65
            .Columns(1).Width = 100
            .Columns(2).Width = 119
            .Columns(3).Width = 65
            .ClearSelection()
        End With
    End Sub

    Public Sub FilterData(valueToSearch As String)
        Dim searchQuery As String = "SELECT NIF, Nome AS Name, Morada AS Address, NumTelem AS Phone FROM Projeto.Cliente WHERE CONCAT(Nome, NIF) like '%" & TextBoxSearch.Text & "%'"
        Dim command As New SqlCommand(searchQuery, CN)
        Dim adapter2 As New SqlDataAdapter(command)
        Dim table2 As New DataTable()

        adapter2.Fill(table2)

        With ClientsDataGridView
            .DataSource = table2
            .Columns(0).Width = 70
            .Columns(1).Width = 90
            .Columns(2).Width = 136
            .Columns(3).Width = 70
        End With

        ClientsDataGridView.DataSource = table2

    End Sub

    'Purchased Products DataGridView
    Private Sub ClientsDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ClientsDataGridView.CellContentClick
        Dim index As Integer = e.RowIndex
        Dim selectedRow As DataGridViewRow = ClientsDataGridView.Rows(index)
        Dim NIF As String = selectedRow.Cells(0).Value.ToString()

        Button5.Enabled = True
        Button6.Enabled = True

        Dim ds As New DataSet()

        CMD = New SqlCommand()
        CMD.Connection = CN
        CMD.CommandText = "SELECT Compra.NumCompra AS Number, Artigo.Nome AS Product_Name, 
                Artigo_Comprado.QuantArtigos AS NºUnits, Compra.Data AS Date, Compra.Montante AS Purchase_Price  
                FROM (((Projeto.Artigo_Comprado JOIN Projeto.Compra ON Artigo_Comprado.NumCompra=Compra.NumCompra) 
                JOIN Projeto.Cliente ON Compra.NIF=Cliente.NIF) JOIN Projeto.Artigo ON 
                Artigo_Comprado.Codigo=Artigo.Codigo)
                WHERE Cliente.NIF = @NIF"
        CMD.Parameters.Add("@NIF", SqlDbType.VarChar, 9)
        CMD.Parameters("@NIF").Value = NIF
        CN.Open()

        Dim adapter As New SqlDataAdapter(CMD)
        adapter.Fill(ds)

        With PurchasedProductsGridView
            .DataSource = ds.Tables(0)
            .Columns(0).Width = 69
            .Columns(1).Width = 193
            .Columns(2).Width = 64
            .Columns(3).Width = 83
            .Columns(4).Width = 93
            .ClearSelection()
        End With
        CN.Close()

        'Returned Products
        Dim ds2 As New DataSet()

        CMD = New SqlCommand()
        CMD.Connection = CN
        CMD.CommandText = "SELECT Devolucao.IDDevolucao AS Number, Artigo.Nome AS Product_Name, 
                Artigo_Devolvido.QuantArtigos AS NºUnits, Devolucao.Data AS Date, Devolucao.Montante AS Returned_Value
                FROM (((Projeto.Artigo_Devolvido JOIN Projeto.Devolucao ON 
                Artigo_Devolvido.IDDevolucao=Devolucao.IDDevolucao) JOIN Projeto.Artigo ON 
                Artigo.Codigo=Artigo_Devolvido.Codigo) JOIN Projeto.Cliente ON Cliente.NIF=Devolucao.NIF)
                WHERE Cliente.NIF = @NIF"
        CMD.Parameters.Add("@NIF", SqlDbType.VarChar, 9)
        CMD.Parameters("@NIF").Value = NIF
        CN.Open()

        Dim adapter2 As New SqlDataAdapter(CMD)
        adapter2.Fill(ds2)

        With ReturnedProdcutsGridView
            .DataSource = ds2.Tables(0)
            .Columns(0).Width = 69
            .Columns(1).Width = 193
            .Columns(2).Width = 64
            .Columns(3).Width = 83
            .Columns(4).Width = 93
            .ClearSelection()
        End With

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If
    End Sub

    Private Sub ButtonSearch_Click(sender As Object, e As EventArgs) Handles ButtonSearch.Click
        FilterData("")
    End Sub

    Private Sub addClient(ByVal NIF As Integer, ByVal name As String, ByVal address As String, ByVal phone As Integer)
        CMD = New SqlCommand()
        CMD.Connection = CN
        CMD.CommandText = "EXEC Projeto.Add_newClient @NIF, @Address, @Name, @Phone"
        CMD.Parameters.Add("@NIF", SqlDbType.Int)
        CMD.Parameters.Add("@Address", SqlDbType.VarChar, 40)
        CMD.Parameters.Add("@Name", SqlDbType.VarChar, 20)
        CMD.Parameters.Add("@Phone", SqlDbType.Int)
        CMD.Parameters("@NIF").Value = NIF
        CMD.Parameters("@Address").Value = address
        CMD.Parameters("@Name").Value = name
        CMD.Parameters("@Phone").Value = phone
        CN.Open()
        CMD.ExecuteScalar()
        loadClients()
        CN.Close()
    End Sub

    'Remove Client Button
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim index As Integer = ClientsDataGridView.CurrentRow.Index
        Dim selectedRow As DataGridViewRow = ClientsDataGridView.Rows(index)
        Dim nif As Integer = selectedRow.Cells(0).Value

        CMD = New SqlCommand()
        CMD.Connection = CN
        CMD.CommandText = "EXEC Projeto.Remove_Client @NIF"
        CMD.Parameters.Add("@NIF", SqlDbType.Int)
        CMD.Parameters("@NIF").Value = nif
        CN.Open()
        CMD.ExecuteScalar()
        loadClients()
        CN.Close()
    End Sub
End Class