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
        Me.CloseToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ItemCountToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ofdOpen = New System.Windows.Forms.OpenFileDialog()
        Me.lblPath = New System.Windows.Forms.Label()
        Me.SFD = New System.Windows.Forms.SaveFileDialog()
        Me.ToolStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvIMD
        '
        Me.lvIMD.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14})
        Me.lvIMD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvIMD.FullRowSelect = True
        Me.lvIMD.GridLines = True
        Me.lvIMD.Location = New System.Drawing.Point(7, 41)
        Me.lvIMD.Name = "lvIMD"
        Me.lvIMD.Size = New System.Drawing.Size(591, 320)
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
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportToolStripButton3, Me.SaveToolStripButton2, Me.CloseToolStripButton1})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(602, 40)
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
        'CloseToolStripButton1
        '
        Me.CloseToolStripButton1.Image = CType(resources.GetObject("CloseToolStripButton1.Image"), System.Drawing.Image)
        Me.CloseToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CloseToolStripButton1.Name = "CloseToolStripButton1"
        Me.CloseToolStripButton1.Size = New System.Drawing.Size(60, 37)
        Me.CloseToolStripButton1.Text = "Close"
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ItemCountToolStripStatusLabel1})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 364)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(602, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'ItemCountToolStripStatusLabel1
        '
        Me.ItemCountToolStripStatusLabel1.Name = "ItemCountToolStripStatusLabel1"
        Me.ItemCountToolStripStatusLabel1.Size = New System.Drawing.Size(40, 17)
        Me.ItemCountToolStripStatusLabel1.Text = "Count"
        '
        'ofdOpen
        '
        Me.ofdOpen.FileName = "OpenFileDialog1"
        Me.ofdOpen.Filter = "PTU File |*.PTU"
        '
        'lblPath
        '
        Me.lblPath.AutoSize = True
        Me.lblPath.BackColor = System.Drawing.Color.LightSlateGray
        Me.lblPath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPath.ForeColor = System.Drawing.Color.LightSlateGray
        Me.lblPath.Location = New System.Drawing.Point(222, 10)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(37, 18)
        Me.lblPath.TabIndex = 9
        Me.lblPath.Text = "Path"
        '
        'SFD
        '
        Me.SFD.Filter = "TEXTFILE |*.txt"
        '
        'ImportSTO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(602, 386)
        Me.Controls.Add(Me.lblPath)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.lvIMD)
        Me.Controls.Add(Me.ToolStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ImportSTO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import STO"
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents CloseToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ItemCountToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ofdOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblPath As System.Windows.Forms.Label
    Friend WithEvents SFD As System.Windows.Forms.SaveFileDialog
End Class
