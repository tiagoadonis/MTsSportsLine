<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Clients
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.PhoneTextBox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.AddressTextBox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.NameTextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.NIFTextBox = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ClientsDataGridView = New System.Windows.Forms.DataGridView()
        Me.PurchasedProductsGridView = New System.Windows.Forms.DataGridView()
        Me.ReturnedProdcutsGridView = New System.Windows.Forms.DataGridView()
        Me.TextBoxSearch = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ClientsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PurchasedProductsGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReturnedProdcutsGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 370)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(226, 32)
        Me.Label1.TabIndex = 77
        Me.Label1.Text = "Insert New Cliente"
        '
        'Button5
        '
        Me.Button5.Enabled = False
        Me.Button5.Location = New System.Drawing.Point(25, 331)
        Me.Button5.Margin = New System.Windows.Forms.Padding(4)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(216, 28)
        Me.Button5.TabIndex = 85
        Me.Button5.Text = "Remove"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Enabled = False
        Me.Button6.Location = New System.Drawing.Point(301, 331)
        Me.Button6.Margin = New System.Windows.Forms.Padding(4)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(216, 28)
        Me.Button6.TabIndex = 86
        Me.Button6.Text = "Edit"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button7)
        Me.GroupBox1.Controls.Add(Me.PhoneTextBox)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.AddressTextBox)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.NameTextBox)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.NIFTextBox)
        Me.GroupBox1.Location = New System.Drawing.Point(25, 407)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(492, 197)
        Me.GroupBox1.TabIndex = 87
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Client"
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(308, 149)
        Me.Button7.Margin = New System.Windows.Forms.Padding(4)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(168, 28)
        Me.Button7.TabIndex = 88
        Me.Button7.Text = "Insert"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'PhoneTextBox
        '
        Me.PhoneTextBox.Location = New System.Drawing.Point(15, 151)
        Me.PhoneTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.PhoneTextBox.Name = "PhoneTextBox"
        Me.PhoneTextBox.Size = New System.Drawing.Size(169, 22)
        Me.PhoneTextBox.TabIndex = 89
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 132)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 17)
        Me.Label6.TabIndex = 88
        Me.Label6.Text = "Phone Number"
        '
        'AddressTextBox
        '
        Me.AddressTextBox.Location = New System.Drawing.Point(15, 97)
        Me.AddressTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.AddressTextBox.Name = "AddressTextBox"
        Me.AddressTextBox.Size = New System.Drawing.Size(461, 22)
        Me.AddressTextBox.TabIndex = 89
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 78)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 17)
        Me.Label5.TabIndex = 88
        Me.Label5.Text = "Address"
        '
        'NameTextBox
        '
        Me.NameTextBox.Location = New System.Drawing.Point(143, 44)
        Me.NameTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(332, 22)
        Me.NameTextBox.TabIndex = 91
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(139, 23)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 17)
        Me.Label4.TabIndex = 90
        Me.Label4.Text = "Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 25)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 17)
        Me.Label3.TabIndex = 88
        Me.Label3.Text = "NIF"
        '
        'NIFTextBox
        '
        Me.NIFTextBox.Location = New System.Drawing.Point(15, 44)
        Me.NIFTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.NIFTextBox.Name = "NIFTextBox"
        Me.NIFTextBox.Size = New System.Drawing.Size(113, 22)
        Me.NIFTextBox.TabIndex = 89
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(569, 321)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(263, 37)
        Me.Label7.TabIndex = 88
        Me.Label7.Text = "Returned Products "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(569, 26)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(270, 37)
        Me.Label8.TabIndex = 89
        Me.Label8.Text = "Purchased Products"
        '
        'ClientsDataGridView
        '
        Me.ClientsDataGridView.AllowUserToAddRows = False
        Me.ClientsDataGridView.AllowUserToResizeColumns = False
        Me.ClientsDataGridView.AllowUserToResizeRows = False
        Me.ClientsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ClientsDataGridView.Location = New System.Drawing.Point(25, 49)
        Me.ClientsDataGridView.Margin = New System.Windows.Forms.Padding(4)
        Me.ClientsDataGridView.MultiSelect = False
        Me.ClientsDataGridView.Name = "ClientsDataGridView"
        Me.ClientsDataGridView.ReadOnly = True
        Me.ClientsDataGridView.RowHeadersVisible = False
        Me.ClientsDataGridView.RowHeadersWidth = 51
        Me.ClientsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ClientsDataGridView.Size = New System.Drawing.Size(492, 274)
        Me.ClientsDataGridView.TabIndex = 121
        '
        'PurchasedProductsGridView
        '
        Me.PurchasedProductsGridView.AllowUserToAddRows = False
        Me.PurchasedProductsGridView.AllowUserToResizeColumns = False
        Me.PurchasedProductsGridView.AllowUserToResizeRows = False
        Me.PurchasedProductsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PurchasedProductsGridView.Enabled = False
        Me.PurchasedProductsGridView.Location = New System.Drawing.Point(576, 63)
        Me.PurchasedProductsGridView.Margin = New System.Windows.Forms.Padding(4)
        Me.PurchasedProductsGridView.MultiSelect = False
        Me.PurchasedProductsGridView.Name = "PurchasedProductsGridView"
        Me.PurchasedProductsGridView.ReadOnly = True
        Me.PurchasedProductsGridView.RowHeadersVisible = False
        Me.PurchasedProductsGridView.RowHeadersWidth = 51
        Me.PurchasedProductsGridView.Size = New System.Drawing.Size(673, 242)
        Me.PurchasedProductsGridView.TabIndex = 122
        '
        'ReturnedProdcutsGridView
        '
        Me.ReturnedProdcutsGridView.AllowUserToAddRows = False
        Me.ReturnedProdcutsGridView.AllowUserToResizeColumns = False
        Me.ReturnedProdcutsGridView.AllowUserToResizeRows = False
        Me.ReturnedProdcutsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ReturnedProdcutsGridView.Enabled = False
        Me.ReturnedProdcutsGridView.Location = New System.Drawing.Point(576, 362)
        Me.ReturnedProdcutsGridView.Margin = New System.Windows.Forms.Padding(4)
        Me.ReturnedProdcutsGridView.MultiSelect = False
        Me.ReturnedProdcutsGridView.Name = "ReturnedProdcutsGridView"
        Me.ReturnedProdcutsGridView.ReadOnly = True
        Me.ReturnedProdcutsGridView.RowHeadersVisible = False
        Me.ReturnedProdcutsGridView.RowHeadersWidth = 51
        Me.ReturnedProdcutsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ReturnedProdcutsGridView.Size = New System.Drawing.Size(673, 242)
        Me.ReturnedProdcutsGridView.TabIndex = 123
        '
        'TextBoxSearch
        '
        Me.TextBoxSearch.Location = New System.Drawing.Point(267, 18)
        Me.TextBoxSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxSearch.Name = "TextBoxSearch"
        Me.TextBoxSearch.Size = New System.Drawing.Size(250, 22)
        Me.TextBoxSearch.TabIndex = 125
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(276, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(197, 17)
        Me.Label2.TabIndex = 126
        Me.Label2.Text = "Search clients by name or NIF"
        '
        'Clients
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1273, 625)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBoxSearch)
        Me.Controls.Add(Me.ReturnedProdcutsGridView)
        Me.Controls.Add(Me.PurchasedProductsGridView)
        Me.Controls.Add(Me.ClientsDataGridView)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Clients"
        Me.Text = "Clients"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ClientsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PurchasedProductsGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReturnedProdcutsGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents NIFTextBox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents NameTextBox As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents AddressTextBox As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents PhoneTextBox As TextBox
    Friend WithEvents Button7 As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents ClientsDataGridView As DataGridView
    Friend WithEvents PurchasedProductsGridView As DataGridView
    Friend WithEvents ReturnedProdcutsGridView As DataGridView
    Friend WithEvents TextBoxSearch As TextBox
    Friend WithEvents Label2 As Label
End Class
