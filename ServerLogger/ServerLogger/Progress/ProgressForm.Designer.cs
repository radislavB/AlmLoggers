namespace ServerLogger.Progress
{
  partial class ProgressForm
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
      this.components = new System.ComponentModel.Container();
      this.lblMainJob = new System.Windows.Forms.Label();
      this.progMainJob = new System.Windows.Forms.ProgressBar();
      this.progSecondaryJob = new System.Windows.Forms.ProgressBar();
      this.lblSecondaryJob = new System.Windows.Forms.Label();
      this.linkCancel = new System.Windows.Forms.LinkLabel();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.SuspendLayout();
      // 
      // lblMainJob
      // 
      this.lblMainJob.AutoSize = true;
      this.lblMainJob.Location = new System.Drawing.Point(12, 8);
      this.lblMainJob.Name = "lblMainJob";
      this.lblMainJob.Size = new System.Drawing.Size(16, 13);
      this.lblMainJob.TabIndex = 0;
      this.lblMainJob.Text = "...";
      // 
      // progMainJob
      // 
      this.progMainJob.Location = new System.Drawing.Point(12, 25);
      this.progMainJob.Name = "progMainJob";
      this.progMainJob.Size = new System.Drawing.Size(396, 23);
      this.progMainJob.TabIndex = 1;
      // 
      // progSecondaryJob
      // 
      this.progSecondaryJob.Location = new System.Drawing.Point(12, 81);
      this.progSecondaryJob.Name = "progSecondaryJob";
      this.progSecondaryJob.Size = new System.Drawing.Size(396, 23);
      this.progSecondaryJob.TabIndex = 3;
      // 
      // lblSecondaryJob
      // 
      this.lblSecondaryJob.AutoSize = true;
      this.lblSecondaryJob.Location = new System.Drawing.Point(12, 65);
      this.lblSecondaryJob.Name = "lblSecondaryJob";
      this.lblSecondaryJob.Size = new System.Drawing.Size(16, 13);
      this.lblSecondaryJob.TabIndex = 2;
      this.lblSecondaryJob.Text = "...";
      // 
      // linkCancel
      // 
      this.linkCancel.AutoSize = true;
      this.linkCancel.Location = new System.Drawing.Point(367, 115);
      this.linkCancel.Name = "linkCancel";
      this.linkCancel.Size = new System.Drawing.Size(40, 13);
      this.linkCancel.TabIndex = 4;
      this.linkCancel.TabStop = true;
      this.linkCancel.Text = "Cancel";
      this.linkCancel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnCancelLinkClicked);
      // 
      // timer1
      // 
      this.timer1.Interval = 1000;
      this.timer1.Tick += new System.EventHandler(this.OnTimerTick);
      // 
      // ProgressForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(421, 136);
      this.ControlBox = false;
      this.Controls.Add(this.linkCancel);
      this.Controls.Add(this.progSecondaryJob);
      this.Controls.Add(this.lblSecondaryJob);
      this.Controls.Add(this.progMainJob);
      this.Controls.Add(this.lblMainJob);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ProgressForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Progress";
      this.Shown += new System.EventHandler(this.OnShown);
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblMainJob;
    private System.Windows.Forms.ProgressBar progMainJob;
    private System.Windows.Forms.ProgressBar progSecondaryJob;
    private System.Windows.Forms.Label lblSecondaryJob;
    private System.Windows.Forms.LinkLabel linkCancel;
    private System.Windows.Forms.Timer timer1;
  }
}