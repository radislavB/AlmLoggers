namespace LogComponents.Controls
{
  partial class ColumnsUserControl
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.clmTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.clmVisible = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.m_btnDown = new System.Windows.Forms.Button();
      this.m_btnUp = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      this.SuspendLayout();
      // 
      // dataGridView1
      // 
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.AllowUserToOrderColumns = true;
      this.dataGridView1.AllowUserToResizeRows = false;
      this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmTitle,
            this.clmVisible});
      this.dataGridView1.Location = new System.Drawing.Point(3, 3);
      this.dataGridView1.MultiSelect = false;
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.RowHeadersVisible = false;
      this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new System.Drawing.Size(305, 223);
      this.dataGridView1.TabIndex = 6;
      this.dataGridView1.SelectionChanged += new System.EventHandler(this.OnSelectionChanged);
      this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnVisibilityCellContentClick);
      // 
      // clmTitle
      // 
      this.clmTitle.DataPropertyName = "Title";
      this.clmTitle.HeaderText = "Title";
      this.clmTitle.Name = "clmTitle";
      this.clmTitle.ReadOnly = true;
      this.clmTitle.Width = 200;
      // 
      // clmVisible
      // 
      this.clmVisible.DataPropertyName = "Visible";
      this.clmVisible.FalseValue = "false";
      this.clmVisible.HeaderText = "Visible";
      this.clmVisible.IndeterminateValue = "";
      this.clmVisible.Name = "clmVisible";
      this.clmVisible.TrueValue = "true";
      // 
      // m_btnDown
      // 
      this.m_btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.m_btnDown.Location = new System.Drawing.Point(314, 105);
      this.m_btnDown.Name = "m_btnDown";
      this.m_btnDown.Size = new System.Drawing.Size(75, 35);
      this.m_btnDown.TabIndex = 5;
      this.m_btnDown.Text = "Down";
      this.m_btnDown.UseVisualStyleBackColor = true;
      this.m_btnDown.Click += new System.EventHandler(this.OnBtnDownClick);
      // 
      // m_btnUp
      // 
      this.m_btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.m_btnUp.Location = new System.Drawing.Point(314, 48);
      this.m_btnUp.Name = "m_btnUp";
      this.m_btnUp.Size = new System.Drawing.Size(75, 35);
      this.m_btnUp.TabIndex = 4;
      this.m_btnUp.Text = "Up";
      this.m_btnUp.UseVisualStyleBackColor = true;
      this.m_btnUp.Click += new System.EventHandler(this.OnBtnUpClick);
      // 
      // ColumnsUserControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.dataGridView1);
      this.Controls.Add(this.m_btnDown);
      this.Controls.Add(this.m_btnUp);
      this.Name = "ColumnsUserControl";
      this.Size = new System.Drawing.Size(392, 229);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.DataGridViewTextBoxColumn clmTitle;
    private System.Windows.Forms.DataGridViewCheckBoxColumn clmVisible;
    private System.Windows.Forms.Button m_btnDown;
    private System.Windows.Forms.Button m_btnUp;

  }
}
