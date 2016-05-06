﻿Public Class frmDollorSimple

    Private dollarClient As Client
    Private dollarEntry As DollarTransaction
    Private strRate As String = DollarRate
    Private fillData As String = "tblDollar"

    Private MODULE_NAME As String = "DOLLAR"

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Friend Sub LoadClient(ByVal cl As Client)
        txtName.Text = String.Format("{0} {1}" & IIf(cl.Suffix <> "", ", " & cl.Suffix, ""), cl.FirstName, cl.LastName)

        dollarClient = cl
        btnSave.Focus()
    End Sub

    Private Function isValid() As Boolean
        If Not IsNumeric(txtRate.Text) Then txtRate.Focus() : Return False
        If cboDenomination.Text = "" Then cboDenomination.DroppedDown = True : Return False
        If txtTotal.Text = "" Then txtTotal.Focus() : Return False
        If txtSerial.Text = "" Then txtSerial.Focus() : Return False
        'If dollarClient Is Nothing Or Not txtName.Text.Contains(dollarClient.FirstName) Then MsgBox("Please select your client at the Client Management", MsgBoxStyle.Information) : txtName.Focus() : Return False
        If dollarClient Is Nothing Then MsgBox("Please select your client at the Client Management", MsgBoxStyle.Information) : txtName.Focus() : Return False

        Return True
    End Function

    Private Sub cboDenomination_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboDenomination.KeyPress
        If isEnter(e) Then
            txtName.Focus()
        End If
    End Sub

    Private Sub cboDenomination_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDenomination.SelectedIndexChanged
        If cboDenomination.Text = "" Or txtRate.Text = "" Then Exit Sub

        ComputeTotal()
    End Sub

    Private Sub ComputeTotal()
        If Not IsNumeric(txtRate.Text) Then Exit Sub

        Dim getAmount As Integer = cboDenomination.Text
        Dim getRate As Double = CDbl(txtRate.Text)
        Console.WriteLine("Rate: " & getRate)
        Console.WriteLine("Amount: " & getAmount)

        txtTotal.Text = "Php " & getRate * getAmount
    End Sub

    Private Sub ClearField()
        cboDenomination.SelectedItem = -1
        txtName.Text = ""
        txtSerial.Text = ""
        txtTotal.Text = ""
        txtRate.Text = ""
    End Sub

    Private Sub frmDollorSimple_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        web_ads.AdsDisplay = webAds
        web_ads.Ads_Initialization()

        ClearField()
        txtRate.Text = strRate
        cboDenomination.SelectedItem = 0
    End Sub

    Friend Sub LoadDollar(ByVal tmpDollar As DollarTransaction)
        With tmpDollar
            cboDenomination.Text = .Denomination
            txtTotal.Text = .NetAmount
            txtSerial.Text = .Serial
            LoadClient(.Customer)
        End With

        btnBrowse.Enabled = False
        btnSave.Enabled = False
        GroupBox1.Enabled = False
        txtName.Enabled = False

        If tmpDollar.Status = "V" Then
            Me.Text = "[VOID] " & Me.Text
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Not isValid() Then Exit Sub

        Dim ans As DialogResult = MsgBox("Do you want to save this transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        dollarEntry = New DollarTransaction
        With dollarEntry
            .CurrentRate = CDbl(txtRate.Text)
            .TransactionDate = CurrentDate
            .Customer = dollarClient
            .Denomination = cboDenomination.Text
            .Serial = txtSerial.Text
            .EncoderID = POSuser.EncoderID
            .NetAmount = txtTotal.Text.Substring(4)

            .SaveDollar()

            AddJournal(.NetAmount, "Debit", "Cash on Hand - Dollar", "Ref# " & .LastIDNumber)
            AddJournal(.NetAmount, "Credit", "Revolving Fund", "Ref# " & .LastIDNumber, "DOLLAR BUYING")

            AddTimelyLogs(MODULE_NAME, String.Format("{0} for Php {1} @ Php {2}", cboDenomination.Text, .NetAmount, .CurrentRate))
        End With

        MsgBox("Transaction Saved", MsgBoxStyle.Information)
        Me.Close()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        frmClient.SearchSelect(txtName.Text, FormName.frmDollarSimple)
        frmClient.Show()
    End Sub

    Private Sub txtName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtName.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        frmDollarList.Show()
    End Sub

    Private Sub txtSerial_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSerial.KeyPress
        If isEnter(e) Then
            txtName.Focus()
        End If
    End Sub

    Private Sub txtRate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRate.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txtRate_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRate.KeyUp
        ComputeTotal()
    End Sub
End Class