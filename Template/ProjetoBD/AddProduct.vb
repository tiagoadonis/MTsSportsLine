Public Class AddProduct
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
    End Sub

    'Price TextBox
    Private Sub TextBox3_KeyPress(sender As Object, e As EventArgs) Handles TextBox3.KeyPress
        CheckPrice(e)
    End Sub
    Private Sub CheckPrice(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 46 Or Asc(e.KeyChar) = 8 Then
        Else
            e.Handled = True
            MsgBox("Only numeric characteres are allowed!", MsgBoxStyle.Information, "ERROR")
        End If
    End Sub

    'Code TextBox
    Private Sub TextBox1_KeyPress(sender As Object, e As EventArgs) Handles TextBox1.KeyPress
        NumberOnly(e)
    End Sub
    Private Sub NumberOnly(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Then
        Else
            e.Handled = True
            MsgBox("Only numeric characteres are allowed!", MsgBoxStyle.Information, "ERROR")
        End If
    End Sub

    'Type TextBox
    Private Sub TextBox4_KeyPress(sender As Object, e As EventArgs) Handles TextBox4.KeyPress
        LettersOnly(e)
    End Sub
    Private Sub LettersOnly(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Then
            e.Handled = True
            MsgBox("Only alphabetic characteres are allowed!", MsgBoxStyle.Information, "ERROR")
        End If
    End Sub

    'Num.Units TextBox
    Private Sub TextBox5_KeyPress(sender As Object, e As EventArgs) Handles TextBox5.KeyPress
        NumberOnly(e)
    End Sub

    'Confirm Button
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text.Length <> 6 Then
            MsgBox("Code number must have 6 numbers!", MsgBoxStyle.Information, "ERROR")
        End If
        If TextBox4.Text.Equals("Acessórios") Or TextBox4.Text.Equals("Vestuário") Or TextBox4.Text.Equals("Calçado") Then
        Else
            MsgBox("Only 'Acessórios', 'Calçado' and 'Vestuário' exists in products type!", MsgBoxStyle.Information, "ERROR")
        End If
        If TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox5.Text = "" Then
            MsgBox("Some textboxes are empty!", MsgBoxStyle.Information, "ERROR")
        End If
    End Sub

End Class