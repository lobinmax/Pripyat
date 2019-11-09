Imports DevExpress.XtraEditors
Imports DevExpress.Utils
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Columns
Imports System.IO
Imports DevExpress.XtraSplashScreen

Public Class frArchivist
    Dim iSelectedNode As Integer = 0
    Dim PreferenceForms As String               ' Ветка в реестре для хранения настроек формы 
    Dim ShowPreviewJournals As Boolean          ' Показать примечание журналов
    Dim ShowClosedJournals As Boolean = True    ' Показать закрытые журналы
    Dim SelectedJournalType As String           ' Выбранный тип журнала

    Private Sub frDocRegistration_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        SaveViewForm(Me)
        RemoveTableDataSet(Me)
        FocusNode_Journals = 0
    End Sub
    Private Sub frArchivist_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.lbDataBaseName.Caption = pref_DataBaseName
        Me.lbServerName.Caption = pref_ServerIP
        LoadViewForm(Me)
        LoadJournalTree(Me.tlJoulnalTypes, "JournalsTree." & Me.Name, 1, DelWithoutChild:=1, ExpandedAll:=1, IsAppearance:=True)
        PreferenceForms = pref_UserSettings & Me.Name & "\"
        ShowPreviewJournals = RegistryRead(PreferenceForms, "ShowPreviewJournals", 1)
        Me.gvJournals.OptionsView.ShowPreview = ShowPreviewJournals
        If ShowPreviewJournals Then Me.btnHidePreview.ImageOptions.Image = My.Resources.none_16x16
        If ShowPreviewJournals = False Then Me.btnHidePreview.ImageOptions.Image = My.Resources.separator_16x16

    End Sub

    ' Фокус на типах журналов
    Private Sub tlJoulnalTypes_AfterFocusNode(sender As System.Object, e As DevExpress.XtraTreeList.NodeEventArgs) Handles tlJoulnalTypes.AfterFocusNode
        If EventChangedControl Then
            FocusNode_Journals = sender.FocusedNode.Id
            ' не обновлять если не изменился выбранный журнал
            If SelectedJournalType <> e.Node("JournalCode") Then Designer_gvJournals()
            SelectedJournalType = e.Node("JournalCode") ' выбранный журнал
            ' обновляем журналы если выбран не Root
            If e.Node.Level <> 0 Then
                Designer_gvDocuments()
            End If
            Me.gcDocuments.Visible = (e.Node.Level <> 0)
        End If
    End Sub

    ' Настройка списка журналов
    Private Sub Designer_gvJournals()
        SelectQueryData(
                        "JournalList." & Me.Name,
                        "EXEC Pr_Journals_Archivist " &
                            "@CodJournalId = " & Me.tlJoulnalTypes.FocusedNode("JournalCode") & ", " &
                            "@Function = 1",
                        "EXEC Pr_Journals_Archivist. Function = 1"
                        )
        ' при первом запуске источник не установлен
        If IsNothing(Me.gcJournals.DataSource) Then
            Me.gcJournals.DataSource = iDataSet.Tables("JournalList." & Me.Name)
            ' сопоставление статуса месяца с изображениями
            Dim rps As New Repository.RepositoryItemImageComboBox
            Dim _ImageCollection As New ImageCollection
            _ImageCollection.AddImage(My.Resources.unlock16x16)
            _ImageCollection.AddImage(My.Resources.lock_16x16)
            _ImageCollection.AddImage(My.Resources.StatusMonth_16x16)

            rps.SmallImages = _ImageCollection
            rps.Items.Add(New ImageComboBoxItem("Активен", "Активен", 0))
            rps.Items.Add(New ImageComboBoxItem("Завершен", "Завершен", 1))
            rps.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center
            ' скрываем все столбцы
            HidenAllColumns_Grid(Me.gvJournals, iDataSet.Tables("JournalList." & Me.Name))
            With Me.gvJournals
                .Images = _ImageCollection
                .PreviewFieldName = "Notes"
                .Columns("ClosePerformer").Visible = True
                .Columns("ClosePerformer").Caption = "Завершил"
                .Columns("DtClose").Visible = True
                .Columns("DtClose").Caption = "Дата завершения"
                .Columns("DocsSum").Visible = True
                .Columns("DocsSum").Caption = "Сумма"
                .Columns("DocsSum").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                .Columns("DocsSum").DisplayFormat.FormatString = "### ### ##0.00 р"
                .Columns("DocsCount").Visible = True
                .Columns("DocsCount").Caption = "Кол-во"
                .Columns("DocsCount").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                .Columns("DocsCount").DisplayFormat.FormatString = "# ##0"
                .Columns("OpenPerformer").Visible = True
                .Columns("OpenPerformer").Caption = "Открыл"
                .Columns("DtOpen").Visible = True
                .Columns("DtOpen").Caption = "Дата открытия"
                .Columns("JournalNumberLong").Visible = True
                .Columns("JournalNumberLong").Caption = "Номер журнала"

                With .Columns("JournalStatus")
                    .Visible = True
                    .ColumnEdit = rps
                    .ImageIndex = 2                    ' Иконка в шапке столбца
                    .ImageAlignment = StringAlignment.Center
                    .ToolTip = "Статус журнала"         ' всплывающее сообщение
                    .OptionsColumn.ShowCaption = False
                    .OptionsColumn.FixedWidth = True
                    .OptionsColumn.AllowSize = False
                    .OptionsFilter.AllowFilter = False
                    .Width = 40
                End With
            End With
        End If
        Me.gvJournals.BestFitColumns()
    End Sub

    ' настройка списка документов
    Private Sub Designer_gvDocuments()
        If CompliteLoad = False Then Exit Sub ' Для обхода ошибки о уже назначенном Датаридере
        ' при первом запуске источник не указан
        If Not IsNothing(Me.gcDocuments.DataSource) Then
            Me.gcDocuments.DataSource = Nothing
            ' Удаляем все столбцы для загрузки новых данных
            Do While iDataSet.Tables("JournalDocuments." & Me.Name).Columns.Count > 0
                iDataSet.Tables("JournalDocuments." & Me.Name).Columns.RemoveAt(0)
            Loop
            Me.gvDocuments.PopulateColumns()
        End If
        tmWaitAnimation.StartWaitingIndicator(Me.SplitContainerControl2.Panel2, 0)
        SelectQueryData(
                        "JournalDocuments." & Me.Name,
                        "EXEC Pr_Journals_Archivist " &
                            "@CodJournalId = " & Me.tlJoulnalTypes.FocusedNode("JournalCode") & ", " &
                            "@CodDocsId = " & Me.tlJoulnalTypes.FocusedNode("DocumentCode") & ", " &
                            "@JournalNumber = " & Me.gvJournals.GetFocusedRowCellDisplayText("JournalNumber") & ", " &
                            "@Function = 2",
                        "EXEC Pr_Journals_Archivist. Function = 2"
                        )
        If IsNothing(Me.gcDocuments.DataSource) Then
            Me.gcDocuments.DataSource = iDataSet.Tables("JournalDocuments." & Me.Name)
        End If
        ' настраиваем отображение документов
        Select Case Me.tlJoulnalTypes.FocusedNode("JournalCode")
            Case "'4-03'"
                Designer4_03() ' листы выдачи заданий 
            Case "'4-05'"
                Designer4_05() ' уведомления
            Case "'4-09'"
                Designer4_05() ' ограничения
        End Select
        SumInDocuments() ' обновляем суммы под списком документов
        tmWaitAnimation.StopWaitingIndicator()
    End Sub

    ' настрайка списка документов. Листы заданий
    Private Sub Designer4_03()
        HidenAllColumns_Grid(Me.gvDocuments, iDataSet.Tables("JournalDocuments." & Me.Name))
        With Me.gvDocuments
            .Columns("Performers").Visible = True
            .Columns("Performers").Caption = "Исполнитель задания"
            .Columns("Giving").Visible = True
            .Columns("Giving").Caption = "Выдал задание"
            .Columns("Author").Visible = True
            .Columns("Author").Caption = "Подготовил задание"
            .Columns("PrintSessionCount").Visible = True
            .Columns("PrintSessionCount").Caption = "Кол-во сеансов печати"
            .Columns("DocsSum").Visible = True
            .Columns("DocsSum").Caption = "Сумма документов"
            .Columns("DocsSum").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            .Columns("DocsSum").DisplayFormat.FormatString = "### ### ##0.00 р"
            .Columns("DocsCount").Visible = True
            .Columns("DocsCount").Caption = "Кол-во док-тов"
            .Columns("DocsCount").ToolTip = "Количество документов содержащихся" & Chr(10) & "в маршрутном листе"
            .Columns("DocsCount").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            .Columns("DocsCount").DisplayFormat.FormatString = "# ##0"
            .Columns("DtPerformance").Visible = True
            .Columns("DtPerformance").Caption = "Дата исполнения"
            .Columns("DtDocument").Visible = True
            .Columns("DtDocument").Caption = "Дата листа-задания"
            .Columns("DocNumberLong").Visible = True
            .Columns("DocNumberLong").Caption = "Номер листа-задания"
            .BestFitColumns()
        End With
    End Sub

    ' настройка списка документов. Уведомления
    Private Sub Designer4_05()
        HidenAllColumns_Grid(Me.gvDocuments, iDataSet.Tables("JournalDocuments." & Me.Name))
        With Me.gvDocuments
            .Columns("Author").Visible = True
            .Columns("Author").Caption = "Автор задания"
            .Columns("Controller").Visible = True
            .Columns("Controller").Caption = "Контролер"
            .Columns("DocumentType").Visible = True
            .Columns("DocumentType").Caption = "Тип мероприятия"
            .Columns("SumDoc").Visible = True
            .Columns("SumDoc").Caption = "Сумма, руб"
            .Columns("SumDoc").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            .Columns("SumDoc").DisplayFormat.FormatString = "### ### ##0.00 р"
            .Columns("SumDoc").BestFit()
            .Columns("AddressString").Visible = True
            .Columns("AddressString").Caption = "Адрес"
            .Columns("SNP_short").Visible = True
            .Columns("SNP_short").Caption = "ФИО"
            .Columns("AbonentNumber").Visible = True
            .Columns("AbonentNumber").Caption = "Номер абонента"
            .Columns("DtDocument").Visible = True
            .Columns("DtDocument").Caption = "Дата документа"
            .Columns("DocNumberLong").Visible = True
            .Columns("DocNumberLong").Caption = "Номер документа"
            .BestFitColumns()
        End With
    End Sub

    ' изменение фокуса на строке с журналами
    Private Sub gvJournals_FocusedRowChanged(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles gvJournals.FocusedRowChanged
        Dim view As ColumnView = TryCast(sender, ColumnView)
        Dim o As Object = view.GetRowCellValue(e.FocusedRowHandle, view.Columns("JournalNumber"))
        If Not o Is Nothing AndAlso Not o Is DBNull.Value Then
            Dim val As Boolean = Convert.ToBoolean(o)
            Designer_gvDocuments()
            Me.btnJournalReport.Enabled = (sender.GetRowCellDisplayText(e.FocusedRowHandle, "JournalStatusId") <> 1)
            Me.btnCloseJournal.Enabled = (sender.GetRowCellDisplayText(e.FocusedRowHandle, "JournalStatusId") = 1)
            Me.btnExportJournal_XLSX.Enabled = (sender.GetRowCellDisplayText(e.FocusedRowHandle, "DocsCount") <> 0)
        End If
    End Sub

    ' вызов контекстного меню правой кнопкой на списке документов
    Private Sub gvDocuments_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles gvDocuments.MouseDown
        Dim view As GridView = CType(sender, GridView)
        Dim pt As Point = view.GridControl.PointToClient(Control.MousePosition)
        Dim info As GridHitInfo = view.CalcHitInfo(pt)

        Dim SortedCount As Integer = 0  ' количество столбцов с сортировкой
        Dim FilterCount As Integer = 0  ' количество столбцов с фильтрами 
        ' считаем столбцы с фильтрами или сортировкой
        For Each col As GridColumn In sender.Columns
            If col.SortOrder <> DevExpress.Data.ColumnSortOrder.None Then SortedCount += 1
            If col.FilterInfo.FilterString <> "" Then FilterCount += 1
        Next
        ' активность кнопок
        Me.btnClearSort.Enabled = (SortedCount <> 0)
        Me.btnClearFilter.Enabled = (FilterCount <> 0)
        Me.btnExportMenu.Enabled = (sender.RowCount > 0)
        ' нажата правая кнопка
        If e.Button = Windows.Forms.MouseButtons.Right And info.InRow Then
            Select Case Me.tlJoulnalTypes.FocusedNode("JournalCode")
                Case "'4-03'"
                    Me.btnOpenTaskSheet.Enabled = True
                    Me.btnCopyAbonNumber.Enabled = False
                Case "'4-05'"
                    Me.btnCopyAbonNumber.Enabled = True
                    Me.btnOpenTaskSheet.Enabled = False
                Case "'4-09'"
                    Me.btnCopyAbonNumber.Enabled = True
                    Me.btnOpenTaskSheet.Enabled = False
            End Select
            Me.PopupMenu.ShowPopup(MousePosition)
        End If
    End Sub

    ' при изменении фильтров обновляем суммы
    Private Sub gvDocuments_ColumnFilterChanged(sender As System.Object, e As System.EventArgs) Handles gvDocuments.ColumnFilterChanged
        SumInDocuments()
    End Sub

    ' Настройка сумм
    Private Sub SumInDocuments()
        ' если столбец существует
        If Me.gvDocuments.Columns.Contains(Me.gvDocuments.Columns("DocNumberLong")) Then
            Me.gvDocuments.Columns("DocNumberLong").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
            Me.gvDocuments.Columns("DocNumberLong").SummaryItem.DisplayFormat =
                "Всего: <b>" & Format(gvDocuments.Columns("DocNumberLong").SummaryItem.SummaryValue, "### ### ##0") & "</b>"
            Me.gvDocuments.Columns("DocNumberLong").BestFit()
        End If
        If Me.gvDocuments.Columns.Contains(Me.gvDocuments.Columns("SumDoc")) Then
            Me.gvDocuments.Columns("SumDoc").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            Me.gvDocuments.Columns("SumDoc").SummaryItem.DisplayFormat =
                "Всего: <b>" & Format(gvDocuments.Columns("SumDoc").SummaryItem.SummaryValue, "### ### ##0.00 р") & "</b>"
            Me.gvDocuments.Columns("SumDoc").BestFit()
        End If
        If Me.gvDocuments.Columns.Contains(Me.gvDocuments.Columns("DocsSum")) Then
            Me.gvDocuments.Columns("DocsSum").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            Me.gvDocuments.Columns("DocsSum").SummaryItem.DisplayFormat =
                "Всего: <b>" & Format(gvDocuments.Columns("DocsSum").SummaryItem.SummaryValue, "### ### ##0.00 р") & "</b>"
            Me.gvDocuments.Columns("DocsSum").BestFit()
        End If
    End Sub

#Region "Панель управления журналами"
    ' Экспорт списка документов в Excel
    Private Sub btnExportJournal_XLSX_Click(sender As System.Object, e As System.EventArgs) Handles btnExportJournal_XLSX.Click
        If iDataSet.Tables.Contains("JournalDocuments_XLSX." & Me.Name) Then
            ' если таблица существует, удаляем столбцы
            Do While iDataSet.Tables("JournalDocuments_XLSX." & Me.Name).Columns.Count > 0
                iDataSet.Tables("JournalDocuments_XLSX." & Me.Name).Columns.RemoveAt(0)
            Loop
        End If
        If SelectQueryData(
                       "JournalDocuments_XLSX." & Me.Name,
                       "EXEC Pr_Journals_Archivist " &
                           "@CodJournalId = '" & Me.gvJournals.GetFocusedRowCellDisplayText("CodJournalId") & "', " &
                           "@JournalNumber = " & Me.gvJournals.GetFocusedRowCellDisplayText("JournalNumber") & ", " &
                           "@Function = 3",
                       "EXEC Pr_Journals_Archivist. Function = 2._XLSX"
                       ) Then
            ' если строк 0
            If iDataSet.Tables("JournalDocuments_XLSX." & Me.Name).Rows.Count = 0 Then
                XtraMessageBox.Show("Отсутствуют данные для экспорта!" & Chr(10) & "Судя по всему журнал пуст ....",
                                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Dim _Name As String = Me.gvJournals.GetFocusedRowCellDisplayText("CodJournalId") & ". Журнал №" & Me.gvJournals.GetFocusedRowCellDisplayText("JournalNumber")
            Dim fileName As String = GetSaveFileName("Microsoft Excel 2007-2010 files(*.xlsx)|*.xlsx", _Name)
            If String.IsNullOrEmpty(fileName) Then
                Return
            End If
            tmWaitAnimation.StartWaitingIndicator(Me.SplitContainerControl1, 0)
            Me.SplitContainerControl2.Enabled = False
            Me.ProgressBar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            ExportToExcel_DataSet(iDataSet.Tables("JournalDocuments_XLSX." & Me.Name), fileName, _Name, ProgressBar, 1, Me)
        End If
        tmWaitAnimation.StopWaitingIndicator()
        Me.SplitContainerControl2.Enabled = True
        Me.ProgressBar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
    End Sub

    ' формирование отчета по журналу
    Private Sub btnJournalReport_Click(sender As System.Object, e As System.EventArgs) Handles btnJournalReport.Click
        If Me.gvJournals.GetFocusedRowCellDisplayText("DocsCount") = 0 Then
            XtraMessageBox.Show("Журнал <u><b>№" & Me.gvJournals.GetFocusedRowCellDisplayText("JournalNumberLong") & "</b></u> пуст ...",
                                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information, DefaultBoolean.True)
            Exit Sub
        End If
        Select Case Me.gvJournals.GetFocusedRowCellDisplayText("CodJournalId")
            Case "4-03" ' листы заданий
                PrepareReport(My.Resources.JournalInArchive_4_03)
            Case "4-05" ' уведомления
                PrepareReport(My.Resources.JournalInArchive_4_05)
            Case "4-09" ' отключения
                PrepareReport(My.Resources.JournalInArchive_4_05)
        End Select
    End Sub
    ' загрузка отчета по журналу
    Private Sub PrepareReport(ByVal ReportFile As Object)
        Dim FRx As New FastReport.Report    ' Новый экземпляр отчета
        Dim _ReportFile As Object = ReportFile
        ' Проверка зашит ли файл отчета в программу
        If File.Exists(SaveResToTemp(_ReportFile)) Then
            Try
                AddHandler FRx.FinishReport, AddressOf CloseWait ' событие после загрузке отчета
                FRx.Load(SaveResToTemp(_ReportFile)) ' Загрузка отчета из ресурсов программы
                Dim wm As FastReport.ReportPage = FRx.Report.Pages(1)
                Dim b As FastReport.PreviewButtons = FRx.Preview.Buttons.Edit
                b = FastReport.PreviewButtons.None
                wm.Watermark.Text = Me.gvJournals.GetFocusedRowCellDisplayText("JournalNumberLong")
                FRx.ReportInfo.Name = Me.gvJournals.GetFocusedRowCellDisplayText("JournalNumberLong") & ". " & Me.gvJournals.GetFocusedRowCellDisplayText("Name")
                FRx.SetParameterValue("ConnectionString", pref_ConnectionString)
                FRx.SetParameterValue("prCodJournalId", Me.gvJournals.GetFocusedRowCellDisplayText("CodJournalId"))
                FRx.SetParameterValue("prJournalNumber", Me.gvJournals.GetFocusedRowCellDisplayText("JournalNumber"))
                FRx.Show(True, Me)              ' Показать отчет
                FRx.Dispose()                   ' Осводить ресурсы
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            ' Если отчета нет в ресурсах программы
            XtraMessageBox.Show("Не найден файл для генератора отчетов!", _
            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    ' скрыть завершенные журналы
    Private Sub btnHideClosedJournals_Click(sender As System.Object, e As System.EventArgs) Handles btnShowClosedJournals.Click
        ShowClosedJournals = InverterBoolean(ShowClosedJournals)
        If ShowClosedJournals Then
            ' очищаем фильтр
            Me.gvJournals.Columns("JournalStatusId").ClearFilter()
            Me.btnShowClosedJournals.ImageOptions.Image = My.Resources.hide_16x16
        Else
            ' скрываем 
            Me.gvJournals.ActiveFilterString = "[JournalStatusId] <> 2"
            Me.btnShowClosedJournals.ImageOptions.Image = My.Resources.show_16x16
        End If
    End Sub

    ' спрятать превьюшки в списке журналов
    Private Sub btnHideTitle_Click(sender As System.Object, e As System.EventArgs) Handles btnHidePreview.Click
        Me.gvJournals.OptionsView.ShowPreview = InverterBoolean(ShowPreviewJournals)
        ShowPreviewJournals = Me.gvJournals.OptionsView.ShowPreview
        ' сохраняем в настройках
        RegistryWrite(PreferenceForms, "ShowPreviewJournals", Convert.ToInt64(ShowPreviewJournals))
        ' меняем иконку на кнопке
        If ShowPreviewJournals Then Me.btnHidePreview.ImageOptions.Image = My.Resources.none_16x16
        If ShowPreviewJournals = False Then Me.btnHidePreview.ImageOptions.Image = My.Resources.separator_16x16
    End Sub
#End Region


#Region "Контекстное меню на списке документов"
    ' очистить фильтры
    Private Sub btnClearFilter_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnClearFilter.ItemClick
        Me.gvDocuments.ClearColumnsFilter()
    End Sub
    ' очистить сортировку
    Private Sub btnClearSort_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnClearSort.ItemClick
        Me.gvDocuments.ClearSorting()
    End Sub
#Region "Группа экспорта"
    ' Export_PDF
    Private Sub btnExport_PDF_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport_PDF.ItemClick
        ' вызываем диалог сохранения файла
        Dim fileName As String = GetSaveFileName("PDF(*.pdf)|*.pdf", Me.tlJoulnalTypes.FocusedNode("JournalName"))
        If String.IsNullOrEmpty(fileName) Then
            Exit Sub
        End If
        Me.gvDocuments.ExportToPdf(fileName)
        OpenFile(fileName)
    End Sub
    ' Export_RTF
    Private Sub btnExport_RTF_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport_RTF.ItemClick
        ' вызываем диалог сохранения файла
        Dim fileName As String = GetSaveFileName("Текст в формате RTF(*.rtf)|*.rtf", Me.tlJoulnalTypes.FocusedNode("JournalName"))
        If String.IsNullOrEmpty(fileName) Then
            Exit Sub
        End If
        Me.gvDocuments.ExportToRtf(fileName)
        OpenFile(fileName)
    End Sub
    ' Export_XLSX
    Private Sub btnExport_XLSX_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport_XLSX.ItemClick
        ' вызываем диалог сохранения файла
        Dim fileName As String = GetSaveFileName("Microsoft Excel 2007-2010 файлы(*.xlsx)|*.xlsx", Me.tlJoulnalTypes.FocusedNode("JournalName"))
        If String.IsNullOrEmpty(fileName) Then
            Exit Sub
        End If
        Dim XLSXoptions As New DevExpress.XtraPrinting.XlsxExportOptionsEx
        XLSXoptions.TextExportMode = DevExpress.XtraPrinting.TextExportMode.Value
        XLSXoptions.ShowTotalSummaries = DefaultBoolean.False
        Me.gvDocuments.ExportToXlsx(fileName, XLSXoptions)
        OpenFile(fileName)
    End Sub
    ' Export_XLS
    Private Sub btnExport_XLS_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport_XLS.ItemClick
        ' вызываем диалог сохранения файла
        Dim fileName As String = GetSaveFileName("Microsoft Excel 2003 файлы(*.xls)|*.xls", Me.tlJoulnalTypes.FocusedNode("JournalName"))
        If String.IsNullOrEmpty(fileName) Then
            Exit Sub
        End If
        Dim XLSoptions As New DevExpress.XtraPrinting.XlsExportOptionsEx
        XLSoptions.TextExportMode = DevExpress.XtraPrinting.TextExportMode.Value
        XLSoptions.ShowTotalSummaries = DefaultBoolean.False
        Me.gvDocuments.ExportToXls(fileName, XLSoptions)
        OpenFile(fileName)
    End Sub
    ' Export_CSV
    Private Sub btnExport_CSV_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport_CSV.ItemClick
        ' вызываем диалог сохранения файла
        Dim fileName As String = GetSaveFileName("CSV (разделители - запятые)(*.csv)|*.csv", Me.tlJoulnalTypes.FocusedNode("JournalName"))
        If String.IsNullOrEmpty(fileName) Then
            Exit Sub
        End If
        Dim CSVoptions As New DevExpress.XtraPrinting.CsvExportOptionsEx
        CSVoptions.TextExportMode = DevExpress.XtraPrinting.TextExportMode.Value
        CSVoptions.Separator = ";"
        CSVoptions.ExportType = DevExpress.Export.ExportType.Default
        CSVoptions.TextExportMode = DevExpress.XtraPrinting.TextExportMode.Value
        Me.gvDocuments.ExportToCsv(fileName, CSVoptions)
        OpenFile(fileName)
    End Sub
#End Region
    ' скопировать номер абонента кнопка
    Private Sub btnCopyAbonNumber_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCopyAbonNumber.ItemClick
        My.Computer.Clipboard.SetText(Me.gvDocuments.GetFocusedRowCellDisplayText("AbonentNumber"))
    End Sub
    ' скопировать номер абонента Ctrl + C
    Private Sub gvDocuments_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles gvDocuments.KeyDown
        If (e.Modifiers = Keys.Control) And (e.KeyCode = Keys.C) Then
            My.Computer.Clipboard.SetText(Me.gvDocuments.GetFocusedRowCellDisplayText("AbonentNumber"))
        End If
    End Sub

    ' открыть лист выдачи задания
    Private Sub btnOpenTaskSheet_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnOpenTaskSheet.ItemClick
        Console.WriteLine(Me.gvDocuments.GetFocusedRowCellDisplayText("TaskSheetId"))
        Dim FRx As New FastReport.Report                                           ' Новый экземпляр отчета
        ' Проверка зашит ли файл отчета в программу
        If File.Exists(SaveResToTemp(My.Resources.PetitionBlank)) Then
            Try
                FRx.Load(SaveResToTemp(My.Resources.TaskSheetBlank)) ' Загрузка отчета из ресурсов программы
                ' Заполнение параметров отчета данными из базы
                'FRx.ReportInfo.Name = "Заявление " & Me.txt_Adress.Text
                FRx.SetParameterValue("TaskSheetId", Me.gvDocuments.GetFocusedRowCellDisplayText("TaskSheetId"))
                FRx.SetParameterValue("OnHands", 0)
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
#End Region
End Class