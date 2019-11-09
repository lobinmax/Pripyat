Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraTreeList
Imports DevExpress.Utils
' Модуль заполнения дерева Управляющих организаций
Module mdSchemeGKO
    ' переменные для хранения выбранных значений в TreeListLookUpEdit
    Friend GKHMultyStringId As String = "NULL"
    Friend GKHMultyStringName As String = "NULL"
    Friend GKOid As String = "NULL"
    Friend GKHid As String = "NULL"
    Friend GKOName As String = "NULL"
    Friend GKHName As String = "NULL"
    ' ===============================
    ' sender - TreeList c управляющими
    ' isExpanded - разворачиватьили нет ноды
    ' iSelectedNode - индекс нода для еге активации в 0-м уровне
    ' VisibleAddress - отображение столбца с адресом
    ' IsRoot - 1-Рут узел Все Управляющие
    Dim ImageCol As New ImageCollection
    Public Sub LoadGKOTree(ByVal sender As DevExpress.XtraTreeList.TreeList,
                           ByVal _form As Object,
                           ByVal isExpanded As Boolean,
                           ByVal iSelectedNode As Integer,
                           Optional VisibleAddress As Boolean = False,
                           Optional ByVal IsRoot As Integer = 0)
        ' загружаем изображения в коллекцию
        ImageCol.Clear()
        ImageCol.AddImage(My.Resources.home_16x16)      ' управляющая
        ImageCol.AddImage(My.Resources.broom_16x16)     ' обслуживающая
        ImageCol.AddImage(My.Resources.home_16x161)     ' Рут
        SelectQueryData(
                        "Pr_GKOTree." & _form.Name,
                        "EXEC Pr_GetGKOLookUp @IsRoot = " & IsRoot,
                        "Pr_GKOTree"
                        )

        If IsNothing(sender.DataSource) Then
            With sender
                .ClearNodes()
                .DataSource = iDataSet.Tables("Pr_GKOTree." & _form.Name)       ' источник данных
                .ParentFieldName = "ParentId"                                   ' Столбец с родителями
                .KeyFieldName = "Id"                                            ' Столбец с дочерними данными
                .StateImageList = ImageCol                                      ' Коллекция с изображения
                .BestFitColumns(True)                                           ' Автоширина по столбцам
            End With
        End If
        sender.FocusedNode = sender.FindNodeByID(iSelectedNode)               ' фокус на заданный узел

        HidenAllColumns_TreeList(sender) ' скрываем все столбцы
        If VisibleAddress Then
            sender.Columns("Address").Visible = True
            sender.Columns("Address").Caption = "Адрес организации"
        End If
        sender.Columns("Name").Visible = True
        sender.Columns("Name").Caption = "Наименование организации"
        ' всем нодам присваиваем иконку
        Dim tl As TreeListNodes = sender.Nodes
        ' если есть Рут узел
        If IsRoot = 1 Then
            tl = sender.Nodes(0).Nodes
            sender.Nodes(0).StateImageIndex = 2
        End If
        ' назначаем иконки для узлов
        For Each nd As TreeListNode In tl
            FillSelectImageIndex(nd)
            nd.StateImageIndex = 0
        Next
        ' разворачиваем узлы
        If isExpanded Then sender.ExpandAll()
        ' Если ROOT "Все улицы" разворачиваем его
        If IsRoot = 1 And sender.Nodes.Count <> 0 Then sender.Nodes(0).Expanded = True
    End Sub
    ' цикл по всем дочерним узлам
    Private Sub FillSelectImageIndex(ByVal ParentNode As TreeListNode)
        For Each nd As TreeListNode In ParentNode.Nodes
            nd.StateImageIndex = 1
        Next
    End Sub
    ' собираем чекнутые узлы
    Friend Sub GetTreeListValues_GKO(ByVal sender As DevExpress.XtraTreeList.TreeList)
        Dim nD As TreeListNode = sender.FocusedNode ' активный узел
        Dim sep As String
        ' обнуляем все переменные
        GKHMultyStringId = "NULL"
        GKHMultyStringName = "NULL"
        GKOid = "NULL"
        GKHid = "NULL"
        GKOName = "NULL"
        GKHName = "NULL"
        ' если включен мультивыбор
        If sender.OptionsView.ShowCheckBoxes Then
            ' собираем чекнутые строки если они есть или если чекнут Root значит фильтра нет
            If sender.GetAllCheckedNodes.Count = 0 Or sender.Nodes(0).Checked Then GoTo m1
            For Each n As TreeListNode In sender.GetAllCheckedNodes
                ' собираем среди обслуживающих
                If n.Item("GKType") = "GKH" Then
                    GKHMultyStringId += sep & n.Item("Id")
                    GKHMultyStringName += sep & n.Item("GKHName")
                    sep = ","
                End If
            Next
            GKHMultyStringId = "'" & Replace(GKHMultyStringId, "NULL", "") & "'"
            GKHMultyStringName = Replace(GKHMultyStringName, "NULL", "")
        Else
            If IsNothing(sender.FocusedNode) = False Then
                GKOid = nD("GKOId")
                GKHid = nD("GKHId")
                GKOName = nD("GKOName")
                GKHName = nD("GKHName")
            End If
        End If
m1:
        'Console.WriteLine("GKHMultyStringId - " & GKHMultyStringId)
        'Console.WriteLine("GKHMultyStringName - " & GKHMultyStringName)
        'Console.WriteLine("GKOid - " & GKOid)
        'Console.WriteLine("GKHid - " & GKHid)
        'Console.WriteLine("GKOName - " & GKOName)
        'Console.WriteLine("GKHName - " & GKHName)
        'Console.WriteLine(Chr(10))
    End Sub
End Module
