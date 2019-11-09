Imports DevExpress.XtraTreeList
Imports DevExpress.XtraEditors
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraEditors.Controls

Public Class frDocRegistration
    Dim ShowJournals As Boolean     ' Скрыть / показать журналы
    Dim PreferenceForms As String   ' Ветка в реестре для хранения настроек формы 
    Dim ProcedureName As String     ' Имя процедуры каторая выполнит регистрацию

    Private Sub frDocRegistration_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        RemoveTableDataSet(Me)
        RegistryWrite(PreferenceForms, "btnHideEmptyJournal", Convert.ToInt32(ShowJournals))
        Me.Dispose()
        frMain.Show()
        frMain.NotifyIcon.Visible = False
        frMain.Time.Enabled = True
    End Sub

    Private Sub frDocRegistration_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PreferenceForms = pref_UserSettings & "\" & Me.Name & "\"
        ShowJournals = Convert.ToBoolean(Convert.ToInt32(RegistryRead(PreferenceForms, "btnHideEmptyJournal", "0")))
        LoadJournalTree(Me.TV_JournalList, "JournalsTree." & Me.Name, 0, 0, Convert.ToBoolean(ShowJournals))
        If ShowJournals Then 
            Me.btnHideEmptyJournal.Image = My.Resources.show_32x32
        Else
            Me.btnHideEmptyJournal.Image = My.Resources.hide_32x32
        End If
        ' создаем таблицу в датаСете для хранения зарегистрированных документов
        iDataSet.Tables.Add("DocumentsId." & Me.Name)
        iDataSet.Tables("DocumentsId." & Me.Name).Columns.Add("DocId")

        Me.txtSumDoc.Enabled = False
        Me.tlpManager.ColumnStyles(1).SizeType = SizeType.Absolute
        Me.tlpManager.ColumnStyles(1).Width = 0
        Me.tlpManager.ColumnStyles(2).SizeType = SizeType.Absolute
        Me.tlpManager.ColumnStyles(2).Width = 0
        ProcedureName = ""
    End Sub

#Region "Заполнение дерева журналов (НЕ Исползуется)"
    Private Sub FillJournalList()
        ' Выгружаем список видов журналов
        SelectQueryData(
                        "JournalList." & Me.Name,
                        "SELECT * FROM vPr_JournalsList",
                        Me.Name & ".GetJournalList"
                        )
        XndStr_Level_0 = Nothing
        For Each iDataRow As DataRow In iDataSet.Tables("JournalList." & Me.Name).Rows
            If iDataRow("JournalName") <> XndStr_Level_0 Then
                XndLevel_0 = Me.TV_JournalList.Nodes.Add(
                                                         iDataRow("JournalName"),
                                                         iDataRow("ParentCodJournalId"),
                                                         iDataRow("CodJournalId"),
                                                         iDataRow("DocumentTypeId")
                                                         )

                XndStr_Level_0 = iDataRow("JournalName")
                FillJournalDocuments(iDataRow.Item("JournalName"))
            End If
        Next
        'Чистим переменные для других элементов
        XndStr_Level_0 = Nothing
        XndStr_Level_1 = Nothing
    End Sub
    Private Sub FillJournalDocuments(ByVal ParentNodeName As String)
        XndStr_Level_1 = Nothing
        For Each iDataRow As DataRow In iDataSet.Tables("JournalList." & Me.Name).Rows
            If iDataRow("JournalName") = ParentNodeName Then
                If iDataRow("DocumentsName") <> XndStr_Level_1 Then
                    XndLevel_1 = XndLevel_0.Nodes.Add(
                                                      iDataRow("DocumentsName"),
                                                      iDataRow("ParentCodJournalId"),
                                                      iDataRow("CodJournalId"),
                                                      iDataRow("DocumentTypeId")
                                                      )
                    XndStr_Level_1 = iDataRow("DocumentsName")
                End If
            End If
        Next iDataRow
    End Sub
#End Region

    Private Sub txtAbonentNumber_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtAbonentNumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            MoneyTextBox_EnterLeave(sender, e, "Click", "G0")
            GetAbonentsInformation(sender.Text)
        End If
    End Sub
    ' Запрет на символы не цыфры
    Private Sub txtAbonentNumber_Properties_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAbonentNumber.KeyPress
        If Not Char.IsDigit(e.KeyChar) And e.KeyChar <> vbBack Then
            e.Handled = True 'блокировка
        End If
    End Sub
    Private Sub txtAbonentNumber_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAbonentNumber.Leave
        MoneyTextBox_EnterLeave(sender, e, "Leave", "N0")
        iEnter = False ' Выход из поля состоялся
    End Sub
    Private Sub txtAbonentNumber_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAbonentNumber.Click
        MoneyTextBox_EnterLeave(sender, e, "Click", "G0")
        ' Если первый вход в поле контрола
        If iEnter = False Then
            sender.SelectAll()      ' Выделяем весь текст
            iEnter = True           ' Вход состоялся
        End If
    End Sub

    ' Контекстные кнопки в текстовом поле
    Private Sub txtAbonentNumber_Properties_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtAbonentNumber.Properties.ButtonClick
        Dim btn As EditorButton = e.Button
        Select Case btn.Index
            Case 0 ' Очистить поле
                sender.Text = Nothing
            Case 1 ' Поиск данных
                GetAbonentsInformation(sender.Text)
        End Select
    End Sub

    ' Развернуть все узлы
    Private Sub btnExpandAll_Click(sender As System.Object, e As System.EventArgs) Handles btnExpandAll.Click
        Me.TV_JournalList.ExpandAll()
    End Sub
    ' Свернуть все узлы
    Private Sub btnCollapseAll_Click(sender As System.Object, e As System.EventArgs) Handles btnCollapseAll.Click
        Me.TV_JournalList.CollapseAll()
    End Sub
    ' Показать/Скрыть панель поиска
    Private Sub btnFindJournal_Click(sender As System.Object, e As System.EventArgs) Handles btnFindJournal.Click
        If Me.TV_JournalList.OptionsFind.AllowFindPanel Then
            Me.TV_JournalList.OptionsFind.AllowFindPanel = False
        Else
            Me.TV_JournalList.OptionsFind.AllowFindPanel = True
        End If
    End Sub
    ' Открыть журнал
    Private Sub btnOpenJournal_Click(sender As System.Object, e As System.EventArgs) Handles btnOpenJournal.Click
        XtraMessageBox.Show("На данный момен архивариус журналов на стадии разработки!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    ' Скрыть / показать журналы без присвоеных документов
    Private Sub btnHideEmptyJournal_Click(sender As System.Object, e As System.EventArgs) Handles btnHideEmptyJournal.Click
        If ShowJournals Then 
            Me.btnHideEmptyJournal.Image = My.Resources.hide_32x32
        Else
            Me.btnHideEmptyJournal.Image = My.Resources.show_32x32
        End If
        ShowJournals = InverterBoolean(ShowJournals)
        LoadJournalTree(Me.TV_JournalList, "JournalsTree." & Me.Name, 0, Convert.ToInt64(ShowJournals))
    End Sub
    ' Выбор журнала
    Private Sub TV_JournalList_AfterFocusNode(sender As Object, e As DevExpress.XtraTreeList.NodeEventArgs) Handles TV_JournalList.AfterFocusNode
        Dim nD As TreeListNode = sender.Selection(0)
        Dim dtId As Integer
        ' Проверяем уровень выбранного узла
        Select Case e.Node.Level
            Case 0
                Me.btnRegistration.Enabled = False
            Case 1
                If IsDBNull(nD.Item("DocumentTypeId")) Then
                    dtId = 0
                Else
                    dtId = nD.Item("DocumentTypeId")
                End If
                ' Проверяем тип документа
                Select Case dtId
                    Case 1 To 8
                        Me.txtSumDoc.Enabled = True
                        Me.tlpManager.ColumnStyles(1).SizeType = SizeType.AutoSize
                        Me.tlpManager.ColumnStyles(2).SizeType = SizeType.AutoSize
                        ProcedureName = "Pr_JournalDocRegistration"
                    Case Else
                        Me.txtSumDoc.Enabled = False
                        Me.tlpManager.ColumnStyles(1).SizeType = SizeType.Absolute
                        Me.tlpManager.ColumnStyles(1).Width = 0
                        Me.tlpManager.ColumnStyles(2).SizeType = SizeType.Absolute
                        Me.tlpManager.ColumnStyles(2).Width = 0
                        ProcedureName = ""
                End Select
        End Select
        Me.btnRegistration.Enabled = False
    End Sub
    ' регистрация документа
    Private Sub btnRegistration_Click(sender As System.Object, e As System.EventArgs) Handles btnRegistration.Click
        Dim nD As TreeListNode = Me.TV_JournalList.Selection(0)
        Dim iRow As DataRow = iDataSet.Tables("AbonentsInfo." & Me.Name).Rows(0)
        If Me.TV_JournalList.Selection(0).Level <> 1 Then
            XtraMessageBox.Show("Не выбран тип документа для регистрации в журнале!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        If SelectQueryData(
                        "RegNumber." & Me.Name,
                        "EXEC Pr_JournalDocRegistration " & _
                                "@DocumentTypeId = " & nD.Item("DocumentTypeId") & ", " & _
                                "@SessionId = NULL, " & _
                                "@AbonentId = " & iRow("AbonentId") & ", " & _
                                "@FamilyMemberId = " & iRow("FamilyMemberId") & ", " & _
                                "@AbonentNumber = '" & iRow("AbonentNumber") & "', " & _
                                "@SNP_short = '" & iRow("SNP_short") & "', " & _
                                "@AddressString = '" & iRow("AddressString") & "', " & _
                                "@SumDoc = " & Me.txtSumDoc.Text & ", " & _
                                "@ControllerId = " & iRow("ControllerId") & ", " & _
                                "@DtDoc = '" & iRow("DtDoc") & "', " & _
                                "@DtBeginOio = '" & iRow("DtBeginOio") & "', " & _
                                "@Function = 2"
                        ) Then

            Me.lbRegNumber.Text = "№ " & iDataSet.Tables("RegNumber." & Me.Name).Rows(0).Item("DocNumber")
            With New frInfo
                .Mess = "Документ " & Me.lbRegNumber.Text & Chr(10) & " зарегистрирован!"
                .Show()     ' Всплываюшее сообщение
            End With
            iDataSet.Tables("DocumentsId." & Me.Name).Rows.Add(iDataSet.Tables("RegNumber." & Me.Name).Rows(0).Item("DocId"))

            Me.btnDeleteLastDocument.Visible = True
        End If
        Me.txtAbonentNumber.Focus()
        Me.txtAbonentNumber.SelectAll()
    End Sub

    ' получаем из базы информацию по лицевому
    Private Sub GetAbonentsInformation(ByVal AbonentNumber As String)
        Dim nD As TreeListNode = Me.TV_JournalList.Selection(0)
        If Me.TV_JournalList.Selection(0).Level <> 1 Then
            XtraMessageBox.Show("Не выбран тип документа для регистрации в журнале!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.txtAbonentNumber.EnterMoveNextControl = False
            Me.lbSNP_short.Text = Nothing
            Me.lbAddressString.Text = Nothing
            Me.btnRegistration.Enabled = False
            Me.txtAbonentNumber.SelectAll()
            Exit Sub
        End If
        If AbonentNumber = "" Then
            XtraMessageBox.Show("Введен некорректный номер лицевого счета!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.txtAbonentNumber.EnterMoveNextControl = False
            Me.lbSNP_short.Text = Nothing
            Me.lbAddressString.Text = Nothing
            Me.btnRegistration.Enabled = False
            Me.txtAbonentNumber.SelectAll()
            Exit Sub
        End If
        If AbonentNumber.Length < 12 Then
            XtraMessageBox.Show("Введен не полный номер лицевого счета!" & Chr(10) & "Номер лицевого счета = 12 символов",
                                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.txtAbonentNumber.EnterMoveNextControl = False
            Me.lbSNP_short.Text = Nothing
            Me.lbAddressString.Text = Nothing
            Me.btnRegistration.Enabled = False
            Me.txtAbonentNumber.SelectAll()
            Exit Sub
        End If
        ' Выгружаем информацию по абоненту
        If SelectQueryData(
                            "AbonentsInfo." & Me.Name,
                            "EXEC Pr_JournalDocRegistration " & _
                                "@AbonentNumber = '" & Replace(AbonentNumber, " ", "") & "', " & _
                                "@DocumentTypeId = " & nD.Item("DocumentTypeId") & ", " & _
                                "@Function = 1",
                            "Pr_JournalDocRegistration @Function = 1"
                            ) Then
            Me.txtAbonentNumber.EnterMoveNextControl = True
            Me.btnRegistration.Enabled = True
            Dim iRow As DataRow = iDataSet.Tables("AbonentsInfo." & Me.Name).Rows(0)
            Me.lbSNP_short.Text = iRow("SNP_short")
            Me.lbAddressString.Text = iRow("AddressString")
        Else
            Me.lbSNP_short.Text = Nothing
            Me.lbAddressString.Text = Nothing
            Me.txtAbonentNumber.EnterMoveNextControl = False
            Me.btnRegistration.Enabled = False
            Me.txtAbonentNumber.SelectAll()
            Exit Sub
        End If

    End Sub
    ' удаление последнего зарегистрированного документа
    Private Sub btnDeleteLastDocument_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteLastDocument.Click
        If iDataSet.Tables("DocumentsId." & Me.Name).Rows.Count <> 0 Then
            Dim LastRowIndex As Integer = iDataSet.Tables("DocumentsId." & Me.Name).Rows.Count - 1
            Dim LastRowValue As Integer = iDataSet.Tables("DocumentsId." & Me.Name).Rows(LastRowIndex).Item("DocId")
            ' Получаем информацию о документе
            SelectQueryData("DocumentsInfo." & Me.Name,
                            "EXEC Pr_JournalDocRegistration " & _
                                "@DocId = " & LastRowValue & ", " & _
                                "@Function = 1, " & _
                                "@Parameter = 2",
                            "GetDocumentsInformation"
                            )
            Dim iRow As DataRow = iDataSet.Tables("DocumentsInfo." & Me.Name).Rows(0)
            If XtraMessageBox.Show(
                                    "Удаление зарегистрированного документа:" & Chr(10) & _
                                    "   Дата - <u><b>№ " & iRow("DtDoc") & "</b></u>" & Chr(10) & _
                                    "   Номер - <u><b>" & iRow("Number") & "</b></u>" & Chr(10) & _
                                    "   Номер абонента - <u><b>" & iRow("AbonentNumber") & "</b></u>" & Chr(10) & _
                                    "   ФИО потребителя - <u><b>" & iRow("SNP_short") & "</b></u>" & Chr(10) & _
                                    "   Адрес потребителя <u><b>" & iRow("AddressString") & "</b></u>" & Chr(10) & _
                                    "   Сумма документа - <u><b>" & OutBD_Money(iRow.Item("SumDoc"), 0, "N") & " руб.</b></u>" & Chr(10) & _
                                    "   Тип документа - <u><b>" & iRow("DocumentsType") & "</b></u>" & Chr(10) & _
                                    "   Автор - <u><b>" & iRow("Author") & "</b></u>" & Chr(10) & _
                                    "Вы согласны?",
                Application.ProductName,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                DevExpress.Utils.DefaultBoolean.True
                                    ) = Windows.Forms.DialogResult.Yes Then
                ' Сначала удаляем из базы
                If IsNothing(ExecuteScalar("EXEC Pr_JournalDocRegistration " & _
                                                "@DocId = " & LastRowValue & ", " & _
                                                "@Function = 4")) Then
                    iDataSet.Tables("DocumentsId." & Me.Name).Rows(LastRowIndex).Delete()
                    With New frInfo
                        .Mess = "Документ № " & iRow("Number") & Chr(10) & "от " & iRow("DtDoc") & "успешно удален!"
                        .Show()     ' Всплываюшее сообщение
                    End With
                End If
            End If
        Else
            XtraMessageBox.Show("Регистрационный кэш записей регистрации пуст!",
                                    Application.ProductName,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information)
        End If
    End Sub
End Class