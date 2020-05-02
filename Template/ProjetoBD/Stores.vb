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

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim addAveiro As New AddProduct
        addAveiro.ShowDialog()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim addPorto As New AddProduct
        addPorto.ShowDialog()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Dim addLisboa As New AddProduct
        addLisboa.ShowDialog()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim editAveiro As New EditProduct
        editAveiro.ShowDialog()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim editPorto As New EditProduct
        editPorto.ShowDialog()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim editLisboa As New EditProduct
        editLisboa.ShowDialog()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim removeAveiro As New RemoveProduct
        removeAveiro.ShowDialog()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim removeAveiro As New RemoveProduct
        removeAveiro.ShowDialog()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim removeAveiro As New RemoveProduct
        removeAveiro.ShowDialog()
    End Sub

    Private Sub Button15_Click_1(sender As Object, e As EventArgs) Handles Button15.Click
        Dim buyAveiro As New BuyProduct
        buyAveiro.ShowDialog()
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Dim buyPorto As New BuyProduct
        buyPorto.ShowDialog()
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        Dim buyLisboa As New BuyProduct
        buyLisboa.ShowDialog()
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Dim returnAveiro As New ReturnProduct
        returnAveiro.ShowDialog()
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        Dim returnPorto As New ReturnProduct
        returnPorto.ShowDialog()
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        Dim returnLisboa As New ReturnProduct
        returnLisboa.ShowDialog()
    End Sub

    Private Sub Button14_Click_1(sender As Object, e As EventArgs) Handles Button14.Click
        Dim aveiroWarehouse As New AveirosWarehouse
        Dim bounds = Me.Bounds()
        AddHandler aveiroWarehouse.Load, Sub() aveiroWarehouse.Bounds = bounds
        aveiroWarehouse.Show()
        Me.Hide()
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        Dim portoWarehouse As New PortosWarehouse
        Dim bounds = Me.Bounds()
        AddHandler portoWarehouse.Load, Sub() portoWarehouse.Bounds = bounds
        portoWarehouse.Show()
        Me.Hide()
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        Dim lisboaWarehouse As New LisboasWarehouse
        Me.Hide()
        lisboaWarehouse.ShowDialog()

    End Sub
End Class