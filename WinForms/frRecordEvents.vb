Imports DevExpress.XtraEditors
Imports DevExpress.Utils
Imports FastReport.Dialog
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraSplashScreen

Public Class frRecordEvents
    Dim DocumentGroup As Integer            ' Переменная группы документов (0-Увед; 1-Отключ)
    Dim IsFirstLoadForm As Boolean = True   ' Первый ли запуск формы
    Dim gvHistoryDZ_Records As GridView
    Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()
        SplashScreenManager.ShowForm(Me, GetType(frDefaultWaitForm), True, True, False)
        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
    End Sub
    Private Sub frRecordEvents_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        RemoveTableDataSet(Me)
        frMain.Show()
        frMain.NotifyIcon.Visible = False
        frMain.Time.Enabled = True
    End Sub

    Private Sub frRecordEvents_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.LabelControl15.Parent = Me.tvInspectors
        Me.lbAbonNumber.Properties.AppearanceReadOnly.BackColor = Me.BackColor
        Me.dtPerformance.EditValue = Now.ToShortDateString
        EventChangedControl = False
        FillTV_Maneger()        ' Выстраиваем дерево контролеров
        ' Заполняем список с годами из журнала
        SelectQueryData(
                        "Years." & Me.Name,
                        "EXEC Pr_OiOUpdateEvents @Function = 1",
                        Me.Name & ".GetYears"
                        )
        Me.cmbRegYear.Properties.DataSource = iDataSet.Tables("Years." & Me.Name)
        Me.cmbRegYear.Properties.DisplayMember = "YearName"
        Me.cmbRegYear.Properties.ValueMember = "Years"
        Me.cmbRegYear.Properties.PopulateColumns()
        Me.cmbRegYear.Properties.Columns("Years").Visible = False
        Me.cmbRegYear.Properties.PopupFormMinSize = New Point(120, 20)
        Me.cmbRegYear.ItemIndex = 0

        ' Заполняем список с методами доставки
        SelectQueryData(
                        "DMethod." & Me.Name,
                        "EXEC Pr_OiOUpdateEvents @Function = 3",
                        Me.Name & ".GetDMethod"
                        )
        Me.cmdDMethod.Properties.DataSource = iDataSet.Tables("DMethod." & Me.Name)
        Me.cmdDMethod.Properties.DisplayMember = "DMethodName"
        Me.cmdDMethod.Properties.ValueMember = "DMethodId"
        Me.cmdDMethod.Properties.PopulateColumns()
        Me.cmdDMethod.Properties.Columns("DMethodId").Visible = False
        Me.cmdDMethod.Properties.PopupFormMinSize = New Point(120, 20)
        Me.cmdDMethod.ItemIndex = 0
        ' Получаем пустую истроию ДЗ
        GetInformationDZ(0)
        Me.cmbRegYear.Focus()
        EventChangedControl = True
        SplashScreenManager.CloseForm(False)
    End Sub

#Region "Заполнение дерева контролеров"
    Private Sub FillTV_Maneger() ' Руководитель группы
        XndStr_Level_0 = ""
        ' Выгружаем таблицу старших и линейных контролеров
        SelectQueryData(
                         "InspectorsTree." & Me.Name, _
                         "SELECT * " & _
                         "FROM   vPr_InspoctorsTree " & _
                         "ORDER BY Manager, ChiefInspector, Inspector",
                         "frAskur_Load.InspectorsTree"
                        )
        ' Пока процесс выполняется....
        Do Until CompliteLoad
            ' Ждем и ничего не делаем
            My.Application.DoEvents()
        Loop
        ' Пр
        ' Перебор значений в iDataSet столбца "ArealName"
        For Each iDataRow As DataRow In iDataSet.Tables("InspectorsTree." & Me.Name).Rows
            If iDataRow.Item("ManagerId") <> XndStr_Level_0 Then
                XndLevel_0 = Me.tvInspectors.Nodes.Add(
                                                        iDataRow("Manager"),
                                                        iDataRow("ManagerId"),
                                                        "NULL",
                                                        "NULL",
                                                        0
                                                        )
                XndStr_Level_0 = iDataRow("ManagerId")
                FillTV_ChiefInsp(iDataRow("ManagerId"))
            End If
        Next iDataRow
        Me.tvInspectors.ExpandAll()
        Me.tvInspectors.MoveLast.Selected = True
    End Sub
    ' Старшие контролеры
    Private Sub FillTV_ChiefInsp(ByVal ParentNodeName As String)
        For Each iDataRow As DataRow In iDataSet.Tables("InspectorsTree." & Me.Name).Rows
            If iDataRow("ManagerId") = ParentNodeName Then
                If iDataRow.Item("ChiefInspectorId") <> XndStr_Level_1 Then
                    XndLevel_1 = XndLevel_0.Nodes.Add(
                                                    iDataRow("ChiefInspector"),
                                                    iDataRow("ManagerId"),
                                                    iDataRow("ChiefInspectorId"),
                                                    "NULL",
                                                    1
                                                    )
                    XndStr_Level_1 = iDataRow("ChiefInspectorId")
                    FillTV_Insp(iDataRow("ChiefInspectorId"))
                End If
            End If
        Next
    End Sub
    ' Линейные контролеры
    Private Sub FillTV_Insp(ByVal ParentNodeName As String)
        For Each iDataRow As DataRow In iDataSet.Tables("InspectorsTree." & Me.Name).Rows
            If iDataRow.Item("ChiefInspectorId") = ParentNodeName Then
                XndLevel_2 = XndLevel_1.Nodes.Add(
                                                    iDataRow("Inspector"),
                                                    iDataRow("ManagerId"),
                                                    iDataRow("ChiefInspectorId"),
                                                    iDataRow("InspectorId"),
                                                    2
                                                    )
            End If
        Next
    End Sub
#End Region

    Private Sub lbAbonNumber_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbAbonNumber.Click
        MoneyTextBox_EnterLeave(sender, e, "Click", "G0")
        ' Если первый вход в поле контрола
        If iEnter = False Then
            sender.SelectAll()      ' Выделяем весь текст
            iEnter = True           ' Вход состоялся
        End If
    End Sub
    Private Sub lbAbonNumber_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbAbonNumber.Leave
        MoneyTextBox_EnterLeave(sender, e, "Leave", "N0")
        iEnter = False ' Выход из поля состоялся
    End Sub

#Region "Изменение номера документа"
    Private Sub txtDocNumber_Leave(sender As System.Object, e As System.EventArgs) Handles txtDocNumber.Leave
        iEnter = False ' Выход из поля состоялся
    End Sub
    Private Sub txtDocNumber_Click(sender As System.Object, e As System.EventArgs) Handles txtDocNumber.Click
        ' Если первый вход в поле контрола
        If iEnter = False Then
            sender.SelectAll()      ' Выделяем весь текст
            iEnter = True           ' Вход состоялся
        End If
    End Sub
#End Region

    ' Выбор исполнителя в дереве
    Private Sub tvInspectors_AfterFocusNode(sender As Object, e As DevExpress.XtraTreeList.NodeEventArgs) Handles tvInspectors.AfterFocusNode
        Dim sTooltip As New SuperToolTip()          ' Новый SuperToolTip
        Dim args As New SuperToolTipSetupArgs()     ' Набор параметров для SuperToolTip

        Me.lbBarPerformer.Caption = "Исполнитель задания: [" & e.Node.GetDisplayText("InspectorTree") & "]"
        ' Добавляем подсказку
        args.Title.Text = "Исполнитель задания:"                        ' Заголовок
        args.Title.Image = My.Resources.user_16x16                      ' Изображение заголовка
        args.Contents.Text = e.Node.GetDisplayText("InspectorTree")     ' Текст сообщения
        sTooltip.Setup(args)                                            ' Привязываем набор параметров к SuperToolTip
        Me.lbBarPerformer.SuperTip = sTooltip
    End Sub

    ' Если выбран не линейный отменяем селект
    Private Sub tvInspectors_BeforeFocusNode(sender As Object, e As DevExpress.XtraTreeList.BeforeFocusNodeEventArgs) Handles tvInspectors.BeforeFocusNode
        If EventChangedControl Then
            If (e.Node IsNot Nothing) Then
                If e.Node.Level <> 2 Then
                    e.CanFocus = False
                End If
            Else
                tvInspectors.Selection.Clear()
            End If
        End If
    End Sub

    ' Запись события в базу
    Private Sub btbRecordToBase_Click(sender As System.Object, e As System.EventArgs) Handles btbRecordToBase.Click
        Dim iRow As DataRow = iDataSet.Tables("InformationEvent." & Me.Name).Rows(0)
        Dim nD As TreeListNode = Me.tvInspectors.Selection(0)

        Dim iResultValidFact As Integer         ' Код результата проверки фактического мероприятия
        Dim RecordOnlyPR As Integer = 0         ' Куда записываем событие ( -- 	0 - запись и в Квазар и в Припять
        '                                                                   --	1 - запись только в Припять)

        ' Проверяем не изменились ли процедуры Квазара котрые использует припять
        If Pr_GetTrackingProcedures("OiO_EventsMiscFunctions") Then Exit Sub
        If Pr_GetTrackingProcedures("OiO_ValidateDtFac") Then Exit Sub

        ' Если нет тех возможности ограничить, переопределяем ограничение на отключение
        If Me.chbImpossibleDisable.EditValue And iRow("EventTypeId") = 3 Then
            iRow("EventTypeId") = 6
        End If

        iResultValidFact = OiOValidateDtFact(
                                            iRow("AbonentId"),
                                            iRow("DtBeginOio"),
                                            iRow("EventTypeId"),
                                            Convert.ToDateTime(Me.dtPerformance.Text).ToShortDateString
                                            )
        ' Если проверка прошла с ошибкой
        If iResultValidFact <> 0 Then
            ' смотрим с какой
            If iResultValidFact = -2 Or iResultValidFact = -4 Then
                ' Записываем только в Припять
                RecordOnlyPR = 1
                Me.lbPripyat.Enabled = True
                ' ////запуск процедуры в Припять
            Else ' При других ошибках выходим из процедуры
                Me.txtDocNumber.Properties.ContextImageOptions.Image = Nothing
                Me.txtDocNumber.Focus()
                Me.txtDocNumber.SelectAll()
                Exit Sub
            End If
        Else
            Me.lbPripyat.Enabled = True
            Me.lbQuasar.Enabled = True
        End If
        If XtraMessageBox.Show("Выбранное мероприятие <u><b>№ " & iRow("DocNumber") & "</b></u>" & " будет сохранено в базу данных!" & Chr(10) & "Вы согласны?",
                                    Application.ProductName,
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question,
                                    MessageBoxDefaultButton.Button1,
                                    DevExpress.Utils.DefaultBoolean.True) = Windows.Forms.DialogResult.Yes Then
            ' если проверка без ошибок записываем в обе базы
            ExecuteQuery(
                        "EXEC Pr_OiOEventsMiscFunctions " & _
                                "@AbonentId = " & iRow("AbonentId") & ", " & _
                                "@EventTypeId = " & iRow("EventTypeId") & ", " & _
                                "@DtBeginOiO = '" & iRow("DtBeginOiO") & "', " & _
                                "@DtFact = '" & Convert.ToDateTime(Me.dtPerformance.Text).ToShortDateString & "' ," & _
                                "@DMethodId = " & Me.cmdDMethod.EditValue & ", " & _
                                "@DocumentNumber = '" & iRow("DocNum") & "', " & _
                                "@DocSum = " & iRow("SumDoc") & ", " & _
                                "@InspectorId = " & nD("InspectorId") & ", " & _
                                "@DocId = " & iRow("DocId") & ", " & _
                                "@SetCostDisable = " & Convert.ToInt32(Me.chbSetCostDisable.Checked) & ", " & _
                                "@RecordOnlyPR = " & RecordOnlyPR
                        )
            GetInformationDZ(iRow("AbonentId"))
            ' ////запуск процедуры в обе базы
            Me.txtDocNumber.Properties.ContextImageOptions.Image = Nothing
            Me.txtDocNumber.Focus()
            Me.txtDocNumber.SelectAll()
        End If
    End Sub

    ' Заполнение информации по документу
    Private Sub txtDocNumber_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDocNumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            iEnter = False
            ' если года не выгрузились, значит журнал пустой
            If iDataSet.Tables("Years." & Me.Name).Rows.Count = 0 Then
                XtraMessageBox.Show("В журнале регистрации отсутствуют зарегистрированные документы!",
                                   Application.ProductName,
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error)
                Exit Sub
            End If
            SelectQueryData(
                            "InformationEvent." & Me.Name,
                            "EXEC Pr_OiOUpdateEvents " & _
                            "@DocNumber = " & Me.txtDocNumber.Text & ", " & _
                            "@DocYear = " & Me.cmbRegYear.EditValue & ", " & _
                            "@DocGroup = " & DocumentGroup & ", " & _
                            "@Function = 2",
                            Me.Name & ".GetInformationEvent"
                            )
            ' Если запрос вернул больше одной записи
            If iDataSet.Tables("InformationEvent." & Me.Name).Rows.Count > 1 Then
                XtraMessageBox.Show("Запрос к журналу регистрации вернул больше одной записи!" & Chr(10) &
                                    "Проверьте корректность введенного номера.",
                                    "Запись мероприятия невозможна...",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                iDataSet.Tables("HistoryDZ." & Me.Name).Rows.Clear()
                iDataSet.Tables("HistoryDZ_Records." & Me.Name).Rows.Clear()
                Me.lbAbonNumber.Text = "Нет данных"
                Me.lbFSN.Text = "Нет данных"
                Me.lbAddress.Text = "Нет данных"
                Me.lbEventType.Text = "Нет данных"
                Me.lbDocSum.Text = "Нет данных"
                Me.lbDocNumber.Text = "Нет данных"
                Me.lbControler.Text = "Нет данных"
                Me.lbPerformer.Text = "Нет данных"
                Me.lbTaskNumber.Text = "Нет данных"

                Me.btbRecordToBase.Enabled = False
                Me.txtDocNumber.Properties.ContextImageOptions.Image = My.Resources.cancel_16x16
                Me.txtDocNumber.Focus()
                Me.txtDocNumber.SelectAll()
                Me.txtDocNumber.Select(0, Me.txtDocNumber.Text.Length)
                Exit Sub
            End If
            ' Заполняем поля данными из датасета
            If iDataSet.Tables("InformationEvent." & Me.Name).Rows.Count <> 0 Then
                Dim iRow As DataRow = iDataSet.Tables("InformationEvent." & Me.Name).Rows(0)
                GetInformationDZ(iRow.Item("AbonentId"))
                Me.lbAbonNumber.Text = OutBD_Money(iRow.Item("AbonentNumber"), 0, "N0")
                Me.lbFSN.Text = iRow.Item("SNP_short")
                Me.lbAddress.Text = iRow.Item("AddressString")
                Me.lbEventType.Text = iRow.Item("prEventName")
                Me.lbDocSum.Text = OutBD_Money(iRow.Item("SumDoc"), 0, "N") & " руб."
                Me.lbDocNumber.Text = iRow.Item("DocNumber")
                Me.lbControler.Text = iRow.Item("Controller")
                Me.lbPerformer.Text = iRow.Item("PerformersName").ToString
                Me.lbTaskNumber.Text = Replace(iRow.Item("TaskSheet").ToString, "г. (№", "г." & Chr(10) & "(№")
                Me.btbRecordToBase.Select()
                Me.btbRecordToBase.Enabled = True
                Me.txtDocNumber.Properties.ContextImageOptions.Image = My.Resources.apply_16x16
            Else
                iDataSet.Tables("HistoryDZ." & Me.Name).Rows.Clear()
                iDataSet.Tables("HistoryDZ_Records." & Me.Name).Rows.Clear()
                Me.lbAbonNumber.Text = "Нет данных"
                Me.lbFSN.Text = "Нет данных"
                Me.lbAddress.Text = "Нет данных"
                Me.lbEventType.Text = "Нет данных"
                Me.lbDocSum.Text = "Нет данных"
                Me.lbDocNumber.Text = "Нет данных"
                Me.lbControler.Text = "Нет данных"
                Me.lbPerformer.Text = "Нет данных"
                Me.lbTaskNumber.Text = "Нет данных"

                Me.btbRecordToBase.Enabled = False
                Me.txtDocNumber.Properties.ContextImageOptions.Image = My.Resources.cancel_16x16
                Me.txtDocNumber.Focus()
                Me.txtDocNumber.SelectAll()
                Me.txtDocNumber.Select(0, Me.txtDocNumber.Text.Length)
            End If
        End If
    End Sub

    ' Получаем информацию по истории ДЗ
    Private Sub GetInformationDZ(ByVal AbonentId As String)
        SelectQueryData(
                        "HistoryDZ." & Me.Name,
                        "EXEC Pr_OiOUpdateEvents " & _
                        "@AbonentId = " & AbonentId & ", " & _
                        "@Function = 4",
                        Me.Name & ".GetHistoryDZ"
                        )
        SelectQueryData(
                        "HistoryDZ_Records." & Me.Name,
                        "EXEC Pr_OiOUpdateEvents " & _
                        "@AbonentId = " & AbonentId & ", " & _
                        "@Function = 5",
                        Me.Name & ".HistoryDZ_Records"
                        )
        ' Если первый запуск
        If IsFirstLoadForm Then
            ' прописываем отношение между таблицами
            If iDataSet.Relations.Contains("События в записи истории ДЗ") = False Then
                iDataSet.Relations.Add("События в записи истории ДЗ", _
                                            iDataSet.Tables("HistoryDZ." & Me.Name).Columns("DtBeginOio"), _
                                           iDataSet.Tables("HistoryDZ_Records." & Me.Name).Columns("DtBeginOio"), False
                                           )
            End If
            Me.gcInformationDZ.DataSource = iDataSet.Tables("HistoryDZ." & Me.Name)
            Me.gcInformationDZ.ForceInitialize()
            ' Оформление истории ДЗ
            Me.gvHistoryDZ.Columns("AbonentId").Visible = False
            Me.gvHistoryDZ.Columns("DtBeginOio").Caption = "Начало"
            Me.gvHistoryDZ.Columns("DtEndOio").Caption = "Окончание"
            Me.gvHistoryDZ.Columns("ResultOfWork").Caption = "Результат работы"
            Me.gvHistoryDZ.Columns("PerformerName").Caption = "Автор"

            IsFirstLoadForm = False
        End If
        Me.gvHistoryDZ.BestFitColumns()
        Me.gvHistoryDZ.FocusedRowHandle = gvHistoryDZ.RowCount - 1
        Me.gvHistoryDZ.ExpandMasterRow(gvHistoryDZ.RowCount - 1)
    End Sub

    ' свернуть/развернуть панел с информацией по истории ДЗ
    Private Sub panelControl_CustomButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.Docking2010.BaseButtonEventArgs) _
                                                                                                Handles pnInformationAbonent.CustomButtonClick
        e.Button.Properties.Enabled = False ' Отключаем кнопку пока панель двигается
        If e.Button.Properties.Tag = 1 Then
            Me.pnInformationAbonent.CustomHeaderButtons.Item(0).Properties.Image = Pripyat.My.Resources.next_16x16
            Me.gcInformationDZ.Visible = False
            e.Button.Properties.Tag = 0
            For i = 1 To 192 Step 20
                Me.ClientSize = New Size(817, 674 - i)
                Application.DoEvents()
            Next
        Else
            Me.pnInformationAbonent.CustomHeaderButtons.Item(0).Properties.Image = Pripyat.My.Resources.previous_16x16
            Me.gcInformationDZ.Visible = True
            e.Button.Properties.Tag = 1
            For i = 482 To 674 Step 20
                Me.ClientSize = New Size(817, i)
                Application.DoEvents()
            Next
        End If
        e.Button.Properties.Enabled = True
    End Sub

    ' Изменение активной группы мероприятий
    Private Sub rgDocumentType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles rgDocumentType.SelectedIndexChanged
        DocumentGroup = sender.Properties.Items(sender.SelectedIndex).Value
        If DocumentGroup = 0 Then
            Me.chbSetCostDisable.Checked = False
            Me.cmdDMethod.Enabled = True
        Else
            Me.cmdDMethod.Enabled = False
        End If
    End Sub

    ' разворот строки по двойному клику где MasterDetail
    Private Sub gvHistoryDZ_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles gvHistoryDZ.RowClick
        If e.Clicks = 2 Then
            sender.SetMasterRowExpanded(e.RowHandle, InverterBoolean(sender.GetMasterRowExpanded(e.RowHandle)))
        End If
    End Sub
    ' При каждом развороте узла, настраиваем строки
    Private Sub gvHistoryDZ_MasterRowExpanded(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs) Handles gvHistoryDZ.MasterRowExpanded
        If e.RowHandle >= 0 Then
            For i = 1 To Me.gcInformationDZ.Views.Count - 1
                Me.gvHistoryDZ_Records = Me.gcInformationDZ.Views.Item(i)
                Me.gvHistoryDZ_Records.Columns("AbonentId").Visible = False
                Me.gvHistoryDZ_Records.Columns("DtBeginOio").Visible = False
                Me.gvHistoryDZ_Records.Columns("EventName").AppearanceCell.FontStyleDelta = FontStyle.Italic
                Me.gvHistoryDZ_Records.Columns("DtFact").AppearanceCell.FontStyleDelta = FontStyle.Bold

                Me.gvHistoryDZ_Records.Columns("EventName").Caption = "Событие"
                Me.gvHistoryDZ_Records.Columns("DtPlane").Caption = "План"
                Me.gvHistoryDZ_Records.Columns("DtFact").Caption = "Факт"
                Me.gvHistoryDZ_Records.Columns("DocSum").Caption = "Сумма"
                Me.gvHistoryDZ_Records.Columns("DocSum").DisplayFormat.FormatType = FormatType.Numeric
                Me.gvHistoryDZ_Records.Columns("DocSum").DisplayFormat.FormatString = "# ##0.00 р."
                Me.gvHistoryDZ_Records.Columns("DocumentNumber").Caption = "№ документа"
                Me.gvHistoryDZ_Records.Columns("PerformerName").Caption = "Контролер"
                Me.gvHistoryDZ_Records.Columns("DMethodName").Caption = "Метод доставки"
                Me.gvHistoryDZ_Records.BestFitColumns()
                Me.gvHistoryDZ_Records.Columns("DtFact").Width = Me.gvHistoryDZ_Records.Columns("DtPlane").Width + 5
            Next
        End If
    End Sub

    ' Выделение строк с итогами
    Private Sub gvHistoryDZ_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gvHistoryDZ.RowStyle
        Dim View As GridView = TryCast(sender, GridView)
        If e.RowHandle >= 0 Then
            If Convert.ToDateTime(View.GetRowCellDisplayText(e.RowHandle, View.Columns("DtEndOio"))) > Now.ToShortDateString Then
                e.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, FontStyle.Bold)
            End If
        End If
    End Sub

    ' если выбраны уведомления допы не выставляем
    Private Sub chbSetCostDisable_CheckedChanged(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles chbSetCostDisable.CheckedChanged
        If rgDocumentType.Properties.Items(rgDocumentType.SelectedIndex).Value = 0 Then
            sender.Checked = False
        End If
    End Sub

    ' При наборе номера снимаем активность с иконок программ
    Private Sub txtDocNumber_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDocNumber.KeyPress
        Me.lbQuasar.Enabled = False
        Me.lbPripyat.Enabled = False
    End Sub

    ' При изменении какого либо параметра кнопка сохранить не активна
    Private Sub dtPerformance_TextChanged(sender As System.Object, e As System.EventArgs) Handles dtPerformance.TextChanged,
                                                                                                    cmdDMethod.EditValueChanging,
                                                                                                    txtDocNumber.TextChanged,
                                                                                                    chbSetCostDisable.CheckedChanged,
                                                                                                    chbImpossibleDisable.EditValueChanged,
                                                                                                    tvInspectors.FocusedNodeChanged,
                                                                                                    rgDocumentType.SelectedIndexChanged
        Me.btbRecordToBase.Enabled = False
    End Sub
End Class