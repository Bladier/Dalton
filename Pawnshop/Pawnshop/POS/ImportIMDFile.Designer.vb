<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportIMDFile
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportIMDFile))
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ImportToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.CloseToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.lvIMD = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ofdOpen = New System.Windows.Forms.OpenFileDialog()
        Me.lblPath = New System.Windows.Forms.Label()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ItemCountToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        Me.ToolStrip.AutoSize = False
        Me.ToolStrip.BackColor = System.Drawing.Color.LightSlateGray
        Me.ToolStrip.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportToolStripButton3, Me.SaveToolStripButton2, Me.CloseToolStripButton1})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1069, 40)
        Me.ToolStrip.TabIndex = 3
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ImportToolStripButton3
        '
        Me.ImportToolStripButton3.Image = CType(resources.GetObject("ImportToolStripButton3.Image"), System.Drawing.Image)
        Me.ImportToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ImportToolStripButton3.Name = "ImportToolStripButton3"
        Me.ImportToolStripButton3.Size = New System.Drawing.Size(67, 37)
        Me.ImportToolStripButton3.Text = "Import"
        '
        'SaveToolStripButton2
        '
        Me.SaveToolStripButton2.Image = CType(resources.GetObject("SaveToolStripButton2.Image"), System.Drawing.Image)
        Me.SaveToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton2.Name = "SaveToolStripButton2"
        Me.SaveToolStripButton2.Size = New System.Drawing.Size(55, 37)
        Me.SaveToolStripButton2.Text = "Save"
        '
        'CloseToolStripButton1
        '
        Me.CloseToolStripButton1.Image = CType(resources.GetObject("CloseToolStripButton1.Image"), System.Drawing.Image)
        Me.CloseToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CloseToolStripButton1.Name = "CloseToolStripButton1"
        Me.CloseToolStripButton1.Size = New System.Drawing.Size(60, 37)
        Me.CloseToolStripButton1.Text = "Close"
        '
        'lvIMD
        '
        Me.lvIMD.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14, Me.ColumnHeader15, Me.ColumnHeader16})
        Me.lvIMD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvIMD.FullRowSelect = True
        Me.lvIMD.GridLines = True
        Me.lvIMD.Location = New System.Drawing.Point(12, 41)
        Me.lvIMD.Name = "lvIMD"
        Me.lvIMD.Size = New System.Drawing.Size(1060, 333)
        Me.lvIMD.TabIndex = 4
        Me.lvIMD.UseCompatibleStateImageBehavior = False
        Me.lvIMD.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ItemCode"
        Me.ColumnHeader1.Width = 115
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Description"
        Me.ColumnHeader2.Width = 261
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "UnitOfMeasure"
        Me.ColumnHeader11.Width = 120
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Price"
        Me.ColumnHeader12.Width = 129
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "On Hold (Yes/No)"
        Me.ColumnHeader13.Width = 132
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "Inventoriable"
        Me.ColumnHeader14.Width = 109
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "Salable"
        Me.ColumnHeader15.Width = 80
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "Has Serial"
        Me.ColumnHeader16.Width = 92
        '
        'ofdOpen
        '
        Me.ofdOpen.Filter = "Excel File |*.xlsx"
        '
        'lblPath
        '
        Me.lblPath.AutoSize = True
        Me.lblPath.BackColor = System.Drawing.Color.LightSlateGray
        Me.lblPath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPath.ForeColor = System.Drawing.Color.LightSlateGray
        Me.lblPath.Location = New System.Drawing.Point(229, 10)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(37, 18)
        Me.lblPath.TabIndex = 5
        Me.lblPath.Text = "Path"
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ItemCountToolStripStatusLabel1})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 377)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(1069, 22)
        Me.StatusStrip.TabIndex = 6
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'ItemCountToolStripStatusLabel1
        '
        Me.ItemCountToolStripStatusLabel1.Name = "ItemCountToolStripStatusLabel1"
        Me.ItemCountToolStripStatusLabel1.Size = New System.Drawing.Size(40, 17)
        Me.ItemCountToolStripStatusLabel1.Text = "Count"
        '
        'ImportIMDFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1069, 399)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.lblPath)
        Me.Controls.Add(Me.lvIMD)
        Me.Controls.Add(Me.ToolStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ImportIMDFile"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import Item Master Data File"
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents SaveToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ImportToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents lvIMD As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ofdOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblPath As System.Windows.Forms.Label
    Friend WithEvents CloseToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ItemCountToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
End Class
