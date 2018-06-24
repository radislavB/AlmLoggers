namespace ServerLogger.Mvc
{
  partial class PlainViewControl
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
      this.m_filterGridControl = new LogComponents.FilterControl.FilterGridControl();
      this.m_contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.m_cmdCopyRequest = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.m_cmdGotoIdRequest = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
      this.m_cmdFilterBy = new System.Windows.Forms.ToolStripMenuItem();
      this.m_cmdClearFilterRequest = new System.Windows.Forms.ToolStripMenuItem();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.m_txtMessage = new ServerLogger.Mvc.MessageTextBox(this.components);
      this.m_contextMenu.SuspendLayout();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.SuspendLayout();
      // 
      // m_filterGridControl
      // 
      this.m_filterGridControl.BackColorDelegate = null;
      this.m_filterGridControl.ContextMenuStrip = this.m_contextMenu;
      this.m_filterGridControl.DataSource = null;
      this.m_filterGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_filterGridControl.FilterConfig = filterConfig1;
      this.m_filterGridControl.FilterText = "";
      this.m_filterGridControl.FocusedIndex = -1;
      this.m_filterGridControl.GridBackgroundColor = System.Drawing.SystemColors.AppWorkspace;
      this.m_filterGridControl.GridContextMenu = null;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.m_filterGridControl.GridDefaultCellStyle = dataGridViewCellStyle1;
      this.m_filterGridControl.ImageStatusDelegate = null;
      this.m_filterGridControl.Location = new System.Drawing.Point(0, 0);
      this.m_filterGridControl.Name = "m_filterGridControl";
      this.m_filterGridControl.Size = new System.Drawing.Size(419, 236);
      this.m_filterGridControl.TabIndex = 1;
      // 
      // m_contextMenu
      // 
      this.m_contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_cmdCopyRequest,
            this.toolStripSeparator1,
            this.m_cmdGotoIdRequest,
            this.toolStripSeparator10,
            this.m_cmdFilterBy,
            this.m_cmdClearFilterRequest});
      this.m_contextMenu.Name = "contextMenuStripGrid";
      this.m_contextMenu.Size = new System.Drawing.Size(153, 126);
      this.m_contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.OnContextMenuOpening);
      // 
      // m_cmdCopyRequest
      // 
      this.m_cmdCopyRequest.Name = "m_cmdCopyRequest";
      this.m_cmdCopyRequest.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
      this.m_cmdCopyRequest.Size = new System.Drawing.Size(152, 22);
      this.m_cmdCopyRequest.Text = "Copy";
      this.m_cmdCopyRequest.Click += new System.EventHandler(this.OnCmdCopyClick);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
      // 
      // m_cmdGotoIdRequest
      // 
      this.m_cmdGotoIdRequest.Name = "m_cmdGotoIdRequest";
      this.m_cmdGotoIdRequest.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.G)));
      this.m_cmdGotoIdRequest.Size = new System.Drawing.Size(152, 22);
      this.m_cmdGotoIdRequest.Text = "Go to Id";
      // 
      // toolStripSeparator10
      // 
      this.toolStripSeparator10.Name = "toolStripSeparator10";
      this.toolStripSeparator10.Size = new System.Drawing.Size(149, 6);
      // 
      // m_cmdFilterBy
      // 
      this.m_cmdFilterBy.Name = "m_cmdFilterBy";
      this.m_cmdFilterBy.Size = new System.Drawing.Size(152, 22);
      this.m_cmdFilterBy.Text = "Filter by value";
      this.m_cmdFilterBy.Click += new System.EventHandler(this.OnCmdFilterByClick);
      // 
      // m_cmdClearFilterRequest
      // 
      this.m_cmdClearFilterRequest.Name = "m_cmdClearFilterRequest";
      this.m_cmdClearFilterRequest.Size = new System.Drawing.Size(152, 22);
      this.m_cmdClearFilterRequest.Text = "Clear filter";
      this.m_cmdClearFilterRequest.Click += new System.EventHandler(this.OnCmdClearFilterClick);
      // 
      // splitContainer1
      // 
      this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(0, 0);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.m_filterGridControl);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.m_txtMessage);
      this.splitContainer1.Size = new System.Drawing.Size(423, 315);
      this.splitContainer1.SplitterDistance = 240;
      this.splitContainer1.SplitterWidth = 2;
      this.splitContainer1.TabIndex = 2;
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
      this.m_txtMessage.Size = new System.Drawing.Size(419, 69);
      this.m_txtMessage.TabIndex = 31;
      this.m_txtMessage.Text = "";
      // 
      // PlainViewControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.splitContainer1);
      this.Name = "PlainViewControl";
      this.Size = new System.Drawing.Size(423, 315);
      this.m_contextMenu.ResumeLayout(false);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private LogComponents.FilterControl.FilterGridControl m_filterGridControl;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private MessageTextBox m_txtMessage;
    private System.Windows.Forms.ContextMenuStrip m_contextMenu;
    private System.Windows.Forms.ToolStripMenuItem m_cmdCopyRequest;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem m_cmdGotoIdRequest;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
    private System.Windows.Forms.ToolStripMenuItem m_cmdFilterBy;
    private System.Windows.Forms.ToolStripMenuItem m_cmdClearFilterRequest;
  }
}
