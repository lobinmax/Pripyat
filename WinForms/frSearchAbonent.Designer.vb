<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frSearchAbonent
    Inherits DevExpress.XtraEditors.XtraForm

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frSearchAbonent))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DataGrid = New System.Windows.Forms.DataGridView()
        Me.PanSearch_LastSurname = New System.Windows.Forms.Panel()
        Me.RadBut_MemberPripyat = New System.Windows.Forms.RadioButton()
        Me.RadBut_MemberQuasar = New System.Windows.Forms.RadioButton()
        Me.RadBut_MaimMember = New System.Windows.Forms.RadioButton()
        Me.Txt_Surname = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.RadBut_AbonNum = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.RadBut_PointNum = New System.Windows.Forms.RadioButton()
        Me.RadBut_Adress = New System.Windows.Forms.RadioButton()
        Me.RadBut_LastSurname = New System.Windows.Forms.RadioButton()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.But_Search = New System.Windows.Forms.Button()
        Me.PanSearch_Address = New System.Windows.Forms.Panel()
        Me.Txt_AddressString = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txt_Room = New System.Windows.Forms.TextBox()
        Me.Txt_Build = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Txt_House = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Txt_LetterHouse = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PanSearch_AbonentNum = New System.Windows.Forms.Panel()
        Me.Txt_AbonNumber = New System.Windows.Forms.MaskedTextBox()
        Me.Lab_CriterialSearch = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Status = New System.Windows.Forms.StatusStrip()
        Me.StLab_Count = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StLab_Messege = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanSearch_LastSurname.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.PanSearch_Address.SuspendLayout()
        Me.PanSearch_AbonentNum.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Status.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.DataGrid)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(555, 251)
        Me.Panel1.TabIndex = 1
        '
        'DataGrid
        '
        Me.DataGrid.AllowUserToAddRows = False
        Me.DataGrid.AllowUserToDeleteRows = False
        Me.DataGrid.AllowUserToResizeRows = False
        Me.DataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.DataGrid.ColumnHeadersHeight = 20
        Me.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DataGrid.Location = New System.Drawing.Point(0, 0)
        Me.DataGrid.MultiSelect = False
        Me.DataGrid.Name = "DataGrid"
        Me.DataGrid.ReadOnly = True
        Me.DataGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGrid.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGrid.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGrid.RowTemplate.Height = 17
        Me.DataGrid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGrid.Size = New System.Drawing.Size(551, 247)
        Me.DataGrid.TabIndex = 0
        '
        'PanSearch_LastSurname
        '
        Me.PanSearch_LastSurname.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanSearch_LastSurname.Controls.Add(Me.RadBut_MemberPripyat)
        Me.PanSearch_LastSurname.Controls.Add(Me.RadBut_MemberQuasar)
        Me.PanSearch_LastSurname.Controls.Add(Me.RadBut_MaimMember)
        Me.PanSearch_LastSurname.Controls.Add(Me.Txt_Surname)
        Me.PanSearch_LastSurname.Controls.Add(Me.Label9)
        Me.PanSearch_LastSurname.Location = New System.Drawing.Point(3, 65)
        Me.PanSearch_LastSurname.Name = "PanSearch_LastSurname"
        Me.PanSearch_LastSurname.Size = New System.Drawing.Size(149, 37)
        Me.PanSearch_LastSurname.TabIndex = 9
        '
        'RadBut_MemberPripyat
        '
        Me.RadBut_MemberPripyat.AutoSize = True
        Me.RadBut_MemberPripyat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.RadBut_MemberPripyat.Location = New System.Drawing.Point(6, 86)
        Me.RadBut_MemberPripyat.Name = "RadBut_MemberPripyat"
        Me.RadBut_MemberPripyat.Size = New System.Drawing.Size(14, 13)
        Me.RadBut_MemberPripyat.TabIndex = 8
        Me.RadBut_MemberPripyat.UseVisualStyleBackColor = True
        '
        'RadBut_MemberQuasar
        '
        Me.RadBut_MemberQuasar.AutoSize = True
        Me.RadBut_MemberQuasar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.RadBut_MemberQuasar.Location = New System.Drawing.Point(6, 63)
        Me.RadBut_MemberQuasar.Name = "RadBut_MemberQuasar"
        Me.RadBut_MemberQuasar.Size = New System.Drawing.Size(144, 17)
        Me.RadBut_MemberQuasar.TabIndex = 7
        Me.RadBut_MemberQuasar.Text = "Член семьи ПК Квазар"
        Me.RadBut_MemberQuasar.UseVisualStyleBackColor = True
        '
        'RadBut_MaimMember
        '
        Me.RadBut_MaimMember.AutoSize = True
        Me.RadBut_MaimMember.Checked = True
        Me.RadBut_MaimMember.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.RadBut_MaimMember.Location = New System.Drawing.Point(6, 42)
        Me.RadBut_MaimMember.Name = "RadBut_MaimMember"
        Me.RadBut_MaimMember.Size = New System.Drawing.Size(91, 17)
        Me.RadBut_MaimMember.TabIndex = 6
        Me.RadBut_MaimMember.TabStop = True
        Me.RadBut_MaimMember.Text = "Собственник"
        Me.RadBut_MaimMember.UseVisualStyleBackColor = True
        '
        'Txt_Surname
        '
        Me.Txt_Surname.Location = New System.Drawing.Point(6, 15)
        Me.Txt_Surname.Name = "Txt_Surname"
        Me.Txt_Surname.Size = New System.Drawing.Size(231, 21)
        Me.Txt_Surname.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label9.Location = New System.Drawing.Point(5, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 13)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Фамилия"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = Global.Pripyat.My.Resources.Resources.Find_150x150
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(143, 112)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'RadBut_AbonNum
        '
        Me.RadBut_AbonNum.AutoSize = True
        Me.RadBut_AbonNum.BackColor = System.Drawing.SystemColors.Control
        Me.RadBut_AbonNum.Checked = True
        Me.RadBut_AbonNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.RadBut_AbonNum.Location = New System.Drawing.Point(6, 6)
        Me.RadBut_AbonNum.Name = "RadBut_AbonNum"
        Me.RadBut_AbonNum.Size = New System.Drawing.Size(120, 24)
        Me.RadBut_AbonNum.TabIndex = 3
        Me.RadBut_AbonNum.TabStop = True
        Me.RadBut_AbonNum.Text = "№ Абонента"
        Me.RadBut_AbonNum.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Location = New System.Drawing.Point(2, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(152, 116)
        Me.Panel2.TabIndex = 4
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.RadBut_PointNum)
        Me.Panel3.Controls.Add(Me.RadBut_Adress)
        Me.Panel3.Controls.Add(Me.RadBut_LastSurname)
        Me.Panel3.Controls.Add(Me.RadBut_AbonNum)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(148, 112)
        Me.Panel3.TabIndex = 5
        '
        'RadBut_PointNum
        '
        Me.RadBut_PointNum.AutoSize = True
        Me.RadBut_PointNum.BackColor = System.Drawing.SystemColors.Control
        Me.RadBut_PointNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.RadBut_PointNum.Location = New System.Drawing.Point(6, 31)
        Me.RadBut_PointNum.Name = "RadBut_PointNum"
        Me.RadBut_PointNum.Size = New System.Drawing.Size(90, 24)
        Me.RadBut_PointNum.TabIndex = 6
        Me.RadBut_PointNum.Text = "№ Точки"
        Me.RadBut_PointNum.UseVisualStyleBackColor = False
        '
        'RadBut_Adress
        '
        Me.RadBut_Adress.AutoSize = True
        Me.RadBut_Adress.BackColor = System.Drawing.SystemColors.Control
        Me.RadBut_Adress.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.RadBut_Adress.Location = New System.Drawing.Point(6, 81)
        Me.RadBut_Adress.Name = "RadBut_Adress"
        Me.RadBut_Adress.Size = New System.Drawing.Size(75, 24)
        Me.RadBut_Adress.TabIndex = 5
        Me.RadBut_Adress.Text = "Адрес"
        Me.RadBut_Adress.UseVisualStyleBackColor = False
        '
        'RadBut_LastSurname
        '
        Me.RadBut_LastSurname.AutoSize = True
        Me.RadBut_LastSurname.BackColor = System.Drawing.SystemColors.Control
        Me.RadBut_LastSurname.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.RadBut_LastSurname.Location = New System.Drawing.Point(6, 56)
        Me.RadBut_LastSurname.Name = "RadBut_LastSurname"
        Me.RadBut_LastSurname.Size = New System.Drawing.Size(99, 24)
        Me.RadBut_LastSurname.TabIndex = 4
        Me.RadBut_LastSurname.Text = "Фамилия"
        Me.RadBut_LastSurname.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel4.Controls.Add(Me.PanSearch_LastSurname)
        Me.Panel4.Controls.Add(Me.But_Search)
        Me.Panel4.Controls.Add(Me.PanSearch_Address)
        Me.Panel4.Controls.Add(Me.PanSearch_AbonentNum)
        Me.Panel4.Location = New System.Drawing.Point(160, 4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(248, 116)
        Me.Panel4.TabIndex = 5
        '
        'But_Search
        '
        Me.But_Search.Image = Global.Pripyat.My.Resources.Resources.search_16x16
        Me.But_Search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.But_Search.Location = New System.Drawing.Point(169, 86)
        Me.But_Search.Name = "But_Search"
        Me.But_Search.Size = New System.Drawing.Size(70, 23)
        Me.But_Search.TabIndex = 7
        Me.But_Search.Text = "Найти"
        Me.But_Search.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.But_Search.UseVisualStyleBackColor = True
        '
        'PanSearch_Address
        '
        Me.PanSearch_Address.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanSearch_Address.Controls.Add(Me.Txt_AddressString)
        Me.PanSearch_Address.Controls.Add(Me.Label1)
        Me.PanSearch_Address.Controls.Add(Me.Txt_Room)
        Me.PanSearch_Address.Controls.Add(Me.Txt_Build)
        Me.PanSearch_Address.Controls.Add(Me.Label6)
        Me.PanSearch_Address.Controls.Add(Me.Txt_House)
        Me.PanSearch_Address.Controls.Add(Me.Label5)
        Me.PanSearch_Address.Controls.Add(Me.Txt_LetterHouse)
        Me.PanSearch_Address.Controls.Add(Me.Label4)
        Me.PanSearch_Address.Controls.Add(Me.Label3)
        Me.PanSearch_Address.Location = New System.Drawing.Point(162, 14)
        Me.PanSearch_Address.Name = "PanSearch_Address"
        Me.PanSearch_Address.Size = New System.Drawing.Size(59, 66)
        Me.PanSearch_Address.TabIndex = 10
        '
        'Txt_AddressString
        '
        Me.Txt_AddressString.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_AddressString.Location = New System.Drawing.Point(6, 16)
        Me.Txt_AddressString.Name = "Txt_AddressString"
        Me.Txt_AddressString.ReadOnly = True
        Me.Txt_AddressString.Size = New System.Drawing.Size(231, 21)
        Me.Txt_AddressString.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Адрес"
        '
        'Txt_Room
        '
        Me.Txt_Room.Location = New System.Drawing.Point(170, 53)
        Me.Txt_Room.Name = "Txt_Room"
        Me.Txt_Room.Size = New System.Drawing.Size(67, 21)
        Me.Txt_Room.TabIndex = 11
        '
        'Txt_Build
        '
        Me.Txt_Build.Location = New System.Drawing.Point(92, 53)
        Me.Txt_Build.Name = "Txt_Build"
        Me.Txt_Build.Size = New System.Drawing.Size(40, 21)
        Me.Txt_Build.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label6.Location = New System.Drawing.Point(167, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Квартира"
        '
        'Txt_House
        '
        Me.Txt_House.Location = New System.Drawing.Point(5, 53)
        Me.Txt_House.Name = "Txt_House"
        Me.Txt_House.Size = New System.Drawing.Size(40, 21)
        Me.Txt_House.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label5.Location = New System.Drawing.Point(92, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Корпус"
        '
        'Txt_LetterHouse
        '
        Me.Txt_LetterHouse.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_LetterHouse.Location = New System.Drawing.Point(51, 53)
        Me.Txt_LetterHouse.MaxLength = 1
        Me.Txt_LetterHouse.Name = "Txt_LetterHouse"
        Me.Txt_LetterHouse.Size = New System.Drawing.Size(24, 21)
        Me.Txt_LetterHouse.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.Location = New System.Drawing.Point(46, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Буква"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Дом"
        '
        'PanSearch_AbonentNum
        '
        Me.PanSearch_AbonentNum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanSearch_AbonentNum.Controls.Add(Me.Txt_AbonNumber)
        Me.PanSearch_AbonentNum.Controls.Add(Me.Lab_CriterialSearch)
        Me.PanSearch_AbonentNum.Location = New System.Drawing.Point(3, 6)
        Me.PanSearch_AbonentNum.Name = "PanSearch_AbonentNum"
        Me.PanSearch_AbonentNum.Size = New System.Drawing.Size(131, 53)
        Me.PanSearch_AbonentNum.TabIndex = 5
        '
        'Txt_AbonNumber
        '
        Me.Txt_AbonNumber.AsciiOnly = True
        Me.Txt_AbonNumber.HideSelection = False
        Me.Txt_AbonNumber.Location = New System.Drawing.Point(8, 16)
        Me.Txt_AbonNumber.Mask = "000 000 000 000"
        Me.Txt_AbonNumber.Name = "Txt_AbonNumber"
        Me.Txt_AbonNumber.Size = New System.Drawing.Size(226, 21)
        Me.Txt_AbonNumber.TabIndex = 8
        '
        'Lab_CriterialSearch
        '
        Me.Lab_CriterialSearch.AutoSize = True
        Me.Lab_CriterialSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Lab_CriterialSearch.Location = New System.Drawing.Point(5, 0)
        Me.Lab_CriterialSearch.Name = "Lab_CriterialSearch"
        Me.Lab_CriterialSearch.Size = New System.Drawing.Size(117, 13)
        Me.Lab_CriterialSearch.TabIndex = 4
        Me.Lab_CriterialSearch.Text = "Номер лицевого счета"
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel6.Controls.Add(Me.PictureBox1)
        Me.Panel6.Location = New System.Drawing.Point(414, 4)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(147, 116)
        Me.Panel6.TabIndex = 6
        '
        'Panel7
        '
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel7.Controls.Add(Me.Panel1)
        Me.Panel7.Location = New System.Drawing.Point(2, 121)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(559, 255)
        Me.Panel7.TabIndex = 7
        '
        'Status
        '
        Me.Status.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StLab_Count, Me.StLab_Messege})
        Me.Status.Location = New System.Drawing.Point(0, 374)
        Me.Status.Name = "Status"
        Me.Status.Size = New System.Drawing.Size(562, 25)
        Me.Status.TabIndex = 8
        Me.Status.Text = "StatusStrip1"
        '
        'StLab_Count
        '
        Me.StLab_Count.AutoSize = False
        Me.StLab_Count.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.StLab_Count.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.StLab_Count.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.StLab_Count.Image = Global.Pripyat.My.Resources.Resources.sunny_16x16
        Me.StLab_Count.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.StLab_Count.Name = "StLab_Count"
        Me.StLab_Count.Size = New System.Drawing.Size(120, 20)
        Me.StLab_Count.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'StLab_Messege
        '
        Me.StLab_Messege.AutoSize = False
        Me.StLab_Messege.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.StLab_Messege.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.StLab_Messege.ForeColor = System.Drawing.Color.DarkRed
        Me.StLab_Messege.Name = "StLab_Messege"
        Me.StLab_Messege.Size = New System.Drawing.Size(427, 20)
        Me.StLab_Messege.Spring = True
        Me.StLab_Messege.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frSearchAbonent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(562, 399)
        Me.Controls.Add(Me.Status)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frSearchAbonent"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Поиск абонента"
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanSearch_LastSurname.ResumeLayout(False)
        Me.PanSearch_LastSurname.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.PanSearch_Address.ResumeLayout(False)
        Me.PanSearch_Address.PerformLayout()
        Me.PanSearch_AbonentNum.ResumeLayout(False)
        Me.PanSearch_AbonentNum.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Status.ResumeLayout(False)
        Me.Status.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents RadBut_AbonNum As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents RadBut_Adress As System.Windows.Forms.RadioButton
    Friend WithEvents RadBut_LastSurname As System.Windows.Forms.RadioButton
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents PanSearch_AbonentNum As System.Windows.Forms.Panel
    Friend WithEvents Txt_LetterHouse As System.Windows.Forms.TextBox
    Friend WithEvents Txt_House As System.Windows.Forms.TextBox
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Lab_CriterialSearch As System.Windows.Forms.Label
    Friend WithEvents Txt_Room As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Build As System.Windows.Forms.TextBox
    Friend WithEvents But_Search As System.Windows.Forms.Button
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Status As System.Windows.Forms.StatusStrip
    Friend WithEvents StLab_Count As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DataGrid As System.Windows.Forms.DataGridView
    Friend WithEvents Txt_AbonNumber As System.Windows.Forms.MaskedTextBox
    Friend WithEvents PanSearch_LastSurname As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Txt_Surname As System.Windows.Forms.TextBox
    Friend WithEvents PanSearch_Address As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txt_AddressString As System.Windows.Forms.TextBox
    Friend WithEvents StLab_Messege As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents RadBut_MaimMember As System.Windows.Forms.RadioButton
    Friend WithEvents RadBut_MemberPripyat As System.Windows.Forms.RadioButton
    Friend WithEvents RadBut_MemberQuasar As System.Windows.Forms.RadioButton
    Friend WithEvents RadBut_PointNum As System.Windows.Forms.RadioButton
End Class
