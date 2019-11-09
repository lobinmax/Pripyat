<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frAddNewPr_SectionCharges
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frAddNewPr_SectionCharges))
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.btnOk = New DevExpress.XtraEditors.SimpleButton()
        Me.vgManager = New DevExpress.XtraVerticalGrid.VGridControl()
        Me.lbAddOrEdit = New DevExpress.XtraEditors.LabelControl()
        Me.ImageCol = New DevExpress.Utils.ImageCollection(Me.components)
        Me.rpsNewIndication = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.ctgIndication = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.rowOldIndication = New DevExpress.XtraVerticalGrid.Rows.MultiEditorRow()
        Me.DtDocOld = New DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties()
        Me.OldIndication = New DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties()
        Me.rowNewIndication = New DevExpress.XtraVerticalGrid.Rows.MultiEditorRow()
        Me.DtDocNew = New DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties()
        Me.NewIndication = New DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties()
        Me.Consumption = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.ctgAudit = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.rowDtCreate = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowAuthor = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        CType(Me.vgManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCol, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rpsNewIndication, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.ImageOptions.Image = Global.Pripyat.My.Resources.Resources.cancel_16x161
        Me.btnCancel.Location = New System.Drawing.Point(390, 156)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Отмена"
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.ImageOptions.Image = Global.Pripyat.My.Resources.Resources.apply_16x162
        Me.btnOk.Location = New System.Drawing.Point(309, 156)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 2
        Me.btnOk.Text = "ОК"
        '
        'vgManager
        '
        Me.vgManager.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.vgManager.Cursor = System.Windows.Forms.Cursors.Default
        Me.vgManager.Dock = System.Windows.Forms.DockStyle.Top
        Me.vgManager.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
        Me.vgManager.Location = New System.Drawing.Point(0, 0)
        Me.vgManager.Name = "vgManager"
        Me.vgManager.OptionsBehavior.ResizeRowHeaders = False
        Me.vgManager.OptionsBehavior.ResizeRowValues = False
        Me.vgManager.OptionsBehavior.UseEnterAsTab = True
        Me.vgManager.RecordWidth = 132
        Me.vgManager.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.rpsNewIndication})
        Me.vgManager.RowHeaderWidth = 68
        Me.vgManager.Rows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.ctgIndication, Me.rowOldIndication, Me.rowNewIndication, Me.Consumption, Me.ctgAudit, Me.rowDtCreate, Me.rowAuthor})
        Me.vgManager.Size = New System.Drawing.Size(477, 140)
        Me.vgManager.TabIndex = 4
        Me.vgManager.TreeButtonStyle = DevExpress.XtraVerticalGrid.TreeButtonStyle.ExplorerBar
        '
        'lbAddOrEdit
        '
        Me.lbAddOrEdit.Appearance.ImageIndex = 0
        Me.lbAddOrEdit.Appearance.ImageList = Me.ImageCol
        Me.lbAddOrEdit.Appearance.Options.UseImageIndex = True
        Me.lbAddOrEdit.Appearance.Options.UseImageList = True
        Me.lbAddOrEdit.HtmlImages = Me.ImageCol
        Me.lbAddOrEdit.Location = New System.Drawing.Point(12, 147)
        Me.lbAddOrEdit.Name = "lbAddOrEdit"
        Me.lbAddOrEdit.Size = New System.Drawing.Size(32, 32)
        Me.lbAddOrEdit.TabIndex = 5
        Me.lbAddOrEdit.ToolTip = "Добавить / Изменить"
        '
        'ImageCol
        '
        Me.ImageCol.ImageSize = New System.Drawing.Size(32, 32)
        Me.ImageCol.ImageStream = CType(resources.GetObject("ImageCol.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCol.InsertGalleryImage("additem_32x32.png", "office2013/actions/additem_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/actions/additem_32x32.png"), 0)
        Me.ImageCol.Images.SetKeyName(0, "additem_32x32.png")
        Me.ImageCol.InsertGalleryImage("edit_32x32.png", "office2013/edit/edit_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/edit/edit_32x32.png"), 1)
        Me.ImageCol.Images.SetKeyName(1, "edit_32x32.png")
        '
        'rpsNewIndication
        '
        Me.rpsNewIndication.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.rpsNewIndication.AutoHeight = False
        Me.rpsNewIndication.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.rpsNewIndication.IsFloatValue = False
        Me.rpsNewIndication.Mask.EditMask = "\d{0,9}"
        Me.rpsNewIndication.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.rpsNewIndication.Name = "rpsNewIndication"
        '
        'ctgIndication
        '
        Me.ctgIndication.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.ctgIndication.Appearance.Options.UseFont = True
        Me.ctgIndication.Appearance.Options.UseTextOptions = True
        Me.ctgIndication.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ctgIndication.Name = "ctgIndication"
        Me.ctgIndication.OptionsRow.AllowFocus = False
        Me.ctgIndication.OptionsRow.AllowMove = False
        Me.ctgIndication.OptionsRow.AllowSize = False
        Me.ctgIndication.Properties.AllowEdit = False
        Me.ctgIndication.Properties.Caption = "Параметры показания"
        '
        'rowOldIndication
        '
        Me.rowOldIndication.Name = "rowOldIndication"
        Me.rowOldIndication.OptionsRow.AllowFocus = False
        Me.rowOldIndication.OptionsRow.AllowMove = False
        Me.rowOldIndication.OptionsRow.AllowSize = False
        Me.rowOldIndication.PropertiesCollection.AddRange(New DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties() {Me.DtDocOld, Me.OldIndication})
        '
        'DtDocOld
        '
        Me.DtDocOld.Caption = "Начальные показания"
        Me.DtDocOld.FieldName = "DtDoc"
        '
        'OldIndication
        '
        Me.OldIndication.FieldName = "OldIndication"
        '
        'rowNewIndication
        '
        Me.rowNewIndication.Name = "rowNewIndication"
        Me.rowNewIndication.OptionsRow.AllowMove = False
        Me.rowNewIndication.OptionsRow.AllowMoveToCustomizationForm = False
        Me.rowNewIndication.OptionsRow.AllowSize = False
        Me.rowNewIndication.PropertiesCollection.AddRange(New DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties() {Me.DtDocNew, Me.NewIndication})
        '
        'DtDocNew
        '
        Me.DtDocNew.Caption = "Текущие показания"
        Me.DtDocNew.FieldName = "Now"
        '
        'NewIndication
        '
        Me.NewIndication.FieldName = "NewIndication"
        Me.NewIndication.RowEdit = Me.rpsNewIndication
        '
        'Consumption
        '
        Me.Consumption.Appearance.Options.UseTextOptions = True
        Me.Consumption.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Consumption.Name = "Consumption"
        Me.Consumption.OptionsRow.AllowFocus = False
        Me.Consumption.OptionsRow.AllowMove = False
        Me.Consumption.OptionsRow.AllowMoveToCustomizationForm = False
        Me.Consumption.OptionsRow.AllowSize = False
        Me.Consumption.Properties.Caption = "Расход, кВт*ч"
        Me.Consumption.Properties.FieldName = "Consumption"
        Me.Consumption.Properties.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        '
        'ctgAudit
        '
        Me.ctgAudit.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.ctgAudit.Appearance.Options.UseFont = True
        Me.ctgAudit.Appearance.Options.UseTextOptions = True
        Me.ctgAudit.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ctgAudit.Name = "ctgAudit"
        Me.ctgAudit.OptionsRow.AllowFocus = False
        Me.ctgAudit.OptionsRow.AllowMove = False
        Me.ctgAudit.OptionsRow.AllowMoveToCustomizationForm = False
        Me.ctgAudit.OptionsRow.AllowSize = False
        Me.ctgAudit.Properties.AllowEdit = False
        Me.ctgAudit.Properties.Caption = "Данные аудита"
        '
        'rowDtCreate
        '
        Me.rowDtCreate.Name = "rowDtCreate"
        Me.rowDtCreate.OptionsRow.AllowFocus = False
        Me.rowDtCreate.OptionsRow.AllowMove = False
        Me.rowDtCreate.OptionsRow.AllowMoveToCustomizationForm = False
        Me.rowDtCreate.OptionsRow.AllowSize = False
        Me.rowDtCreate.OptionsRow.DblClickExpanding = False
        Me.rowDtCreate.Properties.Caption = "Дата создания"
        Me.rowDtCreate.Properties.FieldName = "DtCreate"
        '
        'rowAuthor
        '
        Me.rowAuthor.Name = "rowAuthor"
        Me.rowAuthor.OptionsRow.AllowFocus = False
        Me.rowAuthor.OptionsRow.AllowMove = False
        Me.rowAuthor.OptionsRow.AllowMoveToCustomizationForm = False
        Me.rowAuthor.OptionsRow.AllowSize = False
        Me.rowAuthor.Properties.Caption = "Автор записи"
        Me.rowAuthor.Properties.FieldName = "Performer"
        '
        'frAddNewPr_SectionCharges
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(477, 191)
        Me.Controls.Add(Me.lbAddOrEdit)
        Me.Controls.Add(Me.vgManager)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frAddNewPr_SectionCharges"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Снятые показания ПУ"
        CType(Me.vgManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCol, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rpsNewIndication, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents vgManager As DevExpress.XtraVerticalGrid.VGridControl
    Friend WithEvents rpsNewIndication As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents ctgIndication As DevExpress.XtraVerticalGrid.Rows.CategoryRow
    Friend WithEvents rowOldIndication As DevExpress.XtraVerticalGrid.Rows.MultiEditorRow
    Friend WithEvents DtDocOld As DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties
    Friend WithEvents OldIndication As DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties
    Friend WithEvents rowNewIndication As DevExpress.XtraVerticalGrid.Rows.MultiEditorRow
    Friend WithEvents DtDocNew As DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties
    Friend WithEvents NewIndication As DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties
    Friend WithEvents Consumption As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents ctgAudit As DevExpress.XtraVerticalGrid.Rows.CategoryRow
    Friend WithEvents rowDtCreate As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowAuthor As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents lbAddOrEdit As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ImageCol As DevExpress.Utils.ImageCollection
End Class
