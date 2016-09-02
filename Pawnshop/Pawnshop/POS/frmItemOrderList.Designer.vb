<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmItemOrderList
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmItemOrderList))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pbHeader = New System.Windows.Forms.PictureBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.grpItem = New System.Windows.Forms.GroupBox()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.txtQuantity = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSearch1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnaddCart = New System.Windows.Forms.Button()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.lblPrice = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.txtItemCode = New System.Windows.Forms.TextBox()
        Me.lblItemCode = New System.Windows.Forms.Label()
        Me.grpList = New System.Windows.Forms.GroupBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblPayment = New System.Windows.Forms.Label()
        Me.txtTotalPrice = New System.Windows.Forms.TextBox()
        Me.lblTotalPrice = New System.Windows.Forms.Label()
        Me.grpCart = New System.Windows.Forms.GroupBox()
        Me.DGItemOrderList = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblItemOrderList = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.pbHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpItem.SuspendLayout()
        CType(Me.txtQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpList.SuspendLayout()
        Me.grpCart.SuspendLayout()
        CType(Me.DGItemOrderList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSlateGray
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.pbHeader)
        Me.Panel1.Controls.Add(Me.lblTitle)
        Me.Panel1.Location = New System.Drawing.Point(1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(985, 66)
        Me.Panel1.TabIndex = 5
        '
        'pbHeader
        '
        Me.pbHeader.BackColor = System.Drawing.Color.Transparent
        Me.pbHeader.Location = New System.Drawing.Point(941, 11)
        Me.pbHeader.Name = "pbHeader"
        Me.pbHeader.Size = New System.Drawing.Size(25, 39)
        Me.pbHeader.TabIndex = 14
        Me.pbHeader.TabStop = False
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe Print", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(3, 8)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(208, 42)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "Item Order List"
        '
        'grpItem
        '
        Me.grpItem.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grpItem.Controls.Add(Me.btnRemove)
        Me.grpItem.Controls.Add(Me.btnUpdate)
        Me.grpItem.Controls.Add(Me.txtQuantity)
        Me.grpItem.Controls.Add(Me.Label2)
        Me.grpItem.Controls.Add(Me.txtSearch1)
        Me.grpItem.Controls.Add(Me.Label1)
        Me.grpItem.Controls.Add(Me.btnSearch)
        Me.grpItem.Controls.Add(Me.btnaddCart)
        Me.grpItem.Controls.Add(Me.txtPrice)
        Me.grpItem.Controls.Add(Me.lblPrice)
        Me.grpItem.Controls.Add(Me.txtDescription)
        Me.grpItem.Controls.Add(Me.lblDescription)
        Me.grpItem.Controls.Add(Me.txtItemCode)
        Me.grpItem.Controls.Add(Me.lblItemCode)
        Me.grpItem.Location = New System.Drawing.Point(11, 19)
        Me.grpItem.Name = "grpItem"
        Me.grpItem.Size = New System.Drawing.Size(403, 280)
        Me.grpItem.TabIndex = 6
        Me.grpItem.TabStop = False
        Me.grpItem.Text = "Order Item"
        '
        'btnRemove
        '
        Me.btnRemove.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRemove.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemove.Image = CType(resources.GetObject("btnRemove.Image"), System.Drawing.Image)
        Me.btnRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRemove.Location = New System.Drawing.Point(297, 227)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(77, 33)
        Me.btnRemove.TabIndex = 16
        Me.btnRemove.Text = "&Remove"
        Me.btnRemove.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRemove.UseVisualStyleBackColor = False
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnUpdate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Image = CType(resources.GetObject("btnUpdate.Image"), System.Drawing.Image)
        Me.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUpdate.Location = New System.Drawing.Point(214, 227)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(77, 33)
        Me.btnUpdate.TabIndex = 15
        Me.btnUpdate.Text = "&Update"
        Me.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'txtQuantity
        '
        Me.txtQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuantity.Location = New System.Drawing.Point(124, 190)
        Me.txtQuantity.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.txtQuantity.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(251, 22)
        Me.txtQuantity.TabIndex = 14
        Me.txtQuantity.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(76, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(147, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Search Description/ItemCode"
        '
        'txtSearch1
        '
        Me.txtSearch1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch1.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.txtSearch1.Location = New System.Drawing.Point(16, 29)
        Me.txtSearch1.Name = "txtSearch1"
        Me.txtSearch1.Size = New System.Drawing.Size(260, 22)
        Me.txtSearch1.TabIndex = 0
        Me.txtSearch1.Text = "Description"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(47, 193)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Quantity"
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(286, 29)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(88, 23)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "&Search"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'btnaddCart
        '
        Me.btnaddCart.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnaddCart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnaddCart.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnaddCart.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnaddCart.Image = CType(resources.GetObject("btnaddCart.Image"), System.Drawing.Image)
        Me.btnaddCart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnaddCart.Location = New System.Drawing.Point(118, 227)
        Me.btnaddCart.Name = "btnaddCart"
        Me.btnaddCart.Size = New System.Drawing.Size(88, 33)
        Me.btnaddCart.TabIndex = 6
        Me.btnaddCart.Text = "&Add Cart"
        Me.btnaddCart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnaddCart.UseVisualStyleBackColor = False
        '
        'txtPrice
        '
        Me.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice.Location = New System.Drawing.Point(124, 159)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.ReadOnly = True
        Me.txtPrice.Size = New System.Drawing.Size(251, 22)
        Me.txtPrice.TabIndex = 4
        Me.txtPrice.Text = "Price"
        '
        'lblPrice
        '
        Me.lblPrice.AutoSize = True
        Me.lblPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrice.Location = New System.Drawing.Point(64, 162)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Size = New System.Drawing.Size(39, 16)
        Me.lblPrice.TabIndex = 8
        Me.lblPrice.Text = "Price"
        '
        'txtDescription
        '
        Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(124, 128)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ReadOnly = True
        Me.txtDescription.Size = New System.Drawing.Size(251, 22)
        Me.txtDescription.TabIndex = 3
        Me.txtDescription.Text = "Description"
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.Location = New System.Drawing.Point(30, 130)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(76, 16)
        Me.lblDescription.TabIndex = 6
        Me.lblDescription.Text = "Description"
        '
        'txtItemCode
        '
        Me.txtItemCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemCode.Location = New System.Drawing.Point(124, 98)
        Me.txtItemCode.Name = "txtItemCode"
        Me.txtItemCode.ReadOnly = True
        Me.txtItemCode.Size = New System.Drawing.Size(251, 22)
        Me.txtItemCode.TabIndex = 2
        Me.txtItemCode.Text = "ItemCode"
        '
        'lblItemCode
        '
        Me.lblItemCode.AutoSize = True
        Me.lblItemCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemCode.Location = New System.Drawing.Point(39, 100)
        Me.lblItemCode.Name = "lblItemCode"
        Me.lblItemCode.Size = New System.Drawing.Size(66, 16)
        Me.lblItemCode.TabIndex = 3
        Me.lblItemCode.Text = "ItemCode"
        '
        'grpList
        '
        Me.grpList.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grpList.Controls.Add(Me.btnClose)
        Me.grpList.Controls.Add(Me.lblPayment)
        Me.grpList.Controls.Add(Me.txtTotalPrice)
        Me.grpList.Controls.Add(Me.lblTotalPrice)
        Me.grpList.Controls.Add(Me.grpCart)
        Me.grpList.Controls.Add(Me.grpItem)
        Me.grpList.Location = New System.Drawing.Point(1, 72)
        Me.grpList.Name = "grpList"
        Me.grpList.Size = New System.Drawing.Size(976, 340)
        Me.grpList.TabIndex = 13
        Me.grpList.TabStop = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(11, 302)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(67, 33)
        Me.btnClose.TabIndex = 14
        Me.btnClose.Text = "&Close"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'lblPayment
        '
        Me.lblPayment.AutoSize = True
        Me.lblPayment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPayment.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPayment.ForeColor = System.Drawing.Color.Red
        Me.lblPayment.Location = New System.Drawing.Point(870, 306)
        Me.lblPayment.Name = "lblPayment"
        Me.lblPayment.Size = New System.Drawing.Size(80, 22)
        Me.lblPayment.TabIndex = 15
        Me.lblPayment.Text = "Payment"
        '
        'txtTotalPrice
        '
        Me.txtTotalPrice.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtTotalPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPrice.ForeColor = System.Drawing.Color.Red
        Me.txtTotalPrice.Location = New System.Drawing.Point(691, 305)
        Me.txtTotalPrice.Name = "txtTotalPrice"
        Me.txtTotalPrice.ReadOnly = True
        Me.txtTotalPrice.Size = New System.Drawing.Size(173, 26)
        Me.txtTotalPrice.TabIndex = 13
        Me.txtTotalPrice.Text = "0.00"
        '
        'lblTotalPrice
        '
        Me.lblTotalPrice.AutoSize = True
        Me.lblTotalPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPrice.Location = New System.Drawing.Point(591, 307)
        Me.lblTotalPrice.Name = "lblTotalPrice"
        Me.lblTotalPrice.Size = New System.Drawing.Size(94, 20)
        Me.lblTotalPrice.TabIndex = 14
        Me.lblTotalPrice.Text = "Total Price"
        '
        'grpCart
        '
        Me.grpCart.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grpCart.Controls.Add(Me.DGItemOrderList)
        Me.grpCart.Controls.Add(Me.lblItemOrderList)
        Me.grpCart.Location = New System.Drawing.Point(420, 19)
        Me.grpCart.Name = "grpCart"
        Me.grpCart.Size = New System.Drawing.Size(533, 280)
        Me.grpCart.TabIndex = 13
        Me.grpCart.TabStop = False
        '
        'DGItemOrderList
        '
        Me.DGItemOrderList.AllowUserToAddRows = False
        Me.DGItemOrderList.AllowUserToDeleteRows = False
        Me.DGItemOrderList.BackgroundColor = System.Drawing.Color.LightSlateGray
        Me.DGItemOrderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGItemOrderList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        Me.DGItemOrderList.Location = New System.Drawing.Point(16, 54)
        Me.DGItemOrderList.Name = "DGItemOrderList"
        Me.DGItemOrderList.ReadOnly = True
        Me.DGItemOrderList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGItemOrderList.Size = New System.Drawing.Size(511, 196)
        Me.DGItemOrderList.TabIndex = 17
        '
        'Column1
        '
        Me.Column1.HeaderText = "ItemCode"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Description"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 150
        '
        'Column3
        '
        Me.Column3.HeaderText = "Price"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "Quantity"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 50
        '
        'Column5
        '
        Me.Column5.HeaderText = "SubTotal"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'lblItemOrderList
        '
        Me.lblItemOrderList.AutoSize = True
        Me.lblItemOrderList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblItemOrderList.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemOrderList.ForeColor = System.Drawing.Color.Black
        Me.lblItemOrderList.Location = New System.Drawing.Point(208, 19)
        Me.lblItemOrderList.Name = "lblItemOrderList"
        Me.lblItemOrderList.Size = New System.Drawing.Size(131, 22)
        Me.lblItemOrderList.TabIndex = 16
        Me.lblItemOrderList.Text = "Item Order List"
        '
        'FrmItemOrderList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(980, 424)
        Me.Controls.Add(Me.grpList)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmItemOrderList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmItemOrderList"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpItem.ResumeLayout(False)
        Me.grpItem.PerformLayout()
        CType(Me.txtQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpList.ResumeLayout(False)
        Me.grpList.PerformLayout()
        Me.grpCart.ResumeLayout(False)
        Me.grpCart.PerformLayout()
        CType(Me.DGItemOrderList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents grpItem As System.Windows.Forms.GroupBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents txtItemCode As System.Windows.Forms.TextBox
    Friend WithEvents lblItemCode As System.Windows.Forms.Label
    Friend WithEvents txtPrice As System.Windows.Forms.TextBox
    Friend WithEvents lblPrice As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnaddCart As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents grpList As System.Windows.Forms.GroupBox
    Friend WithEvents grpCart As System.Windows.Forms.GroupBox
    Friend WithEvents lblPayment As System.Windows.Forms.Label
    Friend WithEvents txtTotalPrice As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalPrice As System.Windows.Forms.Label
    Friend WithEvents lblItemOrderList As System.Windows.Forms.Label
    Friend WithEvents txtSearch1 As System.Windows.Forms.TextBox
    Friend WithEvents pbHeader As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents DGItemOrderList As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtQuantity As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
End Class
