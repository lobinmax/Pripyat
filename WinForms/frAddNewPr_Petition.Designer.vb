<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frAddNewPr_Petition
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
        Me.components = New System.ComponentModel.Container()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_CalPIR1_txt_ExcitementDt = New System.Windows.Forms.DateTimePicker()
        Me.PIR1_txt_ExcitementDt = New System.Windows.Forms.MaskedTextBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.PIR1_txt_ExecutiveNumber = New System.Windows.Forms.TextBox()
        Me.Label84 = New System.Windows.Forms.Label()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.PIR1_txt_PetitionSumm = New System.Windows.Forms.TextBox()
        Me.Label83 = New System.Windows.Forms.Label()
        Me.PIR1_cmb_CopPerformer = New System.Windows.Forms.ComboBox()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.Label89 = New System.Windows.Forms.Label()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.Label91 = New System.Windows.Forms.Label()
        Me.TimerH = New System.Windows.Forms.Timer(Me.components)
        Me.TimerW = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.btn_CalPIR1_txt_ExcitementDt)
        Me.Panel1.Controls.Add(Me.PIR1_txt_ExcitementDt)
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Controls.Add(Me.PIR1_txt_ExecutiveNumber)
        Me.Panel1.Controls.Add(Me.Label84)
        Me.Panel1.Controls.Add(Me.Label82)
        Me.Panel1.Controls.Add(Me.PIR1_txt_PetitionSumm)
        Me.Panel1.Controls.Add(Me.Label83)
        Me.Panel1.Controls.Add(Me.PIR1_cmb_CopPerformer)
        Me.Panel1.Controls.Add(Me.Label70)
        Me.Panel1.Controls.Add(Me.Label89)
        Me.Panel1.Controls.Add(Me.Label90)
        Me.Panel1.Controls.Add(Me.Label91)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(246, 165)
        Me.Panel1.TabIndex = 0
        '
        'btn_CalPIR1_txt_ExcitementDt
        '
        Me.btn_CalPIR1_txt_ExcitementDt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.btn_CalPIR1_txt_ExcitementDt.Location = New System.Drawing.Point(212, 47)
        Me.btn_CalPIR1_txt_ExcitementDt.Name = "btn_CalPIR1_txt_ExcitementDt"
        Me.btn_CalPIR1_txt_ExcitementDt.Size = New System.Drawing.Size(20, 20)
        Me.btn_CalPIR1_txt_ExcitementDt.TabIndex = 128
        Me.btn_CalPIR1_txt_ExcitementDt.Tag = "PIR1_txt_ExcitementDt"
        '
        'PIR1_txt_ExcitementDt
        '
        Me.PIR1_txt_ExcitementDt.Location = New System.Drawing.Point(134, 47)
        Me.PIR1_txt_ExcitementDt.Mask = "00/00/0000"
        Me.PIR1_txt_ExcitementDt.Name = "PIR1_txt_ExcitementDt"
        Me.PIR1_txt_ExcitementDt.RejectInputOnFirstFailure = True
        Me.PIR1_txt_ExcitementDt.ResetOnSpace = False
        Me.PIR1_txt_ExcitementDt.Size = New System.Drawing.Size(98, 20)
        Me.PIR1_txt_ExcitementDt.TabIndex = 127
        Me.PIR1_txt_ExcitementDt.Tag = ""
        Me.PIR1_txt_ExcitementDt.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.PIR1_txt_ExcitementDt.ValidatingType = GetType(Date)
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(6, 127)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(69, 29)
        Me.TableLayoutPanel1.TabIndex = 136
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.BackColor = System.Drawing.SystemColors.Control
        Me.Cancel_Button.BackgroundImage = Global.Pripyat.My.Resources.Resources.Del_16x161
        Me.Cancel_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(39, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(25, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.UseVisualStyleBackColor = False
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.BackColor = System.Drawing.SystemColors.Control
        Me.OK_Button.BackgroundImage = Global.Pripyat.My.Resources.Resources.Ok_70x70
        Me.OK_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.OK_Button.Location = New System.Drawing.Point(4, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(25, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.UseVisualStyleBackColor = True
        '
        'PIR1_txt_ExecutiveNumber
        '
        Me.PIR1_txt_ExecutiveNumber.Location = New System.Drawing.Point(5, 17)
        Me.PIR1_txt_ExecutiveNumber.Name = "PIR1_txt_ExecutiveNumber"
        Me.PIR1_txt_ExecutiveNumber.Size = New System.Drawing.Size(115, 20)
        Me.PIR1_txt_ExecutiveNumber.TabIndex = 129
        '
        'Label84
        '
        Me.Label84.AutoSize = True
        Me.Label84.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label84.Location = New System.Drawing.Point(131, 1)
        Me.Label84.Name = "Label84"
        Me.Label84.Size = New System.Drawing.Size(68, 13)
        Me.Label84.TabIndex = 135
        Me.Label84.Text = "Сумма иска"
        '
        'Label82
        '
        Me.Label82.AutoSize = True
        Me.Label82.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label82.Location = New System.Drawing.Point(3, 50)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(137, 13)
        Me.Label82.TabIndex = 132
        Me.Label82.Text = "Дата возбуждение ИП     "
        '
        'PIR1_txt_PetitionSumm
        '
        Me.PIR1_txt_PetitionSumm.Location = New System.Drawing.Point(134, 17)
        Me.PIR1_txt_PetitionSumm.Name = "PIR1_txt_PetitionSumm"
        Me.PIR1_txt_PetitionSumm.Size = New System.Drawing.Size(98, 20)
        Me.PIR1_txt_PetitionSumm.TabIndex = 134
        Me.PIR1_txt_PetitionSumm.Tag = "isk"
        '
        'Label83
        '
        Me.Label83.AutoSize = True
        Me.Label83.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label83.Location = New System.Drawing.Point(3, 1)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(60, 13)
        Me.Label83.TabIndex = 133
        Me.Label83.Text = "Номер ИП"
        '
        'PIR1_cmb_CopPerformer
        '
        Me.PIR1_cmb_CopPerformer.FormattingEnabled = True
        Me.PIR1_cmb_CopPerformer.Location = New System.Drawing.Point(5, 98)
        Me.PIR1_cmb_CopPerformer.Name = "PIR1_cmb_CopPerformer"
        Me.PIR1_cmb_CopPerformer.Size = New System.Drawing.Size(227, 21)
        Me.PIR1_cmb_CopPerformer.TabIndex = 130
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label70.Location = New System.Drawing.Point(2, 82)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(175, 13)
        Me.Label70.TabIndex = 131
        Me.Label70.Text = "Судебный пристав - исполнитель"
        '
        'Label89
        '
        Me.Label89.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label89.ForeColor = System.Drawing.Color.Red
        Me.Label89.Location = New System.Drawing.Point(116, 16)
        Me.Label89.Name = "Label89"
        Me.Label89.Size = New System.Drawing.Size(10, 10)
        Me.Label89.TabIndex = 142
        Me.Label89.Text = "*"
        Me.Label89.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label90
        '
        Me.Label90.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label90.ForeColor = System.Drawing.Color.Red
        Me.Label90.Location = New System.Drawing.Point(231, 15)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(10, 10)
        Me.Label90.TabIndex = 143
        Me.Label90.Text = "*"
        Me.Label90.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label91
        '
        Me.Label91.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label91.ForeColor = System.Drawing.Color.Red
        Me.Label91.Location = New System.Drawing.Point(231, 46)
        Me.Label91.Name = "Label91"
        Me.Label91.Size = New System.Drawing.Size(10, 10)
        Me.Label91.TabIndex = 144
        Me.Label91.Text = "*"
        Me.Label91.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TimerH
        '
        Me.TimerH.Interval = 1
        '
        'TimerW
        '
        Me.TimerW.Interval = 1
        '
        'frAddNewPr_Petition
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(246, 165)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frAddNewPr_Petition"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "frAddNewPr_Petition"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btn_CalPIR1_txt_ExcitementDt As System.Windows.Forms.DateTimePicker
    Friend WithEvents PIR1_txt_ExecutiveNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label84 As System.Windows.Forms.Label
    Friend WithEvents Label82 As System.Windows.Forms.Label
    Friend WithEvents PIR1_txt_PetitionSumm As System.Windows.Forms.TextBox
    Friend WithEvents PIR1_txt_ExcitementDt As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label83 As System.Windows.Forms.Label
    Friend WithEvents PIR1_cmb_CopPerformer As System.Windows.Forms.ComboBox
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Public WithEvents TimerH As System.Windows.Forms.Timer
    Public WithEvents TimerW As System.Windows.Forms.Timer
    Friend WithEvents Label91 As System.Windows.Forms.Label
    Friend WithEvents Label89 As System.Windows.Forms.Label
    Friend WithEvents Label90 As System.Windows.Forms.Label
End Class
