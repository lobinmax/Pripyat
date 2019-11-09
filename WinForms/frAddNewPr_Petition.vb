Imports DevExpress.XtraEditors

Public Class frAddNewPr_Petition
    Dim iCurRow As Object = frAbonents.PIR1_DGView_PetitionsDebt.CurrentRow()   ' Активная строка на гриде c слушаниями
    Dim MemH As Integer = 165           ' Предел высоты формы
    Dim MemW As Integer = 246           ' Предел ширины формы
    Dim SpeedPaint As Integer = 10      ' Скорость развертывания формы

    Private Sub frAddNewPr_Petition_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        EventChangedControl = False ' Отключение обработки событий
        ' Заполнение PIR1_cmb_CopPerformer приставов
        With Me.PIR1_cmb_CopPerformer
            .DataSource = iDataSet.Tables("CopPerformers")
            .DisplayMember = "name"
            .ValueMember = "id"
            .Text = Nothing
        End With
        Me.PIR1_txt_ExcitementDt.Text = Now.Date                                            ' Сегодня
        If iCurRow.Cells("DebtSummAfterDecision").Value.ToString = "" Then
            Me.PIR1_txt_PetitionSumm.Text = _
                OutBD_Money(iCurRow.Cells("DebtSumm").Value + iCurRow.Cells("GovTax").Value, 0, "N")
        Else
            Me.PIR1_txt_PetitionSumm.Text = _
                OutBD_Money(iCurRow.Cells("DebtSummAfterDecision").Value + iCurRow.Cells("GovTax").Value, 0, "N")
        End If
        Me.PIR1_txt_ExecutiveNumber.Select()                                                ' Выбираем поле с номером ИП
        ' Отображение формы на 20 пикселей от курсора мыши
        Me.Location = New Point(Cursor.Position.X, Cursor.Position.Y)
        ' Плавное появление формы
        Me.Width = 0
        Me.Height = 0
        TimerW.Start()
        TimerH.Start()
        EventChangedControl = True ' Включение обработки событий
    End Sub

#Region "События на контролах с датами"
    Sub PIR1_txt_ExcitementDt_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PIR1_txt_ExcitementDt.MouseClick
        DateMaskEvents("MouseClick", sender)
    End Sub
    Private Sub PIR1_txt_ExcitementDt_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PIR1_txt_ExcitementDt.KeyUp
        DateMaskEvents("KeyUp", sender, e.KeyCode)
    End Sub
    ' Кнопки календаря
    Private Sub btn_CalPIR1_txt_ExcitementDt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CalPIR1_txt_ExcitementDt.ValueChanged
        ' Имя контрола в который нужно внести дату берется из Тега кнопки календаря
        Me.Panel1.Controls(sender.Tag).Text = sender.Text
    End Sub
    Private Sub btn_CalPIR1_txt_ExcitementDt_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_CalPIR1_txt_ExcitementDt.MouseDown
        ' Если в контроле дата, переносим в календарь
        If IsDate(Me.Panel1.Controls(sender.Tag).Text) Then _
            sender.Value = Me.Panel1.Controls(sender.Tag).Text
    End Sub
#End Region

#Region "Обработка денежных полей"
    Private Sub PIR1_txt_PetitionSumm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PIR1_txt_PetitionSumm.KeyPress
        ' Проверка корректности вводимых данных (только цыфры, и ограниченное количество символов)
        MoneyTextBox_Numbers(sender, e)
    End Sub
    Private Sub PIR1_txt_PetitionSumm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PIR1_txt_PetitionSumm.Click
        MoneyTextBox_EnterLeave(sender, e, "Click", "G")
    End Sub
    Private Sub PIR1_txt_PetitionSumm_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PIR1_txt_PetitionSumm.Leave
        MoneyTextBox_EnterLeave(sender, e, "Leave", "N")
    End Sub
#End Region

    ' Проверка заполнения всех полей
    Private Function CheckValidate() As Boolean
        If Me.PIR1_txt_ExecutiveNumber.Text = "" Or _
           Me.PIR1_txt_ExcitementDt.Text = "" Or _
           Me.PIR1_txt_ExcitementDt.Text = "" Then
            XtraMessageBox.Show("Не заполнены обязательные поля!",
                            "Отсутствуют значения",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1)
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub TimerW_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerW.Tick
        ' Плавное появление формы
        If Me.Width >= MemW Then
            sender.Stop()
        Else
            ' Если при увеличении, размер выходит за предел
            If (SpeedPaint + Me.Width) > MemW Then
                ' Приравниваем к пределу
                Me.Width = MemW
            Else
                ' Иначе продолжаем развертывать
                Me.Width = SpeedPaint + Me.Width
            End If
        End If
    End Sub
    Private Sub TimerH_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerH.Tick
        ' Плавное появление формы
        If Me.Height >= MemH Then
            sender.Stop()
        Else
            ' Если при увеличении, размер выходит за предел
            If (SpeedPaint + Me.Height) > MemH Then
                ' Приравниваем к пределу
                Me.Height = MemH
            Else
                ' Иначе продолжаем развертывать
                Me.Height = SpeedPaint + Me.Height
            End If
        End If
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        ' если все поля заполнены, то заносим данные в базу
        If CheckValidate() Then
            If ExecuteQuery(
                            "EXEC Pr_AbonentsPetitions " & _
                                            "@AbonentId = " & iCurRow.Cells("AbonentId").Value & ", " & _
                                            "@MemberId = " & iCurRow.Cells("MemberId").Value & ", " & _
                                            "@DtPeriodStart = '" & iCurRow.Cells("DtPeriodStart").Value & "', " & _
                                            "@DtPeriodEnd = '" & iCurRow.Cells("DtPeriodEnd").Value & "', " & _
                                            "@EnergyTypeId = " & iCurRow.Cells("EnergyTypeId").Value & ", " & _
                                            "@CopPerformerId = " & ConvertToNull(Me.PIR1_cmb_CopPerformer.SelectedValue.ToString, True, 0) & ", " & _
                                            "@ExecutiveNumber = " & ConvertToNull(Me.PIR1_txt_ExecutiveNumber.Text, True, 0) & ", " & _
                                            "@ExcitementDt = " & DateInDataBase(Me.PIR1_txt_ExcitementDt.Text) & ", " & _
                                            "@DebtSumm = " & OutBD_Money(Me.PIR1_txt_PetitionSumm.Text, 1, "G") & ", " & _
                                            "@Function = 2", _
 _
                            "AddNewPetition"
                            ) Then
                With New frInfo
                    .Mess = "Добавлены материалы нового" & Chr(10) & "исполнительного производства.."
                    .Show()     ' Всплываюшее сообщение
                End With
                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If
        End If
    End Sub
End Class