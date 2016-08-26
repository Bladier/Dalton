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
        Me.txtHasSerial = New System.Windows.Forms.TextBox()
        Me.txtSalable = New System.Windows.Forms.TextBox()
        Me.txtInventoriable = New System.Windows.Forms.TextBox()
        Me.txtOnHold = New System.Windows.Forms.TextBox()
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
        Me.GroupBox1.Controls.Add(Me.txtHasSerial)
        Me.GroupBox1.Controls.Add(Me.txtSalable)
        Me.GroupBox1.Controls.Add(Me.txtInventoriable)
        Me.GroupBox1.Controls.Add(Me.txtOnHold)
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
        Me.GroupBox1.Location = New System.Drawing.Point(20, 86)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(345, 304)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Add Item"
        '
        'txtHasSerial
        '
        Me.txtHasSerial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHasSerial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHasSerial.Location = New System.Drawing.Point(134, 253)
        Me.txtHasSerial.Name = "txtHasSerial"
        Me.txtHasSerial.Size = New System.Drawing.Size(173, 22)
        Me.txtHasSerial.TabIndex = 8
        '
        'txtSalable
        '
        Me.txtSalable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalable.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSalable.Location = New System.Drawing.Point(134, 223)
        Me.txtSalable.Name = "txtSalable"
        Me.txtSalable.Size = New System.Drawing.Size(173, 22)
        Me.txtSalable.TabIndex = 7
        '
        'txtInventoriable
        '
        Me.txtInventoriable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInventoriable.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInventoriable.Location = New System.Drawing.Point(134, 193)
        Me.txtInventoriable.Name = "txtInventoriable"
        Me.txtInventoriable.Size = New System.Drawing.Size(173, 22)
        Me.txtInventoriable.TabIndex = 6
        '
        'txtOnHold
        '
        Me.txtOnHold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOnHold.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOnHold.Location = New System.Drawing.Point(134, 162)
        Me.txtOnHold.Name = "txtOnHold"
        Me.txtOnHold.Size = New System.Drawing.Size(173, 22)
        Me.txtOnHold.TabIndex = 5
        '
        'txtPrice
        '
        Me.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice.Location = New System.Drawing.Point(134, 130)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(173, 22)
        Me.txtPrice.TabIndex = 4
        '
        'txtUnitofMeasure
        '
        Me.txtUnitofMeasure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnitofMeasure.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnitofMeasure.Location = New System.Drawing.Point(134, 100)
        Me.txtUnitofMeasure.Name = "txtUnitofMeasure"
        Me.txtUnitofMeasure.Size = New System.Drawing.Size(173, 22)
        Me.txtUnitofMeasure.TabIndex = 3
        '
        'txtDescription
        '
        Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(134, 70)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(173, 22)
        Me.txtDescription.TabIndex = 2
        '
        'lblHasSerial
        '
        Me.lblHasSerial.AutoSize = True
        Me.lblHasSerial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHasSerial.Location = New System.Drawing.Point(13, 254)
        Me.lblHasSerial.Name = "lblHasSerial"
        Me.lblHasSerial.Size = New System.Drawing.Size(102, 16)
        Me.lblHasSerial.TabIndex = 8
        Me.lblHasSerial.Text = "Has Serial(Y/N)"
        '
        'lblisSale
        '
        Me.lblisSale.AutoSize = True
        Me.lblisSale.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblisSale.Location = New System.Drawing.Point(29, 225)
        Me.lblisSale.Name = "lblisSale"
        Me.lblisSale.Size = New System.Drawing.Size(86, 16)
        Me.lblisSale.TabIndex = 7
        Me.lblisSale.Text = "Salable(Y/N)"
        '
        'lblisInv
        '
        Me.lblisInv.AutoSize = True
        Me.lblisInv.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblisInv.Location = New System.Drawing.Point(1, 195)
        Me.lblisInv.Name = "lblisInv"
        Me.lblisInv.Size = New System.Drawing.Size(116, 16)
        Me.lblisInv.TabIndex = 6
        Me.lblisInv.Text = "Inventoriable(Y/N)"
        '
        'lblonHoldYN
        '
        Me.lblonHoldYN.AutoSize = True
        Me.lblonHoldYN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblonHoldYN.Location = New System.Drawing.Point(26, 166)
        Me.lblonHoldYN.Name = "lblonHoldYN"
        Me.lblonHoldYN.Size = New System.Drawing.Size(91, 16)
        Me.lblonHoldYN.TabIndex = 5
        Me.lblonHoldYN.Text = "On Hold (Y/N)"
        '
        'lblPrice
        '
        Me.lblPrice.AutoSize = True
        Me.lblPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrice.Location = New System.Drawing.Point(73, 137)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Size = New System.Drawing.Size(39, 16)
        Me.lblPrice.TabIndex = 4
        Me.lblPrice.Text = "Price"
        '
        'lblUnitOfMeasure
        '
        Me.lblUnitOfMeasure.AutoSize = True
        Me.lblUnitOfMeasure.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnitOfMeasure.Location = New System.Drawing.Point(19, 102)
        Me.lblUnitOfMeasure.Name = "lblUnitOfMeasure"
        Me.lblUnitOfMeasure.Size = New System.Drawing.Size(97, 16)
        Me.lblUnitOfMeasure.TabIndex = 3
        Me.lblUnitOfMeasure.Text = "UnitOfMeasure"
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.Location = New System.Drawing.Point(40, 72)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(76, 16)
        Me.lblDescription.TabIndex = 2
        Me.lblDescription.Text = "Description"
        '
        'txtItemCode
        '
        Me.txtItemCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemCode.Location = New System.Drawing.Point(134, 40)
        Me.txtItemCode.Name = "txtItemCode"
        Me.txtItemCode.Size = New System.Drawing.Size(173, 22)
        Me.txtItemCode.TabIndex = 1
        '
        'lblItemCode
        '
        Me.lblItemCode.AutoSize = True
        Me.lblItemCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemCode.Location = New System.Drawing.Point(49, 42)
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
        Me.btnCancel.TabIndex = 1
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
        Me.btnSave.TabIndex = 0
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
        Me.lblTitle.Size = New System.Drawing.Size(242, 42)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "Register New Item"
        '
        'frmAddProduct
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(519, 408)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmAddProduct"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Item Registration"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
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
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents txtHasSerial As System.Windows.Forms.TextBox
    Friend WithEvents txtSalable As System.Windows.Forms.TextBox
    Friend WithEvents txtInventoriable As System.Windows.Forms.TextBox
    Friend WithEvents txtOnHold As System.Windows.Forms.TextBox
End Class
