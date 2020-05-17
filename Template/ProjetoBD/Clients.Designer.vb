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
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ClientsDataGridView = New System.Windows.Forms.DataGridView()
        Me.PurchasedProductsDataGridView = New System.Windows.Forms.DataGridView()
        Me.ReturnedProductsDataGridView = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ClientsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PurchasedProductsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReturnedProductsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 299)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(175, 25)
        Me.Label1.TabIndex = 77
        Me.Label1.Text = "Insert New Cliente"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(19, 257)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(162, 23)
        Me.Button5.TabIndex = 85
        Me.Button5.Text = "Remove"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(203, 257)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(162, 23)
        Me.Button6.TabIndex = 86
        Me.Button6.Text = "Edit"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button7)
        Me.GroupBox1.Controls.Add(Me.TextBox4)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TextBox3)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(19, 331)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(346, 160)
        Me.GroupBox1.TabIndex = 87
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Client"
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(208, 120)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(126, 23)
        Me.Button7.TabIndex = 88
        Me.Button7.Text = "Insert"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(11, 123)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(100, 20)
        Me.TextBox4.TabIndex = 89
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 107)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 13)
        Me.Label6.TabIndex = 88
        Me.Label6.Text = "Phone Number"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(11, 79)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(323, 20)
        Me.TextBox3.TabIndex = 89
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 88
        Me.Label5.Text = "Address"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(107, 36)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(227, 20)
        Me.TextBox2.TabIndex = 91
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(104, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 90
        Me.Label4.Text = "Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 13)
        Me.Label3.TabIndex = 88
        Me.Label3.Text = "NIF"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(11, 36)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(86, 20)
        Me.TextBox1.TabIndex = 89
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(427, 261)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(202, 30)
        Me.Label7.TabIndex = 88
        Me.Label7.Text = "Returned Products "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(427, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(207, 30)
        Me.Label8.TabIndex = 89
        Me.Label8.Text = "Purchased Products"
        '
        'ClientsDataGridView
        '
        Me.ClientsDataGridView.AllowUserToAddRows = False
        Me.ClientsDataGridView.AllowUserToDeleteRows = False
        Me.ClientsDataGridView.AllowUserToResizeColumns = False
        Me.ClientsDataGridView.AllowUserToResizeRows = False
        Me.ClientsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ClientsDataGridView.Location = New System.Drawing.Point(19, 25)
        Me.ClientsDataGridView.MultiSelect = False
        Me.ClientsDataGridView.Name = "ClientsDataGridView"
        Me.ClientsDataGridView.ReadOnly = True
        Me.ClientsDataGridView.RowHeadersVisible = False
        Me.ClientsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ClientsDataGridView.Size = New System.Drawing.Size(346, 223)
        Me.ClientsDataGridView.TabIndex = 92
        '
        'PurchasedProductsDataGridView
        '
        Me.PurchasedProductsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PurchasedProductsDataGridView.Location = New System.Drawing.Point(432, 51)
        Me.PurchasedProductsDataGridView.Name = "PurchasedProductsDataGridView"
        Me.PurchasedProductsDataGridView.Size = New System.Drawing.Size(505, 197)
        Me.PurchasedProductsDataGridView.TabIndex = 93
        '
        'ReturnedProductsDataGridView
        '
        Me.ReturnedProductsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ReturnedProductsDataGridView.Location = New System.Drawing.Point(432, 294)
        Me.ReturnedProductsDataGridView.Name = "ReturnedProductsDataGridView"
        Me.ReturnedProductsDataGridView.Size = New System.Drawing.Size(505, 197)
        Me.ReturnedProductsDataGridView.TabIndex = 94
        '
        'Clients
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(955, 508)
        Me.Controls.Add(Me.ClientsDataGridView)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PurchasedProductsDataGridView)
        Me.Controls.Add(Me.ReturnedProductsDataGridView)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Clients"
        Me.Text = "Clients"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ClientsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PurchasedProductsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReturnedProductsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Button7 As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents ClientsDataGridView As DataGridView
    Friend WithEvents PurchasedProductsDataGridView As DataGridView
    Friend WithEvents ReturnedProductsDataGridView As DataGridView
End Class
