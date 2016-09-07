Public Class frmReciept
    Dim newpage As Boolean = False
    Dim mRow As Integer = 0
    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        'Dim col1 = FrmItemOrderList.DGItemOrderList.CurrentCell.RowIndex
        'e.Graphics.DrawString(FrmItemOrderList.DGItemOrderList.Item(FrmItemOrderList.("").HeaderText, col1).Value.ToString, SystemFonts.DefaultFont, Brushes.Black, 300, 200)
        With FrmItemOrderList.DGItemOrderList
            Dim fmt As StringFormat = New StringFormat(StringFormatFlags.LineLimit)
            fmt.LineAlignment = StringAlignment.Near
            fmt.Trimming = StringTrimming.EllipsisCharacter
            Dim y As Single = 4
            Do While mRow < .RowCount
                Dim row As DataGridViewRow = .Rows(mRow)
                Dim x As Single = 1
                Dim h As Single = 1
                'For Each cell As DataGridViewCell In row.Cells
                '    'Dim rc As RectangleF = New RectangleF(x, y, cell.Size.Width, cell.Size.Height)
                '    e.Graphics.DrawRectangle(Pens.Black, rc.Left, rc.Top, rc.Width, rc.Height)
                '    If (newpage) Then
                '        e.Graphics.DrawString(FrmItemOrderList.DGItemOrderList.Columns(cell.ColumnIndex).HeaderText, .Font, Brushes.Black, rc, fmt)
                '    Else
                '        e.Graphics.DrawString(FrmItemOrderList.DGItemOrderList.Rows(cell.RowIndex).Cells(cell.ColumnIndex).FormattedValue.ToString(), .Font, Brushes.Black, rc, fmt)
                '    End If
                '    x += rc.Width
                '    h = Math.Max(h, rc.Height)
                'Next
                newpage = False
                y += h
                mRow += 1
                If y + h > e.MarginBounds.Bottom Then
                    e.HasMorePages = True
                    mRow -= 1
                    newpage = True
                    Exit Sub
                End If
            Loop
            mRow = 0
        End With
    End Sub

    Private Sub frmReciept_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim pd As New Printing.PrintDocument()

        pd.DefaultPageSettings.PaperSize = pd.PrinterSettings.PaperSizes(200)
    End Sub
End Class