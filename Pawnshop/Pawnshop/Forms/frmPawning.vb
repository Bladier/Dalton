﻿Public Class frmPawning
    'Version 1.2
    ' - Legend Added
    'Version 1.1
    ' - Don't display item not equal or less than the current date

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmPawning_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                Console.WriteLine("New Loan!")
                btnLoan.PerformClick()
            Case Keys.F2
                txtSearch.Focus()
            Case Keys.F4
                Console.WriteLine("Renewal")
                btnRenew.PerformClick()
            Case Keys.F5
                Console.WriteLine("Redeem")
                btnRedeem.PerformClick()
        End Select
    End Sub

    Private Sub frmPawning_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
        LoadActive()

        web_ads.AdsDisplay = webAds
        web_ads.Ads_Initialization()
    End Sub

    Private Sub btnLoan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoan.Click
        frmPawnItem.NewLoan()
        frmPawnItem.Show()
    End Sub

    Friend Sub LoadActive()
        Dim st As String = "1"

        st &= IIf(chkRenew.Checked, "1", "0")
        st &= IIf(chkRedeem.Checked, "1", "0")
        st &= IIf(chkSeg.Checked, "1", "0")

        Dim mySql As String = "SELECT FIRST 100 * FROM tblpawn WHERE LoanDate <= '" & CurrentDate.ToShortDateString
        'mySql = "SELECT * FROM tblpawn WHERE LoanDate <= '" & CurrentDate.ToShortDateString
        If st = "1000" Then
            mySql &= "' AND (Status = 'L' OR Status = 'R') ORDER BY LoanDate ASC, PAWNID ASC"
        Else
            'mySql &= "' AND (Status = 'L' OR Status = 'R' "
            mySql &= "' AND ("
            If st.Substring(1, 1) = "1" Then mySql &= "Status = '0' " 'Renew
            If st.Substring(2, 1) = "1" Then
                If st.Substring(1, 1) = "1" Then mySql &= " OR "
                mySql &= "Status = 'X' " 'Redeem
            End If
            If st.Substring(3, 1) = "1" Then
                If st.Substring(2, 1) = "1" Then mySql &= " OR "
                If st.Substring(1, 1) = "1" And st.Substring(2, 1) = "0" Then mySql &= " OR "
                mySql &= "Status = 'S' " 'Segregate
            End If

            mySql &= ") ORDER BY LoanDate DESC, PAWNID DESC"

        End If
        Dim ds As DataSet = LoadSQL(mySql)

        'HACK
        'Add proper PAWNING REFRESHER if display is not the same with the query
        If ds.Tables(0).Rows.Count = lvPawners.Items.Count And lvPawners.Items.Count > 10 Then
            'Exit Sub
        End If

        lvPawners.Items.Clear()
        dbReaderOpen()

        Dim PawnReader = LoadSQL_byDataReader(mySql)
        While PawnReader.Read

            Dim readerPT As New PawnTicket
            readerPT.LoadTicketInReader(PawnReader)
            AddItem(readerPT)

        End While

        dbReaderClose()
    End Sub

    Private Sub AddItem(ByVal tk As PawnTicket)
        Dim ticket As String
        ticket = String.Format("{0:000000}", tk.PawnTicket)
        Dim lv As ListViewItem = lvPawners.Items.Add(ticket)
        lv.SubItems.Add(tk.ItemType)
        lv.SubItems.Add(tk.Description)
        lv.SubItems.Add(String.Format("{0} {1}", tk.Pawner.FirstName, tk.Pawner.LastName))
        lv.SubItems.Add(tk.LoanDate)
        lv.SubItems.Add(tk.MaturityDate)
        lv.SubItems.Add(tk.ExpiryDate)
        lv.SubItems.Add(tk.AuctionDate)
        lv.SubItems.Add(tk.Principal)
        lv.Tag = tk.PawnID

        Select Case tk.Status
            Case "0" : lv.BackColor = Color.LightGray
            Case "X" : lv.BackColor = Color.Red
            Case "S" : lv.BackColor = Color.Yellow
            Case "W" : lv.BackColor = Color.Red
            Case "V" : lv.BackColor = Color.Gray
        End Select
    End Sub

    Private Sub ClearFields()
        txtSearch.Text = ""
        lvPawners.Items.Clear()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtSearch.Text = "" Then Exit Sub
        Dim secured_str As String = txtSearch.Text
        secured_str = DreadKnight(secured_str)

        Dim mySql As String = "SELECT * FROM tblpawn WHERE "
        If IsNumeric(secured_str) Then mySql &= vbCr & "PAWNTICKET = " & CInt(secured_str) & " OR "
        mySql &= vbCr & "UPPER(DESCRIPTION) LIKE UPPER('%" & secured_str & "%')"
        mySql &= vbCr & " OR UPPER(ITEMTYPE) LIKE UPPER('%" & secured_str & "%')"

        Console.WriteLine(mySql)
        Dim ds As DataSet = LoadSQL(mySql)
        Dim MaxRow As Single = ds.Tables(0).Rows.Count
        Dim clientID As Integer = 0

        lvPawners.Items.Clear()
        If MaxRow = 0 Then

            mySql = "SELECT * FROM tblClient WHERE "
            mySql &= vbCr & "UPPER(FIRSTNAME) LIKE UPPER('%" & secured_str & "%') OR "
            mySql &= vbCr & "UPPER(MIDDLENAME) LIKE UPPER('%" & secured_str & "%') OR "
            mySql &= vbCr & "UPPER(LASTNAME) LIKE UPPER('%" & secured_str & "%')"

            ds.Clear()
            ds = LoadSQL(mySql)
            MaxRow = ds.Tables(0).Rows.Count
            If MaxRow = 0 Then
                Console.WriteLine("No Pawn, No Client, No found")
                MsgBox("Query not found", MsgBoxStyle.Information)
                Exit Sub
            End If

            For Each dr As DataRow In ds.Tables(0).Rows
                clientID = dr.Item("ClientID")
                Dim xDs As DataSet

                mySql = "SELECT * FROM tblpawn WHERE clientID = " & clientID
                xDs = LoadSQL(mySql)
                MaxRow = xDs.Tables(0).Rows.Count
                If MaxRow > 0 Then
                    lvPawners.Items.Clear()
                    For Each xdr As DataRow In xDs.Tables(0).Rows
                        Dim tmpTicket As New PawnTicket
                        tmpTicket.LoadTicketInRow(xdr)
                        AddItem(tmpTicket)
                    Next
                End If
            Next
        Else
            For Each dr As DataRow In ds.Tables(0).Rows
                Dim tmpTicket As New PawnTicket
                tmpTicket.LoadTicketInRow(dr)
                AddItem(tmpTicket)
            Next
        End If

        MsgBox(MaxRow & " result found.", MsgBoxStyle.Information)
        'Auto Select
        If lvPawners.Items.Count > 0 Then
            lvPawners.Focus()
            lvPawners.Items(0).Selected = True
            lvPawners.Items(0).EnsureVisible()
        End If
    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        If lvPawners.SelectedItems.Count <= 0 Then Exit Sub

        Dim idx As Integer = CInt(lvPawners.FocusedItem.Tag)
        Dim tmpTicket As New PawnTicket
        tmpTicket.LoadTicket(idx)
        frmPawnItem.Show()
        frmPawnItem.LoadPawnTicket(tmpTicket, "D")
    End Sub

    Private Sub lvPawners_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvPawners.DoubleClick
        btnView.PerformClick()
    End Sub

    Private Sub lvPawners_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvPawners.KeyPress
        If isEnter(e) Then
            btnView.PerformClick()
        End If
    End Sub

    Private Sub btnRenew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRenew.Click
        If lvPawners.SelectedItems.Count > 0 Then
            btnView.PerformClick()
            frmPawnItem.btnRenew.PerformClick()
        End If
    End Sub

    Private Sub btnRedeem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRedeem.Click
        If lvPawners.SelectedItems.Count > 0 Then
            btnView.PerformClick()
            frmPawnItem.btnRedeem.PerformClick()
        End If
    End Sub

    Private Sub chkRenew_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRenew.CheckedChanged
        LoadActive()
    End Sub

    Private Sub chkRedeem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRedeem.CheckedChanged
        LoadActive()
    End Sub

    Private Sub chkSeg_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSeg.CheckedChanged
        LoadActive()
    End Sub
End Class