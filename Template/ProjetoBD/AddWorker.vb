Public Class AddWorker

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
    End Sub

    'NumFunc TextBox
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

    'PhoneNumber TextBox
    Private Sub TextBox5_KeyPress(sender As Object, e As EventArgs) Handles TextBox5.KeyPress
        NumberOnly(e)
    End Sub

    'Name TextBox
    Private Sub TextBox4_KeyPress(sender As Object, e As EventArgs) Handles TextBox4.KeyPress
        LettersOnly(e)
    End Sub
    Private Sub LettersOnly(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (Asc(e.KeyChar) >= 65 And Asc(e.KeyChar) <= 90) Or (Asc(e.KeyChar) >= 97 And Asc(e.KeyChar) <= 122) Or Asc(e.KeyChar) = 8 Then
        Else
            e.Handled = True
            MsgBox("Only alphabetic characteres are allowed!", MsgBoxStyle.Information, "ERROR")
        End If
    End Sub

    'Address TextBox
    Private Sub TextBox2_KeyPress(sender As Object, e As EventArgs) Handles TextBox2.KeyPress
        LettersOnly(e)
    End Sub

    'Confirm Button
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text.Length <> 6 Then
            MsgBox("FuncNum must have 6 numbers!", MsgBoxStyle.Information, "ERROR")
        End If
        If TextBox5.Text.Length <> 9 Then
            MsgBox("Phone number must have 9 numbers!", MsgBoxStyle.Information, "ERROR")
        End If
        If TextBox2.Text = "" Or TextBox4.Text = "" Then
            MsgBox("Some textboxes are empty!", MsgBoxStyle.Information, "ERROR")
        End If
    End Sub

End Class