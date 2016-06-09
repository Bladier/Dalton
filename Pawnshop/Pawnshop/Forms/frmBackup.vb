﻿Imports System.IO

Public Class frmBackup

    Private _backup As String = "Rar.exe"
    Private bkPassword As String
    ''' <summary>
    ''' click button to close application.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    ''' <summary>
    ''' load the loadbackupSetup and loadfiles method.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmBackup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadBackupSetup()
        LoadFiles()
    End Sub
    ''' <summary>
    ''' This function able to select either what path you want to use.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function isReady() As Boolean
        If txtPath1.Text <> "" Then Return True
        If chkOn2.Checked And txtPath2.Text <> "" Then Return True
        If chkOn3.Checked And txtPath3.Text <> "" Then Return True

        Return False
    End Function
    ''' <summary>
    ''' create backup of files to selected path
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadBackupSetup()
        On Error Resume Next

        Dim bkSwitch As String
        bkSwitch = GetOption("BkTag")

        txtPath1.Text = GetOption("Bk1Path")
        txtPath2.Text = GetOption("Bk2Path")
        txtPath3.Text = GetOption("Bk3Path")

        chkOn2.Checked = IIf(bkSwitch.Substring(0, 1) = "1", True, False) 'Switch
        chkOn3.Checked = IIf(bkSwitch.Substring(1, 1) = "1", True, False)
        chkCP2.Checked = IIf(bkSwitch.Split("|")(1).Substring(0, 1) = "1", True, False) 'Copy Paste
        chkCP3.Checked = IIf(bkSwitch.Split("|")(1).Substring(1, 1) = "1", True, False)

        txtPath2.Enabled = chkOn2.Checked
        chkCP2.Enabled = chkOn2.Checked
        btnBrowse2.Enabled = chkOn2.Checked
        txtPath3.Enabled = chkOn3.Checked
        chkCP3.Enabled = chkOn3.Checked
        btnBrowse3.Enabled = chkOn3.Checked
    End Sub
    ''' <summary>
    ''' load the file to listbox
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadFiles()
        lstFileList.Items.Clear()
        If txtPath1.Text = "" Then Exit Sub

        Dim di As New IO.DirectoryInfo(txtPath1.Text)
        Dim diar1 As IO.FileInfo() = di.GetFiles()
        Dim dra As IO.FileInfo

        For Each dra In diar1
            If dra.Extension = ".noEXT" Then
                lstFileList.Items.Add(dra)
            End If
        Next
    End Sub
    ''' <summary>
    ''' start backuping selected files to desire path
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub startBackup()
        'First
        doBackup(txtPath1.Text)
        Dim forRedundancy As String = BranchCode & CurrentDate.ToString("yyyyMMMdd") & ".noEXT"

        'Redundancy
        If chkOn2.Checked Then
            If chkCP2.Checked Then
                FileCopy(txtPath1.Text & "\" & forRedundancy, txtPath2.Text & "\" & forRedundancy)
            Else : doBackup(txtPath2.Text)
            End If
        End If

        If chkOn3.Checked Then
            If chkCP3.Checked Then
                FileCopy(txtPath1.Text & "\" & forRedundancy, txtPath3.Text & "\" & forRedundancy)
            Else : doBackup(txtPath3.Text)
            End If
        End If
    End Sub
    ''' <summary>
    ''' this method create and copy backup files
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub StartupExecute()
        Dim path() As String = {GetOption("Bk1Path"), GetOption("Bk2Path"), GetOption("Bk3Path")}
        Dim bkTags As String = GetOption("BkTag")

        doBackup(path(0))
        Dim forRedundancy As String = BranchCode & CurrentDate.ToString("yyyyMMMdd") & ".noEXT"

        If bkTags.Substring(0, 1) = "1" Then
            If bkTags.Split("|")(1).Substring(0, 1) = "1" Then
                FileCopy(path(0) & "\" & forRedundancy, path(1) & "\" & forRedundancy)
            Else : doBackup(path(1))
            End If
        End If

        If bkTags.Substring(1, 1) = "1" Then
            If bkTags.Split("|")(1).Substring(1, 1) = "1" Then
                FileCopy(path(0) & "\" & forRedundancy, path(2) & "\" & forRedundancy)
            Else : doBackup(path(2))
            End If
        End If
    End Sub
    ''' <summary>
    ''' This button perform backup
    ''' if the back up is not ready message will appear "failed to execute backup"
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecute.Click
        If Not isReady() Then MsgBox("Failed to execute backup", MsgBoxStyle.Critical) : Exit Sub
        If Not System.IO.File.Exists("W3W1LH4CKU.FDB") Then MsgBox("Database is missing!" + vbCr + "Contact your System Administrator", MsgBoxStyle.Critical) : Exit Sub
        bkPassword = BackupPassword(CurrentDate)

        startBackup()
        doSaveSettings()

        MsgBox("Backup successful", MsgBoxStyle.Information)
        LoadFiles()
    End Sub
    ''' <summary>
    ''' this mehtod will save the backup file to the desire path.
    ''' </summary>
    ''' <param name="path"></param>
    ''' <remarks></remarks>
    Private Sub doBackup(ByVal path As String)
        Dim cmd As String = String.Format(" a -p{0} {1}{2}.noEXT W3W1LH4CKU.FDB", bkPassword, IIf(path = "", "", path & "\"), BranchCode & CurrentDate.ToString("yyyyMMMdd"))

        Console.WriteLine(CommandPrompt(_backup, cmd))
    End Sub
    ''' <summary>
    ''' this button call the dosavesettings method.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        doSaveSettings()

        MsgBox("Settings Saved", MsgBoxStyle.Information)
    End Sub
    ''' <summary>
    ''' this method perform saving of settings
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub doSaveSettings()
        Dim priv As String = ""
        priv &= IIf(chkOn2.Checked, 1, 0)
        priv &= IIf(chkOn3.Checked, 1, 0)
        priv &= "|"
        priv &= IIf(chkCP2.Checked, 1, 0)
        priv &= IIf(chkCP3.Checked, 1, 0)

        UpdateOptions("Bk1Path", txtPath1.Text)
        UpdateOptions("Bk2Path", txtPath2.Text)
        UpdateOptions("Bk3Path", txtPath3.Text)
        UpdateOptions("BkTag", priv)
    End Sub
    ''' <summary>
    ''' click button to browse desire file to backup 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBrowseFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseFile.Click
        Process.Start(GetOption("Bk1Path"))
    End Sub
    ''' <summary>
    ''' checkbox that enable the second txtpath, copy/paste checkbox and browse button
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub chkOn2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOn2.CheckedChanged
        txtPath2.Enabled = chkOn2.Checked
        chkCP2.Enabled = chkOn2.Checked
        btnBrowse2.Enabled = chkOn2.Checked
    End Sub
    ''' <summary>
    ''' checkbox that enable the thrid txtpath, copy/paste checkbox and browse button
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub chkOn3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOn3.CheckedChanged
        txtPath3.Enabled = chkOn3.Checked
        chkCP3.Enabled = chkOn3.Checked
        btnBrowse3.Enabled = chkOn3.Checked
    End Sub
    ''' <summary>
    ''' browse button of 1st backup file that open the file location
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBrowse1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse1.Click
        If Not fbdBackup.ShowDialog = Windows.Forms.DialogResult.OK Then Exit Sub

        txtPath1.Text = fbdBackup.SelectedPath
    End Sub
    ''' <summary>
    '''browse button of second backup file that open the file location
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBrowse2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse2.Click
        If Not fbdBackup.ShowDialog = Windows.Forms.DialogResult.OK Then Exit Sub

        txtPath2.Text = fbdBackup.SelectedPath
    End Sub
    ''' <summary>
    ''' browse button of 3rd backup file that open the file location
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBrowse3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse3.Click
        If Not fbdBackup.ShowDialog = Windows.Forms.DialogResult.OK Then Exit Sub

        txtPath3.Text = fbdBackup.SelectedPath
    End Sub
End Class