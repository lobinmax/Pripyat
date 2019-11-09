Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.Utils

' Модуль для построения дерева улиц
Module mdSchemeAddressStreet
    ' Dim IsRoot As Integer = 0               ' Вид формы в зависимости от того какой формой вызван диалог
    '                                           0 - вид для диалога поиска
    '                                           1 - вид для выбора адреса (Родитель "Все улицы")
    ' Dim AddressFunction As Integer = 10  ' Для форм выбора адреса (Родитель "Все улицы")
    '                                           10 - можно выбрать только улицу
    '                                           11 - можно выбрать любую ветку
    Dim ImageCol As New ImageCollection
    Friend Areal As String = "NULL"                         ' Административная единица
    Friend CityVillage As String = "NULL"                   ' Район
    Friend Street As String = "NULL"                        ' Улица
    Friend ArealId As String = "NULL"                       ' Административный район
    Friend CityVillageId As String = "NULL"                 ' Город / Деревня
    Friend StreetId As String = "NULL"                      ' Улица
    Friend AddressString As String = "NULL"                 ' Выбранный адрес полность одной строк
    Friend MultiStreetsStringId As String = "NULL"          ' Строка с выбранными улицами при множественном выборе

    Friend Sub LoadAddressTree(ByVal AddressFunction As Integer,
                               ByVal IsRoot As Integer,
                               ByVal TV_Address As DevExpress.XtraTreeList.TreeList,
                               Optional OkButton As Object = Nothing,
                               Optional ControlerId As String = "NULL",
                               Optional TableName As String = "AddressAreal")
        EventChangedControl = False
        ' загружаем изображения в коллекцию
        ImageCol.Clear()
        ImageCol.AddImage(My.Resources.Adress_16x16)
        ImageCol.AddImage(My.Resources.Check_Mark_16x16)
        ' если можно выбрать любую ветку активируем кнопку Ок
        If IsNothing(OkButton) = False And AddressFunction = 11 Then OkButton.Enabled = True
        ' Выборка районов и улиц имеющихся в базе
        SelectQueryData(
                        TableName,
                        "EXEC Pr_GetAddressArealPerformer @ControlerId = " & ControlerId & ", @IsRoot = " & IsRoot,
                        "frAddresAreal_Load"
                       )
        If IsNothing(TV_Address.DataSource) Then
            With TV_Address
                .DataSource = iDataSet.Tables(TableName)        ' источник данных
                .ParentFieldName = "ParentId"                   ' Столбец с родителями
                .KeyFieldName = "Id"                            ' Столбец с дочерними данными
                .RootValue = DBNull.Value
                .SelectImageList = ImageCol                     ' Коллекция с изображения
            End With
        End If

        ' скрываем все столбцы кроме Name
        For Each col As Columns.TreeListColumn In TV_Address.Columns
            If col.FieldName <> "Name" Then col.Visible = False
        Next
        ' всем нодам присваиваем иконку
        For Each nd As TreeListNode In TV_Address.Nodes
            FillSelectImageIndex(nd)
            nd.SelectImageIndex = 1
        Next
        ' Если ROOT "Все улицы" разворачиваем его
        If IsRoot = 1 And TV_Address.Nodes.Count <> 0 Then TV_Address.Nodes(0).Expanded = True
        EventChangedControl = True
    End Sub
    ' цикл по всем дочерним узлам
    Private Sub FillSelectImageIndex(ByVal ParentNode As TreeListNode)
        For Each nd As TreeListNode In ParentNode.Nodes
            nd.SelectImageIndex = 1
            FillSelectImageIndex(nd)
        Next
    End Sub
    ' собираем чекнутые узлы
    Friend Sub GetTreeListValues_Address(ByVal sender As DevExpress.XtraTreeList.TreeList)
        Dim nD As TreeListNode = sender.FocusedNode ' активный узел
        Dim sep As String
        ' обнуляем все переменные
        Areal = "NULL"                         ' Административная единица
        CityVillage = "NULL"                       ' Район
        Street = "NULL"                        ' Улица
        ArealId = "NULL"                       ' Административный район
        CityVillageId = "NULL"                     ' Город / Деревня
        StreetId = "NULL"                      ' Улица
        AddressString = "NULL"                 ' Выбранный адрес полность одной строк
        MultiStreetsStringId = "NULL"
        ' если включен мультивыбор
        If sender.OptionsView.ShowCheckBoxes Then
            ' собираем чекнутые строки если они есть или если чекнут Root значит фильтра нет
            If sender.GetAllCheckedNodes.Count = 0 Or sender.Nodes(0).Checked Then GoTo m1
            For Each n As TreeListNode In sender.GetAllCheckedNodes
                ' среди улиц
                If n("AddressPartType") = "Street" Then
                    MultiStreetsStringId += sep & n.Item("StreetId")
                    sep = ","
                End If
            Next
            MultiStreetsStringId = "'" & Replace(MultiStreetsStringId, "NULL", "") & "'"
        Else
            If IsNothing(sender.FocusedNode) = False Then
                Areal = nD("Areal")
                CityVillage = nD("CityVillage")
                Street = nD("Street")
                ArealId = nD("ArealId")
                Areal = nD("Areal")
                CityVillageId = nD("CityVillageId")
                StreetId = nD("StreetId")
                AddressString = nD("AddressString")
            End If
        End If
m1:
        'Console.WriteLine("Areal - " & Areal)
        'Console.WriteLine("CityVillage - " & CityVillage)
        'Console.WriteLine("Street - " & Street)
        'Console.WriteLine("ArealId - " & ArealId)
        'Console.WriteLine("CityVillageId - " & CityVillageId)
        'Console.WriteLine("StreetId - " & StreetId)
        'Console.WriteLine("AddressString - " & AddressString)
        'Console.WriteLine("MultiStreetsStringId - " & MultiStreetsStringId)
        'Console.WriteLine(Chr(10))
    End Sub
End Module
