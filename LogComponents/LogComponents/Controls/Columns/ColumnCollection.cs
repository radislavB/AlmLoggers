using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace LogComponents.Controls
{
  public class ColumnCollection : BindingList<ColumnSettings>
  {
    ConfigBase m_options;

    public ColumnCollection(ConfigBase options , DataGridViewColumnCollection gridColumns)
    {
      m_options = options;
      Debug.Assert(gridColumns != null);
      ColumnSettings columnSettings;
      foreach (DataGridViewColumn gridColumn in gridColumns)
      {
        columnSettings = new ColumnSettings(gridColumn);
        Add(columnSettings);

        m_options.Set<ColumnSettings>(columnSettings.Name, columnSettings);
      }

      SortByDisplayIndex();

      this.AllowEdit = true;
      this.AllowNew = false;
      this.AllowRemove = false;
      this.RaiseListChangedEvents = true;
    }

    public void SortByDisplayIndex()
    {
      List<ColumnSettings> list = (List<ColumnSettings>)Items;
      list.Sort(CompareByDisplayIndex);
    }

    private static int CompareByDisplayIndex(ColumnSettings a, ColumnSettings b)
    {
      return a.DisplayIndex - b.DisplayIndex;
    }

    public int ChangeDisplayIndex(int index, bool up)
    {
      ColumnSettings temp = this[index];
      int secondIndex = (up ? index - 1 : index + 1);
      temp.DisplayIndex = secondIndex;

      this[index] = this[secondIndex];
      this[secondIndex] = temp;

      return secondIndex;
    }

    public void ChangeVisibility(int index)
    {
      this[index].Visible = !this[index].Visible;
    }
  }
}
