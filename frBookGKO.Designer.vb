<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frBookGKO
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
        Dim SuperToolTip4 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem4 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem4 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip5 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipItem5 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim ToolTipSeparatorItem2 As DevExpress.Utils.ToolTipSeparatorItem = New DevExpress.Utils.ToolTipSeparatorItem()
        Dim ToolTipTitleItem5 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim SuperToolTip6 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipItem6 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim ToolTipTitleItem6 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frBookGKO))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.tlGKO = New DevExpress.XtraTreeList.TreeList()
        Me.pmGKO = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.bmiAdd = New DevExpress.XtraBars.BarSubItem()
        Me.btnAddGKO = New DevExpress.XtraBars.BarButtonItem()
        Me.btnAddGKH = New DevExpress.XtraBars.BarButtonItem()
        Me.btnEditGKO = New DevExpress.XtraBars.BarButtonItem()
        Me.btnDeleteGKO = New DevExpress.XtraBars.BarButtonItem()
        Me.btnUpdate = New DevExpress.XtraBars.BarButtonItem()
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.DownBar = New DevExpress.XtraBars.Bar()
        Me.lbCreater = New DevExpress.XtraBars.BarStaticItem()
        Me.lbUpdater = New DevExpress.XtraBars.BarStaticItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tlGKO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pmGKO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.PictureEdit1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(581, 77)
        Me.PanelControl1.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl2.Appearance.Image = Global.Pripyat.My.Resources.Resources.info_16x16
        Me.LabelControl2.Appearance.Options.UseImage = True
        Me.LabelControl2.Location = New System.Drawing.Point(548, 12)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(16, 16)
        ToolTipTitleItem4.Appearance.Image = Global.Pripyat.My.Resources.Resources.info_32x32
        ToolTipTitleItem4.Appearance.Options.UseImage = True
        ToolTipTitleItem4.Image = Global.Pripyat.My.Resources.Resources.info_32x32
        ToolTipTitleItem4.Text = "Для информации"
        ToolTipItem4.LeftIndent = 6
        ToolTipItem4.Text = "УК не имеющая в своем подчинении" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Обслуживающей организации, сама и является ею"
        SuperToolTip4.Items.Add(ToolTipTitleItem4)
        SuperToolTip4.Items.Add(ToolTipItem4)
        Me.LabelControl2.SuperTip = SuperToolTip4
        Me.LabelControl2.TabIndex = 2
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 14.0!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.LabelControl1.Location = New System.Drawing.Point(96, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(374, 46)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Справочник Управляющих и Обслуживающих организаций"
        '
        'PictureEdit1
        '
        Me.PictureEdit1.Cursor = System.Windows.Forms.Cursors.Default
        Me.PictureEdit1.EditValue = Global.Pripyat.My.Resources.Resources.jkh_icon
        Me.PictureEdit1.Location = New System.Drawing.Point(8, 0)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.AllowFocused = False
        Me.PictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PictureEdit1.Properties.Appearance.Options.UseBackColor = True
        Me.PictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.PictureEdit1.Properties.ShowMenu = False
        Me.PictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PictureEdit1.Properties.ZoomAccelerationFactor = 1.0R
        Me.PictureEdit1.Size = New System.Drawing.Size(77, 77)
        Me.PictureEdit1.TabIndex = 0
        '
        'tlGKO
        '
        Me.tlGKO.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.tlGKO.Appearance.HeaderPanel.Options.UseFont = True
        Me.tlGKO.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.tlGKO.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.tlGKO.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.tlGKO.BestFitVisibleOnly = True
        Me.tlGKO.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.tlGKO.Cursor = System.Windows.Forms.Cursors.Default
        Me.tlGKO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlGKO.KeyFieldName = ""
        Me.tlGKO.Location = New System.Drawing.Point(0, 77)
        Me.tlGKO.Name = "tlGKO"
        Me.tlGKO.OptionsBehavior.Editable = False
        Me.tlGKO.OptionsCustomization.AllowColumnMoving = False
        Me.tlGKO.OptionsCustomization.AllowColumnResizing = False
        Me.tlGKO.OptionsCustomization.AllowQuickHideColumns = False
        Me.tlGKO.OptionsCustomization.AllowSort = False
        Me.tlGKO.OptionsFilter.AllowColumnMRUFilterList = False
        Me.tlGKO.OptionsFilter.AllowFilterEditor = False
        Me.tlGKO.OptionsFind.ShowClearButton = False
        Me.tlGKO.OptionsFind.ShowCloseButton = False
        Me.tlGKO.OptionsFind.ShowFindButton = False
        Me.tlGKO.OptionsLayout.AddNewColumns = False
        Me.tlGKO.OptionsMenu.EnableColumnMenu = False
        Me.tlGKO.OptionsMenu.EnableFooterMenu = False
        Me.tlGKO.OptionsMenu.ShowAutoFilterRowItem = False
        Me.tlGKO.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.tlGKO.OptionsSelection.SelectNodesOnRightClick = True
        Me.tlGKO.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFullFocus
        Me.tlGKO.OptionsView.ShowIndicator = False
        Me.tlGKO.ParentFieldName = ""
        Me.tlGKO.Size = New System.Drawing.Size(581, 264)
        Me.tlGKO.TabIndex = 2
        '
        'pmGKO
        '
        Me.pmGKO.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bmiAdd), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Caption, Me.btnEditGKO, "Изменить"), New DevExpress.XtraBars.LinkPersistInfo(Me.btnDeleteGKO), New DevExpress.XtraBars.LinkPersistInfo(Me.btnUpdate)})
        Me.pmGKO.Manager = Me.BarManager
        Me.pmGKO.Name = "pmGKO"
        '
        'bmiAdd
        '
        Me.bmiAdd.Caption = "Добавить"
        Me.bmiAdd.Id = 9
        Me.bmiAdd.ImageOptions.Image = Global.Pripyat.My.Resources.Resources.addfile_16x16
        Me.bmiAdd.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnAddGKO), New DevExpress.XtraBars.LinkPersistInfo(Me.btnAddGKH)})
        Me.bmiAdd.Name = "bmiAdd"
        '
        'btnAddGKO
        '
        Me.btnAddGKO.Caption = "Управляющую организацию"
        Me.btnAddGKO.Id = 10
        Me.btnAddGKO.ImageOptions.Image = Global.Pripyat.My.Resources.Resources.home_16x16
        Me.btnAddGKO.Name = "btnAddGKO"
        '
        'btnAddGKH
        '
        Me.btnAddGKH.Caption = "Обслуживающую организацию"
        Me.btnAddGKH.Id = 11
        Me.btnAddGKH.ImageOptions.Image = Global.Pripyat.My.Resources.Resources.broom_16x16
        Me.btnAddGKH.Name = "btnAddGKH"
        '
        'btnEditGKO
        '
        Me.btnEditGKO.Caption = "Изменить"
        Me.btnEditGKO.Id = 1
        Me.btnEditGKO.ImageOptions.Image = Global.Pripyat.My.Resources.Resources.editfile_16x16
        Me.btnEditGKO.ImageOptions.LargeImage = Global.Pripyat.My.Resources.Resources.Edit_16x16
        Me.btnEditGKO.Name = "btnEditGKO"
        Me.btnEditGKO.ShortcutKeyDisplayString = "Enter"
        '
        'btnDeleteGKO
        '
        Me.btnDeleteGKO.Caption = "Удалить"
        Me.btnDeleteGKO.Id = 2
        Me.btnDeleteGKO.ImageOptions.Image = Global.Pripyat.My.Resources.Resources.deletelist_16x16
        Me.btnDeleteGKO.Name = "btnDeleteGKO"
        Me.btnDeleteGKO.ShortcutKeyDisplayString = "Delete"
        '
        'btnUpdate
        '
        Me.btnUpdate.Caption = "Обновить"
        Me.btnUpdate.Id = 12
        Me.btnUpdate.ImageOptions.Image = Global.Pripyat.My.Resources.Resources.recurrence_16x16
        Me.btnUpdate.ImageOptions.LargeImage = Global.Pripyat.My.Resources.Resources.recurrence_32x32
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.ShortcutKeyDisplayString = "F1"
        '
        'BarManager
        '
        Me.BarManager.AllowShowToolbarsPopup = False
        Me.BarManager.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.DownBar})
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnEditGKO, Me.btnDeleteGKO, Me.bmiAdd, Me.btnAddGKO, Me.btnAddGKH, Me.btnUpdate, Me.lbCreater, Me.lbUpdater})
        Me.BarManager.MaxItemId = 15
        Me.BarManager.StatusBar = Me.DownBar
        '
        'DownBar
        '
        Me.DownBar.BarName = "Строка состояния"
        Me.DownBar.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.DownBar.DockCol = 0
        Me.DownBar.DockRow = 0
        Me.DownBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.DownBar.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.lbCreater), New DevExpress.XtraBars.LinkPersistInfo(Me.lbUpdater)})
        Me.DownBar.OptionsBar.AllowQuickCustomization = False
        Me.DownBar.OptionsBar.AllowRename = True
        Me.DownBar.OptionsBar.DisableClose = True
        Me.DownBar.OptionsBar.DisableCustomization = True
        Me.DownBar.OptionsBar.DrawBorder = False
        Me.DownBar.OptionsBar.DrawDragBorder = False
        Me.DownBar.OptionsBar.DrawSizeGrip = True
        Me.DownBar.OptionsBar.UseWholeRow = True
        Me.DownBar.Text = "Строка состояния"
        '
        'lbCreater
        '
        Me.lbCreater.AllowHtmlText = DevExpress.Utils.DefaultBoolean.[True]
        Me.lbCreater.AutoSize = DevExpress.XtraBars.BarStaticItemSize.Spring
        Me.lbCreater.Id = 13
        Me.lbCreater.ImageOptions.Image = Global.Pripyat.My.Resources.Resources.employee_16x16
        Me.lbCreater.ItemAppearance.Normal.Options.UseTextOptions = True
        Me.lbCreater.ItemAppearance.Normal.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisWord
        Me.lbCreater.Name = "lbCreater"
        Me.lbCreater.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ToolTipItem5.Text = "Автор записи"
        ToolTipTitleItem5.Appearance.Image = Global.Pripyat.My.Resources.Resources.employee_16x16
        ToolTipTitleItem5.Appearance.Options.UseImage = True
        ToolTipTitleItem5.Image = Global.Pripyat.My.Resources.Resources.employee_16x16
        SuperToolTip5.Items.Add(ToolTipItem5)
        SuperToolTip5.Items.Add(ToolTipSeparatorItem2)
        SuperToolTip5.Items.Add(ToolTipTitleItem5)
        Me.lbCreater.SuperTip = SuperToolTip5
        '
        'lbUpdater
        '
        Me.lbUpdater.AllowHtmlText = DevExpress.Utils.DefaultBoolean.[True]
        Me.lbUpdater.AutoSize = DevExpress.XtraBars.BarStaticItemSize.Spring
        Me.lbUpdater.Id = 14
        Me.lbUpdater.ImageOptions.Image = Global.Pripyat.My.Resources.Resources.recurrence_16x16
        Me.lbUpdater.ItemAppearance.Normal.Options.UseTextOptions = True
        Me.lbUpdater.ItemAppearance.Normal.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisWord
        Me.lbUpdater.Name = "lbUpdater"
        Me.lbUpdater.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ToolTipItem6.Text = "Автор изменений"
        ToolTipTitleItem6.Appearance.Image = Global.Pripyat.My.Resources.Resources.recurrence_16x16
        ToolTipTitleItem6.Appearance.Options.UseImage = True
        ToolTipTitleItem6.Image = Global.Pripyat.My.Resources.Resources.recurrence_16x16
        SuperToolTip6.Items.Add(ToolTipItem6)
        SuperToolTip6.Items.Add(ToolTipTitleItem6)
        Me.lbUpdater.SuperTip = SuperToolTip6
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager
        Me.barDockControlTop.Size = New System.Drawing.Size(581, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 341)
        Me.barDockControlBottom.Manager = Me.BarManager
        Me.barDockControlBottom.Size = New System.Drawing.Size(581, 27)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Manager = Me.BarManager
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 341)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(581, 0)
        Me.barDockControlRight.Manager = Me.BarManager
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 341)
        '
        'frBookGKO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(581, 368)
        Me.Controls.Add(Me.tlGKO)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1000, 565)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(587, 396)
        Me.Name = "frBookGKO"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Жилищно-коммунальные организации"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tlGKO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pmGKO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents tlGKO As DevExpress.XtraTreeList.TreeList
    Friend WithEvents pmGKO As DevExpress.XtraBars.PopupMenu
    Friend WithEvents btnEditGKO As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnDeleteGKO As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents bmiAdd As DevExpress.XtraBars.BarSubItem
    Friend WithEvents btnAddGKO As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnAddGKH As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnUpdate As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents DownBar As DevExpress.XtraBars.Bar
    Friend WithEvents lbCreater As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents lbUpdater As DevExpress.XtraBars.BarStaticItem
End Class
