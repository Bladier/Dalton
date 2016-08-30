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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSearch1 = New System.Windows.Forms.TextBox()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
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
        Me.lblPayment = New System.Windows.Forms.Label()
        Me.txtTotalPrice = New System.Windows.Forms.TextBox()
        Me.lblTotalPrice = New System.Windows.Forms.Label()
        Me.grpCart = New System.Windows.Forms.GroupBox()
        Me.lblItemOrderList = New System.Windows.Forms.Label()
        Me.lvItemOrderList = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.pbHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpItem.SuspendLayout()
        Me.grpList.SuspendLayout()
        Me.grpCart.SuspendLayout()
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
        Me.grpItem.Controls.Add(Me.Label2)
        Me.grpItem.Controls.Add(Me.txtSearch1)
        Me.grpItem.Controls.Add(Me.txtQuantity)
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
        'txtQuantity
        '
        Me.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuantity.Location = New System.Drawing.Point(124, 190)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(251, 22)
        Me.txtQuantity.TabIndex = 5
        Me.txtQuantity.Text = "Quantity"
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
        Me.btnaddCart.Location = New System.Drawing.Point(287, 227)
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
        Me.txtTotalPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPrice.ForeColor = System.Drawing.Color.Red
        Me.txtTotalPrice.Location = New System.Drawing.Point(691, 305)
        Me.txtTotalPrice.Name = "txtTotalPrice"
        Me.txtTotalPrice.Size = New System.Drawing.Size(173, 26)
        Me.txtTotalPrice.TabIndex = 13
        Me.txtTotalPrice.Text = "TotalPrice"
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
        Me.grpCart.Controls.Add(Me.lblItemOrderList)
        Me.grpCart.Controls.Add(Me.lvItemOrderList)
        Me.grpCart.Location = New System.Drawing.Point(420, 19)
        Me.grpCart.Name = "grpCart"
        Me.grpCart.Size = New System.Drawing.Size(533, 280)
        Me.grpCart.TabIndex = 13
        Me.grpCart.TabStop = False
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
        'lvItemOrderList
        '
        Me.lvItemOrderList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lvItemOrderList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvItemOrderList.FullRowSelect = True
        Me.lvItemOrderList.GridLines = True
        Me.lvItemOrderList.Location = New System.Drawing.Point(10, 50)
        Me.lvItemOrderList.Name = "lvItemOrderList"
        Me.lvItemOrderList.Size = New System.Drawing.Size(516, 216)
        Me.lvItemOrderList.TabIndex = 0
        Me.lvItemOrderList.UseCompatibleStateImageBehavior = False
        Me.lvItemOrderList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ItemCode"
        Me.ColumnHeader1.Width = 93
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Description"
        Me.ColumnHeader2.Width = 245
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Price"
        Me.ColumnHeader3.Width = 96
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Quantity"
        Me.ColumnHeader4.Width = 77
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
        Me.grpList.ResumeLayout(False)
        Me.grpList.PerformLayout()
        Me.grpCart.ResumeLayout(False)
        Me.grpCart.PerformLayout()
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
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnaddCart As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents grpList As System.Windows.Forms.GroupBox
    Friend WithEvents grpCart As System.Windows.Forms.GroupBox
    Friend WithEvents lblPayment As System.Windows.Forms.Label
    Friend WithEvents txtTotalPrice As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalPrice As System.Windows.Forms.Label
    Friend WithEvents lblItemOrderList As System.Windows.Forms.Label
    Friend WithEvents lvItemOrderList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtSearch1 As System.Windows.Forms.TextBox
    Friend WithEvents pbHeader As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
