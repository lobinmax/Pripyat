<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frBookTSO
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
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim ToolTipSeparatorItem1 As DevExpress.Utils.ToolTipSeparatorItem = New DevExpress.Utils.ToolTipSeparatorItem()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim SuperToolTip2 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipItem2 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim ToolTipSeparatorItem2 As DevExpress.Utils.ToolTipSeparatorItem = New DevExpress.Utils.ToolTipSeparatorItem()
        Dim ToolTipTitleItem2 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frBookTSO))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.pmTSO = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.btnAddTSO = New DevExpress.XtraBars.BarButtonItem()
        Me.btnEditTSO = New DevExpress.XtraBars.BarButtonItem()
        Me.btnDeleteTSO = New DevExpress.XtraBars.BarButtonItem()
        Me.btnUpdate = New DevExpress.XtraBars.BarButtonItem()
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.DownBar = New DevExpress.XtraBars.Bar()
        Me.lbCreater = New DevExpress.XtraBars.BarStaticItem()
        Me.lbUpdater = New DevExpress.XtraBars.BarStaticItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.gcTSO = New DevExpress.XtraGrid.GridControl()
        Me.gvTSO = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pmTSO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcTSO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvTSO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.PictureEdit1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(581, 77)
        Me.PanelControl1.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 14.0!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.LabelControl1.Location = New System.Drawing.Point(102, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(425, 23)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Справочник Сетевых организаций"
        '
        'PictureEdit1
        '
        Me.PictureEdit1.Cursor = System.Windows.Forms.Cursors.Default
        Me.PictureEdit1.EditValue = Global.Pripyat.My.Resources.Resources.tso_60x60
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
        'pmTSO
        '
        Me.pmTSO.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnAddTSO), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Caption, Me.btnEditTSO, "Изменить"), New DevExpress.XtraBars.LinkPersistInfo(Me.btnDeleteTSO), New DevExpress.XtraBars.LinkPersistInfo(Me.btnUpdate)})
        Me.pmTSO.Manager = Me.BarManager
        Me.pmTSO.Name = "pmTSO"
        '
        'btnAddTSO
        '
        Me.btnAddTSO.Caption = "Добавить"
        Me.btnAddTSO.Id = 13
        Me.btnAddTSO.ImageOptions.Image = Global.Pripyat.My.Resources.Resources.addfile_16x16
        Me.btnAddTSO.Name = "btnAddTSO"
        '
        'btnEditTSO
        '
        Me.btnEditTSO.Caption = "Изменить"
        Me.btnEditTSO.Id = 1
        Me.btnEditTSO.ImageOptions.Image = Global.Pripyat.My.Resources.Resources.editfile_16x16
        Me.btnEditTSO.ImageOptions.LargeImage = Global.Pripyat.My.Resources.Resources.Edit_16x16
        Me.btnEditTSO.Name = "btnEditTSO"
        Me.btnEditTSO.ShortcutKeyDisplayString = "Enter"
        '
        'btnDeleteTSO
        '
        Me.btnDeleteTSO.Caption = "Удалить"
        Me.btnDeleteTSO.Id = 2
        Me.btnDeleteTSO.ImageOptions.Image = Global.Pripyat.My.Resources.Resources.deletelist_16x16
        Me.btnDeleteTSO.Name = "btnDeleteTSO"
        Me.btnDeleteTSO.ShortcutKeyDisplayString = "Delete"
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
        Me.BarManager.AllowCustomization = False
        Me.BarManager.AllowHtmlText = True
        Me.BarManager.AllowQuickCustomization = False
        Me.BarManager.AllowShowToolbarsPopup = False
        Me.BarManager.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.DownBar})
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnEditTSO, Me.btnDeleteTSO, Me.btnUpdate, Me.btnAddTSO, Me.lbCreater, Me.lbUpdater})
        Me.BarManager.MaxItemId = 18
        Me.BarManager.StatusBar = Me.DownBar
        '
        'DownBar
        '
        Me.DownBar.BarName = "Строка состояния"
        Me.DownBar.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.DownBar.DockCol = 0
        Me.DownBar.DockRow = 0
        Me.DownBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.DownBar.HideWhenMerging = DevExpress.Utils.DefaultBoolean.[False]
        Me.DownBar.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.lbCreater), New DevExpress.XtraBars.LinkPersistInfo(Me.lbUpdater)})
        Me.DownBar.OptionsBar.AllowQuickCustomization = False
        Me.DownBar.OptionsBar.DisableClose = True
        Me.DownBar.OptionsBar.DisableCustomization = True
        Me.DownBar.OptionsBar.DrawBorder = False
        Me.DownBar.OptionsBar.DrawDragBorder = False
        Me.DownBar.OptionsBar.DrawSizeGrip = True
        Me.DownBar.OptionsBar.RotateWhenVertical = False
        Me.DownBar.OptionsBar.UseWholeRow = True
        Me.DownBar.Text = "Строка состояния"
        '
        'lbCreater
        '
        Me.lbCreater.AllowHtmlText = DevExpress.Utils.DefaultBoolean.[True]
        Me.lbCreater.AutoSize = DevExpress.XtraBars.BarStaticItemSize.Spring
        Me.lbCreater.Id = 16
        Me.lbCreater.ImageOptions.Image = Global.Pripyat.My.Resources.Resources.employee_16x161
        Me.lbCreater.ImageOptions.LargeImage = Global.Pripyat.My.Resources.Resources.employee_32x321
        Me.lbCreater.ItemAppearance.Normal.Options.UseTextOptions = True
        Me.lbCreater.ItemAppearance.Normal.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisWord
        Me.lbCreater.Name = "lbCreater"
        Me.lbCreater.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        SuperToolTip1.AllowHtmlText = DevExpress.Utils.DefaultBoolean.[True]
        ToolTipItem1.Text = "Автор записи"
        ToolTipTitleItem1.Appearance.Image = Global.Pripyat.My.Resources.Resources.employee_16x16
        ToolTipTitleItem1.Appearance.Options.UseImage = True
        ToolTipTitleItem1.Image = Global.Pripyat.My.Resources.Resources.employee_16x16
        SuperToolTip1.Items.Add(ToolTipItem1)
        SuperToolTip1.Items.Add(ToolTipSeparatorItem1)
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        Me.lbCreater.SuperTip = SuperToolTip1
        '
        'lbUpdater
        '
        Me.lbUpdater.AllowHtmlText = DevExpress.Utils.DefaultBoolean.[True]
        Me.lbUpdater.AutoSize = DevExpress.XtraBars.BarStaticItemSize.Spring
        Me.lbUpdater.Id = 17
        Me.lbUpdater.ImageOptions.Image = Global.Pripyat.My.Resources.Resources.recurrence_16x161
        Me.lbUpdater.ImageOptions.LargeImage = Global.Pripyat.My.Resources.Resources.recurrence_32x321
        Me.lbUpdater.ItemAppearance.Normal.Options.UseTextOptions = True
        Me.lbUpdater.ItemAppearance.Normal.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisWord
        Me.lbUpdater.Name = "lbUpdater"
        Me.lbUpdater.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ToolTipItem2.Text = "Автор изменений"
        ToolTipTitleItem2.Appearance.Image = Global.Pripyat.My.Resources.Resources.recurrence_16x16
        ToolTipTitleItem2.Appearance.Options.UseImage = True
        ToolTipTitleItem2.Image = Global.Pripyat.My.Resources.Resources.recurrence_16x16
        SuperToolTip2.Items.Add(ToolTipItem2)
        SuperToolTip2.Items.Add(ToolTipSeparatorItem2)
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        Me.lbUpdater.SuperTip = SuperToolTip2
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
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 331)
        Me.barDockControlBottom.Manager = Me.BarManager
        Me.barDockControlBottom.Size = New System.Drawing.Size(581, 27)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Manager = Me.BarManager
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 331)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(581, 0)
        Me.barDockControlRight.Manager = Me.BarManager
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 331)
        '
        'gcTSO
        '
        Me.gcTSO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcTSO.Location = New System.Drawing.Point(0, 77)
        Me.gcTSO.MainView = Me.gvTSO
        Me.gcTSO.MenuManager = Me.BarManager
        Me.gcTSO.Name = "gcTSO"
        Me.gcTSO.Size = New System.Drawing.Size(581, 254)
        Me.gcTSO.TabIndex = 7
        Me.gcTSO.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvTSO})
        '
        'gvTSO
        '
        Me.gvTSO.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.gvTSO.Appearance.HeaderPanel.Options.UseFont = True
        Me.gvTSO.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.gvTSO.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gvTSO.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.gvTSO.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.gvTSO.GridControl = Me.gcTSO
        Me.gvTSO.Name = "gvTSO"
        Me.gvTSO.OptionsBehavior.Editable = False
        Me.gvTSO.OptionsCustomization.AllowColumnMoving = False
        Me.gvTSO.OptionsCustomization.AllowSort = False
        Me.gvTSO.OptionsMenu.EnableColumnMenu = False
        Me.gvTSO.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.gvTSO.OptionsView.ShowGroupPanel = False
        '
        'frBookTSO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(581, 358)
        Me.Controls.Add(Me.gcTSO)
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
        Me.MinimumSize = New System.Drawing.Size(587, 386)
        Me.Name = "frBookTSO"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Сетевые организации"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pmTSO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcTSO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvTSO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents pmTSO As DevExpress.XtraBars.PopupMenu
    Friend WithEvents btnEditTSO As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnDeleteTSO As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents btnUpdate As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents gcTSO As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvTSO As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnAddTSO As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents DownBar As DevExpress.XtraBars.Bar
    Friend WithEvents lbCreater As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents lbUpdater As DevExpress.XtraBars.BarStaticItem
End Class
