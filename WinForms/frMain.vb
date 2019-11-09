Imports System.Windows.Forms
Imports System.Data.OleDb
Imports System.IO
Imports System.Threading
Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraEditors

Public Class frMain
    Dim UpgradeStarterPath As String            ' Путь откуда копируются обновления
    Dim LastUpgrade As String                   ' Дата и время последнего обновления Стартера (берется из БД настроек)
    Dim UpgradeEvent As Boolean = True          ' Состоялось или нет обновление стартера 
    Dim UpdatePath As String

    Sub New()
        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()
        ' Добавьте все инициализирующие действия после вызова InitializeComponent().
        ' Событие при изменении темы оформления
        Me.ForeColor = Me.BackColor
        AddHandler DevExpress.LookAndFeel.UserLookAndFeel.Default.StyleChanged, AddressOf Default_StyleChanged
        Clock.ClockStyleData.FaceBackgroundImage = My.Resources.hdr
        Me.NotifyIcon.Text = Application.ProductName & Chr(10) & _
                            "[" & pref_DataBaseName & " - " & pref_PerformerLogin & "]"
        If pref_DataBaseName = "PripyatDebuger" Then
            Me.PictureBox1.Visible = False
        End If
        ' Устанавливаем родительский фон контролам, для прозрачности
        Me.PictureBox2.Parent = Me.PictureBox1
        Me.PictureBox3.Parent = Me.PictureBox1
        Me.PictureBox4.Parent = Me.PictureBox1
        Me.PictureBox5.Parent = Me.PictureBox1
        Me.PictureBox6.Parent = Me.PictureBox1
        Me.Clock.Parent = Me.PictureBox1

        ' праздники   день пеобеды
        If Now.Month = 5 Then Me.PictureBox3.Visible = True
        ' день народного единства
        If Now.Month = 11 Then
            If Now.Day >= 1 And Now.Day <= 18 Then
                Me.PictureBox4.Visible = True
            End If
        End If
        ' новый год
        If Now.Month = 12 Then
            If Now.Day >= 15 Then
                Me.PictureBox5.Visible = True
            End If
        ElseIf Now.Month = 1 Then
            If Now.Day <= 25 Then
                Me.PictureBox5.Visible = True
            End If
        End If
        ' 23 февраля
        If Now.Month = 2 Then
            If Now.Day >= 10 And Now.Day <= 27 Then
                Me.PictureBox6.Visible = True
            End If
        End If
        Me.lb_MessageForUser.Parent = Me.PictureBox1
    End Sub
    Private Sub frMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Dim Th As New Thread(AddressOf UpgradeStarter)    ' Создание дилигата процесса обновления старта
        Me.Time.Enabled = True                              ' Включаем таймер чтоб тикало время
        ' Th.Start()                                        ' Запуск обновления Стартера в фоновом режиме
    End Sub

    Sub UpgradeStarter()
        ' Чтоб отладка не возвращала ошибку из разных потоков
        Control.CheckForIllegalCrossThreadCalls = False
        UpgradeStarterPath = RegistryRead(pref_RegistryPath & "Update\Starter", "UpdatePath")       ' Чтение из настроек пути обновления Стартера
        LastUpgrade = RegistryRead(pref_RegistryPath & "Update\Starter", "LastUpdate")              ' Чтение из файла дата и времени последнего обновления Стартера
        ' Проверка пути обновления из реестра
        If Directory.Exists(UpgradeStarterPath.ToString).ToString() Then
            ' Запуск копирования обновления
            Dim _UpgradeStarterPath As New DirectoryInfo(UpgradeStarterPath)
            Dim _StartupPath As New DirectoryInfo(Application.StartupPath)
            ' Проверка совпадения даты последнего обновления и его публикации
            If _UpgradeStarterPath.LastWriteTime.ToString = LastUpgrade Then
                ' Если даты совпали то, обновление для Стартера выкладывалось
                RegistryWrite(pref_RegistryPath & "Update\Starter", "UpdateValidate", 1)
            Else ' Если даты не совпали значит опубликовано обновление
                ' Копируем все файлы в каталоге
                For Each fi As FileInfo In _UpgradeStarterPath.GetFiles()
                    fi.CopyTo(Path.Combine(_StartupPath.ToString(), fi.Name), True)
                Next
                ' Копируем все папки в каталоге
                For Each diSourceSubDir As DirectoryInfo In _UpgradeStarterPath.GetDirectories()
                    Dim nextTargetSubDir As DirectoryInfo = _StartupPath.CreateSubdirectory(diSourceSubDir.Name)
                Next
                ' После удачного обновления записываем в реестр отметку об обновлении и даты последнего обновления каталога Upgrade
                RegistryWrite(pref_RegistryPath & "Update\Starter", "UpdateValidate", 1)
                RegistryWrite(pref_RegistryPath & "Update\Starter", "LastUpdate", _UpgradeStarterPath.LastWriteTime)
            End If
        Else
            ' Сообщаем об ошибке
            RegistryWrite(pref_RegistryPath & "Update\Starter", "UpdateValidate", 0)
            UpgradeEvent = False
            lb_MessageForUser.Text = "Во время обновления Стартера программы произошла ошибка конфигурации!" & Chr(10) & _
                                     "Сообщите системному администратору!"
        End If
    End Sub

    'Private Sub Time_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Time.Tick
    ' Текущее системное время и дата
    'Me.Clock.Value = Now.ToLocalTime
    ' Если Стартер не обновился, показываем мерцающее сообщение
    'If UpgradeEvent = False Then
    'If Me.lb_MessageForUser.Visible = True Then
    'Me.lb_MessageForUser.Visible = False
    'Else
    'Me.lb_MessageForUser.Visible = True
    'End If
    'End If
    ' End Sub

    Private Sub frMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Application.Exit()
    End Sub

    ' Выход  из программы
    Private Sub btExit_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.ItemClick
        If XtraMessageBox.Show(
                               "Подтвердите выход из программы!", _
                               Application.ProductName, _
                               MessageBoxButtons.OKCancel, _
                               MessageBoxIcon.Question
                               ) = DialogResult.OK Then
            Application.Exit()
        End If
    End Sub

    ' Сворачивание программы в трей
    Private Sub btPoints_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPoints.ItemClick, btPoints_link.ItemClick
        Me.Time.Enabled = False
        frAbonents.Show()
        NotifyIcon.Visible = True
        Me.Hide()
    End Sub

    ' Вызов формы из трея
    Private Sub NotifyIcon_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon.MouseDoubleClick
        Me.Time.Enabled = True
        Me.Show()
        NotifyIcon.Visible = False
        frAbonents.Dispose()
    End Sub

    Private Sub btRefJudicialArea_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRefJudicialArea.ItemClick
        frBooksJudicialArea.ShowDialog() : frBooksJudicialArea.Dispose()
    End Sub

    Private Sub btRefCopPerformers_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRefCopPerformers.ItemClick
        frBookCopPerformers.ShowDialog() : frBookCopPerformers.Dispose()
    End Sub


    Private Sub btConverterDBF_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btConverterDBF.ItemClick
        frConverterDBFtoTXT.ShowDialog() : frConverterDBFtoTXT.Dispose()
    End Sub

    Private Sub btAskur_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAskur.ItemClick, btAskur_link.ItemClick
        Me.Hide()
        NotifyIcon.Visible = True
        Me.Time.Enabled = False
        frAskur.Show()
    End Sub

    Private Sub frMain_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ExecuteScalar("EXEC Pr_ValidationStatusMonth") = 1 Then frOpenMonth.ShowDialog()
    End Sub

    Private Sub MainTS_About_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' XtraForm1.ShowDialog()
    End Sub

    Private Sub btConnectionDB_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btConnectionDB.ItemClick
        frLoginForm.ShowDialog()
    End Sub
    ' Событие изменения темы оформления
    Private Sub Default_StyleChanged(ByVal sender As Object, ByVal e As EventArgs)
        RegistryWrite(pref_ComplexSettings, "SkinName", DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName)
    End Sub

    Private Sub btRecordEvents_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btRecordEvents.ItemClick, btRecordEvents_link.ItemClick
        Me.Hide()
        NotifyIcon.Visible = True
        Me.Time.Enabled = False
        frRecordEvents.Show()
    End Sub

    Private Sub btDocRegistration_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btDocRegistration.ItemClick, btDocRegistration_link.ItemClick
        frDocRegistration.ShowDialog()
    End Sub

    Private Sub btCloseConnection_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btCloseConnection.ItemClick
        If pref_PerformerLogin <> "prog" Then
            XtraMessageBox.Show(
                               "Только Администратор может запустить цикл закрытия соединений к БД " & pref_DataBaseName & "!", _
                               Application.ProductName, _
                               MessageBoxButtons.OK, _
                               MessageBoxIcon.Stop
                               )
            Exit Sub
        End If
        If tmCloseConnection.Enabled Then
            If XtraMessageBox.Show("Будет остановлен цикл закрытия соединений к БД " & pref_DataBaseName & Chr(10) & "Вы согласны?",
                                            Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then

                tmCloseConnection.Enabled = False
                Me.btCloseConnection.ImageIndex = 19
            End If
        Else
            If XtraMessageBox.Show("Будет запущен цикл закрытия соединений к БД " & pref_DataBaseName & Chr(10) & "Вы согласны?",
                                Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                tmCloseConnection.Enabled = True
                Me.btCloseConnection.ImageIndex = 20
            End If

        End If
    End Sub

    Private Sub tmCloseConnection_Tick(sender As System.Object, e As System.EventArgs) Handles tmCloseConnection.Tick
        Application.DoEvents()
        ExecuteQuery(
                    "SET NOCOUNT ON " & _
                    "DECLARE @dbname VARCHAR(100) " & _
                    "DECLARE @query VARCHAR(max) " & _
                    "SET @query = '' " & _
                    "SET @dbname = '" & pref_DataBaseName & "' " & _
                    "SELECT @query=coalesce(@query,',' ) + 'kill ' + CONVERT(VARCHAR, spid)+ '; ' " & _
                    "FROM sys.sysprocesses WHERE dbid = db_id(@dbname) /*AND loginame <> 'Kruzer' AND loginame <> 'Nurd'*/ AND loginame <> 'lobin' AND loginame <> 'prog' AND loginame <> 'sa' AND loginame <> '' " & _
                    "IF LEN(@query) > 0 " & _
                    "BEGIN " & _
                    "EXEC(@query) " & _
                    "END"
                    )
        Application.DoEvents()
    End Sub

    Private Sub btBindings_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btBindings.ItemClick, btBindings_link.ItemClick
        frBindings.Show()
    End Sub

    Private Sub btRefGKO_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btRefGKO.ItemClick
        frBookGKO.ShowDialog()
    End Sub

    Private Sub btFlatReference_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btFlatReference.ItemClick
        frBookFlat.ShowDialog()
    End Sub

    Private Sub btRefTSO_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btRefTSO.ItemClick
        frBookTSO.ShowDialog()
    End Sub

    Private Sub btnReports_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnReports_link.ItemClick
        frReport.ShowDialog()
    End Sub

    Private Sub btnSectionODN_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSectionODN.ItemClick, btnSectionODN_link.ItemClick
        Me.Time.Enabled = False
        frSectionODN.Show()
        Me.Time.Enabled = True
    End Sub

    Private Sub btnArchivist_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnArchivist.ItemClick, btnArchivist_link.ItemClick
        'XtraMessageBox.Show("Архив документов находится на стадии разработки!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Exit Sub
        frArchivist.ShowDialog()
    End Sub
End Class
