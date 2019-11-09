Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraEditors

Public Class frBookGKO
    Dim iSelectedNode As Integer  ' Индекс активного нода
    ' Закрытие формы
    Private Sub frBookGKO_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        RemoveTableDataSet(Me)
        Me.Dispose()
        frMain.Show()
        frMain.NotifyIcon.Visible = False
        frMain.Time.Enabled = True
    End Sub
    ' Загрузка формы
    Private Sub frBookGKO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        tmWaitAnimation.StartWaitingIndicator(Me, 0)
        btnUpdate_ItemClick(sender, Nothing)
        tmWaitAnimation.StopWaitingIndicator()
    End Sub
    ' Выделение нода
    Private Sub tlGKO_AfterFocusNode(sender As Object, e As DevExpress.XtraTreeList.NodeEventArgs) Handles tlGKO.AfterFocusNode
        ' Запись индекса активного нода, только на нулевом уровне
        If sender.FocusedNode IsNot Nothing Then
            If sender.FocusedNode.Level = 0 Then
                iSelectedNode = sender.GetNodeIndex(Me.tlGKO.FocusedNode)
            End If
        End If
        iSelectedNode = tlGKO.FocusedNode.Id
    End Sub
    ' Правой кнопкой мыши вызываем контекстное меню
    Private Sub tlGKO_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles tlGKO.MouseClick
        Dim tl As TreeList = sender
        Dim hitinfo As TreeListHitInfo = tl.CalcHitInfo(e.Location)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ' если меню вызвано вне строк, можно только добавить
            If IsNothing(hitinfo.Node) Then
                Me.btnDeleteGKO.Enabled = False
                Me.btnEditGKO.Enabled = False
                Me.btnAddGKH.Enabled = False
                ' и если нодов 0, то добавить только УК
                If sender.Nodes.Count = 0 Then
                    btnAddGKH.Enabled = False
                End If
                sender.SetFocusedNode(Nothing)
                Me.pmGKO.ShowPopup(MousePosition)
            Else
                Me.btnAddGKH.Enabled = True
                Me.btnDeleteGKO.Enabled = True
                Me.btnEditGKO.Enabled = True
                Me.pmGKO.ShowPopup(MousePosition)
            End If
        End If
    End Sub
    ' редактирование по двойному клику только  для обслуживающих
    Private Sub tlGKO_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles tlGKO.MouseDoubleClick
        If sender.AllNodesCount <> 0 Then
            Dim tl As TreeList = sender
            Dim hitinfo As TreeListHitInfo = tl.CalcHitInfo(e.Location)
            If hitinfo.Node IsNot Nothing And sender.FocusedNode.HasChildren = False And e.Button = Windows.Forms.MouseButtons.Left Then
                btnEditGKO_ItemClick(sender, Nothing) ' Изменение записи
            End If
        End If
    End Sub
    ' показываем автора и кто изменил
    Private Sub tlGKO_FocusedNodeChanged(sender As System.Object, e As DevExpress.XtraTreeList.FocusedNodeChangedEventArgs) Handles tlGKO.FocusedNodeChanged
        If sender.Nodes.Count = 0 Then
            lbCreater.Caption = Nothing
            lbUpdater.Caption = Nothing
        Else
            lbCreater.Caption = "Создано:  <u>" & sender.FocusedNode("CreaterName") & " - " & _
                               Format(sender.FocusedNode("CreateDt"), "d") & "г.</u>"
            lbUpdater.Caption = "Изменено:  <u>" & sender.FocusedNode("UpdaterName") & " - " & _
                Format(sender.FocusedNode("UpdateDt"), "d") & "г.</u>"
        End If
    End Sub
#Region "Контектное меню"
    ' Добавить управляющую
    Private Sub btnAddGKO_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnAddGKO.ItemClick
        ' Если есть записи
        If Me.tlGKO.Nodes.Count <> 0 Then
            ' если что то выбрано среди строк
            If IsNothing(Me.tlGKO.FocusedNode) = False Then
                ' если выбран уровень с обслуживающими
                If Me.tlGKO.FocusedNode.Level = 1 Then
                    ' Активируем его родителя с управляющими
                    Me.tlGKO.SetFocusedNode(Me.tlGKO.FocusedNode.ParentNode)
                End If
            End If
        End If

        AddOrEdit = 2 ' Добавление
        frAddNewPr_Books_GKO.GKType = "GKO"
        If frAddNewPr_Books_GKO.ShowDialog = Windows.Forms.DialogResult.OK Then
            btnUpdate_ItemClick(sender, Nothing)
        End If
    End Sub
    ' Добавить обслуживающую
    Private Sub btnAddGKH_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnAddGKH.ItemClick
        ' Если выбран уровень с обслуживающими
        If Me.tlGKO.FocusedNode.Level = 1 Then
            ' Активируем его родителя с управляющими
            Me.tlGKO.SetFocusedNode(Me.tlGKO.FocusedNode.ParentNode)
        End If
        AddOrEdit = 2 ' Добавление
        frAddNewPr_Books_GKO.GKType = "GKH"
        If frAddNewPr_Books_GKO.ShowDialog = Windows.Forms.DialogResult.OK Then
            btnUpdate_ItemClick(sender, Nothing)
        End If
    End Sub
    ' Изменение записи
    Private Sub btnEditGKO_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEditGKO.ItemClick
        AddOrEdit = 3 ' Изменение
        If Me.tlGKO.FocusedNode.Level = 0 Then frAddNewPr_Books_GKO.GKType = "GKO"
        If Me.tlGKO.FocusedNode.Level = 1 Then frAddNewPr_Books_GKO.GKType = "GKH"
        If frAddNewPr_Books_GKO.ShowDialog = Windows.Forms.DialogResult.OK Then
            btnUpdate_ItemClick(sender, Nothing)
        End If
    End Sub
    ' Удаление записи
    Private Sub btnDeleteGKO_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDeleteGKO.ItemClick
        ' Удаление управляющей
        If Me.tlGKO.FocusedNode.Level = 0 Then
            If XtraMessageBox.Show("Управляющая организация <u><b>" & Me.tlGKO.FocusedNode("GKName") & "</u></b>" & Chr(10) & _
                                   "и все принадлежащие ей Обслуживающие будут удалены!" & Chr(10) & _
                                   "Вы согласны?",
                                   Application.ProductName,
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question,
                                   DevExpress.Utils.DefaultBoolean.True) = Windows.Forms.DialogResult.Yes Then
                ExecuteQuery(
                   "EXEC Pr_Books_GKO " & _
                       "@GKOid = " & Me.tlGKO.FocusedNode("Id") & ", " & _
                       "@Function = 4", "DeleteGKO"
                   ) : btnUpdate_ItemClick(sender, Nothing)
            End If
            ' Удаление обслуживающей
        Else
            If XtraMessageBox.Show("Ослуживающая организация <u><b>" & Me.tlGKO.FocusedNode("GKName") & "</u></b> будет удалена!" & Chr(10) & _
                                   "Вы согласны?",
                                   Application.ProductName,
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question,
                                   DevExpress.Utils.DefaultBoolean.True) = Windows.Forms.DialogResult.Yes Then
                ExecuteQuery(
                   "EXEC Pr_Books_GKH " & _
                       "@GKHid = " & Me.tlGKO.FocusedNode("Id") & ", " & _
                       "@Function = 4", "DeleteGKH"
                   ) : btnUpdate_ItemClick(sender, Nothing)
            End If
        End If
    End Sub
    ' Обновление данных
    Private Sub btnUpdate_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnUpdate.ItemClick
        LoadGKOTree(Me.tlGKO, Me, True, iSelectedNode, True)
    End Sub
#End Region
    ' Горячие клавиши на поле таблицы
    Private Sub tlGKO_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tlGKO.KeyDown
        ' если что то выбрано
        If Me.tlGKO.FocusedNode IsNot Nothing Then
            If e.KeyCode = Keys.Delete Then btnDeleteGKO_ItemClick(sender, Nothing) ' Удаление записи
            If e.KeyCode = Keys.Enter Then btnEditGKO_ItemClick(sender, Nothing) ' Изменение записи
            If e.KeyCode = Keys.F1 Then btnUpdate_ItemClick(sender, Nothing) ' Обновление данных
        End If
    End Sub
End Class