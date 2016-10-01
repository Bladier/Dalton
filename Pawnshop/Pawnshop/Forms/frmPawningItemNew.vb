﻿Imports Microsoft.Reporting.WinForms

Public Class frmPawningItemNew
    Friend transactionType As String = "L"
    Friend PT_Entry As New PawnTicket2 'Serve as Pawn Ticket
    Friend PawnedItem As New PawnItem 'Serve as Pawned Item
    Friend Pawner As New Client
    Friend Pawner_OtherClaimer As New Client

    Private ItemClasses_ht As Hashtable
    Private Appraisers_ht As Hashtable

    Private currentPawnTicket As Integer = GetOption("PawnLastNum")
    Private currentORNumber As Integer = GetOption("ORLastNum")

    Private LoanDate As Date, MaturityDate As Date, ExpiryDate As Date, AuctionDate As Date
    Private Appraisal As Double, Principal As Double, AdvanceInterest As Double, NetAmount As Double
    Private ORNum As Integer, ORDate As Date, DaysOverDue As Integer, PawnInterest As Double, PawnPenalty As Double, PawnServiceCharge As Double, eVat As Double = 0
    Private RenewDue As Double, RedeemDue As Double


    Private PRINTER_PT As String = GetOption("PrinterPT")
    Private PRINTER_OR As String = GetOption("PrinterOR")

    Const MOD_NAME As String = "PAWNING"
    Const ITEM_REDEEM As String = "REDEEM"
    Const ITEM_NEWLOAN As String = "NEW LOAN"
    Const ITEM_RENEW As String = "RENEW"
    Const HAS_ADVINT As Boolean = True
    Const PAUSE_OR As Boolean = False
    Const OR_COPIES As Integer = 2
    Const MONTH_COMPUTE As Integer = 4

    Private unableToSave As Boolean = False

    Private PRINT_PTOLD As Integer = 0
    Private PRINT_PTNEW As Integer = 0
    Private SAP_ACCOUNTCODE() As String = _
        {"_SYS00000000143",
        "_SYS00000001056",
        "_SYS00000000300",
        "_SYS00000000298",
        "_SYS00000001072",
        "_SYS00000001071",
        "_SYS00000000297"}

    Dim Critical_Language() As String =
            {"Failed to verify hash value to the "}
    'Private OTPDisable As Boolean = IIf(GetOption("OTP") = "YES", True, False)
    Private Reprint As Boolean = False

    Private Sub ClearFields()
        mod_system.isAuthorized = False

        txtCustomer.Text = ""
        txtAddr.Text = ""
        txtBDay.Text = ""
        txtContact.Text = ""
        'cboKarat.Text = ""

        txtTicket.Text = ""
        txtOldTicket.Text = ""
        txtLoan.Text = ""
        txtMatu.Text = ""
        txtExpiry.Text = ""
        txtAuction.Text = ""
        txtAppr.Text = ""
        txtPrincipal.Text = ""
        txtAdv.Text = ""
        txtNet.Text = ""

        txtReceipt.Text = ""
        txtReceiptDate.Text = ""
        txtPrincipal2.Text = ""
        txtOver.Text = ""
        txtPenalty.Text = ""
        txtService.Text = ""
        txtEvat.Text = ""
        txtRenew.Text = ""
        txtRedeem.Text = ""

        txtClassification.Text = ""
        txtClaimer.Clear()

    End Sub

    Private Sub LoadAppraisers()
        Dim mySql As String = "SELECT * FROM tbl_Gamit WHERE PRIVILEGE <> 'PDuNxp8S9q0=' AND STATUS <> 0"
        Dim ds As DataSet = LoadSQL(mySql)

        Appraisers_ht = New Hashtable
        cboAppraiser.Items.Clear()

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim u As New ComputerUser
            u.LoadUserByRow(dr)

            If u.canAppraise Then
                cboAppraiser.Items.Add(u.UserName)
                Appraisers_ht.Add(u.UserID, u)
            End If
        Next
    End Sub

    Private Sub btnSearchClassification_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchClassification.Click
        Dim secured_str As String = txtClassification.Text
        secured_str = DreadKnight(secured_str)
        frmItemList.SearchSelect(secured_str, FormName.Item)
        frmItemList.Show()
    End Sub

    Private Sub btnSearchClaimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchClaimer.Click
        Dim secured_str As String = txtClaimer.Text
        secured_str = DreadKnight(secured_str)
        frmClient.SearchSelect(secured_str, FormName.PawnClaimer)
        frmClient.Show()
    End Sub

    Friend Sub LoadClient(ByVal cl As Client)
        txtCustomer.Text = String.Format("{0} {1}" & IIf(cl.Suffix <> "", "," & cl.Suffix, ""), cl.FirstName, cl.LastName)
        txtAddr.Text = String.Format("{0} {1} " + vbCrLf + "{2}", cl.AddressSt, cl.AddressBrgy, cl.AddressCity)
        txtBDay.Text = cl.Birthday.ToString("MMM dd, yyyy")
        txtContact.Text = cl.Cellphone1 & IIf(cl.Cellphone2 <> "", ", " & cl.Cellphone2, "")

        Pawner = cl
        txtClassification.Focus()
    End Sub

    Friend Sub LoadCliamer(ByVal cl As Client)
        txtClaimer.Text = String.Format("{0} {1}" & IIf(cl.Suffix <> "", "," & cl.Suffix, ""), cl.FirstName, cl.LastName)
        Pawner_OtherClaimer = cl
    End Sub

    Friend Sub Load_ItemSpecification(ByVal Item As ItemClass)
        PawnedItem.ItemClass = Item
        txtClassification.Text = Item.ClassName

        ItemClasses_ht = New Hashtable
        lvSpec.Items.Clear()
        For Each spec As ItemSpecs In PawnedItem.ItemClass.ItemSpecifications
            Dim lv As ListViewItem = lvSpec.Items.Add(spec.SpecName)
            lv.SubItems.Add("")
            ItemClasses_ht.Add(spec.SpecID, spec.SpecName)
        Next

        lvSpec.Focus()
        lvSpec.Items(0).Selected = True
    End Sub

    Private Sub AddItem(ByVal cio As DataRow)
        Dim tmpItem As New ItemSpecs
        tmpItem.LoadItemSpecs_row(cio)

        Dim lv As ListViewItem = lvSpec.Items.Add(tmpItem.SpecID)
        lv.SubItems.Add(tmpItem.SpecName)
        lv.SubItems.Add(tmpItem.SpecLayout)
        lv.SubItems.Add(tmpItem.SpecType)
        lv.SubItems.Add("")
        'lv.SubItems.Add(tmpCIO.Amount)
        'lv.SubItems.Add(tmpCIO.Particulars)
        lv.Tag = tmpItem.SpecID

    End Sub

    Private Sub lvSpec_ColumnWidthChanging(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnWidthChangingEventArgs) Handles lvSpec.ColumnWidthChanging
        If Me.lvSpec.Columns(e.ColumnIndex).Width = 0 Then
            e.Cancel = True
            e.NewWidth = Me.lvSpec.Columns(e.ColumnIndex).Width
        End If
    End Sub

    Friend Sub DisplayValue(value As String, id As Integer)
        lvSpec.Items(id).SubItems(1).Text = value
    End Sub

    Private Sub InputSpec()
        If lvSpec.SelectedItems.Count = 0 Then Exit Sub

        Dim tmpSpec As New ItemSpecs
        Dim idx As Integer = lvSpec.FocusedItem.Index
        Dim selectedID As Integer = GetIDbyName(lvSpec.FocusedItem.Text, ItemClasses_ht)
        tmpSpec.LoadItemSpecs(selectedID)

        Select Case tmpSpec.SpecLayout
            Case "TextBox"
                frm_PanelTextbox.retID = idx
                frm_PanelTextbox.inputType = tmpSpec.SpecType
                frm_PanelTextbox.ShowDialog()
            Case "Yes/No"
                frm_PanelYesNo.retID = idx
                frm_PanelYesNo.ShowDialog()
            Case "MultiLine"
                frm_PanelMultiline.retID = idx
                frm_PanelMultiline.ShowDialog()
        End Select
    End Sub

    Private Sub lvSpec_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvSpec.KeyPress
        If isEnter(e) Then
            InputSpec()
        End If
    End Sub

    Private Sub lvSpec_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvSpec.DoubleClick
        InputSpec()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SaveNewLoan()
    End Sub

    Private Sub SaveNewLoan()

        ' SAVING PAWNED ITEM INFORMATION ================================
        ' Saving Pawned Item Specification
        Dim i As Integer = 0
        Dim PawnSpecs As New CollectionPawnItemSpecs
        For Each ItmSpc As ItemSpecs In PawnedItem.ItemClass.ItemSpecifications
            Dim pwnSpec As New PawnItemSpec
            pwnSpec.UnitOfMeasure = ItmSpc.UnitOfMeasure
            pwnSpec.SpecName = ItmSpc.SpecName
            pwnSpec.SpecType = ItmSpc.SpecType
            pwnSpec.SpecsValue = lvSpec.Items(i).SubItems(1).Text
            pwnSpec.isRequired = ItmSpc.isRequired

            PawnSpecs.Add(pwnSpec)
            i += 1
        Next
        PawnedItem.PawnItemSpecs = PawnSpecs
        ' END - SAVING PAWNED ITEM INFORMATION ===========================

        ' SAVING PAWN TICKET
        With PT_Entry
            .Pawner = Pawner
            .PawnItem = PawnedItem

            .PawnTicket = currentPawnTicket
            .LoanDate = txtLoan.Text
        End With

    End Sub


    Private Sub dateChange(selectedClass As ItemClass)
        Select Case selectedClass.Category
            Case "GADGET"
                txtExpiry.Text = txtMatu.Text
                txtAuction.Text = CurrentDate.AddDays(62).ToShortDateString
            Case Else
                txtExpiry.Text = CurrentDate.AddDays(119).ToShortDateString
                txtAuction.Text = CurrentDate.AddDays(152).ToShortDateString
        End Select

        ReComputeInterest()
    End Sub

    Private Sub Assembling_Transactions()

    End Sub


    Private Sub ReComputeInterest()
        Dim intHash As String = ""

        If transactionType = "D" Then Exit Sub 'Display No Recommute
        If txtMatu.Text = "" Then Exit Sub 'No Maturity Date

        Dim itemPrincipal As Double, isDPJ As Boolean = False

        If txtPrincipal.Text = "" Or Not IsNumeric(txtPrincipal.Text) Then
            itemPrincipal = 0
        Else
            itemPrincipal = CDbl(txtPrincipal.Text)
        End If

        Dim matuDateTmp
        If Not PT_Entry Is Nothing Then
            ' Not for new Loan
            'If PawnItem.AdvanceInterest <> 0 Then isDPJ = True
            'matuDateTmp = PawnItem.MaturityDate
            'intHash = PawnItem.INT_Checksum
        Else
            'New Loan
            isDPJ = True
            matuDateTmp = CDate(txtMatu.Text)
            intHash = TBLINT_HASH
        End If
        daltonCompute = New PawnCalculation(itemPrincipal, txtClassification.Text, CurrentDate, matuDateTmp, isDPJ, intHash)

        With daltonCompute
            daysDue = .DaysOverDue
            Net_Amount = .NetAmount
            AdvanceInterest = .AdvanceInterest
            ServiceCharge = .ServiceCharge
            DelayInt = .Interest
            Penalty = .Penalty
            Renew_Due = .RenewDue
            Redeem_Due = .RedeemDue

            isOldItem = Not isDPJ
            isEarlyRedeem = .isEarlyRedeem

        End With

        txtNet.Text = Net_Amount.ToString("Php #,##0.00")

        'Display Advance Interest for Renew and New Loan
        If HAS_ADVINT And (transactionType = "R" Or transactionType = "L") Then
            txtAdv.Text = AdvanceInterest.ToString("#,##0.00")
        End If

        If isDPJ Then
            'New Items
            If transactionType = "X" Then
                ' Redeem
                txtService.Text = 0
            Else
                'Non Redeem
                txtService.Text = ServiceCharge.ToString("#,##0.00")
            End If
        Else
            'Remantic
            txtService.Text = ServiceCharge.ToString("#,##0.00")
        End If

        'Non New Loan
        If transactionType <> "L" Then
            txtOver.Text = daysDue
            If daysDue <= 3 Then
                If DelayInt > AdvanceInterest Then
                    DelayInt -= AdvanceInterest
                Else
                    DelayInt = 0
                End If
                Penalty = 0
            Else
                If DelayInt > AdvanceInterest And transactionType <> "X" Then _
                    DelayInt -= AdvanceInterest
            End If

            If transactionType = "X" Then
                txtRenew.Text = 0
                txtRedeem.Text = Redeem_Due.ToString("Php #,##0.00")
                If daysDue > 3 Then DelayInt -= AdvanceInterest
            ElseIf transactionType = "R" Then
                txtRenew.Text = Renew_Due.ToString("Php #,##0.00")
                txtRedeem.Text = 0
                'DelayInt -= AdvanceInterest
            End If

            txtInt.Text = DelayInt.ToString("#,##0.00")
            txtPenalty.Text = Penalty.ToString("#,##0.00")
        End If
    End Sub

    Private Function CurrentPTNumber(Optional ByVal num As Integer = 0) As String
        Return String.Format("{0:000000}", If(num = 0, currentPawnTicket, num))
    End Function

    Private Function CurrentOR() As String
        Return String.Format("{0:000000}", currentORNumber)
    End Function

    ''' <summary>
    ''' This is call when you wanted to generate new PawnTicket Number Sequence
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GeneratePT()
        'Check PT if existing
        Dim mySql As String, ds As DataSet
        mySql = "SELECT * FROM tblPAWN "
        mySql &= "WHERE PAWNTICKET = '" & currentPawnTicket & "'"
        ds = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count >= 1 Then _
            MsgBox("PT# " & currentPawnTicket.ToString("000000") & " already existed.", MsgBoxStyle.Critical) : unableToSave = True : Exit Sub

        txtTicket.Text = CurrentPTNumber()
        txtLoan.Text = CurrentDate.ToShortDateString
        txtMatu.Text = CurrentDate.AddDays(29).ToShortDateString
        'dateChange(txtClassification.Text)

        If transactionType = "R" Then
            txtTicket.Text = CurrentPTNumber(GetOption("PawnLastNum"))
            txtOldTicket.Text = CurrentPTNumber(PT_Entry.PawnTicket)
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim secured_str As String = txtCustomer.Text
        secured_str = DreadKnight(secured_str)
        frmClient.SearchSelect(secured_str, FormName.NewPawning)
        frmClient.Show()
    End Sub

    Private Sub txtClassification_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtClassification.KeyPress
        If isEnter(e) Then
            btnSearchClassification.PerformClick()
        End If
    End Sub

    Private Sub txtPrincipal_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPrincipal.KeyUp
        ReComputeInterest()
    End Sub

    Private Sub frmPawningItemNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
        LoadAppraisers()
        'If transactionType = "L" Then NewLoan()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub txtCustomer_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCustomer.KeyDown
        If e.KeyCode = 13 Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub lvSpec_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvSpec.SelectedIndexChanged

    End Sub
End Class