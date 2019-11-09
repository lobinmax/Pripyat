<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frPayOrdersControl
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frPayOrdersControl))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.DGView_PayOrders = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.cmb_PayOrderStatus = New System.Windows.Forms.ComboBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.txt_NumberPayOrder = New System.Windows.Forms.TextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.txt_SummPayOrder = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btn_Caltxt_DtPayOrder = New System.Windows.Forms.DateTimePicker()
        Me.txt_DtPayOrder = New System.Windows.Forms.MaskedTextBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.PIR1_ToolSt_PetitionsMeneger = New System.Windows.Forms.ToolStrip()
        Me.Btn_AddNewPayOrder = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Btn_DeletePayOrder = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Btn_SavePayOrder = New System.Windows.Forms.ToolStripButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.DGView_PayOrders, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.PIR1_ToolSt_PetitionsMeneger.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(454, 151)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(73, 29)
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
        'DGView_PayOrders
        '
        Me.DGView_PayOrders.AllowUserToAddRows = False
        Me.DGView_PayOrders.AllowUserToDeleteRows = False
        Me.DGView_PayOrders.AllowUserToResizeColumns = False
        Me.DGView_PayOrders.AllowUserToResizeRows = False
        Me.DGView_PayOrders.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DGView_PayOrders.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGView_PayOrders.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DGView_PayOrders.ColumnHeadersHeight = 20
        Me.DGView_PayOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGView_PayOrders.DefaultCellStyle = DataGridViewCellStyle6
        Me.DGView_PayOrders.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGView_PayOrders.Location = New System.Drawing.Point(0, 0)
        Me.DGView_PayOrders.MultiSelect = False
        Me.DGView_PayOrders.Name = "DGView_PayOrders"
        Me.DGView_PayOrders.ReadOnly = True
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGView_PayOrders.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DGView_PayOrders.RowHeadersWidth = 21
        Me.DGView_PayOrders.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        Me.DGView_PayOrders.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.DGView_PayOrders.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.DGView_PayOrders.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DGView_PayOrders.RowTemplate.Height = 17
        Me.DGView_PayOrders.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGView_PayOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGView_PayOrders.Size = New System.Drawing.Size(505, 88)
        Me.DGView_PayOrders.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.DGView_PayOrders)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(509, 92)
        Me.Panel1.TabIndex = 5
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Location = New System.Drawing.Point(0, 94)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(507, 29)
        Me.Panel2.TabIndex = 6
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel6.Controls.Add(Me.cmb_PayOrderStatus)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel6.Location = New System.Drawing.Point(348, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(158, 25)
        Me.Panel6.TabIndex = 10
        '
        'cmb_PayOrderStatus
        '
        Me.cmb_PayOrderStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_PayOrderStatus.FormattingEnabled = True
        Me.cmb_PayOrderStatus.Location = New System.Drawing.Point(1, 1)
        Me.cmb_PayOrderStatus.Name = "cmb_PayOrderStatus"
        Me.cmb_PayOrderStatus.Size = New System.Drawing.Size(152, 21)
        Me.cmb_PayOrderStatus.TabIndex = 71
        Me.cmb_PayOrderStatus.Tag = ""
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel5.Controls.Add(Me.txt_NumberPayOrder)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.Location = New System.Drawing.Point(206, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(142, 25)
        Me.Panel5.TabIndex = 9
        '
        'txt_NumberPayOrder
        '
        Me.txt_NumberPayOrder.Location = New System.Drawing.Point(1, 1)
        Me.txt_NumberPayOrder.MaxLength = 15
        Me.txt_NumberPayOrder.Name = "txt_NumberPayOrder"
        Me.txt_NumberPayOrder.Size = New System.Drawing.Size(136, 20)
        Me.txt_NumberPayOrder.TabIndex = 56
        Me.txt_NumberPayOrder.Tag = "isk"
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel4.Controls.Add(Me.txt_SummPayOrder)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(115, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(91, 25)
        Me.Panel4.TabIndex = 8
        '
        'txt_SummPayOrder
        '
        Me.txt_SummPayOrder.Location = New System.Drawing.Point(1, 1)
        Me.txt_SummPayOrder.Name = "txt_SummPayOrder"
        Me.txt_SummPayOrder.Size = New System.Drawing.Size(86, 20)
        Me.txt_SummPayOrder.TabIndex = 55
        Me.txt_SummPayOrder.Tag = "isk"
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.btn_Caltxt_DtPayOrder)
        Me.Panel3.Controls.Add(Me.txt_DtPayOrder)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(115, 25)
        Me.Panel3.TabIndex = 7
        '
        'btn_Caltxt_DtPayOrder
        '
        Me.btn_Caltxt_DtPayOrder.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.btn_Caltxt_DtPayOrder.Location = New System.Drawing.Point(90, 1)
        Me.btn_Caltxt_DtPayOrder.Name = "btn_Caltxt_DtPayOrder"
        Me.btn_Caltxt_DtPayOrder.Size = New System.Drawing.Size(20, 20)
        Me.btn_Caltxt_DtPayOrder.TabIndex = 109
        '
        'txt_DtPayOrder
        '
        Me.txt_DtPayOrder.Location = New System.Drawing.Point(1, 1)
        Me.txt_DtPayOrder.Mask = "00/00/0000"
        Me.txt_DtPayOrder.Name = "txt_DtPayOrder"
        Me.txt_DtPayOrder.RejectInputOnFirstFailure = True
        Me.txt_DtPayOrder.ResetOnSpace = False
        Me.txt_DtPayOrder.Size = New System.Drawing.Size(109, 20)
        Me.txt_DtPayOrder.TabIndex = 116
        Me.txt_DtPayOrder.Tag = "isk"
        Me.txt_DtPayOrder.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.txt_DtPayOrder.ValidatingType = GetType(Date)
        '
        'Panel7
        '
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel7.Controls.Add(Me.Panel1)
        Me.Panel7.Controls.Add(Me.Panel2)
        Me.Panel7.Location = New System.Drawing.Point(12, 12)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Panel7.Size = New System.Drawing.Size(513, 128)
        Me.Panel7.TabIndex = 7
        '
        'PIR1_ToolSt_PetitionsMeneger
        '
        Me.PIR1_ToolSt_PetitionsMeneger.AutoSize = False
        Me.PIR1_ToolSt_PetitionsMeneger.Dock = System.Windows.Forms.DockStyle.None
        Me.PIR1_ToolSt_PetitionsMeneger.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.PIR1_ToolSt_PetitionsMeneger.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Btn_AddNewPayOrder, Me.ToolStripSeparator1, Me.Btn_DeletePayOrder, Me.ToolStripSeparator2, Me.Btn_SavePayOrder})
        Me.PIR1_ToolSt_PetitionsMeneger.Location = New System.Drawing.Point(12, 143)
        Me.PIR1_ToolSt_PetitionsMeneger.Name = "PIR1_ToolSt_PetitionsMeneger"
        Me.PIR1_ToolSt_PetitionsMeneger.Size = New System.Drawing.Size(120, 37)
        Me.PIR1_ToolSt_PetitionsMeneger.TabIndex = 9
        '
        'Btn_AddNewPayOrder
        '
        Me.Btn_AddNewPayOrder.AutoSize = False
        Me.Btn_AddNewPayOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Btn_AddNewPayOrder.Image = CType(resources.GetObject("Btn_AddNewPayOrder.Image"), System.Drawing.Image)
        Me.Btn_AddNewPayOrder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Btn_AddNewPayOrder.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_AddNewPayOrder.Name = "Btn_AddNewPayOrder"
        Me.Btn_AddNewPayOrder.Size = New System.Drawing.Size(35, 35)
        Me.Btn_AddNewPayOrder.ToolTipText = "Добавить новое платежное поручение"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 37)
        '
        'Btn_DeletePayOrder
        '
        Me.Btn_DeletePayOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Btn_DeletePayOrder.Enabled = False
        Me.Btn_DeletePayOrder.Image = CType(resources.GetObject("Btn_DeletePayOrder.Image"), System.Drawing.Image)
        Me.Btn_DeletePayOrder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Btn_DeletePayOrder.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_DeletePayOrder.Name = "Btn_DeletePayOrder"
        Me.Btn_DeletePayOrder.Size = New System.Drawing.Size(36, 34)
        Me.Btn_DeletePayOrder.ToolTipText = "Удалить платежное поручение"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 37)
        '
        'Btn_SavePayOrder
        '
        Me.Btn_SavePayOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Btn_SavePayOrder.Enabled = False
        Me.Btn_SavePayOrder.Image = CType(resources.GetObject("Btn_SavePayOrder.Image"), System.Drawing.Image)
        Me.Btn_SavePayOrder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Btn_SavePayOrder.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_SavePayOrder.Name = "Btn_SavePayOrder"
        Me.Btn_SavePayOrder.Size = New System.Drawing.Size(36, 34)
        Me.Btn_SavePayOrder.ToolTipText = "Сохранить изменения в записях"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Purple
        Me.Label1.Location = New System.Drawing.Point(12, 179)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(226, 12)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "* Все поля являются обязательными к заполнению"
        '
        'frPayOrdersControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(539, 193)
        Me.Controls.Add(Me.PIR1_ToolSt_PetitionsMeneger)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frPayOrdersControl"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "    Управление платежными поручениями. Иск за период   с 01.01.2010г. по 01.01.20" & _
            "13г."
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.DGView_PayOrders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.PIR1_ToolSt_PetitionsMeneger.ResumeLayout(False)
        Me.PIR1_ToolSt_PetitionsMeneger.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents DGView_PayOrders As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txt_DtPayOrder As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_SummPayOrder As System.Windows.Forms.TextBox
    Friend WithEvents cmb_PayOrderStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents PIR1_ToolSt_PetitionsMeneger As System.Windows.Forms.ToolStrip
    Friend WithEvents Btn_AddNewPayOrder As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Btn_DeletePayOrder As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Btn_SavePayOrder As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_NumberPayOrder As System.Windows.Forms.TextBox
    Friend WithEvents btn_Caltxt_DtPayOrder As System.Windows.Forms.DateTimePicker

End Class
