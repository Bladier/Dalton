<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIMD
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIMD))
        Me.lvIMD = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.NewToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.UpdateToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.txtSearchtoolStrip = New System.Windows.Forms.ToolStripTextBox()
        Me.SearchToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.CloseToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvIMD
        '
        Me.lvIMD.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14, Me.ColumnHeader15, Me.ColumnHeader16, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lvIMD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvIMD.FullRowSelect = True
        Me.lvIMD.GridLines = True
        Me.lvIMD.Location = New System.Drawing.Point(0, 42)
        Me.lvIMD.Name = "lvIMD"
        Me.lvIMD.Size = New System.Drawing.Size(1036, 370)
        Me.lvIMD.TabIndex = 1
        Me.lvIMD.UseCompatibleStateImageBehavior = False
        Me.lvIMD.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 115
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "ItemCode"
        Me.ColumnHeader2.Width = 261
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Description"
        Me.ColumnHeader11.Width = 120
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Unit Of Measure"
        Me.ColumnHeader12.Width = 129
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Price"
        Me.ColumnHeader13.Width = 109
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "On Hold (Yes/No)"
        Me.ColumnHeader14.Width = 127
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "Inventoriable"
        Me.ColumnHeader15.Width = 80
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "Salable"
        Me.ColumnHeader16.Width = 92
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Has Serial"
        Me.ColumnHeader3.Width = 96
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.LightSlateGray
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripButton1, Me.UpdateToolStripButton4, Me.txtSearchtoolStrip, Me.SearchToolStripButton2, Me.CloseToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1042, 40)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'NewToolStripButton1
        '
        Me.NewToolStripButton1.AutoSize = False
        Me.NewToolStripButton1.Image = CType(resources.GetObject("NewToolStripButton1.Image"), System.Drawing.Image)
        Me.NewToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewToolStripButton1.Name = "NewToolStripButton1"
        Me.NewToolStripButton1.Size = New System.Drawing.Size(65, 40)
        Me.NewToolStripButton1.Text = "&New"
        '
        'UpdateToolStripButton4
        '
        Me.UpdateToolStripButton4.Image = CType(resources.GetObject("UpdateToolStripButton4.Image"), System.Drawing.Image)
        Me.UpdateToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.UpdateToolStripButton4.Name = "UpdateToolStripButton4"
        Me.UpdateToolStripButton4.Size = New System.Drawing.Size(71, 37)
        Me.UpdateToolStripButton4.Text = "Update"
        '
        'txtSearchtoolStrip
        '
        Me.txtSearchtoolStrip.BackColor = System.Drawing.SystemColors.Info
        Me.txtSearchtoolStrip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearchtoolStrip.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchtoolStrip.ForeColor = System.Drawing.SystemColors.InfoText
        Me.txtSearchtoolStrip.Name = "txtSearchtoolStrip"
        Me.txtSearchtoolStrip.Size = New System.Drawing.Size(160, 40)
        Me.txtSearchtoolStrip.Text = "Search"
        '
        'SearchToolStripButton2
        '
        Me.SearchToolStripButton2.Image = CType(resources.GetObject("SearchToolStripButton2.Image"), System.Drawing.Image)
        Me.SearchToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SearchToolStripButton2.Name = "SearchToolStripButton2"
        Me.SearchToolStripButton2.Size = New System.Drawing.Size(67, 37)
        Me.SearchToolStripButton2.Text = "Search"
        '
        'CloseToolStripButton1
        '
        Me.CloseToolStripButton1.Image = CType(resources.GetObject("CloseToolStripButton1.Image"), System.Drawing.Image)
        Me.CloseToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CloseToolStripButton1.Name = "CloseToolStripButton1"
        Me.CloseToolStripButton1.Size = New System.Drawing.Size(60, 37)
        Me.CloseToolStripButton1.Text = "Close"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "ON HAND"
        Me.ColumnHeader4.Width = 97
        '
        'frmIMD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 424)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.lvIMD)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmIMD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ITEM MASTER DATA"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lvIMD As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents NewToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtSearchtoolStrip As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents SearchToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents UpdateToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents CloseToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
End Class
