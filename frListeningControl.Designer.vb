<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frListeningControl
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.txt_DtListening = New System.Windows.Forms.MaskedTextBox()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmb_ListeningType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_DtPostpone = New System.Windows.Forms.MaskedTextBox()
        Me.Panel = New System.Windows.Forms.Panel()
        Me.btn_CalDtPostpone = New System.Windows.Forms.DateTimePicker()
        Me.btn_CalDtDecision = New System.Windows.Forms.DateTimePicker()
        Me.TimerH = New System.Windows.Forms.Timer(Me.components)
        Me.TimerW = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel.SuspendLayout()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(120, 104)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "ОК"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Отмена"
        '
        'txt_DtListening
        '
        Me.txt_DtListening.Location = New System.Drawing.Point(151, 6)
        Me.txt_DtListening.Mask = "00/00/0000"
        Me.txt_DtListening.Name = "txt_DtListening"
        Me.txt_DtListening.RejectInputOnFirstFailure = True
        Me.txt_DtListening.ResetOnSpace = False
        Me.txt_DtListening.Size = New System.Drawing.Size(111, 20)
        Me.txt_DtListening.TabIndex = 101
        Me.txt_DtListening.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.txt_DtListening.ValidatingType = GetType(Date)
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label72.Location = New System.Drawing.Point(0, 9)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(145, 13)
        Me.Label72.TabIndex = 102
        Me.Label72.Text = "Дата судебного заседания"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 13)
        Me.Label1.TabIndex = 103
        Me.Label1.Text = "Итоги заседания"
        '
        'cmb_ListeningType
        '
        Me.cmb_ListeningType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_ListeningType.FormattingEnabled = True
        Me.cmb_ListeningType.Location = New System.Drawing.Point(100, 35)
        Me.cmb_ListeningType.Name = "cmb_ListeningType"
        Me.cmb_ListeningType.Size = New System.Drawing.Size(163, 21)
        Me.cmb_ListeningType.TabIndex = 104
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(156, 13)
        Me.Label2.TabIndex = 107
        Me.Label2.Text = "Дата следующего заседания"
        '
        'txt_DtPostpone
        '
        Me.txt_DtPostpone.Location = New System.Drawing.Point(162, 66)
        Me.txt_DtPostpone.Mask = "00/00/0000"
        Me.txt_DtPostpone.Name = "txt_DtPostpone"
        Me.txt_DtPostpone.RejectInputOnFirstFailure = True
        Me.txt_DtPostpone.ResetOnSpace = False
        Me.txt_DtPostpone.Size = New System.Drawing.Size(100, 20)
        Me.txt_DtPostpone.TabIndex = 106
        Me.txt_DtPostpone.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.txt_DtPostpone.ValidatingType = GetType(Date)
        '
        'Panel
        '
        Me.Panel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel.Controls.Add(Me.btn_CalDtPostpone)
        Me.Panel.Controls.Add(Me.btn_CalDtDecision)
        Me.Panel.Controls.Add(Me.Label72)
        Me.Panel.Controls.Add(Me.Label2)
        Me.Panel.Controls.Add(Me.txt_DtListening)
        Me.Panel.Controls.Add(Me.txt_DtPostpone)
        Me.Panel.Controls.Add(Me.Label1)
        Me.Panel.Controls.Add(Me.cmb_ListeningType)
        Me.Panel.Location = New System.Drawing.Point(0, 0)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(269, 98)
        Me.Panel.TabIndex = 108
        '
        'btn_CalDtPostpone
        '
        Me.btn_CalDtPostpone.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.btn_CalDtPostpone.Location = New System.Drawing.Point(242, 66)
        Me.btn_CalDtPostpone.Name = "btn_CalDtPostpone"
        Me.btn_CalDtPostpone.Size = New System.Drawing.Size(20, 20)
        Me.btn_CalDtPostpone.TabIndex = 109
        '
        'btn_CalDtDecision
        '
        Me.btn_CalDtDecision.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.btn_CalDtDecision.Location = New System.Drawing.Point(242, 6)
        Me.btn_CalDtDecision.Name = "btn_CalDtDecision"
        Me.btn_CalDtDecision.Size = New System.Drawing.Size(20, 20)
        Me.btn_CalDtDecision.TabIndex = 108
        '
        'TimerH
        '
        Me.TimerH.Interval = 1
        '
        'TimerW
        '
        Me.TimerW.Interval = 1
        '
        'frListeningControl
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(269, 136)
        Me.Controls.Add(Me.Panel)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frListeningControl"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Данные судебного заседания"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents txt_DtListening As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmb_ListeningType As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_DtPostpone As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Panel As System.Windows.Forms.Panel
    Friend WithEvents btn_CalDtPostpone As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_CalDtDecision As System.Windows.Forms.DateTimePicker
    Public WithEvents TimerH As System.Windows.Forms.Timer
    Public WithEvents TimerW As System.Windows.Forms.Timer

End Class
