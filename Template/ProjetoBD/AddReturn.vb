Public Class AddReturn
    Dim Check

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
    End Sub

    'IDReturn TextBox
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

    'Date TextBox
    Private Sub TextBox4_KeyPress(sender As Object, e As EventArgs) Handles TextBox4.KeyPress
        CheckDate(e)
    End Sub
    Private Sub CheckDate(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 47 Or Asc(e.KeyChar) = 8 Then
        Else
            e.Handled = True
            MsgBox("Only numeric characteres are allowed!", MsgBoxStyle.Information, "ERROR")
        End If
    End Sub

    'Amount TextBox
    Private Sub TextBox5_KeyPress(sender As Object, e As EventArgs) Handles TextBox5.KeyPress
        CheckPrice(e)
    End Sub
    Private Sub CheckPrice(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 46 Or Asc(e.KeyChar) = 8 Then
        Else
            e.Handled = True
            MsgBox("Only numeric characteres are allowed!", MsgBoxStyle.Information, "ERROR")
        End If
    End Sub

    'NIF TextBox
    Private Sub TextBox2_KeyPress(sender As Object, e As EventArgs) Handles TextBox2.KeyPress
        NumberOnly(e)
    End Sub

    'ProductCode TextBox
    Private Sub TextBox3_KeyPress(sender As Object, e As EventArgs) Handles TextBox3.KeyPress
        NumberOnly(e)
    End Sub

    'ProdQuant TextBox
    Private Sub TextBox6_KeyPress(sender As Object, e As EventArgs) Handles TextBox6.KeyPress
        NumberOnly(e)
    End Sub

    'Confirm Button
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text.Length <> 5 Then
            MsgBox("PurchaseNumber must have 5 numbers!", MsgBoxStyle.Information, "ERROR")
        End If
        If TextBox2.Text.Length <> 9 Then
            MsgBox("NIF must have 9 numbers!", MsgBoxStyle.Information, "ERROR")
        End If
        If TextBox3.Text.Length <> 6 Then
            MsgBox("ProductCode must have 6 numbers!", MsgBoxStyle.Information, "ERROR")
        End If
        Check = IsDate(TextBox4.Text)
        If Check = False Then
            MsgBox("Date must be in format DD/MM/YYYY!", MsgBoxStyle.Information, "ERROR")
        End If
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Then
            MsgBox("Some textboxes are empty!", MsgBoxStyle.Information, "ERROR")
        End If
    End Sub

End Class