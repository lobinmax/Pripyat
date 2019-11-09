Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraTreeList
Imports DevExpress.Utils

Module mdSchemeAbonentStatus
    ' переменные для хранения выбранных значений в TreeListLookUpEdit
    Friend AbonentStatusId As String = "NULL"
    Friend AbonentStatusName As String = "NULL"
    Friend ExtAbonentStatusId As String = "NULL"
    Friend ExtAbonentStatusName As String = "NULL"
    Friend AbonentStatusMultyStringId As String = "NULL"
    Friend AbonentStatusMultyStringName As String = "NULL"

    Dim ImageCol As New ImageCollection
    Public Sub LoadAbonentStatusTree(ByVal sender As DevExpress.XtraTreeList.TreeList,
                                                     ByVal isExpanded As Boolean,
                           Optional ByVal IsRoot As Integer = 0,
                           Optional TableName As String = "AbonentStatus")
        ' загружаем изображения в коллекцию
        ImageCol.Clear()
        ImageCol.AddImage(My.Resources.status_16x16)
        ImageCol.AddImage(My.Resources.status_16x161)
        ImageCol.AddImage(My.Resources.apply_16x161)
        SelectQueryData(TableName, "EXEC Pr_GetAbonentStatusLookUp @IsRoot = " & IsRoot, "GetAbonentStatus")


        If IsNothing(sender.DataSource) Then
            With sender
                .ClearNodes()
                .DataSource = iDataSet.Tables(TableName)
                .ParentFieldName = "ParentId"
                .KeyFieldName = "Id"
                .BestFitColumns(True)
                .StateImageList = ImageCol
                HidenAllColumns_TreeList(sender)
                .Columns("Name").Visible = True
            End With
        End If

        ' всем нодам присваиваем иконку
        For Each nd As TreeListNode In sender.Nodes
            FillSelectImageIndex(nd, IsRoot)
            If nd.Level = IsRoot Then
                nd.StateImageIndex = 1
            Else
                nd.StateImageIndex = 2
            End If
        Next
        ' Если ROOT "Все ..." разворачиваем его
        If IsRoot = 1 And sender.Nodes.Count <> 0 Then
            With sender.Nodes(0)
                .Expanded = True
                .StateImageIndex = 0
            End With
        End If
    End Sub
    ' цикл по всем дочерним узлам
    Private Sub FillSelectImageIndex(ByVal ParentNode As TreeListNode, ByVal IsRoot As Integer)
        For Each nd As TreeListNode In ParentNode.Nodes
            If nd.Level = IsRoot Then
                nd.StateImageIndex = 1
            Else
                nd.StateImageIndex = 2
            End If
            FillSelectImageIndex(nd, IsRoot)
        Next
    End Sub
    ' собираем чекнутые узлы
    Friend Sub GetTreeListValues_AbonStatus(ByVal sender As DevExpress.XtraTreeList.TreeList)
        Dim nD As TreeListNode = sender.FocusedNode ' активный узел
        Dim sep As String
        ' обнуляем все переменные
        AbonentStatusId = "NULL"
        AbonentStatusName = "NULL"
        ExtAbonentStatusId = "NULL"
        ExtAbonentStatusName = "NULL"
        AbonentStatusMultyStringId = "NULL"
        AbonentStatusMultyStringName = "NULL"
        ' если включен мультивыбор
        If sender.OptionsView.ShowCheckBoxes Then
            ' собираем чекнутые строки если они есть или если чекнут Root значит фильтра нет
            If sender.GetAllCheckedNodes.Count = 0 Or sender.Nodes(0).Checked Then GoTo m1
            For Each n As TreeListNode In sender.GetAllCheckedNodes
                ' среди причин статусов
                If n("ExtAbonentStatusId") <> "NULL" Then
                    AbonentStatusMultyStringId += sep & n.Item("ExtAbonentStatusId")
                    AbonentStatusMultyStringName += sep & n.Item("ExtAbonentStatus")
                    sep = ","
                End If
            Next
            AbonentStatusMultyStringId = "'" & Replace(AbonentStatusMultyStringId, "NULL", "") & "'"
            AbonentStatusMultyStringName = Replace(Replace(AbonentStatusMultyStringName, "NULL", ""), sep, Chr(10))
        Else
            If IsNothing(sender.FocusedNode) = False Then
                AbonentStatusId = nD("AbonentStatusId")
                AbonentStatusName = nD("AbonentStatus")
                ExtAbonentStatusId = nD("ExtAbonentStatusId")
                ExtAbonentStatusName = nD("ExtAbonentStatus")
            End If
        End If
m1:
        'Console.WriteLine("AbonentStatusId - " & AbonentStatusId)
        'Console.WriteLine("AbonentStatusName - " & AbonentStatusName)
        'Console.WriteLine("ExtAbonentStatusId - " & ExtAbonentStatusId)
        'Console.WriteLine("ExtAbonentStatusName - " & ExtAbonentStatusName)
        'Console.WriteLine("AbonentStatusMultyStringId - " & AbonentStatusMultyStringId)
        'Console.WriteLine("AbonentStatusMultyStringName - " & AbonentStatusMultyStringName)
        'Console.WriteLine(Chr(10))
    End Sub
End Module
