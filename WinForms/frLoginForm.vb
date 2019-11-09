Imports System.Windows.Forms.BorderStyle
Imports System.Globalization
Imports DevExpress.LookAndFeel
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraSpellChecker
Imports System.Threading
Imports System.IO

Public Class frLoginForm
    Dim PreferenceForms As String                                           ' Ветка в реестре для хранения настроек формы 
    Dim iRecords() As String
    Dim iRecord As String
    Dim openOfficeDictionaryRU As New SpellCheckerOpenOfficeDictionary()    ' параметры для проверки орфографии
    Sub New()
        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()
        Try
            DevExpress.UserSkins.BonusSkins.Register()
            ' Добавьте все инициализирующие действия после вызова InitializeComponent().
            iLookAndFeel.EnableBonusSkins = True           ' Включаем бонусные скины
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = RegistryRead(pref_ComplexSettings, "SkinName", "Dark Side")
            ' Параметры отображения формы
            PreferenceForms = pref_RegistryPath & Me.Name & "\" ' Путь к настройкам в реестре
            ' Проверка лицензии программы
            'm:
            'If LicenseCheck() = False Then
            'If frLicense.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'GoTo m
            'Else
            'End
            'End If
            'End If

            ' настраиваем проверщика орфографии
            With spCheck
                .Dictionaries.Clear()
                .Dictionaries.Add(openOfficeDictionaryRU)
                .CheckAsYouTypeOptions.CheckControlsInParentContainer = True
                .SpellCheckMode = SpellCheckMode.AsYouType
            End With
            With openOfficeDictionaryRU
                .DictionaryPath = "Dictionaries\Dictionary.dic"
                .GrammarPath = "Dictionaries\Dictionary.aff"
                .Culture = New CultureInfo("ru-RU")
            End With

            If Convert.ToBoolean(Convert.ToInt32(RegistryRead(PreferenceForms, "IsShort", "0"))) Then
                Me.ClientSize = New Point(450, 152)
                Me.FormIsShort.Image = Pripyat.My.Resources.Resources.pull_down
                Me.Separator.Visible = False
            Else
                Me.ClientSize = New Point(450, 201)
                Me.FormIsShort.Image = Pripyat.My.Resources.Resources.pull_up
                Me.Separator.Visible = True
            End If
            ' Отображение пароля
            Me.ChB_ShowPass.Checked = Convert.ToBoolean(Convert.ToInt32(RegistryRead(PreferenceForms, "ShowPass", "0")))

            ' Заполнение основных полей
            iRecord = RegistryRead(PreferenceForms, "HistoryLogin", "")
            If iRecord <> "" Then
                iRecords = Nothing
                iRecords = iRecord.Split(",")
                Me.User.Properties.Items.AddRange(iRecords.Distinct.ToArray)
                Me.User.SelectedIndex = 0
            End If

            iRecord = RegistryRead(PreferenceForms, "HistoryServer", "")
            If iRecord <> "" Then
                iRecords = Nothing
                iRecords = iRecord.Split(",")
                Me.Server.Properties.Items.AddRange(iRecords.Distinct.ToArray)
                Me.Server.SelectedIndex = 0
            End If

            iRecord = RegistryRead(PreferenceForms, "HistoryBase", "")
            If iRecord <> "" Then
                iRecords = Nothing
                iRecords = iRecord.Split(",")
                Me.BD.Properties.Items.AddRange(iRecords.Distinct.ToArray)
                Me.BD.SelectedIndex = 0
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End Try
    End Sub
    Private Sub frLoginForm_Load(sender As Object, e As System.EventArgs) Handles MyBase.Paint
        Dim Th As New Thread(AddressOf UpgradeStarter)  ' Создание дилигата процесса обновления старта
        Th.Start()          ' Запуск "обновления" Стартера в фоновом режиме
        Me.Select()
        Me.Focus()
        Me.Pass.Select() : Me.Pass.Text = Nothing   ' Фокус на пароль
    End Sub

    ' если есть обновленный стартер, удаляем старый, переименовываем новый
    Private Sub UpgradeStarter()
        Try
            If File.Exists(Application.StartupPath & "\PripyatStarter_New.exe").ToString() Then
                My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\PripyatStarter.exe")
                My.Computer.FileSystem.RenameFile(Application.StartupPath & "\PripyatStarter_New.exe", "PripyatStarter.exe")
            End If
        Catch e As Exception
            XtraMessageBox.Show(e.Message)
        End Try
    End Sub
    Private Sub ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ok.Click
        Dim iRecord As String ' Переменная для записи истории подключений к базе
        ' Разделитель целой и дробной цасти
        DecSeporator = My.Computer.Info.InstalledUICulture.NumberFormat.NumberDecimalSeparator
        ' Меняем системный разделитель целой и дробной части
        Dim inf As New CultureInfo(System.Threading.Thread.CurrentThread.CurrentCulture.Name)
        System.Threading.Thread.CurrentThread.CurrentCulture = inf
        inf.NumberFormat.NumberDecimalSeparator = "."

        '=================================
        ' Если поля не заполнены выходим из процедуры
        If Me.Server.Text = "" Or
           Me.User.Text = "" Or
           Me.Pass.Text = "" Or
           Me.BD.Text = "" Then
            XtraMessageBox.Show("Для входы в клиентскую базу данных " & Me.BD.Text & " необходимо заполнить все поля!", _
                            "Заполнены не все поля...", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub ' Выход процедуры
        End If
        ' Попытка подключится к клиентской базе данных
        ' Запись переменных настроек
        pref_ServerIP = Me.Server.Text      ' IP сервера
        pref_DataBaseName = Me.BD.Text      ' Имя БД
        pref_PerformerLogin = Me.User.Text  ' Логин пользователя

        Try ' Вызов процедуры подключения к базе данных
            ConnectionToBase(Me.Server.Text,
                             Me.User.Text,
                             Me.Pass.Text,
                             Me.BD.Text)

            ' Запись истории логинов в реестр
            ' Пользователь
            iRecord = ""
            If Me.User.Properties.Items.Count = 0 Then
                iRecord = Me.User.Text
            Else
                For i = 0 To Me.User.Properties.Items.Count - 1
                    iRecord = iRecord & "," & Me.User.Properties.Items(i).ToString()
                Next
                iRecord = Me.User.Text & iRecord
            End If
            RegistryWrite(PreferenceForms, "HistoryLogin", iRecord)

            ' База данных 
            iRecord = ""
            If Me.BD.Properties.Items.Count = 0 Then
                iRecord = Me.BD.Text
            Else
                For i = 0 To Me.BD.Properties.Items.Count - 1
                    iRecord = iRecord & "," & Me.BD.Properties.Items(i).ToString()
                Next
                iRecord = Me.BD.Text & iRecord
            End If
            RegistryWrite(PreferenceForms, "HistoryBase", iRecord)

            ' Сервер
            iRecord = ""
            If Me.Server.Properties.Items.Count = 0 Then
                iRecord = Me.Server.Text
            Else
                For i = 0 To Me.Server.Properties.Items.Count - 1
                    iRecord = iRecord & "," & Me.Server.Properties.Items(i).ToString()
                Next
                iRecord = Me.Server.Text & iRecord
            End If
            RegistryWrite(PreferenceForms, "HistoryServer", iRecord)

            ' Ветка в реестре для персональных настроек пользователя
            pref_UserSettings = pref_RegistryPath & "UserSettings\" & pref_PerformerLogin & "\"
            frMain.Show()                           ' Запуск гравной формы программы
            frMain.Text = "(" & Me.User.Text & ") - " & "Комплексная работа по возврату дебиторской задолженности"
            ' Информация в СтатусБар из настроек
            frMain.lbDataBaseName.Caption = Me.BD.Text
            frMain.lbServerName.Caption = Me.Server.Text
            frMain.lbUserName.Caption = pref_PerformerName
            Me.Close()                              ' Закрытие формы входа

        Catch ex As Exception ' При неудачной попытки
            Me.Pass.Text = ""
            Me.Pass.Select()
            ' Сообщение при неудачном подключении к базе данных
            XtraMessageBox.Show(ex.Message & Chr(10) & "Обратитесь к СисАдмину...", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Application.Exit()
    End Sub

    Private Sub ChB_ShowPass_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChB_ShowPass.CheckedChanged
        ' Показывать или не показывать пароль
        If sender.Checked = True Then Me.Pass.Properties.PasswordChar = ""
        If sender.Checked = False Then Me.Pass.Properties.PasswordChar = Chr(7)
        RegistryWrite(PreferenceForms, "ShowPass", Convert.ToInt32(sender.Checked))
    End Sub

    Private Sub ClearHistory_User(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles User.ButtonClick
        Dim btn As EditorButton = e.Button
        If btn.Index = 1 Then
            If Me.User.Properties.Items.Count <> 0 Then
                If XtraMessageBox.Show("Вы действительно хотите очистить историю имен пользователей?", _
                                       Application.ProductName, _
                                       MessageBoxButtons.YesNo, _
                                       MessageBoxIcon.Question, _
                                       MessageBoxDefaultButton.Button2
                                       ) = Windows.Forms.DialogResult.Yes Then
                    RegistryWrite(PreferenceForms, "HistoryLogin", "")
                    sender.Properties.Items.Clear()
                    sender.Text = ""
                End If
            End If
        End If
    End Sub
    Private Sub ClearHistory_BD(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles BD.ButtonClick
        Dim btn As EditorButton = e.Button
        If btn.Index = 1 Then
            If sender.Properties.Items.Count <> 0 Then
                If XtraMessageBox.Show("Вы действительно хотите очистить историю баз данных?", _
                                       Application.ProductName, _
                                       MessageBoxButtons.YesNo, _
                                       MessageBoxIcon.Question, _
                                       MessageBoxDefaultButton.Button2
                                       ) = Windows.Forms.DialogResult.Yes Then
                    RegistryWrite(PreferenceForms, "HistoryBase", "")
                    sender.Properties.Items.Clear()
                    sender.Text = ""
                End If
            End If
        End If
    End Sub
    Private Sub ClearHistory_Server(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles Server.ButtonClick
        Dim btn As EditorButton = e.Button
        If btn.Index = 1 Then
            If sender.Properties.Items.Count <> 0 Then
                If XtraMessageBox.Show("Вы действительно хотите очистить историю имен срверов?", _
                                       Application.ProductName, _
                                       MessageBoxButtons.YesNo, _
                                       MessageBoxIcon.Question, _
                                       MessageBoxDefaultButton.Button2
                                       ) = Windows.Forms.DialogResult.Yes Then
                    RegistryWrite(PreferenceForms, "HistoryServer", "")
                    sender.Properties.Items.Clear()
                    sender.Text = ""
                End If
            End If
        End If
    End Sub
    Private Sub FormIsShort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormIsShort.Click
        If Convert.ToBoolean(Convert.ToInt32(RegistryRead(PreferenceForms, "IsShort", "0"))) Then
            RegistryWrite(PreferenceForms, "IsShort", "0")
            Me.ClientSize = New Point(450, 201)
            Me.FormIsShort.Image = Pripyat.My.Resources.Resources.pull_up
            Me.Separator.Visible = True
        Else
            RegistryWrite(PreferenceForms, "IsShort", "1")
            Me.ClientSize = New Point(450, 152)
            Me.FormIsShort.Image = Pripyat.My.Resources.Resources.pull_down
            Me.Separator.Visible = False
        End If
    End Sub
End Class
