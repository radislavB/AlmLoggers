namespace WebGateLogger.Mvc
{
  partial class QcSensePerformanceControl
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
      this.dataGridView1 = new LogComponents.FilterControl.DataGridView();
      this.clmProperty = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.clmValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      this.SuspendLayout();
      // 
      // dataGridView1
      // 
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.AllowUserToResizeRows = false;
      this.dataGridView1.BackColorDelegate = null;
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmProperty,
            this.clmValue});
      this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGridView1.FocusedIndex = -1;
      this.dataGridView1.ImageStatusDelegate = null;
      this.dataGridView1.Location = new System.Drawing.Point(0, 0);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.RowHeadersWidth = 25;
      this.dataGridView1.Size = new System.Drawing.Size(551, 191);
      this.dataGridView1.TabIndex = 0;
      // 
      // clmProperty
      // 
      this.clmProperty.HeaderText = "Property";
      this.clmProperty.Name = "clmProperty";
      this.clmProperty.ReadOnly = true;
      this.clmProperty.Width = 150;
      // 
      // clmValue
      // 
      this.clmValue.HeaderText = "Value";
      this.clmValue.Name = "clmValue";
      this.clmValue.ReadOnly = true;
      this.clmValue.Width = 300;
      // 
      // QcSensePerformanceControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.dataGridView1);
      this.Name = "QcSensePerformanceControl";
      this.Size = new System.Drawing.Size(551, 191);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private LogComponents.FilterControl.DataGridView dataGridView1;
    private System.Windows.Forms.DataGridViewTextBoxColumn clmProperty;
    private System.Windows.Forms.DataGridViewTextBoxColumn clmValue;
  }
}
