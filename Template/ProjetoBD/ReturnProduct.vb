Public Class ReturnProduct
    'Cient's NIF TextBox
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

    'Worker's Code TextBox
    Private Sub TextBox4_KeyPress(sender As Object, e As EventArgs) Handles TextBox4.KeyPress
        NumberOnly(e)
    End Sub

    'Product's Code TextBox
    Private Sub TextBox6_KeyPress(sender As Object, e As EventArgs) Handles TextBox6.KeyPress
        NumberOnly(e)
    End Sub

    'Nº Units TextBox
    Private Sub TextBox5_KeyPress(sender As Object, e As EventArgs) Handles TextBox5.KeyPress
        NumberOnly(e)
    End Sub

    ' Cancel Button
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
    End Sub

    'Confirm Button
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text.Length <> 9 Then
            MsgBox("Client's NIF Must Have 9 Numbers!", MsgBoxStyle.Information, "ERROR")
        End If
        If TextBox4.Text.Length <> 6 Then
            MsgBox("Worker's Code Must Have 6 Numbers!", MsgBoxStyle.Information, "ERROR")
        End If
        If TextBox6.Text.Length <> 6 Then
            MsgBox("Product's Code Must Have 6 Numbers!", MsgBoxStyle.Information, "ERROR")
        End If
    End Sub
End Class