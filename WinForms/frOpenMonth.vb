Imports System.Threading
Public Class frOpenMonth
    Dim LoadEnd As Boolean = False
    Sub MonthOpen()
        ExecuteQuery("EXEC Pr_MonthOpen", "MonthOpen")
        LoadEnd = True
    End Sub
    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If LoadEnd = False Then e.Cancel = True
    End Sub

    Private Sub frOpenMonth_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Dim Th As New Thread(AddressOf MonthOpen)  ' Создание дилигата процесса обновления старта
        Th.Start()
        Me.Cursor = Cursors.WaitCursor
        ' Пока процесс выполняется....
        Do Until LoadEnd
            ' Ждем и ничего не делаем
            My.Application.DoEvents()
        Loop
        Me.Close()
    End Sub
End Class