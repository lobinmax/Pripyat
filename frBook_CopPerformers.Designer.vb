<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frBook_CopPerformers
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frBook_CopPerformers))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.DG_CopPerformers = New System.Windows.Forms.DataGridView()
        Me.Menu_CopPerformers = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Btn_AddNewCop = New System.Windows.Forms.ToolStripMenuItem()
        Me.Btn_EditCop = New System.Windows.Forms.ToolStripMenuItem()
        Me.Btn_DeleteCop = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.DG_CopPerformers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Menu_CopPerformers.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(393, 228)
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
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Отмена"
        '
        'DG_CopPerformers
        '
        Me.DG_CopPerformers.AllowUserToAddRows = False
        Me.DG_CopPerformers.AllowUserToDeleteRows = False
        Me.DG_CopPerformers.AllowUserToResizeRows = False
        Me.DG_CopPerformers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DG_CopPerformers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DG_CopPerformers.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DG_CopPerformers.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DG_CopPerformers.ColumnHeadersHeight = 20
        Me.DG_CopPerformers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DG_CopPerformers.ContextMenuStrip = Me.Menu_CopPerformers
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DG_CopPerformers.DefaultCellStyle = DataGridViewCellStyle2
        Me.DG_CopPerformers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DG_CopPerformers.Location = New System.Drawing.Point(3, 16)
        Me.DG_CopPerformers.MultiSelect = False
        Me.DG_CopPerformers.Name = "DG_CopPerformers"
        Me.DG_CopPerformers.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DG_CopPerformers.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DG_CopPerformers.RowHeadersWidth = 21
        Me.DG_CopPerformers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        Me.DG_CopPerformers.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DG_CopPerformers.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.DG_CopPerformers.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DG_CopPerformers.RowTemplate.Height = 17
        Me.DG_CopPerformers.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DG_CopPerformers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DG_CopPerformers.Size = New System.Drawing.Size(545, 196)
        Me.DG_CopPerformers.TabIndex = 4
        '
        'Menu_CopPerformers
        '
        Me.Menu_CopPerformers.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Btn_AddNewCop, Me.Btn_EditCop, Me.Btn_DeleteCop})
        Me.Menu_CopPerformers.Name = "Menu_JudicialArea"
        Me.Menu_CopPerformers.Size = New System.Drawing.Size(216, 70)
        '
        'Btn_AddNewCop
        '
        Me.Btn_AddNewCop.Image = Global.Pripyat.My.Resources.Resources.Create_32x32
        Me.Btn_AddNewCop.Name = "Btn_AddNewCop"
        Me.Btn_AddNewCop.ShortcutKeyDisplayString = "+"
        Me.Btn_AddNewCop.Size = New System.Drawing.Size(215, 22)
        Me.Btn_AddNewCop.Text = "Добавить пристава"
        '
        'Btn_EditCop
        '
        Me.Btn_EditCop.Image = Global.Pripyat.My.Resources.Resources.edit_24x24
        Me.Btn_EditCop.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.Btn_EditCop.Name = "Btn_EditCop"
        Me.Btn_EditCop.ShortcutKeyDisplayString = "Enter"
        Me.Btn_EditCop.Size = New System.Drawing.Size(215, 22)
        Me.Btn_EditCop.Text = "Изменить пристава"
        '
        'Btn_DeleteCop
        '
        Me.Btn_DeleteCop.Image = Global.Pripyat.My.Resources.Resources.Delete_32x32
        Me.Btn_DeleteCop.Name = "Btn_DeleteCop"
        Me.Btn_DeleteCop.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.Btn_DeleteCop.Size = New System.Drawing.Size(215, 22)
        Me.Btn_DeleteCop.Text = "Удалить пристава"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DG_CopPerformers)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(551, 215)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Пристава - исполнители"
        '
        'frBook_CopPerformers
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(551, 269)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frBook_CopPerformers"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Пристава - Исполнители"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.DG_CopPerformers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Menu_CopPerformers.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents DG_CopPerformers As System.Windows.Forms.DataGridView
    Friend WithEvents Menu_CopPerformers As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Btn_AddNewCop As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Btn_EditCop As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Btn_DeleteCop As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox

End Class
