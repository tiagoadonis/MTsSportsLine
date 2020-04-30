Public Class Clients
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Stores As New Stores
        Dim bounds = Me.Bounds()
        AddHandler Stores.Load, Sub() Stores.Bounds = bounds
        Stores.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click

    End Sub

    Private Sub Clients_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class