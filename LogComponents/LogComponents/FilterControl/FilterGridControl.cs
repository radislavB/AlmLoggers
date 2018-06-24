using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace LogComponents.FilterControl
{
  public partial class FilterGridControl : UserControl
  {
    FilterConfig m_filterConfig;
    ConfigBase m_options;
    IFilterableBindingList m_dataSource;
    static object[] s_emptySource = new object[0];
    bool m_inFilterProcess = false;

    public FilterGridControl()
    {
      InitializeComponent();

      if (DesignMode)
        return;

      UpdateStatus();
      InitGrid();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    /// <param name="filterablePropertiesNameMap">Map of column text to property name</param>
    public void Initialize(ConfigBase options, Dictionary<string, string> filterablePropertiesNameMap)
    {
      m_filterConfig = new FilterConfig();
      m_filterConfig.Initialize(filterablePropertiesNameMap);
      m_options = options;
      LoadHistoryFromOptions();
    }

    public bool IsPropertyFilterable(string property)
    {
      return m_filterConfig.IsPropertyFilterable(property);
    }

    private void InitGrid()
    {
      m_grid.AllowUserToOrderColumns = true;
      m_grid.AllowUserToAddRows = false;
      m_grid.AllowUserToDeleteRows = false;
      m_grid.AllowUserToResizeRows = false;
      m_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

      m_grid.RowTemplate.Height = 19;
    }

    #region Event handler

    private void OnFilterTextChanged(object sender, EventArgs e)
    {
      SetFilter(m_comboBox.Text);
      RaiseFocusedIndexChanged();
    }

    private void OnRowEnter(object sender, DataGridViewCellEventArgs e)
    {
      RaiseFocusedIndexChanged();
    }

    #endregion

    #region Events

    public event EventHandler<EventArgs> FilterChanged;

    public event EventHandler<EventArgs> DataSourceChanged;

    public event EventHandler<FocusedIndexChangedEventArgs> FocusedIndexChanged;

    public new event KeyEventHandler KeyDown
    {
      add
      {
        this.m_comboBox.KeyDown += value;
        this.m_grid.KeyDown += value;
        this.m_txtStatus.KeyDown += value;
      }
      remove
      {
        this.m_comboBox.KeyDown -= value;
        this.m_grid.KeyDown -= value;
        this.m_txtStatus.KeyDown -= value;
      }
    }

    public new event DragEventHandler DragDrop
    {
      add
      {
        base.DragDrop += value;
        this.m_comboBox.DragDrop += value;
        this.m_grid.DragDrop += value;
        this.m_txtStatus.DragDrop += value;
      }
      remove
      {
        base.DragDrop -= value;
        this.m_comboBox.DragDrop -= value;
        this.m_grid.DragDrop -= value;
        this.m_txtStatus.DragDrop -= value;
      }
    }

    public new event DragEventHandler DragEnter
    {
      add
      {
        base.DragEnter += value;
        this.m_comboBox.DragEnter += value;
        this.m_grid.DragEnter += value;
        this.m_txtStatus.DragEnter += value;
      }
      remove
      {
        base.DragEnter -= value;
        this.m_comboBox.DragEnter -= value;
        this.m_grid.DragEnter -= value;
        this.m_txtStatus.DragEnter -= value;
      }
    }

    #endregion

    #region Private methods

    private void RaiseFilterChanged()
    {
      if (FilterChanged != null)
      {
        FilterChanged(this, EventArgs.Empty);
      }
    }

    private void RaiseFocusedIndexChanged()
    {
      if (!m_inFilterProcess && FocusedIndexChanged != null)
      {
        FocusedIndexChanged(this, new FocusedIndexChangedEventArgs(FocusedIndex));
      }
    }

    private void SetFilter(string filterWord)
    {
      //save currently focused entity
      ISupportId supportIdEntity = m_grid.FocusedObject<ISupportId>();

      m_filterConfig.SetFilter(filterWord);
      m_history.Add(filterWord);

      if (m_dataSource == null)
        return;

      m_inFilterProcess = true;

      bool hadNoData = m_dataSource.Count == 0;
      m_dataSource.SetFilter(m_filterConfig);

      if (supportIdEntity != null)
      {
        int newIndex = m_dataSource.GetIndexById(supportIdEntity.Id);
        if (newIndex > -1)
          m_grid.FocusedIndex = newIndex;
      }
      if (hadNoData)
      {
        //workaround - if previously count was 0, after that shown rows are empty
        m_grid.DataSource = s_emptySource;
        m_grid.DataSource = m_dataSource;
      }

      //raise event
      m_inFilterProcess = false;
      RaiseFocusedIndexChanged();

      //update status
      UpdateStatus();
      RaiseFilterChanged();
    }

    private void UpdateStatus()
    {
      if (m_dataSource == null)
      {
        m_txtStatus.Text = "No data ...";
      }
      else if (m_dataSource.IsFiltered)
      {
        m_txtStatus.Text = string.Format("Filtering : {0} from {1}", m_dataSource.Count, m_dataSource.FullCount);
      }
      else
      {
        m_txtStatus.Text = string.Format("Total : {0} items", m_dataSource.FullCount);
      }
    }

    #endregion

    #region History

    HistoryCollection m_history = new HistoryCollection();

    private void ReloadHistory()
    {
      if (!m_history.Modified)
        return;

      m_comboBox.Items.Clear();
      for (int i = 0; i < m_history.Count; i++)
      {
        m_comboBox.Items.Add(m_history[i]);
      }

      m_history.Modified = false;
    }

    private void OnDropDown(object sender, EventArgs e)
    {
      ReloadHistory();
    }

    private void LoadHistoryFromOptions()
    {
      string optionName = this.Name;
      if (optionName[1] == '_')
      {
        optionName = optionName.Substring(2);
      }

      optionName = string.Format("{0}{1}History",
        char.ToUpper(optionName[0]), optionName.Substring(1));

      m_history = m_options.Get<HistoryCollection>(optionName);
      m_history.Modified = true;
    }

    #endregion

    #region Public

    [Browsable(false)]
    public FilterConfig FilterConfig
    {
      get { return m_filterConfig; }
      set { m_filterConfig = value; }
    }

    [Browsable(false)]
    public override string Text
    {
      get
      {
        return m_comboBox.Text;
      }
      set
      {
        m_comboBox.Text = value;
      }
    }

    [Browsable(false)]
    public IFilterableBindingList DataSource
    {
      get { return m_dataSource; }
      set
      {
        m_dataSource = value;
        m_grid.DataSource = value;

        if (m_comboBox.Text.Length > 0)
        {
          SetFilter(m_comboBox.Text);
        }

        UpdateStatus();

        if (DataSourceChanged != null)
        {
          DataSourceChanged(this, EventArgs.Empty);
        }
      }
    }

    [Browsable(false)]
    public DataGridViewColumnCollection Columns
    {
      get
      {
        return m_grid.Columns;

      }
    }

    [Browsable(false)]
    public int FocusedIndex
    {
      get
      {
        return m_grid.FocusedIndex;
      }
      set
      {
        m_grid.FocusedIndex = value;
      }
    }

    [Browsable(false)]
    public T FocusedObject<T>()
      where T : class
    {
      return m_grid.FocusedObject<T>();
    }

    [Browsable(false)]
    public Color GridBackgroundColor
    {
      get
      {
        return m_grid.BackgroundColor;
      }
      set
      {
        m_grid.BackgroundColor = value;
      }
    }

    [Browsable(false)]
    public DataGridViewCellStyle GridDefaultCellStyle
    {
      get
      {
        return m_grid.DefaultCellStyle;
      }
      set
      {
        m_grid.DefaultCellStyle = value;
      }
    }

    public void ScrollToRow(int index)
    {
      m_grid.ScrollToRow(index);
    }

    public ContextMenuStrip GridContextMenu
    {
      get
      {
        return m_grid.ContextMenuStrip;
      }
      set
      {
        m_grid.ContextMenuStrip = value;
      }
    }

    public DataObject GetClipboardContent()
    {
      return m_grid.GetClipboardContent();
    }

    public void ClearFilter()
    {
      m_comboBox.Text = string.Empty;
    }

    public string FilterText
    {
      get
      {
        return m_comboBox.Text;
      }
      set
      {
        m_comboBox.Text = value;
      }
    }

    public ImageStatusDelegate ImageStatusDelegate
    {
      get { return m_grid.ImageStatusDelegate; }
      set { m_grid.ImageStatusDelegate = value; }
    }

    public BackColorDelegate BackColorDelegate
    {
      get { return m_grid.BackColorDelegate; }
      set { m_grid.BackColorDelegate = value; }
    }

    public DataGridViewCell ActiveCell
    {
      get
      {
        return m_grid.CurrentCell;
      }
    }

    public IList<T> GetSelectedObjects<T>()
    {
      IList<T> objects = new List<T>();

      foreach (DataGridViewRow row in m_grid.SelectedRows)
      {
        objects.Add((T)row.DataBoundItem);
      }

      return objects;
    }
          
    public void CopyFromGrid()
    {
      if (m_grid.SelectedCells.Count == 1)
      {
        Clipboard.SetDataObject(m_grid.SelectedCells[0].Value.ToString());
      }
      else
      {
        DataObject clipboardData = m_grid.GetClipboardContent();
        if (clipboardData != null)
        {
          Clipboard.SetDataObject(clipboardData);
        }
        else
        {
          Clipboard.Clear();
        }
      }
    }

    #endregion

  }

}
