<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportSTO
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportSTO))
        Me.lvIMD = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ImportToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.CancelToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvIMD
        '
        Me.lvIMD.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14})
        Me.lvIMD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvIMD.FullRowSelect = True
        Me.lvIMD.GridLines = True
        Me.lvIMD.Location = New System.Drawing.Point(1, 41)
        Me.lvIMD.Name = "lvIMD"
        Me.lvIMD.Size = New System.Drawing.Size(1014, 341)
        Me.lvIMD.TabIndex = 6
        Me.lvIMD.UseCompatibleStateImageBehavior = False
        Me.lvIMD.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ItemCode"
        Me.ColumnHeader1.Width = 145
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Description"
        Me.ColumnHeader2.Width = 261
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Quantity"
        Me.ColumnHeader11.Width = 181
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Ware House Code"
        Me.ColumnHeader12.Width = 129
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "STO No"
        Me.ColumnHeader13.Width = 158
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "STO Date"
        Me.ColumnHeader14.Width = 171
        '
        'ToolStrip
        '
        Me.ToolStrip.AutoSize = False
        Me.ToolStrip.BackColor = System.Drawing.Color.LightSlateGray
        Me.ToolStrip.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportToolStripButton3, Me.SaveToolStripButton2, Me.CancelToolStripButton1})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1015, 40)
        Me.ToolStrip.TabIndex = 5
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ImportToolStripButton3
        '
        Me.ImportToolStripButton3.Image = CType(resources.GetObject("ImportToolStripButton3.Image"), System.Drawing.Image)
        Me.ImportToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ImportToolStripButton3.Name = "ImportToolStripButton3"
        Me.ImportToolStripButton3.Size = New System.Drawing.Size(95, 37)
        Me.ImportToolStripButton3.Text = "Import STO"
        '
        'SaveToolStripButton2
        '
        Me.SaveToolStripButton2.Image = CType(resources.GetObject("SaveToolStripButton2.Image"), System.Drawing.Image)
        Me.SaveToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton2.Name = "SaveToolStripButton2"
        Me.SaveToolStripButton2.Size = New System.Drawing.Size(55, 37)
        Me.SaveToolStripButton2.Text = "Save"
        '
        'CancelToolStripButton1
        '
        Me.CancelToolStripButton1.Image = CType(resources.GetObject("CancelToolStripButton1.Image"), System.Drawing.Image)
        Me.CancelToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CancelToolStripButton1.Name = "CancelToolStripButton1"
        Me.CancelToolStripButton1.Size = New System.Drawing.Size(66, 37)
        Me.CancelToolStripButton1.Text = "Cancel"
        '
        'ImportSTO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1015, 386)
        Me.Controls.Add(Me.lvIMD)
        Me.Controls.Add(Me.ToolStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ImportSTO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import STO"
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lvIMD As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ImportToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents CancelToolStripButton1 As System.Windows.Forms.ToolStripButton
End Class
