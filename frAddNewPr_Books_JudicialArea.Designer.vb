<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frAddNewPr_Books_JudicialArea
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frAddNewPr_Books_JudicialArea))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.cmb_CourtType = New System.Windows.Forms.ComboBox()
        Me.txt_Adress = New System.Windows.Forms.TextBox()
        Me.Btn_CheckAdress = New System.Windows.Forms.Button()
        Me.cmb_ZoneOfService = New System.Windows.Forms.ComboBox()
        Me.cmb_CurrentJudges = New System.Windows.Forms.ComboBox()
        Me.txt_Phone = New System.Windows.Forms.MaskedTextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtM_Number = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtM_House = New System.Windows.Forms.MaskedTextBox()
        Me.txt_JudicialAreaName = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.txtM_Postal = New System.Windows.Forms.MaskedTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtM_mail = New System.Windows.Forms.MaskedTextBox()
        Me.txt_Site = New System.Windows.Forms.TextBox()
        Me.txtM_PhoneMobile = New System.Windows.Forms.MaskedTextBox()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(423, 209)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.TabStop = False
        Me.Cancel_Button.Text = "Отмена"
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 13
        Me.OK_Button.Text = "ОК"
        '
        'cmb_CourtType
        '
        Me.cmb_CourtType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_CourtType.FormattingEnabled = True
        Me.cmb_CourtType.Location = New System.Drawing.Point(123, 12)
        Me.cmb_CourtType.Name = "cmb_CourtType"
        Me.cmb_CourtType.Size = New System.Drawing.Size(159, 21)
        Me.cmb_CourtType.TabIndex = 1
        '
        'txt_Adress
        '
        Me.txt_Adress.BackColor = System.Drawing.SystemColors.Window
        Me.txt_Adress.Location = New System.Drawing.Point(12, 63)
        Me.txt_Adress.Multiline = True
        Me.txt_Adress.Name = "txt_Adress"
        Me.txt_Adress.Size = New System.Drawing.Size(270, 44)
        Me.txt_Adress.TabIndex = 3
        Me.txt_Adress.TabStop = False
        '
        'Btn_CheckAdress
        '
        Me.Btn_CheckAdress.BackgroundImage = Global.Pripyat.My.Resources.Resources.Adress_48x48
        Me.Btn_CheckAdress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btn_CheckAdress.Location = New System.Drawing.Point(252, 108)
        Me.Btn_CheckAdress.Name = "Btn_CheckAdress"
        Me.Btn_CheckAdress.Size = New System.Drawing.Size(30, 30)
        Me.Btn_CheckAdress.TabIndex = 3
        Me.Btn_CheckAdress.UseVisualStyleBackColor = True
        '
        'cmb_ZoneOfService
        '
        Me.cmb_ZoneOfService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_ZoneOfService.FormattingEnabled = True
        Me.cmb_ZoneOfService.Location = New System.Drawing.Point(406, 12)
        Me.cmb_ZoneOfService.Name = "cmb_ZoneOfService"
        Me.cmb_ZoneOfService.Size = New System.Drawing.Size(162, 21)
        Me.cmb_ZoneOfService.TabIndex = 2
        '
        'cmb_CurrentJudges
        '
        Me.cmb_CurrentJudges.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_CurrentJudges.DropDownWidth = 270
        Me.cmb_CurrentJudges.FormattingEnabled = True
        Me.cmb_CurrentJudges.Location = New System.Drawing.Point(298, 117)
        Me.cmb_CurrentJudges.Name = "cmb_CurrentJudges"
        Me.cmb_CurrentJudges.Size = New System.Drawing.Size(270, 21)
        Me.cmb_CurrentJudges.Sorted = True
        Me.cmb_CurrentJudges.TabIndex = 7
        '
        'txt_Phone
        '
        Me.txt_Phone.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.txt_Phone.Location = New System.Drawing.Point(49, 166)
        Me.txt_Phone.Mask = "+7 (30000) 0-00-00"
        Me.txt_Phone.Name = "txt_Phone"
        Me.txt_Phone.Size = New System.Drawing.Size(110, 20)
        Me.txt_Phone.TabIndex = 8
        Me.txt_Phone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label27.Location = New System.Drawing.Point(9, 15)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(117, 13)
        Me.Label27.TabIndex = 22
        Me.Label27.Text = "Судебная инстанция  "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Полный адрес участка"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(295, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 13)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Зона обслуживания  "
        '
        'txtM_Number
        '
        Me.txtM_Number.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.txtM_Number.Location = New System.Drawing.Point(510, 166)
        Me.txtM_Number.Mask = "№ 999"
        Me.txtM_Number.Name = "txtM_Number"
        Me.txtM_Number.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtM_Number.Size = New System.Drawing.Size(58, 20)
        Me.txtM_Number.TabIndex = 12
        Me.txtM_Number.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(424, 169)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Номер участка  "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.Location = New System.Drawing.Point(295, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(180, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Исполняющий обязанности судьи"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label5.Location = New System.Drawing.Point(47, 152)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Телефон"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label6.Location = New System.Drawing.Point(47, 201)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Мобильный"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label7.Location = New System.Drawing.Point(199, 152)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 13)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Электронная почта"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label8.Location = New System.Drawing.Point(199, 200)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(119, 13)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "Страница в интернете"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Pripyat.My.Resources.Resources.mail_40x40
        Me.PictureBox1.Location = New System.Drawing.Point(166, 153)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(35, 35)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 32
        Me.PictureBox1.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label9.Location = New System.Drawing.Point(163, 121)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(36, 13)
        Me.Label9.TabIndex = 34
        Me.Label9.Text = "Дом  "
        '
        'txtM_House
        '
        Me.txtM_House.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.txtM_House.Location = New System.Drawing.Point(197, 118)
        Me.txtM_House.Mask = "д. AAAA"
        Me.txtM_House.Name = "txtM_House"
        Me.txtM_House.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtM_House.Size = New System.Drawing.Size(47, 20)
        Me.txtM_House.TabIndex = 5
        Me.txtM_House.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'txt_JudicialAreaName
        '
        Me.txt_JudicialAreaName.Location = New System.Drawing.Point(298, 63)
        Me.txt_JudicialAreaName.Name = "txt_JudicialAreaName"
        Me.txt_JudicialAreaName.Size = New System.Drawing.Size(270, 20)
        Me.txt_JudicialAreaName.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label10.Location = New System.Drawing.Point(295, 48)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(125, 13)
        Me.Label10.TabIndex = 37
        Me.Label10.Text = "Наименование участка"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(13, 200)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(35, 35)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 38
        Me.PictureBox3.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(13, 153)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(35, 35)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 39
        Me.PictureBox4.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Pripyat.My.Resources.Resources.e_48x48
        Me.PictureBox2.Location = New System.Drawing.Point(166, 200)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(35, 35)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 40
        Me.PictureBox2.TabStop = False
        '
        'txtM_Postal
        '
        Me.txtM_Postal.BeepOnError = True
        Me.txtM_Postal.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.txtM_Postal.Location = New System.Drawing.Point(108, 118)
        Me.txtM_Postal.Mask = "999999"
        Me.txtM_Postal.Name = "txtM_Postal"
        Me.txtM_Postal.Size = New System.Drawing.Size(47, 20)
        Me.txtM_Postal.TabIndex = 4
        Me.txtM_Postal.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label11.Location = New System.Drawing.Point(9, 121)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(102, 13)
        Me.Label11.TabIndex = 42
        Me.Label11.Text = "Почтовый индекс  "
        '
        'txtM_mail
        '
        Me.txtM_mail.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.txtM_mail.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.txtM_mail.Location = New System.Drawing.Point(202, 166)
        Me.txtM_mail.Mask = "____________@_____.____"
        Me.txtM_mail.Name = "txtM_mail"
        Me.txtM_mail.Size = New System.Drawing.Size(194, 20)
        Me.txtM_mail.TabIndex = 43
        Me.txtM_mail.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'txt_Site
        '
        Me.txt_Site.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.txt_Site.Location = New System.Drawing.Point(202, 215)
        Me.txt_Site.Name = "txt_Site"
        Me.txt_Site.Size = New System.Drawing.Size(194, 20)
        Me.txt_Site.TabIndex = 45
        Me.txt_Site.Text = "http://"
        '
        'txtM_PhoneMobile
        '
        Me.txtM_PhoneMobile.Location = New System.Drawing.Point(50, 218)
        Me.txtM_PhoneMobile.Mask = "+7 (999) 000-00-00"
        Me.txtM_PhoneMobile.Name = "txtM_PhoneMobile"
        Me.txtM_PhoneMobile.Size = New System.Drawing.Size(109, 20)
        Me.txtM_PhoneMobile.TabIndex = 46
        Me.txtM_PhoneMobile.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'frAddNewPr_Books_JudicialArea
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(583, 247)
        Me.Controls.Add(Me.txtM_PhoneMobile)
        Me.Controls.Add(Me.txt_Site)
        Me.Controls.Add(Me.txtM_mail)
        Me.Controls.Add(Me.txtM_Postal)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.txtM_Number)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txt_JudicialAreaName)
        Me.Controls.Add(Me.cmb_ZoneOfService)
        Me.Controls.Add(Me.txtM_House)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Btn_CheckAdress)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmb_CourtType)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.txt_Phone)
        Me.Controls.Add(Me.cmb_CurrentJudges)
        Me.Controls.Add(Me.txt_Adress)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frAddNewPr_Books_JudicialArea"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Добавление нового судебного участка"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents cmb_CourtType As System.Windows.Forms.ComboBox
    Friend WithEvents txt_Adress As System.Windows.Forms.TextBox
    Friend WithEvents Btn_CheckAdress As System.Windows.Forms.Button
    Friend WithEvents cmb_ZoneOfService As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_CurrentJudges As System.Windows.Forms.ComboBox
    Friend WithEvents txt_Phone As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtM_Number As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtM_House As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_JudicialAreaName As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents txtM_Postal As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtM_mail As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_Site As System.Windows.Forms.TextBox
    Friend WithEvents txtM_PhoneMobile As System.Windows.Forms.MaskedTextBox

End Class
