using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace LogComponents.FilterControl
{
  public partial class DataGridView : System.Windows.Forms.DataGridView
  {

    #region Private members

    private ImageStatusDelegate m_imageStatusDelegate;

    private BackColorDelegate m_backColorDelegate;

    private int m_selectedRowIndex = -1;

    #endregion

    #region Ctor

    public DataGridView()
    {
      InitializeComponent();
      AutoGenerateColumns = false;
    }

    #endregion

    #region Public methods

    [Browsable(false)]
    public int FocusedIndex
    {
      get
      {
        if (Rows.Count == 0)
        {
          m_selectedRowIndex = -1;
        }

        return m_selectedRowIndex;
      }
      set
      {
        if (value >= 0 && value < Rows.Count)
        {
          int firstVisibleColumn = FindFirstVisibleColumn();
          if (firstVisibleColumn > -1)
          {
            CurrentCell = Rows[value].Cells[firstVisibleColumn];
          }
          Rows[value].Selected = true;
          FirstDisplayedScrollingRowIndex = value;
          m_selectedRowIndex = value;

          //cell.Selected = true;
          OnRowEnter(new DataGridViewCellEventArgs(0, value));
        }
        else if (Rows.Count == 0)
        {
          m_selectedRowIndex = -1;
        }
      }
    }

    public void ScrollToRow(int rowIndex)
    {
      Debug.Assert(RowCount > rowIndex, "RowCount>rowIndex");
      Debug.Assert(rowIndex > -1, "rowIndex>-1");

      FocusedIndex = rowIndex;
    }

    public T FocusedObject<T>()
      where T : class
    {
      if (FocusedIndex > -1 && Rows.Count > FocusedIndex)
      {
        return (T)this.Rows[FocusedIndex].DataBoundItem;
      }

      FocusedIndex = -1;
      return null;
    }

    public ImageStatusDelegate ImageStatusDelegate
    {
      get { return m_imageStatusDelegate; }
      set { m_imageStatusDelegate = value; }
    }

    public BackColorDelegate BackColorDelegate
    {
      get { return m_backColorDelegate; }
      set { m_backColorDelegate = value; }
    }

    #endregion

    #region Protected methods

    protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
    {
      if (!this.DesignMode && DataSource != null && e.RowIndex > -1 && ((IList)DataSource).Count > 0)
      {
        object rowObject = Rows[e.RowIndex].DataBoundItem;

        if (e.ColumnIndex == -1 && m_imageStatusDelegate != null)
        {
          ImageStatus imageStatus = m_imageStatusDelegate(rowObject);
          if (imageStatus != null)
          {
            PaintImageInCell(imageStatus, e);
          }
        }

        if (e.ColumnIndex > -1 && m_backColorDelegate != null)
        {
          Color color = m_backColorDelegate(rowObject);
          e.CellStyle.BackColor = color;
        }

      }


      base.OnCellPainting(e);
    }

    protected override void OnRowEnter(DataGridViewCellEventArgs e)
    {
      if (m_selectedRowIndex != e.RowIndex)
      {
        m_selectedRowIndex = e.RowIndex;
        base.OnRowEnter(e);
      }
    }

    #endregion

    #region Private methods

    private void PaintImageInCell(ImageStatus imageStatus, DataGridViewCellPaintingEventArgs e)
    {
      e.PaintBackground(e.ClipBounds, true);
      Rectangle r = Rectangle.Inflate(e.CellBounds, -4, -2);
      e.Graphics.DrawImage(imageStatus.Image, r);

      if (!string.IsNullOrEmpty(imageStatus.Status))
      {
        Rows[e.RowIndex].Cells[0].ToolTipText = imageStatus.Status;
      }

      e.Handled = true;
    }

    private int FindFirstVisibleColumn()
    {

      for (int i = 0; i < Columns.Count; i++)
      {
        if (Columns[i].Visible)
        {
          return i;
        }
      }

      return -1;
    }

    #endregion

  }
}
