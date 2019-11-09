Imports DevExpress.XtraEditors
Public Class frListeningControl
    Dim W As Double = 275 / 15                                                          ' Доля ширины формы
    Dim H As Double = 160 / 15                                                          ' Доля высоты формы 
    Friend iTimerW As Boolean = True                                                    ' вкл/откл обработки таймером изменения ширины формы
    Friend iTimerH As Boolean = True                                                    ' вкл/откл обработки таймером изменения высоты формы
    Dim iCurRow As Object = frAbonents.PIR1_DGView_ListeningHistory.CurrentRow()        ' Активная строка на гриде c слушаниями

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim CurRow As Object = frAbonents.PIR1_DGView_PetitionsDebt.CurrentRow      ' Активная строка на гриде c исками
        Dim ListeningPostpone As Boolean = False                                    ' Перенесено слушение или нет
        If Me.txt_DtPostpone.Text <> "__.__.____" Then ListeningPostpone = True ' Если дата переноса слушания пустая
        ' Если грид не пустой и выделенная строка не итоговая
        If frAbonents.PIR1_DGView_PetitionsDebt.Rows.Count <> 0 Then
            ' Передача значений полей в текст команды запроса
            Select Case AddOrEdit
                Case 3 ' - изменение
                    If Update_PrPetitionsListening(CurRow.Cells("AbonentId").Value, _
                             CurRow.Cells("MemberId").Value, _
                             "'" & CurRow.Cells("DtPeriodStart").Value & "'", _
                             "'" & CurRow.Cells("DtPeriodEnd").Value & "'", _
                             CurRow.Cells("EnergyTypeId").Value, _
                             "'" & iCurRow.Cells("DtListening").Value & "'", _
                             ConvertToNull(Me.txt_DtListening.Text, True, 1, "__.__.____"), _
                             ConvertToNull(Me.txt_DtPostpone.Text, True, 1, "__.__.____"), _
                             ConvertToNull(Me.cmb_ListeningType.SelectedValue, True, 0), _
                             "NULL", _
                                 iTimeNow(0).ToString, _
                                 pref_PerformerId, _
                                 iTimeNow(0).ToString, _
                                 pref_PerformerId, ListeningPostpone) Then
                        With New frInfo
                            .Mess = "Слушание на " & Me.txt_DtListening.Text & "г. изменено"
                            .Show()     ' Всплываюшее сообщение
                        End With
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        Me.Close()
                    End If
                Case 2 ' - добавление
                    If Insert_PrPetitionsListening(CurRow.Cells("AbonentId").Value, _
                                                 CurRow.Cells("MemberId").Value, _
                                                 "'" & CurRow.Cells("DtPeriodStart").Value & "'", _
                                                 "'" & CurRow.Cells("DtPeriodEnd").Value & "'", _
                                                 CurRow.Cells("EnergyTypeId").Value, _
                                                 ConvertToNull(Me.txt_DtListening.Text, True, 1, "__.__.____"), _
                                                 ConvertToNull(Me.txt_DtPostpone.Text, True, 1, "__.__.____"), _
                                                 ConvertToNull(Me.cmb_ListeningType.SelectedValue, True, 0), _
                                                 "NULL", _
                                                     iTimeNow(0).ToString, _
                                                     pref_PerformerId, _
                                                     iTimeNow(0).ToString, _
                                                     pref_PerformerId, ListeningPostpone) Then
                        With New frInfo
                            .Mess = "На " & Me.txt_DtListening.Text & "г. назначено слушание по иску"
                            .Show()  ' Всплываюшее сообщение
                        End With
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        Me.Close()
                    End If
            End Select

        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frListeningControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EventChangedControl = False ' Отключение обработки событий
        ' Заполнение PIR1_cmb_ListeningType итогов слушания
        With Me.cmb_ListeningType
            .DataSource = iDataSet.Tables("ListeningType")
            .DisplayMember = "Name"
            .ValueMember = "ListeningTypeId"
            .SelectedIndex = 2
        End With
        Select Case AddOrEdit
            Case 3 ' Изменение записи
                Me.txt_DtListening.Text = iCurRow.Cells("DtListening").Value
                Me.cmb_ListeningType.SelectedValue = iCurRow.Cells("ListeningTypeId").Value
                Me.txt_DtPostpone.Text = iCurRow.Cells("DtPostpone").Value.ToString
            Case 2 ' Новая запись
                Me.txt_DtListening.Text = Now.Date   ' Сегодня
        End Select
        ' Отображение формы на 20 пикселей от курсора мыши
        Me.Location = New Point(Cursor.Position.X - 300, Cursor.Position.Y - 110)
        ' Плавное появление формы
        Me.Width = 0
        Me.Height = 0
        TimerW.Start()
        TimerH.Start()
        EventChangedControl = True ' Включение обработки событий
    End Sub

    Private Sub cmb_ListeningType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_ListeningType.SelectedIndexChanged
        ' Если обработка не включена то событие не происходит
        If EventChangedControl Then
            ' Слушание перенесено
            If Me.cmb_ListeningType.SelectedValue = 1 Then
                Me.Height = 159
            End If
            '/////////////////////////////////////////////
            ' Принято решение
            If Me.cmb_ListeningType.SelectedValue <> 1 Then
                Me.Height = 125
                Me.txt_DtPostpone.Text = Nothing
            End If
        End If
    End Sub

    Private Sub TimerW_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerW.Tick
        If iTimerW Then
            ' Плавное появление формы
            If Me.Width >= 274 Then
                TimerW.Stop()
                iTimerW = False
            Else
                Me.Width = W + Me.Width
            End If
        End If
    End Sub
    Private Sub TimerH_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerH.Tick
        If iTimerH Then
            ' Плавное появление формы
            If Me.Height >= 125 Then
                TimerW.Stop()
                iTimerH = False
            Else
                Me.Height = H + Me.Height
            End If
        End If
    End Sub

    ' Обработка полей с датами
    Private Sub txt_DtListening_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txt_DtListening.MouseClick
        DateMaskEvents("MouseClick", sender)
    End Sub
    Private Sub txt_DtListening_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_DtListening.KeyUp
        DateMaskEvents("KeyUp", sender, e.KeyCode)
    End Sub
    Private Sub txt_DtListening_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_DtListening.Validating
        ' Проверка корректности введенной даты
        txtMaskValidating(sender, "Введена некорректная дата! Исправьте....", "__.__.____")
        If sender.Text = "__.__.____" Then XtraMessageBox.Show("Не указана дата слушания....", _
                            "Введите дату...", MessageBoxButtons.OK, MessageBoxIcon.Error) _
          : sender.Focus() _
          : sender.SelectAll()
    End Sub
    Private Sub txt_DtListening_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_DtListening.Leave
        ' Проверка корректности периода и последовательности дат
        If Me.txt_DtListening.Text <> "__.__.____" And Me.txt_DtPostpone.Text <> "__.__.____" Then _
        ValidateOfDateDiff(Me.txt_DtListening.Text, Me.txt_DtPostpone.Text, Me.txt_DtListening, "Дата слушания и дата переноса не согласовываются между собой...")
    End Sub
    Private Sub btn_CalDtDecision_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CalDtDecision.ValueChanged
        Me.txt_DtListening.Text = sender.Text
    End Sub
    Private Sub btn_CalDtDecision_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_CalDtDecision.MouseEnter
        If IsDate(Me.txt_DtListening.Text) Then sender.Value = Me.txt_DtListening.Text
    End Sub

    Private Sub txt_DtPostpone_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txt_DtPostpone.MouseClick
        DateMaskEvents("MouseClick", sender)
    End Sub
    Private Sub txt_DtPostpone_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_DtPostpone.KeyUp
        DateMaskEvents("KeyUp", sender, e.KeyCode)
    End Sub
    Private Sub txt_DtPostpone_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_DtPostpone.Validating
        ' Проверка корректности введенной даты
        txtMaskValidating(sender, "Введена некорректная дата! Исправьте....", "__.__.____")
        ' Проверка корректности периода если в поле не пустая маска        
        If sender.Text = "__.__.____" And Me.cmb_ListeningType.SelectedValue = 1 Then XtraMessageBox.Show("Не указана дата следующего слушания....", _
                            "Введите дату...", MessageBoxButtons.OK, MessageBoxIcon.Error) _
                : sender.Focus() _
                : sender.SelectAll()
    End Sub
    Private Sub txt_DtPostpone_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_DtPostpone.Leave
        ' Проверка корректности периода и последовательности дат
        If Me.txt_DtListening.Text <> "__.__.____" And Me.txt_DtPostpone.Text <> "__.__.____" Then _
        ValidateOfDateDiff(Me.txt_DtListening.Text, Me.txt_DtPostpone.Text, Me.txt_DtPostpone, "Дата слушания и дата переноса не согласовываются между собой...")
    End Sub
    Private Sub btn_CalDtPostpone_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CalDtPostpone.ValueChanged
        Me.txt_DtPostpone.Text = sender.Text
    End Sub
    Private Sub btn_CalDtPostpone_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_CalDtPostpone.MouseEnter
        If IsDate(Me.txt_DtPostpone.Text) Then sender.Value = Me.txt_DtPostpone.Text
    End Sub
End Class
