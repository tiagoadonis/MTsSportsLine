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
            .loadClients()
            .TopLevel = False
            Panel1.Controls.Add(Clients)
            .BringToFront()
            .Show()
            clearClientsSection()
        End With
    End Sub

    'Stores Button
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With Stores
            .TopLevel = False
            Panel1.Controls.Add(Stores)
            .BringToFront()
            .Show()
            clearStoresSection()
        End With
    End Sub

    'Workers Button
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        With Workers
            .loadStores()
            .TopLevel = False
            Panel1.Controls.Add(Workers)
            .BringToFront()
            .Show()
        End With
    End Sub

    'Deliveries Button
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        With Deliveries
            .loadDeliveries()
            .TopLevel = False
            Panel1.Controls.Add(Deliveries)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub clearStoresSection()
        With Stores
            .StoresDataGridView.ClearSelection()
            .ProductsDataGridView.DataSource = Nothing
            .WarehousesDataGridView.DataSource = Nothing
            .WharehousesProductsDataGridView.DataSource = Nothing
            .TextBoxName.Text = ""
            .TextBoxPrice.Text = ""
            .TextBoxUnits.Text = ""
            .TextBoxCode.Text = ""
            .TextBoxType.Text = ""
            .TextBoxName2.Text = ""
            .TextBoxPrice2.Text = ""
            .TextBoxUnits2.Text = ""
            .TextBoxCode2.Text = ""
            .TextBoxType2.Text = ""
            .TextBoxTotalStorage.Text = ""
            .TextBoxStorageOccupied.Text = ""
        End With
    End Sub

    Private Sub clearClientsSection()
        With Clients
            .ClientsDataGridView.ClearSelection()
            .PurchasedProductsGridView.DataSource = Nothing
            .ReturnedProdcutsGridView.DataSource = Nothing
        End With
    End Sub

End Class