Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraTreeList.Columns
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraEditors.Controls

Public Class frAddNewPr_CounterSection
    Dim CurNode As TreeListNode = frSectionODN.tlODUlist.FocusedNode ' Выбранный узел в дереве ОДУ
    Dim SectionId As String ' ИД созданной секции
    Dim PreferenceForms As String       ' Ветка в реестре для хранения настроек формы 

    Sub New()
        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()
        LoadViewForm(Me)
        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
    End Sub
    Private Sub frAddNewPr_CounterSection_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        SaveViewForm(Me)
        RemoveTableDataSet(Me)
        Me.Dispose()
    End Sub
    Private Sub frAddNewPr_CounterSection_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        tmWaitAnimation.StartWaitingIndicator(frSectionODN, 0)
        ' перечень ТУ для подключения
        SelectQueryData(
                       "PointConnection." & Me.Name,
                       "EXEC Pr_PointsPublic_MiscFunctions @PublicPointId = " & CurNode("PublicPointId") & ", @Function = 1",
                       "Get CounterTypes"
                       )
        Me.gcAbonentList.DataSource = iDataSet.Tables("PointConnection." & Me.Name)
        With Me.gvAbonentList
            .PopulateColumns(iDataSet.Tables("PointConnection." & Me.Name))
            ' фильтр скрыть подключенных
            .Columns("IsConnection").FilterInfo = New ColumnFilterInfo(Me.gvAbonentList.Columns("IsConnection"), Me.chbShowConnection.Checked)
            .Columns("PointId").Visible = False
            .Columns("IsConnection").Visible = False
            .Columns("Connect").Visible = False
            .Columns("Connect").Caption = "Подключен"
            .Columns("Checked").Caption = "Выбор"
            .Columns("PointNumber").Caption = "Номер ТУ"
            .Columns("SNP").Caption = "ФИО"
            .Columns("Address").Caption = "Адрес"
            .Columns("CountLodgers").Caption = "Жильцов"
            .Columns("CountLodgers").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            .Columns("CountLodgers").ColumnEdit = New Repository.RepositoryItemSpinEdit With {.MinValue = 0, .IsFloatValue = False}
            .Columns("SquareTotal").Caption = "Площадь"
            .Columns("IsConnection").OptionsFilter.AllowFilter = False
            .BestFitColumns()
        End With

        ' перечень приборов учета
        SelectQueryData(
                       "CountersType." & Me.Name,
                       "SELECT * FROM vPr_cmbCountersType WHERE Signs != 0",
                       "Get CounterTypes"
                       )
        With Me.slueCounterType
            .Properties.DataSource = iDataSet.Tables("CountersType." & Me.Name)
            .Properties.KeyMember = "CounterTypeId"
            .Properties.DisplayMember = "FullCounterName"
            .EditValue = iDataSet.Tables("CountersType." & Me.Name).Rows(0)
        End With
        With Me.gvCounterType
            HidenAllColumns_Grid(Me.gvCounterType, iDataSet.Tables("CountersType." & Me.Name))
            .Columns("RootNodeName").Visible = True
            .Columns("FullCounterName").Visible = True
            .Columns("FullCounterName").Caption = "Наименование прибора учета"
            .Columns("RootNodeName").Group()
        End With
        ' для того чтоб активировать выбор
        Me.slueCounterType.ShowPopup()
        Me.slueCounterType.ClosePopup()

        ' Схемы распределения
        SelectQueryData(
                       "Schemes." & Me.Name,
                       "SELECT * FROM vPr_PointsPublicSectionsSchemes",
                       "Get Schemes"
                       )
        With Me.cmbSchemes
            .Properties.DataSource = iDataSet.Tables("Schemes." & Me.Name)
            .Properties.ValueMember = "SchemesId"
            .Properties.DisplayMember = "Name"
            .ItemIndex = 0
            .Properties.PopulateColumns()
            .Properties.Columns("SchemesId").Visible = False
        End With

        Me.txtDtSetup.EditValue = ExecuteScalar("SELECT dbo.Pr_fnsGetFirstDayActiveMonth()")
        Me.txtDtSetup.BackColor = Me.txtCounterNumber.BackColor
        Me.lbAddressODUHouse.Text = "<b>ПУ для: </b><u><i>" & CurNode("AddressHouse") & "</u></i>"
        Me.lbPointsCount.Text = "<u>Всего точек учета по дому: <b>" & iDataSet.Tables("PointConnection." & Me.Name).Rows.Count & "</b> шт.</u>"
        Me.lbPointsConnectionCount.Text = "<u>Из них подключенных к секции: <b>" & iDataSet.Tables("PointConnection." & Me.Name).Select("IsConnection=1").Count & "</b> шт.</u>"
        tmWaitAnimation.StopWaitingIndicator()
    End Sub

#Region "gvAbonentList"
    ' выделям отмеченные строки
    Private Sub gvAbonentList_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gvAbonentList.RowStyle
        Dim View As GridView = TryCast(sender, GridView)
        If e.RowHandle >= 0 Then
            If View.GetRowCellValue(e.RowHandle, View.Columns("Checked")) Then
                e.Appearance.Font = New System.Drawing.Font("Tahoma", 8.5!, FontStyle.Underline Or FontStyle.Italic)
            End If
        End If
    End Sub
    ' проверка корректности кол-ва жильцов
    Private Sub gvAbonentList_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles gvAbonentList.ValidatingEditor
        If sender.FocusedColumn.FieldName <> "CountLodgers" Then Exit Sub
        If (Convert.ToInt32(e.Value) < 0) Then
            e.Valid = False
            e.ErrorText = "Число проживающих не может быть мешьше нуля!"
        End If
    End Sub
    ' запрет редактирования всех столбцов кроме IsConnection и CountLodgers
    Private Sub gvAbonentList_ShowingEditor(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles gvAbonentList.ShowingEditor
        If sender.FocusedColumn.FieldName = "Checked" Or sender.FocusedColumn.FieldName = "CountLodgers" Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub
#End Region

    ' скрыть/ показать подключенных/НЕ подлюченных ТУ
    Private Sub chbShowConnection_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chbShowConnection.CheckedChanged
        ' фильтруем по столбцу IsConnection
        Me.gvAbonentList.Columns("IsConnection").FilterInfo = New ColumnFilterInfo(Me.gvAbonentList.Columns("IsConnection"), sender.Checked)
        ' если показать подключенных полностью отключаем редактирование
        Me.gvAbonentList.OptionsBehavior.Editable = InverterBoolean(sender.Checked)
        If sender.Checked Then
            sender.Text = "Показать НЕ подключенных"
            Me.gvAbonentList.Columns("Connect").Visible = True
        Else
            sender.Text = "Показать уже подключенных"
            Me.gvAbonentList.Columns("Connect").Visible = False
        End If
    End Sub
    ' OK
    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        If ValidateData() = False Then Exit Sub
        If AddNewSection() = False Then Exit Sub
        If PointsConnection(SectionId) = False Then Exit Sub
        frSectionODN.iSelectedNode_ODU = SectionId
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
    ' Cancel
    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    ' создание секции
    Private Function AddNewSection() As Boolean
        SectionId = ExecuteScalar(
                "EXEC Pr_PointsPublicAddSection " &
                    "@PublicPointId = " & CurNode("PublicPointId") & ", " &
                    "@SectionRoomNumber = " & Me.txtRoomNumber.EditValue & ", " &
                    "@DtCounterSetup = '" & Me.txtDtSetup.EditValue & "', " &
                    "@CounterTypeId = " & Me.gvCounterType.GetFocusedRowCellValue("CounterTypeId") & ", " &
                    "@CounterNumber = '" & Me.txtCounterNumber.EditValue & "', " &
                    "@IndicationSetup = " & Me.txtIndicationSetup.EditValue & ", " &
                    "@SchemesId = " & Me.cmbSchemes.EditValue & ", " &
                    "@Function = 1", "EXEC Pr_PointsPublicAddSection @Function = 1")
        If IsNothing(SectionId) Then Return False : Exit Function
        Return True
    End Function
    ' подключаем список точек
    Private Function PointsConnection(ByVal SectionId As Integer) As Boolean
        For r = 0 To Me.gvAbonentList.RowCount
            If Me.gvAbonentList.GetRowCellValue(r, "Checked") Then
                Do Until CompliteLoad
                    Application.DoEvents()
                Loop
                If ExecuteQuery("EXEC Pr_PointsPublicAddSection " &
                                "@SectionId = " & SectionId & ", " &
                                "@PointId = " & Me.gvAbonentList.GetRowCellValue(r, "PointId") & ", " &
                                "@LodgersCount = " & Me.gvAbonentList.GetRowCellValue(r, "CountLodgers") & ", " &
                                "@Function = 2", "EXEC Pr_PointsPublicAddSection @Function = 2") = False Then
                    XtraMessageBox.Show("Во время подключения одной из ТУ возникла ошибка!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    ' проверка корректности полей
    Private Function ValidateData() As Boolean
        ' если выбрано, то не видит ТУ для подключения
        If Me.chbShowConnection.Checked Then Me.chbShowConnection.Checked = False
        ' показания установки
        If (Convert.ToInt32(Me.txtIndicationSetup.Value) < 0) Or IsNothing(Me.txtIndicationSetup.Value) Then
            XtraMessageBox.Show("Не указаны показания установки!" & Chr(10) & "Или значение меньше нуля!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        ' Номер ПУ
        If Me.txtCounterNumber.Text = "" Then
            XtraMessageBox.Show("Введите номер прибора учета!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        ' значность ПУ
        Console.WriteLine(Me.gvCounterType.GetFocusedRowCellValue("Signs"))
        If Me.gvCounterType.GetFocusedRowCellValue("Signs") < Me.txtIndicationSetup.Text.Length Then
            XtraMessageBox.Show("Значность выбранного ПУ не соответствует показаниям установки!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        ' дата установка ПУ
        Dim PeriodNumberOpenMin As Integer = ExecuteScalar("SELECT kpnom.PeriodNumber FROM vKernel_PeriodNumberOpenMin AS kpnom")
        If Year(Me.txtDtSetup.Text) * 100 + Month(Me.txtDtSetup.Text) < PeriodNumberOpenMin Then
            XtraMessageBox.Show("Дата установки принадлежит к закрытому периоду!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        ' считаем выбранные лицевые
        Dim chCount As Integer = 0
        For r = 0 To Me.gvAbonentList.RowCount
            If Me.gvAbonentList.GetRowCellValue(r, "Checked") Then chCount += 1
            ' если один чек есть незачем продолжать цикл
            If chCount > 0 Then Return True
        Next ' если ничего не выбрано
        If chCount = 0 Then
            XtraMessageBox.Show("Не выбраны точки учета для подклюбчения к секционному ПУ!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.txtIndicationSetup.Focus() : Me.txtIndicationSetup.SelectAll()
            Return False
        End If
    End Function
End Class