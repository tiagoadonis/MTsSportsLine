Public Class Stores
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Clients As New Clients
        Dim bounds = Me.Bounds()
        AddHandler Clients.Load, Sub() Clients.Bounds = bounds
        Clients.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim Workers As New Workers
        Dim bounds = Me.Bounds()
        AddHandler Workers.Load, Sub() Workers.Bounds = bounds
        Workers.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim Deliviries As New Deliveries
        Dim bounds = Me.Bounds()
        AddHandler Deliveries.Load, Sub() Deliveries.Bounds = bounds
        Deliveries.Show()
        Me.Hide()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim addStore As New AddStore
        addStore.ShowDialog()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim addProduct As New AddProduct
        addProduct.ShowDialog()
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        Dim buyProduct As New BuyProduct
        buyProduct.ShowDialog()
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        Dim returnProduct As New ReturnProduct
        returnProduct.ShowDialog()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim addProduct As New AddProduct
        addProduct.ShowDialog()
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Dim addWarehouse As New AddWarehouse
        addWarehouse.ShowDialog()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim removeProduct As New RemoveProduct
        removeProduct.ShowDialog()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim removeProduct As New RemoveProduct
        removeProduct.ShowDialog()
    End Sub
End Class