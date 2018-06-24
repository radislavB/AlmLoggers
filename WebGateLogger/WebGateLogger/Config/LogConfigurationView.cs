using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace WebGateLogger.Config
{
  public partial class LogConfigurationView : UserControl
  {
    bool m_initialized = false;
    bool m_dirty = false;

    public event EventHandler<EventArgs> OnModify;

    public LogConfigurationView()
    {
      InitializeComponent();
      InitializeControl();
      m_initialized = true;
    }

    private void InitializeControl()
    {
      m_chkActivateLogs.Checked = WebGateLogUtility.IsActivated;
      m_txtPath.Text = WebGateLogUtility.LogPath;
      m_nmrMaxLines.Value = WebGateLogUtility.MaxLines;

      OnChkActivateLogsCheckStateChanged(null, null);
    }

    private void OnBtnDirectoryClick(object sender, EventArgs e)
    {

      FolderBrowserDialog folderDialog = new FolderBrowserDialog();
      folderDialog.SelectedPath = m_txtPath.Text;
      DialogResult dr = folderDialog.ShowDialog();
      if (dr == DialogResult.OK)
      {
        m_txtPath.Text = folderDialog.SelectedPath;
      }
    }

    private void RaiseOnModify(object sender, EventArgs e)
    {

      if (m_initialized && OnModify != null)
      {
        OnModify(this, EventArgs.Empty);
        m_dirty = true;
      }
    }

    public void SaveChanges()
    {
      if (!m_dirty)
        return;

      m_dirty = false;

      WebGateLogUtility.IsActivated = m_chkActivateLogs.Checked;
      if (m_chkActivateLogs.Checked)
      {
        WebGateLogUtility.LogPath = m_txtPath.Text;
        WebGateLogUtility.MaxLines = (int)m_nmrMaxLines.Value;
      }



    }

    private void OnChkActivateLogsCheckStateChanged(object sender, EventArgs e)
    {
      m_logConfigurationGroupBox.Enabled = m_chkActivateLogs.Checked;
    }

  }
}
