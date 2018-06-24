using System;
using System.Windows.Forms;

namespace LogComponents.Controls
{
  public partial class ColumnsUserControl : UserControl
  {
    ColumnCollection m_columns;
    ConfigBase m_options;

    public ColumnsUserControl()
    {
      InitializeComponent();
    }

    public void Initialize(ConfigBase options, DataGridViewColumnCollection gridColumns)
    {
      m_options = options;
      m_columns = new ColumnCollection(options, gridColumns);
      dataGridView1.AutoGenerateColumns = false;
      dataGridView1.DataSource = m_columns;
      dataGridView1.Rows[0].Selected = true;
    }

    public void SortByDisplayIndex()
    {
      m_columns.SortByDisplayIndex();
    }

    private void OnBtnUpClick(object sender, EventArgs e)
    {
      SelectedIndex = m_columns.ChangeDisplayIndex(SelectedIndex, true);
    }

    private void OnBtnDownClick(object sender, EventArgs e)
    {
      SelectedIndex = m_columns.ChangeDisplayIndex(SelectedIndex, false);
    }

    private void OnSelectionChanged(object sender, EventArgs e)
    {
      int index = SelectedIndex;

      m_btnUp.Enabled = (index > 0);
      m_btnDown.Enabled = (index != -1 && index < dataGridView1.RowCount - 1);
    }

    private int SelectedIndex
    {
      get
      {
        DataGridViewSelectedRowCollection rows = dataGridView1.SelectedRows;
        if (rows.Count == 0)
          return -1;

        return rows[0].Index;
      }
      set
      {
        dataGridView1.Rows[value].Selected = true;
      }
    }

    private void OnVisibilityCellContentClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex == -1 || e.ColumnIndex != 1)
        return;

      m_columns.ChangeVisibility(e.RowIndex);
    }
  }
}
