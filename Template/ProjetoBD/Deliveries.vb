Imports System.Data.SqlClient
Imports System.Security.Cryptography

Public Class Deliveries
    Dim Check As DateTime
    Dim Check2 As DateTime

    Dim CMD As SqlCommand
    Dim CN As SqlConnection = New SqlConnection("Data Source = localhost;" &
                                                "Initial Catalog = LojaDesporto; Integrated Security = true;")

    Public Sub loadDeliveries()
        Dim adapter As New SqlDataAdapter("SELECT Transporte.IDTransporte AS ID, Data AS Date, Destino AS Destination FROM Projeto.Transporte", CN)
        Dim table As New DataTable()
        adapter.Fill(table)

        With DeliveriesDataGridView
            .DataSource = table
            .Columns(0).Width = 90
            .Columns(1).Width = 100
            .Columns(2).Width = 220
        End With
    End Sub

    'Deliveries DataGridView
    Private Sub DataGridview1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DeliveriesDataGridView.CellClick
        Dim index As Integer = e.RowIndex
        Dim selectedRow As DataGridViewRow = DeliveriesDataGridView.Rows(index)
        Dim ID As String = selectedRow.Cells(0).Value.ToString

        Button2.Enabled = True
        Button3.Enabled = True
        TextBoxID.Text = selectedRow.Cells(0).Value.ToString
        TextBoxDate.Text = selectedRow.Cells(1).Value.ToString
        TextBoxDest.Text = selectedRow.Cells(2).Value.ToString

        CMD = New SqlCommand()
        CMD.Connection = CN
        CMD.CommandText = "SELECT Artigo_Transporte.Codigo FROM Projeto.Artigo_Transporte Where Artigo_Transporte.IDTransporte = @id"
        CMD.Parameters.Add("@id", SqlDbType.VarChar, 40)
        CMD.Parameters("@id").Value = ID
        CN.Open()

        Dim code As String = CMD.ExecuteScalar().ToString
        TextBoxCode.Text = code
        CN.Close()

        CMD = New SqlCommand()
        CMD.Connection = CN
        CMD.CommandText = "SELECT Artigo_Transporte.QuantArtigos FROM Projeto.Artigo_Transporte Where Artigo_Transporte.IDTransporte = @id"
        CMD.Parameters.Add("@id", SqlDbType.VarChar, 40)
        CMD.Parameters("@id").Value = ID
        CN.Open()

        Dim type As String = CMD.ExecuteScalar().ToString
        TextBoxAmount.Text = type

        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If

    End Sub

    'Edit Button
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBoxDate.Enabled = True
        TextBoxAmount.Enabled = True
        TextBoxCode.Enabled = True
        TextBoxDest.Enabled = True
        Button1.Enabled = True
        Button3.Enabled = False
    End Sub

    'ProductCode TextBox
    Private Sub TextBoxCode_KeyPress(sender As Object, e As EventArgs) Handles TextBoxCode.KeyPress
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
    Private Sub TextBoxDate_KeyPress(sender As Object, e As EventArgs) Handles TextBoxDate.KeyPress
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
    Private Sub TextBoxAmount_KeyPress(sender As Object, e As EventArgs) Handles TextBoxAmount.KeyPress
        NumberOnly(e)
    End Sub

    'Destination TextBox
    Private Sub TextBoxDest_KeyPress(sender As Object, e As EventArgs) Handles TextBoxDest.KeyPress
        LettersOnly(e)
    End Sub
    Private Sub LettersOnly(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (Asc(e.KeyChar) >= 65 And Asc(e.KeyChar) <= 90) Or (Asc(e.KeyChar) >= 97 And Asc(e.KeyChar) <= 122) Or Asc(e.KeyChar) = 8 Then
        Else
            e.Handled = True
            MsgBox("Only alphabetic characteres are allowed!", MsgBoxStyle.Information, "ERROR")
        End If
    End Sub

    'Save Button
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBoxCode.Text.Length <> 6 Then
            MsgBox("Product Code must have 6 numbers!", MsgBoxStyle.Information, "ERROR")
        End If
        If TextBoxCode.Text = "" Or TextBoxDate.Text = "" Or TextBoxDest.Text = "" Or TextBoxAmount.Text = "" Then
            MsgBox("Some textboxes are empty!", MsgBoxStyle.Information, "ERROR")
        End If
        If TextBoxDate.Text(2) <> "/" Or TextBoxDate.Text(5) <> "/" Then
            MsgBox("Date must be in format DD/MM/YYY!", MsgBoxStyle.Information, "ERROR")
        End If
        Check = Convert.ToDateTime(TextBoxDate.Text)
        If Check <= DateTime.Now Then
            MsgBox("Date must be after today!", MsgBoxStyle.Information, "ERROR")
        End If
        If Check > DateTime.Now And TextBoxDate.Text(2) = "/" And TextBoxDate.Text(5) = "/" And TextBoxCode.Text.Length = 6 And TextBoxCode.Text <> "" And TextBoxDate.Text <> "" And TextBoxDest.Text <> "" And TextBoxAmount.Text <> "" Then
            TextBoxDate.Enabled = False
            TextBoxAmount.Enabled = False
            TextBoxCode.Enabled = False
            TextBoxDest.Enabled = False
            Button1.Enabled = False
            Button3.Enabled = True
            'INSERIR NA BASE DE DADOS OS CAMPOS DAS TEXTBOXES
        End If
    End Sub

    'ProductCode2 TextBox
    Private Sub TextBoxCode2_KeyPress(sender As Object, e As EventArgs) Handles TextBoxCode2.KeyPress
        NumberOnly(e)
    End Sub

    'Date2 TextBox
    Private Sub TextBoxDate2_KeyPress(sender As Object, e As EventArgs) Handles TextBoxDate2.KeyPress
        CheckDate(e)
    End Sub

    'Amount2 TextBox
    Private Sub TextBoxAmount2_KeyPress(sender As Object, e As EventArgs) Handles TextBoxAmount2.KeyPress
        NumberOnly(e)
    End Sub

    'Destination2 TextBox
    Private Sub TextBoxDest2_KeyPress(sender As Object, e As EventArgs) Handles TextBoxDest2.KeyPress
        LettersOnly(e)
    End Sub

    'ID2 TextBox
    Private Sub TextBoxID2_KeyPress(sender As Object, e As EventArgs) Handles TextBoxID2.KeyPress
        NumberOnly(e)
    End Sub

    'Add Button
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBoxCode2.Text.Length <> 6 Then
            MsgBox("Product Code must have 6 numbers!", MsgBoxStyle.Information, "ERROR")
        End If
        If TextBoxID2.Text.Length <> 6 Then
            MsgBox("Transport ID must have 6 numbers!", MsgBoxStyle.Information, "ERROR")
        End If
        If TextBoxCode2.Text = "" Or TextBoxDate2.Text = "" Or TextBoxDest2.Text = "" Or TextBoxAmount2.Text = "" Or TextBoxID2.Text = "" Then
            MsgBox("Some textboxes are empty!", MsgBoxStyle.Information, "ERROR")
        End If
        If TextBoxDate2.Text(2) <> "/" Or TextBoxDate2.Text(5) <> "/" Then
            MsgBox("Date must be in format DD/MM/YYY!", MsgBoxStyle.Information, "ERROR")
        End If
        Check2 = Convert.ToDateTime(TextBoxDate2.Text)
        If Check2 <= DateTime.Now Then
            MsgBox("Date must be after today!", MsgBoxStyle.Information, "ERROR")
        End If
        If Check2 > DateTime.Now And TextBoxDate2.Text(2) = "/" And TextBoxDate2.Text(5) = "/" And TextBoxCode2.Text.Length = 6 And TextBoxID2.Text.Length = 6 And TextBoxCode2.Text <> "" And TextBoxDate2.Text <> "" And TextBoxDest2.Text <> "" And TextBoxAmount2.Text <> "" And TextBoxID2.Text <> "" Then
            'INSERIR NA BASE DE DADOS OS CAMPOS DAS TEXTBOXES
        End If
    End Sub
End Class