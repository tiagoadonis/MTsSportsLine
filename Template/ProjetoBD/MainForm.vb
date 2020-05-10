Imports System.Data.SqlClient

Public Class MainForm

    Dim CN As SqlConnection
    Dim CMD As SqlCommand

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Local Server
        CN = New SqlConnection("Data Source = localhost;" &
                               "Initial Catalog = LojaDesporto; Integrated Security = true;")

        'IEETA Server
        'CN = New SqlConnection("Data Source = tcp:mednat.ieeta.pt\SQLSERVER,8101;" &
        '                       "Initial Catalog = p7g9; uid = p7g9; password = M88904_T88896")

        Try
            CN.Open()
            If CN.State = ConnectionState.Open Then
                MsgBox("Successful connection to database", MsgBoxStyle.OkOnly, "Connection Test")
            End If
        Catch ex As Exception
            MsgBox("FAILED TO OPEN CONNECTION TO DATABSE", MsgBoxStyle.Critical, "ERROR")
        End Try

        CMD = New SqlCommand
        CMD.Connection = CN
        CN.Close()

        Stores.loadStores()

        Panel1.Controls.Clear()
        Stores.TopLevel = False
        Panel1.Controls.Add(Stores)
        Stores.Show()
    End Sub

    'Cients Button
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        With Clients
            .TopLevel = False
            Panel1.Controls.Add(Clients)
            .BringToFront()
            .Show()
        End With
    End Sub

    'Stores Button
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With Stores
            .TopLevel = False
            Panel1.Controls.Add(Stores)
            .BringToFront()
            .Show()
        End With
    End Sub
End Class