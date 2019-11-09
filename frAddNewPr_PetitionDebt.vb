Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Public Class frAddNewPr_PetitionDebt

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        ' Если есть и все поля заполнены то, добавляем в базу новый иск
        If FillingElements() Then
            If Insert_PrPetitionsDebt(pref_AbonentId, _
                                 ConvertToNull(Me.cmd_PrMembers.SelectedValue, True, 0), _
                                 ConvertToNull(Me.PIR1_cmb_EnergyType.SelectedValue, True, 0), _
                                 ConvertToNull(Me.PIR1_txt_DtPeriodStart.Text, True, 1, "__.__.____"), _
                                 ConvertToNull(Me.PIR1_txt_DtPeriodEnd.Text, True, 1, "__.__.____"), _
                                 OutBD_Money(Me.PIR1_txt_DebtSumm.Text, 1, "G"), _
                                 OutBD_Money(Me.PIR1_txt_GovTax.Text, 1, "G"), _
                                 ConvertToNull(Me.PIR1_cmb_CourtType.SelectedValue, True, 0), _
                                 ConvertToNull(Me.PIR1_cmb_PetitionType.SelectedValue, True, 0), _
                                 ConvertToNull(Me.PIR1_cmb_JudicialArea.SelectedValue, True, 0), _
                                 ConvertToNull(Me.PIR1_txt_NumberPetition.Text, True, 0), _
                                 ConvertToNull(Me.PIR1_txt_DtPetitions.Text, True, 1, "__.__.____"), _
                                 iTimeNow(0).ToString, _
                                 pref_PerformerId, _
                                 iTimeNow(4).ToString) Then
                With New frInfo
                    .Mess = "Добавлен новый иск на абонента" & Chr(10) & Me.cmd_PrMembers.SelectedText
                    .Show()     ' Всплываюшее сообщение
                End With
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        Else
            Exit Sub
        End If
    End Sub

    ' Проверка заполнения всех необходимых полей
    Private Function FillingElements() As Boolean
        If PIR1_txt_DtPeriodStart.Text = "__.__.____" Or _
           PIR1_txt_DtPeriodEnd.Text = "__.__.____" Or _
           PIR1_txt_DtPetitions.Text = "__.__.____" Or _
           PIR1_txt_DebtSumm.Text = "" Or _
           PIR1_txt_NumberPetition.Text = "" Or
           PIR1_txt_GovTax.Text = "" Then
            XtraMessageBox.Show("Не все обязательные поля заполнены!", _
                                Application.ProductName, _
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False ' Если не все поля заполнены
        Else
            Return True  ' Если с полями в се в порядке
        End If
    End Function

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    ' Загрузка формы
    Private Sub frAddNewPr_Petition_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Сегодняшняя дата заявления
        Me.PIR1_txt_DtPetitions.Text = Now.Date
        ' Выборка ФИО членов семьи заведенных в ПК Припять
        SelectQueryData(
                        "Members_FIO", _
 _
                        "EXEC Pr_AbonentsMembers " & _
                                "@AbonentId = " & pref_AbonentId & ", " & _
                                "@Function = 7", _
 _
                        "AddPetition"
                        )

        ' Заполнение cmd_PrMembers членов семьи ПК Припять
        With Me.cmd_PrMembers
            .DataSource = iDataSet.Tables("Members_FIO")
            .DisplayMember = "FullName"
            .ValueMember = "MemberId"
            ' Если члены семьи заведены то, выбираем первый пункт в списке
            If .Items.Count <> 0 Then
                .SelectedIndex = 0
                ' Если нет то, уведомляем об этом
            Else
                XtraMessageBox.Show("Для добавления нового иска, необходимо завести хотя бы одного члена семьи" _
                                & Chr(10) & "в " & Application.ProductName & " на вкладке Члены семьи", _
                                "Отсутствуют данные в " & Application.ProductName, _
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close() ' закрываем форму
            End If
        End With

        EventChangedControl = False     ' обработки событий изменения значений контролов
        ' Заполнение PIR1_cmb_EnergyType видов услуг
        With Me.PIR1_cmb_EnergyType
            .DataSource = iDataSet.Tables("EnergyTypes")
            .DisplayMember = "Name"
            .ValueMember = "EnergyTypeId"
            If .Items.Count <> 0 Then .SelectedIndex = 0
        End With

        ' Заполнение PIR1_cmb_PetitionType видов исков
        With Me.PIR1_cmb_PetitionType
            .DataSource = iDataSet.Tables("PetitionTypes")
            .DisplayMember = "Name"
            .ValueMember = "PetitionTypeId"
            If .Items.Count <> 0 Then .SelectedIndex = 0
        End With

        ' Заполнение PIR1_cmb_CourtType судебных инстанций
        With Me.PIR1_cmb_CourtType
            .DataSource = iDataSet.Tables("CourtType")
            .DisplayMember = "Name"
            .ValueMember = "CourtTypeId"
            If .Items.Count <> 0 Then .SelectedIndex = 0
        End With

        ' Заполнение PIR1_cmb_JudicialArea судебных участков
        With Me.PIR1_cmb_JudicialArea
            .DataSource = iDataSet.Tables("JudicialArea")
            .DisplayMember = "NameString"
            .ValueMember = "JudicialAreaId"
            If .Items.Count <> 0 Then .SelectedIndex = 0
        End With
        EventChangedControl = True      ' обработки событий изменения значений контролов
    End Sub

    ' Обработка событий текстовых полей
    ' Обработка полей с датами

    Private Sub PIR1_txt_DtPeriodStart_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PIR1_txt_DtPeriodStart.MouseClick
        DateMaskEvents("MouseClick", sender)
    End Sub
    Private Sub PIR1_txt_DtPeriodStart_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PIR1_txt_DtPeriodStart.KeyUp
        DateMaskEvents("KeyUp", sender, e.KeyCode)
    End Sub
    Private Sub PIR1_txt_DtPeriodStart_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PIR1_txt_DtPeriodStart.Validating
        ' Проверка корректности введенного номера
        txtMaskValidating(sender, "Введена некорректная дата! Исправьте....", "__.__.____")
    End Sub
    Private Sub btn_CalPDDateOfIssue_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CalPIR1_txt_DtPeriodStart.ValueChanged
        Me.PIR1_txt_DtPeriodStart.Text = sender.Text
    End Sub
    Private Sub btn_CalPDDateOfIssue_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_CalPIR1_txt_DtPeriodStart.MouseEnter
        If IsDate(Me.PIR1_txt_DtPeriodStart.Text) Then sender.Value = Me.PIR1_txt_DtPeriodStart.Text
    End Sub

    Private Sub PIR1_txt_DtPeriodEnd_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PIR1_txt_DtPeriodEnd.MouseClick
        DateMaskEvents("MouseClick", sender)
    End Sub
    Private Sub PIR1_txt_DtPeriodEnd_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PIR1_txt_DtPeriodEnd.KeyUp
        DateMaskEvents("KeyUp", sender, e.KeyCode)
    End Sub
    Private Sub PIR1_txt_DtPeriodEnd_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PIR1_txt_DtPeriodEnd.Validating
        ' Проверка корректности введенного номера
        txtMaskValidating(sender, "Введена некорректная дата! Исправьте....", "__.__.____")
    End Sub
    Private Sub btn_CalPIR1_txt_DtPeriodEnd_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CalPIR1_txt_DtPeriodEnd.ValueChanged
        Me.PIR1_txt_DtPeriodEnd.Text = sender.Text
    End Sub
    Private Sub btn_CalPIR1_txt_DtPeriodEnd_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_CalPIR1_txt_DtPeriodEnd.MouseEnter
        If IsDate(Me.PIR1_txt_DtPeriodEnd.Text) Then sender.Value = Me.PIR1_txt_DtPeriodEnd.Text
    End Sub

    Private Sub PIR1_txt_DtPetitions_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PIR1_txt_DtPetitions.MouseClick
        DateMaskEvents("MouseClick", sender)
    End Sub
    Private Sub PIR1_txt_DtPetitions_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PIR1_txt_DtPetitions.KeyUp
        DateMaskEvents("KeyUp", sender, e.KeyCode)
    End Sub
    Private Sub PIR1_txt_DtPetitions_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PIR1_txt_DtPetitions.Validating
        ' Проверка корректности введенного номера
        txtMaskValidating(sender, "Введена некорректная дата! Исправьте....", "__.__.____")
    End Sub
    Private Sub btn_CalPIR1_txt_DtPetitions_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CalPIR1_txt_DtPetitions.ValueChanged
        Me.PIR1_txt_DtPetitions.Text = sender.Text
    End Sub
    Private Sub btn_CalPIR1_txt_DtPetitions_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_CalPIR1_txt_DtPetitions.MouseEnter
        If IsDate(Me.PIR1_txt_DtPeriodStart.Text) Then sender.Value = Me.PIR1_txt_DtPetitions.Text
    End Sub

    ' Обработка денежных полей
    Private Sub PIR1_txt_DebtSumm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PIR1_txt_DebtSumm.KeyPress
        ' Проверка корректности вводимых данных (только цыфры, и ограниченное количество символов)
        MoneyTextBox_Numbers(sender, e)
    End Sub
    Private Sub PIR1_txt_DebtSumm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PIR1_txt_DebtSumm.Click
        MoneyTextBox_EnterLeave(sender, e, "Click", "G")
    End Sub
    Private Sub PIR1_txt_DebtSumm_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PIR1_txt_DebtSumm.Leave
        MoneyTextBox_EnterLeave(sender, e, "Leave", "N")
        ' Если сумма иска не указана то, очищаем гос.пошлину
        If sender.Text = "" Then Me.PIR1_txt_GovTax.Text = Nothing
    End Sub
    Private Sub PIR1_txt_DebtSumm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles PIR1_txt_DebtSumm.LostFocus
        ' Расчет гос.пошлины
        If PIR1_cmb_PetitionType.Text = "" Then
            XtraMessageBox.Show("Невозможно произвести расчет Гос.пошлины, так как неуказан тип иска!", _
                "Расчет госпошлины...", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.PIR1_cmb_PetitionType.Focus()                ' Фокус на контрол
            Me.PIR1_cmb_PetitionType.DroppedDown = True     ' Разворачиваем список,
        Else
            ' Расчитываем госпошлину
            If sender.Text <> "" Then CalculateGovTax(sender.Text, PIR1_cmb_PetitionType, PIR1_txt_GovTax)
        End If
    End Sub

    ' Обработка поля с регистрационным номером
    Private Sub PIR1_txt_NumberPetition_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PIR1_txt_NumberPetition.Click
        Dim iPrefix As String = pref_DivisionIndex & "-2-06-" ' Берем преффикс из настроек
        ' Если поле пустое
        If sender.Text = "" Then
            sender.Text = pref_DivisionIndex & "-2-06-"                                                  ' Заносим регистрационный префикс
            sender.Select(iPrefix.Length, sender.TextLength - iPrefix.Length)       ' Выделяем весь текст который после регистрационного префикса
        Else
            ' если вход в поле не осуществлен
            If iEnter Then
                sender.Select(iPrefix.Length, sender.TextLength - iPrefix.Length)   ' Выделяем весь текст который после регистрационного префикса 
                iEnter = False                                             ' Поле активно, больше не выделяем
            End If
        End If
    End Sub

    Private Sub PIR1_txt_NumberPetition_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles PIR1_txt_NumberPetition.LostFocus
        Dim iPrefix As String = pref_DivisionIndex & "-2-06-"  ' Берем преффикс из настроек
        If sender.Text = iPrefix Then sender.Text = Nothing ' Если ввели только префикс поле очищается
        iEnter = True                              ' Поле НЕ активно, больше не выделяем
    End Sub

    Private Sub PIR1_txt_NumberPetition_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PIR1_txt_NumberPetition.KeyPress
        ' Если нажата BackSpace и поле остался только префикс, то отменяем стирание
        If Asc(e.KeyChar) = 8 And sender.Text = pref_DivisionIndex & "-2-06-" Then e.Handled = True
    End Sub

    ' При изменении типа иска перерасчет гос.пошлины
    Private Sub PIR1_cmb_PetitionType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PIR1_cmb_PetitionType.SelectedIndexChanged
        If EventChangedControl Then
            If Me.PIR1_txt_DebtSumm.Text <> "" Then
                ' Расчитываем госпошлину
                CalculateGovTax(Me.PIR1_txt_DebtSumm.Text, sender, PIR1_txt_GovTax)
            End If
        End If
    End Sub

    Private Sub PIR1_cmb_CourtType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PIR1_cmb_CourtType.SelectedIndexChanged
        If EventChangedControl Then
            ' У каждой инстанции свои участки
            GetPr_JudicialArea(Me.PIR1_cmb_CourtType.SelectedValue)
        End If
    End Sub

End Class
