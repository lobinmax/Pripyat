Imports DevExpress.XtraBars.Navigation
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraTreeList.Nodes
Imports System.Threading
Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports System.Globalization
Imports System.IO
Imports DevExpress.Spreadsheet
Imports DevExpress.XtraSpreadsheet.API.Native.Implementation
Imports DevExpress.XtraEditors

Public Class frReport
    Dim PreferenceForms As String       ' Ветка в реестре для хранения настроек формы 
    Dim IsFindedTab As Boolean = False  ' Если true значит нашли записанную в настройках вклаку
    Dim iSelectedNode As Integer        ' Индекс активного нода

    Sub New()
        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()
        SplashScreenManager.ShowForm(Me, GetType(frDefaultWaitForm), True, True, False)
        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
    End Sub
    Private Sub frReport_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        RemoveTableDataSet(Me)
    End Sub

    Private Sub frReport_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PreferenceForms = pref_UserSettings & "\" & Me.Name & "\"
        Me.lbDB_Name.Caption = pref_DataBaseName
        Me.lbDB_Server.Caption = pref_ServerIP
        Me.XtraTabControl.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False
        Dim aeName As String = RegistryRead(PreferenceForms, "AccordionSelectedElement", "aeShare_DebetList")
        ' ищем активный элемент по записанному значению в настройках
        For Each el As AccordionControlElement In AccordionControl.Elements
            FindedSelectElement(el, aeName)
            If IsFindedTab Then Exit For
        Next
        SplashScreenManager.CloseForm(False)
    End Sub
    ' рекурсия по _AccordionControl
    Private Sub FindedSelectElement(ByVal _AccordionControl As AccordionControlElement, _SelectedElementName As String)
        For Each el As AccordionControlElement In _AccordionControl.Elements
            FindedSelectElement(el, _SelectedElementName)
            If el.Name = _SelectedElementName Then
                Me.AccordionControl.SelectedElement = el
                IsFindedTab = True
                Exit For
            End If
        Next
    End Sub
    ' клик по элементу в аккардионе
    Private Sub AccordionControl_SelectedElementChanged(sender As System.Object, e As DevExpress.XtraBars.Navigation.SelectedElementChangedEventArgs) _
        Handles AccordionControl.SelectedElementChanged
        Dim aeName As String = e.Element.Name       ' Имя выбранного пункта на аккардионе 
        aeName = Replace(aeName, "ae", "tp", 1, 2)  ' определяем имя сопоставленной вкладки
        RegistryWrite(PreferenceForms, "AccordionSelectedElement", e.Element.Name)  ' запись в настройки активной вкладки
        ' активируем сопоставленную вкладку если такова существует
        If Me.XtraTabControl.TabPages.Contains(Me.XtraTabControl.Controls(aeName)) Then
            Me.XtraTabControl.SelectedTabPage = Me.XtraTabControl.Controls(aeName)
            SelectedPageChanged(aeName)
        End If
    End Sub
    ' при выборе определенной вкладки
    Private Sub SelectedPageChanged(ByVal TabName As String)
        Select Case TabName
            Case "tpShare_DebetList"
                DesignerShareDebetList()
        End Select
    End Sub

#Region "#Общие отчеты"
#Region "Расширенный список должников"
    ' заполненение элементов данными из базы
    Private Sub DesignerShareDebetList()
        Dim tbName As String ' Для хранения имен таблицы
        Dim tbDataset As DataTable = iDataSet.Tables(tbName) ' датасет

        ' периоды для 3005
        tbName = "Share_DebetList_Period3005." & Me.Name
        If InverterBoolean(iDataSet.Tables.Contains(tbName)) Then
            SelectQueryData(tbName, "SELECT * FROM vPr_cmdCounterPeriod pcp", "GetPeriodList3005")
            tbDataset = iDataSet.Tables(tbName)
            With Me.cmbShare_DebetList_Period3005
                .Properties.DataSource = tbDataset
                .Properties.ValueMember = "GroupCount"
                .Properties.DisplayMember = "GroupName"
                .Properties.PopulateColumns()
                .Properties.Columns("GroupCount").Visible = False
                .Properties.Columns("CountMin").Visible = False
                .Properties.Columns("CountMax").Visible = False
                .ItemIndex = 0
            End With
        End If

        ' периоды для 3201
        tbName = "Share_DebetList_Period3201." & Me.Name
        If InverterBoolean(iDataSet.Tables.Contains(tbName)) Then
            SelectQueryData(tbName, "SELECT * FROM vPr_cmdCounterPeriod pcp", "GetPeriodList3201")
            tbDataset = iDataSet.Tables(tbName)
            With Me.cmbShare_DebetList_Period3201
                .Properties.DataSource = tbDataset
                .Properties.ValueMember = "GroupCount"
                .Properties.DisplayMember = "GroupName"
                .Properties.PopulateColumns()
                .Properties.Columns("GroupCount").Visible = False
                .Properties.Columns("CountMin").Visible = False
                .Properties.Columns("CountMax").Visible = False
                .ItemIndex = 0
            End With
        End If

        ' сетевые
        tbName = "Share_DebetList_TSO." & Me.Name
        If InverterBoolean(iDataSet.Tables.Contains(tbName)) Then
            SelectQueryData(tbName, "SELECT * FROM vPr_cmbTSO", "GetTSO")
            tbDataset = iDataSet.Tables(tbName)
            With Me.cmbShare_DebetList_TSO
                .Properties.DataSource = tbDataset
                .Properties.ValueMember = "TSOId"
                .Properties.DisplayMember = "TSOName"
                .Properties.PopulateColumns()
                .Properties.Columns("TSOId").Visible = False
                .ItemIndex = 0
            End With
        End If

        ' статусы ТУ
        tbName = "Share_DebetList_PointStatus." & Me.Name
        If InverterBoolean(iDataSet.Tables.Contains(tbName)) Then
            SelectQueryData(tbName, "SELECT * FROM vPr_cmbAccountStatus", "GetAccountStatus")
            tbDataset = iDataSet.Tables(tbName)
            With Me.cmbShare_DebetList_PointStatus
                .Properties.DataSource = tbDataset
                .Properties.ValueMember = "AccountStatusId"
                .Properties.DisplayMember = "Name"
                .Properties.PopulateColumns()
                .Properties.Columns("AccountStatusId").Visible = False
                .ItemIndex = 0
            End With
        End If

        ' статусы абонента 
        tbName = "Share_DebetList_AbonentStatus." & Me.Name
        If InverterBoolean(iDataSet.Tables.Contains(tbName)) Then
            Me.cmbShare_DebetList_AbonentStatus.Properties.DisplayMember = "StatusString"
            Me.cmbShare_DebetList_AbonentStatus.Properties.KeyMember = "Id"
            LoadAbonentStatusTree(Me.tlShare_DebetList_AbonentStatus, True, 1, tbName)
            tbDataset = iDataSet.Tables(tbName)
            Me.cmbShare_DebetList_AbonentStatus.EditValue = tbDataset.Rows(0)
            Me.tlShare_DebetList_AbonentStatus.SelectNode(Me.tlShare_DebetList_AbonentStatus.FindNodeByFieldValue("Id", tbDataset.Rows(0).Item("Id")))
        End If

        ' управляющие
        tbName = "Pr_GKOTree." & Me.Name
        If InverterBoolean(iDataSet.Tables.Contains(tbName)) Then
            Me.cmbShare_DebetList_GKO.Properties.DisplayMember = "GKString"
            Me.cmbShare_DebetList_GKO.Properties.KeyMember = "Id"
            LoadGKOTree(Me.tlShare_DebetList_GKO, Me, False, iSelectedNode, False, 1)
            tbDataset = iDataSet.Tables(tbName)
            Me.cmbShare_DebetList_GKO.EditValue = tbDataset.Rows(0)
            Me.tlShare_DebetList_GKO.SelectNode(Me.tlShare_DebetList_GKO.FindNodeByFieldValue("Id", tbDataset.Rows(0).Item("Id")))
        End If

        ' адреса
        tbName = "Share_DebetList_Address." & Me.Name
        If InverterBoolean(iDataSet.Tables.Contains(tbName)) Then
            Me.cmbShare_DebetList_Address.Properties.DisplayMember = "AddressString"
            Me.cmbShare_DebetList_Address.Properties.KeyMember = "Id"
            LoadAddressTree(11, 1, Me.tlShare_DebetList_Address, TableName:=tbName)
            tbDataset = iDataSet.Tables(tbName)
            Me.cmbShare_DebetList_Address.EditValue = tbDataset.Rows(0)
            Me.tlShare_DebetList_Address.SelectNode(Me.tlShare_DebetList_Address.FindNodeByFieldValue("Id", tbDataset.Rows(0).Item("Id")))
        End If

        ' контролеры
        tbName = "Share_DebetList_Controller." & Me.Name
        If InverterBoolean(iDataSet.Tables.Contains(tbName)) Then
            Me.cmbShare_DebetList_Controller.Properties.DisplayMember = "Role"
            Me.cmbShare_DebetList_Controller.Properties.KeyMember = "Id"
            LoadInspectorsTree(Me.tlShare_DebetList_Controller, tbName)
            tbDataset = iDataSet.Tables(tbName)
            Me.cmbShare_DebetList_Controller.EditValue = tbDataset.Rows(0)
            Me.tlShare_DebetList_Controller.SelectNode(Me.tlShare_DebetList_Controller.FindNodeByFieldValue("Id", tbDataset.Rows(0).Item("Id")))
        End If
    End Sub
    ' фильтрация по умолчанию
    Private Sub btnShare_DebetList_ClearFilter_Click(sender As System.Object, e As System.EventArgs) Handles btnShare_DebetList_ClearFilter.Click
        Me.cmbShare_DebetList_Controller.EditValue = iDataSet.Tables("Share_DebetList_Controller." & Me.Name).Rows(0)  ' контролеры
        Me.cmbShare_DebetList_Period3005.ItemIndex = 0  ' периоды для 3005
        Me.cmbShare_DebetList_Period3201.ItemIndex = 0  ' периоды для 3201
        Me.cmbShare_DebetList_TSO.ItemIndex = 0         ' сетевые
        Me.cmbShare_DebetList_PointStatus.ItemIndex = 0 ' статусы ТУ
        ' статусы абонента
        Me.cmbShare_DebetList_AbonentStatus.EditValue = iDataSet.Tables("Share_DebetList_AbonentStatus." & Me.Name).Rows(0)
        Me.tlShare_DebetList_AbonentStatus.FocusedNode = Nothing
        ' управляющие
        Me.cmbShare_DebetList_GKO.EditValue = iDataSet.Tables("Pr_GKOTree." & Me.Name).Rows(0)
        Me.tlShare_DebetList_GKO.FocusedNode = Nothing
        ' адреса
        Me.cmbShare_DebetList_Address.EditValue = iDataSet.Tables("Share_DebetList_Address." & Me.Name).Rows(0)
        Me.tlShare_DebetList_Address.FocusedNode = Nothing
        ' контролеры
        Me.cmbShare_DebetList_Controller.EditValue = iDataSet.Tables("Share_DebetList_Controller." & Me.Name).Rows(0)
        Me.tlShare_DebetList_Controller.FocusedNode = Nothing

        Me.seShare_DebetList_SaldoMin.Value = 0             ' сальдо мин
        Me.seShare_DebetList_SaldoMax.Value = 999999        ' сальдо макс
        Me.rgShare_DebetList_SaldoType.SelectedIndex = 0    ' статическое сальдо
    End Sub
    ' контекстные кнопки выподающих списков
    Private Sub cmbShare_DebetList_Controller_Properties_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles _
        cmbShare_DebetList_TSO.ButtonClick
        Select Case sender.Name
            Case "cmbShare_DebetList_TSO"
                Me.cmbShare_DebetList_TSO.ItemIndex = 0         ' сетевые
        End Select
    End Sub
    ' активация / дисактивация мультивыбора
    Private Sub cmbShare_DebetList_GKO_Properties_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles _
        cmbShare_DebetList_Controller.ButtonClick, cmbShare_DebetList_GKO.ButtonClick, cmbShare_DebetList_Address.ButtonClick, cmbShare_DebetList_AbonentStatus.ButtonClick
        Dim tlSender As TreeList = sender.Properties.TreeList
        Dim btn As EditorButton = e.Button
        Dim ppShow As Boolean = sender.IsPopupOpen ' выпадающий список активен
        Select Case btn.Index
            Case 1 ' мультивыбор
                If tlSender.OptionsView.ShowCheckBoxes Then
                    tlSender.OptionsView.ShowCheckBoxes = False
                    sender.Properties.TextEditStyle = TextEditStyles.DisableTextEditor
                    btn.ImageOptions.Image = My.Resources.hideproduct_16x16
                Else
                    tlSender.OptionsView.ShowCheckBoxes = True
                    btn.ImageOptions.Image = My.Resources.showproduct_16x16
                    sender.Properties.TextEditStyle = TextEditStyles.HideTextEditor
                End If
                If ppShow Then sender.ShowPopup() ' выбрасываем выпадающий список
            Case 2 ' умолчание
                Select Case sender.Name
                    Case "cmbShare_DebetList_Controller"
                        ' контролеры
                        Me.cmbShare_DebetList_Controller.EditValue = iDataSet.Tables("Share_DebetList_Controller." & Me.Name).Rows(0)
                        Me.tlShare_DebetList_Controller.FocusedNode = Nothing
                    Case "cmbShare_DebetList_GKO"
                        ' управляющие
                        Me.cmbShare_DebetList_GKO.EditValue = iDataSet.Tables("Pr_GKOTree." & Me.Name).Rows(0)
                        Me.tlShare_DebetList_GKO.FocusedNode = Nothing
                    Case "cmbShare_DebetList_Address"
                        ' адреса
                        Me.cmbShare_DebetList_Address.EditValue = iDataSet.Tables("Share_DebetList_Address." & Me.Name).Rows(0)
                        Me.tlShare_DebetList_Address.FocusedNode = Nothing
                End Select
        End Select
    End Sub

    ' изменение периодов через выподающие списки
    Private Sub cmbShare_DebetList_Period3005_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles _
        cmbShare_DebetList_Period3005.EditValueChanged, cmbShare_DebetList_Period3201.EditValueChanged
        Dim iRow As DataRowView = sender.GetSelectedDataRow()
        Select Case sender.Name
            Case "cmbShare_DebetList_Period3005"
                Me.seShare_DebetList_Per3005Min.Value = iRow("CountMin")
                Me.seShare_DebetList_Per3005Max.Value = iRow("CountMax")
            Case "cmbShare_DebetList_Period3201"
                Me.seShare_DebetList_Per3201Min.Value = iRow("CountMin")
                Me.seShare_DebetList_Per3201Max.Value = iRow("CountMax")
        End Select
    End Sub
    ' становление умолчаний по группам контролов
    Private Sub GroupControl_CustomButtonClick(sender As System.Object, e As DevExpress.XtraBars.Docking2010.BaseButtonEventArgs) Handles _
        GroupControl1.CustomButtonClick, GroupControl2.CustomButtonClick, GroupControl3.CustomButtonClick, GroupControl4.CustomButtonClick
        Select Case e.Button.Properties.VisibleIndex ' индекс кнопки 
            Case 1
                Me.cmbShare_DebetList_Period3005.ItemIndex = 0  ' периоды для 3005
            Case 2
                Me.cmbShare_DebetList_Period3201.ItemIndex = 0  ' периоды для 3201
            Case 3
                Me.cmbShare_DebetList_PointStatus.ItemIndex = 0 ' статусы ТУ
                ' статусы абонента 
                Me.cmbShare_DebetList_AbonentStatus.EditValue = iDataSet.Tables("Share_DebetList_AbonentStatus." & Me.Name).Rows(0)
                Me.tlShare_DebetList_AbonentStatus.FocusedNode = Nothing
            Case 4
                Me.seShare_DebetList_SaldoMin.Value = 0             ' сальдо мин
                Me.seShare_DebetList_SaldoMax.Value = 999999        ' сальдо макс
                Me.rgShare_DebetList_SaldoType.SelectedIndex = 0    ' статическое сальдо
        End Select
    End Sub
    ' загрузка отчета
    Private Sub btnShare_DebetList_CreateReport_Click(sender As System.Object, e As System.EventArgs) Handles btnShare_DebetList_CreateReport.Click
        ' вызываем диалог сохранения файла
        Dim fileName As String = GetSaveFileName("Microsoft Excel 2007-2010 files(*.xlsx)|*.xlsx", "Список должников " & Now.Date & ".xlsx")
        If String.IsNullOrEmpty(fileName) Then
            Return
        End If
        tmWaitAnimation.StartWaitingIndicator(Me, 0)
        Me.AccordionControl.Enabled = False
        Me.XtraTabControl.Enabled = False
        Me.ProgressBarReport.Caption = "Формирование данных на сервере ..."
        Me.ProgressBarReport.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        ' обработка фильтров
        GetTreeListValues_GKO(Me.tlShare_DebetList_GKO)                     ' ЖКХ
        GetTreeListValues_Inspectors(Me.tlShare_DebetList_Controller)       ' контролеры
        GetTreeListValues_AbonStatus(Me.tlShare_DebetList_AbonentStatus)    ' статус абонента
        GetTreeListValues_Address(Me.tlShare_DebetList_Address)             ' адреса

        Application.DoEvents()
        If SelectQueryData("Pr_rptShare_DebetList." & Me.Name,
                        "EXEC Pr_rptShare_DebetList " & _
                            "@TSOId = " & cmbShare_DebetList_TSO.EditValue & ", " & _
                            "@ChiefId = " & ChiefId & ", " & _
                            "@ControllerId = " & ControllerId & ", " & _
                            "@RouterId = " & RouterId & ", " & _
                            "@RouterMultyStringId = " & RouterMultyStringId & ", " & _
                            "@GKOid = " & GKOid & ", " & _
                            "@GKHid = " & GKHid & ", " & _
                            "@GKHMultyStringId = " & GKHMultyStringId & ", " & _
                            "@ArealId = " & ArealId & ", " & _
                            "@CityVillageId = " & CityVillageId & ", " & _
                            "@StreetId = " & StreetId & ", " & _
                            "@MultiStreetsStringId = " & MultiStreetsStringId & ", " & _
                            "@PeriodMin_3005 = " & Me.seShare_DebetList_Per3005Min.EditValue & ", " & _
                            "@PeriodMax_3005 = " & Me.seShare_DebetList_Per3005Max.EditValue & ", " & _
                            "@PeriodMin_3201 = " & Me.seShare_DebetList_Per3201Min.EditValue & ", " & _
                            "@PeriodMax_3201 = " & Me.seShare_DebetList_Per3201Max.EditValue & ", " & _
                            "@BalanceMin = " & Me.seShare_DebetList_SaldoMin.EditValue & ", " & _
                            "@BalanceMax = " & Me.seShare_DebetList_SaldoMax.EditValue & ", " & _
                            "@BalanceType = " & Me.rgShare_DebetList_SaldoType.SelectedIndex & ", " & _
                            "@PointStatusId = " & Me.cmbShare_DebetList_PointStatus.EditValue & ", " & _
                            "@AbonentStatusId = " & AbonentStatusId & ", " & _
                            "@ExtAbonentStatusId = " & ExtAbonentStatusId & ", " & _
                            "@AbonentStatusMultyStringId = " & AbonentStatusMultyStringId,
                        "Pr_rptShare_DebetList"
                        ) = False Then
            GoTo m
        End If
        Application.DoEvents()
        Me.ProgressBarReport.Caption = "Экспорт данных в Microsoft Excel ..."
        RepositoryProgressBarReport.ShowTitle = True
        Application.DoEvents()
        ExportToExcel_DataSet(iDataSet.Tables("Pr_rptShare_DebetList." & Me.Name), fileName, "Список должников", ProgressBarReport, 1, Me)
m:
        tmWaitAnimation.StopWaitingIndicator()
        Me.AccordionControl.Enabled = True
        Me.XtraTabControl.Enabled = True
        Me.ProgressBarReport.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        RepositoryProgressBarReport.ShowTitle = False
        Me.XtraTabControl.Enabled = True
        Me.AccordionControl.Enabled = True
    End Sub
#End Region
#End Region
End Class