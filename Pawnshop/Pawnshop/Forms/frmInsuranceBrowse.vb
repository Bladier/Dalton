Public Class frmInsuranceBrowse

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        frmInsurance.Show()
        frmInsurance.txtClient.ReadOnly = False
        frmInsurance.txtCOI.ReadOnly = False
        frmInsurance.txtAmount.ReadOnly = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class