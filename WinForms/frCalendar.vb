Public Class frCalendar
    Public DtControl As Object          ' Контрол в который нужно записать дату

    Private Sub Mth_Calendar_DateSelected(ByVal sender As Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles Mth_Calendar.DateSelected
        ' Вставка в текстовое поля выбранной даты в календаре
        DtControl.Text = Me.Mth_Calendar.SelectionStart.Date
        Me.Close()
    End Sub

    Private Sub frCalendar_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        DtControl.SelectAll()
        Me.Close()
    End Sub

    Private Sub frCalendar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Отображение формы на 20 пикселей от курсора мыши
        Me.Location = New Point(Cursor.Position.X + 20, Cursor.Position.Y + 20)
        ' Если маска заполнена то, текст берется из контрола....
        If DtControl.MaskFull Then
            Me.Mth_Calendar.SelectionStart = DtControl.Text
            Me.Mth_Calendar.SelectionEnd = DtControl.Text
        Else ' Если нет устанавливаем сегодня
            Me.Mth_Calendar.SelectionStart = Now.Date
            Me.Mth_Calendar.SelectionEnd = Now.Date
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DtControl.SelectAll()
        Me.Close()
    End Sub
End Class