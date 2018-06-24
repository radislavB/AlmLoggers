namespace ServerLogger
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
      System.Windows.Forms.GroupBox groupBox5;
      System.Windows.Forms.Label label4;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
      this.m_cmbShortcutFolders = new System.Windows.Forms.ComboBox();
      this.m_btnShortcut = new System.Windows.Forms.Button();
      this.m_tabControl = new System.Windows.Forms.TabControl();
      this.m_tabGeneral = new System.Windows.Forms.TabPage();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.m_btnOpenRepository = new System.Windows.Forms.Button();
      this.m_txtRepository = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.m_btnDefinePurgeFolder = new System.Windows.Forms.Button();
      this.m_txtPurgeFolder = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.m_nmrOldFilesThreshold = new System.Windows.Forms.NumericUpDown();
      this.m_chkRemoveOldFiles = new System.Windows.Forms.CheckBox();
      this.m_tabColors = new System.Windows.Forms.TabPage();
      this.m_propColors = new LogComponents.Controls.CustomPropertyGrid();
      this.m_tabRequestColumns = new System.Windows.Forms.TabPage();
      this.m_ucRequestColumns = new LogComponents.Controls.ColumnsUserControl();
      this.m_tabRowColumns = new System.Windows.Forms.TabPage();
      this.m_ucRowColumns = new LogComponents.Controls.ColumnsUserControl();
      this.m_tabAbout = new System.Windows.Forms.TabPage();
      this.m_tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
      this.pictureBox3 = new System.Windows.Forms.PictureBox();
      this.m_lblProductName = new System.Windows.Forms.Label();
      this.m_lblVersion = new System.Windows.Forms.Label();
      this.m_lblCopyright = new System.Windows.Forms.Label();
      this.m_lblCompanyName = new System.Windows.Forms.Label();
      this.m_txtProductDescription = new System.Windows.Forms.TextBox();
      this.m_buttonPanel = new System.Windows.Forms.Panel();
      this.m_btnRestoreDefault = new System.Windows.Forms.Button();
      this.m_btnOk = new System.Windows.Forms.Button();
      this.m_btnApply = new System.Windows.Forms.Button();
      this.m_btnCancel = new System.Windows.Forms.Button();
      groupBox5 = new System.Windows.Forms.GroupBox();
      label4 = new System.Windows.Forms.Label();
      groupBox5.SuspendLayout();
      this.m_tabControl.SuspendLayout();
      this.m_tabGeneral.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.m_nmrOldFilesThreshold)).BeginInit();
      this.m_tabColors.SuspendLayout();
      this.m_tabRequestColumns.SuspendLayout();
      this.m_tabRowColumns.SuspendLayout();
      this.m_tabAbout.SuspendLayout();
      this.m_tableLayoutPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
      this.m_buttonPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox5
      // 
      groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      groupBox5.Controls.Add(this.m_cmbShortcutFolders);
      groupBox5.Controls.Add(this.m_btnShortcut);
      groupBox5.Location = new System.Drawing.Point(6, 6);
      groupBox5.Name = "groupBox5";
      groupBox5.Size = new System.Drawing.Size(389, 68);
      groupBox5.TabIndex = 46;
      groupBox5.TabStop = false;
      groupBox5.Text = "Shortcuts to application";
      // 
      // m_cmbShortcutFolders
      // 
      this.m_cmbShortcutFolders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.m_cmbShortcutFolders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.m_cmbShortcutFolders.FormattingEnabled = true;
      this.m_cmbShortcutFolders.Items.AddRange(new object[] {
            "Custom folder",
            "Desktop",
            "Quick toolbar"});
      this.m_cmbShortcutFolders.Location = new System.Drawing.Point(161, 28);
      this.m_cmbShortcutFolders.Name = "m_cmbShortcutFolders";
      this.m_cmbShortcutFolders.Size = new System.Drawing.Size(218, 21);
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
      // label4
      // 
      label4.AutoSize = true;
      label4.Location = new System.Drawing.Point(246, 21);
      label4.Name = "label4";
      label4.Size = new System.Drawing.Size(29, 13);
      label4.TabIndex = 44;
      label4.Text = "days";
      // 
      // m_tabControl
      // 
      this.m_tabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
      this.m_tabControl.Controls.Add(this.m_tabGeneral);
      this.m_tabControl.Controls.Add(this.m_tabColors);
      this.m_tabControl.Controls.Add(this.m_tabRequestColumns);
      this.m_tabControl.Controls.Add(this.m_tabRowColumns);
      this.m_tabControl.Controls.Add(this.m_tabAbout);
      this.m_tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_tabControl.Location = new System.Drawing.Point(5, 5);
      this.m_tabControl.Multiline = true;
      this.m_tabControl.Name = "m_tabControl";
      this.m_tabControl.SelectedIndex = 0;
      this.m_tabControl.Size = new System.Drawing.Size(411, 430);
      this.m_tabControl.TabIndex = 38;
      // 
      // m_tabGeneral
      // 
      this.m_tabGeneral.Controls.Add(this.groupBox2);
      this.m_tabGeneral.Controls.Add(this.groupBox1);
      this.m_tabGeneral.Controls.Add(groupBox5);
      this.m_tabGeneral.Location = new System.Drawing.Point(4, 25);
      this.m_tabGeneral.Name = "m_tabGeneral";
      this.m_tabGeneral.Padding = new System.Windows.Forms.Padding(3);
      this.m_tabGeneral.Size = new System.Drawing.Size(403, 401);
      this.m_tabGeneral.TabIndex = 4;
      this.m_tabGeneral.Text = "General";
      this.m_tabGeneral.UseVisualStyleBackColor = true;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.m_btnOpenRepository);
      this.groupBox2.Controls.Add(this.m_txtRepository);
      this.groupBox2.Controls.Add(this.label2);
      this.groupBox2.Location = new System.Drawing.Point(7, 170);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(388, 103);
      this.groupBox2.TabIndex = 48;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Repository";
      // 
      // m_btnOpenRepository
      // 
      this.m_btnOpenRepository.Location = new System.Drawing.Point(230, 73);
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
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.m_btnDefinePurgeFolder);
      this.groupBox1.Controls.Add(this.m_txtPurgeFolder);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(label4);
      this.groupBox1.Controls.Add(this.m_nmrOldFilesThreshold);
      this.groupBox1.Controls.Add(this.m_chkRemoveOldFiles);
      this.groupBox1.Location = new System.Drawing.Point(7, 81);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(388, 72);
      this.groupBox1.TabIndex = 47;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Purge";
      // 
      // m_btnDefinePurgeFolder
      // 
      this.m_btnDefinePurgeFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.m_btnDefinePurgeFolder.Location = new System.Drawing.Point(349, 40);
      this.m_btnDefinePurgeFolder.Name = "m_btnDefinePurgeFolder";
      this.m_btnDefinePurgeFolder.Size = new System.Drawing.Size(29, 23);
      this.m_btnDefinePurgeFolder.TabIndex = 47;
      this.m_btnDefinePurgeFolder.Text = "...";
      this.m_btnDefinePurgeFolder.UseVisualStyleBackColor = true;
      this.m_btnDefinePurgeFolder.Click += new System.EventHandler(this.OnBtnDefinePurgeFolderClick);
      // 
      // m_txtPurgeFolder
      // 
      this.m_txtPurgeFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.m_txtPurgeFolder.Location = new System.Drawing.Point(55, 42);
      this.m_txtPurgeFolder.Name = "m_txtPurgeFolder";
      this.m_txtPurgeFolder.ReadOnly = true;
      this.m_txtPurgeFolder.Size = new System.Drawing.Size(288, 20);
      this.m_txtPurgeFolder.TabIndex = 46;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(7, 45);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(42, 13);
      this.label1.TabIndex = 45;
      this.label1.Text = "Folder :";
      // 
      // m_nmrOldFilesThreshold
      // 
      this.m_nmrOldFilesThreshold.Location = new System.Drawing.Point(173, 16);
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
      this.m_nmrOldFilesThreshold.TabIndex = 43;
      this.m_nmrOldFilesThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.m_nmrOldFilesThreshold.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
      this.m_nmrOldFilesThreshold.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
      // 
      // m_chkRemoveOldFiles
      // 
      this.m_chkRemoveOldFiles.AutoSize = true;
      this.m_chkRemoveOldFiles.Location = new System.Drawing.Point(10, 19);
      this.m_chkRemoveOldFiles.Name = "m_chkRemoveOldFiles";
      this.m_chkRemoveOldFiles.Size = new System.Drawing.Size(157, 17);
      this.m_chkRemoveOldFiles.TabIndex = 42;
      this.m_chkRemoveOldFiles.Text = "Remove log files older than ";
      this.m_chkRemoveOldFiles.UseVisualStyleBackColor = true;
      this.m_chkRemoveOldFiles.CheckedChanged += new System.EventHandler(this.OnModify);
      // 
      // m_tabColors
      // 
      this.m_tabColors.Controls.Add(this.m_propColors);
      this.m_tabColors.Location = new System.Drawing.Point(4, 25);
      this.m_tabColors.Name = "m_tabColors";
      this.m_tabColors.Padding = new System.Windows.Forms.Padding(3);
      this.m_tabColors.Size = new System.Drawing.Size(403, 401);
      this.m_tabColors.TabIndex = 0;
      this.m_tabColors.Text = "Colors";
      this.m_tabColors.UseVisualStyleBackColor = true;
      // 
      // m_propColors
      // 
      this.m_propColors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.m_propColors.HelpVisible = false;
      this.m_propColors.Location = new System.Drawing.Point(9, 14);
      this.m_propColors.Name = "m_propColors";
      this.m_propColors.Size = new System.Drawing.Size(388, 381);
      this.m_propColors.TabIndex = 0;
      this.m_propColors.ToolbarVisible = false;
      // 
      // m_tabRequestColumns
      // 
      this.m_tabRequestColumns.Controls.Add(this.m_ucRequestColumns);
      this.m_tabRequestColumns.Location = new System.Drawing.Point(4, 25);
      this.m_tabRequestColumns.Name = "m_tabRequestColumns";
      this.m_tabRequestColumns.Padding = new System.Windows.Forms.Padding(3);
      this.m_tabRequestColumns.Size = new System.Drawing.Size(403, 401);
      this.m_tabRequestColumns.TabIndex = 2;
      this.m_tabRequestColumns.Text = "Request columns";
      this.m_tabRequestColumns.UseVisualStyleBackColor = true;
      // 
      // m_ucRequestColumns
      // 
      this.m_ucRequestColumns.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_ucRequestColumns.Location = new System.Drawing.Point(3, 3);
      this.m_ucRequestColumns.Name = "m_ucRequestColumns";
      this.m_ucRequestColumns.Size = new System.Drawing.Size(397, 395);
      this.m_ucRequestColumns.TabIndex = 0;
      // 
      // m_tabRowColumns
      // 
      this.m_tabRowColumns.Controls.Add(this.m_ucRowColumns);
      this.m_tabRowColumns.Location = new System.Drawing.Point(4, 25);
      this.m_tabRowColumns.Name = "m_tabRowColumns";
      this.m_tabRowColumns.Padding = new System.Windows.Forms.Padding(3);
      this.m_tabRowColumns.Size = new System.Drawing.Size(403, 401);
      this.m_tabRowColumns.TabIndex = 3;
      this.m_tabRowColumns.Text = "Row columns";
      this.m_tabRowColumns.UseVisualStyleBackColor = true;
      // 
      // m_ucRowColumns
      // 
      this.m_ucRowColumns.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_ucRowColumns.Location = new System.Drawing.Point(3, 3);
      this.m_ucRowColumns.Name = "m_ucRowColumns";
      this.m_ucRowColumns.Size = new System.Drawing.Size(397, 395);
      this.m_ucRowColumns.TabIndex = 0;
      // 
      // m_tabAbout
      // 
      this.m_tabAbout.Controls.Add(this.m_tableLayoutPanel);
      this.m_tabAbout.Location = new System.Drawing.Point(4, 25);
      this.m_tabAbout.Name = "m_tabAbout";
      this.m_tabAbout.Padding = new System.Windows.Forms.Padding(3);
      this.m_tabAbout.Size = new System.Drawing.Size(403, 401);
      this.m_tabAbout.TabIndex = 1;
      this.m_tabAbout.Text = "About";
      this.m_tabAbout.UseVisualStyleBackColor = true;
      // 
      // m_tableLayoutPanel
      // 
      this.m_tableLayoutPanel.ColumnCount = 2;
      this.m_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
      this.m_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67F));
      this.m_tableLayoutPanel.Controls.Add(this.pictureBox3, 0, 0);
      this.m_tableLayoutPanel.Controls.Add(this.m_lblProductName, 1, 0);
      this.m_tableLayoutPanel.Controls.Add(this.m_lblVersion, 1, 1);
      this.m_tableLayoutPanel.Controls.Add(this.m_lblCopyright, 1, 2);
      this.m_tableLayoutPanel.Controls.Add(this.m_lblCompanyName, 1, 3);
      this.m_tableLayoutPanel.Controls.Add(this.m_txtProductDescription, 1, 4);
      this.m_tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_tableLayoutPanel.Location = new System.Drawing.Point(3, 3);
      this.m_tableLayoutPanel.Name = "m_tableLayoutPanel";
      this.m_tableLayoutPanel.RowCount = 5;
      this.m_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
      this.m_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
      this.m_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
      this.m_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
      this.m_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.m_tableLayoutPanel.Size = new System.Drawing.Size(397, 395);
      this.m_tableLayoutPanel.TabIndex = 2;
      // 
      // pictureBox3
      // 
      this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
      this.pictureBox3.Location = new System.Drawing.Point(3, 3);
      this.pictureBox3.Name = "pictureBox3";
      this.m_tableLayoutPanel.SetRowSpan(this.pictureBox3, 5);
      this.pictureBox3.Size = new System.Drawing.Size(125, 389);
      this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox3.TabIndex = 12;
      this.pictureBox3.TabStop = false;
      // 
      // m_lblProductName
      // 
      this.m_lblProductName.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_lblProductName.Location = new System.Drawing.Point(137, 0);
      this.m_lblProductName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
      this.m_lblProductName.MaximumSize = new System.Drawing.Size(0, 17);
      this.m_lblProductName.Name = "m_lblProductName";
      this.m_lblProductName.Size = new System.Drawing.Size(257, 17);
      this.m_lblProductName.TabIndex = 19;
      this.m_lblProductName.Text = "Product Name";
      this.m_lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // m_lblVersion
      // 
      this.m_lblVersion.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_lblVersion.Location = new System.Drawing.Point(137, 43);
      this.m_lblVersion.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
      this.m_lblVersion.MaximumSize = new System.Drawing.Size(0, 17);
      this.m_lblVersion.Name = "m_lblVersion";
      this.m_lblVersion.Size = new System.Drawing.Size(257, 17);
      this.m_lblVersion.TabIndex = 0;
      this.m_lblVersion.Text = "Version";
      this.m_lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // m_lblCopyright
      // 
      this.m_lblCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_lblCopyright.Location = new System.Drawing.Point(137, 86);
      this.m_lblCopyright.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
      this.m_lblCopyright.MaximumSize = new System.Drawing.Size(0, 17);
      this.m_lblCopyright.Name = "m_lblCopyright";
      this.m_lblCopyright.Size = new System.Drawing.Size(257, 17);
      this.m_lblCopyright.TabIndex = 21;
      this.m_lblCopyright.Text = "Copyright";
      this.m_lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // m_lblCompanyName
      // 
      this.m_lblCompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_lblCompanyName.Location = new System.Drawing.Point(137, 129);
      this.m_lblCompanyName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
      this.m_lblCompanyName.MaximumSize = new System.Drawing.Size(0, 17);
      this.m_lblCompanyName.Name = "m_lblCompanyName";
      this.m_lblCompanyName.Size = new System.Drawing.Size(257, 17);
      this.m_lblCompanyName.TabIndex = 22;
      this.m_lblCompanyName.Text = "Company Name";
      this.m_lblCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // m_txtProductDescription
      // 
      this.m_txtProductDescription.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_txtProductDescription.Location = new System.Drawing.Point(137, 175);
      this.m_txtProductDescription.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
      this.m_txtProductDescription.Multiline = true;
      this.m_txtProductDescription.Name = "m_txtProductDescription";
      this.m_txtProductDescription.ReadOnly = true;
      this.m_txtProductDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.m_txtProductDescription.Size = new System.Drawing.Size(257, 217);
      this.m_txtProductDescription.TabIndex = 23;
      this.m_txtProductDescription.TabStop = false;
      this.m_txtProductDescription.Text = "Description";
      // 
      // m_buttonPanel
      // 
      this.m_buttonPanel.Controls.Add(this.m_btnRestoreDefault);
      this.m_buttonPanel.Controls.Add(this.m_btnOk);
      this.m_buttonPanel.Controls.Add(this.m_btnApply);
      this.m_buttonPanel.Controls.Add(this.m_btnCancel);
      this.m_buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.m_buttonPanel.Location = new System.Drawing.Point(5, 435);
      this.m_buttonPanel.Name = "m_buttonPanel";
      this.m_buttonPanel.Size = new System.Drawing.Size(411, 37);
      this.m_buttonPanel.TabIndex = 37;
      // 
      // m_btnRestoreDefault
      // 
      this.m_btnRestoreDefault.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.m_btnRestoreDefault.Location = new System.Drawing.Point(14, 6);
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
      this.m_btnOk.Location = new System.Drawing.Point(310, 6);
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
      this.m_btnApply.Location = new System.Drawing.Point(130, 6);
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
      this.m_btnCancel.Location = new System.Drawing.Point(220, 6);
      this.m_btnCancel.Name = "m_btnCancel";
      this.m_btnCancel.Size = new System.Drawing.Size(75, 25);
      this.m_btnCancel.TabIndex = 5;
      this.m_btnCancel.Text = "&Cancel";
      this.m_btnCancel.UseVisualStyleBackColor = true;
      this.m_btnCancel.Click += new System.EventHandler(this.OnCancelClick);
      // 
      // OptionsForm
      // 
      this.AcceptButton = this.m_btnOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.m_btnCancel;
      this.ClientSize = new System.Drawing.Size(421, 477);
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
      this.Shown += new System.EventHandler(this.OnShown);
      groupBox5.ResumeLayout(false);
      this.m_tabControl.ResumeLayout(false);
      this.m_tabGeneral.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.m_nmrOldFilesThreshold)).EndInit();
      this.m_tabColors.ResumeLayout(false);
      this.m_tabRequestColumns.ResumeLayout(false);
      this.m_tabRowColumns.ResumeLayout(false);
      this.m_tabAbout.ResumeLayout(false);
      this.m_tableLayoutPanel.ResumeLayout(false);
      this.m_tableLayoutPanel.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
      this.m_buttonPanel.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl m_tabControl;
    private System.Windows.Forms.TabPage m_tabColors;
    private LogComponents.Controls.CustomPropertyGrid m_propColors;
    private System.Windows.Forms.TabPage m_tabAbout;
    private System.Windows.Forms.TableLayoutPanel m_tableLayoutPanel;
    private System.Windows.Forms.PictureBox pictureBox3;
    private System.Windows.Forms.Label m_lblProductName;
    private System.Windows.Forms.Label m_lblVersion;
    private System.Windows.Forms.Label m_lblCopyright;
    private System.Windows.Forms.Label m_lblCompanyName;
    private System.Windows.Forms.TextBox m_txtProductDescription;
    private System.Windows.Forms.Panel m_buttonPanel;
    private System.Windows.Forms.Button m_btnRestoreDefault;
    private System.Windows.Forms.Button m_btnOk;
    private System.Windows.Forms.Button m_btnApply;
    private System.Windows.Forms.Button m_btnCancel;
    private System.Windows.Forms.TabPage m_tabRequestColumns;
    private LogComponents.Controls.ColumnsUserControl m_ucRequestColumns;
    private System.Windows.Forms.TabPage m_tabRowColumns;
    private LogComponents.Controls.ColumnsUserControl m_ucRowColumns;
    private System.Windows.Forms.TabPage m_tabGeneral;
    private System.Windows.Forms.ComboBox m_cmbShortcutFolders;
    private System.Windows.Forms.Button m_btnShortcut;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.NumericUpDown m_nmrOldFilesThreshold;
    private System.Windows.Forms.CheckBox m_chkRemoveOldFiles;
    private System.Windows.Forms.Button m_btnDefinePurgeFolder;
    private System.Windows.Forms.TextBox m_txtPurgeFolder;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Button m_btnOpenRepository;
    private System.Windows.Forms.TextBox m_txtRepository;
    private System.Windows.Forms.Label label2;
  }
}