﻿Public Class frmMain

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the color in the MDI client.
        For Each ctl As Control In Me.Controls
            If TypeOf ctl Is MdiClient Then
                ctl.BackColor = Me.BackColor
            End If
        Next ctl
    End Sub

    Friend Sub LoadChild(ByVal frm As Form)
        frm.MdiParent = Me
        frm.TopMost = True
        frm.BringToFront()
        frm.Show()
    End Sub

    Friend Sub Alert()
        MsgBox("Alert", MsgBoxStyle.Critical)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsToolStripMenuItem.Click
        frmSettings.Show()
    End Sub

    Private Sub UserManagementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserManagementToolStripMenuItem.Click
        frmUserManagement.Show()
    End Sub

    Private Sub OpenStoreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenStoreToolStripMenuItem.Click
        frmOpenStore.Show()
    End Sub

    Private Sub ExpiryGeneratorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpiryGeneratorToolStripMenuItem.Click
        frmExtractor.FormType = frmExtractor.ExtractType.Expiry
        frmExtractor.Show()
    End Sub

    Private Sub JournalEntriesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JournalEntriesToolStripMenuItem.Click
        frmExtractor.FormType = frmExtractor.ExtractType.JournalEntry
        frmExtractor.Show()
    End Sub
End Class
