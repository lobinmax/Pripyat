Imports System.Windows.Forms
Imports System.Threading
Imports Microsoft.Office.Interop
Imports DevExpress.XtraEditors

Public Class frExportTo
    Dim FileName As String ' Имя файла на выходе
    ' Для работы с Excel
    Dim exl As New Excel.Application
    Dim exlSheet As Excel.Worksheet

    Friend ExportFunction As Integer    ' Номер функции экпорта для идентификации откуда запущена процедура
    ' 0 - frRouter.TS_btnToExcel_Click (Экспорт списка с маршрутами)
    ' 1 - frRouter.TS_btnToExcel_Click (Экспорт списка лицевых без назначенного маршрута)

    Private Sub frExportTo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        exl.Quit()
        exl = Nothing
        LiberationMemory()
        Me.Close()
        Me.Dispose()
        Process.Start(FileName)
    End Sub

    Private Sub frExportTo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Select Case ExportFunction
            Case 0 ' 0 - frRouter.TS_btnToExcel_Click (Экспорт списка с маршрутами)
                Dim iExportFunction_0 As New Thread(AddressOf ExportFunction_0)
                iExportFunction_0.Start(frRouter.DG_RoutersList)
            Case 1 ' 1 - frRouter.TS_btnToExcel_Click (Экспорт списка лицевых без назначенного маршрута)
                Dim iExportFunction_1 As New Thread(AddressOf ExportFunction_1)
                iExportFunction_1.Start(frRouter.DG_RoutersList)
        End Select
    End Sub

    Private Sub ExportFunction_0(ByVal iGrig As Object)
        Dim rowsTotal, colsTotal As Short
        Dim I, j, iC As Short
        Dim counter As Integer = 0
        FileName = My.Computer.FileSystem.SpecialDirectories.Desktop & "\Маршрутизация контролеров_" & Replace(Now.ToString, ":", "-") & ".xlsx"
        Try
            exl.Workbooks.Add()
            exlSheet = exl.Workbooks(1).Worksheets(1)
            exlSheet.Name = "Маршрутизация участков"
            rowsTotal = iGrig.RowCount - 1
            colsTotal = iGrig.Columns.Count - 1
            With exlSheet
                .Cells.Select()
                .Cells.Delete()
                For iC = 5 To colsTotal - 1
                    .Cells(1, iC - 4).Value = iGrig.Columns(iC).HeaderText
                Next
                For I = 0 To rowsTotal
                    For j = 5 To colsTotal - 1
                        .Cells(I + 2, j - 4).value = iGrig.Rows(I).Cells(j).Value
                        counter += 1
                        pn_Progress.Width = (((rowsTotal * 4) - ((rowsTotal * 4) - counter)) / (rowsTotal * 4)) * 520
                    Next j
                Next I
                .Rows("1:1").Font.FontStyle = "Bold"
                .Rows("1:1").Font.Size = 10
                .Cells.Columns.AutoFit()
                .Cells.Select()
                .Cells.EntireColumn.AutoFit()
                .Cells(1, 1).Select()
                exlSheet.SaveAs(FileName)
            End With
            exl.Visible = True
        Catch ex As Exception
            XtraMessageBox.Show("Ошибка экспорта: " & ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Close()
    End Sub

    Private Sub ExportFunction_1(ByVal iGrig As Object)
        Dim rowsTotal, colsTotal As Short
        Dim I, j, iC As Short
        Dim counter As Integer = 0
        FileName = My.Computer.FileSystem.SpecialDirectories.Desktop & "\Лицевые без маршрута_" & Replace(Now.ToString, ":", "-") & ".xlsx"
        Try
            exl.Workbooks.Add()
            exlSheet = exl.Workbooks(1).Worksheets(1)
            exlSheet.Name = "Лицевые без маршрута"
            rowsTotal = iGrig.RowCount
            colsTotal = iGrig.Columns.Count
            With exlSheet
                .Cells.Select()
                .Cells.Delete()
                For iC = 0 To colsTotal - 1
                    .Cells(1, iC + 1).Value = iGrig.Columns(iC).HeaderText
                Next
                For I = 0 To rowsTotal - 1
                    For j = 0 To colsTotal - 1
                        If j = 0 Then
                            .Cells(I + 2, j + 1).value = "'" & iGrig.Rows(I).Cells(j).Value
                            counter += 1
                            pn_Progress.Width = (((rowsTotal * 5) - ((rowsTotal * 5) - counter)) / (rowsTotal * 5)) * 520
                        Else
                            .Cells(I + 2, j + 1).value = iGrig.Rows(I).Cells(j).Value
                            counter += 1
                            pn_Progress.Width = (((rowsTotal * 5) - ((rowsTotal * 5) - counter)) / (rowsTotal * 5)) * 520
                        End If
                    Next j
                Next I
                .Rows("1:1").Font.FontStyle = "Bold"
                .Rows("1:1").Font.Size = 10
                .Cells.Columns.AutoFit()
                .Cells.Select()
                .Cells.EntireColumn.AutoFit()
                .Cells(1, 1).Select()
                exlSheet.SaveAs(FileName)
            End With
        Catch ex As Exception
            XtraMessageBox.Show("Ошибка экспорта: " & ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Close()
    End Sub
End Class
