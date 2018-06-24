using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace LogComponents.Controls
{
  [TypeConverter(typeof(ColumnSettingsTypeConverter))]
  public class ColumnSettings
  {
    DataGridViewColumn m_source;
    int m_displayIndex;
    bool m_visible;
    int m_width;


    public ColumnSettings(int displayIndex, bool visible, int width)
    {
      m_displayIndex = displayIndex;
      m_visible = visible;
      m_width = width;
    }

    public ColumnSettings(DataGridViewColumn column)
    {
      Debug.Assert(column != null, "column can't be null");
      m_source = column;
    }

    public bool Visible
    {
      get
      {
        if (m_source == null)
          return m_visible;

        return m_source.Visible;
      }
      set
      {
        m_source.Visible = value;
      }
    }

    public int DisplayIndex
    {
      get
      {
        if (m_source == null)
          return m_displayIndex;

        return m_source.DisplayIndex;
      }
      set
      {
        m_source.DisplayIndex = value;
      }
    }

    public string Title
    {
      get
      {
        return m_source.HeaderText;
      }
      set
      {
        m_source.HeaderText = value;
      }
    }

    public int Width
    {
      get
      {
        if (m_source == null)
          return m_width;

        return m_source.Width;
      }
      set
      {
        m_source.Width = value;
      }
    }

    public string Name
    {
      get
      {
        return m_source.Name;
      }
    }

    public override string ToString()
    {
      return Title;
    }

    public static void SetColumnsSettingsFromOptions(ConfigBase options, DataGridViewColumnCollection columns)
    {
      bool reorderDone = false;

      //set column property as saved in options
      foreach (DataGridViewColumn column in columns)
      {
        ColumnSettings settings = options.Get<ColumnSettings>(column.Name);
        if (settings == null)
        {
          continue;
        }

        if (column.Resizable == DataGridViewTriState.True)
        {
          column.Width = settings.Width;
        }
        column.Visible = settings.Visible;
        if (column.DisplayIndex != settings.DisplayIndex && settings.DisplayIndex < columns.Count)
        {
          reorderDone = true;
          column.DisplayIndex = settings.DisplayIndex;
        }
      }

      //reschedule according to properties
      int loop = 0;
      while (reorderDone && loop < 10)
      {
        loop++;
        reorderDone = false;
        foreach (DataGridViewColumn column in columns)
        {
          ColumnSettings settings = options.Get<ColumnSettings>(column.Name);
          if (settings != null && column.DisplayIndex != settings.DisplayIndex && settings.DisplayIndex < columns.Count)
          {
            reorderDone = true;
            column.DisplayIndex = settings.DisplayIndex;
          }
        }
      }
    }

    public static void SaveColumnsonSettingInOptions(ConfigBase options, DataGridViewColumnCollection columns)
    {
      foreach (DataGridViewColumn column in columns)
      {
        ColumnSettings columnSettings = new ColumnSettings(column);
        options.Set<ColumnSettings>(columnSettings.Name, columnSettings);
      }
    }
  }



  public class ColumnSettingsTypeConverter : TypeConverter
  {
    public static char[] DIVIDER = { ';' };

    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
      return sourceType == typeof(string);
    }

    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
      if (value.GetType() != typeof(string))
        throw new ArgumentException("Illegal type of argument");

      string[] parts = ((string)value).Split(DIVIDER, StringSplitOptions.RemoveEmptyEntries);

      try
      {
        int displayIndex = int.Parse(parts[0]);
        bool visible = bool.Parse(parts[1]);
        int width = int.Parse(parts[2]);

        return new ColumnSettings(displayIndex, visible, width);
      }
      catch
      {
        return null;
      }
    }

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      ColumnSettings column = (ColumnSettings)value;
      StringBuilder builder = new StringBuilder();
      builder.Append(column.DisplayIndex);
      builder.Append(DIVIDER);
      builder.Append(column.Visible);
      builder.Append(DIVIDER);
      builder.Append(column.Width);

      return builder.ToString();
    }
  }
}
