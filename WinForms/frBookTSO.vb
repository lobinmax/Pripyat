Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Columns

Public Class frBookTSO

    Sub New()

        InitializeComponent()
    End Sub
    Dim iSelectedRow As Integer  ' Индекс активной строки
    ' Закрытие формы
    Private Sub frBookTSO_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        RemoveTableDataSet(Me)
        Me.Dispose()
        frMain.Show()
        frMain.NotifyIcon.Visible = False
        frMain.Time.Enabled = True
    End Sub
    ' Загрузка формы
    Private Sub frBookTSO_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        tmWaitAnimation.StartWaitingIndicator(Me, 0)
        btnUpdate_ItemClick(sender, Nothing)
        If iDataSet.Tables.Contains("TSO." & Me.Name) Then
            Me.gcTSO.DataSource = iDataSet.Tables("TSO." & Me.Name)
            HidenAllColumns_Grid(Me.gvTSO, iDataSet.Tables("TSO." & Me.Name))
            Me.gvTSO.Columns("TSOAddress").Visible = True
            Me.gvTSO.Columns("TSOAddress").Caption = "Адрес ТСО"
            Me.gvTSO.Columns("TSOName").Visible = True
            Me.gvTSO.Columns("TSOName").Caption = "Наименование ТСО"
            Me.gvTSO.BestFitColumns()
        End If
        tmWaitAnimation.StopWaitingIndicator()
    End Sub

#Region "gvTSO"
    ' показываем автора и кто изменил
    Private Sub gvTSO_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles gvTSO.FocusedRowChanged
        If sender.RowCount = 0 Then
            lbCreater.Caption = Nothing
            lbUpdater.Caption = Nothing
        Else
            lbCreater.Caption = "Создано:  <u>" & sender.GetFocusedRowCellDisplayText("CreaterName") & " - " & _
                sender.GetFocusedRowCellDisplayText("CreateDt") & "г.</u>"
            lbUpdater.Caption = "Изменено:  <u>" & sender.GetFocusedRowCellDisplayText("UpdaterName") & " - " & _
                sender.GetFocusedRowCellDisplayText("UpdateDt") & "г.</u>"
        End If
    End Sub
    ' вызов контекстного меню правой кнопкой
    Private Sub gvTSO_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles gvTSO.MouseDown
        Dim view As GridView = CType(sender, GridView)
        Dim pt As Point = view.GridControl.PointToClient(Control.MousePosition)
        Dim info As GridHitInfo = view.CalcHitInfo(pt)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Me.btnDeleteTSO.Enabled = info.InRow                    ' активность кнопки = был ли клик по строкам, а не вне их
            Me.btnEditTSO.Enabled = info.InRow
            Me.pmTSO.ShowPopup(Cursor.Position)                     ' вызов меню
        End If
        ' если клик двойной и по строке а не вне ее
        If e.Clicks = 2 And info.InRow Then
            btnEditGKO_ItemClick(sender, Nothing)
        End If
        iSelectedRow = Me.gvTSO.FocusedRowHandle                    ' запоминаем выделенную строку
    End Sub
    ' Горячие клавиши на поле таблицы
    Private Sub tlGKO_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles gvTSO.KeyDown
        ' если что то выбрано
        If Me.gvTSO.GetSelectedRows IsNot Nothing Then
            If e.KeyCode = Keys.Delete Then btnDeleteGKO_ItemClick(sender, Nothing) ' Удаление записи
            If e.KeyCode = Keys.Enter Then btnEditGKO_ItemClick(sender, Nothing) ' Изменение записи
            If e.KeyCode = Keys.F1 Then btnUpdate_ItemClick(sender, Nothing) ' Обновление данных
        End If
    End Sub
#End Region

#Region "Контектное меню"
    ' Добавить ТСО
    Private Sub btnAddTSO_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnAddTSO.ItemClick
        AddOrEdit = 2 ' Добавление
        If frAddNewPr_Books_TSO.ShowDialog = Windows.Forms.DialogResult.OK Then
            btnUpdate_ItemClick(sender, Nothing)
            Me.gvTSO.FocusedRowHandle = Me.gvTSO.RowCount - 1
            Me.gvTSO.SelectRow(Me.gvTSO.RowCount - 1)
        End If
        frAddNewPr_Books_TSO.Dispose()
    End Sub
    ' Изменение записи
    Private Sub btnEditGKO_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEditTSO.ItemClick
        iSelectedRow = Me.gvTSO.FocusedRowHandle
        AddOrEdit = 3 ' Изменение
        If frAddNewPr_Books_TSO.ShowDialog = Windows.Forms.DialogResult.OK Then
            btnUpdate_ItemClick(sender, Nothing)
            Me.gvTSO.FocusedRowHandle = iSelectedRow
            Me.gvTSO.SelectRow(iSelectedRow)
        End If
        frAddNewPr_Books_TSO.Dispose()
    End Sub
    ' Удаление записи
    Private Sub btnDeleteGKO_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDeleteTSO.ItemClick
        If XtraMessageBox.Show("Сетевая организация <u><b>" & Me.gvTSO.GetFocusedRowCellDisplayText("TSOName") & "</u></b> " & _
                               "будет удалена!" & Chr(10) & _
                               "Вы согласны?",
                               Application.ProductName,
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question,
                               DevExpress.Utils.DefaultBoolean.True) = Windows.Forms.DialogResult.Yes Then
            iSelectedRow = Me.gvTSO.FocusedRowHandle
            ExecuteQuery(
               "EXEC Pr_Books_TSO " & _
                   "@TSOId = " & Me.gvTSO.GetFocusedRowCellDisplayText("TSOId") & ", " & _
                   "@Function = 4", "DeleteGKO"
                        )
            btnUpdate_ItemClick(sender, Nothing)
            Me.gvTSO.FocusedRowHandle = iSelectedRow - 1
            Me.gvTSO.SelectRow(iSelectedRow - 1)
        End If
    End Sub
    ' Обновление данных
    Private Sub btnUpdate_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnUpdate.ItemClick
        iSelectedRow = Me.gvTSO.FocusedRowHandle
        SelectQueryData("TSO." & Me.Name, "SELECT * FROM vPr_TSO", "Get_TSO")
        Me.gvTSO.FocusedRowHandle = iSelectedRow
        Me.gvTSO.SelectRow(iSelectedRow)
    End Sub
#End Region
End Class