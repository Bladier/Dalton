﻿Public Class CashInOutTransaction

    Private fillData As String = "tblCashTrans"

#Region "Variables and Procedures"
    Private _transID As Integer
    Public Property TransactionID() As Integer
        Get
            Return _transID
        End Get
        Set(ByVal value As Integer)
            _transID = value
        End Set
    End Property

    Private _cashID As Integer
    Public Property CashID() As Integer
        Get
            Return _cashID
        End Get
        Set(ByVal value As Integer)
            _cashID = value
        End Set
    End Property

    Private _type As String
    Public Property Type() As String
        Get
            Return _type
        End Get
        Set(ByVal value As String)
            _type = value
        End Set
    End Property

    Private _category As String
    Public Property Category() As String
        Get
            Return _category
        End Get
        Set(ByVal value As String)
            _category = value
        End Set
    End Property

    Private _transName As String
    Public Property Transaction() As String
        Get
            Return _transName
        End Get
        Set(ByVal value As String)
            _transName = value
        End Set
    End Property

    Private _amount As Double
    Public Property Amount() As Double
        Get
            Return _amount
        End Get
        Set(ByVal value As Double)
            _amount = value
        End Set
    End Property

    Private _particulars As String
    Public Property Particulars() As String
        Get
            Return _particulars
        End Get
        Set(ByVal value As String)
            _particulars = value
        End Set
    End Property

    Private _status As Boolean = True
    Public Property Status() As Boolean
        Get
            Return _status
        End Get
        Set(ByVal value As Boolean)
            _status = value
        End Set
    End Property

    Private _transDate As Date
    Public Property TransactionDate() As Date
        Get
            Return _transDate
        End Get
        Set(ByVal value As Date)
            _transDate = value
        End Set
    End Property

    Private _encoderID As Integer
    Public Property EncoderID() As Integer
        Get
            Return _encoderID
        End Get
        Set(ByVal value As Integer)
            _encoderID = value
        End Set
    End Property

#End Region

    Public Sub LoadCashIOTrans(ByVal id As Integer)
        Dim mySql As String = "SELECT * FROM " & fillData & " WHERE TransID = " & id
        Dim ds As DataSet = LoadSQL(mySql, fillData)

        LoadCashIObyRow(ds.Tables(fillData).Rows(0))
    End Sub

    Public Sub LoadCashIObyRow(ByVal dr As DataRow)
        With dr
            _transID = .Item("TransID")
            _cashID = .Item("CashID")
            _type = .Item("Type")
            _category = .Item("Category")
            _transDate = .Item("TransDate")
            _transName = .Item("TransName")
            _status = .Item("Status")
            _amount = .Item("Amount")
            _particulars = .Item("Remarks")
        End With
    End Sub

    Public Sub Save()
        Dim mySql As String = "SELECT * FROM " & fillData
        Dim ds As DataSet = LoadSQL(mySql, fillData)
        Dim dsNewRow As DataRow

        dsNewRow = ds.Tables(fillData).NewRow
        With dsNewRow
            .Item("CashID") = _cashID
            .Item("Type") = _type
            .Item("Category") = _category
            .Item("TransDate") = _transDate
            .Item("TransName") = _transName
            .Item("Status") = _status
            .Item("Amount") = _amount
            .Item("Remarks") = _particulars
            .Item("EncoderID") = _encoderID
            .Item("SystemInfo") = Now
        End With
        ds.Tables(fillData).Rows.Add(dsNewRow)
        database.SaveEntry(ds)
    End Sub
End Class