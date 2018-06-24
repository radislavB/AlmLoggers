namespace LogComponents.Controls
{
  partial class BaseDialog
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
      this.m_btnCancel = new System.Windows.Forms.Button();
      this.m_btnOk = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // m_btnCancel
      // 
      this.m_btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.m_btnCancel.Location = new System.Drawing.Point(124, 231);
      this.m_btnCancel.Name = "m_btnCancel";
      this.m_btnCancel.Size = new System.Drawing.Size(75, 23);
      this.m_btnCancel.TabIndex = 0;
      this.m_btnCancel.Text = "Cancel";
      this.m_btnCancel.UseVisualStyleBackColor = true;
      // 
      // m_btnOk
      // 
      this.m_btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.m_btnOk.Location = new System.Drawing.Point(205, 231);
      this.m_btnOk.Name = "m_btnOk";
      this.m_btnOk.Size = new System.Drawing.Size(75, 23);
      this.m_btnOk.TabIndex = 1;
      this.m_btnOk.Text = "Ok";
      this.m_btnOk.UseVisualStyleBackColor = true;
      // 
      // BaseDialog
      // 
      this.AcceptButton = this.m_btnOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.m_btnCancel;
      this.ClientSize = new System.Drawing.Size(292, 266);
      this.Controls.Add(this.m_btnOk);
      this.Controls.Add(this.m_btnCancel);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "BaseDialog";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "BaseDialog";
      this.ResumeLayout(false);

    }

    #endregion

    protected System.Windows.Forms.Button m_btnCancel;
    protected System.Windows.Forms.Button m_btnOk;

  }
}