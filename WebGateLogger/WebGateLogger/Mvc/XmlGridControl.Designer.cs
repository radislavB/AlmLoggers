namespace WebGateLogger.Mvc
{
  partial class XmlGridControl
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
      this.m_btnFind = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      this.label1 = new System.Windows.Forms.Label();
      this.m_lstBox = new System.Windows.Forms.ListBox();
      this.m_txtFind = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.m_txtCount = new System.Windows.Forms.TextBox();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      this.SuspendLayout();
      // 
      // m_btnFind
      // 
      this.m_btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.m_btnFind.Enabled = false;
      this.m_btnFind.Location = new System.Drawing.Point(404, 12);
      this.m_btnFind.Name = "m_btnFind";
      this.m_btnFind.Size = new System.Drawing.Size(75, 23);
      this.m_btnFind.TabIndex = 5;
      this.m_btnFind.Text = "Find";
      this.m_btnFind.UseVisualStyleBackColor = true;
      this.m_btnFind.Click += new System.EventHandler(this.OnBtnFindClick);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.m_lstBox);
      this.panel1.Controls.Add(this.m_btnFind);
      this.panel1.Controls.Add(this.m_txtFind);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(489, 112);
      this.panel1.TabIndex = 3;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(2, 47);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(48, 13);
      this.label1.TabIndex = 6;
      this.label1.Text = "Tables : ";
      // 
      // m_lstBox
      // 
      this.m_lstBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.m_lstBox.FormattingEnabled = true;
      this.m_lstBox.Location = new System.Drawing.Point(50, 47);
      this.m_lstBox.Name = "m_lstBox";
      this.m_lstBox.Size = new System.Drawing.Size(348, 56);
      this.m_lstBox.TabIndex = 0;
      this.m_lstBox.SelectedIndexChanged += new System.EventHandler(this.OnSelectedIndexChanged);
      // 
      // m_txtFind
      // 
      this.m_txtFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.m_txtFind.Location = new System.Drawing.Point(50, 14);
      this.m_txtFind.Name = "m_txtFind";
      this.m_txtFind.Size = new System.Drawing.Size(348, 20);
      this.m_txtFind.TabIndex = 4;
      this.m_txtFind.TextChanged += new System.EventHandler(this.OnTxtFind_TextChanged);
      this.m_txtFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnTxtFindKeyDown);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(11, 17);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(36, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Find : ";
      // 
      // dataGridView1
      // 
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
      this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
      this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGridView1.Location = new System.Drawing.Point(0, 112);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.Size = new System.Drawing.Size(489, 215);
      this.dataGridView1.TabIndex = 0;
      this.dataGridView1.DataSourceChanged += new System.EventHandler(this.OnDataGridViewDataSourceChanged);
      // 
      // m_txtCount
      // 
      this.m_txtCount.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.m_txtCount.Location = new System.Drawing.Point(0, 327);
      this.m_txtCount.Name = "m_txtCount";
      this.m_txtCount.ReadOnly = true;
      this.m_txtCount.Size = new System.Drawing.Size(489, 20);
      this.m_txtCount.TabIndex = 4;
      // 
      // XmlGridControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.dataGridView1);
      this.Controls.Add(this.m_txtCount);
      this.Controls.Add(this.panel1);
      this.Name = "XmlGridControl";
      this.Size = new System.Drawing.Size(489, 347);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button m_btnFind;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.TextBox m_txtFind;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.ListBox m_lstBox;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox m_txtCount;

  }
}
