
namespace ServerLogger
{
  partial class GotoIdDialog
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
      this.m_lblRange = new System.Windows.Forms.Label();
      this.m_txtId = new LogComponents.Controls.TextBoxNumeric();
      this.SuspendLayout();
      // 
      // m_btnCancel
      // 
      this.m_btnCancel.Location = new System.Drawing.Point(38, 66);
      this.m_btnCancel.TabIndex = 1;
      // 
      // m_btnOk
      // 
      this.m_btnOk.Location = new System.Drawing.Point(119, 66);
      this.m_btnOk.TabIndex = 2;
      this.m_btnOk.Click += new System.EventHandler(this.OnBtnOkClick);
      // 
      // m_lblRange
      // 
      this.m_lblRange.AutoSize = true;
      this.m_lblRange.Location = new System.Drawing.Point(4, 9);
      this.m_lblRange.Name = "m_lblRange";
      this.m_lblRange.Size = new System.Drawing.Size(126, 13);
      this.m_lblRange.TabIndex = 4;
      this.m_lblRange.Text = "Select ID from {0} to {1} :";
      // 
      // m_txtId
      // 
      this.m_txtId.Location = new System.Drawing.Point(7, 25);
      this.m_txtId.Name = "m_txtId";
      this.m_txtId.Size = new System.Drawing.Size(187, 20);
      this.m_txtId.TabIndex = 0;
      this.m_txtId.TextChanged += new System.EventHandler(this.OnTxtIndexTextChanged);
      // 
      // GotoIdDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.ClientSize = new System.Drawing.Size(206, 101);
      this.Controls.Add(this.m_txtId);
      this.Controls.Add(this.m_lblRange);
      this.Name = "GotoIdDialog";
      this.Text = "Goto id ...";
      this.Controls.SetChildIndex(this.m_btnCancel, 0);
      this.Controls.SetChildIndex(this.m_btnOk, 0);
      this.Controls.SetChildIndex(this.m_lblRange, 0);
      this.Controls.SetChildIndex(this.m_txtId, 0);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label m_lblRange;
    private LogComponents.Controls.TextBoxNumeric m_txtId;

  }
}
