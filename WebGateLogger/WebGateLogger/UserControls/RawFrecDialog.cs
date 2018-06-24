using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WebGateLogger
{
  public partial class RawFrecDialog : Form
  {
    Frec m_currentFrec;
    public RawFrecDialog()
    {
      InitializeComponent();
      InitializeEscapeButton();
    }

    private void InitializeEscapeButton()
    {
      Button escButton = new Button();
      escButton.Click += OnBtnExitClick;
      this.CancelButton = escButton;
    }

    public void SetFrec(Frec frec)
    {
      m_currentFrec = frec;
      Text = string.Format("{0} - {1}", frec.Id, frec.Title);

      //raw frec
      webBrowser1.DocumentText = frec.GetRawFrec();

      //performance data
      dataGridView1.Rows.Clear();
      string performanceXML = frec.GetResponsePerformanceXML();
      if (!string.IsNullOrEmpty(performanceXML))
      {
        DataSet ds = new DataSet();

        using (TextReader tr = new StringReader(performanceXML))
        {
          ds.ReadXml(tr);
          DataRow row = ds.Tables[0].Rows[0];
          foreach (DataColumn column in ds.Tables[0].Columns)
          {
            dataGridView1.Rows.Add(column.ColumnName, row[column]);
          }
        }
      }


      UpdateCommands();

    }

    private void UpdateCommands()
    {
      int index = m_currentFrec.Parent.IndexOf(m_currentFrec);

      //prev frec
      if (index > 0)
      {
        m_btnPrevFrec.Enabled = true;
        m_btnPrevFrec.Tag = m_currentFrec.Parent.GetItem(index - 1);

      }
      else
      {
        m_btnPrevFrec.Enabled = false;
        m_btnPrevFrec.Tag = null;
      }


      //next frec
      if (index < m_currentFrec.Parent.Count - 1)
      {
        m_btnNextFrec.Enabled = true;
        m_btnNextFrec.Tag = m_currentFrec.Parent.GetItem(index + 1);

      }
      else
      {
        m_btnNextFrec.Enabled = false;
        m_btnNextFrec.Tag = null;
      }
    }

    private void OnNavigationButtonClick(object sender, EventArgs e)
    {
      Frec frec = (Frec)((ToolStripItem)sender).Tag;
      SetFrec(frec);
    }

    private void OnBtnExitClick(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
    }

  }
}
