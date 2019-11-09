Imports System.Reflection ' для двойной буферизации DataGridView
Imports Microsoft.Office.Interop
Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraEditors
Imports System.IO
Imports System.Threading
Imports DevExpress.XtraEditors.ButtonsPanelControl
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraBars
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraReports.UI
Imports System.Drawing.Printing
Imports DevExpress.XtraPrinting

Public Class frAskur
    Dim WithEvents TextControl As TextBox                           ' Для запрета редактирования DataGrida
    Dim curDocumentTypeId As Integer                                ' Тип текущего документа запущенного на печать
    Dim AbonentId = "NULL"                                          ' Ид абонента (для печати 1го лицевого)
    Dim ControllerId As String = "NULL"                             ' Ид контролера
    Dim GKO As String = "NULL"                                      ' Наименование УК
    Dim RouterId As String = "NULL"                                 ' Ид маршрута
    Dim BalanceMin As String = "NULL"                               ' Диапазон долга Мин
    Dim BalanceMax As String = "NULL"                               ' Диапазон долга Макс
    Dim CountMonthMin As String = "NULL"                            ' Диапан периодов ДЗ Мин
    Dim CountMonthMax As String = "NULL"                            ' Группа периодов ДЗ Макс
    Dim prHouseTypeId As String = "NULL"                            ' Тип жилья по ПК Припять
    Dim KVZ_EventTypeId As String = "NULL"                          ' Тип документа на вручение расчитанный по ПК Припять
    Dim prEventGroupMin As String = "NULL"                          ' Группировка по типу документа
    Dim prEventGroupMax As String = "NULL"                          ' Все типы: - Уведомлений (100 - 110)
    '                                                                           - Извещения (110)
    '                                                                           - Отключения (1)
    Dim IsDelPrinted As Integer                                     'Исключение из перечня уже печатавших
    '                                                                           - 1: - исключение
    '                                                                           - 0: - оставляем

    Dim DtSessionBegin As DateTime                                  ' Фильтры для сеансов печати (нач. дата)
    Dim DtSessionEnd As DateTime                                    ' Фильтры для сеансов печати (конеч. дата)
    Dim DebetMapEvents As String = "1, 3, 6, 8"                     ' Строка с набором событий для выгрузки карты ДЗ

    '------------------------------------------------------------------------------------------------------------------------------
    Dim IsFirstActPrintDocs As Boolean = True                       ' Первая ли активация вкладки "Печать документов"
    Dim IsFirstActTasksHistory As Boolean = True                    ' Первая ли активация вкладки "Статистика выдачи задания"
    Dim IsFirstActDebetMap As Boolean = True                        ' Первая ли активация вкладки "Карта ДЗ"
    Dim PreferenceForms As String                                   ' Ветка в реестре для хранения настроек формы 
    Dim SessionsSelectedIndex As Integer = 0                        ' Индекс активной строки на сетке сеансов печати
    Dim IsNewTaskSheetId As Boolean                                 ' Имеется уже лист задание или будет формироваться новый
    Friend TaskSheetId As String                                    ' ИД листа задания, нового либо существующего
    Friend OnHands As String                                        ' ИД листа задания для загрузки того что на руках


    Sub New()
        SplashScreenManager.ShowForm(Me, GetType(frWaitAskur), True, True, False)
        InitializeComponent()
        EventChangedControl = False
        PreferenceForms = pref_UserSettings & Me.Name & "\"
        Me.SplitContainerControl1.Panel1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.SplitContainerControl1.Panel2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.SplitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default
        Me.SplitContainerControl1.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default

        Me.lb_WorkerName.Caption = "Сотрудник: " & pref_PerformerName
        Me.lb_WorkerName.Tag = "Сотрудник: " & pref_PerformerId
        Me.num_PrintStart.Value = 1
        Me.num_PrintEnd.Value = 1

        ' Исключения для районов
        If pref_CityOrVillages = 2 Then
            Me.RB_cmbRoute.Enabled = False
        End If

        FillTV_Maneger()        ' Выстраиваем дерево контролеров
        GetPreferenceForm()     ' Загрузка настроек из реестра
        tc_MainTabControl_SelectedPageChanged(Me, Nothing)

        ' Двойная буферезация для DataGridView
        SetDoubleBuffered(Me.dg_ResultPrint)   'Установка DoubleBuffered для DataGridView
        SetDoubleBuffered(Me.dg_ControlSum)    'Установка DoubleBuffered для DataGridView

        EventChangedControl = True
        FormLoadComplied = True ' Форма загружена

        SplashScreenManager.CloseForm()
    End Sub

    Private Sub frAskur_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        SavePreferenceForm()
        FormLoadComplied = False
        LiberationMemory()
        RemoveTableDataSet(Me)
        Me.Dispose()
        frMain.Show()
        frMain.NotifyIcon.Visible = False
        frMain.Time.Enabled = True
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

#Region "Манипуляции с настройками программы"
    ' Сохранения настроек формы
    Private Sub SavePreferenceForm()
        RegistryWrite(PreferenceForms, "TabControlSelectedIndex", Me.tc_MainTabControl.SelectedTabPageIndex)
        RegistryWrite(PreferenceForms, "DtSessionBegin", DtSessionBegin)
        RegistryWrite(PreferenceForms, "DtSessionEnd", DtSessionEnd)
        RegistryWrite(PreferenceForms, "IsDelPrinted", Convert.ToInt32(Me.RB_tglDelPrinted.Checked))
        RegistryWrite(PreferenceForms, "RB_menuPeriodSession.Pressed", RB_menuPeriodSession.Tag)
    End Sub
    ' Чтение настроек формы
    Private Sub GetPreferenceForm()
        DtSessionBegin = RegistryRead(PreferenceForms, "DtSessionBegin", Now.AddDays(-7).ToShortDateString)
        DtSessionEnd = RegistryRead(PreferenceForms, "DtSessionEnd", Now.ToShortDateString)
        Me.RB_tglDelPrinted.Checked = Convert.ToBoolean(Convert.ToInt32(RegistryRead(PreferenceForms, "IsDelPrinted", "0")))
        Me.tc_MainTabControl.SelectedTabPageIndex = RegistryRead(PreferenceForms, "TabControlSelectedIndex", 0)
        WhatIsPeriod(RegistryRead(PreferenceForms, "RB_menuPeriodSession.Pressed", "tb_fltrSessionLast7Days"))
    End Sub
    ' Отметка в меню какой период взят из настроек
    Private Sub WhatIsPeriod(ByVal ActiveItem As String)
        Me.RB_menuPeriodSession.Tag = ActiveItem
        Select Case ActiveItem
            Case "tb_fltrSessionLast7Days" ' За последние 7 дней
                tb_fltrSessionLast7Days.Checked = True
            Case "tb_fltrSessionLast30Days" ' За последние 30 дней
                tb_fltrSessionLast30Days.Checked = True
            Case "tb_fltrSessionLast90Days" ' За последние 90 дней
                tb_fltrSessionLast90Days.Checked = True
            Case "tb_fltrSessionLast365Days" ' За последние 365 дней
                tb_fltrSessionLast365Days.Checked = True
            Case "tb_fltrSessionCurWeek" ' За текущюю неделю
                tb_fltrSessionCurWeek.Checked = True
            Case "tb_fltrSessionCurMonth" ' За текущий месяц
                tb_fltrSessionCurMonth.Checked = True
            Case "tb_fltrSessionCurQuarter" ' За текущий квартал
                tb_fltrSessionCurQuarter.Checked = True
            Case "tb_fltrSessionCurYear" ' За текущий год
                tb_fltrSessionCurYear.Checked = True
            Case "tb_fltrSessionClear" ' Без ограничений
                tb_fltrSessionClear.Checked = True
        End Select
    End Sub
#End Region
#Region "<<<<<<<<<<<<<TabControl>>>>>>>>>>>>>>>>>"
    ' Скрытие всех контекстных вкладок и отображение заданной
    Private Sub ContextualTabGroupsVisible(ByVal tg As RibbonPageCategory, ByVal t As RibbonPage)
        For Each PageCategories As RibbonPageCategory In Me.RibbonMain.PageCategories
            If PageCategories.Name = tg.Name Then
                PageCategories.Visible = True
                ' Если отобразили нужную контектную вкладку
                For Each iTab As RibbonPage In PageCategories.Pages
                    ' активируем в ней вкладку
                    If iTab.Name = t.Name Then
                        iTab.Ribbon.SelectedPage = t
                    End If
                Next
            Else
                PageCategories.Visible = False
            End If
        Next
    End Sub
    ' после активации вкладки
    Private Sub tc_MainTabControl_SelectedPageChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tc_MainTabControl.SelectedPageChanged
        If Me.tc_MainTabControl.SelectedTabPageIndex <> -1 Then
            Application.DoEvents()
            Me.tc_MainTabControl.TabPages(Me.tc_MainTabControl.SelectedTabPageIndex).Hide()
        End If
        Select Case Me.tc_MainTabControl.SelectedTabPageIndex
            Case 0 ' Печать документов
                ActivatePrintDocs()
            Case 1 ' История выдачи заданий 
                ActivateTasksHistory()
            Case 2 ' Карта ДЗ
                ActivateDebitMap()
        End Select
        If Me.tc_MainTabControl.SelectedTabPageIndex <> -1 Then
            Application.DoEvents()
            Me.tc_MainTabControl.TabPages(Me.tc_MainTabControl.SelectedTabPageIndex).Show()
        End If
    End Sub

#Region "<<<<<<<<<<<<<Вкладка Печать документов>>>>>>>>>>>>>>>>>"
    ' Активация вкладки
    Private Sub ActivatePrintDocs()
        If FormLoadComplied Then WaitFormShow(Me, 1)
        ' Постоянные события при активации вкладки
        ContextualTabGroupsVisible(Me.RibConTab_PrintDocs, Me.RibTab_Filters)
        Me.lb_CurrentAddress.Visibility = True             ' Отображаем имя иcполнителя в нижнем баре

        ' События при первой активации вкладки
        If IsFirstActPrintDocs Then
            LoadingPerformers()     ' Загрузка контролеров
            LoadingGKO()            ' Загрузка списка УК
            LoadingRouters()        ' Загрузка маршрутов

            ' Загружаем пустой список на печать уведомлений
            SelectQueryData("ListPrint." & Me.Name, "EXEC Pr_OioPrintNotice @ControllerId = 0", "btn_ViewResult")
            ' Пока процесс выполняется....
            Do Until CompliteLoad
                ' Ждем и ничего не делаем
                My.Application.DoEvents()
            Loop
            ' Привязываем dg_ResultPrint к данным
            Me.dg_ResultPrint.DataSource = iDataSet.Tables("ListPrint." & Me.Name)
            ' Скрываем все столбцы на .dg_ResultPrint
            For i = 0 To Me.dg_ResultPrint.ColumnCount - 1
                Me.dg_ResultPrint.Columns.Item(i).Visible = False
            Next
            ' Отображаем нужные столбцы и задаем им имена
            Dim ColGrid As Object = Me.dg_ResultPrint.Columns
            ColGrid.Item("RowNumber").HeaderText = "№ П/П"
            ColGrid.Item("RowNumber").Visible = True
            ColGrid.Item("AbonentNumber").HeaderText = "Номер абонента"
            ColGrid.Item("AbonentNumber").Visible = True
            ColGrid.Item("SNP").HeaderText = "Фамилия Имя Отчество"
            ColGrid.Item("SNP").Visible = True
            ColGrid.Item("AddressString").HeaderText = "Адрес должника"
            ColGrid.Item("AddressString").Visible = True
            ColGrid.Item("Balance").HeaderText = "Сумма долга"
            ColGrid.Item("Balance").Visible = True
            ColGrid.Item("Balance").DefaultCellStyle.Format = "N2"
            ColGrid.Item("prEventName").HeaderText = "Тип документа"
            ColGrid.Item("prEventName").Visible = True
            ' Отключаем сортировку столбцов по всему Гриду
            For i = 0 To Me.dg_ResultPrint.ColumnCount - 1
                Me.dg_ResultPrint.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next
            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            Me.dg_ControlSum.DataSource = iDataSet.Tables("ListPrint." & Me.Name & "1")
            ' Скрываем все столбцы на .dg_ResultPrint
            For i = 0 To Me.dg_ControlSum.ColumnCount - 1
                Me.dg_ControlSum.Columns.Item(i).Visible = False
            Next
            ' Отображаем нужные столбцы и задаем им имена
            Dim ColGrid1 As Object = Me.dg_ControlSum.Columns
            ColGrid1.Item("prEventName").HeaderText = "Планируемое событие"
            ColGrid1.Item("prEventName").Visible = True
            ColGrid1.Item("Count").HeaderText = "Кол - во, шт"
            ColGrid1.Item("Count").Visible = True
            ColGrid1.Item("Count").DefaultCellStyle.Format = "N0"
            ColGrid1.Item("Sum").HeaderText = "Сумма, руб"
            ColGrid1.Item("Sum").Visible = True
            ColGrid1.Item("Sum").DefaultCellStyle.Format = "N2"
            Me.dg_ControlSum.Columns("prEventName").MinimumWidth = 200
            ' Отключаем сортировку столбцов по всему Гриду
            For i = 0 To Me.dg_ControlSum.ColumnCount - 1
                Me.dg_ControlSum.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i
            ' загружаем список активных принтеров
            Me.cmbPrintersList.Properties.Items.Clear()
            Dim printDoc As New PrintDocument   ' произвольный документ
            Dim printName As String             ' имя принтера
            Dim image As Boolean                ' статус принтера
            Dim ActivePrinter As Integer = 0
            ' перебираем подключенные принтеры
            For i = 0 To PrinterSettings.InstalledPrinters.Count - 1
                printName = PrinterSettings.InstalledPrinters.Item(i)
                image = (printDoc.PrinterSettings.PrinterName = printName)
                If printDoc.PrinterSettings.PrinterName = printName Then ActivePrinter = i
                Dim someItem As New ImageComboBoxItem
                someItem.Description = printName
                someItem.ImageIndex = Convert.ToInt64(image)
                someItem.Value = printName
                Me.cmbPrintersList.Properties.Items.Add(someItem)
            Next
            Me.cmbPrintersList.SelectedIndex = ActivePrinter
            IsFirstActPrintDocs = False
        End If
        If FormLoadComplied Then WaitFormShow(Me, 0)
    End Sub
#Region "Обработка изменения диапазона на печать"
    Private Sub num_Print_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Если первый вход в поле контрола
        If iEnter = False Then
            sender.SelectAll()      ' Выделяем весь текст
            iEnter = True           ' Вход состоялся
        End If
    End Sub
    Private Sub num_PrintEnd_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        iEnter = False ' Выход из поля состоялся
    End Sub
    Private Sub num_PrintStart_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If EventChangedControl = True Then
            ' Запрещаем значение меньше нуля и больше чем Me.num_PrintEnd.Value
            If sender.Value < 1 Then sender.Value = 1
            If sender.Value > Me.num_PrintEnd.Value Then sender.Value = Me.num_PrintEnd.Value
        End If
    End Sub
    Private Sub num_PrintEnd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If EventChangedControl = True Then
            ' Запрещаем значение меньше нуля, меньше чем num_PrintStart.Value 
            ' и больше количества строк на dg_ResultPrint
            If sender.Value < 1 Then sender.Value = 1
            If sender.Value < Me.num_PrintStart.Value Then sender.Value = Me.num_PrintStart.Value
            If sender.Value > Me.dg_ResultPrint.RowCount Then sender.Value = Me.dg_ResultPrint.RowCount
        End If
    End Sub
#End Region

    ' Выбрать весь диапазон на печать
    Private Sub btn_AllDiapazon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_AllDiapazon.Click
        ' Если список должников не пустой
        If Me.dg_ResultPrint.RowCount <> 0 Then
            Me.num_PrintStart.Value = 1
            Me.num_PrintEnd.Value = Me.dg_ResultPrint.RowCount
        End If
    End Sub
    ' При изменении принтера проверяем дуплекс
    Private Sub cmbPrintersList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbPrintersList.SelectedIndexChanged
        Dim np As New Printing.PrinterSettings
        np.PrinterName = cmbPrintersList.Text
        If np.CanDuplex Then
            Me.lbIsDuplex.Appearance.Image = My.Resources.apply_16x16
            Me.lbIsDuplex.ToolTip = "Выбранный принтер поддерживает" & Chr(10) & "двухстороннюю печать"
        Else
            Me.lbIsDuplex.Appearance.Image = My.Resources.cancel_16x16
            Me.lbIsDuplex.ToolTip = "Выбранный принтер НЕ поддерживает" & Chr(10) & "двухстороннюю печать"
        End If
    End Sub
    ' Выгрузка и просмотр перечня дебиторов на печать
    Private Sub btn_ViewResult_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ViewResult.Click
        Dim sw = New Stopwatch()
        sw.Start() ' Старт измерения времени на выгрузку
        Me.Cursor = Cursors.WaitCursor
        ' Определение параметров фильтрации выборки
        '=====================================================
        ControllerId = Me.RB_cmbControllers.EditValue
        If Me.RB_cmbGKORepository.GetDisplayText(Me.RB_cmbGKO.EditValue) <> "Все Управляющие компании" Then
            GKO = "'" & Me.RB_cmbGKORepository.GetDisplayText(Me.RB_cmbGKO.EditValue) & "'"
        End If
        RouterId = Me.RB_cmbRoute.EditValue
        BalanceMin = Me.RB_numDebetMin.EditValue
        BalanceMax = Me.RB_numDebetMax.EditValue
        CountMonthMin = Me.RB_PeriodMin.EditValue
        CountMonthMax = Me.RB_PeriodMax.EditValue
        prHouseTypeId = "NULL"
        If Me.RB_tglMKD.Checked Then prHouseTypeId = Me.RB_tglMKD.Tag
        If Me.RB_tglChS.Checked Then prHouseTypeId = Me.RB_tglChS.Tag

        Select Case Me.RB_menuDocType.Description
            Case "RB_menuDocTypeNotices" ' Уведомления
                KVZ_EventTypeId = "NULL"
                prEventGroupMin = 100
                prEventGroupMax = 110
            Case "RB_menuDocTypeNoticesUnh" ' Извещения
                KVZ_EventTypeId = "NULL"
                prEventGroupMin = 110
                prEventGroupMax = 110
            Case "RB_menuDocTypeUnhookinges" ' Отключения
                KVZ_EventTypeId = "NULL"
                prEventGroupMin = 1
                prEventGroupMax = 1
            Case "RB_menuDocTypeAllDocs" ' Все мероприятия
                KVZ_EventTypeId = "NULL"
                prEventGroupMin = "NULL"
                prEventGroupMax = "NULL"
            Case Else
                KVZ_EventTypeId = Me.RB_menuDocType.Tag
                prEventGroupMin = "NULL"
                prEventGroupMax = "NULL"
        End Select

        IsDelPrinted = Convert.ToInt32(RB_tglDelPrinted.Checked)
        '=====================================================
        If iDataSet.Tables.Contains("ListPrint." & Me.Name & "1") Then iDataSet.Tables("ListPrint." & Me.Name & "1").Clear()
        SelectQueryData(
                        "ListPrint." & Me.Name,
 _
                        "EXEC Pr_OioPrintNotice " & _
                                "@ControllerId = " & ControllerId & ", " & _
                                "@GKO = " & GKO & ", " & _
                                "@RouterId = " & RouterId & ", " & _
                                "@ArealId = " & ArealId & ", " & _
                                "@VillageId = " & CityVillageId & ", " & _
                                "@AddressPartId = " & StreetId & ", " & _
                                "@BalanceMin = " & BalanceMin & ", " & _
                                "@BalanceMax = " & BalanceMax & ", " & _
                                "@CountMonthMin = " & CountMonthMin & ", " & _
                                "@CountMonthMax = " & CountMonthMax & ", " & _
                                "@prHouseTypeId = " & prHouseTypeId & ", " & _
                                "@KVZ_EventTypeId = " & KVZ_EventTypeId & ", " & _
                                "@prEventGroupMin = " & prEventGroupMin & ", " & _
                                "@prEventGroupMax = " & prEventGroupMax & ", " & _
                                "@IsDelPrinted = " & IsDelPrinted,
 _
                        "btn_ViewResult"
                        )
        ' Пока процесс выполняется....
        Do Until CompliteLoad
            ' Ждем и ничего не делаем
            My.Application.DoEvents()
        Loop

        ' Если перечень выгружен
        If Me.dg_ResultPrint.RowCount <> 0 Then
            ' Диапазон на печать
            Me.num_PrintStart.Text = 1
            Me.num_PrintStart.Enabled = True
            Me.num_PrintEnd.Text = Me.dg_ResultPrint.RowCount
            Me.num_PrintEnd.Enabled = True

            Me.btn_AllDiapazon.Enabled = True   ' Кнопка весь диапазон
            Me.btn_PrintDocs.Enabled = True     ' Кнопка Печать
            ' Форматируем таблицу с контрольными суммами
            Designer_dgControlSum()
        Else
            ' Диапазон на печать
            Me.num_PrintStart.Text = 0
            Me.num_PrintStart.Enabled = False
            Me.num_PrintEnd.Text = 0
            Me.num_PrintEnd.Enabled = False

            Me.btn_AllDiapazon.Enabled = False  ' Кнопка весь диапазон
            Me.btn_PrintDocs.Enabled = False    ' Кнопка Печать
        End If
        Me.Cursor = Cursors.Default
        sw.Stop() ' Останавливаем таймер затраченного времени на процедуру
        ' Записываем затраченное время
        Me.lbl_TimeInWay.Caption = Microsoft.VisualBasic.Strings.Left(sw.Elapsed.ToString(), 8)
    End Sub
    ' Событие при печати активного документа
    Private Sub PrintingSystem_StartPrint(sender As Object, e As PrintDocumentEventArgs)
        ' Set the page range.
        Select curDocumentTypeId ' Тип документа
            Case 1, 2, 5    ' Уведомление
                e.PrintDocument.PrinterSettings.Duplex = Duplex.Vertical
                e.PrintDocument.PrinterSettings.FromPage = 1
                e.PrintDocument.PrinterSettings.ToPage = 2
                e.PrintDocument.PrinterSettings.Copies = 1
            Case 3, 6, 8    ' Акт
                e.PrintDocument.PrinterSettings.Duplex = Duplex.Default
                e.PrintDocument.PrinterSettings.FromPage = 3
                e.PrintDocument.PrinterSettings.ToPage = 3
                e.PrintDocument.PrinterSettings.Copies = 2
        End Select
    End Sub
    ' Запуск печати удомлений
    Private Sub btn_PrintDocs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_PrintDocs.Click
        LiberationMemory() ' Перед печатью очищаем память
        Dim rptNotice As New blNotice()
        Dim printTool As New ReportPrintTool(rptNotice)
        Dim rPrintCurRow As Object = Me.dg_ResultPrint.Rows
        AddHandler printTool.PrintingSystem.StartPrint, AddressOf PrintingSystem_StartPrint
        printTool.PrinterSettings.PrinterName = cmbPrintersList.Text
        ' Получаем константы для бланков
        Try
            SelectQueryData(
                            "Constants." & Me.Name,
                            "SELECT * FROM vPr_OioConstantsNotice",
                            "btn_PrintDocs.1"
                            )
            Dim rConstants As Object = iDataSet.Tables("Constants." & Me.Name).Rows(0)
            ' Заполняем бланк константами
            rptNotice.lbNameRuleManager.Text = rConstants("NameRuleManager")                ' Должность подписанта
            rptNotice.lbNameRuleManagerReason.Text = rConstants("NameRuleManagerReason")    ' Основание подписанта
            rptNotice.lbManager.Text = rConstants("Manager")                                ' Подписант
            rptNotice.lbOrganizationPhone.Text = rConstants("OrganizationPhone")            ' Телефоны организации
            rptNotice.lbBankRequisitions.Text = rConstants("Requisitions")                  ' Реквизиты
            rptNotice.lbDivisionAddress.Text = rConstants("DivisionAddress")                ' Юр. адрес предприятия
            'rptNotice. = rConstants("PerformerOrganisation")                               ' Подписант акта 
        Catch ex As Exception
            Exit Sub
        End Try

        ' Создаем в базе сеанс печати и получаем его ИД
        SelectQueryData(
                        "SessionId." & Me.Name,
 _
                        "EXEC Pr_PrintSessions " & _
                                                "@UserName = '" & My.User.Name & "', " & _
                                                "@HostName = '" & My.Computer.Name & "', " & _
                                                "@PrinterName = '" & printTool.PrinterSettings.PrinterName & "', " & _
                                                "@Copies = " & printTool.PrinterSettings.Copies & ", " & _
                                                "@fltr_ControllerId = " & ControllerId & ", " & _
                                                "@fltr_Gko = " & GKO & ", " & _
                                                "@fltr_RouterId = " & RouterId & ", " & _
                                                "@fltr_ArealId = " & ArealId & ", " & _
                                                "@fltr_CityVillageId = " & CityVillageId & ", " & _
                                                "@fltr_AddressPartId = " & StreetId & ", " & _
                                                "@fltr_BalanceMin = " & BalanceMin & ", " & _
                                                "@fltr_BalanceMax = " & BalanceMax & ", " & _
                                                "@fltr_CountMonthMin = " & CountMonthMin & ", " & _
                                                "@fltr_CountMonthMax = " & CountMonthMax & ", " & _
                                                "@fltr_prHouseTypeId = " & prHouseTypeId & ", " & _
                                                "@fltr_DocTypeNotice = '" & Me.RB_menuDocType.Caption & "', " & _
                                                "@Function = 2",
 _
                       "btn_PrintDocs.2"
                       )
        ' Записываем ИД сеанса в переменную
        Dim SessionId As Integer = iDataSet.Tables("SessionId." & Me.Name).Rows(0).Item("SessionId")

        ' Запускаем цикл печати
        For i = Me.num_PrintStart.Text - 1 To Me.num_PrintEnd.Text - 1
            ' выделяем активную строку печати
            Me.dg_ResultPrint.CurrentCell = Me.dg_ResultPrint _
                                            .Rows(i) _
                                            .Cells(Me.dg_ResultPrint.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Name)
            Me.dg_ResultPrint.SelectedCells(dg_ResultPrint.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Index).Selected = True
            Application.DoEvents()
            Try
                ' Регистрируем документ
                SelectQueryData(
                                "InJournal." & Me.Name,
 _
                                "EXEC Pr_JournalDocRegistration " & _
                                                "@SessionId = " & SessionId & ", " & _
                                                "@AbonentId = " & rPrintCurRow.Item(i).Cells("AbonentId").Value & ", " & _
                                                "@FamilyMemberId = " & ConvertToNull(rPrintCurRow.Item(i).Cells("FamilyMemberId").Value.ToString, True, 0) & ", " & _
                                                "@AbonentNumber = '" & rPrintCurRow.Item(i).Cells("AbonentNumber").Value & "', " & _
                                                "@SNP_short = '" & rPrintCurRow.Item(i).Cells("SNP_short").Value & "', " & _
                                                "@AddressString = '" & rPrintCurRow.Item(i).Cells("AddressString").Value & "', " & _
                                                "@SumDoc = " & Replace(rPrintCurRow.Item(i).Cells("Balance").Value, " ", "") & ", " & _
                                                "@DocumentTypeId = " & rPrintCurRow.Item(i).Cells("KVZ_EventTypeId").Value & ", " & _
                                                "@ControllerId = " & rPrintCurRow.Item(i).Cells("ControllerId").Value & ", " & _
                                                "@DtDoc = '" & rPrintCurRow.Item(i).Cells("DtDoc").Value & "', " & _
                                                "@DtBeginOio = '" & rPrintCurRow.Item(i).Cells("DtBeginOio").Value & "', " & _
                                                "@Function = 2",
 _
                                "btn_PrintDocs.3"
                                )
            Catch ex As Exception
                XtraMessageBox.Show("Неудалось зарегистрировать документ!" & Chr(10) & _
                                    "Проверьте подключение к базе данных....",
                                    "Ошибка регистрации",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
            ' Наименование бланка - документа
            rptNotice.DisplayName = rPrintCurRow.Item(i).Cells("Address").Value()
            curDocumentTypeId = rPrintCurRow.Item(i).Cells("KVZ_EventTypeId").Value
            Select Case curDocumentTypeId ' Тип документа
                Case 1, 2, 5    ' Уведомление
                    rptNotice.lbSNP.Text = rPrintCurRow.Item(i).Cells("SNP").Value()
                    rptNotice.lbAbonentNumber.Text = "№ лицевого счета:  " & rPrintCurRow.Item(i).Cells("AbonentNumber").Value()
                    rptNotice.lbAddress.Text = rPrintCurRow.Item(i).Cells("Address").Value()
                    rptNotice.lbAltAddress.Text = rPrintCurRow.Item(i).Cells("altAddress").Value()
                    rptNotice.lbCounterNumber.Text = "№ счетчика:  " & rPrintCurRow.Item(i).Cells("CounterNumber").Value()
                    ' Регистрационный номер и дата
                    rptNotice.lbDtDoc.Text = iDataSet.Tables("InJournal." & Me.Name).Rows(0).Item("DtDocument").ToString & " г."
                    rptNotice.lbDocNumber.Text = iDataSet.Tables("InJournal." & Me.Name).Rows(0).Item("DocNumber").ToString

                    rptNotice.lbDocName.Text = rPrintCurRow.Item(i).Cells("prDocName").Value()
                    rptNotice.txtDocText.Html = rPrintCurRow.Item(i).Cells("prDocText").Value()
                    rptNotice.txtLastIndicationString.Html = rPrintCurRow.Item(i).Cells("LastIndicString").Value()
                    rptNotice.lbLastPayString.Text = rPrintCurRow.Item(i).Cells("LastPayString").Value()
                    rptNotice.lbPerformerName.Text = rPrintCurRow.Item(i).Cells("PerformerName").Value()
                    rptNotice.lbPerformerName_footer.Text = rPrintCurRow.Item(i).Cells("PerformerName").Value()

                    rptNotice.lbSNP_footer.Text = rPrintCurRow.Item(i).Cells("SNP").Value()
                    rptNotice.lbAbonentNumber_footer.Text = rPrintCurRow.Item(i).Cells("AbonentNumber").Value()
                    rptNotice.lbAddress_footer.Text = rPrintCurRow.Item(i).Cells("Address").Value()
                    rptNotice.lbAltAddress_footer.Text = rPrintCurRow.Item(i).Cells("altAddress").Value()
                    rptNotice.lbDtDoc_footer.Text = iDataSet.Tables("InJournal." & Me.Name).Rows(0).Item("DtDocument").ToString & " г."
                    rptNotice.lbDocNumber_footer.Text = iDataSet.Tables("InJournal." & Me.Name).Rows(0).Item("DocNumber").ToString
                    rptNotice.txtDocText_footer.Html = rPrintCurRow.Item(i).Cells("prDocText_footer").Value()

                    rptNotice.XrBarCode1.Text = "45" & rPrintCurRow.Item(i).Cells("AbonentNumber").Value()
                    rptNotice.XrBarCode2.Text = rPrintCurRow.Item(i).Cells("Balance").Value()
                    rptNotice.XrBarCode3.Text = rPrintCurRow.Item(i).Cells("AbonentNumber").Value()
                    rptNotice.lbBalance1.Text = rPrintCurRow.Item(i).Cells("Balance").Value() & " руб."
                    rptNotice.lbBalance2.Text = rPrintCurRow.Item(i).Cells("Balance").Value() & " руб."
                    rptNotice.lbBalance3.Text = rPrintCurRow.Item(i).Cells("Balance").Value()
                    rptNotice.lbAbonentNumber1.Text = "№ лицевого счета:  " & rPrintCurRow.Item(i).Cells("AbonentNumber").Value()
                    rptNotice.lbAbonentNumber2.Text = "№ лицевого счета:  " & rPrintCurRow.Item(i).Cells("AbonentNumber").Value()
                    rptNotice.lbAddress1.Text = rPrintCurRow.Item(i).Cells("Address").Value()
                    rptNotice.lbAddress2.Text = rPrintCurRow.Item(i).Cells("Address").Value()
                    rptNotice.lbAltAddress1.Text = rPrintCurRow.Item(i).Cells("altAddress").Value()
                    rptNotice.lbAltAddress2.Text = rPrintCurRow.Item(i).Cells("altAddress").Value()
                    rptNotice.lbEnergyType.Text = "Электроэнергия  " & rPrintCurRow.Item(i).Cells("AbonentNumber").Value()
                Case 3, 6, 8    ' Акт
                    rptNotice.lbSNP_a.Text = rPrintCurRow.Item(i).Cells("SNP").Value()
                    rptNotice.lbAddress_a.Text = rPrintCurRow.Item(i).Cells("AddressString").Value()
                    rptNotice.lbAbonentNumber_a.Text = rPrintCurRow.Item(i).Cells("AbonentNumber").Value()
                    rptNotice.lbBalance_a.Text = rPrintCurRow.Item(i).Cells("Balance").Value() & " рублей."

                    ' Регистрационный номер и дата
                    Dim dt As Date = iDataSet.Tables("InJournal." & Me.Name).Rows(0).Item("DtDocument").ToString

                    rptNotice.txtDtDoc_a.Html = _
                        "<pre><p align=""Center"" style=""font-size: 14pt; font-family:'Times New Roman'""" & _
                        "<b>Акт №<u>  " & iDataSet.Tables("InJournal." & Me.Name).Rows(0).Item("DocNumber").ToString & "  </u>" & _
                        " от " & Chr(171) & "<u>   " & GetDayNumberString(dt.Day) & "   </u>" & Chr(187) &
                        "<u>  " & GetMonthString(dt.Month, "Р", VbStrConv.Lowercase) & "  </u>" & _
                        "  <u> " & dt.Year & " </u> г." & _
                        "</b></p></pre>"
                    rptNotice.lbDocName_a.Text = rPrintCurRow.Item(i).Cells("prDocName").Value()
                    rptNotice.lbLastPay_a.Text = rPrintCurRow.Item(i).Cells("LastPayString").Value()
                    'exl.Names.Item("a_PerformerName").RefersToRange.Value = rPrintCurRow.Item(i).Cells("PerformerName").Value()
                    ' Получение данных для таблицы акта
                    SelectQueryData(
                                    "PointsList." & Me.Name,
                                    "EXEC Pr_OioGetPointsCounters @AbonentId = " & rPrintCurRow.Item(i).Cells("AbonentId").Value(),
                                    "btn_PrintDocs.2"
                                    )
                    ' Заполнение таблицы с точками учета
                    ' Очищаем таблицу
                    For Each xrRow As XRTableRow In rptNotice.XrTable2.Rows
                        xrRow.Visible = True
                        If xrRow.Index <> 0 Then
                            For iCell = 0 To xrRow.Cells.Count - 1
                                rptNotice.XrTable2.Rows(xrRow.Index).Cells(iCell).Text = ""
                            Next (iCell)
                        End If
                    Next
                    ' Заполняем таблицу
                    For r = 0 To iDataSet.Tables("PointsList." & Me.Name).Rows.Count - 1            ' строки
                        For c = 0 To iDataSet.Tables("PointsList." & Me.Name).Columns.Count - 1     ' столбцы
                            rptNotice.XrTable2.Rows(r + 1).Cells(c).Text = iDataSet.Tables("PointsList." & Me.Name).Rows(r).Item(c).ToString
                        Next c
                    Next r
            End Select
            Application.DoEvents()
            rptNotice.CreateDocument()
            ' printTool.ShowRibbonPreview()
            printTool.Print()
        Next
        With New frInfo
            .Mess = "Печать уведомлений завершена!"
            .Show()     ' Всплываюшее сообщение
        End With
    End Sub

    ' Формирование таблицы с контрольными суммами перечня на печать
    Private Sub Designer_dgControlSum()
        ' Цикл по таблице с контрольными суммами
        For i = 0 To Me.dg_ControlSum.RowCount - 1
            Select Case Me.dg_ControlSum.Item("EventTypeId", i).Value
                Case 2 To 89 ' Разбивка по типам жилья
                    Me.dg_ControlSum.Rows(i).Height = 15
                    ' Наименование события
                    Me.dg_ControlSum.Item("prEventName", i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    Me.dg_ControlSum.Item("prEventName", i).Style.Font = New Font("Microsoft Sans Serif", 7.0!, FontStyle.Regular)
                    ' Количество
                    Me.dg_ControlSum.Item("Count", i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    Me.dg_ControlSum.Item("Count", i).Style.Font = New Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular)
                    ' Сумма
                    Me.dg_ControlSum.Item("Sum", i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    Me.dg_ControlSum.Item("Sum", i).Style.Font = New Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular)

                Case 0 ' Промежуточные итоги
                    ' Наименование события
                    Me.dg_ControlSum.Item("prEventName", i).Style.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Me.dg_ControlSum.Item("prEventName", i).Style.Font = New Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold)
                    Me.dg_ControlSum.Item("prEventName", i).Style.BackColor = Color.FromArgb(205, 175, 149)
                    Me.dg_ControlSum.Item("prEventName", i).Style.ForeColor = Color.FromArgb(93, 71, 139)
                    ' Количество
                    Me.dg_ControlSum.Item("Count", i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    Me.dg_ControlSum.Item("Count", i).Style.Font = New Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold)
                    Me.dg_ControlSum.Item("Count", i).Style.BackColor = Color.FromArgb(205, 175, 149)
                    Me.dg_ControlSum.Item("Count", i).Style.ForeColor = Color.FromArgb(93, 71, 139)
                    ' Сумма
                    Me.dg_ControlSum.Item("Sum", i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    Me.dg_ControlSum.Item("Sum", i).Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold)
                    Me.dg_ControlSum.Item("Sum", i).Style.BackColor = Color.FromArgb(205, 175, 149)
                    Me.dg_ControlSum.Item("Sum", i).Style.ForeColor = Color.FromArgb(93, 71, 139)

                Case 90 ' Итого
                    ' Наименование события
                    Me.dg_ControlSum.Item("prEventName", i).Style.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Me.dg_ControlSum.Item("prEventName", i).Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold)
                    Me.dg_ControlSum.Item("prEventName", i).Style.BackColor = Color.FromArgb(255, 106, 106)
                    Me.dg_ControlSum.Item("prEventName", i).Style.ForeColor = Color.FromArgb(0, 0, 238)
                    ' Количество
                    Me.dg_ControlSum.Item("Count", i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    Me.dg_ControlSum.Item("Count", i).Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold)
                    Me.dg_ControlSum.Item("Count", i).Style.BackColor = Color.FromArgb(255, 106, 106)
                    Me.dg_ControlSum.Item("Count", i).Style.ForeColor = Color.FromArgb(0, 0, 238)
                    ' Сумма
                    Me.dg_ControlSum.Item("Sum", i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    Me.dg_ControlSum.Item("Sum", i).Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold)
                    Me.dg_ControlSum.Item("Sum", i).Style.BackColor = Color.FromArgb(255, 106, 106)
                    Me.dg_ControlSum.Item("Sum", i).Style.ForeColor = Color.FromArgb(0, 0, 238)
            End Select
        Next i
    End Sub
    ' Запрет выделения строки в гриде с контрольными суммами
    Private Sub dg_ControlSum_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        dg_ControlSum.CurrentCell.Selected = False
    End Sub

#Region "Для возможности скопировать данные из ячейки"
    Private Sub dg_ResultPrint_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs)

        ' Отмена при попытке редактировать Грид
        TextControl = e.Control
        TextControl.ReadOnly = True ' вот и не сможем менять содержимое
    End Sub
    Private Sub DataGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        ' ВКЛ Запрета на редактирование
        Me.dg_ResultPrint.ReadOnly = True
    End Sub
    Private Sub DataGrid_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        ' Активиция ячейки правой кнопкой мыши
        If e.ColumnIndex >= 0 And e.RowIndex >= 0 And e.Button = Windows.Forms.MouseButtons.Left And e.Clicks = 2 Then
            ' ОТКЛ Запрета на редактированиее
            sender.ReadOnly = False
            sender.CurrentCell = sender.Rows(e.RowIndex).Cells(e.ColumnIndex)
            sender.BeginEdit(True)
        End If
    End Sub
#End Region
#End Region

#Region "<<<<<<<<<<<<<Вкладка Статистика выдачи задания>>>>>>>>>>>>>>>>>"
    ' Активация вкладки
    Private Sub ActivateTasksHistory()
        EventChangedControl = False                 ' Отключаем обработку событий
        ' Постоянные события при выборе вкладки
        ContextualTabGroupsVisible(Me.RibConTab_TasksHistory, Me.RibTab_SessionId)
        Me.lb_CurrentAddress.Visibility = False         ' Скрываем имя изполнителя в нижнем баре
        ' События при первой активации вкладки
        If IsFirstActTasksHistory Then
            Designer_AdvTV_TaskHistory()
            IsFirstActTasksHistory = False
        End If
        EventChangedControl = True                  ' Включаем обработку событий
    End Sub
    ' Настройка списка сеансов печати
    Private Sub Designer_AdvTV_TaskHistory()
        If FormLoadComplied Then WaitFormShow(Me, 1)
        Me.AdvTV_TaskHistory.Visible = False
        EventChangedControl = False                 ' Отключаем обработку событий
        ' Выгружаем данные из базы за заданный период
        SelectQueryData(
                        "OioPrintSessions." & Me.Name, _
 _
                        "SELECT * FROM vPr_OioPrintSessions " & _
                        "WHERE DtSession BETWEEN CAST('" & DtSessionBegin & "' AS Date) AND CAST('" & DtSessionEnd & "' AS Date)" & _
                        "ORDER BY SessionId DESC",
 _
                        "TabControl_Case1"
                        )
        ' Пока процесс выполняется....
        Do Until CompliteLoad
            ' Ждем и ничего не делаем
            My.Application.DoEvents()
        Loop
        If IsFirstActTasksHistory Then
            ' Настраиваем привязку
            Dim BindSourse As New BindingSource         ' Новая привязка данных
            BindSourse.DataSource = iDataSet
            BindSourse.DataMember = "OioPrintSessions." & Me.Name
            ' Связываем с AdvTV_TaskHistory
            Me.AdvTV_TaskHistory.DataSource = BindSourse
            ' Столбец группировки
            Me.AdvTV_TaskHistory.GroupingMembers = "GroupName, TaskSheet"
            ' Отображаемые столбцы
            Me.AdvTV_TaskHistory.DisplayMembers = "TimePrint, UserName, HostName, PrinterName, Copies, fltr_ControllerName, PerformersName"
        End If

        Me.AdvTV_TaskHistory.CollapseAll() ' Сворачиваем все ноды
        ' Настраиваем столбцы
        For i = 0 To Me.AdvTV_TaskHistory.Columns.Count - 1
            ' Синхронизируем имена столбцов с именами в базе 
            ' для последующего переименования
            Me.AdvTV_TaskHistory.Columns(i).Name = Me.AdvTV_TaskHistory.Columns(i).DataFieldName
        Next
        ' Переименовываем заголовки списка
        Me.AdvTV_TaskHistory.Columns("TimePrint").Text = "Время"
        Me.AdvTV_TaskHistory.Columns("UserName").Text = "Доменное имя"
        Me.AdvTV_TaskHistory.Columns("HostName").Text = "Имя станции"
        Me.AdvTV_TaskHistory.Columns("PrinterName").Text = "Принтер"
        Me.AdvTV_TaskHistory.Columns("Copies").Text = "Копий"
        Me.AdvTV_TaskHistory.Columns("fltr_ControllerName").Text = "Участок"
        Me.AdvTV_TaskHistory.Columns("PerformersName").Text = "Исполнитель задания"
        ' Обработка столбцов
        For i = 0 To Me.AdvTV_TaskHistory.Columns.Count - 1
            Me.AdvTV_TaskHistory.Columns(i).SortingEnabled = False              ' Отключаем сортировку данных
            Me.AdvTV_TaskHistory.Columns(i).Width.AutoSizeMinHeader = True      ' Авторазмер заголовков
            Me.AdvTV_TaskHistory.Columns(i).Width.AutoSize = True               ' Авторазмер столбцов
        Next
        ' Настраиваем ноды        
        For Each n0 As DevComponents.AdvTree.Node In Me.AdvTV_TaskHistory.Nodes
            With n0
                .FullRowBackground = True
                .Selectable = True
                .Style = Me.ElementStyle4
                .Style.Font = _
                    New System.Drawing.Font("Microsoft Sans Serif", 9.0!, FontStyle.Bold)
            End With

            For Each n1 As DevComponents.AdvTree.Node In n0.Nodes
                With n1
                    ' Если лист задания назначен, чекбокс не отображаем
                    If n1.Text = "<<Лист - задание НЕ НАЗНАЧЕН>>" Then
                        .CheckBoxVisible = True
                    Else
                        .CheckBoxVisible = False
                    End If
                    .FullRowBackground = True
                    .Selectable = True
                    .Style = Me.ElementStyle8
                End With

                For Each n2 As DevComponents.AdvTree.Node In n1.Nodes
                    With n2
                        ' Если лист задания назначен, чекбокс не отображаем
                        If iDataSet.Tables("OioPrintSessions." & Me.Name).Rows(n2.BindingIndex).Item("TaskSheetId").ToString = "" Then
                            .CheckBoxVisible = True
                        Else
                            .CheckBoxVisible = False
                        End If
                        .FullRowBackground = True
                        .Selectable = True
                    End With
                Next
            Next
        Next
        ' Если что то есть, то разворачиваем первый нод
        If iDataSet.Tables("OioPrintSessions." & Me.Name).Rows.Count <> 0 Then
            Me.AdvTV_TaskHistory.Nodes(0).Expand()
            ' и все уго дочерние узлы
            For i = 0 To Me.AdvTV_TaskHistory.Nodes(0).Nodes.Count - 1
                Me.AdvTV_TaskHistory.Nodes(0).Nodes(i).Expand()
            Next (i)
        End If
        Me.AdvTV_TaskHistory.Visible = True
        EventChangedControl = True                  ' Включаем обработку событий
        If FormLoadComplied Then WaitFormShow(Me, 0)
    End Sub
    ' Изменения статуса чек бокса головного нода на списке сеансов печати
    Private Sub IsChecked()
        Dim iCounter As Integer ' Счетчик чекнутых нодов
        ' Нод нулевого уровня
        If Me.AdvTV_TaskHistory.SelectedNode.Level = 0 Then
            If Me.AdvTV_TaskHistory.SelectedNode.Checked Then
                ' Цикл по всем дочерним чекбоксам
                For i = 0 To Me.AdvTV_TaskHistory.SelectedNode.Nodes.Count - 1
                    Me.AdvTV_TaskHistory.SelectedNode.Nodes(i).Checked = True
                    For j = 0 To Me.AdvTV_TaskHistory.SelectedNode.Nodes(i).Nodes.Count - 1
                        Me.AdvTV_TaskHistory.SelectedNode.Nodes(i).Nodes(j).Checked = True
                    Next j
                Next i
            Else
                ' Цикл по всем дочерним чекбоксам
                For i = 0 To Me.AdvTV_TaskHistory.SelectedNode.Nodes.Count - 1
                    Me.AdvTV_TaskHistory.SelectedNode.Nodes(i).Checked = False
                    For j = 0 To Me.AdvTV_TaskHistory.SelectedNode.Nodes(i).Nodes.Count - 1
                        Me.AdvTV_TaskHistory.SelectedNode.Nodes(i).Nodes(j).Checked = False
                    Next j
                Next
            End If
        End If

        ' Нод первого уровня
        If Me.AdvTV_TaskHistory.SelectedNode.Level = 1 Then
            If Me.AdvTV_TaskHistory.SelectedNode.Checked Then
                ' Цикл по всем дочерним чекбоксам
                For i = 0 To Me.AdvTV_TaskHistory.SelectedNode.Nodes.Count - 1
                    Me.AdvTV_TaskHistory.SelectedNode.Nodes(i).Checked = True
                Next i
            Else
                ' Цикл по всем дочерним чекбоксам
                For i = 0 To Me.AdvTV_TaskHistory.SelectedNode.Nodes.Count - 1
                    Me.AdvTV_TaskHistory.SelectedNode.Nodes(i).Checked = False
                Next
            End If
        End If

        ' Нод второго уровня
        If Me.AdvTV_TaskHistory.SelectedNode.Level = 2 Then
            ' если у родителя только один нод
            If Me.AdvTV_TaskHistory.SelectedNode.Parent.Nodes.Count = 1 Then
                ' Выделяем или снимаем выделение у родителя
                If Me.AdvTV_TaskHistory.SelectedNode.Checked Then
                    Me.AdvTV_TaskHistory.SelectedNode.Parent.Checked = True
                Else
                    Me.AdvTV_TaskHistory.SelectedNode.Parent.Checked = False
                End If
            End If
            ' если выделены все дочерние ноды, родителя тоже выделяем
            ' считаем чекнутые ноды
            For Each n As DevComponents.AdvTree.Node In Me.AdvTV_TaskHistory.SelectedNode.Parent.Nodes
                If n.Checked Then iCounter += 1
            Next
            ' если чекнутых столько сколько и всего нодов
            If Me.AdvTV_TaskHistory.SelectedNode.Parent.Nodes.Count = iCounter Then
                ' выделяем родителя
                Me.AdvTV_TaskHistory.SelectedNode.Parent.Checked = True
            Else ' снимаем выделение
                Me.AdvTV_TaskHistory.SelectedNode.Parent.Checked = False
            End If
        End If
    End Sub
    ' Манипуляции с кнопкой формирования листа задания
    ' 1 - новый лист задания (формирование); 0 - уже привязанный лист задания (просмотр)
    Private Sub _IsNewTaskSheetId(ByVal Param As Integer)
        Select Case Param
            Case 1 ' формирование
                IsNewTaskSheetId = True
                Me.RB_btnFormingTaskList.Caption = "Формирование листа задания"
                Me.RB_btnFormingTaskList.Glyph = My.Resources.Task_32x32
            Case (0) ' просмотр
                IsNewTaskSheetId = False
                Me.RB_btnFormingTaskList.Caption = "Просмотр листа задания"
                Me.RB_btnFormingTaskList.Glyph = My.Resources.TaskView_32x32
        End Select

    End Sub

    ' Определение того что чекнуто и отображение/скрытие кнопок
    Private Sub AdvTV_TaskHistory_AfterCheck(ByVal sender As Object, ByVal e As DevComponents.AdvTree.AdvTreeCellEventArgs) Handles AdvTV_TaskHistory.AfterCheck
        Dim iCounterAll As Integer = 0      ' Счетчик чекнутых нодов по всей сетке
        Dim iCounter As Integer = 0         ' Счетчик чекнутых нодов в текущей группе
        Dim iDateTS As String = ""
        Dim iAuthorId As Integer = 0
        If EventChangedControl Then
            IsChecked()
            For Each n As DevComponents.AdvTree.Node In Me.AdvTV_TaskHistory.CheckedNodes
                Dim iRow As DataRow = iDataSet.Tables("OioPrintSessions." & Me.Name).Rows(n.BindingIndex)
                ' Первый цикл
                If iCounterAll = 0 Then
                    iDateTS = iRow.Item("DtSession").ToString()
                    iAuthorId = iRow.Item("AuthorId").ToString()
                End If
                ' Если разные даты и разные авторы печати
                If iDateTS <> iRow.Item("DtSession").ToString() Or
                    iAuthorId <> iRow.Item("AuthorId").ToString() Then
                    ' отменяем чек
                    Me.AdvTV_TaskHistory.SelectedNode.Checked = False
                    Me.RB_btnFormingTaskList.Enabled = False
                End If
                iCounterAll += 1
            Next

            Select Case Me.AdvTV_TaskHistory.SelectedNode.Level
                Case 1
                    ' Считаем количество чеков в выбранной группе
                    For Each n As DevComponents.AdvTree.Node In Me.AdvTV_TaskHistory.SelectedNode.Nodes
                        If n.Checked Then iCounter += 1
                    Next
                Case 2
                    ' Считаем количество чеков у родителя выбранного нода
                    For Each n As DevComponents.AdvTree.Node In Me.AdvTV_TaskHistory.SelectedNode.Parent.Nodes
                        If n.Checked Then iCounter += 1
                    Next
            End Select
            ' если если есть в группе чекнутые ноды
            If iCounterAll <> 0 And iCounter <> 0 Then
                _IsNewTaskSheetId(1)
                Me.RB_btnFormingTaskList.Enabled = True
            Else
                _IsNewTaskSheetId(0)
                Me.RB_btnFormingTaskList.Enabled = False
            End If
        End If
    End Sub
    ' Заполнение примененных фильтров при выборе нода 2го уровня (сеанса печати)
    Private Sub AdvTV_TaskHistory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdvTV_TaskHistory.SelectedIndexChanged
        Dim iCounter As Integer = 0 ' Счетчик чеков
        If EventChangedControl Then
            Select Case Me.AdvTV_TaskHistory.SelectedNode.Level
                Case 0 ' Выбрана группа Автора печати за дату
                    Me.RB_btnDeleteSession.Enabled = False
                    Me.RB_btnViewSession.Enabled = False
                    Me.RB_btnFormingTaskList.Enabled = False
                    _IsNewTaskSheetId(0)
                    ClearViewFiltersSession()

                Case 1 ' Выбран лист выдачи задания
                    ' проверка выбран пустой лист задания или нет
                    For Each n As DevComponents.AdvTree.Node In Me.AdvTV_TaskHistory.SelectedNode.Nodes
                        Dim iRow As DataRow = iDataSet.Tables("OioPrintSessions." & Me.Name).Rows(n.BindingIndex)
                        ' если у сеанса печати нет листов заданий
                        If iRow.Item("TaskSheetId").ToString() = "" Then
                            _IsNewTaskSheetId(1)
                        Else
                            ' значит лист задания уже назначен
                            _IsNewTaskSheetId(0)
                        End If
                        ' Считаем чеки
                        If n.Checked Then
                            iCounter += 1
                        End If
                    Next
                    ' если это не новый лист задания
                    If IsNewTaskSheetId = False Then
                        Me.RB_btnFormingTaskList.Enabled = True
                    End If
                    ' если новый лист задания и чеков 0
                    If IsNewTaskSheetId And iCounter = 0 Then
                        ' отключаем формирование
                        Me.RB_btnFormingTaskList.Enabled = False
                    Else
                        ' включаем формирование
                        Me.RB_btnFormingTaskList.Enabled = True
                    End If

                    Me.RB_btnDeleteSession.Enabled = False
                    Me.RB_btnViewSession.Enabled = False
                    ClearViewFiltersSession()

                Case 2 ' Выбран непосредственно сеанс печати
                    Dim iRow As DataRow = iDataSet.Tables("OioPrintSessions." & Me.Name).Rows(Me.AdvTV_TaskHistory.SelectedIndex)
                    Me.lb_fltr_ControllerName.Text = iRow.Item("fltr_ControllerName").ToString()
                    Me.lb_fltr_Gko.Text = iRow.Item("fltr_Gko").ToString()
                    Me.lb_fltr_RouterName.Text = iRow.Item("fltr_RouterName").ToString()
                    Me.lb_fltr_Geo.Text = iRow.Item("fltr_Geo").ToString()
                    Me.lb_fltr_Balance.Text = iRow.Item("fltr_Balance").ToString()
                    Me.lb_fltr_CountMonth.Text = iRow.Item("fltr_CountMonth").ToString()
                    Me.lb_fltr_prHouseType.Text = iRow.Item("fltr_prHouseType").ToString()
                    Me.lb_fltr_DocTypeNotice.Text = iRow.Item("fltr_DocTypeNotice").ToString()

                    Me.RB_btnDeleteSession.Enabled = True
                    Me.RB_btnViewSession.Enabled = True

                    ' если не назначен лист задания
                    If iRow.Item("TaskSheetId").ToString = "" Then
                        ' значить формируем новый
                        _IsNewTaskSheetId(1)
                    Else
                        ' значить формируем уже назначенный
                        _IsNewTaskSheetId(0)
                    End If
                    ' Считаем чеки у родителя выбранной группы
                    For Each n As DevComponents.AdvTree.Node In Me.AdvTV_TaskHistory.SelectedNode.Parent.Nodes
                        If n.Checked Then
                            iCounter += 1
                        End If
                    Next
                    ' Если что то чекнуто, можем формировать
                    If iCounter <> 0 Then
                        Me.RB_btnFormingTaskList.Enabled = True
                    Else
                        Me.RB_btnFormingTaskList.Enabled = False
                    End If
            End Select
            ' Фиксируем выделенную строку
            SessionsSelectedIndex = Me.AdvTV_TaskHistory.SelectedNode.BindingIndex
        End If
    End Sub
    ' Очищаем поля используемых фильтров, если выбран НЕ сеанс печати
    Sub ClearViewFiltersSession()
        Me.lb_fltr_ControllerName.Text = Nothing
        Me.lb_fltr_Gko.Text = Nothing
        Me.lb_fltr_RouterName.Text = Nothing
        Me.lb_fltr_Geo.Text = Nothing
        Me.lb_fltr_Balance.Text = Nothing
        Me.lb_fltr_CountMonth.Text = Nothing
        Me.lb_fltr_prHouseType.Text = Nothing
        Me.lb_fltr_DocTypeNotice.Text = Nothing
    End Sub
#End Region

#Region "<<<<<<<<<<<<<Вкладка Карта ДЗ>>>>>>>>>>>>>>>>>"
    ' Активация вкладки Карта ДЗ
    Private Sub ActivateDebitMap()
        If FormLoadComplied Then WaitFormShow(Me, 1)
        ' Если первая активация вкладки
        ContextualTabGroupsVisible(RibConTab_DebetMap, RibTab_DebetMap)
        If IsFirstActDebetMap Then
            ' Выбираем перечень событий которые есть в базе
            SelectQueryData("Pr_OioDebetEvents", "EXEC Pr_OioDebetMap @Function = 1", "Pr_OioDebetMap.Function=1")
            Me.cmbDebMap_Events.Properties.DataSource = iDataSet.Tables("Pr_OioDebetEvents")
            Me.cmbDebMap_Events.Properties.DisplayMember = "EventName"
            Me.cmbDebMap_Events.Properties.ValueMember = "EventTypeId"
            ' Ставим чек на всех меропиятиях
            For i = 0 To Me.cmbDebMap_Events.Properties.GetItems.Count - 1
                Me.cmbDebMap_Events.Properties.Items(i).CheckState = CheckState.Checked
            Next
            ' Выгружаем карту ДЗ
            SelectQueryData(
                            "Pr_OioDebetMap", _
                            "EXEC Pr_OioDebetMap " & _
                            "@fltrEventsList = '" & DebetMapEvents & "', " & _
                            "@BalanceMin = " & Me.spDebMap_BalanceMin.Text & ", " & _
                            "@BalanceMax = " & Me.spDebMap_BalanceMax.Text & ", @Function = 2",
                            "Pr_OioDebetMap.Function=1"
                            )
            Me.gcDebMapGrid.DataSource = iDataSet.Tables("Pr_OioDebetMap")
            ' Привязываем столбцы к бэндам
            Me.gbGroupName.Columns.Add(Me.gvDebMapGrid.Columns("GroupName"))
            Me.gbSubGroupName.Columns.Add(Me.gvDebMapGrid.Columns("SubGroupName"))
            Me.gb2.Columns.Add(Me.gvDebMapGrid.Columns("Group2_sum"))
            Me.gb2.Columns.Add(Me.gvDebMapGrid.Columns("Group2_count"))
            Me.gb3.Columns.Add(Me.gvDebMapGrid.Columns("Group3_sum"))
            Me.gb3.Columns.Add(Me.gvDebMapGrid.Columns("Group3_count"))
            Me.gb4.Columns.Add(Me.gvDebMapGrid.Columns("Group4_sum"))
            Me.gb4.Columns.Add(Me.gvDebMapGrid.Columns("Group4_count"))
            Me.gb5.Columns.Add(Me.gvDebMapGrid.Columns("Group5_sum"))
            Me.gb5.Columns.Add(Me.gvDebMapGrid.Columns("Group5_count"))
            Me.gb6.Columns.Add(Me.gvDebMapGrid.Columns("Group6_sum"))
            Me.gb6.Columns.Add(Me.gvDebMapGrid.Columns("Group6_count"))
            Me.gb7.Columns.Add(Me.gvDebMapGrid.Columns("Group7_sum"))
            Me.gb7.Columns.Add(Me.gvDebMapGrid.Columns("Group7_count"))
            Me.gb8.Columns.Add(Me.gvDebMapGrid.Columns("Group8_sum"))
            Me.gb8.Columns.Add(Me.gvDebMapGrid.Columns("Group8_count"))
            Me.gb9.Columns.Add(Me.gvDebMapGrid.Columns("Group9_sum"))
            Me.gb9.Columns.Add(Me.gvDebMapGrid.Columns("Group9_count"))
            Me.gb0.Columns.Add(Me.gvDebMapGrid.Columns("Group0_sum"))
            Me.gb0.Columns.Add(Me.gvDebMapGrid.Columns("Group0_count"))
            ' Устанавливаем форматы данных в столбцах c деньгами
            For i = 3 To Me.gvDebMapGrid.Columns.Count - 1 Step 2
                Me.gvDebMapGrid.Columns(i).DisplayFormat.FormatType = FormatType.Numeric
                Me.gvDebMapGrid.Columns(i).DisplayFormat.FormatString = "# ##0.00 р."
                Me.gvDebMapGrid.Columns(i).Caption = "Сумма, руб."
            Next
            ' Устанавливаем форматы данных в столбцах cо штуками
            For i = 4 To Me.gvDebMapGrid.Columns.Count - 1 Step 2
                Me.gvDebMapGrid.Columns(i).DisplayFormat.FormatType = FormatType.Numeric
                Me.gvDebMapGrid.Columns(i).DisplayFormat.FormatString = "# ##0"
                Me.gvDebMapGrid.Columns(i).Caption = "Кол - во, шт."
            Next
            ' Жирный шрифт для итоговых данных
            Me.gvDebMapGrid.Columns("Group0_sum").AppearanceCell.FontStyleDelta = FontStyle.Bold
            Me.gvDebMapGrid.Columns("Group0_count").AppearanceCell.FontStyleDelta = FontStyle.Bold

            Me.gvDebMapGrid.Columns("RowId").Visible = False    ' Скрываем столбец с номером строки
            Me.gbGroupName.Visible = False                      ' Скрываем первый бенд 
            Me.gbSubGroupName.Fixed = FixedStyle.Left           ' Фиксируем следующий бенд 
            Me.gvDebMapGrid.BestFitColumns()                    ' Выравниваем ширину всех столбцов
            Me.gvDebMapGrid.Columns("GroupName").Group()        ' Групируем по субгруппе

            ' Присваиваем имена группам в зависимости от типа базы
            If pref_CityOrVillages = 1 Then
                Me.gvDebMapGrid.Columns("GroupName").Caption = "Контролер"
                Me.gvDebMapGrid.Columns("SubGroupName").Caption = "Номер маршрута"
            End If
            If pref_CityOrVillages = 2 Then
                Me.gvDebMapGrid.Columns("GroupName").Caption = "Административный район"
                Me.gvDebMapGrid.Columns("SubGroupName").Caption = "Населенный пункт"
            End If
            IsFirstActDebetMap = False ' Первая активация состоялась
        End If
        If FormLoadComplied Then WaitFormShow(Me, 0)
    End Sub
    ' Выделение строк с итогами
    Private Sub tbl_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gvDebMapGrid.RowStyle
        Dim View As GridView = TryCast(sender, GridView)
        If e.RowHandle >= 0 Then
            If View.GetRowCellDisplayText(e.RowHandle, View.Columns("RowId")) = 999999 Then
                e.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, FontStyle.Bold)
            End If
        End If
    End Sub
    ' Свернуть/развернуть панель фильтров для карты ДЗ
    Private Sub pnFilterDebetMap_CustomButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.Docking2010.BaseButtonEventArgs) _
                                                                                                Handles pnFilterDebetMap.CustomButtonClick
        e.Button.Properties.Enabled = False ' Отключаем кнопку пока панель двигается
        If e.Button.Properties.Tag = 1 Then
            Me.pnFilterDebetMap.CustomHeaderButtons.Item(0).Properties.Image = Pripyat.My.Resources.next_16x16
            e.Button.Properties.Tag = 0
            For i = 1 To 128 Step 20
                sender.Size = New Size(sender.Width, 155 - i)
                Application.DoEvents()
            Next
        Else
            Me.pnFilterDebetMap.CustomHeaderButtons.Item(0).Properties.Image = Pripyat.My.Resources.previous_16x16
            e.Button.Properties.Tag = 1
            For i = 27 To 155 Step 20
                sender.Size = New Size(sender.Width, i)
                Application.DoEvents()
            Next
        End If
        e.Button.Properties.Enabled = True
    End Sub

#Region "Изменение фильтров для карты ДЗ"
    Private Sub spDebMapSpins_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles spDebMap_BalanceMin.Click,
                                                                                                        spDebMap_BalanceMax.Click
        ' Если первый вход в поле контрола
        If iEnter = False Then
            sender.SelectAll()      ' Выделяем весь текст
            iEnter = True           ' Вход состоялся
        End If
    End Sub
    Private Sub spDebMapSpins_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles spDebMap_BalanceMin.Leave,
                                                                                                        spDebMap_BalanceMax.Leave
        iEnter = False ' Выход из поля состоялся
    End Sub
    ' Изменение набора мероприятий
    Private Sub cmbDebMap_Events_CloseUp(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.CloseUpEventArgs) Handles cmbDebMap_Events.CloseUp
        Dim sTooltip As New SuperToolTip()          ' Новый SuperToolTip
        Dim args As New SuperToolTipSetupArgs()     ' Набор параметров для SuperToolTip
        args.Title.Text = "Выбранные мероприятия:" & Chr(10) & "_____________________"      ' Заголовок
        args.Title.Image = My.Resources.boemployee_32x32                                    ' Изображение заголовка
        args.Contents.Text = Replace(sender.text, ", ", Chr(10))                            ' Текст сообщения
        sTooltip.Setup(args)                                                                ' Привязываем набор параметров к SuperToolTip
        sender.SuperTip = sTooltip                                                          ' Привязываем SuperToolTip контролу
        If e.Value = "" Then
            DebetMapEvents = "NULL"
        Else
            DebetMapEvents = e.Value
        End If
    End Sub
#End Region

#Region "Умолчания для границ задолженности"
    ' Мин 0, макс 999 999
    Private Sub spDebMap_BalanceMin_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) _
                                                                                                            Handles spDebMap_BalanceMin.ButtonClick
        Dim b As EditorButton = e.Button
        If b.Index = 1 Then
            sender.Text = 0
        End If
    End Sub
    Private Sub spDebMap_BalanceMax_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) _
                                                                                                            Handles spDebMap_BalanceMax.ButtonClick
        Dim b As EditorButton = e.Button
        If b.Index = 1 Then
            sender.Text = 999999
        End If
    End Sub
#End Region
    ' Обновление карты ДЗ
    Private Sub btnUpdateDebetMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateDebetMap.Click
        If FormLoadComplied Then WaitFormShow(Me, 1)
        Me.tc_MainTabControl.SelectedTabPage.Hide()
        Application.DoEvents()
        If iDataSet.Tables.Contains("Pr_OioDebetMap") Then iDataSet.Tables("Pr_OioDebetMap").Clear()
        iDataAdapter.SelectCommand.CommandText = "EXEC Pr_OioDebetMap " & _
                                                "@fltrEventsList = '" & DebetMapEvents & "', " & _
                                                "@BalanceMin = " & Me.spDebMap_BalanceMin.Text & ", " & _
                                                "@BalanceMax = " & Me.spDebMap_BalanceMax.Text & ", @Function = 2"
        iDataAdapter.Fill(iDataSet, "Pr_OioDebetMap")
        Me.tc_MainTabControl.SelectedTabPage.Show()
        If FormLoadComplied Then WaitFormShow(Me, 0)
    End Sub
#End Region

#End Region

#Region "<<<<<<<<<<<<<RIBBON PANEl>>>>>>>>>>>>>>>>>"
#Region "<<<<<<<<<<<<<Вкладка Главная>>>>>>>>>>>>>>>>>"
#Region "<<<<<<<<<<<<<Группа Параметры АСКУР>>>>>>>>>>>>>>>>>"

#End Region
#Region "<<<<<<<<<<<<<Группа Маршрутизация участков >>>>>>>>>>>>>>>>>"
    ' Запуск формы настройки маршрутизации
    Private Sub RibBtn_Router_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RibBtn_Router.ItemClick
        'If pref_CityOrVillages = 1 Then
        'frRouter.ShowDialog()
        'Else
        'XtraMessageBox.Show("Маршрутизация участков доступна только в <b><u>ГОРОДСКОЙ</u></b> базе!", _
        'Application.ProductName, _
        'MessageBoxButtons.OK, _
        'MessageBoxIcon.Information, _
        'DevExpress.Utils.DefaultBoolean.True)
        'End If
        XtraMessageBox.Show("На данный момент эта форма не обслуживается!" & Chr(10) & "Обратитесь к разработчику комплекса ...", _
                                Application.ProductName, _
                                MessageBoxButtons.OK, _
                                MessageBoxIcon.Information, _
                                DevExpress.Utils.DefaultBoolean.True)
    End Sub
#End Region
#End Region

#Region "<<<<<<<<<<<<<Доп. Вкладка Параметры печати документов>>>>>>>>>>>>>>>>>"
#Region "<<<<<<<<<<<<<Вкладка Фильтры>>>>>>>>>>>>>>>>>"
    ' При изменении какого либо фильтра, запрещаем печать
    Private Sub RB_cmbPerformer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_cmbControllers.EditValueChanged,
                                                                                                                            RB_cmbGKO.EditValueChanged,
                                                                                                                            RB_cmbRoute.EditValueChanged,
                                                                                                                            RB_numDebetMin.EditValueChanged,
                                                                                                                            RB_numDebetMax.EditValueChanged,
                                                                                                                            RB_PeriodMin.EditValueChanged,
                                                                                                                            RB_PeriodMin.EditValueChanged,
                                                                                                                            RB_PeriodMax.EditValueChanged,
                                                                                                                            RB_PeriodMax.EditValueChanged,
                                                                                                                            RB_tglDelPrinted.CheckedChanged

        Me.btn_PrintDocs.Enabled = False
    End Sub
#Region "<<<<<<<<<<<<<Группа Дата документа и участок>>>>>>>>>>>>>>>>>"
    Private Sub LoadingPerformers()
        ' Заполняем список контролеров
        ' Первая запись пустая
        SelectQueryData("cmbInspectors." & Me.Name, "SELECT * FROM vPr_cmbInspectors")
        Me.RB_cmbControllersRepository.DataSource = iDataSet.Tables("cmbInspectors." & Me.Name)
        Me.RB_cmbControllersRepository.DisplayMember = "Inspector"
        Me.RB_cmbControllersRepository.ValueMember = "InspectorId"
        Me.RB_cmbControllersRepository.PopulateViewColumns()
        Me.RB_cmbControllersRepository.View.Columns("InspectorId").Visible = False
        Me.RB_cmbControllers.EditValue = "NULL"
    End Sub
    Private Sub LoadingGKO()
        ' Выгружаем перечень УК-шек
        SelectQueryData("GKO." & Me.Name, "SELECT * FROM vPr_cmbGKO")
        ' Заполняем список УК-шек
        Me.RB_cmbGKORepository.DataSource = iDataSet.Tables("GKO." & Me.Name)
        Me.RB_cmbGKORepository.DisplayMember = "GKOName"
    End Sub
#End Region

#Region "<<<<<<<<<<<<<Группа Адресные фильтры>>>>>>>>>>>>>>>>>"
    Private Sub LoadingRouters()
        ' Выгружаем перечень маршрутов
        SelectQueryData("Routers." & Me.Name, "SELECT * FROM vPr_cmbRouters ")
        Me.RB_cmbRouteRepository.DataSource = iDataSet.Tables("Routers." & Me.Name)
        Me.RB_cmbRouteRepository.DisplayMember = "Router"
        Me.RB_cmbRouteRepository.ValueMember = "RouterId"
        Me.RB_cmbRouteRepository.PopulateViewColumns()
        Me.RB_cmbRouteRepositoryView.Columns("RouterId").Visible = False
        Me.RB_cmbRoute.EditValue = "NULL"
    End Sub
    ' Выбор адреса для печати уведомлений
    Private Sub RB_btnAdress_Click(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles RB_btnAdress.ItemClick
        frAdressAreal.Vid = 1
        frAdressAreal.AddressFunction = 11
        If frAdressAreal.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.lb_CurrentAddress.Caption = AddressString
            Me.btn_PrintDocs.Enabled = False
        End If
        frAdressAreal.Dispose()
    End Sub
#End Region

#Region "<<<<<<<<<<<<<Группа Задолженность>>>>>>>>>>>>>>>>>"
    ' Заполнение готовых диапазонов периодов ДЗ
    Private Sub RB_menuPeriod_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles RB_menuPeriodAll.ItemClick,
                                                                                                                        RB_menuPeriod_1.ItemClick,
                                                                                                                        RB_menuPeriod_2.ItemClick,
                                                                                                                        RB_menuPeriod_3.ItemClick,
                                                                                                                        RB_menuPeriod_4.ItemClick,
                                                                                                                        RB_menuPeriod_5.ItemClick,
                                                                                                                        RB_menuPeriod_6.ItemClick,
                                                                                                                        RB_menuPeriod_7.ItemClick,
                                                                                                                        RB_menuPeriod_8.ItemClick,
                                                                                                                        RB_menuPeriod_9.ItemClick
        ' Границы периодов берем из базы
        Me.RB_PeriodMin.EditValue = ExecuteScalar("SELECT CountMin FROM vPr_cmdCounterPeriod WHERE GroupCount = " & e.Item.Tag)
        Me.RB_PeriodMax.EditValue = ExecuteScalar("SELECT CountMax FROM vPr_cmdCounterPeriod WHERE GroupCount = " & e.Item.Tag)

    End Sub
#End Region

#Region "<<<<<<<<<<<<<Тип жилья>>>>>>>>>>>>>>>>>"
    Private Sub RB_tglMKD_CheckedChanged(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles RB_tglMKD.CheckedChanged
        If sender.Checked Then Me.RB_tglChS.Checked = False
    End Sub
    Private Sub RB_tglChS_CheckedChanged(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles RB_tglChS.CheckedChanged
        If sender.Checked Then Me.RB_tglMKD.Checked = False
    End Sub
#End Region
#Region "<<<<<<<<<<<<<Типы документов>>>>>>>>>>>>>>>>>"
    ' Выбор типа уведомления на печать
    Private Sub RB_menuDocType_PressedButtonChanged(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles RB_menuDocTypeNotice.ItemClick,
        RB_menuDocTypeNoticeRestriction.ItemClick,
        RB_menuDocTypeNoticeUnhooking.ItemClick,
        RB_menuDocTypeRestriction.ItemClick,
        RB_menuDocTypeUnhooking.ItemClick,
        RB_menuDocTypeAllDocs.ItemClick,
        RB_menuDocTypeNotices.ItemClick,
        RB_menuDocTypeNoticesUnh.ItemClick,
        RB_menuDocTypeUnhookinges.ItemClick

        ' Если форма загружена и включены события контролов
        ' отключаем кнопку печати
        If EventChangedControl = True And FormLoadComplied Then
            Me.btn_PrintDocs.Enabled = False
            Me.RB_menuDocType.Caption = e.Item.Caption
            Me.RB_menuDocType.Tag = e.Item.Tag
            Me.RB_menuDocType.Description = e.Item.Name
        End If
    End Sub
#End Region
#End Region

#Region "<<<<<<<<<<<<<Вкладка Настройки>>>>>>>>>>>>>>>>>"

#End Region
#End Region

#Region "<<<<<<<<<<<<<Доп. Вкладка История выдачи задания>>>>>>>>>>>>>>>>>"
#Region "<<<<<<<<<<<<<Вкладка Сеансы печати>>>>>>>>>>>>>>>>>"
#Region "<<<<<<<<<<<<<Группа Фильтры>>>>>>>>>>>>>>>>>"
    ' Очищаем фильтры для сеансов печати

    Private Sub RB_btnClearFilters_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles RB_btnClearFilters.ItemClick
        EventChangedControl = False
        DtSessionBegin = "01.01.1900"               ' Минус сто лет
        DtSessionEnd = Now.ToShortDateString        ' Сегодня
        Designer_AdvTV_TaskHistory()
        ' Фильтр без ограничений
        Me.tb_fltrSessionClear.Checked = True
        EventChangedControl = True
    End Sub
    ' Выбор заготовок периодов для фильтрации сеансов печати
    Private Sub RB_menuPeriodSession_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles tb_fltrSessionLast7Days.ItemClick,
                                                                                                        tb_fltrSessionLast30Days.ItemClick,
                                                                                                        tb_fltrSessionLast90Days.ItemClick,
                                                                                                        tb_fltrSessionLast365Days.ItemClick,
                                                                                                        tb_fltrSessionCurWeek.ItemClick,
                                                                                                        tb_fltrSessionCurMonth.ItemClick,
                                                                                                        tb_fltrSessionCurQuarter.ItemClick,
                                                                                                        tb_fltrSessionCurYear.ItemClick,
                                                                                                        tb_fltrSessionClear.ItemClick
        EventChangedControl = False
        Me.RB_menuPeriodSession.Tag = e.Item.Name
        Select Case e.Item.Tag
            Case 0 ' За последние 7 дней
                DtSessionBegin = Now.AddDays(-7).ToShortDateString : DtSessionEnd = Now.ToShortDateString()
            Case 1 ' За последние 30 дней
                DtSessionBegin = Now.AddDays(-30).ToShortDateString : DtSessionEnd = Now.ToShortDateString()
            Case 2 ' За последние 90 дней
                DtSessionBegin = Now.AddDays(-90).ToShortDateString : DtSessionEnd = Now.ToShortDateString()
            Case 3 ' За последние 365 дней
                DtSessionBegin = Now.AddDays(-365).ToShortDateString : DtSessionEnd = Now.ToShortDateString()
            Case 4 ' За текущюю неделю
                DtSessionBegin = Now.AddDays(-Now.DayOfWeek + 1).ToShortDateString : DtSessionEnd = Now.ToShortDateString()
            Case 5 ' За текущий месяц
                DtSessionBegin = Now.AddDays(-Now.Day + 1).ToShortDateString : DtSessionEnd = Now.ToShortDateString()
            Case 6 ' За текущий квартал
                DtSessionBegin = DateSerial(Now.Year, DatePart(DateInterval.Quarter, Now) * 3 - 2, 1).ToShortDateString : DtSessionEnd = Now.ToShortDateString()
            Case 7 ' За текущий год
                DtSessionBegin = DateSerial(Now.Year, 1, 1).ToShortDateString : DtSessionEnd = Now.ToShortDateString()
            Case 8 ' Без ограничений
                RB_btnClearFilters_ItemClick(sender, e)
        End Select
        Designer_AdvTV_TaskHistory()
        EventChangedControl = True
    End Sub
#End Region

#Region "<<<<<<<<<<<<<Группа Обработка сеансов печати>>>>>>>>>>>>>>>>>"
    ' Сформировать лист задания
    Private Sub RB_btnFormingTaskList_Click(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles RB_btnFormingTaskList.ItemClick
        ' Координаты формы
        Dim _X As Integer = Cursor.Position.X + 20
        Dim _Y As Integer = Cursor.Position.Y + 20
        Dim SessionId As String = ""                    ' Накопитель перечня сеансов печати

        If IsNewTaskSheetId Then
            ' Проверка корректности выбранных строк
            For Each n As DevComponents.AdvTree.Node In Me.AdvTV_TaskHistory.CheckedNodes
                ' переменная для хранения чекнутой строки связанной iDataSet.Tables("OioPrintSessions." & Me.Name)
                Dim iRow As DataRow = iDataSet.Tables("OioPrintSessions." & Me.Name).Rows(n.BindingIndex)
                SessionId = SessionId & iRow.Item("SessionId").ToString() & " "
                ' Ид листа задания, если он уже есть
                TaskSheetId = iRow.Item("TaskSheetId").ToString()
            Next
            ' Запуск процедуры регистрации листа задания
            frOptionsTask.SessionId = Replace(Trim(SessionId), " ", ",")
            frOptionsTask._X = Cursor.Position.X + 20
            frOptionsTask._Y = Cursor.Position.Y + 20
            If frOptionsTask.ShowDialog = Windows.Forms.DialogResult.OK Then
                ReportTaskList()
                Designer_AdvTV_TaskHistory()
                Me.AdvTV_TaskHistory.SelectedIndex = SessionsSelectedIndex
            End If
        Else ' Формирование уже назначенного листа задания
            For Each n As DevComponents.AdvTree.Node In Me.AdvTV_TaskHistory.SelectedNode.Nodes
                ' переменная для хранения чекнутой строки связанной iDataSet.Tables("OioPrintSessions." & Me.Name)
                Dim iRow As DataRow = iDataSet.Tables("OioPrintSessions." & Me.Name).Rows(n.BindingIndex)
                ' Ид листа задания, если он уже есть
                TaskSheetId = iRow.Item("TaskSheetId").ToString()
                Exit For
            Next
            Select Case XtraMessageBox.Show(
                                        "Добавить в отчет перечень неотработанных мероприятий?", _
                                        Application.ProductName, _
                                        MessageBoxButtons.YesNoCancel, _
                                        MessageBoxIcon.Question, _
                                        MessageBoxDefaultButton.Button2
                                        )
                Case Windows.Forms.DialogResult.Yes
                    OnHands = TaskSheetId
                    ReportTaskList()
                Case Windows.Forms.DialogResult.No
                    OnHands = 0
                    ReportTaskList()
                Case Windows.Forms.DialogResult.Cancel
                    Exit Sub
            End Select
        End If
    End Sub
    ' Генерация отчета с листом задания
    Private Sub ReportTaskList()
        Dim FRx As New FastReport.Report                                           ' Новый экземпляр отчета
        ' Проверка зашит ли файл отчета в программу
        If File.Exists(SaveResToTemp(My.Resources.PetitionBlank)) Then
            Try
                FRx.Load(SaveResToTemp(My.Resources.TaskSheetBlank)) ' Загрузка отчета из ресурсов программы
                ' Заполнение параметров отчета данными из базы
                'FRx.ReportInfo.Name = "Заявление " & Me.txt_Adress.Text
                FRx.SetParameterValue("TaskSheetId", TaskSheetId)
                FRx.SetParameterValue("OnHands", OnHands)
                FRx.SetParameterValue("ConnectionString", pref_ConnectionString)
                FRx.Show()          ' Показать отчет
                FRx.Dispose()       ' Осводить ресурсы
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            ' Если отчета нет в ресурсах программы
            XtraMessageBox.Show("Не найден файл для генератора отчетов!", _
                             Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub
    ' Удаление выбраннного сеанса печати
    Private Sub RB_btnDeleteSession_Click(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles RB_btnDeleteSession.ItemClick
        Dim iRow As DataRow         ' Активная строка на сетке
        Dim iDocsCount As Integer   ' Кол-во документов в сеансе печати

        iRow = iDataSet.Tables("OioPrintSessions." & Me.Name).Rows(Me.AdvTV_TaskHistory.SelectedIndex)
        iDocsCount = ExecuteScalar("EXEC Pr_PrintSessions @SessionId = " & iRow.Item("SessionId") & ", @Function = 1, @Parameter = 2")

        Select Case XtraMessageBox.Show("Внимание! Сейчас будет удален сеанс печати который содержит " & Chr(10) & _
                                        "<u><b>" & Convert.ToDecimal(iDocsCount) & "</b></u> зарегистрированных документов!" & Chr(10) & _
                                        "В случае удаления, необходимо позаботиться о ликвидации распечатанных уведомлений!" & Chr(10) & _
                                        "Вы согласны?", _
                                        Application.ProductName, _
                                        MessageBoxButtons.YesNo, _
                                        MessageBoxIcon.Question, _
                                        MessageBoxDefaultButton.Button1, _
                                        DevExpress.Utils.DefaultBoolean.True)
            Case Windows.Forms.DialogResult.Yes
                Try
                    ExecuteScalar("EXEC Pr_PrintSessions @SessionId = " & iRow.Item("SessionId") & ", @Function = 4", "[Удаление сеанса печати]")
                    Designer_AdvTV_TaskHistory()
                    With New frInfo
                        .Mess = "Сеанс печати удален!"
                        .Show()     ' Всплываюшее сообщение
                    End With
                Catch
                End Try
        End Select
    End Sub
#End Region

#Region "<<<<<<<<<<<<<Группа Вид>>>>>>>>>>>>>>>>>"
    ' Свернуть все
    Private Sub RB_btnSessionsCollapse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_btnSessionsCollapse.ItemClick
        Me.AdvTV_TaskHistory.CollapseAll()
    End Sub
    ' Развернуть все
    Private Sub RB_btnSessionsExpanded_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_btnSessionsExpanded.ItemClick
        Me.AdvTV_TaskHistory.ExpandAll()
    End Sub
    ' Чекнуть  все строки
    Private Sub RB_btnSessionsChecked_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_btnSessionsChecked.ItemClick
        Me.Cursor = Cursors.WaitCursor : EventChangedControl = False
        For Each n0 As DevComponents.AdvTree.Node In Me.AdvTV_TaskHistory.Nodes
            n0.Checked = True
            For Each n1 As DevComponents.AdvTree.Node In n0.Nodes
                n1.Checked = True
                For Each n2 As DevComponents.AdvTree.Node In n1.Nodes
                    n2.Checked = True
                Next
            Next
        Next
        Me.Cursor = Cursors.Default : EventChangedControl = True
    End Sub
    ' Снять чек со всех строк
    Private Sub RB_btnSessionsUnChecked_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_btnSessionsUnChecked.ItemClick
        Me.Cursor = Cursors.WaitCursor : EventChangedControl = False
        For Each n0 As DevComponents.AdvTree.Node In Me.AdvTV_TaskHistory.Nodes
            n0.Checked = False
            For Each n1 As DevComponents.AdvTree.Node In n0.Nodes
                n1.Checked = False
                For Each n2 As DevComponents.AdvTree.Node In n1.Nodes
                    n2.Checked = False
                Next
            Next
        Next
        Me.Cursor = Cursors.Default : EventChangedControl = True
    End Sub
#End Region

#Region "<<<<<<<<<<<<<Обновить>>>>>>>>>>>>>>>>>"
    ' Обновление информации на вкладке
    Private Sub RB_btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_btnUpdate.ItemClick
        Designer_AdvTV_TaskHistory()
    End Sub
#End Region
#End Region
#End Region

#Region "<<<<<<<<<<<<<Доп. Вкладка Обзор задолженности>>>>>>>>>>>>>>>>>"
#Region "<<<<<<<<<<<<<Вкладка Карта ДЗ>>>>>>>>>>>>>>>>>"

#End Region
#End Region
#End Region
End Class
