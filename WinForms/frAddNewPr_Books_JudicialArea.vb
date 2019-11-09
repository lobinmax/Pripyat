Imports System.Drawing.SystemColors ' Импорт пространства системной политры
Imports DevExpress.XtraEditors

Public Class frAddNewPr_Books_JudicialArea

    Dim DG_JudicialArea_row As Object = frBooksJudicialArea.DG_JudicialArea.CurrentRow     ' Активная строка на гриде с Судебными участками

    Private Sub frAddNewPr_Books_JudicialArea_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()    ' Выгружаем форму
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.Close()      ' Закрываем форму
    End Sub

    Private Sub frAddNewPr_Books_JudicialArea_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EventChangedControl = False     ' Отключение обработки событий
        ' Загрузка зон обслуживания
        SelectQueryData("ZoneOfService", _
 _
                                "SELECT * " & _
                                "FROM Pr_ZoneOfService " & _
                                "ORDER BY ZoneOfServiceId", _
 _
                        "frAddNewPr_Books_JudicialArea_Load.ZoneOfService")

        ' Привязка зон обслуживания к cmd_cmb_ZoneOfService
        With Me.cmb_ZoneOfService
            .DataSource = iDataSet.Tables("ZoneOfService")
            .DisplayMember = "Name"
            .ValueMember = "ZoneOfServiceId"
            .SelectedIndex = 0
        End With

        ' Привязка видов инстанций к cmdTS_CourtType
        With Me.cmb_CourtType
            .DataSource = iDataSet.Tables("CourtType")
            .DisplayMember = "Name"
            .ValueMember = "CourtTypeId"
            .SelectedValue = frBooksJudicialArea.cmdTS_CourtType.ComboBox.SelectedValue
        End With

        ' Загрузка судей
        GetPr_Judges(Me.cmb_CourtType.SelectedValue)
        ' Привязка судей к cmb_CurrentJudges
        With Me.cmb_CurrentJudges
            .DataSource = iDataSet.Tables("Judges")
            .DisplayMember = "Name"
            .ValueMember = "JudgeId"
        End With

        If AddOrEdit = 3 Then  ' если форма запущена на изменение записи
            Me.cmb_CourtType.Enabled = False
            Me.Text = "Изменение информации по судебному участку"
            ' Заполнение полей данными из активной строки на DG_JudicialArea
            Me.cmb_CourtType.SelectedValue = DG_JudicialArea_row.Cells("CourtTypeId").Value.ToString()
            Me.txtM_Postal.Text = DG_JudicialArea_row.Cells("Postal").Value.ToString()
            Me.txt_Adress.Text = DG_JudicialArea_row.Cells("AdressStreet").Value.ToString()
            Me.txtM_House.Text = DG_JudicialArea_row.Cells("HouseNumber").Value.ToString()
            Me.cmb_ZoneOfService.SelectedValue = DG_JudicialArea_row.Cells("ZoneOfServiceId").Value.ToString()
            Me.txt_JudicialAreaName.Text = DG_JudicialArea_row.Cells("JudicialAreaName").Value.ToString()
            Me.cmb_CurrentJudges.SelectedValue = DG_JudicialArea_row.Cells("CurrentJudgeId").Value.ToString()
            ' Если данные из базы уже есть то, меняем настройки маски
            If DG_JudicialArea_row.Cells("Number").Value.ToString() <> "" Then
                Me.txtM_Number.TextMaskFormat = MaskFormat.IncludeLiterals
                Me.txtM_Number.Text = DG_JudicialArea_row.Cells("Number").Value.ToString()
            End If
            ' Если данные из базы уже есть то, меняем настройки маски
            If DG_JudicialArea_row.Cells("Phone").Value.ToString() <> "" Then
                Me.txt_Phone.TextMaskFormat = MaskFormat.IncludePromptAndLiterals
                Me.txt_Phone.Text = DG_JudicialArea_row.Cells("Phone").Value.ToString()
            End If
            ' Если данные из базы уже есть то, меняем настройки маски
            If DG_JudicialArea_row.Cells("PhoneMobile").Value.ToString() <> "" Then
                Me.txtM_PhoneMobile.TextMaskFormat = MaskFormat.IncludePromptAndLiterals
                Me.txtM_PhoneMobile.Text = DG_JudicialArea_row.Cells("PhoneMobile").Value.ToString()
            End If
            ' Если данные из базы уже есть то, меняем цвет текста и маску
            If DG_JudicialArea_row.Cells("email").Value.ToString() <> "" Then
                Me.txtM_mail.Mask = ""
                Me.txtM_mail.ForeColor = WindowText
                Me.txtM_mail.Text = DG_JudicialArea_row.Cells("email").Value.ToString()
            End If
            ' Если данные из базы уже есть то, меняем цвет текста
            If DG_JudicialArea_row.Cells("Site").Value.ToString() <> "" Then
                Me.txt_Site.ForeColor = WindowText
                Me.txt_Site.Text = DG_JudicialArea_row.Cells("Site").Value.ToString()
            End If
        End If
        ' Если выбран Мировой суд
        If Me.cmb_CourtType.SelectedValue = 1 Then
            ' Отображаем номер участка
            Me.txtM_Number.Enabled = True
        Else ' Если выбран Федеральный суд
            ' Скрываем номер участка, у федералов нет номеров
            Me.txtM_Number.Enabled = False
            Me.txtM_Number.Text = ""
        End If
        EventChangedControl = True      ' Включение обработки событий
    End Sub

    ' Запуск диалога для выбора адреса
    Private Sub Btn_CheckAdress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_CheckAdress.Click
        ' Если диалог вернул оК то,
        If frAdressAreal.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ' То заносим полный путь из дерева адресов
            Me.txt_Adress.Text = AddressString
        End If
        frAdressAreal.Dispose()         ' Выгружаем форму
        Me.txtM_Postal.Focus()          ' Переводим фокус на поле с индексом
        Me.txtM_Postal.Select(0, 6)     ' И выделяем все 6-ть знаков
    End Sub

#Region "Обработка Почтового индекса"
    Private Sub txtM_Postal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtM_Postal.Click
        ' Если НЕ инициализирован вход в поле
        If iEnter = False Then
            sender.Select(0, 6)     ' Выделяем 6-ть знаков в поле 
            iEnter = True           ' Отмечаем что выполнен вход в поле
        End If
    End Sub
    Private Sub txtM_Postal_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtM_Postal.Leave
        iEnter = False          ' Отмечаем что выполнен выход из поле
    End Sub
    Private Sub txtM_Postal_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtM_Postal.Validating
        ' Если текст в поле НЕ соответствует маске и в поле НЕ пусто
        If sender.MaskFull = False And sender.Text <> "" Then
            ' сообщение об ошибке и фокус обратно в поле
            XtraMessageBox.Show("Почтовый индекс не соответствует маске", _
                            "Заполните почтовый индекс", _
                            MessageBoxButtons.OK, _
                            MessageBoxIcon.Asterisk)
            sender.Focus()
        End If
    End Sub
#End Region

#Region "Обработка Номера дома"
    Private Sub txtM_House_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtM_House.Click
        ' Если НЕ инициализирован вход в поле
        If iEnter = False Then
            sender.Select(3, 10)    ' Выделяем 10-ть знаков в поле начиная с 3-го
            iEnter = True           ' Отмечаем что выполнен вход в поле
        End If
    End Sub
    Private Sub txtM_House_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtM_House.Leave
        iEnter = False              ' Отмечаем что выполнен выход из поле
    End Sub
    Private Sub txtM_House_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtM_House.Validated
        ' В настройках маски исключаем и подсказки и литералы
        sender.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
    End Sub
#End Region

#Region "Обработка Номера телефона"
    Private Sub txt_Phone_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Phone.Click
        ' Если НЕ инициализирован вход в поле
        If iEnter = False Then
            sender.Select(5, sender.TextLength)     ' Выделяем текст с 5-го и до конца поля
            iEnter = True                           ' Отмечаем что выполнен вход в поле
        End If
    End Sub
    Private Sub txt_Phone_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Phone.Leave
        iEnter = False                              ' Отмечаем что выполнен выход из поле
    End Sub
    Private Sub txt_Phone_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Phone.Validated
        ' В настройках маски исключаем и подсказки и литералы
        sender.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
        ' Если текст в поле НЕ соответствует маске и в поле НЕ пусто
        If sender.MaskFull = False And sender.Text <> "" Then
            ' В настройках маски исключаем и подсказки и литералы
            sender.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
            ' сообщаем об ошибке и переводим фокус обратно в поле
            XtraMessageBox.Show("Номер городского телефона не соответствует маске", _
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

#Region "Обработка Номера сотового телефона"
    Private Sub txtM_PhoneMobile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtM_PhoneMobile.Click
        ' Если НЕ инициализирован вход в поле 
        If iEnter = False Then
            sender.Select(4, sender.TextLength)     ' Выделяем текст с 5-го и до конца поля
            iEnter = True                           ' Отмечаем что выполнен вход в поле
        End If
    End Sub
    Private Sub txtM_PhoneMobile_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtM_PhoneMobile.Leave
        iEnter = False                              ' Отмечаем что выполнен выход из поле
    End Sub
    Private Sub txtM_PhoneMobile_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtM_PhoneMobile.Validated
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

#Region "Обработка Электронной почты"
    ' События Email - Проверка корректности эл.адреса
    Private Sub txtM_mail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtM_mail.Click
        ' Если НЕ инициализирован вход в поле
        If iEnter = False Then
            sender.Select(0, sender.TextLength)     ' Выделяем весь тект в поле
            sender.Mask = ""                        ' Очищаем поле
            sender.ForeColor = WindowText           ' Меняем цвет текта 
            iEnter = True                           ' Отмечаем что выполнен вход в поле
        End If
    End Sub
    Private Sub txtM_mail_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtM_mail.Leave
        iEnter = False                                  ' Отмечаем что выполнен выход из поле
        ' Если в поле пусто
        If sender.Text = "" Then
            sender.Mask = "____________@_____.____"     ' Устанавливаем маску поля
            sender.ForeColor = InactiveCaption          ' Меняем цвет текта
        End If
    End Sub
    Private Sub txtM_mail_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtM_mail.KeyPress
        Dim s As String = sender.Text
        Dim c As Integer = 0
        If e.KeyChar = "@" Then c = InStr(1, s, "@") '      Если введена @ то, считаем сколько их уже
        If c > 1 Then e.Handled = True : Beep() '           Если их больше одной то отменяем ввод
    End Sub
    Private Sub txtM_mail_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtM_mail.TextChanged
        ' Если в Боксе один знак и он Собака то очищаем бокс
        If Len(sender.Text) = 1 And sender.Text = "@" Then sender.Clear() : Beep()
    End Sub
    Private Sub txtM_mail_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtM_mail.Validated
        ' Если емайл не прошел проверку и поле НЕ пустое и не равно маске
        If EmailAddressCheck(sender.Text) = False And sender.Text <> "" And sender.Text <> "____________@_____.____" Then
            ' сообщаем об ошибке и переводим фокус обратно в поле
            XtraMessageBox.Show("Исправьте E-mail адрес (ivanov@mail.ru)!", "Не корректный E-mail!")
            sender.Focus()
        End If
    End Sub
#End Region

#Region "Обработка Адреса домашней страницы"
    Private Sub txt_Site_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Site.Click
        ' Если НЕ инициализирован вход в поле
        If iEnter = False Or txt_Site.SelectionStart < 7 Then
            sender.Select(7, sender.TextLength)     ' Выделяем текст с 5-го и до конца поля
            sender.ForeColor = WindowText           ' Меняем цвет текста
            iEnter = True                           ' Отмечаем что выполнен вход в поле
        End If
    End Sub
    Private Sub txt_Site_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Site.Leave
        ' Если НЕ инициализирован вход в поле
        iEnter = False
        If sender.Text = "http://" Or sender.Text = "" Then
            sender.ForeColor = InactiveCaption
            sender.Text = "http://"
        End If
    End Sub
    Private Sub txt_Site_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Site.KeyPress
        ' Если нажата BackSpace и поле остался только "http://", то отменяем стирание
        If Asc(e.KeyChar) = 8 And sender.Text = "http://" Then e.Handled = True
    End Sub
#End Region

#Region "Обработка номера судебного участка"
    Private Sub txtM_Number_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtM_Number.Click
        ' Если НЕ инициализирован вход в поле
        If iEnter = False Then
            sender.Select(2, 4)             ' Выделяем текст с 5-го и до конца поля
            iEnter = True                   ' Отмечаем что выполнен вход в поле
        End If
    End Sub
    Private Sub txtM_Number_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtM_Number.Leave
        iEnter = False                      ' Отмечаем что выполнен выход из поле
    End Sub
    Private Sub txtM_Number_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtM_Number.Validated
        ' В настройках маски исключаем и подсказки и литералы
        sender.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
        ' Если в поле не пусто, то Включаем подсказки
        If sender.Text <> "" Then sender.TextMaskFormat = MaskFormat.IncludeLiterals
    End Sub
#End Region

    ' Событие при изменении инстанции
    Private Sub cmb_CourtType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_CourtType.SelectedIndexChanged
        ' Если обработка событий включена то, при изменении инстанции, 
        ' обновляем список судей по этой инстанции
        If EventChangedControl Then
            GetPr_Judges(sender.SelectedValue)
            ' Если выбран Мировой суд
            If sender.SelectedValue = 1 Then
                ' Отображаем номер участка
                Me.txtM_Number.Enabled = True
            Else ' Если выбран Федеральный суд
                ' Скрываем номер участка, у федералов нет номеров
                Me.txtM_Number.Enabled = False
                Me.txtM_Number.Text = ""
            End If
        End If
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        ' Если поля прошли проверку
        If CheckFill() Then
            If AddOrEdit = 2 Then ' Добавление записи
                If ExecuteQuery(
                                                "EXEC Pr_Books_JudicialArea " & _
                                                    "@JudicialAreaId = NULL, " & _
                                                    "@CourtTypeId = " & Me.cmb_CourtType.SelectedValue & ", " & _
                                                    "@Postal = " & ConvertToNull(Me.txtM_Postal.Text, True, 0) & ", " & _
                                                    "@Adress = " & ConvertToNull(Me.txt_Adress.Text, True, 0) & ", " & _
                                                    "@HouseNumber = " & ConvertToNull(Me.txtM_House.Text, True, 0) & ", " & _
                                                    "@ZoneOfServiceId = " & Me.cmb_ZoneOfService.SelectedValue & ", " & _
                                                    "@JudicialAreaName = " & ConvertToNull(Me.txt_JudicialAreaName.Text, True, 0) & ", " & _
                                                    "@Number = " & ConvertToNull(Me.txtM_Number.Text, True, 0) & ", " & _
                                                    "@CurrentJudgeId = " & Me.cmb_CurrentJudges.SelectedValue & ", " & _
                                                    "@Phone = " & ConvertToNull(Me.txt_Phone.Text, True, 0) & ", " & _
                                                    "@PhoneMobile = " & ConvertToNull(Me.txtM_PhoneMobile.Text, True, 0) & ", " & _
                                                    "@email = " & ConvertToNull(Me.txtM_mail.Text, True, 0) & ", " & _
                                                    "@Site = " & ConvertToNull(Me.txt_Site.Text, True, 1, "http://") & ", " & _
                                                    "@Function = " & AddOrEdit,
 _
                                                "AddNewPr_Books_JudicialArea"
                                             ) Then
                    With New frInfo     ' Всплываюшее сообщение 
                        .Mess = "В справочник добавлен новый судебный участок..."
                        .Show()
                    End With
                    Me.Close()      ' Закрываем форму
                End If
            End If

            If AddOrEdit = 3 Then   ' Изменение записи
                If ExecuteQuery(
                                                "EXEC Pr_Books_JudicialArea " & _
                                                    "@JudicialAreaId = " & DG_JudicialArea_row.Cells("JudicialAreaId").Value.ToString() & ", " & _
                                                    "@CourtTypeId = " & Me.cmb_CourtType.SelectedValue & ", " & _
                                                    "@Postal = " & ConvertToNull(Me.txtM_Postal.Text, True, 0) & ", " & _
                                                    "@Adress = " & ConvertToNull(Me.txt_Adress.Text, True, 0) & ", " & _
                                                    "@HouseNumber = " & ConvertToNull(Me.txtM_House.Text, True, 0) & ", " & _
                                                    "@ZoneOfServiceId = " & Me.cmb_ZoneOfService.SelectedValue & ", " & _
                                                    "@JudicialAreaName = " & ConvertToNull(Me.txt_JudicialAreaName.Text, True, 0) & ", " & _
                                                    "@Number = " & ConvertToNull(Me.txtM_Number.Text, True, 0) & ", " & _
                                                    "@CurrentJudgeId = " & Me.cmb_CurrentJudges.SelectedValue & ", " & _
                                                    "@Phone = " & ConvertToNull(Me.txt_Phone.Text, True, 0) & ", " & _
                                                    "@PhoneMobile = " & ConvertToNull(Me.txtM_PhoneMobile.Text, True, 0) & ", " & _
                                                    "@email = " & ConvertToNull(Me.txtM_mail.Text, True, 0) & ", " & _
                                                    "@Site = " & ConvertToNull(Me.txt_Site.Text, True, 1, "http://") & ", " & _
                                                    "@Function = " & AddOrEdit,
 _
                                                "Edit.Pr_Books_JudicialArea"
                                              ) Then
                    With New frInfo     ' Всплываюшее сообщение
                        .Mess = "Запись в справочнике успешно изменена..."
                        .Show()
                    End With
                    Me.Close()      ' Закрываем форму
                End If
            End If
            ' Возвращаем оК в родительскую форму
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End If
    End Sub

    ' Проверка заполнения полей
    Private Function CheckFill() As Boolean
        If txt_Adress.Text = "" _
        Or txtM_Postal.Text = "" _
        Or txtM_House.Text = "" _
        Or txt_JudicialAreaName.Text = "" Then
            XtraMessageBox.Show("Не заполнены обязательные поля!", _
                            "Заполните обязательные поля", _
                            MessageBoxButtons.OK, _
                            MessageBoxIcon.Stop)
            Return False
        Else
            If Me.cmb_CourtType.SelectedValue = 1 And Me.txtM_Number.Text = "" Then
                XtraMessageBox.Show("Не заполнены обязательные поля!", _
                        "Заполните обязательные поля", _
                        MessageBoxButtons.OK, _
                        MessageBoxIcon.Stop)
                Return False
            Else
                Return True
            End If
            Return True
        End If
    End Function

End Class
