Public Class frmPOSMain

    Private Sub CloseChildForms()
        For Each frm As Form In Me.MdiChildren
            If frm.Name = "frmHome" Then
            Else
                frm.Close()
            End If
        Next
    End Sub


    Private Sub ItemListToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemListToolStripButton1.Click
        CloseChildForms()
        ImportIMDFile.MdiParent = Me
        ImportIMDFile.Show()
    End Sub


    Private Sub POSToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POSToolStripButton1.Click
        CloseChildForms()
        FrmItemOrderList.MdiParent = Me
        FrmItemOrderList.Show()
    End Sub

    Private Sub LoadTransactionToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadTransactionToolStripButton1.Click
        CloseChildForms()
        frmIMD.MdiParent = Me
        frmIMD.Show()
    End Sub

    Private Sub ImportSTOToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportSTOToolStripButton3.Click
        CloseChildForms()
        ImportSTO.MdiParent = Me
        ImportSTO.Show()
    End Sub


    Private Sub CloseToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripButton1.Click
        Me.Hide()
        frmMain.Show()
    End Sub
End Class