using System;
using System.Windows.Forms;
using LogComponents;
using LogComponents.Controls;

namespace ServerLogger
{
  public partial class GotoIdDialog : BaseDialog
  {
    int m_gotoId, m_min,m_max;

    public GotoIdDialog()
    {
      InitializeComponent();
    }

    public DialogResult ShowDialog(int minId, int maxId)
    {
      m_min = minId;
      m_max = maxId;

      m_lblRange.Text = string.Format("Select index from {0} to {1}", minId, maxId);
      m_btnOk.Enabled = false;
      m_txtId.Text = string.Empty;

      return ShowDialog();
    }

    public int GotoId
    {
      get
      {
        return m_gotoId;
      }
    }

    private void OnTxtIndexTextChanged(object sender, EventArgs e)
    {
      m_btnOk.Enabled = (m_txtId.TextLength > 0);
    }

    private void OnBtnOkClick(object sender, EventArgs e)
    {

      bool ok = int.TryParse(m_txtId.Text, out m_gotoId);
      if (!ok || m_gotoId < m_min || m_gotoId>m_max)
      {
        Helpers.FormUtilities.ShowMessage(m_lblRange.Text);
        return;
      }

      DialogResult = DialogResult.OK;
    }
  }
}
