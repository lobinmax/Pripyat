Imports DevExpress.XtraEditors
Imports System.Windows.Forms

Public Class frChooseMember
    Dim W As Double = 421 / 25                                                          ' Доля ширины формы
    Dim H As Double = 52 / 25                                                           ' Доля высоты формы 
    Dim iTimerW As Boolean = True                                                    ' вкл/откл обработки таймером изменения ширины формы
    Dim iTimerH As Boolean = True                                                    ' вкл/откл обработки таймером изменения высоты формы

    Private Sub frChooseMember_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Запрос на выборку членов семьи по Квазару для ComboBoxa перекачки
        SelectQueryData(
                        "FamilyMember.List_kwz", _
 _
                        "EXEC Pr_AbonentsMembers " & _
                                "@AbonentId = " & pref_AbonentId & ", " & _
                                "@Function = 5", _
 _
                        "ClickTree_PanMembers.1"
                        )
        ' Заполнение cmb_MembersQuasar членов семьи по Квазару
        With Me.cmb_MembersQuasar
            .DataSource = iDataSet.Tables("FamilyMember.List_kwz")
            .DisplayMember = "FullName"
            .ValueMember = "FamilyMemberId"
        End With

        ' Плавное появление формы
        Me.Width = 0
        Me.Height = 0
        TimerW.Start()
        TimerH.Start()
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim iRowCount As Integer = frAbonents.DGView_PrMembers.RowCount ' Кол-во строк в Гриде
        ' Цикл по всем строкам Грида 
        If iRowCount <> 0 Then
            For i = 0 To iRowCount - 1
                Dim Pr_F As String = frAbonents.DGView_PrMembers.Rows(i).Cells("Surname").Value
                Dim Pr_I As String = frAbonents.DGView_PrMembers.Rows(i).Cells("Name").Value
                Dim Pr_O As String = frAbonents.DGView_PrMembers.Rows(i).Cells("Patronymic").Value
                Dim Pr_FIO As String = Pr_F & " " & Pr_I & " " & Pr_O
                ' Если ФИО уже присутствует в гриде членов семьи то, сообщение об этом
                If Pr_FIO = Me.cmb_MembersQuasar.Text Then
                    XtraMessageBox.Show("Абонента <" & Me.cmb_MembersQuasar.Text & "> добавить невозможно, " & Chr(10) & _
                                    "так как запись уже существует в " & Application.ProductName, _
                                    Application.ProductName & " / Запись уже существет", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                    Me.Close()
                End If
            Next
        End If
        ' В случае несовпадения ФИО, добавляется выбранный член семьи из Квазара
        ' Выкружаем по нему информацию из Квазара
        SelectQueryData(
                        "FamilyMember", _
 _
                        "EXEC Pr_AbonentsMembers " & _
                              "@MemberId = " & Me.cmb_MembersQuasar.SelectedValue & ", " & _
                              "@Function = 6", _
 _
                        "FamilyMember_LoadFromKWZ"
                        )
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub TimerW_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerW.Tick
        If iTimerW Then
            ' Плавное появление формы
            If Me.Width >= 421 Then
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
            If Me.Height >= 52 Then
                TimerW.Stop()
                iTimerH = False
            Else
                Me.Height = H + Me.Height
            End If
        End If
    End Sub

    ' Таскание формы по экрану
    Private Sub Panel1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseDown
        sender.Capture = False
        Me.WndProc(Message.Create(Me.Handle, &HA1, New IntPtr(2), IntPtr.Zero))
    End Sub

End Class
