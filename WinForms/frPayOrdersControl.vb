Imports System.Windows.Forms
Imports DevExpress.XtraEditors

Public Class frPayOrdersControl
    Dim FirstLoad As Boolean = True                                         ' Первая активация формы или нет
    Dim iSelectRowDGView_PayOrders As Integer = 0                           ' Активная строка на Гриде
    Dim CurRow As Object = frAbonents.PIR1_DGView_PetitionsDebt.CurrentRow      ' Активная строка на гриде c исками

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Me.Btn_SavePayOrder.Enabled Then
            Select Case XtraMessageBox.Show("В платежных поручениях имеется не сохраненная запись!" & Chr(10) &
                                        "Все равно закрыть?", Application.ProductName, MessageBoxButtons.YesNo,
                                                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                Case DialogResult.Yes ' Да
                    Me.Close()
                Case DialogResult.No ' Нет
                    Exit Select
            End Select
        Else
            Me.Close()
        End If
    End Sub

    Private Sub frPayOrdersControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = "    Управление платежными поручениями. Иск за период   с " & CurRow.Cells("DtPeriodStart").Value & "г. " & _
                                                                        "по " & CurRow.Cells("DtPeriodEnd").Value & "г."
        DisignerPayOrdersGrid()
        Me.Btn_SavePayOrder.Enabled = False
    End Sub

    Private Sub DisignerPayOrdersGrid()
        EventChangedControl = False ' Отключаем обработку событий в полях
        GetPr_PayOrders(CurRow.Cells("AbonentId").Value, _
                        CurRow.Cells("MemberId").Value, _
                        "'" & CurRow.Cells("DtPeriodStart").Value & "'", _
                        "'" & CurRow.Cells("DtPeriodEnd").Value & "'", _
                        CurRow.Cells("EnergyTypeId").Value)
        GetPr_PayOrderStatus()
        If FirstLoad Then
            ' <<<<<<<НАСТРОЙКА PIR1_DGView_Petitions>>>>>>>
            ' Привязка PIR1_DGView_Petitions к iDataset.PetitionsDebt
            Me.DGView_PayOrders.DataSource = iDataSet.Tables("PayOrders")
            ' Скрываем все столбцы на .PIR1_DGView_Petitions
            For i = 0 To Me.DGView_PayOrders.ColumnCount - 1
                Me.DGView_PayOrders.Columns.Item(i).Visible = False
            Next
            ' Отображаем нужные столбцы и задаем им имена
            Dim ColGrid As Object = Me.DGView_PayOrders.Columns
            ColGrid.Item("DtPayOrder").HeaderText = "Дата поручения"
            ColGrid.Item("DtPayOrder").Visible = True
            ColGrid.Item("DtPayOrder").Width = 92

            ColGrid.Item("SumPayOrder").HeaderText = "Сумма"
            ColGrid.Item("SumPayOrder").Visible = True
            ColGrid.Item("SumPayOrder").Width = 92
            ColGrid.Item("SumPayOrder").DefaultCellStyle.Format = "N2"

            ColGrid.Item("NumberPayOrder").HeaderText = "Номер"
            ColGrid.Item("NumberPayOrder").Visible = True
            ColGrid.Item("NumberPayOrder").Width = 142

            ColGrid.Item("PayOrderStatus").HeaderText = "Статус поручения"
            ColGrid.Item("PayOrderStatus").Visible = True
            ColGrid.Item("PayOrderStatus").Width = 152

            ' Отключаем сортировку столбцов по всему Гриду
            For i = 0 To Me.DGView_PayOrders.ColumnCount - 1
                Me.DGView_PayOrders.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next
            ' Заполнение cmb_PayOrderStatus статусов платежных поручений
            With Me.cmb_PayOrderStatus
                .DataSource = iDataSet.Tables("PayOrderStatus")
                .DisplayMember = "Name"
                .ValueMember = "PayOrderStatusId"
            End With
            FirstLoad = False ' Первая активация состоялась
        End If
        EventChangedControl = True ' Включаем обработку событий в полях

        If Me.DGView_PayOrders.RowCount <> 0 Then
            If iSelectRowDGView_PayOrders >= 0 Then ' если индекс активной строки >= 0
                ' то, активируем строку по индексу из переменной
                Me.DGView_PayOrders.CurrentCell = Me.DGView_PayOrders _
                                                    .Rows(iSelectRowDGView_PayOrders) _
                                                    .Cells(Me.DGView_PayOrders.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Name)
            Else ' иначе, активируем первую строку
                Me.DGView_PayOrders.CurrentCell = Me.DGView_PayOrders _
                                                    .Rows(0) _
                                                    .Cells(Me.DGView_PayOrders.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Name)
            End If
            Fill_DGView_PayOrders()         ' Разноска информации по полям
        Else ' Если пустой то, делаем недоступными кнопки удалить и сохранить
            ClearDataCurrentPayOrder()
        End If
    End Sub

    ' События на гриде с платежными ордерами
    Private Sub PIR1_DGView_Petitions_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGView_PayOrders.SelectionChanged
        If EventChangedControl Then
            If ValidateFilling(False) = False Then
                If Me.DGView_PayOrders.RowCount.ToString <> 0 Then Me.DGView_PayOrders.CurrentCell = Me.DGView_PayOrders.Rows(iSelectRowDGView_PayOrders).Cells(8)
            Else
                Fill_DGView_PayOrders()
                If Me.DGView_PayOrders.RowCount.ToString <> 0 And Me.DGView_PayOrders.CurrentRow.Selected Then
                    ' Запись в переменную номера активной строки DGView_PrMembers
                    iSelectRowDGView_PayOrders = Me.DGView_PayOrders.CurrentRow.Index
                End If
            End If
        End If

    End Sub
    Private Sub PIR1_DGView_Petitions_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGView_PayOrders.KeyDown
        ' Удаление записи кнопкой DELETE
        ' Если грид не пустой или всего с одной записью
        Dim iCurRow As Object = Me.DGView_PayOrders.CurrentRow        ' Активная строка на гриде
        Dim lRow As Integer = Me.DGView_PayOrders.Rows.Count          ' Количество строк на гриде
        If lRow <> 0 Then _
        If e.KeyCode = Keys.Delete Then Me.Btn_DeletePayOrder_Click(sender, e)
    End Sub
    ' Заполнение полей для ввода
    Private Sub Fill_DGView_PayOrders()
        EventChangedControl = False ' Отключаем обработку событий в полях
        Dim iCurRow As Object = Me.DGView_PayOrders.CurrentRow      ' Активная строка на гриде
        Dim lRow As Integer = Me.DGView_PayOrders.Rows.Count          ' Количество строк на гриде
        If lRow <> 0 Then
            ' Включение всех контролов 
            For Each f As Control In Me.Panel2.Controls
                f.Enabled = True
            Next
            ' Заполнение всех полей с информацией по иску
            Me.txt_DtPayOrder.Text = ConvertToNull(iCurRow.Cells("DtPayOrder").Value.ToString, False, 1)
            Me.txt_SummPayOrder.Text = OutBD_Money(iCurRow.Cells("SumPayOrder").Value.ToString, 0, "N")
            Me.txt_NumberPayOrder.Text = iCurRow.Cells("NumberPayOrder").Value.ToString
            Me.cmb_PayOrderStatus.Text = iCurRow.Cells("PayOrderStatus").Value.ToString
            Me.Btn_DeletePayOrder.Enabled = True
        Else
            ClearDataCurrentPayOrder()
        End If
        EventChangedControl = True ' Включаем обработку событий в полях
    End Sub
    ' Чистка полей для ввода
    Private Sub ClearDataCurrentPayOrder()
        EventChangedControl = False ' Отключаем обработку событий в полях
        ' Чистка полей
        Me.txt_DtPayOrder.Text = Nothing
        Me.txt_SummPayOrder.Text = Nothing
        Me.txt_NumberPayOrder.Text = Nothing
        Me.cmb_PayOrderStatus.Text = Nothing
        ' Отключение всех контролов
        For Each f As Control In Me.Panel2.Controls
            f.Enabled = False
        Next
        Me.Btn_DeletePayOrder.Enabled = False
        EventChangedControl = True ' Включаем обработку событий в полях
    End Sub
    ' Проверка заполненности полей
    ' ReturnMeess - возвращает ли функция сообщение об ошибке (по-умолчанию возвращает)
    Private Function ValidateFilling(Optional ByVal ReturnMeess As Boolean = True)
        Dim lRow As Integer = Me.DGView_PayOrders.Rows.Count - 1            ' Последняя строка на гриде
        Dim lCol As Integer = Me.DGView_PayOrders.Columns.Count - 1         ' Последняя столбец на гриде
        If lRow = -1 Then Return True : Exit Function ' Если грид пустой
        ' По всему гриду ищем пустую ячейку
        For i = 0 To lRow
            For j = 6 To 9
                If IsDBNull(Me.DGView_PayOrders.Rows(i).Cells(j).Value) Then
                    If ReturnMeess Then XtraMessageBox.Show("Имеется неоконченная или не сохраненная запись." & Chr(10) & _
                                                        "Заполните сохраните её....", "Добавление невозможно", _
                                                        MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                    Exit Function
                End If
            Next j
        Next
        If Me.txt_DtPayOrder.Text = "__.__.____" Or _
        Me.txt_SummPayOrder.Text = "0.00" Or _
        Me.txt_NumberPayOrder.Text = "" Or _
        Me.cmb_PayOrderStatus.Text = "" Then
            If ReturnMeess Then XtraMessageBox.Show("Не все обязательные поля заполнены....", "Указана не вся информация!", _
                                                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Return False
        Else
            Return True
        End If
    End Function

    ' Управление платежными ордерами
    Private Sub Btn_AddNewPayOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_AddNewPayOrder.Click
        EventChangedControl = False ' Отключаем обработку событий в полях
        Dim iCurRow As Object = Me.DGView_PayOrders.CurrentRow      ' Активная строка на гриде
        Dim lRow As Integer = Me.DGView_PayOrders.Rows.Count        ' Последняя строка на гриде
        If ValidateFilling() Then
            ' Добавление новой строки в DataSet("PayOrders")
            With iDataSet.Tables("PayOrders")
                Dim rowArray(10) As Object
                rowArray(1) = CurRow.Cells("MemberId").Value
                rowArray(2) = CurRow.Cells("AbonentId").Value
                rowArray(3) = CurRow.Cells("DtPeriodStart").Value
                rowArray(4) = CurRow.Cells("DtPeriodEnd").Value
                rowArray(5) = CurRow.Cells("EnergyTypeId").Value
                rowArray(6) = Now.Date
                rowArray(7) = OutBD_Money(0, 0, "N")
                rowArray(8) = ""
                rowArray(9) = "1"
                rowArray(10) = "В ожидании"
                .Rows.Add.ItemArray = rowArray
            End With
            ' Наводим фоокус на грид, чтобы сработало событие
            iSelectRowDGView_PayOrders = lRow
            Dim iLastRow As Integer = Me.DGView_PayOrders.Rows.GetLastRow(DataGridViewElementStates.Displayed)
            Me.DGView_PayOrders.CurrentCell = Me.DGView_PayOrders.Rows(iSelectRowDGView_PayOrders).Cells("DtPayOrder")
            Fill_DGView_PayOrders()
        Else
            XtraMessageBox.Show("Имеется неоконченная или не сохраненная запись." & Chr(10) & _
                            "Заполните сохраните её....", "Добавление невозможно", _
                             MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        EventChangedControl = True ' Включаем обработку событий в полях
    End Sub
    Private Sub Btn_DeletePayOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_DeletePayOrder.Click
        Dim lRow As Integer = Me.DGView_PayOrders.Rows.Count            ' Количество строк на гриде
        Dim iCurRow As Object = Me.DGView_PayOrders.CurrentRow          ' Активная строка на гриде
        If iCurRow.Cells("PayOrderId").Value.ToString = "" Then
            EventChangedControl = False                                 ' Отключаем обработку событий в полях
            Me.DGView_PayOrders.Rows.Remove(iCurRow)                    ' Удаляем последнюю строку
            iSelectRowDGView_PayOrders = iSelectRowDGView_PayOrders - 1 ' Уменьшаем переменную с номеро строки
            DisignerPayOrdersGrid()                                     ' Перерисовываем элементы
            Exit Sub
        End If
        If lRow <> 0 Then
            If Delete_PrPayOrders(iCurRow.Cells("PayOrderId").Value.ToString) Then
                iSelectRowDGView_PayOrders = iSelectRowDGView_PayOrders - 1 ' Уменьшаем переменную с номеро строки
                With New frInfo
                    .Mess = "Платежный ордер от " & iCurRow.Cells("DtPayOrder").Value.ToString & Chr(10) & " удален..."
                    .Show()     ' Всплываюшее сообщение
                End With
            End If
            DisignerPayOrdersGrid()
        End If
    End Sub
    Private Sub Btn_SavePayOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_SavePayOrder.Click
        Dim iCurRow As Object = Me.DGView_PayOrders.Rows()          ' Активная строка на гриде
        Dim lRow As Integer = Me.DGView_PayOrders.Rows.Count - 1    ' Последняя строка на гриде
        If ValidateFilling() Then
            For i = 0 To lRow
                If iCurRow(i).Cells("PayOrderId").Value.ToString = Nothing Then ' Если в гриде нет PayOrderId 
                    ' то, новая запись
                    iCurRow(i).Cells("DtCreate").Value() = Replace(iTimeNow(0).ToString, "'", "")
                    iCurRow(i).Cells("DtUpdate").Value() = Replace(iTimeNow(0).ToString, "'", "")
                    iCurRow(i).Cells("CratePerformerId").Value() = pref_PerformerId
                    iCurRow(i).Cells("UpdatePerformerId").Value() = pref_PerformerId

                    Insert_PrPayOrders(CurRow.Cells("AbonentId").Value, _
                                       CurRow.Cells("MemberId").Value, _
                                       "'" & CurRow.Cells("DtPeriodStart").Value & "'", _
                                       "'" & CurRow.Cells("DtPeriodEnd").Value & "'", _
                                       CurRow.Cells("EnergyTypeId").Value, _
                                       "'" & iCurRow(i).Cells("DtPayOrder").Value & "'", _
                                       OutBD_Money(iCurRow(i).Cells("SumPayOrder").Value, 1, "G"), _
                                       "'" & iCurRow(i).Cells("NumberPayOrder").Value & "'", _
                                        iCurRow(i).Cells("PayOrderStatusId").Value, _
                                       iTimeNow(0).ToString, _
                                       pref_PerformerId,
                                       iTimeNow(0).ToString, _
                                       pref_PerformerId)
                Else ' Иначе обновление всех записей
                    Update_PrPayOrders(iCurRow(i).Cells("PayOrderId").Value, _
                                       CurRow.Cells("AbonentId").Value, _
                                       CurRow.Cells("MemberId").Value, _
                                       "'" & CurRow.Cells("DtPeriodStart").Value & "'", _
                                       "'" & CurRow.Cells("DtPeriodEnd").Value & "'", _
                                       CurRow.Cells("EnergyTypeId").Value, _
                                       "'" & iCurRow(i).Cells("DtPayOrder").Value & "'", _
                                       OutBD_Money(iCurRow(i).Cells("SumPayOrder").Value, 1, "G"), _
                                       "'" & iCurRow(i).Cells("NumberPayOrder").Value & "'", _
                                        iCurRow(i).Cells("PayOrderStatusId").Value, _
                                       iTimeNow(0).ToString, _
                                       pref_PerformerId)
                End If
            Next i
            With New frInfo
                .Mess = "Измененения в платежных ордерах" & Chr(10) & "успешно сохранены..."
                .Show()     ' Всплываюшее сообщение
            End With
            DisignerPayOrdersGrid()
            Me.Btn_SavePayOrder.Enabled = False
        End If
    End Sub
    ' Ввод данных в поля 
    ' txt_DtPayOrder
    Private Sub txt_DtPayOrder_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txt_DtPayOrder.MouseClick
        DateMaskEvents("MouseClick", sender)
    End Sub
    Private Sub txt_DtPayOrder_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_DtPayOrder.KeyUp
        DateMaskEvents("KeyUp", sender, e.KeyCode)
    End Sub
    Private Sub txt_DtPayOrder_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_DtPayOrder.Validating
        Dim iCurRow As Object = Me.DGView_PayOrders.CurrentRow      ' Активная строка на гриде
        ' Проверка корректности введенного номера
        If txtMaskValidating(sender, "Введена некорректная дата! Исправьте....", "__.__.____") Then
            If Me.DGView_PayOrders.Rows.Count <> 0 Then
                If Me.txt_DtPayOrder.Text = "__.__.____" Then
                    iCurRow.Cells("DtPayOrder").Value = ""
                    Me.Btn_SavePayOrder.Enabled = True
                Else
                    iCurRow.Cells("DtPayOrder").Value = Me.txt_DtPayOrder.Text
                    Me.Btn_SavePayOrder.Enabled = True
                End If
            End If
        End If
    End Sub
    Private Sub btn_Caltxt_DtPayOrder_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Caltxt_DtPayOrder.ValueChanged
        Me.txt_DtPayOrder.Text = sender.Text
    End Sub
    Private Sub btn_Caltxt_DtPayOrder_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Caltxt_DtPayOrder.MouseEnter
        If IsDate(Me.txt_DtPayOrder.Text) Then sender.Value = Me.txt_DtPayOrder.Text
    End Sub
 
    Private Sub txt_SummPayOrder_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_SummPayOrder.KeyPress
        ' Проверка корректности вводимых данных (только цыфры, и ограниченное количество символов)
        MoneyTextBox_Numbers(sender, e)
    End Sub
    Private Sub txt_SummPayOrder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_SummPayOrder.Click
        MoneyTextBox_EnterLeave(sender, e, "Click", "G")
    End Sub
    Private Sub txt_SummPayOrder_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_SummPayOrder.Leave
        MoneyTextBox_EnterLeave(sender, e, "Leave", "N")
    End Sub
    Private Sub txt_SummPayOrder_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_SummPayOrder.TextChanged
        If EventChangedControl Then
            Dim iCurRow As Object = Me.DGView_PayOrders.CurrentRow      ' Активная строка на гриде
            Dim lRow As Integer = Me.DGView_PayOrders.Rows.Count        ' Последняя строка на гриде
            If sender.Text = "" Then sender.Text = "0" & DecSeporator & "00"
            If EventChangedControl And lRow <> 0 Then
                iCurRow.Cells("SumPayOrder").Value = OutBD_Money(Me.txt_SummPayOrder.Text, 1, "G")
                Me.Btn_SavePayOrder.Enabled = True
            End If
        End If
    End Sub
    Private Sub txt_NumberPayOrder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_NumberPayOrder.Click
        Me.txt_NumberPayOrder.SelectAll()
    End Sub
    Private Sub txt_NumberPayOrder_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_NumberPayOrder.TextChanged
        If EventChangedControl Then
            Dim iCurRow As Object = Me.DGView_PayOrders.CurrentRow      ' Активная строка на гриде
            iCurRow.Cells("NumberPayOrder").Value = Me.txt_NumberPayOrder.Text
            Me.Btn_SavePayOrder.Enabled = True
        End If
    End Sub
    Private Sub cmb_PayOrderStatus_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_PayOrderStatus.SelectedValueChanged
        If EventChangedControl Then
            Dim iCurRow As Object = Me.DGView_PayOrders.CurrentRow      ' Активная строка на гриде
            iCurRow.Cells("PayOrderStatus").Value = Me.cmb_PayOrderStatus.Text
            iCurRow.Cells("PayOrderStatusId").Value = Me.cmb_PayOrderStatus.SelectedValue
            Me.Btn_SavePayOrder.Enabled = True
        End If
    End Sub
End Class
