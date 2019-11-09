Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Public Class frBooksJudicialArea

    Private Sub frBooks_JudicialArea_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Close()      ' Закрываем форму
        Me.Dispose()    ' Высвобождение ресурсов
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Close()      ' Закрываем форму
    End Sub

    Private Sub btnTS_Quit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTS_Quit.Click
        Me.Close()      ' Закрываем форму
        Me.Dispose()    ' Высвобождение ресурсов
    End Sub

    Private Sub btnTS_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTS_Update.Click
        UpdateForm()
    End Sub

    ' Обновление информации на форме
    Private Sub UpdateForm()
        EventChangedControl = False                         ' Отключаем обработку событий
        'GetPr_CourtType()                                   ' Выгружаем список инстанций
        ' Обновляем список судебных участков
        SelectQueryData(
                        "JudicialAreaList",
 _
                        "EXEC pr_Books_JudicialArea  @JudicialAreaId = NULL," & _
                                                    "@CourtTypeId = " & Me.cmdTS_CourtType.ComboBox.SelectedValue & "," & _
                                                    "@Postal = NULL," & _
                                                    "@Adress = NULL," & _
                                                    "@HouseNumber = NULL," & _
                                                    "@ZoneOfServiceId = NULL," & _
                                                    "@JudicialAreaName = NULL," & _
                                                    "@Number = NULL," & _
                                                    "@CurrentJudgeId = NULL," & _
                                                    "@Phone = NULL," & _
                                                    "@PhoneMobile = NULL," & _
                                                    "@email = NULL," & _
                                                    "@Site = NULL," & _
                                                    "@Function = 1",
 _
                        "GetPr_JudicialAreaList"
                        )
        ' и судей
        GetPr_Judges(Me.cmdTS_CourtType.ComboBox.SelectedValue)
        EventChangedControl = True                          ' Включаем обработку событий
    End Sub

    ' События при загрузке формы
    Private Sub frBooks_JudicialArea_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EventChangedControl = False     ' Отключение обработки событий
        GetPr_CourtType()               ' Загрузка видов инстанций
        ' Привязка видов инстанций к cmdTS_CourtType
        With Me.cmdTS_CourtType.ComboBox
            .DataSource = iDataSet.Tables("CourtType") : EventChangedControl = False
            .DisplayMember = "Name"
            .ValueMember = "CourtTypeId"
            .SelectedIndex = 0
        End With
        ' Загрузка судебных участков
        SelectQueryData(
                        "JudicialAreaList",
 _
                        "EXEC pr_Books_JudicialArea  @JudicialAreaId = NULL," & _
                                                    "@CourtTypeId = " & Me.cmdTS_CourtType.ComboBox.SelectedValue & "," & _
                                                    "@Postal = NULL," & _
                                                    "@Adress = NULL," & _
                                                    "@HouseNumber = NULL," & _
                                                    "@ZoneOfServiceId = NULL," & _
                                                    "@JudicialAreaName = NULL," & _
                                                    "@Number = NULL," & _
                                                    "@CurrentJudgeId = NULL," & _
                                                    "@Phone = NULL," & _
                                                    "@PhoneMobile = NULL," & _
                                                    "@email = NULL," & _
                                                    "@Site = NULL," & _
                                                    "@Function = 1",
 _
                        "GetPr_JudicialAreaList"
                        )
        ' Привязка судебный участков к DG_JudicialArea
        Me.DG_JudicialArea.DataSource = iDataSet.Tables("JudicialAreaList")

        ' Скрываем все столбцы на .DG_JudicialArea
        For i = 0 To Me.DG_JudicialArea.ColumnCount - 1
            Me.DG_JudicialArea.Columns.Item(i).Visible = False
        Next
        ' Отображаем нужные столбцы и задаем им имена
        Dim ColGrid_ As Object = Me.DG_JudicialArea.Columns
        ColGrid_.Item("Adress").HeaderText = "Адрес участка"
        ColGrid_.Item("Adress").Visible = True
        ColGrid_.Item("ZoneOfService").HeaderText = "Юрисдикция"
        ColGrid_.Item("ZoneOfService").Visible = True
        ColGrid_.Item("NameString").HeaderText = "Наименование участка"
        ColGrid_.Item("NameString").Visible = True
        ColGrid_.Item("CurrentJudge").HeaderText = "Исполняющий судья"
        ColGrid_.Item("CurrentJudge").Visible = True

        GetPr_Judges(1)                                         ' Загрузка судей
        Me.DG_Judges.DataSource = iDataSet.Tables("Judges")     ' Привязка судей к DG_Judges

        ' Скрываем все столбцы на .DG_Judges
        For i = 0 To Me.DG_Judges.ColumnCount - 1
            Me.DG_Judges.Columns.Item(i).Visible = False
        Next
        ' Отображаем нужные столбцы и задаем им имена
        Dim ColGrid As Object = Me.DG_Judges.Columns
        ColGrid.Item("Name").HeaderText = "ФИО судьи"
        ColGrid.Item("Name").Visible = True
        ColGrid.Item("Phone").HeaderText = "Телефон"
        ColGrid.Item("Phone").Visible = True
        ColGrid.Item("PhoneMobile").HeaderText = "Моб.телефон"
        ColGrid.Item("PhoneMobile").Visible = True
        ColGrid.Item("email").HeaderText = "Email"
        ColGrid.Item("email").Visible = True

        ' Включение обработки событий
        EventChangedControl = True
    End Sub

    ' События при изменение инстанции
    Private Sub cmdTS_CourtType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdTS_CourtType.SelectedIndexChanged
        Me.Menu_JudicialArea.Hide()     ' Прячем контекстное меню если оно вызвано

        If EventChangedControl Then     ' Если обработка событий включена то
            ' Выгружаем судебные участки по заданной в Me.cmdTS_CourtType.ComboBox инстанции
            SelectQueryData(
                        "JudicialAreaList",
 _
                        "EXEC pr_Books_JudicialArea  @JudicialAreaId = NULL," & _
                                                    "@CourtTypeId = " & Me.cmdTS_CourtType.ComboBox.SelectedValue & "," & _
                                                    "@Postal = NULL," & _
                                                    "@Adress = NULL," & _
                                                    "@HouseNumber = NULL," & _
                                                    "@ZoneOfServiceId = NULL," & _
                                                    "@JudicialAreaName = NULL," & _
                                                    "@Number = NULL," & _
                                                    "@CurrentJudgeId = NULL," & _
                                                    "@Phone = NULL," & _
                                                    "@PhoneMobile = NULL," & _
                                                    "@email = NULL," & _
                                                    "@Site = NULL," & _
                                                    "@Function = 1",
 _
                        "GetPr_JudicialAreaList"
                        )

            GetPr_Judges(Me.cmdTS_CourtType.ComboBox.SelectedValue)     ' Выгружаем список судей
            ' Меняем название вкладок
            If Me.cmdTS_CourtType.ComboBox.SelectedValue = 1 Then Me.Tab_Judges.Text = "Мировые судьи"
            If Me.cmdTS_CourtType.ComboBox.SelectedValue = 2 Then Me.Tab_Judges.Text = "Федеральные судьи"
        End If
    End Sub

#Region "События на вкладке СУДЕБНЫЕ УЧАСТКИ"
#Region "Кнопки контектного меню грида Судебных участков"
    ' Добавление нового участка
    Private Sub Btn_AddNewJudicialArea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_AddNewJudicialArea.Click
        ' Передаем информацию на форму frAddNewPr_Books_JudicialArea
        AddOrEdit = 2           ' Переменная для добавления записи
        ' Если форма вернула Ок, то обновляем форму
        If frAddNewPr_Books_JudicialArea.ShowDialog = Windows.Forms.DialogResult.OK Then
            UpdateForm()    ' Обновление информации на форме
        End If
    End Sub
    ' Изменение выбранного участка
    Private Sub Btn_EditJudicialArea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_EditJudicialArea.Click
        ' Передаем информацию на форму frAddNewPr_Books_JudicialArea
        AddOrEdit = 3           ' Переменная для добавления записи
        ' Если форма вернула Ок, то обновляем форму
        If frAddNewPr_Books_JudicialArea.ShowDialog = Windows.Forms.DialogResult.OK Then
            UpdateForm()    ' Обновление информации на форме
        End If
    End Sub
    ' Удаление выбранного участка
    Private Sub Btn_DeleteJudicialArea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_DeleteJudicialArea.Click
        ' Вопрос перед удалением
        Select Case XtraMessageBox.Show("Судебный участок <<" & DG_JudicialArea.CurrentRow.Cells("NameString").Value.ToString() & ">> будет удален! Вы согласны?", _
                                    "Внимание! Удаление без возможности восстановления", _
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Case DialogResult.Yes       ' Ok
                If ExecuteQuery(
                                                "EXEC pr_Books_JudicialArea " & _
                                                    "@JudicialAreaId = " & DG_JudicialArea.CurrentRow.Cells("JudicialAreaId").Value.ToString() & "," & _
                                                    "@CourtTypeId = NULL," & _
                                                    "@Postal = NULL," & _
                                                    "@Adress = NULL," & _
                                                    "@HouseNumber = NULL," & _
                                                    "@ZoneOfServiceId = NULL," & _
                                                    "@JudicialAreaName = NULL," & _
                                                    "@Number = NULL," & _
                                                    "@CurrentJudgeId = NULL," & _
                                                    "@Phone = NULL," & _
                                                    "@PhoneMobile = NULL," & _
                                                    "@email = NULL," & _
                                                    "@Site = NULL," & _
                                                    "@Function = 4",
 _
                                                "Delete.Books_JudicialArea"
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
#Region "События на гриде Судебных участков"
    ' Контекстное меню грида Судебных участков
    Private Sub Menu_JudicialArea_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Menu_JudicialArea.Opening
        Me.DG_JudicialArea.Select()                     ' Активируем грид чтобы выделилась строка
        If Me.DG_JudicialArea.RowCount = 0 Then         ' Если грид пустой
            Me.Btn_EditJudicialArea.Enabled = False     ' Отключаем кнопку изменить
            Me.Btn_DeleteJudicialArea.Enabled = False   ' Отключаем кнопку удалить
        Else                                            ' Если грид НЕ пустой
            Me.Btn_EditJudicialArea.Enabled = True      ' Включаем кнопку изменить
            Me.Btn_DeleteJudicialArea.Enabled = True    ' Включаем кнопку удалить
        End If
    End Sub
    ' Активиция ячейки правой кнопкой мыши
    Private Sub DG_JudicialArea_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DG_JudicialArea.CellMouseDown
        'Если счелчок на поле сетки и правой кнопки мыши
        If e.ColumnIndex >= 0 And e.RowIndex >= 0 And e.Button = Windows.Forms.MouseButtons.Right Then
            ' Активируем строку по отловленным координатам
            sender.CurrentCell = sender.Rows(e.RowIndex).Cells(e.ColumnIndex)
        End If
    End Sub
    ' Двойной счелчок на гриде
    Private Sub DG_JudicialArea_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DG_JudicialArea.DoubleClick
        AddOrEdit = 3      ' Переменная для изменения записи
        ' Если форма вернула Ок, то обновляем форму
        If frAddNewPr_Books_JudicialArea.ShowDialog = Windows.Forms.DialogResult.OK Then
            ' Обновление информации на форме
            UpdateForm()
        End If
    End Sub
    ' Отмена перехода на новыю строку по нажатии Enter
    Private Sub DG_JudicialArea_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DG_JudicialArea.KeyDown
        If e.KeyCode = Keys.Enter Then e.Handled = True
    End Sub
    ' Отлов нажатия горячих клавиш на гриде
    Private Sub DG_JudicialArea_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DG_JudicialArea.KeyPress
        ' Событие по нажатии "+"
        If Asc(e.KeyChar) = 43 Then
            AddOrEdit = 2      ' Переменная для ДОБАВЛЕНИЯ записи
            ' Если форма вернула Ок, то обновляем форму
            If frAddNewPr_Books_JudicialArea.ShowDialog = Windows.Forms.DialogResult.OK Then
                ' Обновление информации на форме
                UpdateForm()
            End If
        End If
        ' Событие по нажатии Enter
        If Asc(e.KeyChar) = 13 Then
            AddOrEdit = 3      ' Переменная для ИЗМЕНЕНИЯ записи
            ' Если форма вернула Ок, то обновляем форму
            If frAddNewPr_Books_JudicialArea.ShowDialog = Windows.Forms.DialogResult.OK Then
                ' Обновление информации на форме
                UpdateForm()
            End If
        End If
    End Sub
#End Region
#End Region


#Region "События на вкладке Судьи"
#Region "Кнопки контектного меню грида Судей"
    ' Добавление нового участка
    Private Sub Btn_AddNewJudges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_AddNewJudges.Click
        ' Передаем информацию на форму frAddNewPr_Books_JudicialArea
        AddOrEdit = 2           ' Переменная для добавления записи
        ' Если форма вернула Ок, то обновляем форму
        If frAddNewPr_Books_Judges.ShowDialog = Windows.Forms.DialogResult.OK Then
            UpdateForm()    ' Обновление информации на форме
        End If
    End Sub
    ' Изменение выбранного участка
    Private Sub Btn_EditJudges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_EditJudges.Click
        ' Передаем информацию на форму frAddNewPr_Books_JudicialArea
        AddOrEdit = 3           ' Переменная для изменения записи
        ' Если форма вернула Ок, то обновляем форму
        If frAddNewPr_Books_Judges.ShowDialog = Windows.Forms.DialogResult.OK Then
            UpdateForm()    ' Обновление информации на форме
        End If
    End Sub
    ' Удаление выбранного участка
    Private Sub Btn_DeleteJudges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_DeleteJudges.Click
        ' Вопрос перед удалением
        Select Case MessageBox.Show("Судья <<" & DG_Judges.CurrentRow.Cells("Name").Value.ToString() & ">> будет удален! Вы согласны?", _
                                    "Внимание! Удаление без возможности восстановления", _
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Case DialogResult.Yes       ' Ok
                If ExecuteQuery(
                                                "EXEC Pr_Books_Judges " & _
                                                    "@JudgeId = " & DG_Judges.CurrentRow.Cells("JudgeId").Value.ToString() & ", " & _
                                                    "@CourtTypeId = NULL, " & _
                                                    "@Name = NULL, " & _
                                                    "@Phone = NULL, " & _
                                                    "@PhoneMobile = NULL, " & _
                                                    "@email = NULL, " & _
                                                    "@Function = 4",
 _
                                                "Delete.Pr_Books_Judges"
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

#End Region

#Region "События на гриде Судей"
    ' Контекстное меню грида Судебных участков
    Private Sub Menu_Judges_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Menu_Judges.Opening
        Me.DG_Judges.Select()                     ' Активируем грид чтобы выделилась строка
        If Me.DG_Judges.RowCount = 0 Then         ' Если грид пустой
            Me.Btn_EditJudges.Enabled = False     ' Отключаем кнопку изменить
            Me.Btn_DeleteJudges.Enabled = False   ' Отключаем кнопку удалить
        Else                                      ' Если грид НЕ пустой
            Me.Btn_EditJudges.Enabled = True      ' Включаем кнопку изменить
            Me.Btn_DeleteJudges.Enabled = True    ' Включаем кнопку удалить
        End If
    End Sub
    ' Активиция ячейки правой кнопкой мыши
    Private Sub DG_Judges_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DG_Judges.CellMouseDown
        'Если счелчок на поле сетки и правой кнопки мыши
        If e.ColumnIndex >= 0 And e.RowIndex >= 0 And e.Button = Windows.Forms.MouseButtons.Right Then
            ' Активируем строку по отловленным координатам
            sender.CurrentCell = sender.Rows(e.RowIndex).Cells(e.ColumnIndex)
        End If
    End Sub
    ' Двойной счелчок на гриде
    Private Sub DG_Judges_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DG_Judges.DoubleClick
        AddOrEdit = 3      ' Переменная для изменения записи
        ' Если форма вернула Ок, то обновляем форму
        If frAddNewPr_Books_Judges.ShowDialog = Windows.Forms.DialogResult.OK Then
            ' Обновление информации на форме
            UpdateForm()
        End If
    End Sub
    ' Отмена перехода на новыю строку по нажатии Enter
    Private Sub DG_Judges_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DG_Judges.KeyDown
        If e.KeyCode = Keys.Enter Then e.Handled = True
    End Sub
    ' Отлов нажатия горячих клавиш на гриде
    Private Sub DG_Judges_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DG_Judges.KeyPress
        ' Событие по нажатии "+"
        If Asc(e.KeyChar) = 43 Then
            AddOrEdit = 2      ' Переменная для ДОБАВЛЕНИЯ записи
            ' Если форма вернула Ок, то обновляем форму
            If frAddNewPr_Books_Judges.ShowDialog = Windows.Forms.DialogResult.OK Then
                ' Обновление информации на форме
                UpdateForm()
            End If
        End If
        ' Событие по нажатии Enter
        If Asc(e.KeyChar) = 13 Then
            AddOrEdit = 3      ' Переменная для ИЗМЕНЕНИЯ записи
            ' Если форма вернула Ок, то обновляем форму
            If frAddNewPr_Books_Judges.ShowDialog = Windows.Forms.DialogResult.OK Then
                ' Обновление информации на форме
                UpdateForm()
            End If
        End If
    End Sub
#End Region
End Class