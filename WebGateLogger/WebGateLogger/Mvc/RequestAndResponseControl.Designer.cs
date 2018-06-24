namespace WebGateLogger.Mvc
{
  partial class RequestAndResponseControl
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
      this.m_splitPanel = new System.Windows.Forms.SplitContainer();
      this.m_txtRequest = new LogComponents.Controls.CustomTextBox();
      this.m_txtResponse = new LogComponents.Controls.CustomTextBox();
      this.m_splitPanel.Panel1.SuspendLayout();
      this.m_splitPanel.Panel2.SuspendLayout();
      this.m_splitPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // m_splitPanel
      // 
      this.m_splitPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_splitPanel.Location = new System.Drawing.Point(0, 0);
      this.m_splitPanel.Margin = new System.Windows.Forms.Padding(0);
      this.m_splitPanel.Name = "m_splitPanel";
      this.m_splitPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // m_splitPanel.Panel1
      // 
      this.m_splitPanel.Panel1.Controls.Add(this.m_txtRequest);
      // 
      // m_splitPanel.Panel2
      // 
      this.m_splitPanel.Panel2.Controls.Add(this.m_txtResponse);
      this.m_splitPanel.Size = new System.Drawing.Size(343, 266);
      this.m_splitPanel.SplitterDistance = 76;
      this.m_splitPanel.SplitterWidth = 2;
      this.m_splitPanel.TabIndex = 1;
      // 
      // m_txtRequest
      // 
      this.m_txtRequest.AcceptsTab = true;
      this.m_txtRequest.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_txtRequest.EnableAutoDragDrop = true;
      this.m_txtRequest.HideSelection = false;
      this.m_txtRequest.Location = new System.Drawing.Point(0, 0);
      this.m_txtRequest.Margin = new System.Windows.Forms.Padding(0);
      this.m_txtRequest.Name = "m_txtRequest";
      this.m_txtRequest.ReadOnly = true;
      this.m_txtRequest.Size = new System.Drawing.Size(343, 76);
      this.m_txtRequest.TabIndex = 1;
      this.m_txtRequest.Text = "";
      // 
      // m_txtResponse
      // 
      this.m_txtResponse.AcceptsTab = true;
      this.m_txtResponse.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_txtResponse.EnableAutoDragDrop = true;
      this.m_txtResponse.HideSelection = false;
      this.m_txtResponse.Location = new System.Drawing.Point(0, 0);
      this.m_txtResponse.Margin = new System.Windows.Forms.Padding(0);
      this.m_txtResponse.Name = "m_txtResponse";
      this.m_txtResponse.ReadOnly = true;
      this.m_txtResponse.Size = new System.Drawing.Size(343, 188);
      this.m_txtResponse.TabIndex = 5;
      this.m_txtResponse.Text = "";
      // 
      // RequestAndResponseControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.m_splitPanel);
      this.Name = "RequestAndResponseControl";
      this.Size = new System.Drawing.Size(343, 266);
      this.m_splitPanel.Panel1.ResumeLayout(false);
      this.m_splitPanel.Panel2.ResumeLayout(false);
      this.m_splitPanel.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.SplitContainer m_splitPanel;
    private LogComponents.Controls.CustomTextBox m_txtRequest;
    private LogComponents.Controls.CustomTextBox m_txtResponse;
  }
}
