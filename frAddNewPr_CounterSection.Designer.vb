<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frAddNewPr_CounterSection
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frAddNewPr_CounterSection))
        Me.gcAbonentList = New DevExpress.XtraGrid.GridControl()
        Me.gvAbonentList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtCounterNumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.lbPointsConnectionCount = New DevExpress.XtraEditors.LabelControl()
        Me.lbPointsCount = New DevExpress.XtraEditors.LabelControl()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.btnOk = New DevExpress.XtraEditors.SimpleButton()
        Me.chbShowConnection = New DevExpress.XtraEditors.CheckButton()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.lbAddressODUHouse = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.txtRoomNumber = New DevExpress.XtraEditors.SpinEdit()
        Me.slueCounterType = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.gvCounterType = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.txtIndicationSetup = New DevExpress.XtraEditors.SpinEdit()
        Me.cmbSchemes = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.txtDtSetup = New DevExpress.XtraEditors.TextEdit()
        CType(Me.gcAbonentList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvAbonentList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCounterNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.txtRoomNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.slueCounterType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvCounterType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIndicationSetup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbSchemes.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDtSetup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gcAbonentList
        '
        Me.gcAbonentList.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gcAbonentList.Location = New System.Drawing.Point(0, 171)
        Me.gcAbonentList.MainView = Me.gvAbonentList
        Me.gcAbonentList.Name = "gcAbonentList"
        Me.gcAbonentList.Size = New System.Drawing.Size(757, 339)
        Me.gcAbonentList.TabIndex = 7
        Me.gcAbonentList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvAbonentList})
        '
        'gvAbonentList
        '
        Me.gvAbonentList.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.gvAbonentList.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gvAbonentList.GridControl = Me.gcAbonentList
        Me.gvAbonentList.Name = "gvAbonentList"
        Me.gvAbonentList.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.[True]
        Me.gvAbonentList.OptionsCustomization.AllowColumnMoving = False
        Me.gvAbonentList.OptionsCustomization.AllowSort = False
        Me.gvAbonentList.OptionsDetail.EnableMasterViewMode = False
        Me.gvAbonentList.OptionsFilter.AllowColumnMRUFilterList = False
        Me.gvAbonentList.OptionsFilter.AllowFilterEditor = False
        Me.gvAbonentList.OptionsFilter.AllowFilterIncrementalSearch = False
        Me.gvAbonentList.OptionsFilter.AllowMRUFilterList = False
        Me.gvAbonentList.OptionsFilter.AllowMultiSelectInCheckedFilterPopup = False
        Me.gvAbonentList.OptionsFilter.ShowAllTableValuesInCheckedFilterPopup = False
        Me.gvAbonentList.OptionsFind.AlwaysVisible = True
        Me.gvAbonentList.OptionsMenu.EnableColumnMenu = False
        Me.gvAbonentList.OptionsMenu.EnableFooterMenu = False
        Me.gvAbonentList.OptionsMenu.EnableGroupPanelMenu = False
        Me.gvAbonentList.OptionsNavigation.EnterMoveNextColumn = True
        Me.gvAbonentList.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.gvAbonentList.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.gvAbonentList.OptionsView.ShowGroupPanel = False
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Underline)
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Location = New System.Drawing.Point(127, 53)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(96, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Тип прибора учета"
        '
        'txtCounterNumber
        '
        Me.txtCounterNumber.EditValue = "000000000"
        Me.txtCounterNumber.EnterMoveNextControl = True
        Me.txtCounterNumber.Location = New System.Drawing.Point(522, 68)
        Me.txtCounterNumber.Name = "txtCounterNumber"
        Me.txtCounterNumber.Properties.MaxLength = 20
        Me.txtCounterNumber.Size = New System.Drawing.Size(223, 20)
        Me.txtCounterNumber.TabIndex = 3
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Underline)
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl2.Location = New System.Drawing.Point(522, 53)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(125, 13)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "Номер прибора учета"
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PanelControl1.Controls.Add(Me.lbPointsConnectionCount)
        Me.PanelControl1.Controls.Add(Me.lbPointsCount)
        Me.PanelControl1.Controls.Add(Me.btnCancel)
        Me.PanelControl1.Controls.Add(Me.btnOk)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 510)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(757, 55)
        Me.PanelControl1.TabIndex = 6
        '
        'lbPointsConnectionCount
        '
        Me.lbPointsConnectionCount.AllowHtmlString = True
        Me.lbPointsConnectionCount.Location = New System.Drawing.Point(15, 24)
        Me.lbPointsConnectionCount.Name = "lbPointsConnectionCount"
        Me.lbPointsConnectionCount.Size = New System.Drawing.Size(66, 13)
        Me.lbPointsConnectionCount.TabIndex = 2
        Me.lbPointsConnectionCount.Text = "LabelControl7"
        '
        'lbPointsCount
        '
        Me.lbPointsCount.AllowHtmlString = True
        Me.lbPointsCount.Location = New System.Drawing.Point(15, 5)
        Me.lbPointsCount.Name = "lbPointsCount"
        Me.lbPointsCount.Size = New System.Drawing.Size(66, 13)
        Me.lbPointsCount.TabIndex = 0
        Me.lbPointsCount.Text = "LabelControl7"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.ImageOptions.Image = Global.Pripyat.My.Resources.Resources.cancel_16x161
        Me.btnCancel.Location = New System.Drawing.Point(670, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Отмена"
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.ImageOptions.Image = Global.Pripyat.My.Resources.Resources.apply_16x162
        Me.btnOk.Location = New System.Drawing.Point(589, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "ОК"
        '
        'chbShowConnection
        '
        Me.chbShowConnection.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chbShowConnection.ImageOptions.Image = Global.Pripyat.My.Resources.Resources.showproduct_16x16
        Me.chbShowConnection.Location = New System.Drawing.Point(549, 183)
        Me.chbShowConnection.Name = "chbShowConnection"
        Me.chbShowConnection.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.chbShowConnection.Size = New System.Drawing.Size(196, 23)
        Me.chbShowConnection.TabIndex = 2
        Me.chbShowConnection.Text = "Показать уже подключенных"
        Me.chbShowConnection.ToolTip = "Показать ТУ уже подключенные к секции"
        Me.chbShowConnection.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Underline)
        Me.LabelControl3.Appearance.Options.UseFont = True
        Me.LabelControl3.Location = New System.Drawing.Point(12, 53)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(82, 13)
        Me.LabelControl3.TabIndex = 7
        Me.LabelControl3.Text = "Дата установки"
        '
        'lbAddressODUHouse
        '
        Me.lbAddressODUHouse.AllowHtmlString = True
        Me.lbAddressODUHouse.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.lbAddressODUHouse.Appearance.Image = Global.Pripyat.My.Resources.Resources.documentmap_32x32
        Me.lbAddressODUHouse.Appearance.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.lbAddressODUHouse.Appearance.Options.UseFont = True
        Me.lbAddressODUHouse.Appearance.Options.UseImage = True
        Me.lbAddressODUHouse.Appearance.Options.UseImageAlign = True
        Me.lbAddressODUHouse.Appearance.Options.UseTextOptions = True
        Me.lbAddressODUHouse.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.lbAddressODUHouse.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lbAddressODUHouse.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.lbAddressODUHouse.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbAddressODUHouse.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        Me.lbAddressODUHouse.Location = New System.Drawing.Point(0, 0)
        Me.lbAddressODUHouse.Name = "lbAddressODUHouse"
        Me.lbAddressODUHouse.Size = New System.Drawing.Size(757, 43)
        Me.lbAddressODUHouse.TabIndex = 0
        Me.lbAddressODUHouse.Text = "<b><i>ПУ для:</b><u>Лесосибирск 7 микрорайон д.1</i></u>"
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Underline)
        Me.LabelControl5.Appearance.Options.UseFont = True
        Me.LabelControl5.Location = New System.Drawing.Point(548, 120)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(134, 13)
        Me.LabelControl5.TabIndex = 0
        Me.LabelControl5.Text = "Номер квартиры (секции):"
        '
        'txtRoomNumber
        '
        Me.txtRoomNumber.EditValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtRoomNumber.EnterMoveNextControl = True
        Me.txtRoomNumber.Location = New System.Drawing.Point(684, 117)
        Me.txtRoomNumber.Name = "txtRoomNumber"
        Me.txtRoomNumber.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtRoomNumber.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.[Default]
        Me.txtRoomNumber.Properties.IsFloatValue = False
        Me.txtRoomNumber.Properties.Mask.EditMask = "N00"
        Me.txtRoomNumber.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.txtRoomNumber.Properties.MaxValue = New Decimal(New Integer() {100, 0, 0, 0})
        Me.txtRoomNumber.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtRoomNumber.Size = New System.Drawing.Size(61, 20)
        Me.txtRoomNumber.TabIndex = 6
        '
        'slueCounterType
        '
        Me.slueCounterType.EnterMoveNextControl = True
        Me.slueCounterType.Location = New System.Drawing.Point(127, 68)
        Me.slueCounterType.Name = "slueCounterType"
        Me.slueCounterType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.slueCounterType.Properties.ShowClearButton = False
        Me.slueCounterType.Properties.View = Me.gvCounterType
        Me.slueCounterType.Size = New System.Drawing.Size(389, 20)
        Me.slueCounterType.TabIndex = 2
        '
        'gvCounterType
        '
        Me.gvCounterType.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.gvCounterType.GroupFormat = "{1} {2}"
        Me.gvCounterType.Name = "gvCounterType"
        Me.gvCounterType.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.[True]
        Me.gvCounterType.OptionsBehavior.Editable = False
        Me.gvCounterType.OptionsCustomization.AllowColumnMoving = False
        Me.gvCounterType.OptionsCustomization.AllowColumnResizing = False
        Me.gvCounterType.OptionsCustomization.AllowSort = False
        Me.gvCounterType.OptionsDetail.EnableMasterViewMode = False
        Me.gvCounterType.OptionsFind.AlwaysVisible = True
        Me.gvCounterType.OptionsFind.ShowClearButton = False
        Me.gvCounterType.OptionsMenu.EnableColumnMenu = False
        Me.gvCounterType.OptionsMenu.EnableFooterMenu = False
        Me.gvCounterType.OptionsMenu.EnableGroupPanelMenu = False
        Me.gvCounterType.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.gvCounterType.OptionsView.ShowGroupPanel = False
        Me.gvCounterType.OptionsView.ShowIndicator = False
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 10.25!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.LabelControl4.Appearance.Options.UseFont = True
        Me.LabelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl4.LineVisible = True
        Me.LabelControl4.Location = New System.Drawing.Point(12, 148)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(733, 22)
        Me.LabelControl4.TabIndex = 11
        Me.LabelControl4.Text = "Список ТУ для подключения к прибору учета секции (квартиры)"
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Underline)
        Me.LabelControl6.Appearance.Options.UseFont = True
        Me.LabelControl6.Location = New System.Drawing.Point(12, 102)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(110, 13)
        Me.LabelControl6.TabIndex = 0
        Me.LabelControl6.Text = "Показания установки"
        '
        'txtIndicationSetup
        '
        Me.txtIndicationSetup.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtIndicationSetup.EnterMoveNextControl = True
        Me.txtIndicationSetup.Location = New System.Drawing.Point(12, 117)
        Me.txtIndicationSetup.Name = "txtIndicationSetup"
        Me.txtIndicationSetup.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.txtIndicationSetup.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.[Default]
        Me.txtIndicationSetup.Properties.IsFloatValue = False
        Me.txtIndicationSetup.Properties.Mask.EditMask = "n0"
        Me.txtIndicationSetup.Size = New System.Drawing.Size(135, 20)
        Me.txtIndicationSetup.TabIndex = 4
        Me.txtIndicationSetup.ToolTip = "Число введенных знаков соответствует" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "значности выбранного прибора учета"
        Me.txtIndicationSetup.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        '
        'cmbSchemes
        '
        Me.cmbSchemes.EnterMoveNextControl = True
        Me.cmbSchemes.Location = New System.Drawing.Point(153, 117)
        Me.cmbSchemes.Name = "cmbSchemes"
        Me.cmbSchemes.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.cmbSchemes.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbSchemes.Properties.DropDownRows = 5
        Me.cmbSchemes.Properties.ShowHeader = False
        Me.cmbSchemes.Size = New System.Drawing.Size(363, 20)
        Me.cmbSchemes.TabIndex = 5
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Underline)
        Me.LabelControl7.Appearance.Options.UseFont = True
        Me.LabelControl7.Location = New System.Drawing.Point(153, 102)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(287, 13)
        Me.LabelControl7.TabIndex = 12
        Me.LabelControl7.Text = "Схема распределения потребления в квартире (секции)"
        '
        'txtDtSetup
        '
        Me.txtDtSetup.Enabled = False
        Me.txtDtSetup.EnterMoveNextControl = True
        Me.txtDtSetup.Location = New System.Drawing.Point(12, 68)
        Me.txtDtSetup.Name = "txtDtSetup"
        Me.txtDtSetup.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.txtDtSetup.Properties.DisplayFormat.FormatString = "d"
        Me.txtDtSetup.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtDtSetup.Properties.EditFormat.FormatString = "d"
        Me.txtDtSetup.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtDtSetup.Properties.Mask.EditMask = "d"
        Me.txtDtSetup.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime
        Me.txtDtSetup.Size = New System.Drawing.Size(109, 20)
        Me.txtDtSetup.TabIndex = 1
        '
        'frAddNewPr_CounterSection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(757, 565)
        Me.Controls.Add(Me.LabelControl7)
        Me.Controls.Add(Me.cmbSchemes)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.chbShowConnection)
        Me.Controls.Add(Me.slueCounterType)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.lbAddressODUHouse)
        Me.Controls.Add(Me.txtCounterNumber)
        Me.Controls.Add(Me.gcAbonentList)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.txtRoomNumber)
        Me.Controls.Add(Me.txtIndicationSetup)
        Me.Controls.Add(Me.txtDtSetup)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1000, 603)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(773, 603)
        Me.Name = "frAddNewPr_CounterSection"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Добавление внутрисекционного прибора учета"
        CType(Me.gcAbonentList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvAbonentList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCounterNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.txtRoomNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.slueCounterType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvCounterType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIndicationSetup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbSchemes.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDtSetup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gcAbonentList As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvAbonentList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtCounterNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbAddressODUHouse As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtRoomNumber As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents slueCounterType As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents gvCounterType As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents chbShowConnection As DevExpress.XtraEditors.CheckButton
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbPointsCount As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtIndicationSetup As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents lbPointsConnectionCount As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbSchemes As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDtSetup As DevExpress.XtraEditors.TextEdit
End Class
