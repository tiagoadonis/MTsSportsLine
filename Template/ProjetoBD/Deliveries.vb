Imports System.Data.SqlClient
Imports System.Security.Cryptography

Public Class Deliveries

    Dim CMD As SqlCommand
    Dim CN As SqlConnection = New SqlConnection("Data Source = localhost;" &
                                                "Initial Catalog = LojaDesporto; Integrated Security = true;")

    Public Sub loadDeliveries()
        Dim adapter As New SqlDataAdapter("SELECT Transporte.IDTransporte AS ID, Data AS Date, Destino AS Dest FROM Projeto.Transporte", CN)
        Dim table As New DataTable()
        adapter.Fill(table)

        With DeliveriesDataGridView
            .DataSource = table
            .Columns(0).Width = 69
            .Columns(1).Width = 83
            .Columns(2).Width = 200
        End With
    End Sub

End Class