Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraTreeList
Imports DevExpress.Utils

Module mdSchemeInspectors
    ' переменные для хранения выбранных значений в TreeListLookUpEdit
    Friend ChiefId As String = "NULL"
    Friend ChiefName As String = "NULL"
    Friend ControllerId As String = "NULL"
    Friend ControllerName As String = "NULL"
    Friend RouterId As String = "NULL"
    Friend RouterName As String = "NULL"
    Friend RouterMultyStringId As String = "NULL"
    Friend RouterMultyStringName As String = "NULL"
    Friend ControllerMultyStringId As String = "NULL"
    Friend ControllerMultyStringName As String = "NULL"

    Dim ImageCol As New ImageCollection
    Public Sub LoadInspectorsTree(ByVal sender As DevExpress.XtraTreeList.TreeList,
                                  Optional TableName As String = "InspectorsTree",
                                  Optional ViewCollumn As String = "Name")
        ' загружаем изображения в коллекцию
        ImageCol.Clear()
        ImageCol.AddImage(My.Resources.manager_16x16)
        ImageCol.AddImage(My.Resources.chief_16x16)
        ImageCol.AddImage(My.Resources.controller_16x16)
        ImageCol.AddImage(My.Resources.router_16x16)
        SelectQueryData(TableName, "EXEC Pr_GetInspectorsLookUp @IsExpChief = 1", "GetInspectors")

        If IsNothing(sender.DataSource) Then
            With sender
                .ClearNodes()
                .DataSource = iDataSet.Tables(TableName)
                .ParentFieldName = "ParentId"
                .KeyFieldName = "Id"
                .BestFitColumns(True)
                .StateImageList = ImageCol
                HidenAllColumns_TreeList(sender)
                .Columns(ViewCollumn).Visible = True
            End With
        End If
        ' всем нодам присваиваем иконку
        For Each nd As TreeListNode In sender.Nodes
            FillSelectImageIndex(nd)
            SettingsNode(nd)
        Next
    End Sub
    ' цикл по всем дочерним узлам
    Private Sub FillSelectImageIndex(ByVal ParentNode As TreeListNode)
        For Each nd As TreeListNode In ParentNode.Nodes
            FillSelectImageIndex(nd)
            SettingsNode(nd)
        Next
    End Sub
    Private Sub SettingsNode(ByVal nd As TreeListNode)
        nd.Expanded = nd("IsExpanded")
        nd.StateImageIndex = nd.Level
    End Sub
    ' собираем чекнутые узлы
    Friend Sub GetTreeListValues_Inspectors(ByVal sender As DevExpress.XtraTreeList.TreeList)
        Dim nD As TreeListNode = sender.FocusedNode ' активный узел
        Dim sep As String
        ' обнуляем все переменные
        ChiefId = "NULL"
        ChiefName = "NULL"
        ControllerId = "NULL"
        ControllerName = "NULL"
        RouterId = "NULL"
        RouterName = "NULL"
        RouterMultyStringId = "NULL"
        RouterMultyStringName = "NULL"
        ControllerMultyStringId = "NULL"
        ControllerMultyStringName = "NULL"
        ' если включен мультивыбор
        If sender.OptionsView.ShowCheckBoxes Then
            ' собираем чекнутые строки если они есть или если чекнут Root значит фильтра нет
            If sender.GetAllCheckedNodes.Count = 0 Or sender.Nodes(0).Checked Then GoTo m1
            For Each n As TreeListNode In sender.GetAllCheckedNodes
                ' среди маршрутов
                If n("Type") = "Router" Then
                    RouterMultyStringId += sep & n.Item("RouterId")
                    sep = ","
                End If
            Next
            RouterMultyStringId = "'" & Replace(RouterMultyStringId, "NULL", "") & "'"
        Else
            If IsNothing(sender.FocusedNode) = False Then
                ChiefId = nD("ChiefId")
                ChiefName = nD("ChiefName")
                ControllerId = nD("ControllerId")
                ControllerName = nD("ControllerName")
                RouterId = nD("RouterId")
                RouterName = nD("RouterName")
            End If
        End If
m1:
        'Console.WriteLine("ChiefId - " & ChiefId)
        'Console.WriteLine("ChiefName - " & ChiefName)
        'Console.WriteLine("ControllerId - " & ControllerId)
        'Console.WriteLine("ControllerName - " & ControllerName)
        'Console.WriteLine("RouterId - " & RouterId)
        'Console.WriteLine("RouterName - " & RouterName)
        'Console.WriteLine("RouterMultyStringId - " & RouterMultyStringId)
        'Console.WriteLine(Chr(10))
    End Sub
End Module
