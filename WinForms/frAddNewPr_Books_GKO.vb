Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraEditors

Public Class frAddNewPr_Books_GKO
    Friend GKType As String                 ' Тип жилищн. организации (GKO / GKH)
    Dim CurrentGKONode As TreeListNode = frBookGKO.tlGKO.FocusedNode
    Public Sub New()
        ' Этот вызов является обязательным для конструктора.
        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
        InitializeComponent()
        Me.Opacity = 0                                  ' Форма полностью прозрачна
        tmWaitAnimation.StartWaitingIndicator(Me, 0)    ' Анимация загрузки
        LoadSpellChecker(Me.PanelControl2)              ' Загрузка словаря для проверки орфографии
    End Sub
    Private Sub frAddNewPr_Books_GKO_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        RemoveTableDataSet(Me)
    End Sub
    Private Sub frAddNewPr_Books_GKO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Select Case GKType
            Case "GKO"
                Me.peImage.EditValue = Global.Pripyat.My.Resources.Resources.gkoworker_250x334
                Me.lbName.Text = "Наименование Управляющей организации"
            Case "GKH"
                Me.peImage.EditValue = Global.Pripyat.My.Resources.Resources.gkhworker_250x386
                Me.lbName.Text = "Наименование Обслуживающей организации"
        End Select
        ' Если форма запущена для изменения записи
        If AddOrEdit = 3 Then
            SelectQueryData(
                            "GKinfo." & Me.Name,
                            "EXEC Pr_Books_GKO @GKid = " & CurrentGKONode("Id").ToString & ",@Function = 1, @GKType = " & GKType,
                            "Pr_GKOTree"
                            )
            Dim iRow As DataRow = iDataSet.Tables("GKinfo." & Me.Name).Rows(0)
            Me.txtName.Text = iRow("GKName").ToString
            Me.txtAddress.Text = iRow("GKAddress").ToString
            Me.txtEmail.Text = iRow("GKEmail").ToString
            Me.txtPhone.Text = iRow("GKPhone").ToString
            Me.txtPhoneMobile.Text = iRow("GKPhoneMobile").ToString
        End If
    End Sub
    ' Перетаскивание формы за любой участок
    Private Sub PanelControl1_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles PanelControl1.MouseDown,
                                                                                                                    PanelControl2.MouseDown,
                                                                                                                    peImage.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.Cursor = Cursors.NoMove2D
            sender.Capture = False
            Me.WndProc(Message.Create(Me.Handle, &HA1, New IntPtr(2), IntPtr.Zero))
            Me.Cursor = Cursors.Default
        End If
    End Sub
    ' После отображения формы
    Private Sub frAddNewPr_Books_GKO_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        ' фокус на элементы в которых будет проверка орфографии
        Me.txtAddress.Focus()
        Me.txtName.Focus()
        Me.Opacity = 1 ' Форма не прозрачная
        Me.peImage.Focus()
        ' включаем тень формы
        Me.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow
        tmWaitAnimation.StopWaitingIndicator()
    End Sub
    ' По ентеру переход на емайл
    Private Sub txtAddress_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtAddress.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtEmail.Focus()
            Me.txtEmail.SelectAll()
        End If
    End Sub
    ' Запись в базу
    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        Dim id As String = "NULL"
        Dim ParentId As String = 0
        ' проверка заполненности полей
        If CheckFilling() = False Then Me.DialogResult = Nothing : Exit Sub
        ' если есть записи и что то выбрано
        If frBookGKO.tlGKO.Nodes.Count <> 0 And frBookGKO.tlGKO.Selection.Count <> 0 Then
            id = CurrentGKONode("Id").ToString
            ParentId = CurrentGKONode("Id").ToString
        End If

        Select Case GKType
            Case "GKO"  ' Управляющие 
                If ExecuteQuery(
                    "EXEC Pr_Books_GKO " & _
                        "@GKOid = " & id & ", " & _
                        "@ParentId = 0," & _
                        "@GKOName = '" & Trim(Me.txtName.Text) & "', " & _
                        "@GKOAddress = '" & Trim(Me.txtAddress.Text) & "', " & _
                        "@GKOEmail = '" & Trim(Me.txtEmail.Text) & "', " & _
                        "@GKOPhone = " & ConvertToNull(Me.txtPhone.Text, True, 0) & ", " & _
                        "@GKOPhoneMobile = " & ConvertToNull(Me.txtPhoneMobile.Text, True, 0) & ", " & _
                        "@Function = " & AddOrEdit
                        ) Then
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                End If
            Case "GKH"  ' Обслуживающие 
                If ExecuteQuery(
                    "EXEC Pr_Books_GKH " & _
                        "@GKHid = " & id & ", " & _
                        "@ParentId = " & ParentId & ", " & _
                        "@GKHName = '" & Trim(Me.txtName.Text) & "', " & _
                        "@GKHAddress = '" & Trim(Me.txtAddress.Text) & "', " & _
                        "@GKHEmail = '" & Trim(Me.txtEmail.Text) & "', " & _
                        "@GKHPhone = " & ConvertToNull(Me.txtPhone.Text, True, 0) & ", " & _
                        "@GKHPhoneMobile = " & ConvertToNull(Me.txtPhoneMobile.Text, True, 0) & ", " & _
                        "@Function = " & AddOrEdit
                        ) Then
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                End If
        End Select
    End Sub
    'Проверка заполнения обязательных полей
    Private Function CheckFilling() As Boolean
        If Trim(Me.txtName.Text) = "" Or Trim(Me.txtAddress.Text) = "" Or Trim(Me.txtEmail.Text) = "" Then
            XtraMessageBox.Show("Не заполнены обязательные поля!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        Else
            Return True
        End If
    End Function

#Region "События при активации и дисактивации полей"
    Private Sub EnterControl(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.Enter,
                                                                                            txtAddress.Enter,
                                                                                            txtEmail.Enter,
                                                                                            txtPhone.Enter,
                                                                                            txtPhoneMobile.Enter
        ' Если первый вход в поле контрола
        If iEnter = False Then
            sender.SelectAll()      ' Выделяем весь текст
            iEnter = True           ' Вход состоялся
        End If
    End Sub
    Private Sub ClickControl(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.Click,
                                                                                            txtAddress.Click,
                                                                                            txtEmail.Click,
                                                                                            txtPhone.Click,
                                                                                            txtPhoneMobile.Click
        ' Если первый вход в поле контрола
        If iClicker = False Then
            sender.SelectAll()      ' Выделяем весь текст
            iClicker = True           ' Вход состоялся
        End If
    End Sub
    Private Sub LeaveControl(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.Leave, txtAddress.Leave, txtEmail.Leave, txtPhone.Leave, txtPhoneMobile.Leave
        iEnter = False ' Выход из поля состоялся
        iClicker = False
    End Sub
    ' при некорректном емайле
    Private Sub txtEmail_InvalidValue(sender As System.Object, e As DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs) Handles txtEmail.InvalidValue
        e.ErrorText = "Введен некорректный эл. адрес"
    End Sub
#End Region

    ' очистить поля с номерами
    Private Sub txt_ButtonPressed(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtPhoneMobile.ButtonPressed, txtPhone.ButtonPressed
        sender.Text = Nothing
        sender.SelectAll()
    End Sub
End Class