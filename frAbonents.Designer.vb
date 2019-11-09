<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frAbonents
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frAbonents))
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Члены семьи")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Общая информация (ПК Квазар)", New System.Windows.Forms.TreeNode() {TreeNode1})
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Электроэнергия")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Капитальный ремонт")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("События ДЗ", New System.Windows.Forms.TreeNode() {TreeNode3, TreeNode4})
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Иски")
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Запросы Суд и ССП")
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Удержания и оплаты")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Реструктуризация")
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Рейды с ССП")
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Розыск")
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Списание")
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Электроэнергия", New System.Windows.Forms.TreeNode() {TreeNode6, TreeNode7, TreeNode8, TreeNode9, TreeNode10, TreeNode11, TreeNode12})
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Иски")
        Dim TreeNode15 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Запросы Суд и ССП")
        Dim TreeNode16 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Удержания и оплаты")
        Dim TreeNode17 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Реструктуризация")
        Dim TreeNode18 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Рейды с ССП")
        Dim TreeNode19 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Розыск")
        Dim TreeNode20 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Списание")
        Dim TreeNode21 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Капитальный ремонт", New System.Windows.Forms.TreeNode() {TreeNode14, TreeNode15, TreeNode16, TreeNode17, TreeNode18, TreeNode19, TreeNode20})
        Dim TreeNode22 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Иски")
        Dim TreeNode23 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Запросы Суд и ССП")
        Dim TreeNode24 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Удержания и оплаты")
        Dim TreeNode25 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Реструктуризация")
        Dim TreeNode26 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Рейды с ССП")
        Dim TreeNode27 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Розыск")
        Dim TreeNode28 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Списание")
        Dim TreeNode29 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("ЖКХ", New System.Windows.Forms.TreeNode() {TreeNode22, TreeNode23, TreeNode24, TreeNode25, TreeNode26, TreeNode27, TreeNode28})
        Dim TreeNode30 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("ПИР", New System.Windows.Forms.TreeNode() {TreeNode13, TreeNode21, TreeNode29})
        Dim TreeNode31 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Абонент ()", New System.Windows.Forms.TreeNode() {TreeNode2, TreeNode5, TreeNode30})
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txt_AbonNumber = New System.Windows.Forms.TextBox()
        Me.txt_Adress = New System.Windows.Forms.TextBox()
        Me.txt_FIO = New System.Windows.Forms.TextBox()
        Me.ContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CreateMember = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewMember = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveMember = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.NotifyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStrip_Search = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip_DemandTSO = New System.Windows.Forms.ToolStripButton()
        Me.Time_NoteResize = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.Processing = New System.Windows.Forms.ToolStripStatusLabel()
        Me.RecordSetInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SplitContainer = New System.Windows.Forms.SplitContainer()
        Me.Txt_HoteNote = New System.Windows.Forms.TextBox()
        Me.TreeView = New System.Windows.Forms.TreeView()
        Me.MainTabControl = New System.Windows.Forms.TabControl()
        Me.AbonentNum = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.DataGrid_AbonStatusHistory = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btn_ClearPhoneNumber = New System.Windows.Forms.Button()
        Me.btn_ClearMobileNumber = New System.Windows.Forms.Button()
        Me.btn_ClearEmail = New System.Windows.Forms.Button()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.txt_PhoneNumber = New System.Windows.Forms.MaskedTextBox()
        Me.txt_MobileNumber = New System.Windows.Forms.MaskedTextBox()
        Me.txt_Controler = New System.Windows.Forms.TextBox()
        Me.txt_mail = New System.Windows.Forms.TextBox()
        Me.txt_ChiefControler = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btn_ClearAltAdress = New System.Windows.Forms.Button()
        Me.btn_EditAltAdress = New System.Windows.Forms.Button()
        Me.cmb_Route = New System.Windows.Forms.ComboBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txt_AltAdress = New System.Windows.Forms.TextBox()
        Me.cmb_RoomType = New System.Windows.Forms.ComboBox()
        Me.txt_RoomNumber = New System.Windows.Forms.TextBox()
        Me.txt_LetterRoom = New System.Windows.Forms.TextBox()
        Me.txt_Room = New System.Windows.Forms.TextBox()
        Me.txt_Section = New System.Windows.Forms.TextBox()
        Me.txt_Build = New System.Windows.Forms.TextBox()
        Me.txt_LetterHouse = New System.Windows.Forms.TextBox()
        Me.txt_House = New System.Windows.Forms.TextBox()
        Me.btn_EditAdress = New System.Windows.Forms.Button()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txt_PostalIndex = New System.Windows.Forms.MaskedTextBox()
        Me.txt_AdressPart = New System.Windows.Forms.TextBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.PictBox_AbonentNum = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GeneralInfo = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.DataGrid_FamilyMember = New System.Windows.Forms.DataGridView()
        Me.PropertyGrid_GenInfo = New System.Windows.Forms.PropertyGrid()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PictBox_GeneralInfo = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Members = New System.Windows.Forms.TabPage()
        Me.GrBox_CurrentMember = New System.Windows.Forms.GroupBox()
        Me.btn_CalDtUnResidence = New System.Windows.Forms.DateTimePicker()
        Me.btn_CalDtResidence = New System.Windows.Forms.DateTimePicker()
        Me.txt_DtResidence = New System.Windows.Forms.MaskedTextBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.сmb_FamilyRole = New System.Windows.Forms.ComboBox()
        Me.txt_NoteMember = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.txt_AddressOfLive = New System.Windows.Forms.TextBox()
        Me.txt_Residence = New System.Windows.Forms.TextBox()
        Me.ckb_ShareOwner = New System.Windows.Forms.CheckBox()
        Me.Lab_CriterialSearch = New System.Windows.Forms.Label()
        Me.txt_Patronymic = New System.Windows.Forms.TextBox()
        Me.txt_Name = New System.Windows.Forms.TextBox()
        Me.txt_Surname = New System.Windows.Forms.TextBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.txt_MemEmail = New System.Windows.Forms.MaskedTextBox()
        Me.txt_MemPhoneMobile = New System.Windows.Forms.MaskedTextBox()
        Me.txt_PlaceOfWork = New System.Windows.Forms.TextBox()
        Me.cmb_SexMember = New System.Windows.Forms.ComboBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.lab_Update = New System.Windows.Forms.Label()
        Me.txt_DtUnResidence = New System.Windows.Forms.MaskedTextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btn_CalPDDateOfIssue = New System.Windows.Forms.DateTimePicker()
        Me.btn_CalPDDateOfBirth = New System.Windows.Forms.DateTimePicker()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.btn_ClearPD = New System.Windows.Forms.Button()
        Me.txt_PDSubunitCode = New System.Windows.Forms.MaskedTextBox()
        Me.txt_PDSubunit = New System.Windows.Forms.TextBox()
        Me.txt_PDNumber = New System.Windows.Forms.MaskedTextBox()
        Me.txt_PDSeries = New System.Windows.Forms.MaskedTextBox()
        Me.txt_PDString = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txt_PDDateOfBirth = New System.Windows.Forms.MaskedTextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txt_PDDateOfIssue = New System.Windows.Forms.MaskedTextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.DGView_PrMembers = New System.Windows.Forms.DataGridView()
        Me.Pan_Members = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.TS_ManagerPrMembers = New System.Windows.Forms.ToolStrip()
        Me.btn_InsertMember = New System.Windows.Forms.ToolStripButton()
        Me.btn_UpdateMember = New System.Windows.Forms.ToolStripButton()
        Me.btn_DeleteMember = New System.Windows.Forms.ToolStripButton()
        Me.PictBox_Members = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.EventsDeb_1 = New System.Windows.Forms.TabPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictBox_EventsDeb_1 = New System.Windows.Forms.PictureBox()
        Me.EventsDeb_5 = New System.Windows.Forms.TabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictBox_EventsDeb_5 = New System.Windows.Forms.PictureBox()
        Me.Suit_1 = New System.Windows.Forms.TabPage()
        Me.PIR1_TabCon = New System.Windows.Forms.TabControl()
        Me.PIR1_TP_PetitionsDebt = New System.Windows.Forms.TabPage()
        Me.Label93 = New System.Windows.Forms.Label()
        Me.btn_CalPIR1_txt_DtDecisionDirection = New System.Windows.Forms.DateTimePicker()
        Me.PIR1_txt_DtDecisionDirection = New System.Windows.Forms.MaskedTextBox()
        Me.btn_CalPIR1_txt_DtClosePetitionDebt = New System.Windows.Forms.DateTimePicker()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.PIR1_cmb_ReasonForEnd = New System.Windows.Forms.ComboBox()
        Me.PIR1_txt_Note = New System.Windows.Forms.TextBox()
        Me.Group_Petition = New System.Windows.Forms.GroupBox()
        Me.btn_CalPIR1_txt_DtDispatch = New System.Windows.Forms.DateTimePicker()
        Me.btn_CalPIR1_txt_DtPetitions = New System.Windows.Forms.DateTimePicker()
        Me.btn_CalPIR1_txt_DtPeriodEnd = New System.Windows.Forms.DateTimePicker()
        Me.btn_CalPIR1_txt_DtPeriodStart = New System.Windows.Forms.DateTimePicker()
        Me.PIR1_cmb_PetitionType = New System.Windows.Forms.TextBox()
        Me.PIR1_cmb_EnergyType = New System.Windows.Forms.TextBox()
        Me.Pic_PayOrders = New System.Windows.Forms.PictureBox()
        Me.Link_PayOrders = New System.Windows.Forms.LinkLabel()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.PIR1_txt_DtDispatch = New System.Windows.Forms.MaskedTextBox()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.PIR1_txt_DtPeriodEnd = New System.Windows.Forms.MaskedTextBox()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.PIR1_txt_GovTax = New System.Windows.Forms.TextBox()
        Me.PIR1_txt_DebtSumm = New System.Windows.Forms.TextBox()
        Me.PIR1_txt_NumberPetition = New System.Windows.Forms.TextBox()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.PIR1_txt_DtPetitions = New System.Windows.Forms.MaskedTextBox()
        Me.PIR1_cmb_CourtType = New System.Windows.Forms.ComboBox()
        Me.PIR1_cmb_JudicialArea = New System.Windows.Forms.ComboBox()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.PIR1_txt_DtPeriodStart = New System.Windows.Forms.MaskedTextBox()
        Me.PIR1_cmb_DecisionDirection = New System.Windows.Forms.ComboBox()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.btn_CalPIR1_txt_DtDtJudicialOrder = New System.Windows.Forms.DateTimePicker()
        Me.PIR1_txt_DealNumber = New System.Windows.Forms.TextBox()
        Me.Label92 = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.btn_CalPIR1_txt_DtDecision = New System.Windows.Forms.DateTimePicker()
        Me.PIR1_txt_DtJudicialOrder = New System.Windows.Forms.MaskedTextBox()
        Me.PIR1_txt_DebtSummAfterDecision = New System.Windows.Forms.TextBox()
        Me.PIR1_txt_DecisionNumber = New System.Windows.Forms.TextBox()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.PIR1_DGView_ListeningHistory = New System.Windows.Forms.DataGridView()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.PIR1_ToolSt_ListeningMeneger = New System.Windows.Forms.ToolStrip()
        Me.PIR1_Btn_AddNewListening = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.PIR1_Btn_EditListening = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.PIR1_Btn_DeleteListening = New System.Windows.Forms.ToolStripButton()
        Me.PIR1_cmb_DecisionType = New System.Windows.Forms.ComboBox()
        Me.PIR1_cmb_DecisionTypeExt = New System.Windows.Forms.ComboBox()
        Me.PIR1_txt_DtDecision = New System.Windows.Forms.MaskedTextBox()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.PIR1_txt_DtClosePetitionDebt = New System.Windows.Forms.MaskedTextBox()
        Me.PIR1_TP_SSPWork = New System.Windows.Forms.TabPage()
        Me.Pan_PetitionControls = New System.Windows.Forms.Panel()
        Me.btn_CalPIR1_txt_DtActImpossibleRecovery = New System.Windows.Forms.DateTimePicker()
        Me.btn_CalPIR1_txt_ExcitementDt = New System.Windows.Forms.DateTimePicker()
        Me.PIR1_cmb_ActImpossibleRecovery = New System.Windows.Forms.ComboBox()
        Me.PIR1_txt_DtActImpossibleRecovery = New System.Windows.Forms.MaskedTextBox()
        Me.PIR1_txt_ExecutiveNumber = New System.Windows.Forms.TextBox()
        Me.Label85 = New System.Windows.Forms.Label()
        Me.Label91 = New System.Windows.Forms.Label()
        Me.Label88 = New System.Windows.Forms.Label()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.Label89 = New System.Windows.Forms.Label()
        Me.Label87 = New System.Windows.Forms.Label()
        Me.PIR1_txt_NotePetition = New System.Windows.Forms.TextBox()
        Me.PIR1_txt_ExcitementDt = New System.Windows.Forms.MaskedTextBox()
        Me.btn_CalPIR1_txt_DtCompletion = New System.Windows.Forms.DateTimePicker()
        Me.PIR1_cmb_CopPerformer = New System.Windows.Forms.ComboBox()
        Me.PIR1_txt_DtCompletion = New System.Windows.Forms.MaskedTextBox()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.Label83 = New System.Windows.Forms.Label()
        Me.Label84 = New System.Windows.Forms.Label()
        Me.PIR1_txt_PetitionSumm = New System.Windows.Forms.TextBox()
        Me.Label86 = New System.Windows.Forms.Label()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.PIR1_ToolSt_PetitionsMeneger = New System.Windows.Forms.ToolStrip()
        Me.PIR1_Btn_AddNewPetition = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.PIR1_Btn_DeletePetition = New System.Windows.Forms.ToolStripButton()
        Me.PIR1_DGView_Petitions = New System.Windows.Forms.DataGridView()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.PIR1_DGView_PetitionsDebt = New System.Windows.Forms.DataGridView()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.PictBox_1_Suit = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PIR1_ToolSt_PetitionsDebtMeneger = New System.Windows.Forms.ToolStrip()
        Me.PIR1_Btn_AddNewPetitionDebt = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.PIR1_Btn_DeletePetitionDebt = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.PIR1_Btn_SavePetitionDebt = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.PIR1_Btn_Filter = New System.Windows.Forms.ToolStripSplitButton()
        Me.ВсеИскиToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ОконченныеToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ВИсполненииToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ПоЧленуСемьиToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmd_TSMenu_FilterMember = New System.Windows.Forms.ToolStripComboBox()
        Me.СписаниеToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PIR1_Btn_Reports = New System.Windows.Forms.ToolStripSplitButton()
        Me.PIR1_Btn_ReportsBlankPetition = New System.Windows.Forms.ToolStripMenuItem()
        Me.РасчетЦеныИскаToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Request_1 = New System.Windows.Forms.TabPage()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.PictBox_1_Request = New System.Windows.Forms.PictureBox()
        Me.Deduction_1 = New System.Windows.Forms.TabPage()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PictBox_1_Deduction = New System.Windows.Forms.PictureBox()
        Me.Guarantee_1 = New System.Windows.Forms.TabPage()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PictBox_1_Guarantee = New System.Windows.Forms.PictureBox()
        Me.Roadstead_1 = New System.Windows.Forms.TabPage()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PictBox_1_Roadstead = New System.Windows.Forms.PictureBox()
        Me.Search_1 = New System.Windows.Forms.TabPage()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.PictBox_1_Search = New System.Windows.Forms.PictureBox()
        Me.Spisanie_1 = New System.Windows.Forms.TabPage()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.PictBox_1_Spisanie = New System.Windows.Forms.PictureBox()
        Me.Suit_5 = New System.Windows.Forms.TabPage()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.PictBox_5_Suit = New System.Windows.Forms.PictureBox()
        Me.Request_5 = New System.Windows.Forms.TabPage()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.PictBox_5_Request = New System.Windows.Forms.PictureBox()
        Me.Deduction_5 = New System.Windows.Forms.TabPage()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.PictBox_5_Deduction = New System.Windows.Forms.PictureBox()
        Me.Guarantee_5 = New System.Windows.Forms.TabPage()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.PictBox_5_Guarantee = New System.Windows.Forms.PictureBox()
        Me.Roadstead_5 = New System.Windows.Forms.TabPage()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.PictBox_5_Roadstead = New System.Windows.Forms.PictureBox()
        Me.Search_5 = New System.Windows.Forms.TabPage()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.PictBox_5_Search = New System.Windows.Forms.PictureBox()
        Me.Spisanie_5 = New System.Windows.Forms.TabPage()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PictBox_5_Spisanie = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.ContextMenu.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        CType(Me.SplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        Me.MainTabControl.SuspendLayout()
        Me.AbonentNum.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DataGrid_AbonStatusHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        CType(Me.PictBox_AbonentNum, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GeneralInfo.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.DataGrid_FamilyMember, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.PictBox_GeneralInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Members.SuspendLayout()
        Me.GrBox_CurrentMember.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGView_PrMembers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.TS_ManagerPrMembers.SuspendLayout()
        CType(Me.PictBox_Members, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EventsDeb_1.SuspendLayout()
        CType(Me.PictBox_EventsDeb_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EventsDeb_5.SuspendLayout()
        CType(Me.PictBox_EventsDeb_5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Suit_1.SuspendLayout()
        Me.PIR1_TabCon.SuspendLayout()
        Me.PIR1_TP_PetitionsDebt.SuspendLayout()
        Me.Group_Petition.SuspendLayout()
        CType(Me.Pic_PayOrders, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        CType(Me.PIR1_DGView_ListeningHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PIR1_ToolSt_ListeningMeneger.SuspendLayout()
        Me.PIR1_TP_SSPWork.SuspendLayout()
        Me.Pan_PetitionControls.SuspendLayout()
        Me.PIR1_ToolSt_PetitionsMeneger.SuspendLayout()
        CType(Me.PIR1_DGView_Petitions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.PIR1_DGView_PetitionsDebt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.PictBox_1_Suit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PIR1_ToolSt_PetitionsDebtMeneger.SuspendLayout()
        Me.Request_1.SuspendLayout()
        CType(Me.PictBox_1_Request, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Deduction_1.SuspendLayout()
        CType(Me.PictBox_1_Deduction, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guarantee_1.SuspendLayout()
        CType(Me.PictBox_1_Guarantee, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Roadstead_1.SuspendLayout()
        CType(Me.PictBox_1_Roadstead, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Search_1.SuspendLayout()
        CType(Me.PictBox_1_Search, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Spisanie_1.SuspendLayout()
        CType(Me.PictBox_1_Spisanie, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Suit_5.SuspendLayout()
        CType(Me.PictBox_5_Suit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Request_5.SuspendLayout()
        CType(Me.PictBox_5_Request, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Deduction_5.SuspendLayout()
        CType(Me.PictBox_5_Deduction, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guarantee_5.SuspendLayout()
        CType(Me.PictBox_5_Guarantee, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Roadstead_5.SuspendLayout()
        CType(Me.PictBox_5_Roadstead, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Search_5.SuspendLayout()
        CType(Me.PictBox_5_Search, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Spisanie_5.SuspendLayout()
        CType(Me.PictBox_5_Spisanie, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.txt_AbonNumber)
        Me.Panel1.Controls.Add(Me.txt_Adress)
        Me.Panel1.Controls.Add(Me.txt_FIO)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1057, 37)
        Me.Panel1.TabIndex = 2
        '
        'txt_AbonNumber
        '
        Me.txt_AbonNumber.BackColor = System.Drawing.SystemColors.Window
        Me.txt_AbonNumber.Font = New System.Drawing.Font("Arial", 10.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txt_AbonNumber.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_AbonNumber.Location = New System.Drawing.Point(8, 6)
        Me.txt_AbonNumber.Name = "txt_AbonNumber"
        Me.txt_AbonNumber.ReadOnly = True
        Me.txt_AbonNumber.Size = New System.Drawing.Size(125, 23)
        Me.txt_AbonNumber.TabIndex = 1
        '
        'txt_Adress
        '
        Me.txt_Adress.BackColor = System.Drawing.SystemColors.Window
        Me.txt_Adress.Font = New System.Drawing.Font("Arial", 10.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.txt_Adress.Location = New System.Drawing.Point(561, 6)
        Me.txt_Adress.Name = "txt_Adress"
        Me.txt_Adress.ReadOnly = True
        Me.txt_Adress.Size = New System.Drawing.Size(479, 23)
        Me.txt_Adress.TabIndex = 3
        '
        'txt_FIO
        '
        Me.txt_FIO.BackColor = System.Drawing.SystemColors.Window
        Me.txt_FIO.Font = New System.Drawing.Font("Arial", 10.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.txt_FIO.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt_FIO.Location = New System.Drawing.Point(139, 6)
        Me.txt_FIO.Name = "txt_FIO"
        Me.txt_FIO.ReadOnly = True
        Me.txt_FIO.Size = New System.Drawing.Size(416, 23)
        Me.txt_FIO.TabIndex = 2
        '
        'ContextMenu
        '
        Me.ContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CreateMember, Me.ViewMember, Me.RemoveMember})
        Me.ContextMenu.Name = "ContextMenu"
        Me.ContextMenu.Size = New System.Drawing.Size(223, 70)
        '
        'CreateMember
        '
        Me.CreateMember.Image = CType(resources.GetObject("CreateMember.Image"), System.Drawing.Image)
        Me.CreateMember.Name = "CreateMember"
        Me.CreateMember.ShortcutKeyDisplayString = "+"
        Me.CreateMember.Size = New System.Drawing.Size(222, 22)
        Me.CreateMember.Text = "Создать запись"
        '
        'ViewMember
        '
        Me.ViewMember.Image = CType(resources.GetObject("ViewMember.Image"), System.Drawing.Image)
        Me.ViewMember.Name = "ViewMember"
        Me.ViewMember.ShortcutKeyDisplayString = "Enter"
        Me.ViewMember.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.ViewMember.Size = New System.Drawing.Size(222, 22)
        Me.ViewMember.Text = "Просмотреть запись"
        '
        'RemoveMember
        '
        Me.RemoveMember.Image = CType(resources.GetObject("RemoveMember.Image"), System.Drawing.Image)
        Me.RemoveMember.Name = "RemoveMember"
        Me.RemoveMember.ShortcutKeyDisplayString = ""
        Me.RemoveMember.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.RemoveMember.Size = New System.Drawing.Size(222, 22)
        Me.RemoveMember.Text = "Удалить запись"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Location = New System.Drawing.Point(4, 182)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(922, 487)
        Me.Panel2.TabIndex = 5
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "розыск_16x16.png")
        Me.ImageList.Images.SetKeyName(1, "списание_16x16.png")
        Me.ImageList.Images.SetKeyName(2, "ЭЭ_16x16.png")
        Me.ImageList.Images.SetKeyName(3, "Check_Mark_16x16.png")
        Me.ImageList.Images.SetKeyName(4, "syd_16x16.png")
        Me.ImageList.Images.SetKeyName(5, "жкх_16x16.jpg")
        Me.ImageList.Images.SetKeyName(6, "запросы_16x16.png")
        Me.ImageList.Images.SetKeyName(7, "иски_16x16.png")
        Me.ImageList.Images.SetKeyName(8, "КР_16x16.png")
        Me.ImageList.Images.SetKeyName(9, "оплаты_16x16.png")
        Me.ImageList.Images.SetKeyName(10, "рассрочка_16x16.png")
        Me.ImageList.Images.SetKeyName(11, "рейд_16x16.jpg")
        Me.ImageList.Images.SetKeyName(12, "Abonent_16x16.png")
        Me.ImageList.Images.SetKeyName(13, "Family_16x16.png")
        Me.ImageList.Images.SetKeyName(14, "Info_16x16.png")
        Me.ImageList.Images.SetKeyName(15, "ДЗ_16x16.png")
        Me.ImageList.Images.SetKeyName(16, "domik_4.jpg")
        Me.ImageList.Images.SetKeyName(17, "metka_16x16.png")
        '
        'NotifyIcon
        '
        Me.NotifyIcon.Text = "Microsoft® Visual Studio® 2010"
        Me.NotifyIcon.Visible = True
        '
        'ToolStrip
        '
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStrip_Search, Me.ToolStrip_DemandTSO})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip.Size = New System.Drawing.Size(1057, 25)
        Me.ToolStrip.TabIndex = 7
        Me.ToolStrip.Text = "ToolStrip1"
        '
        'ToolStrip_Search
        '
        Me.ToolStrip_Search.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrip_Search.Image = CType(resources.GetObject("ToolStrip_Search.Image"), System.Drawing.Image)
        Me.ToolStrip_Search.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrip_Search.Name = "ToolStrip_Search"
        Me.ToolStrip_Search.Size = New System.Drawing.Size(23, 22)
        Me.ToolStrip_Search.Text = "Поиск абонента"
        '
        'ToolStrip_DemandTSO
        '
        Me.ToolStrip_DemandTSO.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrip_DemandTSO.Image = CType(resources.GetObject("ToolStrip_DemandTSO.Image"), System.Drawing.Image)
        Me.ToolStrip_DemandTSO.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrip_DemandTSO.Name = "ToolStrip_DemandTSO"
        Me.ToolStrip_DemandTSO.Size = New System.Drawing.Size(23, 22)
        Me.ToolStrip_DemandTSO.Text = "Заявка в ТСО"
        '
        'Time_NoteResize
        '
        Me.Time_NoteResize.Interval = 1
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Processing, Me.RecordSetInfo})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 674)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(1057, 25)
        Me.StatusStrip.TabIndex = 6
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'Processing
        '
        Me.Processing.AutoSize = False
        Me.Processing.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.Processing.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.Processing.Image = CType(resources.GetObject("Processing.Image"), System.Drawing.Image)
        Me.Processing.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Processing.Name = "Processing"
        Me.Processing.Size = New System.Drawing.Size(250, 20)
        Me.Processing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RecordSetInfo
        '
        Me.RecordSetInfo.AutoSize = False
        Me.RecordSetInfo.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.RecordSetInfo.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.RecordSetInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.RecordSetInfo.Name = "RecordSetInfo"
        Me.RecordSetInfo.Size = New System.Drawing.Size(792, 20)
        Me.RecordSetInfo.Spring = True
        Me.RecordSetInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SplitContainer
        '
        Me.SplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer.Location = New System.Drawing.Point(0, 62)
        Me.SplitContainer.Name = "SplitContainer"
        '
        'SplitContainer.Panel1
        '
        Me.SplitContainer.Panel1.Controls.Add(Me.Txt_HoteNote)
        Me.SplitContainer.Panel1.Controls.Add(Me.TreeView)
        '
        'SplitContainer.Panel2
        '
        Me.SplitContainer.Panel2.Controls.Add(Me.MainTabControl)
        Me.SplitContainer.Size = New System.Drawing.Size(1057, 612)
        Me.SplitContainer.SplitterDistance = 250
        Me.SplitContainer.TabIndex = 8
        '
        'Txt_HoteNote
        '
        Me.Txt_HoteNote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_HoteNote.Location = New System.Drawing.Point(0, 514)
        Me.Txt_HoteNote.Multiline = True
        Me.Txt_HoteNote.Name = "Txt_HoteNote"
        Me.Txt_HoteNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_HoteNote.Size = New System.Drawing.Size(246, 271)
        Me.Txt_HoteNote.TabIndex = 0
        Me.Txt_HoteNote.UseSystemPasswordChar = True
        '
        'TreeView
        '
        Me.TreeView.Cursor = System.Windows.Forms.Cursors.Default
        Me.TreeView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView.HideSelection = False
        Me.TreeView.HotTracking = True
        Me.TreeView.ImageIndex = 0
        Me.TreeView.ImageList = Me.ImageList
        Me.TreeView.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.TreeView.Location = New System.Drawing.Point(0, 0)
        Me.TreeView.Name = "TreeView"
        TreeNode1.ImageKey = "Family_16x16.png"
        TreeNode1.Name = "Members"
        TreeNode1.SelectedImageKey = "Check_Mark_16x16.png"
        TreeNode1.Text = "Члены семьи"
        TreeNode2.ImageKey = "Info_16x16.png"
        TreeNode2.Name = "GeneralInfo"
        TreeNode2.SelectedImageKey = "Check_Mark_16x16.png"
        TreeNode2.Text = "Общая информация (ПК Квазар)"
        TreeNode3.ImageKey = "ЭЭ_16x16.png"
        TreeNode3.Name = "EventsDeb_1"
        TreeNode3.SelectedImageKey = "Check_Mark_16x16.png"
        TreeNode3.Text = "Электроэнергия"
        TreeNode4.ImageKey = "КР_16x16.png"
        TreeNode4.Name = "EventsDeb_5"
        TreeNode4.SelectedImageKey = "Check_Mark_16x16.png"
        TreeNode4.Text = "Капитальный ремонт"
        TreeNode5.ImageKey = "ДЗ_16x16.png"
        TreeNode5.Name = "EventsDeb_1"
        TreeNode5.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        TreeNode5.SelectedImageKey = "Check_Mark_16x16.png"
        TreeNode5.Text = "События ДЗ"
        TreeNode6.ImageKey = "иски_16x16.png"
        TreeNode6.Name = "Suit_1"
        TreeNode6.SelectedImageKey = "Check_Mark_16x16.png"
        TreeNode6.Text = "Иски"
        TreeNode7.ImageKey = "запросы_16x16.png"
        TreeNode7.Name = "Request_1"
        TreeNode7.SelectedImageKey = "Check_Mark_16x16.png"
        TreeNode7.Text = "Запросы Суд и ССП"
        TreeNode8.ImageKey = "оплаты_16x16.png"
        TreeNode8.Name = "Deduction_1"
        TreeNode8.SelectedImageKey = "Check_Mark_16x16.png"
        TreeNode8.Text = "Удержания и оплаты"
        TreeNode9.ImageKey = "рассрочка_16x16.png"
        TreeNode9.Name = "Guarantee_1"
        TreeNode9.SelectedImageKey = "Check_Mark_16x16.png"
        TreeNode9.Text = "Реструктуризация"
        TreeNode10.ImageKey = "рейд_16x16.jpg"
        TreeNode10.Name = "Roadstead_1"
        TreeNode10.SelectedImageKey = "Check_Mark_16x16.png"
        TreeNode10.Text = "Рейды с ССП"
        TreeNode11.ImageKey = "розыск_16x16.png"
        TreeNode11.Name = "Search_1"
        TreeNode11.SelectedImageKey = "Check_Mark_16x16.png"
        TreeNode11.Text = "Розыск"
        TreeNode12.ImageKey = "списание_16x16.png"
        TreeNode12.Name = "Spisanie_1"
        TreeNode12.SelectedImageKey = "Check_Mark_16x16.png"
        TreeNode12.Text = "Списание"
        TreeNode13.ImageKey = "ЭЭ_16x16.png"
        TreeNode13.Name = "Suit_1"
        TreeNode13.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        TreeNode13.SelectedImageKey = "Check_Mark_16x16.png"
        TreeNode13.Text = "Электроэнергия"
        TreeNode14.ImageKey = "иски_16x16.png"
        TreeNode14.Name = "Suit_5"
        TreeNode14.SelectedImageKey = "Check_Mark_16x16.png"
        TreeNode14.Text = "Иски"
        TreeNode15.ImageKey = "запросы_16x16.png"
        TreeNode15.Name = "Request_5"
        TreeNode15.SelectedImageKey = "Check_Mark_16x16.png"
        TreeNode15.Text = "Запросы Суд и ССП"
        TreeNode16.ImageKey = "оплаты_16x16.png"
        TreeNode16.Name = "Deduction_5"
        TreeNode16.SelectedImageKey = "Check_Mark_16x16.png"
        TreeNode16.Text = "Удержания и оплаты"
        TreeNode17.ImageKey = "рассрочка_16x16.png"
        TreeNode17.Name = "Guarantee_5"
        TreeNode17.SelectedImageKey = "Check_Mark_16x16.png"
        TreeNode17.Text = "Реструктуризация"
        TreeNode18.ImageKey = "рейд_16x16.jpg"
        TreeNode18.Name = "Roadstead_5"
        TreeNode18.SelectedImageKey = "Check_Mark_16x16.png"
        TreeNode18.Text = "Рейды с ССП"
        TreeNode19.ImageKey = "розыск_16x16.png"
        TreeNode19.Name = "Search_5"
        TreeNode19.SelectedImageKey = "Check_Mark_16x16.png"
        TreeNode19.Text = "Розыск"
        TreeNode20.ImageKey = "списание_16x16.png"
        TreeNode20.Name = "Spisanie_5"
        TreeNode20.SelectedImageKey = "Check_Mark_16x16.png"
        TreeNode20.Text = "Списание"
        TreeNode21.ImageKey = "КР_16x16.png"
        TreeNode21.Name = "Suit_5"
        TreeNode21.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        TreeNode21.SelectedImageKey = "Check_Mark_16x16.png"
        TreeNode21.Text = "Капитальный ремонт"
        TreeNode22.ImageKey = "иски_16x16.png"
        TreeNode22.Name = "Suit_2"
        TreeNode22.SelectedImageKey = "Check_Mark_16x16.png"
        TreeNode22.Text = "Иски"
        TreeNode23.ImageKey = "запросы_16x16.png"
        TreeNode23.Name = "Request_2"
        TreeNode23.SelectedImageKey = "Check_Mark_16x16.png"
        TreeNode23.Text = "Запросы Суд и ССП"
        TreeNode24.ImageKey = "оплаты_16x16.png"
        TreeNode24.Name = "Deduction_2"
        TreeNode24.SelectedImageKey = "Check_Mark_16x16.png"
        TreeNode24.Text = "Удержания и оплаты"
        TreeNode25.ImageKey = "рассрочка_16x16.png"
        TreeNode25.Name = "Guarantee_2"
        TreeNode25.SelectedImageKey = "Check_Mark_16x16.png"
        TreeNode25.Text = "Реструктуризация"
        TreeNode26.ImageKey = "рейд_16x16.jpg"
        TreeNode26.Name = "Roadstead_2"
        TreeNode26.SelectedImageKey = "Check_Mark_16x16.png"
        TreeNode26.Text = "Рейды с ССП"
        TreeNode27.ImageKey = "розыск_16x16.png"
        TreeNode27.Name = "Search_2"
        TreeNode27.SelectedImageKey = "Check_Mark_16x16.png"
        TreeNode27.Text = "Розыск"
        TreeNode28.ImageKey = "списание_16x16.png"
        TreeNode28.Name = "Spisanie_2"
        TreeNode28.SelectedImageKey = "Check_Mark_16x16.png"
        TreeNode28.Text = "Списание"
        TreeNode29.ImageKey = "жкх_16x16.jpg"
        TreeNode29.Name = "Pir_2"
        TreeNode29.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        TreeNode29.SelectedImageKey = "Check_Mark_16x16.png"
        TreeNode29.Text = "ЖКХ"
        TreeNode30.ImageKey = "syd_16x16.png"
        TreeNode30.Name = "Suit_1"
        TreeNode30.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        TreeNode30.SelectedImageKey = "Check_Mark_16x16.png"
        TreeNode30.Text = "ПИР"
        TreeNode31.Checked = True
        TreeNode31.ImageKey = "Abonent_16x16.png"
        TreeNode31.Name = "AbonentNum"
        TreeNode31.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        TreeNode31.SelectedImageKey = "Check_Mark_16x16.png"
        TreeNode31.Tag = ""
        TreeNode31.Text = "Абонент ()"
        Me.TreeView.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode31})
        Me.TreeView.SelectedImageKey = "Check_Mark_16x16.png"
        Me.TreeView.Size = New System.Drawing.Size(246, 608)
        Me.TreeView.StateImageList = Me.ImageList
        Me.TreeView.TabIndex = 0
        '
        'MainTabControl
        '
        Me.MainTabControl.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.MainTabControl.Controls.Add(Me.AbonentNum)
        Me.MainTabControl.Controls.Add(Me.GeneralInfo)
        Me.MainTabControl.Controls.Add(Me.Members)
        Me.MainTabControl.Controls.Add(Me.EventsDeb_1)
        Me.MainTabControl.Controls.Add(Me.EventsDeb_5)
        Me.MainTabControl.Controls.Add(Me.Suit_1)
        Me.MainTabControl.Controls.Add(Me.Request_1)
        Me.MainTabControl.Controls.Add(Me.Deduction_1)
        Me.MainTabControl.Controls.Add(Me.Guarantee_1)
        Me.MainTabControl.Controls.Add(Me.Roadstead_1)
        Me.MainTabControl.Controls.Add(Me.Search_1)
        Me.MainTabControl.Controls.Add(Me.Spisanie_1)
        Me.MainTabControl.Controls.Add(Me.Suit_5)
        Me.MainTabControl.Controls.Add(Me.Request_5)
        Me.MainTabControl.Controls.Add(Me.Deduction_5)
        Me.MainTabControl.Controls.Add(Me.Guarantee_5)
        Me.MainTabControl.Controls.Add(Me.Roadstead_5)
        Me.MainTabControl.Controls.Add(Me.Search_5)
        Me.MainTabControl.Controls.Add(Me.Spisanie_5)
        Me.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainTabControl.ItemSize = New System.Drawing.Size(30, 20)
        Me.MainTabControl.Location = New System.Drawing.Point(0, 0)
        Me.MainTabControl.Name = "MainTabControl"
        Me.MainTabControl.SelectedIndex = 0
        Me.MainTabControl.Size = New System.Drawing.Size(799, 608)
        Me.MainTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.MainTabControl.TabIndex = 19
        '
        'AbonentNum
        '
        Me.AbonentNum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.AbonentNum.Controls.Add(Me.GroupBox3)
        Me.AbonentNum.Controls.Add(Me.GroupBox2)
        Me.AbonentNum.Controls.Add(Me.GroupBox1)
        Me.AbonentNum.Controls.Add(Me.Panel6)
        Me.AbonentNum.Location = New System.Drawing.Point(4, 24)
        Me.AbonentNum.Name = "AbonentNum"
        Me.AbonentNum.Size = New System.Drawing.Size(791, 580)
        Me.AbonentNum.TabIndex = 0
        Me.AbonentNum.Text = "TabPage1"
        Me.AbonentNum.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupBox3.Controls.Add(Me.DataGrid_AbonStatusHistory)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(0, 385)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(787, 190)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "История абонента"
        '
        'DataGrid_AbonStatusHistory
        '
        Me.DataGrid_AbonStatusHistory.AllowUserToAddRows = False
        Me.DataGrid_AbonStatusHistory.AllowUserToDeleteRows = False
        Me.DataGrid_AbonStatusHistory.AllowUserToResizeRows = False
        Me.DataGrid_AbonStatusHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGrid_AbonStatusHistory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGrid_AbonStatusHistory.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGrid_AbonStatusHistory.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGrid_AbonStatusHistory.ColumnHeadersHeight = 20
        Me.DataGrid_AbonStatusHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGrid_AbonStatusHistory.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGrid_AbonStatusHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGrid_AbonStatusHistory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DataGrid_AbonStatusHistory.Location = New System.Drawing.Point(3, 16)
        Me.DataGrid_AbonStatusHistory.MultiSelect = False
        Me.DataGrid_AbonStatusHistory.Name = "DataGrid_AbonStatusHistory"
        Me.DataGrid_AbonStatusHistory.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGrid_AbonStatusHistory.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGrid_AbonStatusHistory.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
        Me.DataGrid_AbonStatusHistory.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGrid_AbonStatusHistory.RowTemplate.Height = 17
        Me.DataGrid_AbonStatusHistory.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGrid_AbonStatusHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGrid_AbonStatusHistory.Size = New System.Drawing.Size(781, 171)
        Me.DataGrid_AbonStatusHistory.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_ClearPhoneNumber)
        Me.GroupBox2.Controls.Add(Me.btn_ClearMobileNumber)
        Me.GroupBox2.Controls.Add(Me.btn_ClearEmail)
        Me.GroupBox2.Controls.Add(Me.PictureBox4)
        Me.GroupBox2.Controls.Add(Me.PictureBox3)
        Me.GroupBox2.Controls.Add(Me.PictureBox2)
        Me.GroupBox2.Controls.Add(Me.txt_PhoneNumber)
        Me.GroupBox2.Controls.Add(Me.txt_MobileNumber)
        Me.GroupBox2.Controls.Add(Me.txt_Controler)
        Me.GroupBox2.Controls.Add(Me.txt_mail)
        Me.GroupBox2.Controls.Add(Me.txt_ChiefControler)
        Me.GroupBox2.Controls.Add(Me.Label31)
        Me.GroupBox2.Controls.Add(Me.Label30)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 263)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(787, 122)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        '
        'btn_ClearPhoneNumber
        '
        Me.btn_ClearPhoneNumber.BackColor = System.Drawing.Color.Transparent
        Me.btn_ClearPhoneNumber.BackgroundImage = CType(resources.GetObject("btn_ClearPhoneNumber.BackgroundImage"), System.Drawing.Image)
        Me.btn_ClearPhoneNumber.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_ClearPhoneNumber.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btn_ClearPhoneNumber.FlatAppearance.BorderSize = 0
        Me.btn_ClearPhoneNumber.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btn_ClearPhoneNumber.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btn_ClearPhoneNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_ClearPhoneNumber.Location = New System.Drawing.Point(742, 80)
        Me.btn_ClearPhoneNumber.Name = "btn_ClearPhoneNumber"
        Me.btn_ClearPhoneNumber.Size = New System.Drawing.Size(20, 20)
        Me.btn_ClearPhoneNumber.TabIndex = 29
        Me.btn_ClearPhoneNumber.UseVisualStyleBackColor = False
        '
        'btn_ClearMobileNumber
        '
        Me.btn_ClearMobileNumber.BackColor = System.Drawing.Color.Transparent
        Me.btn_ClearMobileNumber.BackgroundImage = CType(resources.GetObject("btn_ClearMobileNumber.BackgroundImage"), System.Drawing.Image)
        Me.btn_ClearMobileNumber.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_ClearMobileNumber.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btn_ClearMobileNumber.FlatAppearance.BorderSize = 0
        Me.btn_ClearMobileNumber.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btn_ClearMobileNumber.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btn_ClearMobileNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_ClearMobileNumber.Location = New System.Drawing.Point(525, 80)
        Me.btn_ClearMobileNumber.Name = "btn_ClearMobileNumber"
        Me.btn_ClearMobileNumber.Size = New System.Drawing.Size(20, 20)
        Me.btn_ClearMobileNumber.TabIndex = 28
        Me.btn_ClearMobileNumber.UseVisualStyleBackColor = False
        '
        'btn_ClearEmail
        '
        Me.btn_ClearEmail.BackColor = System.Drawing.Color.Transparent
        Me.btn_ClearEmail.BackgroundImage = CType(resources.GetObject("btn_ClearEmail.BackgroundImage"), System.Drawing.Image)
        Me.btn_ClearEmail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_ClearEmail.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btn_ClearEmail.FlatAppearance.BorderSize = 0
        Me.btn_ClearEmail.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btn_ClearEmail.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btn_ClearEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_ClearEmail.Location = New System.Drawing.Point(308, 80)
        Me.btn_ClearEmail.Name = "btn_ClearEmail"
        Me.btn_ClearEmail.Size = New System.Drawing.Size(20, 20)
        Me.btn_ClearEmail.TabIndex = 27
        Me.btn_ClearEmail.UseVisualStyleBackColor = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(580, 60)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 9
        Me.PictureBox4.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(363, 60)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 8
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(6, 60)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 7
        Me.PictureBox2.TabStop = False
        '
        'txt_PhoneNumber
        '
        Me.txt_PhoneNumber.Location = New System.Drawing.Point(626, 80)
        Me.txt_PhoneNumber.Mask = "+7 (30000) 0-00-00"
        Me.txt_PhoneNumber.Name = "txt_PhoneNumber"
        Me.txt_PhoneNumber.Size = New System.Drawing.Size(110, 20)
        Me.txt_PhoneNumber.TabIndex = 6
        '
        'txt_MobileNumber
        '
        Me.txt_MobileNumber.Location = New System.Drawing.Point(409, 80)
        Me.txt_MobileNumber.Mask = "7 (000) 000-00-00"
        Me.txt_MobileNumber.Name = "txt_MobileNumber"
        Me.txt_MobileNumber.ResetOnSpace = False
        Me.txt_MobileNumber.Size = New System.Drawing.Size(112, 20)
        Me.txt_MobileNumber.TabIndex = 5
        Me.txt_MobileNumber.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        '
        'txt_Controler
        '
        Me.txt_Controler.BackColor = System.Drawing.SystemColors.Window
        Me.txt_Controler.Location = New System.Drawing.Point(136, 13)
        Me.txt_Controler.Name = "txt_Controler"
        Me.txt_Controler.ReadOnly = True
        Me.txt_Controler.Size = New System.Drawing.Size(250, 20)
        Me.txt_Controler.TabIndex = 4
        Me.txt_Controler.Text = "Самигуллина Рахиля Махаматгалеевна"
        '
        'txt_mail
        '
        Me.txt_mail.Location = New System.Drawing.Point(52, 80)
        Me.txt_mail.Name = "txt_mail"
        Me.txt_mail.Size = New System.Drawing.Size(250, 20)
        Me.txt_mail.TabIndex = 1
        Me.txt_mail.Text = "____________@_____.____"
        '
        'txt_ChiefControler
        '
        Me.txt_ChiefControler.BackColor = System.Drawing.SystemColors.Window
        Me.txt_ChiefControler.Location = New System.Drawing.Point(534, 13)
        Me.txt_ChiefControler.Name = "txt_ChiefControler"
        Me.txt_ChiefControler.ReadOnly = True
        Me.txt_ChiefControler.Size = New System.Drawing.Size(228, 20)
        Me.txt_ChiefControler.TabIndex = 3
        Me.txt_ChiefControler.Text = "Веселов Алексей Николаевич"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label31.Location = New System.Drawing.Point(406, 16)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(124, 13)
        Me.Label31.TabIndex = 2
        Me.Label31.Text = "Старший контролер"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label30.Location = New System.Drawing.Point(3, 16)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(133, 13)
        Me.Label30.TabIndex = 0
        Me.Label30.Text = "Линейный контролер"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label29)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.btn_ClearAltAdress)
        Me.GroupBox1.Controls.Add(Me.btn_EditAltAdress)
        Me.GroupBox1.Controls.Add(Me.cmb_Route)
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.txt_AltAdress)
        Me.GroupBox1.Controls.Add(Me.cmb_RoomType)
        Me.GroupBox1.Controls.Add(Me.txt_RoomNumber)
        Me.GroupBox1.Controls.Add(Me.txt_LetterRoom)
        Me.GroupBox1.Controls.Add(Me.txt_Room)
        Me.GroupBox1.Controls.Add(Me.txt_Section)
        Me.GroupBox1.Controls.Add(Me.txt_Build)
        Me.GroupBox1.Controls.Add(Me.txt_LetterHouse)
        Me.GroupBox1.Controls.Add(Me.txt_House)
        Me.GroupBox1.Controls.Add(Me.btn_EditAdress)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.txt_PostalIndex)
        Me.GroupBox1.Controls.Add(Me.txt_AdressPart)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 55)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(787, 208)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Почтовый адрес"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Red
        Me.Label29.Location = New System.Drawing.Point(3, 189)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(301, 13)
        Me.Label29.TabIndex = 28
        Me.Label29.Text = "Внимание! Сделанные изменения отобразятся в ПК Квазар"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.Control
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(540, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(244, 189)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 27
        Me.PictureBox1.TabStop = False
        '
        'btn_ClearAltAdress
        '
        Me.btn_ClearAltAdress.BackColor = System.Drawing.Color.Transparent
        Me.btn_ClearAltAdress.BackgroundImage = CType(resources.GetObject("btn_ClearAltAdress.BackgroundImage"), System.Drawing.Image)
        Me.btn_ClearAltAdress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_ClearAltAdress.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btn_ClearAltAdress.FlatAppearance.BorderSize = 0
        Me.btn_ClearAltAdress.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btn_ClearAltAdress.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btn_ClearAltAdress.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_ClearAltAdress.Location = New System.Drawing.Point(481, 116)
        Me.btn_ClearAltAdress.Name = "btn_ClearAltAdress"
        Me.btn_ClearAltAdress.Size = New System.Drawing.Size(20, 20)
        Me.btn_ClearAltAdress.TabIndex = 26
        Me.btn_ClearAltAdress.UseVisualStyleBackColor = False
        '
        'btn_EditAltAdress
        '
        Me.btn_EditAltAdress.BackColor = System.Drawing.Color.Transparent
        Me.btn_EditAltAdress.BackgroundImage = CType(resources.GetObject("btn_EditAltAdress.BackgroundImage"), System.Drawing.Image)
        Me.btn_EditAltAdress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_EditAltAdress.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btn_EditAltAdress.FlatAppearance.BorderSize = 0
        Me.btn_EditAltAdress.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btn_EditAltAdress.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btn_EditAltAdress.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_EditAltAdress.Location = New System.Drawing.Point(460, 116)
        Me.btn_EditAltAdress.Name = "btn_EditAltAdress"
        Me.btn_EditAltAdress.Size = New System.Drawing.Size(20, 20)
        Me.btn_EditAltAdress.TabIndex = 25
        Me.btn_EditAltAdress.UseVisualStyleBackColor = False
        '
        'cmb_Route
        '
        Me.cmb_Route.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_Route.FormattingEnabled = True
        Me.cmb_Route.Location = New System.Drawing.Point(368, 167)
        Me.cmb_Route.Name = "cmb_Route"
        Me.cmb_Route.Size = New System.Drawing.Size(160, 21)
        Me.cmb_Route.TabIndex = 24
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label28.Location = New System.Drawing.Point(365, 151)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(163, 13)
        Me.Label28.TabIndex = 23
        Me.Label28.Text = "Маршрут (Специальный адрес)"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label27.Location = New System.Drawing.Point(3, 101)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(176, 13)
        Me.Label27.TabIndex = 21
        Me.Label27.Text = "Альтернативный почтовый адрес"
        '
        'txt_AltAdress
        '
        Me.txt_AltAdress.BackColor = System.Drawing.SystemColors.Window
        Me.txt_AltAdress.Location = New System.Drawing.Point(6, 117)
        Me.txt_AltAdress.Name = "txt_AltAdress"
        Me.txt_AltAdress.ReadOnly = True
        Me.txt_AltAdress.Size = New System.Drawing.Size(453, 20)
        Me.txt_AltAdress.TabIndex = 20
        '
        'cmb_RoomType
        '
        Me.cmb_RoomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_RoomType.FormattingEnabled = True
        Me.cmb_RoomType.Location = New System.Drawing.Point(333, 61)
        Me.cmb_RoomType.Name = "cmb_RoomType"
        Me.cmb_RoomType.Size = New System.Drawing.Size(112, 21)
        Me.cmb_RoomType.TabIndex = 19
        '
        'txt_RoomNumber
        '
        Me.txt_RoomNumber.Location = New System.Drawing.Point(451, 61)
        Me.txt_RoomNumber.MaxLength = 3
        Me.txt_RoomNumber.Name = "txt_RoomNumber"
        Me.txt_RoomNumber.Size = New System.Drawing.Size(51, 20)
        Me.txt_RoomNumber.TabIndex = 18
        Me.txt_RoomNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_LetterRoom
        '
        Me.txt_LetterRoom.Location = New System.Drawing.Point(275, 61)
        Me.txt_LetterRoom.MaxLength = 1
        Me.txt_LetterRoom.Name = "txt_LetterRoom"
        Me.txt_LetterRoom.Size = New System.Drawing.Size(34, 20)
        Me.txt_LetterRoom.TabIndex = 17
        Me.txt_LetterRoom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_Room
        '
        Me.txt_Room.Location = New System.Drawing.Point(205, 61)
        Me.txt_Room.MaxLength = 3
        Me.txt_Room.Name = "txt_Room"
        Me.txt_Room.Size = New System.Drawing.Size(64, 20)
        Me.txt_Room.TabIndex = 16
        Me.txt_Room.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_Section
        '
        Me.txt_Section.Location = New System.Drawing.Point(158, 61)
        Me.txt_Section.MaxLength = 3
        Me.txt_Section.Name = "txt_Section"
        Me.txt_Section.Size = New System.Drawing.Size(41, 20)
        Me.txt_Section.TabIndex = 15
        Me.txt_Section.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_Build
        '
        Me.txt_Build.Location = New System.Drawing.Point(93, 61)
        Me.txt_Build.MaxLength = 3
        Me.txt_Build.Name = "txt_Build"
        Me.txt_Build.Size = New System.Drawing.Size(40, 20)
        Me.txt_Build.TabIndex = 14
        Me.txt_Build.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_LetterHouse
        '
        Me.txt_LetterHouse.Location = New System.Drawing.Point(53, 61)
        Me.txt_LetterHouse.MaxLength = 1
        Me.txt_LetterHouse.Name = "txt_LetterHouse"
        Me.txt_LetterHouse.Size = New System.Drawing.Size(34, 20)
        Me.txt_LetterHouse.TabIndex = 13
        Me.txt_LetterHouse.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_House
        '
        Me.txt_House.Location = New System.Drawing.Point(6, 61)
        Me.txt_House.MaxLength = 4
        Me.txt_House.Name = "txt_House"
        Me.txt_House.Size = New System.Drawing.Size(41, 20)
        Me.txt_House.TabIndex = 12
        Me.txt_House.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btn_EditAdress
        '
        Me.btn_EditAdress.BackColor = System.Drawing.Color.Transparent
        Me.btn_EditAdress.BackgroundImage = CType(resources.GetObject("btn_EditAdress.BackgroundImage"), System.Drawing.Image)
        Me.btn_EditAdress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_EditAdress.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btn_EditAdress.FlatAppearance.BorderSize = 0
        Me.btn_EditAdress.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btn_EditAdress.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btn_EditAdress.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_EditAdress.Location = New System.Drawing.Point(508, 19)
        Me.btn_EditAdress.Name = "btn_EditAdress"
        Me.btn_EditAdress.Size = New System.Drawing.Size(20, 20)
        Me.btn_EditAdress.TabIndex = 11
        Me.btn_EditAdress.UseVisualStyleBackColor = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(330, 45)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(172, 13)
        Me.Label26.TabIndex = 10
        Me.Label26.Text = "Тип и номер жилого помещения"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(272, 45)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(37, 13)
        Me.Label25.TabIndex = 9
        Me.Label25.Text = "Буква"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(202, 45)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(67, 13)
        Me.Label24.TabIndex = 8
        Me.Label24.Text = "№квартиры"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(155, 46)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(44, 13)
        Me.Label23.TabIndex = 7
        Me.Label23.Text = "Секция"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(90, 45)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(43, 13)
        Me.Label22.TabIndex = 6
        Me.Label22.Text = "Корпус"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(50, 45)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(37, 13)
        Me.Label21.TabIndex = 5
        Me.Label21.Text = "Буква"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(3, 45)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(44, 13)
        Me.Label20.TabIndex = 4
        Me.Label20.Text = "№дома"
        '
        'txt_PostalIndex
        '
        Me.txt_PostalIndex.BeepOnError = True
        Me.txt_PostalIndex.Location = New System.Drawing.Point(6, 19)
        Me.txt_PostalIndex.Mask = "000000"
        Me.txt_PostalIndex.Name = "txt_PostalIndex"
        Me.txt_PostalIndex.Size = New System.Drawing.Size(60, 20)
        Me.txt_PostalIndex.TabIndex = 3
        Me.txt_PostalIndex.Text = "662546"
        Me.txt_PostalIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_AdressPart
        '
        Me.txt_AdressPart.BackColor = System.Drawing.SystemColors.Window
        Me.txt_AdressPart.Location = New System.Drawing.Point(72, 19)
        Me.txt_AdressPart.Name = "txt_AdressPart"
        Me.txt_AdressPart.ReadOnly = True
        Me.txt_AdressPart.Size = New System.Drawing.Size(430, 20)
        Me.txt_AdressPart.TabIndex = 2
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.PictBox_AbonentNum)
        Me.Panel6.Controls.Add(Me.Label3)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(787, 55)
        Me.Panel6.TabIndex = 14
        '
        'PictBox_AbonentNum
        '
        Me.PictBox_AbonentNum.BackColor = System.Drawing.Color.Transparent
        Me.PictBox_AbonentNum.Image = CType(resources.GetObject("PictBox_AbonentNum.Image"), System.Drawing.Image)
        Me.PictBox_AbonentNum.Location = New System.Drawing.Point(0, 0)
        Me.PictBox_AbonentNum.Name = "PictBox_AbonentNum"
        Me.PictBox_AbonentNum.Size = New System.Drawing.Size(50, 50)
        Me.PictBox_AbonentNum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictBox_AbonentNum.TabIndex = 9
        Me.PictBox_AbonentNum.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label3.Location = New System.Drawing.Point(57, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Абонент"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GeneralInfo
        '
        Me.GeneralInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GeneralInfo.Controls.Add(Me.GroupBox4)
        Me.GeneralInfo.Controls.Add(Me.PropertyGrid_GenInfo)
        Me.GeneralInfo.Controls.Add(Me.Panel3)
        Me.GeneralInfo.Location = New System.Drawing.Point(4, 24)
        Me.GeneralInfo.Name = "GeneralInfo"
        Me.GeneralInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.GeneralInfo.Size = New System.Drawing.Size(791, 580)
        Me.GeneralInfo.TabIndex = 1
        Me.GeneralInfo.Text = "TabPage2"
        Me.GeneralInfo.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.DataGrid_FamilyMember)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox4.Location = New System.Drawing.Point(3, 395)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(781, 180)
        Me.GroupBox4.TabIndex = 9
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Члены семьи по данным ПК Квазар"
        '
        'DataGrid_FamilyMember
        '
        Me.DataGrid_FamilyMember.AllowUserToAddRows = False
        Me.DataGrid_FamilyMember.AllowUserToDeleteRows = False
        Me.DataGrid_FamilyMember.AllowUserToResizeRows = False
        Me.DataGrid_FamilyMember.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGrid_FamilyMember.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGrid_FamilyMember.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGrid_FamilyMember.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGrid_FamilyMember.ColumnHeadersHeight = 20
        Me.DataGrid_FamilyMember.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGrid_FamilyMember.ContextMenuStrip = Me.ContextMenu
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGrid_FamilyMember.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGrid_FamilyMember.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGrid_FamilyMember.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DataGrid_FamilyMember.Location = New System.Drawing.Point(3, 16)
        Me.DataGrid_FamilyMember.MultiSelect = False
        Me.DataGrid_FamilyMember.Name = "DataGrid_FamilyMember"
        Me.DataGrid_FamilyMember.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGrid_FamilyMember.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGrid_FamilyMember.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
        Me.DataGrid_FamilyMember.RowTemplate.Height = 18
        Me.DataGrid_FamilyMember.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGrid_FamilyMember.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGrid_FamilyMember.Size = New System.Drawing.Size(775, 161)
        Me.DataGrid_FamilyMember.TabIndex = 0
        '
        'PropertyGrid_GenInfo
        '
        Me.PropertyGrid_GenInfo.BackColor = System.Drawing.SystemColors.Control
        Me.PropertyGrid_GenInfo.CategoryForeColor = System.Drawing.Color.Black
        Me.PropertyGrid_GenInfo.CommandsActiveLinkColor = System.Drawing.Color.Red
        Me.PropertyGrid_GenInfo.CommandsDisabledLinkColor = System.Drawing.Color.DimGray
        Me.PropertyGrid_GenInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.PropertyGrid_GenInfo.Location = New System.Drawing.Point(3, 59)
        Me.PropertyGrid_GenInfo.Name = "PropertyGrid_GenInfo"
        Me.PropertyGrid_GenInfo.PropertySort = System.Windows.Forms.PropertySort.Categorized
        Me.PropertyGrid_GenInfo.Size = New System.Drawing.Size(781, 336)
        Me.PropertyGrid_GenInfo.TabIndex = 8
        Me.PropertyGrid_GenInfo.ToolbarVisible = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.PictBox_GeneralInfo)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(781, 56)
        Me.Panel3.TabIndex = 10
        '
        'PictBox_GeneralInfo
        '
        Me.PictBox_GeneralInfo.BackColor = System.Drawing.Color.Transparent
        Me.PictBox_GeneralInfo.Image = CType(resources.GetObject("PictBox_GeneralInfo.Image"), System.Drawing.Image)
        Me.PictBox_GeneralInfo.Location = New System.Drawing.Point(0, 0)
        Me.PictBox_GeneralInfo.Name = "PictBox_GeneralInfo"
        Me.PictBox_GeneralInfo.Size = New System.Drawing.Size(50, 50)
        Me.PictBox_GeneralInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictBox_GeneralInfo.TabIndex = 6
        Me.PictBox_GeneralInfo.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label1.Location = New System.Drawing.Point(60, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 16)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Общая информация"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Members
        '
        Me.Members.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Members.Controls.Add(Me.GrBox_CurrentMember)
        Me.Members.Controls.Add(Me.DGView_PrMembers)
        Me.Members.Controls.Add(Me.Pan_Members)
        Me.Members.Controls.Add(Me.Panel5)
        Me.Members.Location = New System.Drawing.Point(4, 24)
        Me.Members.Name = "Members"
        Me.Members.Padding = New System.Windows.Forms.Padding(3)
        Me.Members.Size = New System.Drawing.Size(791, 580)
        Me.Members.TabIndex = 2
        Me.Members.Text = "TabPage3"
        Me.Members.UseVisualStyleBackColor = True
        '
        'GrBox_CurrentMember
        '
        Me.GrBox_CurrentMember.Controls.Add(Me.btn_CalDtUnResidence)
        Me.GrBox_CurrentMember.Controls.Add(Me.btn_CalDtResidence)
        Me.GrBox_CurrentMember.Controls.Add(Me.txt_DtResidence)
        Me.GrBox_CurrentMember.Controls.Add(Me.Label48)
        Me.GrBox_CurrentMember.Controls.Add(Me.сmb_FamilyRole)
        Me.GrBox_CurrentMember.Controls.Add(Me.txt_NoteMember)
        Me.GrBox_CurrentMember.Controls.Add(Me.Label41)
        Me.GrBox_CurrentMember.Controls.Add(Me.txt_AddressOfLive)
        Me.GrBox_CurrentMember.Controls.Add(Me.txt_Residence)
        Me.GrBox_CurrentMember.Controls.Add(Me.ckb_ShareOwner)
        Me.GrBox_CurrentMember.Controls.Add(Me.Lab_CriterialSearch)
        Me.GrBox_CurrentMember.Controls.Add(Me.txt_Patronymic)
        Me.GrBox_CurrentMember.Controls.Add(Me.txt_Name)
        Me.GrBox_CurrentMember.Controls.Add(Me.txt_Surname)
        Me.GrBox_CurrentMember.Controls.Add(Me.GroupBox7)
        Me.GrBox_CurrentMember.Controls.Add(Me.cmb_SexMember)
        Me.GrBox_CurrentMember.Controls.Add(Me.Label43)
        Me.GrBox_CurrentMember.Controls.Add(Me.Label45)
        Me.GrBox_CurrentMember.Controls.Add(Me.Label44)
        Me.GrBox_CurrentMember.Controls.Add(Me.Label46)
        Me.GrBox_CurrentMember.Controls.Add(Me.Label39)
        Me.GrBox_CurrentMember.Controls.Add(Me.Label47)
        Me.GrBox_CurrentMember.Controls.Add(Me.lab_Update)
        Me.GrBox_CurrentMember.Controls.Add(Me.txt_DtUnResidence)
        Me.GrBox_CurrentMember.Controls.Add(Me.Label40)
        Me.GrBox_CurrentMember.Controls.Add(Me.GroupBox5)
        Me.GrBox_CurrentMember.Controls.Add(Me.Label50)
        Me.GrBox_CurrentMember.Controls.Add(Me.Label49)
        Me.GrBox_CurrentMember.Controls.Add(Me.Label42)
        Me.GrBox_CurrentMember.Dock = System.Windows.Forms.DockStyle.Top
        Me.GrBox_CurrentMember.Location = New System.Drawing.Point(3, 159)
        Me.GrBox_CurrentMember.Name = "GrBox_CurrentMember"
        Me.GrBox_CurrentMember.Size = New System.Drawing.Size(781, 411)
        Me.GrBox_CurrentMember.TabIndex = 9
        Me.GrBox_CurrentMember.TabStop = False
        Me.GrBox_CurrentMember.Text = "Данные члена семьи"
        '
        'btn_CalDtUnResidence
        '
        Me.btn_CalDtUnResidence.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.btn_CalDtUnResidence.Location = New System.Drawing.Point(381, 46)
        Me.btn_CalDtUnResidence.Name = "btn_CalDtUnResidence"
        Me.btn_CalDtUnResidence.Size = New System.Drawing.Size(20, 20)
        Me.btn_CalDtUnResidence.TabIndex = 109
        '
        'btn_CalDtResidence
        '
        Me.btn_CalDtResidence.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.btn_CalDtResidence.Location = New System.Drawing.Point(381, 26)
        Me.btn_CalDtResidence.Name = "btn_CalDtResidence"
        Me.btn_CalDtResidence.Size = New System.Drawing.Size(20, 20)
        Me.btn_CalDtResidence.TabIndex = 5
        '
        'txt_DtResidence
        '
        Me.txt_DtResidence.Location = New System.Drawing.Point(291, 26)
        Me.txt_DtResidence.Mask = "00/00/0000"
        Me.txt_DtResidence.Name = "txt_DtResidence"
        Me.txt_DtResidence.RejectInputOnFirstFailure = True
        Me.txt_DtResidence.ResetOnSpace = False
        Me.txt_DtResidence.Size = New System.Drawing.Size(111, 20)
        Me.txt_DtResidence.TabIndex = 4
        Me.txt_DtResidence.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.txt_DtResidence.ValidatingType = GetType(Date)
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label48.Location = New System.Drawing.Point(232, 125)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(82, 13)
        Me.Label48.TabIndex = 32
        Me.Label48.Text = "Семейная роль"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'сmb_FamilyRole
        '
        Me.сmb_FamilyRole.DropDownHeight = 200
        Me.сmb_FamilyRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.сmb_FamilyRole.FormattingEnabled = True
        Me.сmb_FamilyRole.IntegralHeight = False
        Me.сmb_FamilyRole.Location = New System.Drawing.Point(231, 141)
        Me.сmb_FamilyRole.Name = "сmb_FamilyRole"
        Me.сmb_FamilyRole.Size = New System.Drawing.Size(171, 21)
        Me.сmb_FamilyRole.TabIndex = 9
        '
        'txt_NoteMember
        '
        Me.txt_NoteMember.Location = New System.Drawing.Point(6, 285)
        Me.txt_NoteMember.MaxLength = 300
        Me.txt_NoteMember.Multiline = True
        Me.txt_NoteMember.Name = "txt_NoteMember"
        Me.txt_NoteMember.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_NoteMember.Size = New System.Drawing.Size(769, 77)
        Me.txt_NoteMember.TabIndex = 20
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label41.Location = New System.Drawing.Point(6, 152)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(100, 13)
        Me.Label41.TabIndex = 24
        Me.Label41.Text = "Адрес проживания"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_AddressOfLive
        '
        Me.txt_AddressOfLive.Location = New System.Drawing.Point(6, 168)
        Me.txt_AddressOfLive.MaxLength = 200
        Me.txt_AddressOfLive.Name = "txt_AddressOfLive"
        Me.txt_AddressOfLive.Size = New System.Drawing.Size(396, 20)
        Me.txt_AddressOfLive.TabIndex = 10
        '
        'txt_Residence
        '
        Me.txt_Residence.Location = New System.Drawing.Point(6, 105)
        Me.txt_Residence.MaxLength = 100
        Me.txt_Residence.Name = "txt_Residence"
        Me.txt_Residence.ReadOnly = True
        Me.txt_Residence.Size = New System.Drawing.Size(396, 20)
        Me.txt_Residence.TabIndex = 8
        '
        'ckb_ShareOwner
        '
        Me.ckb_ShareOwner.Location = New System.Drawing.Point(6, 129)
        Me.ckb_ShareOwner.Name = "ckb_ShareOwner"
        Me.ckb_ShareOwner.Size = New System.Drawing.Size(220, 23)
        Me.ckb_ShareOwner.TabIndex = 7
        Me.ckb_ShareOwner.Text = "Является дольщиком"
        Me.ckb_ShareOwner.UseVisualStyleBackColor = True
        '
        'Lab_CriterialSearch
        '
        Me.Lab_CriterialSearch.AutoSize = True
        Me.Lab_CriterialSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Lab_CriterialSearch.Location = New System.Drawing.Point(300, 88)
        Me.Lab_CriterialSearch.Name = "Lab_CriterialSearch"
        Me.Lab_CriterialSearch.Size = New System.Drawing.Size(102, 13)
        Me.Lab_CriterialSearch.TabIndex = 21
        Me.Lab_CriterialSearch.Text = "Адрес регистрации"
        Me.Lab_CriterialSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_Patronymic
        '
        Me.txt_Patronymic.Location = New System.Drawing.Point(66, 66)
        Me.txt_Patronymic.MaxLength = 50
        Me.txt_Patronymic.Name = "txt_Patronymic"
        Me.txt_Patronymic.Size = New System.Drawing.Size(157, 20)
        Me.txt_Patronymic.TabIndex = 3
        '
        'txt_Name
        '
        Me.txt_Name.Location = New System.Drawing.Point(66, 46)
        Me.txt_Name.MaxLength = 50
        Me.txt_Name.Name = "txt_Name"
        Me.txt_Name.Size = New System.Drawing.Size(157, 20)
        Me.txt_Name.TabIndex = 2
        '
        'txt_Surname
        '
        Me.txt_Surname.Location = New System.Drawing.Point(66, 26)
        Me.txt_Surname.MaxLength = 50
        Me.txt_Surname.Name = "txt_Surname"
        Me.txt_Surname.Size = New System.Drawing.Size(157, 20)
        Me.txt_Surname.TabIndex = 1
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.txt_MemEmail)
        Me.GroupBox7.Controls.Add(Me.txt_MemPhoneMobile)
        Me.GroupBox7.Controls.Add(Me.txt_PlaceOfWork)
        Me.GroupBox7.Location = New System.Drawing.Point(6, 193)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(396, 73)
        Me.GroupBox7.TabIndex = 20
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Контактные данные (место работы, телефон, email и пр.)"
        '
        'txt_MemEmail
        '
        Me.txt_MemEmail.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.txt_MemEmail.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite
        Me.txt_MemEmail.Location = New System.Drawing.Point(116, 42)
        Me.txt_MemEmail.Mask = "____________@_____.____"
        Me.txt_MemEmail.Name = "txt_MemEmail"
        Me.txt_MemEmail.Size = New System.Drawing.Size(272, 20)
        Me.txt_MemEmail.TabIndex = 110
        Me.txt_MemEmail.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'txt_MemPhoneMobile
        '
        Me.txt_MemPhoneMobile.Location = New System.Drawing.Point(6, 42)
        Me.txt_MemPhoneMobile.Mask = "+7 (999) 000-00-00"
        Me.txt_MemPhoneMobile.Name = "txt_MemPhoneMobile"
        Me.txt_MemPhoneMobile.Size = New System.Drawing.Size(104, 20)
        Me.txt_MemPhoneMobile.TabIndex = 47
        Me.txt_MemPhoneMobile.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'txt_PlaceOfWork
        '
        Me.txt_PlaceOfWork.Location = New System.Drawing.Point(6, 18)
        Me.txt_PlaceOfWork.MaxLength = 60
        Me.txt_PlaceOfWork.Name = "txt_PlaceOfWork"
        Me.txt_PlaceOfWork.Size = New System.Drawing.Size(382, 20)
        Me.txt_PlaceOfWork.TabIndex = 11
        '
        'cmb_SexMember
        '
        Me.cmb_SexMember.DropDownHeight = 200
        Me.cmb_SexMember.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_SexMember.FormattingEnabled = True
        Me.cmb_SexMember.IntegralHeight = False
        Me.cmb_SexMember.ItemHeight = 13
        Me.cmb_SexMember.Location = New System.Drawing.Point(291, 66)
        Me.cmb_SexMember.Name = "cmb_SexMember"
        Me.cmb_SexMember.Size = New System.Drawing.Size(111, 21)
        Me.cmb_SexMember.TabIndex = 6
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label43.Location = New System.Drawing.Point(9, 30)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(74, 13)
        Me.Label43.TabIndex = 26
        Me.Label43.Text = "Фамилия      "
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label45.Location = New System.Drawing.Point(9, 69)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(87, 13)
        Me.Label45.TabIndex = 28
        Me.Label45.Text = "Отчество           "
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label44.Location = New System.Drawing.Point(9, 49)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(68, 13)
        Me.Label44.TabIndex = 27
        Me.Label44.Text = "Имя             "
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label46.Location = New System.Drawing.Point(232, 70)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(66, 13)
        Me.Label46.TabIndex = 29
        Me.Label46.Text = "Пол             "
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label39.Location = New System.Drawing.Point(232, 31)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(69, 13)
        Me.Label39.TabIndex = 22
        Me.Label39.Text = "Прописан    "
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label47.Location = New System.Drawing.Point(3, 269)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(75, 13)
        Me.Label47.TabIndex = 30
        Me.Label47.Text = "Комментарий"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lab_Update
        '
        Me.lab_Update.AutoEllipsis = True
        Me.lab_Update.ForeColor = System.Drawing.Color.Blue
        Me.lab_Update.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lab_Update.Location = New System.Drawing.Point(370, 267)
        Me.lab_Update.Name = "lab_Update"
        Me.lab_Update.Size = New System.Drawing.Size(396, 14)
        Me.lab_Update.TabIndex = 18
        Me.lab_Update.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'txt_DtUnResidence
        '
        Me.txt_DtUnResidence.Location = New System.Drawing.Point(291, 46)
        Me.txt_DtUnResidence.Mask = "00/00/0000"
        Me.txt_DtUnResidence.Name = "txt_DtUnResidence"
        Me.txt_DtUnResidence.RejectInputOnFirstFailure = True
        Me.txt_DtUnResidence.ResetOnSpace = False
        Me.txt_DtUnResidence.Size = New System.Drawing.Size(111, 20)
        Me.txt_DtUnResidence.TabIndex = 5
        Me.txt_DtUnResidence.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.txt_DtUnResidence.ValidatingType = GetType(Date)
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label40.Location = New System.Drawing.Point(232, 49)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(64, 13)
        Me.Label40.TabIndex = 23
        Me.Label40.Text = "Выписан    "
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.btn_CalPDDateOfIssue)
        Me.GroupBox5.Controls.Add(Me.btn_CalPDDateOfBirth)
        Me.GroupBox5.Controls.Add(Me.PictureBox5)
        Me.GroupBox5.Controls.Add(Me.btn_ClearPD)
        Me.GroupBox5.Controls.Add(Me.txt_PDSubunitCode)
        Me.GroupBox5.Controls.Add(Me.txt_PDSubunit)
        Me.GroupBox5.Controls.Add(Me.txt_PDNumber)
        Me.GroupBox5.Controls.Add(Me.txt_PDSeries)
        Me.GroupBox5.Controls.Add(Me.txt_PDString)
        Me.GroupBox5.Controls.Add(Me.Label37)
        Me.GroupBox5.Controls.Add(Me.Label38)
        Me.GroupBox5.Controls.Add(Me.Label35)
        Me.GroupBox5.Controls.Add(Me.Label34)
        Me.GroupBox5.Controls.Add(Me.txt_PDDateOfBirth)
        Me.GroupBox5.Controls.Add(Me.Label33)
        Me.GroupBox5.Controls.Add(Me.txt_PDDateOfIssue)
        Me.GroupBox5.Controls.Add(Me.Label36)
        Me.GroupBox5.Location = New System.Drawing.Point(408, 14)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(367, 252)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Паспортные данные"
        '
        'btn_CalPDDateOfIssue
        '
        Me.btn_CalPDDateOfIssue.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.btn_CalPDDateOfIssue.Location = New System.Drawing.Point(238, 90)
        Me.btn_CalPDDateOfIssue.Name = "btn_CalPDDateOfIssue"
        Me.btn_CalPDDateOfIssue.Size = New System.Drawing.Size(20, 20)
        Me.btn_CalPDDateOfIssue.TabIndex = 22
        '
        'btn_CalPDDateOfBirth
        '
        Me.btn_CalPDDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.btn_CalPDDateOfBirth.Location = New System.Drawing.Point(238, 14)
        Me.btn_CalPDDateOfBirth.Name = "btn_CalPDDateOfBirth"
        Me.btn_CalPDDateOfBirth.Size = New System.Drawing.Size(20, 20)
        Me.btn_CalPDDateOfBirth.TabIndex = 21
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(263, 12)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(92, 98)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 14
        Me.PictureBox5.TabStop = False
        '
        'btn_ClearPD
        '
        Me.btn_ClearPD.BackgroundImage = CType(resources.GetObject("btn_ClearPD.BackgroundImage"), System.Drawing.Image)
        Me.btn_ClearPD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_ClearPD.Location = New System.Drawing.Point(335, 167)
        Me.btn_ClearPD.Name = "btn_ClearPD"
        Me.btn_ClearPD.Size = New System.Drawing.Size(20, 20)
        Me.btn_ClearPD.TabIndex = 0
        Me.btn_ClearPD.UseVisualStyleBackColor = True
        '
        'txt_PDSubunitCode
        '
        Me.txt_PDSubunitCode.Location = New System.Drawing.Point(146, 161)
        Me.txt_PDSubunitCode.Mask = "000-000"
        Me.txt_PDSubunitCode.Name = "txt_PDSubunitCode"
        Me.txt_PDSubunitCode.Size = New System.Drawing.Size(55, 20)
        Me.txt_PDSubunitCode.TabIndex = 19
        Me.txt_PDSubunitCode.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        '
        'txt_PDSubunit
        '
        Me.txt_PDSubunit.Location = New System.Drawing.Point(81, 116)
        Me.txt_PDSubunit.MaxLength = 200
        Me.txt_PDSubunit.Multiline = True
        Me.txt_PDSubunit.Name = "txt_PDSubunit"
        Me.txt_PDSubunit.Size = New System.Drawing.Size(274, 34)
        Me.txt_PDSubunit.TabIndex = 18
        '
        'txt_PDNumber
        '
        Me.txt_PDNumber.Location = New System.Drawing.Point(147, 65)
        Me.txt_PDNumber.Mask = "000000"
        Me.txt_PDNumber.Name = "txt_PDNumber"
        Me.txt_PDNumber.Size = New System.Drawing.Size(55, 20)
        Me.txt_PDNumber.TabIndex = 16
        Me.txt_PDNumber.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        '
        'txt_PDSeries
        '
        Me.txt_PDSeries.Location = New System.Drawing.Point(147, 38)
        Me.txt_PDSeries.Mask = "0000"
        Me.txt_PDSeries.Name = "txt_PDSeries"
        Me.txt_PDSeries.Size = New System.Drawing.Size(55, 20)
        Me.txt_PDSeries.TabIndex = 15
        Me.txt_PDSeries.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        '
        'txt_PDString
        '
        Me.txt_PDString.Location = New System.Drawing.Point(9, 187)
        Me.txt_PDString.MaxLength = 300
        Me.txt_PDString.Multiline = True
        Me.txt_PDString.Name = "txt_PDString"
        Me.txt_PDString.ReadOnly = True
        Me.txt_PDString.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_PDString.Size = New System.Drawing.Size(346, 56)
        Me.txt_PDString.TabIndex = 20
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label37.Location = New System.Drawing.Point(9, 135)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(135, 13)
        Me.Label37.TabIndex = 11
        Me.Label37.Text = "Кем выдан                        "
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label38.Location = New System.Drawing.Point(9, 164)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(146, 13)
        Me.Label38.TabIndex = 12
        Me.Label38.Text = "Код подразделения             "
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label35.Location = New System.Drawing.Point(9, 67)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(146, 13)
        Me.Label35.TabIndex = 9
        Me.Label35.Text = "Номер                                   "
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label34.Location = New System.Drawing.Point(9, 41)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(143, 13)
        Me.Label34.TabIndex = 8
        Me.Label34.Text = "Серия                                   "
        '
        'txt_PDDateOfBirth
        '
        Me.txt_PDDateOfBirth.Location = New System.Drawing.Point(147, 14)
        Me.txt_PDDateOfBirth.Mask = "00/00/0000"
        Me.txt_PDDateOfBirth.Name = "txt_PDDateOfBirth"
        Me.txt_PDDateOfBirth.RejectInputOnFirstFailure = True
        Me.txt_PDDateOfBirth.ResetOnSpace = False
        Me.txt_PDDateOfBirth.Size = New System.Drawing.Size(111, 20)
        Me.txt_PDDateOfBirth.TabIndex = 14
        Me.txt_PDDateOfBirth.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.txt_PDDateOfBirth.ValidatingType = GetType(Date)
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label33.Location = New System.Drawing.Point(9, 16)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(143, 13)
        Me.Label33.TabIndex = 7
        Me.Label33.Text = "Дата рождения                   "
        '
        'txt_PDDateOfIssue
        '
        Me.txt_PDDateOfIssue.Location = New System.Drawing.Point(147, 90)
        Me.txt_PDDateOfIssue.Mask = "00/00/0000"
        Me.txt_PDDateOfIssue.Name = "txt_PDDateOfIssue"
        Me.txt_PDDateOfIssue.RejectInputOnFirstFailure = True
        Me.txt_PDDateOfIssue.ResetOnSpace = False
        Me.txt_PDDateOfIssue.Size = New System.Drawing.Size(111, 20)
        Me.txt_PDDateOfIssue.TabIndex = 17
        Me.txt_PDDateOfIssue.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.txt_PDDateOfIssue.ValidatingType = GetType(Date)
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label36.Location = New System.Drawing.Point(9, 94)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(145, 13)
        Me.Label36.TabIndex = 10
        Me.Label36.Text = "Дата выдачи                        "
        '
        'Label50
        '
        Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label50.ForeColor = System.Drawing.Color.Red
        Me.Label50.Location = New System.Drawing.Point(3, 46)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(10, 10)
        Me.Label50.TabIndex = 44
        Me.Label50.Text = "*"
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label49
        '
        Me.Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label49.ForeColor = System.Drawing.Color.Red
        Me.Label49.Location = New System.Drawing.Point(3, 28)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(10, 10)
        Me.Label49.TabIndex = 43
        Me.Label49.Text = "*"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label42
        '
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.Red
        Me.Label42.Location = New System.Drawing.Point(3, 66)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(10, 10)
        Me.Label42.TabIndex = 42
        Me.Label42.Text = "*"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DGView_PrMembers
        '
        Me.DGView_PrMembers.AllowUserToAddRows = False
        Me.DGView_PrMembers.AllowUserToDeleteRows = False
        Me.DGView_PrMembers.AllowUserToResizeRows = False
        Me.DGView_PrMembers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DGView_PrMembers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DGView_PrMembers.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGView_PrMembers.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DGView_PrMembers.ColumnHeadersHeight = 20
        Me.DGView_PrMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGView_PrMembers.DefaultCellStyle = DataGridViewCellStyle8
        Me.DGView_PrMembers.Dock = System.Windows.Forms.DockStyle.Top
        Me.DGView_PrMembers.Location = New System.Drawing.Point(3, 58)
        Me.DGView_PrMembers.MultiSelect = False
        Me.DGView_PrMembers.Name = "DGView_PrMembers"
        Me.DGView_PrMembers.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGView_PrMembers.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.DGView_PrMembers.RowHeadersWidth = 21
        Me.DGView_PrMembers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        Me.DGView_PrMembers.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.DGView_PrMembers.RowTemplate.Height = 17
        Me.DGView_PrMembers.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGView_PrMembers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGView_PrMembers.Size = New System.Drawing.Size(781, 101)
        Me.DGView_PrMembers.TabIndex = 5
        '
        'Pan_Members
        '
        Me.Pan_Members.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pan_Members.Location = New System.Drawing.Point(3, 301)
        Me.Pan_Members.Name = "Pan_Members"
        Me.Pan_Members.Size = New System.Drawing.Size(443, 198)
        Me.Pan_Members.TabIndex = 2
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.TS_ManagerPrMembers)
        Me.Panel5.Controls.Add(Me.PictBox_Members)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Controls.Add(Me.Label32)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(3, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(781, 55)
        Me.Panel5.TabIndex = 109
        '
        'TS_ManagerPrMembers
        '
        Me.TS_ManagerPrMembers.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TS_ManagerPrMembers.AutoSize = False
        Me.TS_ManagerPrMembers.Dock = System.Windows.Forms.DockStyle.None
        Me.TS_ManagerPrMembers.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TS_ManagerPrMembers.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_InsertMember, Me.btn_UpdateMember, Me.btn_DeleteMember})
        Me.TS_ManagerPrMembers.Location = New System.Drawing.Point(660, 10)
        Me.TS_ManagerPrMembers.Name = "TS_ManagerPrMembers"
        Me.TS_ManagerPrMembers.Size = New System.Drawing.Size(113, 42)
        Me.TS_ManagerPrMembers.TabIndex = 108
        '
        'btn_InsertMember
        '
        Me.btn_InsertMember.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_InsertMember.Image = CType(resources.GetObject("btn_InsertMember.Image"), System.Drawing.Image)
        Me.btn_InsertMember.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_InsertMember.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_InsertMember.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_InsertMember.Name = "btn_InsertMember"
        Me.btn_InsertMember.Size = New System.Drawing.Size(36, 39)
        Me.btn_InsertMember.ToolTipText = "Добавить нового члена семьи"
        '
        'btn_UpdateMember
        '
        Me.btn_UpdateMember.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_UpdateMember.Enabled = False
        Me.btn_UpdateMember.Image = CType(resources.GetObject("btn_UpdateMember.Image"), System.Drawing.Image)
        Me.btn_UpdateMember.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_UpdateMember.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_UpdateMember.Name = "btn_UpdateMember"
        Me.btn_UpdateMember.Size = New System.Drawing.Size(36, 39)
        Me.btn_UpdateMember.ToolTipText = "Сохранить изменения"
        '
        'btn_DeleteMember
        '
        Me.btn_DeleteMember.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_DeleteMember.Image = CType(resources.GetObject("btn_DeleteMember.Image"), System.Drawing.Image)
        Me.btn_DeleteMember.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btn_DeleteMember.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_DeleteMember.Name = "btn_DeleteMember"
        Me.btn_DeleteMember.Size = New System.Drawing.Size(36, 39)
        Me.btn_DeleteMember.ToolTipText = "Удалить члена семьи"
        '
        'PictBox_Members
        '
        Me.PictBox_Members.BackColor = System.Drawing.Color.Transparent
        Me.PictBox_Members.Image = CType(resources.GetObject("PictBox_Members.Image"), System.Drawing.Image)
        Me.PictBox_Members.Location = New System.Drawing.Point(0, 0)
        Me.PictBox_Members.Name = "PictBox_Members"
        Me.PictBox_Members.Size = New System.Drawing.Size(50, 50)
        Me.PictBox_Members.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictBox_Members.TabIndex = 6
        Me.PictBox_Members.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label2.Location = New System.Drawing.Point(56, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 16)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Члены семьи"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(56, 24)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(274, 29)
        Me.Label32.TabIndex = 8
        Me.Label32.Text = "Члены семьи несущие солидарную ответственность по оплате коммунальных услуг"
        '
        'EventsDeb_1
        '
        Me.EventsDeb_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.EventsDeb_1.Controls.Add(Me.Label4)
        Me.EventsDeb_1.Controls.Add(Me.PictBox_EventsDeb_1)
        Me.EventsDeb_1.Location = New System.Drawing.Point(4, 24)
        Me.EventsDeb_1.Name = "EventsDeb_1"
        Me.EventsDeb_1.Padding = New System.Windows.Forms.Padding(3)
        Me.EventsDeb_1.Size = New System.Drawing.Size(791, 580)
        Me.EventsDeb_1.TabIndex = 3
        Me.EventsDeb_1.Text = "TabPage4"
        Me.EventsDeb_1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label4.Location = New System.Drawing.Point(61, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(137, 50)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Работа с ДЗ ""Электроэнергия"""
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictBox_EventsDeb_1
        '
        Me.PictBox_EventsDeb_1.BackColor = System.Drawing.Color.Transparent
        Me.PictBox_EventsDeb_1.Image = CType(resources.GetObject("PictBox_EventsDeb_1.Image"), System.Drawing.Image)
        Me.PictBox_EventsDeb_1.Location = New System.Drawing.Point(3, 3)
        Me.PictBox_EventsDeb_1.Name = "PictBox_EventsDeb_1"
        Me.PictBox_EventsDeb_1.Size = New System.Drawing.Size(50, 50)
        Me.PictBox_EventsDeb_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictBox_EventsDeb_1.TabIndex = 0
        Me.PictBox_EventsDeb_1.TabStop = False
        '
        'EventsDeb_5
        '
        Me.EventsDeb_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.EventsDeb_5.Controls.Add(Me.Label5)
        Me.EventsDeb_5.Controls.Add(Me.PictBox_EventsDeb_5)
        Me.EventsDeb_5.Location = New System.Drawing.Point(4, 24)
        Me.EventsDeb_5.Name = "EventsDeb_5"
        Me.EventsDeb_5.Padding = New System.Windows.Forms.Padding(3)
        Me.EventsDeb_5.Size = New System.Drawing.Size(791, 580)
        Me.EventsDeb_5.TabIndex = 4
        Me.EventsDeb_5.Text = "TabPage5"
        Me.EventsDeb_5.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label5.Location = New System.Drawing.Point(59, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(174, 50)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Работа с ДЗ ""Капитальный ремонт"""
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictBox_EventsDeb_5
        '
        Me.PictBox_EventsDeb_5.BackColor = System.Drawing.Color.Transparent
        Me.PictBox_EventsDeb_5.Image = CType(resources.GetObject("PictBox_EventsDeb_5.Image"), System.Drawing.Image)
        Me.PictBox_EventsDeb_5.Location = New System.Drawing.Point(3, 3)
        Me.PictBox_EventsDeb_5.Name = "PictBox_EventsDeb_5"
        Me.PictBox_EventsDeb_5.Size = New System.Drawing.Size(50, 50)
        Me.PictBox_EventsDeb_5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictBox_EventsDeb_5.TabIndex = 0
        Me.PictBox_EventsDeb_5.TabStop = False
        '
        'Suit_1
        '
        Me.Suit_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Suit_1.Controls.Add(Me.PIR1_TabCon)
        Me.Suit_1.Controls.Add(Me.GroupBox6)
        Me.Suit_1.Controls.Add(Me.Panel4)
        Me.Suit_1.Location = New System.Drawing.Point(4, 24)
        Me.Suit_1.Name = "Suit_1"
        Me.Suit_1.Padding = New System.Windows.Forms.Padding(3)
        Me.Suit_1.Size = New System.Drawing.Size(791, 580)
        Me.Suit_1.TabIndex = 5
        Me.Suit_1.Text = "TabPage6"
        Me.Suit_1.UseVisualStyleBackColor = True
        '
        'PIR1_TabCon
        '
        Me.PIR1_TabCon.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PIR1_TabCon.Controls.Add(Me.PIR1_TP_PetitionsDebt)
        Me.PIR1_TabCon.Controls.Add(Me.PIR1_TP_SSPWork)
        Me.PIR1_TabCon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.PIR1_TabCon.HotTrack = True
        Me.PIR1_TabCon.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PIR1_TabCon.Location = New System.Drawing.Point(3, 200)
        Me.PIR1_TabCon.Multiline = True
        Me.PIR1_TabCon.Name = "PIR1_TabCon"
        Me.PIR1_TabCon.SelectedIndex = 0
        Me.PIR1_TabCon.Size = New System.Drawing.Size(785, 373)
        Me.PIR1_TabCon.TabIndex = 110
        '
        'PIR1_TP_PetitionsDebt
        '
        Me.PIR1_TP_PetitionsDebt.BackColor = System.Drawing.SystemColors.Control
        Me.PIR1_TP_PetitionsDebt.Controls.Add(Me.Label93)
        Me.PIR1_TP_PetitionsDebt.Controls.Add(Me.btn_CalPIR1_txt_DtDecisionDirection)
        Me.PIR1_TP_PetitionsDebt.Controls.Add(Me.PIR1_txt_DtDecisionDirection)
        Me.PIR1_TP_PetitionsDebt.Controls.Add(Me.btn_CalPIR1_txt_DtClosePetitionDebt)
        Me.PIR1_TP_PetitionsDebt.Controls.Add(Me.Label65)
        Me.PIR1_TP_PetitionsDebt.Controls.Add(Me.PIR1_cmb_ReasonForEnd)
        Me.PIR1_TP_PetitionsDebt.Controls.Add(Me.PIR1_txt_Note)
        Me.PIR1_TP_PetitionsDebt.Controls.Add(Me.Group_Petition)
        Me.PIR1_TP_PetitionsDebt.Controls.Add(Me.PIR1_cmb_DecisionDirection)
        Me.PIR1_TP_PetitionsDebt.Controls.Add(Me.Label55)
        Me.PIR1_TP_PetitionsDebt.Controls.Add(Me.GroupBox8)
        Me.PIR1_TP_PetitionsDebt.Controls.Add(Me.Label66)
        Me.PIR1_TP_PetitionsDebt.Controls.Add(Me.PIR1_txt_DtClosePetitionDebt)
        Me.PIR1_TP_PetitionsDebt.ImageKey = "(отсутствует)"
        Me.PIR1_TP_PetitionsDebt.Location = New System.Drawing.Point(4, 22)
        Me.PIR1_TP_PetitionsDebt.Name = "PIR1_TP_PetitionsDebt"
        Me.PIR1_TP_PetitionsDebt.Padding = New System.Windows.Forms.Padding(3)
        Me.PIR1_TP_PetitionsDebt.Size = New System.Drawing.Size(777, 347)
        Me.PIR1_TP_PetitionsDebt.TabIndex = 0
        Me.PIR1_TP_PetitionsDebt.Text = "Исковые мероприятия"
        '
        'Label93
        '
        Me.Label93.AutoSize = True
        Me.Label93.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label93.Location = New System.Drawing.Point(356, 306)
        Me.Label93.Name = "Label93"
        Me.Label93.Size = New System.Drawing.Size(142, 13)
        Me.Label93.TabIndex = 126
        Me.Label93.Text = "Дата направления ИЛ, СП"
        '
        'btn_CalPIR1_txt_DtDecisionDirection
        '
        Me.btn_CalPIR1_txt_DtDecisionDirection.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.btn_CalPIR1_txt_DtDecisionDirection.Location = New System.Drawing.Point(455, 320)
        Me.btn_CalPIR1_txt_DtDecisionDirection.Name = "btn_CalPIR1_txt_DtDecisionDirection"
        Me.btn_CalPIR1_txt_DtDecisionDirection.Size = New System.Drawing.Size(21, 20)
        Me.btn_CalPIR1_txt_DtDecisionDirection.TabIndex = 125
        '
        'PIR1_txt_DtDecisionDirection
        '
        Me.PIR1_txt_DtDecisionDirection.Location = New System.Drawing.Point(359, 320)
        Me.PIR1_txt_DtDecisionDirection.Mask = "00/00/0000"
        Me.PIR1_txt_DtDecisionDirection.Name = "PIR1_txt_DtDecisionDirection"
        Me.PIR1_txt_DtDecisionDirection.RejectInputOnFirstFailure = True
        Me.PIR1_txt_DtDecisionDirection.ResetOnSpace = False
        Me.PIR1_txt_DtDecisionDirection.Size = New System.Drawing.Size(117, 20)
        Me.PIR1_txt_DtDecisionDirection.TabIndex = 124
        Me.PIR1_txt_DtDecisionDirection.Tag = "isk"
        Me.PIR1_txt_DtDecisionDirection.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.PIR1_txt_DtDecisionDirection.ValidatingType = GetType(Date)
        '
        'btn_CalPIR1_txt_DtClosePetitionDebt
        '
        Me.btn_CalPIR1_txt_DtClosePetitionDebt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.btn_CalPIR1_txt_DtClosePetitionDebt.Location = New System.Drawing.Point(746, 320)
        Me.btn_CalPIR1_txt_DtClosePetitionDebt.Name = "btn_CalPIR1_txt_DtClosePetitionDebt"
        Me.btn_CalPIR1_txt_DtClosePetitionDebt.Size = New System.Drawing.Size(21, 20)
        Me.btn_CalPIR1_txt_DtClosePetitionDebt.TabIndex = 123
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label65.Location = New System.Drawing.Point(525, 264)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(146, 13)
        Me.Label65.TabIndex = 113
        Me.Label65.Text = "Причина окончания ИЛ, СП"
        '
        'PIR1_cmb_ReasonForEnd
        '
        Me.PIR1_cmb_ReasonForEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PIR1_cmb_ReasonForEnd.FormattingEnabled = True
        Me.PIR1_cmb_ReasonForEnd.Location = New System.Drawing.Point(527, 278)
        Me.PIR1_cmb_ReasonForEnd.Name = "PIR1_cmb_ReasonForEnd"
        Me.PIR1_cmb_ReasonForEnd.Size = New System.Drawing.Size(241, 21)
        Me.PIR1_cmb_ReasonForEnd.TabIndex = 112
        '
        'PIR1_txt_Note
        '
        Me.PIR1_txt_Note.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.PIR1_txt_Note.Location = New System.Drawing.Point(6, 234)
        Me.PIR1_txt_Note.MaxLength = 300
        Me.PIR1_txt_Note.Multiline = True
        Me.PIR1_txt_Note.Name = "PIR1_txt_Note"
        Me.PIR1_txt_Note.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.PIR1_txt_Note.Size = New System.Drawing.Size(347, 108)
        Me.PIR1_txt_Note.TabIndex = 95
        Me.PIR1_txt_Note.Tag = "isk"
        '
        'Group_Petition
        '
        Me.Group_Petition.BackColor = System.Drawing.SystemColors.Control
        Me.Group_Petition.Controls.Add(Me.btn_CalPIR1_txt_DtDispatch)
        Me.Group_Petition.Controls.Add(Me.btn_CalPIR1_txt_DtPetitions)
        Me.Group_Petition.Controls.Add(Me.btn_CalPIR1_txt_DtPeriodEnd)
        Me.Group_Petition.Controls.Add(Me.btn_CalPIR1_txt_DtPeriodStart)
        Me.Group_Petition.Controls.Add(Me.PIR1_cmb_PetitionType)
        Me.Group_Petition.Controls.Add(Me.PIR1_cmb_EnergyType)
        Me.Group_Petition.Controls.Add(Me.Pic_PayOrders)
        Me.Group_Petition.Controls.Add(Me.Link_PayOrders)
        Me.Group_Petition.Controls.Add(Me.Label74)
        Me.Group_Petition.Controls.Add(Me.Label71)
        Me.Group_Petition.Controls.Add(Me.Label73)
        Me.Group_Petition.Controls.Add(Me.Label69)
        Me.Group_Petition.Controls.Add(Me.PIR1_txt_DtDispatch)
        Me.Group_Petition.Controls.Add(Me.Label54)
        Me.Group_Petition.Controls.Add(Me.Label53)
        Me.Group_Petition.Controls.Add(Me.Label52)
        Me.Group_Petition.Controls.Add(Me.PIR1_txt_DtPeriodEnd)
        Me.Group_Petition.Controls.Add(Me.Label59)
        Me.Group_Petition.Controls.Add(Me.Label56)
        Me.Group_Petition.Controls.Add(Me.Label57)
        Me.Group_Petition.Controls.Add(Me.Label51)
        Me.Group_Petition.Controls.Add(Me.PIR1_txt_GovTax)
        Me.Group_Petition.Controls.Add(Me.PIR1_txt_DebtSumm)
        Me.Group_Petition.Controls.Add(Me.PIR1_txt_NumberPetition)
        Me.Group_Petition.Controls.Add(Me.Label58)
        Me.Group_Petition.Controls.Add(Me.Label60)
        Me.Group_Petition.Controls.Add(Me.Label68)
        Me.Group_Petition.Controls.Add(Me.PIR1_txt_DtPetitions)
        Me.Group_Petition.Controls.Add(Me.PIR1_cmb_CourtType)
        Me.Group_Petition.Controls.Add(Me.PIR1_cmb_JudicialArea)
        Me.Group_Petition.Controls.Add(Me.Label79)
        Me.Group_Petition.Controls.Add(Me.Label80)
        Me.Group_Petition.Controls.Add(Me.Label81)
        Me.Group_Petition.Controls.Add(Me.Label78)
        Me.Group_Petition.Controls.Add(Me.Label76)
        Me.Group_Petition.Controls.Add(Me.Label75)
        Me.Group_Petition.Controls.Add(Me.Label77)
        Me.Group_Petition.Controls.Add(Me.PIR1_txt_DtPeriodStart)
        Me.Group_Petition.Location = New System.Drawing.Point(6, 6)
        Me.Group_Petition.Name = "Group_Petition"
        Me.Group_Petition.Size = New System.Drawing.Size(347, 224)
        Me.Group_Petition.TabIndex = 53
        Me.Group_Petition.TabStop = False
        Me.Group_Petition.Text = "Параметры иска"
        '
        'btn_CalPIR1_txt_DtDispatch
        '
        Me.btn_CalPIR1_txt_DtDispatch.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.btn_CalPIR1_txt_DtDispatch.Location = New System.Drawing.Point(316, 195)
        Me.btn_CalPIR1_txt_DtDispatch.Name = "btn_CalPIR1_txt_DtDispatch"
        Me.btn_CalPIR1_txt_DtDispatch.Size = New System.Drawing.Size(20, 20)
        Me.btn_CalPIR1_txt_DtDispatch.TabIndex = 120
        '
        'btn_CalPIR1_txt_DtPetitions
        '
        Me.btn_CalPIR1_txt_DtPetitions.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.btn_CalPIR1_txt_DtPetitions.Location = New System.Drawing.Point(196, 195)
        Me.btn_CalPIR1_txt_DtPetitions.Name = "btn_CalPIR1_txt_DtPetitions"
        Me.btn_CalPIR1_txt_DtPetitions.Size = New System.Drawing.Size(20, 20)
        Me.btn_CalPIR1_txt_DtPetitions.TabIndex = 119
        '
        'btn_CalPIR1_txt_DtPeriodEnd
        '
        Me.btn_CalPIR1_txt_DtPeriodEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.btn_CalPIR1_txt_DtPeriodEnd.Location = New System.Drawing.Point(87, 70)
        Me.btn_CalPIR1_txt_DtPeriodEnd.Name = "btn_CalPIR1_txt_DtPeriodEnd"
        Me.btn_CalPIR1_txt_DtPeriodEnd.Size = New System.Drawing.Size(20, 20)
        Me.btn_CalPIR1_txt_DtPeriodEnd.TabIndex = 118
        '
        'btn_CalPIR1_txt_DtPeriodStart
        '
        Me.btn_CalPIR1_txt_DtPeriodStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.btn_CalPIR1_txt_DtPeriodStart.Location = New System.Drawing.Point(87, 31)
        Me.btn_CalPIR1_txt_DtPeriodStart.Name = "btn_CalPIR1_txt_DtPeriodStart"
        Me.btn_CalPIR1_txt_DtPeriodStart.Size = New System.Drawing.Size(20, 20)
        Me.btn_CalPIR1_txt_DtPeriodStart.TabIndex = 117
        '
        'PIR1_cmb_PetitionType
        '
        Me.PIR1_cmb_PetitionType.Location = New System.Drawing.Point(121, 69)
        Me.PIR1_cmb_PetitionType.Name = "PIR1_cmb_PetitionType"
        Me.PIR1_cmb_PetitionType.ReadOnly = True
        Me.PIR1_cmb_PetitionType.Size = New System.Drawing.Size(213, 20)
        Me.PIR1_cmb_PetitionType.TabIndex = 116
        Me.PIR1_cmb_PetitionType.Tag = "isk"
        '
        'PIR1_cmb_EnergyType
        '
        Me.PIR1_cmb_EnergyType.Location = New System.Drawing.Point(121, 31)
        Me.PIR1_cmb_EnergyType.Name = "PIR1_cmb_EnergyType"
        Me.PIR1_cmb_EnergyType.ReadOnly = True
        Me.PIR1_cmb_EnergyType.Size = New System.Drawing.Size(213, 20)
        Me.PIR1_cmb_EnergyType.TabIndex = 115
        Me.PIR1_cmb_EnergyType.Tag = "isk"
        '
        'Pic_PayOrders
        '
        Me.Pic_PayOrders.Image = CType(resources.GetObject("Pic_PayOrders.Image"), System.Drawing.Image)
        Me.Pic_PayOrders.InitialImage = Nothing
        Me.Pic_PayOrders.Location = New System.Drawing.Point(310, 149)
        Me.Pic_PayOrders.Name = "Pic_PayOrders"
        Me.Pic_PayOrders.Size = New System.Drawing.Size(24, 24)
        Me.Pic_PayOrders.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.Pic_PayOrders.TabIndex = 113
        Me.Pic_PayOrders.TabStop = False
        '
        'Link_PayOrders
        '
        Me.Link_PayOrders.AutoSize = True
        Me.Link_PayOrders.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline
        Me.Link_PayOrders.Location = New System.Drawing.Point(192, 156)
        Me.Link_PayOrders.Name = "Link_PayOrders"
        Me.Link_PayOrders.Size = New System.Drawing.Size(119, 13)
        Me.Link_PayOrders.TabIndex = 112
        Me.Link_PayOrders.TabStop = True
        Me.Link_PayOrders.Text = "Платёжное поручение"
        '
        'Label74
        '
        Me.Label74.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label74.ForeColor = System.Drawing.Color.Red
        Me.Label74.Location = New System.Drawing.Point(107, 67)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(10, 10)
        Me.Label74.TabIndex = 103
        Me.Label74.Text = "*"
        Me.Label74.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label71
        '
        Me.Label71.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label71.ForeColor = System.Drawing.Color.Red
        Me.Label71.Location = New System.Drawing.Point(107, 29)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(10, 10)
        Me.Label71.TabIndex = 102
        Me.Label71.Text = "*"
        Me.Label71.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label73
        '
        Me.Label73.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label73.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label73.Location = New System.Drawing.Point(5, 14)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(18, 81)
        Me.Label73.TabIndex = 100
        Me.Label73.Text = "Период"
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label69.Location = New System.Drawing.Point(222, 180)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(112, 13)
        Me.Label69.TabIndex = 96
        Me.Label69.Text = "Дата отправки в суд"
        '
        'PIR1_txt_DtDispatch
        '
        Me.PIR1_txt_DtDispatch.Location = New System.Drawing.Point(223, 195)
        Me.PIR1_txt_DtDispatch.Mask = "00/00/0000"
        Me.PIR1_txt_DtDispatch.Name = "PIR1_txt_DtDispatch"
        Me.PIR1_txt_DtDispatch.RejectInputOnFirstFailure = True
        Me.PIR1_txt_DtDispatch.ResetOnSpace = False
        Me.PIR1_txt_DtDispatch.Size = New System.Drawing.Size(113, 20)
        Me.PIR1_txt_DtDispatch.TabIndex = 63
        Me.PIR1_txt_DtDispatch.Tag = "isk"
        Me.PIR1_txt_DtDispatch.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.PIR1_txt_DtDispatch.ValidatingType = GetType(Date)
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label54.Location = New System.Drawing.Point(109, 138)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(75, 13)
        Me.Label54.TabIndex = 82
        Me.Label54.Text = "Гос. пошлина"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label53.Location = New System.Drawing.Point(4, 138)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(68, 13)
        Me.Label53.TabIndex = 81
        Me.Label53.Text = "Сумма иска"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label52.Location = New System.Drawing.Point(22, 15)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(44, 13)
        Me.Label52.TabIndex = 47
        Me.Label52.Text = "Начало"
        '
        'PIR1_txt_DtPeriodEnd
        '
        Me.PIR1_txt_DtPeriodEnd.Location = New System.Drawing.Point(25, 69)
        Me.PIR1_txt_DtPeriodEnd.Mask = "00/00/0000"
        Me.PIR1_txt_DtPeriodEnd.Name = "PIR1_txt_DtPeriodEnd"
        Me.PIR1_txt_DtPeriodEnd.RejectInputOnFirstFailure = True
        Me.PIR1_txt_DtPeriodEnd.ResetOnSpace = False
        Me.PIR1_txt_DtPeriodEnd.Size = New System.Drawing.Size(82, 20)
        Me.PIR1_txt_DtPeriodEnd.TabIndex = 52
        Me.PIR1_txt_DtPeriodEnd.Tag = "isk"
        Me.PIR1_txt_DtPeriodEnd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.PIR1_txt_DtPeriodEnd.ValidatingType = GetType(Date)
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label59.Location = New System.Drawing.Point(184, 96)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(99, 13)
        Me.Label59.TabIndex = 87
        Me.Label59.Text = "Судебный участок"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label56.Location = New System.Drawing.Point(257, 15)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(79, 13)
        Me.Label56.TabIndex = 84
        Me.Label56.Text = "Предмет иска"
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label57.Location = New System.Drawing.Point(4, 96)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(111, 13)
        Me.Label57.TabIndex = 85
        Me.Label57.Text = "Судебная инстанция"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label51.Location = New System.Drawing.Point(22, 53)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(38, 13)
        Me.Label51.TabIndex = 48
        Me.Label51.Text = "Конец"
        '
        'PIR1_txt_GovTax
        '
        Me.PIR1_txt_GovTax.Location = New System.Drawing.Point(112, 153)
        Me.PIR1_txt_GovTax.Name = "PIR1_txt_GovTax"
        Me.PIR1_txt_GovTax.ReadOnly = True
        Me.PIR1_txt_GovTax.Size = New System.Drawing.Size(72, 20)
        Me.PIR1_txt_GovTax.TabIndex = 55
        Me.PIR1_txt_GovTax.Tag = "isk"
        '
        'PIR1_txt_DebtSumm
        '
        Me.PIR1_txt_DebtSumm.Location = New System.Drawing.Point(7, 153)
        Me.PIR1_txt_DebtSumm.Name = "PIR1_txt_DebtSumm"
        Me.PIR1_txt_DebtSumm.Size = New System.Drawing.Size(98, 20)
        Me.PIR1_txt_DebtSumm.TabIndex = 54
        Me.PIR1_txt_DebtSumm.Tag = "isk"
        '
        'PIR1_txt_NumberPetition
        '
        Me.PIR1_txt_NumberPetition.BackColor = System.Drawing.SystemColors.Window
        Me.PIR1_txt_NumberPetition.Location = New System.Drawing.Point(8, 194)
        Me.PIR1_txt_NumberPetition.Name = "PIR1_txt_NumberPetition"
        Me.PIR1_txt_NumberPetition.Size = New System.Drawing.Size(122, 20)
        Me.PIR1_txt_NumberPetition.TabIndex = 59
        Me.PIR1_txt_NumberPetition.Tag = "isk"
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label58.Location = New System.Drawing.Point(283, 52)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(53, 13)
        Me.Label58.TabIndex = 86
        Me.Label58.Text = "Тип иска"
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label60.Location = New System.Drawing.Point(5, 180)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(98, 13)
        Me.Label60.TabIndex = 88
        Me.Label60.Text = "Номер заявления"
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label68.Location = New System.Drawing.Point(133, 180)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(90, 13)
        Me.Label68.TabIndex = 95
        Me.Label68.Text = "Дата заявления"
        '
        'PIR1_txt_DtPetitions
        '
        Me.PIR1_txt_DtPetitions.Location = New System.Drawing.Point(136, 195)
        Me.PIR1_txt_DtPetitions.Mask = "00/00/0000"
        Me.PIR1_txt_DtPetitions.Name = "PIR1_txt_DtPetitions"
        Me.PIR1_txt_DtPetitions.RejectInputOnFirstFailure = True
        Me.PIR1_txt_DtPetitions.ResetOnSpace = False
        Me.PIR1_txt_DtPetitions.Size = New System.Drawing.Size(80, 20)
        Me.PIR1_txt_DtPetitions.TabIndex = 61
        Me.PIR1_txt_DtPetitions.Tag = "isk"
        Me.PIR1_txt_DtPetitions.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.PIR1_txt_DtPetitions.ValidatingType = GetType(Date)
        '
        'PIR1_cmb_CourtType
        '
        Me.PIR1_cmb_CourtType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PIR1_cmb_CourtType.FormattingEnabled = True
        Me.PIR1_cmb_CourtType.Location = New System.Drawing.Point(7, 112)
        Me.PIR1_cmb_CourtType.Name = "PIR1_cmb_CourtType"
        Me.PIR1_cmb_CourtType.Size = New System.Drawing.Size(160, 21)
        Me.PIR1_cmb_CourtType.TabIndex = 57
        Me.PIR1_cmb_CourtType.Tag = ""
        '
        'PIR1_cmb_JudicialArea
        '
        Me.PIR1_cmb_JudicialArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PIR1_cmb_JudicialArea.FormattingEnabled = True
        Me.PIR1_cmb_JudicialArea.Location = New System.Drawing.Point(184, 112)
        Me.PIR1_cmb_JudicialArea.Name = "PIR1_cmb_JudicialArea"
        Me.PIR1_cmb_JudicialArea.Size = New System.Drawing.Size(152, 21)
        Me.PIR1_cmb_JudicialArea.TabIndex = 70
        Me.PIR1_cmb_JudicialArea.Tag = ""
        '
        'Label79
        '
        Me.Label79.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label79.ForeColor = System.Drawing.Color.Red
        Me.Label79.Location = New System.Drawing.Point(105, 153)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(10, 10)
        Me.Label79.TabIndex = 108
        Me.Label79.Text = "*"
        Me.Label79.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label80
        '
        Me.Label80.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label80.ForeColor = System.Drawing.Color.Red
        Me.Label80.Location = New System.Drawing.Point(129, 192)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(10, 10)
        Me.Label80.TabIndex = 109
        Me.Label80.Text = "*"
        Me.Label80.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label81
        '
        Me.Label81.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label81.ForeColor = System.Drawing.Color.Red
        Me.Label81.Location = New System.Drawing.Point(215, 192)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(10, 10)
        Me.Label81.TabIndex = 110
        Me.Label81.Text = "*"
        Me.Label81.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label78
        '
        Me.Label78.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label78.ForeColor = System.Drawing.Color.Red
        Me.Label78.Location = New System.Drawing.Point(335, 112)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(10, 10)
        Me.Label78.TabIndex = 107
        Me.Label78.Text = "*"
        Me.Label78.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label76
        '
        Me.Label76.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label76.ForeColor = System.Drawing.Color.Red
        Me.Label76.Location = New System.Drawing.Point(335, 67)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(10, 10)
        Me.Label76.TabIndex = 105
        Me.Label76.Text = "*"
        Me.Label76.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label75
        '
        Me.Label75.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label75.ForeColor = System.Drawing.Color.Red
        Me.Label75.Location = New System.Drawing.Point(335, 29)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(10, 10)
        Me.Label75.TabIndex = 104
        Me.Label75.Text = "*"
        Me.Label75.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label77
        '
        Me.Label77.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label77.ForeColor = System.Drawing.Color.Red
        Me.Label77.Location = New System.Drawing.Point(168, 112)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(10, 10)
        Me.Label77.TabIndex = 106
        Me.Label77.Text = "*"
        Me.Label77.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PIR1_txt_DtPeriodStart
        '
        Me.PIR1_txt_DtPeriodStart.Location = New System.Drawing.Point(25, 31)
        Me.PIR1_txt_DtPeriodStart.Mask = "00/00/0000"
        Me.PIR1_txt_DtPeriodStart.Name = "PIR1_txt_DtPeriodStart"
        Me.PIR1_txt_DtPeriodStart.RejectInputOnFirstFailure = True
        Me.PIR1_txt_DtPeriodStart.ResetOnSpace = False
        Me.PIR1_txt_DtPeriodStart.Size = New System.Drawing.Size(82, 20)
        Me.PIR1_txt_DtPeriodStart.TabIndex = 114
        Me.PIR1_txt_DtPeriodStart.Tag = "isk"
        Me.PIR1_txt_DtPeriodStart.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.PIR1_txt_DtPeriodStart.ValidatingType = GetType(Date)
        '
        'PIR1_cmb_DecisionDirection
        '
        Me.PIR1_cmb_DecisionDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PIR1_cmb_DecisionDirection.FormattingEnabled = True
        Me.PIR1_cmb_DecisionDirection.Location = New System.Drawing.Point(359, 278)
        Me.PIR1_cmb_DecisionDirection.Name = "PIR1_cmb_DecisionDirection"
        Me.PIR1_cmb_DecisionDirection.Size = New System.Drawing.Size(154, 21)
        Me.PIR1_cmb_DecisionDirection.TabIndex = 74
        Me.PIR1_cmb_DecisionDirection.Tag = ""
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label55.Location = New System.Drawing.Point(356, 264)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(115, 13)
        Me.Label55.TabIndex = 83
        Me.Label55.Text = "Направление ИЛ, СП"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.btn_CalPIR1_txt_DtDtJudicialOrder)
        Me.GroupBox8.Controls.Add(Me.PIR1_txt_DealNumber)
        Me.GroupBox8.Controls.Add(Me.Label92)
        Me.GroupBox8.Controls.Add(Me.Label61)
        Me.GroupBox8.Controls.Add(Me.btn_CalPIR1_txt_DtDecision)
        Me.GroupBox8.Controls.Add(Me.PIR1_txt_DtJudicialOrder)
        Me.GroupBox8.Controls.Add(Me.PIR1_txt_DebtSummAfterDecision)
        Me.GroupBox8.Controls.Add(Me.PIR1_txt_DecisionNumber)
        Me.GroupBox8.Controls.Add(Me.Label64)
        Me.GroupBox8.Controls.Add(Me.PIR1_DGView_ListeningHistory)
        Me.GroupBox8.Controls.Add(Me.Label63)
        Me.GroupBox8.Controls.Add(Me.Label72)
        Me.GroupBox8.Controls.Add(Me.PIR1_ToolSt_ListeningMeneger)
        Me.GroupBox8.Controls.Add(Me.PIR1_cmb_DecisionType)
        Me.GroupBox8.Controls.Add(Me.PIR1_cmb_DecisionTypeExt)
        Me.GroupBox8.Controls.Add(Me.PIR1_txt_DtDecision)
        Me.GroupBox8.Controls.Add(Me.Label67)
        Me.GroupBox8.Controls.Add(Me.Label62)
        Me.GroupBox8.Location = New System.Drawing.Point(359, 6)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(408, 255)
        Me.GroupBox8.TabIndex = 100
        Me.GroupBox8.TabStop = False
        '
        'btn_CalPIR1_txt_DtDtJudicialOrder
        '
        Me.btn_CalPIR1_txt_DtDtJudicialOrder.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.btn_CalPIR1_txt_DtDtJudicialOrder.Location = New System.Drawing.Point(172, 228)
        Me.btn_CalPIR1_txt_DtDtJudicialOrder.Name = "btn_CalPIR1_txt_DtDtJudicialOrder"
        Me.btn_CalPIR1_txt_DtDtJudicialOrder.Size = New System.Drawing.Size(20, 20)
        Me.btn_CalPIR1_txt_DtDtJudicialOrder.TabIndex = 122
        '
        'PIR1_txt_DealNumber
        '
        Me.PIR1_txt_DealNumber.Location = New System.Drawing.Point(173, 120)
        Me.PIR1_txt_DealNumber.Name = "PIR1_txt_DealNumber"
        Me.PIR1_txt_DealNumber.Size = New System.Drawing.Size(97, 20)
        Me.PIR1_txt_DealNumber.TabIndex = 123
        Me.PIR1_txt_DealNumber.Tag = "isk"
        '
        'Label92
        '
        Me.Label92.AutoSize = True
        Me.Label92.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label92.Location = New System.Drawing.Point(170, 104)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(48, 13)
        Me.Label92.TabIndex = 124
        Me.Label92.Text = "№ Дела"
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label61.Location = New System.Drawing.Point(3, 104)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(78, 13)
        Me.Label61.TabIndex = 89
        Me.Label61.Text = "Решение суда"
        '
        'btn_CalPIR1_txt_DtDecision
        '
        Me.btn_CalPIR1_txt_DtDecision.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.btn_CalPIR1_txt_DtDecision.Location = New System.Drawing.Point(97, 160)
        Me.btn_CalPIR1_txt_DtDecision.Name = "btn_CalPIR1_txt_DtDecision"
        Me.btn_CalPIR1_txt_DtDecision.Size = New System.Drawing.Size(20, 20)
        Me.btn_CalPIR1_txt_DtDecision.TabIndex = 121
        '
        'PIR1_txt_DtJudicialOrder
        '
        Me.PIR1_txt_DtJudicialOrder.Location = New System.Drawing.Point(82, 228)
        Me.PIR1_txt_DtJudicialOrder.Mask = "00/00/0000"
        Me.PIR1_txt_DtJudicialOrder.Name = "PIR1_txt_DtJudicialOrder"
        Me.PIR1_txt_DtJudicialOrder.RejectInputOnFirstFailure = True
        Me.PIR1_txt_DtJudicialOrder.ResetOnSpace = False
        Me.PIR1_txt_DtJudicialOrder.Size = New System.Drawing.Size(111, 20)
        Me.PIR1_txt_DtJudicialOrder.TabIndex = 76
        Me.PIR1_txt_DtJudicialOrder.Tag = "isk"
        Me.PIR1_txt_DtJudicialOrder.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.PIR1_txt_DtJudicialOrder.ValidatingType = GetType(Date)
        '
        'PIR1_txt_DebtSummAfterDecision
        '
        Me.PIR1_txt_DebtSummAfterDecision.Location = New System.Drawing.Point(151, 159)
        Me.PIR1_txt_DebtSummAfterDecision.Name = "PIR1_txt_DebtSummAfterDecision"
        Me.PIR1_txt_DebtSummAfterDecision.Size = New System.Drawing.Size(81, 20)
        Me.PIR1_txt_DebtSummAfterDecision.TabIndex = 102
        Me.PIR1_txt_DebtSummAfterDecision.Tag = "isk"
        '
        'PIR1_txt_DecisionNumber
        '
        Me.PIR1_txt_DecisionNumber.Location = New System.Drawing.Point(266, 228)
        Me.PIR1_txt_DecisionNumber.Name = "PIR1_txt_DecisionNumber"
        Me.PIR1_txt_DecisionNumber.Size = New System.Drawing.Size(134, 20)
        Me.PIR1_txt_DecisionNumber.TabIndex = 71
        Me.PIR1_txt_DecisionNumber.Tag = "isk"
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label64.Location = New System.Drawing.Point(3, 232)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(73, 13)
        Me.Label64.TabIndex = 92
        Me.Label64.Text = "Дата ИЛ, СП"
        '
        'PIR1_DGView_ListeningHistory
        '
        Me.PIR1_DGView_ListeningHistory.AllowUserToAddRows = False
        Me.PIR1_DGView_ListeningHistory.AllowUserToDeleteRows = False
        Me.PIR1_DGView_ListeningHistory.AllowUserToResizeRows = False
        Me.PIR1_DGView_ListeningHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.PIR1_DGView_ListeningHistory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PIR1_DGView_ListeningHistory.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PIR1_DGView_ListeningHistory.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.PIR1_DGView_ListeningHistory.ColumnHeadersHeight = 20
        Me.PIR1_DGView_ListeningHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.PIR1_DGView_ListeningHistory.DefaultCellStyle = DataGridViewCellStyle12
        Me.PIR1_DGView_ListeningHistory.Dock = System.Windows.Forms.DockStyle.Top
        Me.PIR1_DGView_ListeningHistory.Location = New System.Drawing.Point(3, 16)
        Me.PIR1_DGView_ListeningHistory.MultiSelect = False
        Me.PIR1_DGView_ListeningHistory.Name = "PIR1_DGView_ListeningHistory"
        Me.PIR1_DGView_ListeningHistory.ReadOnly = True
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PIR1_DGView_ListeningHistory.RowHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.PIR1_DGView_ListeningHistory.RowHeadersWidth = 21
        Me.PIR1_DGView_ListeningHistory.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Black
        Me.PIR1_DGView_ListeningHistory.RowsDefaultCellStyle = DataGridViewCellStyle14
        Me.PIR1_DGView_ListeningHistory.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.PIR1_DGView_ListeningHistory.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.PIR1_DGView_ListeningHistory.RowTemplate.Height = 17
        Me.PIR1_DGView_ListeningHistory.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.PIR1_DGView_ListeningHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.PIR1_DGView_ListeningHistory.Size = New System.Drawing.Size(402, 85)
        Me.PIR1_DGView_ListeningHistory.TabIndex = 100
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label63.Location = New System.Drawing.Point(199, 231)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(58, 13)
        Me.Label63.TabIndex = 91
        Me.Label63.Text = "№ ИЛ, СП"
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label72.Location = New System.Drawing.Point(3, 144)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(106, 13)
        Me.Label72.TabIndex = 99
        Me.Label72.Text = "Дата решения суда"
        '
        'PIR1_ToolSt_ListeningMeneger
        '
        Me.PIR1_ToolSt_ListeningMeneger.Dock = System.Windows.Forms.DockStyle.None
        Me.PIR1_ToolSt_ListeningMeneger.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.PIR1_ToolSt_ListeningMeneger.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PIR1_Btn_AddNewListening, Me.ToolStripSeparator4, Me.PIR1_Btn_EditListening, Me.ToolStripSeparator5, Me.PIR1_Btn_DeleteListening})
        Me.PIR1_ToolSt_ListeningMeneger.Location = New System.Drawing.Point(317, 104)
        Me.PIR1_ToolSt_ListeningMeneger.Name = "PIR1_ToolSt_ListeningMeneger"
        Me.PIR1_ToolSt_ListeningMeneger.Size = New System.Drawing.Size(87, 27)
        Me.PIR1_ToolSt_ListeningMeneger.TabIndex = 101
        '
        'PIR1_Btn_AddNewListening
        '
        Me.PIR1_Btn_AddNewListening.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PIR1_Btn_AddNewListening.Enabled = False
        Me.PIR1_Btn_AddNewListening.Image = CType(resources.GetObject("PIR1_Btn_AddNewListening.Image"), System.Drawing.Image)
        Me.PIR1_Btn_AddNewListening.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.PIR1_Btn_AddNewListening.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PIR1_Btn_AddNewListening.Name = "PIR1_Btn_AddNewListening"
        Me.PIR1_Btn_AddNewListening.Size = New System.Drawing.Size(24, 24)
        Me.PIR1_Btn_AddNewListening.ToolTipText = "Добавить слушание"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 27)
        '
        'PIR1_Btn_EditListening
        '
        Me.PIR1_Btn_EditListening.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PIR1_Btn_EditListening.Enabled = False
        Me.PIR1_Btn_EditListening.Image = CType(resources.GetObject("PIR1_Btn_EditListening.Image"), System.Drawing.Image)
        Me.PIR1_Btn_EditListening.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.PIR1_Btn_EditListening.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PIR1_Btn_EditListening.Name = "PIR1_Btn_EditListening"
        Me.PIR1_Btn_EditListening.Size = New System.Drawing.Size(24, 24)
        Me.PIR1_Btn_EditListening.ToolTipText = "Редактировать запись"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 27)
        '
        'PIR1_Btn_DeleteListening
        '
        Me.PIR1_Btn_DeleteListening.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PIR1_Btn_DeleteListening.Enabled = False
        Me.PIR1_Btn_DeleteListening.Image = CType(resources.GetObject("PIR1_Btn_DeleteListening.Image"), System.Drawing.Image)
        Me.PIR1_Btn_DeleteListening.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.PIR1_Btn_DeleteListening.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PIR1_Btn_DeleteListening.Name = "PIR1_Btn_DeleteListening"
        Me.PIR1_Btn_DeleteListening.Size = New System.Drawing.Size(24, 24)
        Me.PIR1_Btn_DeleteListening.ToolTipText = "Удалить запись"
        '
        'PIR1_cmb_DecisionType
        '
        Me.PIR1_cmb_DecisionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PIR1_cmb_DecisionType.FormattingEnabled = True
        Me.PIR1_cmb_DecisionType.Location = New System.Drawing.Point(6, 120)
        Me.PIR1_cmb_DecisionType.Name = "PIR1_cmb_DecisionType"
        Me.PIR1_cmb_DecisionType.Size = New System.Drawing.Size(161, 21)
        Me.PIR1_cmb_DecisionType.TabIndex = 72
        Me.PIR1_cmb_DecisionType.Tag = ""
        '
        'PIR1_cmb_DecisionTypeExt
        '
        Me.PIR1_cmb_DecisionTypeExt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PIR1_cmb_DecisionTypeExt.DropDownWidth = 450
        Me.PIR1_cmb_DecisionTypeExt.FormattingEnabled = True
        Me.PIR1_cmb_DecisionTypeExt.Location = New System.Drawing.Point(6, 200)
        Me.PIR1_cmb_DecisionTypeExt.Name = "PIR1_cmb_DecisionTypeExt"
        Me.PIR1_cmb_DecisionTypeExt.Size = New System.Drawing.Size(394, 21)
        Me.PIR1_cmb_DecisionTypeExt.TabIndex = 73
        Me.PIR1_cmb_DecisionTypeExt.Tag = ""
        '
        'PIR1_txt_DtDecision
        '
        Me.PIR1_txt_DtDecision.Location = New System.Drawing.Point(6, 159)
        Me.PIR1_txt_DtDecision.Mask = "00/00/0000"
        Me.PIR1_txt_DtDecision.Name = "PIR1_txt_DtDecision"
        Me.PIR1_txt_DtDecision.RejectInputOnFirstFailure = True
        Me.PIR1_txt_DtDecision.ResetOnSpace = False
        Me.PIR1_txt_DtDecision.Size = New System.Drawing.Size(111, 20)
        Me.PIR1_txt_DtDecision.TabIndex = 69
        Me.PIR1_txt_DtDecision.Tag = "isk"
        Me.PIR1_txt_DtDecision.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.PIR1_txt_DtDecision.ValidatingType = GetType(Date)
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label67.Location = New System.Drawing.Point(148, 144)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(148, 13)
        Me.Label67.TabIndex = 103
        Me.Label67.Text = "Сумма иска после решения"
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label62.Location = New System.Drawing.Point(3, 184)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(123, 13)
        Me.Label62.TabIndex = 90
        Me.Label62.Text = "Причина решения суда"
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label66.Location = New System.Drawing.Point(550, 323)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(129, 13)
        Me.Label66.TabIndex = 116
        Me.Label66.Text = "Дата окончания ИЛ, СП"
        '
        'PIR1_txt_DtClosePetitionDebt
        '
        Me.PIR1_txt_DtClosePetitionDebt.Location = New System.Drawing.Point(679, 320)
        Me.PIR1_txt_DtClosePetitionDebt.Mask = "00/00/0000"
        Me.PIR1_txt_DtClosePetitionDebt.Name = "PIR1_txt_DtClosePetitionDebt"
        Me.PIR1_txt_DtClosePetitionDebt.RejectInputOnFirstFailure = True
        Me.PIR1_txt_DtClosePetitionDebt.ResetOnSpace = False
        Me.PIR1_txt_DtClosePetitionDebt.Size = New System.Drawing.Size(89, 20)
        Me.PIR1_txt_DtClosePetitionDebt.TabIndex = 117
        Me.PIR1_txt_DtClosePetitionDebt.Tag = "isk"
        Me.PIR1_txt_DtClosePetitionDebt.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.PIR1_txt_DtClosePetitionDebt.ValidatingType = GetType(Date)
        '
        'PIR1_TP_SSPWork
        '
        Me.PIR1_TP_SSPWork.BackColor = System.Drawing.SystemColors.Control
        Me.PIR1_TP_SSPWork.Controls.Add(Me.Pan_PetitionControls)
        Me.PIR1_TP_SSPWork.Controls.Add(Me.PIR1_ToolSt_PetitionsMeneger)
        Me.PIR1_TP_SSPWork.Controls.Add(Me.PIR1_DGView_Petitions)
        Me.PIR1_TP_SSPWork.Location = New System.Drawing.Point(4, 22)
        Me.PIR1_TP_SSPWork.Name = "PIR1_TP_SSPWork"
        Me.PIR1_TP_SSPWork.Padding = New System.Windows.Forms.Padding(3)
        Me.PIR1_TP_SSPWork.Size = New System.Drawing.Size(777, 347)
        Me.PIR1_TP_SSPWork.TabIndex = 1
        Me.PIR1_TP_SSPWork.Text = "Исполнительное производство"
        '
        'Pan_PetitionControls
        '
        Me.Pan_PetitionControls.Controls.Add(Me.btn_CalPIR1_txt_DtActImpossibleRecovery)
        Me.Pan_PetitionControls.Controls.Add(Me.btn_CalPIR1_txt_ExcitementDt)
        Me.Pan_PetitionControls.Controls.Add(Me.PIR1_cmb_ActImpossibleRecovery)
        Me.Pan_PetitionControls.Controls.Add(Me.PIR1_txt_DtActImpossibleRecovery)
        Me.Pan_PetitionControls.Controls.Add(Me.PIR1_txt_ExecutiveNumber)
        Me.Pan_PetitionControls.Controls.Add(Me.Label85)
        Me.Pan_PetitionControls.Controls.Add(Me.Label91)
        Me.Pan_PetitionControls.Controls.Add(Me.Label88)
        Me.Pan_PetitionControls.Controls.Add(Me.Label90)
        Me.Pan_PetitionControls.Controls.Add(Me.Label89)
        Me.Pan_PetitionControls.Controls.Add(Me.Label87)
        Me.Pan_PetitionControls.Controls.Add(Me.PIR1_txt_NotePetition)
        Me.Pan_PetitionControls.Controls.Add(Me.PIR1_txt_ExcitementDt)
        Me.Pan_PetitionControls.Controls.Add(Me.btn_CalPIR1_txt_DtCompletion)
        Me.Pan_PetitionControls.Controls.Add(Me.PIR1_cmb_CopPerformer)
        Me.Pan_PetitionControls.Controls.Add(Me.PIR1_txt_DtCompletion)
        Me.Pan_PetitionControls.Controls.Add(Me.Label70)
        Me.Pan_PetitionControls.Controls.Add(Me.Label83)
        Me.Pan_PetitionControls.Controls.Add(Me.Label84)
        Me.Pan_PetitionControls.Controls.Add(Me.PIR1_txt_PetitionSumm)
        Me.Pan_PetitionControls.Controls.Add(Me.Label86)
        Me.Pan_PetitionControls.Controls.Add(Me.Label82)
        Me.Pan_PetitionControls.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pan_PetitionControls.Location = New System.Drawing.Point(3, 158)
        Me.Pan_PetitionControls.Name = "Pan_PetitionControls"
        Me.Pan_PetitionControls.Size = New System.Drawing.Size(771, 142)
        Me.Pan_PetitionControls.TabIndex = 110
        '
        'btn_CalPIR1_txt_DtActImpossibleRecovery
        '
        Me.btn_CalPIR1_txt_DtActImpossibleRecovery.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.btn_CalPIR1_txt_DtActImpossibleRecovery.Location = New System.Drawing.Point(415, 17)
        Me.btn_CalPIR1_txt_DtActImpossibleRecovery.Name = "btn_CalPIR1_txt_DtActImpossibleRecovery"
        Me.btn_CalPIR1_txt_DtActImpossibleRecovery.Size = New System.Drawing.Size(20, 20)
        Me.btn_CalPIR1_txt_DtActImpossibleRecovery.TabIndex = 128
        Me.btn_CalPIR1_txt_DtActImpossibleRecovery.Tag = "PIR1_txt_DtActImpossibleRecovery"
        '
        'btn_CalPIR1_txt_ExcitementDt
        '
        Me.btn_CalPIR1_txt_ExcitementDt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.btn_CalPIR1_txt_ExcitementDt.Location = New System.Drawing.Point(221, 49)
        Me.btn_CalPIR1_txt_ExcitementDt.Name = "btn_CalPIR1_txt_ExcitementDt"
        Me.btn_CalPIR1_txt_ExcitementDt.Size = New System.Drawing.Size(20, 20)
        Me.btn_CalPIR1_txt_ExcitementDt.TabIndex = 119
        Me.btn_CalPIR1_txt_ExcitementDt.Tag = "PIR1_txt_ExcitementDt"
        '
        'PIR1_cmb_ActImpossibleRecovery
        '
        Me.PIR1_cmb_ActImpossibleRecovery.FormattingEnabled = True
        Me.PIR1_cmb_ActImpossibleRecovery.Location = New System.Drawing.Point(345, 49)
        Me.PIR1_cmb_ActImpossibleRecovery.Name = "PIR1_cmb_ActImpossibleRecovery"
        Me.PIR1_cmb_ActImpossibleRecovery.Size = New System.Drawing.Size(241, 21)
        Me.PIR1_cmb_ActImpossibleRecovery.TabIndex = 130
        '
        'PIR1_txt_DtActImpossibleRecovery
        '
        Me.PIR1_txt_DtActImpossibleRecovery.Location = New System.Drawing.Point(345, 17)
        Me.PIR1_txt_DtActImpossibleRecovery.Mask = "00/00/0000"
        Me.PIR1_txt_DtActImpossibleRecovery.Name = "PIR1_txt_DtActImpossibleRecovery"
        Me.PIR1_txt_DtActImpossibleRecovery.RejectInputOnFirstFailure = True
        Me.PIR1_txt_DtActImpossibleRecovery.ResetOnSpace = False
        Me.PIR1_txt_DtActImpossibleRecovery.Size = New System.Drawing.Size(90, 20)
        Me.PIR1_txt_DtActImpossibleRecovery.TabIndex = 127
        Me.PIR1_txt_DtActImpossibleRecovery.Tag = "isk"
        Me.PIR1_txt_DtActImpossibleRecovery.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.PIR1_txt_DtActImpossibleRecovery.ValidatingType = GetType(Date)
        '
        'PIR1_txt_ExecutiveNumber
        '
        Me.PIR1_txt_ExecutiveNumber.Location = New System.Drawing.Point(0, 19)
        Me.PIR1_txt_ExecutiveNumber.Name = "PIR1_txt_ExecutiveNumber"
        Me.PIR1_txt_ExecutiveNumber.Size = New System.Drawing.Size(115, 20)
        Me.PIR1_txt_ExecutiveNumber.TabIndex = 120
        '
        'Label85
        '
        Me.Label85.AutoSize = True
        Me.Label85.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label85.Location = New System.Drawing.Point(254, 20)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(104, 13)
        Me.Label85.TabIndex = 129
        Me.Label85.Text = "Дата акта о НВ      "
        '
        'Label91
        '
        Me.Label91.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label91.ForeColor = System.Drawing.Color.Red
        Me.Label91.Location = New System.Drawing.Point(242, 49)
        Me.Label91.Name = "Label91"
        Me.Label91.Size = New System.Drawing.Size(10, 10)
        Me.Label91.TabIndex = 141
        Me.Label91.Text = "*"
        Me.Label91.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label88
        '
        Me.Label88.AutoSize = True
        Me.Label88.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label88.Location = New System.Drawing.Point(274, 52)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(80, 13)
        Me.Label88.TabIndex = 136
        Me.Label88.Text = "Причина          "
        '
        'Label90
        '
        Me.Label90.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label90.ForeColor = System.Drawing.Color.Red
        Me.Label90.Location = New System.Drawing.Point(242, 18)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(10, 10)
        Me.Label90.TabIndex = 140
        Me.Label90.Text = "*"
        Me.Label90.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label89
        '
        Me.Label89.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label89.ForeColor = System.Drawing.Color.Red
        Me.Label89.Location = New System.Drawing.Point(116, 19)
        Me.Label89.Name = "Label89"
        Me.Label89.Size = New System.Drawing.Size(10, 10)
        Me.Label89.TabIndex = 139
        Me.Label89.Text = "*"
        Me.Label89.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label87
        '
        Me.Label87.AutoSize = True
        Me.Label87.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label87.Location = New System.Drawing.Point(595, 3)
        Me.Label87.Name = "Label87"
        Me.Label87.Size = New System.Drawing.Size(105, 13)
        Me.Label87.TabIndex = 135
        Me.Label87.Text = "Комментарий к ИП"
        '
        'PIR1_txt_NotePetition
        '
        Me.PIR1_txt_NotePetition.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PIR1_txt_NotePetition.Location = New System.Drawing.Point(598, 19)
        Me.PIR1_txt_NotePetition.MaximumSize = New System.Drawing.Size(250, 102)
        Me.PIR1_txt_NotePetition.MaxLength = 300
        Me.PIR1_txt_NotePetition.Multiline = True
        Me.PIR1_txt_NotePetition.Name = "PIR1_txt_NotePetition"
        Me.PIR1_txt_NotePetition.Size = New System.Drawing.Size(167, 102)
        Me.PIR1_txt_NotePetition.TabIndex = 134
        Me.PIR1_txt_NotePetition.Tag = "isk"
        '
        'PIR1_txt_ExcitementDt
        '
        Me.PIR1_txt_ExcitementDt.Location = New System.Drawing.Point(143, 49)
        Me.PIR1_txt_ExcitementDt.Mask = "00/00/0000"
        Me.PIR1_txt_ExcitementDt.Name = "PIR1_txt_ExcitementDt"
        Me.PIR1_txt_ExcitementDt.RejectInputOnFirstFailure = True
        Me.PIR1_txt_ExcitementDt.ResetOnSpace = False
        Me.PIR1_txt_ExcitementDt.Size = New System.Drawing.Size(98, 20)
        Me.PIR1_txt_ExcitementDt.TabIndex = 118
        Me.PIR1_txt_ExcitementDt.Tag = ""
        Me.PIR1_txt_ExcitementDt.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.PIR1_txt_ExcitementDt.ValidatingType = GetType(Date)
        '
        'btn_CalPIR1_txt_DtCompletion
        '
        Me.btn_CalPIR1_txt_DtCompletion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.btn_CalPIR1_txt_DtCompletion.Location = New System.Drawing.Point(460, 100)
        Me.btn_CalPIR1_txt_DtCompletion.Name = "btn_CalPIR1_txt_DtCompletion"
        Me.btn_CalPIR1_txt_DtCompletion.Size = New System.Drawing.Size(20, 20)
        Me.btn_CalPIR1_txt_DtCompletion.TabIndex = 132
        Me.btn_CalPIR1_txt_DtCompletion.Tag = "PIR1_txt_DtCompletion"
        '
        'PIR1_cmb_CopPerformer
        '
        Me.PIR1_cmb_CopPerformer.FormattingEnabled = True
        Me.PIR1_cmb_CopPerformer.Location = New System.Drawing.Point(3, 100)
        Me.PIR1_cmb_CopPerformer.Name = "PIR1_cmb_CopPerformer"
        Me.PIR1_cmb_CopPerformer.Size = New System.Drawing.Size(241, 21)
        Me.PIR1_cmb_CopPerformer.TabIndex = 121
        '
        'PIR1_txt_DtCompletion
        '
        Me.PIR1_txt_DtCompletion.Location = New System.Drawing.Point(386, 100)
        Me.PIR1_txt_DtCompletion.Mask = "00/00/0000"
        Me.PIR1_txt_DtCompletion.Name = "PIR1_txt_DtCompletion"
        Me.PIR1_txt_DtCompletion.RejectInputOnFirstFailure = True
        Me.PIR1_txt_DtCompletion.ResetOnSpace = False
        Me.PIR1_txt_DtCompletion.Size = New System.Drawing.Size(94, 20)
        Me.PIR1_txt_DtCompletion.TabIndex = 131
        Me.PIR1_txt_DtCompletion.Tag = "isk"
        Me.PIR1_txt_DtCompletion.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.PIR1_txt_DtCompletion.ValidatingType = GetType(Date)
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label70.Location = New System.Drawing.Point(0, 84)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(175, 13)
        Me.Label70.TabIndex = 122
        Me.Label70.Text = "Судебный пристав - исполнитель"
        '
        'Label83
        '
        Me.Label83.AutoSize = True
        Me.Label83.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label83.Location = New System.Drawing.Point(-1, 3)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(60, 13)
        Me.Label83.TabIndex = 124
        Me.Label83.Text = "Номер ИП"
        '
        'Label84
        '
        Me.Label84.AutoSize = True
        Me.Label84.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label84.Location = New System.Drawing.Point(140, 3)
        Me.Label84.Name = "Label84"
        Me.Label84.Size = New System.Drawing.Size(68, 13)
        Me.Label84.TabIndex = 126
        Me.Label84.Text = "Сумма иска"
        '
        'PIR1_txt_PetitionSumm
        '
        Me.PIR1_txt_PetitionSumm.Location = New System.Drawing.Point(143, 19)
        Me.PIR1_txt_PetitionSumm.Name = "PIR1_txt_PetitionSumm"
        Me.PIR1_txt_PetitionSumm.Size = New System.Drawing.Size(98, 20)
        Me.PIR1_txt_PetitionSumm.TabIndex = 125
        Me.PIR1_txt_PetitionSumm.Tag = "isk"
        '
        'Label86
        '
        Me.Label86.AutoSize = True
        Me.Label86.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label86.Location = New System.Drawing.Point(266, 103)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(123, 13)
        Me.Label86.TabIndex = 133
        Me.Label86.Text = "Дата окончания ИП     "
        '
        'Label82
        '
        Me.Label82.AutoSize = True
        Me.Label82.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label82.Location = New System.Drawing.Point(0, 52)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(149, 13)
        Me.Label82.TabIndex = 123
        Me.Label82.Text = "Дата возбуждение ИП         "
        '
        'PIR1_ToolSt_PetitionsMeneger
        '
        Me.PIR1_ToolSt_PetitionsMeneger.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.PIR1_ToolSt_PetitionsMeneger.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PIR1_Btn_AddNewPetition, Me.ToolStripSeparator6, Me.PIR1_Btn_DeletePetition})
        Me.PIR1_ToolSt_PetitionsMeneger.Location = New System.Drawing.Point(3, 131)
        Me.PIR1_ToolSt_PetitionsMeneger.Name = "PIR1_ToolSt_PetitionsMeneger"
        Me.PIR1_ToolSt_PetitionsMeneger.Size = New System.Drawing.Size(771, 27)
        Me.PIR1_ToolSt_PetitionsMeneger.TabIndex = 138
        '
        'PIR1_Btn_AddNewPetition
        '
        Me.PIR1_Btn_AddNewPetition.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PIR1_Btn_AddNewPetition.Enabled = False
        Me.PIR1_Btn_AddNewPetition.Image = CType(resources.GetObject("PIR1_Btn_AddNewPetition.Image"), System.Drawing.Image)
        Me.PIR1_Btn_AddNewPetition.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.PIR1_Btn_AddNewPetition.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PIR1_Btn_AddNewPetition.Name = "PIR1_Btn_AddNewPetition"
        Me.PIR1_Btn_AddNewPetition.Size = New System.Drawing.Size(24, 24)
        Me.PIR1_Btn_AddNewPetition.ToolTipText = "Добавить исполнительное производство"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 27)
        '
        'PIR1_Btn_DeletePetition
        '
        Me.PIR1_Btn_DeletePetition.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PIR1_Btn_DeletePetition.Enabled = False
        Me.PIR1_Btn_DeletePetition.Image = CType(resources.GetObject("PIR1_Btn_DeletePetition.Image"), System.Drawing.Image)
        Me.PIR1_Btn_DeletePetition.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.PIR1_Btn_DeletePetition.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PIR1_Btn_DeletePetition.Name = "PIR1_Btn_DeletePetition"
        Me.PIR1_Btn_DeletePetition.Size = New System.Drawing.Size(24, 24)
        Me.PIR1_Btn_DeletePetition.ToolTipText = "Удалить исполнительное производство"
        '
        'PIR1_DGView_Petitions
        '
        Me.PIR1_DGView_Petitions.AllowUserToAddRows = False
        Me.PIR1_DGView_Petitions.AllowUserToDeleteRows = False
        Me.PIR1_DGView_Petitions.AllowUserToResizeRows = False
        Me.PIR1_DGView_Petitions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.PIR1_DGView_Petitions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PIR1_DGView_Petitions.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PIR1_DGView_Petitions.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.PIR1_DGView_Petitions.ColumnHeadersHeight = 20
        Me.PIR1_DGView_Petitions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.PIR1_DGView_Petitions.DefaultCellStyle = DataGridViewCellStyle16
        Me.PIR1_DGView_Petitions.Dock = System.Windows.Forms.DockStyle.Top
        Me.PIR1_DGView_Petitions.Location = New System.Drawing.Point(3, 3)
        Me.PIR1_DGView_Petitions.MultiSelect = False
        Me.PIR1_DGView_Petitions.Name = "PIR1_DGView_Petitions"
        Me.PIR1_DGView_Petitions.ReadOnly = True
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PIR1_DGView_Petitions.RowHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.PIR1_DGView_Petitions.RowHeadersWidth = 21
        Me.PIR1_DGView_Petitions.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.PIR1_DGView_Petitions.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.PIR1_DGView_Petitions.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.PIR1_DGView_Petitions.RowTemplate.Height = 17
        Me.PIR1_DGView_Petitions.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.PIR1_DGView_Petitions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.PIR1_DGView_Petitions.Size = New System.Drawing.Size(771, 128)
        Me.PIR1_DGView_Petitions.TabIndex = 100
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.PIR1_DGView_PetitionsDebt)
        Me.GroupBox6.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox6.Location = New System.Drawing.Point(3, 61)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(781, 139)
        Me.GroupBox6.TabIndex = 112
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "История исков"
        '
        'PIR1_DGView_PetitionsDebt
        '
        Me.PIR1_DGView_PetitionsDebt.AllowUserToAddRows = False
        Me.PIR1_DGView_PetitionsDebt.AllowUserToDeleteRows = False
        Me.PIR1_DGView_PetitionsDebt.AllowUserToResizeRows = False
        Me.PIR1_DGView_PetitionsDebt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.PIR1_DGView_PetitionsDebt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PIR1_DGView_PetitionsDebt.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PIR1_DGView_PetitionsDebt.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.PIR1_DGView_PetitionsDebt.ColumnHeadersHeight = 20
        Me.PIR1_DGView_PetitionsDebt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.PIR1_DGView_PetitionsDebt.DefaultCellStyle = DataGridViewCellStyle19
        Me.PIR1_DGView_PetitionsDebt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PIR1_DGView_PetitionsDebt.Location = New System.Drawing.Point(3, 16)
        Me.PIR1_DGView_PetitionsDebt.MultiSelect = False
        Me.PIR1_DGView_PetitionsDebt.Name = "PIR1_DGView_PetitionsDebt"
        Me.PIR1_DGView_PetitionsDebt.ReadOnly = True
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PIR1_DGView_PetitionsDebt.RowHeadersDefaultCellStyle = DataGridViewCellStyle20
        Me.PIR1_DGView_PetitionsDebt.RowHeadersWidth = 21
        Me.PIR1_DGView_PetitionsDebt.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(197, Byte), Integer))
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.Black
        Me.PIR1_DGView_PetitionsDebt.RowsDefaultCellStyle = DataGridViewCellStyle21
        Me.PIR1_DGView_PetitionsDebt.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.PIR1_DGView_PetitionsDebt.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.PIR1_DGView_PetitionsDebt.RowTemplate.Height = 17
        Me.PIR1_DGView_PetitionsDebt.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.PIR1_DGView_PetitionsDebt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.PIR1_DGView_PetitionsDebt.Size = New System.Drawing.Size(775, 120)
        Me.PIR1_DGView_PetitionsDebt.TabIndex = 111
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.PictBox_1_Suit)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.PIR1_ToolSt_PetitionsDebtMeneger)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(781, 58)
        Me.Panel4.TabIndex = 113
        '
        'PictBox_1_Suit
        '
        Me.PictBox_1_Suit.BackColor = System.Drawing.Color.Transparent
        Me.PictBox_1_Suit.Image = CType(resources.GetObject("PictBox_1_Suit.Image"), System.Drawing.Image)
        Me.PictBox_1_Suit.Location = New System.Drawing.Point(0, 0)
        Me.PictBox_1_Suit.Name = "PictBox_1_Suit"
        Me.PictBox_1_Suit.Size = New System.Drawing.Size(50, 50)
        Me.PictBox_1_Suit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictBox_1_Suit.TabIndex = 108
        Me.PictBox_1_Suit.TabStop = False
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label6.Location = New System.Drawing.Point(60, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(177, 50)
        Me.Label6.TabIndex = 109
        Me.Label6.Text = """ПИР - Электроэнергия"" Иски"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PIR1_ToolSt_PetitionsDebtMeneger
        '
        Me.PIR1_ToolSt_PetitionsDebtMeneger.AutoSize = False
        Me.PIR1_ToolSt_PetitionsDebtMeneger.Dock = System.Windows.Forms.DockStyle.None
        Me.PIR1_ToolSt_PetitionsDebtMeneger.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.PIR1_ToolSt_PetitionsDebtMeneger.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PIR1_Btn_AddNewPetitionDebt, Me.ToolStripSeparator1, Me.PIR1_Btn_DeletePetitionDebt, Me.ToolStripSeparator2, Me.PIR1_Btn_SavePetitionDebt, Me.ToolStripSeparator3, Me.PIR1_Btn_Filter, Me.PIR1_Btn_Reports})
        Me.PIR1_ToolSt_PetitionsDebtMeneger.Location = New System.Drawing.Point(464, 13)
        Me.PIR1_ToolSt_PetitionsDebtMeneger.Name = "PIR1_ToolSt_PetitionsDebtMeneger"
        Me.PIR1_ToolSt_PetitionsDebtMeneger.Padding = New System.Windows.Forms.Padding(0)
        Me.PIR1_ToolSt_PetitionsDebtMeneger.Size = New System.Drawing.Size(307, 42)
        Me.PIR1_ToolSt_PetitionsDebtMeneger.TabIndex = 8
        '
        'PIR1_Btn_AddNewPetitionDebt
        '
        Me.PIR1_Btn_AddNewPetitionDebt.AutoSize = False
        Me.PIR1_Btn_AddNewPetitionDebt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PIR1_Btn_AddNewPetitionDebt.Image = Global.Pripyat.My.Resources.Resources.Create_32x32
        Me.PIR1_Btn_AddNewPetitionDebt.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.PIR1_Btn_AddNewPetitionDebt.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PIR1_Btn_AddNewPetitionDebt.Name = "PIR1_Btn_AddNewPetitionDebt"
        Me.PIR1_Btn_AddNewPetitionDebt.Size = New System.Drawing.Size(35, 35)
        Me.PIR1_Btn_AddNewPetitionDebt.ToolTipText = "Добавить новы иск"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 42)
        '
        'PIR1_Btn_DeletePetitionDebt
        '
        Me.PIR1_Btn_DeletePetitionDebt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PIR1_Btn_DeletePetitionDebt.Image = Global.Pripyat.My.Resources.Resources.Delete_32x32
        Me.PIR1_Btn_DeletePetitionDebt.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.PIR1_Btn_DeletePetitionDebt.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PIR1_Btn_DeletePetitionDebt.Name = "PIR1_Btn_DeletePetitionDebt"
        Me.PIR1_Btn_DeletePetitionDebt.Size = New System.Drawing.Size(36, 39)
        Me.PIR1_Btn_DeletePetitionDebt.ToolTipText = "Удалить иск"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 42)
        '
        'PIR1_Btn_SavePetitionDebt
        '
        Me.PIR1_Btn_SavePetitionDebt.AutoSize = False
        Me.PIR1_Btn_SavePetitionDebt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PIR1_Btn_SavePetitionDebt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PIR1_Btn_SavePetitionDebt.Enabled = False
        Me.PIR1_Btn_SavePetitionDebt.Image = Global.Pripyat.My.Resources.Resources.save_32x32
        Me.PIR1_Btn_SavePetitionDebt.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.PIR1_Btn_SavePetitionDebt.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PIR1_Btn_SavePetitionDebt.Name = "PIR1_Btn_SavePetitionDebt"
        Me.PIR1_Btn_SavePetitionDebt.Size = New System.Drawing.Size(36, 39)
        Me.PIR1_Btn_SavePetitionDebt.ToolTipText = "Сохранить изменения в записях " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "исковых мероприятий"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 42)
        '
        'PIR1_Btn_Filter
        '
        Me.PIR1_Btn_Filter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PIR1_Btn_Filter.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ВсеИскиToolStripMenuItem, Me.ОконченныеToolStripMenuItem, Me.ВИсполненииToolStripMenuItem, Me.ПоЧленуСемьиToolStripMenuItem, Me.СписаниеToolStripMenuItem})
        Me.PIR1_Btn_Filter.Image = Global.Pripyat.My.Resources.Resources.filter_32x32
        Me.PIR1_Btn_Filter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.PIR1_Btn_Filter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PIR1_Btn_Filter.Name = "PIR1_Btn_Filter"
        Me.PIR1_Btn_Filter.Size = New System.Drawing.Size(131, 39)
        Me.PIR1_Btn_Filter.Text = "Фильтр исков"
        Me.PIR1_Btn_Filter.ToolTipText = "Параметры отображения списков исков"
        '
        'ВсеИскиToolStripMenuItem
        '
        Me.ВсеИскиToolStripMenuItem.CheckOnClick = True
        Me.ВсеИскиToolStripMenuItem.Name = "ВсеИскиToolStripMenuItem"
        Me.ВсеИскиToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.ВсеИскиToolStripMenuItem.Text = "Все иски"
        '
        'ОконченныеToolStripMenuItem
        '
        Me.ОконченныеToolStripMenuItem.CheckOnClick = True
        Me.ОконченныеToolStripMenuItem.Name = "ОконченныеToolStripMenuItem"
        Me.ОконченныеToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.ОконченныеToolStripMenuItem.Text = "Оконченные"
        '
        'ВИсполненииToolStripMenuItem
        '
        Me.ВИсполненииToolStripMenuItem.CheckOnClick = True
        Me.ВИсполненииToolStripMenuItem.Name = "ВИсполненииToolStripMenuItem"
        Me.ВИсполненииToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.ВИсполненииToolStripMenuItem.Text = "В исполнении"
        '
        'ПоЧленуСемьиToolStripMenuItem
        '
        Me.ПоЧленуСемьиToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmd_TSMenu_FilterMember})
        Me.ПоЧленуСемьиToolStripMenuItem.Name = "ПоЧленуСемьиToolStripMenuItem"
        Me.ПоЧленуСемьиToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.ПоЧленуСемьиToolStripMenuItem.Text = "По члену семьи"
        '
        'cmd_TSMenu_FilterMember
        '
        Me.cmd_TSMenu_FilterMember.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmd_TSMenu_FilterMember.DropDownWidth = 200
        Me.cmd_TSMenu_FilterMember.Name = "cmd_TSMenu_FilterMember"
        Me.cmd_TSMenu_FilterMember.Size = New System.Drawing.Size(200, 23)
        '
        'СписаниеToolStripMenuItem
        '
        Me.СписаниеToolStripMenuItem.CheckOnClick = True
        Me.СписаниеToolStripMenuItem.Name = "СписаниеToolStripMenuItem"
        Me.СписаниеToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.СписаниеToolStripMenuItem.Text = "Переданы на списание"
        '
        'PIR1_Btn_Reports
        '
        Me.PIR1_Btn_Reports.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PIR1_Btn_Reports.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PIR1_Btn_Reports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PIR1_Btn_ReportsBlankPetition, Me.РасчетЦеныИскаToolStripMenuItem})
        Me.PIR1_Btn_Reports.Image = CType(resources.GetObject("PIR1_Btn_Reports.Image"), System.Drawing.Image)
        Me.PIR1_Btn_Reports.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.PIR1_Btn_Reports.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PIR1_Btn_Reports.Name = "PIR1_Btn_Reports"
        Me.PIR1_Btn_Reports.Size = New System.Drawing.Size(48, 39)
        Me.PIR1_Btn_Reports.ToolTipText = "Бланки и прочие отчеты"
        '
        'PIR1_Btn_ReportsBlankPetition
        '
        Me.PIR1_Btn_ReportsBlankPetition.Image = Global.Pripyat.My.Resources.Resources.BlankPetition_50x50
        Me.PIR1_Btn_ReportsBlankPetition.Name = "PIR1_Btn_ReportsBlankPetition"
        Me.PIR1_Btn_ReportsBlankPetition.Size = New System.Drawing.Size(171, 22)
        Me.PIR1_Btn_ReportsBlankPetition.Text = "Заявление в суд"
        '
        'РасчетЦеныИскаToolStripMenuItem
        '
        Me.РасчетЦеныИскаToolStripMenuItem.Image = Global.Pripyat.My.Resources.Resources.RaschetPetition_50x50
        Me.РасчетЦеныИскаToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.РасчетЦеныИскаToolStripMenuItem.Name = "РасчетЦеныИскаToolStripMenuItem"
        Me.РасчетЦеныИскаToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.РасчетЦеныИскаToolStripMenuItem.Text = "Расчет цены иска"
        '
        'Request_1
        '
        Me.Request_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Request_1.Controls.Add(Me.Label7)
        Me.Request_1.Controls.Add(Me.PictBox_1_Request)
        Me.Request_1.Location = New System.Drawing.Point(4, 24)
        Me.Request_1.Name = "Request_1"
        Me.Request_1.Padding = New System.Windows.Forms.Padding(3)
        Me.Request_1.Size = New System.Drawing.Size(791, 580)
        Me.Request_1.TabIndex = 6
        Me.Request_1.Text = "TabPage7"
        Me.Request_1.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label7.Location = New System.Drawing.Point(59, 3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(186, 50)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = """ПИР - Электроэнергия"" Запросы Суд и ССП"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictBox_1_Request
        '
        Me.PictBox_1_Request.BackColor = System.Drawing.Color.Transparent
        Me.PictBox_1_Request.Image = CType(resources.GetObject("PictBox_1_Request.Image"), System.Drawing.Image)
        Me.PictBox_1_Request.Location = New System.Drawing.Point(3, 3)
        Me.PictBox_1_Request.Name = "PictBox_1_Request"
        Me.PictBox_1_Request.Size = New System.Drawing.Size(50, 50)
        Me.PictBox_1_Request.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictBox_1_Request.TabIndex = 0
        Me.PictBox_1_Request.TabStop = False
        '
        'Deduction_1
        '
        Me.Deduction_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Deduction_1.Controls.Add(Me.Label8)
        Me.Deduction_1.Controls.Add(Me.PictBox_1_Deduction)
        Me.Deduction_1.Location = New System.Drawing.Point(4, 24)
        Me.Deduction_1.Name = "Deduction_1"
        Me.Deduction_1.Padding = New System.Windows.Forms.Padding(3)
        Me.Deduction_1.Size = New System.Drawing.Size(791, 580)
        Me.Deduction_1.TabIndex = 7
        Me.Deduction_1.Text = "TabPage8"
        Me.Deduction_1.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label8.Location = New System.Drawing.Point(59, 3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(186, 50)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = """ПИР - Электроэнергия"" Удержания и оплаты"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictBox_1_Deduction
        '
        Me.PictBox_1_Deduction.BackColor = System.Drawing.Color.Transparent
        Me.PictBox_1_Deduction.Image = CType(resources.GetObject("PictBox_1_Deduction.Image"), System.Drawing.Image)
        Me.PictBox_1_Deduction.Location = New System.Drawing.Point(3, 3)
        Me.PictBox_1_Deduction.Name = "PictBox_1_Deduction"
        Me.PictBox_1_Deduction.Size = New System.Drawing.Size(50, 50)
        Me.PictBox_1_Deduction.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictBox_1_Deduction.TabIndex = 0
        Me.PictBox_1_Deduction.TabStop = False
        '
        'Guarantee_1
        '
        Me.Guarantee_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Guarantee_1.Controls.Add(Me.Label9)
        Me.Guarantee_1.Controls.Add(Me.PictBox_1_Guarantee)
        Me.Guarantee_1.Location = New System.Drawing.Point(4, 24)
        Me.Guarantee_1.Name = "Guarantee_1"
        Me.Guarantee_1.Padding = New System.Windows.Forms.Padding(3)
        Me.Guarantee_1.Size = New System.Drawing.Size(791, 580)
        Me.Guarantee_1.TabIndex = 8
        Me.Guarantee_1.Text = "TabPage9"
        Me.Guarantee_1.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label9.Location = New System.Drawing.Point(59, 3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(186, 50)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = """ПИР - Электроэнергия"" Реструктуризация"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictBox_1_Guarantee
        '
        Me.PictBox_1_Guarantee.BackColor = System.Drawing.Color.Transparent
        Me.PictBox_1_Guarantee.Image = CType(resources.GetObject("PictBox_1_Guarantee.Image"), System.Drawing.Image)
        Me.PictBox_1_Guarantee.Location = New System.Drawing.Point(3, 3)
        Me.PictBox_1_Guarantee.Name = "PictBox_1_Guarantee"
        Me.PictBox_1_Guarantee.Size = New System.Drawing.Size(50, 50)
        Me.PictBox_1_Guarantee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictBox_1_Guarantee.TabIndex = 0
        Me.PictBox_1_Guarantee.TabStop = False
        '
        'Roadstead_1
        '
        Me.Roadstead_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Roadstead_1.Controls.Add(Me.Label10)
        Me.Roadstead_1.Controls.Add(Me.PictBox_1_Roadstead)
        Me.Roadstead_1.Location = New System.Drawing.Point(4, 24)
        Me.Roadstead_1.Name = "Roadstead_1"
        Me.Roadstead_1.Padding = New System.Windows.Forms.Padding(3)
        Me.Roadstead_1.Size = New System.Drawing.Size(791, 580)
        Me.Roadstead_1.TabIndex = 9
        Me.Roadstead_1.Text = "TabPage10"
        Me.Roadstead_1.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label10.Location = New System.Drawing.Point(59, 3)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(186, 50)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = """ПИР - Электроэнергия"" Рейды с ССП"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictBox_1_Roadstead
        '
        Me.PictBox_1_Roadstead.BackColor = System.Drawing.Color.Transparent
        Me.PictBox_1_Roadstead.Image = CType(resources.GetObject("PictBox_1_Roadstead.Image"), System.Drawing.Image)
        Me.PictBox_1_Roadstead.Location = New System.Drawing.Point(3, 3)
        Me.PictBox_1_Roadstead.Name = "PictBox_1_Roadstead"
        Me.PictBox_1_Roadstead.Size = New System.Drawing.Size(50, 50)
        Me.PictBox_1_Roadstead.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictBox_1_Roadstead.TabIndex = 0
        Me.PictBox_1_Roadstead.TabStop = False
        '
        'Search_1
        '
        Me.Search_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Search_1.Controls.Add(Me.Label18)
        Me.Search_1.Controls.Add(Me.PictBox_1_Search)
        Me.Search_1.Location = New System.Drawing.Point(4, 24)
        Me.Search_1.Name = "Search_1"
        Me.Search_1.Padding = New System.Windows.Forms.Padding(3)
        Me.Search_1.Size = New System.Drawing.Size(791, 580)
        Me.Search_1.TabIndex = 10
        Me.Search_1.Text = "TabPage11"
        Me.Search_1.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label18.Location = New System.Drawing.Point(59, 3)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(169, 50)
        Me.Label18.TabIndex = 1
        Me.Label18.Text = """ПИР - Электроэнергия"" Розыск"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictBox_1_Search
        '
        Me.PictBox_1_Search.BackColor = System.Drawing.Color.Transparent
        Me.PictBox_1_Search.Image = CType(resources.GetObject("PictBox_1_Search.Image"), System.Drawing.Image)
        Me.PictBox_1_Search.Location = New System.Drawing.Point(3, 3)
        Me.PictBox_1_Search.Name = "PictBox_1_Search"
        Me.PictBox_1_Search.Size = New System.Drawing.Size(50, 50)
        Me.PictBox_1_Search.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictBox_1_Search.TabIndex = 0
        Me.PictBox_1_Search.TabStop = False
        '
        'Spisanie_1
        '
        Me.Spisanie_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Spisanie_1.Controls.Add(Me.Label11)
        Me.Spisanie_1.Controls.Add(Me.PictBox_1_Spisanie)
        Me.Spisanie_1.Location = New System.Drawing.Point(4, 24)
        Me.Spisanie_1.Name = "Spisanie_1"
        Me.Spisanie_1.Padding = New System.Windows.Forms.Padding(3)
        Me.Spisanie_1.Size = New System.Drawing.Size(791, 580)
        Me.Spisanie_1.TabIndex = 11
        Me.Spisanie_1.Text = "TabPage12"
        Me.Spisanie_1.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label11.Location = New System.Drawing.Point(59, 3)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(186, 50)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = """ПИР - Электроэнергия"" Списание"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictBox_1_Spisanie
        '
        Me.PictBox_1_Spisanie.BackColor = System.Drawing.Color.Transparent
        Me.PictBox_1_Spisanie.Image = CType(resources.GetObject("PictBox_1_Spisanie.Image"), System.Drawing.Image)
        Me.PictBox_1_Spisanie.Location = New System.Drawing.Point(3, 3)
        Me.PictBox_1_Spisanie.Name = "PictBox_1_Spisanie"
        Me.PictBox_1_Spisanie.Size = New System.Drawing.Size(50, 50)
        Me.PictBox_1_Spisanie.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictBox_1_Spisanie.TabIndex = 0
        Me.PictBox_1_Spisanie.TabStop = False
        '
        'Suit_5
        '
        Me.Suit_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Suit_5.Controls.Add(Me.Label17)
        Me.Suit_5.Controls.Add(Me.PictBox_5_Suit)
        Me.Suit_5.Location = New System.Drawing.Point(4, 24)
        Me.Suit_5.Name = "Suit_5"
        Me.Suit_5.Padding = New System.Windows.Forms.Padding(3)
        Me.Suit_5.Size = New System.Drawing.Size(791, 580)
        Me.Suit_5.TabIndex = 12
        Me.Suit_5.Text = "TabPage13"
        Me.Suit_5.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label17.Location = New System.Drawing.Point(59, 3)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(201, 50)
        Me.Label17.TabIndex = 1
        Me.Label17.Text = """ПИР - Капитальный ремонт"" Иски"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictBox_5_Suit
        '
        Me.PictBox_5_Suit.BackColor = System.Drawing.Color.Transparent
        Me.PictBox_5_Suit.Image = CType(resources.GetObject("PictBox_5_Suit.Image"), System.Drawing.Image)
        Me.PictBox_5_Suit.Location = New System.Drawing.Point(3, 3)
        Me.PictBox_5_Suit.Name = "PictBox_5_Suit"
        Me.PictBox_5_Suit.Size = New System.Drawing.Size(50, 50)
        Me.PictBox_5_Suit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictBox_5_Suit.TabIndex = 0
        Me.PictBox_5_Suit.TabStop = False
        '
        'Request_5
        '
        Me.Request_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Request_5.Controls.Add(Me.Label16)
        Me.Request_5.Controls.Add(Me.PictBox_5_Request)
        Me.Request_5.Location = New System.Drawing.Point(4, 24)
        Me.Request_5.Name = "Request_5"
        Me.Request_5.Padding = New System.Windows.Forms.Padding(3)
        Me.Request_5.Size = New System.Drawing.Size(791, 580)
        Me.Request_5.TabIndex = 13
        Me.Request_5.Text = "TabPage14"
        Me.Request_5.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label16.Location = New System.Drawing.Point(59, 3)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(201, 50)
        Me.Label16.TabIndex = 1
        Me.Label16.Text = """ПИР - Капитальный ремонт"" Запросы Суд и ССП"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictBox_5_Request
        '
        Me.PictBox_5_Request.BackColor = System.Drawing.Color.Transparent
        Me.PictBox_5_Request.Image = CType(resources.GetObject("PictBox_5_Request.Image"), System.Drawing.Image)
        Me.PictBox_5_Request.Location = New System.Drawing.Point(3, 3)
        Me.PictBox_5_Request.Name = "PictBox_5_Request"
        Me.PictBox_5_Request.Size = New System.Drawing.Size(50, 50)
        Me.PictBox_5_Request.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictBox_5_Request.TabIndex = 0
        Me.PictBox_5_Request.TabStop = False
        '
        'Deduction_5
        '
        Me.Deduction_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Deduction_5.Controls.Add(Me.Label15)
        Me.Deduction_5.Controls.Add(Me.PictBox_5_Deduction)
        Me.Deduction_5.Location = New System.Drawing.Point(4, 24)
        Me.Deduction_5.Name = "Deduction_5"
        Me.Deduction_5.Padding = New System.Windows.Forms.Padding(3)
        Me.Deduction_5.Size = New System.Drawing.Size(791, 580)
        Me.Deduction_5.TabIndex = 14
        Me.Deduction_5.Text = "TabPage15"
        Me.Deduction_5.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label15.Location = New System.Drawing.Point(59, 3)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(201, 50)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = """ПИР - Капитальный ремонт"" Удержания и оплаты"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictBox_5_Deduction
        '
        Me.PictBox_5_Deduction.BackColor = System.Drawing.Color.Transparent
        Me.PictBox_5_Deduction.Image = CType(resources.GetObject("PictBox_5_Deduction.Image"), System.Drawing.Image)
        Me.PictBox_5_Deduction.Location = New System.Drawing.Point(3, 3)
        Me.PictBox_5_Deduction.Name = "PictBox_5_Deduction"
        Me.PictBox_5_Deduction.Size = New System.Drawing.Size(50, 50)
        Me.PictBox_5_Deduction.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictBox_5_Deduction.TabIndex = 0
        Me.PictBox_5_Deduction.TabStop = False
        '
        'Guarantee_5
        '
        Me.Guarantee_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Guarantee_5.Controls.Add(Me.Label14)
        Me.Guarantee_5.Controls.Add(Me.PictBox_5_Guarantee)
        Me.Guarantee_5.Location = New System.Drawing.Point(4, 24)
        Me.Guarantee_5.Name = "Guarantee_5"
        Me.Guarantee_5.Padding = New System.Windows.Forms.Padding(3)
        Me.Guarantee_5.Size = New System.Drawing.Size(791, 580)
        Me.Guarantee_5.TabIndex = 15
        Me.Guarantee_5.Text = "TabPage16"
        Me.Guarantee_5.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label14.Location = New System.Drawing.Point(62, 3)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(201, 50)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = """ПИР - Капитальный ремонт"" Реструктуризация"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictBox_5_Guarantee
        '
        Me.PictBox_5_Guarantee.BackColor = System.Drawing.Color.Transparent
        Me.PictBox_5_Guarantee.Image = CType(resources.GetObject("PictBox_5_Guarantee.Image"), System.Drawing.Image)
        Me.PictBox_5_Guarantee.Location = New System.Drawing.Point(3, 3)
        Me.PictBox_5_Guarantee.Name = "PictBox_5_Guarantee"
        Me.PictBox_5_Guarantee.Size = New System.Drawing.Size(50, 50)
        Me.PictBox_5_Guarantee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictBox_5_Guarantee.TabIndex = 0
        Me.PictBox_5_Guarantee.TabStop = False
        '
        'Roadstead_5
        '
        Me.Roadstead_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Roadstead_5.Controls.Add(Me.Label13)
        Me.Roadstead_5.Controls.Add(Me.PictBox_5_Roadstead)
        Me.Roadstead_5.Location = New System.Drawing.Point(4, 24)
        Me.Roadstead_5.Name = "Roadstead_5"
        Me.Roadstead_5.Padding = New System.Windows.Forms.Padding(3)
        Me.Roadstead_5.Size = New System.Drawing.Size(791, 580)
        Me.Roadstead_5.TabIndex = 16
        Me.Roadstead_5.Text = "TabPage17"
        Me.Roadstead_5.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label13.Location = New System.Drawing.Point(59, 3)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(201, 50)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = """ПИР - Капитальный ремонт"" Рейды с ССП"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictBox_5_Roadstead
        '
        Me.PictBox_5_Roadstead.BackColor = System.Drawing.Color.Transparent
        Me.PictBox_5_Roadstead.Image = CType(resources.GetObject("PictBox_5_Roadstead.Image"), System.Drawing.Image)
        Me.PictBox_5_Roadstead.Location = New System.Drawing.Point(3, 3)
        Me.PictBox_5_Roadstead.Name = "PictBox_5_Roadstead"
        Me.PictBox_5_Roadstead.Size = New System.Drawing.Size(50, 50)
        Me.PictBox_5_Roadstead.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictBox_5_Roadstead.TabIndex = 0
        Me.PictBox_5_Roadstead.TabStop = False
        '
        'Search_5
        '
        Me.Search_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Search_5.Controls.Add(Me.Label19)
        Me.Search_5.Controls.Add(Me.PictBox_5_Search)
        Me.Search_5.Location = New System.Drawing.Point(4, 24)
        Me.Search_5.Name = "Search_5"
        Me.Search_5.Padding = New System.Windows.Forms.Padding(3)
        Me.Search_5.Size = New System.Drawing.Size(791, 580)
        Me.Search_5.TabIndex = 17
        Me.Search_5.Text = "TabPage18"
        Me.Search_5.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label19.Location = New System.Drawing.Point(59, 3)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(169, 50)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = """ПИР - Электроэнергия"" Розыск"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictBox_5_Search
        '
        Me.PictBox_5_Search.BackColor = System.Drawing.Color.Transparent
        Me.PictBox_5_Search.Image = CType(resources.GetObject("PictBox_5_Search.Image"), System.Drawing.Image)
        Me.PictBox_5_Search.Location = New System.Drawing.Point(3, 3)
        Me.PictBox_5_Search.Name = "PictBox_5_Search"
        Me.PictBox_5_Search.Size = New System.Drawing.Size(50, 50)
        Me.PictBox_5_Search.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictBox_5_Search.TabIndex = 0
        Me.PictBox_5_Search.TabStop = False
        '
        'Spisanie_5
        '
        Me.Spisanie_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Spisanie_5.Controls.Add(Me.Label12)
        Me.Spisanie_5.Controls.Add(Me.PictBox_5_Spisanie)
        Me.Spisanie_5.Location = New System.Drawing.Point(4, 24)
        Me.Spisanie_5.Name = "Spisanie_5"
        Me.Spisanie_5.Padding = New System.Windows.Forms.Padding(3)
        Me.Spisanie_5.Size = New System.Drawing.Size(791, 580)
        Me.Spisanie_5.TabIndex = 18
        Me.Spisanie_5.Text = "TabPage19"
        Me.Spisanie_5.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label12.Location = New System.Drawing.Point(59, 3)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(201, 50)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = """ПИР - Капитальный ремонт"" Списание"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictBox_5_Spisanie
        '
        Me.PictBox_5_Spisanie.BackColor = System.Drawing.Color.Transparent
        Me.PictBox_5_Spisanie.Image = CType(resources.GetObject("PictBox_5_Spisanie.Image"), System.Drawing.Image)
        Me.PictBox_5_Spisanie.Location = New System.Drawing.Point(3, 3)
        Me.PictBox_5_Spisanie.Name = "PictBox_5_Spisanie"
        Me.PictBox_5_Spisanie.Size = New System.Drawing.Size(50, 50)
        Me.PictBox_5_Spisanie.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictBox_5_Spisanie.TabIndex = 0
        Me.PictBox_5_Spisanie.TabStop = False
        '
        'frAbonents
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1057, 699)
        Me.Controls.Add(Me.SplitContainer)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.Panel2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(1070, 720)
        Me.Name = "frAbonents"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Абоненты"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ContextMenu.ResumeLayout(False)
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.SplitContainer.Panel1.ResumeLayout(False)
        Me.SplitContainer.Panel1.PerformLayout()
        Me.SplitContainer.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer.ResumeLayout(False)
        Me.MainTabControl.ResumeLayout(False)
        Me.AbonentNum.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.DataGrid_AbonStatusHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        CType(Me.PictBox_AbonentNum, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GeneralInfo.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.DataGrid_FamilyMember, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictBox_GeneralInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Members.ResumeLayout(False)
        Me.GrBox_CurrentMember.ResumeLayout(False)
        Me.GrBox_CurrentMember.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGView_PrMembers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.TS_ManagerPrMembers.ResumeLayout(False)
        Me.TS_ManagerPrMembers.PerformLayout()
        CType(Me.PictBox_Members, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EventsDeb_1.ResumeLayout(False)
        CType(Me.PictBox_EventsDeb_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EventsDeb_5.ResumeLayout(False)
        CType(Me.PictBox_EventsDeb_5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Suit_1.ResumeLayout(False)
        Me.PIR1_TabCon.ResumeLayout(False)
        Me.PIR1_TP_PetitionsDebt.ResumeLayout(False)
        Me.PIR1_TP_PetitionsDebt.PerformLayout()
        Me.Group_Petition.ResumeLayout(False)
        Me.Group_Petition.PerformLayout()
        CType(Me.Pic_PayOrders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        CType(Me.PIR1_DGView_ListeningHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PIR1_ToolSt_ListeningMeneger.ResumeLayout(False)
        Me.PIR1_ToolSt_ListeningMeneger.PerformLayout()
        Me.PIR1_TP_SSPWork.ResumeLayout(False)
        Me.PIR1_TP_SSPWork.PerformLayout()
        Me.Pan_PetitionControls.ResumeLayout(False)
        Me.Pan_PetitionControls.PerformLayout()
        Me.PIR1_ToolSt_PetitionsMeneger.ResumeLayout(False)
        Me.PIR1_ToolSt_PetitionsMeneger.PerformLayout()
        CType(Me.PIR1_DGView_Petitions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.PIR1_DGView_PetitionsDebt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        CType(Me.PictBox_1_Suit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PIR1_ToolSt_PetitionsDebtMeneger.ResumeLayout(False)
        Me.PIR1_ToolSt_PetitionsDebtMeneger.PerformLayout()
        Me.Request_1.ResumeLayout(False)
        CType(Me.PictBox_1_Request, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Deduction_1.ResumeLayout(False)
        CType(Me.PictBox_1_Deduction, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guarantee_1.ResumeLayout(False)
        CType(Me.PictBox_1_Guarantee, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Roadstead_1.ResumeLayout(False)
        CType(Me.PictBox_1_Roadstead, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Search_1.ResumeLayout(False)
        CType(Me.PictBox_1_Search, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Spisanie_1.ResumeLayout(False)
        CType(Me.PictBox_1_Spisanie, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Suit_5.ResumeLayout(False)
        CType(Me.PictBox_5_Suit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Request_5.ResumeLayout(False)
        CType(Me.PictBox_5_Request, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Deduction_5.ResumeLayout(False)
        CType(Me.PictBox_5_Deduction, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guarantee_5.ResumeLayout(False)
        CType(Me.PictBox_5_Guarantee, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Roadstead_5.ResumeLayout(False)
        CType(Me.PictBox_5_Roadstead, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Search_5.ResumeLayout(False)
        CType(Me.PictBox_5_Search, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Spisanie_5.ResumeLayout(False)
        CType(Me.PictBox_5_Spisanie, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_Adress As System.Windows.Forms.TextBox
    Friend WithEvents txt_FIO As System.Windows.Forms.TextBox
    Friend WithEvents txt_AbonNumber As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend Shadows ContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents TreeView As System.Windows.Forms.TreeView
    Friend WithEvents Txt_HoteNote As System.Windows.Forms.TextBox
    Friend WithEvents MainTabControl As System.Windows.Forms.TabControl
    Friend WithEvents AbonentNum As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGrid_AbonStatusHistory As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_ClearPhoneNumber As System.Windows.Forms.Button
    Friend WithEvents btn_ClearMobileNumber As System.Windows.Forms.Button
    Friend WithEvents btn_ClearEmail As System.Windows.Forms.Button
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents txt_PhoneNumber As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_MobileNumber As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_Controler As System.Windows.Forms.TextBox
    Friend WithEvents txt_mail As System.Windows.Forms.TextBox
    Friend WithEvents txt_ChiefControler As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btn_ClearAltAdress As System.Windows.Forms.Button
    Friend WithEvents btn_EditAltAdress As System.Windows.Forms.Button
    Friend WithEvents cmb_Route As System.Windows.Forms.ComboBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txt_AltAdress As System.Windows.Forms.TextBox
    Friend WithEvents cmb_RoomType As System.Windows.Forms.ComboBox
    Friend WithEvents txt_RoomNumber As System.Windows.Forms.TextBox
    Friend WithEvents txt_LetterRoom As System.Windows.Forms.TextBox
    Friend WithEvents txt_Room As System.Windows.Forms.TextBox
    Friend WithEvents txt_Section As System.Windows.Forms.TextBox
    Friend WithEvents txt_Build As System.Windows.Forms.TextBox
    Friend WithEvents txt_LetterHouse As System.Windows.Forms.TextBox
    Friend WithEvents txt_House As System.Windows.Forms.TextBox
    Friend WithEvents btn_EditAdress As System.Windows.Forms.Button
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txt_PostalIndex As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_AdressPart As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictBox_AbonentNum As System.Windows.Forms.PictureBox
    Friend WithEvents GeneralInfo As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Public WithEvents DataGrid_FamilyMember As System.Windows.Forms.DataGridView
    Private WithEvents PropertyGrid_GenInfo As System.Windows.Forms.PropertyGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictBox_GeneralInfo As System.Windows.Forms.PictureBox
    Friend WithEvents Members As System.Windows.Forms.TabPage
    Friend WithEvents TS_ManagerPrMembers As System.Windows.Forms.ToolStrip
    Friend WithEvents GrBox_CurrentMember As System.Windows.Forms.GroupBox
    Friend WithEvents btn_CalDtUnResidence As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_CalDtResidence As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_DtResidence As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents сmb_FamilyRole As System.Windows.Forms.ComboBox
    Friend WithEvents txt_NoteMember As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents txt_AddressOfLive As System.Windows.Forms.TextBox
    Friend WithEvents txt_Residence As System.Windows.Forms.TextBox
    Friend WithEvents ckb_ShareOwner As System.Windows.Forms.CheckBox
    Friend WithEvents Lab_CriterialSearch As System.Windows.Forms.Label
    Friend WithEvents txt_Patronymic As System.Windows.Forms.TextBox
    Friend WithEvents txt_Name As System.Windows.Forms.TextBox
    Friend WithEvents txt_Surname As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_MemEmail As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_MemPhoneMobile As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_PlaceOfWork As System.Windows.Forms.TextBox
    Friend WithEvents cmb_SexMember As System.Windows.Forms.ComboBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents lab_Update As System.Windows.Forms.Label
    Friend WithEvents txt_DtUnResidence As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_CalPDDateOfIssue As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_CalPDDateOfBirth As System.Windows.Forms.DateTimePicker
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents btn_ClearPD As System.Windows.Forms.Button
    Friend WithEvents txt_PDSubunitCode As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_PDSubunit As System.Windows.Forms.TextBox
    Friend WithEvents txt_PDNumber As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_PDSeries As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_PDString As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txt_PDDateOfBirth As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txt_PDDateOfIssue As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents DGView_PrMembers As System.Windows.Forms.DataGridView
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictBox_Members As System.Windows.Forms.PictureBox
    Friend WithEvents Pan_Members As System.Windows.Forms.Panel
    Friend WithEvents EventsDeb_1 As System.Windows.Forms.TabPage
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictBox_EventsDeb_1 As System.Windows.Forms.PictureBox
    Friend WithEvents EventsDeb_5 As System.Windows.Forms.TabPage
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictBox_EventsDeb_5 As System.Windows.Forms.PictureBox
    Friend WithEvents Suit_1 As System.Windows.Forms.TabPage
    Friend WithEvents PIR1_TabCon As System.Windows.Forms.TabControl
    Friend WithEvents PIR1_TP_PetitionsDebt As System.Windows.Forms.TabPage
    Friend WithEvents btn_CalPIR1_txt_DtClosePetitionDebt As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents PIR1_cmb_ReasonForEnd As System.Windows.Forms.ComboBox
    Friend WithEvents PIR1_txt_Note As System.Windows.Forms.TextBox
    Friend WithEvents Group_Petition As System.Windows.Forms.GroupBox
    Friend WithEvents btn_CalPIR1_txt_DtDispatch As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_CalPIR1_txt_DtPetitions As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_CalPIR1_txt_DtPeriodEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_CalPIR1_txt_DtPeriodStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents PIR1_cmb_PetitionType As System.Windows.Forms.TextBox
    Friend WithEvents PIR1_cmb_EnergyType As System.Windows.Forms.TextBox
    Friend WithEvents Pic_PayOrders As System.Windows.Forms.PictureBox
    Friend WithEvents Link_PayOrders As System.Windows.Forms.LinkLabel
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents PIR1_txt_DtDispatch As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents PIR1_txt_DtPeriodEnd As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents PIR1_txt_GovTax As System.Windows.Forms.TextBox
    Friend WithEvents PIR1_txt_DebtSumm As System.Windows.Forms.TextBox
    Friend WithEvents PIR1_txt_NumberPetition As System.Windows.Forms.TextBox
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents PIR1_txt_DtPetitions As System.Windows.Forms.MaskedTextBox
    Friend WithEvents PIR1_cmb_CourtType As System.Windows.Forms.ComboBox
    Friend WithEvents PIR1_cmb_JudicialArea As System.Windows.Forms.ComboBox
    Friend WithEvents Label79 As System.Windows.Forms.Label
    Friend WithEvents Label80 As System.Windows.Forms.Label
    Friend WithEvents Label81 As System.Windows.Forms.Label
    Friend WithEvents Label78 As System.Windows.Forms.Label
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents Label77 As System.Windows.Forms.Label
    Friend WithEvents PIR1_txt_DtPeriodStart As System.Windows.Forms.MaskedTextBox
    Friend WithEvents PIR1_cmb_DecisionDirection As System.Windows.Forms.ComboBox
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents PIR1_txt_DtClosePetitionDebt As System.Windows.Forms.MaskedTextBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_CalPIR1_txt_DtDtJudicialOrder As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_CalPIR1_txt_DtDecision As System.Windows.Forms.DateTimePicker
    Friend WithEvents PIR1_txt_DebtSummAfterDecision As System.Windows.Forms.TextBox
    Friend WithEvents PIR1_DGView_ListeningHistory As System.Windows.Forms.DataGridView
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents PIR1_txt_DecisionNumber As System.Windows.Forms.TextBox
    Friend WithEvents PIR1_ToolSt_ListeningMeneger As System.Windows.Forms.ToolStrip
    Friend WithEvents PIR1_cmb_DecisionType As System.Windows.Forms.ComboBox
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents PIR1_cmb_DecisionTypeExt As System.Windows.Forms.ComboBox
    Friend WithEvents PIR1_txt_DtJudicialOrder As System.Windows.Forms.MaskedTextBox
    Friend WithEvents PIR1_txt_DtDecision As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents PIR1_TP_SSPWork As System.Windows.Forms.TabPage
    Friend WithEvents PIR1_DGView_Petitions As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PictBox_1_Suit As System.Windows.Forms.PictureBox
    Friend WithEvents PIR1_ToolSt_PetitionsDebtMeneger As System.Windows.Forms.ToolStrip
    Friend WithEvents PIR1_Btn_AddNewPetitionDebt As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PIR1_Btn_DeletePetitionDebt As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PIR1_Btn_SavePetitionDebt As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PIR1_Btn_Filter As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ВсеИскиToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ОконченныеToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ВИсполненииToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ПоЧленуСемьиToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_TSMenu_FilterMember As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents СписаниеToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Request_1 As System.Windows.Forms.TabPage
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PictBox_1_Request As System.Windows.Forms.PictureBox
    Friend WithEvents Deduction_1 As System.Windows.Forms.TabPage
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PictBox_1_Deduction As System.Windows.Forms.PictureBox
    Friend WithEvents Guarantee_1 As System.Windows.Forms.TabPage
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictBox_1_Guarantee As System.Windows.Forms.PictureBox
    Friend WithEvents Roadstead_1 As System.Windows.Forms.TabPage
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PictBox_1_Roadstead As System.Windows.Forms.PictureBox
    Friend WithEvents Search_1 As System.Windows.Forms.TabPage
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents PictBox_1_Search As System.Windows.Forms.PictureBox
    Friend WithEvents Spisanie_1 As System.Windows.Forms.TabPage
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents PictBox_1_Spisanie As System.Windows.Forms.PictureBox
    Friend WithEvents Suit_5 As System.Windows.Forms.TabPage
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents PictBox_5_Suit As System.Windows.Forms.PictureBox
    Friend WithEvents Request_5 As System.Windows.Forms.TabPage
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents PictBox_5_Request As System.Windows.Forms.PictureBox
    Friend WithEvents Deduction_5 As System.Windows.Forms.TabPage
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents PictBox_5_Deduction As System.Windows.Forms.PictureBox
    Friend WithEvents Guarantee_5 As System.Windows.Forms.TabPage
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents PictBox_5_Guarantee As System.Windows.Forms.PictureBox
    Friend WithEvents Roadstead_5 As System.Windows.Forms.TabPage
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents PictBox_5_Roadstead As System.Windows.Forms.PictureBox
    Friend WithEvents Search_5 As System.Windows.Forms.TabPage
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents PictBox_5_Search As System.Windows.Forms.PictureBox
    Friend WithEvents Spisanie_5 As System.Windows.Forms.TabPage
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents PictBox_5_Spisanie As System.Windows.Forms.PictureBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents PIR1_DGView_PetitionsDebt As System.Windows.Forms.DataGridView
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Private WithEvents NotifyIcon As System.Windows.Forms.NotifyIcon
    Private WithEvents ToolStrip_Search As System.Windows.Forms.ToolStripButton
    Private WithEvents Processing As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents ViewMember As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents RemoveMember As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents CreateMember As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents RecordSetInfo As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents Time_NoteResize As System.Windows.Forms.Timer
    Private WithEvents btn_InsertMember As System.Windows.Forms.ToolStripButton
    Private WithEvents btn_UpdateMember As System.Windows.Forms.ToolStripButton
    Private WithEvents btn_DeleteMember As System.Windows.Forms.ToolStripButton
    Private WithEvents PIR1_Btn_AddNewListening As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents PIR1_Btn_EditListening As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents PIR1_Btn_DeleteListening As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_CalPIR1_txt_ExcitementDt As System.Windows.Forms.DateTimePicker
    Friend WithEvents PIR1_cmb_ActImpossibleRecovery As System.Windows.Forms.ComboBox
    Friend WithEvents btn_CalPIR1_txt_DtActImpossibleRecovery As System.Windows.Forms.DateTimePicker
    Friend WithEvents PIR1_txt_DtActImpossibleRecovery As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label85 As System.Windows.Forms.Label
    Friend WithEvents btn_CalPIR1_txt_DtCompletion As System.Windows.Forms.DateTimePicker
    Friend WithEvents PIR1_txt_DtCompletion As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label86 As System.Windows.Forms.Label
    Friend WithEvents Label88 As System.Windows.Forms.Label
    Friend WithEvents Label87 As System.Windows.Forms.Label
    Friend WithEvents PIR1_txt_NotePetition As System.Windows.Forms.TextBox
    Friend WithEvents PIR1_ToolSt_PetitionsMeneger As System.Windows.Forms.ToolStrip
    Private WithEvents PIR1_Btn_AddNewPetition As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents PIR1_Btn_DeletePetition As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label84 As System.Windows.Forms.Label
    Friend WithEvents PIR1_txt_PetitionSumm As System.Windows.Forms.TextBox
    Friend WithEvents Label83 As System.Windows.Forms.Label
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents PIR1_cmb_CopPerformer As System.Windows.Forms.ComboBox
    Friend WithEvents PIR1_txt_ExecutiveNumber As System.Windows.Forms.TextBox
    Friend WithEvents PIR1_txt_ExcitementDt As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label82 As System.Windows.Forms.Label
    Friend WithEvents Label91 As System.Windows.Forms.Label
    Friend WithEvents Label89 As System.Windows.Forms.Label
    Friend WithEvents Label90 As System.Windows.Forms.Label
    Public WithEvents Pan_PetitionControls As System.Windows.Forms.Panel
    Friend WithEvents PIR1_Btn_Reports As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents PIR1_Btn_ReportsBlankPetition As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents РасчетЦеныИскаToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip_DemandTSO As System.Windows.Forms.ToolStripButton
    Private WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents PIR1_txt_DealNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label92 As System.Windows.Forms.Label
    Friend WithEvents btn_CalPIR1_txt_DtDecisionDirection As System.Windows.Forms.DateTimePicker
    Friend WithEvents PIR1_txt_DtDecisionDirection As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label93 As System.Windows.Forms.Label
End Class
