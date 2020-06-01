Imports System.Data.SqlClient
Imports System.Security.Cryptography

Public Class Workers
    Dim CMD As SqlCommand
    Dim CN As SqlConnection = New SqlConnection("Data Source = localhost;" &
                                                "Initial Catalog = LojaDesporto; Integrated Security = true;")

    Public Sub loadStores()
        Dim adapter As New SqlDataAdapter("SELECT NumLoja AS Number, Nome AS Name FROM Projeto.Loja", CN)
        Dim table As New DataTable()
        adapter.Fill(table)

        With StoresDataGridView
            .DataSource = table
            .Columns(0).Width = 100
            .Columns(1).Width = 273
        End With
    End Sub

    Public Sub FilterData(valueToSearch As String)
        Dim numStore As String = StoresDataGridView.CurrentRow.Cells(0).Value.ToString
        Dim search As String = TextBoxSearch.Text
        Dim table2 As New DataTable()

        CMD = New SqlCommand()
        CMD.Connection = CN
        CMD.CommandText = "SELECT Funcionario.NumFunc AS Num, Funcionario.Nome AS Name, Morada AS Address 
                           FROM  (Projeto.Loja JOIN Projeto.Funcionario ON Loja.NumLoja=Funcionario.NumLoja) 
                           WHERE CONCAT(Funcionario.NumFunc, Funcionario.Nome) like '%' + @search + '%' AND Loja.NumLoja like '%' + @store + '%'"
        CMD.Parameters.Add("@search", SqlDbType.VarChar, 40)
        CMD.Parameters("@search").Value = search
        CMD.Parameters.Add("@store", SqlDbType.VarChar, 3)
        CMD.Parameters("@store").Value = numStore
        CN.Open()

        Dim adapter2 As New SqlDataAdapter(CMD)
        adapter2.Fill(table2)

        With WorkersDataGridView
            .DataSource = table2
            .Columns(0).Width = 80
            .Columns(1).Width = 112
            .Columns(2).Width = 164
            .ClearSelection()
        End With
        CN.Close()

        WorkersDataGridView.DataSource = table2

    End Sub

    Private Sub TextBoxSearch_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSearch.TextChanged
        FilterData("")
    End Sub

    'Stores DataGridView
    Private Sub DataGridview1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles StoresDataGridView.CellClick
        Dim lastIndex As Integer = -1
        Dim index As Integer = e.RowIndex
        Dim selectedRow As DataGridViewRow = StoresDataGridView.Rows(index)
        Dim numStore As String = selectedRow.Cells(0).Value.ToString

        If (lastIndex <> index) Then
            WorkersDataGridView.DataSource = Nothing
            SalesDataGridView.DataSource = Nothing
            ReturnsDataGridView.DataSource = Nothing
            lastIndex = index
        End If

        Button3.Enabled = True
        TextBoxSearch.Enabled = True
        Label5.Enabled = True

        loadWorkers(numStore)
    End Sub

    'Workers DataGridView
    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles WorkersDataGridView.CellClick
        Dim index As Integer = e.RowIndex
        Dim selectedRow As DataGridViewRow = WorkersDataGridView.Rows(index)
        Dim numFunc As String = selectedRow.Cells(0).Value.ToString

        Button4.Enabled = True

        'Sales
        Dim ds As New DataSet()

        CMD = New SqlCommand()
        CMD.Connection = CN
        CMD.CommandText = "SELECT Compra.NumCompra AS Sale_Number, Compra.Data AS Date, Compra.Montante AS Amount, 
                           Compra.NIF AS NIF
                           FROM (Projeto.Funcionario JOIN Projeto.Compra ON Funcionario.NumFunc=Compra.NumFunc)
                           WHERE Funcionario.NumFunc = @num"
        CMD.Parameters.Add("@num", SqlDbType.VarChar, 6)
        CMD.Parameters("@num").Value = numFunc
        CN.Open()

        Dim adapter As New SqlDataAdapter(CMD)
        adapter.Fill(ds)

        With SalesDataGridView
            .DataSource = ds.Tables(0)
            .Columns(0).Width = 94
            .Columns(1).Width = 92
            .Columns(2).Width = 87
            .Columns(3).Width = 100
            .ClearSelection()
        End With
        CN.Close()

        'Returns
        Dim ds2 As New DataSet()

        CMD = New SqlCommand()
        CMD.Connection = CN
        CMD.CommandText = "SELECT Devolucao.IDDevolucao AS Return_Number, Devolucao.Data AS Date, 
                           Devolucao.Montante AS Amount, Devolucao.NIF AS NIF
                           FROM (Projeto.Funcionario JOIN Projeto.Devolucao ON Funcionario.NumFunc=Devolucao.NumFunc)
                           WHERE Funcionario.NumFunc = @num"
        CMD.Parameters.Add("@num", SqlDbType.VarChar, 6)
        CMD.Parameters("@num").Value = numFunc
        CN.Open()

        Dim adapter2 As New SqlDataAdapter(CMD)
        adapter2.Fill(ds2)

        With ReturnsDataGridView
            .DataSource = ds2.Tables(0)
            .Columns(0).Width = 94
            .Columns(1).Width = 92
            .Columns(2).Width = 87
            .Columns(3).Width = 100
            .ClearSelection()
        End With

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If
    End Sub

    'Add Worker Button
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim addWorker As New AddWorker
        addWorker.StartPosition = FormStartPosition.CenterScreen
        addWorker.ShowDialog()
    End Sub

    Private Sub Workers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        StoresDataGridView.ClearSelection()
        TextBoxSearch.Text = ""
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Label5.Enabled = False
        Label5.Visible = False
    End Sub

    Public Sub addWorker(ByVal num As Integer, ByVal morada As String, ByVal nome As String, ByVal phone As Integer)
        Dim index As Integer = StoresDataGridView.CurrentRow.Index
        Dim selectedRow As DataGridViewRow = StoresDataGridView.Rows(index)
        Dim numStore As Integer = selectedRow.Cells(0).Value

        CMD = New SqlCommand()
        CMD.Connection = CN
        CMD.CommandText = "EXEC Projeto.Add_Worker @num, @morada, @nome, @phone, @store"
        CMD.Parameters.Add("@num", SqlDbType.Int)
        CMD.Parameters.Add("@morada", SqlDbType.VarChar, 40)
        CMD.Parameters.Add("@nome", SqlDbType.VarChar, 20)
        CMD.Parameters.Add("@phone", SqlDbType.BigInt)
        CMD.Parameters.Add("@store", SqlDbType.Int)
        CMD.Parameters("@num").Value = num
        CMD.Parameters("@morada").Value = morada
        CMD.Parameters("@nome").Value = nome
        CMD.Parameters("@phone").Value = phone
        CMD.Parameters("@store").Value = numStore
        CN.Open()
        CMD.ExecuteScalar()
        loadWorkers(numStore)
        CN.Close()

    End Sub

    Private Sub loadWorkers(ByVal numStore As Integer)
        Dim ds As New DataSet()

        CMD = New SqlCommand
        CMD.Connection = CN
        CMD.CommandText = "SELECT Funcionario.NumFunc AS Num, Funcionario.Nome AS Name, Morada AS Address
                           FROM (Projeto.Loja JOIN Projeto.Funcionario ON Loja.NumLoja=Funcionario.NumLoja)
                           WHERE Loja.NumLoja = @store"
        CMD.Parameters.Add("@store", SqlDbType.VarChar, 1)
        CMD.Parameters("@store").Value = numStore

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If

        CN.Open()

        Dim adapter As New SqlDataAdapter(CMD)
        adapter.Fill(ds)

        With WorkersDataGridView
            .DataSource = ds.Tables(0)
            .Columns(0).Width = 80
            .Columns(1).Width = 112
            .Columns(2).Width = 164
            .ClearSelection()
        End With
        CN.Close()
    End Sub
End Class
