<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frRouter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frRouter))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PB_Loader = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TV_Performers = New System.Windows.Forms.TreeView()
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.DG_RoutersList = New System.Windows.Forms.DataGridView()
        Me.TS_Viewer = New System.Windows.Forms.ToolStrip()
        Me.TS_cmbRoute = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TS_lbStreet = New System.Windows.Forms.ToolStripLabel()
        Me.TS_btnChooseStreet = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TS_btnLoading = New System.Windows.Forms.ToolStripButton()
        Me.TS_btnToExcel = New System.Windows.Forms.ToolStripButton()
        Me.TS_btnWithoutRoute = New System.Windows.Forms.ToolStripButton()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmb_BindRouter = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lb_ActiveRouters = New System.Windows.Forms.ListBox()
        Me.btn_Binding = New C1.Win.C1Input.C1Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lb_BindControler = New System.Windows.Forms.Label()
        Me.lb_BindAddress = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tv_BindStreets = New System.Windows.Forms.TreeView()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PB_Loader, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TabControl.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DG_RoutersList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TS_Viewer.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.btn_Binding, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(831, 562)
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
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.PB_Loader)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(981, 101)
        Me.Panel1.TabIndex = 1
        '
        'PB_Loader
        '
        Me.PB_Loader.Dock = System.Windows.Forms.DockStyle.Right
        Me.PB_Loader.Image = CType(resources.GetObject("PB_Loader.Image"), System.Drawing.Image)
        Me.PB_Loader.Location = New System.Drawing.Point(880, 0)
        Me.PB_Loader.Name = "PB_Loader"
        Me.PB_Loader.Size = New System.Drawing.Size(99, 99)
        Me.PB_Loader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PB_Loader.TabIndex = 3
        Me.PB_Loader.TabStop = False
        Me.PB_Loader.Visible = False
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(100, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(591, 99)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Распределение маршрутов на участках линейных контролеров"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.Image = Global.Pripyat.My.Resources.Resources.Routes_100x100
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 99)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Location = New System.Drawing.Point(1, 106)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TV_Performers)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TabControl)
        Me.SplitContainer1.Size = New System.Drawing.Size(976, 447)
        Me.SplitContainer1.SplitterDistance = 291
        Me.SplitContainer1.TabIndex = 2
        '
        'TV_Performers
        '
        Me.TV_Performers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TV_Performers.HideSelection = False
        Me.TV_Performers.HotTracking = True
        Me.TV_Performers.ImageIndex = 0
        Me.TV_Performers.ImageList = Me.ImageList
        Me.TV_Performers.Location = New System.Drawing.Point(0, 0)
        Me.TV_Performers.Name = "TV_Performers"
        Me.TV_Performers.SelectedImageIndex = 1
        Me.TV_Performers.Size = New System.Drawing.Size(289, 445)
        Me.TV_Performers.TabIndex = 3
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "tree_16x16.png")
        Me.ImageList.Images.SetKeyName(1, "galkaRed_16x16.png")
        Me.ImageList.Images.SetKeyName(2, "Check_Mark_16x16.png")
        Me.ImageList.Images.SetKeyName(3, "metka_16x16.png")
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabPage1)
        Me.TabControl.Controls.Add(Me.TabPage2)
        Me.TabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl.Location = New System.Drawing.Point(0, 0)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(679, 445)
        Me.TabControl.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DG_RoutersList)
        Me.TabPage1.Controls.Add(Me.TS_Viewer)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(671, 419)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Просмотр"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'DG_RoutersList
        '
        Me.DG_RoutersList.AllowUserToAddRows = False
        Me.DG_RoutersList.AllowUserToDeleteRows = False
        Me.DG_RoutersList.AllowUserToResizeRows = False
        Me.DG_RoutersList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DG_RoutersList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DG_RoutersList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DG_RoutersList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DG_RoutersList.DefaultCellStyle = DataGridViewCellStyle2
        Me.DG_RoutersList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DG_RoutersList.Location = New System.Drawing.Point(3, 28)
        Me.DG_RoutersList.MultiSelect = False
        Me.DG_RoutersList.Name = "DG_RoutersList"
        Me.DG_RoutersList.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DG_RoutersList.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DG_RoutersList.RowHeadersWidth = 21
        Me.DG_RoutersList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        Me.DG_RoutersList.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DG_RoutersList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.DG_RoutersList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DG_RoutersList.RowTemplate.Height = 17
        Me.DG_RoutersList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DG_RoutersList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DG_RoutersList.Size = New System.Drawing.Size(665, 388)
        Me.DG_RoutersList.TabIndex = 112
        '
        'TS_Viewer
        '
        Me.TS_Viewer.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TS_Viewer.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TS_cmbRoute, Me.ToolStripSeparator1, Me.TS_lbStreet, Me.TS_btnChooseStreet, Me.ToolStripSeparator2, Me.TS_btnLoading, Me.TS_btnToExcel, Me.TS_btnWithoutRoute})
        Me.TS_Viewer.Location = New System.Drawing.Point(3, 3)
        Me.TS_Viewer.Name = "TS_Viewer"
        Me.TS_Viewer.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.TS_Viewer.Size = New System.Drawing.Size(665, 25)
        Me.TS_Viewer.TabIndex = 2
        Me.TS_Viewer.Text = "ToolStrip1"
        '
        'TS_cmbRoute
        '
        Me.TS_cmbRoute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TS_cmbRoute.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.TS_cmbRoute.Name = "TS_cmbRoute"
        Me.TS_cmbRoute.Size = New System.Drawing.Size(150, 25)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'TS_lbStreet
        '
        Me.TS_lbStreet.Name = "TS_lbStreet"
        Me.TS_lbStreet.Size = New System.Drawing.Size(65, 22)
        Me.TS_lbStreet.Tag = "NULL"
        Me.TS_lbStreet.Text = "Все улицы"
        '
        'TS_btnChooseStreet
        '
        Me.TS_btnChooseStreet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TS_btnChooseStreet.Image = Global.Pripyat.My.Resources.Resources.Adress_32x32
        Me.TS_btnChooseStreet.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TS_btnChooseStreet.Name = "TS_btnChooseStreet"
        Me.TS_btnChooseStreet.Size = New System.Drawing.Size(23, 22)
        Me.TS_btnChooseStreet.Text = "Выбрать улицу..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'TS_btnLoading
        '
        Me.TS_btnLoading.Image = Global.Pripyat.My.Resources.Resources.Ok_70x70
        Me.TS_btnLoading.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TS_btnLoading.Name = "TS_btnLoading"
        Me.TS_btnLoading.Size = New System.Drawing.Size(81, 22)
        Me.TS_btnLoading.Text = "Загрузить"
        Me.TS_btnLoading.ToolTipText = "Загрузить список"
        '
        'TS_btnToExcel
        '
        Me.TS_btnToExcel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TS_btnToExcel.ForeColor = System.Drawing.Color.Green
        Me.TS_btnToExcel.Image = Global.Pripyat.My.Resources.Resources.excel_logo
        Me.TS_btnToExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TS_btnToExcel.Name = "TS_btnToExcel"
        Me.TS_btnToExcel.Size = New System.Drawing.Size(53, 22)
        Me.TS_btnToExcel.Text = "Excel"
        Me.TS_btnToExcel.ToolTipText = "Выгрузить список в книгу Excel"
        '
        'TS_btnWithoutRoute
        '
        Me.TS_btnWithoutRoute.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TS_btnWithoutRoute.Image = Global.Pripyat.My.Resources.Resources.Delete_32x32
        Me.TS_btnWithoutRoute.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TS_btnWithoutRoute.Name = "TS_btnWithoutRoute"
        Me.TS_btnWithoutRoute.Size = New System.Drawing.Size(112, 22)
        Me.TS_btnWithoutRoute.Text = "Без маршрутов"
        Me.TS_btnWithoutRoute.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.TS_btnWithoutRoute.ToolTipText = "Загрузка списка лицевых без назначенного маршрута" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Выборка по всем улицам и по вс" & _
            "ем контролерам"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TableLayoutPanel2)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.tv_BindStreets)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(671, 419)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Привязка маршрутов"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.AutoSize = True
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 262.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label7, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cmb_BindRouter, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.lb_ActiveRouters, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.btn_Binding, 1, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.Label5, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label6, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lb_BindControler, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lb_BindAddress, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(298, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 5
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(370, 146)
        Me.TableLayoutPanel2.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Location = New System.Drawing.Point(3, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Часть адреса:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmb_BindRouter
        '
        Me.cmb_BindRouter.FormattingEnabled = True
        Me.cmb_BindRouter.Location = New System.Drawing.Point(111, 52)
        Me.cmb_BindRouter.Name = "cmb_BindRouter"
        Me.cmb_BindRouter.Size = New System.Drawing.Size(165, 21)
        Me.cmb_BindRouter.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(3, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 27)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Новый маршрут:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lb_ActiveRouters
        '
        Me.lb_ActiveRouters.BackColor = System.Drawing.Color.White
        Me.lb_ActiveRouters.Enabled = False
        Me.lb_ActiveRouters.ForeColor = System.Drawing.Color.Black
        Me.lb_ActiveRouters.FormattingEnabled = True
        Me.lb_ActiveRouters.Location = New System.Drawing.Point(111, 29)
        Me.lb_ActiveRouters.Name = "lb_ActiveRouters"
        Me.lb_ActiveRouters.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.lb_ActiveRouters.Size = New System.Drawing.Size(135, 17)
        Me.lb_ActiveRouters.Sorted = True
        Me.lb_ActiveRouters.TabIndex = 9
        '
        'btn_Binding
        '
        Me.btn_Binding.AutoEllipsis = True
        Me.btn_Binding.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Binding.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.btn_Binding.Image = Global.Pripyat.My.Resources.Resources.Map_icon
        Me.btn_Binding.Location = New System.Drawing.Point(213, 79)
        Me.btn_Binding.Name = "btn_Binding"
        Me.btn_Binding.Size = New System.Drawing.Size(154, 64)
        Me.btn_Binding.TabIndex = 5
        Me.btn_Binding.Text = "Привязать"
        Me.btn_Binding.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Binding.UseVisualStyleBackColor = True
        Me.btn_Binding.VisualStyle = C1.Win.C1Input.VisualStyle.Office2007Black
        Me.btn_Binding.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Black
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Location = New System.Drawing.Point(3, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 23)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Текущий маршрут:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Location = New System.Drawing.Point(3, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Участок:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lb_BindControler
        '
        Me.lb_BindControler.AutoSize = True
        Me.lb_BindControler.Location = New System.Drawing.Point(111, 13)
        Me.lb_BindControler.Name = "lb_BindControler"
        Me.lb_BindControler.Size = New System.Drawing.Size(0, 13)
        Me.lb_BindControler.TabIndex = 14
        '
        'lb_BindAddress
        '
        Me.lb_BindAddress.AutoSize = True
        Me.lb_BindAddress.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lb_BindAddress.Location = New System.Drawing.Point(111, 0)
        Me.lb_BindAddress.Name = "lb_BindAddress"
        Me.lb_BindAddress.Size = New System.Drawing.Size(256, 13)
        Me.lb_BindAddress.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.Image = Global.Pripyat.My.Resources.Resources.warning_48x48
        Me.Label4.Location = New System.Drawing.Point(306, 363)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 53)
        Me.Label4.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(356, 379)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(248, 26)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Внимание! Проделанные изменения коснуться" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "клиентской базы ПК Квазар!"
        '
        'tv_BindStreets
        '
        Me.tv_BindStreets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tv_BindStreets.Dock = System.Windows.Forms.DockStyle.Left
        Me.tv_BindStreets.ImageIndex = 3
        Me.tv_BindStreets.ImageList = Me.ImageList
        Me.tv_BindStreets.Location = New System.Drawing.Point(3, 3)
        Me.tv_BindStreets.Name = "tv_BindStreets"
        Me.tv_BindStreets.PathSeparator = " "
        Me.tv_BindStreets.SelectedImageIndex = 2
        Me.tv_BindStreets.Size = New System.Drawing.Size(295, 413)
        Me.tv_BindStreets.TabIndex = 0
        '
        'frRouter
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(981, 603)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frRouter"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Маршрутизатор"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.PB_Loader, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.TabControl.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.DG_RoutersList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TS_Viewer.ResumeLayout(False)
        Me.TS_Viewer.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.btn_Binding, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TS_Viewer As System.Windows.Forms.ToolStrip
    Friend WithEvents TS_cmbRoute As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents TS_btnLoading As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TV_Performers As System.Windows.Forms.TreeView
    Friend WithEvents PB_Loader As System.Windows.Forms.PictureBox
    Friend WithEvents TS_lbStreet As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TS_btnChooseStreet As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TS_btnWithoutRoute As System.Windows.Forms.ToolStripButton
    Friend WithEvents TS_btnToExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents DG_RoutersList As System.Windows.Forms.DataGridView
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents tv_BindStreets As System.Windows.Forms.TreeView
    Friend WithEvents btn_Binding As C1.Win.C1Input.C1Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmb_BindRouter As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lb_ActiveRouters As System.Windows.Forms.ListBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lb_BindControler As System.Windows.Forms.Label
    Friend WithEvents lb_BindAddress As System.Windows.Forms.Label

End Class
