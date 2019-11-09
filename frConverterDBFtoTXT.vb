Imports Microsoft.Office.Interop
Imports System.IO
Imports DevExpress.XtraEditors

Public Class frConverterDBFtoTXT
    Dim AllDirectories As Integer = 1
    Dim exl As New Excel.Application
    Dim exlSheet As Excel.Worksheet

    Private Sub btn_ChooseFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ChooseFolder.Click
        Dim FBD As New FolderBrowserDialog
        If FBD.ShowDialog Then
            Me.txt_PathFolder.Text = FBD.SelectedPath
        Else
            Me.txt_PathFolder.Text = ""
        End If
    End Sub

    Private Sub btn_Converting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Converting.Click
        Dim iSummPaymants As Decimal
        Dim iCountPaymants As Integer
        Dim iCountRow As Integer
        Dim iStringPay As String = ""
        Dim Dirs As New IO.DirectoryInfo(Me.txt_PathFolder.Text)
        Me.lb_Loger.Items.Clear()
        Me.btn_Converting.Enabled = False
        Me.btn_CreateTXT.Enabled = False
        Try
            For Each D In Dirs.EnumerateFiles("*.dbf", AllDirectories)
                exl.Workbooks.Open(D.FullName)              ' Открываем файл Excel
                exlSheet = exl.Workbooks(1).Worksheets(1)   ' Переходим к первому листу
                ' Количество строк в файле
                iCountRow = exlSheet.Range(Cell1:="A1", _
                                           Cell2:=exlSheet.Range("A" & exlSheet.Rows.Count).End(Excel.XlDirection.xlUp)).Count
                ' Сумма количество квитанций в файле
                iSummPaymants = 0
                iCountPaymants = 0
                For s = 1 To iCountRow
                    If IsNumeric(exlSheet.Cells(s, Me.Num_AbonNumber).Value) Then
                        iSummPaymants = iSummPaymants + exlSheet.Cells(s, Me.Num_SumPayments).Value
                        iCountPaymants = iCountPaymants + 1
                    End If
                Next s

                Me.lab_ReadFile.Text = "Файл - " & D.Name
                Me.lab_ReadCount.Text = "Кол-во квитанций - " & iCountRow
                For i = 1 To iCountRow
                    If IsNumeric(exlSheet.Cells(i, Me.Num_AbonNumber).Value) Then
                        ' Получаем Почтовое отделение из БД
                        SelectQueryData("ItemName", _
 _
                                        "SELECT ItemName " & _
                                        "FROM vItemsPayments " & _
                                        "WHERE   (GroupItemName = 'Почта электронные платежи') AND " & _
                                                "(DivisionCode = '" & exlSheet.Cells(i, 2).Value & "') AND " & _
                                                "(FilialCode = '" & exlSheet.Cells(i, 3).Value & "')",
 _
                                        "GetItemName")

                        iStringPay = exlSheet.Cells(i, Me.Num_DtPayments).Value & ";" & _
                                     "1" & ";" & _
                                     "Почта электронные платежи" & ";" & _
                                     iDataSet.Tables("ItemName").Rows(0).Item("ItemName").ToString & ";" & _
                                     "1" & ";" & _
                                     exlSheet.Cells(i, 2).Value & ";" & _
                                     exlSheet.Cells(i, 3).Value & ";" & _
                                     exlSheet.Cells(i, Me.Num_AbonNumber).Value & ";" & _
                                     exlSheet.Cells(i, Me.Num_DtPayments).Value & ";" & _
                                     "0" & ";" & _
                                     "0" & ";" & _
                                     "0" & ";" & _
                                     exlSheet.Cells(i, Me.Num_SumPayments).Value & ";" & _
                                     "91" & ";" & _
                                     iCountPaymants & ";" & _
                                     iSummPaymants & ";"

                        Me.lb_Loger.Items.Add(iStringPay)
                        Me.lb_Loger.SelectedIndex = Me.lb_Loger.Items.Count - 1
                        My.Application.DoEvents()
                    End If
                Next i
                exl.Quit()
            Next D
        Catch ex1 As Exception
            XtraMessageBox.Show(ex1.Message.ToString)
        End Try
        Me.btn_Converting.Enabled = True
        Me.btn_CreateTXT.Enabled = True
    End Sub


    Private Sub txt_PathFolder_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_PathFolder.TextChanged
        If sender.Text = "" Then
            Me.btn_Converting.Enabled = False
        Else
            Me.btn_Converting.Enabled = True
        End If
    End Sub

    Private Sub btn_CreateTXT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_CreateTXT.Click
        Dim SFD As New SaveFileDialog
        SFD.Filter = "Текстовые файлы(*.txt)|*.txt|Все файлы(*.*)|*.*"
        SFD.FileName = "ПлатежиМРО_"
        If SFD.ShowDialog = DialogResult.OK Then
            Dim f As New StreamWriter(SFD.FileName, False, System.Text.Encoding.GetEncoding(1251))
            ' Открываем файл "D:Test1.txt", Если поставить не False а True, то запись будет в конец файла. 
            'Т.е. если в файле уже есть текст, то этот текст стераться не будет, а новый будет добавляться в конец. 
            'Если файла не существует, то он создаваться не будет. А если же поставить False, то если в файле был текст, 
            'то он стерается, и запись идет в пустой файл. Если файла не существует, то он создается. Дальше идет тип кодировки, 
            'в нашем случае это стандартная 1251
            For i = 0 To Me.lb_Loger.Items.Count - 1
                f.Write(Me.lb_Loger.Items(i).ToString & vbNewLine)
            Next i
            f.Close() ' Закрываем файл
        End If
    End Sub

    Private Sub frConverterDBFtoTXT_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        exl.Quit()
        exl = Nothing
        LiberationMemory
    End Sub

    Private Sub chb_AllDirectories_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chb_AllDirectories.CheckedChanged
        If chb_AllDirectories.Checked Then
            AllDirectories = 1
        Else
            AllDirectories = 0
        End If
    End Sub
End Class