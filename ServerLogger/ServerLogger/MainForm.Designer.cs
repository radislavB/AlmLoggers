
namespace ServerLogger
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.m_txtStatus = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.m_btnLastFile = new System.Windows.Forms.ToolStripButton();
      this.m_btnLoadFile = new System.Windows.Forms.ToolStripButton();
      this.m_loadFolder = new System.Windows.Forms.ToolStripButton();
      this.m_btnSourceFile = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.m_btnOptions = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
      this.m_btnNextFile = new System.Windows.Forms.ToolStripButton();
      this.m_btnPrevFile = new System.Windows.Forms.ToolStripButton();
      this.m_mainMvcManager = new LogComponents.MVC.MvcManager();
      this.statusStrip1.SuspendLayout();
      this.toolStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_txtStatus});
      this.statusStrip1.Location = new System.Drawing.Point(3, 551);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(856, 22);
      this.statusStrip1.SizingGrip = false;
      this.statusStrip1.TabIndex = 28;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // m_txtStatus
      // 
      this.m_txtStatus.Name = "m_txtStatus";
      this.m_txtStatus.Size = new System.Drawing.Size(841, 17);
      this.m_txtStatus.Spring = true;
      this.m_txtStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // toolStrip1
      // 
      this.toolStrip1.AllowDrop = true;
      this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_btnLastFile,
            this.m_btnLoadFile,
            this.m_loadFolder,
            this.m_btnSourceFile,
            this.toolStripSeparator2,
            this.m_btnOptions,
            this.toolStripSeparator6,
            this.m_btnNextFile,
            this.m_btnPrevFile});
      this.toolStrip1.Location = new System.Drawing.Point(3, 3);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
      this.toolStrip1.Size = new System.Drawing.Size(856, 31);
      this.toolStrip1.TabIndex = 29;
      this.toolStrip1.Text = "Filter";
      // 
      // m_btnLastFile
      // 
      this.m_btnLastFile.Image = global::ServerLogger.Properties.Resources.data;
      this.m_btnLastFile.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.m_btnLastFile.Name = "m_btnLastFile";
      this.m_btnLastFile.Size = new System.Drawing.Size(72, 28);
      this.m_btnLastFile.Text = "Last file";
      this.m_btnLastFile.ToolTipText = "Last file from lastly opened directory";
      this.m_btnLastFile.Click += new System.EventHandler(this.OnBtnLastFileClick);
      // 
      // m_btnLoadFile
      // 
      this.m_btnLoadFile.Image = global::ServerLogger.Properties.Resources.data_into;
      this.m_btnLoadFile.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.m_btnLoadFile.Name = "m_btnLoadFile";
      this.m_btnLoadFile.Size = new System.Drawing.Size(80, 28);
      this.m_btnLoadFile.Text = "Load files";
      this.m_btnLoadFile.Click += new System.EventHandler(this.OnBtnLoadFileClick);
      // 
      // m_loadFolder
      // 
      this.m_loadFolder.Image = global::ServerLogger.Properties.Resources.server_into;
      this.m_loadFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.m_loadFolder.Name = "m_loadFolder";
      this.m_loadFolder.Size = new System.Drawing.Size(89, 28);
      this.m_loadFolder.Text = "Load folder";
      this.m_loadFolder.Click += new System.EventHandler(this.OnBtnLoadFolderClick);
      // 
      // m_btnSourceFile
      // 
      this.m_btnSourceFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.m_btnSourceFile.Enabled = false;
      this.m_btnSourceFile.Image = global::ServerLogger.Properties.Resources.document_notebook;
      this.m_btnSourceFile.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.m_btnSourceFile.Name = "m_btnSourceFile";
      this.m_btnSourceFile.Size = new System.Drawing.Size(28, 28);
      this.m_btnSourceFile.Text = "Source file";
      this.m_btnSourceFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.m_btnSourceFile.Click += new System.EventHandler(this.OnBtnSourceFileClick);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
      // 
      // m_btnOptions
      // 
      this.m_btnOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.m_btnOptions.Image = global::ServerLogger.Properties.Resources.control_panel;
      this.m_btnOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.m_btnOptions.Name = "m_btnOptions";
      this.m_btnOptions.Size = new System.Drawing.Size(28, 28);
      this.m_btnOptions.Text = "Configuration";
      this.m_btnOptions.Click += new System.EventHandler(this.OnBtnOptionsClick);
      // 
      // toolStripSeparator6
      // 
      this.toolStripSeparator6.Name = "toolStripSeparator6";
      this.toolStripSeparator6.Size = new System.Drawing.Size(6, 31);
      // 
      // m_btnNextFile
      // 
      this.m_btnNextFile.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.m_btnNextFile.Enabled = false;
      this.m_btnNextFile.Image = global::ServerLogger.Properties.Resources.nav_right_blue;
      this.m_btnNextFile.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.m_btnNextFile.Name = "m_btnNextFile";
      this.m_btnNextFile.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.m_btnNextFile.Size = new System.Drawing.Size(28, 28);
      this.m_btnNextFile.Click += new System.EventHandler(this.OnBtnPrevNextClick);
      // 
      // m_btnPrevFile
      // 
      this.m_btnPrevFile.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.m_btnPrevFile.Enabled = false;
      this.m_btnPrevFile.Image = global::ServerLogger.Properties.Resources.nav_left_blue;
      this.m_btnPrevFile.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.m_btnPrevFile.Name = "m_btnPrevFile";
      this.m_btnPrevFile.Size = new System.Drawing.Size(28, 28);
      this.m_btnPrevFile.Click += new System.EventHandler(this.OnBtnPrevNextClick);
      // 
      // m_mainMvcManager
      // 
      this.m_mainMvcManager.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_mainMvcManager.Location = new System.Drawing.Point(3, 34);
      this.m_mainMvcManager.Name = "m_mainMvcManager";
      this.m_mainMvcManager.SelectedIndex = 0;
      this.m_mainMvcManager.Size = new System.Drawing.Size(856, 517);
      this.m_mainMvcManager.TabIndex = 30;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(862, 576);
      this.Controls.Add(this.m_mainMvcManager);
      this.Controls.Add(this.toolStrip1);
      this.Controls.Add(this.statusStrip1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "MainForm";
      this.Padding = new System.Windows.Forms.Padding(3);
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Server logger";
      this.Load += new System.EventHandler(this.OnLoad);
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton m_btnPrevFile;
    private System.Windows.Forms.ToolStripButton m_btnNextFile;
    private System.Windows.Forms.ToolStripButton m_btnSourceFile;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripButton m_btnLastFile;
    private System.Windows.Forms.ToolStripButton m_btnOptions;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    private System.Windows.Forms.ToolStripButton m_btnLoadFile;
    private System.Windows.Forms.ToolStripButton m_loadFolder;
    private System.Windows.Forms.ToolStripStatusLabel m_txtStatus;
    private LogComponents.MVC.MvcManager m_mainMvcManager;
  }
}

