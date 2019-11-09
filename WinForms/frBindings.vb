Imports DevExpress.XtraBars.Navigation
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports System.IO
Imports DevExpress.XtraGrid.Columns
Imports System.Threading
Imports DevExpress.LookAndFeel
Imports DevExpress.XtraSplashScreen

Public Class frBindings
    Dim PreferenceForms As String       ' Ветка в реестре для хранения настроек формы 
    Dim iSelectedNode As Integer        ' Индекс активного нода
    Dim iSelectedRowISU As Integer      ' Активная строка на гриде с ИСУшками
    Dim iSelectedRowCityP As Integer    ' Активная строка на гриде с частями города
    Dim iSelectedRowMailD As Integer    ' Активная строка на гриде с методами доставки ПРД
    Dim iSelectedRowTSO As Integer      ' Активная строка на гриде с ТСО

    ' переменные с параметрами дома для каждой вкладки
    Dim txtGKO_House_ As String
    Dim txtGKO_LetterHouse_ As String
    Dim txtGKO_Build_ As String
    Dim txtCityP_House_ As String
    Dim txtCityP_LetterHouse_ As String
    Dim txtCityP_Build_ As String
    Dim txtMailD_House_ As String
    Dim txtMailD_LetterHouse_ As String
    Dim txtMailD_Build_ As String
    Dim txtTSO_House_ As String
    Dim txtTSO_LetterHouse_ As String
    Dim txtTSO_Build_ As String

    ' мультистрока с накопленными Ид улиц для каждой вкладки
    Dim MultiAddressIdGKO As String = "NULL"
    Dim MultiAddressIdCityP As String = "NULL"
    Dim MultiAddressIdMailD As String = "NULL"
    Dim MultiAddressIdTSO As String = "NULL"

    Dim sep As String                   ' разделитель для мультистрок
    Dim CounterTypeId As String         ' мультистрока с Ид ПУ
    Dim CounterName As String           ' мультистрока с именами ПУ

    Dim potokBind As Boolean            ' поток занят привязкий л/с
    Sub New()
        SplashScreenManager.ShowForm(Me, GetType(frDefaultWaitForm), True, True, False)
        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()
        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
    End Sub
    Private Sub frBindings_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        RemoveTableDataSet(Me)
        frMain.Show()
        frMain.NotifyIcon.Visible = False
        frMain.Time.Enabled = True
    End Sub
    Private Sub frBindings_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ArealId = "NULL"
        CityVillageId = "NULL"
        StreetId = "NULL"
        PreferenceForms = pref_UserSettings & "\" & Me.Name & "\"

        If RegistryRead(PreferenceForms, "CollapsedPage", 1) = 1 Then
            Me.npMain.PageProperties.ShowMode = ItemShowMode.ImageAndText
            Me.btnCollapsedPage.ImageOptions.Image = My.Resources.hide_16x16
        Else
            Me.npMain.PageProperties.ShowMode = ItemShowMode.Image
            Me.btnCollapsedPage.ImageOptions.Image = My.Resources.show_16x16
        End If
        Me.npMain.ShowToolTips = RegistryRead(PreferenceForms, "CollapsedPage", 1)
        Me.npMain.SelectedPageIndex = RegistryRead(PreferenceForms, "npMain_SelectedPageIndex", 0)
        Me.npMain.Pages(Me.npMain.SelectedPageIndex).Focus()
        SplashScreenManager.CloseForm(False)
    End Sub
    Private Sub npMain_SelectedPageIndexChanged(sender As System.Object, e As System.EventArgs) Handles npMain.SelectedPageIndexChanged
        Dim IsFirstLoad As Boolean      ' переменная первой активации вкладки
        If PreferenceForms IsNot Nothing Then
            SplashScreenManager.ShowForm(Me, GetType(frDefaultWaitForm), True, True, True, True)
            RegistryWrite(PreferenceForms, "npMain_SelectedPageIndex", sender.SelectedPageIndex)
            Select Case sender.SelectedPageIndex
                Case 0
                    If Me.tlAddressAreal_GKO.DataSource Is Nothing Then _
                        LoadAddressTree(11, 1, Me.tlAddressAreal_GKO, TableName:="AddressGKO." & Me.Name) ' загрузка улиц
                    If Me.tlGKO.DataSource Is Nothing Then _
                        LoadGKOTree(Me.tlGKO, Me, True, iSelectedNode) ' загрузка ЖКХ
                Case 1
                    If Me.tlAddressAreal_MailD.DataSource Is Nothing Then _
                        LoadAddressTree(11, 1, Me.tlAddressAreal_MailD, TableName:="AddressMailD." & Me.Name) ' загрузка улиц

                    IsFirstLoad = InverterBoolean(iDataSet.Tables.Contains("MailDelivery." & Me.Name))
                    ' загрузка методов доставки
                    SelectQueryData("MailDelivery." & Me.Name, "SELECT * FROM vMailDeliverySource")
                    If IsFirstLoad Then
                        Me.gcMailDelivery.DataSource = iDataSet.Tables("MailDelivery." & Me.Name)
                        Me.gvMailDelivery.Columns("MailDeliverySourceId").Visible = False
                        Me.gvMailDelivery.Columns("Notes").Visible = False
                        Me.gvMailDelivery.Columns("Name").Caption = "Наименование метода доставки"
                    End If

                    Me.gvMailDelivery.SelectRow(iSelectedRowMailD)
                    Me.gvMailDelivery.FocusedRowHandle = iSelectedRowMailD

                Case 2
                    If Me.tlAddressAreal_CityP.DataSource Is Nothing Then _
                        LoadAddressTree(11, 1, Me.tlAddressAreal_CityP, TableName:="AddressCityP." & Me.Name) ' загрузка улиц

                    IsFirstLoad = InverterBoolean(iDataSet.Tables.Contains("CityParts." & Me.Name))
                    ' загрузка частей города
                    SelectQueryData("CityParts." & Me.Name, "EXEC Pr_BooksFlat @Function = 1, @SelectNumber = 14")
                    If IsFirstLoad Then
                        Me.gcCityParts.DataSource = iDataSet.Tables("CityParts." & Me.Name)
                        Me.gvCityParts.Columns("Id").Visible = False
                        Me.gvCityParts.Columns("Name").Caption = "Наименование части города"
                    End If

                    Me.gvCityParts.SelectRow(iSelectedRowCityP)
                    Me.gvCityParts.FocusedRowHandle = iSelectedRowCityP

                Case 3
                    If Me.tlAddressAreal_TSO.DataSource Is Nothing Then _
                       LoadAddressTree(11, 1, Me.tlAddressAreal_TSO, TableName:="AddressTSO." & Me.Name) ' загрузка улиц

                    IsFirstLoad = InverterBoolean(iDataSet.Tables.Contains("TSO." & Me.Name))
                    ' загрузка ТСО
                    SelectQueryData("TSO." & Me.Name, "SELECT * FROM vPr_TSO")
                    If IsFirstLoad Then
                        Me.gcTSO.DataSource = iDataSet.Tables("TSO." & Me.Name)
                        HidenAllColumns_Grid(Me.gvTSO, iDataSet.Tables("TSO." & Me.Name))
                        Me.gvTSO.Columns("TSOName").Visible = True
                        Me.gvTSO.Columns("TSOName").Caption = "Наименование ТСО"
                    End If

                    Me.gvTSO.SelectRow(iSelectedRowTSO)
                    Me.gvTSO.FocusedRowHandle = iSelectedRowTSO

                Case 4
                    ' выборка из справочника ИСУ
                    SelectQueryData(
                                    "ISUCounterList." & Me.Name,
                                    "EXEC Pr_BindingISO @Function = 1, @SelectNumber = 2",
                                    "Get ISUCounterList"
                                    )
                    Me.gcISUList.DataSource = iDataSet.Tables("ISUCounterList." & Me.Name)
                    Me.gvISUList.PopulateColumns()
                    Me.gvISUList.Columns("CounterTypeId").Visible = False
                    Me.gvISUList.Columns("Name").Width = 200
                    Me.gvISUList.Columns("Accuracy").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    Me.gvISUList.Columns("Accuracy").DisplayFormat.FormatString = "n0"
                    Me.gvISUList.Columns("Name").Caption = "Наименование прибора учета"
                    Me.gvISUList.Columns("Signs").Caption = "Значность"
                    Me.gvISUList.Columns("IntervalVerify").Caption = "МПИ"
                    Me.gvISUList.Columns("Amper").Caption = "Ток"
                    Me.gvISUList.Columns("Voltage").Caption = "Напряжение"
                    Me.gvISUList.Columns("Accuracy").Caption = "Точность"
                    Me.gvISUList.Columns("Author").Caption = "Добавил"
                    Me.gvISUList.BestFitColumns(True)
                    ' выборка из справочника Квазара
                    SelectQueryData(
                                    "CounterList." & Me.Name,
                                    "EXEC Pr_BindingISO @Function = 1, @SelectNumber = 1",
                                    "Get CounterList"
                                    )
                    Me.RepositoryLookUpEdit_ISU.DataSource = iDataSet.Tables("CounterList." & Me.Name)
                    ' Me.RepositoryLookUpEdit_ISU.PopulateViewColumns()
                    HidenAllColumns_Grid(Me.gvISUCountersFromMenu, iDataSet.Tables("CounterList." & Me.Name))
                    Me.gvISUCountersFromMenu.Columns("CounterName").Visible = True
                    Me.gvISUCountersFromMenu.Columns("CounterName").Caption = "Наименование прибора учета"
                    Me.gvISUCountersFromMenu.Columns("SignsGroupName").Visible = True
                    Me.gvISUCountersFromMenu.Columns("SignsGroupName").Group()
                    Me.gvISUCountersFromMenu.BestFitColumns(True)
                    ' выборка мест установки ПУ
                    SelectQueryData(
                                    "CounterPlace." & Me.Name,
                                    "SELECT * FROM vCounterPlace",
                                    "Get CounterPlace"
                                    )
                    Me.cmbCounterPlaceISU.Properties.DataSource = iDataSet.Tables("CounterPlace." & Me.Name)
                    Me.cmbCounterPlaceISU.Properties.DisplayMember = "Name"
                    Me.cmbCounterPlaceISU.Properties.ValueMember = "CounterPlaceId"
                    Me.cmbCounterPlaceISU.Properties.PopulateColumns()
                    Me.cmbCounterPlaceISU.Properties.Columns("CounterPlaceId").Visible = False
                    Me.cmbCounterPlaceISU.Properties.PopupFormMinSize = New Point(120, 20)
                    Me.cmbCounterPlaceISU.SelectedText = "Опора"
                    Me.cmbCounterPlaceISU.ItemIndex = 9

                    Me.gvISUList.ClearSelection()                           ' очищаем выделения на таблице
                    Me.gvISUList.FocusedRowHandle = iSelectedRowISU         ' фокус на строке
                    Me.gvISUList.SelectRow(iSelectedRowISU)                 ' выделение строки
                    iSelectedRowISU = Me.gvISUList.FocusedRowHandle         ' запонимаем выделенную строку
                    ' удаление потерь
                    Me.cheDeleteLossesISU.Checked = RegistryRead(PreferenceForms, "cheDeleteLossesISU", 0)
            End Select
        End If
        SplashScreenManager.CloseForm(False)
    End Sub
    ' Отмена сворачивания панели при повторном клике на вкладку
    Private Sub npMain_StateChanged(sender As System.Object, e As DevExpress.XtraBars.Navigation.StateChangedEventArgs) Handles npMain.StateChanged
        npMain.State = DevExpress.XtraBars.Navigation.NavigationPaneState.Default
    End Sub
    ' Свернуть / развернуть панель вкладок
    Private Sub btnCollapsedPage_Click(sender As System.Object, e As System.EventArgs) Handles btnCollapsedPage.ItemClick
        ' Разворачиваем
        If Me.npMain.PageProperties.ShowMode = ItemShowMode.Image Then
            Me.npMain.PageProperties.ShowMode = ItemShowMode.ImageAndText   ' только изображения
            Me.btnCollapsedPage.ImageOptions.Image = My.Resources.hide_16x16             ' смена изображения
            Me.npMain.ShowToolTips = DevExpress.Utils.DefaultBoolean.False  ' откл показ подсказок
        Else
            ' Сворачиваем
            Me.npMain.PageProperties.ShowMode = ItemShowMode.Image          ' текст и изображения
            Me.btnCollapsedPage.ImageOptions.Image = My.Resources.show_16x16             ' смена изображения
            Me.npMain.ShowToolTips = DevExpress.Utils.DefaultBoolean.True   ' вкл показ подсказок
        End If
        ' запись в настройки по свойству ....npMain.ShowToolTips
        RegistryWrite(PreferenceForms, "CollapsedPage", Convert.ToInt64(Me.npMain.ShowToolTips))
    End Sub
    ' выведение привязок в отдельный поток
    Private Sub RunBinding(ByVal BindName As String)
        Me.npMain.Enabled = False
        If XtraMessageBox.Show("Сейчас будет запущени процесс привязки к лицевым счетам!" & Chr(10) & _
                              "Вы согласны?", Application.ProductName,
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                              DevExpress.Utils.DefaultBoolean.True) = Windows.Forms.DialogResult.No Then
            Me.npMain.Enabled = True
            Exit Sub
        End If
        Me.potokBind = True ' поток занят
        Me.StatusBar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always

        ' делегаты для привязки в отдельном потоке
        Dim GKO As New Thread(AddressOf RunBindingGKO)
        Dim MailD As New Thread(AddressOf RunBindingMailD)
        Dim CityP As New Thread(AddressOf RunBindingCityP)
        Dim TSO As New Thread(AddressOf RunBindingTSO)
        Dim ISO As New Thread(AddressOf RunBindingISO)
        Select Case BindName
            Case "GKO"
                GKO.Start()
            Case "MailD"
                MailD.Start()
            Case "CityP"
                CityP.Start()
            Case "TSO"
                TSO.Start()
            Case "ISO"
                ISO.Start()
        End Select
        ' пока поток привязки занять ждем....
        Do While potokBind
            Application.DoEvents()
        Loop
        Me.npMain.Enabled = True
        Me.StatusBar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        'Me.TopMost = True
        'Me.TopMost = False
        'Me.Refresh()
    End Sub
#Region "Вкладка УПРАВЛЯЮЩИЕ ОРГАНИЗАЦИИ"
#Region "tlAddressAreal_GKO"
    ' событие после чека выбранного узла
    Private Sub tlAddressAreal_GKO_AfterCheckNode(sender As Object, e As DevExpress.XtraTreeList.NodeEventArgs) Handles tlAddressAreal_GKO.AfterCheckNode
        Me.Cursor = Cursors.WaitCursor
        sep = Nothing
        Me.lbGKO_ToWhatBind.Text = Nothing      ' очищаем перечень того что выбрали
        MultiAddressIdGKO = Nothing
        ' цикл по всем чекнутым нодам
        For Each chn As TreeListNode In sender.GetAllCheckedNodes
            ' если узел Улица 
            If chn.Item("AddressPartType") = "Street" Then
                ' накапливаем перечень выбранных улиц
                Me.lbGKO_ToWhatBind.Text = Me.lbGKO_ToWhatBind.Text & sep & chn.Item("AddressString")       ' имена
                MultiAddressIdGKO = MultiAddressIdGKO & Trim(sep) & chn.Item("StreetId")                    ' ИДшники
                sep = ", " ' изменяем сепоратор
            End If
        Next
        ' заключаем мультистроку в ковычки
        MultiAddressIdGKO = "'" & MultiAddressIdGKO & "'"
        ' если есть чекнутые узлы, записываем перечень улиц в подсказку заменив разделитель на NewLine
        If sender.GetAllCheckedNodes.Count <> 0 Then _
        Me.lbGKO_ToWhatBind.ToolTip = Replace(Microsoft.VisualBasic.Left(Me.lbGKO_ToWhatBind.Text, Me.lbGKO_ToWhatBind.Text.Length - 2), sep, Chr(10))
        ' если мульти строка длинной более 8000 знаков (максимум для VARCHAR в SQL)
        If MultiAddressIdGKO.Length >= 8000 Then
            XtraMessageBox.Show("Достигнуто максимальное количество знаков (8000) для передачи в базу данных!" & Chr(10) & _
                                "Возможна привязка не в полном объеме!",
                                Application.ProductName,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
        End If
        Me.Cursor = Cursors.Default
    End Sub
    ' событие после фокуса на узле
    Private Sub tlAddressAreal_GKO_AfterFocusNode(ByVal sender As Object, ByVal e As DevExpress.XtraTreeList.NodeEventArgs) Handles tlAddressAreal_GKO.AfterFocusNode
        Dim nD As TreeListNode = sender.FocusedNode ' активный узел
        If EventChangedControl And Me.cheGKOMultiStreet.Checked = False Then
            ' запись в переменные выбранной части адреса
            Areal = nD.Item("Areal")
            ArealId = Trim(nD.Item("ArealId"))
            CityVillage = nD.Item("CityVillage")
            CityVillageId = Trim(nD.Item("CityVillageId"))
            Street = nD.Item("Street")
            StreetId = Trim(nD.Item("StreetId"))
            AddressString = nD.Item("AddressString")
            ' заполнить параметры дома можно только если выбрана улица
            Me.pnGKOHouseParameters.Enabled = (nD.Item("AddressPartType") = "Street")
            ' заполняем параметры дома если можно
            If Me.pnGKOHouseParameters.Enabled Then
                If Me.txtGKO_House.Text <> "" Then txtGKO_House_ = " д." & Me.txtGKO_House.Text
                If Me.txtGKO_LetterHouse.Text <> "" Then txtGKO_LetterHouse_ = Me.txtGKO_LetterHouse.Text
                If Me.txtGKO_Build.Text <> "" Then txtGKO_Build_ = " корп." & Me.txtGKO_Build.Text
            End If
            ' показываем какой адрес выбрали если только не включен множественный выбор улиц
            If Me.cheGKOMultiStreet.Checked = False Then
                Me.lbGKO_ToWhatBind.Text = AddressString & txtGKO_House_ & txtGKO_LetterHouse_ & txtGKO_Build_
            End If
        End If
    End Sub
    ' по ентеру переход на поле №дома
    Private Sub tlAddressAreal_GKO_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tlAddressAreal_GKO.KeyUp
        If e.KeyData = Keys.Enter Then
            Me.txtGKO_House.Focus()
            Me.txtGKO_House.SelectAll()
        End If
    End Sub
#End Region

#Region "tlGKO"
    ' по ентеру переход на кнопку привязать
    Private Sub tlGKO_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tlGKO.KeyUp, cheGKONothing.KeyUp
        If e.KeyData = Keys.Enter Then
            Me.btBindingGKO.Focus()
        End If
    End Sub
    ' событие до фокуса на узле
    Private Sub tlGKO_BeforeFocusNode(sender As Object, e As DevExpress.XtraTreeList.BeforeFocusNodeEventArgs) Handles tlGKO.BeforeFocusNode
        ' если выбрана не обслуживающая
        If e.Node.Level <> 1 Then
            e.CanFocus = False ' отменяем фокус
        Else
            ' показываем в поле что выбрали
            Me.lbGKO_WhatBind.Text = e.Node.Item("Name")
        End If
    End Sub
#End Region
    ' загрузка отчета
    Private Sub npBindGKO_CustomButtonClick(sender As System.Object, e As DevExpress.XtraBars.Docking2010.ButtonEventArgs) Handles npBindGKO.CustomButtonClick
        PreparedReport(My.Resources.BindingDataView_GKO, Me)
    End Sub
    ' при входе в поля с параметрами дома выбараем весь тект
    Private Sub txtGKO_House_Enter(sender As System.Object, e As System.EventArgs) Handles txtGKO_LetterHouse.Enter, txtGKO_House.Enter, txtGKO_Build.Enter
        sender.SelectAll()
    End Sub
    ' событие при изменении любого из параметров дома
    Private Sub txtGKO_House_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtGKO_LetterHouse.TextChanged, txtGKO_House.TextChanged, txtGKO_Build.TextChanged
        'очищаем преременные с параметрами дома
        txtGKO_House_ = ""
        txtGKO_LetterHouse_ = ""
        txtGKO_Build_ = ""
        ' перезаписываем эти переменные из полей параметров
        If Me.txtGKO_House.Text <> "" Then txtGKO_House_ = " д." & Me.txtGKO_House.Text
        If Me.txtGKO_LetterHouse.Text <> "" Then txtGKO_LetterHouse_ = Me.txtGKO_LetterHouse.Text
        If Me.txtGKO_Build.Text <> "" Then txtGKO_Build_ = " корп." & Me.txtGKO_Build.Text
        ' если дом не указан то и буквы не может быть
        If txtGKO_House_ = "" Then Me.txtGKO_LetterHouse.Text = "" : txtGKO_LetterHouse_ = ""
        'показываем полный адрес
        Me.lbGKO_ToWhatBind.Text = AddressString & txtGKO_House_ & txtGKO_LetterHouse_ & txtGKO_Build_
    End Sub
    ' переход по ентору из поля "Корпус" на кнопку привязать 
    Private Sub txtGKO_Build_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtGKO_Build.KeyDown
        If e.KeyCode = Keys.Enter Then Me.btBindingGKO.Focus()
    End Sub
    ' очистка полей с параметрами улиц
    Private Sub btnGKOClearHouseParameters_Click(sender As System.Object, e As System.EventArgs) Handles btnGKOClearHouseParameters.Click
        Me.txtGKO_House.Text = Nothing
        Me.txtGKO_LetterHouse.Text = Nothing
        Me.txtGKO_Build.Text = Nothing
    End Sub
    ' Активация множественного выбора улиц
    Private Sub cheGKOMultiStreet_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cheGKOMultiStreet.CheckedChanged
        ' при включении...
        If sender.Checked Then
            Me.pnGKOHouseParameters.Enabled = False     ' отключаем группу с параметрами дома
            Me.lbGKO_ToWhatBind.Text = Nothing          ' очищаем поле с улицей
            Me.tlAddressAreal_GKO.UncheckAll()          ' снимаем чеки со всех узлов
        Else ' при отключении
            ' включаем группу с параметрами дома если только фокус на узле с улицами
            If Me.tlAddressAreal_GKO.FocusedNode.Item("AddressPartType") = "Street" Then Me.pnGKOHouseParameters.Enabled = True
            tlAddressAreal_GKO_AfterFocusNode(Me.tlAddressAreal_GKO, Nothing) ' вызов события фокуса на tlAddressAreal_GKO 
        End If
        MultiAddressIdGKO = "NULL"                                           ' очищаем переменную со строкой мультиулиц
        Me.tlAddressAreal_GKO.OptionsView.ShowCheckBoxes = sender.Checked   ' включаем чекбоксы
    End Sub
    ' Сыбытие при изменении видимости группы полей с параметрами дома
    Private Sub pnGKOHouseParameters_EnabledChanged(sender As System.Object, e As System.EventArgs) Handles pnGKOHouseParameters.EnabledChanged
        ' очищаем переменные если группа скрыта
        If sender.Enabled = False Then
            txtGKO_House_ = ""
            txtGKO_LetterHouse_ = ""
            txtGKO_Build_ = ""
        End If
    End Sub
    ' событие при изменении поле "что привязываем" и "к чему привязываем"
    Private Sub lbGKO_ToWhatBind_TextChanged(sender As System.Object, e As System.EventArgs) Handles lbGKO_ToWhatBind.TextChanged, lbGKO_WhatBind.TextChanged
        ' если поля пустые отключаем кнопку Привязать
        If Me.lbGKO_WhatBind.Text = "" Or Me.lbGKO_ToWhatBind.Text = "" Then
            Me.btBindingGKO.Enabled = False
        Else
            Me.btBindingGKO.Enabled = True
        End If
    End Sub
    ' Активация отсутствия ЖКХ
    Private Sub cheGKONothing_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cheGKONothing.CheckedChanged
        Me.tlGKO.Enabled = InverterBoolean(sender.Checked)
        If sender.Checked Then
            Me.lbGKO_WhatBind.Text = "Нет обслуживающей организации"
        Else
            ' если есть фокус и выбран узел 1-го уровня
            If tlGKO.FocusedNode IsNot Nothing And Me.tlGKO.FocusedNode.Level = 1 Then
                ' показываем что выбрано в листе ЖКХ
                Me.lbGKO_WhatBind.Text = Me.tlGKO.FocusedNode.GetDisplayText("GKName")
            Else
                Me.lbGKO_WhatBind.Text = Nothing
            End If
        End If
    End Sub
    ' Запуск привязки
    Private Sub btBindingGKO_Click(sender As System.Object, e As System.EventArgs) Handles btBindingGKO.Click
        RunBinding("GKO")
    End Sub
    ' Процесс привязки
    Private Sub RunBindingGKO()
        ' Чтоб отладка не возвращала ошибку из разных потоков
        Control.CheckForIllegalCrossThreadCalls = False
        Dim _lookAndFeel As New DefaultLookAndFeel ' Оформление для MSGBOX
        _lookAndFeel.EnableBonusSkins = True
        ' используем текущюю тему
        _lookAndFeel.LookAndFeel.SkinName = RegistryRead(pref_ComplexSettings, "SkinName", "Dark Side")
        Try ' Если выбрано отсутствуе ЖКХ
            If Me.cheGKONothing.Checked Then
                GKHid = "NULL"
            Else
                Dim GKHid As String = Me.tlGKO.FocusedNode("Id")    ' Ид ЖКХ
            End If
            Dim CountRow As Integer = ExecuteScalar(
                "EXEC Pr_BindingGKH " & _
                    "@ArealId = " & ArealId & ", " & _
                    "@VillageId = " & CityVillageId & ", " & _
                    "@StreetId = " & StreetId & ", " & _
                    "@GKHid = " & GKHid & ", " & _
                    "@MultiStreet = " & MultiAddressIdGKO & ", " & _
                    "@HouseParameters = " & ConvertToNull(Trim(Me.txtGKO_House.Text & Me.txtGKO_LetterHouse.Text & Me.txtGKO_Build.Text), True, 0)
                                                    )
            potokBind = False ' Поток не занят
            XtraMessageBox.Show(_lookAndFeel.LookAndFeel, Me,
                                "Обработано строк: <u><b>" & CountRow.ToString("N0") & "</u></b>", _
                                Application.ProductName, _
                                MessageBoxButtons.OK, _
                                MessageBoxIcon.Information, _
                                DevExpress.Utils.DefaultBoolean.True)
            Me.txtGKO_House.Select() ' активация поля <Дом>
            ' если ошибка
        Catch ex As Exception
            XtraMessageBox.Show(_lookAndFeel.LookAndFeel, Me, ex.Message & Chr(10) & _
                   "<b>Ошибка процесса привязки места установки ИСУ ПУ</b>",
                   Application.ProductName,
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error,
                   DevExpress.Utils.DefaultBoolean.True)
            Me.potokBind = False
        End Try
    End Sub
#End Region

#Region "Вкладка МЕТОД ДОСТАВКИ ПРД"
#Region "tlAddressAreal_MailD"
    ' событие после чека выбранного узла
    Private Sub tlAddressAreal_MailD_AfterCheckNode(sender As Object, e As DevExpress.XtraTreeList.NodeEventArgs) Handles tlAddressAreal_MailD.AfterCheckNode
        Me.Cursor = Cursors.WaitCursor
        sep = Nothing
        Me.lbMailD_ToWhatBind.Text = Nothing      ' очищаем перечень того что выбрали
        MultiAddressIdMailD = Nothing
        ' цикл по всем чекнутым нодам
        For Each chn As TreeListNode In sender.GetAllCheckedNodes
            ' если узел Улица 
            If chn.Item("AddressPartType") = "Street" Then
                ' накапливаем перечень выбранных улиц
                Me.lbMailD_ToWhatBind.Text = Me.lbMailD_ToWhatBind.Text & sep & chn.Item("AddressString")   ' имена
                MultiAddressIdMailD = MultiAddressIdMailD & Trim(sep) & chn.Item("StreetId")                  ' ИДшники
                sep = ", " ' изменяем сепоратор
            End If
        Next
        ' заключаем мультистроку в ковычки
        MultiAddressIdMailD = "'" & MultiAddressIdMailD & "'"
        ' если есть чекнутые узлы, записываем перечень улиц в подсказку заменив разделитель на NewLine
        If sender.GetAllCheckedNodes.Count <> 0 Then _
        Me.lbMailD_ToWhatBind.ToolTip = Replace(Microsoft.VisualBasic.Left(Me.lbMailD_ToWhatBind.Text, Me.lbMailD_ToWhatBind.Text.Length - 2), sep, Chr(10))
        ' если мульти строка длинной более 8000 знаков (максимум для VARCHAR в SQL)
        If MultiAddressIdMailD.Length >= 8000 Then
            XtraMessageBox.Show("Достигнуто максимальное количество знаков (8000) для передачи в базу данных!" & Chr(10) & _
                                "Возможна привязка не в полном объеме!",
                                Application.ProductName,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
        End If
        Me.Cursor = Cursors.Default
    End Sub
    ' событие после фокуса на узле
    Private Sub tlAddressAreal_MailD_AfterFocusNode(ByVal sender As Object, ByVal e As DevExpress.XtraTreeList.NodeEventArgs) Handles tlAddressAreal_MailD.AfterFocusNode
        Dim nD As TreeListNode = sender.FocusedNode ' активный узел
        If EventChangedControl And Me.cheMailDMultiStreet.Checked = False Then
            ' запись в переменные выбранной части адреса
            Areal = nD.Item("Areal")
            ArealId = Trim(nD.Item("ArealId"))
            CityVillage = nD.Item("CityVillage")
            CityVillageId = Trim(nD.Item("CityVillageId"))
            Street = nD.Item("Street")
            StreetId = Trim(nD.Item("StreetId"))
            AddressString = nD.Item("AddressString")
            ' заполнить параметры дома можно только если выбрана улица
            Me.pnMailDHouseParameters.Enabled = (nD.Item("AddressPartType") = "Street")
            ' заполняем параметры дома если можно
            If Me.pnGKOHouseParameters.Enabled Then
                If Me.txtMailD_House.Text <> "" Then txtMailD_House_ = " д." & Me.txtMailD_House.Text
                If Me.txtMailD_LetterHouse.Text <> "" Then txtMailD_LetterHouse_ = Me.txtMailD_LetterHouse.Text
                If Me.txtMailD_Build.Text <> "" Then txtMailD_Build_ = " корп." & Me.txtMailD_Build.Text
            End If
            ' показываем какой адрес выбрали если только не включен множественный выбор улиц
            If Me.cheMailDMultiStreet.Checked = False Then
                Me.lbMailD_ToWhatBind.Text = AddressString & txtMailD_House_ & txtMailD_LetterHouse_ & txtMailD_Build_
            End If
        End If
    End Sub
    ' по ентеру переход на поле №дома
    Private Sub tlAddressAreal_MailD_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tlAddressAreal_MailD.KeyUp
        If e.KeyData = Keys.Enter Then
            Me.txtCityP_House.Focus()
            Me.txtCityP_House.SelectAll()
        End If
    End Sub
#End Region

#Region "gvCityParts"
    ' событие клика по части улицы запись активной строки
    Private Sub gvMailDelivery_Click(sender As Object, e As System.EventArgs) Handles gvMailDelivery.Click
        iSelectedRowMailD = sender.FocusedRowHandle
    End Sub
    ' событие выбора части улицы
    Private Sub gvMailDelivery_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles gvMailDelivery.FocusedRowChanged
        Me.lbMailD_WhatBind.Text = sender.GetRowCellDisplayText(sender.FocusedRowHandle, "Name")
    End Sub
    ' по ентеру переход на кнопку привязать
    Private Sub gvMailDelivery_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles gvMailDelivery.KeyUp
        If e.KeyData = Keys.Enter Then
            Me.btBindingMailD.Focus()
        End If
    End Sub
#End Region
    ' загрузка отчета
    Private Sub npBindMailDelivery_CustomButtonClick(sender As System.Object, e As DevExpress.XtraBars.Docking2010.ButtonEventArgs) Handles npBindMailDelivery.CustomButtonClick
        PreparedReport(My.Resources.BindingDataView_MailDelivery, Me)
    End Sub
    ' при входе в поля с параметрами дома выбараем весь тект
    Private Sub txtMailD_House_Enter(sender As System.Object, e As System.EventArgs) Handles txtMailD_LetterHouse.Enter,
                                                                                            txtMailD_House.Enter,
                                                                                            txtMailD_Build.Enter
        sender.SelectAll()
    End Sub
    ' событие при изменении любого из параметров дома
    Private Sub txtMailD_House_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtMailD_LetterHouse.TextChanged,
                                                                                                    txtMailD_House.TextChanged,
                                                                                                    txtMailD_Build.TextChanged
        'очищаем преременные с параметрами дома
        txtMailD_House_ = ""
        txtMailD_LetterHouse_ = ""
        txtMailD_Build_ = ""
        ' перезаписываем эти переменные из полей параметров
        If Me.txtMailD_House.Text <> "" Then txtMailD_House_ = " д." & Me.txtMailD_House.Text
        If Me.txtMailD_LetterHouse.Text <> "" Then txtMailD_LetterHouse_ = Me.txtMailD_LetterHouse.Text
        If Me.txtMailD_Build.Text <> "" Then txtMailD_Build_ = " корп." & Me.txtMailD_Build.Text
        ' если дом не указан то и буквы не может быть
        If txtMailD_House_ = "" Then Me.txtMailD_LetterHouse.Text = "" : txtMailD_LetterHouse_ = ""
        'показываем полный адрес
        Me.lbMailD_ToWhatBind.Text = AddressString & txtMailD_House_ & txtMailD_LetterHouse_ & txtMailD_Build_
    End Sub
    ' переход по ентору из поля "Корпус" на кнопку привязать 
    Private Sub txtMailD_Build_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtMailD_Build.KeyDown
        If e.KeyCode = Keys.Enter Then Me.btBindingMailD.Focus()
    End Sub
    ' очистка полей с параметрами улиц
    Private Sub btnMailDClearHouseParameters_Click(sender As System.Object, e As System.EventArgs) Handles btnMailDClearHouseParameters.Click
        Me.txtMailD_House.Text = Nothing
        Me.txtMailD_LetterHouse.Text = Nothing
        Me.txtMailD_Build.Text = Nothing
    End Sub
    ' Активация множественного выбора улиц
    Private Sub cheMailDMultiStreet_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cheMailDMultiStreet.CheckedChanged
        ' при включении...
        If sender.Checked Then
            Me.pnMailDHouseParameters.Enabled = False     ' отключаем группу с параметрами дома
            Me.lbMailD_ToWhatBind.Text = Nothing          ' очищаем поле с улицей
            Me.tlAddressAreal_MailD.UncheckAll()          ' снимаем чеки со всех узлов
        Else ' при отключении
            ' включаем группу с параметрами дома если только фокус на узле с улицами
            If Me.tlAddressAreal_MailD.FocusedNode.Item("AddressPartType") = "Street" Then Me.pnMailDHouseParameters.Enabled = True
            tlAddressAreal_MailD_AfterFocusNode(Me.tlAddressAreal_MailD, Nothing) ' вызов события фокуса на tlAddressAreal_GKO 
        End If
        MultiAddressIdMailD = "NULL"                                           ' очищаем переменную со строкой мультиулиц
        Me.tlAddressAreal_MailD.OptionsView.ShowCheckBoxes = sender.Checked   ' включаем чекбоксы
    End Sub
    ' Сыбытие при изменении видимости группы полей с параметрами дома
    Private Sub pnMailDHouseParameters_EnabledChanged(sender As System.Object, e As System.EventArgs) Handles pnMailDHouseParameters.EnabledChanged
        ' очищаем переменные если группа скрыта
        If sender.Enabled = False Then
            txtGKO_House_ = ""
            txtGKO_LetterHouse_ = ""
            txtGKO_Build_ = ""
        End If
    End Sub
    ' событие при изменении поле "что привязываем" и "к чему привязываем"
    Private Sub lbMailD_ToWhatBind_TextChanged(sender As System.Object, e As System.EventArgs) Handles lbMailD_ToWhatBind.TextChanged, lbMailD_WhatBind.TextChanged
        ' если поля пустые отключаем кнопку Привязать
        If Me.lbMailD_WhatBind.Text = "" Or Me.lbMailD_ToWhatBind.Text = "" Then
            Me.btBindingMailD.Enabled = False
        Else
            Me.btBindingMailD.Enabled = True
        End If
    End Sub
    ' Запуск привязки
    Private Sub btBindingMailD_Click(sender As System.Object, e As System.EventArgs) Handles btBindingMailD.Click
        RunBinding("MailD")
    End Sub
    Private Sub RunBindingMailD()
        ' Чтоб отладка не возвращала ошибку из разных потоков
        Control.CheckForIllegalCrossThreadCalls = False
        Dim _lookAndFeel As New DefaultLookAndFeel ' Оформление для MSGBOX
        _lookAndFeel.EnableBonusSkins = True
        ' используем текущюю тему
        _lookAndFeel.LookAndFeel.SkinName = RegistryRead(pref_ComplexSettings, "SkinName", "Dark Side")
        Try
            Dim MailDeliveryId As String = Me.gvMailDelivery.GetFocusedRowCellDisplayText("MailDeliverySourceId")   ' Ид части города

            Dim CountRow As Integer = ExecuteScalar(
                "EXEC Pr_BindingMailDelivery " & _
                    "@ArealId = " & ArealId & ", " & _
                    "@VillageId = " & CityVillageId & ", " & _
                    "@StreetId = " & StreetId & ", " & _
                    "@MailDeliveryId = " & MailDeliveryId & ", " & _
                    "@MultiStreet = " & MultiAddressIdMailD & ", " & _
                    "@HouseParameters = " & ConvertToNull(Trim(Me.txtMailD_House.Text & Me.txtMailD_LetterHouse.Text & Me.txtMailD_Build.Text), True, 0)
                                                )
            potokBind = False ' Поток не занят
            XtraMessageBox.Show(_lookAndFeel.LookAndFeel, Me,
                                "Обработано строк: <u><b>" & CountRow.ToString("N0") & "</u></b>", _
                                Application.ProductName, _
                                MessageBoxButtons.OK, _
                                MessageBoxIcon.Information, _
                                DevExpress.Utils.DefaultBoolean.True)
            Me.txtMailD_House.Select() ' активация поля <Дом>
            ' если ошибка
        Catch ex As Exception
            XtraMessageBox.Show(_lookAndFeel.LookAndFeel, Me, ex.Message & Chr(10) & _
                   "<b>Ошибка процесса привязки места установки ИСУ ПУ</b>",
                   Application.ProductName,
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error,
                   DevExpress.Utils.DefaultBoolean.True)
            Me.potokBind = False
        End Try
    End Sub
#End Region

#Region "Вкладка ЧАСТИ ГОРОДА"
#Region "tlAddressAreal_CityP"
    ' событие после чека выбранного узла
    Private Sub tlAddressAreal_CityP_AfterCheckNode(sender As Object, e As DevExpress.XtraTreeList.NodeEventArgs) Handles tlAddressAreal_CityP.AfterCheckNode
        Me.Cursor = Cursors.WaitCursor
        sep = Nothing
        Me.lbCityP_ToWhatBind.Text = Nothing      ' очищаем перечень того что выбрали
        MultiAddressIdCityP = Nothing
        ' цикл по всем чекнутым нодам
        For Each chn As TreeListNode In sender.GetAllCheckedNodes
            ' если узел Улица 
            If chn.Item("AddressPartType") = "Street" Then
                ' накапливаем перечень выбранных улиц
                Me.lbCityP_ToWhatBind.Text = Me.lbCityP_ToWhatBind.Text & sep & chn.Item("AddressString")   ' имена
                MultiAddressIdCityP = MultiAddressIdCityP & Trim(sep) & chn.Item("StreetId")                  ' ИДшники
                sep = ", " ' изменяем сепоратор
            End If
        Next
        ' заключаем мультистроку в ковычки
        MultiAddressIdCityP = "'" & MultiAddressIdCityP & "'"
        ' если есть чекнутые узлы, записываем перечень улиц в подсказку заменив разделитель на NewLine
        If sender.GetAllCheckedNodes.Count <> 0 Then _
        Me.lbCityP_ToWhatBind.ToolTip = Replace(Microsoft.VisualBasic.Left(Me.lbCityP_ToWhatBind.Text, Me.lbCityP_ToWhatBind.Text.Length - 2), sep, Chr(10))
        ' если мульти строка длинной более 8000 знаков (максимум для VARCHAR в SQL)
        If MultiAddressIdCityP.Length >= 8000 Then
            XtraMessageBox.Show("Достигнуто максимальное количество знаков (8000) для передачи в базу данных!" & Chr(10) & _
                                "Возможна привязка не в полном объеме!",
                                Application.ProductName,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
        End If
        Me.Cursor = Cursors.Default
    End Sub
    ' событие после фокуса на узле
    Private Sub tlAddressAreal_CityP_AfterFocusNode(ByVal sender As Object, ByVal e As DevExpress.XtraTreeList.NodeEventArgs) Handles tlAddressAreal_CityP.AfterFocusNode
        Dim nD As TreeListNode = sender.FocusedNode ' активный узел
        If EventChangedControl And Me.cheCityPMultiStreet.Checked = False Then
            ' запись в переменные выбранной части адреса
            Areal = nD.Item("Areal")
            ArealId = Trim(nD.Item("ArealId"))
            CityVillage = nD.Item("CityVillage")
            CityVillageId = Trim(nD.Item("CityVillageId"))
            Street = nD.Item("Street")
            StreetId = Trim(nD.Item("StreetId"))
            AddressString = nD.Item("AddressString")
            ' заполнить параметры дома можно только если выбрана улица
            Me.pnCityPHouseParameters.Enabled = (nD.Item("AddressPartType") = "Street")
            ' заполняем параметры дома если можно
            If Me.pnGKOHouseParameters.Enabled Then
                If Me.txtCityP_House.Text <> "" Then txtCityP_House_ = " д." & Me.txtCityP_House.Text
                If Me.txtCityP_LetterHouse.Text <> "" Then txtCityP_LetterHouse_ = Me.txtCityP_LetterHouse.Text
                If Me.txtCityP_Build.Text <> "" Then txtCityP_Build_ = " корп." & Me.txtCityP_Build.Text
            End If
            ' показываем какой адрес выбрали если только не включен множественный выбор улиц
            If Me.cheCityPMultiStreet.Checked = False Then
                Me.lbCityP_ToWhatBind.Text = AddressString & txtCityP_House_ & txtCityP_LetterHouse_ & txtCityP_Build_
            End If
        End If
    End Sub
    ' по ентеру переход на поле №дома
    Private Sub tlAddressAreal_CityP_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tlAddressAreal_CityP.KeyUp
        If e.KeyData = Keys.Enter Then
            Me.txtCityP_House.Focus()
            Me.txtCityP_House.SelectAll()
        End If
    End Sub
#End Region

#Region "gvCityParts"
    ' событие клика по части улицы запись активной строки
    Private Sub gvCityParts_Click(sender As Object, e As System.EventArgs) Handles gvCityParts.Click
        iSelectedRowCityP = sender.FocusedRowHandle
    End Sub
    ' событие выбора части улицы
    Private Sub gvCityParts_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles gvCityParts.FocusedRowChanged
        Me.lbCityP_WhatBind.Text = sender.GetRowCellDisplayText(sender.FocusedRowHandle, "Name")
    End Sub
    ' по ентеру переход на кнопку привязать
    Private Sub gvCityParts_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles gvCityParts.KeyUp, cheCityPNothing.KeyUp
        If e.KeyData = Keys.Enter Then
            Me.btBindingCityP.Focus()
        End If
    End Sub
#End Region
    ' загрузка отчета
    Private Sub npBindPartCity_CustomButtonClick(sender As System.Object, e As DevExpress.XtraBars.Docking2010.ButtonEventArgs) Handles npBindPartCity.CustomButtonClick
        PreparedReport(My.Resources.BindingDataView_CityParts, Me)
    End Sub
    ' при входе в поля с параметрами дома выбараем весь тект
    Private Sub txtCityP_House_Enter(sender As System.Object, e As System.EventArgs) Handles txtCityP_LetterHouse.Enter,
                                                                                            txtCityP_House.Enter,
                                                                                            txtCityP_Build.Enter
        sender.SelectAll()
    End Sub
    ' событие при изменении любого из параметров дома
    Private Sub txtCityP_House_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCityP_LetterHouse.TextChanged,
                                                                                                    txtCityP_House.TextChanged,
                                                                                                    txtCityP_Build.TextChanged
        'очищаем преременные с параметрами дома
        txtCityP_House_ = ""
        txtCityP_LetterHouse_ = ""
        txtCityP_Build_ = ""
        ' перезаписываем эти переменные из полей параметров
        If Me.txtCityP_House.Text <> "" Then txtCityP_House_ = " д." & Me.txtCityP_House.Text
        If Me.txtCityP_LetterHouse.Text <> "" Then txtCityP_LetterHouse_ = Me.txtCityP_LetterHouse.Text
        If Me.txtCityP_Build.Text <> "" Then txtCityP_Build_ = " корп." & Me.txtCityP_Build.Text
        ' если дом не указан то и буквы не может быть
        If txtCityP_House_ = "" Then Me.txtCityP_LetterHouse.Text = "" : txtCityP_LetterHouse_ = ""
        'показываем полный адрес
        Me.lbCityP_ToWhatBind.Text = AddressString & txtCityP_House_ & txtCityP_LetterHouse_ & txtCityP_Build_
    End Sub
    ' переход по ентору из поля "Корпус" на кнопку привязать 
    Private Sub txtCityP_Build_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCityP_Build.KeyDown
        If e.KeyCode = Keys.Enter Then Me.btBindingCityP.Focus()
    End Sub
    ' очистка полей с параметрами улиц
    Private Sub btnCityPClearHouseParameters_Click(sender As System.Object, e As System.EventArgs) Handles btnCityPClearHouseParameters.Click
        Me.txtCityP_House.Text = Nothing
        Me.txtCityP_LetterHouse.Text = Nothing
        Me.txtCityP_Build.Text = Nothing
    End Sub
    ' Активация множественного выбора улиц
    Private Sub cheCityPMultiStreet_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cheCityPMultiStreet.CheckedChanged
        ' при включении...
        If sender.Checked Then
            Me.pnCityPHouseParameters.Enabled = False     ' отключаем группу с параметрами дома
            Me.lbCityP_ToWhatBind.Text = Nothing          ' очищаем поле с улицей
            Me.tlAddressAreal_CityP.UncheckAll()          ' снимаем чеки со всех узлов
        Else ' при отключении
            ' включаем группу с параметрами дома если только фокус на узле с улицами
            If Me.tlAddressAreal_CityP.FocusedNode.Item("AddressPartType") = "Street" Then Me.pnCityPHouseParameters.Enabled = True
            tlAddressAreal_CityP_AfterFocusNode(Me.tlAddressAreal_CityP, Nothing) ' вызов события фокуса на tlAddressAreal_GKO 
        End If
        MultiAddressIdCityP = "NULL"                                           ' очищаем переменную со строкой мультиулиц
        Me.tlAddressAreal_CityP.OptionsView.ShowCheckBoxes = sender.Checked   ' включаем чекбоксы
    End Sub
    ' Сыбытие при изменении видимости группы полей с параметрами дома
    Private Sub pnCityPHouseParameters_EnabledChanged(sender As System.Object, e As System.EventArgs) Handles pnCityPHouseParameters.EnabledChanged
        ' очищаем переменные если группа скрыта
        If sender.Enabled = False Then
            txtGKO_House_ = ""
            txtGKO_LetterHouse_ = ""
            txtGKO_Build_ = ""
        End If
    End Sub
    ' событие при изменении поле "что привязываем" и "к чему привязываем"
    Private Sub lbCityP_ToWhatBind_TextChanged(sender As System.Object, e As System.EventArgs) Handles lbCityP_ToWhatBind.TextChanged, lbCityP_WhatBind.TextChanged
        ' если поля пустые отключаем кнопку Привязать
        If Me.lbCityP_WhatBind.Text = "" Or Me.lbCityP_ToWhatBind.Text = "" Then
            Me.btBindingCityP.Enabled = False
        Else
            Me.btBindingCityP.Enabled = True
        End If
    End Sub
    ' Активация отсутствия части города
    Private Sub cheCityPNothing_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cheCityPNothing.CheckedChanged
        Me.gcCityParts.Enabled = InverterBoolean(sender.Checked)
        If sender.Checked Then
            Me.lbCityP_WhatBind.Text = "Нет привязки к Части города"
        Else
            If Me.gvCityParts.FocusedRowHandle.ToString IsNot Nothing Then
                Me.lbCityP_WhatBind.Text = Me.gvCityParts.GetRowCellDisplayText(Me.gvCityParts.FocusedRowHandle, "Name")
            End If
        End If
    End Sub
    ' Запуск привязки
    Private Sub btBindingCityP_Click(sender As System.Object, e As System.EventArgs) Handles btBindingCityP.Click
        RunBinding("CityP")
    End Sub
    ' процесс привязки
    Private Sub RunBindingCityP()
        ' Чтоб отладка не возвращала ошибку из разных потоков
        Control.CheckForIllegalCrossThreadCalls = False
        Dim _lookAndFeel As New DefaultLookAndFeel ' Оформление для MSGBOX
        _lookAndFeel.EnableBonusSkins = True
        ' используем текущюю тему
        _lookAndFeel.LookAndFeel.SkinName = RegistryRead(pref_ComplexSettings, "SkinName", "Dark Side")
        Try
            Dim CityPartId As String = Me.gvCityParts.GetFocusedRowCellDisplayText("Id")   ' Ид части города
            If Me.cheCityPNothing.Checked Then CityPartId = "NULL" ' Если выбрано отсутствуе части города

            Dim CountRow As Integer = ExecuteScalar(
                "EXEC Pr_BindingCityParts " & _
                    "@ArealId = " & ArealId & ", " & _
                    "@VillageId = " & CityVillageId & ", " & _
                    "@StreetId = " & StreetId & ", " & _
                    "@CityPartId = " & CityPartId & ", " & _
                    "@MultiStreet = " & MultiAddressIdCityP & ", " & _
                    "@HouseParameters = " & ConvertToNull(Trim(Me.txtCityP_House.Text & Me.txtCityP_LetterHouse.Text & Me.txtCityP_Build.Text), True, 0)
                                                )

            potokBind = False ' Поток не занят
            XtraMessageBox.Show(_lookAndFeel.LookAndFeel, Me,
                                "Обработано строк: <u><b>" & CountRow.ToString("N0") & "</u></b>", _
                                Application.ProductName, _
                                MessageBoxButtons.OK, _
                                MessageBoxIcon.Information, _
                                DevExpress.Utils.DefaultBoolean.True)
            Me.txtCityP_House.Select() ' активация поля <Дом>
            ' если ошибка
        Catch ex As Exception
            XtraMessageBox.Show(_lookAndFeel.LookAndFeel, Me, ex.Message & Chr(10) & _
                   "<b>Ошибка процесса привязки места установки ИСУ ПУ</b>",
                   Application.ProductName,
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error,
                   DevExpress.Utils.DefaultBoolean.True)
            Me.potokBind = False
        End Try
    End Sub
#End Region

#Region "Вкладка ТСО"
#Region "tlAddressAreal_TSO"
    ' событие после чека выбранного узла
    Private Sub tlAddressAreal_TSO_AfterCheckNode(sender As Object, e As DevExpress.XtraTreeList.NodeEventArgs) Handles tlAddressAreal_TSO.AfterCheckNode
        Me.Cursor = Cursors.WaitCursor
        sep = Nothing
        Me.lbTSO_ToWhatBind.Text = Nothing      ' очищаем перечень того что выбрали
        MultiAddressIdTSO = Nothing
        ' цикл по всем чекнутым нодам
        For Each chn As TreeListNode In sender.GetAllCheckedNodes
            ' если узел Улица 
            If chn.Item("AddressPartType") = "Street" Then
                ' накапливаем перечень выбранных улиц
                Me.lbTSO_ToWhatBind.Text = Me.lbTSO_ToWhatBind.Text & sep & chn.Item("AddressString")   ' имена
                MultiAddressIdTSO = MultiAddressIdTSO & Trim(sep) & chn.Item("StreetId")                  ' ИДшники
                sep = ", " ' изменяем сепоратор
            End If
        Next
        ' заключаем мультистроку в ковычки
        MultiAddressIdTSO = "'" & MultiAddressIdTSO & "'"
        ' если есть чекнутые узлы, записываем перечень улиц в подсказку заменив разделитель на NewLine
        If sender.GetAllCheckedNodes.Count <> 0 Then _
        Me.lbTSO_ToWhatBind.ToolTip = Replace(Microsoft.VisualBasic.Left(Me.lbTSO_ToWhatBind.Text, Me.lbTSO_ToWhatBind.Text.Length - 2), sep, Chr(10))
        ' если мульти строка длинной более 8000 знаков (максимум для VARCHAR в SQL)
        If MultiAddressIdTSO.Length >= 8000 Then
            XtraMessageBox.Show("Достигнуто максимальное количество знаков (8000) для передачи в базу данных!" & Chr(10) & _
                                "Возможна привязка не в полном объеме!",
                                Application.ProductName,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
        End If
        Me.Cursor = Cursors.Default
    End Sub
    ' событие после фокуса на узле
    Private Sub tlAddressAreal_TSO_AfterFocusNode(ByVal sender As Object, ByVal e As DevExpress.XtraTreeList.NodeEventArgs) Handles tlAddressAreal_TSO.AfterFocusNode
        Dim nD As TreeListNode = sender.FocusedNode ' активный узел
        If EventChangedControl And Me.cheTSOMultiStreet.Checked = False Then
            ' запись в переменные выбранной части адреса
            Areal = nD.Item("Areal")
            ArealId = Trim(nD.Item("ArealId"))
            CityVillage = nD.Item("CityVillage")
            CityVillageId = Trim(nD.Item("CityVillageId"))
            Street = nD.Item("Street")
            StreetId = Trim(nD.Item("StreetId"))
            AddressString = nD.Item("AddressString")
            ' заполнить параметры дома можно только если выбрана улица
            Me.pnTSOHouseParameters.Enabled = (nD.Item("AddressPartType") = "Street")
            ' заполняем параметры дома если можно
            If Me.pnGKOHouseParameters.Enabled Then
                If Me.txtTSO_House.Text <> "" Then txtTSO_House_ = " д." & Me.txtTSO_House.Text
                If Me.txtTSO_LetterHouse.Text <> "" Then txtTSO_LetterHouse_ = Me.txtTSO_LetterHouse.Text
                If Me.txtTSO_Build.Text <> "" Then txtTSO_Build_ = " корп." & Me.txtTSO_Build.Text
            End If
            ' показываем какой адрес выбрали если только не включен множественный выбор улиц
            If Me.cheTSOMultiStreet.Checked = False Then
                Me.lbTSO_ToWhatBind.Text = AddressString & txtTSO_House_ & txtTSO_LetterHouse_ & txtTSO_Build_
            End If
        End If
    End Sub
    ' по ентеру переход на поле №дома
    Private Sub tlAddressAreal_TSO_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tlAddressAreal_TSO.KeyUp
        If e.KeyData = Keys.Enter Then
            Me.txtTSO_House.Focus()
            Me.txtTSO_House.SelectAll()
        End If
    End Sub
#End Region

#Region "gvTSO"
    ' событие клика по части улицы запись активной строки
    Private Sub gvvTSO_Click(sender As Object, e As System.EventArgs) Handles gvTSO.Click
        iSelectedRowTSO = sender.FocusedRowHandle
    End Sub
    ' событие выбора части улицы
    Private Sub gvvTSO_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles gvTSO.FocusedRowChanged
        Me.lbTSO_WhatBind.Text = sender.GetRowCellDisplayText(sender.FocusedRowHandle, "TSOName")
    End Sub
    ' по ентеру переход на кнопку привязать
    Private Sub gvTSO_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles gvTSO.KeyUp, cheTSONothing.KeyUp
        If e.KeyData = Keys.Enter Then
            Me.btBindingTSO.Focus()
        End If
    End Sub
#End Region
    ' загрузка отчета
    Private Sub npBindNetwoks_CustomButtonClick(sender As System.Object, e As DevExpress.XtraBars.Docking2010.ButtonEventArgs) Handles npBindNetwoks.CustomButtonClick
        PreparedReport(My.Resources.BindingDataView_TSO, Me)
    End Sub
    ' при входе в поля с параметрами дома выбараем весь тект
    Private Sub txtTSO_House_Enter(sender As System.Object, e As System.EventArgs) Handles txtTSO_LetterHouse.Enter,
                                                                                            txtTSO_House.Enter,
                                                                                            txtTSO_Build.Enter
        sender.SelectAll()
    End Sub
    ' событие при изменении любого из параметров дома
    Private Sub txtTSO_House_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTSO_LetterHouse.TextChanged,
                                                                                                    txtTSO_House.TextChanged,
                                                                                                    txtTSO_Build.TextChanged
        'очищаем преременные с параметрами дома
        txtTSO_House_ = ""
        txtTSO_LetterHouse_ = ""
        txtTSO_Build_ = ""
        ' перезаписываем эти переменные из полей параметров
        If Me.txtTSO_House.Text <> "" Then txtTSO_House_ = " д." & Me.txtTSO_House.Text
        If Me.txtTSO_LetterHouse.Text <> "" Then txtTSO_LetterHouse_ = Me.txtTSO_LetterHouse.Text
        If Me.txtTSO_Build.Text <> "" Then txtTSO_Build_ = " корп." & Me.txtTSO_Build.Text
        ' если дом не указан то и буквы не может быть
        If txtTSO_House_ = "" Then Me.txtTSO_LetterHouse.Text = "" : txtTSO_LetterHouse_ = ""
        'показываем полный адрес
        Me.lbTSO_ToWhatBind.Text = AddressString & txtTSO_House_ & txtTSO_LetterHouse_ & txtTSO_Build_
    End Sub
    ' переход по ентору из поля "Корпус" на кнопку привязать 
    Private Sub txtTSO_Build_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtTSO_Build.KeyDown
        If e.KeyCode = Keys.Enter Then Me.btBindingTSO.Focus()
    End Sub
    ' очистка полей с параметрами улиц
    Private Sub btnTSOClearHouseParameters_Click(sender As System.Object, e As System.EventArgs) Handles btnTSOClearHouseParameters.Click
        Me.txtTSO_House.Text = Nothing
        Me.txtTSO_LetterHouse.Text = Nothing
        Me.txtTSO_Build.Text = Nothing
    End Sub
    ' Активация множественного выбора улиц
    Private Sub cheTSOMultiStreet_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cheTSOMultiStreet.CheckedChanged
        ' при включении...
        If sender.Checked Then
            Me.pnTSOHouseParameters.Enabled = False     ' отключаем группу с параметрами дома
            Me.lbTSO_ToWhatBind.Text = Nothing          ' очищаем поле с улицей
            Me.tlAddressAreal_TSO.UncheckAll()          ' снимаем чеки со всех узлов
        Else ' при отключении
            ' включаем группу с параметрами дома если только фокус на узле с улицами
            If Me.tlAddressAreal_TSO.FocusedNode.Item("AddressPartType") = "Street" Then Me.pnTSOHouseParameters.Enabled = True
            tlAddressAreal_TSO_AfterFocusNode(Me.tlAddressAreal_TSO, Nothing) ' вызов события фокуса на tlAddressAreal_GKO 
        End If
        MultiAddressIdTSO = "NULL"                                           ' очищаем переменную со строкой мультиулиц
        Me.tlAddressAreal_TSO.OptionsView.ShowCheckBoxes = sender.Checked   ' включаем чекбоксы
    End Sub
    ' Сыбытие при изменении видимости группы полей с параметрами дома
    Private Sub pnTSOHouseParameters_EnabledChanged(sender As System.Object, e As System.EventArgs) Handles pnTSOHouseParameters.EnabledChanged
        ' очищаем переменные если группа скрыта
        If sender.Enabled = False Then
            txtGKO_House_ = ""
            txtGKO_LetterHouse_ = ""
            txtGKO_Build_ = ""
        End If
    End Sub
    ' событие при изменении поле "что привязываем" и "к чему привязываем"
    Private Sub lbTSO_ToWhatBind_TextChanged(sender As System.Object, e As System.EventArgs) Handles lbTSO_ToWhatBind.TextChanged, lbTSO_WhatBind.TextChanged
        ' если поля пустые отключаем кнопку Привязать
        If Me.lbTSO_WhatBind.Text = "" Or Me.lbTSO_ToWhatBind.Text = "" Then
            Me.btBindingTSO.Enabled = False
        Else
            Me.btBindingTSO.Enabled = True
        End If
    End Sub
    ' Активация отсутствия части города
    Private Sub cheTSONothing_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cheTSONothing.CheckedChanged
        Me.gcTSO.Enabled = InverterBoolean(sender.Checked)
        If sender.Checked Then
            Me.lbTSO_WhatBind.Text = "Нет привязки к ТСО"
        Else
            If Me.gvTSO.FocusedRowHandle.ToString IsNot Nothing Then
                Me.lbTSO_WhatBind.Text = Me.gvTSO.GetRowCellDisplayText(Me.gvTSO.FocusedRowHandle, "TSOName")
            End If
        End If
    End Sub
    ' Запуск привязки
    Private Sub btBindingTSO_Click(sender As System.Object, e As System.EventArgs) Handles btBindingTSO.Click
        RunBinding("TSO")
    End Sub
    ' процесс привязки
    Private Sub RunBindingTSO()
        ' Чтоб отладка не возвращала ошибку из разных потоков
        Control.CheckForIllegalCrossThreadCalls = False
        Dim _lookAndFeel As New DefaultLookAndFeel                              ' Оформление для MSGBOX
        Dim TSOId As String = Me.gvTSO.GetFocusedRowCellDisplayText("TSOId")    ' Ид части ТСО
        _lookAndFeel.EnableBonusSkins = True
        ' используем текущюю тему
        _lookAndFeel.LookAndFeel.SkinName = RegistryRead(pref_ComplexSettings, "SkinName", "Dark Side")
        Try
            If Me.cheTSONothing.Checked Then TSOId = "NULL" ' Если выбрано отсутствуе части города

            Dim CountRow As Integer = ExecuteScalar(
                "EXEC Pr_BindingTSO " & _
                    "@ArealId = " & ArealId & ", " & _
                    "@VillageId = " & CityVillageId & ", " & _
                    "@StreetId = " & StreetId & ", " & _
                    "@TSOId = " & TSOId & ", " & _
                    "@MultiStreet = " & MultiAddressIdTSO & ", " & _
                    "@HouseParameters = " & ConvertToNull(Trim(Me.txtTSO_House.Text & Me.txtTSO_LetterHouse.Text & Me.txtTSO_Build.Text), True, 0)
                                                )
            potokBind = False ' Поток не занят
            XtraMessageBox.Show(_lookAndFeel.LookAndFeel, Me,
                                "Обработано строк: <u><b>" & CountRow.ToString("N0") & "</u></b>", _
                                Application.ProductName, _
                                MessageBoxButtons.OK, _
                                MessageBoxIcon.Information, _
                                DevExpress.Utils.DefaultBoolean.True)
            Me.txtTSO_House.Select() ' активация поля <Дом>
            ' если ошибка
        Catch ex As Exception
            XtraMessageBox.Show(_lookAndFeel.LookAndFeel, Me, ex.Message & Chr(10) & _
                   "<b>Ошибка процесса привязки места установки ИСУ ПУ</b>",
                   Application.ProductName,
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error,
                   DevExpress.Utils.DefaultBoolean.True)
            Me.potokBind = False
        End Try
    End Sub
#End Region

#Region "Вкладка МЕСТО УСТАНОВКИ ИСУ"
#Region "gvISUCountersFromMenu"
    ' отмена скрытия при дабавлении ПУ из справочника Квазара
    Private Sub RepositoryLookUpEdit_ISU_QueryCloseUp(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles RepositoryLookUpEdit_ISU.QueryCloseUp
        e.Cancel = True
    End Sub
    ' дабавление ПУ из справочника Квазара
    Private Sub gvISUCountersFromMenu_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles gvISUCountersFromMenu.DoubleClick
        Dim view As GridView = CType(sender, GridView)
        Dim pt As Point = view.GridControl.PointToClient(Control.MousePosition)
        Dim info As GridHitInfo = view.CalcHitInfo(pt)
        ' если клик был по строке, а не вне ее
        If info.InRow OrElse info.InRowCell Then
            If info.Column IsNot Nothing Then
                ' перекачка ПУ в базе
                ExecuteQuery(
                        "EXEC Pr_BindingISO @CounterTypeId = " & info.View.GetRowCellValue(info.RowHandle, "CounterTypeId") & ", @Function = 2",
                        "AddCounterISU"
                            )
                ' удаление выбранного ПУ из iDataSet
                iDataSet.Tables("CounterList." & Me.Name).Rows.RemoveAt(info.View.GetDataSourceRowIndex(info.RowHandle))
                ' обновление информации по ИСУ ПУшкам
                SelectQueryData(
                               "ISUCounterList." & Me.Name,
                               "EXEC Pr_BindingISO @Function = 1, @SelectNumber = 2",
                               "Get CounterList"
                               )
                Me.gvISUList.ClearSelection()                                   ' очищаем выделения на таблице
                Me.gvISUList.FocusedRowHandle = Me.gvISUList.RowCount - 1       ' фокус на строке
                Me.gvISUList.SelectRow(Me.gvISUList.RowCount - 1)               ' выделение строки
                iSelectedRowISU = Me.gvISUList.FocusedRowHandle                 ' запонимаем выделенную строку
            End If
        End If
    End Sub
#End Region
#Region "gvISUList"
    ' прячем меню при клике на гриде т.к на RepositoryLookUpEdit_ISU_QueryCloseUp отменяет само себя
    Private Sub gvISUList_Click(sender As System.Object, e As System.EventArgs) Handles gvISUList.Click
        Me.pmISUmenu.HidePopup()
        iSelectedRowISU = Me.gvISUList.FocusedRowHandle
    End Sub
    ' вызов контекстного меню правой кнопкой
    Private Sub gvISUList_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles gvISUList.MouseDown
        Dim view As GridView = CType(sender, GridView)
        Dim pt As Point = view.GridControl.PointToClient(Control.MousePosition)
        Dim info As GridHitInfo = view.CalcHitInfo(pt)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Me.btnDeleteCounterISU.Enabled = info.InRow                 ' активность кнопки = был ли клик по строкам, а не вне их
            Me.btnReportISUList.Enabled = Me.gvISUList.RowCount > 0     ' активна если строк больше нуля
            Me.pmISUmenu.ShowPopup(Cursor.Position)                     ' вызов меню
        End If
        iSelectedRowISU = Me.gvISUList.FocusedRowHandle                 ' запоминаем выделенную строку
    End Sub
    ' активность кнопки отчета если нет строк
    Private Sub gvISUList_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gvISUList.RowStyle
        If sender.RowCount = 0 Then
            npBindCounterPlace.CustomHeaderButtons(0).Properties.Enabled = False
        Else
            npBindCounterPlace.CustomHeaderButtons(0).Properties.Enabled = True
        End If
    End Sub
#End Region
    ' удаление из справочника ИСУ ПУ
    Private Sub btnDeleteCounterISU_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDeleteCounterISU.ItemClick
        ' очищаем переменные
        sep = Nothing
        CounterTypeId = Nothing
        CounterName = Nothing
        ' цикл по выделенным строкам
        If gvISUList.SelectedRowsCount <> 0 Then
            For r = 0 To gvISUList.RowCount
                If gvISUList.IsRowSelected(r) Then
                    CounterTypeId = CounterTypeId & sep & Me.gvISUList.GetRowCellValue(r, "CounterTypeId")  ' мультистрока ИД
                    CounterName = CounterName & sep & Me.gvISUList.GetRowCellValue(r, "Name")               ' мультистрока Наимен
                    sep = ","                                                                               ' меняем разделитель
                End If
            Next
            CounterTypeId = "'" & CounterTypeId & "'"
            CounterName = Replace(CounterName, ",", Chr(10))    ' меняем разделитель на "новую строку"
        End If
        If XtraMessageBox.Show("Следующие приборы учета будут удалены:" & Chr(10) & _
                            "<u><b>" & CounterName & "</u></b>" & Chr(10) & _
                            "Вы согласны?",
                            Application.ProductName,
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question,
                            DevExpress.Utils.DefaultBoolean.True) = Windows.Forms.DialogResult.Yes Then
            ' удаление в базе
            ExecuteQuery(
                        "EXEC Pr_BindingISO @CounterTypeId = " & CounterTypeId & ", @Function = 4",
                        "DeleteSelectedCounters"
                        )
            ' обновление информации
            SelectQueryData(
                            "ISUCounterList." & Me.Name,
                            "EXEC Pr_BindingISO @Function = 1, @SelectNumber = 2",
                            "Get CounterList"
                            )
            Me.gvISUList.ClearSelection()                           ' очищаем выделения на таблице
            Me.gvISUList.FocusedRowHandle = iSelectedRowISU - 1     ' фокус на строке
            Me.gvISUList.SelectRow(iSelectedRowISU - 1)             ' выделение строки
            iSelectedRowISU = Me.gvISUList.FocusedRowHandle         ' запонимаем выделенную строку
        End If
    End Sub
    ' удаление из справочника ИСУ ПУ
    Private Sub gvISUList_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles gvISUList.KeyDown
        If e.KeyData = Keys.Delete Then
            btnDeleteCounterISU_ItemClick(sender, Nothing)
        End If
    End Sub
    ' загрузка отчета ISUPointsList
    Private Sub npBindCounterPlace_CustomButtonClick(sender As System.Object, e As DevExpress.XtraBars.Docking2010.ButtonEventArgs) Handles npBindCounterPlace.CustomButtonClick
        PreparedReport(My.Resources.BindingDataView_ISU, Me)
    End Sub
    Private Sub btnReportISUList_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnReportISUList.ItemClick
        PreparedReport(My.Resources.BindingDataView_ISU, Me)
    End Sub
    
    ' Удаление потерь
    Private Sub cheDeleteLossesISU_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cheDeleteLossesISU.CheckedChanged
        RegistryWrite(PreferenceForms, "cheDeleteLossesISU", Convert.ToInt32(sender.Checked))
    End Sub
    ' Запуск привязки ИСУ приборов учета
    Private Sub btBindingISU_Click(sender As System.Object, e As System.EventArgs) Handles btBindingISU.Click
        RunBinding("ISO")
    End Sub
    ' процесс привязки
    Private Sub RunBindingISO()
        ' Чтоб отладка не возвращала ошибку из разных потоков
        Control.CheckForIllegalCrossThreadCalls = False
        Dim _lookAndFeel As New DefaultLookAndFeel ' Оформление для MSGBOX                                             
        _lookAndFeel.EnableBonusSkins = True
        ' используем текущюю тему
        _lookAndFeel.LookAndFeel.SkinName = RegistryRead(pref_ComplexSettings, "SkinName", "Dark Side")
        Try
            Dim CountRow As Integer     ' счетчик обработанных строк в БД
            sep = Nothing               ' разделитель мультистроки
            CounterTypeId = Nothing     ' мультистрока с ИД счетчиков
            ' цикл по строкам и запись мультистроки
            For r = 0 To Me.gvISUList.RowCount - 1
                CounterTypeId = CounterTypeId & sep & Me.gvISUList.GetRowCellValue(r, "CounterTypeId")
                ' если строка одна, разделитель не меняем
                If Me.gvISUList.RowCount > 1 Then sep = ","
            Next
            CounterTypeId = "'" & CounterTypeId & "'"
            ' процесс привязки, процедура вернет кол-во строк
            CountRow = ExecuteScalar(
                "EXEC Pr_BindingISO " &
                "@CounterTypeId = " & CounterTypeId & ", " &
                "@CounterPlaceId = " & Me.cmbCounterPlaceISU.EditValue & ", " &
                "@DeleteLesses = " & Convert.ToInt32(Me.cheDeleteLossesISU.Checked) & ", " &
                "@Function = 3")
            potokBind = False ' Поток не занят
            XtraMessageBox.Show(_lookAndFeel.LookAndFeel, Me,
                                "Обработано строк: <u><b>" & CountRow.ToString("N0") & "</u></b>", _
                                Application.ProductName, _
                                MessageBoxButtons.OK, _
                                MessageBoxIcon.Information, _
                                DevExpress.Utils.DefaultBoolean.True)
            ' если ошибка
        Catch ex As Exception
            XtraMessageBox.Show(_lookAndFeel.LookAndFeel, Me, ex.Message & Chr(10) & _
                   "<b>Ошибка процесса привязки места установки ИСУ ПУ</b>",
                   Application.ProductName,
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error,
                   DevExpress.Utils.DefaultBoolean.True)
            Me.potokBind = False
        End Try
    End Sub
#End Region
End Class