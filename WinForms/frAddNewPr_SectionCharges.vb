Imports DevExpress.XtraVerticalGrid.Rows
Imports DevExpress.XtraEditors

Public Class frAddNewPr_SectionCharges

    Private Sub frAddNewPr_SectionCharges_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        RemoveTableDataSet(Me)
        Me.Dispose()
    End Sub
    Private Sub frAddNewPr_SectionCharges_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.lbAddOrEdit.Appearance.ImageIndex = AddOrEdit - 2
        Select Case AddOrEdit
            Case 2 ' Создание
                SelectQueryData("LastCharges." & Me.Name,
                                 "EXEC Pr_PointsPublicCharges " & _
                                 "@SectionId = " & frSectionODN.tlODUlist.FocusedNode("Id") & ", " & _
                                 "@DtDoc = '" & Now.ToShortDateString & "', " & _
                                 "@Function = 1", "EXEC Pr_PointsPublicCharges.Add")
            Case 3 ' Изменение
                SelectQueryData("LastCharges." & Me.Name,
                                 "EXEC Pr_PointsPublicCharges " & _
                                 "@SectionId = " & frSectionODN.tlODUlist.FocusedNode("Id") & ", " & _
                                 "@DocumentId = " & frSectionODN.gvChargesSection.GetFocusedRowCellDisplayText("DocumentId") & ", " & _
                                 "@DtDoc = '" & frSectionODN.gvChargesSection.GetFocusedRowCellDisplayText("DtDoc") & "', " & _
                                 "@Function = 1", "EXEC Pr_PointsPublicCharges.Edit")
        End Select
        Me.vgManager.DataSource = iDataSet.Tables("LastCharges." & Me.Name)
        ' активируем ячейку с показания
        Me.vgManager.Select()
        Me.vgManager.Focus()
        Me.vgManager.FocusedRow = Me.rowNewIndication
        Me.vgManager.FocusedRecordCellIndex = 1
    End Sub
    ' расчет расхода через сервер при изменении значений
    Private Sub vgManager_CellValueChanged(sender As Object, e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles vgManager.CellValueChanged
        If IsDBNull(Me.DtDocNew.Value) Then Me.DtDocNew.Value = Now.ToShortDateString
        Dim DocumentId As String = "NULL"
        Dim NewIndication As Integer = Me.NewIndication.Value       ' запоминаем показания
        Dim DtDocNew As Date = Me.DtDocNew.Value.ToShortDateString  ' запоминаем дату показаний
        ' при изменении записи фиксируем DocumentId
        If AddOrEdit = 3 Then DocumentId = frSectionODN.gvChargesSection.GetFocusedRowCellDisplayText("DocumentId")
        If e.Row.Properties.RowHandle = 5 Then
            SelectQueryData("LastCharges." & Me.Name,
                                 "EXEC Pr_PointsPublicCharges " & _
                                 "@SectionId = " & frSectionODN.tlODUlist.FocusedNode("Id") & ", " & _
                                 "@DtDoc = '" & Me.DtDocNew.Value.ToShortDateString & "', " & _
                                 "@DocumentId = " & DocumentId & ", " & _
                                 "@Function = 1", "EXEC Pr_PointsPublicCharges.Add")
            Me.NewIndication.Value = NewIndication
            Me.DtDocNew.Value = DtDocNew.ToShortDateString
            ' пересчитываем расход
            Me.Consumption.Properties.Value =
                ExecuteScalar("SELECT dbo.Pr_fnsPointsPublicGetConsumption (" &
                              frSectionODN.tlODUlist.FocusedNode("Id") & ", " & _
                              "'" & Convert.ToDateTime(Me.DtDocNew.Value).ToShortDateString & "', " &
                              DocumentId & ", " & _
                              Me.NewIndication.Value & ")",
                              "EXEC Pr_fnsPointsPublicGetConsumption")
            Me.btnOk.Focus()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
    ' ok
    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        Dim Period As Integer = Convert.ToDateTime(Me.DtDocNew.Value).Year * 100 + Convert.ToDateTime(Me.DtDocNew.Value).Month
        Dim DocumentId As String
        If AddOrEdit = 2 Then DocumentId = "NULL"
        If AddOrEdit = 3 Then DocumentId = frSectionODN.gvChargesSection.GetFocusedRowCellDisplayText("DocumentId")

        frSectionODN.DocumentId = ExecuteScalar("EXEC Pr_PointsPublicCharges " &
                        "@SectionId = " & frSectionODN.tlODUlist.FocusedNode("Id") & ", " &
                        "@DocumentId = " & DocumentId & ", " &
                        "@DtDoc = '" & Me.DtDocNew.Value.ToShortDateString & "', " &
                        "@NewIndication = " & Me.NewIndication.Value & ", " &
                        "@Function = " & AddOrEdit,
                        "EXEC Pr_PointsPublicCharges @Function = " & AddOrEdit)
        ' активируем период в дереве если он только будет создан
        If IsNothing(frSectionODN.tlPeriodList.FindNodeByID(Period)) Then
            frSectionODN.iSelectedNode_Period = Convert.ToDateTime(Me.DtDocNew.Value).Year * 100 + Convert.ToDateTime(Me.DtDocNew.Value).Month
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class