namespace PAG_Manager
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable. 
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabActivitySelection = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelActivitySelection = new System.Windows.Forms.TableLayoutPanel();
            this.labelActivitySelectionSkill = new System.Windows.Forms.Label();
            this.dataGridViewActivitySelectionSkills = new System.Windows.Forms.DataGridView();
            this.SkillName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkedListBoxActivitySelectionPag = new System.Windows.Forms.CheckedListBox();
            this.tableLayoutPanelActivitySelectionToolbar = new System.Windows.Forms.TableLayoutPanel();
            this.labelActivitySelectionPag = new System.Windows.Forms.Label();
            this.buttonActivitySelectResetSelection = new System.Windows.Forms.Button();
            this.tabContentSelection = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelContentSelection = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewContentSelectionPag = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkedListBoxContentSelectionSkill = new System.Windows.Forms.CheckedListBox();
            this.tableLayoutContentSelectionSkill = new System.Windows.Forms.TableLayoutPanel();
            this.labelContentSelectionSkill = new System.Windows.Forms.Label();
            this.buttonContentSelectionSelectionReset = new System.Windows.Forms.Button();
            this.tableLayoutPanelContentSelectionActivitySelection = new System.Windows.Forms.TableLayoutPanel();
            this.labelContentSelectionPag = new System.Windows.Forms.Label();
            this.listBoxContentSelectionInclusion = new System.Windows.Forms.ListBox();
            this.tabSkills = new System.Windows.Forms.TabPage();
            this.dataGridViewSkills = new System.Windows.Forms.DataGridView();
            this.StudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentFName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentLName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPagDates = new System.Windows.Forms.TabPage();
            this.dataGridViewPag = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabLookup = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelLookup = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxLookupSearch = new System.Windows.Forms.GroupBox();
            this.buttonLookupSubmitModifications = new System.Windows.Forms.Button();
            this.checkBoxArchives = new System.Windows.Forms.CheckBox();
            this.textBoxLookupName = new System.Windows.Forms.TextBox();
            this.labelLookupName = new System.Windows.Forms.Label();
            this.listBoxStudentNames = new System.Windows.Forms.ListBox();
            this.dataGridViewStudentLookup = new System.Windows.Forms.DataGridView();
            this.tabAwardPag = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelAwardPag = new System.Windows.Forms.TableLayoutPanel();
            this.treeViewYearSelect = new System.Windows.Forms.TreeView();
            this.treeViewPagSelect = new System.Windows.Forms.TreeView();
            this.groupBoxAwardPag = new System.Windows.Forms.GroupBox();
            this.labelAwardPagSelectedAbsent = new System.Windows.Forms.Label();
            this.buttonAwardPagClearSelection = new System.Windows.Forms.Button();
            this.labelAwardPagSelectedFailedSkills = new System.Windows.Forms.Label();
            this.labelAwardPagSelectedPag = new System.Windows.Forms.Label();
            this.labelAwardPagSelectedStudents = new System.Windows.Forms.Label();
            this.buttonAwardPag = new System.Windows.Forms.Button();
            this.labelPagAwardSettingsSelectDate = new System.Windows.Forms.Label();
            this.dateTimePickerAwardPag = new System.Windows.Forms.DateTimePicker();
            this.tabReport = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelStudentReport = new System.Windows.Forms.TableLayoutPanel();
            this.buttonGenerateReport = new System.Windows.Forms.Button();
            this.progressBarStudentReport = new System.Windows.Forms.ProgressBar();
            this.dataGridViewStudentReport = new System.Windows.Forms.DataGridView();
            this.labelReportSettings = new System.Windows.Forms.Label();
            this.tabAdmin = new System.Windows.Forms.TabPage();
            this.tabControlAdmin = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.checkBoxShowStudentID = new System.Windows.Forms.CheckBox();
            this.buttonLoadDefaults = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.radioButtonAdmin = new System.Windows.Forms.RadioButton();
            this.buttonGetDirectory = new System.Windows.Forms.Button();
            this.tabSkillPagList = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelPagSkillList = new System.Windows.Forms.TableLayoutPanel();
            this.listBoxSkillList = new System.Windows.Forms.ListBox();
            this.toolStripSkillList = new System.Windows.Forms.ToolStrip();
            this.skillListToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.skillListToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.skillListToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.skillListToolStripButtonAddRecord = new System.Windows.Forms.ToolStripButton();
            this.skillListToolStripButtonRemovePag = new System.Windows.Forms.ToolStripButton();
            this.skillListToolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripPagList = new System.Windows.Forms.ToolStrip();
            this.pagListToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.pagListToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.pagListToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.pagListToolStripButtonAddRecord = new System.Windows.Forms.ToolStripButton();
            this.pagListToolStripButtonRemovePag = new System.Windows.Forms.ToolStripButton();
            this.pagListToolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.listBoxPagList = new System.Windows.Forms.ListBox();
            this.tabPagSkillRelation = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelPagSkillRelation = new System.Windows.Forms.TableLayoutPanel();
            this.buttonBuildPagSkillRelation = new System.Windows.Forms.Button();
            this.listBoxPagRelation = new System.Windows.Forms.ListBox();
            this.checkedListBoxSkillRelation = new System.Windows.Forms.CheckedListBox();
            this.tabSkillRequirements = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelSkillRequirement = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewSkillRequirement = new System.Windows.Forms.DataGridView();
            this.SkillRequirementsTableSkillName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SkillRequirementsTableRequiredAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSaveSkillRequirement = new System.Windows.Forms.Button();
            this.tabGroup = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelPagGroup = new System.Windows.Forms.TableLayoutPanel();
            this.pagGroupToolStrip = new System.Windows.Forms.ToolStrip();
            this.pagGroupToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.pagGroupToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.pagGroupToolStripSeperator = new System.Windows.Forms.ToolStripSeparator();
            this.pagGroupToolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
            this.pagGroupToolStripRemove = new System.Windows.Forms.ToolStripButton();
            this.pagGroupToolStripSave = new System.Windows.Forms.ToolStripButton();
            this.listBoxGroupList = new System.Windows.Forms.ListBox();
            this.checkedListBoxPagList = new System.Windows.Forms.CheckedListBox();
            this.tabStudentImport = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelImportStudents = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonImportCSV = new System.Windows.Forms.Button();
            this.buttonAddStudentRecord = new System.Windows.Forms.Button();
            this.labelImportStudents = new System.Windows.Forms.Label();
            this.dataGridViewStudentImport = new System.Windows.Forms.DataGridView();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hidePagViewColumnsWithoutPAGDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startMaximisedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openManualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialogImportCSV = new System.Windows.Forms.OpenFileDialog();
            this.StudentReportID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentReportFName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentReportSName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentReportYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentReportClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentReportCondition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControlMain.SuspendLayout();
            this.tabActivitySelection.SuspendLayout();
            this.tableLayoutPanelActivitySelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActivitySelectionSkills)).BeginInit();
            this.tableLayoutPanelActivitySelectionToolbar.SuspendLayout();
            this.tabContentSelection.SuspendLayout();
            this.tableLayoutPanelContentSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContentSelectionPag)).BeginInit();
            this.tableLayoutContentSelectionSkill.SuspendLayout();
            this.tableLayoutPanelContentSelectionActivitySelection.SuspendLayout();
            this.tabSkills.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSkills)).BeginInit();
            this.tabPagDates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPag)).BeginInit();
            this.tabLookup.SuspendLayout();
            this.tableLayoutPanelLookup.SuspendLayout();
            this.groupBoxLookupSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudentLookup)).BeginInit();
            this.tabAwardPag.SuspendLayout();
            this.tableLayoutPanelAwardPag.SuspendLayout();
            this.groupBoxAwardPag.SuspendLayout();
            this.tabReport.SuspendLayout();
            this.tableLayoutPanelStudentReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudentReport)).BeginInit();
            this.tabAdmin.SuspendLayout();
            this.tabControlAdmin.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tabSkillPagList.SuspendLayout();
            this.tableLayoutPanelPagSkillList.SuspendLayout();
            this.toolStripSkillList.SuspendLayout();
            this.toolStripPagList.SuspendLayout();
            this.tabPagSkillRelation.SuspendLayout();
            this.tableLayoutPanelPagSkillRelation.SuspendLayout();
            this.tabSkillRequirements.SuspendLayout();
            this.tableLayoutPanelSkillRequirement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSkillRequirement)).BeginInit();
            this.tabGroup.SuspendLayout();
            this.tableLayoutPanelPagGroup.SuspendLayout();
            this.pagGroupToolStrip.SuspendLayout();
            this.tabStudentImport.SuspendLayout();
            this.tableLayoutPanelImportStudents.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudentImport)).BeginInit();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabActivitySelection);
            this.tabControlMain.Controls.Add(this.tabContentSelection);
            this.tabControlMain.Controls.Add(this.tabSkills);
            this.tabControlMain.Controls.Add(this.tabPagDates);
            this.tabControlMain.Controls.Add(this.tabLookup);
            this.tabControlMain.Controls.Add(this.tabAwardPag);
            this.tabControlMain.Controls.Add(this.tabReport);
            this.tabControlMain.Controls.Add(this.tabAdmin);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 24);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(784, 537);
            this.tabControlMain.TabIndex = 0;
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            // 
            // tabActivitySelection
            // 
            this.tabActivitySelection.Controls.Add(this.tableLayoutPanelActivitySelection);
            this.tabActivitySelection.Location = new System.Drawing.Point(4, 22);
            this.tabActivitySelection.Name = "tabActivitySelection";
            this.tabActivitySelection.Padding = new System.Windows.Forms.Padding(3);
            this.tabActivitySelection.Size = new System.Drawing.Size(776, 511);
            this.tabActivitySelection.TabIndex = 4;
            this.tabActivitySelection.Text = "Activity Selection";
            this.tabActivitySelection.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelActivitySelection
            // 
            this.tableLayoutPanelActivitySelection.ColumnCount = 2;
            this.tableLayoutPanelActivitySelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelActivitySelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelActivitySelection.Controls.Add(this.labelActivitySelectionSkill, 1, 0);
            this.tableLayoutPanelActivitySelection.Controls.Add(this.dataGridViewActivitySelectionSkills, 1, 1);
            this.tableLayoutPanelActivitySelection.Controls.Add(this.checkedListBoxActivitySelectionPag, 0, 1);
            this.tableLayoutPanelActivitySelection.Controls.Add(this.tableLayoutPanelActivitySelectionToolbar, 0, 0);
            this.tableLayoutPanelActivitySelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelActivitySelection.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelActivitySelection.Name = "tableLayoutPanelActivitySelection";
            this.tableLayoutPanelActivitySelection.RowCount = 2;
            this.tableLayoutPanelActivitySelection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanelActivitySelection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelActivitySelection.Size = new System.Drawing.Size(770, 505);
            this.tableLayoutPanelActivitySelection.TabIndex = 0;
            // 
            // labelActivitySelectionSkill
            // 
            this.labelActivitySelectionSkill.AutoSize = true;
            this.labelActivitySelectionSkill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelActivitySelectionSkill.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelActivitySelectionSkill.Location = new System.Drawing.Point(388, 0);
            this.labelActivitySelectionSkill.Name = "labelActivitySelectionSkill";
            this.labelActivitySelectionSkill.Size = new System.Drawing.Size(379, 34);
            this.labelActivitySelectionSkill.TabIndex = 3;
            this.labelActivitySelectionSkill.Text = "Specification Content:";
            this.labelActivitySelectionSkill.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridViewActivitySelectionSkills
            // 
            this.dataGridViewActivitySelectionSkills.AllowUserToAddRows = false;
            this.dataGridViewActivitySelectionSkills.AllowUserToDeleteRows = false;
            this.dataGridViewActivitySelectionSkills.AllowUserToResizeColumns = false;
            this.dataGridViewActivitySelectionSkills.AllowUserToResizeRows = false;
            this.dataGridViewActivitySelectionSkills.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewActivitySelectionSkills.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewActivitySelectionSkills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewActivitySelectionSkills.ColumnHeadersVisible = false;
            this.dataGridViewActivitySelectionSkills.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SkillName});
            this.dataGridViewActivitySelectionSkills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewActivitySelectionSkills.Location = new System.Drawing.Point(388, 37);
            this.dataGridViewActivitySelectionSkills.MultiSelect = false;
            this.dataGridViewActivitySelectionSkills.Name = "dataGridViewActivitySelectionSkills";
            this.dataGridViewActivitySelectionSkills.ReadOnly = true;
            this.dataGridViewActivitySelectionSkills.RowHeadersVisible = false;
            this.dataGridViewActivitySelectionSkills.RowHeadersWidth = 61;
            this.dataGridViewActivitySelectionSkills.RowTemplate.Height = 20;
            this.dataGridViewActivitySelectionSkills.Size = new System.Drawing.Size(379, 465);
            this.dataGridViewActivitySelectionSkills.TabIndex = 0;
            this.dataGridViewActivitySelectionSkills.SelectionChanged += new System.EventHandler(this.dataGridViewActivitySelectionSkills_SelectionChanged);
            // 
            // SkillName
            // 
            this.SkillName.HeaderText = "SkillName";
            this.SkillName.Name = "SkillName";
            this.SkillName.ReadOnly = true;
            // 
            // checkedListBoxActivitySelectionPag
            // 
            this.checkedListBoxActivitySelectionPag.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBoxActivitySelectionPag.CheckOnClick = true;
            this.checkedListBoxActivitySelectionPag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxActivitySelectionPag.FormattingEnabled = true;
            this.checkedListBoxActivitySelectionPag.Location = new System.Drawing.Point(3, 37);
            this.checkedListBoxActivitySelectionPag.Name = "checkedListBoxActivitySelectionPag";
            this.checkedListBoxActivitySelectionPag.Size = new System.Drawing.Size(379, 465);
            this.checkedListBoxActivitySelectionPag.TabIndex = 4;
            this.checkedListBoxActivitySelectionPag.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxActivitySelectionPag_ItemCheck);
            // 
            // tableLayoutPanelActivitySelectionToolbar
            // 
            this.tableLayoutPanelActivitySelectionToolbar.ColumnCount = 2;
            this.tableLayoutPanelActivitySelectionToolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tableLayoutPanelActivitySelectionToolbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelActivitySelectionToolbar.Controls.Add(this.labelActivitySelectionPag, 0, 0);
            this.tableLayoutPanelActivitySelectionToolbar.Controls.Add(this.buttonActivitySelectResetSelection, 1, 0);
            this.tableLayoutPanelActivitySelectionToolbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelActivitySelectionToolbar.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelActivitySelectionToolbar.Name = "tableLayoutPanelActivitySelectionToolbar";
            this.tableLayoutPanelActivitySelectionToolbar.RowCount = 1;
            this.tableLayoutPanelActivitySelectionToolbar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelActivitySelectionToolbar.Size = new System.Drawing.Size(379, 28);
            this.tableLayoutPanelActivitySelectionToolbar.TabIndex = 5;
            // 
            // labelActivitySelectionPag
            // 
            this.labelActivitySelectionPag.AutoSize = true;
            this.labelActivitySelectionPag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelActivitySelectionPag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelActivitySelectionPag.Location = new System.Drawing.Point(3, 0);
            this.labelActivitySelectionPag.Name = "labelActivitySelectionPag";
            this.labelActivitySelectionPag.Size = new System.Drawing.Size(117, 28);
            this.labelActivitySelectionPag.TabIndex = 4;
            this.labelActivitySelectionPag.Text = "Activity Selection:";
            this.labelActivitySelectionPag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonActivitySelectResetSelection
            // 
            this.buttonActivitySelectResetSelection.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonActivitySelectResetSelection.Location = new System.Drawing.Point(278, 3);
            this.buttonActivitySelectResetSelection.Name = "buttonActivitySelectResetSelection";
            this.buttonActivitySelectResetSelection.Size = new System.Drawing.Size(98, 22);
            this.buttonActivitySelectResetSelection.TabIndex = 5;
            this.buttonActivitySelectResetSelection.Text = "Reset Selection";
            this.buttonActivitySelectResetSelection.UseVisualStyleBackColor = true;
            this.buttonActivitySelectResetSelection.Click += new System.EventHandler(this.buttonActivitySelectResetSelection_Click);
            // 
            // tabContentSelection
            // 
            this.tabContentSelection.Controls.Add(this.tableLayoutPanelContentSelection);
            this.tabContentSelection.Location = new System.Drawing.Point(4, 22);
            this.tabContentSelection.Name = "tabContentSelection";
            this.tabContentSelection.Padding = new System.Windows.Forms.Padding(3);
            this.tabContentSelection.Size = new System.Drawing.Size(776, 511);
            this.tabContentSelection.TabIndex = 5;
            this.tabContentSelection.Text = "Specification Content Selection";
            this.tabContentSelection.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelContentSelection
            // 
            this.tableLayoutPanelContentSelection.ColumnCount = 2;
            this.tableLayoutPanelContentSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelContentSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelContentSelection.Controls.Add(this.dataGridViewContentSelectionPag, 0, 1);
            this.tableLayoutPanelContentSelection.Controls.Add(this.checkedListBoxContentSelectionSkill, 1, 1);
            this.tableLayoutPanelContentSelection.Controls.Add(this.tableLayoutContentSelectionSkill, 1, 0);
            this.tableLayoutPanelContentSelection.Controls.Add(this.tableLayoutPanelContentSelectionActivitySelection, 0, 0);
            this.tableLayoutPanelContentSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelContentSelection.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelContentSelection.Name = "tableLayoutPanelContentSelection";
            this.tableLayoutPanelContentSelection.RowCount = 2;
            this.tableLayoutPanelContentSelection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanelContentSelection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelContentSelection.Size = new System.Drawing.Size(770, 505);
            this.tableLayoutPanelContentSelection.TabIndex = 1;
            // 
            // dataGridViewContentSelectionPag
            // 
            this.dataGridViewContentSelectionPag.AllowUserToAddRows = false;
            this.dataGridViewContentSelectionPag.AllowUserToDeleteRows = false;
            this.dataGridViewContentSelectionPag.AllowUserToResizeColumns = false;
            this.dataGridViewContentSelectionPag.AllowUserToResizeRows = false;
            this.dataGridViewContentSelectionPag.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewContentSelectionPag.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewContentSelectionPag.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewContentSelectionPag.ColumnHeadersVisible = false;
            this.dataGridViewContentSelectionPag.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6});
            this.dataGridViewContentSelectionPag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewContentSelectionPag.Location = new System.Drawing.Point(3, 45);
            this.dataGridViewContentSelectionPag.MultiSelect = false;
            this.dataGridViewContentSelectionPag.Name = "dataGridViewContentSelectionPag";
            this.dataGridViewContentSelectionPag.ReadOnly = true;
            this.dataGridViewContentSelectionPag.RowHeadersVisible = false;
            this.dataGridViewContentSelectionPag.RowHeadersWidth = 61;
            this.dataGridViewContentSelectionPag.RowTemplate.Height = 20;
            this.dataGridViewContentSelectionPag.Size = new System.Drawing.Size(379, 457);
            this.dataGridViewContentSelectionPag.TabIndex = 0;
            this.dataGridViewContentSelectionPag.SelectionChanged += new System.EventHandler(this.dataGridViewContentSelectionPag_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "SkillName";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // checkedListBoxContentSelectionSkill
            // 
            this.checkedListBoxContentSelectionSkill.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBoxContentSelectionSkill.CheckOnClick = true;
            this.checkedListBoxContentSelectionSkill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxContentSelectionSkill.FormattingEnabled = true;
            this.checkedListBoxContentSelectionSkill.Location = new System.Drawing.Point(388, 45);
            this.checkedListBoxContentSelectionSkill.Name = "checkedListBoxContentSelectionSkill";
            this.checkedListBoxContentSelectionSkill.Size = new System.Drawing.Size(379, 457);
            this.checkedListBoxContentSelectionSkill.TabIndex = 4;
            this.checkedListBoxContentSelectionSkill.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxContentSelectionSkill_ItemCheck);
            // 
            // tableLayoutContentSelectionSkill
            // 
            this.tableLayoutContentSelectionSkill.ColumnCount = 2;
            this.tableLayoutContentSelectionSkill.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 142F));
            this.tableLayoutContentSelectionSkill.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutContentSelectionSkill.Controls.Add(this.labelContentSelectionSkill, 0, 0);
            this.tableLayoutContentSelectionSkill.Controls.Add(this.buttonContentSelectionSelectionReset, 1, 0);
            this.tableLayoutContentSelectionSkill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutContentSelectionSkill.Location = new System.Drawing.Point(388, 3);
            this.tableLayoutContentSelectionSkill.Name = "tableLayoutContentSelectionSkill";
            this.tableLayoutContentSelectionSkill.RowCount = 1;
            this.tableLayoutContentSelectionSkill.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutContentSelectionSkill.Size = new System.Drawing.Size(379, 36);
            this.tableLayoutContentSelectionSkill.TabIndex = 5;
            // 
            // labelContentSelectionSkill
            // 
            this.labelContentSelectionSkill.AutoSize = true;
            this.labelContentSelectionSkill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelContentSelectionSkill.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContentSelectionSkill.Location = new System.Drawing.Point(3, 0);
            this.labelContentSelectionSkill.Name = "labelContentSelectionSkill";
            this.labelContentSelectionSkill.Size = new System.Drawing.Size(136, 36);
            this.labelContentSelectionSkill.TabIndex = 4;
            this.labelContentSelectionSkill.Text = "Specification Content:";
            this.labelContentSelectionSkill.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonContentSelectionSelectionReset
            // 
            this.buttonContentSelectionSelectionReset.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonContentSelectionSelectionReset.Location = new System.Drawing.Point(278, 3);
            this.buttonContentSelectionSelectionReset.Name = "buttonContentSelectionSelectionReset";
            this.buttonContentSelectionSelectionReset.Size = new System.Drawing.Size(98, 30);
            this.buttonContentSelectionSelectionReset.TabIndex = 5;
            this.buttonContentSelectionSelectionReset.Text = "Reset Selection";
            this.buttonContentSelectionSelectionReset.UseVisualStyleBackColor = true;
            this.buttonContentSelectionSelectionReset.Click += new System.EventHandler(this.buttonContentSelectionSelectionReset_Click);
            // 
            // tableLayoutPanelContentSelectionActivitySelection
            // 
            this.tableLayoutPanelContentSelectionActivitySelection.ColumnCount = 2;
            this.tableLayoutPanelContentSelectionActivitySelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 118F));
            this.tableLayoutPanelContentSelectionActivitySelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 261F));
            this.tableLayoutPanelContentSelectionActivitySelection.Controls.Add(this.labelContentSelectionPag, 0, 0);
            this.tableLayoutPanelContentSelectionActivitySelection.Controls.Add(this.listBoxContentSelectionInclusion, 1, 0);
            this.tableLayoutPanelContentSelectionActivitySelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelContentSelectionActivitySelection.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelContentSelectionActivitySelection.Name = "tableLayoutPanelContentSelectionActivitySelection";
            this.tableLayoutPanelContentSelectionActivitySelection.RowCount = 1;
            this.tableLayoutPanelContentSelectionActivitySelection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelContentSelectionActivitySelection.Size = new System.Drawing.Size(379, 36);
            this.tableLayoutPanelContentSelectionActivitySelection.TabIndex = 6;
            // 
            // labelContentSelectionPag
            // 
            this.labelContentSelectionPag.AutoSize = true;
            this.labelContentSelectionPag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelContentSelectionPag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContentSelectionPag.Location = new System.Drawing.Point(3, 0);
            this.labelContentSelectionPag.Name = "labelContentSelectionPag";
            this.labelContentSelectionPag.Size = new System.Drawing.Size(112, 36);
            this.labelContentSelectionPag.TabIndex = 4;
            this.labelContentSelectionPag.Text = "Activity Selection:";
            this.labelContentSelectionPag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listBoxContentSelectionInclusion
            // 
            this.listBoxContentSelectionInclusion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxContentSelectionInclusion.FormattingEnabled = true;
            this.listBoxContentSelectionInclusion.Items.AddRange(new object[] {
            "PAG\'s must contain at least 1 selected skill",
            "PAG\'s must contain all selected skills"});
            this.listBoxContentSelectionInclusion.Location = new System.Drawing.Point(121, 3);
            this.listBoxContentSelectionInclusion.Name = "listBoxContentSelectionInclusion";
            this.listBoxContentSelectionInclusion.Size = new System.Drawing.Size(255, 30);
            this.listBoxContentSelectionInclusion.TabIndex = 5;
            this.listBoxContentSelectionInclusion.SelectedIndexChanged += new System.EventHandler(this.listBoxContentSelectionInclusion_SelectedIndexChanged);
            // 
            // tabSkills
            // 
            this.tabSkills.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.tabSkills.Controls.Add(this.dataGridViewSkills);
            this.tabSkills.Location = new System.Drawing.Point(4, 22);
            this.tabSkills.Name = "tabSkills";
            this.tabSkills.Padding = new System.Windows.Forms.Padding(3);
            this.tabSkills.Size = new System.Drawing.Size(776, 511);
            this.tabSkills.TabIndex = 0;
            this.tabSkills.Text = "Skills View";
            // 
            // dataGridViewSkills
            // 
            this.dataGridViewSkills.AllowUserToAddRows = false;
            this.dataGridViewSkills.AllowUserToDeleteRows = false;
            this.dataGridViewSkills.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewSkills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSkills.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StudentID,
            this.StudentFName,
            this.StudentLName,
            this.StudentYear,
            this.StudentClass});
            this.dataGridViewSkills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSkills.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewSkills.Name = "dataGridViewSkills";
            this.dataGridViewSkills.ReadOnly = true;
            this.dataGridViewSkills.Size = new System.Drawing.Size(770, 505);
            this.dataGridViewSkills.TabIndex = 0;
            // 
            // StudentID
            // 
            this.StudentID.Frozen = true;
            this.StudentID.HeaderText = "StudentID";
            this.StudentID.Name = "StudentID";
            this.StudentID.ReadOnly = true;
            // 
            // StudentFName
            // 
            this.StudentFName.Frozen = true;
            this.StudentFName.HeaderText = "First Name";
            this.StudentFName.Name = "StudentFName";
            this.StudentFName.ReadOnly = true;
            // 
            // StudentLName
            // 
            this.StudentLName.Frozen = true;
            this.StudentLName.HeaderText = "Last Name";
            this.StudentLName.Name = "StudentLName";
            this.StudentLName.ReadOnly = true;
            // 
            // StudentYear
            // 
            this.StudentYear.Frozen = true;
            this.StudentYear.HeaderText = "Year";
            this.StudentYear.Name = "StudentYear";
            this.StudentYear.ReadOnly = true;
            // 
            // StudentClass
            // 
            this.StudentClass.Frozen = true;
            this.StudentClass.HeaderText = "Class";
            this.StudentClass.Name = "StudentClass";
            this.StudentClass.ReadOnly = true;
            // 
            // tabPagDates
            // 
            this.tabPagDates.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.tabPagDates.Controls.Add(this.dataGridViewPag);
            this.tabPagDates.Location = new System.Drawing.Point(4, 22);
            this.tabPagDates.Margin = new System.Windows.Forms.Padding(2);
            this.tabPagDates.Name = "tabPagDates";
            this.tabPagDates.Padding = new System.Windows.Forms.Padding(2);
            this.tabPagDates.Size = new System.Drawing.Size(776, 511);
            this.tabPagDates.TabIndex = 2;
            this.tabPagDates.Text = "PAG View";
            // 
            // dataGridViewPag
            // 
            this.dataGridViewPag.AllowUserToAddRows = false;
            this.dataGridViewPag.AllowUserToDeleteRows = false;
            this.dataGridViewPag.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewPag.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPag.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dataGridViewPag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPag.Location = new System.Drawing.Point(2, 2);
            this.dataGridViewPag.Name = "dataGridViewPag";
            this.dataGridViewPag.ReadOnly = true;
            this.dataGridViewPag.Size = new System.Drawing.Size(772, 507);
            this.dataGridViewPag.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "StudentID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "First Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.Frozen = true;
            this.dataGridViewTextBoxColumn3.HeaderText = "Last Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.Frozen = true;
            this.dataGridViewTextBoxColumn4.HeaderText = "Year";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.Frozen = true;
            this.dataGridViewTextBoxColumn5.HeaderText = "Class";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // tabLookup
            // 
            this.tabLookup.Controls.Add(this.tableLayoutPanelLookup);
            this.tabLookup.Location = new System.Drawing.Point(4, 22);
            this.tabLookup.Name = "tabLookup";
            this.tabLookup.Padding = new System.Windows.Forms.Padding(3);
            this.tabLookup.Size = new System.Drawing.Size(776, 511);
            this.tabLookup.TabIndex = 3;
            this.tabLookup.Text = "Student Lookup";
            this.tabLookup.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelLookup
            // 
            this.tableLayoutPanelLookup.ColumnCount = 2;
            this.tableLayoutPanelLookup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanelLookup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelLookup.Controls.Add(this.groupBoxLookupSearch, 0, 0);
            this.tableLayoutPanelLookup.Controls.Add(this.listBoxStudentNames, 0, 1);
            this.tableLayoutPanelLookup.Controls.Add(this.dataGridViewStudentLookup, 1, 1);
            this.tableLayoutPanelLookup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLookup.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelLookup.Name = "tableLayoutPanelLookup";
            this.tableLayoutPanelLookup.RowCount = 2;
            this.tableLayoutPanelLookup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelLookup.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelLookup.Size = new System.Drawing.Size(770, 505);
            this.tableLayoutPanelLookup.TabIndex = 0;
            // 
            // groupBoxLookupSearch
            // 
            this.tableLayoutPanelLookup.SetColumnSpan(this.groupBoxLookupSearch, 2);
            this.groupBoxLookupSearch.Controls.Add(this.buttonLookupSubmitModifications);
            this.groupBoxLookupSearch.Controls.Add(this.checkBoxArchives);
            this.groupBoxLookupSearch.Controls.Add(this.textBoxLookupName);
            this.groupBoxLookupSearch.Controls.Add(this.labelLookupName);
            this.groupBoxLookupSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLookupSearch.Location = new System.Drawing.Point(3, 3);
            this.groupBoxLookupSearch.Name = "groupBoxLookupSearch";
            this.groupBoxLookupSearch.Size = new System.Drawing.Size(764, 54);
            this.groupBoxLookupSearch.TabIndex = 0;
            this.groupBoxLookupSearch.TabStop = false;
            this.groupBoxLookupSearch.Text = "Student Lookup";
            // 
            // buttonLookupSubmitModifications
            // 
            this.buttonLookupSubmitModifications.Location = new System.Drawing.Point(567, 19);
            this.buttonLookupSubmitModifications.Name = "buttonLookupSubmitModifications";
            this.buttonLookupSubmitModifications.Size = new System.Drawing.Size(92, 23);
            this.buttonLookupSubmitModifications.TabIndex = 6;
            this.buttonLookupSubmitModifications.Text = "Save Changes";
            this.buttonLookupSubmitModifications.UseVisualStyleBackColor = true;
            this.buttonLookupSubmitModifications.Click += new System.EventHandler(this.buttonLookupSubmitModifications_Click);
            // 
            // checkBoxArchives
            // 
            this.checkBoxArchives.AutoSize = true;
            this.checkBoxArchives.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxArchives.Location = new System.Drawing.Point(321, 23);
            this.checkBoxArchives.Name = "checkBoxArchives";
            this.checkBoxArchives.Size = new System.Drawing.Size(104, 17);
            this.checkBoxArchives.TabIndex = 4;
            this.checkBoxArchives.Text = "Search Archives";
            this.checkBoxArchives.UseVisualStyleBackColor = true;
            this.checkBoxArchives.CheckedChanged += new System.EventHandler(this.checkBoxArchives_CheckedChanged);
            // 
            // textBoxLookupName
            // 
            this.textBoxLookupName.Location = new System.Drawing.Point(124, 21);
            this.textBoxLookupName.Name = "textBoxLookupName";
            this.textBoxLookupName.Size = new System.Drawing.Size(191, 20);
            this.textBoxLookupName.TabIndex = 1;
            this.textBoxLookupName.TextChanged += new System.EventHandler(this.textBoxLookupName_TextChanged);
            // 
            // labelLookupName
            // 
            this.labelLookupName.AutoSize = true;
            this.labelLookupName.Location = new System.Drawing.Point(6, 24);
            this.labelLookupName.Name = "labelLookupName";
            this.labelLookupName.Size = new System.Drawing.Size(112, 13);
            this.labelLookupName.TabIndex = 0;
            this.labelLookupName.Text = "Search name or class:";
            // 
            // listBoxStudentNames
            // 
            this.listBoxStudentNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxStudentNames.FormattingEnabled = true;
            this.listBoxStudentNames.Location = new System.Drawing.Point(3, 63);
            this.listBoxStudentNames.Name = "listBoxStudentNames";
            this.listBoxStudentNames.Size = new System.Drawing.Size(174, 463);
            this.listBoxStudentNames.TabIndex = 1;
            this.listBoxStudentNames.SelectedIndexChanged += new System.EventHandler(this.listBoxStudentNames_SelectedIndexChanged);
            // 
            // dataGridViewStudentLookup
            // 
            this.dataGridViewStudentLookup.AllowUserToAddRows = false;
            this.dataGridViewStudentLookup.AllowUserToDeleteRows = false;
            this.dataGridViewStudentLookup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewStudentLookup.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewStudentLookup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewStudentLookup.Location = new System.Drawing.Point(183, 63);
            this.dataGridViewStudentLookup.Name = "dataGridViewStudentLookup";
            this.dataGridViewStudentLookup.Size = new System.Drawing.Size(584, 463);
            this.dataGridViewStudentLookup.TabIndex = 2;
            this.dataGridViewStudentLookup.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewStudentLookup_CellEndEdit);
            this.dataGridViewStudentLookup.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStudentLookup_CellValueChanged);
            this.dataGridViewStudentLookup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewStudentLookup_KeyDown);
            // 
            // tabAwardPag
            // 
            this.tabAwardPag.Controls.Add(this.tableLayoutPanelAwardPag);
            this.tabAwardPag.Location = new System.Drawing.Point(4, 22);
            this.tabAwardPag.Name = "tabAwardPag";
            this.tabAwardPag.Padding = new System.Windows.Forms.Padding(3);
            this.tabAwardPag.Size = new System.Drawing.Size(776, 511);
            this.tabAwardPag.TabIndex = 6;
            this.tabAwardPag.Text = "Award PAG";
            this.tabAwardPag.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelAwardPag
            // 
            this.tableLayoutPanelAwardPag.ColumnCount = 3;
            this.tableLayoutPanelAwardPag.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelAwardPag.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelAwardPag.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 182F));
            this.tableLayoutPanelAwardPag.Controls.Add(this.treeViewYearSelect, 0, 0);
            this.tableLayoutPanelAwardPag.Controls.Add(this.treeViewPagSelect, 1, 0);
            this.tableLayoutPanelAwardPag.Controls.Add(this.groupBoxAwardPag, 2, 0);
            this.tableLayoutPanelAwardPag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelAwardPag.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelAwardPag.Name = "tableLayoutPanelAwardPag";
            this.tableLayoutPanelAwardPag.RowCount = 1;
            this.tableLayoutPanelAwardPag.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelAwardPag.Size = new System.Drawing.Size(770, 505);
            this.tableLayoutPanelAwardPag.TabIndex = 0;
            // 
            // treeViewYearSelect
            // 
            this.treeViewYearSelect.CheckBoxes = true;
            this.treeViewYearSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewYearSelect.Location = new System.Drawing.Point(3, 3);
            this.treeViewYearSelect.Name = "treeViewYearSelect";
            this.treeViewYearSelect.Size = new System.Drawing.Size(288, 499);
            this.treeViewYearSelect.TabIndex = 0;
            this.treeViewYearSelect.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewYearSelect_AfterCheck);
            // 
            // treeViewPagSelect
            // 
            this.treeViewPagSelect.CheckBoxes = true;
            this.treeViewPagSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewPagSelect.Location = new System.Drawing.Point(297, 3);
            this.treeViewPagSelect.Name = "treeViewPagSelect";
            this.treeViewPagSelect.Size = new System.Drawing.Size(288, 499);
            this.treeViewPagSelect.TabIndex = 1;
            this.treeViewPagSelect.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewPagSelect_AfterCheck);
            // 
            // groupBoxAwardPag
            // 
            this.groupBoxAwardPag.Controls.Add(this.labelAwardPagSelectedAbsent);
            this.groupBoxAwardPag.Controls.Add(this.buttonAwardPagClearSelection);
            this.groupBoxAwardPag.Controls.Add(this.labelAwardPagSelectedFailedSkills);
            this.groupBoxAwardPag.Controls.Add(this.labelAwardPagSelectedPag);
            this.groupBoxAwardPag.Controls.Add(this.labelAwardPagSelectedStudents);
            this.groupBoxAwardPag.Controls.Add(this.buttonAwardPag);
            this.groupBoxAwardPag.Controls.Add(this.labelPagAwardSettingsSelectDate);
            this.groupBoxAwardPag.Controls.Add(this.dateTimePickerAwardPag);
            this.groupBoxAwardPag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxAwardPag.Location = new System.Drawing.Point(591, 3);
            this.groupBoxAwardPag.Name = "groupBoxAwardPag";
            this.groupBoxAwardPag.Size = new System.Drawing.Size(176, 499);
            this.groupBoxAwardPag.TabIndex = 2;
            this.groupBoxAwardPag.TabStop = false;
            this.groupBoxAwardPag.Text = "PAG Award Settings";
            // 
            // labelAwardPagSelectedAbsent
            // 
            this.labelAwardPagSelectedAbsent.Location = new System.Drawing.Point(6, 114);
            this.labelAwardPagSelectedAbsent.Name = "labelAwardPagSelectedAbsent";
            this.labelAwardPagSelectedAbsent.Size = new System.Drawing.Size(164, 31);
            this.labelAwardPagSelectedAbsent.TabIndex = 11;
            this.labelAwardPagSelectedAbsent.Text = "0 students within the selected class will be marked as absent";
            // 
            // buttonAwardPagClearSelection
            // 
            this.buttonAwardPagClearSelection.Location = new System.Drawing.Point(6, 19);
            this.buttonAwardPagClearSelection.Name = "buttonAwardPagClearSelection";
            this.buttonAwardPagClearSelection.Size = new System.Drawing.Size(164, 23);
            this.buttonAwardPagClearSelection.TabIndex = 10;
            this.buttonAwardPagClearSelection.Text = "Clear Selection";
            this.buttonAwardPagClearSelection.UseVisualStyleBackColor = true;
            this.buttonAwardPagClearSelection.Click += new System.EventHandler(this.buttonAwardPagClearSelection_Click);
            // 
            // labelAwardPagSelectedFailedSkills
            // 
            this.labelAwardPagSelectedFailedSkills.Location = new System.Drawing.Point(6, 173);
            this.labelAwardPagSelectedFailedSkills.Name = "labelAwardPagSelectedFailedSkills";
            this.labelAwardPagSelectedFailedSkills.Size = new System.Drawing.Size(164, 31);
            this.labelAwardPagSelectedFailedSkills.TabIndex = 9;
            this.labelAwardPagSelectedFailedSkills.Text = "0 skills within the selected PAG\'s will be marked as failed";
            // 
            // labelAwardPagSelectedPag
            // 
            this.labelAwardPagSelectedPag.AutoSize = true;
            this.labelAwardPagSelectedPag.Location = new System.Drawing.Point(6, 148);
            this.labelAwardPagSelectedPag.Name = "labelAwardPagSelectedPag";
            this.labelAwardPagSelectedPag.Size = new System.Drawing.Size(131, 13);
            this.labelAwardPagSelectedPag.TabIndex = 8;
            this.labelAwardPagSelectedPag.Text = "You are awarding 0 PAG\'s";
            // 
            // labelAwardPagSelectedStudents
            // 
            this.labelAwardPagSelectedStudents.AutoSize = true;
            this.labelAwardPagSelectedStudents.Location = new System.Drawing.Point(6, 94);
            this.labelAwardPagSelectedStudents.Name = "labelAwardPagSelectedStudents";
            this.labelAwardPagSelectedStudents.Size = new System.Drawing.Size(148, 13);
            this.labelAwardPagSelectedStudents.TabIndex = 7;
            this.labelAwardPagSelectedStudents.Text = "You have selected 0 students";
            // 
            // buttonAwardPag
            // 
            this.buttonAwardPag.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonAwardPag.Location = new System.Drawing.Point(3, 473);
            this.buttonAwardPag.Name = "buttonAwardPag";
            this.buttonAwardPag.Size = new System.Drawing.Size(170, 23);
            this.buttonAwardPag.TabIndex = 6;
            this.buttonAwardPag.Text = "Award PAG";
            this.buttonAwardPag.UseVisualStyleBackColor = true;
            this.buttonAwardPag.Click += new System.EventHandler(this.buttonAwardPag_Click);
            // 
            // labelPagAwardSettingsSelectDate
            // 
            this.labelPagAwardSettingsSelectDate.AutoSize = true;
            this.labelPagAwardSettingsSelectDate.Location = new System.Drawing.Point(1, 46);
            this.labelPagAwardSettingsSelectDate.Name = "labelPagAwardSettingsSelectDate";
            this.labelPagAwardSettingsSelectDate.Size = new System.Drawing.Size(161, 13);
            this.labelPagAwardSettingsSelectDate.TabIndex = 4;
            this.labelPagAwardSettingsSelectDate.Text = "Select the PAG completion date:";
            // 
            // dateTimePickerAwardPag
            // 
            this.dateTimePickerAwardPag.CustomFormat = "d/M/yyyy";
            this.dateTimePickerAwardPag.Location = new System.Drawing.Point(3, 62);
            this.dateTimePickerAwardPag.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerAwardPag.Name = "dateTimePickerAwardPag";
            this.dateTimePickerAwardPag.Size = new System.Drawing.Size(170, 20);
            this.dateTimePickerAwardPag.TabIndex = 3;
            this.dateTimePickerAwardPag.ValueChanged += new System.EventHandler(this.dateTimePickerAwardPag_ValueChanged);
            // 
            // tabReport
            // 
            this.tabReport.Controls.Add(this.tableLayoutPanelStudentReport);
            this.tabReport.Location = new System.Drawing.Point(4, 22);
            this.tabReport.Name = "tabReport";
            this.tabReport.Padding = new System.Windows.Forms.Padding(3);
            this.tabReport.Size = new System.Drawing.Size(776, 511);
            this.tabReport.TabIndex = 7;
            this.tabReport.Text = "Student Report";
            this.tabReport.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelStudentReport
            // 
            this.tableLayoutPanelStudentReport.ColumnCount = 3;
            this.tableLayoutPanelStudentReport.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanelStudentReport.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelStudentReport.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanelStudentReport.Controls.Add(this.buttonGenerateReport, 0, 0);
            this.tableLayoutPanelStudentReport.Controls.Add(this.progressBarStudentReport, 1, 0);
            this.tableLayoutPanelStudentReport.Controls.Add(this.dataGridViewStudentReport, 0, 1);
            this.tableLayoutPanelStudentReport.Controls.Add(this.labelReportSettings, 2, 0);
            this.tableLayoutPanelStudentReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelStudentReport.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelStudentReport.Name = "tableLayoutPanelStudentReport";
            this.tableLayoutPanelStudentReport.RowCount = 2;
            this.tableLayoutPanelStudentReport.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanelStudentReport.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelStudentReport.Size = new System.Drawing.Size(770, 505);
            this.tableLayoutPanelStudentReport.TabIndex = 0;
            // 
            // buttonGenerateReport
            // 
            this.buttonGenerateReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonGenerateReport.Location = new System.Drawing.Point(3, 3);
            this.buttonGenerateReport.Name = "buttonGenerateReport";
            this.buttonGenerateReport.Size = new System.Drawing.Size(94, 22);
            this.buttonGenerateReport.TabIndex = 0;
            this.buttonGenerateReport.Text = "Generate Report";
            this.buttonGenerateReport.UseVisualStyleBackColor = true;
            this.buttonGenerateReport.Click += new System.EventHandler(this.buttonGenerateReport_Click);
            // 
            // progressBarStudentReport
            // 
            this.progressBarStudentReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBarStudentReport.Location = new System.Drawing.Point(103, 3);
            this.progressBarStudentReport.Name = "progressBarStudentReport";
            this.progressBarStudentReport.Size = new System.Drawing.Size(464, 22);
            this.progressBarStudentReport.TabIndex = 1;
            // 
            // dataGridViewStudentReport
            // 
            this.dataGridViewStudentReport.AllowUserToAddRows = false;
            this.dataGridViewStudentReport.AllowUserToDeleteRows = false;
            this.dataGridViewStudentReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStudentReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StudentReportID,
            this.StudentReportFName,
            this.StudentReportSName,
            this.StudentReportYear,
            this.StudentReportClass,
            this.StudentReportCondition});
            this.tableLayoutPanelStudentReport.SetColumnSpan(this.dataGridViewStudentReport, 2);
            this.dataGridViewStudentReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewStudentReport.Location = new System.Drawing.Point(3, 31);
            this.dataGridViewStudentReport.Name = "dataGridViewStudentReport";
            this.dataGridViewStudentReport.ReadOnly = true;
            this.dataGridViewStudentReport.Size = new System.Drawing.Size(564, 471);
            this.dataGridViewStudentReport.TabIndex = 2;
            this.dataGridViewStudentReport.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStudentReport_CellClick);
            this.dataGridViewStudentReport.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStudentReport_CellEnter);
            // 
            // labelReportSettings
            // 
            this.labelReportSettings.AutoSize = true;
            this.labelReportSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelReportSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReportSettings.Location = new System.Drawing.Point(573, 0);
            this.labelReportSettings.Name = "labelReportSettings";
            this.labelReportSettings.Size = new System.Drawing.Size(194, 28);
            this.labelReportSettings.TabIndex = 3;
            this.labelReportSettings.Text = "Report Settings";
            this.labelReportSettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabAdmin
            // 
            this.tabAdmin.Controls.Add(this.tabControlAdmin);
            this.tabAdmin.Location = new System.Drawing.Point(4, 22);
            this.tabAdmin.Name = "tabAdmin";
            this.tabAdmin.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdmin.Size = new System.Drawing.Size(776, 511);
            this.tabAdmin.TabIndex = 1;
            this.tabAdmin.Text = "Admin";
            this.tabAdmin.UseVisualStyleBackColor = true;
            // 
            // tabControlAdmin
            // 
            this.tabControlAdmin.Controls.Add(this.tabGeneral);
            this.tabControlAdmin.Controls.Add(this.tabSkillPagList);
            this.tabControlAdmin.Controls.Add(this.tabPagSkillRelation);
            this.tabControlAdmin.Controls.Add(this.tabSkillRequirements);
            this.tabControlAdmin.Controls.Add(this.tabGroup);
            this.tabControlAdmin.Controls.Add(this.tabStudentImport);
            this.tabControlAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlAdmin.Location = new System.Drawing.Point(3, 3);
            this.tabControlAdmin.Name = "tabControlAdmin";
            this.tabControlAdmin.SelectedIndex = 0;
            this.tabControlAdmin.Size = new System.Drawing.Size(770, 505);
            this.tabControlAdmin.TabIndex = 3;
            this.tabControlAdmin.Resize += new System.EventHandler(this.tabControlAdmin_Resize);
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.checkBoxShowStudentID);
            this.tabGeneral.Controls.Add(this.buttonLoadDefaults);
            this.tabGeneral.Controls.Add(this.button2);
            this.tabGeneral.Controls.Add(this.radioButtonAdmin);
            this.tabGeneral.Controls.Add(this.buttonGetDirectory);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(762, 479);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowStudentID
            // 
            this.checkBoxShowStudentID.AutoSize = true;
            this.checkBoxShowStudentID.Location = new System.Drawing.Point(344, 22);
            this.checkBoxShowStudentID.Name = "checkBoxShowStudentID";
            this.checkBoxShowStudentID.Size = new System.Drawing.Size(107, 17);
            this.checkBoxShowStudentID.TabIndex = 4;
            this.checkBoxShowStudentID.Text = "Show Student ID";
            this.checkBoxShowStudentID.UseVisualStyleBackColor = true;
            this.checkBoxShowStudentID.CheckedChanged += new System.EventHandler(this.checkBoxShowStudentID_CheckedChanged);
            // 
            // buttonLoadDefaults
            // 
            this.buttonLoadDefaults.Location = new System.Drawing.Point(53, 86);
            this.buttonLoadDefaults.Name = "buttonLoadDefaults";
            this.buttonLoadDefaults.Size = new System.Drawing.Size(120, 23);
            this.buttonLoadDefaults.TabIndex = 3;
            this.buttonLoadDefaults.Text = "Load Default Settings";
            this.buttonLoadDefaults.UseVisualStyleBackColor = true;
            this.buttonLoadDefaults.Click += new System.EventHandler(this.buttonLoadDefaults_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(53, 115);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // radioButtonAdmin
            // 
            this.radioButtonAdmin.AutoSize = true;
            this.radioButtonAdmin.Location = new System.Drawing.Point(43, 22);
            this.radioButtonAdmin.Name = "radioButtonAdmin";
            this.radioButtonAdmin.Size = new System.Drawing.Size(194, 17);
            this.radioButtonAdmin.TabIndex = 0;
            this.radioButtonAdmin.Text = "Enable Advanced Database Editing";
            this.radioButtonAdmin.UseVisualStyleBackColor = true;
            this.radioButtonAdmin.CheckedChanged += new System.EventHandler(this.radioButtonAdmin_CheckedChanged);
            // 
            // buttonGetDirectory
            // 
            this.buttonGetDirectory.Location = new System.Drawing.Point(53, 56);
            this.buttonGetDirectory.Name = "buttonGetDirectory";
            this.buttonGetDirectory.Size = new System.Drawing.Size(110, 23);
            this.buttonGetDirectory.TabIndex = 1;
            this.buttonGetDirectory.Text = "Get Main Directory";
            this.buttonGetDirectory.UseVisualStyleBackColor = true;
            this.buttonGetDirectory.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabSkillPagList
            // 
            this.tabSkillPagList.Controls.Add(this.tableLayoutPanelPagSkillList);
            this.tabSkillPagList.Location = new System.Drawing.Point(4, 22);
            this.tabSkillPagList.Name = "tabSkillPagList";
            this.tabSkillPagList.Padding = new System.Windows.Forms.Padding(3);
            this.tabSkillPagList.Size = new System.Drawing.Size(762, 479);
            this.tabSkillPagList.TabIndex = 1;
            this.tabSkillPagList.Text = "List of PAG\'s and Skills";
            this.tabSkillPagList.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelPagSkillList
            // 
            this.tableLayoutPanelPagSkillList.ColumnCount = 2;
            this.tableLayoutPanelPagSkillList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelPagSkillList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelPagSkillList.Controls.Add(this.listBoxSkillList, 0, 1);
            this.tableLayoutPanelPagSkillList.Controls.Add(this.toolStripSkillList, 1, 0);
            this.tableLayoutPanelPagSkillList.Controls.Add(this.toolStripPagList, 0, 0);
            this.tableLayoutPanelPagSkillList.Controls.Add(this.listBoxPagList, 0, 1);
            this.tableLayoutPanelPagSkillList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelPagSkillList.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelPagSkillList.Name = "tableLayoutPanelPagSkillList";
            this.tableLayoutPanelPagSkillList.RowCount = 2;
            this.tableLayoutPanelPagSkillList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanelPagSkillList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPagSkillList.Size = new System.Drawing.Size(756, 473);
            this.tableLayoutPanelPagSkillList.TabIndex = 0;
            // 
            // listBoxSkillList
            // 
            this.listBoxSkillList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxSkillList.FormattingEnabled = true;
            this.listBoxSkillList.Location = new System.Drawing.Point(381, 28);
            this.listBoxSkillList.Name = "listBoxSkillList";
            this.listBoxSkillList.Size = new System.Drawing.Size(372, 442);
            this.listBoxSkillList.TabIndex = 3;
            this.listBoxSkillList.SelectedIndexChanged += new System.EventHandler(this.listBoxSkillList_SelectedIndexChanged);
            // 
            // toolStripSkillList
            // 
            this.toolStripSkillList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.skillListToolStripLabel,
            this.skillListToolStripTextBox,
            this.skillListToolStripSeparator,
            this.skillListToolStripButtonAddRecord,
            this.skillListToolStripButtonRemovePag,
            this.skillListToolStripButtonSave});
            this.toolStripSkillList.Location = new System.Drawing.Point(378, 0);
            this.toolStripSkillList.Name = "toolStripSkillList";
            this.toolStripSkillList.Size = new System.Drawing.Size(378, 25);
            this.toolStripSkillList.TabIndex = 2;
            this.toolStripSkillList.Text = "PAG list tool strip";
            // 
            // skillListToolStripLabel
            // 
            this.skillListToolStripLabel.Name = "skillListToolStripLabel";
            this.skillListToolStripLabel.Size = new System.Drawing.Size(36, 22);
            this.skillListToolStripLabel.Text = "Skills:";
            // 
            // skillListToolStripTextBox
            // 
            this.skillListToolStripTextBox.Name = "skillListToolStripTextBox";
            this.skillListToolStripTextBox.Size = new System.Drawing.Size(237, 25);
            this.skillListToolStripTextBox.TextChanged += new System.EventHandler(this.skillListToolStripTextBox_TextChanged);
            // 
            // skillListToolStripSeparator
            // 
            this.skillListToolStripSeparator.Name = "skillListToolStripSeparator";
            this.skillListToolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // skillListToolStripButtonAddRecord
            // 
            this.skillListToolStripButtonAddRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.skillListToolStripButtonAddRecord.Image = ((System.Drawing.Image)(resources.GetObject("skillListToolStripButtonAddRecord.Image")));
            this.skillListToolStripButtonAddRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.skillListToolStripButtonAddRecord.Name = "skillListToolStripButtonAddRecord";
            this.skillListToolStripButtonAddRecord.Size = new System.Drawing.Size(23, 22);
            this.skillListToolStripButtonAddRecord.Text = "Add Record";
            this.skillListToolStripButtonAddRecord.Click += new System.EventHandler(this.skillListToolStripButtonAddRecord_Click);
            // 
            // skillListToolStripButtonRemovePag
            // 
            this.skillListToolStripButtonRemovePag.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.skillListToolStripButtonRemovePag.Image = ((System.Drawing.Image)(resources.GetObject("skillListToolStripButtonRemovePag.Image")));
            this.skillListToolStripButtonRemovePag.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.skillListToolStripButtonRemovePag.Name = "skillListToolStripButtonRemovePag";
            this.skillListToolStripButtonRemovePag.Size = new System.Drawing.Size(23, 22);
            this.skillListToolStripButtonRemovePag.Text = "Remove Record";
            this.skillListToolStripButtonRemovePag.Click += new System.EventHandler(this.skillListToolStripButtonRemovePag_Click);
            // 
            // skillListToolStripButtonSave
            // 
            this.skillListToolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.skillListToolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("skillListToolStripButtonSave.Image")));
            this.skillListToolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.skillListToolStripButtonSave.Name = "skillListToolStripButtonSave";
            this.skillListToolStripButtonSave.Size = new System.Drawing.Size(23, 22);
            this.skillListToolStripButtonSave.Text = "Save Data";
            this.skillListToolStripButtonSave.Click += new System.EventHandler(this.skillListToolStripButtonSave_Click);
            // 
            // toolStripPagList
            // 
            this.toolStripPagList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pagListToolStripLabel,
            this.pagListToolStripTextBox,
            this.pagListToolStripSeparator,
            this.pagListToolStripButtonAddRecord,
            this.pagListToolStripButtonRemovePag,
            this.pagListToolStripButtonSave});
            this.toolStripPagList.Location = new System.Drawing.Point(0, 0);
            this.toolStripPagList.Name = "toolStripPagList";
            this.toolStripPagList.Size = new System.Drawing.Size(378, 25);
            this.toolStripPagList.TabIndex = 0;
            this.toolStripPagList.Text = "PAG list tool strip";
            // 
            // pagListToolStripLabel
            // 
            this.pagListToolStripLabel.Name = "pagListToolStripLabel";
            this.pagListToolStripLabel.Size = new System.Drawing.Size(37, 22);
            this.pagListToolStripLabel.Text = "PAGs:";
            // 
            // pagListToolStripTextBox
            // 
            this.pagListToolStripTextBox.Name = "pagListToolStripTextBox";
            this.pagListToolStripTextBox.Size = new System.Drawing.Size(237, 25);
            this.pagListToolStripTextBox.TextChanged += new System.EventHandler(this.pagListToolStripTextBox_TextChanged);
            // 
            // pagListToolStripSeparator
            // 
            this.pagListToolStripSeparator.Name = "pagListToolStripSeparator";
            this.pagListToolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // pagListToolStripButtonAddRecord
            // 
            this.pagListToolStripButtonAddRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pagListToolStripButtonAddRecord.Image = ((System.Drawing.Image)(resources.GetObject("pagListToolStripButtonAddRecord.Image")));
            this.pagListToolStripButtonAddRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pagListToolStripButtonAddRecord.Name = "pagListToolStripButtonAddRecord";
            this.pagListToolStripButtonAddRecord.Size = new System.Drawing.Size(23, 22);
            this.pagListToolStripButtonAddRecord.Text = "Add Record";
            this.pagListToolStripButtonAddRecord.Click += new System.EventHandler(this.pagListToolStripButtonAddRecord_Click);
            // 
            // pagListToolStripButtonRemovePag
            // 
            this.pagListToolStripButtonRemovePag.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pagListToolStripButtonRemovePag.Image = ((System.Drawing.Image)(resources.GetObject("pagListToolStripButtonRemovePag.Image")));
            this.pagListToolStripButtonRemovePag.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pagListToolStripButtonRemovePag.Name = "pagListToolStripButtonRemovePag";
            this.pagListToolStripButtonRemovePag.Size = new System.Drawing.Size(23, 22);
            this.pagListToolStripButtonRemovePag.Text = "Remove Record";
            this.pagListToolStripButtonRemovePag.Click += new System.EventHandler(this.pagListToolStripButtonRemovePag_Click);
            // 
            // pagListToolStripButtonSave
            // 
            this.pagListToolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pagListToolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("pagListToolStripButtonSave.Image")));
            this.pagListToolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pagListToolStripButtonSave.Name = "pagListToolStripButtonSave";
            this.pagListToolStripButtonSave.Size = new System.Drawing.Size(23, 22);
            this.pagListToolStripButtonSave.Text = "Save Data";
            this.pagListToolStripButtonSave.Click += new System.EventHandler(this.pagListToolStripButtonSave_Click);
            // 
            // listBoxPagList
            // 
            this.listBoxPagList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxPagList.FormattingEnabled = true;
            this.listBoxPagList.Location = new System.Drawing.Point(3, 28);
            this.listBoxPagList.Name = "listBoxPagList";
            this.listBoxPagList.Size = new System.Drawing.Size(372, 442);
            this.listBoxPagList.TabIndex = 1;
            this.listBoxPagList.SelectedIndexChanged += new System.EventHandler(this.listBoxPagList_SelectedIndexChanged);
            // 
            // tabPagSkillRelation
            // 
            this.tabPagSkillRelation.Controls.Add(this.tableLayoutPanelPagSkillRelation);
            this.tabPagSkillRelation.Location = new System.Drawing.Point(4, 22);
            this.tabPagSkillRelation.Name = "tabPagSkillRelation";
            this.tabPagSkillRelation.Size = new System.Drawing.Size(762, 479);
            this.tabPagSkillRelation.TabIndex = 2;
            this.tabPagSkillRelation.Text = "PAG and Skill Relations";
            this.tabPagSkillRelation.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelPagSkillRelation
            // 
            this.tableLayoutPanelPagSkillRelation.ColumnCount = 2;
            this.tableLayoutPanelPagSkillRelation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelPagSkillRelation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelPagSkillRelation.Controls.Add(this.buttonBuildPagSkillRelation, 0, 0);
            this.tableLayoutPanelPagSkillRelation.Controls.Add(this.listBoxPagRelation, 0, 1);
            this.tableLayoutPanelPagSkillRelation.Controls.Add(this.checkedListBoxSkillRelation, 1, 1);
            this.tableLayoutPanelPagSkillRelation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelPagSkillRelation.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelPagSkillRelation.Name = "tableLayoutPanelPagSkillRelation";
            this.tableLayoutPanelPagSkillRelation.RowCount = 2;
            this.tableLayoutPanelPagSkillRelation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelPagSkillRelation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPagSkillRelation.Size = new System.Drawing.Size(762, 479);
            this.tableLayoutPanelPagSkillRelation.TabIndex = 0;
            // 
            // buttonBuildPagSkillRelation
            // 
            this.buttonBuildPagSkillRelation.Location = new System.Drawing.Point(3, 3);
            this.buttonBuildPagSkillRelation.Name = "buttonBuildPagSkillRelation";
            this.buttonBuildPagSkillRelation.Size = new System.Drawing.Size(148, 23);
            this.buttonBuildPagSkillRelation.TabIndex = 2;
            this.buttonBuildPagSkillRelation.Text = "Build PAG-Skill Relations";
            this.buttonBuildPagSkillRelation.UseVisualStyleBackColor = true;
            this.buttonBuildPagSkillRelation.Click += new System.EventHandler(this.buttonBuildPagSkillRelation_Click);
            // 
            // listBoxPagRelation
            // 
            this.listBoxPagRelation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxPagRelation.FormattingEnabled = true;
            this.listBoxPagRelation.Location = new System.Drawing.Point(3, 33);
            this.listBoxPagRelation.Name = "listBoxPagRelation";
            this.listBoxPagRelation.Size = new System.Drawing.Size(375, 443);
            this.listBoxPagRelation.TabIndex = 0;
            this.listBoxPagRelation.SelectedIndexChanged += new System.EventHandler(this.listBoxPagRelation_SelectedIndexChanged);
            // 
            // checkedListBoxSkillRelation
            // 
            this.checkedListBoxSkillRelation.CheckOnClick = true;
            this.checkedListBoxSkillRelation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxSkillRelation.FormattingEnabled = true;
            this.checkedListBoxSkillRelation.Location = new System.Drawing.Point(384, 33);
            this.checkedListBoxSkillRelation.Name = "checkedListBoxSkillRelation";
            this.checkedListBoxSkillRelation.Size = new System.Drawing.Size(375, 443);
            this.checkedListBoxSkillRelation.TabIndex = 1;
            this.checkedListBoxSkillRelation.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxSkillRelation_ItemCheck);
            // 
            // tabSkillRequirements
            // 
            this.tabSkillRequirements.Controls.Add(this.tableLayoutPanelSkillRequirement);
            this.tabSkillRequirements.Location = new System.Drawing.Point(4, 22);
            this.tabSkillRequirements.Name = "tabSkillRequirements";
            this.tabSkillRequirements.Padding = new System.Windows.Forms.Padding(3);
            this.tabSkillRequirements.Size = new System.Drawing.Size(762, 479);
            this.tabSkillRequirements.TabIndex = 3;
            this.tabSkillRequirements.Text = "Skill Requirements";
            this.tabSkillRequirements.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelSkillRequirement
            // 
            this.tableLayoutPanelSkillRequirement.ColumnCount = 1;
            this.tableLayoutPanelSkillRequirement.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSkillRequirement.Controls.Add(this.dataGridViewSkillRequirement, 0, 1);
            this.tableLayoutPanelSkillRequirement.Controls.Add(this.buttonSaveSkillRequirement, 0, 0);
            this.tableLayoutPanelSkillRequirement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelSkillRequirement.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelSkillRequirement.Name = "tableLayoutPanelSkillRequirement";
            this.tableLayoutPanelSkillRequirement.RowCount = 2;
            this.tableLayoutPanelSkillRequirement.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelSkillRequirement.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSkillRequirement.Size = new System.Drawing.Size(756, 473);
            this.tableLayoutPanelSkillRequirement.TabIndex = 0;
            // 
            // dataGridViewSkillRequirement
            // 
            this.dataGridViewSkillRequirement.AllowUserToAddRows = false;
            this.dataGridViewSkillRequirement.AllowUserToDeleteRows = false;
            this.dataGridViewSkillRequirement.AllowUserToResizeRows = false;
            this.dataGridViewSkillRequirement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSkillRequirement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SkillRequirementsTableSkillName,
            this.SkillRequirementsTableRequiredAmount});
            this.dataGridViewSkillRequirement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSkillRequirement.Location = new System.Drawing.Point(3, 33);
            this.dataGridViewSkillRequirement.Name = "dataGridViewSkillRequirement";
            this.dataGridViewSkillRequirement.RowHeadersVisible = false;
            this.dataGridViewSkillRequirement.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewSkillRequirement.Size = new System.Drawing.Size(750, 437);
            this.dataGridViewSkillRequirement.TabIndex = 0;
            // 
            // SkillRequirementsTableSkillName
            // 
            this.SkillRequirementsTableSkillName.HeaderText = "Skill Name";
            this.SkillRequirementsTableSkillName.Name = "SkillRequirementsTableSkillName";
            this.SkillRequirementsTableSkillName.ReadOnly = true;
            this.SkillRequirementsTableSkillName.Width = 630;
            // 
            // SkillRequirementsTableRequiredAmount
            // 
            this.SkillRequirementsTableRequiredAmount.HeaderText = "Times Required to Show Proficiency";
            this.SkillRequirementsTableRequiredAmount.Name = "SkillRequirementsTableRequiredAmount";
            // 
            // buttonSaveSkillRequirement
            // 
            this.buttonSaveSkillRequirement.Location = new System.Drawing.Point(3, 3);
            this.buttonSaveSkillRequirement.Name = "buttonSaveSkillRequirement";
            this.buttonSaveSkillRequirement.Size = new System.Drawing.Size(138, 23);
            this.buttonSaveSkillRequirement.TabIndex = 1;
            this.buttonSaveSkillRequirement.Text = "Save Skill Requirements";
            this.buttonSaveSkillRequirement.UseVisualStyleBackColor = true;
            this.buttonSaveSkillRequirement.Click += new System.EventHandler(this.buttonSaveSkillRequirement_Click);
            // 
            // tabGroup
            // 
            this.tabGroup.Controls.Add(this.tableLayoutPanelPagGroup);
            this.tabGroup.Location = new System.Drawing.Point(4, 22);
            this.tabGroup.Name = "tabGroup";
            this.tabGroup.Padding = new System.Windows.Forms.Padding(3);
            this.tabGroup.Size = new System.Drawing.Size(762, 479);
            this.tabGroup.TabIndex = 5;
            this.tabGroup.Text = "PAG Groups";
            this.tabGroup.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelPagGroup
            // 
            this.tableLayoutPanelPagGroup.ColumnCount = 2;
            this.tableLayoutPanelPagGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelPagGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelPagGroup.Controls.Add(this.pagGroupToolStrip, 0, 0);
            this.tableLayoutPanelPagGroup.Controls.Add(this.listBoxGroupList, 0, 1);
            this.tableLayoutPanelPagGroup.Controls.Add(this.checkedListBoxPagList, 1, 1);
            this.tableLayoutPanelPagGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelPagGroup.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelPagGroup.Name = "tableLayoutPanelPagGroup";
            this.tableLayoutPanelPagGroup.RowCount = 2;
            this.tableLayoutPanelPagGroup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanelPagGroup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPagGroup.Size = new System.Drawing.Size(756, 473);
            this.tableLayoutPanelPagGroup.TabIndex = 1;
            // 
            // pagGroupToolStrip
            // 
            this.pagGroupToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pagGroupToolStripLabel,
            this.pagGroupToolStripTextBox,
            this.pagGroupToolStripSeperator,
            this.pagGroupToolStripButtonAdd,
            this.pagGroupToolStripRemove,
            this.pagGroupToolStripSave});
            this.pagGroupToolStrip.Location = new System.Drawing.Point(0, 0);
            this.pagGroupToolStrip.Name = "pagGroupToolStrip";
            this.pagGroupToolStrip.Size = new System.Drawing.Size(378, 25);
            this.pagGroupToolStrip.TabIndex = 0;
            this.pagGroupToolStrip.Text = "PAG list tool strip";
            // 
            // pagGroupToolStripLabel
            // 
            this.pagGroupToolStripLabel.Name = "pagGroupToolStripLabel";
            this.pagGroupToolStripLabel.Size = new System.Drawing.Size(48, 22);
            this.pagGroupToolStripLabel.Text = "Groups:";
            // 
            // pagGroupToolStripTextBox
            // 
            this.pagGroupToolStripTextBox.Name = "pagGroupToolStripTextBox";
            this.pagGroupToolStripTextBox.Size = new System.Drawing.Size(226, 25);
            this.pagGroupToolStripTextBox.TextChanged += new System.EventHandler(this.pagGroupToolStripTextBox_TextChanged);
            // 
            // pagGroupToolStripSeperator
            // 
            this.pagGroupToolStripSeperator.Name = "pagGroupToolStripSeperator";
            this.pagGroupToolStripSeperator.Size = new System.Drawing.Size(6, 25);
            // 
            // pagGroupToolStripButtonAdd
            // 
            this.pagGroupToolStripButtonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pagGroupToolStripButtonAdd.Image = ((System.Drawing.Image)(resources.GetObject("pagGroupToolStripButtonAdd.Image")));
            this.pagGroupToolStripButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pagGroupToolStripButtonAdd.Name = "pagGroupToolStripButtonAdd";
            this.pagGroupToolStripButtonAdd.Size = new System.Drawing.Size(23, 22);
            this.pagGroupToolStripButtonAdd.Text = "Add Record";
            this.pagGroupToolStripButtonAdd.Click += new System.EventHandler(this.pagGroupToolStripButtonAdd_Click);
            // 
            // pagGroupToolStripRemove
            // 
            this.pagGroupToolStripRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pagGroupToolStripRemove.Image = ((System.Drawing.Image)(resources.GetObject("pagGroupToolStripRemove.Image")));
            this.pagGroupToolStripRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pagGroupToolStripRemove.Name = "pagGroupToolStripRemove";
            this.pagGroupToolStripRemove.Size = new System.Drawing.Size(23, 22);
            this.pagGroupToolStripRemove.Text = "Remove Record";
            this.pagGroupToolStripRemove.Click += new System.EventHandler(this.pagGroupToolStripRemove_Click);
            // 
            // pagGroupToolStripSave
            // 
            this.pagGroupToolStripSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pagGroupToolStripSave.Image = ((System.Drawing.Image)(resources.GetObject("pagGroupToolStripSave.Image")));
            this.pagGroupToolStripSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pagGroupToolStripSave.Name = "pagGroupToolStripSave";
            this.pagGroupToolStripSave.Size = new System.Drawing.Size(23, 22);
            this.pagGroupToolStripSave.Text = "Save Data";
            this.pagGroupToolStripSave.Click += new System.EventHandler(this.pagGroupToolStripSave_Click);
            // 
            // listBoxGroupList
            // 
            this.listBoxGroupList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxGroupList.FormattingEnabled = true;
            this.listBoxGroupList.Location = new System.Drawing.Point(3, 28);
            this.listBoxGroupList.Name = "listBoxGroupList";
            this.listBoxGroupList.Size = new System.Drawing.Size(372, 442);
            this.listBoxGroupList.TabIndex = 1;
            this.listBoxGroupList.SelectedIndexChanged += new System.EventHandler(this.listBoxGroupList_SelectedIndexChanged);
            // 
            // checkedListBoxPagList
            // 
            this.checkedListBoxPagList.CheckOnClick = true;
            this.checkedListBoxPagList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxPagList.FormattingEnabled = true;
            this.checkedListBoxPagList.Location = new System.Drawing.Point(381, 28);
            this.checkedListBoxPagList.Name = "checkedListBoxPagList";
            this.checkedListBoxPagList.Size = new System.Drawing.Size(372, 442);
            this.checkedListBoxPagList.TabIndex = 2;
            this.checkedListBoxPagList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxPagList_ItemCheck);
            // 
            // tabStudentImport
            // 
            this.tabStudentImport.Controls.Add(this.tableLayoutPanelImportStudents);
            this.tabStudentImport.Location = new System.Drawing.Point(4, 22);
            this.tabStudentImport.Name = "tabStudentImport";
            this.tabStudentImport.Padding = new System.Windows.Forms.Padding(3);
            this.tabStudentImport.Size = new System.Drawing.Size(762, 479);
            this.tabStudentImport.TabIndex = 4;
            this.tabStudentImport.Text = "Import Students";
            this.tabStudentImport.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelImportStudents
            // 
            this.tableLayoutPanelImportStudents.ColumnCount = 1;
            this.tableLayoutPanelImportStudents.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelImportStudents.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanelImportStudents.Controls.Add(this.dataGridViewStudentImport, 0, 1);
            this.tableLayoutPanelImportStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelImportStudents.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelImportStudents.Name = "tableLayoutPanelImportStudents";
            this.tableLayoutPanelImportStudents.RowCount = 2;
            this.tableLayoutPanelImportStudents.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelImportStudents.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelImportStudents.Size = new System.Drawing.Size(756, 473);
            this.tableLayoutPanelImportStudents.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonImportCSV);
            this.flowLayoutPanel1.Controls.Add(this.buttonAddStudentRecord);
            this.flowLayoutPanel1.Controls.Add(this.labelImportStudents);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(750, 24);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // buttonImportCSV
            // 
            this.buttonImportCSV.Location = new System.Drawing.Point(3, 3);
            this.buttonImportCSV.Name = "buttonImportCSV";
            this.buttonImportCSV.Size = new System.Drawing.Size(75, 21);
            this.buttonImportCSV.TabIndex = 1;
            this.buttonImportCSV.Text = "Import CSV";
            this.buttonImportCSV.UseVisualStyleBackColor = true;
            this.buttonImportCSV.Click += new System.EventHandler(this.buttonImportCSV_Click);
            // 
            // buttonAddStudentRecord
            // 
            this.buttonAddStudentRecord.Enabled = false;
            this.buttonAddStudentRecord.Location = new System.Drawing.Point(84, 3);
            this.buttonAddStudentRecord.Name = "buttonAddStudentRecord";
            this.buttonAddStudentRecord.Size = new System.Drawing.Size(113, 21);
            this.buttonAddStudentRecord.TabIndex = 2;
            this.buttonAddStudentRecord.Text = "Add Records to list";
            this.buttonAddStudentRecord.UseVisualStyleBackColor = true;
            this.buttonAddStudentRecord.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // labelImportStudents
            // 
            this.labelImportStudents.AutoSize = true;
            this.labelImportStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelImportStudents.Location = new System.Drawing.Point(203, 0);
            this.labelImportStudents.Name = "labelImportStudents";
            this.labelImportStudents.Size = new System.Drawing.Size(442, 27);
            this.labelImportStudents.TabIndex = 3;
            this.labelImportStudents.Text = "Columns must be in order (First Name, Last Name, Year, Class). Extra columns will" +
    " be ignored";
            this.labelImportStudents.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewStudentImport
            // 
            this.dataGridViewStudentImport.AllowUserToOrderColumns = true;
            this.dataGridViewStudentImport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStudentImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewStudentImport.Location = new System.Drawing.Point(3, 33);
            this.dataGridViewStudentImport.Name = "dataGridViewStudentImport";
            this.dataGridViewStudentImport.Size = new System.Drawing.Size(750, 437);
            this.dataGridViewStudentImport.TabIndex = 0;
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.adminToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(784, 24);
            this.menuStripMain.TabIndex = 1;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hidePagViewColumnsWithoutPAGDataToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // hidePagViewColumnsWithoutPAGDataToolStripMenuItem
            // 
            this.hidePagViewColumnsWithoutPAGDataToolStripMenuItem.CheckOnClick = true;
            this.hidePagViewColumnsWithoutPAGDataToolStripMenuItem.Name = "hidePagViewColumnsWithoutPAGDataToolStripMenuItem";
            this.hidePagViewColumnsWithoutPAGDataToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.hidePagViewColumnsWithoutPAGDataToolStripMenuItem.Text = "Hide Pag View Columns without PAG data";
            this.hidePagViewColumnsWithoutPAGDataToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.hidePagViewColumnsWithoutPAGDataToolStripMenuItem_CheckStateChanged);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startMaximisedToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // startMaximisedToolStripMenuItem
            // 
            this.startMaximisedToolStripMenuItem.CheckOnClick = true;
            this.startMaximisedToolStripMenuItem.Name = "startMaximisedToolStripMenuItem";
            this.startMaximisedToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.startMaximisedToolStripMenuItem.Text = "Start Maximised";
            this.startMaximisedToolStripMenuItem.Click += new System.EventHandler(this.startMaximisedToolStripMenuItem_Click);
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.adminToolStripMenuItem.Text = "Enable Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openManualToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // openManualToolStripMenuItem
            // 
            this.openManualToolStripMenuItem.Name = "openManualToolStripMenuItem";
            this.openManualToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.openManualToolStripMenuItem.Text = "Open Manual";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // openFileDialogImportCSV
            // 
            this.openFileDialogImportCSV.Filter = "CSV files (*.csv)|*.csv";
            this.openFileDialogImportCSV.ShowHelp = true;
            this.openFileDialogImportCSV.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogImportCSV_FileOk);
            this.openFileDialogImportCSV.HelpRequest += new System.EventHandler(this.openFileDialogImportCSV_HelpRequest);
            // 
            // StudentReportID
            // 
            this.StudentReportID.Frozen = true;
            this.StudentReportID.HeaderText = "ID";
            this.StudentReportID.Name = "StudentReportID";
            this.StudentReportID.ReadOnly = true;
            // 
            // StudentReportFName
            // 
            this.StudentReportFName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.StudentReportFName.Frozen = true;
            this.StudentReportFName.HeaderText = "First Name";
            this.StudentReportFName.Name = "StudentReportFName";
            this.StudentReportFName.ReadOnly = true;
            this.StudentReportFName.Width = 82;
            // 
            // StudentReportSName
            // 
            this.StudentReportSName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.StudentReportSName.Frozen = true;
            this.StudentReportSName.HeaderText = "Last Name";
            this.StudentReportSName.Name = "StudentReportSName";
            this.StudentReportSName.ReadOnly = true;
            this.StudentReportSName.Width = 83;
            // 
            // StudentReportYear
            // 
            this.StudentReportYear.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.StudentReportYear.Frozen = true;
            this.StudentReportYear.HeaderText = "Year";
            this.StudentReportYear.Name = "StudentReportYear";
            this.StudentReportYear.ReadOnly = true;
            this.StudentReportYear.Width = 54;
            // 
            // StudentReportClass
            // 
            this.StudentReportClass.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.StudentReportClass.Frozen = true;
            this.StudentReportClass.HeaderText = "Class";
            this.StudentReportClass.Name = "StudentReportClass";
            this.StudentReportClass.ReadOnly = true;
            this.StudentReportClass.Width = 57;
            // 
            // StudentReportCondition
            // 
            this.StudentReportCondition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.StudentReportCondition.DefaultCellStyle = dataGridViewCellStyle2;
            this.StudentReportCondition.HeaderText = "Condition";
            this.StudentReportCondition.Name = "StudentReportCondition";
            this.StudentReportCondition.ReadOnly = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.menuStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormMain";
            this.Text = "PAG Manager";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabActivitySelection.ResumeLayout(false);
            this.tableLayoutPanelActivitySelection.ResumeLayout(false);
            this.tableLayoutPanelActivitySelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActivitySelectionSkills)).EndInit();
            this.tableLayoutPanelActivitySelectionToolbar.ResumeLayout(false);
            this.tableLayoutPanelActivitySelectionToolbar.PerformLayout();
            this.tabContentSelection.ResumeLayout(false);
            this.tableLayoutPanelContentSelection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContentSelectionPag)).EndInit();
            this.tableLayoutContentSelectionSkill.ResumeLayout(false);
            this.tableLayoutContentSelectionSkill.PerformLayout();
            this.tableLayoutPanelContentSelectionActivitySelection.ResumeLayout(false);
            this.tableLayoutPanelContentSelectionActivitySelection.PerformLayout();
            this.tabSkills.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSkills)).EndInit();
            this.tabPagDates.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPag)).EndInit();
            this.tabLookup.ResumeLayout(false);
            this.tableLayoutPanelLookup.ResumeLayout(false);
            this.groupBoxLookupSearch.ResumeLayout(false);
            this.groupBoxLookupSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudentLookup)).EndInit();
            this.tabAwardPag.ResumeLayout(false);
            this.tableLayoutPanelAwardPag.ResumeLayout(false);
            this.groupBoxAwardPag.ResumeLayout(false);
            this.groupBoxAwardPag.PerformLayout();
            this.tabReport.ResumeLayout(false);
            this.tableLayoutPanelStudentReport.ResumeLayout(false);
            this.tableLayoutPanelStudentReport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudentReport)).EndInit();
            this.tabAdmin.ResumeLayout(false);
            this.tabControlAdmin.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.tabSkillPagList.ResumeLayout(false);
            this.tableLayoutPanelPagSkillList.ResumeLayout(false);
            this.tableLayoutPanelPagSkillList.PerformLayout();
            this.toolStripSkillList.ResumeLayout(false);
            this.toolStripSkillList.PerformLayout();
            this.toolStripPagList.ResumeLayout(false);
            this.toolStripPagList.PerformLayout();
            this.tabPagSkillRelation.ResumeLayout(false);
            this.tableLayoutPanelPagSkillRelation.ResumeLayout(false);
            this.tabSkillRequirements.ResumeLayout(false);
            this.tableLayoutPanelSkillRequirement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSkillRequirement)).EndInit();
            this.tabGroup.ResumeLayout(false);
            this.tableLayoutPanelPagGroup.ResumeLayout(false);
            this.tableLayoutPanelPagGroup.PerformLayout();
            this.pagGroupToolStrip.ResumeLayout(false);
            this.pagGroupToolStrip.PerformLayout();
            this.tabStudentImport.ResumeLayout(false);
            this.tableLayoutPanelImportStudents.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudentImport)).EndInit();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabSkills;
        private System.Windows.Forms.TabPage tabAdmin;
        private System.Windows.Forms.RadioButton radioButtonAdmin;
        public System.Windows.Forms.DataGridView dataGridViewSkills;
        private System.Windows.Forms.Button buttonGetDirectory;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage tabPagDates;
        public System.Windows.Forms.DataGridView dataGridViewPag;
        private System.Windows.Forms.TabPage tabLookup;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLookup;
        private System.Windows.Forms.GroupBox groupBoxLookupSearch;
        private System.Windows.Forms.CheckBox checkBoxArchives;
        private System.Windows.Forms.TextBox textBoxLookupName;
        private System.Windows.Forms.Label labelLookupName;
        private System.Windows.Forms.ListBox listBoxStudentNames;
        private System.Windows.Forms.TabControl tabControlAdmin;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabSkillPagList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPagSkillList;
        private System.Windows.Forms.TabPage tabPagSkillRelation;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStripPagList;
        private System.Windows.Forms.ToolStripTextBox pagListToolStripTextBox;
        private System.Windows.Forms.ToolStripButton pagListToolStripButtonAddRecord;
        private System.Windows.Forms.ToolStripButton pagListToolStripButtonRemovePag;
        private System.Windows.Forms.ToolStripSeparator pagListToolStripSeparator;
        private System.Windows.Forms.ToolStripLabel pagListToolStripLabel;
        private System.Windows.Forms.ListBox listBoxPagList;
        private System.Windows.Forms.ToolStrip toolStripSkillList;
        private System.Windows.Forms.ToolStripLabel skillListToolStripLabel;
        private System.Windows.Forms.ToolStripTextBox skillListToolStripTextBox;
        private System.Windows.Forms.ToolStripSeparator skillListToolStripSeparator;
        private System.Windows.Forms.ToolStripButton skillListToolStripButtonAddRecord;
        private System.Windows.Forms.ToolStripButton skillListToolStripButtonRemovePag;
        private System.Windows.Forms.ListBox listBoxSkillList;
        private System.Windows.Forms.Button buttonLoadDefaults;
        private System.Windows.Forms.ToolStripButton pagListToolStripButtonSave;
        private System.Windows.Forms.ToolStripButton skillListToolStripButtonSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPagSkillRelation;
        private System.Windows.Forms.ListBox listBoxPagRelation;
        private System.Windows.Forms.CheckedListBox checkedListBoxSkillRelation;
        private System.Windows.Forms.Button buttonBuildPagSkillRelation;
        private System.Windows.Forms.TabPage tabActivitySelection;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelActivitySelection;
        private System.Windows.Forms.DataGridView dataGridViewActivitySelectionSkills;
        private System.Windows.Forms.DataGridViewTextBoxColumn SkillName;
        private System.Windows.Forms.Label labelActivitySelectionSkill;
        private System.Windows.Forms.CheckedListBox checkedListBoxActivitySelectionPag;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelActivitySelectionToolbar;
        private System.Windows.Forms.Label labelActivitySelectionPag;
        private System.Windows.Forms.Button buttonActivitySelectResetSelection;
        private System.Windows.Forms.TabPage tabContentSelection;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelContentSelection;
        private System.Windows.Forms.DataGridView dataGridViewContentSelectionPag;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.CheckedListBox checkedListBoxContentSelectionSkill;
        private System.Windows.Forms.TableLayoutPanel tableLayoutContentSelectionSkill;
        private System.Windows.Forms.Label labelContentSelectionSkill;
        private System.Windows.Forms.Button buttonContentSelectionSelectionReset;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openManualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelContentSelectionActivitySelection;
        private System.Windows.Forms.Label labelContentSelectionPag;
        private System.Windows.Forms.ListBox listBoxContentSelectionInclusion;
        private System.Windows.Forms.TabPage tabAwardPag;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelAwardPag;
        private System.Windows.Forms.TreeView treeViewYearSelect;
        private System.Windows.Forms.TreeView treeViewPagSelect;
        private System.Windows.Forms.GroupBox groupBoxAwardPag;
        private System.Windows.Forms.Label labelPagAwardSettingsSelectDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerAwardPag;
        private System.Windows.Forms.Button buttonAwardPag;
        private System.Windows.Forms.Label labelAwardPagSelectedFailedSkills;
        private System.Windows.Forms.Label labelAwardPagSelectedPag;
        private System.Windows.Forms.Label labelAwardPagSelectedStudents;
        private System.Windows.Forms.Button buttonAwardPagClearSelection;
        private System.Windows.Forms.TabPage tabSkillRequirements;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSkillRequirement;
        private System.Windows.Forms.DataGridView dataGridViewSkillRequirement;
        private System.Windows.Forms.DataGridViewTextBoxColumn SkillRequirementsTableSkillName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SkillRequirementsTableRequiredAmount;
        private System.Windows.Forms.Button buttonSaveSkillRequirement;
        private System.Windows.Forms.TabPage tabStudentImport;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelImportStudents;
        private System.Windows.Forms.DataGridView dataGridViewStudentImport;
        private System.Windows.Forms.Button buttonImportCSV;
        private System.Windows.Forms.OpenFileDialog openFileDialogImportCSV;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonAddStudentRecord;
        private System.Windows.Forms.Label labelImportStudents;
        private System.Windows.Forms.Label labelAwardPagSelectedAbsent;
        private System.Windows.Forms.ToolStripMenuItem hidePagViewColumnsWithoutPAGDataToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxShowStudentID;
        private System.Windows.Forms.DataGridView dataGridViewStudentLookup;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startMaximisedToolStripMenuItem;
        private System.Windows.Forms.Button buttonLookupSubmitModifications;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentFName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentLName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.TabPage tabReport;
        private System.Windows.Forms.TabPage tabGroup;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPagGroup;
        private System.Windows.Forms.ToolStrip pagGroupToolStrip;
        private System.Windows.Forms.ToolStripLabel pagGroupToolStripLabel;
        private System.Windows.Forms.ToolStripTextBox pagGroupToolStripTextBox;
        private System.Windows.Forms.ToolStripSeparator pagGroupToolStripSeperator;
        private System.Windows.Forms.ToolStripButton pagGroupToolStripButtonAdd;
        private System.Windows.Forms.ToolStripButton pagGroupToolStripRemove;
        private System.Windows.Forms.ToolStripButton pagGroupToolStripSave;
        private System.Windows.Forms.ListBox listBoxGroupList;
        private System.Windows.Forms.CheckedListBox checkedListBoxPagList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelStudentReport;
        private System.Windows.Forms.Button buttonGenerateReport;
        private System.Windows.Forms.ProgressBar progressBarStudentReport;
        private System.Windows.Forms.DataGridView dataGridViewStudentReport;
        private System.Windows.Forms.Label labelReportSettings;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentReportID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentReportFName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentReportSName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentReportYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentReportClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentReportCondition;
    }
}

