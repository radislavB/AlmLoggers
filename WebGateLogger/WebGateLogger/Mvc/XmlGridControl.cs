using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using LogComponents;
using LogComponents.MVC;

namespace WebGateLogger.Mvc
{
  public partial class XmlGridControl : MvcControl
  {
    public XmlGridControl()
    {
      InitializeComponent();
    }

    public override string Caption
    {
      get
      {
        return "XML grid view";
      }
    }

    public override int Order
    {
      get
      {
        return 40;
      }
    }

    public override bool isVisibleForContext(IMvcContext context)
    {
      return true;
    }


    protected override void OnMvcContextChanged()
    {
      base.OnMvcContextChanged();

      if (MvcContext == null)
      {
        ClearControls();
        return;
      }

      string xmlData = GetXmlData();
      if (!string.IsNullOrEmpty(xmlData))
      {
        LoadXml(xmlData);
      }
      else
      {
        ClearControls();
      }
    }

    private string GetXmlData()
    {
      Frec frec = (Frec)MvcContext;
      if (frec.Title == "UpdateClientPerformanceData")
      {
        return frec.Request;
      }

      return null;
    }

    private void ClearControls()
    {
      m_lstBox.Items.Clear();
      dataGridView1.DataSource = null;
    }

    private void LoadXml(string content)
    {
      DataSet ds = new DataSet();
      TextReader reader = new StringReader(content);
      ds.ReadXml(reader);

      m_lstBox.Items.Clear();
      m_lstBox.DisplayMember = "TableName";
      foreach (DataTable dataTable in ds.Tables)
      {
        m_lstBox.Items.Add(dataTable);
      }

      if (m_lstBox.Items.Count > 0)
      {
        m_lstBox.SelectedIndex = 0;
      }

    }

    private void OnSelectedIndexChanged(object sender, EventArgs e)
    {
      dataGridView1.DataSource = m_lstBox.SelectedItem;
      m_txtCount.Text = "Total : " + dataGridView1.RowCount;
    }

    private void OnBtnFindClick(object sender, EventArgs e)
    {
      string findText = m_txtFind.Text;
      int startRow = 0;
      int startColumn = 0;
      DataGridViewCell currentCell = dataGridView1.CurrentCell;
      if (currentCell != null)
      {
        startRow = currentCell.RowIndex;
        startColumn = currentCell.OwningColumn.DisplayIndex + 1;
      }

      bool isFound = false;


      for (int i = startRow; !isFound && i < dataGridView1.RowCount; i++)
      {
        int j;
        if (i == startRow)
        {
          j = startColumn;
        }
        else
        {
          j = 0;
        }
        for (; !isFound && j < dataGridView1.ColumnCount; j++)
        {
          DataGridViewCell cell = dataGridView1[j, i];
          if (cell != null)
          {
            if (cell.Value.ToString().ToLower().Contains(findText.ToLower()))
            {
              dataGridView1.CurrentCell = cell;
              isFound = true;

            }
          }
        }
      }

      if (!isFound)
      {
        Helpers.FormUtilities.ShowMessage(string.Format("{0} - not found", findText));
      }
    }

    private void OnTxtFind_TextChanged(object sender, EventArgs e)
    {
      m_btnFind.Enabled = m_txtFind.TextLength > 0 && dataGridView1.DataSource != null;
    }

    private void OnDataGridViewDataSourceChanged(object sender, EventArgs e)
    {
      m_btnFind.Enabled = dataGridView1.DataSource != null;
    }

    private void OnTxtFindKeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        m_btnFind.PerformClick();
      }
    }
  }
}
