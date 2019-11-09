<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frDocRegistration
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
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip2 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem2 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem2 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip3 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem3 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem3 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip4 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem4 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem4 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip5 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem5 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem5 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip6 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem6 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem6 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frDocRegistration))
        Me.lbRegNumber = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.SeparatorControl1 = New DevExpress.XtraEditors.SeparatorControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.lbSNP_short = New DevExpress.XtraEditors.LabelControl()
        Me.lbAddressString = New DevExpress.XtraEditors.LabelControl()
        Me.TV_JournalList = New DevExpress.XtraTreeList.TreeList()
        Me.btnExpandAll = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCollapseAll = New DevExpress.XtraEditors.SimpleButton()
        Me.btnFindJournal = New DevExpress.XtraEditors.SimpleButton()
        Me.btnOpenJournal = New DevExpress.XtraEditors.SimpleButton()
        Me.btnHideEmptyJournal = New DevExpress.XtraEditors.SimpleButton()
        Me.tlpManager = New System.Windows.Forms.TableLayoutPanel()
        Me.txtAbonentNumber = New DevExpress.XtraEditors.ButtonEdit()
        Me.txtSumDoc = New DevExpress.XtraEditors.SpinEdit()
        Me.btnRegistration = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.btnDeleteLastDocument = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TV_JournalList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpManager.SuspendLayout()
        CType(Me.txtAbonentNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSumDoc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbRegNumber
        '
        Me.lbRegNumber.Appearance.Font = New System.Drawing.Font("Times New Roman", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbRegNumber.Appearance.Options.UseFont = True
        Me.lbRegNumber.Appearance.Options.UseTextOptions = True
        Me.lbRegNumber.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.lbRegNumber.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lbRegNumber.Location = New System.Drawing.Point(352, 70)
        Me.lbRegNumber.Name = "lbRegNumber"
        Me.lbRegNumber.Size = New System.Drawing.Size(307, 19)
        Me.lbRegNumber.TabIndex = 12
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.Location = New System.Drawing.Point(9, 71)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(97, 13)
        Me.LabelControl2.TabIndex = 0
        Me.LabelControl2.Tag = ""
        Me.LabelControl2.Text = "ФИО потребителя:"
        '
        'SeparatorControl1
        '
        Me.SeparatorControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SeparatorControl1.AutoSizeMode = True
        Me.SeparatorControl1.LineAlignment = DevExpress.XtraEditors.Alignment.Far
        Me.SeparatorControl1.Location = New System.Drawing.Point(1, 51)
        Me.SeparatorControl1.Name = "SeparatorControl1"
        Me.SeparatorControl1.Size = New System.Drawing.Size(695, 20)
        Me.SeparatorControl1.TabIndex = 3
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LabelControl3.Appearance.Options.UseFont = True
        Me.LabelControl3.Location = New System.Drawing.Point(9, 96)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(105, 13)
        Me.LabelControl3.TabIndex = 0
        Me.LabelControl3.Tag = ""
        Me.LabelControl3.Text = "Адрес потребителя:"
        '
        'lbSNP_short
        '
        Me.lbSNP_short.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbSNP_short.Appearance.Options.UseFont = True
        Me.lbSNP_short.Location = New System.Drawing.Point(136, 71)
        Me.lbSNP_short.Name = "lbSNP_short"
        Me.lbSNP_short.Size = New System.Drawing.Size(0, 13)
        Me.lbSNP_short.TabIndex = 0
        Me.lbSNP_short.Tag = ""
        '
        'lbAddressString
        '
        Me.lbAddressString.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbAddressString.Appearance.Options.UseFont = True
        Me.lbAddressString.Location = New System.Drawing.Point(136, 96)
        Me.lbAddressString.Name = "lbAddressString"
        Me.lbAddressString.Size = New System.Drawing.Size(0, 13)
        Me.lbAddressString.TabIndex = 0
        Me.lbAddressString.Tag = ""
        '
        'TV_JournalList
        '
        Me.TV_JournalList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TV_JournalList.Appearance.Caption.Font = New System.Drawing.Font("Tahoma", 8.25!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TV_JournalList.Appearance.Caption.Options.UseFont = True
        Me.TV_JournalList.Appearance.Caption.Options.UseTextOptions = True
        Me.TV_JournalList.Appearance.Caption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.TV_JournalList.Caption = "Журналы и типы документов                               "
        Me.TV_JournalList.Location = New System.Drawing.Point(43, 120)
        Me.TV_JournalList.Name = "TV_JournalList"
        Me.TV_JournalList.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.[True]
        Me.TV_JournalList.OptionsBehavior.Editable = False
        Me.TV_JournalList.OptionsBehavior.ResizeNodes = False
        Me.TV_JournalList.OptionsCustomization.AllowBandMoving = False
        Me.TV_JournalList.OptionsCustomization.AllowBandResizing = False
        Me.TV_JournalList.OptionsCustomization.AllowColumnMoving = False
        Me.TV_JournalList.OptionsCustomization.AllowColumnResizing = False
        Me.TV_JournalList.OptionsCustomization.AllowFilter = False
        Me.TV_JournalList.OptionsCustomization.AllowQuickHideColumns = False
        Me.TV_JournalList.OptionsCustomization.AllowSort = False
        Me.TV_JournalList.OptionsFind.AllowFindPanel = False
        Me.TV_JournalList.OptionsFind.AlwaysVisible = True
        Me.TV_JournalList.OptionsLayout.AddNewColumns = False
        Me.TV_JournalList.OptionsMenu.EnableColumnMenu = False
        Me.TV_JournalList.OptionsMenu.EnableFooterMenu = False
        Me.TV_JournalList.OptionsMenu.ShowAutoFilterRowItem = False
        Me.TV_JournalList.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.TV_JournalList.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFullFocus
        Me.TV_JournalList.OptionsView.ShowCaption = True
        Me.TV_JournalList.OptionsView.ShowColumns = False
        Me.TV_JournalList.OptionsView.ShowIndicator = False
        Me.TV_JournalList.OptionsView.ShowVertLines = False
        Me.TV_JournalList.Size = New System.Drawing.Size(645, 370)
        Me.TV_JournalList.TabIndex = 5
        '
        'btnExpandAll
        '
        Me.btnExpandAll.ImageOptions.Image = Global.Pripyat.My.Resources.Resources.remove_32x32
        Me.btnExpandAll.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnExpandAll.Location = New System.Drawing.Point(9, 143)
        Me.btnExpandAll.Name = "btnExpandAll"
        Me.btnExpandAll.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[True]
        Me.btnExpandAll.Size = New System.Drawing.Size(32, 32)
        ToolTipTitleItem1.Appearance.Image = Global.Pripyat.My.Resources.Resources.remove_32x32
        ToolTipTitleItem1.Appearance.Options.UseImage = True
        ToolTipTitleItem1.Image = Global.Pripyat.My.Resources.Resources.remove_32x32
        ToolTipTitleItem1.Text = "Развернуть"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Разверныть все узлы списка"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.btnExpandAll.SuperTip = SuperToolTip1
        Me.btnExpandAll.TabIndex = 6
        '
        'btnCollapseAll
        '
        Me.btnCollapseAll.ImageOptions.Image = Global.Pripyat.My.Resources.Resources.add_32x32
        Me.btnCollapseAll.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnCollapseAll.Location = New System.Drawing.Point(9, 174)
        Me.btnCollapseAll.Name = "btnCollapseAll"
        Me.btnCollapseAll.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[True]
        Me.btnCollapseAll.Size = New System.Drawing.Size(32, 32)
        ToolTipTitleItem2.Appearance.Image = Global.Pripyat.My.Resources.Resources.add_32x32
        ToolTipTitleItem2.Appearance.Options.UseImage = True
        ToolTipTitleItem2.Image = Global.Pripyat.My.Resources.Resources.add_32x32
        ToolTipTitleItem2.Text = "Свернуть "
        ToolTipItem2.LeftIndent = 6
        ToolTipItem2.Text = "Свернуть все узлы списка"
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.btnCollapseAll.SuperTip = SuperToolTip2
        Me.btnCollapseAll.TabIndex = 7
        '
        'btnFindJournal
        '
        Me.btnFindJournal.ImageOptions.Image = Global.Pripyat.My.Resources.Resources.find_32x32
        Me.btnFindJournal.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnFindJournal.Location = New System.Drawing.Point(9, 205)
        Me.btnFindJournal.Name = "btnFindJournal"
        Me.btnFindJournal.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[True]
        Me.btnFindJournal.Size = New System.Drawing.Size(32, 32)
        ToolTipTitleItem3.Appearance.Image = Global.Pripyat.My.Resources.Resources.find_32x32
        ToolTipTitleItem3.Appearance.Options.UseImage = True
        ToolTipTitleItem3.Image = Global.Pripyat.My.Resources.Resources.find_32x32
        ToolTipTitleItem3.Text = "Поиск"
        ToolTipItem3.LeftIndent = 6
        ToolTipItem3.Text = "Показать / Скрыть панель поиска" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "по списку журналов"
        SuperToolTip3.Items.Add(ToolTipTitleItem3)
        SuperToolTip3.Items.Add(ToolTipItem3)
        Me.btnFindJournal.SuperTip = SuperToolTip3
        Me.btnFindJournal.TabIndex = 8
        '
        'btnOpenJournal
        '
        Me.btnOpenJournal.ImageOptions.Image = Global.Pripyat.My.Resources.Resources.article_32x32
        Me.btnOpenJournal.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnOpenJournal.Location = New System.Drawing.Point(9, 236)
        Me.btnOpenJournal.Name = "btnOpenJournal"
        Me.btnOpenJournal.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[True]
        Me.btnOpenJournal.Size = New System.Drawing.Size(32, 32)
        ToolTipTitleItem4.Appearance.Image = Global.Pripyat.My.Resources.Resources.article_32x32
        ToolTipTitleItem4.Appearance.Options.UseImage = True
        ToolTipTitleItem4.Image = Global.Pripyat.My.Resources.Resources.article_32x32
        ToolTipTitleItem4.Text = "Открыть"
        ToolTipItem4.LeftIndent = 6
        ToolTipItem4.Text = "Открыть журнал для просмотра" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "документов"
        SuperToolTip4.Items.Add(ToolTipTitleItem4)
        SuperToolTip4.Items.Add(ToolTipItem4)
        Me.btnOpenJournal.SuperTip = SuperToolTip4
        Me.btnOpenJournal.TabIndex = 9
        '
        'btnHideEmptyJournal
        '
        Me.btnHideEmptyJournal.ImageOptions.Image = Global.Pripyat.My.Resources.Resources.hide_32x32
        Me.btnHideEmptyJournal.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnHideEmptyJournal.Location = New System.Drawing.Point(9, 267)
        Me.btnHideEmptyJournal.Name = "btnHideEmptyJournal"
        Me.btnHideEmptyJournal.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[True]
        Me.btnHideEmptyJournal.Size = New System.Drawing.Size(32, 32)
        ToolTipTitleItem5.Appearance.Image = Global.Pripyat.My.Resources.Resources.showproduct_32x32
        ToolTipTitleItem5.Appearance.Options.UseImage = True
        ToolTipTitleItem5.Image = Global.Pripyat.My.Resources.Resources.showproduct_32x32
        ToolTipTitleItem5.Text = "Скрыть / Показать"
        ToolTipItem5.LeftIndent = 6
        ToolTipItem5.Text = "Скрыть / Показать журналы без" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "назначенных документов"
        SuperToolTip5.Items.Add(ToolTipTitleItem5)
        SuperToolTip5.Items.Add(ToolTipItem5)
        Me.btnHideEmptyJournal.SuperTip = SuperToolTip5
        Me.btnHideEmptyJournal.TabIndex = 10
        '
        'tlpManager
        '
        Me.tlpManager.ColumnCount = 4
        Me.tlpManager.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.tlpManager.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpManager.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpManager.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpManager.Controls.Add(Me.txtAbonentNumber, 1, 1)
        Me.tlpManager.Controls.Add(Me.txtSumDoc, 2, 1)
        Me.tlpManager.Controls.Add(Me.btnRegistration, 3, 1)
        Me.tlpManager.Controls.Add(Me.LabelControl1, 1, 0)
        Me.tlpManager.Controls.Add(Me.LabelControl7, 2, 0)
        Me.tlpManager.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpManager.Location = New System.Drawing.Point(0, 0)
        Me.tlpManager.Name = "tlpManager"
        Me.tlpManager.RowCount = 2
        Me.tlpManager.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpManager.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpManager.Size = New System.Drawing.Size(698, 52)
        Me.tlpManager.TabIndex = 11
        '
        'txtAbonentNumber
        '
        Me.txtAbonentNumber.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtAbonentNumber.EditValue = ""
        Me.txtAbonentNumber.Location = New System.Drawing.Point(13, 22)
        Me.txtAbonentNumber.Name = "txtAbonentNumber"
        Me.txtAbonentNumber.Properties.Appearance.Options.UseTextOptions = True
        Me.txtAbonentNumber.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtAbonentNumber.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search)})
        Me.txtAbonentNumber.Properties.MaxLength = 12
        Me.txtAbonentNumber.Size = New System.Drawing.Size(160, 20)
        Me.txtAbonentNumber.TabIndex = 1
        '
        'txtSumDoc
        '
        Me.txtSumDoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSumDoc.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtSumDoc.EnterMoveNextControl = True
        Me.txtSumDoc.Location = New System.Drawing.Point(179, 22)
        Me.txtSumDoc.Name = "txtSumDoc"
        Me.txtSumDoc.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtSumDoc.Size = New System.Drawing.Size(120, 20)
        Me.txtSumDoc.TabIndex = 2
        '
        'btnRegistration
        '
        Me.btnRegistration.Enabled = False
        Me.btnRegistration.ImageOptions.Image = Global.Pripyat.My.Resources.Resources.addnewdatasource_16x16
        Me.btnRegistration.Location = New System.Drawing.Point(305, 22)
        Me.btnRegistration.Name = "btnRegistration"
        Me.btnRegistration.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[True]
        Me.btnRegistration.Size = New System.Drawing.Size(141, 20)
        Me.btnRegistration.TabIndex = 3
        Me.btnRegistration.Text = "Зарегистрировать"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelControl1.Location = New System.Drawing.Point(13, 3)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(160, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Tag = ""
        Me.LabelControl1.Text = "Номер лицевого счета"
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LabelControl7.Appearance.Options.UseFont = True
        Me.LabelControl7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelControl7.Location = New System.Drawing.Point(179, 3)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(120, 13)
        Me.LabelControl7.TabIndex = 0
        Me.LabelControl7.Tag = ""
        Me.LabelControl7.Text = "Сумма документа"
        '
        'btnDeleteLastDocument
        '
        Me.btnDeleteLastDocument.ImageOptions.Image = Global.Pripyat.My.Resources.Resources.deletelist_16x16
        Me.btnDeleteLastDocument.Location = New System.Drawing.Point(665, 66)
        Me.btnDeleteLastDocument.Name = "btnDeleteLastDocument"
        Me.btnDeleteLastDocument.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[True]
        Me.btnDeleteLastDocument.Size = New System.Drawing.Size(23, 23)
        ToolTipTitleItem6.Appearance.Image = Global.Pripyat.My.Resources.Resources.deletelist_32x32
        ToolTipTitleItem6.Appearance.Options.UseImage = True
        ToolTipTitleItem6.Image = Global.Pripyat.My.Resources.Resources.deletelist_32x32
        ToolTipTitleItem6.Text = "Удаление"
        ToolTipItem6.LeftIndent = 6
        ToolTipItem6.Text = "Удалить из журнала последний " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "зарегистрированный документ," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "начиная с конца по о" & _
    "дному"
        SuperToolTip6.Items.Add(ToolTipTitleItem6)
        SuperToolTip6.Items.Add(ToolTipItem6)
        Me.btnDeleteLastDocument.SuperTip = SuperToolTip6
        Me.btnDeleteLastDocument.TabIndex = 13
        Me.btnDeleteLastDocument.Visible = False
        '
        'frDocRegistration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(698, 502)
        Me.Controls.Add(Me.btnDeleteLastDocument)
        Me.Controls.Add(Me.tlpManager)
        Me.Controls.Add(Me.btnHideEmptyJournal)
        Me.Controls.Add(Me.btnOpenJournal)
        Me.Controls.Add(Me.btnFindJournal)
        Me.Controls.Add(Me.btnCollapseAll)
        Me.Controls.Add(Me.btnExpandAll)
        Me.Controls.Add(Me.TV_JournalList)
        Me.Controls.Add(Me.lbAddressString)
        Me.Controls.Add(Me.lbSNP_short)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.SeparatorControl1)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.lbRegNumber)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(714, 540)
        Me.Name = "frDocRegistration"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Регистрация нового документа"
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TV_JournalList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpManager.ResumeLayout(False)
        Me.tlpManager.PerformLayout()
        CType(Me.txtAbonentNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSumDoc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbRegNumber As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SeparatorControl1 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbSNP_short As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbAddressString As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TV_JournalList As DevExpress.XtraTreeList.TreeList
    Friend WithEvents btnExpandAll As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCollapseAll As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnFindJournal As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnOpenJournal As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnHideEmptyJournal As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tlpManager As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtAbonentNumber As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents txtSumDoc As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents btnRegistration As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnDeleteLastDocument As DevExpress.XtraEditors.SimpleButton
End Class
