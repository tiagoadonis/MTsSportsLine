Imports System.Data.SqlClient

Public Class Stores

    Dim CN As SqlConnection
    Dim CMD As SqlCommand

    'Load DataBase
    Private Sub Stores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim count As Integer        'Contador não funciona para apenas mostrar o dialog no início
        count = 0

        'Local Server
        'CN = New SqlConnection("Data Source = localhost;" &
        '                       "Initial Catalog = LojaDesporto; Integrated Security = true;")

        'IEETA Server
        CN = New SqlConnection("Data Source = tcp:mednat.ieeta.pt\SQLSERVER,8101;" &
                               "Initial Catalog = p7g9; uid = p7g9; password = M88904_T88896")

        If (count = 0) Then
            Try
                CN.Open()
                If CN.State = ConnectionState.Open Then
                    MsgBox("Successful connection to database", MsgBoxStyle.OkOnly, "Connection Test")
                End If
            Catch ex As Exception
                MsgBox("FAILED TO OPEN CONNECTION TO DATABSE", MsgBoxStyle.Critical, "ERROR")
            End Try
            count += 1
        End If

        CMD = New SqlCommand
        CMD.Connection = CN
    End Sub

    'Clients Button
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Clients As New Clients
        Dim bounds = Me.Bounds()
        AddHandler Clients.Load, Sub() Clients.Bounds = bounds
        Clients.Show()
        Me.Hide()
    End Sub

    'Workers Button
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim Workers As New Workers
        Dim bounds = Me.Bounds()
        AddHandler Workers.Load, Sub() Workers.Bounds = bounds
        Workers.Show()
        Me.Hide()
    End Sub

    'Deliveries Button
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim Deliviries As New Deliveries
        Dim bounds = Me.Bounds()
        AddHandler Deliveries.Load, Sub() Deliveries.Bounds = bounds
        Deliveries.Show()
        Me.Hide()
    End Sub

    'Add Store Button
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim addStore As New AddStore
        addStore.ShowDialog()
    End Sub

    'Add Product Button
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim addProduct As New AddProduct
        addProduct.ShowDialog()
    End Sub

    'Buy Product Button 
    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        Dim buyProduct As New BuyProduct
        buyProduct.ShowDialog()
    End Sub

    'Return Product Button
    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        Dim returnProduct As New ReturnProduct
        returnProduct.ShowDialog()
    End Sub

    'Add Product Button (Warehouse)
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim addProduct As New AddProduct
        addProduct.ShowDialog()
    End Sub

    'Add Warehouse Button
    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Dim addWarehouse As New AddWarehouse
        addWarehouse.ShowDialog()
    End Sub

    'Remove Product Button
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim removeProduct As New RemoveProduct
        removeProduct.ShowDialog()
    End Sub

    'Remove Product Button (Warehouse)
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim removeProduct As New RemoveProduct
        removeProduct.ShowDialog()
    End Sub
End Class