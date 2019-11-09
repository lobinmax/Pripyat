Imports System.Windows.Forms
Imports DevExpress.XtraEditors

Public Class frBook_CopPerformers
    Dim WithEvents TextControl As TextBox ' Для запрета редактирования DataGrida

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frBook_CopPerformers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Выгружаем перечень  приставов
        SelectQueryData(
                        "CopPerformers", _
                        "EXEC Pr_Books_CopPerformers NULL," & _
                                                    "NULL," & _
                                                    "NULL," & _
                                                    "NULL," & _
                                                    "NULL," & _
                                                    "1", _
                        "frBook.CopPerformers.Load"
                        )
        Me.DG_CopPerformers.DataSource = iDataSet.Tables("CopPerformers")
        ' Скрываем все столбцы на .DG_CopPerformers
        For i = 0 To Me.DG_CopPerformers.ColumnCount - 1
            Me.DG_CopPerformers.Columns.Item(i).Visible = False
        Next
        ' Отображаем нужные столбцы и задаем им имена
        Dim ColGrid_ As Object = Me.DG_CopPerformers.Columns
        ColGrid_.Item("Name").HeaderText = "ФИО пристава - исполнителя"
        ColGrid_.Item("Name").Visible = True
        ColGrid_.Item("Phone").HeaderText = "Телефон"
        ColGrid_.Item("Phone").Visible = True
        ColGrid_.Item("PhoneMobile").HeaderText = "Мобильный телефон"
        ColGrid_.Item("PhoneMobile").Visible = True
        ColGrid_.Item("Email").HeaderText = "Email"
        ColGrid_.Item("Email").Visible = True
    End Sub


#Region "Кнопки контектного меню грида Приставов"
    ' Контекстное меню грида приставов. Появление меню
    Private Sub Menu_CopPerformers_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Menu_CopPerformers.Opening
        Me.DG_CopPerformers.Select()                    ' Активируем грид чтобы выделилась строка
        If Me.DG_CopPerformers.RowCount = 0 Then        ' Если грид пустой
            Me.Btn_EditCop.Enabled = False              ' Отключаем кнопку изменить
            Me.Btn_DeleteCop.Enabled = False            ' Отключаем кнопку удалить
        Else                                            ' Если грид НЕ пустой
            Me.Btn_EditCop.Enabled = True               ' Включаем кнопку изменить
            Me.Btn_DeleteCop.Enabled = True             ' Включаем кнопку удалить
        End If
    End Sub
    ' Добавление нового участка
    Private Sub Btn_AddNewCop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_AddNewCop.Click
        ' Передаем информацию на форму frAddNewPr_Books_JudicialArea
        AddOrEdit = 2           ' Переменная для добавления записи
        ' Если форма вернула Ок, то обновляем форму
        If frAddNewPr_Book_CopPerformers.ShowDialog = Windows.Forms.DialogResult.OK Then
            UpdateForm()    ' Обновление информации на форме
        End If
    End Sub
    ' Изменение выбранного участка
    Private Sub Btn_EditCop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_EditCop.Click
        ' Передаем информацию на форму frAddNewPr_Books_JudicialArea
        AddOrEdit = 3           ' Переменная для изменения записи
        ' Если форма вернула Ок, то обновляем форму
        If frAddNewPr_Book_CopPerformers.ShowDialog = Windows.Forms.DialogResult.OK Then
            UpdateForm()    ' Обновление информации на форме
        End If
    End Sub
    ' Удаление выбранного участка
    Private Sub Btn_DeleteCop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_DeleteCop.Click
        ' Вопрос перед удалением
        Select Case XtraMessageBox.Show("Пристав исполнитель <<" & DG_CopPerformers.CurrentRow.Cells("Name").Value.ToString() & ">> будет удален! Вы согласны?", _
                                    "Внимание! Удаление без возможности восстановления", _
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Case DialogResult.Yes       ' Ok
                If ExecuteQuery(
                                                "EXEC Pr_Books_CopPerformers " & _
                                                    "@CopPerformerId = " & DG_CopPerformers.CurrentRow.Cells("CopPerformerId").Value.ToString() & ", " & _
                                                    "@Name = NULL, " & _
                                                    "@Phone = NULL, " & _
                                                    "@PhoneMobile = NULL, " & _
                                                    "@Email = NULL, " & _
                                                    "@Function = 4",
 _
                                                "Delete.Pr_Books_CopPerformers"
                                             ) Then
                    With New frInfo         ' Всплываюшее сообщение
                        .Mess = "Запись в справочнике успешно удалена..."
                        .Show()
                    End With
                    UpdateForm()        ' Обновляем информацию на форме
                End If
            Case DialogResult.Cancel    ' Отмена
                UpdateForm()            ' Обновляем информацию на форме
        End Select
    End Sub
#End Region


#Region "События на гриде Приставов"
    ' При завершении редактирования ячейки включаем запрет редактирования
    Private Sub DG_CopPerformers_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG_CopPerformers.CellEndEdit
        ' ВКЛ Запрета на редактирование
        Me.DG_CopPerformers.ReadOnly = True
    End Sub
    ' Отмена при попытке редактировать ячейку
    Private Sub DG_CopPerformers_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DG_CopPerformers.EditingControlShowing
        TextControl = e.Control     ' Отмена при попытке редактировать Грид
        TextControl.ReadOnly = True ' вот и не сможем менять содержимое
    End Sub
    ' Активиция ячейки правой кнопкой мыши
    Private Sub DG_CopPerformers_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DG_CopPerformers.CellMouseDown
        ' Активиция ячейки правой кнопкой мыши
        If e.ColumnIndex >= 0 And e.RowIndex >= 0 And e.Button = Windows.Forms.MouseButtons.Right Then
            sender.ReadOnly = False                                             ' ОТКЛ Запрета на редактированиее
            sender.CurrentCell = sender.Rows(e.RowIndex).Cells(e.ColumnIndex)   ' Активируем ячейку по координатам
            sender.BeginEdit(True)                                              ' Входим в нее для редактирование с выделение всего текста
        End If
    End Sub
    ' Двойной счелчок на гриде
    Private Sub DG_CopPerformers_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DG_CopPerformers.DoubleClick
        AddOrEdit = 3      ' Переменная для изменения записи
        ' Если форма вернула Ок, то обновляем форму
        If frAddNewPr_Book_CopPerformers.ShowDialog = Windows.Forms.DialogResult.OK Then
            ' Обновление информации на форме
            UpdateForm()
        End If
    End Sub
    ' Отмена перехода на новыю строку по нажатии Enter
    Private Sub DG_CopPerformers_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DG_CopPerformers.KeyDown
        If e.KeyCode = Keys.Enter Then e.Handled = True
    End Sub
    ' Отлов нажатия горячих клавиш на гриде
    Private Sub DG_CopPerformers_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DG_CopPerformers.KeyPress
        ' Событие по нажатии "+"
        If Asc(e.KeyChar) = 43 Then
            AddOrEdit = 2      ' Переменная для ДОБАВЛЕНИЯ записи
            ' Если форма вернула Ок, то обновляем форму
            If frAddNewPr_Book_CopPerformers.ShowDialog = Windows.Forms.DialogResult.OK Then
                ' Обновление информации на форме
                UpdateForm()
            End If
        End If
        ' Событие по нажатии Enter
        If Asc(e.KeyChar) = 13 Then
            AddOrEdit = 3      ' Переменная для ИЗМЕНЕНИЯ записи
            ' Если форма вернула Ок, то обновляем форму
            If frAddNewPr_Book_CopPerformers.ShowDialog = Windows.Forms.DialogResult.OK Then
                ' Обновление информации на форме
                UpdateForm()
            End If
        End If
    End Sub
#End Region

    ' Обновление перечня приставов
    Private Sub UpdateForm()
        SelectQueryData(
                "CopPerformers", _
                "EXEC Pr_Books_CopPerformers NULL," & _
                                            "NULL," & _
                                            "NULL," & _
                                            "NULL," & _
                                            "NULL," & _
                                            "1", _
                "frBook.CopPerformers.Load"
                )
    End Sub

End Class
