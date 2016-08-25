<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddProduct
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddProduct))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtIMDID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbHasSerial = New System.Windows.Forms.ComboBox()
        Me.cmbIsSalable = New System.Windows.Forms.ComboBox()
        Me.cmbInInven = New System.Windows.Forms.ComboBox()
        Me.cmbOnhold = New System.Windows.Forms.ComboBox()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.txtUnitofMeasure = New System.Windows.Forms.TextBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.lblHasSerial = New System.Windows.Forms.Label()
        Me.lblisSale = New System.Windows.Forms.Label()
        Me.lblisInv = New System.Windows.Forms.Label()
        Me.lblonHoldYN = New System.Windows.Forms.Label()
        Me.lblPrice = New System.Windows.Forms.Label()
        Me.lblUnitOfMeasure = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.txtItemCode = New System.Windows.Forms.TextBox()
        Me.lblItemCode = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GroupBox1.Controls.Add(Me.txtIMDID)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbHasSerial)
        Me.GroupBox1.Controls.Add(Me.cmbIsSalable)
        Me.GroupBox1.Controls.Add(Me.cmbInInven)
        Me.GroupBox1.Controls.Add(Me.cmbOnhold)
        Me.GroupBox1.Controls.Add(Me.txtPrice)
        Me.GroupBox1.Controls.Add(Me.txtUnitofMeasure)
        Me.GroupBox1.Controls.Add(Me.txtDescription)
        Me.GroupBox1.Controls.Add(Me.lblHasSerial)
        Me.GroupBox1.Controls.Add(Me.lblisSale)
        Me.GroupBox1.Controls.Add(Me.lblisInv)
        Me.GroupBox1.Controls.Add(Me.lblonHoldYN)
        Me.GroupBox1.Controls.Add(Me.lblPrice)
        Me.GroupBox1.Controls.Add(Me.lblUnitOfMeasure)
        Me.GroupBox1.Controls.Add(Me.lblDescription)
        Me.GroupBox1.Controls.Add(Me.txtItemCode)
        Me.GroupBox1.Controls.Add(Me.lblItemCode)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(21, 86)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(345, 337)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Add Item"
        '
        'txtIMDID
        '
        Me.txtIMDID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIMDID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIMDID.Location = New System.Drawing.Point(138, 33)
        Me.txtIMDID.Name = "txtIMDID"
        Me.txtIMDID.ReadOnly = True
        Me.txtIMDID.Size = New System.Drawing.Size(173, 22)
        Me.txtIMDID.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(65, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "IMD ID"
        '
        'cmbHasSerial
        '
        Me.cmbHasSerial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbHasSerial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbHasSerial.FormattingEnabled = True
        Me.cmbHasSerial.Items.AddRange(New Object() {"Y", "N"})
        Me.cmbHasSerial.Location = New System.Drawing.Point(138, 289)
        Me.cmbHasSerial.Name = "cmbHasSerial"
        Me.cmbHasSerial.Size = New System.Drawing.Size(175, 24)
        Me.cmbHasSerial.TabIndex = 14
        '
        'cmbIsSalable
        '
        Me.cmbIsSalable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIsSalable.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIsSalable.FormattingEnabled = True
        Me.cmbIsSalable.Items.AddRange(New Object() {"Y", "N"})
        Me.cmbIsSalable.Location = New System.Drawing.Point(138, 259)
        Me.cmbIsSalable.Name = "cmbIsSalable"
        Me.cmbIsSalable.Size = New System.Drawing.Size(175, 24)
        Me.cmbIsSalable.TabIndex = 13
        '
        'cmbInInven
        '
        Me.cmbInInven.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbInInven.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbInInven.FormattingEnabled = True
        Me.cmbInInven.Items.AddRange(New Object() {"Y", "N"})
        Me.cmbInInven.Location = New System.Drawing.Point(138, 227)
        Me.cmbInInven.Name = "cmbInInven"
        Me.cmbInInven.Size = New System.Drawing.Size(175, 24)
        Me.cmbInInven.TabIndex = 12
        '
        'cmbOnhold
        '
        Me.cmbOnhold.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOnhold.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOnhold.FormattingEnabled = True
        Me.cmbOnhold.Items.AddRange(New Object() {"Y", "N"})
        Me.cmbOnhold.Location = New System.Drawing.Point(138, 194)
        Me.cmbOnhold.Name = "cmbOnhold"
        Me.cmbOnhold.Size = New System.Drawing.Size(175, 24)
        Me.cmbOnhold.TabIndex = 1
        '
        'txtPrice
        '
        Me.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice.Location = New System.Drawing.Point(138, 158)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(173, 22)
        Me.txtPrice.TabIndex = 11
        '
        'txtUnitofMeasure
        '
        Me.txtUnitofMeasure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnitofMeasure.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnitofMeasure.Location = New System.Drawing.Point(138, 128)
        Me.txtUnitofMeasure.Name = "txtUnitofMeasure"
        Me.txtUnitofMeasure.Size = New System.Drawing.Size(173, 22)
        Me.txtUnitofMeasure.TabIndex = 10
        '
        'txtDescription
        '
        Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(138, 98)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(173, 22)
        Me.txtDescription.TabIndex = 9
        '
        'lblHasSerial
        '
        Me.lblHasSerial.AutoSize = True
        Me.lblHasSerial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHasSerial.Location = New System.Drawing.Point(49, 292)
        Me.lblHasSerial.Name = "lblHasSerial"
        Me.lblHasSerial.Size = New System.Drawing.Size(71, 16)
        Me.lblHasSerial.TabIndex = 8
        Me.lblHasSerial.Text = "Has Serial"
        '
        'lblisSale
        '
        Me.lblisSale.AutoSize = True
        Me.lblisSale.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblisSale.Location = New System.Drawing.Point(52, 262)
        Me.lblisSale.Name = "lblisSale"
        Me.lblisSale.Size = New System.Drawing.Size(68, 16)
        Me.lblisSale.TabIndex = 7
        Me.lblisSale.Text = "Is Salable"
        '
        'lblisInv
        '
        Me.lblisInv.AutoSize = True
        Me.lblisInv.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblisInv.Location = New System.Drawing.Point(24, 231)
        Me.lblisInv.Name = "lblisInv"
        Me.lblisInv.Size = New System.Drawing.Size(98, 16)
        Me.lblisInv.TabIndex = 6
        Me.lblisInv.Text = "Is Inventoriable"
        '
        'lblonHoldYN
        '
        Me.lblonHoldYN.AutoSize = True
        Me.lblonHoldYN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblonHoldYN.Location = New System.Drawing.Point(30, 198)
        Me.lblonHoldYN.Name = "lblonHoldYN"
        Me.lblonHoldYN.Size = New System.Drawing.Size(91, 16)
        Me.lblonHoldYN.TabIndex = 5
        Me.lblonHoldYN.Text = "On Hold (Y/N)"
        '
        'lblPrice
        '
        Me.lblPrice.AutoSize = True
        Me.lblPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrice.Location = New System.Drawing.Point(79, 162)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Size = New System.Drawing.Size(39, 16)
        Me.lblPrice.TabIndex = 4
        Me.lblPrice.Text = "Price"
        '
        'lblUnitOfMeasure
        '
        Me.lblUnitOfMeasure.AutoSize = True
        Me.lblUnitOfMeasure.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnitOfMeasure.Location = New System.Drawing.Point(23, 130)
        Me.lblUnitOfMeasure.Name = "lblUnitOfMeasure"
        Me.lblUnitOfMeasure.Size = New System.Drawing.Size(97, 16)
        Me.lblUnitOfMeasure.TabIndex = 3
        Me.lblUnitOfMeasure.Text = "UnitOfMeasure"
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.Location = New System.Drawing.Point(44, 100)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(76, 16)
        Me.lblDescription.TabIndex = 2
        Me.lblDescription.Text = "Description"
        '
        'txtItemCode
        '
        Me.txtItemCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemCode.Location = New System.Drawing.Point(138, 68)
        Me.txtItemCode.Name = "txtItemCode"
        Me.txtItemCode.Size = New System.Drawing.Size(173, 22)
        Me.txtItemCode.TabIndex = 1
        '
        'lblItemCode
        '
        Me.lblItemCode.AutoSize = True
        Me.lblItemCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemCode.Location = New System.Drawing.Point(53, 70)
        Me.lblItemCode.Name = "lblItemCode"
        Me.lblItemCode.Size = New System.Drawing.Size(66, 16)
        Me.lblItemCode.TabIndex = 0
        Me.lblItemCode.Text = "ItemCode"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GroupBox2.Controls.Add(Me.btnCancel)
        Me.GroupBox2.Controls.Add(Me.btnSave)
        Me.GroupBox2.Location = New System.Drawing.Point(375, 126)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(136, 127)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(32, 74)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 33)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(32, 30)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 33)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "&Save "
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSlateGray
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblTitle)
        Me.Panel1.Location = New System.Drawing.Point(-3, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(527, 66)
        Me.Panel1.TabIndex = 4
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe Print", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(3, 9)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(234, 42)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "Adding New Item"
        '
        'frmAddProduct
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(519, 435)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmAddProduct"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Product"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbOnhold As System.Windows.Forms.ComboBox
    Friend WithEvents txtPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtUnitofMeasure As System.Windows.Forms.TextBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents lblHasSerial As System.Windows.Forms.Label
    Friend WithEvents lblisSale As System.Windows.Forms.Label
    Friend WithEvents lblisInv As System.Windows.Forms.Label
    Friend WithEvents lblonHoldYN As System.Windows.Forms.Label
    Friend WithEvents lblPrice As System.Windows.Forms.Label
    Friend WithEvents lblUnitOfMeasure As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents txtItemCode As System.Windows.Forms.TextBox
    Friend WithEvents lblItemCode As System.Windows.Forms.Label
    Friend WithEvents cmbHasSerial As System.Windows.Forms.ComboBox
    Friend WithEvents cmbIsSalable As System.Windows.Forms.ComboBox
    Friend WithEvents cmbInInven As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents txtIMDID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
