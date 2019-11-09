Imports System.Drawing.SystemColors ' Импорт пространства системной политры
Imports DevExpress.XtraEditors

Public Class frAddNewPr_Member
    Public NewOrQusar As Boolean = False ' Новый член семьи или из Квазара (False - новый, True - из Квазара)

    Private Sub frAddNewPr_Member_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Заполнение сmb_FamilyRole семейных ролей
        With Me.сmb_FamilyRole
            .DataSource = iDataSet.Tables("FamilyRole")
            .DisplayMember = "name"
            .ValueMember = "FamilyRoleId"
            .SelectedValue = 1
        End With
        ' Заполнение пола абонента
        With Me.cmb_SexMember
            .DataSource = iDataSet.Tables("SexMember")
            .DisplayMember = "Name"
            .ValueMember = "SexMembersId"
            .SelectedValue = 1
        End With
        ' Адрес прописки по месту
        Me.txt_Residence.Text = frAbonents.txt_Adress.Text
        ' Если добавляется абонент из Квазара то, заполняются поля формы данными из квазара
        If NewOrQusar Then
            Dim DSrow As Object = iDataSet.Tables("FamilyMember").Rows(0)
            ' Заполнение информации по члену семьи
            Me.txt_Surname.Text = DSrow.Item("Surname").ToString
            Me.txt_Name.Text = DSrow.Item("Name").ToString
            Me.txt_Patronymic.Text = DSrow.Item("Patronymic").ToString
            Me.txt_DtResidence.Text = Mid(DSrow.Item("DtResidence").ToString, 1, 10)
            Me.txt_DtUnResidence.Text = Mid(DSrow.Item("DtUnResidence").ToString, 1, 10)
            Me.cmb_SexMember.Text = DSrow.Item("SexMembers").ToString
            Me.ckb_ShareOwner.Checked = DSrow.Item("ShareOwner").ToString
            ' Если член семьи является дольщиком, прописан может быть где угодно
            If Me.ckb_ShareOwner.Checked Then
                Me.txt_Residence.ReadOnly = False
                Me.txt_Residence.Text = DSrow.Item("Residence").ToString
            Else
                Me.txt_Residence.ReadOnly = True
                Me.txt_Residence.Text = frAbonents.txt_Adress.Text
            End If
            Me.сmb_FamilyRole.Text = DSrow.Item("FamilyRoles").ToString
            ' Паспортные данные
            Me.txt_PDDateOfBirth.Text = Mid(DSrow.Item("PDDateOfBirth").ToString, 1, 10)
            Me.txt_PDSeries.Text = DSrow.Item("PDSeries").ToString
            Me.txt_PDNumber.Text = DSrow.Item("PDNumber").ToString
            Me.txt_PDDateOfIssue.Text = Mid(DSrow.Item("PDDateOfIssue").ToString, 1, 10)
            Me.txt_PDSubunit.Text = DSrow.Item("PDSubunit").ToString
            Me.txt_PDSubunitCode.Text = DSrow.Item("PDSubunitCode").ToString
            Me.txt_PDString.Text = "Серия: " & Me.txt_PDSeries.Text & _
                                   " №_" & Me.txt_PDNumber.Text & _
                                   " Код подразделения :" & Me.txt_PDSubunitCode.Text & vbNewLine & _
                                   "Выдан: " & Me.txt_PDDateOfIssue.Text & " " & Me.txt_PDSubunit.Text
        End If
    End Sub

    ' Если член семьи является дольщиком то, прописан может быть где угодно 
    Private Sub ckb_ShareOwner_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckb_ShareOwner.CheckedChanged
        If Me.ckb_ShareOwner.Checked Then
            Me.txt_Residence.ReadOnly = False
            Me.txt_Residence.Text = Nothing
        Else
            Me.txt_Residence.ReadOnly = True
            Me.txt_Residence.Text = frAbonents.txt_Adress.Text
        End If
    End Sub

#Region "Обработка Электронной почты"
    Private Sub txt_MemEmail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_MemEmail.Click
        ' Если НЕ инициализирован вход в поле
        If iEnter = False Then
            sender.Select(0, sender.TextLength)     ' Выделяем весь тект в поле
            sender.Mask = ""                        ' Очищаем поле
            sender.ForeColor = WindowText           ' Меняем цвет текта 
            iEnter = True                           ' Отмечаем что выполнен вход в поле
        End If
    End Sub
    Private Sub txt_MemEmail_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_MemEmail.Leave
        iEnter = False                                  ' Отмечаем что выполнен выход из поле
        ' Если в поле пусто
        If sender.Text = "" Then
            sender.Mask = "____________@_____.____"     ' Устанавливаем маску поля
            sender.ForeColor = InactiveCaption          ' Меняем цвет текта
        End If
    End Sub
    Private Sub txt_MemEmail_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_MemEmail.KeyPress
        Dim s As String = sender.Text
        Dim c As Integer = 0
        If e.KeyChar = "@" Then c = InStr(1, s, "@") '      Если введена @ то, считаем сколько их уже
        If c > 1 Then e.Handled = True : Beep() '           Если их больше одной то отменяем ввод
    End Sub
    Private Sub txt_MemEmail_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_MemEmail.TextChanged
        ' Если в Боксе один знак и он Собака то очищаем бокс 
        If Len(sender.Text) = 1 And sender.Text = "@" Then sender.Clear() : Beep()
    End Sub
    Private Sub txt_MemEmail_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_MemEmail.Validated
        ' Если емайл не прошел проверку и поле НЕ пустое и не равно маске
        If EmailAddressCheck(sender.Text) = False And sender.Text <> "" And sender.Text <> "____________@_____.____" Then
            ' сообщаем об ошибке и переводим фокус обратно в поле
            XtraMessageBox.Show("Исправьте E-mail адрес (ivanov@mail.ru)!", "Не корректный E-mail!")
            sender.Focus()
        End If
    End Sub
#End Region

#Region "Обработка Номера сотового телефона"
    Private Sub txt_MemPhoneMobile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_MemPhoneMobile.Click,
                                                                                                       txt_PDSeries.Click,
                                                                                                       txt_PDNumber.Click,
                                                                                                       txt_PDSubunitCode.Click
        ' Если НЕ инициализирован вход в поле 
        If iEnter = False Then
            ' Если тектовое поле для сотового телефона
            If sender.Name = "txt_MemPhoneMobile" Then
                sender.Select(4, sender.TextLength)     ' Выделяем текст с 5-го и до конца поля
                iEnter = True                           ' Отмечаем что выполнен вход в поле
            Else ' Для остальных полей
                sender.Selectall()                      ' Просто выделяем весь текст
                iEnter = True                           ' Отмечаем что выполнен вход в поле
            End If
        End If
    End Sub
    Private Sub txt_MemPhoneMobile_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_MemPhoneMobile.Leave,
                                                                                                      txt_PDSeries.Leave,
                                                                                                      txt_PDNumber.Leave,
                                                                                                      txt_PDSubunitCode.Leave
        iEnter = False                              ' Отмечаем что выполнен выход из поле
    End Sub
    Private Sub txt_MemPhoneMobile_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_MemPhoneMobile.Validated
        ' В настройках маски исключаем и подсказки и литералы
        sender.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
        ' Если текст в поле НЕ соответствует маске и в поле НЕ пусто
        If sender.MaskFull = False And sender.Text <> "" Then
            ' В настройках маски исключаем и подсказки и литералы
            sender.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
            ' сообщаем об ошибке и переводим фокус обратно в поле
            XtraMessageBox.Show("Номер сотового телефона не соответствует маске", _
                            "Заполните Номер городского телефона", _
                            MessageBoxButtons.OK, _
                            MessageBoxIcon.Asterisk)
            sender.focus()
        Else ' Если текст в поле соответствует маске
            ' В настройках маски Включаем и подсказки и литералы
            If sender.Text <> "" Then sender.TextMaskFormat = MaskFormat.IncludePromptAndLiterals
        End If
    End Sub
#End Region

    ' Обработка поля серия паспорта
    Private Sub txt_PDSeries_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_PDSeries.Validating
        ' Проверка корректности введенного номера
        txtMaskValidating(sender, "Введен некорректная серия паспорта! Исправьте....", "____")
    End Sub
    ' Обработка поля номер паспорта
    Private Sub txt_PDNumber_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_PDNumber.Validating
        ' Проверка корректности введенного номера
        txtMaskValidating(sender, "Введен некорректный номер паспорта! Исправьте....", "______")
    End Sub
    ' Обработка поля код подразделения
    Private Sub txt_PDSubunitCode_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_PDSubunitCode.Validating
        ' Проверка корректности введенного номера
        txtMaskValidating(sender, "Введен некорректный код подразделения! Исправьте....", "___-___")
    End Sub

#Region "Обработка текстовых полей с датами"

    Private Sub txt_DtResidence_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_DtResidence.Leave,
                                                                                                   txt_DtUnResidence.Leave,
                                                                                                   txt_PDDateOfBirth.Leave,
                                                                                                   txt_PDDateOfIssue.Leave
        If Not IsDate(sender.Text) And sender.Text <> "__.__.____" Then _
                XtraMessageBox.Show("Введенный текст не является датой", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error) : sender.Focus()
    End Sub
    Private Sub txt_DtResidence_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txt_DtResidence.MouseClick,
                                                                                                                           txt_DtUnResidence.MouseClick,
                                                                                                                           txt_PDDateOfBirth.MouseClick,
                                                                                                                           txt_PDDateOfIssue.MouseClick
        DateMaskEvents("MouseClick", sender)
    End Sub
    Private Sub txt_DtResidence_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_DtResidence.KeyUp,
                                                                                                                    txt_DtUnResidence.KeyUp,
                                                                                                                    txt_PDDateOfBirth.KeyUp,
                                                                                                                    txt_PDDateOfIssue.KeyUp
        DateMaskEvents("KeyUp", sender, e.KeyCode)
    End Sub
    Private Sub txt_DtResidence_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_DtResidence.Validating,
                                                                                                                             txt_DtUnResidence.Validating,
                                                                                                                             txt_PDDateOfBirth.Validating,
                                                                                                                             txt_PDDateOfIssue.Validating
        ' Проверка корректности введенного номера
        txtMaskValidating(sender, "Введена некорректная дата! Исправьте....", "__.__.____")
    End Sub
#End Region

    Private Sub btn_ClearDtResidence_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CalDtResidence.ValueChanged
        Me.txt_DtResidence.Text = sender.Text
    End Sub
    Private Sub btn_ClearDtResidence_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_CalDtResidence.MouseEnter
        If IsDate(Me.txt_DtResidence.Text) Then sender.Value = Me.txt_DtResidence.Text
    End Sub

    Private Sub btn_CalDtUnResidence_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CalDtUnResidence.ValueChanged
        Me.txt_DtUnResidence.Text = sender.Text
    End Sub
    Private Sub btn_CalDtUnResidence_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_CalDtUnResidence.MouseEnter
        If IsDate(Me.txt_DtUnResidence.Text) Then sender.Value = Me.txt_DtUnResidence.Text
    End Sub

    Private Sub btn_CalPDDateOfBirth_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CalPDDateOfBirth.ValueChanged
        Me.txt_PDDateOfBirth.Text = sender.Text
    End Sub
    Private Sub btn_CalPDDateOfBirth_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_CalPDDateOfBirth.MouseEnter
        If IsDate(Me.txt_PDDateOfBirth.Text) Then sender.Value = Me.txt_PDDateOfBirth.Text
    End Sub

    Private Sub btn_CalPDDateOfIssue_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CalPDDateOfIssue.ValueChanged
        Me.txt_PDDateOfIssue.Text = sender.Text
    End Sub
    Private Sub btn_CalPDDateOfIssue_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_CalPDDateOfIssue.MouseEnter
        If IsDate(Me.txt_PDDateOfIssue.Text) Then sender.Value = Me.txt_PDDateOfIssue.Text
    End Sub

    ' Очистить паспортные данные
    Private Sub btn_ClearPD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ClearPD.Click
        Me.txt_PDDateOfBirth.Text = Nothing : Me.txt_PDSeries.Text = Nothing : Me.txt_PDNumber.Text = Nothing
        Me.txt_PDDateOfIssue.Text = Nothing : Me.txt_PDSubunit.Text = Nothing : Me.txt_PDSubunitCode.Text = Nothing
        Me.txt_PDString.Text = Nothing
    End Sub

    Private Sub btn_InsertMember_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_UpdateMember.Click
        ' Передача значений полей в текст команды запроса
        If ExecuteQuery("EXEC Pr_AbonentsMembers " & _
                                                "@AbonentId = " & pref_AbonentId & ", " & _
                                                "@Surname = " & ConvertToNull(Me.txt_Surname.Text, True, 0) & ", " & _
                                                "@Name = " & ConvertToNull(Me.txt_Name.Text, True, 0) & ", " & _
                                                "@Patronymic = " & ConvertToNull(Me.txt_Patronymic.Text, True, 0) & ", " & _
                                                "@SexMembersId = " & ConvertToNull(Me.cmb_SexMember.SelectedValue, True, 0) & ", " & _
                                                "@Residence = " & ConvertToNull(Me.txt_Residence.Text, True, 0) & ", " & _
                                                "@DtResidence = " & ConvertToNull(Me.txt_DtResidence.Text, True, 1, "__.__.____") & ", " & _
                                                "@DtUnResidence = " & ConvertToNull(Me.txt_DtUnResidence.Text, True, 1, "__.__.____") & ", " & _
                                                "@FamilyRoleId = " & ConvertToNull(Me.сmb_FamilyRole.SelectedValue, True, 0) & ", " & _
                                                "@ShareOwner = " & Me.ckb_ShareOwner.Checked.ToString & ", " & _
                                                "@PDDateOfBirth = " & ConvertToNull(Me.txt_PDDateOfBirth.Text, True, 1, "__.__.____") & ", " & _
                                                "@PDSeries = " & ConvertToNull(Me.txt_PDSeries.Text, True, 1, "____") & ", " & _
                                                "@PDNumber = " & ConvertToNull(Me.txt_PDNumber.Text, True, 1, "______") & ", " & _
                                                "@PDDateOfIssue = " & ConvertToNull(Me.txt_PDDateOfIssue.Text, True, 1, "__.__.____") & ", " & _
                                                "@PDSubunit = " & ConvertToNull(Me.txt_PDSubunit.Text, True, 0) & ", " & _
                                                "@PDSubunitCode = " & ConvertToNull(Me.txt_PDSubunitCode.Text, True, 1, "___-___") & ", " & _
                                                "@PDString = " & ConvertToNull(Me.txt_PDString.Text, True, 0) & ", " & _
                                                "@Phone = " & ConvertToNull(Me.txt_MemPhoneMobile.Text, True, 0) & ", " & _
                                                "@Email = " & ConvertToNull(Me.txt_MemEmail.Text, True, 0) & ", " & _
                                                "@AddressOfLive = " & ConvertToNull(Me.txt_AddressOfLive.Text, True, 0) & ", " & _
                                                "@PlaceOfWork = " & ConvertToNull(Me.txt_PlaceOfWork.Text, True, 0) & ", " & _
                                                "@Note = " & ConvertToNull(Me.txt_NoteMember.Text, True, 0) & ", " & _
                                                "@Function = 2",
 _
                                                "InsertMember"
                                            ) Then
            If NewOrQusar Then
                With New frInfo
                    .Mess = "Перекачка записи успешно завершена"
                    .Show()  ' Всплываюшее сообщение
                End With
            Else
                With New frInfo
                    .Mess = "Новый член семьи успешно добавлен..."
                    .Show()  ' Всплываюшее сообщение
                End With
            End If
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub
End Class