Public Class frmSearchLoans
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        frmNewloan.Show()
        frmNewloan.lblTranstype.Text = "NEW LOAN"
        frmNewloan.txtPawner.ReadOnly = False
        frmNewloan.txtDesc.ReadOnly = False
        frmNewloan.cboItemtype.Enabled = True
        frmNewloan.cboCategory.Enabled = True
        frmNewloan.lblNticket.Visible = False
        frmNewloan.txtNticket.Visible = False
        frmNewloan.txtAppraisal.ReadOnly = False
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnRedeem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRedeem.Click
        frmNewloan.Show()
        frmNewloan.btnSave.Text = "Redeem"
        frmNewloan.lblTranstype.Text = "LOAN REDEMPTION"
        frmNewloan.grpReceipt.Visible = True
        frmNewloan.grpAmount.Visible = False
        frmNewloan.lblRedeemDue.Visible = True
        frmNewloan.txtRedeemDue.Visible = True
    End Sub

    Private Sub btnRenew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRenew.Click
        frmNewloan.Show()
        frmNewloan.btnSave.Text = "Renew"
        frmNewloan.lblTranstype.Text = "LOAN RENEWAL"
        frmNewloan.grpReceipt.Visible = True
        frmNewloan.btnLess.Visible = True
        frmNewloan.grpAmount.Visible = False
        frmNewloan.lblRenewDue.Visible = True
        frmNewloan.txtRenewDue.Visible = True
    End Sub
End Class