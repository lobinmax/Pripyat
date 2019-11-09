Public Class frMessager

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub frMesseger_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim wa As Rectangle = SystemInformation.WorkingArea                                         ' Разрешение экрана
        Dim LastUpdatePack As String = RegistryRead(pref_RegistryPath & "Update", "LastUpdatePack") ' Дата и время последней публикации
        Dim LastUpdatePack_Date As String = Mid(LastUpdatePack, 1, 10)                              ' Раскладываем на дату
        Dim LastUpdatePack_Time As String = Mid(LastUpdatePack, 12)                                 ' .... и время
        ' Показываем сообщение о дате и времени публикации
        Me.lb_TextMessege.Text = "Для ПК Припять опубликовано обновление!" & Chr(10) & _
                                 "Дата: " & LastUpdatePack_Date & "г." & Chr(10) & _
                                 "Время: " & LastUpdatePack_Time
        ' координаты формы в нижнем правом углу
        Me.Location = New Point(wa.Width - Me.Width, wa.Height - Me.Height)
        Me.Opacity = 0 ' форма полностью прозрачна
        For i = 0.01 To 0.9 Step 0.01
            ' холостой цикл для таймаута
            For r = 0 To 10000
                Application.DoEvents()
            Next r
            Me.Opacity = i ' Добавляем видимость форме
        Next i
    End Sub
End Class