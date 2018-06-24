namespace LogComponents.FilterControl
{
  partial class FilterGridControl
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
      this.panel1 = new System.Windows.Forms.Panel();
      this.m_comboBox = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.m_txtStatus = new System.Windows.Forms.TextBox();
      this.m_grid = new LogComponents.FilterControl.DataGridView();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.m_grid)).BeginInit();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.m_comboBox);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
      this.panel1.Size = new System.Drawing.Size(193, 23);
      this.panel1.TabIndex = 0;
      // 
      // m_comboBox
      // 
      this.m_comboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.m_comboBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_comboBox.FormattingEnabled = true;
      this.m_comboBox.Location = new System.Drawing.Point(38, 1);
      this.m_comboBox.MaxDropDownItems = 15;
      this.m_comboBox.Name = "m_comboBox";
      this.m_comboBox.Size = new System.Drawing.Size(155, 21);
      this.m_comboBox.TabIndex = 7;
      this.m_comboBox.DropDown += new System.EventHandler(this.OnDropDown);
      this.m_comboBox.TextChanged += new System.EventHandler(this.OnFilterTextChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Dock = System.Windows.Forms.DockStyle.Left;
      this.label1.Location = new System.Drawing.Point(0, 1);
      this.label1.Margin = new System.Windows.Forms.Padding(0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(38, 13);
      this.label1.TabIndex = 6;
      this.label1.Text = "Filter : ";
      // 
      // m_txtStatus
      // 
      this.m_txtStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.m_txtStatus.Location = new System.Drawing.Point(0, 123);
      this.m_txtStatus.Name = "m_txtStatus";
      this.m_txtStatus.ReadOnly = true;
      this.m_txtStatus.Size = new System.Drawing.Size(193, 20);
      this.m_txtStatus.TabIndex = 2;
      // 
      // m_grid
      // 
      this.m_grid.AllowUserToAddRows = false;
      this.m_grid.AllowUserToDeleteRows = false;
      this.m_grid.BackColorDelegate = null;
      this.m_grid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
      this.m_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.m_grid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_grid.FocusedIndex = -1;
      this.m_grid.ImageStatusDelegate = null;
      this.m_grid.Location = new System.Drawing.Point(0, 23);
      this.m_grid.Name = "m_grid";
      this.m_grid.ReadOnly = true;
      this.m_grid.RowHeadersWidth = 25;
      this.m_grid.Size = new System.Drawing.Size(193, 100);
      this.m_grid.TabIndex = 1;
      this.m_grid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnRowEnter);
      // 
      // FilterGridControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.m_grid);
      this.Controls.Add(this.m_txtStatus);
      this.Controls.Add(this.panel1);
      this.Name = "FilterGridControl";
      this.Size = new System.Drawing.Size(193, 143);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.m_grid)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.TextBox m_txtStatus;
    private System.Windows.Forms.ComboBox m_comboBox;
    private System.Windows.Forms.Label label1;
    private LogComponents.FilterControl.DataGridView m_grid;
  }
}
