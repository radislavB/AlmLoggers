namespace WebGateLogger
{
  partial class RawFrecDialog
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
      this.webBrowser1 = new System.Windows.Forms.WebBrowser();
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.m_btnNextFrec = new System.Windows.Forms.ToolStripButton();
      this.m_btnPrevFrec = new System.Windows.Forms.ToolStripButton();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.clmField = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.clmValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.toolStrip1.SuspendLayout();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      this.SuspendLayout();
      // 
      // webBrowser1
      // 
      this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.webBrowser1.Location = new System.Drawing.Point(3, 3);
      this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
      this.webBrowser1.Name = "webBrowser1";
      this.webBrowser1.Size = new System.Drawing.Size(527, 386);
      this.webBrowser1.TabIndex = 0;
      // 
      // toolStrip1
      // 
      this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_btnNextFrec,
            this.m_btnPrevFrec});
      this.toolStrip1.Location = new System.Drawing.Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
      this.toolStrip1.Size = new System.Drawing.Size(541, 31);
      this.toolStrip1.TabIndex = 1;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // m_btnNextFrec
      // 
      this.m_btnNextFrec.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.m_btnNextFrec.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.m_btnNextFrec.Image = global::WebGateLogger.Properties.Resources.nav_right_blue;
      this.m_btnNextFrec.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.m_btnNextFrec.Name = "m_btnNextFrec";
      this.m_btnNextFrec.Size = new System.Drawing.Size(28, 28);
      this.m_btnNextFrec.Text = "Next frec";
      this.m_btnNextFrec.Click += new System.EventHandler(this.OnNavigationButtonClick);
      // 
      // m_btnPrevFrec
      // 
      this.m_btnPrevFrec.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.m_btnPrevFrec.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.m_btnPrevFrec.Image = global::WebGateLogger.Properties.Resources.nav_left_blue;
      this.m_btnPrevFrec.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.m_btnPrevFrec.Name = "m_btnPrevFrec";
      this.m_btnPrevFrec.Size = new System.Drawing.Size(28, 28);
      this.m_btnPrevFrec.Text = "Previous frec";
      this.m_btnPrevFrec.Click += new System.EventHandler(this.OnNavigationButtonClick);
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl1.Location = new System.Drawing.Point(0, 31);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(541, 418);
      this.tabControl1.TabIndex = 2;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.webBrowser1);
      this.tabPage1.Location = new System.Drawing.Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(533, 392);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Raw frec";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.dataGridView1);
      this.tabPage2.Location = new System.Drawing.Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(533, 392);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "QC Sense performance data";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // dataGridView1
      // 
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmField,
            this.clmValue});
      this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGridView1.Location = new System.Drawing.Point(3, 3);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.Size = new System.Drawing.Size(527, 386);
      this.dataGridView1.TabIndex = 0;
      // 
      // clmField
      // 
      this.clmField.HeaderText = "Field";
      this.clmField.Name = "clmField";
      this.clmField.ReadOnly = true;
      this.clmField.Width = 130;
      // 
      // clmValue
      // 
      this.clmValue.HeaderText = "Value";
      this.clmValue.Name = "clmValue";
      this.clmValue.ReadOnly = true;
      this.clmValue.Width = 250;
      // 
      // RawFrecDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(541, 449);
      this.Controls.Add(this.tabControl1);
      this.Controls.Add(this.toolStrip1);
      this.KeyPreview = true;
      this.MinimizeBox = false;
      this.Name = "RawFrecDialog";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Frec additional data";
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.WebBrowser webBrowser1;
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton m_btnPrevFrec;
    private System.Windows.Forms.ToolStripButton m_btnNextFrec;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.DataGridViewTextBoxColumn clmField;
    private System.Windows.Forms.DataGridViewTextBoxColumn clmValue;
  }
}