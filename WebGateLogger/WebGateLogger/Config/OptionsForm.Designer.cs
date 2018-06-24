namespace WebGateLogger
{
    partial class OptionsForm
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
          this.components = new System.ComponentModel.Container();
          System.Windows.Forms.GroupBox groupBox1;
          System.Windows.Forms.Label label4;
          System.Windows.Forms.Label label3;
          System.Windows.Forms.Label label1;
          System.Windows.Forms.GroupBox groupBox5;
          System.Windows.Forms.Label label5;
          System.Windows.Forms.Label label6;
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
          System.Windows.Forms.Label label8;
          this.m_chkLoadFollowingSessionFiles = new System.Windows.Forms.CheckBox();
          this.m_chkAddToContextMenuOfExplorer = new System.Windows.Forms.CheckBox();
          this.m_nmrOldFilesThreshold = new System.Windows.Forms.NumericUpDown();
          this.m_chkRemoveOldFiles = new System.Windows.Forms.CheckBox();
          this.m_chkStayOnRowOnRefresh = new System.Windows.Forms.CheckBox();
          this.m_chkLoadOnStart = new System.Windows.Forms.CheckBox();
          this.m_chkScrollToBottomOnLoad = new System.Windows.Forms.CheckBox();
          this.m_cmbShortcutFolders = new System.Windows.Forms.ComboBox();
          this.m_btnShortcut = new System.Windows.Forms.Button();
          this.m_buttonPanel = new System.Windows.Forms.Panel();
          this.m_btnRestoreDefault = new System.Windows.Forms.Button();
          this.m_btnOk = new System.Windows.Forms.Button();
          this.m_btnApply = new System.Windows.Forms.Button();
          this.m_btnCancel = new System.Windows.Forms.Button();
          this.m_tabAbout = new System.Windows.Forms.TabPage();
          this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
          this.pictureBox1 = new System.Windows.Forms.PictureBox();
          this.m_lblProductName = new System.Windows.Forms.Label();
          this.m_lblVersion = new System.Windows.Forms.Label();
          this.m_lblCopyright = new System.Windows.Forms.Label();
          this.m_lblCompanyName = new System.Windows.Forms.Label();
          this.m_txtProductDescription = new System.Windows.Forms.TextBox();
          this.m_tabColumns = new System.Windows.Forms.TabPage();
          this.m_columnsControl = new LogComponents.Controls.ColumnsUserControl();
          this.m_tabColors = new System.Windows.Forms.TabPage();
          this.m_propColors = new LogComponents.Controls.CustomPropertyGrid();
          this.m_tabOptions = new System.Windows.Forms.TabPage();
          this.m_logConfigurationView = new WebGateLogger.Config.LogConfigurationView();
          this.m_tabControl = new System.Windows.Forms.TabControl();
          this.m_tabAdvanced = new System.Windows.Forms.TabPage();
          this.groupBox3 = new System.Windows.Forms.GroupBox();
          this.m_nmrDontIndentateResponceLargeThan = new System.Windows.Forms.NumericUpDown();
          this.m_gridExcludedFrecs = new System.Windows.Forms.DataGridView();
          this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
          this.label7 = new System.Windows.Forms.Label();
          this.m_nmrMaximalResponseLength = new System.Windows.Forms.NumericUpDown();
          this.m_chkLazyParsing = new System.Windows.Forms.CheckBox();
          this.groupBox2 = new System.Windows.Forms.GroupBox();
          this.m_btnOpenRepository = new System.Windows.Forms.Button();
          this.m_txtRepository = new System.Windows.Forms.TextBox();
          this.label2 = new System.Windows.Forms.Label();
          this.panelBorderPainter1 = new WebGateLogger.UserControls.PanelBorderPainter(this.components);
          groupBox1 = new System.Windows.Forms.GroupBox();
          label4 = new System.Windows.Forms.Label();
          label3 = new System.Windows.Forms.Label();
          label1 = new System.Windows.Forms.Label();
          groupBox5 = new System.Windows.Forms.GroupBox();
          label5 = new System.Windows.Forms.Label();
          label6 = new System.Windows.Forms.Label();
          label8 = new System.Windows.Forms.Label();
          groupBox1.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.m_nmrOldFilesThreshold)).BeginInit();
          groupBox5.SuspendLayout();
          this.m_buttonPanel.SuspendLayout();
          this.m_tabAbout.SuspendLayout();
          this.tableLayoutPanel.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
          this.m_tabColumns.SuspendLayout();
          this.m_tabColors.SuspendLayout();
          this.m_tabOptions.SuspendLayout();
          this.m_tabControl.SuspendLayout();
          this.m_tabAdvanced.SuspendLayout();
          this.groupBox3.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.m_nmrDontIndentateResponceLargeThan)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.m_gridExcludedFrecs)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.m_nmrMaximalResponseLength)).BeginInit();
          this.groupBox2.SuspendLayout();
          this.SuspendLayout();
          // 
          // groupBox1
          // 
          groupBox1.Controls.Add(this.m_chkLoadFollowingSessionFiles);
          groupBox1.Controls.Add(this.m_chkAddToContextMenuOfExplorer);
          groupBox1.Controls.Add(label4);
          groupBox1.Controls.Add(this.m_nmrOldFilesThreshold);
          groupBox1.Controls.Add(this.m_chkRemoveOldFiles);
          groupBox1.Controls.Add(this.m_chkStayOnRowOnRefresh);
          groupBox1.Controls.Add(this.m_chkLoadOnStart);
          groupBox1.Controls.Add(this.m_chkScrollToBottomOnLoad);
          groupBox1.Location = new System.Drawing.Point(9, 3);
          groupBox1.Name = "groupBox1";
          groupBox1.Size = new System.Drawing.Size(382, 155);
          groupBox1.TabIndex = 39;
          groupBox1.TabStop = false;
          groupBox1.Text = "General";
          // 
          // m_chkLoadFollowingSessionFiles
          // 
          this.m_chkLoadFollowingSessionFiles.AutoSize = true;
          this.m_chkLoadFollowingSessionFiles.Location = new System.Drawing.Point(16, 129);
          this.m_chkLoadFollowingSessionFiles.Name = "m_chkLoadFollowingSessionFiles";
          this.m_chkLoadFollowingSessionFiles.Size = new System.Drawing.Size(156, 17);
          this.m_chkLoadFollowingSessionFiles.TabIndex = 43;
          this.m_chkLoadFollowingSessionFiles.Text = "Load following session files ";
          this.m_chkLoadFollowingSessionFiles.UseVisualStyleBackColor = true;
          this.m_chkLoadFollowingSessionFiles.CheckedChanged += new System.EventHandler(this.OnModify);
          // 
          // m_chkAddToContextMenuOfExplorer
          // 
          this.m_chkAddToContextMenuOfExplorer.AutoSize = true;
          this.m_chkAddToContextMenuOfExplorer.Location = new System.Drawing.Point(16, 107);
          this.m_chkAddToContextMenuOfExplorer.Name = "m_chkAddToContextMenuOfExplorer";
          this.m_chkAddToContextMenuOfExplorer.Size = new System.Drawing.Size(289, 17);
          this.m_chkAddToContextMenuOfExplorer.TabIndex = 42;
          this.m_chkAddToContextMenuOfExplorer.Text = "Add to context menu of windows explorer (Open with ...)";
          this.m_chkAddToContextMenuOfExplorer.UseVisualStyleBackColor = true;
          this.m_chkAddToContextMenuOfExplorer.CheckedChanged += new System.EventHandler(this.OnModify);
          // 
          // label4
          // 
          label4.AutoSize = true;
          label4.Location = new System.Drawing.Point(252, 89);
          label4.Name = "label4";
          label4.Size = new System.Drawing.Size(29, 13);
          label4.TabIndex = 41;
          label4.Text = "days";
          // 
          // m_nmrOldFilesThreshold
          // 
          this.m_nmrOldFilesThreshold.Location = new System.Drawing.Point(179, 84);
          this.m_nmrOldFilesThreshold.Maximum = new decimal(new int[] {
            356,
            0,
            0,
            0});
          this.m_nmrOldFilesThreshold.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
          this.m_nmrOldFilesThreshold.Name = "m_nmrOldFilesThreshold";
          this.m_nmrOldFilesThreshold.Size = new System.Drawing.Size(62, 20);
          this.m_nmrOldFilesThreshold.TabIndex = 40;
          this.m_nmrOldFilesThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
          this.m_nmrOldFilesThreshold.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
          this.m_nmrOldFilesThreshold.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
          this.m_nmrOldFilesThreshold.ValueChanged += new System.EventHandler(this.OnModify);
          // 
          // m_chkRemoveOldFiles
          // 
          this.m_chkRemoveOldFiles.AutoSize = true;
          this.m_chkRemoveOldFiles.Location = new System.Drawing.Point(16, 85);
          this.m_chkRemoveOldFiles.Name = "m_chkRemoveOldFiles";
          this.m_chkRemoveOldFiles.Size = new System.Drawing.Size(157, 17);
          this.m_chkRemoveOldFiles.TabIndex = 39;
          this.m_chkRemoveOldFiles.Text = "Remove log files older than ";
          this.m_chkRemoveOldFiles.UseVisualStyleBackColor = true;
          this.m_chkRemoveOldFiles.CheckedChanged += new System.EventHandler(this.OnModify);
          // 
          // m_chkStayOnRowOnRefresh
          // 
          this.m_chkStayOnRowOnRefresh.AutoSize = true;
          this.m_chkStayOnRowOnRefresh.Location = new System.Drawing.Point(16, 63);
          this.m_chkStayOnRowOnRefresh.Name = "m_chkStayOnRowOnRefresh";
          this.m_chkStayOnRowOnRefresh.Size = new System.Drawing.Size(178, 17);
          this.m_chkStayOnRowOnRefresh.TabIndex = 34;
          this.m_chkStayOnRowOnRefresh.Text = "Stay on the same row on refresh";
          this.m_chkStayOnRowOnRefresh.UseVisualStyleBackColor = true;
          this.m_chkStayOnRowOnRefresh.CheckedChanged += new System.EventHandler(this.OnModify);
          // 
          // m_chkLoadOnStart
          // 
          this.m_chkLoadOnStart.AutoSize = true;
          this.m_chkLoadOnStart.Location = new System.Drawing.Point(16, 19);
          this.m_chkLoadOnStart.Name = "m_chkLoadOnStart";
          this.m_chkLoadOnStart.Size = new System.Drawing.Size(163, 17);
          this.m_chkLoadOnStart.TabIndex = 31;
          this.m_chkLoadOnStart.Text = "Load last created log on start";
          this.m_chkLoadOnStart.UseVisualStyleBackColor = true;
          this.m_chkLoadOnStart.CheckedChanged += new System.EventHandler(this.OnModify);
          // 
          // m_chkScrollToBottomOnLoad
          // 
          this.m_chkScrollToBottomOnLoad.AutoSize = true;
          this.m_chkScrollToBottomOnLoad.Location = new System.Drawing.Point(16, 41);
          this.m_chkScrollToBottomOnLoad.Name = "m_chkScrollToBottomOnLoad";
          this.m_chkScrollToBottomOnLoad.Size = new System.Drawing.Size(137, 17);
          this.m_chkScrollToBottomOnLoad.TabIndex = 32;
          this.m_chkScrollToBottomOnLoad.Text = "Scroll to bottom on load";
          this.m_chkScrollToBottomOnLoad.UseVisualStyleBackColor = true;
          this.m_chkScrollToBottomOnLoad.CheckedChanged += new System.EventHandler(this.OnModify);
          // 
          // label3
          // 
          label3.AutoSize = true;
          label3.Location = new System.Drawing.Point(213, 47);
          label3.Name = "label3";
          label3.Size = new System.Drawing.Size(90, 13);
          label3.TabIndex = 48;
          label3.Text = "chars in response";
          // 
          // label1
          // 
          label1.AutoSize = true;
          label1.Location = new System.Drawing.Point(10, 47);
          label1.Name = "label1";
          label1.Size = new System.Drawing.Size(71, 13);
          label1.TabIndex = 46;
          label1.Text = "Parse at most";
          // 
          // groupBox5
          // 
          groupBox5.Controls.Add(this.m_cmbShortcutFolders);
          groupBox5.Controls.Add(this.m_btnShortcut);
          groupBox5.Location = new System.Drawing.Point(9, 288);
          groupBox5.Name = "groupBox5";
          groupBox5.Size = new System.Drawing.Size(382, 68);
          groupBox5.TabIndex = 45;
          groupBox5.TabStop = false;
          groupBox5.Text = "Shortcuts to application";
          // 
          // m_cmbShortcutFolders
          // 
          this.m_cmbShortcutFolders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.m_cmbShortcutFolders.FormattingEnabled = true;
          this.m_cmbShortcutFolders.Items.AddRange(new object[] {
            "Custom folder",
            "Desktop",
            "Quick toolbar"});
          this.m_cmbShortcutFolders.Location = new System.Drawing.Point(161, 28);
          this.m_cmbShortcutFolders.Name = "m_cmbShortcutFolders";
          this.m_cmbShortcutFolders.Size = new System.Drawing.Size(199, 21);
          this.m_cmbShortcutFolders.TabIndex = 3;
          // 
          // m_btnShortcut
          // 
          this.m_btnShortcut.Location = new System.Drawing.Point(12, 28);
          this.m_btnShortcut.Name = "m_btnShortcut";
          this.m_btnShortcut.Size = new System.Drawing.Size(128, 23);
          this.m_btnShortcut.TabIndex = 2;
          this.m_btnShortcut.Text = "Create shortcut in ";
          this.m_btnShortcut.UseVisualStyleBackColor = true;
          this.m_btnShortcut.Click += new System.EventHandler(this.OnBtnShortcutInCustomFolderClick);
          // 
          // label5
          // 
          label5.AutoSize = true;
          label5.Location = new System.Drawing.Point(213, 75);
          label5.Name = "label5";
          label5.Size = new System.Drawing.Size(0, 13);
          label5.TabIndex = 56;
          // 
          // label6
          // 
          label6.AutoSize = true;
          label6.Location = new System.Drawing.Point(10, 75);
          label6.Name = "label6";
          label6.Size = new System.Drawing.Size(179, 13);
          label6.TabIndex = 54;
          label6.Text = "Don\'t indentate responce large than ";
          // 
          // m_buttonPanel
          // 
          this.m_buttonPanel.Controls.Add(this.m_btnRestoreDefault);
          this.m_buttonPanel.Controls.Add(this.m_btnOk);
          this.m_buttonPanel.Controls.Add(this.m_btnApply);
          this.m_buttonPanel.Controls.Add(this.m_btnCancel);
          this.m_buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
          this.m_buttonPanel.Location = new System.Drawing.Point(5, 400);
          this.m_buttonPanel.Name = "m_buttonPanel";
          this.m_buttonPanel.Size = new System.Drawing.Size(414, 37);
          this.m_buttonPanel.TabIndex = 35;
          // 
          // m_btnRestoreDefault
          // 
          this.m_btnRestoreDefault.Anchor = System.Windows.Forms.AnchorStyles.None;
          this.m_btnRestoreDefault.Location = new System.Drawing.Point(16, 6);
          this.m_btnRestoreDefault.Name = "m_btnRestoreDefault";
          this.m_btnRestoreDefault.Size = new System.Drawing.Size(101, 25);
          this.m_btnRestoreDefault.TabIndex = 7;
          this.m_btnRestoreDefault.Text = "&Restore default";
          this.m_btnRestoreDefault.UseVisualStyleBackColor = true;
          this.m_btnRestoreDefault.Click += new System.EventHandler(this.OnRestoreClick);
          // 
          // m_btnOk
          // 
          this.m_btnOk.Anchor = System.Windows.Forms.AnchorStyles.None;
          this.m_btnOk.Location = new System.Drawing.Point(312, 6);
          this.m_btnOk.Name = "m_btnOk";
          this.m_btnOk.Size = new System.Drawing.Size(75, 25);
          this.m_btnOk.TabIndex = 4;
          this.m_btnOk.Text = "&Ok";
          this.m_btnOk.UseVisualStyleBackColor = true;
          this.m_btnOk.Click += new System.EventHandler(this.OnOkClick);
          // 
          // m_btnApply
          // 
          this.m_btnApply.Anchor = System.Windows.Forms.AnchorStyles.None;
          this.m_btnApply.Enabled = false;
          this.m_btnApply.Location = new System.Drawing.Point(132, 6);
          this.m_btnApply.Name = "m_btnApply";
          this.m_btnApply.Size = new System.Drawing.Size(75, 25);
          this.m_btnApply.TabIndex = 6;
          this.m_btnApply.Text = "&Apply";
          this.m_btnApply.UseVisualStyleBackColor = true;
          this.m_btnApply.Click += new System.EventHandler(this.OnApplyClick);
          // 
          // m_btnCancel
          // 
          this.m_btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
          this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          this.m_btnCancel.Location = new System.Drawing.Point(222, 6);
          this.m_btnCancel.Name = "m_btnCancel";
          this.m_btnCancel.Size = new System.Drawing.Size(75, 25);
          this.m_btnCancel.TabIndex = 5;
          this.m_btnCancel.Text = "&Cancel";
          this.m_btnCancel.UseVisualStyleBackColor = true;
          this.m_btnCancel.Click += new System.EventHandler(this.OnCancelClick);
          // 
          // m_tabAbout
          // 
          this.m_tabAbout.Controls.Add(this.tableLayoutPanel);
          this.m_tabAbout.Location = new System.Drawing.Point(4, 25);
          this.m_tabAbout.Name = "m_tabAbout";
          this.m_tabAbout.Padding = new System.Windows.Forms.Padding(3);
          this.m_tabAbout.Size = new System.Drawing.Size(406, 366);
          this.m_tabAbout.TabIndex = 2;
          this.m_tabAbout.Text = "About";
          this.m_tabAbout.UseVisualStyleBackColor = true;
          // 
          // tableLayoutPanel
          // 
          this.tableLayoutPanel.ColumnCount = 2;
          this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
          this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67F));
          this.tableLayoutPanel.Controls.Add(this.pictureBox1, 0, 0);
          this.tableLayoutPanel.Controls.Add(this.m_lblProductName, 1, 0);
          this.tableLayoutPanel.Controls.Add(this.m_lblVersion, 1, 1);
          this.tableLayoutPanel.Controls.Add(this.m_lblCopyright, 1, 2);
          this.tableLayoutPanel.Controls.Add(this.m_lblCompanyName, 1, 3);
          this.tableLayoutPanel.Controls.Add(this.m_txtProductDescription, 1, 4);
          this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
          this.tableLayoutPanel.Location = new System.Drawing.Point(3, 3);
          this.tableLayoutPanel.Name = "tableLayoutPanel";
          this.tableLayoutPanel.RowCount = 5;
          this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
          this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
          this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
          this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
          this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
          this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
          this.tableLayoutPanel.Size = new System.Drawing.Size(400, 360);
          this.tableLayoutPanel.TabIndex = 1;
          // 
          // pictureBox1
          // 
          this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
          this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
          this.pictureBox1.Location = new System.Drawing.Point(3, 3);
          this.pictureBox1.Name = "pictureBox1";
          this.tableLayoutPanel.SetRowSpan(this.pictureBox1, 5);
          this.pictureBox1.Size = new System.Drawing.Size(126, 354);
          this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
          this.pictureBox1.TabIndex = 12;
          this.pictureBox1.TabStop = false;
          // 
          // m_lblProductName
          // 
          this.m_lblProductName.Dock = System.Windows.Forms.DockStyle.Fill;
          this.m_lblProductName.Location = new System.Drawing.Point(138, 0);
          this.m_lblProductName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
          this.m_lblProductName.MaximumSize = new System.Drawing.Size(0, 17);
          this.m_lblProductName.Name = "m_lblProductName";
          this.m_lblProductName.Size = new System.Drawing.Size(259, 17);
          this.m_lblProductName.TabIndex = 19;
          this.m_lblProductName.Text = "Product Name";
          this.m_lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
          // 
          // m_lblVersion
          // 
          this.m_lblVersion.Dock = System.Windows.Forms.DockStyle.Fill;
          this.m_lblVersion.Location = new System.Drawing.Point(138, 36);
          this.m_lblVersion.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
          this.m_lblVersion.MaximumSize = new System.Drawing.Size(0, 17);
          this.m_lblVersion.Name = "m_lblVersion";
          this.m_lblVersion.Size = new System.Drawing.Size(259, 17);
          this.m_lblVersion.TabIndex = 0;
          this.m_lblVersion.Text = "Version";
          this.m_lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
          // 
          // m_lblCopyright
          // 
          this.m_lblCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
          this.m_lblCopyright.Location = new System.Drawing.Point(138, 72);
          this.m_lblCopyright.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
          this.m_lblCopyright.MaximumSize = new System.Drawing.Size(0, 17);
          this.m_lblCopyright.Name = "m_lblCopyright";
          this.m_lblCopyright.Size = new System.Drawing.Size(259, 17);
          this.m_lblCopyright.TabIndex = 21;
          this.m_lblCopyright.Text = "Copyright";
          this.m_lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
          // 
          // m_lblCompanyName
          // 
          this.m_lblCompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
          this.m_lblCompanyName.Location = new System.Drawing.Point(138, 108);
          this.m_lblCompanyName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
          this.m_lblCompanyName.MaximumSize = new System.Drawing.Size(0, 17);
          this.m_lblCompanyName.Name = "m_lblCompanyName";
          this.m_lblCompanyName.Size = new System.Drawing.Size(259, 17);
          this.m_lblCompanyName.TabIndex = 22;
          this.m_lblCompanyName.Text = "Company Name";
          this.m_lblCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
          // 
          // m_txtProductDescription
          // 
          this.m_txtProductDescription.Dock = System.Windows.Forms.DockStyle.Fill;
          this.m_txtProductDescription.Location = new System.Drawing.Point(138, 147);
          this.m_txtProductDescription.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
          this.m_txtProductDescription.Multiline = true;
          this.m_txtProductDescription.Name = "m_txtProductDescription";
          this.m_txtProductDescription.ReadOnly = true;
          this.m_txtProductDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
          this.m_txtProductDescription.Size = new System.Drawing.Size(259, 210);
          this.m_txtProductDescription.TabIndex = 23;
          this.m_txtProductDescription.TabStop = false;
          this.m_txtProductDescription.Text = "Description";
          // 
          // m_tabColumns
          // 
          this.m_tabColumns.Controls.Add(this.m_columnsControl);
          this.m_tabColumns.Location = new System.Drawing.Point(4, 25);
          this.m_tabColumns.Name = "m_tabColumns";
          this.m_tabColumns.Padding = new System.Windows.Forms.Padding(3);
          this.m_tabColumns.Size = new System.Drawing.Size(406, 366);
          this.m_tabColumns.TabIndex = 5;
          this.m_tabColumns.Text = "Columns";
          this.m_tabColumns.UseVisualStyleBackColor = true;
          // 
          // m_columnsControl
          // 
          this.m_columnsControl.Dock = System.Windows.Forms.DockStyle.Fill;
          this.m_columnsControl.Location = new System.Drawing.Point(3, 3);
          this.m_columnsControl.Name = "m_columnsControl";
          this.m_columnsControl.Size = new System.Drawing.Size(400, 360);
          this.m_columnsControl.TabIndex = 0;
          // 
          // m_tabColors
          // 
          this.m_tabColors.Controls.Add(this.m_propColors);
          this.m_tabColors.Location = new System.Drawing.Point(4, 25);
          this.m_tabColors.Name = "m_tabColors";
          this.m_tabColors.Padding = new System.Windows.Forms.Padding(3);
          this.m_tabColors.Size = new System.Drawing.Size(406, 366);
          this.m_tabColors.TabIndex = 4;
          this.m_tabColors.Text = "Colors and Fonts";
          this.m_tabColors.UseVisualStyleBackColor = true;
          // 
          // m_propColors
          // 
          this.m_propColors.HelpVisible = false;
          this.m_propColors.Location = new System.Drawing.Point(9, 19);
          this.m_propColors.Name = "m_propColors";
          this.m_propColors.Size = new System.Drawing.Size(385, 280);
          this.m_propColors.TabIndex = 0;
          this.m_propColors.ToolbarVisible = false;
          // 
          // m_tabOptions
          // 
          this.m_tabOptions.Controls.Add(groupBox5);
          this.m_tabOptions.Controls.Add(this.m_logConfigurationView);
          this.m_tabOptions.Controls.Add(groupBox1);
          this.m_tabOptions.Location = new System.Drawing.Point(4, 25);
          this.m_tabOptions.Name = "m_tabOptions";
          this.m_tabOptions.Padding = new System.Windows.Forms.Padding(3);
          this.m_tabOptions.Size = new System.Drawing.Size(406, 366);
          this.m_tabOptions.TabIndex = 0;
          this.m_tabOptions.Text = "Options";
          this.m_tabOptions.UseVisualStyleBackColor = true;
          // 
          // m_logConfigurationView
          // 
          this.m_logConfigurationView.Location = new System.Drawing.Point(3, 162);
          this.m_logConfigurationView.Name = "m_logConfigurationView";
          this.m_logConfigurationView.Size = new System.Drawing.Size(397, 126);
          this.m_logConfigurationView.TabIndex = 44;
          // 
          // m_tabControl
          // 
          this.m_tabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
          this.m_tabControl.Controls.Add(this.m_tabOptions);
          this.m_tabControl.Controls.Add(this.m_tabColors);
          this.m_tabControl.Controls.Add(this.m_tabColumns);
          this.m_tabControl.Controls.Add(this.m_tabAdvanced);
          this.m_tabControl.Controls.Add(this.m_tabAbout);
          this.m_tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
          this.m_tabControl.Location = new System.Drawing.Point(5, 5);
          this.m_tabControl.Name = "m_tabControl";
          this.m_tabControl.SelectedIndex = 0;
          this.m_tabControl.Size = new System.Drawing.Size(414, 395);
          this.m_tabControl.TabIndex = 36;
          // 
          // m_tabAdvanced
          // 
          this.m_tabAdvanced.Controls.Add(this.groupBox3);
          this.m_tabAdvanced.Controls.Add(this.groupBox2);
          this.m_tabAdvanced.Location = new System.Drawing.Point(4, 25);
          this.m_tabAdvanced.Name = "m_tabAdvanced";
          this.m_tabAdvanced.Padding = new System.Windows.Forms.Padding(3);
          this.m_tabAdvanced.Size = new System.Drawing.Size(406, 366);
          this.m_tabAdvanced.TabIndex = 6;
          this.m_tabAdvanced.Text = "Advanced";
          this.m_tabAdvanced.UseVisualStyleBackColor = true;
          // 
          // groupBox3
          // 
          this.groupBox3.Controls.Add(label8);
          this.groupBox3.Controls.Add(label5);
          this.groupBox3.Controls.Add(label6);
          this.groupBox3.Controls.Add(this.m_nmrDontIndentateResponceLargeThan);
          this.groupBox3.Controls.Add(this.m_gridExcludedFrecs);
          this.groupBox3.Controls.Add(this.label7);
          this.groupBox3.Controls.Add(label3);
          this.groupBox3.Controls.Add(label1);
          this.groupBox3.Controls.Add(this.m_nmrMaximalResponseLength);
          this.groupBox3.Controls.Add(this.m_chkLazyParsing);
          this.groupBox3.Location = new System.Drawing.Point(12, 112);
          this.groupBox3.Name = "groupBox3";
          this.groupBox3.Size = new System.Drawing.Size(388, 248);
          this.groupBox3.TabIndex = 1;
          this.groupBox3.TabStop = false;
          this.groupBox3.Text = "Parsing";
          // 
          // m_nmrDontIndentateResponceLargeThan
          // 
          this.m_nmrDontIndentateResponceLargeThan.Location = new System.Drawing.Point(190, 72);
          this.m_nmrDontIndentateResponceLargeThan.Maximum = new decimal(new int[] {
            -294967296,
            0,
            0,
            0});
          this.m_nmrDontIndentateResponceLargeThan.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
          this.m_nmrDontIndentateResponceLargeThan.Name = "m_nmrDontIndentateResponceLargeThan";
          this.m_nmrDontIndentateResponceLargeThan.Size = new System.Drawing.Size(121, 20);
          this.m_nmrDontIndentateResponceLargeThan.TabIndex = 55;
          this.m_nmrDontIndentateResponceLargeThan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
          this.m_nmrDontIndentateResponceLargeThan.ThousandsSeparator = true;
          this.m_nmrDontIndentateResponceLargeThan.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
          this.m_nmrDontIndentateResponceLargeThan.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
          this.m_nmrDontIndentateResponceLargeThan.ValueChanged += new System.EventHandler(this.OnModify);
          // 
          // m_gridExcludedFrecs
          // 
          this.m_gridExcludedFrecs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
          this.m_gridExcludedFrecs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
          this.m_gridExcludedFrecs.Location = new System.Drawing.Point(9, 120);
          this.m_gridExcludedFrecs.Name = "m_gridExcludedFrecs";
          this.m_gridExcludedFrecs.RowTemplate.Height = 19;
          this.m_gridExcludedFrecs.Size = new System.Drawing.Size(373, 121);
          this.m_gridExcludedFrecs.TabIndex = 53;
          this.m_gridExcludedFrecs.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.OnGridExcludedFrecsCellBeginEdit);
          this.m_gridExcludedFrecs.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.OnGridExcludedFrecsUserRowAction);
          this.m_gridExcludedFrecs.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.OnGridExcludedFrecsUserRowAction);
          // 
          // Column1
          // 
          this.Column1.HeaderText = "Frec name";
          this.Column1.Name = "Column1";
          this.Column1.Width = 300;
          // 
          // label7
          // 
          this.label7.Location = new System.Drawing.Point(6, 101);
          this.label7.Name = "label7";
          this.label7.Size = new System.Drawing.Size(93, 48);
          this.label7.TabIndex = 52;
          this.label7.Text = "Excluded frecs :";
          // 
          // m_nmrMaximalResponseLength
          // 
          this.m_nmrMaximalResponseLength.Location = new System.Drawing.Point(86, 45);
          this.m_nmrMaximalResponseLength.Maximum = new decimal(new int[] {
            -294967296,
            0,
            0,
            0});
          this.m_nmrMaximalResponseLength.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
          this.m_nmrMaximalResponseLength.Name = "m_nmrMaximalResponseLength";
          this.m_nmrMaximalResponseLength.Size = new System.Drawing.Size(121, 20);
          this.m_nmrMaximalResponseLength.TabIndex = 47;
          this.m_nmrMaximalResponseLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
          this.m_nmrMaximalResponseLength.ThousandsSeparator = true;
          this.m_nmrMaximalResponseLength.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
          this.m_nmrMaximalResponseLength.Value = new decimal(new int[] {
            15000,
            0,
            0,
            0});
          this.m_nmrMaximalResponseLength.ValueChanged += new System.EventHandler(this.OnModify);
          // 
          // m_chkLazyParsing
          // 
          this.m_chkLazyParsing.AutoSize = true;
          this.m_chkLazyParsing.Location = new System.Drawing.Point(11, 22);
          this.m_chkLazyParsing.Name = "m_chkLazyParsing";
          this.m_chkLazyParsing.Size = new System.Drawing.Size(141, 17);
          this.m_chkLazyParsing.TabIndex = 32;
          this.m_chkLazyParsing.Text = "Use lazy parsing of frecs";
          this.m_chkLazyParsing.UseVisualStyleBackColor = true;
          this.m_chkLazyParsing.CheckedChanged += new System.EventHandler(this.OnModify);
          // 
          // groupBox2
          // 
          this.groupBox2.Controls.Add(this.m_btnOpenRepository);
          this.groupBox2.Controls.Add(this.m_txtRepository);
          this.groupBox2.Controls.Add(this.label2);
          this.groupBox2.Location = new System.Drawing.Point(12, 6);
          this.groupBox2.Name = "groupBox2";
          this.groupBox2.Size = new System.Drawing.Size(388, 103);
          this.groupBox2.TabIndex = 0;
          this.groupBox2.TabStop = false;
          this.groupBox2.Text = "Repository";
          // 
          // m_btnOpenRepository
          // 
          this.m_btnOpenRepository.Location = new System.Drawing.Point(230, 72);
          this.m_btnOpenRepository.Name = "m_btnOpenRepository";
          this.m_btnOpenRepository.Size = new System.Drawing.Size(152, 23);
          this.m_btnOpenRepository.TabIndex = 2;
          this.m_btnOpenRepository.Text = "Open repository folder";
          this.m_btnOpenRepository.UseVisualStyleBackColor = true;
          this.m_btnOpenRepository.Click += new System.EventHandler(this.OnBtnOpenRepositoryClick);
          // 
          // m_txtRepository
          // 
          this.m_txtRepository.Location = new System.Drawing.Point(48, 17);
          this.m_txtRepository.Multiline = true;
          this.m_txtRepository.Name = "m_txtRepository";
          this.m_txtRepository.ReadOnly = true;
          this.m_txtRepository.Size = new System.Drawing.Size(334, 50);
          this.m_txtRepository.TabIndex = 1;
          // 
          // label2
          // 
          this.label2.AutoSize = true;
          this.label2.Location = new System.Drawing.Point(7, 34);
          this.label2.Name = "label2";
          this.label2.Size = new System.Drawing.Size(35, 13);
          this.label2.TabIndex = 0;
          this.label2.Text = "Path :";
          // 
          // panelBorderPainter1
          // 
          this.panelBorderPainter1.Panel = this.m_buttonPanel;
          this.panelBorderPainter1.Side = System.Windows.Forms.Border3DSide.Top;
          // 
          // label8
          // 
          label8.AutoSize = true;
          label8.Location = new System.Drawing.Point(314, 75);
          label8.Name = "label8";
          label8.Size = new System.Drawing.Size(33, 13);
          label8.TabIndex = 57;
          label8.Text = "chars";
          // 
          // OptionsForm
          // 
          this.AcceptButton = this.m_btnOk;
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this.m_btnCancel;
          this.CausesValidation = false;
          this.ClientSize = new System.Drawing.Size(424, 442);
          this.Controls.Add(this.m_tabControl);
          this.Controls.Add(this.m_buttonPanel);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "OptionsForm";
          this.Padding = new System.Windows.Forms.Padding(5);
          this.ShowIcon = false;
          this.ShowInTaskbar = false;
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
          this.Text = "Configuration";
          this.Load += new System.EventHandler(this.OnLoad);
          groupBox1.ResumeLayout(false);
          groupBox1.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this.m_nmrOldFilesThreshold)).EndInit();
          groupBox5.ResumeLayout(false);
          this.m_buttonPanel.ResumeLayout(false);
          this.m_tabAbout.ResumeLayout(false);
          this.tableLayoutPanel.ResumeLayout(false);
          this.tableLayoutPanel.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
          this.m_tabColumns.ResumeLayout(false);
          this.m_tabColors.ResumeLayout(false);
          this.m_tabOptions.ResumeLayout(false);
          this.m_tabControl.ResumeLayout(false);
          this.m_tabAdvanced.ResumeLayout(false);
          this.groupBox3.ResumeLayout(false);
          this.groupBox3.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this.m_nmrDontIndentateResponceLargeThan)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.m_gridExcludedFrecs)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.m_nmrMaximalResponseLength)).EndInit();
          this.groupBox2.ResumeLayout(false);
          this.groupBox2.PerformLayout();
          this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel m_buttonPanel;
      private System.Windows.Forms.Button m_btnOk;
      private System.Windows.Forms.Button m_btnApply;
      private System.Windows.Forms.Button m_btnCancel;
      private WebGateLogger.UserControls.PanelBorderPainter panelBorderPainter1;
      private System.Windows.Forms.Button m_btnRestoreDefault;
      private System.Windows.Forms.TabPage m_tabAbout;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
      private System.Windows.Forms.PictureBox pictureBox1;
      private System.Windows.Forms.Label m_lblProductName;
      private System.Windows.Forms.Label m_lblVersion;
      private System.Windows.Forms.Label m_lblCopyright;
      private System.Windows.Forms.Label m_lblCompanyName;
      private System.Windows.Forms.TextBox m_txtProductDescription;
      private System.Windows.Forms.TabPage m_tabColumns;
      private LogComponents.Controls.ColumnsUserControl m_columnsControl;
      private System.Windows.Forms.TabPage m_tabColors;
      private LogComponents.Controls.CustomPropertyGrid m_propColors;
      private System.Windows.Forms.TabPage m_tabOptions;
      private WebGateLogger.Config.LogConfigurationView m_logConfigurationView;
      private System.Windows.Forms.CheckBox m_chkAddToContextMenuOfExplorer;
      private System.Windows.Forms.NumericUpDown m_nmrOldFilesThreshold;
      private System.Windows.Forms.CheckBox m_chkRemoveOldFiles;
      private System.Windows.Forms.CheckBox m_chkStayOnRowOnRefresh;
      private System.Windows.Forms.CheckBox m_chkLoadOnStart;
      private System.Windows.Forms.CheckBox m_chkScrollToBottomOnLoad;
      private System.Windows.Forms.TabControl m_tabControl;
      private System.Windows.Forms.TabPage m_tabAdvanced;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.Button m_btnOpenRepository;
      private System.Windows.Forms.TextBox m_txtRepository;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.CheckBox m_chkLazyParsing;
      private System.Windows.Forms.NumericUpDown m_nmrMaximalResponseLength;
      private System.Windows.Forms.Button m_btnShortcut;
      private System.Windows.Forms.ComboBox m_cmbShortcutFolders;
      private System.Windows.Forms.CheckBox m_chkLoadFollowingSessionFiles;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.DataGridView m_gridExcludedFrecs;
      private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
      private System.Windows.Forms.NumericUpDown m_nmrDontIndentateResponceLargeThan;
    }
}