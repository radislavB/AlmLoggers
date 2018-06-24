namespace ServerLogger.Mvc
{
  partial class GroupByRequestControl
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      LogComponents.FilterControl.FilterConfig filterConfig1 = new LogComponents.FilterControl.FilterConfig();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      LogComponents.FilterControl.FilterConfig filterConfig2 = new LogComponents.FilterControl.FilterConfig();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      this.m_mainSplit = new System.Windows.Forms.SplitContainer();
      this.m_requestFilterGrid = new LogComponents.FilterControl.FilterGridControl();
      this.m_requestContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.m_cmdCopyRequest = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.m_cmdColumnsRequest = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
      this.m_cmdGotoIdRequest = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
      this.m_cmdFilterBy = new System.Windows.Forms.ToolStripMenuItem();
      this.m_cmdClearFilterRequest = new System.Windows.Forms.ToolStripMenuItem();
      this.m_rightSplit = new System.Windows.Forms.SplitContainer();
      this.m_subRequestFilterGrid = new LogComponents.FilterControl.FilterGridControl();
      this.m_rowContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.m_cmdCopyRow = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.m_cmdColumnsRow = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
      this.m_cmdGotoIndexRow = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
      this.m_cmdFilterBy1 = new System.Windows.Forms.ToolStripMenuItem();
      this.m_cmdFilterBy2 = new System.Windows.Forms.ToolStripMenuItem();
      this.m_cmdClearFilterRow = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
      this.m_cmdSourceRow = new System.Windows.Forms.ToolStripMenuItem();
      this.m_txtMessage = new MessageTextBox();
      this.m_mainSplit.Panel1.SuspendLayout();
      this.m_mainSplit.Panel2.SuspendLayout();
      this.m_mainSplit.SuspendLayout();
      this.m_requestContextMenu.SuspendLayout();
      this.m_rightSplit.Panel1.SuspendLayout();
      this.m_rightSplit.Panel2.SuspendLayout();
      this.m_rightSplit.SuspendLayout();
      this.m_rowContextMenu.SuspendLayout();
      this.SuspendLayout();
      // 
      // m_mainSplit
      // 
      this.m_mainSplit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.m_mainSplit.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_mainSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
      this.m_mainSplit.Location = new System.Drawing.Point(0, 0);
      this.m_mainSplit.Name = "m_mainSplit";
      // 
      // m_mainSplit.Panel1
      // 
      this.m_mainSplit.Panel1.Controls.Add(this.m_requestFilterGrid);
      // 
      // m_mainSplit.Panel2
      // 
      this.m_mainSplit.Panel2.Controls.Add(this.m_rightSplit);
      this.m_mainSplit.Size = new System.Drawing.Size(631, 495);
      this.m_mainSplit.SplitterDistance = 347;
      this.m_mainSplit.SplitterWidth = 2;
      this.m_mainSplit.TabIndex = 33;
      // 
      // m_requestFilterGrid
      // 
      this.m_requestFilterGrid.BackColorDelegate = null;
      this.m_requestFilterGrid.ContextMenuStrip = this.m_requestContextMenu;
      this.m_requestFilterGrid.DataSource = null;
      this.m_requestFilterGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_requestFilterGrid.FilterConfig = filterConfig1;
      this.m_requestFilterGrid.FilterText = "";
      this.m_requestFilterGrid.FocusedIndex = -1;
      this.m_requestFilterGrid.GridBackgroundColor = System.Drawing.SystemColors.AppWorkspace;
      this.m_requestFilterGrid.GridContextMenu = null;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.m_requestFilterGrid.GridDefaultCellStyle = dataGridViewCellStyle1;
      this.m_requestFilterGrid.ImageStatusDelegate = null;
      this.m_requestFilterGrid.Location = new System.Drawing.Point(0, 0);
      this.m_requestFilterGrid.Name = "m_requestFilterGrid";
      this.m_requestFilterGrid.Size = new System.Drawing.Size(343, 491);
      this.m_requestFilterGrid.TabIndex = 0;
      this.m_requestFilterGrid.FilterChanged += new System.EventHandler<System.EventArgs>(this.OnRequestFilterGridFilterChanged);
      // 
      // m_requestContextMenu
      // 
      this.m_requestContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_cmdCopyRequest,
            this.toolStripSeparator1,
            this.m_cmdColumnsRequest,
            this.toolStripSeparator7,
            this.m_cmdGotoIdRequest,
            this.toolStripSeparator10,
            this.m_cmdFilterBy,
            this.m_cmdClearFilterRequest});
      this.m_requestContextMenu.Name = "contextMenuStripGrid";
      this.m_requestContextMenu.Size = new System.Drawing.Size(149, 132);
      this.m_requestContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.OnRequestContextMenuOpening);
      // 
      // m_cmdCopyRequest
      // 
      this.m_cmdCopyRequest.Name = "m_cmdCopyRequest";
      this.m_cmdCopyRequest.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
      this.m_cmdCopyRequest.Size = new System.Drawing.Size(148, 22);
      this.m_cmdCopyRequest.Text = "Copy";
      this.m_cmdCopyRequest.Click += new System.EventHandler(this.OnCmdCopyClick);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
      // 
      // m_cmdColumnsRequest
      // 
      this.m_cmdColumnsRequest.Name = "m_cmdColumnsRequest";
      this.m_cmdColumnsRequest.Size = new System.Drawing.Size(148, 22);
      this.m_cmdColumnsRequest.Text = "Columns";
      this.m_cmdColumnsRequest.Click += new System.EventHandler(this.OnCmdColumnsClick);
      // 
      // toolStripSeparator7
      // 
      this.toolStripSeparator7.Name = "toolStripSeparator7";
      this.toolStripSeparator7.Size = new System.Drawing.Size(145, 6);
      // 
      // m_cmdGotoIdRequest
      // 
      this.m_cmdGotoIdRequest.Name = "m_cmdGotoIdRequest";
      this.m_cmdGotoIdRequest.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.G)));
      this.m_cmdGotoIdRequest.Size = new System.Drawing.Size(148, 22);
      this.m_cmdGotoIdRequest.Text = "Go to Id";
      this.m_cmdGotoIdRequest.Click += new System.EventHandler(this.OnCmnGotoIndexClick);
      // 
      // toolStripSeparator10
      // 
      this.toolStripSeparator10.Name = "toolStripSeparator10";
      this.toolStripSeparator10.Size = new System.Drawing.Size(145, 6);
      // 
      // m_cmdFilterBy
      // 
      this.m_cmdFilterBy.Name = "m_cmdFilterBy";
      this.m_cmdFilterBy.Size = new System.Drawing.Size(148, 22);
      this.m_cmdFilterBy.Text = "Filter by value";
      this.m_cmdFilterBy.Click += new System.EventHandler(this.OnCmdFilterByClick);
      // 
      // m_cmdClearFilterRequest
      // 
      this.m_cmdClearFilterRequest.Name = "m_cmdClearFilterRequest";
      this.m_cmdClearFilterRequest.Size = new System.Drawing.Size(148, 22);
      this.m_cmdClearFilterRequest.Text = "Clear filter";
      this.m_cmdClearFilterRequest.Click += new System.EventHandler(this.OnCmdClearFilterClick);
      // 
      // m_rightSplit
      // 
      this.m_rightSplit.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_rightSplit.Location = new System.Drawing.Point(0, 0);
      this.m_rightSplit.Name = "m_rightSplit";
      this.m_rightSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // m_rightSplit.Panel1
      // 
      this.m_rightSplit.Panel1.Controls.Add(this.m_subRequestFilterGrid);
      // 
      // m_rightSplit.Panel2
      // 
      this.m_rightSplit.Panel2.Controls.Add(this.m_txtMessage);
      this.m_rightSplit.Size = new System.Drawing.Size(278, 491);
      this.m_rightSplit.SplitterDistance = 234;
      this.m_rightSplit.TabIndex = 0;
      // 
      // m_subRequestFilterGrid
      // 
      this.m_subRequestFilterGrid.BackColorDelegate = null;
      this.m_subRequestFilterGrid.ContextMenuStrip = this.m_rowContextMenu;
      this.m_subRequestFilterGrid.DataSource = null;
      this.m_subRequestFilterGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_subRequestFilterGrid.FilterConfig = filterConfig2;
      this.m_subRequestFilterGrid.FilterText = "";
      this.m_subRequestFilterGrid.FocusedIndex = -1;
      this.m_subRequestFilterGrid.GridBackgroundColor = System.Drawing.SystemColors.AppWorkspace;
      this.m_subRequestFilterGrid.GridContextMenu = null;
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
      dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.m_subRequestFilterGrid.GridDefaultCellStyle = dataGridViewCellStyle2;
      this.m_subRequestFilterGrid.ImageStatusDelegate = null;
      this.m_subRequestFilterGrid.Location = new System.Drawing.Point(0, 0);
      this.m_subRequestFilterGrid.Name = "m_subRequestFilterGrid";
      this.m_subRequestFilterGrid.Size = new System.Drawing.Size(278, 234);
      this.m_subRequestFilterGrid.TabIndex = 0;
      // 
      // m_rowContextMenu
      // 
      this.m_rowContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_cmdCopyRow,
            this.toolStripSeparator4,
            this.m_cmdColumnsRow,
            this.toolStripSeparator5,
            this.m_cmdGotoIndexRow,
            this.toolStripSeparator9,
            this.m_cmdFilterBy1,
            this.m_cmdFilterBy2,
            this.m_cmdClearFilterRow,
            this.toolStripSeparator8,
            this.m_cmdSourceRow});
      this.m_rowContextMenu.Name = "contextMenuStripGrid";
      this.m_rowContextMenu.Size = new System.Drawing.Size(179, 182);
      this.m_rowContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.OnRowContextMenuOpening);
      this.m_rowContextMenu.Click += new System.EventHandler(this.OnCmdCopyClick);
      // 
      // m_cmdCopyRow
      // 
      this.m_cmdCopyRow.Name = "m_cmdCopyRow";
      this.m_cmdCopyRow.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
      this.m_cmdCopyRow.Size = new System.Drawing.Size(178, 22);
      this.m_cmdCopyRow.Text = "Copy";
      // 
      // toolStripSeparator4
      // 
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new System.Drawing.Size(175, 6);
      // 
      // m_cmdColumnsRow
      // 
      this.m_cmdColumnsRow.Name = "m_cmdColumnsRow";
      this.m_cmdColumnsRow.Size = new System.Drawing.Size(178, 22);
      this.m_cmdColumnsRow.Text = "Columns";
      this.m_cmdColumnsRow.Click += new System.EventHandler(this.OnCmdColumnsClick);
      // 
      // toolStripSeparator5
      // 
      this.toolStripSeparator5.Name = "toolStripSeparator5";
      this.toolStripSeparator5.Size = new System.Drawing.Size(175, 6);
      // 
      // m_cmdGotoIndexRow
      // 
      this.m_cmdGotoIndexRow.Name = "m_cmdGotoIndexRow";
      this.m_cmdGotoIndexRow.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.G)));
      this.m_cmdGotoIndexRow.Size = new System.Drawing.Size(178, 22);
      this.m_cmdGotoIndexRow.Text = "Go to Id";
      this.m_cmdGotoIndexRow.Click += new System.EventHandler(this.OnCmnGotoIndexClick);
      // 
      // toolStripSeparator9
      // 
      this.toolStripSeparator9.Name = "toolStripSeparator9";
      this.toolStripSeparator9.Size = new System.Drawing.Size(175, 6);
      // 
      // m_cmdFilterBy1
      // 
      this.m_cmdFilterBy1.Name = "m_cmdFilterBy1";
      this.m_cmdFilterBy1.Size = new System.Drawing.Size(178, 22);
      this.m_cmdFilterBy1.Text = "Filter by 1";
      this.m_cmdFilterBy1.Click += new System.EventHandler(this.OnCmdFilterBy1Click);
      // 
      // m_cmdFilterBy2
      // 
      this.m_cmdFilterBy2.Name = "m_cmdFilterBy2";
      this.m_cmdFilterBy2.Size = new System.Drawing.Size(178, 22);
      this.m_cmdFilterBy2.Text = "Filter by 2";
      this.m_cmdFilterBy2.Click += new System.EventHandler(this.OnCmdFilterBy2Click);
      // 
      // m_cmdClearFilterRow
      // 
      this.m_cmdClearFilterRow.Name = "m_cmdClearFilterRow";
      this.m_cmdClearFilterRow.Size = new System.Drawing.Size(178, 22);
      this.m_cmdClearFilterRow.Text = "Clear filter";
      this.m_cmdClearFilterRow.Click += new System.EventHandler(this.OnCmdClearFilterClick);
      // 
      // toolStripSeparator8
      // 
      this.toolStripSeparator8.Name = "toolStripSeparator8";
      this.toolStripSeparator8.Size = new System.Drawing.Size(175, 6);
      // 
      // m_cmdSourceRow
      // 
      this.m_cmdSourceRow.Name = "m_cmdSourceRow";
      this.m_cmdSourceRow.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
      this.m_cmdSourceRow.Size = new System.Drawing.Size(178, 22);
      this.m_cmdSourceRow.Text = "Open  source";
      this.m_cmdSourceRow.Click += new System.EventHandler(this.OnCmnSourceRowClick);
      // 
      // m_txtMessage
      // 
      this.m_txtMessage.BackColor = System.Drawing.SystemColors.Control;
      this.m_txtMessage.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_txtMessage.EnableAutoDragDrop = true;
      this.m_txtMessage.HideSelection = false;
      this.m_txtMessage.Location = new System.Drawing.Point(0, 0);
      this.m_txtMessage.Name = "m_txtMessage";
      this.m_txtMessage.ReadOnly = true;
      this.m_txtMessage.Size = new System.Drawing.Size(278, 253);
      this.m_txtMessage.TabIndex = 30;
      this.m_txtMessage.Text = "";
      // 
      // GroupByRequestControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.m_mainSplit);
      this.Name = "GroupByRequestControl";
      this.Size = new System.Drawing.Size(631, 495);
      this.m_mainSplit.Panel1.ResumeLayout(false);
      this.m_mainSplit.Panel2.ResumeLayout(false);
      this.m_mainSplit.ResumeLayout(false);
      this.m_requestContextMenu.ResumeLayout(false);
      this.m_rightSplit.Panel1.ResumeLayout(false);
      this.m_rightSplit.Panel2.ResumeLayout(false);
      this.m_rightSplit.ResumeLayout(false);
      this.m_rowContextMenu.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.SplitContainer m_mainSplit;
    private LogComponents.FilterControl.FilterGridControl m_requestFilterGrid;
    private System.Windows.Forms.SplitContainer m_rightSplit;
    private LogComponents.FilterControl.FilterGridControl m_subRequestFilterGrid;
    private MessageTextBox m_txtMessage;
    private System.Windows.Forms.ContextMenuStrip m_requestContextMenu;
    private System.Windows.Forms.ToolStripMenuItem m_cmdCopyRequest;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem m_cmdColumnsRequest;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
    private System.Windows.Forms.ToolStripMenuItem m_cmdGotoIdRequest;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
    private System.Windows.Forms.ToolStripMenuItem m_cmdFilterBy;
    private System.Windows.Forms.ToolStripMenuItem m_cmdClearFilterRequest;
    private System.Windows.Forms.ContextMenuStrip m_rowContextMenu;
    private System.Windows.Forms.ToolStripMenuItem m_cmdCopyRow;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    private System.Windows.Forms.ToolStripMenuItem m_cmdColumnsRow;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    private System.Windows.Forms.ToolStripMenuItem m_cmdGotoIndexRow;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
    private System.Windows.Forms.ToolStripMenuItem m_cmdFilterBy1;
    private System.Windows.Forms.ToolStripMenuItem m_cmdFilterBy2;
    private System.Windows.Forms.ToolStripMenuItem m_cmdClearFilterRow;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
    private System.Windows.Forms.ToolStripMenuItem m_cmdSourceRow;

  }
}
