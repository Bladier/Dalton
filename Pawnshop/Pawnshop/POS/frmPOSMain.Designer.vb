<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPOSMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPOSMain))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ItemListToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ImportSTOToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.POSToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.LoadTransactionToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.CancelToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1233, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(92, 22)
        Me.ExitToolStripMenuItem.Text = "&Exit"
        '
        'ToolStrip
        '
        Me.ToolStrip.AutoSize = False
        Me.ToolStrip.BackColor = System.Drawing.Color.LightSlateGray
        Me.ToolStrip.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ItemListToolStripButton1, Me.ImportSTOToolStripButton3, Me.POSToolStripButton1, Me.LoadTransactionToolStripButton1, Me.CancelToolStripButton1})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1233, 40)
        Me.ToolStrip.TabIndex = 4
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ItemListToolStripButton1
        '
        Me.ItemListToolStripButton1.Image = CType(resources.GetObject("ItemListToolStripButton1.Image"), System.Drawing.Image)
        Me.ItemListToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ItemListToolStripButton1.Name = "ItemListToolStripButton1"
        Me.ItemListToolStripButton1.Size = New System.Drawing.Size(119, 37)
        Me.ItemListToolStripButton1.Text = "Import Item List"
        '
        'ImportSTOToolStripButton3
        '
        Me.ImportSTOToolStripButton3.Image = CType(resources.GetObject("ImportSTOToolStripButton3.Image"), System.Drawing.Image)
        Me.ImportSTOToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ImportSTOToolStripButton3.Name = "ImportSTOToolStripButton3"
        Me.ImportSTOToolStripButton3.Size = New System.Drawing.Size(95, 37)
        Me.ImportSTOToolStripButton3.Text = "Import STO"
        '
        'POSToolStripButton1
        '
        Me.POSToolStripButton1.Image = CType(resources.GetObject("POSToolStripButton1.Image"), System.Drawing.Image)
        Me.POSToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.POSToolStripButton1.Name = "POSToolStripButton1"
        Me.POSToolStripButton1.Size = New System.Drawing.Size(52, 37)
        Me.POSToolStripButton1.Text = "POS"
        '
        'LoadTransactionToolStripButton1
        '
        Me.LoadTransactionToolStripButton1.Image = CType(resources.GetObject("LoadTransactionToolStripButton1.Image"), System.Drawing.Image)
        Me.LoadTransactionToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LoadTransactionToolStripButton1.Name = "LoadTransactionToolStripButton1"
        Me.LoadTransactionToolStripButton1.Size = New System.Drawing.Size(133, 37)
        Me.LoadTransactionToolStripButton1.Text = "Load Master Data"
        '
        'CancelToolStripButton1
        '
        Me.CancelToolStripButton1.Image = CType(resources.GetObject("CancelToolStripButton1.Image"), System.Drawing.Image)
        Me.CancelToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CancelToolStripButton1.Name = "CancelToolStripButton1"
        Me.CancelToolStripButton1.Size = New System.Drawing.Size(66, 37)
        Me.CancelToolStripButton1.Text = "Cancel"
        '
        'frmPOSMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1233, 565)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmPOSMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "POS Main"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ItemListToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ImportSTOToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents LoadTransactionToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents CancelToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents POSToolStripButton1 As System.Windows.Forms.ToolStripButton
End Class
