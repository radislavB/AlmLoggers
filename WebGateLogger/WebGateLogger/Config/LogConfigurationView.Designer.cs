namespace WebGateLogger.Config
{
  partial class LogConfigurationView
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
      this.m_chkActivateLogs = new System.Windows.Forms.CheckBox();
      this.m_logConfigurationGroupBox = new System.Windows.Forms.GroupBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.m_nmrMaxLines = new System.Windows.Forms.NumericUpDown();
      this.m_btnDirectory = new System.Windows.Forms.Button();
      this.m_txtPath = new System.Windows.Forms.TextBox();
      this.m_logConfigurationGroupBox.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.m_nmrMaxLines)).BeginInit();
      this.SuspendLayout();
      // 
      // m_chkActivateLogs
      // 
      this.m_chkActivateLogs.AutoSize = true;
      this.m_chkActivateLogs.Location = new System.Drawing.Point(6, 10);
      this.m_chkActivateLogs.Name = "m_chkActivateLogs";
      this.m_chkActivateLogs.Size = new System.Drawing.Size(126, 17);
      this.m_chkActivateLogs.TabIndex = 0;
      this.m_chkActivateLogs.Text = "Write WebGate Logs";
      this.m_chkActivateLogs.UseVisualStyleBackColor = true;
      this.m_chkActivateLogs.CheckStateChanged += new System.EventHandler(this.OnChkActivateLogsCheckStateChanged);
      this.m_chkActivateLogs.CheckedChanged += new System.EventHandler(this.RaiseOnModify);
      // 
      // m_logConfigurationGroupBox
      // 
      this.m_logConfigurationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.m_logConfigurationGroupBox.Controls.Add(this.label2);
      this.m_logConfigurationGroupBox.Controls.Add(this.label1);
      this.m_logConfigurationGroupBox.Controls.Add(this.m_nmrMaxLines);
      this.m_logConfigurationGroupBox.Controls.Add(this.m_btnDirectory);
      this.m_logConfigurationGroupBox.Controls.Add(this.m_txtPath);
      this.m_logConfigurationGroupBox.Location = new System.Drawing.Point(6, 33);
      this.m_logConfigurationGroupBox.Name = "m_logConfigurationGroupBox";
      this.m_logConfigurationGroupBox.Size = new System.Drawing.Size(347, 90);
      this.m_logConfigurationGroupBox.TabIndex = 1;
      this.m_logConfigurationGroupBox.TabStop = false;
      this.m_logConfigurationGroupBox.Text = "WebGateLog configuration";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(6, 59);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(72, 13);
      this.label2.TabIndex = 4;
      this.label2.Text = "Max lines/file:";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 26);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(32, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "Path:";
      // 
      // m_nmrMaxLines
      // 
      this.m_nmrMaxLines.Location = new System.Drawing.Point(81, 57);
      this.m_nmrMaxLines.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
      this.m_nmrMaxLines.Name = "m_nmrMaxLines";
      this.m_nmrMaxLines.Size = new System.Drawing.Size(120, 20);
      this.m_nmrMaxLines.TabIndex = 2;
      this.m_nmrMaxLines.ValueChanged += new System.EventHandler(this.RaiseOnModify);
      // 
      // m_btnDirectory
      // 
      this.m_btnDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.m_btnDirectory.Location = new System.Drawing.Point(317, 21);
      this.m_btnDirectory.Name = "m_btnDirectory";
      this.m_btnDirectory.Size = new System.Drawing.Size(24, 23);
      this.m_btnDirectory.TabIndex = 1;
      this.m_btnDirectory.Text = "...";
      this.m_btnDirectory.UseVisualStyleBackColor = true;
      this.m_btnDirectory.Click += new System.EventHandler(this.OnBtnDirectoryClick);
      // 
      // m_txtPath
      // 
      this.m_txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.m_txtPath.Location = new System.Drawing.Point(81, 23);
      this.m_txtPath.Name = "m_txtPath";
      this.m_txtPath.ReadOnly = true;
      this.m_txtPath.Size = new System.Drawing.Size(230, 20);
      this.m_txtPath.TabIndex = 0;
      this.m_txtPath.Text = "c:/WebGateLogs";
      this.m_txtPath.TextChanged += new System.EventHandler(this.RaiseOnModify);
      // 
      // LogConfigurationView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.m_logConfigurationGroupBox);
      this.Controls.Add(this.m_chkActivateLogs);
      this.Name = "LogConfigurationView";
      this.Size = new System.Drawing.Size(361, 126);
      this.m_logConfigurationGroupBox.ResumeLayout(false);
      this.m_logConfigurationGroupBox.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.m_nmrMaxLines)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.CheckBox m_chkActivateLogs;
    private System.Windows.Forms.GroupBox m_logConfigurationGroupBox;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.NumericUpDown m_nmrMaxLines;
    private System.Windows.Forms.Button m_btnDirectory;
    private System.Windows.Forms.TextBox m_txtPath;
  }
}
