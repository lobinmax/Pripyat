
Imports DevExpress.XtraGrid.Columns.GridColumn
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class frBookFlat
    Dim PreferenceForms As String   ' Ветка в реестре для хранения настроек формы 
    Dim _SelectedTab As Integer     ' Индекс активной владки для номера селекта в базе

    Private Sub frBookFlat_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        RemoveTableDataSet(Me)
    End Sub
    Private Sub frBookFlat_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PreferenceForms = pref_UserSettings & "\" & Me.Name & "\"                                   ' путь к настройкам
        Me.npMain.SelectedPageIndex = RegistryRead(PreferenceForms, "npMain_SelectedPageIndex", 0)  ' активаци я вкладки
        Me.npMain.Pages(Me.npMain.SelectedPageIndex).Focus()
    End Sub
    ' изменение картинки вкладки
    Private Sub npMain_SelectedPageChanging(sender As Object, e As DevExpress.XtraBars.Navigation.SelectedPageChangingEventArgs) Handles npMain.SelectedPageChanging
        If e.OldPage IsNot Nothing Then
            e.OldPage.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.Text
        End If
        e.Page.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
    End Sub
    ' события при смене активной вкладки
    Private Sub npMain_SelectedPageIndexChanged(sender As Object, e As System.EventArgs) Handles npMain.SelectedPageIndexChanged
        Dim IsFirstLoad As Boolean      ' переменная первой активации вкладки
        If PreferenceForms IsNot Nothing Then
            ' запись в настройки
            RegistryWrite(PreferenceForms, "npMain_SelectedPageIndex", sender.SelectedPageIndex)
            Select Case sender.SelectedPageIndex
                Case 0 ' -- Акты ССП
                    _SelectedTab = sender.SelectedPageIndex
                    IsFirstLoad = InverterBoolean(iDataSet.Tables.Contains("ActImpossible." & Me.Name))

                    SelectQueryData("ActImpossible." & Me.Name, "EXEC Pr_BooksFlat @Function = 1, @SelectNumber = " & _SelectedTab)
                    ' при первой актвации вкладки
                    If IsFirstLoad Then
                        Me.gcActImpossible.DataSource = iDataSet.Tables("ActImpossible." & Me.Name)
                        With Me.gvActImpossible
                            .Columns("Id").Caption = "Идентификатор"
                            .Columns("Id").BestFit()
                            .Columns("Name").Caption = "Наименование"
                            .Focus()
                        End With
                    End If
                Case 1 ' -- виды судов
                    _SelectedTab = sender.SelectedPageIndex
                    IsFirstLoad = InverterBoolean(iDataSet.Tables.Contains("CourtType." & Me.Name))

                    SelectQueryData("CourtType." & Me.Name, "EXEC Pr_BooksFlat @Function = 1, @SelectNumber = " & _SelectedTab)
                    ' при первой актвации вкладки
                    If IsFirstLoad Then
                        Me.gcCourtType.DataSource = iDataSet.Tables("CourtType." & Me.Name)
                        With Me.gvCourtType
                            .Columns("Id").Caption = "Идентификатор"
                            .Columns("Id").BestFit()
                            .Columns("Name").Caption = "Наименование"
                            .Focus()
                        End With
                    End If
                Case 2 ' -- зоны обслуживания судьи
                    _SelectedTab = sender.SelectedPageIndex
                    IsFirstLoad = InverterBoolean(iDataSet.Tables.Contains("ZoneOfService." & Me.Name))

                    SelectQueryData("ZoneOfService." & Me.Name, "EXEC Pr_BooksFlat @Function = 1, @SelectNumber = " & _SelectedTab)
                    ' при первой актвации вкладки
                    If IsFirstLoad Then
                        Me.gcZoneOfService.DataSource = iDataSet.Tables("ZoneOfService." & Me.Name)
                        With Me.gvZoneOfService
                            .Columns("Id").Caption = "Идентификатор"
                            .Columns("Id").BestFit()
                            .Columns("Name").Caption = "Наименование"
                            .Focus()
                        End With
                    End If
                Case 3 ' -- виды заявлений в суд
                    _SelectedTab = sender.SelectedPageIndex
                    IsFirstLoad = InverterBoolean(iDataSet.Tables.Contains("PetitionType." & Me.Name))

                    SelectQueryData("PetitionType." & Me.Name, "EXEC Pr_BooksFlat @Function = 1, @SelectNumber = " & _SelectedTab)
                    ' при первой актвации вкладки
                    If IsFirstLoad Then
                        Me.gcPetitionType.DataSource = iDataSet.Tables("PetitionType." & Me.Name)
                        With Me.gvPetitionType
                            .Columns("Id").Caption = "Идентификатор"
                            .Columns("Id").BestFit()
                            .Columns("Name").Caption = "Наименование"
                            .Columns("NameShort").Caption = "Кодировка"
                            .Focus()
                        End With
                    End If
                Case 4 ' -- виды решений
                    _SelectedTab = sender.SelectedPageIndex
                    IsFirstLoad = InverterBoolean(iDataSet.Tables.Contains("DecisionType." & Me.Name))

                    SelectQueryData("DecisionType." & Me.Name, "EXEC Pr_BooksFlat @Function = 1, @SelectNumber = " & _SelectedTab)
                    SelectQueryData("DecisionTypeExt." & Me.Name, "EXEC Pr_BooksFlat @Function = 1, @SelectNumber = " & _SelectedTab + 1)
                    If iDataSet.Relations.Contains("Причины решения суда") = False Then
                        iDataSet.Relations.Add("Причины решения суда", _
                                            iDataSet.Tables("DecisionType." & Me.Name).Columns("Id"), _
                                            iDataSet.Tables("DecisionTypeExt." & Me.Name).Columns("Id"), False
                                            )
                    End If
                    ' при первой актвации вкладки
                    If IsFirstLoad Then
                        Me.gcDecisionType.DataSource = iDataSet.Tables("DecisionType." & Me.Name)
                        With Me.gvDecisionType
                            .Columns("Id").Caption = "Идентификатор"
                            .Columns("Id").BestFit()
                            .Columns("Name").Caption = "Наименование"
                            .Focus()
                        End With
                    End If
                Case 5 ' -- место взыскания
                    _SelectedTab = sender.SelectedPageIndex + 1
                    IsFirstLoad = InverterBoolean(iDataSet.Tables.Contains("DecisionDirections." & Me.Name))

                    SelectQueryData("DecisionDirections." & Me.Name, "EXEC Pr_BooksFlat @Function = 1, @SelectNumber = " & _SelectedTab)
                    ' при первой актвации вкладки
                    If IsFirstLoad Then
                        Me.gcDecisionDirections.DataSource = iDataSet.Tables("DecisionDirections." & Me.Name)
                        With Me.gvDecisionDirections
                            .Columns("Id").Caption = "Идентификатор"
                            .Columns("Id").BestFit()
                            .Columns("Name").Caption = "Наименование"
                            .Focus()
                        End With
                    End If
                Case 6 ' -- статьи взыскания
                    _SelectedTab = sender.SelectedPageIndex + 1
                    IsFirstLoad = InverterBoolean(iDataSet.Tables.Contains("EnergyTypes." & Me.Name))

                    SelectQueryData("EnergyTypes." & Me.Name, "EXEC Pr_BooksFlat @Function = 1, @SelectNumber = " & _SelectedTab)
                    ' при первой актвации вкладки
                    If IsFirstLoad Then
                        Me.gcEnergyTypes.DataSource = iDataSet.Tables("EnergyTypes." & Me.Name)
                        With Me.gvEnergyTypes
                            .Columns("Id").Caption = "Идентификатор"
                            .Columns("Id").BestFit()
                            .Columns("Name").Caption = "Наименование"
                            .Columns("NameShort").Caption = "Код статьи"
                            .Focus()
                        End With
                    End If
                Case 7 ' -- итоги слушания
                    _SelectedTab = sender.SelectedPageIndex + 1
                    IsFirstLoad = InverterBoolean(iDataSet.Tables.Contains("ListeningType." & Me.Name))

                    SelectQueryData("ListeningType." & Me.Name, "EXEC Pr_BooksFlat @Function = 1, @SelectNumber = " & _SelectedTab)
                    ' при первой актвации вкладки
                    If IsFirstLoad Then
                        Me.gcListeningType.DataSource = iDataSet.Tables("ListeningType." & Me.Name)
                        With Me.gvListeningType
                            .Columns("Id").Caption = "Идентификатор"
                            .Columns("Id").BestFit()
                            .Columns("Name").Caption = "Наименование"
                            .Focus()
                        End With
                    End If
                Case 8 ' -- причины окончания
                    _SelectedTab = sender.SelectedPageIndex + 1
                    IsFirstLoad = InverterBoolean(iDataSet.Tables.Contains("ReasonForEnd." & Me.Name))

                    SelectQueryData("ReasonForEnd." & Me.Name, "EXEC Pr_BooksFlat @Function = 1, @SelectNumber = " & _SelectedTab)
                    ' при первой актвации вкладки
                    If IsFirstLoad Then
                        Me.gcReasonForEnd.DataSource = iDataSet.Tables("ReasonForEnd." & Me.Name)
                        With Me.gvReasonForEnd
                            .Columns("Id").Caption = "Идентификатор"
                            .Columns("Id").BestFit()
                            .Columns("Name").Caption = "Наименование"
                            .Focus()
                        End With
                    End If
                Case 9 ' -- статус платежного поручения
                    _SelectedTab = sender.SelectedPageIndex + 1
                    IsFirstLoad = InverterBoolean(iDataSet.Tables.Contains("PayOrderStatus." & Me.Name))

                    SelectQueryData("PayOrderStatus." & Me.Name, "EXEC Pr_BooksFlat @Function = 1, @SelectNumber = " & _SelectedTab)
                    ' при первой актвации вкладки
                    If IsFirstLoad Then
                        Me.gcPayOrderStatus.DataSource = iDataSet.Tables("PayOrderStatus." & Me.Name)
                        With Me.gvPayOrderStatus
                            .Columns("Id").Caption = "Идентификатор"
                            .Columns("Id").BestFit()
                            .Columns("Name").Caption = "Наименование"
                            .Focus()
                        End With
                    End If
                Case 10 ' -- виды журналов
                    _SelectedTab = sender.SelectedPageIndex + 1
                    IsFirstLoad = InverterBoolean(iDataSet.Tables.Contains("JournaType." & Me.Name))

                    SelectQueryData("JournaType." & Me.Name, "EXEC Pr_BooksFlat @Function = 1, @SelectNumber = " & _SelectedTab)
                    SelectQueryData("JournalDocumentsType." & Me.Name, "EXEC Pr_BooksFlat @Function = 1, @SelectNumber = " & _SelectedTab + 1)

                    If iDataSet.Relations.Contains("Типы документов для журнала") = False Then
                        iDataSet.Relations.Add("Типы документов для журнала", _
                        iDataSet.Tables("JournaType." & Me.Name).Columns("CodJournalId"), _
                        iDataSet.Tables("JournalDocumentsType." & Me.Name).Columns("CodParentJournalId"), False
                         )
                    End If

                    If IsFirstLoad Then
                        Me.gcJournaType.DataSource = iDataSet.Tables("JournaType." & Me.Name)
                        With Me.gvJournaType
                            .Columns("CodJournalId").Caption = "Код"
                            .Columns("Name").Caption = "Наименование журнала"
                            .Columns("SaveTimeYear").Caption = "Срок хранения,лет"
                            .Columns("ArticleNumber").Caption = "Артикль"
                            .Focus()
                            .BestFitColumns(True)
                        End With
                    End If
                Case 11 ' -- статус журнала
                    _SelectedTab = sender.SelectedPageIndex + 2
                    IsFirstLoad = InverterBoolean(iDataSet.Tables.Contains("JournalStatus." & Me.Name))

                    SelectQueryData("JournalStatus." & Me.Name, "EXEC Pr_BooksFlat @Function = 1, @SelectNumber = " & _SelectedTab)
                    ' при первой актвации вкладки
                    If IsFirstLoad Then
                        Me.gcJournalStatus.DataSource = iDataSet.Tables("JournalStatus." & Me.Name)
                        With Me.gvJournalStatus
                            .Columns("Id").Caption = "Идентификатор"
                            .Columns("Id").BestFit()
                            .Columns("Name").Caption = "Наименование"
                            .Focus()
                        End With
                    End If
                Case 12 ' -- части города
                    _SelectedTab = sender.SelectedPageIndex + 2
                    IsFirstLoad = InverterBoolean(iDataSet.Tables.Contains("CityParts." & Me.Name))

                    SelectQueryData("CityParts." & Me.Name, "EXEC Pr_BooksFlat @Function = 1, @SelectNumber = " & _SelectedTab)
                    ' при первой актвации вкладки
                    If IsFirstLoad Then
                        Me.gcCityParts.DataSource = iDataSet.Tables("CityParts." & Me.Name)
                        With Me.gvCityParts
                            .Columns("Id").Caption = "Идентификатор"
                            .Columns("Id").BestFit()
                            .Columns("Name").Caption = "Наименование"
                            .Focus()
                        End With
                    End If
            End Select
        End If
    End Sub
    ' Отмена сворачивания панели при повторном клике на вкладку
    Private Sub npMain_StateChanged(sender As System.Object, e As DevExpress.XtraBars.Navigation.StateChangedEventArgs) Handles npMain.StateChanged
        npMain.State = DevExpress.XtraBars.Navigation.NavigationPaneState.Default
    End Sub
    ' разворот строки по двойному клику где MasterDetail
    Private Sub gv_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles gvJournaType.RowClick, gvDecisionType.RowClick
        If e.Clicks = 2 Then
            sender.SetMasterRowExpanded(e.RowHandle, InverterBoolean(sender.GetMasterRowExpanded(e.RowHandle)))
        End If
    End Sub
    ' при развороте MasterDetail подсвечиваем родительскую строку
    Private Sub gv_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gvJournaType.RowStyle, gvDecisionType.RowStyle
        Dim View As GridView = sender
        If (e.RowHandle >= 0) Then
            If View.GetMasterRowExpanded(e.RowHandle) Then
                e.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline)
            End If
        End If
    End Sub

#Region "ПИР.Виды и причины решений"
    ' разворот строки с видом решения
    Private Sub gvDecisionType_MasterRowExpanded(sender As System.Object, e As DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs) Handles gvDecisionType.MasterRowExpanded
        Dim gv As GridView
        If e.RowHandle >= 0 Then
            For i = 1 To sender.GridControl.Views.Count - 1
                gv = Me.gcDecisionType.Views.Item(i)
                With gv
                    .Columns("Id").Visible = False
                    .Columns("ExtId").Caption = "Код"
                    .Columns("ExtId").BestFit()
                    .Columns("Name").Caption = "Наименование причины"
                End With
            Next
        End If
    End Sub
    ' свернуть / развернуть узлы Типы решений суда
    Private Sub pgDecisionType_CustomButtonClick(sender As System.Object, e As DevExpress.XtraBars.Docking2010.ButtonEventArgs) Handles pgDecisionType.CustomButtonClick
        Me.Cursor = Cursors.WaitCursor
        Select Case e.Button.Properties.Caption
            Case 0 ' Свернуть узлы
                For r = 0 To Me.gvDecisionType.RowCount - 1
                    Me.gvDecisionType.SetMasterRowExpanded(r, True)
                Next
            Case 1 ' Развернуть узлы
                For r = 0 To Me.gvDecisionType.RowCount - 1
                    Me.gvDecisionType.SetMasterRowExpanded(r, False)
                Next
        End Select
        Me.Cursor = Cursors.Default
    End Sub
#End Region

#Region "Журналы.Виды журналов"
    ' разворот строки с типом журнала
    Private Sub gvJournaType_MasterRowExpanded(sender As System.Object, e As DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs) Handles gvJournaType.MasterRowExpanded
        Dim gv As GridView
        If e.RowHandle >= 0 Then
            For i = 1 To sender.GridControl.Views.Count - 1
                gv = Me.gcJournaType.Views.Item(i)
                With gv
                    .Columns("CodJournalId").Caption = "Код док-та"
                    .Columns("CodParentJournalId").Visible = False
                    .Columns("Name").Caption = "Наименование документа"
                    .Columns("SaveTimeYear").Caption = "Срок хранения,лет"
                    .Columns("ArticleNumber").Caption = "Артикль"
                    .BestFitColumns()
                End With
            Next
        End If
    End Sub
    ' свернуть / развернуть узлы Типы журналов
    Private Sub pgJournaType_CustomButtonClick(sender As System.Object, e As DevExpress.XtraBars.Docking2010.ButtonEventArgs) Handles pgJournaType.CustomButtonClick
        Me.Cursor = Cursors.WaitCursor
        Select Case e.Button.Properties.Caption
            Case 0 ' Свернуть узлы
                For r = 0 To Me.gvJournaType.RowCount - 1
                    Me.gvJournaType.SetMasterRowExpanded(r, True)
                Next
            Case 1 ' Развернуть узлы
                For r = 0 To Me.gvJournaType.RowCount - 1
                    Me.gvJournaType.SetMasterRowExpanded(r, False)
                Next
        End Select
        Me.Cursor = Cursors.Default
    End Sub
#End Region

#Region "Части города"
    ' Части города. Добавить. Изменить. Удалить
    Private Sub pgCityParts_CustomButtonClick(sender As System.Object, e As DevExpress.XtraBars.Docking2010.ButtonEventArgs) Handles pgCityParts.CustomButtonClick
        Dim _row As Integer = Me.gvCityParts.FocusedRowHandle   ' текушая строка
        Dim _XtraInputBox As New XtraInputBoxArgs()             ' диалог для ввода значений
        Dim result As String                                    ' результат из диалога
        Dim editor As New TextEdit                              ' тип редактора в диалоге
        editor.Properties.MaxLength = 50                        ' макс кол-во знаков редакторе 
        editor.Properties.NullValuePromptShowForEmptyValue = True
        editor.Properties.ShowNullValuePromptWhenFocused = True
        editor.Properties.NullValuePrompt = "Введите часть города (до " & editor.Properties.MaxLength & " символов)"
        _XtraInputBox.Editor = editor
        _XtraInputBox.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True
        _XtraInputBox.Prompt = "<b><u>Наименование части города</b></u>"
        _XtraInputBox.DefaultButtonIndex = 0

        Select Case e.Button.Properties.Caption
            Case 0 ' Добавить
                _XtraInputBox.Caption = "Создать часть города"
                result = "'" & Trim(XtraInputBox.Show(_XtraInputBox)) & "'"
                If result <> "''" Then
                    ExecuteQuery(
                        "EXEC Pr_BooksFlat " &
                            "@Name = " & result & ", " &
                            "@Function = 2, " &
                            "@SelectNumber = " & _SelectedTab,
                        "AddCityPart"
                                )
                    _row = Me.gvCityParts.RowCount
                End If
            Case 1 ' Изменить
                _XtraInputBox.Caption = "Редактировать часть города"
                _XtraInputBox.DefaultResponse = Me.gvCityParts.GetFocusedRowCellDisplayText("Name")
                result = "'" & Trim(XtraInputBox.Show(_XtraInputBox)) & "'"
                If result <> "''" Then
                    ExecuteQuery(
                        "EXEC Pr_BooksFlat " &
                            "@Id = " & Me.gvCityParts.GetFocusedRowCellDisplayText("Id") & ", " &
                            "@Name = " & result & ", " &
                            "@Function = 3, " &
                            "@SelectNumber = " & _SelectedTab,
                        "EditCityPart"
                                )
                End If
            Case 2 ' Удалить
                If Me.gvCityParts.RowCount = 0 Then Exit Sub
                If XtraMessageBox.Show("Часть города <u><b>" & Me.gvCityParts.GetFocusedRowCellDisplayText("Name") & "</u></b> будет удалена!" & Chr(10) &
                                       "Вы согласны?",
                                       Application.ProductName,
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Question,
                                       DevExpress.Utils.DefaultBoolean.True
                                       ) = Windows.Forms.DialogResult.Yes Then
                    ExecuteQuery(
                        "EXEC Pr_BooksFlat " &
                            "@Id = " & Me.gvCityParts.GetFocusedRowCellDisplayText("Id") & ", " &
                            "@Function = 4, " &
                            "@SelectNumber = " & _SelectedTab,
                        "DeleteCityPart"
                                )
                    _row = _row - 1
                End If
        End Select
        ' обновление данных в таблице
        SelectQueryData("CityParts." & Me.Name, "EXEC Pr_BooksFlat @Function = 1, @SelectNumber = " & _SelectedTab)
        Me.gvCityParts.FocusedRowHandle = _row
        Me.gvCityParts.SelectRow(_row)
        Me.Cursor = Cursors.Default
    End Sub
    ' удаление части города по Delete
    Private Sub gvCityParts_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles gvCityParts.KeyDown
        ' переменная с кнопкой, событие которой далее запускается
        Dim btn As New DevExpress.XtraBars.Docking2010.ButtonEventArgs(pgCityParts.CustomHeaderButtons.Item("2"))
        If e.KeyCode = Keys.Delete Then
            pgCityParts_CustomButtonClick(sender, btn)
        End If
    End Sub
    ' редактирование Части города по Enter
    Private Sub gvCityParts_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles gvCityParts.MouseDown
        Dim view As GridView = CType(sender, GridView)
        Dim pt As Point = view.GridControl.PointToClient(Control.MousePosition)
        Dim info As GridHitInfo = view.CalcHitInfo(pt)
        Dim btn As New DevExpress.XtraBars.Docking2010.ButtonEventArgs(pgCityParts.CustomHeaderButtons.Item("1"))
        ' если клик двойной и по строке а не вне ее
        If e.Clicks = 2 And info.InRow Then
            pgCityParts_CustomButtonClick(sender, btn)
        End If
    End Sub
#End Region
End Class