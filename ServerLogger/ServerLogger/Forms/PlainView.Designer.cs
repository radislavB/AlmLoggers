
namespace ServerLogger
{
  partial class PlainView
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
      LogComponents.FilterControl.FilterConfig filterConfig1 = new LogComponents.FilterControl.FilterConfig();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      this.m_filterGridControl = new LogComponents.FilterControl.FilterGridControl();
      this.SuspendLayout();
      // 
      // m_filterGridControl
      // 
      this.m_filterGridControl.DataSource = null;
      this.m_filterGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_filterGridControl.FilterConfig = filterConfig1;
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
      this.m_filterGridControl.Location = new System.Drawing.Point(0, 0);
      this.m_filterGridControl.Name = "m_filterGridControl";
      this.m_filterGridControl.Size = new System.Drawing.Size(456, 381);
      this.m_filterGridControl.TabIndex = 0;
      // 
      // PlainView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(456, 381);
      this.Controls.Add(this.m_filterGridControl);
      this.MinimizeBox = false;
      this.Name = "PlainView";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.Text = "PlainView";
      this.ResumeLayout(false);

    }

    #endregion

    private LogComponents.FilterControl.FilterGridControl m_filterGridControl;
  }
}