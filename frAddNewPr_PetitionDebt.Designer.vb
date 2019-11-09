<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frAddNewPr_PetitionDebt
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Group_Petition = New System.Windows.Forms.GroupBox()
        Me.btn_CalPIR1_txt_DtPetitions = New System.Windows.Forms.DateTimePicker()
        Me.btn_CalPIR1_txt_DtPeriodEnd = New System.Windows.Forms.DateTimePicker()
        Me.btn_CalPIR1_txt_DtPeriodStart = New System.Windows.Forms.DateTimePicker()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.PIR1_cmb_PetitionType = New System.Windows.Forms.ComboBox()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.PIR1_txt_DtPeriodEnd = New System.Windows.Forms.MaskedTextBox()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.PIR1_txt_GovTax = New System.Windows.Forms.TextBox()
        Me.PIR1_txt_DebtSumm = New System.Windows.Forms.TextBox()
        Me.PIR1_txt_NumberPetition = New System.Windows.Forms.TextBox()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.PIR1_cmb_EnergyType = New System.Windows.Forms.ComboBox()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.PIR1_txt_DtPetitions = New System.Windows.Forms.MaskedTextBox()
        Me.PIR1_cmb_CourtType = New System.Windows.Forms.ComboBox()
        Me.PIR1_cmb_JudicialArea = New System.Windows.Forms.ComboBox()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.PIR1_txt_DtPeriodStart = New System.Windows.Forms.MaskedTextBox()
        Me.cmd_PrMembers = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_CalDtResidence = New System.Windows.Forms.DateTimePicker()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Group_Petition.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(213, 283)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "ОК"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Отмена"
        '
        'Group_Petition
        '
        Me.Group_Petition.BackColor = System.Drawing.SystemColors.Control
        Me.Group_Petition.Controls.Add(Me.btn_CalPIR1_txt_DtPetitions)
        Me.Group_Petition.Controls.Add(Me.btn_CalPIR1_txt_DtPeriodEnd)
        Me.Group_Petition.Controls.Add(Me.btn_CalPIR1_txt_DtPeriodStart)
        Me.Group_Petition.Controls.Add(Me.Label74)
        Me.Group_Petition.Controls.Add(Me.Label71)
        Me.Group_Petition.Controls.Add(Me.Label73)
        Me.Group_Petition.Controls.Add(Me.PIR1_cmb_PetitionType)
        Me.Group_Petition.Controls.Add(Me.Label54)
        Me.Group_Petition.Controls.Add(Me.Label53)
        Me.Group_Petition.Controls.Add(Me.Label52)
        Me.Group_Petition.Controls.Add(Me.PIR1_txt_DtPeriodEnd)
        Me.Group_Petition.Controls.Add(Me.Label59)
        Me.Group_Petition.Controls.Add(Me.Label56)
        Me.Group_Petition.Controls.Add(Me.Label57)
        Me.Group_Petition.Controls.Add(Me.Label51)
        Me.Group_Petition.Controls.Add(Me.PIR1_txt_GovTax)
        Me.Group_Petition.Controls.Add(Me.PIR1_txt_DebtSumm)
        Me.Group_Petition.Controls.Add(Me.PIR1_txt_NumberPetition)
        Me.Group_Petition.Controls.Add(Me.Label58)
        Me.Group_Petition.Controls.Add(Me.Label60)
        Me.Group_Petition.Controls.Add(Me.PIR1_cmb_EnergyType)
        Me.Group_Petition.Controls.Add(Me.Label68)
        Me.Group_Petition.Controls.Add(Me.PIR1_txt_DtPetitions)
        Me.Group_Petition.Controls.Add(Me.PIR1_cmb_CourtType)
        Me.Group_Petition.Controls.Add(Me.PIR1_cmb_JudicialArea)
        Me.Group_Petition.Controls.Add(Me.Label79)
        Me.Group_Petition.Controls.Add(Me.Label80)
        Me.Group_Petition.Controls.Add(Me.Label81)
        Me.Group_Petition.Controls.Add(Me.Label78)
        Me.Group_Petition.Controls.Add(Me.Label76)
        Me.Group_Petition.Controls.Add(Me.Label75)
        Me.Group_Petition.Controls.Add(Me.Label77)
        Me.Group_Petition.Controls.Add(Me.PIR1_txt_DtPeriodStart)
        Me.Group_Petition.Location = New System.Drawing.Point(12, 45)
        Me.Group_Petition.Name = "Group_Petition"
        Me.Group_Petition.Size = New System.Drawing.Size(347, 224)
        Me.Group_Petition.TabIndex = 54
        Me.Group_Petition.TabStop = False
        Me.Group_Petition.Text = "Параметры иска"
        '
        'btn_CalPIR1_txt_DtPetitions
        '
        Me.btn_CalPIR1_txt_DtPetitions.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.btn_CalPIR1_txt_DtPetitions.Location = New System.Drawing.Point(195, 195)
        Me.btn_CalPIR1_txt_DtPetitions.Name = "btn_CalPIR1_txt_DtPetitions"
        Me.btn_CalPIR1_txt_DtPetitions.Size = New System.Drawing.Size(20, 20)
        Me.btn_CalPIR1_txt_DtPetitions.TabIndex = 118
        '
        'btn_CalPIR1_txt_DtPeriodEnd
        '
        Me.btn_CalPIR1_txt_DtPeriodEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.btn_CalPIR1_txt_DtPeriodEnd.Location = New System.Drawing.Point(87, 69)
        Me.btn_CalPIR1_txt_DtPeriodEnd.Name = "btn_CalPIR1_txt_DtPeriodEnd"
        Me.btn_CalPIR1_txt_DtPeriodEnd.Size = New System.Drawing.Size(20, 20)
        Me.btn_CalPIR1_txt_DtPeriodEnd.TabIndex = 117
        '
        'btn_CalPIR1_txt_DtPeriodStart
        '
        Me.btn_CalPIR1_txt_DtPeriodStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.btn_CalPIR1_txt_DtPeriodStart.Location = New System.Drawing.Point(87, 31)
        Me.btn_CalPIR1_txt_DtPeriodStart.Name = "btn_CalPIR1_txt_DtPeriodStart"
        Me.btn_CalPIR1_txt_DtPeriodStart.Size = New System.Drawing.Size(20, 20)
        Me.btn_CalPIR1_txt_DtPeriodStart.TabIndex = 116
        '
        'Label74
        '
        Me.Label74.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label74.ForeColor = System.Drawing.Color.Red
        Me.Label74.Location = New System.Drawing.Point(107, 67)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(10, 10)
        Me.Label74.TabIndex = 103
        Me.Label74.Text = "*"
        Me.Label74.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label71
        '
        Me.Label71.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label71.ForeColor = System.Drawing.Color.Red
        Me.Label71.Location = New System.Drawing.Point(107, 29)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(10, 10)
        Me.Label71.TabIndex = 102
        Me.Label71.Text = "*"
        Me.Label71.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label73
        '
        Me.Label73.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label73.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label73.Location = New System.Drawing.Point(5, 14)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(18, 81)
        Me.Label73.TabIndex = 100
        Me.Label73.Text = "Период"
        '
        'PIR1_cmb_PetitionType
        '
        Me.PIR1_cmb_PetitionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PIR1_cmb_PetitionType.FormattingEnabled = True
        Me.PIR1_cmb_PetitionType.Location = New System.Drawing.Point(141, 68)
        Me.PIR1_cmb_PetitionType.Name = "PIR1_cmb_PetitionType"
        Me.PIR1_cmb_PetitionType.Size = New System.Drawing.Size(195, 21)
        Me.PIR1_cmb_PetitionType.TabIndex = 101
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label54.Location = New System.Drawing.Point(109, 138)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(75, 13)
        Me.Label54.TabIndex = 82
        Me.Label54.Text = "Гос. пошлина"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label53.Location = New System.Drawing.Point(4, 138)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(68, 13)
        Me.Label53.TabIndex = 81
        Me.Label53.Text = "Сумма иска"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label52.Location = New System.Drawing.Point(22, 15)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(44, 13)
        Me.Label52.TabIndex = 47
        Me.Label52.Text = "Начало"
        '
        'PIR1_txt_DtPeriodEnd
        '
        Me.PIR1_txt_DtPeriodEnd.Location = New System.Drawing.Point(25, 69)
        Me.PIR1_txt_DtPeriodEnd.Mask = "00/00/0000"
        Me.PIR1_txt_DtPeriodEnd.Name = "PIR1_txt_DtPeriodEnd"
        Me.PIR1_txt_DtPeriodEnd.RejectInputOnFirstFailure = True
        Me.PIR1_txt_DtPeriodEnd.ResetOnSpace = False
        Me.PIR1_txt_DtPeriodEnd.Size = New System.Drawing.Size(82, 20)
        Me.PIR1_txt_DtPeriodEnd.TabIndex = 52
        Me.PIR1_txt_DtPeriodEnd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.PIR1_txt_DtPeriodEnd.ValidatingType = GetType(Date)
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label59.Location = New System.Drawing.Point(182, 96)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(102, 13)
        Me.Label59.TabIndex = 87
        Me.Label59.Text = " Судебный участок"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label56.Location = New System.Drawing.Point(257, 13)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(79, 13)
        Me.Label56.TabIndex = 84
        Me.Label56.Text = "Предмет иска"
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label57.Location = New System.Drawing.Point(4, 96)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(111, 13)
        Me.Label57.TabIndex = 85
        Me.Label57.Text = "Судебная инстанция"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label51.Location = New System.Drawing.Point(22, 53)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(38, 13)
        Me.Label51.TabIndex = 48
        Me.Label51.Text = "Конец"
        '
        'PIR1_txt_GovTax
        '
        Me.PIR1_txt_GovTax.Location = New System.Drawing.Point(112, 153)
        Me.PIR1_txt_GovTax.Name = "PIR1_txt_GovTax"
        Me.PIR1_txt_GovTax.ReadOnly = True
        Me.PIR1_txt_GovTax.Size = New System.Drawing.Size(72, 20)
        Me.PIR1_txt_GovTax.TabIndex = 55
        '
        'PIR1_txt_DebtSumm
        '
        Me.PIR1_txt_DebtSumm.Location = New System.Drawing.Point(7, 153)
        Me.PIR1_txt_DebtSumm.Name = "PIR1_txt_DebtSumm"
        Me.PIR1_txt_DebtSumm.Size = New System.Drawing.Size(98, 20)
        Me.PIR1_txt_DebtSumm.TabIndex = 54
        '
        'PIR1_txt_NumberPetition
        '
        Me.PIR1_txt_NumberPetition.BackColor = System.Drawing.SystemColors.Window
        Me.PIR1_txt_NumberPetition.Location = New System.Drawing.Point(7, 195)
        Me.PIR1_txt_NumberPetition.Name = "PIR1_txt_NumberPetition"
        Me.PIR1_txt_NumberPetition.Size = New System.Drawing.Size(122, 20)
        Me.PIR1_txt_NumberPetition.TabIndex = 59
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label58.Location = New System.Drawing.Point(283, 52)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(53, 13)
        Me.Label58.TabIndex = 86
        Me.Label58.Text = "Тип иска"
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label60.Location = New System.Drawing.Point(5, 180)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(98, 13)
        Me.Label60.TabIndex = 88
        Me.Label60.Text = "Номер заявления"
        '
        'PIR1_cmb_EnergyType
        '
        Me.PIR1_cmb_EnergyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PIR1_cmb_EnergyType.DropDownWidth = 146
        Me.PIR1_cmb_EnergyType.FormattingEnabled = True
        Me.PIR1_cmb_EnergyType.Location = New System.Drawing.Point(121, 29)
        Me.PIR1_cmb_EnergyType.Name = "PIR1_cmb_EnergyType"
        Me.PIR1_cmb_EnergyType.Size = New System.Drawing.Size(215, 21)
        Me.PIR1_cmb_EnergyType.TabIndex = 56
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label68.Location = New System.Drawing.Point(133, 180)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(90, 13)
        Me.Label68.TabIndex = 95
        Me.Label68.Text = "Дата заявления"
        '
        'PIR1_txt_DtPetitions
        '
        Me.PIR1_txt_DtPetitions.Location = New System.Drawing.Point(136, 195)
        Me.PIR1_txt_DtPetitions.Mask = "00/00/0000"
        Me.PIR1_txt_DtPetitions.Name = "PIR1_txt_DtPetitions"
        Me.PIR1_txt_DtPetitions.RejectInputOnFirstFailure = True
        Me.PIR1_txt_DtPetitions.ResetOnSpace = False
        Me.PIR1_txt_DtPetitions.Size = New System.Drawing.Size(80, 20)
        Me.PIR1_txt_DtPetitions.TabIndex = 61
        Me.PIR1_txt_DtPetitions.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.PIR1_txt_DtPetitions.ValidatingType = GetType(Date)
        '
        'PIR1_cmb_CourtType
        '
        Me.PIR1_cmb_CourtType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PIR1_cmb_CourtType.FormattingEnabled = True
        Me.PIR1_cmb_CourtType.Location = New System.Drawing.Point(7, 112)
        Me.PIR1_cmb_CourtType.Name = "PIR1_cmb_CourtType"
        Me.PIR1_cmb_CourtType.Size = New System.Drawing.Size(160, 21)
        Me.PIR1_cmb_CourtType.TabIndex = 57
        '
        'PIR1_cmb_JudicialArea
        '
        Me.PIR1_cmb_JudicialArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PIR1_cmb_JudicialArea.FormattingEnabled = True
        Me.PIR1_cmb_JudicialArea.Location = New System.Drawing.Point(184, 112)
        Me.PIR1_cmb_JudicialArea.Name = "PIR1_cmb_JudicialArea"
        Me.PIR1_cmb_JudicialArea.Size = New System.Drawing.Size(152, 21)
        Me.PIR1_cmb_JudicialArea.TabIndex = 70
        '
        'Label79
        '
        Me.Label79.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label79.ForeColor = System.Drawing.Color.Red
        Me.Label79.Location = New System.Drawing.Point(105, 153)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(10, 10)
        Me.Label79.TabIndex = 108
        Me.Label79.Text = "*"
        Me.Label79.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label80
        '
        Me.Label80.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label80.ForeColor = System.Drawing.Color.Red
        Me.Label80.Location = New System.Drawing.Point(129, 192)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(10, 10)
        Me.Label80.TabIndex = 109
        Me.Label80.Text = "*"
        Me.Label80.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label81
        '
        Me.Label81.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label81.ForeColor = System.Drawing.Color.Red
        Me.Label81.Location = New System.Drawing.Point(215, 192)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(10, 10)
        Me.Label81.TabIndex = 110
        Me.Label81.Text = "*"
        Me.Label81.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label78
        '
        Me.Label78.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label78.ForeColor = System.Drawing.Color.Red
        Me.Label78.Location = New System.Drawing.Point(335, 112)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(10, 10)
        Me.Label78.TabIndex = 107
        Me.Label78.Text = "*"
        Me.Label78.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label76
        '
        Me.Label76.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label76.ForeColor = System.Drawing.Color.Red
        Me.Label76.Location = New System.Drawing.Point(335, 67)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(10, 10)
        Me.Label76.TabIndex = 105
        Me.Label76.Text = "*"
        Me.Label76.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label75
        '
        Me.Label75.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label75.ForeColor = System.Drawing.Color.Red
        Me.Label75.Location = New System.Drawing.Point(335, 25)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(10, 10)
        Me.Label75.TabIndex = 104
        Me.Label75.Text = "*"
        Me.Label75.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label77
        '
        Me.Label77.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label77.ForeColor = System.Drawing.Color.Red
        Me.Label77.Location = New System.Drawing.Point(167, 112)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(10, 10)
        Me.Label77.TabIndex = 106
        Me.Label77.Text = "*"
        Me.Label77.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PIR1_txt_DtPeriodStart
        '
        Me.PIR1_txt_DtPeriodStart.Location = New System.Drawing.Point(25, 31)
        Me.PIR1_txt_DtPeriodStart.Mask = "00/00/0000"
        Me.PIR1_txt_DtPeriodStart.Name = "PIR1_txt_DtPeriodStart"
        Me.PIR1_txt_DtPeriodStart.RejectInputOnFirstFailure = True
        Me.PIR1_txt_DtPeriodStart.ResetOnSpace = False
        Me.PIR1_txt_DtPeriodStart.Size = New System.Drawing.Size(82, 20)
        Me.PIR1_txt_DtPeriodStart.TabIndex = 114
        Me.PIR1_txt_DtPeriodStart.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.PIR1_txt_DtPeriodStart.ValidatingType = GetType(Date)
        '
        'cmd_PrMembers
        '
        Me.cmd_PrMembers.FormattingEnabled = True
        Me.cmd_PrMembers.Location = New System.Drawing.Point(12, 18)
        Me.cmd_PrMembers.Name = "cmd_PrMembers"
        Me.cmd_PrMembers.Size = New System.Drawing.Size(347, 21)
        Me.cmd_PrMembers.TabIndex = 55
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 85
        Me.Label1.Text = "Член семьи"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(9, 269)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(186, 13)
        Me.Label2.TabIndex = 115
        Me.Label2.Text = "* - поля обязательные к заполнению"
        '
        'btn_CalDtResidence
        '
        Me.btn_CalDtResidence.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.btn_CalDtResidence.Location = New System.Drawing.Point(87, 31)
        Me.btn_CalDtResidence.Name = "btn_CalDtResidence"
        Me.btn_CalDtResidence.Size = New System.Drawing.Size(20, 20)
        Me.btn_CalDtResidence.TabIndex = 116
        '
        'frAddNewPr_PetitionDebt
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(371, 324)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmd_PrMembers)
        Me.Controls.Add(Me.Group_Petition)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frAddNewPr_PetitionDebt"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Создание нового иска"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Group_Petition.ResumeLayout(False)
        Me.Group_Petition.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Group_Petition As System.Windows.Forms.GroupBox
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents PIR1_cmb_PetitionType As System.Windows.Forms.ComboBox
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents PIR1_txt_DtPeriodEnd As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents PIR1_txt_GovTax As System.Windows.Forms.TextBox
    Friend WithEvents PIR1_txt_DebtSumm As System.Windows.Forms.TextBox
    Friend WithEvents PIR1_txt_NumberPetition As System.Windows.Forms.TextBox
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents PIR1_cmb_EnergyType As System.Windows.Forms.ComboBox
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents PIR1_txt_DtPetitions As System.Windows.Forms.MaskedTextBox
    Friend WithEvents PIR1_cmb_CourtType As System.Windows.Forms.ComboBox
    Friend WithEvents PIR1_cmb_JudicialArea As System.Windows.Forms.ComboBox
    Friend WithEvents Label79 As System.Windows.Forms.Label
    Friend WithEvents Label80 As System.Windows.Forms.Label
    Friend WithEvents Label81 As System.Windows.Forms.Label
    Friend WithEvents Label78 As System.Windows.Forms.Label
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents Label77 As System.Windows.Forms.Label
    Friend WithEvents PIR1_txt_DtPeriodStart As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cmd_PrMembers As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_CalPIR1_txt_DtPetitions As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_CalPIR1_txt_DtPeriodEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_CalPIR1_txt_DtPeriodStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_CalDtResidence As System.Windows.Forms.DateTimePicker

End Class
