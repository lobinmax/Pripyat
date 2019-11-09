Imports System.Windows.Forms
Imports System.Threading
Imports DevExpress.XtraEditors

Public Class frRouter
    Dim ExportFunction As Integer           ' Номер функции экпорта для идентификации откуда запущена процедура
    ' 0 - frRouter.TS_btnToExcel_Click (Экспорт списка с маршрутами)
    ' 1 - frRouter.TS_btnToExcel_Click (Экспорт списка лицевых без назначенного маршрута)

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frRouter_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frRouter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        EventChangedControl = False         ' Отключаем обработку событий в контролах
        SetDoubleBuffered(DG_RoutersList)   'Установка DoubleBuffered для DataGridView
        ' Выгружаем таблицу старших и линейных контролеров
        SelectQueryData(
                        "InspectorsTree", _
                        "SELECT * " & _
                        "FROM   vPr_InspoctorsTree", _
                        "frAskur_Load.InspectorsTree"
                        )
        ' Выгружаем перечень маршрутов
        SelectQueryData(
                        "Routes", _
 _
                        "SELECT * " & _
                        "FROM   vPr_Routes " & _
                        "ORDER BY SpecDepart", _
 _
                        "frAskur_Load.Routes"
                        )
        ' Выгружаем перечень маршрутов
        ' для выбора маршрута при привязки
        SelectQueryData(
                        "Routes0", _
 _
                        "SELECT * " & _
                        "FROM   vPr_Routes " & _
                        "WHERE SpecDepartId <> 0" & _
                        "ORDER BY SpecDepart", _
 _
                        "frAskur_Load.Routes"
                        )
        ' Выгружаем перечень улиц по заданным критериям
        SelectQueryData(
                        "DistribRouters", _
 _
                        "EXEC Pr_DistribRouters " & _
                        "@NodeLevel = 0, " & _
                        "@Function = 1",
 _
                        "frRouter_Load.DistribRouters"
                        )

        ' Выборка районов и улиц имеющихся в базе
        SelectQueryData(
                        "AddressAreal",
                        "EXEC Pr_GetAddressArealPerformer",
                        "frRouter_Load.AddressAreal"
                        )
        ' Привязка маршрутов на вкладке "Просмотр"
        With Me.TS_cmbRoute.ComboBox
            .DataSource = iDataSet.Tables("Routes")
            .DisplayMember = "SpecDepart"
            .ValueMember = "SpecDepartId"
            .SelectedIndex = 1
        End With

        ' Привязка маршрутов на вкладке "Привязка"
        With Me.cmb_BindRouter
            .DataSource = iDataSet.Tables("Routes0")
            .DisplayMember = "SpecDepart"
            .ValueMember = "SpecDepartId"
            .SelectedIndex = 1
        End With

        FillTV_Maneger()                                                    ' Запонение дерева контролеров
        FillTV_All()                                                        ' Заполнение дерева с улицами
        Me.TV_Performers.ExpandAll()                                        ' Разворачиваем все дерево с контролерами
        Me.TV_Performers.SelectedNode = Me.TV_Performers.Nodes.Item(0)      ' Активация родительского нода в контролерах
        Me.tv_BindStreets.SelectedNode = Me.tv_BindStreets.Nodes.Item(0)    ' Активация родительского нода в улицах
        EventChangedControl = True                                          ' Включаем обработку событий в контролах
    End Sub

#Region "Заполнение дерева контролеров"
    Private Sub FillTV_Maneger() ' Руководитель группы
        ndStr_Level_0 = ""
        ' Перебор значений в iDataSet столбца "ArealName"
        For Each iDataRow As DataRow In iDataSet.Tables("InspectorsTree").Rows
            If iDataRow.Item("Manager").ToString <> ndStr_Level_0 Then                  ' Если зафиксирован повтор значения то
                ndLevel_0 = Me.TV_Performers.Nodes.Add(iDataRow.Item("Manager"))        ' Значение записывается в Нод
                ndLevel_0.Name = iDataRow.Item("ManagerId")                             ' Присваиваем имени нода ManagerId
                ndStr_Level_0 = ndLevel_0.Text                                          ' Присваиваем переменной значение Нода
                FillTV_ChiefInsp(Me.TV_Performers, ndLevel_0.Text)                      ' Заполняем ветку Village в текущем Ноде
            End If
        Next iDataRow
    End Sub
    Private Sub FillTV_ChiefInsp(ByVal sender As TreeView, ByVal ParentNodeName As String) ' Старшие контролеры
        ' Перебор значений в iDataSet столбца "VillageName" где значения столбца "ArealName" равны родительскому Ноду (ParentNodeName)
        For Each iDataRow As DataRow In iDataSet.Tables("InspectorsTree").Select("Manager='" & ParentNodeName & "'")
            If iDataRow("ChiefInspector").ToString <> ndStr_Level_1 Then                ' Если зафиксирован повтор значения то
                ndLevel_1 = ndLevel_0.Nodes.Add(iDataRow("ChiefInspector"))             ' Значение записывается в Нод
                ndLevel_1.Name = iDataRow.Item("ChiefInspectorId")                      ' Нод разворачивается
                ndStr_Level_1 = ndLevel_1.Text                                          ' Присваиваем переменной значение Нода
                FillTV_Insp(ndLevel_1, ndLevel_1.Text)
            End If
        Next
    End Sub
    Private Sub FillTV_Insp(ByVal ParentNode As TreeNode, ByVal ParentNodeName As String) ' Линейные контролеры
        ' Перебор значений в iDataSet столбца "StreetName" где значения столбца "VillageName" равны родительскому Ноду (ParentNodeName)
        For Each iDataRow As DataRow In iDataSet.Tables("InspectorsTree").Select("ChiefInspector='" & ParentNodeName & "'")
            ndLevel_2 = ParentNode.Nodes.Add(iDataRow("Inspector"))                     ' Значение записывается в Нод безусловно
            ndLevel_2.Name = iDataRow.Item("InspectorId")                               ' Присваиваем имени нода InspectorId
        Next
    End Sub
#End Region

#Region "Заполнение дерева улиц"
    Private Sub FillTV_All()
        Me.tv_BindStreets.Nodes.Clear()
        ndStr_Level_0 = ""
        For Each iDataRow As DataRow In iDataSet.Tables("AddressAreal").Rows
            If iDataRow.Item("CityVillage") <> ndStr_Level_0 Then                       ' Если зафиксирован повтор значения то
                ndLevel_0 = Me.tv_BindStreets.Nodes.Add(iDataRow.Item("CityVillage"))   ' Значение записывается в Нод
                ndLevel_0.Name = iDataRow.Item("CityVillageId")                         ' Присваиваем ноду значение Id
                ndStr_Level_0 = ndLevel_0.Text                                          ' Присваиваем переменной значение Нода
                FillTV_Village_1(Me.tv_BindStreets, ndLevel_0.Text)                     ' Заполняем ветку Village в текущем Ноде
            End If
        Next iDataRow
    End Sub
    Private Sub FillTV_Village_1(ByVal sender As TreeView, ByVal ParentNodeName As String)
        ' Перебор значений в iDataSet столбца "Street" где значения столбца "CityVillage" равны родительскому Ноду (ParentNodeName)
        For Each iDataRow As DataRow In iDataSet.Tables("AddressAreal").Select("CityVillage='" & ParentNodeName & "'")
            If iDataRow("Street") <> ndStr_Level_2 Then                                 ' Если зафиксирован повтор значения то
                ndLevel_1 = ndLevel_0.Nodes.Add(iDataRow("Street"))                     ' Значение записывается в Нод
                ndLevel_1.Name = iDataRow.Item("AddressPartId")                         ' Присваиваем ноду значение Id
                ndStr_Level_1 = ndLevel_1.Text                                          ' Присваиваем переменной значение Нода
            End If
        Next
    End Sub
#End Region

    Private Sub TS_btnChooseStreet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TS_btnChooseStreet.Click
        frAdressAreal.Vid = 1 ' Загружаем форму выбора адресов с Видом - 1
        frAdressAreal.AddressFunction = 10
        ' Если форма вернула Ок
        If frAdressAreal.ShowDialog() = DialogResult.OK Then
            ' Переменная активного нода в выборе адресаId
                Me.TS_lbStreet.Text = AddressString    ' Название выбранной улицы
        End If
        frAdressAreal.Dispose()
        frAdressAreal.Close()
    End Sub

    Private Sub TS_btnLoading_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TS_btnLoading.Click
        ExportFunction = 0                                  ' Указываем что экспорт с маршрутами
        Dim iLoaderList As New Thread(AddressOf LoaderList) ' Для выгрузки маршрутов исп. отдельный процесс
        Me.Cursor = Cursors.WaitCursor                      ' Курсор "В ожидании"
        sender.Enabled = False                              ' Отключение кнопки чтоб опять не нажали
        Me.PB_Loader.Visible = True                         ' Отображение спирали для визуализации
        iLoaderList.Start()                                 ' Запуск загрузки маршрутов в отдельном процессе
        CompliteLoad = False                                ' Процесс выгрузки запущен
        ' Пока процесс выполняется....
        Do Until CompliteLoad
            ' Ждем и ничего не делаем
            My.Application.DoEvents()
        Loop

        Me.DG_RoutersList.DataSource = Nothing                              ' Отвязываем данные от грида
        Me.DG_RoutersList.DataSource = iDataSet.Tables("DistribRouters")    ' ... и привязываем занового

        ' Скрываем все столбцы на .DG_RoutersList
        For i = 0 To Me.DG_RoutersList.ColumnCount - 1
            Me.DG_RoutersList.Columns.Item(i).Visible = False
        Next
        ' Отображаем нужные столбцы и задаем им имена
        Dim ColGrid_Petit As Object = Me.DG_RoutersList.Columns
        ColGrid_Petit.Item("AddressString").HeaderText = "Часть адреса"
        ColGrid_Petit.Item("AddressString").Visible = True
        ColGrid_Petit.Item("Router").HeaderText = "№ маршрута"
        ColGrid_Petit.Item("Router").Visible = True
        ColGrid_Petit.Item("Inspector").HeaderText = "Линейный контролер"
        ColGrid_Petit.Item("Inspector").Visible = True
        ColGrid_Petit.Item("ChiefInspector").HeaderText = "Старший контролер"
        ColGrid_Petit.Item("ChiefInspector").Visible = True

        ' Отключаем сортировку столбцов по всему Гриду
        For i = 0 To Me.DG_RoutersList.ColumnCount - 1
            Me.DG_RoutersList.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        Me.PB_Loader.Visible = False                        ' Прячем спираль визуализации
        Me.Cursor = Cursors.Default                         ' Курсор по-умолчанию
    End Sub

    ' Загруска списка маршрутов
    Private Sub LoaderList()
        Try
            SelectQueryData(
                           "DistribRouters", _
 _
                           "EXEC Pr_DistribRouters " & _
                           "@NodeLevel = " & Me.TV_Performers.SelectedNode.Level & ", " & _
                           "@PerformerId = " & Me.TV_Performers.SelectedNode.Name & ", " & _
                           "@RouterId = " & ConvertToNull(Me.TS_cmbRoute.ComboBox.SelectedValue, True, 0) & ", " & _
                           "@AddressPartId = " & StreetId & ", " & _
                           "@Function = 1", _
 _
                           "frRouter_Load.DistribRouters"
                          )
        Catch ex As Exception
            CompliteLoad = True
            XtraMessageBox.Show(ex.Message, _
                                Application.ProductName, _
                                MessageBoxButtons.OK, _
                                MessageBoxIcon.Question, _
                                MessageBoxDefaultButton.Button1, _
                                DevExpress.Utils.DefaultBoolean.True)
        End Try
    End Sub

    Private Sub TS_btnWithoutRoute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TS_btnWithoutRoute.Click
        ExportFunction = 1 ' Указываем что экспорт списка без маршрутов
        Dim iLoadWithoutRoute = New Thread(AddressOf LoadWithoutRoute)  ' Для выгрузки маршрутов исп. отдельный процесс
        Me.Cursor = Cursors.WaitCursor                                  ' Курсор "В ожидании"
        sender.Enabled = False                                          ' Отключение кнопки чтоб опять не нажали
        Me.PB_Loader.Visible = True                                     ' Отображение спирали для визуализации
        iLoadWithoutRoute.Start()                                       ' Запуск загрузки маршрутов в отдельном процессе
        CompliteLoad = False                                            ' Процесс выгрузки запущен
        ' Пока процесс выполняется....
        Do Until CompliteLoad
            ' Ждем и ничего не делаем
            My.Application.DoEvents()
        Loop

        Me.DG_RoutersList.DataSource = Nothing                          ' Отвязываем данные от грида
        Me.DG_RoutersList.DataSource = iDataSet.Tables("WithoutRoute")  ' ... и привязываем занового

        ' Скрываем все столбцы на .DG_RoutersList
        For i = 0 To Me.DG_RoutersList.ColumnCount - 1
            Me.DG_RoutersList.Columns.Item(i).Visible = False
        Next
        ' Отображаем нужные столбцы и задаем им имена
        Dim ColGrid_Petit As Object = Me.DG_RoutersList.Columns
        ColGrid_Petit.Item("AbonNumber").HeaderText = "Номер абонента"
        ColGrid_Petit.Item("AbonNumber").Visible = True
        ColGrid_Petit.Item("LastSurName").HeaderText = "ФИО абонента"
        ColGrid_Petit.Item("LastSurName").Visible = True
        ColGrid_Petit.Item("AddressString").HeaderText = "Часть адреса"
        ColGrid_Petit.Item("AddressString").Visible = True
        ColGrid_Petit.Item("SpecDepart").HeaderText = "№ маршрута"
        ColGrid_Petit.Item("SpecDepart").Visible = True
        ColGrid_Petit.Item("Controller").HeaderText = "Линейный контролер"
        ColGrid_Petit.Item("Controller").Visible = True

        ' Отключаем сортировку столбцов по всему Гриду
        For i = 0 To Me.DG_RoutersList.ColumnCount - 1
            Me.DG_RoutersList.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        Me.PB_Loader.Visible = False        ' Прячем спираль визуализации
        sender.Enabled = True               ' Включаем кнопку Загрузить
        Me.Cursor = Cursors.Default         ' Курсор по-умолчанию
    End Sub

    ' Загрузка списка лицевых без маршрутов
    Private Sub LoadWithoutRoute()
        SelectQueryData(
                        "WithoutRoute",
                        "SELECT * FROM vPr_WithoutRouter",
                        "LoadWithoutRoute"
                        )
    End Sub

    Private Sub TS_cmbRoute_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TS_cmbRoute.SelectedIndexChanged,
                                                                                                              TS_lbStreet.TextChanged,
                                                                                                              TV_Performers.NodeMouseClick
        ' При изменении значений критериев выгрузки
        ' кнопка Загрузить активируется
        Me.TS_btnLoading.Enabled = True
    End Sub

    ' Событие при выборе какого либо инспектора
    Private Sub TV_Performers_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TV_Performers.AfterSelect
        ' Если обработка событий включена
        If EventChangedControl Then
            ' Перебираем все ноды в дереве контролеров и устанавливаем шрифт по-умолчанию
            For Each n0 As TreeNode In Me.TV_Performers.Nodes   ' Нод 0 - го уровня
                n0.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
                For Each n1 As TreeNode In n0.Nodes             ' Нод 1 - го уровня
                    n1.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
                    For Each n2 As TreeNode In n1.Nodes         ' Нод 2 - го уровня
                        n2.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
                    Next
                Next
            Next
            ' ...а выбранный нод подчеркиваем
            e.Node.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
            ' Если выбран линейный контролер
            If e.Node.Level = 2 Then
                ' Выборка районов и улиц по выбранному контролеру
                SelectQueryData(
                                "AddressAreal",
                                "EXEC Pr_GetAddressArealPerformer",
                                "frRouter_Load.AddressAreal"
                                )
                ' Указываем какого контролера выбрали
                Me.lb_BindControler.Text = e.Node.Text
            Else
                Me.lb_BindControler.Text = "Контролер не выбран"
                ' Выборка всех районов и улиц имеющихся в базе
                SelectQueryData(
                                "AddressAreal",
                                "EXEC Pr_GetAddressArealPerformer",
                                "frRouter_Load.AddressAreal"
                                )
            End If
            ' если ДатаСет не пустой...
            If iDataSet.Tables("AddressAreal").Rows.Count <> 0 Then
                FillTV_All()    ' Заполняем дерево улиц
                ' и выбираем самый первый нод
                Me.tv_BindStreets.SelectedNode = Me.tv_BindStreets.Nodes.Item(0)
                ' выгружаем тукущие маршруты по выбранной улице и контролеру
                SelectQueryData(
                                "GetRouter",
 _
                                "EXEC Pr_GetRouterAddressPart " & _
                                            "@AddressPartId = " & Me.tv_BindStreets.SelectedNode.Name & "," & _
                                            "@ControllerId = " & Me.TV_Performers.SelectedNode.Name,
 _
                                "tv_BindStreets.AfterSelect"
                               )
                ' Обрабатываем ListBox с текущими маршрутами
                With Me.lb_ActiveRouters
                    .Height = 17 + (13 * (iDataSet.Tables("GetRouter").Rows.Count) - 1) ' Высота по кол-ву строк
                    .DataSource = iDataSet.Tables("GetRouter")                          ' Привязка к данным
                    .ValueMember = "Route"                                              ' Отображаемые данные
                End With
            Else
                Me.tv_BindStreets.Nodes.Clear()                                         ' очищаем дерево с улицами
                If iDataSet.Tables.Contains("GetRouter") Then iDataSet.Tables("GetRouter").Clear() ' очищаем таблицу ДатаСет если она существует
                Me.lb_BindAddress.Text = "<b><u>Адрес не указан</u></b>"
                With Me.lb_ActiveRouters
                    .Height = 17 + (13 * (iDataSet.Tables("GetRouter").Rows.Count) - 1) ' Высота по кол-ву строк
                    .DataSource = iDataSet.Tables("GetRouter")                          ' Привязка к данным
                    .ValueMember = "Route"                                              ' Отображаемые данные
                End With
            End If
        End If
    End Sub

    Private Sub TS_btnToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TS_btnToExcel.Click
        ' Если грид не пустой то, экпортируем
        If Me.DG_RoutersList.RowCount <> 0 Then
            ' присваиваем функцию экпорта в зависимости от вида выгруженного списка
            frExportTo.ExportFunction = ExportFunction
            frExportTo.ShowDialog()
        Else
            XtraMessageBox.Show("Нет данных для экспорта!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

#Region "Вкладка <ПРИВЯЗКА>"
    ' Событие на дереве с улицами на вкладке "Привязка"
    Private Sub tv_BindStreets_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tv_BindStreets.AfterSelect
        ' Если обработка событий включена
        If EventChangedControl Then
            ' выбранный адрес в дереве
            Me.lb_BindAddress.Text = Me.tv_BindStreets.SelectedNode.FullPath
            ' выгружаем тукущие маршруты по выбранной улице и контролеру
            SelectQueryData(
                            "GetRouter",
 _
                            "EXEC Pr_GetRouterAddressPart " & _
                                        "@AddressPartId = " & Me.tv_BindStreets.SelectedNode.Name & "," & _
                                        "@ControllerId = " & Me.TV_Performers.SelectedNode.Name,
 _
                            "tv_BindStreets.AfterSelect"
                           )
            ' Обрабатываем ListBox с текущими маршрутами
            With Me.lb_ActiveRouters
                .Height = 17 + (13 * (iDataSet.Tables("GetRouter").Rows.Count) - 1) ' Высота по кол-ву строк
                .DataSource = iDataSet.Tables("GetRouter")                          ' Привязка к данным
                .ValueMember = "Route"                                              ' Отображаемые данные
            End With
        End If
    End Sub
    ' Запуск процесса привязки
    Private Sub btn_Binding_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Binding.Click
        ' Если выбран не линейный контролер, отменяем процесс привязки
        If Me.TV_Performers.SelectedNode.Level <> 2 Or Me.tv_BindStreets.Nodes.Count = 0 Then
            XtraMessageBox.Show("Недостаточно данных для привязки маршрута!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        If XtraMessageBox.Show("Будет выполнена привязка <" & Me.tv_BindStreets.SelectedNode.FullPath & ">" & Chr(10) & _
                           "по участку <" & Me.TV_Performers.SelectedNode.Text & ">" & Chr(10) & _
                           "к маршруту <" & Me.cmb_BindRouter.Text & ">!" & Chr(10) & _
                           "Вы согласны?",
                           Application.ProductName,
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If Me.tv_BindStreets.SelectedNode.Level = 1 Then
                ' запуск процесса привязки
                If ExecuteQuery(
                                               "EXEC Pr_DistribRouters " & _
                                                        "@PerformerId = " & Me.TV_Performers.SelectedNode.Name & "," & _
                                                        "@RouterId = " & Me.cmb_BindRouter.SelectedValue & "," & _
                                                        "@AddressPartId = " & Me.tv_BindStreets.SelectedNode.Name & "," & _
                                                        "@Function = 3",
                                               "btn_Binding_Click.@AddressPartId"
                                               ) Then
                    With New frInfo
                        .Mess = "Привязка маршрута " & Me.cmb_BindRouter.Text & "Успешно произведена!"
                        .Show()     ' Всплываюшее сообщение
                    End With
                    Exit Sub        ' завершаем процедуру привязки
                End If
            End If
            ' если для привязки выбран весь администрутивный район
            If Me.tv_BindStreets.SelectedNode.Level = 0 Then
                ' запуск процесса привязки
                If ExecuteQuery(
                                               "EXEC Pr_DistribRouters " & _
                                                        "@PerformerId = " & Me.TV_Performers.SelectedNode.Name & "," & _
                                                        "@RouterId = " & Me.cmb_BindRouter.SelectedValue & "," & _
                                                        "@ArealId = " & Me.tv_BindStreets.SelectedNode.Name & "," & _
                                                        "@Function = 3",
                                               "btn_Binding_Click.@ArealId"
                                               ) Then
                    With New frInfo
                        .Mess = "Привязка маршрута " & Me.cmb_BindRouter.Text & "Успешно произведена!"
                        .Show()     ' Всплываюшее сообщение
                    End With
                    Exit Sub        ' завершаем процедуру привязки
                End If
            End If
        End If
    End Sub
#End Region
End Class
