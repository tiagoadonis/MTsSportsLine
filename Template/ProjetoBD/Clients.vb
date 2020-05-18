﻿Imports System.Data.SqlClient

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

        With ClientsDataGridView
            .DataSource = table
            .Columns(0).Width = 65
            .Columns(1).Width = 100
            .Columns(2).Width = 119
            .Columns(3).Width = 65
        End With
        ClientsDataGridView.ClearSelection()
    End Sub

    'Purchased Products DataGridView
    Private Sub ClientsDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ClientsDataGridView.CellContentClick
        Dim index As Integer = e.RowIndex
        Dim selectedRow As DataGridViewRow = ClientsDataGridView.Rows(index)
        Dim NIF As String = selectedRow.Cells(0).Value.ToString()

        Dim queryPurchasedProducts As String = "SELECT Compra.NumCompra AS Number, Artigo.Nome AS Product_Name, 
                Artigo_Comprado.QuantArtigos AS NºUnits, Compra.Data AS Date, Compra.Montante AS Purchase_Price  
                FROM (((Projeto.Artigo_Comprado JOIN Projeto.Compra ON Artigo_Comprado.NumCompra=Compra.NumCompra) 
                JOIN Projeto.Cliente ON Compra.NIF=Cliente.NIF) JOIN Projeto.Artigo ON 
                Artigo_Comprado.Codigo=Artigo.Codigo)
                WHERE Cliente.NIF = '" + NIF + "'"

        Dim ds As New DataSet()

        CMD = New SqlCommand(queryPurchasedProducts, CN)
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
        End With
        PurchasedProductsGridView.ClearSelection()
        CN.Close()

        'Returned Products
        Dim queryReturnedProducts As String = "SELECT Devolucao.IDDevolucao AS Number, Artigo.Nome AS Product_Name, 
                Artigo_Devolvido.QuantArtigos AS NºUnits, Devolucao.Data AS Date, Devolucao.Montante AS Returned_Value
                FROM (((Projeto.Artigo_Devolvido JOIN Projeto.Devolucao ON 
                Artigo_Devolvido.IDDevolucao=Devolucao.IDDevolucao) JOIN Projeto.Artigo ON 
                Artigo.Codigo=Artigo_Devolvido.Codigo) JOIN Projeto.Cliente ON Cliente.NIF=Devolucao.NIF)
                WHERE Cliente.NIF = '" + NIF + "'"

        Dim ds2 As New DataSet()

        CMD = New SqlCommand(queryReturnedProducts, CN)
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
        End With
        ReturnedProdcutsGridView.ClearSelection()

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If
    End Sub
End Class