﻿Public Class frmNewloan

    Dim Pawner As Client
    Dim PawnItem As PawnTicket, VoidPawnItem As PawnTicket
    Dim currentPawnTicket As Integer = GetLastNum()
    Dim currentOR As Integer = GetORNum()
    Dim transactionType As String

    Private Function GetORNum() As Integer
        Return GetOption("ORLastNum")
    End Function

    Private Function GetLastNum() As Integer
        Return GetOption("PawnLastNum")
    End Function

    Private Sub LoadItemType()
        Dim itmType As String() = {"JWL", "APP", "BIG", "CEL"}
        cboItemtype.Items.Clear()
        cboItemtype.Items.AddRange(itmType)
    End Sub

    Private Sub ItemType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItemtype.SelectedIndexChanged
        cboCategory.Items.Clear()
        cboCategory.Text = ""
        'Enable Grams and Karat
        If cboItemtype.SelectedItem = "JWL" Then
            txtGrams.ReadOnly = False
            cboKarat.Enabled = True
        Else
            txtGrams.ReadOnly = True
            cboKarat.Enabled = False
        End If
        'Sub Category
        If cboItemtype.SelectedItem = "APP" Then
            cboCategory.Items.Add("CAMERA")
            cboCategory.Items.Add("CARPENTRY TOOLS")
            cboCategory.Items.Add("HOME APP-SMALL")
            cboCategory.Items.Add("LAPTOP")
            cboCategory.Items.Add("NOTEBOOK")

        ElseIf cboItemtype.SelectedItem = "BIG" Then
            cboCategory.Items.Add("BIKE")
            cboCategory.Items.Add("HOME APP-BIG")
            cboCategory.Items.Add("MOTORCYCLE")

        ElseIf cboItemtype.SelectedItem = "CEL" Then
            cboCategory.Items.Add("CELLPHONE")
            cboCategory.Items.Add("TABLET")

        ElseIf cboItemtype.SelectedItem = "JWL" Then
            cboCategory.Items.Add("ANKLET")
            cboCategory.Items.Add("BANGLE")
            cboCategory.Items.Add("BRACELET")
            cboCategory.Items.Add("BROUCH")
            cboCategory.Items.Add("EARRINGS")
            cboCategory.Items.Add("NECKLACE")
            cboCategory.Items.Add("PENDANT")
            cboCategory.Items.Add("RING")
        End If

        'Dates
        'LoanDate.Value = Date.Now
        Maturity.Value = LoanDate.Value.AddDays(29)
        If cboItemtype.SelectedItem = "CEL" Then
            Expiry.Value = Maturity.Value
            Auction.Value = LoanDate.Value.AddDays(63)
        Else
            Expiry.Value = LoanDate.Value.AddDays(89)
            Auction.Value = LoanDate.Value.AddDays(123)
        End If
    End Sub

    Private Sub LoadAppraisers()
        Dim users() As String = {"Eskie", "Frances", "Mai2", "Jayr"}
        cboAppraiser.Items.Clear()
        cboAppraiser.Items.AddRange(users)
    End Sub

    Private Sub btnSearchSender_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        frmClient.SearchSelect(txtPawner.Text, FormName.frmPawning)
        frmClient.Show()
    End Sub

    Private Sub txtPawner_KeyPress(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPawner.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub txtGrams_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGrams.KeyPress
        DigitOnly(e)
        If isEnter(e) Then
            cboKarat.Focus()
        End If
    End Sub

    Private Sub txtAppraisal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAppraisal.KeyPress
        DigitOnly(e)
        If isEnter(e) Then
            txtPrincipal.Focus()
        End If
    End Sub

    Private Sub txtAppraisal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAppraisal.TextChanged
        txtTotal.Text = txtAppraisal.Text
        txtPrincipal.Text = txtAppraisal.Text
    End Sub

    Private Sub txtPawner_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPawner.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub txtless_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        DigitOnly(e)
    End Sub

    Private Sub frmNewloan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F4
                Console.WriteLine("Renewal")
                'Renewal()
                SwitchTransaction("RENEW")
            Case Keys.F5
                Console.WriteLine("Redeem")
                'Redeem()
                SwitchTransaction("REDEEM")
        End Select
    End Sub

    Private Sub frmNewloan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

    End Sub

    Private Sub frmNewloan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If IsNothing(Pawner) Then
            ClearFields()
            LoadAppraisers()
            NewLoan()
        End If
    End Sub

    Friend Sub NewLoan()
        transactionType = "L"
        Me.Text = "New Loan"
        lblTitle.Text = "New Loan"

        ' Pawner
        txtPawner.ReadOnly = False
        txtPawner.Focus()

        ' Item Information
        cboItemtype.Enabled = True
        txtDesc.ReadOnly = False
        cboCategory.Enabled = True
        txtGrams.ReadOnly = False
        txtGrams.Text = ""
        cboKarat.Enabled = True
        cboKarat.Text = ""

        ' Ticket Information
        LoanDate.Value = CurrentDate
        Maturity.Value = LoanDate.Value.AddDays(29) : Maturity.Enabled = False
        If cboItemtype.Text = "CEL" Then
            Expiry.Value = Maturity.Value : Expiry.Enabled = False
            Auction.Value = LoanDate.Value.AddDays(63) : Auction.Enabled = False
        Else
            Expiry.Value = LoanDate.Value.AddDays(89) : Expiry.Enabled = False
            Auction.Value = LoanDate.Value.AddDays(123) : Auction.Enabled = False
        End If
        txtAppraisal.ReadOnly = False
        txtPrincipal.ReadOnly = False
        txtTotal.BackColor = System.Drawing.SystemColors.Window

        ' Receipt Information
        grpReceipt.Enabled = False
        txtRefNo.ReadOnly = False
        dtpDate.Value = CurrentDate
        txtAppr.ReadOnly = False
        txtOverDue.ReadOnly = False
        txtDelayInt.ReadOnly = False
        txtPenalty.ReadOnly = False
        txtSrvChrg.ReadOnly = False
        txtEvat.ReadOnly = False
        txtRenewDue.ReadOnly = False
        txtRedeemDue.ReadOnly = False

        cboAppraiser.Text = ""
        cboAppraiser.Enabled = True

        LoadCurrentPawnTicket()

        btnRedeem.Enabled = False
        btnRenew.Enabled = False
    End Sub

    Friend Sub LoadPawnTicket(ByVal tk As PawnTicket, ByVal tt As String)
        transactionType = tt

        ' Pawner
        LoadPawnerInfo(tk.Pawner)
        Pawner = tk.Pawner
        btnSearch.Enabled = False

        ' Item Information
        cboItemtype.Text = tk.ItemType
        txtDesc.Text = tk.Description
        cboCategory.Text = GetCategoryByID(tk.CategoryID)
        txtGrams.Text = IIf(tk.Grams = 0, "", tk.Grams)
        cboKarat.Text = tk.Karat
        txtAppraisal.Text = tk.Appraisal
        txtPrincipal.Text = tk.Principal
        txtTotal.Text = tk.NetAmount

        ' Ticket Information
        txtTicket.Text = String.Format("{0:000000}", tk.PawnTicket)
        txtNticket.Text = IIf(tk.OldTicket = 0, String.Format("{0:000000}", 0), String.Format("{0:000000}", tk.OldTicket))
        LoanDate.Value = tk.LoanDate
        Maturity.Value = tk.MaturityDate
        Expiry.Value = tk.ExpiryDate
        Auction.Value = tk.AuctionDate
        txtAppraisal.Text = tk.Appraisal
        txtPrincipal.Text = tk.Principal

        ' Receipt Information
        txtRefNo.Text = tk.OfficialReceiptNumber
        dtpDate.Value = IIf(tk.OfficialReceiptDate = #12:00:00 AM#, dtpDate.MinDate, tk.OfficialReceiptDate)
        txtAppr.Text = tk.Appraisal
        txtOverDue.Text = tk.DaysOverDue
        txtDelayInt.Text = tk.DelayInterest
        txtPenalty.Text = tk.Penalty
        txtSrvChrg.Text = tk.ServiceCharge
        txtEvat.Text = tk.EVAT
        txtRenewDue.Text = tk.RenewDue
        txtRedeemDue.Text = tk.RedeemDue

        LoadAppraisers()
        cboAppraiser.Text = GetAppraiserById(tk.AppraiserID)

        PawnItem = tk

        Select Case tt
            Case "D" 'Display
                ' Pawner
                txtPawner.ReadOnly = True

                ' Item Information
                cboItemtype.Enabled = False
                txtDesc.ReadOnly = True
                cboCategory.Enabled = False
                txtGrams.ReadOnly = True
                cboKarat.Enabled = False

                ' Ticket Information
                Maturity.Enabled = False
                Expiry.Enabled = False
                Auction.Enabled = False
                txtAppraisal.ReadOnly = True
                txtPrincipal.ReadOnly = True

                ' Receipt Information
                grpReceipt.Enabled = False

                cboAppraiser.Enabled = False
                btnSave.Enabled = False
                btnRedeem.Visible = True
                btnRenew.Visible = True

                Dim st As String = "N/A"
                Select Case tk.Status
                    Case "0"
                        st = "Inactive"
                    Case "L"
                        st = "Active"
                    Case "X"
                        st = "Redeemed"
                    Case "R"
                        st = "Renewed"
                    Case "W"
                        st = "Withdrawed"
                    Case "S"
                        st = "Segregated"
                    Case "V"
                        st = "Void"
                End Select

                Me.Text = "Pawn Ticket Number " & tk.PawnTicket & " [" & st & "]"
                lblTitle.Text = "Display"

                ' Disable renew
                If tk.Status = "0" Or tk.Status = "V" Or tk.Status = "W" Or tk.Status = "S" Or tk.Status = "X" Then
                    btnRenew.Enabled = False
                    btnRedeem.Enabled = False
                End If

                ' Activate Void
                If tk.Status = "L" Or tk.Status = "R" Or tk.Status = "W" Then
                    btnVoid.Enabled = True
                End If
                If tk.Status = "V" Then
                    If GetOldPT() <> Nothing Then
                        lblVOID.Text = "New Ticket: " & GetOldPT()
                        lblVOID.Visible = True
                        btnVoid.Visible = False
                    End If
                End If

                ' Activate Cancel
                If tk.Status = "X" Then
                    btnVoid.Enabled = True
                    btnVoid.Text = "CANCEL"
                End If
        End Select
    End Sub

    Friend Sub LoadPawnerInfo(ByVal cl As Client)
        txtPawner.Text = String.Format("{0} {1} {2} {3}", cl.FirstName, cl.MiddleName, cl.LastName, cl.Suffix)
        txtAddress.Text = String.Format("{0} {1} {2}, {3}" & vbCrLf & "{4}", cl.AddressSt, cl.AddressBrgy, cl.AddressProvince, cl.AddressCity, cl.ZipCode)
        txtBDay.Text = cl.Birthday.ToString("MMM dd, yyyy")
        lblAge.Text = GetCurrentAge(DateTime.Parse(txtBDay.Text)) & " years old"
        txtPhone.Text = cl.Cellphone1 & IIf(cl.Cellphone2 <> "", ", " & cl.Cellphone2, "") & IIf(cl.Telephone <> "", ", " & cl.Telephone, "")

        cboItemtype.Focus()
        Pawner = cl
    End Sub

    Private Sub LoadCurrentPawnTicket()
        txtTicket.Text = String.Format("{0:000000}", currentPawnTicket)
    End Sub

    Private Sub ClearFields()
        ' Pawner
        txtPawner.Text = ""
        txtAddress.Text = ""
        txtBDay.Text = ""
        txtPhone.Text = ""
        lblAge.Text = "-"

        ' Item Information
        txtDesc.Text = ""
        cboItemtype.SelectedIndex = -1
        cboCategory.SelectedIndex = -1
        ' Jewel
        txtGrams.Text = ""
        cboKarat.Text = ""

        ' Ticket Information
        txtTicket.Text = ""
        txtNticket.Text = ""
        LoanDate.Value = CurrentDate
        Maturity.Value = LoanDate.Value.AddDays(29)
        Expiry.Value = LoanDate.Value.AddDays(89)
        Auction.Value = LoanDate.Value.AddDays(123)
        txtAppraisal.Text = ""
        txtPrincipal.Text = ""
        txtTotal.Text = ""

        ' Receipt Information
        txtRefNo.Text = ""
        dtpDate.Value = CurrentDate
        txtAppr.Text = ""
        txtOverDue.Text = ""
        txtDelayInt.Text = ""
        txtPenalty.Text = ""
        txtSrvChrg.Text = ""
        txtEvat.Text = ""
        txtRenewDue.Text = ""
        txtRedeemDue.Text = ""

        cboAppraiser.SelectedIndex = -1
        LoadCurrentPawnTicket()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        'frmPawning.LoadActive()
        Me.Close()
    End Sub

    Private Sub cboKarat_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboKarat.KeyPress
        If isEnter(e) Then
            txtAppraisal.Focus()
        End If
    End Sub

    Private Sub cboKarat_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboKarat.LostFocus
        txtAppraisal.Focus()
    End Sub

    Private Sub txtPrincipal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrincipal.KeyPress
        DigitOnly(e)
        If isEnter(e) Then
            txtTotal.Focus()
        End If
    End Sub

    Private Sub txtPrincipal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrincipal.TextChanged
        txtTotal.Text = txtPrincipal.Text
    End Sub

    Private Function checkPayments() As Boolean
        If transactionType = "L" Then
            If CDbl(txtPrincipal.Text) > CDbl(txtAppraisal.Text) Then txtPrincipal.Focus() : Return False
            If CDbl(txtTotal.Text) > CDbl(txtPrincipal.Text) Then txtTotal.Focus() : Return False

            Return True
        End If

        Dim shouldPay As Double = CDbl(txtRedeemDue.Text)
        If CDbl(txtTotal.Text) > shouldPay Then Return False

        Return True
    End Function

    Private Function CompleteFields() As Boolean
        Dim ret As Boolean = True

        If cboItemtype.Text = "" Then cboItemtype.Focus() : ret = False
        If cboCategory.Text = "" Then cboCategory.Focus() : ret = False

        'Jewel
        If cboItemtype.Text = "JWL" Then
            If txtGrams.Text = "" Then txtGrams.Focus() : ret = False
            If cboKarat.Text = "" Then cboKarat.Focus() : ret = False
        End If

        ' Ticket
        If txtAppraisal.Text = "" Then txtAppraisal.Focus() : ret = False
        If txtPrincipal.Text = "" Then txtPrincipal.Focus() : ret = False
        If txtTotal.Text = "" Then txtTotal.Focus() : ret = False

        If cboAppraiser.Text = "" Then cboAppraiser.Focus() : ret = False

        Return ret
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Not CompleteFields() Then Exit Sub

        If Not checkPayments() Then
            MsgBox("Check payment", MsgBoxStyle.Critical, "Payment Problem")
            Exit Sub
        End If

        Dim newPawnItem As New PawnTicket
        With newPawnItem
            .PawnTicket = txtTicket.Text
            .Pawner = Pawner
            .LoanDate = LoanDate.Value
            .MaturityDate = Maturity.Value
            .ExpiryDate = Expiry.Value
            .AuctionDate = Auction.Value
            .ItemType = cboItemtype.Text
            .CategoryID = GetCategoryID(cboCategory.Text)
            .Description = txtDesc.Text
            If cboItemtype.Text = "JWL" Then
                .Karat = cboKarat.Text
                .Grams = txtGrams.Text
            End If
            .Appraisal = txtAppraisal.Text
            If transactionType = "R" Then
                If CDbl(txtRedeemDue.Text) - CDbl(txtTotal.Text) < 0 Then
                    Dim lessPrin As Double
                    lessPrin = Math.Abs(CDbl(txtRenewDue.Text) - CDbl(txtTotal.Text))
                    .Principal = CDbl(txtPrincipal.Text) - lessPrin
                Else
                    .Principal = txtPrincipal.Text
                End If
            End If
            .NetAmount = txtTotal.Text
            .AppraiserID = GetAppraiserID(cboAppraiser.Text)
            .Status = transactionType
            If transactionType <> "L" Then
                .Interest = txtDelayInt.Text
                .OldTicket = txtNticket.Text
                .OfficialReceiptNumber = txtRefNo.Text
                .OfficialReceiptDate = dtpDate.Value
                .EVAT = txtEvat.Text
                .DaysOverDue = txtOverDue.Text
                .DelayInterest = txtDelayInt.Text
                .Penalty = txtPenalty.Text
                .ServiceCharge = txtSrvChrg.Text
                .RenewDue = txtRenewDue.Text
                .RedeemDue = txtRedeemDue.Text
            End If

            .SaveTicket()
            currentPawnTicket += 1
            database.UpdateOptions("PawnLastNum", CInt(currentPawnTicket))
        End With

        Select Case transactionType
            Case "R"
                PawnItem.RedeemTicket()
                currentOR += 1
                database.UpdateOptions("", CInt(currentOR))
        End Select

        Dim ans As DialogResult = MsgBox("Do you want to enter more?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then
            frmPawning.LoadActive()
            Me.Close()
        Else
            NewLoan()
            txtPawner.Focus()
        End If
    End Sub

    Private Sub RedeemPawnTicket()
        Dim mySql As String = "SELECT * FROM TBLPAWN WHERE pawnID = " & PawnItem.PawnID
        Dim ds As DataSet = LoadSQL(mySql, "tblPawn")
        ds.Tables("tblPawn").Rows(0).Item("Status") = "X"
        ds.Tables("tblPawn").Rows(0).Item("EncoderID") = UserID
        database.SaveEntry(ds)

        MsgBox(String.Format("Pawn Ticket: {0} redeem", PawnItem.PawnTicket), MsgBoxStyle.Information, "Thank you")
        frmPawning.LoadActive()
        Me.Close()
    End Sub

    Private Sub RenewPawnTicket(ByVal id As Integer)
        Dim ds As DataSet, tbl As String = "tblPawn"
        ds = LoadSQL("SELECT * FROM TBLPAWN WHERE PawnId = " & id, "tblPawn")

        ds.Tables(tbl).Rows(0).Item("STATUS") = 0
        ds.Tables(tbl).Rows(0).Item("EncoderID") = UserID
        database.SaveEntry(ds, False)
    End Sub

    Private Function GetCategoryByID(ByVal id As Integer) As String
        Dim cat() As String
        cat = {"CAMERA", "CARPENTRY TOOLS", "HOME APP-SMALL", "LAPTOP", "NOTEBOOK", _
               "BIKE", "HOME APP-BIG", "MOTORCYCLE", "CELLPHONE", "TABLET", "ANKLET", _
               "BANGLE", "BRACELET", "BROUCH", "EARRINGS", "NECKLACE", "PENDANT", "RING"}
        Return cat(id)
    End Function

    Private Function GetCategoryID(ByVal typ As String) As Integer
        ' Must be in the database
        Select Case typ
            Case "CAMERA" : Return 0
            Case "CARPENTRY TOOLS" : Return 1
            Case "HOME APP-SMALL" : Return 2
            Case "LAPTOP" : Return 3
            Case "NOTEBOOK" : Return 4
            Case "BIKE" : Return 5
            Case "HOME APP-BIG" : Return 6
            Case "MOTORCYCLE" : Return 7
            Case "CELLPHONE" : Return 8
            Case "TABLET" : Return 9
            Case "ANKLET" : Return 10
            Case "BANGLE" : Return 11
            Case "BRACELET" : Return 12
            Case "BROUCH" : Return 13
            Case "EARRINGS" : Return 14
            Case "NECKLACE" : Return 15
            Case "PENDANT" : Return 16
            Case "RING" : Return 17
            Case Else : Return 99
        End Select
    End Function

    Private Function GetAppraiserById(ByVal id As Integer) As String
        Dim app() As String
        app = {"Eskie", "Frances", "Mai2", "Jayr"}

        Return app(id)
    End Function

    Private Function GetAppraiserID(ByVal name As String) As Integer
        Select Case name
            Case "Eskie" : Return 0
            Case "Frances" : Return 1
            Case "Mai2" : Return 2
            Case "Jayr" : Return 3
            Case Else
                Return 99
        End Select
    End Function

    Private Sub cboCategory_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCategory.KeyPress
        If isEnter(e) Then
            txtDesc.Focus()
        End If
    End Sub

    Private Sub cboAppraiser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboAppraiser.KeyPress
        If isEnter(e) And cboAppraiser.Text <> "" Then
            AddAuthentication()
        End If
    End Sub

    Private Sub AddAuthentication()
        btnSave.PerformClick()
    End Sub

    Private Sub btnRenew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRenew.Click
        If btnRenew.Text <> "&Renew" Then
            btnRenew.Text = "&Renew"
            CancelTrans()
            transactionType = "D"
            Exit Sub
        End If
        If transactionType = "D" Then
            SwitchTransaction("RENEW")
        Else
            MsgBox("Please cancel current transaction mode", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub CancelTrans()
        LoadPawnTicket(PawnItem, "D")
        txtTotal.ReadOnly = True
    End Sub

    'Friend Sub Renewal()
    '    If transactionType = "L" Then Exit Sub

    '    transactionType = "R"

    '    'Buttons
    '    btnRenew.Text = "C&ancel"
    '    btnRedeem.Text = "R&edeem"
    '    btnSave.Enabled = True

    '    grpPawner.Enabled = False
    '    grpItem.Enabled = False
    '    grpTicket.Enabled = True
    '    txtTicket.ReadOnly = True
    '    txtNticket.ReadOnly = True
    '    LoanDate.Enabled = False
    '    Maturity.Enabled = False
    '    Expiry.Enabled = False
    '    Auction.Enabled = False
    '    txtAppraisal.ReadOnly = True
    '    txtPrincipal.ReadOnly = True
    '    txtTotal.ReadOnly = False

    '    grpReceipt.Enabled = True

    '    'Ticket Information
    '    txtTicket.Text = String.Format("{0:000000}", currentPawnTicket)
    '    txtNticket.Text = String.Format("{0:000000}", PawnItem.PawnTicket)
    '    LoanDate.Value = CurrentDate
    '    Maturity.Value = LoanDate.Value.AddDays(29) : Maturity.Enabled = False
    '    If PawnItem.ItemType = "CEL" Then
    '        Expiry.Value = Maturity.Value : Expiry.Enabled = False
    '        Auction.Value = LoanDate.Value.AddDays(63) : Auction.Enabled = False
    '    Else
    '        Expiry.Value = LoanDate.Value.AddDays(89) : Expiry.Enabled = False
    '        Auction.Value = LoanDate.Value.AddDays(123) : Auction.Enabled = False
    '    End If
    '    txtAppraisal.Text = PawnItem.Appraisal
    '    txtPrincipal.Text = PawnItem.Principal

    '    txtRefNo.Text = String.Format("{0:000000}", currentOR)
    '    dtpDate.Value = CurrentDate
    '    txtAppr.Text = PawnItem.Appraisal
    '    Dim diff = CurrentDate - PawnItem.MaturityDate
    '    If diff.Days > 0 Then
    '        txtOverDue.Text = diff.Days
    '    Else
    '        txtOverDue.Text = 0
    '    End If
    '    txtDelayInt.Text = GetInterest(PawnItem.Principal)
    '    txtPenalty.Text = GetPenalty(PawnItem.Principal)
    '    txtSrvChrg.Text = GetServiceCharge(PawnItem.Principal)
    '    txtEvat.Text = GetOption("Evat") ' No EVAT implemented

    '    txtRenewDue.Text = CDbl(txtDelayInt.Text) + CDbl(txtPenalty.Text) + CDbl(txtSrvChrg.Text)
    '    txtRedeemDue.Text = CDbl(txtDelayInt.Text) + CDbl(txtPenalty.Text) + CDbl(txtSrvChrg.Text) + CDbl(PawnItem.Appraisal)

    '    txtTotal.Text = txtRenewDue.Text ' Total
    '    txtTotal.Focus()
    '    txtTotal.SelectAll()
    'End Sub

    Private Function GetServiceCharge(ByVal principal As Double) As Double
        Dim srvPrin As Double = CDbl(txtPrincipal.Text)
        Dim ret As Double = 0

        If srvPrin < 500 Then
            ret = srvPrin * 0.01
        Else
            ret = 5
        End If

        Return ret
    End Function

    Private Function GetPenalty(ByVal principal As Double) As Double
        Dim rate As Double
        Dim diff = CurrentDate - PawnItem.LoanDate
        rate = GetPawnshop(diff.Days, PawnItem.ItemType, "Penalty")

        Return rate * principal
    End Function

    Private Function GetInterest(ByVal principal As Double) As Double
        Dim int As Double
        Dim diff = CurrentDate - PawnItem.LoanDate
        int = GetPawnshop(diff.Days, PawnItem.ItemType)

        Console.WriteLine("GetInterest")
        Console.WriteLine("Loan: " & PawnItem.LoanDate)
        Console.WriteLine("Matu: " & PawnItem.MaturityDate)
        Console.WriteLine("Date: " & CurrentDate)
        Console.WriteLine("Day: " & diff.Days + 1)
        Console.WriteLine("Int: " & int)
        Console.WriteLine("Prin: " & principal)
        Console.WriteLine("NetDue: " & int * principal)

        Return principal * int
    End Function

    Private Sub txtTotal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotal.KeyPress
        DigitOnly(e)
        If (transactionType = "R" Or transactionType = "X") And isEnter(e) Then
            btnSave.PerformClick()
        End If
        If transactionType = "L" Then
            cboAppraiser.Focus()
        End If
    End Sub

    Private Sub btnRedeem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRedeem.Click
        If btnRedeem.Text <> "R&edeem" Then
            btnRedeem.Text = "R&edeem"
            CancelTrans()
            transactionType = "D"
            Exit Sub
        End If
        If transactionType = "D" Then
            SwitchTransaction("REDEEM")
        Else
            MsgBox("Please cancel current transaction mode", MsgBoxStyle.Information)
        End If
    End Sub

    Friend Sub SwitchTransaction(ByVal typ As String)
        If transactionType = "L" Then Exit Sub

        'Buttons
        btnSave.Enabled = True

        grpPawner.Enabled = False
        grpItem.Enabled = False
        grpTicket.Enabled = True
        txtTicket.ReadOnly = True
        txtNticket.ReadOnly = True
        LoanDate.Enabled = False
        Maturity.Enabled = False
        Expiry.Enabled = False
        Auction.Enabled = False
        txtAppraisal.ReadOnly = True
        txtPrincipal.ReadOnly = True
        txtTotal.ReadOnly = False

        grpReceipt.Enabled = True

        'Ticket Information
        txtTicket.Text = String.Format("{0:000000}", currentPawnTicket)
        txtNticket.Text = String.Format("{0:000000}", PawnItem.PawnTicket)
        LoanDate.Value = CurrentDate
        Maturity.Value = LoanDate.Value.AddDays(29) : Maturity.Enabled = False
        If PawnItem.ItemType = "CEL" Then
            Expiry.Value = Maturity.Value : Expiry.Enabled = False
            Auction.Value = LoanDate.Value.AddDays(63) : Auction.Enabled = False
        Else
            Expiry.Value = LoanDate.Value.AddDays(89) : Expiry.Enabled = False
            Auction.Value = LoanDate.Value.AddDays(123) : Auction.Enabled = False
        End If
        txtAppraisal.Text = PawnItem.Appraisal
        txtPrincipal.Text = PawnItem.Principal

        txtRefNo.Text = String.Format("{0:000000}", currentOR)
        dtpDate.Value = CurrentDate
        txtAppr.Text = PawnItem.Appraisal
        Dim diff = CurrentDate - PawnItem.MaturityDate
        If diff.Days > 0 Then
            txtOverDue.Text = diff.Days
        Else
            txtOverDue.Text = 0
        End If
        txtDelayInt.Text = GetInterest(PawnItem.Principal)
        txtPenalty.Text = GetPenalty(PawnItem.Principal)
        txtSrvChrg.Text = GetServiceCharge(PawnItem.Principal)
        txtEvat.Text = GetOption("Evat") ' No EVAT implemented

        txtRenewDue.Text = CDbl(txtDelayInt.Text) + CDbl(txtPenalty.Text) + CDbl(txtSrvChrg.Text)
        txtRedeemDue.Text = CDbl(txtDelayInt.Text) + CDbl(txtPenalty.Text) + CDbl(txtSrvChrg.Text) + CDbl(PawnItem.Principal)

        Select Case typ
            Case "REDEEM"
                transactionType = "X"
                btnRedeem.Text = "C&ancel"
                btnRenew.Text = "&Renew"
                txtTotal.Text = txtRedeemDue.Text ' Total
            Case "RENEW"
                transactionType = "R"
                btnRedeem.Text = "R&edeem"
                btnRenew.Text = "C&ancel"
                txtTotal.Text = txtRenewDue.Text ' Total
            Case Else
                Exit Sub
        End Select

        txtTotal.Focus()
        txtTotal.SelectAll()
    End Sub

    'Friend Sub Redeem()
    '    If transactionType = "L" Then Exit Sub

    '    transactionType = "X"

    '    'Buttons
    '    btnRenew.Text = "&Renew"
    '    btnRedeem.Text = "C&ancel"
    '    btnSave.Enabled = True

    '    grpPawner.Enabled = False : grpItem.Enabled = False
    '    grpTicket.Enabled = True : txtTicket.ReadOnly = True
    '    txtNticket.ReadOnly = True : LoanDate.Enabled = False
    '    Maturity.Enabled = False : Expiry.Enabled = False
    '    Auction.Enabled = False : txtAppraisal.ReadOnly = True
    '    txtPrincipal.ReadOnly = True : txtTotal.ReadOnly = False

    '    grpReceipt.Enabled = True

    '    'Ticket Information
    '    txtTicket.Text = String.Format("{0:000000}", PawnItem.PawnTicket)
    '    LoanDate.Value = PawnItem.LoanDate
    '    Maturity.Value = LoanDate.Value.AddDays(30)
    '    Expiry.Value = LoanDate.Value.AddDays(60)
    '    Auction.Value = LoanDate.Value.AddDays(90)
    '    txtAppraisal.Text = PawnItem.Appraisal
    '    txtPrincipal.Text = PawnItem.Principal

    '    txtRefNo.Text = String.Format("{0:000000}", currentOR)
    '    dtpDate.Value = CurrentDate
    '    txtAppr.Text = PawnItem.Appraisal
    '    Dim diff = CurrentDate - Maturity.Value
    '    If diff.Days > 0 Then
    '        txtOverDue.Text = diff.Days
    '    Else
    '        txtOverDue.Text = 0
    '    End If
    '    txtPenalty.Text = GetPenalty(PawnItem.Principal)
    '    txtSrvChrg.Text = GetServiceCharge(PawnItem.Principal)
    '    txtEvat.Text = GetOption("Evat") ' No EVAT implemented

    '    txtRenewDue.Text = CDbl(txtDelayInt.Text) + CDbl(txtPenalty.Text) + CDbl(txtSrvChrg.Text)
    '    txtRedeemDue.Text = CDbl(txtDelayInt.Text) + CDbl(txtPenalty.Text) + CDbl(txtSrvChrg.Text) + CDbl(PawnItem.Principal)

    '    txtTotal.Text = txtRedeemDue.Text ' Total
    '    txtTotal.Focus()
    '    txtTotal.SelectAll()
    'End Sub

#Region "Pawnshop Information"
    Friend Function GetPawnshop(ByVal day As Integer, ByVal pawnItemType As String, Optional ByVal mainType As String = "Interest") As Double
        Dim mySql As String = "SELECT * FROM tblint WHERE ItemType = '" & pawnItemType & "'"
        Dim ds As DataSet = LoadSQL(mySql)
        day += 1 'Include the Loan Date

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim min As Integer = 0, max As Integer = 0
            min = dr.Item("DayFrom") : max = dr.Item("DayTo")

            Select Case day
                Case min To max
                    Return dr.Item(mainType)
            End Select
        Next

        MsgBox("Day " & day & " is out of bound.", MsgBoxStyle.Critical)
        Return 0
    End Function
#End Region

    Private Sub btnVoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoid.Click
        Dim ans As DialogResult = _
        MsgBox("Do you want to void this transaction?", vbCritical + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "W A R N I N G")
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        If PawnItem.LoanDate <> CurrentDate.Date Then
            MsgBox("You cannot VOID in a different DATE", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If PawnItem.Status = "L" Then
            Dim mySql As String = "SELECT * FROM tblPawn WHERE PawnID = " & PawnItem.PawnID
            Dim tbl As String = "tblPawn", ds As DataSet
            ds = LoadSQL(mySql, tbl)
            ds.Tables(0).Rows(0).Item("Status") = "V"
            database.SaveEntry(ds, False)
        End If

        If PawnItem.Status = "R" Then
            VoidPawnItem = PawnItem
            'Renewal()
            SwitchTransaction("RENEW")
            PawnItem.LoadTicket(VoidPawnItem.OldTicket, "OldTicket")
            LoadPawnTicket(PawnItem, "R")
            LoadCurrentPawnTicket()

            'Disable Buttons
            btnRenew.Enabled = False
            btnRedeem.Enabled = False

            Exit Sub
        End If

        If PawnItem.Status = "X" Then
            Console.WriteLine("OLD: " & PawnItem.OldTicket)
            'PawnItem.CancelTicket()

            MsgBox("PT#" & PawnItem.PawnTicket & vbCr & "Is now restored", MsgBoxStyle.Information)
            frmPawning.LoadActive()
            Me.Close()
            Exit Sub
        End If

        MsgBox("PT# " & PawnItem.PawnTicket & vbCr & "Is now VOID", MsgBoxStyle.Information)
        frmPawning.LoadActive()
        Me.Close()
    End Sub

    Private Function GetOldPT() As Integer
        On Error Resume Next

        Dim pt As Integer = PawnItem.PawnTicket
        Dim ds As DataSet, mySql As String = _
            "SELECT * FROM tblPawn WHERE OldTicket = " & pt
        ds = LoadSQL(mySql)

        Dim newPT As Integer
        newPT = ds.Tables(0).Rows(0).Item("PawnTicket")

        Return newPT
    End Function

    Private Sub VoidTheOldTicket()
        If VoidPawnItem Is Nothing Then Exit Sub

        Dim tbl As String = "tblPawn", mySql As String, ds As DataSet
        mySql = "SELECT * FROM tblPawn WHERE PawnID = " & VoidPawnItem.PawnID
        ds = LoadSQL(mySql, tbl)

        ds.Tables(0).Rows(0).Item("Status") = "V"
        database.SaveEntry(ds, False)
    End Sub

    Private Sub cboCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCategory.SelectedIndexChanged

    End Sub
End Class

