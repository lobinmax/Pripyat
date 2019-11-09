Friend Class HeaderCellCheckBox
    ' Класс для добавления Чекбокса в заголовок столбца на гриде
    Inherits DataGridViewColumnHeaderCell
    Private _checkBoxRegion As Rectangle
    Private _checkAll As Boolean
    Friend ReadOnly Property All As Boolean
        Get
            Return _checkAll
        End Get
    End Property
    Protected Overrides Sub Paint(ByVal graphics As Graphics, ByVal clipBounds As Rectangle, ByVal cellBounds As Rectangle, ByVal rowIndex As Integer, ByVal dataGridViewElementState As DataGridViewElementStates, ByVal value As Object, ByVal formattedValue As Object, ByVal errorText As String, ByVal cellStyle As DataGridViewCellStyle, ByVal advancedBorderStyle As DataGridViewAdvancedBorderStyle, ByVal paintParts As DataGridViewPaintParts)
        MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex, dataGridViewElementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts)
        graphics.FillRectangle(New SolidBrush(cellStyle.BackColor), cellBounds)
        'Зона для прорисовки флажка
        _checkBoxRegion = New Rectangle(cellBounds.X + 1, cellBounds.Y + 2, 25, cellBounds.Height - 4)
        'Прорисовка флажка
        ControlPaint.DrawCheckBox(graphics, _checkBoxRegion, CType(IIf(_checkAll, ButtonState.Checked, ButtonState.Normal), ButtonState))
        'Зона для прорисовки текста заголовка
        Dim textRect As New Rectangle(_checkBoxRegion.Right + 1, _checkBoxRegion.Top, cellBounds.Width - _checkBoxRegion.Width, cellBounds.Height)
        'прорисовка текста
        graphics.DrawString(value.ToString(), cellStyle.Font, New SolidBrush(cellStyle.ForeColor), textRect)
    End Sub
    Protected Overrides Sub OnMouseClick(ByVal e As DataGridViewCellMouseEventArgs)
        _checkAll = Not _checkAll
        MyBase.OnMouseClick(e)
    End Sub
End Class