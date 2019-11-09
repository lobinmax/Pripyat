<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frBooksJudicialArea
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frBooksJudicialArea))
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.cmdTS_CourtType = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnTS_Update = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnTS_Quit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Tab_JudicialArea = New System.Windows.Forms.TabPage()
        Me.GB_Judicials = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DG_JudicialArea = New System.Windows.Forms.DataGridView()
        Me.Menu_JudicialArea = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Btn_AddNewJudicialArea = New System.Windows.Forms.ToolStripMenuItem()
        Me.Btn_EditJudicialArea = New System.Windows.Forms.ToolStripMenuItem()
        Me.Btn_DeleteJudicialArea = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tab_Judges = New System.Windows.Forms.TabPage()
        Me.GB_Judges = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DG_Judges = New System.Windows.Forms.DataGridView()
        Me.Menu_Judges = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Btn_AddNewJudges = New System.Windows.Forms.ToolStripMenuItem()
        Me.Btn_EditJudges = New System.Windows.Forms.ToolStripMenuItem()
        Me.Btn_DeleteJudges = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStrip.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.Tab_JudicialArea.SuspendLayout()
        Me.GB_Judicials.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DG_JudicialArea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Menu_JudicialArea.SuspendLayout()
        Me.Tab_Judges.SuspendLayout()
        Me.GB_Judges.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DG_Judges, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Menu_Judges.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdTS_CourtType, Me.ToolStripSeparator3, Me.btnTS_Update, Me.ToolStripSeparator2, Me.btnTS_Quit, Me.ToolStripSeparator1, Me.ToolStripLabel1, Me.ToolStripLabel2, Me.ToolStripLabel3})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip.Size = New System.Drawing.Size(579, 39)
        Me.ToolStrip.TabIndex = 0
        '
        'cmdTS_CourtType
        '
        Me.cmdTS_CourtType.AutoSize = False
        Me.cmdTS_CourtType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmdTS_CourtType.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdTS_CourtType.Name = "cmdTS_CourtType"
        Me.cmdTS_CourtType.Size = New System.Drawing.Size(170, 23)
        Me.cmdTS_CourtType.ToolTipText = "Судебная инстанция"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 39)
        '
        'btnTS_Update
        '
        Me.btnTS_Update.AutoSize = False
        Me.btnTS_Update.BackColor = System.Drawing.Color.Transparent
        Me.btnTS_Update.BackgroundImage = Global.Pripyat.My.Resources.Resources.update_70x70
        Me.btnTS_Update.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTS_Update.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnTS_Update.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnTS_Update.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnTS_Update.Name = "btnTS_Update"
        Me.btnTS_Update.Size = New System.Drawing.Size(36, 36)
        Me.btnTS_Update.ToolTipText = "Обновить информацию"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'btnTS_Quit
        '
        Me.btnTS_Quit.AutoSize = False
        Me.btnTS_Quit.BackColor = System.Drawing.Color.Transparent
        Me.btnTS_Quit.BackgroundImage = Global.Pripyat.My.Resources.Resources.Logoff_32x32
        Me.btnTS_Quit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTS_Quit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnTS_Quit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnTS_Quit.Name = "btnTS_Quit"
        Me.btnTS_Quit.Size = New System.Drawing.Size(36, 36)
        Me.btnTS_Quit.ToolTipText = "Закрыть форму"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(0, 36)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.AutoSize = False
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(250, 36)
        Me.ToolStripLabel2.Text = " "
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.AutoSize = False
        Me.ToolStripLabel3.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripLabel3.BackgroundImage = Global.Pripyat.My.Resources.Resources.Court
        Me.ToolStripLabel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStripLabel3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(55, 36)
        Me.ToolStripLabel3.Text = "ToolStripLabel3"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnOK.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOK.Location = New System.Drawing.Point(468, 260)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(96, 24)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        Me.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.Tab_JudicialArea)
        Me.TabControl1.Controls.Add(Me.Tab_Judges)
        Me.TabControl1.HotTrack = True
        Me.TabControl1.ImageList = Me.ImageList
        Me.TabControl1.ItemSize = New System.Drawing.Size(170, 27)
        Me.TabControl1.Location = New System.Drawing.Point(0, 49)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(578, 201)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControl1.TabIndex = 5
        Me.TabControl1.TabStop = False
        '
        'Tab_JudicialArea
        '
        Me.Tab_JudicialArea.AccessibleDescription = ""
        Me.Tab_JudicialArea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Tab_JudicialArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Tab_JudicialArea.Controls.Add(Me.GB_Judicials)
        Me.Tab_JudicialArea.ImageIndex = 0
        Me.Tab_JudicialArea.Location = New System.Drawing.Point(4, 31)
        Me.Tab_JudicialArea.Name = "Tab_JudicialArea"
        Me.Tab_JudicialArea.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_JudicialArea.Size = New System.Drawing.Size(570, 166)
        Me.Tab_JudicialArea.TabIndex = 0
        Me.Tab_JudicialArea.Text = "Судебные участки         "
        Me.Tab_JudicialArea.UseVisualStyleBackColor = True
        '
        'GB_Judicials
        '
        Me.GB_Judicials.Controls.Add(Me.Panel1)
        Me.GB_Judicials.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GB_Judicials.Location = New System.Drawing.Point(3, 3)
        Me.GB_Judicials.Name = "GB_Judicials"
        Me.GB_Judicials.Size = New System.Drawing.Size(560, 156)
        Me.GB_Judicials.TabIndex = 3
        Me.GB_Judicials.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.DG_JudicialArea)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(554, 137)
        Me.Panel1.TabIndex = 103
        '
        'DG_JudicialArea
        '
        Me.DG_JudicialArea.AllowUserToAddRows = False
        Me.DG_JudicialArea.AllowUserToDeleteRows = False
        Me.DG_JudicialArea.AllowUserToResizeRows = False
        Me.DG_JudicialArea.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DG_JudicialArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DG_JudicialArea.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DG_JudicialArea.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DG_JudicialArea.ColumnHeadersHeight = 20
        Me.DG_JudicialArea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DG_JudicialArea.ContextMenuStrip = Me.Menu_JudicialArea
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DG_JudicialArea.DefaultCellStyle = DataGridViewCellStyle2
        Me.DG_JudicialArea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DG_JudicialArea.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DG_JudicialArea.Location = New System.Drawing.Point(0, 0)
        Me.DG_JudicialArea.MultiSelect = False
        Me.DG_JudicialArea.Name = "DG_JudicialArea"
        Me.DG_JudicialArea.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DG_JudicialArea.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DG_JudicialArea.RowHeadersWidth = 21
        Me.DG_JudicialArea.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        Me.DG_JudicialArea.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DG_JudicialArea.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.DG_JudicialArea.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.DG_JudicialArea.RowTemplate.Height = 17
        Me.DG_JudicialArea.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DG_JudicialArea.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DG_JudicialArea.Size = New System.Drawing.Size(550, 133)
        Me.DG_JudicialArea.TabIndex = 6
        '
        'Menu_JudicialArea
        '
        Me.Menu_JudicialArea.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Btn_AddNewJudicialArea, Me.Btn_EditJudicialArea, Me.Btn_DeleteJudicialArea})
        Me.Menu_JudicialArea.Name = "Menu_JudicialArea"
        Me.Menu_JudicialArea.Size = New System.Drawing.Size(211, 70)
        '
        'Btn_AddNewJudicialArea
        '
        Me.Btn_AddNewJudicialArea.Image = Global.Pripyat.My.Resources.Resources.Create_32x32
        Me.Btn_AddNewJudicialArea.Name = "Btn_AddNewJudicialArea"
        Me.Btn_AddNewJudicialArea.ShortcutKeyDisplayString = "+"
        Me.Btn_AddNewJudicialArea.Size = New System.Drawing.Size(210, 22)
        Me.Btn_AddNewJudicialArea.Text = "Добавить участок"
        '
        'Btn_EditJudicialArea
        '
        Me.Btn_EditJudicialArea.Image = Global.Pripyat.My.Resources.Resources.edit_24x24
        Me.Btn_EditJudicialArea.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.Btn_EditJudicialArea.Name = "Btn_EditJudicialArea"
        Me.Btn_EditJudicialArea.ShortcutKeyDisplayString = "Enter"
        Me.Btn_EditJudicialArea.Size = New System.Drawing.Size(210, 22)
        Me.Btn_EditJudicialArea.Text = "Изменить участок"
        '
        'Btn_DeleteJudicialArea
        '
        Me.Btn_DeleteJudicialArea.Image = Global.Pripyat.My.Resources.Resources.Delete_32x32
        Me.Btn_DeleteJudicialArea.Name = "Btn_DeleteJudicialArea"
        Me.Btn_DeleteJudicialArea.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.Btn_DeleteJudicialArea.Size = New System.Drawing.Size(210, 22)
        Me.Btn_DeleteJudicialArea.Text = "Удалить участок"
        '
        'Tab_Judges
        '
        Me.Tab_Judges.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Tab_Judges.Controls.Add(Me.GB_Judges)
        Me.Tab_Judges.ImageIndex = 1
        Me.Tab_Judges.Location = New System.Drawing.Point(4, 31)
        Me.Tab_Judges.Name = "Tab_Judges"
        Me.Tab_Judges.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_Judges.Size = New System.Drawing.Size(570, 166)
        Me.Tab_Judges.TabIndex = 1
        Me.Tab_Judges.Text = "Мировые судьи             "
        Me.Tab_Judges.UseVisualStyleBackColor = True
        '
        'GB_Judges
        '
        Me.GB_Judges.Controls.Add(Me.Panel2)
        Me.GB_Judges.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GB_Judges.Location = New System.Drawing.Point(3, 3)
        Me.GB_Judges.Name = "GB_Judges"
        Me.GB_Judges.Size = New System.Drawing.Size(560, 156)
        Me.GB_Judges.TabIndex = 4
        Me.GB_Judges.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.DG_Judges)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 16)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(554, 137)
        Me.Panel2.TabIndex = 103
        '
        'DG_Judges
        '
        Me.DG_Judges.AllowUserToAddRows = False
        Me.DG_Judges.AllowUserToDeleteRows = False
        Me.DG_Judges.AllowUserToResizeRows = False
        Me.DG_Judges.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DG_Judges.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DG_Judges.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DG_Judges.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DG_Judges.ColumnHeadersHeight = 20
        Me.DG_Judges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DG_Judges.ContextMenuStrip = Me.Menu_Judges
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DG_Judges.DefaultCellStyle = DataGridViewCellStyle6
        Me.DG_Judges.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DG_Judges.Location = New System.Drawing.Point(0, 0)
        Me.DG_Judges.MultiSelect = False
        Me.DG_Judges.Name = "DG_Judges"
        Me.DG_Judges.ReadOnly = True
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DG_Judges.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DG_Judges.RowHeadersWidth = 21
        Me.DG_Judges.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        Me.DG_Judges.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.DG_Judges.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.DG_Judges.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.DG_Judges.RowTemplate.Height = 17
        Me.DG_Judges.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DG_Judges.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DG_Judges.Size = New System.Drawing.Size(550, 133)
        Me.DG_Judges.TabIndex = 5
        '
        'Menu_Judges
        '
        Me.Menu_Judges.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Btn_AddNewJudges, Me.Btn_EditJudges, Me.Btn_DeleteJudges})
        Me.Menu_Judges.Name = "Menu_JudicialArea"
        Me.Menu_Judges.Size = New System.Drawing.Size(204, 70)
        '
        'Btn_AddNewJudges
        '
        Me.Btn_AddNewJudges.Image = Global.Pripyat.My.Resources.Resources.Create_32x32
        Me.Btn_AddNewJudges.Name = "Btn_AddNewJudges"
        Me.Btn_AddNewJudges.ShortcutKeyDisplayString = "+"
        Me.Btn_AddNewJudges.Size = New System.Drawing.Size(203, 22)
        Me.Btn_AddNewJudges.Text = "Добавить судью"
        '
        'Btn_EditJudges
        '
        Me.Btn_EditJudges.Image = Global.Pripyat.My.Resources.Resources.edit_24x24
        Me.Btn_EditJudges.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.Btn_EditJudges.Name = "Btn_EditJudges"
        Me.Btn_EditJudges.ShortcutKeyDisplayString = "Enter"
        Me.Btn_EditJudges.Size = New System.Drawing.Size(203, 22)
        Me.Btn_EditJudges.Text = "Изменить запись"
        '
        'Btn_DeleteJudges
        '
        Me.Btn_DeleteJudges.Image = Global.Pripyat.My.Resources.Resources.Delete_32x32
        Me.Btn_DeleteJudges.Name = "Btn_DeleteJudges"
        Me.Btn_DeleteJudges.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.Btn_DeleteJudges.Size = New System.Drawing.Size(203, 22)
        Me.Btn_DeleteJudges.Text = "Удалить запись"
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "Молот_58х48.png")
        Me.ImageList.Images.SetKeyName(1, "Судья_48х42.png")
        '
        'frBooks_JudicialArea
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(579, 296)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frBooks_JudicialArea"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Судебные инстанции и их сотрудники"
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.Tab_JudicialArea.ResumeLayout(False)
        Me.GB_Judicials.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.DG_JudicialArea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Menu_JudicialArea.ResumeLayout(False)
        Me.Tab_Judges.ResumeLayout(False)
        Me.GB_Judges.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.DG_Judges, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Menu_Judges.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents btnTS_Update As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdTS_CourtType As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents btnTS_Quit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Tab_JudicialArea As System.Windows.Forms.TabPage
    Friend WithEvents Tab_Judges As System.Windows.Forms.TabPage
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents GB_Judicials As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DG_JudicialArea As System.Windows.Forms.DataGridView
    Friend WithEvents GB_Judges As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DG_Judges As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Menu_JudicialArea As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Btn_AddNewJudicialArea As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Btn_EditJudicialArea As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Btn_DeleteJudicialArea As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_Judges As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Btn_AddNewJudges As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Btn_DeleteJudges As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Btn_EditJudges As System.Windows.Forms.ToolStripMenuItem
End Class
