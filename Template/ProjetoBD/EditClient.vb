Public Class EditClient
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
    End Sub

    ' Edit button
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox4.Text.Length <> 9 Then
            MsgBox("Client's Phone Number Must Have 9 Numbers!", MsgBoxStyle.Information, "ERROR")
        End If
    End Sub

    ' Phone Number TextBox
    Private Sub TextBox4_KeyPress(sender As Object, e As EventArgs) Handles TextBox4.KeyPress
        NumberOnly(e)
    End Sub
    Private Sub NumberOnly(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Then
        Else
            e.Handled = True
            MsgBox("Only Numeric Characteres are Allowed!", MsgBoxStyle.Information, "ERROR")
        End If
    End Sub
End Class