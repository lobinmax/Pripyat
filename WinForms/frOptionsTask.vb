Imports DevExpress.XtraEditors
Public Class frOptionsTask
    Dim W As Double = 365 / 15                                                          ' Доля ширины формы
    Dim H As Double = 203 / 15                                                          ' Доля высоты формы 
    Dim iTimerW As Boolean = True                                                    ' вкл/откл обработки таймером изменения ширины формы
    Dim iTimerH As Boolean = True                                                    ' вкл/откл обработки таймером изменения высоты формы
    ' Координаты формы при загрузке
    Friend _X As Integer
    Friend _Y As Integer
    Friend SessionId As String          ' Перечень сеансов печати
    Friend PerformersId As String       ' Перечень дополнительных исполнителей задания


    Dim PreferenceForms As String       ' Ветка в реестре для хранения настроек формы

    Private Sub TimerW_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerW.Tick
        If iTimerW Then
            ' Плавное появление формы
            If Me.Width >= 365 Then
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
            If Me.Height >= 203 Then
                TimerW.Stop()
                iTimerH = False
            Else
                Me.Height = H + Me.Height
            End If
        End If
    End Sub
    Private Sub frOptionsTask_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frOptionsTask_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PreferenceForms = pref_UserSettings & "\" & Me.Name & "\"
        dt_Performance.Text = Now.ToShortDateString
        Me.chb_AddToWorking.Checked = RegistryRead(PreferenceForms, "chb_AddToWorkingValue", 0)
        ' Настраиваем привязку
        Dim BindSourse As New BindingSource         ' Новая привязка данных
        BindSourse.DataSource = iDataSet
        BindSourse.DataMember = "InspectorsTree." & frAskur.Name
        ' Связываем с AdvTV_TaskHistory
        Me.cmt_SubPerformers.DataSource = BindSourse
        ' Отображаемые столбцы
        Me.cmt_SubPerformers.DisplayMembers = "Inspector"
        ' Настраиваем столбцы
        For i = 0 To Me.cmt_SubPerformers.Columns.Count - 1
            ' Синхронизируем имена столбцов с именами в базе 
            ' для последующего оперирования
            Me.cmt_SubPerformers.Columns(i).Name = Me.cmt_SubPerformers.Columns(i).DataFieldName
        Next
        ' Настройка нодов
        For Each n As DevComponents.AdvTree.Node In Me.cmt_SubPerformers.Nodes
            n.CheckBoxVisible = True
        Next
        ' Отображение формы рядом с курсором мыши
        Me.Location = New Point(_X, _Y)
        ' Плавное появление формы
        Me.Width = 0
        Me.Height = 0
        TimerW.Start()
        TimerH.Start()
    End Sub

    Private Sub chb_AddToWorking_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chb_AddToWorking.CheckedChanged
        ' Запись параметра в настройки
        RegistryWrite(PreferenceForms, "chb_AddToWorkingValue", chb_AddToWorking.CheckState)
    End Sub

    Private Sub btn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_OK.Click
        Dim c As Integer = 0        ' Счетчик чекнутых нодов
        Dim TaskSheetId As Integer
        For Each n As DevComponents.AdvTree.Node In Me.cmt_SubPerformers.Nodes
            If n.Checked Then
                c += 1
            End If
        Next
        ' Если не один исполнитель не выбран
        If c = 0 Then
            XtraMessageBox.Show("Нет контролеров назначенных в качестве исполнителей задания!", _
                            Application.ProductName, _
                            MessageBoxButtons.OK, _
                            MessageBoxIcon.Information)
            Me.cmt_SubPerformers.ShowDropDown()
            Exit Sub
        End If
        TaskSheetId = ExecuteScalar(
                                    "EXEC Pr_JournalTaskRegistration " & _
                                    "@DocumentTypeId = 9 ," & _
                                    "@DtPerformance = '" & Me.dt_Performance.Text & "', " & _
                                    "@SessionId = '" & SessionId & "', " & _
                                    "@PerformerId = '" & PerformersId & "', " & _
                                    "@Function = 2"
                                    )
        ' передаем полученные параметры обратно
        frAskur.TaskSheetId = TaskSheetId
        If Me.chb_AddToWorking.Checked Then
            frAskur.OnHands = TaskSheetId
        Else
            frAskur.OnHands = 0
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cmt_SubPerformers_ButtonCustomClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmt_SubPerformers.ButtonCustomClick
        For Each n As DevComponents.AdvTree.Node In Me.cmt_SubPerformers.Nodes
            n.Checked = False
        Next
        Me.cmt_SubPerformers.ShowDropDown()
    End Sub
    Private Sub cmt_SubPerformers_ButtonCustom2Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmt_SubPerformers.ButtonCustom2Click
        For Each n As DevComponents.AdvTree.Node In Me.cmt_SubPerformers.Nodes
            n.Checked = True
        Next
        Me.cmt_SubPerformers.ShowDropDown()
    End Sub

    Private Sub cmt_SubPerformers_PopupClose(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmt_SubPerformers.PopupClose
        Dim s As String = ""
        Dim i As String = ""
        For Each n As DevComponents.AdvTree.Node In Me.cmt_SubPerformers.Nodes
            Dim iRows As DataRow = iDataSet.Tables("InspectorsTree." & frAskur.Name).Rows(n.Index)
            If n.Checked Then
                s = s & Chr(10) & n.Text                    ' Для всплывающего сообщения
                i = i & iRows.Item("InspectorId") & " "     ' для отправки в базу
            End If
        Next
        PerformersId = Replace(Trim(i), " ", ",")
        Me.ToolTip.SetToolTip(Me.cmt_SubPerformers, s)
    End Sub
End Class