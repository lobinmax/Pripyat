Imports System.Windows.Forms
Imports System.Drawing.SystemColors ' Импорт пространства системной политры
Imports DevExpress.XtraEditors

Public Class frAddNewPr_Book_CopPerformers

    Dim DG_Cop_row As Object = frBookCopPerformers.DG_CopPerformers.CurrentRow     ' Активная строка на гриде с Приставами

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frAddNewPr_Books_Judges_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()    ' Выгружаем форму
    End Sub

    ' Загрузка формы
    Private Sub frAddNewPr_Books_Judges_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' если форма запущена на изменение записи
        If AddOrEdit = 3 Then
            Me.Text = "Изменение данных Пристава - Исполнителя"
            ' Заполнение полей данными из активной строки на DG_CopPerformers
            Me.txt_CopName.Text = DG_Cop_row.Cells("Name").Value.ToString()
            ' Если данные из базы уже есть то, меняем настройки маски
            If DG_Cop_row.Cells("Phone").Value.ToString() <> "" Then
                Me.txt_Phone.TextMaskFormat = MaskFormat.IncludePromptAndLiterals
                Me.txt_Phone.Text = DG_Cop_row.Cells("Phone").Value.ToString()
            End If
            ' Если данные из базы уже есть то, меняем настройки маски
            If DG_Cop_row.Cells("PhoneMobile").Value.ToString() <> "" Then
                Me.txtM_PhoneMobile.TextMaskFormat = MaskFormat.IncludePromptAndLiterals
                Me.txtM_PhoneMobile.Text = DG_Cop_row.Cells("PhoneMobile").Value.ToString()
            End If
            ' Если данные из базы уже есть то, меняем цвет текста и маску
            If DG_Cop_row.Cells("email").Value.ToString() <> "" Then
                Me.txtM_mail.Mask = ""
                Me.txtM_mail.ForeColor = WindowText
                Me.txtM_mail.Text = DG_Cop_row.Cells("email").Value.ToString()
            End If
        End If
    End Sub

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

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        ' Если поля прошли проверку
        If CheckFill() Then
            If AddOrEdit = 2 Then ' Добавление записи
                If ExecuteQuery(
                                                "EXEC Pr_Books_CopPerformers " & _
                                                        "@CopPerformerId = NULL, " & _
                                                        "@Name = " & ConvertToNull(Me.txt_CopName.Text, True, 0) & ", " & _
                                                        "@Phone = " & ConvertToNull(Me.txt_Phone.Text, True, 0) & ", " & _
                                                        "@PhoneMobile = " & ConvertToNull(Me.txtM_PhoneMobile.Text, True, 0) & ", " & _
                                                        "@email = " & ConvertToNull(Me.txtM_mail.Text, True, 0) & ", " & _
                                                        "@Function = " & AddOrEdit,
 _
                                                "AddNew.Pr_Books_CopPerformers"
                                             ) Then
                    With New frInfo     ' Всплываюшее сообщение 
                        .Mess = "В справочник добавлен Пристав - Исполнитель..."
                        .Show()
                    End With
                    Me.Close()      ' Закрываем форму
                End If
            End If

            If AddOrEdit = 3 Then   ' Изменение записи
                If ExecuteQuery(
                                                "EXEC Pr_Books_CopPerformers " & _
                                                    "@CopPerformerId = " & DG_Cop_row.Cells("CopPerformerId").Value.ToString() & ", " & _
                                                    "@Name = " & ConvertToNull(Me.txt_CopName.Text, True, 0) & ", " & _
                                                    "@Phone = " & ConvertToNull(Me.txt_Phone.Text, True, 0) & ", " & _
                                                    "@PhoneMobile = " & ConvertToNull(Me.txtM_PhoneMobile.Text, True, 0) & ", " & _
                                                    "@email = " & ConvertToNull(Me.txtM_mail.Text, True, 0) & ", " & _
                                                    "@Function = " & AddOrEdit,
 _
                                                "Edit.Pr_Books_CopPerformers"
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
        If Me.txt_CopName.Text = "" Then
            XtraMessageBox.Show("Не указана ФИО Пристава - Исполнителя!", _
                            "Заполните ФИО", _
                            MessageBoxButtons.OK, _
                            MessageBoxIcon.Stop)
            Return False
        Else
            Return True
        End If
    End Function
End Class
