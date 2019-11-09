Imports System.Windows.Forms
Imports Microsoft.Office.Interop
Imports DevExpress.XtraEditors

Public Class frLetterTSO
    Private Sub frLetterTSO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SelectQueryData(
                        "AbonentCountersList",
                        "Exec Pr_AbonentCountersList " & pref_AbonentId,
                        "frLetterTSO_Load.AbonentCountersList"
                        )
        Me.DGView_NumbersPoint.DataSource = iDataSet.Tables("AbonentCountersList")
        ' Отключаем сортировку столбцов по всему Гриду
        For i = 0 To Me.DGView_NumbersPoint.ColumnCount - 1
            Me.DGView_NumbersPoint.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        ' Скрываем все столбцы
        For i = 0 To Me.DGView_NumbersPoint.ColumnCount - 1
            Me.DGView_NumbersPoint.Columns.Item(i).Visible = False
        Next
        DGView_NumbersPoint.Columns(0).HeaderCell = New HeaderCellCheckBox()
        ' Отображаем нужные столбцы и задаем им имена
        Dim ColGrid As Object = Me.DGView_NumbersPoint.Columns
        ColGrid.Item("iCheck").HeaderText = ""
        ColGrid.Item("iCheck").Visible = True
        ColGrid.Item("PointNumber").HeaderText = "№ Точки учета"
        ColGrid.Item("PointNumber").Visible = True
        ColGrid.Item("PointNumber").ReadOnly = True
        ColGrid.Item("CounterName").HeaderText = "Тип прибора учета"
        ColGrid.Item("CounterName").Visible = True
        ColGrid.Item("CounterName").ReadOnly = True
        ColGrid.Item("CounterNumber").HeaderText = "№ прибора учата"
        ColGrid.Item("CounterNumber").Visible = True
        ColGrid.Item("CounterNumber").ReadOnly = True
        ' Проверка на какой лицевой установить галку
        For Each row As DataGridViewRow In DGView_NumbersPoint.Rows
            If row.Cells("PointNumber").Value = frAbonents.txt_AbonNumber.Text Then
                row.Cells("iCheck").Value = True
            End If
        Next
    End Sub

    Private Sub DGView_NumbersPoint_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles DGView_NumbersPoint.ColumnHeaderMouseClick
        ' Если тип столбца CheckBox
        If sender.Columns(e.ColumnIndex).HeaderCell.GetType() = GetType(HeaderCellCheckBox) Then
            ' Активируем соседний столбец
            sender.SelectedCells(DGView_NumbersPoint.Columns.Item("PointNumber").Index).Selected = True
            ' Перебираем все строки и инвертируем галки
            For Each row As DataGridViewRow In sender.Rows
                row.Cells(e.ColumnIndex).Value = CType(sender.Columns(e.ColumnIndex).HeaderCell, HeaderCellCheckBox).All
            Next
        End If
    End Sub

    Private Sub btn_Forming_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Forming.Click
        Dim SFD As New SaveFileDialog   ' Экземпляр диалога для сохранения
        Dim CountCheck As Integer = 0   ' Счетчик галок
        Dim oWord As Word.Application   ' Экземпляр Word
        Dim oDoc As Word.Document       ' Экземпляр Word-овского документа

        ' Проверка выбран ли хоть один лицевой
        For Each row As DataGridViewRow In DGView_NumbersPoint.Rows
            If row.Cells("iCheck").Value = True Then
                CountCheck += 1
            End If
        Next
        ' Если ничего не выбрано
        If CountCheck = 0 Then
            XtraMessageBox.Show("Для формирования заявки не выбраны лицевые!",
                                            Application.ProductName,
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Если выбрано больше двух лицевых
        If CountCheck >= 3 Then
            XtraMessageBox.Show("Шаблон заявки расчитан на два и менее лицевых!" & Chr(10) & "Для расширения функционала обратитесь к разработчиуку https://vk.com/lobin_max",
                                            Application.ProductName,
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error)
            Exit Sub
        End If



        SFD.Filter = "Документ Word (*.docx)|*.docx"
        SFD.FileName = "Заявка на рассторжение " & frAbonents.txt_Adress.Text
        If SFD.ShowDialog = DialogResult.OK Then
            oWord = New Word.Application
            oWord.Visible = True

            Select Case CountCheck
                Case 1 ' Если выбран один лицевой
                    For Each row As DataGridViewRow In DGView_NumbersPoint.Rows
                        If row.Cells("iCheck").Value = True Then
                            oDoc = oWord.Documents.Add(SaveResToTemp(My.Resources.ltrCloseContract_1))
                            oDoc.Bookmarks.Item("AbonNumber_" & CountCheck).Range.Text = row.Cells("PointNumber").Value
                        End If
                    Next
                    oDoc.Bookmarks.Item("Addres_" & CountCheck).Range.Text = frAbonents.txt_Adress.Text
                    oDoc.Bookmarks.Item("FIO_" & CountCheck).Range.Text = frAbonents.txt_FIO.Text
                    If frAbonents.txt_MobileNumber.Text = "7 (___) ___-__-__" Then
                        oDoc.Bookmarks.Item("Phone_" & CountCheck).Range.Text = "Нет данных"
                    Else
                        oDoc.Bookmarks.Item("Phone_" & CountCheck).Range.Text = frAbonents.txt_MobileNumber.Text
                    End If
                    oDoc.Bookmarks.Item("Performer").Range.Text = pref_PerformerName
                    oDoc.SaveAs(SFD.FileName)

                Case 2 ' Если выбрано два лицевых
                    Dim index As Integer = 0 ' Индекс строки в шаблоне
                    oDoc = oWord.Documents.Add(SaveResToTemp(My.Resources.ltrCloseContract_2))
                    ' Перебираем строки по гриду
                    For Each row As DataGridViewRow In DGView_NumbersPoint.Rows
                        ' Если обнаружена галка
                        If row.Cells("iCheck").Value = True Then
                            ' Заполняем закладки в шаблоне
                            index += 1
                            oDoc.Bookmarks.Item("AbonNumber_" & index).Range.Text = row.Cells("PointNumber").Value
                            oDoc.Bookmarks.Item("Addres_" & index).Range.Text = frAbonents.txt_Adress.Text
                            oDoc.Bookmarks.Item("FIO_" & index).Range.Text = frAbonents.txt_FIO.Text
                            If frAbonents.txt_MobileNumber.Text = "7 (___) ___-__-__" Then
                                oDoc.Bookmarks.Item("Phone_" & index).Range.Text = "Нет данных"
                            Else
                                oDoc.Bookmarks.Item("Phone_" & index).Range.Text = frAbonents.txt_MobileNumber.Text
                            End If
                            oDoc.Bookmarks.Item("Performer").Range.Text = pref_PerformerName
                        End If
                    Next
                    oDoc.SaveAs(SFD.FileName)
            End Select

            oDoc = Nothing
            oWord = Nothing
            SFD.Dispose()
        End If
    End Sub
End Class

