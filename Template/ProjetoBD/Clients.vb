Public Class Clients
    'Stores Button
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Stores As New Stores
        Dim bounds = Me.Bounds()
        AddHandler Stores.Load, Sub() Stores.Bounds = bounds
        Stores.Show()
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
        Dim Deliveries As New Deliveries
        Dim bounds = Me.Bounds()
        AddHandler Deliveries.Load, Sub() Deliveries.Bounds = bounds
        Deliveries.Show()
        Me.Hide()
    End Sub

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
        EditClient.ShowDialog()
    End Sub

    'Close Button
    Sub Client_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.Closed
        Application.Exit()
    End Sub
End Class