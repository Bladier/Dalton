﻿Public Class frm_PanelKarat

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim tmpResult As String = txtGram.Text
        With frmPawningItemNew.lvSpec
            .SelectedItems(0).SubItems(4).Text = tmpResult
        End With
        Me.Close()
    End Sub

    Private Sub frm_PanelKarat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtGram.Clear()
        txtGram.Focus()
    End Sub

    Private Sub txtGram_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGram.KeyPress
        DigitOnly(e)
        If isEnter(e) Then
            btnSubmit.PerformClick()
        End If
    End Sub
End Class