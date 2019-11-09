<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frAddNewPr_Books_Judges
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frAddNewPr_Books_Judges))
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.cmb_CourtType = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtM_mail = New System.Windows.Forms.MaskedTextBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_Phone = New System.Windows.Forms.MaskedTextBox()
        Me.txtM_PhoneMobile = New System.Windows.Forms.MaskedTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txt_JudgesName = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OK_Button.Location = New System.Drawing.Point(144, 263)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 6
        Me.OK_Button.Text = "ОК"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(217, 263)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 51
        Me.Cancel_Button.TabStop = False
        Me.Cancel_Button.Text = "Отмена"
        '
        'cmb_CourtType
        '
        Me.cmb_CourtType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_CourtType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_CourtType.FormattingEnabled = True
        Me.cmb_CourtType.Location = New System.Drawing.Point(125, 12)
        Me.cmb_CourtType.Name = "cmb_CourtType"
        Me.cmb_CourtType.Size = New System.Drawing.Size(159, 21)
        Me.cmb_CourtType.TabIndex = 1
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label27.Location = New System.Drawing.Point(11, 15)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(117, 13)
        Me.Label27.TabIndex = 24
        Me.Label27.Text = "Судебная инстанция  "
        '
        'txtM_mail
        '
        Me.txtM_mail.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.txtM_mail.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.txtM_mail.Location = New System.Drawing.Point(42, 129)
        Me.txtM_mail.Mask = "____________@_____.____"
        Me.txtM_mail.Name = "txtM_mail"
        Me.txtM_mail.Size = New System.Drawing.Size(194, 20)
        Me.txtM_mail.TabIndex = 5
        Me.txtM_mail.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(6, 19)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(35, 35)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 51
        Me.PictureBox4.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(6, 66)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(35, 35)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 50
        Me.PictureBox3.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Pripyat.My.Resources.Resources.mail_40x40
        Me.PictureBox1.Location = New System.Drawing.Point(6, 116)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(35, 35)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 49
        Me.PictureBox1.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label7.Location = New System.Drawing.Point(39, 115)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 13)
        Me.Label7.TabIndex = 48
        Me.Label7.Text = "Электронная почта"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label6.Location = New System.Drawing.Point(40, 67)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 47
        Me.Label6.Text = "Мобильный"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label5.Location = New System.Drawing.Point(40, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 46
        Me.Label5.Text = "Телефон"
        '
        'txt_Phone
        '
        Me.txt_Phone.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.txt_Phone.Location = New System.Drawing.Point(42, 32)
        Me.txt_Phone.Mask = "+7 (30000) 0-00-00"
        Me.txt_Phone.Name = "txt_Phone"
        Me.txt_Phone.Size = New System.Drawing.Size(110, 20)
        Me.txt_Phone.TabIndex = 3
        Me.txt_Phone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'txtM_PhoneMobile
        '
        Me.txtM_PhoneMobile.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.txtM_PhoneMobile.Location = New System.Drawing.Point(42, 81)
        Me.txtM_PhoneMobile.Mask = "+7 (999) 000-00-00"
        Me.txtM_PhoneMobile.Name = "txtM_PhoneMobile"
        Me.txtM_PhoneMobile.Size = New System.Drawing.Size(110, 20)
        Me.txtM_PhoneMobile.TabIndex = 4
        Me.txtM_PhoneMobile.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label10.Location = New System.Drawing.Point(11, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 13)
        Me.Label10.TabIndex = 54
        Me.Label10.Text = "ФИО судьи"
        '
        'txt_JudgesName
        '
        Me.txt_JudgesName.Location = New System.Drawing.Point(14, 55)
        Me.txt_JudgesName.Name = "txt_JudgesName"
        Me.txt_JudgesName.Size = New System.Drawing.Size(270, 20)
        Me.txt_JudgesName.TabIndex = 2
        Me.txt_JudgesName.Tag = "txt_Phone"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PictureBox4)
        Me.GroupBox1.Controls.Add(Me.txtM_PhoneMobile)
        Me.GroupBox1.Controls.Add(Me.txt_Phone)
        Me.GroupBox1.Controls.Add(Me.txtM_mail)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.PictureBox3)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 82)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(272, 165)
        Me.GroupBox1.TabIndex = 55
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Контактная информация"
        '
        'frAddNewPr_Books_Judges
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(298, 304)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txt_JudgesName)
        Me.Controls.Add(Me.cmb_CourtType)
        Me.Controls.Add(Me.Label27)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frAddNewPr_Books_Judges"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Добавление судьи в справочник"
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents cmb_CourtType As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtM_mail As System.Windows.Forms.MaskedTextBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_Phone As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtM_PhoneMobile As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_JudgesName As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox

End Class
