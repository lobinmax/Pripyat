Imports System.Drawing.Color
Imports System.Drawing.SystemColors ' Импорт пространства системной политры
Imports FastReport
Imports FastReport.Preview
Imports System.IO
Imports DevExpress.XtraEditors

Public Class frAbonents
    Dim WithEvents TextControl As TextBox               ' Для запрета редактирования DataGrida
    Dim ProperyGrid_GenInfo As New clsGeneralInfo       ' Класс для PropertyGrid_GenInfo
    Dim FirstLoad_PanAbonentNum As Boolean = True       ' Первая активация панели Pan_AbonentNum или нет
    Dim FirstLoad_PanGeneralInfo As Boolean = True      ' Первая активация панели Pan_AbonentNum или нет
    Dim FirstLoad_Pan_Members As Boolean = True         ' Первая активация панели Pan_AbonentNum или нет
    Dim FirstLoad_Pan_1_Suit As Boolean = True          ' Первая активация панели Pan_1_Suit или нет

    ' Общие процедуры
    ' ===================================================================================================================================
    Private Sub frAbonents_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        ' После закрытия формы открывается главное окно 
        frMain.Show()
        frMain.NotifyIcon.Visible = False
        frMain.Time.Enabled = True
    End Sub

    Private Sub frAbonents_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Size = New Point(1070, 720)
        ' Скрываем язычки вкладок
        MainTabControl.ItemSize = New System.Drawing.Size(0, 1)
        ' Настройка TreeView
        Me.TreeView.SelectedNode = Me.TreeView.Nodes(0) ' Активный Нод
        ' Развернутые НОДЫ
        Me.TreeView.Nodes(0).Expand()
        Me.TreeView.Nodes(0).Nodes(0).Expand()
        Me.TreeView.Nodes(0).Nodes(1).Expand()
        Me.TreeView.Nodes(0).Nodes(2).Expand()
        Me.TreeView.Nodes(0).Nodes(2).Nodes(0).Expand()
        Me.TreeView.Nodes(0).Nodes(2).Nodes(1).Expand()
        ' Разворачиваем все панели в SplitContainer.Panel2
        ' For Each Pan As Panel In Me.SplitContainer.Panel2.Controls
        ' Pan.Parent = Me.SplitContainer.Panel2   ' Родитель панели
        ' Pan.Dock = DockStyle.Fill               ' Закрепляем в родителе
        ' Next
    End Sub
    ' ===================================================================================================================================
    ' События ToolStrip (Верхняя панель с кнопками)
    ' ===================================================================================================================================
    Private Sub ToolStrip_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStrip_Search.Click
        ' Проверка изменений в записях по ПИР
        If Me.PIR1_Btn_SavePetitionDebt.Enabled Then
            ' Вопрос сохранить или нет
            Select Case XtraMessageBox.Show("На вкладке <Притензионно - исковой работы> имеются не сохраненне изменения." & Chr(10) &
                                        "Сохранить изменения в безе данных?",
                                        Application.ProductName, MessageBoxButtons.YesNoCancel,
                                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                Case DialogResult.Yes
                    PIR1_Btn_SavePetitionDebt_Click(sender, e)  ' Нажимаем кнопку Сохранить данные по иску
                    Exit Sub
                Case DialogResult.No
                    ClickTree_Pan_1_Suit()                      ' Просто обновляем панель
                Case DialogResult.Cancel
                    Exit Sub                                    ' Просто обновляем панель
            End Select
        End If

        ' ///При запуске поиска записывается переменная активного нода
        ' ///и в зависимости от этого выполняется тот или иной SELECT после поиска абонента

        ' Переменная для хранения активного НОДА дерева
        Dim ActiveNodTreeView As String = Me.TreeView.SelectedNode.Name

        MessageStatusStrip("Поиск лицего счета...", Processing)     ' Сообщение об операции

        ' Диалог для поиска абонента
        If frSearchAbonent.ShowDialog = Windows.Forms.DialogResult.OK Then
            MessageStatusStrip("Загрузка данных...", Processing)        ' Сообщение об операции

            GetGeneralInfo()    ' Запрос на выборку основной информации по абоненту
            '                     Номер л\с в первом Ноде
            Me.TreeView.Nodes(0).Text = "Абонент (" & Me.txt_AbonNumber.Text & ")"

            Select Case ActiveNodTreeView
                Case "GeneralInfo"
                    ' Запрос на выборку истории членов семьи по абоненту
                    SelectQueryData(
                                    "FamilyMember", _
 _
                                    "SELECT * " & _
                                    "FROM vFamilyMembers  " & _
                                    "WHERE AbonentId =" & pref_AbonentId, _
 _
                                    "FamilyMember.Kwz"
                                    )
                    ' Настройка ProperyGrid_GenInfo
                    DesignerProperyGrid_GenInfo()

                Case "Members"
                    ClickTree_PanMembers()

                Case "Pir"
                    ClickTree_Pan_1_Suit()

                Case "Suit_1"
                    ClickTree_Pan_1_Suit()
            End Select

            MessageStatusStrip("Готово...", Processing)             ' Сообщение об операции
        End If
        frSearchAbonent.Dispose()
    End Sub

    ' События TreeView
    ' ===================================================================================================================================
    Private Sub TreeView_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView.AfterSelect
        Me.MainTabControl.SelectTab(e.Node.Name) ' Активируем вкладку с именем совпадающим с деревом
        ' На каждой вкладке свои процедуры
        Select Case e.Node().Name
            Case "AbonentNum" ' +++++++++++ Вкладка "Абонент"
                MessageStatusStrip("Загрузка данных по абоненту...", Processing)            ' Сообщение об операции
                GetGeneralInfo()                                                            ' Запрос на выборку основной информации по абоненту
                ' Если панель активирована впервый раз, выполняем процедуры которые потом будут не нужны
                If FirstLoad_PanAbonentNum Then
                    DesignerDataGrid_AbonStatusHistory()                                    ' Настройка Грида AbonStatusHistory
                    FillElements_PanAbonentNum()                                            ' Разноска информации по элементам панели
                End If
                Me.TreeView.Nodes(0).Text = "Абонент (" & Me.txt_AbonNumber.Text & ")"      ' Номер л\с в первом Ноде
                MessageStatusStrip("Готово...", Processing)                                 ' Сообщение об операции
                FirstLoad_PanAbonentNum = False                                             ' Первая активация PanAbonentNum состоялась

            Case "GeneralInfo" ' +++++++++++ Вкладка "Общая информация"
                MessageStatusStrip("Загрузка основной информации...", Processing)           ' Сообщение об операции
                ' Запрос на выборку истории членов семьи по абоненту
                SelectQueryData(
                                "FamilyMember", _
 _
                                "SELECT * " & _
                                "FROM vFamilyMembers  " & _
                                "WHERE AbonentId =" & pref_AbonentId, _
 _
                                "FamilyMember.Kwz"
                                )
                ' Настройка ProperyGrid_GenInfo
                DesignerProperyGrid_GenInfo()
                ' Если панель активирована впервый раз, выполняем процедуры которые потом будут не нужны
                If FirstLoad_PanGeneralInfo Then DesignerDataGrid_FamilyMember() '            Настройка DataGrid_FamilyMember
                MessageStatusStrip("Готово...", Processing)                                 ' Сообщение об операции
                FirstLoad_PanAbonentNum = False                                             ' Первая активация PanAbonentNum состоялась

                ' +++++++++++ Вкладка "Члены семьи"
            Case "Members"
                ClickTree_PanMembers()

                ' +++++++++++ Вкладка "ПИР. Электроэнергия. Иски"
            Case "EventsDeb_1"

            Case "EventsDeb_1"

            Case "EventsDeb_5"

            Case "Pir"
                ClickTree_Pan_1_Suit()

            Case "Suit_1"
                ClickTree_Pan_1_Suit()

            Case "Request_1"

            Case "Deduction_1"

            Case "Guarantee_1"

            Case "Roadstead_1"

            Case "Search_1"

            Case "Spisanie_1"

            Case "Suit_5"

            Case "Request_5"

            Case "Deduction_5"

            Case "Guarantee_5"

            Case "Roadstead_5"

            Case "Search_5"

            Case "Spisanie_5"

            Case "Suit_2"

            Case "Request_2"

            Case "Deduction_2"

            Case "Guarantee_2"

            Case "Roadstead_2"

            Case "Search_2"

            Case "Spisanie_2"

        End Select
    End Sub
    ' ===================================================================================================================================
#Region "СОБЫТИЯ НА ПАНЕЛЕ PAN_ABONENTNUM"
    ' ===================================================================================================================================
    Private Sub FillElements_PanAbonentNum()
        ' Разносим данные из базы по текстовым элементам Pan_AbonentNum
        GetRoomType() ' Выборка из бызы типов комнат
        Me.txt_AbonNumber.DataBindings.Add("Text", iDataSet.Tables("GenInfo"), "AbonNumber")
        Me.txt_FIO.DataBindings.Add("Text", iDataSet.Tables("GenInfo"), "Fio").ToString()
        Me.txt_Adress.DataBindings.Add("Text", iDataSet.Tables("GenInfo"), "Address").ToString()
        Me.txt_PostalIndex.DataBindings.Add("Text", iDataSet.Tables("GenInfo"), "PostIndex").ToString()
        Me.txt_AdressPart.DataBindings.Add("Text", iDataSet.Tables("GenInfo"), "AddressString").ToString()
        Me.txt_House.DataBindings.Add("Text", iDataSet.Tables("GenInfo"), "House").ToString()
        Me.txt_LetterHouse.DataBindings.Add("Text", iDataSet.Tables("GenInfo"), "LetterHouse").ToString()
        Me.txt_Build.DataBindings.Add("Text", iDataSet.Tables("GenInfo"), "Build").ToString()
        Me.txt_Section.DataBindings.Add("Text", iDataSet.Tables("GenInfo"), "Section").ToString()
        Me.txt_Room.DataBindings.Add("Text", iDataSet.Tables("GenInfo"), "Room").ToString()
        Me.txt_LetterRoom.DataBindings.Add("Text", iDataSet.Tables("GenInfo"), "LetterRoom").ToString()
        Me.Txt_HoteNote.DataBindings.Add("Text", iDataSet.Tables("GenInfo"), "HotNotes").ToString()
        With Me.cmb_RoomType
            .DataSource = iDataSet.Tables("RoomType")
            .DisplayMember = "name"
            .ValueMember = "RoomTypeId"
            .DataBindings.Add("Text", iDataSet.Tables("GenInfo"), "RoomTypes").ToString()
        End With
        Me.txt_RoomNumber.DataBindings.Add("Text", iDataSet.Tables("GenInfo"), "RoomNumber").ToString()
        Me.txt_AltAdress.DataBindings.Add("Text", iDataSet.Tables("GenInfo"), "AltAddress").ToString()
        With Me.cmb_Route
            '.DataSource = iDataSet.Tables("RoomType")
            '.DisplayMember = "Name"
            .DataBindings.Add("Text", iDataSet.Tables("GenInfo"), "Route").ToString()
        End With
        Me.txt_Controler.DataBindings.Add("Text", iDataSet.Tables("GenInfo"), "Controler").ToString()
        Me.txt_ChiefControler.DataBindings.Add("Text", iDataSet.Tables("GenInfo"), "ChiefControler").ToString()
        Me.txt_mail.DataBindings.Add("Text", iDataSet.Tables("GenInfo"), "email").ToString()
        Me.txt_MobileNumber.DataBindings.Add("Text", iDataSet.Tables("GenInfo"), "PhoneMobile").ToString()
        Me.txt_PhoneNumber.DataBindings.Add("Text", iDataSet.Tables("GenInfo"), "Phone").ToString()
    End Sub
    ' ===================================================================================================================================
    ' События txt_mail - Проверка корректности эл.адреса
    ' ===================================================================================================================================
    Private Sub txt_mail_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_mail.KeyPress
        Dim s As String = sender.Text
        Dim c As Integer = 0
        If e.KeyChar = "@" Then c = InStr(1, s, "@") '      Если введена @ то, считаем сколько их уже
        If c > 1 Then e.Handled = True : Beep() '           Если их больше одной то отменяем ввод
    End Sub
    Private Sub txt_mail_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_mail.TextChanged
        ' Если в Боксе один знак и он Собака то очищаем бокс
        If Len(sender.Text) = 1 And sender.Text = "@" Then sender.Clear() : Beep()
    End Sub
    Private Sub txt_mail_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_mail.Validated
        If EmailAddressCheck(sender.Text) = False Then
            XtraMessageBox.Show("Исправьте E-mail адрес (ivanov@mail.ru)!", "Не корректный E-mail!")
            sender.Focus()
            sender.Text = ""
        End If
    End Sub
    ' ===================================================================================================================================
    ' События DataGrid_AbonStatusHistory
    ' ===================================================================================================================================
    Private Sub DesignerDataGrid_AbonStatusHistory()
        ' Настройка отображения DataGrid_AbonStatusHistory
        Me.DataGrid_AbonStatusHistory.DataSource = iDataSet.Tables("AbonentHistory")
        Me.DataGrid_AbonStatusHistory.Columns.Item(0).Visible = False

        ' Отключаем сортировку столбцов по всему Гриду
        For i = 0 To Me.DataGrid_AbonStatusHistory.ColumnCount - 1
            Me.DataGrid_AbonStatusHistory.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub
    Private Sub DataGrid_AbonStatusHistory_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGrid_AbonStatusHistory.CellDoubleClick
        ' ОТКЛ Запрета на редактированиее
        Me.DataGrid_AbonStatusHistory.ReadOnly = False
    End Sub
    Private Sub DataGrid_AbonStatusHistory_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) _
            Handles DataGrid_AbonStatusHistory.EditingControlShowing
        ' Отмена при попытке редактировать Грид
        TextControl = e.Control
        TextControl.ReadOnly = True ' вот и не сможем менять содержимое
    End Sub
    Private Sub DataGrid_AbonStatusHistory_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGrid_AbonStatusHistory.CellEndEdit
        ' ВКЛ Запрета на редактирование
        Me.DataGrid_AbonStatusHistory.ReadOnly = True
    End Sub
    ' ===================================================================================================================================
    ' События Кнопок при наведении и нажатии мыши
    ' btn_EditAdress=====================================================================================================================
    Private Sub btn_EditAdress_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_EditAdress.MouseLeave
        btn_EditAdress.FlatStyle = FlatStyle.Flat
    End Sub
    Private Sub btn_EditAdress_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btn_EditAdress.MouseMove
        btn_EditAdress.FlatStyle = FlatStyle.Standard
    End Sub
    Private Sub btn_EditAdress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_EditAdress.Click
        XtraMessageBox.Show("Функция не реализована......" & Chr(10) & "_____________________________М.А. Лобин", _
                        "Обработчик не найден", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    ' btn_EditAltAdress==================================================================================================================
    Private Sub btn_EditAltAdress_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_EditAltAdress.MouseLeave
        btn_EditAltAdress.FlatStyle = FlatStyle.Flat
    End Sub

    Private Sub btn_EditAltAdress_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btn_EditAltAdress.MouseMove
        btn_EditAltAdress.FlatStyle = FlatStyle.Standard
    End Sub

    Private Sub btn_EditAltAdress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_EditAltAdress.Click
        XtraMessageBox.Show("Функция не реализована......" & Chr(10) & "_____________________________М.А. Лобин", _
                        "Обработчик не найден", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    ' btn_ClearAltAdress=================================================================================================================
    Private Sub btn_ClearAltAdress_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ClearAltAdress.MouseLeave
        btn_ClearAltAdress.FlatStyle = FlatStyle.Flat
    End Sub

    Private Sub btn_ClearAltAdress_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btn_ClearAltAdress.MouseMove
        btn_ClearAltAdress.FlatStyle = FlatStyle.Standard
    End Sub

    Private Sub btn_ClearAltAdress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ClearAltAdress.Click
        XtraMessageBox.Show("Функция не реализована......" & Chr(10) & "_____________________________М.А. Лобин", _
                        "Обработчик не найден", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    ' btn_ClearEmail=====================================================================================================================
    Private Sub btn_ClearEmail_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ClearEmail.MouseLeave
        btn_ClearEmail.FlatStyle = FlatStyle.Flat
    End Sub

    Private Sub btn_ClearEmail_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btn_ClearEmail.MouseMove
        btn_ClearEmail.FlatStyle = FlatStyle.Standard
    End Sub

    Private Sub btn_ClearEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ClearEmail.Click
        Me.txt_mail.Text = Nothing
    End Sub
    ' btn_ClearMobileNumber==============================================================================================================
    Private Sub btn_ClearMobileNumber_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ClearMobileNumber.MouseLeave
        btn_ClearMobileNumber.FlatStyle = FlatStyle.Flat
    End Sub

    Private Sub btn_ClearMobileNumber_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btn_ClearMobileNumber.MouseMove
        btn_ClearMobileNumber.FlatStyle = FlatStyle.Standard
    End Sub

    Private Sub btn_ClearMobileNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ClearMobileNumber.Click
        Me.txt_MobileNumber.Text = Nothing
    End Sub
    ' btn_ClearPhoneNumber===============================================================================================================
    Private Sub btn_ClearPhoneNumber_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ClearPhoneNumber.MouseLeave
        btn_ClearPhoneNumber.FlatStyle = FlatStyle.Flat
    End Sub

    Private Sub btn_ClearPhoneNumber_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btn_ClearPhoneNumber.MouseMove
        btn_ClearPhoneNumber.FlatStyle = FlatStyle.Standard
    End Sub

    Private Sub btn_ClearPhoneNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ClearPhoneNumber.Click
        Me.txt_PhoneNumber.Text = Nothing
    End Sub
    ' ===================================================================================================================================
#End Region

#Region "CОБЫТИЯ НА GАНЕЛЕ PAN_GENERALINFO"
    Private Sub DesignerProperyGrid_GenInfo()
        ' Заполнение PropertyGrid
        Me.PropertyGrid_GenInfo.SelectedObject = ProperyGrid_GenInfo
        ' Данные Квазар
        ProperyGrid_GenInfo.AbonentStatus = iDataSet.Tables("AbonentHistory").Rows(iDataSet.Tables("AbonentHistory").Rows.Count - 1).Item("Состояние").ToString
        ProperyGrid_GenInfo.AbonentStatusExt = iDataSet.Tables("AbonentHistory").Rows(iDataSet.Tables("AbonentHistory").Rows.Count - 1).Item("Причина").ToString
        ProperyGrid_GenInfo.CountTY = iDataSet.Tables("GenInfo").Rows(0).Item("CountTY").ToString
        ProperyGrid_GenInfo.LodgersCount = iDataSet.Tables("GenInfo").Rows(0).Item("LodgersCount").ToString
        ProperyGrid_GenInfo.Controler = iDataSet.Tables("GenInfo").Rows(0).Item("Controler").ToString
        ProperyGrid_GenInfo.ChiefControler = iDataSet.Tables("GenInfo").Rows(0).Item("ChiefControler").ToString
        ProperyGrid_GenInfo.HousePropName = iDataSet.Tables("GenInfo").Rows(0).Item("HousePropName").ToString
        ProperyGrid_GenInfo.HousePropName = iDataSet.Tables("GenInfo").Rows(0).Item("HousePropName").ToString
        ' Данные ПИР
        ProperyGrid_GenInfo.CopPerformer = "Не реализовано..."
        ProperyGrid_GenInfo.JudicialArea = "Не реализовано..."
        ProperyGrid_GenInfo.MembersCount = "Не реализовано..."
        ' Коммунальные данные
        ProperyGrid_GenInfo.GKO = iDataSet.Tables("GenInfo").Rows(0).Item("GKO").ToString
        ProperyGrid_GenInfo.ManagerHouses = iDataSet.Tables("GenInfo").Rows(0).Item("ManagerHouses").ToString
        ProperyGrid_GenInfo.BuildTypes = iDataSet.Tables("GenInfo").Rows(0).Item("BuildTypes").ToString
        ProperyGrid_GenInfo.HouseTypes = iDataSet.Tables("GenInfo").Rows(0).Item("HouseTypes").ToString
        ProperyGrid_GenInfo.Floors = iDataSet.Tables("GenInfo").Rows(0).Item("Floors").ToString
        ProperyGrid_GenInfo.SquareTotal = iDataSet.Tables("GenInfo").Rows(0).Item("SquareTotal").ToString
    End Sub
    ' ===================================================================================================================================
    ' События DataGrid_AbonStatusHistory
    ' ===================================================================================================================================
    Private Sub DesignerDataGrid_FamilyMember()
        ' Настройка отображения DataGrid_FamilyMember
        Me.DataGrid_FamilyMember.DataSource = iDataSet '.Tables("FamilyMember")
        Me.DataGrid_FamilyMember.DataMember = iDataSet.Tables("FamilyMember").ToString

        ' Задаем имена заголовков столбцов
        Me.DataGrid_FamilyMember.Columns.Item(3).HeaderText = "Семейная роль"
        Me.DataGrid_FamilyMember.Columns.Item(5).HeaderText = "Фамилия"
        Me.DataGrid_FamilyMember.Columns.Item(6).HeaderText = "Имя"
        Me.DataGrid_FamilyMember.Columns.Item(7).HeaderText = "Отчество"
        Me.DataGrid_FamilyMember.Columns.Item(13).HeaderText = "Прописан"
        Me.DataGrid_FamilyMember.Columns.Item(14).HeaderText = "Выписан"
        Me.DataGrid_FamilyMember.Columns.Item(18).HeaderText = "Долевая"

        ' Скрываем ненужные столбцы
        For i = 0 To Me.DataGrid_FamilyMember.ColumnCount - 1
            If i <> 3 And i <> 5 And i <> 6 And i <> 7 And i <> 13 And i <> 14 And i <> 18 _
            Then Me.DataGrid_FamilyMember.Columns.Item(i).Visible = False
        Next

        ' Отключаем сортировку столбцов по всему Гриду
        For i = 0 To Me.DataGrid_FamilyMember.ColumnCount - 1
            Me.DataGrid_FamilyMember.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub

    Private Sub DataGrid_FamilyMember_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGrid_FamilyMember.CellDoubleClick
        ' ОТКЛ Запрета на редактированиее если столбец не "Долевая"
        If e.ColumnIndex <> 18 Then Me.DataGrid_FamilyMember.ReadOnly = False
    End Sub

    Private Sub DataGrid_FamilyMember_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) _
            Handles DataGrid_FamilyMember.EditingControlShowing
        ' Отмена при попытке редактировать Грид
        TextControl = e.Control
        TextControl.ReadOnly = True ' вот и не сможем менять содержимое
    End Sub

    Private Sub DataGrid_FamilyMember_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGrid_FamilyMember.CellEndEdit
        ' ВКЛ Запрета на редактирование
        Me.DataGrid_FamilyMember.ReadOnly = True
    End Sub

    Private Sub DataGrid_FamilyMember_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGrid_FamilyMember.CellMouseDown
        ' Активиция ячейки правой кнопкой мыши
        If e.ColumnIndex >= 0 And e.RowIndex >= 0 And e.Button = Windows.Forms.MouseButtons.Right Then
            DataGrid_FamilyMember.CurrentCell = DataGrid_FamilyMember.Rows(e.RowIndex).Cells(e.ColumnIndex)
        End If
    End Sub
    ' События пунктов меню правой кнопки на Гриде с членам семьи
    Private Sub ViewMember_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewMember.Click
        ' Просмотр информации по выбранному члены семьи
        Try
            With frViewFamilyMember
                .iCurrRowDG = Me.DataGrid_FamilyMember.CurrentRow.Index
                .ShowDialog()
                .Dispose()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    ' ===================================================================================================================================
#End Region

#Region "CОБЫТИЯ НА ПАНЕЛЕ Члены семьи"
    ' Событие по клику на ноде дерева
    Private Sub ClickTree_PanMembers()
        EventChangedControl = False                                  ' Отключаем обработку событий в контролах
        MessageStatusStrip("Загрузка членов семьи...", Processing)   ' Сообщение об операции
        ' Запрос на выборку истории членов семьи по данным Припять
        SelectQueryData(
                        "Members", _
 _
                        "EXEC Pr_AbonentsMembers " & _
                                "@AbonentId = " & pref_AbonentId & ", " & _
                                "@Function = 1", _
 _
                        "ClickTree_PanMembers"
                        )

        ' +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        ' Если панель активирована впервый раз то, выполняем процедуры которые потом будут не нужны
        If FirstLoad_Pan_Members Then
            DesignerPan_Members()   ' Настройка всей панели Pan_Members
            ' Запрос на выборку семейных ролей
            SelectQueryData(
                            "FamilyRole",
                            "SELECT * FROM vPr_FamilyRoles",
                            "GetFamilyRole"
                            )
            ' Запрос на выборку полов
            SelectQueryData(
                            "SexMember",
                            "SELECT * FROM Pr_SexMembers",
                            "GetPr_SexMembers"
                            )

            ' Заполнение сmb_FamilyRole семейных ролей
            With Me.сmb_FamilyRole
                .DataSource = iDataSet.Tables("FamilyRole")
                .DisplayMember = "name"
                .ValueMember = "FamilyRoleId"
                .Text = Nothing
            End With
            ' Заполнение пола абонента
            With Me.cmb_SexMember
                .DataSource = iDataSet.Tables("SexMember")
                .DisplayMember = "Name"
                .ValueMember = "SexMembersId"
                .Text = Nothing
            End With
            FirstLoad_Pan_Members = False  ' Первая активация PanAbonentNum состоялась
        End If
        ' +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        EventChangedControl = True ' Включаем обработку событий в контролах
        ' Если грид непустой то, активируем строку по индексу в переменной
        If Me.DGView_PrMembers.RowCount <> 0 Then
            If iSelectRowDGView_Members >= 0 Then ' если индекс активной строки >= 0
                ' то, активируем строку по индексу
                Me.DGView_PrMembers.CurrentCell = Me.DGView_PrMembers _
                                                .Rows(iSelectRowDGView_Members) _
                                                .Cells(Me.DGView_PrMembers.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Name)
            Else ' иначе, активируем первую строку
                Me.DGView_PrMembers.CurrentCell = Me.DGView_PrMembers _
                                                .Rows(0) _
                                                .Cells(Me.DGView_PrMembers.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Name)
            End If
        Else ' Если пустой то, делаем недоступными кнопки удалить и сохранить
        End If
        FillDataCurrentMember()                     ' Разноска информации по полям
        MessageStatusStrip("Готово...", Processing) ' Сообщение об операции
    End Sub
    ' Привязка к данным базы DGView_PrMembers
    Private Sub DesignerPan_Members()
        ' Привязка DGView_PrMembers к iDataset.Pr_Members
        Me.DGView_PrMembers.DataSource = iDataSet.Tables("Members")
        ' Скрываем все столбцы на .DGView_PrMembers
        For i = 0 To Me.DGView_PrMembers.ColumnCount - 1
            Me.DGView_PrMembers.Columns.Item(i).Visible = False
        Next
        ' Отображаем нужные столбцы и задаем им имена
        Dim ColGrid As Object = Me.DGView_PrMembers.Columns
        ColGrid.Item("Surname").HeaderText = "Фамилия"
        ColGrid.Item("Surname").Visible = True
        ColGrid.Item("Name").HeaderText = "Имя"
        ColGrid.Item("Name").Visible = True
        ColGrid.Item("Patronymic").HeaderText = "Отчество"
        ColGrid.Item("Patronymic").Visible = True
        ColGrid.Item("FamilyRoles").HeaderText = "Семейная роль"
        ColGrid.Item("FamilyRoles").Visible = True
        ColGrid.Item("DtResidence").HeaderText = "Прописан"
        ColGrid.Item("DtResidence").Visible = True
        ColGrid.Item("DtUnResidence").HeaderText = "Выписан"
        ColGrid.Item("DtUnResidence").Visible = True
        ColGrid.Item("DtCreate").HeaderText = "Создан"
        ColGrid.Item("DtCreate").Visible = True
        ColGrid.Item("PerfCreater").HeaderText = "Автор"
        ColGrid.Item("PerfCreater").Visible = True
        ' Отключаем сортировку столбцов по всему Гриду
        For i = 0 To Me.DGView_PrMembers.ColumnCount - 1
            Me.DGView_PrMembers.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub

#Region "События на гриде с Членами семьи"
    Private Sub DGView_PrMembers_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGView_PrMembers.SelectionChanged
        If EventChangedControl Then
            FillDataCurrentMember()
            If Me.DGView_PrMembers.RowCount.ToString <> 0 And Me.DGView_PrMembers.CurrentRow.Selected Then
                ' Запись в переменную номера активной строки DGView_PrMembers
                iSelectRowDGView_Members = Me.DGView_PrMembers.CurrentRow.Index
            End If
        End If
    End Sub
    ' Удаление члена семьи
    Private Sub DGView_PrMembers_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGView_PrMembers.KeyDown
        ' Если грид не пустой
        If DGView_PrMembers.Rows.Count <> 0 Then _
            If e.KeyCode = Keys.Delete Then btn_DeleteMember_Click(sender, e)
    End Sub
#End Region

    ' Заполнение информации по выбранному в DGView_PrMembers члену семьи
    Private Sub FillDataCurrentMember()
        Dim CurRow As Object = DGView_PrMembers.CurrentRow ' Активная строка на гриде
        Me.GrBox_CurrentMember.Enabled = True
        ' Если грид не пустой
        If Me.DGView_PrMembers.Rows.Count <> 0 Then
            Me.GrBox_CurrentMember.Enabled = True ' Включение всех контролов на панеле
            Me.btn_InsertMember.Enabled = True ' Отдельная обработка для менеджера членов
            Me.btn_DeleteMember.Enabled = True

            ' Заголовок в GroupBox ФИО
            Me.GrBox_CurrentMember.Text = "Данные члена семьи (" & _
                                          CurRow.Cells("Surname").Value.ToString & " " & _
                                          CurRow.Cells("Name").Value.ToString & " " & _
                                          CurRow.Cells("Patronymic").Value.ToString & ")"
            ' Заполнение информации по члену семьи
            Me.txt_Surname.Text = CurRow.Cells("Surname").Value.ToString
            Me.txt_Name.Text = CurRow.Cells("Name").Value.ToString
            Me.txt_Patronymic.Text = CurRow.Cells("Patronymic").Value.ToString
            Me.txt_DtResidence.Text = ConvertToNull(CurRow.Cells("DtResidence").Value.ToString, False, 1)
            Me.txt_DtUnResidence.Text = ConvertToNull(CurRow.Cells("DtUnResidence").Value.ToString, False, 1)
            Me.cmb_SexMember.Text = CurRow.Cells("SexMembers").Value.ToString
            Me.ckb_ShareOwner.Checked = CurRow.Cells("ShareOwner").Value.ToString
            ' Если член семьи является дольщиком, прописан может быть где угодно
            If Me.ckb_ShareOwner.Checked Then
                Me.txt_Residence.ReadOnly = False
                Me.txt_Residence.Text = CurRow.Cells("Residence").Value.ToString
            Else
                Me.txt_Residence.ReadOnly = True
                Me.txt_Residence.Text = Me.txt_Adress.Text
            End If
            Me.сmb_FamilyRole.Text = CurRow.Cells("FamilyRoles").Value.ToString
            Me.txt_AddressOfLive.Text = CurRow.Cells("AddressOfLive").Value.ToString
            Me.txt_PlaceOfWork.Text = CurRow.Cells("PlaceOfWork").Value.ToString

            ' Если данные из базы уже есть то, меняем настройки маски
            If CurRow.Cells("Phone").Value.ToString <> "" Then
                Me.txt_MemPhoneMobile.TextMaskFormat = MaskFormat.IncludePromptAndLiterals
                Me.txt_MemPhoneMobile.Text = CurRow.Cells("Phone").Value.ToString
            End If

            ' Если данные из базы уже есть то, меняем цвет текста и маску
            If CurRow.Cells("Email").Value.ToString <> "" Then
                Me.txt_MemEmail.Mask = ""
                Me.txt_MemEmail.ForeColor = WindowText
                Me.txt_MemEmail.Text = CurRow.Cells("Email").Value.ToString
            End If

            Me.txt_NoteMember.Text = CurRow.Cells("Note").Value.ToString
            Me.lab_Update.Text = "Запись изменена: " & CurRow.Cells("DtUpdate").Value.ToString & " - " & CurRow.Cells("PerfUpdater").Value.ToString
            ' Паспортные данные
            Me.txt_PDDateOfBirth.Text = ConvertToNull(CurRow.Cells("PDDateOfBirth").Value.ToString, False, 1)
            Me.txt_PDSeries.Text = CurRow.Cells("PDSeries").Value.ToString
            Me.txt_PDNumber.Text = CurRow.Cells("PDNumber").Value.ToString
            Me.txt_PDDateOfIssue.Text = ConvertToNull(CurRow.Cells("PDDateOfIssue").Value.ToString, False, 1)
            Me.txt_PDSubunit.Text = CurRow.Cells("PDSubunit").Value.ToString
            Me.txt_PDSubunitCode.Text = CurRow.Cells("PDSubunitCode").Value.ToString
            Me.txt_PDString.Text = "Серия: " & Me.txt_PDSeries.Text & _
                                   " №_" & Me.txt_PDNumber.Text & _
                                   " Код подразделения :" & Me.txt_PDSubunitCode.Text & vbNewLine & _
                                   "Выдан: " & Me.txt_PDDateOfIssue.Text & " " & Me.txt_PDSubunit.Text
        Else
            ' Отключение всех контролов на панеле
            ClearDataCurrentMember() ' Чистка всех полей
            Me.GrBox_CurrentMember.Enabled = False
            Me.btn_UpdateMember.Enabled = False
            Me.btn_DeleteMember.Enabled = False
        End If
        Me.btn_UpdateMember.Enabled = False
    End Sub

    ' Чистка полей с информацие по члену семьи
    Private Sub ClearDataCurrentMember()
        ' Заголовок в GroupBox ФИО
        Me.GrBox_CurrentMember.Text = "Данные члена семьи"
        ' Чистка информации по члену семьи
        Me.txt_Surname.Text = Nothing : Me.txt_Name.Text = Nothing : Me.txt_Patronymic.Text = Nothing
        Me.txt_DtResidence.Text = Nothing : Me.txt_DtUnResidence.Text = Nothing : Me.cmb_SexMember.Text = Nothing
        Me.ckb_ShareOwner.Checked = False : Me.txt_Residence.ReadOnly = True : Me.txt_Residence.Text = Nothing
        Me.сmb_FamilyRole.Text = Nothing : Me.txt_AddressOfLive.Text = Nothing : Me.txt_PlaceOfWork.Text = Nothing
        Me.txt_MemPhoneMobile.Text = Nothing : Me.txt_MemEmail.Text = Nothing : Me.txt_NoteMember.Text = Nothing
        Me.lab_Update.Text = Nothing
        ' Паспортные данные
        Me.txt_PDDateOfBirth.Text = Nothing : Me.txt_PDSeries.Text = Nothing : Me.txt_PDNumber.Text = Nothing
        Me.txt_PDDateOfIssue.Text = Nothing : Me.txt_PDSubunit.Text = Nothing : Me.txt_PDSubunitCode.Text = Nothing
        Me.txt_PDString.Text = Nothing
    End Sub

    ' Если член семьи является дольщиком то, прописан может быть где угодно 
    Private Sub ckb_ShareOwner_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckb_ShareOwner.CheckedChanged
        Dim CurRow As Object = DGView_PrMembers.CurrentRow
        If Me.ckb_ShareOwner.Checked Then
            Me.txt_Residence.ReadOnly = False
            Me.txt_Residence.Text = Nothing
        Else
            Me.txt_Residence.ReadOnly = True
            Me.txt_Residence.Text = Me.txt_Adress.Text
        End If
    End Sub

#Region "Обработка Номера сотового телефона"
    Private Sub txt_MemPhoneMobile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_MemPhoneMobile.Click,
                                                                                                      txt_PDSeries.Click,
                                                                                                      txt_PDNumber.Click,
                                                                                                      txt_PDSubunitCode.Click
        ' Если НЕ инициализирован вход в поле 
        If iEnter = False Then
            ' Если тектовое поле для сотового телефона
            If sender.Name = "txt_MemPhoneMobile" Then
                sender.Select(4, sender.TextLength)     ' Выделяем текст с 5-го и до конца поля
                iEnter = True                           ' Отмечаем что выполнен вход в поле
            Else ' Для остальных полей
                sender.Selectall()                      ' Просто выделяем весь текст
                iEnter = True                           ' Отмечаем что выполнен вход в поле
            End If
        End If
    End Sub
    Private Sub txt_MemPhoneMobile_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_MemPhoneMobile.Leave,
                                                                                                      txt_PDSeries.Leave,
                                                                                                      txt_PDNumber.Leave,
                                                                                                      txt_PDSubunitCode.Leave
        iEnter = False                              ' Отмечаем что выполнен выход из поле
    End Sub
    Private Sub txt_MemPhoneMobile_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_MemPhoneMobile.Validated
        ' В настройках маски исключаем и подсказки и литералы
        sender.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
        ' Если текст в поле НЕ соответствует маске и в поле НЕ пусто
        If sender.MaskFull = False And sender.Text <> "" Then
            ' В настройках маски исключаем и подсказки и литералы
            sender.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
            ' сообщаем об ошибке и переводим фокус обратно в поле
            XtraMessageBox.Show("Номер сотового телефона не соответствует маске", _
                            "Заполните Номер городского телефона", _
                            MessageBoxButtons.OK, _
                            MessageBoxIcon.Asterisk)
            sender.focus()
        Else ' Если текст в поле соответствует маске
            ' В настройках маски Включаем и подсказки и литералы
            If sender.Text <> "" Then sender.TextMaskFormat = MaskFormat.IncludePromptAndLiterals
        End If
    End Sub
#End Region

#Region "Обработка Электронной почты"
    Private Sub txt_MemEmail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_MemEmail.Click
        ' Если НЕ инициализирован вход в поле
        If iEnter = False Then
            sender.Select(0, sender.TextLength)     ' Выделяем весь тект в поле
            sender.Mask = ""                        ' Очищаем поле
            sender.ForeColor = WindowText           ' Меняем цвет текта 
            iEnter = True                           ' Отмечаем что выполнен вход в поле
        End If
    End Sub
    Private Sub txt_MemEmail_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_MemEmail.Leave
        iEnter = False                                  ' Отмечаем что выполнен выход из поле
        ' Если в поле пусто
        If sender.Text = "" Then
            sender.Mask = "____________@_____.____"     ' Устанавливаем маску поля
            sender.ForeColor = InactiveCaption          ' Меняем цвет текта
        End If
    End Sub
    Private Sub txt_MemEmail_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_MemEmail.KeyPress
        Dim s As String = sender.Text
        Dim c As Integer = 0
        If e.KeyChar = "@" Then c = InStr(1, s, "@") '      Если введена @ то, считаем сколько их уже
        If c > 1 Then e.Handled = True : Beep() '           Если их больше одной то отменяем ввод
    End Sub
    Private Sub txt_MemEmail_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_MemEmail.TextChanged
        If EventChangedControl Then  ' Заранее отключаем оброботку событий в контролах
            ' Если в Боксе один знак и он Собака то очищаем бокс
            If Len(sender.Text) = 1 And sender.Text = "@" Then sender.Clear() : Beep()
        End If
    End Sub
    Private Sub txt_MemEmail_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_MemEmail.Validated
        ' Если емайл не прошел проверку и поле НЕ пустое и не равно маске
        If EmailAddressCheck(sender.Text) = False And sender.Text <> "" And sender.Text <> "____________@_____.____" Then
            ' сообщаем об ошибке и переводим фокус обратно в поле
            XtraMessageBox.Show("Исправьте E-mail адрес (ivanov@mail.ru)!", "Не корректный E-mail!")
            sender.Focus()
        End If
    End Sub
#End Region

    ' Обработка поля серия паспорта
    Private Sub txt_PDSeries_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_PDSeries.Validating
        ' Проверка корректности введенного номера
        txtMaskValidating(sender, "Введен некорректная серия паспорта! Исправьте....", "____")
    End Sub
    ' Обработка поля номер паспорта
    Private Sub txt_PDNumber_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_PDNumber.Validating
        ' Проверка корректности введенного номера
        txtMaskValidating(sender, "Введен некорректный номер паспорта! Исправьте....", "______")
    End Sub
    ' Обработка поля код подразделения
    Private Sub txt_PDSubunitCode_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_PDSubunitCode.Validating
        ' Проверка корректности введенного номера
        txtMaskValidating(sender, "Введен некорректный код подразделения! Исправьте....", "___-___")
    End Sub

#Region "Обработка текстовых полей с датами"
    Private Sub txt_DtResidence_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_DtResidence.Leave,
                                                                                                   txt_DtUnResidence.Leave,
                                                                                                   txt_PDDateOfBirth.Leave,
                                                                                                   txt_PDDateOfIssue.Leave
        If Not IsDate(sender.Text) And sender.Text <> "__.__.____" Then _
            XtraMessageBox.Show("Введенный текст не является датой", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error) : sender.Focus()
    End Sub
    Private Sub txt_DtResidence_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txt_DtResidence.MouseClick,
                                                                                                                           txt_DtUnResidence.MouseClick,
                                                                                                                           txt_PDDateOfBirth.MouseClick,
                                                                                                                           txt_PDDateOfIssue.MouseClick
        DateMaskEvents("MouseClick", sender)
    End Sub
    Private Sub txt_DtResidence_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_DtResidence.KeyUp,
                                                                                                                    txt_DtUnResidence.KeyUp,
                                                                                                                    txt_PDDateOfBirth.KeyUp,
                                                                                                                    txt_PDDateOfIssue.KeyUp
        DateMaskEvents("KeyUp", sender, e.KeyCode)
    End Sub
    Private Sub txt_DtResidence_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_DtResidence.Validating,
                                                                                                                             txt_DtUnResidence.Validating,
                                                                                                                             txt_PDDateOfBirth.Validating,
                                                                                                                             txt_PDDateOfIssue.Validating
        ' Проверка корректности введенного номера
        txtMaskValidating(sender, "Введена некорректная дата! Исправьте....", "__.__.____")
    End Sub

    Private Sub btn_CalDtResidence_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CalDtResidence.ValueChanged
        Me.txt_DtResidence.Text = sender.Text
    End Sub
    Private Sub btn_CalDtResidence_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_CalDtResidence.MouseEnter
        If IsDate(Me.txt_DtResidence.Text) Then sender.Value = Me.txt_DtResidence.Text
    End Sub

    Private Sub btn_CalDtUnResidence_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CalDtUnResidence.ValueChanged
        Me.txt_DtUnResidence.Text = sender.Text
    End Sub
    Private Sub btn_CalDtUnResidence_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_CalDtUnResidence.MouseEnter
        If IsDate(Me.txt_DtUnResidence.Text) Then sender.Value = Me.txt_DtUnResidence.Text
    End Sub

    Private Sub btn_CalPDDateOfBirth_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CalPDDateOfBirth.ValueChanged
        Me.txt_PDDateOfBirth.Text = sender.Text
    End Sub
    Private Sub btn_CalPDDateOfBirth_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_CalPDDateOfBirth.MouseEnter
        If IsDate(Me.txt_PDDateOfBirth.Text) Then sender.Value = Me.txt_PDDateOfBirth.Text
    End Sub

    Private Sub btn_CalPDDateOfIssue_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CalPDDateOfIssue.ValueChanged
        Me.txt_PDDateOfIssue.Text = sender.Text
    End Sub
    Private Sub btn_CalPDDateOfIssue_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_CalPDDateOfIssue.MouseEnter
        If IsDate(Me.txt_PDDateOfIssue.Text) Then sender.Value = Me.txt_PDDateOfIssue.Text
    End Sub
#End Region

    ' Очистить паспортные данные
    Private Sub btn_ClearPD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ClearPD.Click
        Me.txt_PDDateOfBirth.Text = Nothing : Me.txt_PDSeries.Text = Nothing : Me.txt_PDNumber.Text = Nothing
        Me.txt_PDDateOfIssue.Text = Nothing : Me.txt_PDSubunit.Text = Nothing : Me.txt_PDSubunitCode.Text = Nothing
        Me.txt_PDString.Text = "Серия: " & Me.txt_PDSeries.Text & _
                                   " №_" & Me.txt_PDNumber.Text & _
                                   " Код подразделения :" & Me.txt_PDSubunitCode.Text & vbNewLine & _
                                   "Выдан: " & Me.txt_PDDateOfIssue.Text & " " & Me.txt_PDSubunit.Text
    End Sub
    ' При изменении паспортных данных происдотит сцепка данных в одну строку
    Private Sub PD_Changed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_PDSeries.TextChanged,
                                                                                               txt_PDNumber.TextChanged,
                                                                                               txt_PDDateOfIssue.TextChanged,
                                                                                               txt_PDSubunit.TextChanged,
                                                                                               txt_PDSubunitCode.TextChanged
        If EventChangedControl Then
            Me.txt_PDString.Text = "Серия: " & Me.txt_PDSeries.Text & _
                                   " №_" & Me.txt_PDNumber.Text & _
                                   " Код подразделения :" & Me.txt_PDSubunitCode.Text & vbNewLine & _
                                   "Выдан: " & Me.txt_PDDateOfIssue.Text & " " & Me.txt_PDSubunit.Text
        End If
    End Sub
    ' При потере фокуса ГрупБокса, проверяем были ли внесены изменения
    Private Sub GrBox_CurrentMember_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrBox_CurrentMember.Leave
        ' Если кнопка сохранить активна
        If Me.btn_UpdateMember.Enabled Then
            ' Вопрос сохранить или нет
            Select Case XtraMessageBox.Show("На вкладке <Члены семьи> имеются не сохраненне изменения." & Chr(10) &
                                        "Сохранить изменения в безе данных?",
                                        Application.ProductName, MessageBoxButtons.YesNoCancel,
                                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                Case DialogResult.Yes
                    btn_UpdateMember_Click(sender, e)   ' Нажимаем кнопку Сохранить
                Case DialogResult.No
                    ClickTree_PanMembers()              ' Просто обновляем панель
            End Select
        End If
    End Sub
    ' Активация кнопки сохронить, при изменении текта в каком либо контроле 
    Private Sub MemberDataChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Surname.TextChanged, txt_Name.TextChanged,
                                                                                                     txt_Patronymic.TextChanged, txt_DtResidence.TextChanged,
                                                                                                     txt_DtUnResidence.TextChanged, cmb_SexMember.TextChanged,
                                                                                                     txt_Residence.TextChanged, сmb_FamilyRole.TextChanged,
                                                                                                     txt_AddressOfLive.TextChanged, txt_PlaceOfWork.TextChanged,
                                                                                                     txt_MemPhoneMobile.TextChanged, txt_MemEmail.TextChanged,
                                                                                                     txt_PDDateOfBirth.TextChanged, txt_PDSeries.TextChanged,
                                                                                                     txt_PDNumber.TextChanged, txt_PDDateOfIssue.TextChanged,
                                                                                                     txt_PDSubunit.TextChanged, txt_PDSubunitCode.TextChanged,
                                                                                                     txt_NoteMember.TextChanged
        If EventChangedControl Then Me.btn_UpdateMember.Enabled = True
    End Sub
#Region "Управление списком членов семьи" ' Изменить. Добавить. Удалить
    Private Sub btn_UpdateMember_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_UpdateMember.Click
        If DGView_PrMembers.Rows.Count <> 0 Then
            ' Передача значений полей в текст команды запроса
            If ExecuteQuery("EXEC Pr_AbonentsMembers " & _
                                                "@Surname = " & ConvertToNull(Me.txt_Surname.Text, True, 0) & ", " & _
                                                "@Name = " & ConvertToNull(Me.txt_Name.Text, True, 0) & ", " & _
                                                "@Patronymic = " & ConvertToNull(Me.txt_Patronymic.Text, True, 0) & ", " & _
                                                "@SexMembersId = " & ConvertToNull(Me.cmb_SexMember.SelectedValue, True, 0) & ", " & _
                                                "@Residence = " & ConvertToNull(Me.txt_Residence.Text, True, 0) & ", " & _
                                                "@DtResidence = " & ConvertToNull(Me.txt_DtResidence.Text, True, 1, "__.__.____") & ", " & _
                                                "@DtUnResidence = " & ConvertToNull(Me.txt_DtUnResidence.Text, True, 1, "__.__.____") & ", " & _
                                                "@FamilyRoleId = " & ConvertToNull(Me.сmb_FamilyRole.SelectedValue, True, 0) & ", " & _
                                                "@ShareOwner = " & Me.ckb_ShareOwner.Checked.ToString & ", " & _
                                                "@PDDateOfBirth = " & ConvertToNull(Me.txt_PDDateOfBirth.Text, True, 1, "__.__.____") & ", " & _
                                                "@PDSeries = " & ConvertToNull(Me.txt_PDSeries.Text, True, 1, "____") & ", " & _
                                                "@PDNumber = " & ConvertToNull(Me.txt_PDNumber.Text, True, 1, "______") & ", " & _
                                                "@PDDateOfIssue = " & ConvertToNull(Me.txt_PDDateOfIssue.Text, True, 1, "__.__.____") & ", " & _
                                                "@PDSubunit = " & ConvertToNull(Me.txt_PDSubunit.Text, True, 0) & ", " & _
                                                "@PDSubunitCode = " & ConvertToNull(Me.txt_PDSubunitCode.Text, True, 1, "___-___") & ", " & _
                                                "@PDString = " & ConvertToNull(Me.txt_PDString.Text, True, 0) & ", " & _
                                                "@Phone = " & ConvertToNull(Me.txt_MemPhoneMobile.Text, True, 0) & ", " & _
                                                "@Email = " & ConvertToNull(Me.txt_MemEmail.Text, True, 0) & ", " & _
                                                "@AddressOfLive = " & ConvertToNull(Me.txt_AddressOfLive.Text, True, 0) & ", " & _
                                                "@PlaceOfWork = " & ConvertToNull(Me.txt_PlaceOfWork.Text, True, 0) & ", " & _
                                                "@Note = " & ConvertToNull(Me.txt_NoteMember.Text, True, 0) & ", " & _
                                                "@MemberId = " & Me.DGView_PrMembers.CurrentRow.Cells("MemberId").Value & ", " & _
                                                "@Function = 3",
 _
                                                "UpdateMember"
                                            ) Then
                With New frInfo
                    .Mess = "Измененения в члене семьи сохранены..."
                    .Show()     ' Всплываюшее сообщение
                End With
            End If
        End If
        ClickTree_PanMembers()  ' Обновление полей
    End Sub
    Private Sub btn_InsertMember_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_InsertMember.Click
        ' Перед добавление спрашиваем 
        Select Case XtraMessageBox.Show("Создать нового члена семьи в ПК Припять или скачать из ПК Квазар?" & Chr(10) & _
                                    "Да - создать в ПК Припять" & Chr(10) & _
                                    "Нет - скачать из ПК Квазар", _
                                    "Параметры создания нового члена семьи", _
                                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

            Case DialogResult.Yes ' Новый член семьи в ПК Припять
                If frAddNewPr_Member.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    ' индекс активной строки делаем количеством строк, 
                    ' для перехода на добавленную строку
                    iSelectRowDGView_Members = Me.DGView_PrMembers.RowCount
                    ClickTree_PanMembers()  ' Обновление полей
                End If
                frAddNewPr_Member.Dispose() ' Выгружаем форму из памяти

            Case DialogResult.No ' Скачать члена семьи из Квазара
                If frChooseMember.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    ' В случае несовпадения ФИО, добавляется выбранный член семьи из Квазара
                    frAddNewPr_Member.NewOrQusar = True  ' Добавление из Квазара
                    If frAddNewPr_Member.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        ' индекс активной строки делаем количеством строк, 
                        ' для перехода на добавленную строку
                        iSelectRowDGView_Members = Me.DGView_PrMembers.RowCount
                        ClickTree_PanMembers() ' Обновление полей
                    End If
                End If
                frChooseMember.Dispose()    ' Выгружаем форму из памяти
                frAddNewPr_Member.Dispose() ' Выгружаем форму из памяти
                ClickTree_PanMembers()      ' Обновляем информацию на форме
        End Select
    End Sub
    Private Sub btn_DeleteMember_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_DeleteMember.Click
        If Me.DGView_PrMembers.Rows.Count <> 0 Then
            ' Вопрос перед удалением
            Select Case XtraMessageBox.Show("Запись <<" & Me.txt_Surname.Text & " " & _
                                                      Me.txt_Name.Text & " " & _
                                                      Me.txt_Patronymic.Text & ">>" & vbCrLf & "будет удалена! Вы согласны?", _
                                                                                "Внимание! Удаление без возможности восстановления", _
                                                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.Yes ' Ok
                    If DGView_PrMembers.Rows.Count <> 0 Then
                        ' Передача значений полей в текст команды запроса
                        If ExecuteQuery("EXEC Pr_AbonentsMembers " & _
                                                            "@Function = 4, " & _
                                                            "@MemberId = " & Me.DGView_PrMembers.CurrentRow.Cells("MemberId").Value, _
 _
                                                        "DeleteMember") Then
                            ' Уменьшаем на единицу номер текущей строки DGView_PrMembers
                            iSelectRowDGView_Members = iSelectRowDGView_Members - 1
                            With New frInfo
                                .Mess = "Член семьи удален..."
                                .Show()     ' Всплываюшее сообщение
                            End With
                        End If
                    End If
                Case DialogResult.Cancel    ' Cancel
            End Select
        End If
        ClickTree_PanMembers()              ' Обновление полей
    End Sub
#End Region
#End Region

#Region " CОБЫТИЯ НА GАНЕЛЕ Pan_1_Suit"
    ' Запись номера активной вкладки
    Private Sub PIR1_TabCon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PIR1_TabCon.SelectedIndexChanged
        ActiveTab_Petition = PIR1_TabCon.SelectedIndex
    End Sub

#Region "Исковые мероприятия"
    ' Событие по клику на ноде дерева
    Private Sub ClickTree_Pan_1_Suit()
        EventChangedControl = False                                                 ' Выключаем обработку событий в контролах
        Me.PIR1_TabCon.SelectedIndex = ActiveTab_Petition                           ' Активируем вклаку с номером из меременной
        MessageStatusStrip("Загрузка ПИР - Элекроэнеиргии...", Processing)          ' Сообщение об операции
        GetPr_PetitionsDebt()                                                       ' Запрос на выборку заявлений в суд
        'GetPr_Members(1)                                                           ' Запрос на выборку членов семьи ПК Припять
        ' +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        ' Если панель активирована впервый раз то, выполняем процедуры которые потом будут не нужны
        If FirstLoad_Pan_1_Suit Then
            GetPr_EnergyTypes()         ' Выборка видов услуг
            GetPr_PetitionTypes()       ' Выборка типов заявлений в суд
            GetPr_CourtType()           ' Выборка судебных инстанций
            GetPr_JudicialArea(1)       ' Выборка судебных участков
            GetPr_ListeningType()       ' Выборка итогов слушания
            GetPr_DecisionType()        ' Выборка видов решения суда
            GetPr_DecisionDirections()  ' Выборка направлений решений суда
            GetPr_ReasonForEnd()        ' Выборка причин окончания исковых мероприятий
            GetPr_DecisionTypeExt(0, 0) ' Выборка всех возможных причин решения суда
            GetPr_PetitionsListening("''", "''", "''", "''", "''") ' Выборка слушаний
            SelectQueryData("Petitions", "EXEC  Pr_AbonentsPetitions @Function = 1", "ClickTree_Pan_1_Suit")                ' Выборка МИП
            SelectQueryData("CopPerformers", "EXEC Pr_Books_CopPerformers @Function = 5", "ClickTree_Pan_1_Suit")           ' Выборка перечня приставов
            SelectQueryData("ActImpossibleRecovery", "EXEC Pr_Books_ActImpossible @Function = 5", "ClickTree_Pan_1_Suit")   ' Выборка причин актов о НВ


            ' <<<<<<<НАСТРОЙКА PIR1_DGView_PetitionsDebt>>>>>>>
            ' Привязка PIR1_DGView_Petitions к iDataset.PetitionsDebt
            Me.PIR1_DGView_PetitionsDebt.DataSource = iDataSet.Tables("PetitionsDebt")
            ' Скрываем все столбцы на .PIR1_DGView_Petitions
            For i = 0 To Me.PIR1_DGView_PetitionsDebt.ColumnCount - 1
                Me.PIR1_DGView_PetitionsDebt.Columns.Item(i).Visible = False
            Next
            ' Отображаем нужные столбцы и задаем им имена
            Dim ColGrid As Object = Me.PIR1_DGView_PetitionsDebt.Columns
            ColGrid.Item("DtPeriodStart").HeaderText = "П-д начало"
            ColGrid.Item("DtPeriodStart").Visible = True
            ColGrid.Item("DtPeriodEnd").HeaderText = "П-д конец"
            ColGrid.Item("DtPeriodEnd").Visible = True
            ColGrid.Item("FIO").HeaderText = "Фамилия Имя Отчество"
            ColGrid.Item("FIO").Visible = True
            ColGrid.Item("DebtSumm").HeaderText = "Сумма иска"
            ColGrid.Item("DebtSumm").Visible = True
            ColGrid.Item("DebtSumm").DefaultCellStyle.Format = "N2"
            ColGrid.Item("GovTax").HeaderText = "Гос.пошлина"
            ColGrid.Item("GovTax").Visible = True
            ColGrid.Item("GovTax").DefaultCellStyle.Format = "N2"
            ColGrid.Item("DebtSummAfterDecision").HeaderText = "Сумма по суду"
            ColGrid.Item("DebtSummAfterDecision").Visible = True
            ColGrid.Item("DebtSummAfterDecision").DefaultCellStyle.Format = "N2"
            ColGrid.Item("EnergyType").HeaderText = "Услуга"
            ColGrid.Item("EnergyType").Visible = True
            ColGrid.Item("DtPetitions").HeaderText = "Дата заявления"
            ColGrid.Item("DtPetitions").Visible = True
            ColGrid.Item("NumberPetitions").HeaderText = "Номер заявления"
            ColGrid.Item("NumberPetitions").Visible = True
            ' Отключаем сортировку столбцов по всему Гриду
            For i = 0 To Me.PIR1_DGView_PetitionsDebt.ColumnCount - 1
                Me.PIR1_DGView_PetitionsDebt.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next
            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            ' <<<<<<<НАСТРОЙКА PIR1_DGView_ListeningHistory>>>>>>>
            ' Привязка PIR1_DGView_ListeningHistory к iDataset.PetitionsListening
            Me.PIR1_DGView_ListeningHistory.DataSource = iDataSet.Tables("PetitionsListening")
            ' Скрываем все столбцы на .PIR1_DGView_ListeningHistory
            For i = 0 To Me.PIR1_DGView_ListeningHistory.ColumnCount - 1
                Me.PIR1_DGView_ListeningHistory.Columns.Item(i).Visible = False
            Next
            ' Отображаем нужные столбцы и задаем им имена
            Dim ColGrid_Listen As Object = Me.PIR1_DGView_ListeningHistory.Columns
            ColGrid_Listen.Item("DtListening").HeaderText = "Дата слушания"
            ColGrid_Listen.Item("DtListening").Visible = True
            ColGrid_Listen.Item("ListeningType").HeaderText = "Результат слушания"
            ColGrid_Listen.Item("ListeningType").Visible = True
            ColGrid_Listen.Item("DtPostpone").HeaderText = "Дата след.слушания"
            ColGrid_Listen.Item("DtPostpone").Visible = True
            ' Отключаем сортировку столбцов по всему Гриду
            For i = 0 To Me.PIR1_DGView_ListeningHistory.ColumnCount - 1
                Me.PIR1_DGView_ListeningHistory.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next
            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            ' <<<<<<<НАСТРОЙКА PIR1_DGView_Petitions>>>>>>>
            ' Привязка PIR1_DGView_Petitions к iDataset.Petitions
            Me.PIR1_DGView_Petitions.DataSource = iDataSet.Tables("Petitions")
            ' Скрываем все столбцы на .PIR1_DGView_ListeningHistory
            For i = 0 To Me.PIR1_DGView_Petitions.ColumnCount - 1
                Me.PIR1_DGView_Petitions.Columns.Item(i).Visible = False
            Next
            ' Отображаем нужные столбцы и задаем им имена
            Dim ColGrid_Petit As Object = Me.PIR1_DGView_Petitions.Columns
            ColGrid_Petit.Item("SerialNumberPetit").HeaderText = "№ П/П"
            ColGrid_Petit.Item("SerialNumberPetit").Visible = True
            ColGrid_Petit.Item("ExecutiveNumber").HeaderText = "№ Исполн. произв-ва"
            ColGrid_Petit.Item("ExecutiveNumber").Visible = True
            ColGrid_Petit.Item("ExcitementDt").HeaderText = "Дата возбуждения"
            ColGrid_Petit.Item("ExcitementDt").Visible = True
            ColGrid_Petit.Item("CopPerformers").HeaderText = "Пристав - исполнитель"
            ColGrid_Petit.Item("CopPerformers").Visible = True
            ColGrid_Petit.Item("DebtSumm").HeaderText = "Сумма ИП"
            ColGrid_Petit.Item("DebtSumm").Visible = True
            ColGrid_Petit.Item("DebtSumm").DefaultCellStyle.Format = "N2"

            ' Отключаем сортировку столбцов по всему Гриду
            For i = 0 To Me.PIR1_DGView_Petitions.ColumnCount - 1
                Me.PIR1_DGView_Petitions.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next
            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            ' Заполнение PIR1_cmb_CourtType судебных инстанций
            With Me.PIR1_cmb_CourtType
                .DataSource = iDataSet.Tables("CourtType")
                .DisplayMember = "Name"
                .ValueMember = "CourtTypeId"
                .Text = Nothing
            End With
            ' Заполнение PIR1_cmb_DecisionType видов решения суда
            With Me.PIR1_cmb_DecisionType
                .DataSource = iDataSet.Tables("DecisionType")
                .DisplayMember = "Name"
                .ValueMember = "DecisionTypeId"
                .Text = Nothing
            End With
            ' Заполнение PIR1_cmb_DecisionTypeExt причин решения суда
            With Me.PIR1_cmb_DecisionTypeExt
                .DataSource = iDataSet.Tables("DecisionTypeExt")
                .DisplayMember = "Name"
                .ValueMember = "DecisionTypeExtId"
                .Text = Nothing
            End With
            ' Заполнение PIR1_cmb_DecisionDirection направлений решений суда
            With Me.PIR1_cmb_DecisionDirection
                .DataSource = iDataSet.Tables("DecisionDirections")
                .DisplayMember = "Name"
                .ValueMember = "DecisionDirectionId"
                .Text = Nothing
            End With
            ' Заполнение PIR1_cmb_ReasonForEnd причин окончания исковых мероприятий
            With Me.PIR1_cmb_ReasonForEnd
                .DataSource = iDataSet.Tables("ReasonForEnd")
                .DisplayMember = "Name"
                .ValueMember = "ReasonForEndId"
                .Text = Nothing
            End With
            ' Заполнение PIR1_cmb_CopPerformer приставов
            With Me.PIR1_cmb_CopPerformer
                .DataSource = iDataSet.Tables("CopPerformers")
                .DisplayMember = "name"
                .ValueMember = "id"
                .Text = Nothing
            End With
            ' Заполнение PIR1_cmb_ActImpossibleRecovery актов НВ
            With Me.PIR1_cmb_ActImpossibleRecovery
                .DataSource = iDataSet.Tables("ActImpossibleRecovery")
                .DisplayMember = "name"
                .ValueMember = "id"
                .Text = Nothing
            End With

            FirstLoad_Pan_1_Suit = False ' Первая активация Pan_1_Suit состоялась
        End If
        ' +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        ' НУЖНО ПЕРЕНЕСТИ В СОБЫТИЕ ВХОДА В cmd_TSMenu_FilterMember
        ' Заполнение cmd_TSMenu_FilterMember ФИО членов семьи по ПК Припять
        'If iDataSet.Tables("Members_FIO").Rows.Count <> 0 Then ' Если  iDataSet("Members") не пустой
        ' Цикл по строкам iDataSet("Members") и загрузка членов в cmd_TSMenu_FilterMember
        'cmd_TSMenu_FilterMember.Items.Clear() ' Перед загрузкой очищаем список
        'For Each r As DataRow In iDataSet.Tables("Members_FIO").Rows
        'With cmd_TSMenu_FilterMember
        '.Items.Add(R.Item("FullName"))
        '.SelectedIndex = 0
        'End With
        'Next
        'Else
        'cmd_TSMenu_FilterMember.Items.Clear()                               ' Очищение cmd_TSMenu_FilterMember
        'End If

        EventChangedControl = True ' Включаем обработку событий в контролах
        ' Если грид непустой то, активируем строку по индексу в переменной
        If Me.PIR1_DGView_PetitionsDebt.RowCount <> 0 Then
            '**** Активация грида с Исками
            ' Установка жирного шрифта для итогов
            Me.PIR1_DGView_PetitionsDebt.Rows(Me.PIR1_DGView_PetitionsDebt.Rows.GetLastRow(DataGridViewElementStates.Visible)).DefaultCellStyle.Font = _
                                                    New System.Drawing.Font("Microsoft Sans Serif", _
                                                                            8.25!, _
                                                                            System.Drawing.FontStyle.Bold, _
                                                                            System.Drawing.GraphicsUnit.Point, _
                                                                            CType(204, Byte))
            If iSelectRowDGView_PetitionsDebt >= Me.PIR1_DGView_PetitionsDebt.RowCount - 1 Or iSelectRowDGView_PetitionsDebt = -1 Then ' если индекс активной строки >= 0
                iSelectRowDGView_PetitionsDebt = 0
            End If
            ' то, активируем строку по индексу из переменной
            Me.PIR1_DGView_PetitionsDebt.CurrentCell = PIR1_DGView_PetitionsDebt _
                                                    .Rows(iSelectRowDGView_PetitionsDebt) _
                                                    .Cells(PIR1_DGView_PetitionsDebt.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Name)
            Me.PIR1_DGView_PetitionsDebt.SelectedCells(PIR1_DGView_PetitionsDebt.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Index).Selected = True
            '
            '
        End If
        Fill_DGView_PetitionsDebt()         ' Разноска информации по полям
        MessageStatusStrip("Готово...", Processing)                             ' Сообщение об операции
    End Sub

    Private Sub PIR1_DGView_PetitionsDebt_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PIR1_DGView_PetitionsDebt.SelectionChanged
        If EventChangedControl Then
            ' Если грид не пустой и текущая строка активна
            If Me.PIR1_DGView_PetitionsDebt.RowCount <> 0 Then
                If Me.PIR1_DGView_PetitionsDebt.CurrentRow.Selected Then
                    ' если была попытка выделить последнюю строку
                    If Me.PIR1_DGView_PetitionsDebt.CurrentRow.Index = PIR1_DGView_PetitionsDebt.Rows.GetLastRow(DataGridViewElementStates.Visible) Then
                        ' отменяем выделение активируем строку по номеру в переменной

                        If iSelectRowDGView_PetitionsDebt >= Me.PIR1_DGView_PetitionsDebt.RowCount - 1 Or iSelectRowDGView_PetitionsDebt = -1 Then ' если индекс активной строки >= 0
                            iSelectRowDGView_PetitionsDebt = 0
                        End If
                        ' то, активируем строку по индексу из переменной
                        Me.PIR1_DGView_PetitionsDebt.CurrentCell = PIR1_DGView_PetitionsDebt _
                                                                .Rows(iSelectRowDGView_PetitionsDebt) _
                                                                .Cells(PIR1_DGView_PetitionsDebt.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Name)
                        Me.PIR1_DGView_PetitionsDebt.SelectedCells(PIR1_DGView_PetitionsDebt.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Index).Selected = True
                    Else
                        Fill_DGView_PetitionsDebt()
                        Fill_DGView_CopsWork()
                        ' Запись в переменную номера активной строки DGView_PrMembers
                        iSelectRowDGView_PetitionsDebt = Me.PIR1_DGView_PetitionsDebt.CurrentRow.Index
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub PIR1_DGView_PetitionsDebt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PIR1_DGView_PetitionsDebt.KeyDown
        ' Удаление записи кнопкой DELETE
        ' Если грид не пустой или всего с одной записью
        Dim CurRow As Object = Me.PIR1_DGView_PetitionsDebt.CurrentRow        ' Активная строка на гриде
        Dim lRow As Integer = Me.PIR1_DGView_PetitionsDebt.Rows.Count         ' Количество строк на гриде
        If lRow <> 0 And CurRow.Index <> lRow - 1 Then _
        If e.KeyCode = Keys.Delete Then Me.PIR1_Btn_DeletePetitionDebt_Click(sender, e)
    End Sub

    ' Разноска информации по полям
    Private Sub Fill_DGView_PetitionsDebt()
        Dim CurRow As Object = Me.PIR1_DGView_PetitionsDebt.CurrentRow        ' Активная строка на гриде
        Dim lRow As Integer = Me.PIR1_DGView_PetitionsDebt.Rows.Count         ' Последняя строка на гриде
        ' Если грид не пустой 
        If lRow <> 0 Then
            ' Включение всех контролов на вкладке TabControl
            For Each e As Control In Me.PIR1_TP_PetitionsDebt.Controls
                e.Enabled = True
            Next
            ' Включаем кнопки управления исками
            Me.PIR1_Btn_DeletePetitionDebt.Enabled = True
            Me.PIR1_Btn_SavePetitionDebt.Enabled = True
            Me.PIR1_Btn_Filter.Enabled = True
            Me.PIR1_Btn_Reports.Enabled = True
            EventChangedControl = False
            ' Загрузка платежных ордеров по иску
            GetPr_PayOrders(CurRow.Cells("AbonentId").Value, _
                            CurRow.Cells("MemberId").Value, _
                            "'" & CurRow.Cells("DtPeriodStart").Value & "'", _
                            "'" & CurRow.Cells("DtPeriodEnd").Value & "'", _
                            CurRow.Cells("EnergyTypeId").Value)
            ' Если ордера по иску имеются 
            If iDataSet.Tables("PayOrders").Rows.Count <> 0 Then
                ' то значок рубря активен
                Me.Pic_PayOrders.Visible = True
            Else
                ' иначе то значок рубря НЕ активен
                Me.Pic_PayOrders.Visible = False
            End If

            ' **** Загрузка слушаний по иску
            GetPr_PetitionsListening(CurRow.Cells("AbonentId").Value.ToString, _
            CurRow.Cells("MemberId").Value.ToString, _
            "'" & CurRow.Cells("DtPeriodStart").Value.ToString & "'", _
            "'" & CurRow.Cells("DtPeriodEnd").Value.ToString & "'", _
            CurRow.Cells("EnergyTypeId").Value.ToString)

            ' **** Активация грида со слушаниями
            ' Если грид слушаний не пустой
            If Me.PIR1_DGView_ListeningHistory.RowCount <> 0 Then
                ' Включение всех контролов управления слушаниями
                Me.PIR1_Btn_AddNewListening.Enabled = True
                Me.PIR1_Btn_EditListening.Enabled = True
                Me.PIR1_Btn_DeleteListening.Enabled = True
                If iSelectRowDGView_Listeneng >= 0 And iSelectRowDGView_Listeneng < Me.PIR1_DGView_ListeningHistory.RowCount Then ' если индекс активной строки >= 0
                    ' то, активируем строку по индексу
                    Me.PIR1_DGView_ListeningHistory.CurrentCell = PIR1_DGView_ListeningHistory _
                                                                  .Rows(iSelectRowDGView_Listeneng) _
                                                                  .Cells(PIR1_DGView_ListeningHistory.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Name)
                Else ' иначе, активируем первую строку
                    Me.PIR1_DGView_ListeningHistory.CurrentCell = PIR1_DGView_ListeningHistory _
                                                                    .Rows(0) _
                                                                    .Cells(PIR1_DGView_ListeningHistory.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Name)
                End If
            Else ' Если грид пустой
                ' Выключение всех контролов управления слушаниями 
                ' кроме кнопки добавить
                Me.PIR1_Btn_AddNewListening.Enabled = True
                Me.PIR1_Btn_EditListening.Enabled = False
                Me.PIR1_Btn_DeleteListening.Enabled = False
            End If

            ' **** Загрузка материалов исполнительно производства (МИП)
            SelectQueryData("Petitions", _
 _
                            "EXEC  Pr_AbonentsPetitions  @AbonentId = " & CurRow.Cells("AbonentId").Value.ToString & ", " & _
                                                        "@MemberId = " & CurRow.Cells("MemberId").Value.ToString & ", " & _
                                                        "@DtPeriodStart = '" & CurRow.Cells("DtPeriodStart").Value.ToString & "', " & _
                                                        "@DtPeriodEnd = '" & CurRow.Cells("DtPeriodEnd").Value.ToString & "', " & _
                                                        "@EnergyTypeId = " & CurRow.Cells("EnergyTypeId").Value.ToString & ", " & _
                                                        "@Function = 1", _
 _
                            "Fill_DGView_PetitionsDebt") ' Выборка МИП

            ' **** Активация грида с МИП
            ' Если грид c МИП не пустой
            If Me.PIR1_DGView_Petitions.RowCount <> 0 Then
                ' Включение всех контролов управления МИП
                Me.PIR1_Btn_AddNewPetition.Enabled = True
                Me.PIR1_Btn_DeletePetition.Enabled = True
                If iSelectRowDGView_Petitions >= 0 And iSelectRowDGView_Petitions < Me.PIR1_DGView_Petitions.RowCount Then ' если индекс активной строки >= 0
                    ' то, активируем строку по индексу
                    Me.PIR1_DGView_Petitions.CurrentCell = PIR1_DGView_Petitions _
                                                                  .Rows(iSelectRowDGView_Petitions) _
                                                                  .Cells(PIR1_DGView_Petitions.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Name)
                Else ' иначе, активируем первую строку
                    Me.PIR1_DGView_Petitions.CurrentCell = PIR1_DGView_Petitions _
                                                                    .Rows(0) _
                                                                    .Cells(PIR1_DGView_Petitions.Columns.GetFirstColumn(DataGridViewElementStates.Visible).Name)
                End If
                Fill_DGView_CopsWork()
            Else ' Если грид пустой
                ' Выключение всех контролов управления МИП 
                ' кроме кнопки добавить
                Fill_DGView_CopsWork()
            End If
            ' ******************************
            ' Заполнение всех полей с информацией по иску
            Me.PIR1_txt_DtPeriodStart.Text = ConvertToNull(CurRow.Cells("DtPeriodStart").Value.ToString, False, 1)
            Me.PIR1_txt_DtPeriodEnd.Text = ConvertToNull(CurRow.Cells("DtPeriodEnd").Value.ToString, False, 1)
            Me.PIR1_cmb_EnergyType.Text = CurRow.Cells("EnergyType").Value.ToString
            Me.PIR1_cmb_PetitionType.Text = CurRow.Cells("PetitionType").Value.ToString
            Me.PIR1_txt_DebtSumm.Text = OutBD_Money(CurRow.Cells("DebtSumm").Value.ToString, 0, "N")
            Me.PIR1_txt_GovTax.Text = OutBD_Money(CurRow.Cells("GovTax").Value.ToString, 0, "N")
            Me.PIR1_txt_NumberPetition.Text = CurRow.Cells("NumberPetitions").Value.ToString
            Me.PIR1_cmb_CourtType.Text = ConvertToNull(CurRow.Cells("CourtType").Value.ToString, False, 0)

            ' Обработка зависимостей судебной инстанции и судебных участков
            GetPr_JudicialArea(Me.PIR1_cmb_CourtType.SelectedValue)        ' Выборка номеров судебных участков
            ' Заполнение PIR1_cmb_JudicialArea судебных участков
            With Me.PIR1_cmb_JudicialArea
                .DataSource = iDataSet.Tables("JudicialArea")
                .DisplayMember = "NameString"
                .ValueMember = "JudicialAreaId"
                .Text = ConvertToNull(CurRow.Cells("JudicialNumber").Value.ToString, False, 0)
            End With
            ' Me.PIR1_cmb_JudicialArea.Text = ConvertToNull(CurRow.Cells("JudicialNumber").Value.ToString, False, 0)

            Me.PIR1_txt_DtPetitions.Text = ConvertToNull(CurRow.Cells("DtPetitions").Value.ToString, False, 1)
            Me.PIR1_txt_DtDispatch.Text = ConvertToNull(CurRow.Cells("DtDispatch").Value.ToString, False, 1)
            Me.PIR1_txt_DtDecision.Text = ConvertToNull(CurRow.Cells("DtDecision").Value.ToString, False, 1)
            Me.PIR1_txt_DealNumber.Text = ConvertToNull(CurRow.Cells("DealNumber").Value.ToString, False, 0)
            Me.PIR1_txt_DebtSummAfterDecision.Text = OutBD_Money(CurRow.Cells("DebtSummAfterDecision").Value.ToString, 0, "N")
            Me.PIR1_cmb_DecisionType.Text = CurRow.Cells("DecisionType").Value.ToString
            Me.PIR1_txt_DtJudicialOrder.Text = ConvertToNull(CurRow.Cells("DtJudicialOrder").Value.ToString, False, 1)
            Me.PIR1_txt_DecisionNumber.Text = CurRow.Cells("DecisionNumber").Value.ToString
            Me.PIR1_cmb_DecisionDirection.Text = CurRow.Cells("DecisionDirection").Value.ToString
            Me.PIR1_txt_DtDecisionDirection.Text = ConvertToNull(CurRow.Cells("DtDecisionDirection").Value.ToString, False, 1)
            Me.PIR1_txt_DtClosePetitionDebt.Text = ConvertToNull(CurRow.Cells("DtClose").Value.ToString, False, 1)
            Me.PIR1_cmb_ReasonForEnd.Text = CurRow.Cells("ReasonForEnd").Value.ToString
            Me.PIR1_txt_Note.Text = CurRow.Cells("Note").Value.ToString
            Me.RecordSetInfo.Text = CurRow.Cells("PackName").Value.ToString
            ' Отдельная обработка подпричин решения суда
            If Me.PIR1_cmb_DecisionType.Text <> "" Then
                Me.PIR1_cmb_DecisionTypeExt.Enabled = True                      ' Элемент доступен
                GetPr_DecisionTypeExt(1, PIR1_cmb_DecisionType.SelectedValue)   ' Выборка причин решения суда
                ' Заполнение PIR1_cmb_DecisionTypeExt причин решения суда
                With Me.PIR1_cmb_DecisionTypeExt
                    .Enabled = True
                    .DataSource = iDataSet.Tables("DecisionTypeExt")
                    .DisplayMember = "Name"
                    .ValueMember = "DecisionTypeExtId"
                    .Text = CurRow.Cells("DecisionTypeExt").Value.ToString
                End With
            Else
                Me.PIR1_cmb_DecisionTypeExt.DataSource = Nothing                ' Очищаем привязку к данным базы
                Me.PIR1_cmb_DecisionTypeExt.Enabled = False                     ' Отключаем элемент
            End If

            EventChangedControl = True                  ' Включение обработки событий изменения значений контролов
        Else
            ClearDataCurrentPetitionDebt()              ' Чистка всех полей по иску
            ClearData_CopsWork()                        ' Чистка всех полей МИП
            Me.PIR1_Btn_AddNewPetition.Enabled = False  ' Так как исков нет, нельзя добать ИП
            Me.PIR1_Btn_Reports.Enabled = False
        End If
        ' После всех заполнений отключаем кнопку сохранить до след-их изменнений
        Me.PIR1_Btn_SavePetitionDebt.Enabled = False
    End Sub

    ' Чистка всех полей с информацие по текущему иску
    Private Sub ClearDataCurrentPetitionDebt()
        EventChangedControl = False    ' Отключение обработки событий PIR1_cmb_DecisionType
        Me.PIR1_txt_DtPeriodStart.Text = Nothing : Me.PIR1_txt_DtPeriodEnd.Text = Nothing
        Me.PIR1_cmb_EnergyType.Text = Nothing : Me.PIR1_cmb_PetitionType.Text = Nothing
        Me.PIR1_cmb_CourtType.Text = Nothing : Me.PIR1_cmb_JudicialArea.Text = Nothing
        Me.PIR1_txt_DebtSumm.Text = Nothing : Me.PIR1_txt_GovTax.Text = Nothing
        Me.PIR1_txt_NumberPetition.Text = Nothing : Me.PIR1_txt_DtPetitions.Text = Nothing
        Me.PIR1_txt_DtDispatch.Text = Nothing : Me.PIR1_txt_Note.Text = Nothing
        Me.PIR1_txt_DtDecision.Text = Nothing : Me.PIR1_txt_DebtSummAfterDecision.Text = Nothing
        Me.PIR1_cmb_DecisionType.Text = Nothing : Me.PIR1_txt_DtJudicialOrder.Text = Nothing
        Me.PIR1_txt_DecisionNumber.Text = Nothing : Me.PIR1_txt_DealNumber.Text = Nothing
        Me.PIR1_cmb_DecisionTypeExt.Text = Nothing : Me.PIR1_cmb_DecisionDirection.Text = Nothing
        Me.RecordSetInfo.Text = Nothing
        EventChangedControl = True     ' Включение обработки событий PIR1_cmb_DecisionType

        ' Отключение всех контролов на вкладке TabControl
        For Each e As Control In PIR1_TP_PetitionsDebt.Controls
            e.Enabled = False
        Next
        ' Отключаем кнопки управления исками
        Me.PIR1_Btn_DeletePetitionDebt.Enabled = False
        Me.PIR1_Btn_SavePetitionDebt.Enabled = False : Me.PIR1_Btn_Filter.Enabled = False
        ' Отключаем кнопки управления слушаниями
        Me.PIR1_Btn_AddNewListening.Enabled = False
        Me.PIR1_Btn_EditListening.Enabled = False
        Me.PIR1_Btn_DeleteListening.Enabled = False
        iDataSet.Tables("PetitionsListening").Clear()
        ' Скрываем отметку что есть платежный ордер
        Me.Pic_PayOrders.Visible = False
    End Sub

    ' отображение подпричин решения суда в зависимости от самого решения
    Private Sub PIR1_cmb_DecisionType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PIR1_cmb_DecisionType.SelectedIndexChanged
        ' Если решения суда нет то,  нет и причин решения
        If Me.PIR1_cmb_DecisionType.Text = "" Then
            Me.PIR1_cmb_DecisionTypeExt.DataSource = Nothing                ' Очищаем привязку к данным базы
            Me.PIR1_cmb_DecisionTypeExt.Enabled = False                     ' Отключаем элемент
        Else
            If EventChangedControl Then
                ' Если обработка не включена то событие не происходит
                GetPr_DecisionTypeExt(1, PIR1_cmb_DecisionType.SelectedValue) ' Выборка причин решения суда
                ' Заполнение PIR1_cmb_DecisionTypeExt причин решения суда
                With Me.PIR1_cmb_DecisionTypeExt
                    .Enabled = True
                    .DataSource = iDataSet.Tables("DecisionTypeExt")
                    .DisplayMember = "Name"
                    .ValueMember = "DecisionTypeExtId"
                End With
            End If
        End If
    End Sub

    ' Обработка событий текстовых полей
    ' Обработка полей с датами
    Private Sub PIR1_txt_DtPeriodStart_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PIR1_txt_DtPeriodStart.Leave
        ' Проверка корректности периода и последовательности дат
        If Me.PIR1_txt_DtPeriodEnd.Text <> "__.__.____" Then _
        ValidateOfDateDiff(Me.PIR1_txt_DtPeriodStart.Text, Me.PIR1_txt_DtPeriodEnd.Text, sender, "Неверно указан период задолженности....")
    End Sub
    Private Sub PIR1_txt_DtPeriodStart_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PIR1_txt_DtPeriodStart.MouseClick
        DateMaskEvents("MouseClick", sender)
    End Sub
    Private Sub PIR1_txt_DtPeriodStart_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PIR1_txt_DtPeriodStart.KeyUp
        DateMaskEvents("KeyUp", sender, e.KeyCode)
    End Sub
    Private Sub PIR1_txt_DtPeriodStart_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PIR1_txt_DtPeriodStart.Validating
        ' Проверка корректности введенной даты
        txtMaskValidating(sender, "Введена некорректная дата! Исправьте....", "__.__.____")
        ' Проверка корректности периода если в поле не пустая маска
    End Sub
    Private Sub btn_CalPIR1_txt_DtPeriodStart_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CalPIR1_txt_DtPeriodStart.ValueChanged
        Me.PIR1_txt_DtPeriodStart.Text = sender.Text
    End Sub
    Private Sub btn_CalPIR1_txt_DtPeriodStart_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_CalPIR1_txt_DtPeriodStart.MouseEnter
        If IsDate(Me.PIR1_txt_DtPeriodStart.Text) Then sender.Value = Me.PIR1_txt_DtPeriodStart.Text
    End Sub

    Private Sub PIR1_txt_DtPeriodEnd_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PIR1_txt_DtPeriodEnd.Leave
        ' Проверка корректности периода и последовательности дат
        If Me.PIR1_txt_DtPeriodEnd.Text <> "__.__.____" Then _
        ValidateOfDateDiff(Me.PIR1_txt_DtPeriodStart.Text, Me.PIR1_txt_DtPeriodEnd.Text, sender, "Неверно указан период задолженности....")
    End Sub
    Private Sub PIR1_txt_DtPeriodEnd_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PIR1_txt_DtPeriodEnd.MouseClick
        DateMaskEvents("MouseClick", sender)
    End Sub
    Private Sub PIR1_txt_DtPeriodEnd_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PIR1_txt_DtPeriodEnd.KeyUp
        DateMaskEvents("KeyUp", sender, e.KeyCode)
    End Sub
    Private Sub PIR1_txt_DtPeriodEnd_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PIR1_txt_DtPeriodEnd.Validating
        ' Проверка корректности введенной даты
        txtMaskValidating(sender, "Введена некорректная дата! Исправьте....", "__.__.____")
        ' Проверка корректности периода если в поле не пустая маска
    End Sub
    Private Sub btn_CalPIR1_txt_DtPeriodEnd_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CalPIR1_txt_DtPeriodEnd.ValueChanged
        Me.PIR1_txt_DtPeriodEnd.Text = sender.Text
    End Sub
    Private Sub btn_CalPIR1_txt_DtPeriodEnd_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_CalPIR1_txt_DtPeriodEnd.MouseEnter
        If IsDate(Me.PIR1_txt_DtPeriodEnd.Text) Then sender.Value = Me.PIR1_txt_DtPeriodEnd.Text
    End Sub

    Private Sub PIR1_txt_DtPetitions_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PIR1_txt_DtPetitions.MouseClick
        DateMaskEvents("MouseClick", sender)
    End Sub
    Private Sub PIR1_txt_DtPetitions_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PIR1_txt_DtPetitions.KeyUp
        DateMaskEvents("KeyUp", sender, e.KeyCode)
    End Sub
    Private Sub PIR1_txt_DtPetitions_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PIR1_txt_DtPetitions.Validating
        ' Проверка корректности введенного номера
        txtMaskValidating(sender, "Введена некорректная дата! Исправьте....", "__.__.____")
    End Sub
    Private Sub btn_CalPIR1_txt_DtPetitions_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CalPIR1_txt_DtPetitions.ValueChanged
        Me.PIR1_txt_DtPetitions.Text = sender.Text
    End Sub
    Private Sub btn_CalPIR1_txt_DtPetitions_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_CalPIR1_txt_DtPetitions.MouseEnter
        If IsDate(Me.PIR1_txt_DtPetitions.Text) Then sender.Value = Me.PIR1_txt_DtPetitions.Text
    End Sub

    Private Sub PIR1_txt_DtDispatch_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PIR1_txt_DtDispatch.MouseClick
        DateMaskEvents("MouseClick", sender)
    End Sub
    Private Sub PIR1_txt_DtDispatch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PIR1_txt_DtDispatch.KeyUp
        DateMaskEvents("KeyUp", sender, e.KeyCode)
    End Sub
    Private Sub PIR1_txt_DtDispatch_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PIR1_txt_DtDispatch.Validating
        ' Проверка корректности введенного номера
        txtMaskValidating(sender, "Введена некорректная дата! Исправьте....", "__.__.____")
    End Sub
    Private Sub btn_CalPIR1_txt_DtDispatch_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CalPIR1_txt_DtDispatch.ValueChanged
        Me.PIR1_txt_DtDispatch.Text = sender.Text
    End Sub
    Private Sub btn_CalPIR1_txt_DtDispatch_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_CalPIR1_txt_DtDispatch.MouseEnter
        If IsDate(Me.PIR1_txt_DtDispatch.Text) Then sender.Value = Me.PIR1_txt_DtDispatch.Text
    End Sub

    Private Sub PIR1_txt_DtDecision_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PIR1_txt_DtDecision.MouseClick
        DateMaskEvents("MouseClick", sender)
    End Sub
    Private Sub PIR1_txt_DtDecision_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PIR1_txt_DtDecision.KeyUp
        DateMaskEvents("KeyUp", sender, e.KeyCode)
    End Sub
    Private Sub PIR1_txt_DtDecision_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PIR1_txt_DtDecision.Validating
        ' Проверка корректности введенного номера
        If txtMaskValidating(sender, "Введена некорректная дата! Исправьте....", "__.__.____") = True Then
            If Me.PIR1_txt_DebtSummAfterDecision.Text = "" And Me.PIR1_DGView_PetitionsDebt.RowCount <> 0 Then _
                Me.PIR1_txt_DebtSummAfterDecision.Text = Me.PIR1_DGView_PetitionsDebt.CurrentRow.Cells("DebtSumm").Value.ToString
            If sender.Text = "__.__.____" Then Me.PIR1_txt_DebtSummAfterDecision.Text = ""
        End If
    End Sub
    Private Sub btn_CalPIR1_txt_DtDecision_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CalPIR1_txt_DtDecision.ValueChanged
        Me.PIR1_txt_DtDecision.Text = sender.Text
        If Me.PIR1_txt_DebtSummAfterDecision.Text = "" And Me.PIR1_DGView_PetitionsDebt.RowCount <> 0 Then _
        Me.PIR1_txt_DebtSummAfterDecision.Text = Me.PIR1_DGView_PetitionsDebt.CurrentRow.Cells("DebtSumm").Value.ToString
        If sender.Text = "" Then Me.PIR1_txt_DebtSummAfterDecision.Text = ""
        ' Если решение суда выбран "Судебный приказ" то дата решения совпадает с датой ИЛ/СП
        If Me.PIR1_cmb_DecisionType.SelectedValue = 5 Then
            Me.PIR1_txt_DtJudicialOrder.Text = Me.PIR1_txt_DtDecision.Text()
        End If
    End Sub
    Private Sub btn_CalPIR1_txt_DtDecision_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_CalPIR1_txt_DtDecision.MouseEnter
        If IsDate(Me.PIR1_txt_DtDecision.Text) Then sender.Value = Me.PIR1_txt_DtDecision.Text
    End Sub

    Private Sub PIR1_txt_DtJudicialOrder_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PIR1_txt_DtJudicialOrder.MouseClick
        DateMaskEvents("MouseClick", sender)
    End Sub
    Private Sub PIR1_txt_DtJudicialOrder_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PIR1_txt_DtJudicialOrder.KeyUp
        DateMaskEvents("KeyUp", sender, e.KeyCode)
    End Sub
    Private Sub PIR1_txt_DtJudicialOrder_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PIR1_txt_DtJudicialOrder.Validating
        ' Проверка корректности введенного номера
        txtMaskValidating(sender, "Введена некорректная дата! Исправьте....", "__.__.____")
    End Sub
    Private Sub btn_CalPIR1_txt_DtDtJudicialOrder_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CalPIR1_txt_DtDtJudicialOrder.ValueChanged
        Me.PIR1_txt_DtJudicialOrder.Text = sender.Text
    End Sub
    Private Sub btn_CalPIR1_txt_DtDtJudicialOrder_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_CalPIR1_txt_DtDtJudicialOrder.MouseEnter
        If IsDate(Me.PIR1_txt_DtJudicialOrder.Text) Then sender.Value = Me.PIR1_txt_DtJudicialOrder.Text
    End Sub

    Private Sub PIR1_txt_DtDecisionDirection_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PIR1_txt_DtDecisionDirection.MouseClick
        DateMaskEvents("MouseClick", sender)
    End Sub
    Private Sub PIR1_txt_DtDecisionDirection_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PIR1_txt_DtDecisionDirection.KeyUp
        DateMaskEvents("KeyUp", sender, e.KeyCode)
    End Sub
    Private Sub PIR1_txt_DtDecisionDirection_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PIR1_txt_DtDecisionDirection.Validating
        ' Проверка корректности введенного номера
        txtMaskValidating(sender, "Введена некорректная дата! Исправьте....", "__.__.____")
    End Sub
    Private Sub btn_CalPIR1_txt_DtDecisionDirection_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CalPIR1_txt_DtDecisionDirection.ValueChanged
        Me.PIR1_txt_DtDecisionDirection.Text = sender.Text
    End Sub
    Private Sub btn_CalPIR1_txt_DtDecisionDirection_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_CalPIR1_txt_DtDecisionDirection.MouseEnter
        If IsDate(Me.PIR1_txt_DtDecisionDirection.Text) Then sender.Value = Me.PIR1_txt_DtDecisionDirection.Text
    End Sub

    Private Sub PIR1_txt_DtClosePetitionDebt_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PIR1_txt_DtClosePetitionDebt.MouseClick
        DateMaskEvents("MouseClick", sender)
    End Sub
    Private Sub PIR1_txt_DtClosePetitionDebt_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PIR1_txt_DtClosePetitionDebt.KeyUp
        DateMaskEvents("KeyUp", sender, e.KeyCode)
    End Sub
    Private Sub PIR1_txt_DtClosePetitionDebt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PIR1_txt_DtClosePetitionDebt.Validating
        ' Проверка корректности введенного номера
        txtMaskValidating(sender, "Введена некорректная дата! Исправьте....", "__.__.____")
    End Sub
    Private Sub btn_CalPIR1_txt_DtClosePetitionDebt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CalPIR1_txt_DtClosePetitionDebt.ValueChanged
        Me.PIR1_txt_DtClosePetitionDebt.Text = sender.Text
    End Sub
    Private Sub btn_CalPIR1_txt_DtClosePetitionDebt_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_CalPIR1_txt_DtClosePetitionDebt.MouseEnter
        If IsDate(Me.PIR1_txt_DtClosePetitionDebt.Text) Then sender.Value = Me.PIR1_txt_DtClosePetitionDebt.Text
    End Sub

    ' Обработка денежных полей
    Private Sub PIR1_txt_DebtSumm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PIR1_txt_DebtSumm.KeyPress
        ' Проверка корректности вводимых данных (только цыфры, и ограниченное количество символов)
        MoneyTextBox_Numbers(sender, e)
    End Sub
    Private Sub PIR1_txt_DebtSumm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PIR1_txt_DebtSumm.Click
        MoneyTextBox_EnterLeave(sender, e, "Click", "G")
    End Sub
    Private Sub PIR1_txt_DebtSumm_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PIR1_txt_DebtSumm.Leave
        MoneyTextBox_EnterLeave(sender, e, "Leave", "N")
        ' Если сумма иска не указана то, очищаем гос.пошлину
        If sender.Text = "" Then Me.PIR1_txt_GovTax.Text = Nothing
    End Sub
    Private Sub PIR1_txt_DebtSumm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles PIR1_txt_DebtSumm.LostFocus
        ' Расчет гос.пошлины
        If PIR1_cmb_PetitionType.Text = "" Then
            XtraMessageBox.Show("Невозможно произвести расчет Гос.пошлины, так как неуказан тип иска!", _
                "Расчет госпошлины...", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ' Me.PIR1_cmb_PetitionType.Focus()                ' Фокус на контрол
            ' Me.PIR1_cmb_PetitionType.DroppedDown = True     ' Разворачиваем список,
        Else
            ' Расчитываем госпошлину
            If sender.Text <> "" Then CalculateGovTax(sender.Text, PIR1_cmb_PetitionType, PIR1_txt_GovTax)
        End If
    End Sub

    Private Sub PIR1_txt_DebtSummAfterDecision_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PIR1_txt_DebtSummAfterDecision.KeyPress
        ' Проверка корректности вводимых данных (только цыфры, и ограниченное количество символов)
        MoneyTextBox_Numbers(sender, e)
    End Sub
    Private Sub PIR1_txt_DebtSummAfterDecision_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PIR1_txt_DebtSummAfterDecision.Click
        MoneyTextBox_EnterLeave(sender, e, "Click", "G")
    End Sub
    Private Sub PIR1_txt_DebtSummAfterDecision_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PIR1_txt_DebtSummAfterDecision.Leave
        MoneyTextBox_EnterLeave(sender, e, "Leave", "N")
    End Sub

    ' Обработка поля с регистрационным номером
    Private Sub PIR1_txt_NumberPetitionDebt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PIR1_txt_NumberPetition.Click
        Dim iPrefix As String = pref_DivisionIndex ' Берем преффикс из настроек
        ' Если поле пустое
        If sender.Text = "" Then
            sender.Text = iPrefix                                                   ' Заносим регистрационный префикс
            sender.Select(iPrefix.Length, sender.TextLength - iPrefix.Length)       ' Выделяем весь текст который после регистрационного префикса
        Else
            ' если вход в поле не осуществлен
            If iEnter Then
                sender.Select(iPrefix.Length, sender.TextLength - iPrefix.Length)   ' Выделяем весь текст который после регистрационного префикса 
                iEnter = False                                             ' Поле активно, больше не выделяем
            End If
        End If
    End Sub
    Private Sub PIR1_txt_NumberPetitionDebt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles PIR1_txt_NumberPetition.LostFocus
        Dim iPrefix As String = pref_DivisionIndex   ' Берем преффикс из настроек
        If sender.Text = iPrefix Then sender.Text = Nothing ' Если ввели только префикс поле очищается
        iEnter = True                              ' Поле НЕ активно, больше не выделяем
    End Sub
    Private Sub PIR1_txt_NumberPetitionDebt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PIR1_txt_NumberPetition.KeyPress
        ' Если нажата BackSpace и поле остался только префикс, то отменяем стирание
        If Asc(e.KeyChar) = 8 And sender.Text = pref_DivisionIndex Then e.Handled = True
    End Sub

    ' Обработка поля для пометок
    Private Sub PIR1_txt_Note_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles PIR1_txt_Note.GotFocus
        Time_NoteResize.Start() ' Старт таймера
    End Sub
    Private Sub PIR1_txt_Note_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles PIR1_txt_Note.LostFocus
        Time_NoteResize.Start() ' Старт таймера
        iEnter = True  ' Поле НЕ активно
    End Sub
    Private Sub PIR1_txt_Note_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PIR1_txt_Note.Click
        ' если вход в поле не осуществлен
        If iEnter Then
            sender.Select(sender.TextLength, sender.TextLength - sender.TextLength)     ' Устанавливаем курсор в конец текста 
            iEnter = False                                                     ' Поле активно
        End If
    End Sub
    Private Sub Time_NoteResize_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Time_NoteResize.Tick
        ' Если панель в обычном состоянии
        If Me.Group_Petition.Height = 224 Then
            ' ...то пока высота ее не станет 179
            Do While Me.Group_Petition.Height <> 179
                Me.Group_Petition.Height = Group_Petition.Height - 1                    ' Уменьшаем панель
                Me.PIR1_txt_Note.Height = PIR1_txt_Note.Height + 1                      ' Увеличиваем текстовое поле
                Me.PIR1_txt_Note.Location = _
                    New Point(PIR1_txt_Note.Location.X, PIR1_txt_Note.Location.Y - 1)   ' И перемещаем текстовое поле вверх
            Loop
            Time_NoteResize.Stop()
        Else ' если пенель уже сжата
            ' ...то пока высота ее не станет 224
            Do While Me.Group_Petition.Height <> 224
                Me.Group_Petition.Height = Group_Petition.Height + 1                    ' Увеличиваем панель
                Me.PIR1_txt_Note.Height = PIR1_txt_Note.Height - 1                      ' Уменьшаем текстовое поле
                Me.PIR1_txt_Note.Location = _
                    New Point(PIR1_txt_Note.Location.X, PIR1_txt_Note.Location.Y + 1)   ' И перемещаем текстовое поле вниз
            Loop
            Time_NoteResize.Stop() ' Останавливаем таймер
        End If
    End Sub

    ' При изменении типа иска перерасчет гос.пошлины
    Private Sub PIR1_cmb_PetitionType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If EventChangedControl Then
            If Me.PIR1_txt_DebtSumm.Text <> "" Then
                ' Расчитываем госпошлину
                CalculateGovTax(Me.PIR1_txt_DebtSumm.Text, sender, PIR1_txt_GovTax)
            End If
        End If
    End Sub

    ' При изменении судебной инстанции обновляем судеьные участки
    Private Sub PIR1_cmb_CourtType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PIR1_cmb_CourtType.SelectedIndexChanged
        If EventChangedControl Then
            GetPr_JudicialArea(Me.PIR1_cmb_CourtType.SelectedValue)        ' Выборка номеров судебных участков
            ' Если выбранная судебная инстанция совпадает с тем что в гриде, участов возвращаем из грида
            If Me.PIR1_cmb_CourtType.SelectedValue = ConvertToNull(Me.PIR1_DGView_PetitionsDebt.CurrentRow.Cells("CourtTypeId").Value.ToString, False, 0) Then
                Me.PIR1_cmb_JudicialArea.Text = ConvertToNull(Me.PIR1_DGView_PetitionsDebt.CurrentRow.Cells("JudicialNumber").Value.ToString, False, 0)
            End If
        End If
    End Sub

#Region "Управление слушаниями"
    ' Добавить новое слушание
    Private Sub PIR1_Btn_AddNewListening_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PIR1_Btn_AddNewListening.Click
        AddOrEdit = 2
        If frListeningControl.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ' Переменная номера активной строки гриды равен кол-ву строк
            iSelectRowDGView_Listeneng = Me.PIR1_DGView_ListeningHistory.RowCount
            Fill_DGView_PetitionsDebt() ' Обновление полей
        End If
        frListeningControl.Dispose()
    End Sub
    ' Изменить текущее слушание
    Private Sub PIR1_Btn_EditListening_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PIR1_Btn_EditListening.Click
        AddOrEdit = 3
        If frListeningControl.ShowDialog() = Windows.Forms.DialogResult.OK Then Fill_DGView_PetitionsDebt()
        frListeningControl.Dispose()
    End Sub
    ' Удалить текущее слушание
    Private Sub PIR1_Btn_DeleteListening_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PIR1_Btn_DeleteListening.Click
        Dim CurRow As Object = Me.PIR1_DGView_ListeningHistory.CurrentRow      ' Активная строка на гриде
        If PIR1_DGView_ListeningHistory.Rows.Count <> 0 Then
            ' Вопрос перед удалением
            Select Case XtraMessageBox.Show("Слушание назначенное на " & CurRow.Cells("DtListening").Value & " будет удалено! Вы согласны?", _
                                                                                "Внимание! Удаление без возможности восстановления", _
                                                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.Yes                       ' Ok
                    If Delete_PrPetitionsListening(CurRow.Cells("AbonentId").Value, _
                         CurRow.Cells("MemberId").Value, _
                         "'" & CurRow.Cells("DtPeriodStart").Value & "'", _
                         "'" & CurRow.Cells("DtPeriodEnd").Value & "'", _
                         CurRow.Cells("EnergyTypeId").Value, _
                         "'" & CurRow.Cells("DtListening").Value & "'") Then
                        ' Уменьшаем значение номера текущей строки грида слушаний
                        iSelectRowDGView_Listeneng = iSelectRowDGView_Listeneng - 1
                        With New frInfo
                            .Mess = "Слушание удалено..."
                            .Show()                         ' Всплываюшее сообщение
                        End With
                        Fill_DGView_PetitionsDebt()              ' Обновление полей
                    End If
                Case DialogResult.Cancel                    ' Cancel
            End Select
        End If
    End Sub
#End Region

    ' Заполнение полей при активации строки на гриде со слушаниями    
    Private Sub PIR1_DGView_ListeningHistory_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PIR1_DGView_ListeningHistory.SelectionChanged
        Dim lRow As Integer = Me.PIR1_DGView_ListeningHistory.Rows.Count       ' Кол - во строк на гриде
        If EventChangedControl Then
            If lRow <> 0 Then iSelectRowDGView_Listeneng = Me.PIR1_DGView_ListeningHistory.CurrentRow.Index
        End If
    End Sub
    Private Sub PIR1_DGView_ListeningHistory_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PIR1_DGView_ListeningHistory.KeyDown
        ' Удаление записи кнопкой DELETE
        ' Если грид не пустой или всего с одной записью
        Dim CurRow As Object = Me.PIR1_DGView_ListeningHistory.CurrentRow        ' Активная строка на гриде
        Dim lRow As Integer = Me.PIR1_DGView_ListeningHistory.Rows.Count         ' Количество строк на гриде
        If lRow <> 0 Then _
        If e.KeyCode = Keys.Delete Then Me.PIR1_Btn_DeleteListening_Click(sender, e)
    End Sub
    ' Запуск управления платежными ордерами
    Private Sub Link_PayOrders_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Link_PayOrders.LinkClicked
        EventChangedControl = False  ' Заранее отключаем оброботку событий в контролах
        If Me.PIR1_DGView_PetitionsDebt.CurrentRow.Selected Then
            frPayOrdersControl.ShowDialog()
            frPayOrdersControl.Dispose()
            ClickTree_Pan_1_Suit()
        End If
    End Sub

    ' Изменить. Добавить. Удалить
    Private Sub PIR1_Btn_SavePetitionDebt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PIR1_Btn_SavePetitionDebt.Click
        Dim CurRow As Object = Me.PIR1_DGView_PetitionsDebt.CurrentRow      ' Активная строка на гриде
        Dim CurRowPetit As Object = Me.PIR1_DGView_Petitions.CurrentRow     ' Активная строка на гриде
        Dim lRow As Integer = Me.PIR1_DGView_PetitionsDebt.Rows.Count       ' Последняя строка на гриде

        ' Если грид не пустой и выделенная строка не итоговая
        If PIR1_DGView_PetitionsDebt.Rows.Count <> 0 And CurRow.Index <> lRow - 1 Then
            ' Передача значений полей в текст команды запроса
            ' Сохранение данных по искам
            Dim DecisionTypeExt As String = "" ' Переменная для хранения значения подпричины решения
            If Me.PIR1_cmb_DecisionTypeExt.SelectedValue = Nothing Then
                DecisionTypeExt = "NULL"
            Else
                DecisionTypeExt = Me.PIR1_cmb_DecisionTypeExt.SelectedValue
            End If
            Update_PrPetitionsDebt(CurRow.Cells("AbonentId").Value, _
                             CurRow.Cells("MemberId").Value, _
                             "'" & CurRow.Cells("DtPeriodStart").Value & "'", _
                             "'" & CurRow.Cells("DtPeriodEnd").Value & "'", _
                             CurRow.Cells("EnergyTypeId").Value, _
                             ConvertToNull(Me.PIR1_txt_DtPeriodStart.Text, True, 1, "__.__.____"), _
                             ConvertToNull(Me.PIR1_txt_DtPeriodEnd.Text, True, 1, "__.__.____"), _
                             Me.PIR1_DGView_PetitionsDebt.CurrentRow.Cells("EnergyTypeId").Value, _
                             OutBD_Money(Me.PIR1_txt_DebtSumm.Text, 1, "G"), _
                             OutBD_Money(Me.PIR1_txt_GovTax.Text, 1, "G"), _
                             ConvertToNull(Me.PIR1_cmb_CourtType.SelectedValue.ToString, True, 0), _
                             "'" & CurRow.Cells("PetitionTypeId").Value & "'", _
                             ConvertToNull(Me.PIR1_txt_NumberPetition.Text, True, 0), _
                             ConvertToNull(Me.PIR1_txt_DtPetitions.Text, True, 1, "__.__.____"), _
                             ConvertToNull(Me.PIR1_txt_DtDispatch.Text, True, 1, "__.__.____"), _
                             ConvertToNull(Me.PIR1_txt_DtDecision.Text, True, 1, "__.__.____"), _
                             ConvertToNull(Me.PIR1_txt_DealNumber.Text, True, 0), _
                             OutBD_Money(Me.PIR1_txt_DebtSummAfterDecision.Text, 1, "G"), _
                             ConvertToNull(Me.PIR1_cmb_JudicialArea.SelectedValue.ToString, True, 0), _
                             ConvertToNull(Me.PIR1_txt_DecisionNumber.Text, True, 0), _
                             ConvertToNull(Me.PIR1_cmb_DecisionType.SelectedValue.ToString, True, 0), _
                             DecisionTypeExt, _
                             ConvertToNull(Me.PIR1_cmb_DecisionDirection.SelectedValue.ToString, True, 0), _
                             ConvertToNull(Me.PIR1_txt_DtDecisionDirection.Text, True, 1, "__.__.____"), _
                             ConvertToNull(Me.PIR1_txt_DtJudicialOrder.Text, True, 1, "__.__.____"), _
                             ConvertToNull(Me.PIR1_txt_DtClosePetitionDebt.Text, True, 1, "__.__.____"), _
                             ConvertToNull(Me.PIR1_cmb_ReasonForEnd.SelectedValue.ToString, True, 0), _
                             iTimeNow(0).ToString, _
                             pref_PerformerId, _
                             ConvertToNull(Me.PIR1_txt_Note.Text, True, 0),
                             "'" & CurRow.Cells("PetitionsPacksId").Value & "'")
            If Me.PIR1_DGView_Petitions.RowCount > 0 Then
                ExecuteQuery("EXEC Pr_AbonentsPetitions " & _
                                                    "@AbonentId = " & CurRowPetit.Cells("AbonentId").Value & ", " & _
                                                    "@MemberId = " & CurRowPetit.Cells("MemberId").Value & ", " & _
                                                    "@DtPeriodStart = '" & CurRowPetit.Cells("DtPeriodStart").Value & "', " & _
                                                    "@DtPeriodEnd = '" & CurRowPetit.Cells("DtPeriodEnd").Value & "', " & _
                                                    "@EnergyTypeId = " & CurRowPetit.Cells("EnergyTypeId").Value & ", " & _
                                                    "@SerialNumberPetit = " & CurRowPetit.Cells("SerialNumberPetit").Value & ", " & _
                                                    "@CopPerformerId = " & ConvertToNull(Me.PIR1_cmb_CopPerformer.SelectedValue.ToString(), True, 0) & ", " & _
                                                    "@ExecutiveNumber = " & ConvertToNull(Me.PIR1_txt_ExecutiveNumber.Text, True, 0) & ", " & _
                                                    "@ExcitementDt = " & DateInDataBase(Me.PIR1_txt_ExcitementDt.Text) & ", " & _
                                                    "@DebtSumm = " & OutBD_Money(Me.PIR1_txt_PetitionSumm.Text, 1, "G") & ", " & _
                                                    "@DtActImpossibleRecovery = " & DateInDataBase(Me.PIR1_txt_DtActImpossibleRecovery.Text) & ", " & _
                                                    "@ActImpossibleRecoveryId = " & ConvertToNull(Me.PIR1_cmb_ActImpossibleRecovery.SelectedValue.ToString, True, 0) & ", " & _
                                                    "@DtCompletion = " & DateInDataBase(Me.PIR1_txt_DtCompletion.Text) & ", " & _
                                                    "@Note = " & ConvertToNull(Me.PIR1_txt_NotePetition.Text, True, 0) & ", " & _
                                                    "@Function = 3",
                                                    "PIR1_Btn_SavePetitionDebt_Click")
            End If
            With New frInfo
                .Mess = "Измененения в исковых мероприятиях и МИП успешно сохранены..."
                .Show()     ' Всплываюшее сообщение
            End With
        End If
        ClickTree_Pan_1_Suit()                                                  ' Обновление полей
    End Sub
    Private Sub PIR1_Btn_AddNewPetitionDebt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PIR1_Btn_AddNewPetitionDebt.Click
        If frAddNewPr_PetitionDebt.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ' индекс активной строки делаем количеством строк, 
            ' для перехода на добавленную строку
            iSelectRowDGView_PetitionsDebt = Me.PIR1_DGView_PetitionsDebt.RowCount - 1
            ClickTree_Pan_1_Suit() ' Обновление полей
        End If
        frAddNewPr_PetitionDebt.Dispose()
    End Sub
    Private Sub PIR1_Btn_DeletePetitionDebt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PIR1_Btn_DeletePetitionDebt.Click
        Dim CurRow As Object = Me.PIR1_DGView_PetitionsDebt.CurrentRow      ' Активная строка на гриде
        Dim lRow As Integer = Me.PIR1_DGView_PetitionsDebt.Rows.Count       ' Последняя строка на гриде
        ' Если грид не пустой выделенная строка не итоговая
        If PIR1_DGView_PetitionsDebt.Rows.Count <> 0 And CurRow.Index <> lRow - 1 Then
            ' Вопрос перед удалением
            Select Case XtraMessageBox.Show("Иск <<" & CurRow.Cells("FIO").Value & ">>" & vbCrLf & "будет удален! Вы согласны?", _
                                                                                "Внимание! Удаление без возможности восстановления", _
                                                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.Yes ' Ok
                    If PIR1_DGView_PetitionsDebt.Rows.Count <> 0 Then
                        ' Передача значений полей в текст команды запроса
                        If Delete_PrPetitionsDebt(CurRow.Cells("AbonentId").Value, _
                             CurRow.Cells("MemberId").Value, _
                             "'" & CurRow.Cells("DtPeriodStart").Value & "'", _
                             "'" & CurRow.Cells("DtPeriodEnd").Value & "'", _
                             CurRow.Cells("EnergyTypeId").Value, _
                             "'" & CurRow.Cells("PetitionsPacksId").Value & "'") Then
                            With New frInfo
                                .Mess = "Иск удален..."
                                .Show()     ' Всплываюшее сообщение
                            End With
                            ' индекс активной строки делаем количеством строк, 
                            ' для перехода на добавленную строку
                            iSelectRowDGView_PetitionsDebt -= 1
                            ClickTree_Pan_1_Suit()              ' Обновление полей
                        End If
                    End If
            End Select
        End If
    End Sub

#Region "Дублирование даты решения суда на дату ИЛ/СП если выбран судебны приказ в решении"
    Private Sub PIR1_txt_DealNumber_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PIR1_txt_DealNumber.Leave
        ' Если решение суда выбран "Судебный приказ" то дата решения совпадает с датой ИЛ/СП
        If Me.PIR1_cmb_DecisionType.SelectedValue = 5 Then
            Me.PIR1_txt_DecisionNumber.Text = sender.Text()
        End If
    End Sub
    Private Sub PIR1_txt_DtDecision_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PIR1_txt_DtDecision.Leave
        ' Если решение суда выбран "Судебный приказ" то дата решения совпадает с датой ИЛ/СП
        If Me.PIR1_cmb_DecisionType.SelectedValue = 5 Then
            Me.PIR1_txt_DtJudicialOrder.Text = sender.Text()
        End If
    End Sub
#End Region

    ' Сформировать заявление в суд
    Private Sub PIR1_Btn_ReportsBlankPetition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PIR1_Btn_ReportsBlankPetition.Click
        Dim FRx As New Report                                           ' Новый экземпляр отчета
        Dim CurRow As Object = Me.PIR1_DGView_PetitionsDebt.CurrentRow  ' Активная строка на гриде
        DativeCase(CurRow.Cells("FIO").Value().ToString, "", "")        ' Винительный падеж
        ' Проверка зашит ли файл отчета в программу
        If File.Exists(SaveResToTemp(My.Resources.PetitionBlank)) Then
            Try
                FRx.Load(SaveResToTemp(My.Resources.PetitionBlank)) ' Загрузка отчета из ресурсов программы
                ' Заполнение параметров отчета данными из базы
                FRx.ReportInfo.Name = "Заявление " & Me.txt_Adress.Text
                FRx.SetParameterValue("AbonentId", CurRow.Cells("AbonentId").Value().ToString)
                FRx.SetParameterValue("MemberId", CurRow.Cells("MemberId").Value().ToString)
                FRx.SetParameterValue("DtPeriodStart", CurRow.Cells("DtPeriodStart").Value().ToString)
                FRx.SetParameterValue("DtPeriodEnd", CurRow.Cells("DtPeriodEnd").Value().ToString)
                FRx.SetParameterValue("EnergyTypeId", CurRow.Cells("EnergyTypeId").Value().ToString)
                FRx.SetParameterValue("ConnectionString", pref_ConnectionString)
                FRx.SetParameterValue("FIO_VinPadeg", DativeCase(CurRow.Cells("FIO").Value().ToString, "", ""))
                FRx.Show()      ' Показать отчет
                FRx.Dispose()   ' Осводить ресурсы
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            ' Если отчета нет в ресурсах программы
            XtraMessageBox.Show("Не найден файл для генератора отчетов!" & Chr(10) & _
                            "Проверьте наличие файла \PetitionBlank.frx в каталоге;" & Chr(10) & _
                            Application.StartupPath & "\Reports\", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    ' ===================================================================================================================================
    ' Включение кнопки сохранить при изменении в каком либо контроле по Иску
    Private Sub PIR1_PetitionDebtDataChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PIR1_txt_DtPeriodStart.TextChanged,
                                                                                                            PIR1_txt_DtPeriodEnd.TextChanged,
                                                                                                            PIR1_cmb_CourtType.TextChanged,
                                                                                                            PIR1_cmb_JudicialArea.TextChanged,
                                                                                                            PIR1_txt_DebtSumm.TextChanged,
                                                                                                            PIR1_txt_GovTax.TextChanged,
                                                                                                            PIR1_txt_NumberPetition.TextChanged,
                                                                                                            PIR1_txt_DtPetitions.TextChanged,
                                                                                                            PIR1_txt_DtDispatch.TextChanged,
                                                                                                            PIR1_txt_Note.TextChanged,
                                                                                                            PIR1_txt_DtDecision.TextChanged,
                                                                                                            PIR1_txt_DebtSummAfterDecision.TextChanged,
                                                                                                            PIR1_cmb_DecisionType.TextChanged,
                                                                                                            PIR1_txt_DtJudicialOrder.TextChanged,
                                                                                                            PIR1_txt_DecisionNumber.TextChanged,
                                                                                                            PIR1_cmb_DecisionTypeExt.TextChanged,
                                                                                                            PIR1_cmb_DecisionDirection.TextChanged,
                                                                                                            PIR1_cmb_ReasonForEnd.TextChanged,
                                                                                                            PIR1_txt_DtClosePetitionDebt.TextChanged,
                                                                                                            PIR1_txt_ExecutiveNumber.TextChanged,
                                                                                                            PIR1_txt_PetitionSumm.TextChanged,
                                                                                                            PIR1_txt_ExcitementDt.TextChanged,
                                                                                                            PIR1_cmb_CopPerformer.TextChanged,
                                                                                                            PIR1_txt_DtActImpossibleRecovery.TextChanged,
                                                                                                            PIR1_cmb_ActImpossibleRecovery.TextChanged,
                                                                                                            PIR1_txt_DtCompletion.TextChanged,
                                                                                                            PIR1_txt_NotePetition.TextChanged,
                                                                                                            PIR1_txt_DealNumber.TextChanged,
                                                                                                            PIR1_txt_DtDecisionDirection.TextChanged
        If EventChangedControl Then Me.PIR1_Btn_SavePetitionDebt.Enabled = True
    End Sub
    ' При переводе фокуса и PIR1_TabCon проверка были ли сделаны изменения
    Private Sub PIR1_TabCon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PIR1_TabCon.Leave
        ' Если кнопка сохранить активна
        If Me.PIR1_Btn_SavePetitionDebt.Enabled Then
            ' Вопрос сохранить или нет
            Select Case XtraMessageBox.Show("На вкладке <Притензионно - исковой работы> имеются не сохраненне изменения." & Chr(10) &
                                        "Сохранить изменения в безе данных?",
                                        Application.ProductName, MessageBoxButtons.YesNoCancel,
                                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                Case DialogResult.Yes
                    PIR1_Btn_SavePetitionDebt_Click(sender, e)      ' Нажимаем кнопку Сохранить данные по иску
                Case DialogResult.No
                    ClickTree_Pan_1_Suit()                      ' Просто обновляем панель
            End Select
        End If
    End Sub
#End Region

#Region "Исполнительное производство"
    ' Заполнение всех полей с информацией по МИП
    Private Sub Fill_DGView_CopsWork()
        If Me.PIR1_DGView_Petitions.RowCount <> 0 Then
            Pan_PetitionControls.Enabled = True
            Dim ActiveRow As Object = Me.PIR1_DGView_Petitions.CurrentRow
            Me.PIR1_txt_ExecutiveNumber.Text = ActiveRow.Cells("ExecutiveNumber").Value.ToString
            Me.PIR1_txt_PetitionSumm.Text = OutBD_Money(ActiveRow.Cells("DebtSumm").Value.ToString, 0, "N")
            Me.PIR1_txt_ExcitementDt.Text = ConvertToNull(ActiveRow.Cells("ExcitementDt").Value.ToString, False, 1)
            Me.PIR1_cmb_CopPerformer.Text = ConvertToNull(ActiveRow.Cells("CopPerformers").Value.ToString, False, 0)
            Me.PIR1_txt_DtActImpossibleRecovery.Text = ConvertToNull(ActiveRow.Cells("DtActImpossibleRecovery").Value.ToString, False, 1)
            Me.PIR1_cmb_ActImpossibleRecovery.Text = ConvertToNull(ActiveRow.Cells("ActImpossibleRecovery").Value.ToString, False, 0)
            Me.PIR1_txt_DtCompletion.Text = ConvertToNull(ActiveRow.Cells("DtCompletion").Value.ToString, False, 1)
            Me.PIR1_txt_NotePetition.Text = ConvertToNull(ActiveRow.Cells("Note").Value.ToString, False, 0)
        Else
            ClearData_CopsWork()
        End If
        Me.PIR1_Btn_SavePetitionDebt.Enabled = False
    End Sub
    ' Очищение всех полей с информацией по МИП
    Private Sub ClearData_CopsWork()
        Dim ActiveRow As Object = Me.PIR1_DGView_Petitions.CurrentRow
        Me.PIR1_txt_ExecutiveNumber.Text = Nothing
        Me.PIR1_txt_PetitionSumm.Text = Nothing
        Me.PIR1_txt_ExcitementDt.Text = Nothing
        Me.PIR1_cmb_CopPerformer.Text = Nothing
        Me.PIR1_txt_DtActImpossibleRecovery.Text = Nothing
        Me.PIR1_cmb_ActImpossibleRecovery.Text = Nothing
        Me.PIR1_txt_DtCompletion.Text = Nothing
        Me.PIR1_txt_NotePetition.Text = Nothing

        Me.Pan_PetitionControls.Enabled = False
        Me.PIR1_Btn_SavePetitionDebt.Enabled = False
        Me.PIR1_Btn_DeletePetition.Enabled = False
        Me.PIR1_Btn_AddNewPetition.Enabled = True

        iDataSet.Tables("Petitions").Clear()
    End Sub

    Private Sub PIR1_DGView_Petitions_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PIR1_DGView_Petitions.SelectionChanged
        If EventChangedControl Then
            ' Если грид не пустой и текущая строка активна
            If Me.PIR1_DGView_Petitions.RowCount.ToString <> 0 Then
                If Me.PIR1_DGView_Petitions.CurrentRow.Selected Then
                    Fill_DGView_CopsWork()
                    ' Запись в переменную номера активной строки DGView_PrMembers
                    iSelectRowDGView_Petitions = Me.PIR1_DGView_Petitions.CurrentRow.Index
                End If
            End If
        End If
    End Sub
    Private Sub PIR1_DGView_Petitions_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PIR1_DGView_Petitions.KeyDown
        ' Удаление записи кнопкой DELETE
        ' Если грид не пустой или всего с одной записью
        Dim lRow As Integer = Me.PIR1_DGView_Petitions.Rows.Count         ' Количество строк на гриде
        If lRow <> 0 Then If e.KeyCode = Keys.Delete Then Me.PIR1_Btn_DeletePetition_Click(sender, e)
    End Sub

#Region "События на контролах с датами"
    Sub PIR1_txt_ExcitementDt_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PIR1_txt_ExcitementDt.MouseClick,
                                                                                                                         PIR1_txt_DtActImpossibleRecovery.MouseClick,
                                                                                                                         PIR1_txt_DtCompletion.MouseClick
        DateMaskEvents("MouseClick", sender)
    End Sub
    Private Sub PIR1_txt_ExcitementDt_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PIR1_txt_ExcitementDt.KeyUp,
                                                                                                                          PIR1_txt_DtActImpossibleRecovery.KeyUp,
                                                                                                                          PIR1_txt_DtCompletion.KeyUp
        DateMaskEvents("KeyUp", sender, e.KeyCode)
    End Sub
    Private Sub PIR1_txt_ExcitementDt_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PIR1_txt_ExcitementDt.Validated,
                                                                                                                    PIR1_txt_DtActImpossibleRecovery.Validated,
                                                                                                                    PIR1_txt_DtCompletion.Validated
        If sender.Text <> "" Then
            Try
                Console.WriteLine(IsDate(CDate(Mid(sender.Text, 1, 2) & "." & Mid(sender.Text, 3, 2) & "." & Mid(sender.Text, 5, 4))))
            Catch ex As Exception
                XtraMessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                sender.Focus()                                                                        ' Возвращаемся обратно в поле ввода
                sender.SelectAll()
            End Try
        End If
    End Sub

    ' Кнопки календаря
    Private Sub btn_CalPIR1_txt_ExcitementDt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CalPIR1_txt_ExcitementDt.ValueChanged,
                                                                                                                              btn_CalPIR1_txt_DtActImpossibleRecovery.ValueChanged,
                                                                                                                              btn_CalPIR1_txt_DtCompletion.ValueChanged
        ' Имя контрола в который нужно внести дату берется из Тега кнопки календаря
        Me.Pan_PetitionControls.Controls(sender.Tag).Text = sender.Text
    End Sub
    Private Sub btn_CalPIR1_txt_ExcitementDt_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_CalPIR1_txt_ExcitementDt.MouseEnter,
                                                                                                                     btn_CalPIR1_txt_DtActImpossibleRecovery.MouseEnter,
                                                                                                                     btn_CalPIR1_txt_DtCompletion.MouseEnter
        ' Если в контроле дата, переносим в календарь
        If IsDate(Me.Pan_PetitionControls.Controls(sender.Tag).Text) Then _
            sender.Value = Me.Pan_PetitionControls.Controls(sender.Tag).Text
    End Sub
#End Region

#Region "Управление МИП" ' Добавить. Удалить
    Private Sub PIR1_Btn_AddNewPetition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PIR1_Btn_AddNewPetition.Click
        If frAddNewPr_Petition.ShowDialog() = Windows.Forms.DialogResult.OK Then ' для перехода на добавленную строку
            iSelectRowDGView_Petitions = Me.PIR1_DGView_Petitions.RowCount
            ' Обновление полей
            Fill_DGView_PetitionsDebt()
            Fill_DGView_CopsWork()
        End If
        frAddNewPr_Petition.Dispose()
    End Sub
    Private Sub PIR1_Btn_DeletePetition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PIR1_Btn_DeletePetition.Click
        Dim CurRow As Object = Me.PIR1_DGView_Petitions.CurrentRow         ' Активная строка на гриде
        ' Если грид не пустой
        If PIR1_DGView_PetitionsDebt.Rows.Count <> 0 Then
            ' Вопрос перед удалением
            Select Case XtraMessageBox.Show("Исполнительное произведство №_" & CurRow.Cells("ExecutiveNumber").Value & " будет удалено!" & vbCrLf & "Вы согласны?", _
                                                                                "Внимание! Удаление без возможности восстановления", _
                                                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.Yes ' Ok
                    ' Передача значений полей в текст команды запроса
                    If ExecuteQuery("EXEC Pr_AbonentsPetitions " & _
                                                   "@AbonentId = " & CurRow.Cells("AbonentId").Value & ", " & _
                                                   "@MemberId = " & CurRow.Cells("MemberId").Value & ", " & _
                                                   "@DtPeriodStart = '" & CurRow.Cells("DtPeriodStart").Value & "', " & _
                                                   "@DtPeriodEnd = '" & CurRow.Cells("DtPeriodEnd").Value & "', " & _
                                                   "@EnergyTypeId = " & CurRow.Cells("EnergyTypeId").Value & ", " & _
                                                   "@SerialNumberPetit = " & CurRow.Cells("SerialNumberPetit").Value & ", " & _
                                                   "@Function = 4",
                                                   "PIR1_Btn_DeletePetition_Click") Then
                        With New frInfo
                            .Mess = "Исполнительное производство" & vbCrLf & "№_" & CurRow.Cells("ExecutiveNumber").Value & " удалено..."
                            .Show()     ' Всплываюшее сообщение
                        End With
                        ' индекс активной строки уменьшаем на 1
                        iSelectRowDGView_Petitions -= 1
                        ' Обновление полей
                        Fill_DGView_PetitionsDebt()
                        Fill_DGView_CopsWork()
                    End If
            End Select
        End If
    End Sub
#End Region


#End Region
#End Region


    Private Sub PIR1_txt_DtDecision_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles PIR1_txt_DtDecision.MaskInputRejected

    End Sub




    Private Sub PIR1_Btn_Reports_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PIR1_Btn_Reports.ButtonClick
        ' Открытие выпадающего списка
        PIR1_Btn_Reports.ShowDropDown()
    End Sub

    Private Sub ToolStrip_DemandTSO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStrip_DemandTSO.Click
        frLetterTSO.ShowDialog()
    End Sub

    Private Sub btn_CalPIR1_txt_DtDecisionDirection_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CalPIR1_txt_DtDecisionDirection.ValueChanged

    End Sub

    Private Sub Pic_PayOrders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pic_PayOrders.Click
        Me.PIR1_cmb_JudicialArea.Text = Nothing

    End Sub

    Private Sub PIR1_cmb_JudicialArea_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PIR1_cmb_JudicialArea.SelectedIndexChanged

    End Sub

    Private Sub PIR1_DGView_PetitionsDebt_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles PIR1_DGView_PetitionsDebt.CellContentClick

    End Sub

End Class