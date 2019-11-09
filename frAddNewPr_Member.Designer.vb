<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frAddNewPr_Member
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frAddNewPr_Member))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GrBox_CurrentMember = New System.Windows.Forms.GroupBox()
        Me.btn_CalDtUnResidence = New System.Windows.Forms.DateTimePicker()
        Me.btn_CalDtResidence = New System.Windows.Forms.DateTimePicker()
        Me.btn_UpdateMember = New System.Windows.Forms.Button()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.сmb_FamilyRole = New System.Windows.Forms.ComboBox()
        Me.txt_NoteMember = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.txt_AddressOfLive = New System.Windows.Forms.TextBox()
        Me.txt_Residence = New System.Windows.Forms.TextBox()
        Me.ckb_ShareOwner = New System.Windows.Forms.CheckBox()
        Me.Lab_CriterialSearch = New System.Windows.Forms.Label()
        Me.txt_Patronymic = New System.Windows.Forms.TextBox()
        Me.txt_Name = New System.Windows.Forms.TextBox()
        Me.txt_Surname = New System.Windows.Forms.TextBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.txt_MemEmail = New System.Windows.Forms.MaskedTextBox()
        Me.txt_MemPhoneMobile = New System.Windows.Forms.MaskedTextBox()
        Me.txt_PlaceOfWork = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btn_CalPDDateOfIssue = New System.Windows.Forms.DateTimePicker()
        Me.btn_CalPDDateOfBirth = New System.Windows.Forms.DateTimePicker()
        Me.txt_PDDateOfIssue = New System.Windows.Forms.MaskedTextBox()
        Me.txt_PDDateOfBirth = New System.Windows.Forms.MaskedTextBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.btn_ClearPD = New System.Windows.Forms.Button()
        Me.txt_PDSubunitCode = New System.Windows.Forms.MaskedTextBox()
        Me.txt_PDSubunit = New System.Windows.Forms.TextBox()
        Me.txt_PDNumber = New System.Windows.Forms.MaskedTextBox()
        Me.txt_PDSeries = New System.Windows.Forms.MaskedTextBox()
        Me.txt_PDString = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.cmb_SexMember = New System.Windows.Forms.ComboBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.txt_DtResidence = New System.Windows.Forms.MaskedTextBox()
        Me.txt_DtUnResidence = New System.Windows.Forms.MaskedTextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GrBox_CurrentMember.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.GrBox_CurrentMember)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(781, 368)
        Me.Panel1.TabIndex = 0
        '
        'GrBox_CurrentMember
        '
        Me.GrBox_CurrentMember.Controls.Add(Me.btn_CalDtUnResidence)
        Me.GrBox_CurrentMember.Controls.Add(Me.btn_CalDtResidence)
        Me.GrBox_CurrentMember.Controls.Add(Me.btn_UpdateMember)
        Me.GrBox_CurrentMember.Controls.Add(Me.Label48)
        Me.GrBox_CurrentMember.Controls.Add(Me.сmb_FamilyRole)
        Me.GrBox_CurrentMember.Controls.Add(Me.txt_NoteMember)
        Me.GrBox_CurrentMember.Controls.Add(Me.Label41)
        Me.GrBox_CurrentMember.Controls.Add(Me.txt_AddressOfLive)
        Me.GrBox_CurrentMember.Controls.Add(Me.txt_Residence)
        Me.GrBox_CurrentMember.Controls.Add(Me.ckb_ShareOwner)
        Me.GrBox_CurrentMember.Controls.Add(Me.Lab_CriterialSearch)
        Me.GrBox_CurrentMember.Controls.Add(Me.txt_Patronymic)
        Me.GrBox_CurrentMember.Controls.Add(Me.txt_Name)
        Me.GrBox_CurrentMember.Controls.Add(Me.txt_Surname)
        Me.GrBox_CurrentMember.Controls.Add(Me.GroupBox7)
        Me.GrBox_CurrentMember.Controls.Add(Me.GroupBox5)
        Me.GrBox_CurrentMember.Controls.Add(Me.cmb_SexMember)
        Me.GrBox_CurrentMember.Controls.Add(Me.Label43)
        Me.GrBox_CurrentMember.Controls.Add(Me.Label45)
        Me.GrBox_CurrentMember.Controls.Add(Me.Label44)
        Me.GrBox_CurrentMember.Controls.Add(Me.Label46)
        Me.GrBox_CurrentMember.Controls.Add(Me.Label47)
        Me.GrBox_CurrentMember.Controls.Add(Me.txt_DtResidence)
        Me.GrBox_CurrentMember.Controls.Add(Me.txt_DtUnResidence)
        Me.GrBox_CurrentMember.Controls.Add(Me.Label40)
        Me.GrBox_CurrentMember.Controls.Add(Me.Label39)
        Me.GrBox_CurrentMember.Controls.Add(Me.Label50)
        Me.GrBox_CurrentMember.Controls.Add(Me.Label49)
        Me.GrBox_CurrentMember.Controls.Add(Me.Label42)
        Me.GrBox_CurrentMember.Location = New System.Drawing.Point(1, 2)
        Me.GrBox_CurrentMember.Name = "GrBox_CurrentMember"
        Me.GrBox_CurrentMember.Size = New System.Drawing.Size(772, 358)
        Me.GrBox_CurrentMember.TabIndex = 5
        Me.GrBox_CurrentMember.TabStop = False
        Me.GrBox_CurrentMember.Text = "Данные нового члена семьи"
        '
        'btn_CalDtUnResidence
        '
        Me.btn_CalDtUnResidence.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.btn_CalDtUnResidence.Location = New System.Drawing.Point(382, 46)
        Me.btn_CalDtUnResidence.Name = "btn_CalDtUnResidence"
        Me.btn_CalDtUnResidence.Size = New System.Drawing.Size(20, 20)
        Me.btn_CalDtUnResidence.TabIndex = 51
        '
        'btn_CalDtResidence
        '
        Me.btn_CalDtResidence.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.btn_CalDtResidence.Location = New System.Drawing.Point(382, 26)
        Me.btn_CalDtResidence.Name = "btn_CalDtResidence"
        Me.btn_CalDtResidence.Size = New System.Drawing.Size(20, 20)
        Me.btn_CalDtResidence.TabIndex = 50
        '
        'btn_UpdateMember
        '
        Me.btn_UpdateMember.BackgroundImage = Global.Pripyat.My.Resources.Resources.AddAbonent_60x60
        Me.btn_UpdateMember.FlatAppearance.BorderSize = 0
        Me.btn_UpdateMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_UpdateMember.Location = New System.Drawing.Point(706, 279)
        Me.btn_UpdateMember.Name = "btn_UpdateMember"
        Me.btn_UpdateMember.Size = New System.Drawing.Size(60, 60)
        Me.btn_UpdateMember.TabIndex = 35
        Me.btn_UpdateMember.UseVisualStyleBackColor = True
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label48.Location = New System.Drawing.Point(232, 125)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(82, 13)
        Me.Label48.TabIndex = 32
        Me.Label48.Text = "Семейная роль"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'сmb_FamilyRole
        '
        Me.сmb_FamilyRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.сmb_FamilyRole.FormattingEnabled = True
        Me.сmb_FamilyRole.Location = New System.Drawing.Point(231, 141)
        Me.сmb_FamilyRole.Name = "сmb_FamilyRole"
        Me.сmb_FamilyRole.Size = New System.Drawing.Size(171, 21)
        Me.сmb_FamilyRole.TabIndex = 31
        '
        'txt_NoteMember
        '
        Me.txt_NoteMember.Location = New System.Drawing.Point(6, 272)
        Me.txt_NoteMember.MaxLength = 300
        Me.txt_NoteMember.Multiline = True
        Me.txt_NoteMember.Name = "txt_NoteMember"
        Me.txt_NoteMember.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_NoteMember.Size = New System.Drawing.Size(694, 67)
        Me.txt_NoteMember.TabIndex = 14
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label41.Location = New System.Drawing.Point(6, 152)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(100, 13)
        Me.Label41.TabIndex = 24
        Me.Label41.Text = "Адрес проживания"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_AddressOfLive
        '
        Me.txt_AddressOfLive.Location = New System.Drawing.Point(6, 168)
        Me.txt_AddressOfLive.MaxLength = 200
        Me.txt_AddressOfLive.Name = "txt_AddressOfLive"
        Me.txt_AddressOfLive.Size = New System.Drawing.Size(396, 20)
        Me.txt_AddressOfLive.TabIndex = 12
        '
        'txt_Residence
        '
        Me.txt_Residence.Location = New System.Drawing.Point(6, 105)
        Me.txt_Residence.MaxLength = 100
        Me.txt_Residence.Name = "txt_Residence"
        Me.txt_Residence.ReadOnly = True
        Me.txt_Residence.Size = New System.Drawing.Size(396, 20)
        Me.txt_Residence.TabIndex = 8
        '
        'ckb_ShareOwner
        '
        Me.ckb_ShareOwner.Location = New System.Drawing.Point(6, 129)
        Me.ckb_ShareOwner.Name = "ckb_ShareOwner"
        Me.ckb_ShareOwner.Size = New System.Drawing.Size(220, 23)
        Me.ckb_ShareOwner.TabIndex = 7
        Me.ckb_ShareOwner.Text = "Является дольщиком"
        Me.ckb_ShareOwner.UseVisualStyleBackColor = True
        '
        'Lab_CriterialSearch
        '
        Me.Lab_CriterialSearch.AutoSize = True
        Me.Lab_CriterialSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Lab_CriterialSearch.Location = New System.Drawing.Point(300, 88)
        Me.Lab_CriterialSearch.Name = "Lab_CriterialSearch"
        Me.Lab_CriterialSearch.Size = New System.Drawing.Size(102, 13)
        Me.Lab_CriterialSearch.TabIndex = 21
        Me.Lab_CriterialSearch.Text = "Адрес регистрации"
        Me.Lab_CriterialSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_Patronymic
        '
        Me.txt_Patronymic.Location = New System.Drawing.Point(66, 66)
        Me.txt_Patronymic.MaxLength = 50
        Me.txt_Patronymic.Name = "txt_Patronymic"
        Me.txt_Patronymic.Size = New System.Drawing.Size(157, 20)
        Me.txt_Patronymic.TabIndex = 25
        '
        'txt_Name
        '
        Me.txt_Name.Location = New System.Drawing.Point(66, 46)
        Me.txt_Name.MaxLength = 50
        Me.txt_Name.Name = "txt_Name"
        Me.txt_Name.Size = New System.Drawing.Size(157, 20)
        Me.txt_Name.TabIndex = 24
        '
        'txt_Surname
        '
        Me.txt_Surname.Location = New System.Drawing.Point(66, 26)
        Me.txt_Surname.MaxLength = 50
        Me.txt_Surname.Name = "txt_Surname"
        Me.txt_Surname.Size = New System.Drawing.Size(157, 20)
        Me.txt_Surname.TabIndex = 23
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.txt_MemEmail)
        Me.GroupBox7.Controls.Add(Me.txt_MemPhoneMobile)
        Me.GroupBox7.Controls.Add(Me.txt_PlaceOfWork)
        Me.GroupBox7.Location = New System.Drawing.Point(6, 193)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(396, 73)
        Me.GroupBox7.TabIndex = 20
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Контактные данные (место работы, телефон, email и пр.)"
        '
        'txt_MemEmail
        '
        Me.txt_MemEmail.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.txt_MemEmail.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.txt_MemEmail.Location = New System.Drawing.Point(116, 42)
        Me.txt_MemEmail.Mask = "____________@_____.____"
        Me.txt_MemEmail.Name = "txt_MemEmail"
        Me.txt_MemEmail.Size = New System.Drawing.Size(272, 20)
        Me.txt_MemEmail.TabIndex = 111
        Me.txt_MemEmail.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'txt_MemPhoneMobile
        '
        Me.txt_MemPhoneMobile.Location = New System.Drawing.Point(6, 42)
        Me.txt_MemPhoneMobile.Mask = "+7 (999) 000-00-00"
        Me.txt_MemPhoneMobile.Name = "txt_MemPhoneMobile"
        Me.txt_MemPhoneMobile.Size = New System.Drawing.Size(104, 20)
        Me.txt_MemPhoneMobile.TabIndex = 48
        Me.txt_MemPhoneMobile.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'txt_PlaceOfWork
        '
        Me.txt_PlaceOfWork.Location = New System.Drawing.Point(6, 18)
        Me.txt_PlaceOfWork.MaxLength = 60
        Me.txt_PlaceOfWork.Name = "txt_PlaceOfWork"
        Me.txt_PlaceOfWork.Size = New System.Drawing.Size(382, 20)
        Me.txt_PlaceOfWork.TabIndex = 13
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.btn_CalPDDateOfIssue)
        Me.GroupBox5.Controls.Add(Me.btn_CalPDDateOfBirth)
        Me.GroupBox5.Controls.Add(Me.txt_PDDateOfIssue)
        Me.GroupBox5.Controls.Add(Me.txt_PDDateOfBirth)
        Me.GroupBox5.Controls.Add(Me.PictureBox5)
        Me.GroupBox5.Controls.Add(Me.btn_ClearPD)
        Me.GroupBox5.Controls.Add(Me.txt_PDSubunitCode)
        Me.GroupBox5.Controls.Add(Me.txt_PDSubunit)
        Me.GroupBox5.Controls.Add(Me.txt_PDNumber)
        Me.GroupBox5.Controls.Add(Me.txt_PDSeries)
        Me.GroupBox5.Controls.Add(Me.txt_PDString)
        Me.GroupBox5.Controls.Add(Me.Label37)
        Me.GroupBox5.Controls.Add(Me.Label36)
        Me.GroupBox5.Controls.Add(Me.Label38)
        Me.GroupBox5.Controls.Add(Me.Label35)
        Me.GroupBox5.Controls.Add(Me.Label34)
        Me.GroupBox5.Controls.Add(Me.Label33)
        Me.GroupBox5.Location = New System.Drawing.Point(408, 14)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(358, 252)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Паспортные данные"
        '
        'btn_CalPDDateOfIssue
        '
        Me.btn_CalPDDateOfIssue.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.btn_CalPDDateOfIssue.Location = New System.Drawing.Point(234, 90)
        Me.btn_CalPDDateOfIssue.Name = "btn_CalPDDateOfIssue"
        Me.btn_CalPDDateOfIssue.Size = New System.Drawing.Size(20, 20)
        Me.btn_CalPDDateOfIssue.TabIndex = 53
        '
        'btn_CalPDDateOfBirth
        '
        Me.btn_CalPDDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.btn_CalPDDateOfBirth.Location = New System.Drawing.Point(234, 11)
        Me.btn_CalPDDateOfBirth.Name = "btn_CalPDDateOfBirth"
        Me.btn_CalPDDateOfBirth.Size = New System.Drawing.Size(20, 20)
        Me.btn_CalPDDateOfBirth.TabIndex = 52
        '
        'txt_PDDateOfIssue
        '
        Me.txt_PDDateOfIssue.Location = New System.Drawing.Point(143, 90)
        Me.txt_PDDateOfIssue.Mask = "00/00/0000"
        Me.txt_PDDateOfIssue.Name = "txt_PDDateOfIssue"
        Me.txt_PDDateOfIssue.RejectInputOnFirstFailure = True
        Me.txt_PDDateOfIssue.ResetOnSpace = False
        Me.txt_PDDateOfIssue.Size = New System.Drawing.Size(111, 20)
        Me.txt_PDDateOfIssue.TabIndex = 48
        Me.txt_PDDateOfIssue.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.txt_PDDateOfIssue.ValidatingType = GetType(Date)
        '
        'txt_PDDateOfBirth
        '
        Me.txt_PDDateOfBirth.Location = New System.Drawing.Point(143, 11)
        Me.txt_PDDateOfBirth.Mask = "00/00/0000"
        Me.txt_PDDateOfBirth.Name = "txt_PDDateOfBirth"
        Me.txt_PDDateOfBirth.RejectInputOnFirstFailure = True
        Me.txt_PDDateOfBirth.ResetOnSpace = False
        Me.txt_PDDateOfBirth.Size = New System.Drawing.Size(111, 20)
        Me.txt_PDDateOfBirth.TabIndex = 47
        Me.txt_PDDateOfBirth.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.txt_PDDateOfBirth.ValidatingType = GetType(Date)
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(260, 12)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(92, 98)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 14
        Me.PictureBox5.TabStop = False
        '
        'btn_ClearPD
        '
        Me.btn_ClearPD.BackgroundImage = CType(resources.GetObject("btn_ClearPD.BackgroundImage"), System.Drawing.Image)
        Me.btn_ClearPD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_ClearPD.Location = New System.Drawing.Point(332, 167)
        Me.btn_ClearPD.Name = "btn_ClearPD"
        Me.btn_ClearPD.Size = New System.Drawing.Size(20, 20)
        Me.btn_ClearPD.TabIndex = 13
        Me.btn_ClearPD.UseVisualStyleBackColor = True
        '
        'txt_PDSubunitCode
        '
        Me.txt_PDSubunitCode.Location = New System.Drawing.Point(143, 161)
        Me.txt_PDSubunitCode.Mask = "000-000"
        Me.txt_PDSubunitCode.Name = "txt_PDSubunitCode"
        Me.txt_PDSubunitCode.Size = New System.Drawing.Size(55, 20)
        Me.txt_PDSubunitCode.TabIndex = 6
        Me.txt_PDSubunitCode.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        '
        'txt_PDSubunit
        '
        Me.txt_PDSubunit.Location = New System.Drawing.Point(78, 116)
        Me.txt_PDSubunit.MaxLength = 200
        Me.txt_PDSubunit.Multiline = True
        Me.txt_PDSubunit.Name = "txt_PDSubunit"
        Me.txt_PDSubunit.Size = New System.Drawing.Size(274, 34)
        Me.txt_PDSubunit.TabIndex = 5
        '
        'txt_PDNumber
        '
        Me.txt_PDNumber.Location = New System.Drawing.Point(143, 64)
        Me.txt_PDNumber.Mask = "000000"
        Me.txt_PDNumber.Name = "txt_PDNumber"
        Me.txt_PDNumber.Size = New System.Drawing.Size(55, 20)
        Me.txt_PDNumber.TabIndex = 3
        Me.txt_PDNumber.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        '
        'txt_PDSeries
        '
        Me.txt_PDSeries.Location = New System.Drawing.Point(143, 38)
        Me.txt_PDSeries.Mask = "0000"
        Me.txt_PDSeries.Name = "txt_PDSeries"
        Me.txt_PDSeries.Size = New System.Drawing.Size(55, 20)
        Me.txt_PDSeries.TabIndex = 2
        Me.txt_PDSeries.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        '
        'txt_PDString
        '
        Me.txt_PDString.Location = New System.Drawing.Point(6, 187)
        Me.txt_PDString.MaxLength = 300
        Me.txt_PDString.Multiline = True
        Me.txt_PDString.Name = "txt_PDString"
        Me.txt_PDString.ReadOnly = True
        Me.txt_PDString.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_PDString.Size = New System.Drawing.Size(346, 56)
        Me.txt_PDString.TabIndex = 0
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label37.Location = New System.Drawing.Point(6, 135)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(135, 13)
        Me.Label37.TabIndex = 11
        Me.Label37.Text = "Кем выдан                        "
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label36.Location = New System.Drawing.Point(6, 94)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(145, 13)
        Me.Label36.TabIndex = 10
        Me.Label36.Text = "Дата выдачи                        "
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label38.Location = New System.Drawing.Point(6, 164)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(146, 13)
        Me.Label38.TabIndex = 12
        Me.Label38.Text = "Код подразделения             "
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label35.Location = New System.Drawing.Point(6, 67)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(146, 13)
        Me.Label35.TabIndex = 9
        Me.Label35.Text = "Номер                                   "
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label34.Location = New System.Drawing.Point(6, 41)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(143, 13)
        Me.Label34.TabIndex = 8
        Me.Label34.Text = "Серия                                   "
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label33.Location = New System.Drawing.Point(6, 16)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(143, 13)
        Me.Label33.TabIndex = 7
        Me.Label33.Text = "Дата рождения                   "
        '
        'cmb_SexMember
        '
        Me.cmb_SexMember.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_SexMember.FormattingEnabled = True
        Me.cmb_SexMember.Items.AddRange(New Object() {"Мужской", "Женский"})
        Me.cmb_SexMember.Location = New System.Drawing.Point(291, 66)
        Me.cmb_SexMember.Name = "cmb_SexMember"
        Me.cmb_SexMember.Size = New System.Drawing.Size(111, 21)
        Me.cmb_SexMember.TabIndex = 10
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label43.Location = New System.Drawing.Point(9, 30)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(74, 13)
        Me.Label43.TabIndex = 26
        Me.Label43.Text = "Фамилия      "
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label45.Location = New System.Drawing.Point(9, 69)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(87, 13)
        Me.Label45.TabIndex = 28
        Me.Label45.Text = "Отчество           "
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label44.Location = New System.Drawing.Point(9, 49)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(68, 13)
        Me.Label44.TabIndex = 27
        Me.Label44.Text = "Имя             "
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label46.Location = New System.Drawing.Point(232, 70)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(66, 13)
        Me.Label46.TabIndex = 29
        Me.Label46.Text = "Пол             "
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label47.Location = New System.Drawing.Point(4, 341)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(68, 13)
        Me.Label47.TabIndex = 30
        Me.Label47.Text = "Примечание"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_DtResidence
        '
        Me.txt_DtResidence.Location = New System.Drawing.Point(291, 26)
        Me.txt_DtResidence.Mask = "00/00/0000"
        Me.txt_DtResidence.Name = "txt_DtResidence"
        Me.txt_DtResidence.RejectInputOnFirstFailure = True
        Me.txt_DtResidence.ResetOnSpace = False
        Me.txt_DtResidence.Size = New System.Drawing.Size(111, 20)
        Me.txt_DtResidence.TabIndex = 45
        Me.txt_DtResidence.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.txt_DtResidence.ValidatingType = GetType(Date)
        '
        'txt_DtUnResidence
        '
        Me.txt_DtUnResidence.Location = New System.Drawing.Point(291, 46)
        Me.txt_DtUnResidence.Mask = "00/00/0000"
        Me.txt_DtUnResidence.Name = "txt_DtUnResidence"
        Me.txt_DtUnResidence.RejectInputOnFirstFailure = True
        Me.txt_DtUnResidence.ResetOnSpace = False
        Me.txt_DtUnResidence.Size = New System.Drawing.Size(111, 20)
        Me.txt_DtUnResidence.TabIndex = 46
        Me.txt_DtUnResidence.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.txt_DtUnResidence.ValidatingType = GetType(Date)
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label40.Location = New System.Drawing.Point(232, 49)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(64, 13)
        Me.Label40.TabIndex = 23
        Me.Label40.Text = "Выписан    "
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label39.Location = New System.Drawing.Point(232, 31)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(69, 13)
        Me.Label39.TabIndex = 22
        Me.Label39.Text = "Прописан    "
        '
        'Label50
        '
        Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label50.ForeColor = System.Drawing.Color.Red
        Me.Label50.Location = New System.Drawing.Point(5, 45)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(10, 10)
        Me.Label50.TabIndex = 49
        Me.Label50.Text = "*"
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label49
        '
        Me.Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label49.ForeColor = System.Drawing.Color.Red
        Me.Label49.Location = New System.Drawing.Point(5, 27)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(10, 10)
        Me.Label49.TabIndex = 48
        Me.Label49.Text = "*"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label42
        '
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.Red
        Me.Label42.Location = New System.Drawing.Point(4, 65)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(10, 10)
        Me.Label42.TabIndex = 47
        Me.Label42.Text = "*"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frAddNewPr_Member
        '
        Me.AcceptButton = Me.btn_UpdateMember
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(781, 368)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frAddNewPr_Member"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Добавление нового члена семьи"
        Me.Panel1.ResumeLayout(False)
        Me.GrBox_CurrentMember.ResumeLayout(False)
        Me.GrBox_CurrentMember.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GrBox_CurrentMember As System.Windows.Forms.GroupBox
    Friend WithEvents btn_UpdateMember As System.Windows.Forms.Button
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents сmb_FamilyRole As System.Windows.Forms.ComboBox
    Friend WithEvents txt_NoteMember As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents txt_AddressOfLive As System.Windows.Forms.TextBox
    Friend WithEvents txt_Residence As System.Windows.Forms.TextBox
    Friend WithEvents ckb_ShareOwner As System.Windows.Forms.CheckBox
    Friend WithEvents Lab_CriterialSearch As System.Windows.Forms.Label
    Friend WithEvents txt_Patronymic As System.Windows.Forms.TextBox
    Friend WithEvents txt_Name As System.Windows.Forms.TextBox
    Friend WithEvents txt_Surname As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_PlaceOfWork As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents btn_ClearPD As System.Windows.Forms.Button
    Friend WithEvents txt_PDSubunitCode As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_PDSubunit As System.Windows.Forms.TextBox
    Friend WithEvents txt_PDNumber As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_PDSeries As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_PDString As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents cmb_SexMember As System.Windows.Forms.ComboBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents txt_PDDateOfIssue As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_PDDateOfBirth As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_DtResidence As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_DtUnResidence As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents btn_CalDtUnResidence As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_CalDtResidence As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_CalPDDateOfIssue As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_CalPDDateOfBirth As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_MemPhoneMobile As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_MemEmail As System.Windows.Forms.MaskedTextBox
End Class
