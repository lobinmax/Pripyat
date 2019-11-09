<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frArchivist
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frArchivist))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.tlJoulnalTypes = New DevExpress.XtraTreeList.TreeList()
        Me.btnCloseJournal = New DevExpress.XtraEditors.SimpleButton()
        Me.btnHidePreview = New DevExpress.XtraEditors.SimpleButton()
        Me.btnShowClosedJournals = New DevExpress.XtraEditors.SimpleButton()
        Me.btnJournalReport = New DevExpress.XtraEditors.SimpleButton()
        Me.btnExportJournal_XLSX = New DevExpress.XtraEditors.SimpleButton()
        Me.gcJournals = New DevExpress.XtraGrid.GridControl()
        Me.gvJournals = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar3 = New DevExpress.XtraBars.Bar()
        Me.btnUpdateForm = New DevExpress.XtraBars.BarButtonItem()
        Me.lbDataBaseName = New DevExpress.XtraBars.BarStaticItem()
        Me.lbServerName = New DevExpress.XtraBars.BarStaticItem()
        Me.ProgressBar = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemProgressBar1 = New DevExpress.XtraEditors.Repository.RepositoryItemProgressBar()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.btnClearFilter = New DevExpress.XtraBars.BarButtonItem()
        Me.btnClearSort = New DevExpress.XtraBars.BarButtonItem()
        Me.btnOpenTaskSheet = New DevExpress.XtraBars.BarButtonItem()
        Me.btnCopyAbonNumber = New DevExpress.XtraBars.BarButtonItem()
        Me.btnExportMenu = New DevExpress.XtraBars.BarSubItem()
        Me.btnExport_PDF = New DevExpress.XtraBars.BarButtonItem()
        Me.btnExport_RTF = New DevExpress.XtraBars.BarButtonItem()
        Me.btnExport_XLSX = New DevExpress.XtraBars.BarButtonItem()
        Me.btnExport_XLS = New DevExpress.XtraBars.BarButtonItem()
        Me.btnExport_CSV = New DevExpress.XtraBars.BarButtonItem()
        Me.BarEditItem1 = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.SplitContainerControl2 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.gcDocuments = New DevExpress.XtraGrid.GridControl()
        Me.gvDocuments = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.lbBackgroundMessage = New DevExpress.XtraEditors.LabelControl()
        Me.PopupMenu = New DevExpress.XtraBars.PopupMenu(Me.components)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.tlJoulnalTypes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcJournals, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvJournals, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemProgressBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl2.SuspendLayout()
        CType(Me.gcDocuments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvDocuments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.PictureEdit1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1382, 120)
        Me.PanelControl1.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 20.25!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Location = New System.Drawing.Point(230, 42)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(768, 33)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Электронный архив зарегистрированных документов"
        '
        'PictureEdit1
        '
        Me.PictureEdit1.Cursor = System.Windows.Forms.Cursors.Default
        Me.PictureEdit1.EditValue = CType(resources.GetObject("PictureEdit1.EditValue"), Object)
        Me.PictureEdit1.Location = New System.Drawing.Point(17, 2)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.AllowFocused = False
        Me.PictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PictureEdit1.Properties.Appearance.Options.UseBackColor = True
        Me.PictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureEdit1.Properties.ReadOnly = True
        Me.PictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.PictureEdit1.Properties.ShowMenu = False
        Me.PictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PictureEdit1.Properties.ZoomAccelerationFactor = 1.0R
        Me.PictureEdit1.Size = New System.Drawing.Size(173, 116)
        Me.PictureEdit1.TabIndex = 0
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.AppearanceCaption.Options.UseTextOptions = True
        Me.SplitContainerControl1.Panel1.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.SplitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.tlJoulnalTypes)
        Me.SplitContainerControl1.Panel1.ShowCaption = True
        Me.SplitContainerControl1.Panel1.Text = "Типы журналов"
        Me.SplitContainerControl1.Panel2.AppearanceCaption.Options.UseTextOptions = True
        Me.SplitContainerControl1.Panel2.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.SplitContainerControl1.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.btnCloseJournal)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.btnHidePreview)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.btnShowClosedJournals)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.btnJournalReport)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.btnExportJournal_XLSX)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.gcJournals)
        Me.SplitContainerControl1.Panel2.ShowCaption = True
        Me.SplitContainerControl1.Panel2.Text = "Журналы"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(1378, 260)
        Me.SplitContainerControl1.SplitterPosition = 698
        Me.SplitContainerControl1.TabIndex = 1
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'tlJoulnalTypes
        '
        Me.tlJoulnalTypes.Cursor = System.Windows.Forms.Cursors.Default
        Me.tlJoulnalTypes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlJoulnalTypes.Location = New System.Drawing.Point(0, 0)
        Me.tlJoulnalTypes.Name = "tlJoulnalTypes"
        Me.tlJoulnalTypes.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.[True]
        Me.tlJoulnalTypes.OptionsBehavior.Editable = False
        Me.tlJoulnalTypes.OptionsBehavior.ResizeNodes = False
        Me.tlJoulnalTypes.OptionsClipboard.AllowHtmlFormat = DevExpress.Utils.DefaultBoolean.[True]
        Me.tlJoulnalTypes.OptionsCustomization.AllowBandMoving = False
        Me.tlJoulnalTypes.OptionsCustomization.AllowBandResizing = False
        Me.tlJoulnalTypes.OptionsCustomization.AllowColumnMoving = False
        Me.tlJoulnalTypes.OptionsCustomization.AllowColumnResizing = False
        Me.tlJoulnalTypes.OptionsCustomization.AllowFilter = False
        Me.tlJoulnalTypes.OptionsCustomization.AllowQuickHideColumns = False
        Me.tlJoulnalTypes.OptionsCustomization.AllowSort = False
        Me.tlJoulnalTypes.OptionsFilter.AllowColumnMRUFilterList = False
        Me.tlJoulnalTypes.OptionsFilter.AllowFilterEditor = False
        Me.tlJoulnalTypes.OptionsFilter.AllowMRUFilterList = False
        Me.tlJoulnalTypes.OptionsFind.AllowFindPanel = False
        Me.tlJoulnalTypes.OptionsLayout.AddNewColumns = False
        Me.tlJoulnalTypes.OptionsMenu.EnableColumnMenu = False
        Me.tlJoulnalTypes.OptionsMenu.EnableFooterMenu = False
        Me.tlJoulnalTypes.OptionsMenu.ShowAutoFilterRowItem = False
        Me.tlJoulnalTypes.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.tlJoulnalTypes.OptionsSelection.SelectNodesOnRightClick = True
        Me.tlJoulnalTypes.OptionsView.AllowHtmlDrawHeaders = True
        Me.tlJoulnalTypes.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFullFocus
        Me.tlJoulnalTypes.OptionsView.ShowColumns = False
        Me.tlJoulnalTypes.OptionsView.ShowHorzLines = False
        Me.tlJoulnalTypes.OptionsView.ShowIndicator = False
        Me.tlJoulnalTypes.OptionsView.ShowVertLines = False
        Me.tlJoulnalTypes.Size = New System.Drawing.Size(694, 234)
        Me.tlJoulnalTypes.TabIndex = 0
        '
        'btnCloseJournal
        '
        Me.btnCloseJournal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCloseJournal.Enabled = False
        Me.btnCloseJournal.ImageOptions.Image = CType(resources.GetObject("btnCloseJournal.ImageOptions.Image"), System.Drawing.Image)
        Me.btnCloseJournal.Location = New System.Drawing.Point(120, 204)
        Me.btnCloseJournal.Name = "btnCloseJournal"
        Me.btnCloseJournal.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.btnCloseJournal.Size = New System.Drawing.Size(25, 23)
        Me.btnCloseJournal.TabIndex = 5
        Me.btnCloseJournal.ToolTip = "Завершить журнал" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Будет создан новый)"
        Me.btnCloseJournal.Visible = False
        '
        'btnHidePreview
        '
        Me.btnHidePreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnHidePreview.ImageOptions.Image = Global.Pripyat.My.Resources.Resources.separator_16x16
        Me.btnHidePreview.Location = New System.Drawing.Point(93, 204)
        Me.btnHidePreview.Name = "btnHidePreview"
        Me.btnHidePreview.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.btnHidePreview.Size = New System.Drawing.Size(25, 23)
        Me.btnHidePreview.TabIndex = 4
        Me.btnHidePreview.ToolTip = "Скрыть / Показать примечания"
        '
        'btnShowClosedJournals
        '
        Me.btnShowClosedJournals.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnShowClosedJournals.ImageOptions.Image = CType(resources.GetObject("btnShowClosedJournals.ImageOptions.Image"), System.Drawing.Image)
        Me.btnShowClosedJournals.Location = New System.Drawing.Point(66, 204)
        Me.btnShowClosedJournals.Name = "btnShowClosedJournals"
        Me.btnShowClosedJournals.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.btnShowClosedJournals.Size = New System.Drawing.Size(25, 23)
        Me.btnShowClosedJournals.TabIndex = 3
        Me.btnShowClosedJournals.ToolTip = "Скрыть / Показать" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "завершенные журналы"
        '
        'btnJournalReport
        '
        Me.btnJournalReport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnJournalReport.Enabled = False
        Me.btnJournalReport.ImageOptions.Image = Global.Pripyat.My.Resources.Resources.ElecronJournal_16x16
        Me.btnJournalReport.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.BottomCenter
        Me.btnJournalReport.Location = New System.Drawing.Point(30, 204)
        Me.btnJournalReport.Name = "btnJournalReport"
        Me.btnJournalReport.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.btnJournalReport.Size = New System.Drawing.Size(25, 23)
        Me.btnJournalReport.TabIndex = 2
        Me.btnJournalReport.ToolTip = "Выгрузить журнал для архивирования." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Возможно только для завершенных журналов."
        '
        'btnExportJournal_XLSX
        '
        Me.btnExportJournal_XLSX.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExportJournal_XLSX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnExportJournal_XLSX.ImageOptions.Image = Global.Pripyat.My.Resources.Resources.excel_16x16
        Me.btnExportJournal_XLSX.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.BottomCenter
        Me.btnExportJournal_XLSX.Location = New System.Drawing.Point(3, 204)
        Me.btnExportJournal_XLSX.Name = "btnExportJournal_XLSX"
        Me.btnExportJournal_XLSX.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.btnExportJournal_XLSX.Size = New System.Drawing.Size(25, 23)
        Me.btnExportJournal_XLSX.TabIndex = 1
        Me.btnExportJournal_XLSX.ToolTip = "Экспорт журнала в книгу Excel." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Как есть, без фильтров"
        '
        'gcJournals
        '
        Me.gcJournals.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcJournals.Location = New System.Drawing.Point(0, 0)
        Me.gcJournals.MainView = Me.gvJournals
        Me.gcJournals.MenuManager = Me.BarManager
        Me.gcJournals.Name = "gcJournals"
        Me.gcJournals.Size = New System.Drawing.Size(667, 234)
        Me.gcJournals.TabIndex = 0
        Me.gcJournals.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvJournals})
        '
        'gvJournals
        '
        Me.gvJournals.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.gvJournals.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gvJournals.Appearance.Preview.Options.UseTextOptions = True
        Me.gvJournals.Appearance.Preview.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.gvJournals.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.gvJournals.GridControl = Me.gcJournals
        Me.gvJournals.Name = "gvJournals"
        Me.gvJournals.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.gvJournals.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.[True]
        Me.gvJournals.OptionsBehavior.Editable = False
        Me.gvJournals.OptionsCustomization.AllowColumnMoving = False
        Me.gvJournals.OptionsCustomization.AllowFilter = False
        Me.gvJournals.OptionsCustomization.AllowGroup = False
        Me.gvJournals.OptionsCustomization.AllowQuickHideColumns = False
        Me.gvJournals.OptionsCustomization.AllowSort = False
        Me.gvJournals.OptionsDetail.EnableMasterViewMode = False
        Me.gvJournals.OptionsFilter.AllowFilterEditor = False
        Me.gvJournals.OptionsImageLoad.AnimationType = DevExpress.Utils.ImageContentAnimationType.Slide
        Me.gvJournals.OptionsMenu.EnableColumnMenu = False
        Me.gvJournals.OptionsMenu.EnableFooterMenu = False
        Me.gvJournals.OptionsMenu.EnableGroupPanelMenu = False
        Me.gvJournals.OptionsMenu.ShowAutoFilterRowItem = False
        Me.gvJournals.OptionsMenu.ShowDateTimeGroupIntervalItems = False
        Me.gvJournals.OptionsMenu.ShowGroupSortSummaryItems = False
        Me.gvJournals.OptionsMenu.ShowSplitItem = False
        Me.gvJournals.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.gvJournals.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.gvJournals.OptionsView.ShowFooter = True
        Me.gvJournals.OptionsView.ShowGroupPanel = False
        Me.gvJournals.OptionsView.ShowPreview = True
        '
        'BarManager
        '
        Me.BarManager.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar3})
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnUpdateForm, Me.btnClearFilter, Me.btnClearSort, Me.btnOpenTaskSheet, Me.btnCopyAbonNumber, Me.btnExportMenu, Me.btnExport_PDF, Me.btnExport_RTF, Me.btnExport_XLSX, Me.btnExport_XLS, Me.btnExport_CSV, Me.BarEditItem1, Me.ProgressBar, Me.lbDataBaseName, Me.lbServerName})
        Me.BarManager.MaxItemId = 16
        Me.BarManager.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1, Me.RepositoryItemProgressBar1})
        Me.BarManager.StatusBar = Me.Bar3
        '
        'Bar3
        '
        Me.Bar3.BarName = "Строка состояния"
        Me.Bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.Bar3.DockCol = 0
        Me.Bar3.DockRow = 0
        Me.Bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.Bar3.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnUpdateForm), New DevExpress.XtraBars.LinkPersistInfo(Me.lbDataBaseName), New DevExpress.XtraBars.LinkPersistInfo(Me.lbServerName), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, Me.ProgressBar, "", True, True, True, 461)})
        Me.Bar3.OptionsBar.AllowQuickCustomization = False
        Me.Bar3.OptionsBar.DrawDragBorder = False
        Me.Bar3.OptionsBar.UseWholeRow = True
        Me.Bar3.Text = "Строка состояния"
        '
        'btnUpdateForm
        '
        Me.btnUpdateForm.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.btnUpdateForm.Caption = "Обновить"
        Me.btnUpdateForm.Id = 0
        Me.btnUpdateForm.ImageOptions.Image = CType(resources.GetObject("btnUpdateForm.ImageOptions.Image"), System.Drawing.Image)
        Me.btnUpdateForm.ImageOptions.LargeImage = CType(resources.GetObject("btnUpdateForm.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnUpdateForm.Name = "btnUpdateForm"
        Me.btnUpdateForm.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        Me.btnUpdateForm.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'lbDataBaseName
        '
        Me.lbDataBaseName.Caption = "lbDataBaseName"
        Me.lbDataBaseName.Id = 14
        Me.lbDataBaseName.ImageOptions.Image = Global.Pripyat.My.Resources.Resources.database_16x16
        Me.lbDataBaseName.Name = "lbDataBaseName"
        Me.lbDataBaseName.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'lbServerName
        '
        Me.lbServerName.Caption = "lbServerName"
        Me.lbServerName.Id = 15
        Me.lbServerName.ImageOptions.Image = Global.Pripyat.My.Resources.Resources.IP_16x16
        Me.lbServerName.Name = "lbServerName"
        Me.lbServerName.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'ProgressBar
        '
        Me.ProgressBar.Edit = Me.RepositoryItemProgressBar1
        Me.ProgressBar.Id = 13
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        Me.ProgressBar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'RepositoryItemProgressBar1
        '
        Me.RepositoryItemProgressBar1.Name = "RepositoryItemProgressBar1"
        Me.RepositoryItemProgressBar1.ShowTitle = True
        Me.RepositoryItemProgressBar1.Step = 1
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager
        Me.barDockControlTop.Size = New System.Drawing.Size(1382, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 721)
        Me.barDockControlBottom.Manager = Me.BarManager
        Me.barDockControlBottom.Size = New System.Drawing.Size(1382, 27)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Manager = Me.BarManager
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 721)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1382, 0)
        Me.barDockControlRight.Manager = Me.BarManager
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 721)
        '
        'btnClearFilter
        '
        Me.btnClearFilter.Caption = "Очистить фильтры"
        Me.btnClearFilter.Id = 1
        Me.btnClearFilter.ImageOptions.Image = CType(resources.GetObject("btnClearFilter.ImageOptions.Image"), System.Drawing.Image)
        Me.btnClearFilter.ImageOptions.LargeImage = CType(resources.GetObject("btnClearFilter.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnClearFilter.Name = "btnClearFilter"
        '
        'btnClearSort
        '
        Me.btnClearSort.Caption = "Очистить сортировку"
        Me.btnClearSort.Id = 2
        Me.btnClearSort.ImageOptions.Image = Global.Pripyat.My.Resources.Resources.SortClear_16x16
        Me.btnClearSort.Name = "btnClearSort"
        '
        'btnOpenTaskSheet
        '
        Me.btnOpenTaskSheet.Caption = "Открыть лист-задание"
        Me.btnOpenTaskSheet.Enabled = False
        Me.btnOpenTaskSheet.Id = 3
        Me.btnOpenTaskSheet.ImageOptions.Image = Global.Pripyat.My.Resources.Resources.Task_16x16
        Me.btnOpenTaskSheet.Name = "btnOpenTaskSheet"
        '
        'btnCopyAbonNumber
        '
        Me.btnCopyAbonNumber.Caption = "Скопировать № л/с     Ctrl + C"
        Me.btnCopyAbonNumber.Enabled = False
        Me.btnCopyAbonNumber.Id = 5
        Me.btnCopyAbonNumber.ImageOptions.Image = CType(resources.GetObject("btnCopyAbonNumber.ImageOptions.Image"), System.Drawing.Image)
        Me.btnCopyAbonNumber.ImageOptions.LargeImage = CType(resources.GetObject("btnCopyAbonNumber.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnCopyAbonNumber.Name = "btnCopyAbonNumber"
        '
        'btnExportMenu
        '
        Me.btnExportMenu.Caption = "Экпорт списка"
        Me.btnExportMenu.Id = 6
        Me.btnExportMenu.ImageOptions.Image = CType(resources.GetObject("btnExportMenu.ImageOptions.Image"), System.Drawing.Image)
        Me.btnExportMenu.ImageOptions.LargeImage = CType(resources.GetObject("btnExportMenu.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnExportMenu.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnExport_PDF), New DevExpress.XtraBars.LinkPersistInfo(Me.btnExport_RTF), New DevExpress.XtraBars.LinkPersistInfo(Me.btnExport_XLSX), New DevExpress.XtraBars.LinkPersistInfo(Me.btnExport_XLS), New DevExpress.XtraBars.LinkPersistInfo(Me.btnExport_CSV)})
        Me.btnExportMenu.Name = "btnExportMenu"
        '
        'btnExport_PDF
        '
        Me.btnExport_PDF.Caption = "PDF формат ..."
        Me.btnExport_PDF.Id = 7
        Me.btnExport_PDF.ImageOptions.Image = CType(resources.GetObject("btnExport_PDF.ImageOptions.Image"), System.Drawing.Image)
        Me.btnExport_PDF.ImageOptions.LargeImage = CType(resources.GetObject("btnExport_PDF.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnExport_PDF.Name = "btnExport_PDF"
        '
        'btnExport_RTF
        '
        Me.btnExport_RTF.Caption = "RTF формат ..."
        Me.btnExport_RTF.Id = 8
        Me.btnExport_RTF.ImageOptions.Image = CType(resources.GetObject("btnExport_RTF.ImageOptions.Image"), System.Drawing.Image)
        Me.btnExport_RTF.ImageOptions.LargeImage = CType(resources.GetObject("btnExport_RTF.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnExport_RTF.Name = "btnExport_RTF"
        '
        'btnExport_XLSX
        '
        Me.btnExport_XLSX.Caption = "Excel 2007 формат ..."
        Me.btnExport_XLSX.Id = 9
        Me.btnExport_XLSX.ImageOptions.Image = CType(resources.GetObject("btnExport_XLSX.ImageOptions.Image"), System.Drawing.Image)
        Me.btnExport_XLSX.ImageOptions.LargeImage = CType(resources.GetObject("btnExport_XLSX.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnExport_XLSX.Name = "btnExport_XLSX"
        '
        'btnExport_XLS
        '
        Me.btnExport_XLS.Caption = "Excel 2003 формат ..."
        Me.btnExport_XLS.Id = 10
        Me.btnExport_XLS.ImageOptions.Image = CType(resources.GetObject("btnExport_XLS.ImageOptions.Image"), System.Drawing.Image)
        Me.btnExport_XLS.ImageOptions.LargeImage = CType(resources.GetObject("btnExport_XLS.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnExport_XLS.Name = "btnExport_XLS"
        '
        'btnExport_CSV
        '
        Me.btnExport_CSV.Caption = "CSV формат ..."
        Me.btnExport_CSV.Id = 11
        Me.btnExport_CSV.ImageOptions.Image = CType(resources.GetObject("btnExport_CSV.ImageOptions.Image"), System.Drawing.Image)
        Me.btnExport_CSV.ImageOptions.LargeImage = CType(resources.GetObject("btnExport_CSV.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnExport_CSV.Name = "btnExport_CSV"
        '
        'BarEditItem1
        '
        Me.BarEditItem1.Caption = "BarEditItem1"
        Me.BarEditItem1.Edit = Me.RepositoryItemTextEdit1
        Me.BarEditItem1.Id = 12
        Me.BarEditItem1.Name = "BarEditItem1"
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'SplitContainerControl2
        '
        Me.SplitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl2.Horizontal = False
        Me.SplitContainerControl2.Location = New System.Drawing.Point(0, 120)
        Me.SplitContainerControl2.Name = "SplitContainerControl2"
        Me.SplitContainerControl2.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.SplitContainerControl2.Panel1.Controls.Add(Me.SplitContainerControl1)
        Me.SplitContainerControl2.Panel1.Text = "Panel1"
        Me.SplitContainerControl2.Panel2.AppearanceCaption.Options.UseTextOptions = True
        Me.SplitContainerControl2.Panel2.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.SplitContainerControl2.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.SplitContainerControl2.Panel2.Controls.Add(Me.gcDocuments)
        Me.SplitContainerControl2.Panel2.Controls.Add(Me.lbBackgroundMessage)
        Me.SplitContainerControl2.Panel2.ShowCaption = True
        Me.SplitContainerControl2.Panel2.Text = "Документы"
        Me.SplitContainerControl2.Size = New System.Drawing.Size(1382, 601)
        Me.SplitContainerControl2.SplitterPosition = 264
        Me.SplitContainerControl2.TabIndex = 2
        Me.SplitContainerControl2.Text = "SplitContainerControl2"
        '
        'gcDocuments
        '
        Me.gcDocuments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcDocuments.Location = New System.Drawing.Point(0, 0)
        Me.gcDocuments.MainView = Me.gvDocuments
        Me.gcDocuments.MenuManager = Me.BarManager
        Me.gcDocuments.Name = "gcDocuments"
        Me.gcDocuments.Size = New System.Drawing.Size(1378, 310)
        Me.gcDocuments.TabIndex = 0
        Me.gcDocuments.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvDocuments})
        '
        'gvDocuments
        '
        Me.gvDocuments.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.gvDocuments.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gvDocuments.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus
        Me.gvDocuments.GridControl = Me.gcDocuments
        Me.gvDocuments.Name = "gvDocuments"
        Me.gvDocuments.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.[True]
        Me.gvDocuments.OptionsBehavior.Editable = False
        Me.gvDocuments.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.[False]
        Me.gvDocuments.OptionsClipboard.CopyCollapsedData = DevExpress.Utils.DefaultBoolean.[False]
        Me.gvDocuments.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.[False]
        Me.gvDocuments.OptionsCustomization.AllowColumnMoving = False
        Me.gvDocuments.OptionsCustomization.AllowGroup = False
        Me.gvDocuments.OptionsCustomization.AllowQuickHideColumns = False
        Me.gvDocuments.OptionsDetail.EnableMasterViewMode = False
        Me.gvDocuments.OptionsMenu.EnableColumnMenu = False
        Me.gvDocuments.OptionsMenu.EnableFooterMenu = False
        Me.gvDocuments.OptionsMenu.EnableGroupPanelMenu = False
        Me.gvDocuments.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.gvDocuments.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.gvDocuments.OptionsView.ShowFooter = True
        Me.gvDocuments.OptionsView.ShowGroupPanel = False
        '
        'lbBackgroundMessage
        '
        Me.lbBackgroundMessage.Appearance.Image = CType(resources.GetObject("lbBackgroundMessage.Appearance.Image"), System.Drawing.Image)
        Me.lbBackgroundMessage.Appearance.Options.UseImage = True
        Me.lbBackgroundMessage.Appearance.Options.UseTextOptions = True
        Me.lbBackgroundMessage.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lbBackgroundMessage.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lbBackgroundMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbBackgroundMessage.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftTop
        Me.lbBackgroundMessage.Location = New System.Drawing.Point(0, 0)
        Me.lbBackgroundMessage.Name = "lbBackgroundMessage"
        Me.lbBackgroundMessage.Size = New System.Drawing.Size(1378, 310)
        Me.lbBackgroundMessage.TabIndex = 1
        Me.lbBackgroundMessage.Text = "Для отображения содержимого журнала," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "выберите его тип, либо тип документа ему пр" & _
    "инадлежащего"
        '
        'PopupMenu
        '
        Me.PopupMenu.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnClearFilter), New DevExpress.XtraBars.LinkPersistInfo(Me.btnClearSort), New DevExpress.XtraBars.LinkPersistInfo(Me.btnOpenTaskSheet, True), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.KeyTip, Me.btnCopyAbonNumber, "", False, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.Standard, "", ""), New DevExpress.XtraBars.LinkPersistInfo(Me.btnExportMenu, True)})
        Me.PopupMenu.Manager = Me.BarManager
        Me.PopupMenu.Name = "PopupMenu"
        '
        'frArchivist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1382, 748)
        Me.Controls.Add(Me.SplitContainerControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(1398, 786)
        Me.Name = "frArchivist"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Архив зарегистрированных документов"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.tlJoulnalTypes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcJournals, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvJournals, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemProgressBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl2.ResumeLayout(False)
        CType(Me.gcDocuments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvDocuments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupMenu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents SplitContainerControl2 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar3 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents tlJoulnalTypes As DevExpress.XtraTreeList.TreeList
    Friend WithEvents gcJournals As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvJournals As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnExportJournal_XLSX As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnJournalReport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnUpdateForm As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnShowClosedJournals As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnHidePreview As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCloseJournal As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents gcDocuments As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvDocuments As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lbBackgroundMessage As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PopupMenu As DevExpress.XtraBars.PopupMenu
    Friend WithEvents btnClearFilter As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnClearSort As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnOpenTaskSheet As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnCopyAbonNumber As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnExportMenu As DevExpress.XtraBars.BarSubItem
    Friend WithEvents btnExport_PDF As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnExport_RTF As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnExport_XLSX As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnExport_XLS As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnExport_CSV As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ProgressBar As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemProgressBar1 As DevExpress.XtraEditors.Repository.RepositoryItemProgressBar
    Friend WithEvents BarEditItem1 As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents lbDataBaseName As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents lbServerName As DevExpress.XtraBars.BarStaticItem
End Class
