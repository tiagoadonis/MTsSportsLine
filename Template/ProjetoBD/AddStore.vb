Public Class AddStore
    'Cancel Button
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        LocationText.Text = ""
        NameText.Text = ""
    End Sub

    'Location TextBox
    Private Sub TextBox1_KeyPress(sender As Object, e As EventArgs) Handles LocationText.KeyPress
        LettersOnly(e)
    End Sub

    Private Sub LettersOnly(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Then
            e.Handled = True
            MsgBox("Only alphabetic characteres are allowed!", MsgBoxStyle.Information, "ERROR")
        End If
    End Sub

    'Confirm Button
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If LocationText.Text = "" Or NameText.Text = "" Then
            MsgBox("Some textbox is empty!", MsgBoxStyle.Information, "ERROR")
        End If

        'To add in Stores DataGridView
        Dim storeName As String = NameText.Text
        Dim storeLocation As String = LocationText.Text
        Stores.addStore(storeName, storeLocation)
    End Sub
End Class