Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Columns

Public Class frSectionODN
    Friend iSelectedNode_ODU As Integer         ' Индекс активного нода дерева ОДУ
    Friend iSelectedNode_Period As Integer      ' Индекс активного нода дерева ОДУ
    Friend DocumentId As Integer                ' Выбранная проводка в gvChargesSection 

    Sub New()
        SplashScreenManager.ShowForm(Me, GetType(frDefaultWaitForm), True, True, False)
        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()
        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
    End Sub

    Private Sub frSectionODN_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        SaveViewForm(Me)
        RemoveTableDataSet(Me)
        Me.Dispose()
    End Sub
    Private Sub frSectionODN_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        LoadViewForm(Me) ' загрузка настроек формы
        ' схема распределения
        SelectQueryData(
                        "Schemes." & Me.Name,
                        "SELECT * FROM vPr_PointsPublicSectionsSchemes",
                        "Get Schemes"
                        )
        With Me.cmbSchemes
            .Properties.DataSource = iDataSet.Tables("Schemes." & Me.Name)
            .Properties.ValueMember = "SchemesId"
            .Properties.DisplayMember = "Name"
            .Properties.PopulateViewColumns()
            Me.gvSchemes.Columns("SchemesId").Visible = False
        End With

        Designer_ODUlist(iSelectedNode_ODU) ' Формирование дерева ОДУ
        SplashScreenManager.CloseForm(False)
    End Sub

#Region "Настройки гридов"
    ' Настройка дерева ОДУ
    Private Sub Designer_ODUlist(ByVal _SelectedNode As Integer)
        SelectQueryData("ODUlist." & Me.Name, "EXEC Pr_PointsPublic_MiscFunctions")
        ' при первом запуске
        If IsNothing(Me.tlODUlist.DataSource) Then
            With Me.tlODUlist
                .DataSource = iDataSet.Tables("ODUlist." & Me.Name)
                HidenAllColumns_TreeList(Me.tlODUlist)
                .ParentFieldName = "ParentId"
                .KeyFieldName = "Id"
                .Columns("Name").Visible = True
            End With
        End If
        Dim IsConn As Boolean = False ' для определения уже подключенных в адресе

        ' настройка дерева
        For Each n0 As TreeListNode In Me.tlODUlist.Nodes
            n0.StateImageIndex = n0.Level   ' Иконка
            n0.Expanded = n0("IsExpanded")  ' Раворот
            If n0.HasChildren Then          ' При наличии подузлов
                For Each n1 As TreeListNode In n0.Nodes
                    n0.Expanded = n0("IsExpanded")
                    If n1.HasChildren Then
                        For Each n2 As TreeListNode In n1.Nodes
                            n2.StateImageIndex = n2.Level
                            n0.Expanded = n0("IsExpanded")
                            If n2.HasChildren Then
                                IsConn = True
                                For Each n3 As TreeListNode In n2.Nodes
                                    n3.StateImageIndex = n3.Level
                                    n0.Expanded = n0("IsExpanded")
                                Next
                            End If
                        Next
                    End If
                    ' Если у улицы есть секционки
                    ' Отмечаем их другой иконкой
                    If IsConn Then
                        n1.StateImageIndex = 4
                    Else
                        n1.StateImageIndex = n1.Level
                    End If
                    IsConn = False
                Next
            End If
        Next
        ' Фокус на заданный узел
        Me.tlODUlist.FocusedNode = Me.tlODUlist.FindNodeByKeyID(_SelectedNode)
    End Sub
    ' Настройка истории замен в секции
    Private Sub DesignerCounterHistory()
        SelectQueryData(
                        "CounterHistory." & Me.Name,
                        "EXEC Pr_PointsPublic_MiscFunctions " &
                            "@SectionId = " & Me.tlODUlist.FocusedNode("Id") & ", " &
                            "@Function = 2",
                        "EXEC Pr_PointsPublic_MiscFunctions @Function = 2"
                        )
        If IsNothing(Me.gcCounterHistory.DataSource) Then
            Me.gcCounterHistory.DataSource = iDataSet.Tables("CounterHistory." & Me.Name)
            HidenAllColumns_Grid(Me.gvCounterHistory, iDataSet.Tables("CounterHistory." & Me.Name))
            With Me.gvCounterHistory
                .Columns("Updater").Visible = True
                .Columns("Updater").Caption = "Автор"
                .Columns("DtUpdate").Visible = True
                .Columns("DtUpdate").Caption = "Изменено"
                .Columns("DtUpdate").DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss"
                .Columns("IndicationRemove").Visible = True
                .Columns("IndicationRemove").Caption = "Показание"
                .Columns("DtCountRemove").Visible = True
                .Columns("DtCountRemove").Caption = "Демонтирован"
                .Columns("CounterNumber").Visible = True
                .Columns("CounterNumber").Caption = "Номер ПУ"
                .Columns("FullCounterName").Visible = True
                .Columns("FullCounterName").Caption = "Тип прибора учета"
                .Columns("IndicationSetup").Visible = True
                .Columns("IndicationSetup").Caption = "Показание"
                .Columns("DtCounterSetup").Visible = True
                .Columns("DtCounterSetup").Caption = "Установлен"
                .BestFitColumns()
            End With
        End If
    End Sub
    ' Настройка списка подключенных ТУ
    Private Sub DesignerAbonentList()
        SelectQueryData(
                        "AbonentList." & Me.Name,
                        "EXEC Pr_PointsPublic_MiscFunctions " &
                            "@SectionId = " & Me.tlODUlist.FocusedNode("Id") & ", " &
                            "@Function = 3",
                        "EXEC Pr_PointsPublic_MiscFunctions @Function = 3"
                        )
        If IsNothing(Me.gcAbonentList.DataSource) Then
            Me.gcAbonentList.DataSource = iDataSet.Tables("AbonentList." & Me.Name)
            HidenAllColumns_Grid(Me.gvAbonentList, iDataSet.Tables("AbonentList." & Me.Name))
            ' запрет на редактирование столбцов
            For Each c As GridColumn In Me.gvAbonentList.Columns
                c.OptionsColumn.AllowEdit = False
            Next
            With Me.gvAbonentList
                .Columns("Creater").Visible = True
                .Columns("Creater").Caption = "Автор"
                .Columns("DtCreate").Visible = True
                .Columns("DtCreate").Caption = "Подключен"
                .Columns("DtCreate").DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss"
                .Columns("SquareTotal").Visible = True
                .Columns("SquareTotal").Caption = "Площадь, м" & ChrW(178)
                .Columns("CountLodgers").Visible = True
                .Columns("CountLodgers").Caption = "Жильцов"
                .Columns("CounterNumber").Visible = True
                .Columns("CounterNumber").Caption = "Номер ПУ"
                .Columns("CounterName").Visible = True
                .Columns("CounterName").Caption = "Тип ТУ"
                .Columns("Address").Visible = True
                .Columns("Address").Caption = "Адрес"
                .Columns("SNP").Visible = True
                .Columns("SNP").Caption = "ФИО"
                .Columns("PointNumber").Visible = True
                .Columns("PointNumber").Caption = "Номер ТУ"
                .Columns("PointNumber").OptionsColumn.AllowEdit = True
                .Columns("PointNumber").OptionsColumn.ReadOnly = True
                .BestFitColumns()
            End With
        End If

        ' Столбцы с суммами
        With Me.gvAbonentList
            ' кол-во ТУ 
            .Columns("PointNumber").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
            .Columns("PointNumber").SummaryItem.DisplayFormat = "Кол-во ТУ: <b>" & gvAbonentList.Columns("PointNumber").SummaryItem.SummaryValue & "</b>"
            ' Кол-во проживающих
            .Columns("CountLodgers").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("CountLodgers").SummaryItem.DisplayFormat = "Всего чел: <b>" & gvAbonentList.Columns("CountLodgers").SummaryItem.SummaryValue & "</b>"
            ' Общая площадь
            .Columns("SquareTotal").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("SquareTotal").SummaryItem.DisplayFormat = "Всего м" & ChrW(178) & ": <b>" & gvAbonentList.Columns("SquareTotal").SummaryItem.SummaryValue & "</b>"
        End With
    End Sub
    ' Настройка дерева периодов
    Private Sub Designer_Periodlist(ByVal _SelectedNode As Integer)
        SelectQueryData(
                        "Periodlist." & Me.Name,
                        "EXEC Pr_GetPeriodLookUp " &
                            "@TableName = 'Pr_PointsPublicSectionsCharges'",
                        "EXEC Pr_GetPeriodLookUp")
        If IsNothing(Me.tlPeriodList.DataSource) Then
            With Me.tlPeriodList
                .DataSource = iDataSet.Tables("Periodlist." & Me.Name)
                HidenAllColumns_TreeList(Me.tlPeriodList)
                .ParentFieldName = "ParentId"
                .KeyFieldName = "Id"
                .Columns("Name").Visible = True
            End With
        End If
        ' настройка дерева
        For Each n0 As TreeListNode In Me.tlPeriodList.Nodes
            n0.StateImageIndex = 7 ' иконка узла
            If n0.HasChildren Then
                For Each n1 As TreeListNode In n0.Nodes
                    n1.StateImageIndex = 5
                    If n1.HasChildren Then
                        For Each n2 As TreeListNode In n1.Nodes
                            n2.StateImageIndex = 6
                        Next
                    End If
                Next
            End If
        Next
        ' Если активный узел не задан
        If _SelectedNode = 0 Then
            ' выбираем последний
            Me.tlPeriodList.MoveLast.Selected = True
        Else
            Me.tlPeriodList.FocusedNode = Me.tlPeriodList.FindNodeByKeyID(_SelectedNode)
        End If
    End Sub
    ' Настройка списка с показаниями по секциям
    Private Sub DesignerChargesSection()
        SelectQueryData(
                        "ChargesSection." & Me.Name,
                            "EXEC Pr_PointsPublic_MiscFunctions @SectionId = " & Me.tlODUlist.FocusedNode("Id") & ", " &
                            "@YEAR = " & Me.tlPeriodList.FocusedNode("Year") & ", " &
                            "@MONTH = " & Me.tlPeriodList.FocusedNode("Month") & ", " &
                            "@Function = 5",
                        "EXEC Pr_PointsPublic_MiscFunctions @Function = 5"
                        )
        If IsNothing(Me.gcChargesSection.DataSource) Then
            Me.gcChargesSection.DataSource = iDataSet.Tables("ChargesSection." & Me.Name)
            ' сопоставление статуса месяца с изображениями
            Dim rps As New Repository.RepositoryItemImageComboBox
            rps.SmallImages = Me.ImageCollection
            rps.Items.Add(New ImageComboBoxItem("Месяц открыт", 1, 8))
            rps.Items.Add(New ImageComboBoxItem("Месяц закрыт", 2, 9))
            rps.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center

            ' ключевое поле для последующей активации строки по DocumentId
            iDataSet.Tables("ChargesSection." & Me.Name).PrimaryKey = New DataColumn() {iDataSet.Tables("ChargesSection." & Me.Name).Columns("DocumentId")}
            HidenAllColumns_Grid(Me.gvChargesSection, iDataSet.Tables("ChargesSection." & Me.Name))
            With Me.gvChargesSection
                .Columns("Updater").Visible = True
                .Columns("Updater").Caption = "Автор"
                .Columns("DtUpdate").Visible = True
                .Columns("DtUpdate").Caption = "Изменено"
                .Columns("DtUpdate").DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss"
                .Columns("Source").Visible = True
                .Columns("Source").Caption = "Тип проводки"
                .Columns("Consumption").Visible = True
                .Columns("Consumption").Caption = "Расход, кВт*ч"
                .Columns("Consumption").AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, FontStyle.Bold)
                .Columns("NewIndication").Visible = True
                .Columns("NewIndication").Caption = "ФП новое"
                .Columns("OldIndication").Visible = True
                .Columns("OldIndication").Caption = "ФП старое"
                .Columns("DtDoc").Visible = True
                .Columns("DtDoc").Caption = "Дата документа"
                With .Columns("MonthStatus")
                    .Visible = True
                    .ColumnEdit = rps
                    .ImageIndex = 10                    ' Иконка в шапке столбца
                    .ImageAlignment = StringAlignment.Center
                    .ToolTip = "Статус периода"         ' всплывающее сообщение
                    .OptionsColumn.ShowCaption = False
                    .OptionsColumn.FixedWidth = True
                    .OptionsColumn.AllowSize = False
                    .OptionsFilter.AllowFilter = False
                    .Width = 40
                End With
            End With
        End If
        With Me.gvChargesSection
            .BestFitColumns(True)
            .Columns("Consumption").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("Consumption").SummaryItem.DisplayFormat =
                "Итого кВ*ч: <b>" & gvChargesSection.Columns("Consumption").SummaryItem.SummaryValue & "</b>"
        End With
        DesignerChargesSections(Me.tlPeriodList.FocusedNode.Level <> 2)
    End Sub
    ' Настройка списка c начислениями по л/с из Квазара
    Private Sub DesignerChargesSections(ByVal IsClear As Boolean)
        ' если выбрана 2-ая вкладка
        If Me.XtraTabControl.SelectedTabPageIndex = 1 Then
            ' индикатор ожидания на списках с начислениями  
            tmWaitAnimation.StartWaitingIndicator(Me.gcChargesIndividual, 0)
        Else
            ' на 1-ой вкладке
            tmWaitAnimation.StartWaitingIndicator(Me.tpSectionProporties, 0)
        End If
        ' при необходимости только чистим ДатаСет
        gcChargesIndividual.Visible = InverterBoolean(IsClear)
        If IsClear And iDataSet.Tables.Contains("AbonentListCharges." & Me.Name) Then
            iDataSet.Tables("AbonentListCharges." & Me.Name).Clear()
            tmWaitAnimation.StopWaitingIndicator()
            Exit Sub
        End If
        SelectQueryData(
                        "AbonentListCharges." & Me.Name,
                        "EXEC Pr_PointsPublic_MiscFunctions " &
                            "@SectionId = " & Me.tlODUlist.FocusedNode("Id") & ", " &
                            "@YEAR = " & Me.tlPeriodList.FocusedNode("Year") & ", " &
                            "@MONTH = " & Me.tlPeriodList.FocusedNode("Month") & ", " &
                            "@Function = 6",
                        "EXEC Pr_PointsPublic_MiscFunctions @Function = 6"
                        )
        ' при первом запуске
        If IsNothing(Me.gcChargesIndividual.DataSource) Then
            Me.gcChargesIndividual.DataSource = iDataSet.Tables("AbonentListCharges." & Me.Name)
            Me.gcChargesIndividual.ForceInitialize()
            HidenAllColumns_Grid(Me.gvChargesIndividual, iDataSet.Tables("AbonentListCharges." & Me.Name))
            With Me.gvChargesIndividual
                .Columns("GroupString").Group() ' Группировка

                With .Columns("DtUpdate")
                    .Visible = True
                    .Caption = "Изменено"
                    .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    .DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss"
                End With
                With .Columns("Performer")
                    .Visible = True
                    .Caption = "Автор"
                End With
                With .Columns("TariffCount")
                    .Visible = True
                    .Caption = "Тариф"
                    .DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    .DisplayFormat.FormatString = "N2"
                End With
                With .Columns("Name")
                    .Visible = True
                    .Caption = "Документ"
                End With
                With .Columns("SumBalanceClosed")
                    .Visible = True
                    .Caption = "Закрыто, руб"
                    .DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    .DisplayFormat.FormatString = "# ##0.00 р"
                End With
                With .Columns("SumCurBalance")
                    .Visible = True
                    .Caption = "Сальдо, руб"
                    .DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    .DisplayFormat.FormatString = "# ##0.00 р"
                End With
                With .Columns("SumPayment")
                    .Visible = True
                    .Caption = "Оплачено, руб"
                    .DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    .DisplayFormat.FormatString = "# ##0.00 р"
                End With
                With .Columns("SumCharge")
                    .Visible = True
                    .Caption = "Начислено, руб"
                    .DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    .DisplayFormat.FormatString = "# ##0.00 р"
                End With
                With .Columns("Consumption")
                    .Visible = True
                    .Caption = "Расход, кВт*ч"
                    .DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    .DisplayFormat.FormatString = "N0"
                End With
                With .Columns("NewIndication")
                    .Visible = True
                    .Caption = "Новое"
                End With
                With .Columns("OldIndication")
                    .Visible = True
                    .Caption = "Старое"
                End With
                With .Columns("DtDoc")
                    .Visible = True
                    .Caption = "Дата док-та"
                End With
            End With
        End If
        With Me.gvChargesIndividual
            .Columns("GroupString").Group()
            .ExpandAllGroups()
            .BestFitColumns(True)
            .Columns("Consumption").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("Consumption").SummaryItem.DisplayFormat =
                "Итого кВ*ч: <b>" & Convert.ToDecimal(gvChargesIndividual.Columns("Consumption").SummaryItem.SummaryValue) & "</b>"
            .Columns("SumCharge").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("SumCharge").SummaryItem.DisplayFormat =
                "Итого руб.: <b>" & Format(Math.Round(Convert.ToDecimal(gvChargesIndividual.Columns("SumCharge").SummaryItem.SummaryValue), 2), "# ##0.00") & "</b>"
        End With
        tmWaitAnimation.StopWaitingIndicator()
    End Sub
#End Region

    Private Sub btnAddSection_Click(sender As System.Object, e As System.EventArgs) Handles btnAddSection.Click
        If frAddNewPr_CounterSection.ShowDialog = Windows.Forms.DialogResult.OK Then
            tmWaitAnimation.StartWaitingIndicator(Me.SplitContainerControl1.Panel2, 0)
            Designer_ODUlist(iSelectedNode_ODU)
            tmWaitAnimation.StopWaitingIndicator()
        End If
    End Sub

#Region "tlODUlist"
    ' Фокус на дереве с домами
    Private Sub tlODUlist_AfterFocusNode(sender As System.Object, e As DevExpress.XtraTreeList.NodeEventArgs) Handles tlODUlist.AfterFocusNode
        EventChangedControl = False
        If sender.FocusedNode IsNot Nothing Then
            Me.btnAddSection.Enabled = (e.Node.Level = 2)       ' кнопка добавить только на доме
            Me.btnDeleteSection.Enabled = (e.Node.Level = 3)    ' кнопка удалить только на секции
            ' показываем вкладки, только на секции
            Me.SplitContainerControl3.Visible = (e.Node.Level = 3)
            Me.SplitContainerControl2.Visible = (e.Node.Level = 3)
            If e.Node.Level = 3 Then    ' выбрана секция
                DesignerCounterHistory()
                DesignerAbonentList()
                Designer_Periodlist(iSelectedNode_Period)
                Me.cmbSchemes.EditValue = _
                    ExecuteScalar("SELECT dbo.Pr_fnsGetCurrentSchemeSection(" & Me.tlODUlist.FocusedNode("Id") & ")")
                DesignerChargesSection()
            End If
        End If
        EventChangedControl = True
    End Sub
    ' После фокуса на дереве с домами
    Private Sub tlODUlist_BeforeFocusNode(sender As Object, e As DevExpress.XtraTreeList.BeforeFocusNodeEventArgs) Handles tlODUlist.BeforeFocusNode
        ' если сработало изменение схемы распределения
        If Me.cmbSchemes.Properties.Buttons(1).Enabled Then
            Select Case XtraMessageBox.Show("В текущей секции была изменена схема распределения ОДН!" & Chr(10) & "Сохранить изменения?",
                                    Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                Case Windows.Forms.DialogResult.Yes     ' сохранение изменений в секции
                    cmbSchemes_Properties_ButtonClick(cmbSchemes, New ButtonPressedEventArgs(Me.cmbSchemes.Properties.Buttons(1)))
                Case Windows.Forms.DialogResult.No      ' отмена изменений
                    Me.cmbSchemes.Properties.Buttons(1).Enabled = False
                Case Windows.Forms.DialogResult.Cancel
                    e.CanFocus = False
            End Select
        End If
    End Sub
    ' двойной клик на дереве секций
    Private Sub tlODUlist_DoubleClick(sender As System.Object, e As System.EventArgs) Handles tlODUlist.DoubleClick
        ' Если выбран дом и в нем нет секции
        If sender.FocusedNode.Level = 2 And sender.FocusedNode.HasChildren = False Then
            btnAddSection_Click(sender, e) ' добавить секции
        End If
    End Sub
#End Region


#Region "ПАРАМЕТРЫ СЕКЦИИ"

#End Region

#Region "ИСТОРИЯ НАЧИСЛЕНИЙ"
    ' Фокус на дереве с периодами
    Private Sub tlPeriodList_AfterFocusNode(sender As System.Object, e As DevExpress.XtraTreeList.NodeEventArgs) Handles tlPeriodList.AfterFocusNode
        If EventChangedControl Then
            ' распределить можно только при выборе месяца
            Me.btnFillODNSection.Enabled = (e.Node.Level = 2)
            iSelectedNode_Period = e.Node("Id")
            DesignerChargesSection()
        End If
    End Sub

#Region "gvChargesSection"
    ' фокус на гриде с показаниями по секции
    Private Sub gvChargesSection_FocusedRowChanged(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles gvChargesSection.FocusedRowChanged
        Dim MonthStatus As Boolean
        MonthStatus = Convert.ToBoolean(sender.GetFocusedRowCellValue("MonthStatus") - 1)
        ' добавить/удалить в зависимости от статуса периода
        Me.btnEditChargesSection.Enabled = InverterBoolean(MonthStatus)
        Me.btnDeleteChargesSection.Enabled = InverterBoolean(MonthStatus)
    End Sub
    ' горячие клавиши на гриде с показаними по секции
    Private Sub gvChargesSection_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles gvChargesSection.KeyDown
        If e.KeyData = Keys.Delete And btnDeleteChargesSection.Enabled Then btnDeleteChargesSection_Click(sender, Nothing)
        If e.KeyData = Keys.Enter And btnEditChargesSection.Enabled Then btnEditChargesSection_Click(sender, Nothing)
    End Sub
    ' правка начисления по двойному клику
    Private Sub gvChargesSection_RowCellClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs) Handles gvChargesSection.RowCellClick
        If e.Clicks = 2 And e.Button = Windows.Forms.MouseButtons.Left And btnEditChargesSection.Enabled Then btnEditChargesSection_Click(sender, Nothing)
    End Sub
    ' при наведении на иконку в столбце со статусом периода, показ подсказки
    Private Sub ToolTipController_GetActiveObjectInfo(sender As System.Object, e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles ToolTipController.GetActiveObjectInfo
        If e.Info Is Nothing AndAlso e.SelectedControl Is Me.gcChargesSection Then
            Dim view As GridView = TryCast(Me.gcChargesSection.FocusedView, GridView)
            Dim info As GridHitInfo = view.CalcHitInfo(e.ControlMousePosition)
            If info.InRowCell Then
                If info.Column.FieldName = "MonthStatus" Then
                    Dim text As String = view.GetRowCellDisplayText(info.RowHandle, info.Column)
                    Dim cellKey As String = info.RowHandle.ToString() & " - " & info.Column.ToString()
                    e.Info = New DevExpress.Utils.ToolTipControlInfo(cellKey, text)
                End If
            End If
        End If
    End Sub
#End Region

#Region "Управление показаниями секции"
    ' добавить начисление по секции
    Private Sub btnAddChargesSection_Click(sender As System.Object, e As System.EventArgs) Handles btnAddChargesSection.Click
        AddOrEdit = 2
        If frAddNewPr_SectionCharges.ShowDialog = Windows.Forms.DialogResult.OK Then
            EventChangedControl = False
            Designer_ODUlist(Me.tlODUlist.FocusedNode("Id"))
            ' фокус на строку по DocumentId
            Me.gvChargesSection.FocusedRowHandle =
                Me.gvChargesSection.GetRowHandle(GetIndexRowInDataSourse(iDataSet.Tables("ChargesSection." & Me.Name), DocumentId))
            EventChangedControl = True
        End If
    End Sub
    ' изменить начисление по секции
    Private Sub btnEditChargesSection_Click(sender As System.Object, e As System.EventArgs) Handles btnEditChargesSection.Click
        ' записываем DocumentId активной строки
        DocumentId = Me.gvChargesSection.GetFocusedRowCellDisplayText("DocumentId")
        AddOrEdit = 3
        If frAddNewPr_SectionCharges.ShowDialog = Windows.Forms.DialogResult.OK Then
            EventChangedControl = False
            Designer_ODUlist(Me.tlODUlist.FocusedNode("Id"))
            ' фокус на строку по DocumentId
            Me.gvChargesSection.FocusedRowHandle =
                Me.gvChargesSection.GetRowHandle(GetIndexRowInDataSourse(iDataSet.Tables("ChargesSection." & Me.Name), DocumentId))
            EventChangedControl = True
        End If
    End Sub
    ' удаление начисления по секции
    Private Sub btnDeleteChargesSection_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteChargesSection.Click
        Dim iRow As Integer = Me.gvChargesSection.FocusedRowHandle ' активная строка 
        If XtraMessageBox.Show("Документ за <u><b>" & Convert.ToDateTime(Me.gvChargesSection.GetFocusedRowCellDisplayText("DtDoc")).ToShortDateString & _
                               "г. </u></b>будет удален!" & Chr(10) & "Вы согласны?",
                               Application.ProductName, MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question,
                               DevExpress.Utils.DefaultBoolean.True) = Windows.Forms.DialogResult.Yes Then
            If ExecuteQuery(
                            "EXEC Pr_PointsPublicCharges " &
                                "@DocumentId = " & Me.gvChargesSection.GetFocusedRowCellDisplayText("DocumentId") & ", " &
                                "@Function = 4",
                            "EXEC Pr_PointsPublicCharges @Function = 4"
                            ) Then
                EventChangedControl = False
                Designer_ODUlist(Me.tlODUlist.FocusedNode("Id"))
                Me.gvChargesSection.FocusedRowHandle = iRow - 1
                Me.gvChargesSection.SelectRow(iRow - 1)
                EventChangedControl = True
            End If
        End If
    End Sub
#End Region

    ' фокус на строке в таблице с разбивкой по лицевым
    Private Sub gvChargesIndividual_FocusedRowChanged(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) _
Handles gvChargesIndividual.FocusedRowChanged
        Dim DocumentId As String = sender.GetRowCellDisplayText(e.FocusedRowHandle, "DocumentId")
        ' если DocumentId = "" то, выбрана группировка
        If Not IsNothing(e.FocusedRowHandle) And DocumentId <> "" Then
            Me.lbNoteDocument.Caption = "Пометки: <b><u>" & ExecuteScalar("SELECT dbo.Pr_fnsGetNoteDocument (" & DocumentId & ")") & "</b></u>"
        Else
            Me.lbNoteDocument.Caption = "Пометки: "
        End If
    End Sub

    ' при изменении активной схемы распределения
    Private Sub cmbSchemes_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cmbSchemes.EditValueChanged
        If EventChangedControl Then
            ' кнопка активна если выбранная схема не совпадает с тем что в базе
            Me.cmbSchemes.Properties.Buttons(1).Enabled = InverterBoolean(Me.cmbSchemes.EditValue = _
                                ExecuteScalar("SELECT ppps.SchemesId FROM Pr_PointsPublicSections AS ppps WHERE ppps.SectionId = " & _
                                              Me.tlODUlist.FocusedNode("Id")))
        End If
    End Sub
    ' сохранение активной схемы
    Private Sub cmbSchemes_Properties_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cmbSchemes.Properties.ButtonClick
        Dim btn As EditorButton = e.Button
        If btn.Index = 1 Then
            btn.Enabled = InverterBoolean(
                                          ExecuteQuery(
                                                       "EXEC Pr_PointsPublic_MiscFunctions " &
                                                            "@SectionId = " & Me.tlODUlist.FocusedNode("Id") & ", " &
                                                            "@SchemeId = " & Me.cmbSchemes.EditValue & ", " &
                                                       "@Function = 4"
                                                       )
                                          )
        End If
    End Sub
    ' распределение ОДС потребление
    Private Sub btnFillODNSection_Click(sender As System.Object, e As System.EventArgs) Handles btnFillODNSection.Click
        If Me.tlPeriodList.FocusedNode.Level <> 2 Then
            XtraMessageBox.Show("Выберите период для распределения потребления!",
                                Application.ProductName,
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If ExecuteQuery(
                        "EXEC Pr_PointsPublicPrepareDistribution " &
                            "@SectionId = " & Me.tlODUlist.FocusedNode("Id") & ", " &
                            "@PeriodNumber = " & Me.tlPeriodList.FocusedNode("Id"),
                        "EXEC Pr_PointsPublicPrepareDistribution"
                        ) Then
            XtraMessageBox.Show("Распределение выполнено!",
                               Application.ProductName,
                               MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
#End Region 
End Class