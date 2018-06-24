namespace WebGateLogger
{
  partial class MainForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.m_statusStrip = new System.Windows.Forms.StatusStrip();
      this.m_txtStatus = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
      this.m_menu = new System.Windows.Forms.ToolStrip();
      this.m_btnRefresh = new System.Windows.Forms.ToolStripButton();
      this.m_btnSpecificLog = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
      this.m_btnLoadedSource = new System.Windows.Forms.ToolStripButton();
      this.m_btnBottom = new System.Windows.Forms.ToolStripButton();
      this.m_btnTop = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.m_btnNextFile = new System.Windows.Forms.ToolStripButton();
      this.m_btnPrevFile = new System.Windows.Forms.ToolStripButton();
      this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
      this.m_cmbRefreshLock = new System.Windows.Forms.ToolStripComboBox();
      this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
      this.m_btnAutoRefresh = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
      this.m_btnOptions = new System.Windows.Forms.ToolStripButton();
      this.m_splitMainPanel = new System.Windows.Forms.SplitContainer();
      this.m_splitLeftPanel = new System.Windows.Forms.SplitContainer();
      this.m_filterGridControl = new LogComponents.FilterControl.FilterGridControl();
      this.m_filterGridControlContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.m_toolCopy = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.m_toolFilterFromCurrentRow = new System.Windows.Forms.ToolStripMenuItem();
      this.m_toolFilterFailedRows = new System.Windows.Forms.ToolStripMenuItem();
      this.m_toolMenuFilterBy = new System.Windows.Forms.ToolStripMenuItem();
      this.m_toolClearFilter = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.m_toolOpen = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
      this.m_toolExit = new System.Windows.Forms.ToolStripMenuItem();
      this.m_tabAdditionalData = new System.Windows.Forms.TabControl();
      this.m_tabIds = new System.Windows.Forms.TabPage();
      this.m_idsGrid = new System.Windows.Forms.DataGridView();
      this.clmTable = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.clmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.m_txtIdsCount = new System.Windows.Forms.TextBox();
      this.m_tabConnectionInfo = new System.Windows.Forms.TabPage();
      this.m_gridConnectionInfo = new LogComponents.Controls.CustomPropertyGrid();
      this.m_mvcManager = new LogComponents.MVC.MvcManager();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.m_statusStrip.SuspendLayout();
      this.m_menu.SuspendLayout();
      this.m_splitMainPanel.Panel1.SuspendLayout();
      this.m_splitMainPanel.Panel2.SuspendLayout();
      this.m_splitMainPanel.SuspendLayout();
      this.m_splitLeftPanel.Panel1.SuspendLayout();
      this.m_splitLeftPanel.Panel2.SuspendLayout();
      this.m_splitLeftPanel.SuspendLayout();
      this.m_filterGridControlContextMenu.SuspendLayout();
      this.m_tabAdditionalData.SuspendLayout();
      this.m_tabIds.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.m_idsGrid)).BeginInit();
      this.m_tabConnectionInfo.SuspendLayout();
      this.SuspendLayout();
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
      // 
      // m_statusStrip
      // 
      this.m_statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_txtStatus,
            this.toolStripStatusLabel1});
      this.m_statusStrip.Location = new System.Drawing.Point(0, 571);
      this.m_statusStrip.Name = "m_statusStrip";
      this.m_statusStrip.ShowItemToolTips = true;
      this.m_statusStrip.Size = new System.Drawing.Size(967, 25);
      this.m_statusStrip.TabIndex = 3;
      this.m_statusStrip.Text = "statusStrip1";
      // 
      // m_txtStatus
      // 
      this.m_txtStatus.Name = "m_txtStatus";
      this.m_txtStatus.Size = new System.Drawing.Size(932, 20);
      this.m_txtStatus.Spring = true;
      this.m_txtStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // toolStripStatusLabel1
      // 
      this.toolStripStatusLabel1.AutoSize = false;
      this.toolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
      this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
      this.toolStripStatusLabel1.Size = new System.Drawing.Size(20, 20);
      // 
      // m_menu
      // 
      this.m_menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.m_menu.ImageScalingSize = new System.Drawing.Size(24, 24);
      this.m_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_btnRefresh,
            this.m_btnSpecificLog,
            this.toolStripSeparator5,
            this.m_btnLoadedSource,
            this.toolStripSeparator1,
            this.m_btnBottom,
            this.m_btnTop,
            this.toolStripSeparator2,
            this.m_btnNextFile,
            this.m_btnPrevFile,
            this.toolStripLabel1,
            this.m_cmbRefreshLock,
            this.toolStripSeparator6,
            this.m_btnAutoRefresh,
            this.toolStripSeparator8,
            this.m_btnOptions});
      this.m_menu.Location = new System.Drawing.Point(0, 0);
      this.m_menu.Name = "m_menu";
      this.m_menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
      this.m_menu.Size = new System.Drawing.Size(967, 31);
      this.m_menu.TabIndex = 2;
      this.m_menu.Text = "toolStrip2";
      // 
      // m_btnRefresh
      // 
      this.m_btnRefresh.Image = global::WebGateLogger.Properties.Resources.component_replace;
      this.m_btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.m_btnRefresh.Name = "m_btnRefresh";
      this.m_btnRefresh.Size = new System.Drawing.Size(73, 28);
      this.m_btnRefresh.Text = "Refresh";
      this.m_btnRefresh.ToolTipText = "Reload last created log file. File is taken from log folder automatically.";
      this.m_btnRefresh.Click += new System.EventHandler(this.OnBtnLoadLastLogClick);
      // 
      // m_btnSpecificLog
      // 
      this.m_btnSpecificLog.Image = global::WebGateLogger.Properties.Resources.component_find;
      this.m_btnSpecificLog.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.m_btnSpecificLog.Name = "m_btnSpecificLog";
      this.m_btnSpecificLog.Size = new System.Drawing.Size(78, 28);
      this.m_btnSpecificLog.Text = "Open log";
      this.m_btnSpecificLog.ToolTipText = "Open arbitrary log file";
      this.m_btnSpecificLog.Click += new System.EventHandler(this.OnBtnLoadSpecificLogClick);
      // 
      // toolStripSeparator5
      // 
      this.toolStripSeparator5.Name = "toolStripSeparator5";
      this.toolStripSeparator5.Size = new System.Drawing.Size(6, 31);
      // 
      // m_btnLoadedSource
      // 
      this.m_btnLoadedSource.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.m_btnLoadedSource.Enabled = false;
      this.m_btnLoadedSource.Image = global::WebGateLogger.Properties.Resources.document_notebook;
      this.m_btnLoadedSource.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.m_btnLoadedSource.Name = "m_btnLoadedSource";
      this.m_btnLoadedSource.Size = new System.Drawing.Size(28, 28);
      this.m_btnLoadedSource.Text = "Open source";
      this.m_btnLoadedSource.Click += new System.EventHandler(this.OnBtnLoadedSource);
      // 
      // m_btnBottom
      // 
      this.m_btnBottom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.m_btnBottom.Image = global::WebGateLogger.Properties.Resources.selection_down;
      this.m_btnBottom.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.m_btnBottom.Name = "m_btnBottom";
      this.m_btnBottom.Size = new System.Drawing.Size(28, 28);
      this.m_btnBottom.Text = "Scroll bottom";
      this.m_btnBottom.Click += new System.EventHandler(this.OnBtnScrollBottomClick);
      // 
      // m_btnTop
      // 
      this.m_btnTop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.m_btnTop.Image = global::WebGateLogger.Properties.Resources.selection_up;
      this.m_btnTop.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.m_btnTop.Name = "m_btnTop";
      this.m_btnTop.Size = new System.Drawing.Size(28, 28);
      this.m_btnTop.Text = "Scroll top";
      this.m_btnTop.Click += new System.EventHandler(this.OnBtnScrollTopClick);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
      // 
      // m_btnNextFile
      // 
      this.m_btnNextFile.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.m_btnNextFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.m_btnNextFile.Enabled = false;
      this.m_btnNextFile.Image = global::WebGateLogger.Properties.Resources.nav_right_blue;
      this.m_btnNextFile.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.m_btnNextFile.Name = "m_btnNextFile";
      this.m_btnNextFile.Size = new System.Drawing.Size(28, 28);
      this.m_btnNextFile.Click += new System.EventHandler(this.OnBtnPrevNextClick);
      // 
      // m_btnPrevFile
      // 
      this.m_btnPrevFile.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.m_btnPrevFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.m_btnPrevFile.Enabled = false;
      this.m_btnPrevFile.Image = global::WebGateLogger.Properties.Resources.nav_left_blue;
      this.m_btnPrevFile.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.m_btnPrevFile.Name = "m_btnPrevFile";
      this.m_btnPrevFile.Size = new System.Drawing.Size(28, 28);
      this.m_btnPrevFile.Click += new System.EventHandler(this.OnBtnPrevNextClick);
      // 
      // toolStripLabel1
      // 
      this.toolStripLabel1.Name = "toolStripLabel1";
      this.toolStripLabel1.Size = new System.Drawing.Size(73, 28);
      this.toolStripLabel1.Text = "Refresh lock :";
      // 
      // m_cmbRefreshLock
      // 
      this.m_cmbRefreshLock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.m_cmbRefreshLock.Items.AddRange(new object[] {
            "No lock",
            "Lock on current server",
            "Lock on current file"});
      this.m_cmbRefreshLock.Name = "m_cmbRefreshLock";
      this.m_cmbRefreshLock.Size = new System.Drawing.Size(140, 31);
      this.m_cmbRefreshLock.SelectedIndexChanged += new System.EventHandler(this.OnRefreshLockChanged);
      // 
      // toolStripSeparator6
      // 
      this.toolStripSeparator6.Name = "toolStripSeparator6";
      this.toolStripSeparator6.Size = new System.Drawing.Size(6, 31);
      // 
      // m_btnAutoRefresh
      // 
      this.m_btnAutoRefresh.CheckOnClick = true;
      this.m_btnAutoRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.m_btnAutoRefresh.Image = ((System.Drawing.Image)(resources.GetObject("m_btnAutoRefresh.Image")));
      this.m_btnAutoRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.m_btnAutoRefresh.Name = "m_btnAutoRefresh";
      this.m_btnAutoRefresh.Size = new System.Drawing.Size(75, 28);
      this.m_btnAutoRefresh.Text = "Auto Refresh";
      this.m_btnAutoRefresh.Click += new System.EventHandler(this.OnBtnAutoRefreshClick);
      // 
      // toolStripSeparator8
      // 
      this.toolStripSeparator8.Name = "toolStripSeparator8";
      this.toolStripSeparator8.Size = new System.Drawing.Size(6, 31);
      // 
      // m_btnOptions
      // 
      this.m_btnOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.m_btnOptions.Image = global::WebGateLogger.Properties.Resources.control_panel;
      this.m_btnOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.m_btnOptions.Name = "m_btnOptions";
      this.m_btnOptions.Size = new System.Drawing.Size(28, 28);
      this.m_btnOptions.Text = "Configuration";
      this.m_btnOptions.Click += new System.EventHandler(this.OnBtnOptionClick);
      // 
      // m_splitMainPanel
      // 
      this.m_splitMainPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.m_splitMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_splitMainPanel.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
      this.m_splitMainPanel.Location = new System.Drawing.Point(0, 31);
      this.m_splitMainPanel.Name = "m_splitMainPanel";
      // 
      // m_splitMainPanel.Panel1
      // 
      this.m_splitMainPanel.Panel1.Controls.Add(this.m_splitLeftPanel);
      // 
      // m_splitMainPanel.Panel2
      // 
      this.m_splitMainPanel.Panel2.Controls.Add(this.m_mvcManager);
      this.m_splitMainPanel.Size = new System.Drawing.Size(967, 540);
      this.m_splitMainPanel.SplitterDistance = 350;
      this.m_splitMainPanel.SplitterWidth = 2;
      this.m_splitMainPanel.TabIndex = 5;
      // 
      // m_splitLeftPanel
      // 
      this.m_splitLeftPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.m_splitLeftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_splitLeftPanel.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
      this.m_splitLeftPanel.Location = new System.Drawing.Point(0, 0);
      this.m_splitLeftPanel.Name = "m_splitLeftPanel";
      this.m_splitLeftPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // m_splitLeftPanel.Panel1
      // 
      this.m_splitLeftPanel.Panel1.Controls.Add(this.m_filterGridControl);
      // 
      // m_splitLeftPanel.Panel2
      // 
      this.m_splitLeftPanel.Panel2.Controls.Add(this.m_tabAdditionalData);
      this.m_splitLeftPanel.Size = new System.Drawing.Size(350, 540);
      this.m_splitLeftPanel.SplitterDistance = 365;
      this.m_splitLeftPanel.SplitterWidth = 2;
      this.m_splitLeftPanel.TabIndex = 0;
      // 
      // m_filterGridControl
      // 
      this.m_filterGridControl.BackColorDelegate = null;
      this.m_filterGridControl.ContextMenuStrip = this.m_filterGridControlContextMenu;
      this.m_filterGridControl.DataSource = null;
      this.m_filterGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_filterGridControl.FilterConfig = null;
      this.m_filterGridControl.FilterText = "";
      this.m_filterGridControl.FocusedIndex = -1;
      this.m_filterGridControl.GridBackgroundColor = System.Drawing.SystemColors.AppWorkspace;
      this.m_filterGridControl.GridContextMenu = null;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.m_filterGridControl.GridDefaultCellStyle = dataGridViewCellStyle1;
      this.m_filterGridControl.ImageStatusDelegate = null;
      this.m_filterGridControl.Location = new System.Drawing.Point(0, 0);
      this.m_filterGridControl.Name = "m_filterGridControl";
      this.m_filterGridControl.Size = new System.Drawing.Size(346, 361);
      this.m_filterGridControl.TabIndex = 0;
      this.m_filterGridControl.FilterChanged += new System.EventHandler<System.EventArgs>(this.OnFilterChanged);
      this.m_filterGridControl.FocusedIndexChanged += new System.EventHandler<LogComponents.FilterControl.FocusedIndexChangedEventArgs>(this.OnFocusedIndexChanged);
      // 
      // m_filterGridControlContextMenu
      // 
      this.m_filterGridControlContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_toolCopy,
            this.toolStripSeparator3,
            this.m_toolFilterFromCurrentRow,
            this.m_toolFilterFailedRows,
            this.m_toolMenuFilterBy,
            this.m_toolClearFilter,
            this.toolStripSeparator4,
            this.m_toolOpen,
            this.toolStripSeparator7,
            this.m_toolExit});
      this.m_filterGridControlContextMenu.Name = "contextMenuStrip1";
      this.m_filterGridControlContextMenu.Size = new System.Drawing.Size(218, 176);
      this.m_filterGridControlContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.OnContextMenuOpening);
      // 
      // m_toolCopy
      // 
      this.m_toolCopy.Name = "m_toolCopy";
      this.m_toolCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
      this.m_toolCopy.Size = new System.Drawing.Size(217, 22);
      this.m_toolCopy.Text = "Copy";
      this.m_toolCopy.Click += new System.EventHandler(this.OnCopyMenuItemClick);
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(214, 6);
      // 
      // m_toolFilterFromCurrentRow
      // 
      this.m_toolFilterFromCurrentRow.Name = "m_toolFilterFromCurrentRow";
      this.m_toolFilterFromCurrentRow.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D1)));
      this.m_toolFilterFromCurrentRow.Size = new System.Drawing.Size(217, 22);
      this.m_toolFilterFromCurrentRow.Text = "Filter from current row";
      this.m_toolFilterFromCurrentRow.Click += new System.EventHandler(this.OnFilterFromCurrentRow);
      // 
      // m_toolFilterFailedRows
      // 
      this.m_toolFilterFailedRows.Name = "m_toolFilterFailedRows";
      this.m_toolFilterFailedRows.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D2)));
      this.m_toolFilterFailedRows.Size = new System.Drawing.Size(217, 22);
      this.m_toolFilterFailedRows.Text = "Filter failed frecs";
      this.m_toolFilterFailedRows.Click += new System.EventHandler(this.OnFilterFailedRows);
      // 
      // m_toolMenuFilterBy
      // 
      this.m_toolMenuFilterBy.Name = "m_toolMenuFilterBy";
      this.m_toolMenuFilterBy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D3)));
      this.m_toolMenuFilterBy.Size = new System.Drawing.Size(217, 22);
      this.m_toolMenuFilterBy.Text = "Filter by ...";
      this.m_toolMenuFilterBy.Click += new System.EventHandler(this.OnMenuFilterByClick);
      // 
      // m_toolClearFilter
      // 
      this.m_toolClearFilter.Name = "m_toolClearFilter";
      this.m_toolClearFilter.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
      this.m_toolClearFilter.Size = new System.Drawing.Size(217, 22);
      this.m_toolClearFilter.Text = "Clear filter";
      this.m_toolClearFilter.Click += new System.EventHandler(this.OnClearFilter);
      // 
      // toolStripSeparator4
      // 
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new System.Drawing.Size(214, 6);
      // 
      // m_toolOpen
      // 
      this.m_toolOpen.Image = global::WebGateLogger.Properties.Resources.control_panel;
      this.m_toolOpen.Name = "m_toolOpen";
      this.m_toolOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
      this.m_toolOpen.Size = new System.Drawing.Size(217, 22);
      this.m_toolOpen.Text = "Open columns settings";
      this.m_toolOpen.Click += new System.EventHandler(this.OnOpenColumnsSettingsMenuItemClick);
      // 
      // toolStripSeparator7
      // 
      this.toolStripSeparator7.Name = "toolStripSeparator7";
      this.toolStripSeparator7.Size = new System.Drawing.Size(214, 6);
      // 
      // m_toolExit
      // 
      this.m_toolExit.Image = global::WebGateLogger.Properties.Resources.Exit;
      this.m_toolExit.Name = "m_toolExit";
      this.m_toolExit.Size = new System.Drawing.Size(217, 22);
      this.m_toolExit.Text = "Exit";
      this.m_toolExit.Click += new System.EventHandler(this.OnBtnCloseClick);
      // 
      // m_tabAdditionalData
      // 
      this.m_tabAdditionalData.Controls.Add(this.m_tabIds);
      this.m_tabAdditionalData.Controls.Add(this.m_tabConnectionInfo);
      this.m_tabAdditionalData.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_tabAdditionalData.Location = new System.Drawing.Point(0, 0);
      this.m_tabAdditionalData.Name = "m_tabAdditionalData";
      this.m_tabAdditionalData.SelectedIndex = 0;
      this.m_tabAdditionalData.Size = new System.Drawing.Size(346, 169);
      this.m_tabAdditionalData.TabIndex = 1;
      // 
      // m_tabIds
      // 
      this.m_tabIds.Controls.Add(this.m_idsGrid);
      this.m_tabIds.Controls.Add(this.m_txtIdsCount);
      this.m_tabIds.Location = new System.Drawing.Point(4, 22);
      this.m_tabIds.Name = "m_tabIds";
      this.m_tabIds.Padding = new System.Windows.Forms.Padding(3);
      this.m_tabIds.Size = new System.Drawing.Size(338, 143);
      this.m_tabIds.TabIndex = 0;
      this.m_tabIds.Text = "Ids";
      this.m_tabIds.UseVisualStyleBackColor = true;
      this.m_tabIds.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
      this.m_tabIds.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
      // 
      // m_idsGrid
      // 
      this.m_idsGrid.AllowUserToAddRows = false;
      this.m_idsGrid.AllowUserToDeleteRows = false;
      this.m_idsGrid.AllowUserToResizeRows = false;
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.m_idsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
      this.m_idsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.m_idsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmTable,
            this.clmId});
      this.m_idsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_idsGrid.Location = new System.Drawing.Point(3, 3);
      this.m_idsGrid.MultiSelect = false;
      this.m_idsGrid.Name = "m_idsGrid";
      this.m_idsGrid.ReadOnly = true;
      this.m_idsGrid.RowHeadersVisible = false;
      this.m_idsGrid.Size = new System.Drawing.Size(332, 117);
      this.m_idsGrid.TabIndex = 0;
      this.m_idsGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnGridResponceIdCellClick);
      // 
      // clmTable
      // 
      this.clmTable.DataPropertyName = "Title";
      this.clmTable.HeaderText = "Title";
      this.clmTable.Name = "clmTable";
      this.clmTable.ReadOnly = true;
      this.clmTable.Width = 150;
      // 
      // clmId
      // 
      this.clmId.DataPropertyName = "Bookmark";
      this.clmId.HeaderText = "Bookmark";
      this.clmId.Name = "clmId";
      this.clmId.ReadOnly = true;
      this.clmId.Width = 160;
      // 
      // m_txtIdsCount
      // 
      this.m_txtIdsCount.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.m_txtIdsCount.Location = new System.Drawing.Point(3, 120);
      this.m_txtIdsCount.Name = "m_txtIdsCount";
      this.m_txtIdsCount.ReadOnly = true;
      this.m_txtIdsCount.Size = new System.Drawing.Size(332, 20);
      this.m_txtIdsCount.TabIndex = 1;
      // 
      // m_tabConnectionInfo
      // 
      this.m_tabConnectionInfo.Controls.Add(this.m_gridConnectionInfo);
      this.m_tabConnectionInfo.Location = new System.Drawing.Point(4, 22);
      this.m_tabConnectionInfo.Name = "m_tabConnectionInfo";
      this.m_tabConnectionInfo.Padding = new System.Windows.Forms.Padding(3);
      this.m_tabConnectionInfo.Size = new System.Drawing.Size(338, 143);
      this.m_tabConnectionInfo.TabIndex = 1;
      this.m_tabConnectionInfo.Text = "File info";
      this.m_tabConnectionInfo.UseVisualStyleBackColor = true;
      // 
      // m_gridConnectionInfo
      // 
      this.m_gridConnectionInfo.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_gridConnectionInfo.HelpVisible = false;
      this.m_gridConnectionInfo.Location = new System.Drawing.Point(3, 3);
      this.m_gridConnectionInfo.Name = "m_gridConnectionInfo";
      this.m_gridConnectionInfo.Size = new System.Drawing.Size(332, 137);
      this.m_gridConnectionInfo.TabIndex = 0;
      this.m_gridConnectionInfo.ToolbarVisible = false;
      // 
      // m_mvcManager
      // 
      this.m_mvcManager.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_mvcManager.Location = new System.Drawing.Point(0, 0);
      this.m_mvcManager.Name = "m_mvcManager";
      this.m_mvcManager.SelectedIndex = 0;
      this.m_mvcManager.Size = new System.Drawing.Size(611, 536);
      this.m_mvcManager.TabIndex = 0;
      this.m_mvcManager.Text = "mvcManager1";
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.ClientSize = new System.Drawing.Size(967, 596);
      this.Controls.Add(this.m_splitMainPanel);
      this.Controls.Add(this.m_menu);
      this.Controls.Add(this.m_statusStrip);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Web Gate Logger";
      this.Load += new System.EventHandler(this.OnLoad);
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
      this.m_statusStrip.ResumeLayout(false);
      this.m_statusStrip.PerformLayout();
      this.m_menu.ResumeLayout(false);
      this.m_menu.PerformLayout();
      this.m_splitMainPanel.Panel1.ResumeLayout(false);
      this.m_splitMainPanel.Panel2.ResumeLayout(false);
      this.m_splitMainPanel.ResumeLayout(false);
      this.m_splitLeftPanel.Panel1.ResumeLayout(false);
      this.m_splitLeftPanel.Panel2.ResumeLayout(false);
      this.m_splitLeftPanel.ResumeLayout(false);
      this.m_filterGridControlContextMenu.ResumeLayout(false);
      this.m_tabAdditionalData.ResumeLayout(false);
      this.m_tabIds.ResumeLayout(false);
      this.m_tabIds.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.m_idsGrid)).EndInit();
      this.m_tabConnectionInfo.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.StatusStrip m_statusStrip;
    private System.Windows.Forms.ToolStripStatusLabel m_txtStatus;
    private System.Windows.Forms.ToolStripButton m_btnRefresh;
    private System.Windows.Forms.ToolStripButton m_btnSpecificLog;
    private System.Windows.Forms.ToolStripButton m_btnTop;
    private System.Windows.Forms.ToolStripButton m_btnBottom;
    private System.Windows.Forms.ToolStrip m_menu;
    private System.Windows.Forms.SplitContainer m_splitMainPanel;
    private System.Windows.Forms.SplitContainer m_splitLeftPanel;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripButton m_btnLoadedSource;
    private System.Windows.Forms.ToolStripButton m_btnOptions;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    private System.Windows.Forms.ToolStripButton m_btnAutoRefresh;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripButton m_btnPrevFile;
    private System.Windows.Forms.ToolStripButton m_btnNextFile;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
    private System.Windows.Forms.DataGridView m_idsGrid;
    private LogComponents.FilterControl.FilterGridControl m_filterGridControl;
    private System.Windows.Forms.DataGridViewTextBoxColumn clmTable;
    private System.Windows.Forms.DataGridViewTextBoxColumn clmId;
    private System.Windows.Forms.ContextMenuStrip m_filterGridControlContextMenu;
    private System.Windows.Forms.ToolStripMenuItem m_toolFilterFromCurrentRow;
    private System.Windows.Forms.ToolStripMenuItem m_toolClearFilter;
    private System.Windows.Forms.ToolStripMenuItem m_toolCopy;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    private System.Windows.Forms.ToolStripMenuItem m_toolOpen;
    private System.Windows.Forms.ToolStripMenuItem m_toolMenuFilterBy;
    private System.Windows.Forms.TabControl m_tabAdditionalData;
    private System.Windows.Forms.TabPage m_tabIds;
    private System.Windows.Forms.TabPage m_tabConnectionInfo;
    private LogComponents.Controls.CustomPropertyGrid m_gridConnectionInfo;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
    private System.Windows.Forms.ToolStripMenuItem m_toolExit;
    private System.Windows.Forms.TextBox m_txtIdsCount;
    private LogComponents.MVC.MvcManager m_mvcManager;
    private System.Windows.Forms.ToolStripMenuItem m_toolFilterFailedRows;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    private System.Windows.Forms.ToolStripComboBox m_cmbRefreshLock;
  }
}

