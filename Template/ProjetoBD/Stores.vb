﻿Imports System.Data.SqlClient

Public Class Stores

    Dim CMD As SqlCommand
    Dim CN As SqlConnection = New SqlConnection("Data Source = localhost;" &
                                                "Initial Catalog = LojaDesporto; Integrated Security = true;")

    'Add Store Button
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim addStore As New AddStore
        addStore.StartPosition = FormStartPosition.CenterScreen
        addStore.ShowDialog()
    End Sub

    'Add Product Button
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim addProduct As New AddProduct
        addProduct.StartPosition = FormStartPosition.CenterScreen
        addProduct.ShowDialog()
    End Sub

    'Buy Product Button 
    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        Dim buyProduct As New BuyProduct
        buyProduct.StartPosition = FormStartPosition.CenterScreen
        buyProduct.ShowDialog()
    End Sub

    'Return Product Button
    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        Dim returnProduct As New ReturnProduct
        returnProduct.StartPosition = FormStartPosition.CenterScreen
        returnProduct.ShowDialog()
    End Sub

    'Add Product Button (Warehouse)
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim addProduct As New AddProduct
        addProduct.StartPosition = FormStartPosition.CenterScreen
        addProduct.ShowDialog()
    End Sub

    'Add Warehouse Button
    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Dim addWarehouse As New AddWarehouse
        addWarehouse.StartPosition = FormStartPosition.CenterScreen
        addWarehouse.ShowDialog()
    End Sub

    'Remove Product Button
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim removeProduct As New RemoveProduct
        removeProduct.StartPosition = FormStartPosition.CenterScreen
        removeProduct.ShowDialog()
    End Sub

    'Remove Product Button (Warehouse)
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim removeProduct As New RemoveProduct
        removeProduct.StartPosition = FormStartPosition.CenterScreen
        removeProduct.ShowDialog()
    End Sub

    Public Sub loadStores()
        Dim adapter As New SqlDataAdapter("SELECT NumLoja AS Number, Nome AS Name FROM Projeto.Loja", CN)
        Dim table As New DataTable()
        adapter.Fill(table)

        With StoresDataGridView
            .DataSource = table
            .Columns(0).Width = 80
            .Columns(1).Width = 196
        End With
    End Sub

    'Stores DataGridView
    Private Sub DataGridview1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles StoresDataGridView.CellClick
        Dim lastIndex As Integer = -1
        Dim index As Integer = e.RowIndex
        Dim selectedRow As DataGridViewRow = StoresDataGridView.Rows(index)
        Dim numStore As String = selectedRow.Cells(0).Value.ToString()

        If (lastIndex <> index) Then
            clearWarehousesProducts()
            TextBoxName.Text = ""
            TextBoxPrice.Text = ""
            TextBoxUnits.Text = ""
            TextBoxCode.Text = ""
            TextBoxType.Text = ""
            TextBoxName2.Text = ""
            TextBoxPrice2.Text = ""
            TextBoxUnits2.Text = ""
            TextBoxCode2.Text = ""
            TextBoxType2.Text = ""
            TextBoxTotalStorage.Text = ""
            TextBoxStorageOccupied.Text = ""
            lastIndex = index
        End If

        Dim queryProducts As String = "SELECT Artigo.Nome AS Name, Preco AS Price, QuantArtigos AS Units
                             FROM ((Projeto.Loja JOIN Projeto.Artigo_Loja ON Loja.NumLoja=Artigo_Loja.NumLoja)
                             JOIN Projeto.Artigo ON Artigo_Loja.Codigo=Artigo.Codigo)
                             WHERE Loja.NumLoja = '" + numStore + "'"

        Dim ds As New DataSet()

        CMD = New SqlCommand(queryProducts, CN)
        CN.Open()

        Dim adapter As New SqlDataAdapter(CMD)
        adapter.Fill(ds)

        With ProductsDataGridView
            .DataSource = ds.Tables(0)
            .Columns(0).Width = 180
            .Columns(1).Width = 42
            .Columns(2).Width = 37
        End With

        ProductsDataGridView.ClearSelection()

        CN.Close()

        'WAREHOUSES
        Dim queryWarehouses As String = "SELECT IDArmazem As Number, capacidade As Capacity
                                        FROM(Projeto.Loja JOIN Projeto.Armazem On Loja.NumLoja=Armazem.NumLoja)
                                        WHERE Loja.NumLoja ='" + numStore + "'"

        Dim ds2 As New DataSet()

        CMD = New SqlCommand(queryWarehouses, CN)
        CN.Open()

        Dim adapter2 As New SqlDataAdapter(CMD)
        adapter2.Fill(ds2)

        With WarehousesDataGridView
            .DataSource = ds2.Tables(0)
            .Columns(0).Width = 138
            .Columns(1).Width = 138
        End With

        WarehousesDataGridView.ClearSelection()

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If
    End Sub

    'Stores' products DataGridView
    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ProductsDataGridView.CellClick
        Dim index As Integer = e.RowIndex
        Dim selectedRow As DataGridViewRow = ProductsDataGridView.Rows(index)
        Dim productName As String = selectedRow.Cells(0).Value.ToString

        TextBoxName.Text = selectedRow.Cells(0).Value.ToString
        TextBoxPrice.Text = selectedRow.Cells(1).Value.ToString
        TextBoxUnits.Text = selectedRow.Cells(2).Value.ToString

        Dim queryCode As String = "SELECT Artigo.Codigo FROM Projeto.Artigo
                                  Where Artigo.Nome='" + productName + "'"

        CMD = New SqlCommand(queryCode, CN)
        CN.Open()
        Dim code As String = CMD.ExecuteScalar().ToString
        TextBoxCode.Text = code
        CN.Close()

        Dim queryType As String = "SELECT Artigo.Categoria FROM Projeto.Artigo
                                  Where Artigo.Nome='" + productName + "'"

        CMD = New SqlCommand(queryType, CN)
        CN.Open()
        Dim type As String = CMD.ExecuteScalar().ToString
        TextBoxType.Text = type

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If

    End Sub

    'Warehouses DataGridView
    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles WarehousesDataGridView.CellClick
        Dim lastIndex As Integer = -1
        Dim index As Integer = e.RowIndex
        Dim selectedRow As DataGridViewRow = WarehousesDataGridView.Rows(index)
        Dim warehouseID As String = selectedRow.Cells(0).Value.ToString

        If (lastIndex <> index) Then
            TextBoxName2.Text = ""
            TextBoxPrice2.Text = ""
            TextBoxUnits2.Text = ""
            TextBoxCode2.Text = ""
            TextBoxType2.Text = ""
            lastIndex = index
        End If

        Dim queryProducts As String = "SELECT Artigo.Nome AS Name, Preco AS Price, QuantArtigos AS Units
                                      FROM ((Projeto.Armazem JOIN Projeto.Artigo_Armazem ON Armazem.IDArmazem=Artigo_Armazem.IDArmazem) 
					                  JOIN Projeto.Artigo ON Artigo_Armazem.Codigo=Artigo.Codigo)
                                      WHERE Armazem.IDArmazem='" + warehouseID + "'"

        Dim ds As New DataSet()

        CMD = New SqlCommand(queryProducts, CN)
        CN.Open()

        Dim adapter As New SqlDataAdapter(CMD)
        adapter.Fill(ds)

        With WharehousesProductsDataGridView
            .DataSource = ds.Tables(0)
            .Columns(0).Width = 180
            .Columns(1).Width = 42
            .Columns(2).Width = 37
        End With

        WharehousesProductsDataGridView.ClearSelection()

        CN.Close()

        Dim queryStorageOccupied As String = "Select Sum(Artigo_Armazem.QuantArtigos) AS Storage_Occupied
                                             From Projeto.Artigo_Armazem
                                             Where Artigo_Armazem.IDArmazem = '" + warehouseID + "'"

        CMD = New SqlCommand(queryStorageOccupied, CN)
        CN.Open()
        Dim storageOccupied As String = CMD.ExecuteScalar().ToString

        TextBoxTotalStorage.Text = selectedRow.Cells(1).Value.ToString
        TextBoxStorageOccupied.Text = storageOccupied

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If
    End Sub

    'Warehouses' Products DataGridView
    Private Sub DataGridView4_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles WharehousesProductsDataGridView.CellClick
        Dim index As Integer = e.RowIndex
        Dim selectedRow As DataGridViewRow = WharehousesProductsDataGridView.Rows(index)
        Dim productName As String = selectedRow.Cells(0).Value.ToString

        TextBoxName2.Text = selectedRow.Cells(0).Value.ToString
        TextBoxPrice2.Text = selectedRow.Cells(1).Value.ToString
        TextBoxUnits2.Text = selectedRow.Cells(2).Value.ToString

        Dim queryCode As String = "SELECT Artigo.Codigo FROM Projeto.Artigo
                                  Where Artigo.Nome='" + productName + "'"

        CMD = New SqlCommand(queryCode, CN)
        CN.Open()
        Dim code As String = CMD.ExecuteScalar().ToString
        TextBoxCode2.Text = code
        CN.Close()

        Dim queryType As String = "SELECT Artigo.Categoria FROM Projeto.Artigo
                                  Where Artigo.Nome='" + productName + "'"

        CMD = New SqlCommand(queryType, CN)
        CN.Open()
        Dim type As String = CMD.ExecuteScalar().ToString
        TextBoxType2.Text = type

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If
    End Sub

    'To clear Warehouses' DataGridView when a new one Store is selected 
    Private Sub clearWarehousesProducts()
        WharehousesProductsDataGridView.DataSource = Nothing
    End Sub

    Private Sub Stores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        StoresDataGridView.ClearSelection()
    End Sub
End Class