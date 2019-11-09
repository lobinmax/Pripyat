Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraTreeList
Imports DevExpress.Utils
' Модуль заполнения дерева Типов журналов
Module mdSchemeJournals
    ' переменные для хранения выбранных значений в TreeListLookUpEdit
    Friend JournalMultyStringId As String = "NULL"
    Friend JournalMultyStringName As String = "NULL"
    Friend JournalCodeId As String = "NULL"
    Friend JournalCodeName As String = "NULL"
    Friend DocumentsCodeId As String = "NULL"
    Friend DocumentsCodeName As String = "NULL"
    Friend FocusNode_Journals As Integer = 0 ' ИД активного узла
    Dim ImageCol As New ImageCollection
    Dim _IsRoot As Integer
    Public Sub LoadJournalTree(ByVal sender As DevExpress.XtraTreeList.TreeList,
                                ByVal dsTableName As String,
                                Optional ByVal IsRoot As Integer = 0,
                                Optional ByVal DelWithoutChild As Integer = 0,
                                Optional ByVal IsExpandedRoot As Integer = 0,
                                Optional ByVal IsExpandedJournal As Integer = 0,
                                Optional ByVal IsExpandedDocumets As Integer = 0,
                                Optional ByVal ExpandedAll As Integer = 0,
                                Optional ByVal IsAppearance As Boolean = False
                                )
        EventChangedControl = False
        ' событие при построении, для изменения оформления узлов
        If IsAppearance Then _IsRoot = IsRoot : AddHandler sender.CustomDrawNodeCell, AddressOf d
        ' загружаем изображения в коллекцию
        ImageCol.Clear()
        ImageCol.AddImage(My.Resources.AllJournal_16x16)        ' Root узел
        ImageCol.AddImage(My.Resources.Book_JournalwPen_16x16)  ' Типы журналов
        ImageCol.AddImage(My.Resources.Documents_16x16)         ' Типы документов
        ' Выгружаем список видов журналов
        SelectQueryData(
                        dsTableName,
                        "EXEC Pr_GetLookUp_JournalTypes " &
                            "@IsRoot = " & IsRoot & ", " &
                            "@DelWithoutChild = " & DelWithoutChild & ", " &
                            "@IsExpandedRoot = " & IsExpandedRoot & ", " &
                            "@IsExpandedJournal = " & IsExpandedJournal & ", " &
                            "@IsExpandedDocumets = " & IsExpandedDocumets & ", " &
                            "@ExpandedAll = " & ExpandedAll & "",
                        sender.Name & ".GetJournalList"
                        )
        If IsNothing(sender.DataSource) Then
            With sender
                .ClearNodes()
                .DataSource = iDataSet.Tables(dsTableName)
                .ParentFieldName = "ParentId"
                .KeyFieldName = "Id"
                .BestFitColumns(True)
                .StateImageList = ImageCol
                HidenAllColumns_TreeList(sender)
                .Columns("Name").Visible = True
            End With
        End If
        EventChangedControl = True
        sender.FocusedNode = sender.FindNodeByID(FocusNode_Journals)
        ' если есть Рут узел
        Dim tl As TreeListNodes = sender.Nodes
        If IsRoot = 1 Then
            sender.Nodes(0).StateImageIndex = 0
            sender.Nodes(0).Expanded = sender.Nodes(0).Item("IsExpanded")
            tl = sender.Nodes(0).Nodes
        End If
        ' всем нодам присваиваем иконку
        For Each nd As TreeListNode In tl
            If nd.Level = IsRoot Then
                nd.StateImageIndex = 1
            Else
                nd.StateImageIndex = 2
            End If
            nd.Expanded = nd("IsExpanded")
            FillSelectImageIndex(nd, IsRoot)
        Next
    End Sub
    ' цикл по всем дочерним узлам
    Private Sub FillSelectImageIndex(ByVal ParentNode As TreeListNode, ByVal IsRoot As Integer)
        For Each nd As TreeListNode In ParentNode.Nodes
            If nd.Level = IsRoot Then
                nd.StateImageIndex = 1
            Else
                nd.StateImageIndex = 2
            End If
            nd.Expanded = nd("IsExpanded")
            FillSelectImageIndex(nd, IsRoot)
        Next
    End Sub
    ' событие при построении узлов
    Private Sub d(sender As System.Object, e As DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs)
        Dim cellFont As New Font("Times New Roman", 8)
        Select Case _IsRoot
            Case 0 ' без Root 
                If e.Node.Level = 0 Then
                    e.Appearance.Font = New Font("Tahoma", 8.25, FontStyle.Underline)
                End If
            Case 1 ' С Root
                If e.Node.Level = 0 Then e.Appearance.Font = New Font("Tahoma", 8.25, FontStyle.Bold)
                If e.Node.Level = 1 Then e.Appearance.Font = New Font("Tahoma", 8.25, FontStyle.Underline)
        End Select
    End Sub
End Module
