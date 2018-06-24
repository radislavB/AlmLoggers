using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LogComponents.MVC;
using LogComponents.FilterControl;
using LogComponents;
using LogComponents.Controls;

namespace ServerLogger.Mvc
{
  public partial class GroupByRequestControl : MvcControl
  {
    LogRequestCollection m_requestCollection;
    LogRequest m_request;
    GotoIdDialog m_gotoIdDialog;

    public GroupByRequestControl()
    {
      InitializeComponent();
    }

    public override void Initialize()
    {
      base.Initialize();

      m_requestFilterGrid.Initialize(Options, Utilities.GetRequestFilterablePropertiesNames());
      m_requestFilterGrid.FocusedIndexChanged += OnRequestFilterGridFocusedIndexChanged;

      m_subRequestFilterGrid.Initialize(Options, Utilities.GetRequestFilterablePropertiesNames());

      InitializeRequestColumns(RequestCollumns);
      ColumnSettings.SetColumnsSettingsFromOptions(Options, RequestCollumns);

      InitializeSubRequestColumns(SubRequestCollumns);
      ColumnSettings.SetColumnsSettingsFromOptions(Options, SubRequestCollumns);

      m_txtMessage.Initialize(Options, m_subRequestFilterGrid);

      m_requestFilterGrid.ImageStatusDelegate = Utilities.GetWarnTypeImageDelegate;
      m_requestFilterGrid.BackColorDelegate = Utilities.BackColorDelegate;

      m_subRequestFilterGrid.ImageStatusDelegate = Utilities.GetWarnTypeImageDelegate;
      m_subRequestFilterGrid.BackColorDelegate = Utilities.BackColorDelegate;

      m_mainSplit.SplitterDistance = Options.MainSplitter;
      m_rightSplit.SplitterDistance = Options.RightSplitter;

      OnOptionsSaved(null, null);
      Options.OnSaved += OnOptionsSaved;
    }

    private void OnOptionsSaved(object sender, EventArgs e)
    {
      m_requestFilterGrid.Invalidate(true);
      m_subRequestFilterGrid.Invalidate(true);
      SetGridColors();
    }

    public override int Order
    {
      get
      {
        return 10;
      }
    }

    public override string Caption
    {
      get
      {
        return "Group by request";
      }
    }

    public override void SaveState()
    {
      base.SaveState();
      Options.MainSplitter = m_mainSplit.SplitterDistance;
      Options.RightSplitter = m_rightSplit.SplitterDistance;

      ColumnSettings.SaveColumnsonSettingInOptions(Options, RequestCollumns);
      ColumnSettings.SaveColumnsonSettingInOptions(Options, SubRequestCollumns);
    }

    internal DataGridViewColumnCollection RequestCollumns
    {
      get
      {
        return m_requestFilterGrid.Columns;
      }
    }

    internal DataGridViewColumnCollection SubRequestCollumns
    {
      get
      {
        return m_subRequestFilterGrid.Columns;
      }
    }

    protected override void OnMvcContextChanged()
    {
      m_requestCollection = (LogRequestCollection)MvcContext;
      m_requestFilterGrid.DataSource = m_requestCollection;
    }

    public int FocusedIndex
    {
      get
      {
        return m_requestFilterGrid.FocusedIndex;
      }
      set
      {
        m_requestFilterGrid.FocusedIndex = value;
      }
    }

    private new Options Options
    {
      get
      {
        return (Options)base.Options;
      }
    }

    private void InitializeRequestColumns(DataGridViewColumnCollection columns)
    {
      DataGridViewColumn column;
      DataGridViewCellStyle style;
      //
      //Index 
      //
      column = new DataGridViewTextBoxColumn();
      columns.Add(column);
      column.DataPropertyName = "Id";
      column.HeaderText = "Id";
      column.Name = "clmRequestId";
      column.Width = 40;
      //
      //Request
      //
      column = new DataGridViewTextBoxColumn();
      columns.Add(column);
      column.DataPropertyName = "Request";
      column.HeaderText = "Request";
      column.Name = "clmRequest";
      column.Width = 150;
	  //
	  //RequestType
	  //
	  column = new DataGridViewTextBoxColumn();
	  columns.Add(column);
	  column.DataPropertyName = "RequestType";
	  column.HeaderText = "Type";
	  column.Name = "plainClmRequestType";
	  column.Width = 70;
      //
      //IP
      //
      column = new DataGridViewTextBoxColumn();
      columns.Add(column);
      column.DataPropertyName = "IP";
      column.HeaderText = "IP";
      column.Name = "clmIP";
      column.Width = 80;
      //
      // Start
      // 
      column = new DataGridViewTextBoxColumn();
      columns.Add(column);
      style = new DataGridViewCellStyle();
      style.Format = "MMM dd, HH:mm:ss.fff";
      column.DataPropertyName = "StartDate";
      column.DefaultCellStyle = style;
      column.HeaderText = "Start";
      column.Name = "clmStart";
      column.Width = 110;
      // 
      // clmFinish
      // 
      column = new DataGridViewTextBoxColumn();
      columns.Add(column);
      style = new DataGridViewCellStyle();
      style.Format = "HH:mm:ss.fff";
      column.DataPropertyName = "FinishDate";
      column.DefaultCellStyle = style;
      column.HeaderText = "Finish";
      column.Name = "clmFinish";
      column.Visible = false;
      column.Width = 75;
      // 
      // clmTotalTime
      // 
      column = new DataGridViewTextBoxColumn();
      columns.Add(column);
      style = new DataGridViewCellStyle();
      style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
      style.Format = Constants.COLUMNS.TOTAL_TIME_FORMAT;
      column.DataPropertyName = Constants.COLUMNS.TOTAL_TIME_PROPERTY_NAME;
      column.DefaultCellStyle = style;
      column.HeaderText = "Total time";
      column.Name = "clmTotalTime";
      column.Width = 80;
      // 
      // clmConnectId
      // 
      column = new DataGridViewTextBoxColumn();
      columns.Add(column);
      column.DataPropertyName = "ConnectId";
      column.HeaderText = "ConnectId";
      column.Name = "clmConnectId";
      column.Visible = false;
      column.Width = 70;
      // 
      // clmLoginId
      // 
      column = new DataGridViewTextBoxColumn();
      columns.Add(column);
      column.DataPropertyName = "LoginId";
      column.HeaderText = "LoginId";
      column.Name = "clmLoginId";
      column.Visible = false;
      column.Width = 70;
      // 
      // clmCallId
      // 
      column = new DataGridViewTextBoxColumn();
      columns.Add(column);
      column.DataPropertyName = "CallId";
      column.HeaderText = "CallId";
      column.Name = "clmCallId";
      column.Visible = false;
      column.Width = 70;
      // 
      // clmUserName
      // 
      column = new DataGridViewTextBoxColumn();
      columns.Add(column);
      column.DataPropertyName = "User";
      column.HeaderText = "User";
      column.Name = "clmUserName";
      column.Visible = false;
      column.Width = 70;
      // 
      // clmThreadName
      // 
      column = new DataGridViewTextBoxColumn();
      columns.Add(column);
      column.DataPropertyName = "Thread";
      column.HeaderText = "Thread";
      column.Name = "clmThreadName";
      column.Visible = false;
    }

    private void InitializeSubRequestColumns(DataGridViewColumnCollection columns)
    {
      DataGridViewColumn column;
      DataGridViewCellStyle style;
      // 
      // clmRowIndex
      // 
      column = new DataGridViewTextBoxColumn();
      columns.Add(column);
      column.DataPropertyName = "Id";
      column.HeaderText = "Id";
      column.Name = "clmRowId";
      column.Width = 50;
      // 
      // clmType
      //
      column = new DataGridViewTextBoxColumn();
      columns.Add(column);
      column.DataPropertyName = "Type";
      column.HeaderText = "Type";
      column.Name = "clmType";
      column.Visible = false;
      column.Width = 40;
      // 
      // clmDate
      // 
      column = new DataGridViewTextBoxColumn();
      columns.Add(column);
      style = new DataGridViewCellStyle();
      style.Format = "HH:mm:ss.fff";
      column.DataPropertyName = "StartDate";
      column.DefaultCellStyle = style;
      column.HeaderText = "Begin time";
      column.Name = "clmDate";
      column.Visible = false;
      column.Width = 80;
      //
      // DB Start DateTime
      // 
      column = new DataGridViewTextBoxColumn();
      columns.Add(column);
      style = new DataGridViewCellStyle();
      style.Format = "HH:mm:ss.fff";
      column.DataPropertyName = "DbStartDate";
      column.DefaultCellStyle = style;
      column.HeaderText = "DB Start";
      column.Name = "plainClmDbStart";
      column.Width = 110;
      // 
      // clmDbTime
      // 
      column = new DataGridViewTextBoxColumn();
      columns.Add(column);
      style = new DataGridViewCellStyle();
      style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
      column.DataPropertyName = "DbTime";
      column.DefaultCellStyle = style;
      column.HeaderText = "DB Time(ms)";
      column.Name = "clmDbTime";
      column.Width = 120;
      // 
      // clmTotalTime
      // 
      column = new DataGridViewTextBoxColumn();
      columns.Add(column);
      style = new DataGridViewCellStyle();
      style.Format = Constants.COLUMNS.TOTAL_TIME_FORMAT;
      style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
      column.DataPropertyName = Constants.COLUMNS.TOTAL_TIME_PROPERTY_NAME;
      column.DefaultCellStyle = style;
      column.HeaderText = "Total Time";
      column.Name = "clmTotalTime";
      column.Width = 100;
      // 
      // clmRowAffected
      // 
      column = new DataGridViewTextBoxColumn();
      columns.Add(column);
      style = new DataGridViewCellStyle();
      style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
      column.DataPropertyName = "RowAffected";
      column.DefaultCellStyle = style;
      column.HeaderText = "Affected rows";
      column.Name = "clmRowAffected";
      column.Visible = false;
      // 
      // clmMethod
      // 
      column = new DataGridViewTextBoxColumn();
      columns.Add(column);
      column.DataPropertyName = "Method";
      column.HeaderText = "Method";
      column.Name = "clmMethod";
      column.Width = 350;
      // 
      // clmSchema
      // 
      column = new DataGridViewTextBoxColumn();
      columns.Add(column);
      column.DataPropertyName = "DbSchema";
      column.HeaderText = "DbSchema";
      column.Name = "clmSchema";
      column.Visible = false;
      // 
      // clmContainsSQL
      // 
      column = new DataGridViewTextBoxColumn();
      columns.Add(column);
      column.DataPropertyName = "ContainsSQL";
      column.HeaderText = "SQL";
      column.Name = "clmContainsSQL";
      column.Visible = false;
      // 
      // clmMessage
      // 
      column = new DataGridViewTextBoxColumn();
      columns.Add(column);
      column.DataPropertyName = "Message";
      column.HeaderText = "Message";
      column.Name = "clmMessage";
      column.Visible = false;
    }

    private void SetGridColors()
    {

      //grid background      
      m_requestFilterGrid.GridBackgroundColor = Options.GridBackColor;
      m_requestFilterGrid.GridDefaultCellStyle.BackColor = Options.RequestRowColor;
      m_subRequestFilterGrid.GridBackgroundColor = Options.GridBackColor;

    }

    #region Event handlers : grid events

    private void OnRequestFilterGridFocusedIndexChanged(object sender, FocusedIndexChangedEventArgs e)
    {
      if (e.FocusedIndex == -1)
      {
        m_request = null;
      }
      else
      {
        m_request = m_requestCollection.GetItem(e.FocusedIndex);
      }

      if (m_request == null || m_request.Count == 0)
      {
        m_txtMessage.Text = string.Empty;
      }

      m_subRequestFilterGrid.DataSource = m_request;
    }

    private void OnCmdCopyClick(object sender, EventArgs e)
    {
      FilterGridControl control = (sender == m_cmdCopyRequest ? m_requestFilterGrid : m_subRequestFilterGrid);
      DataObject dataObj = control.GetClipboardContent();
      if (dataObj != null)
        Clipboard.SetDataObject(dataObj);
      else
        Clipboard.Clear();
    }

    private void OnCmdClearFilterClick(object sender, EventArgs e)
    {
      FilterGridControl control = (sender == m_cmdClearFilterRequest ? m_requestFilterGrid : m_subRequestFilterGrid);
      control.ClearFilter();
    }

    private void OnCmdColumnsClick(object sender, EventArgs e)
    {
      OptionsForm optionForm = new OptionsForm();
      optionForm.InitializeColumns(RequestCollumns, SubRequestCollumns);

      if (sender == m_cmdColumnsRequest)
      {
        optionForm.ShowDialog(Tabs.RequestColumns);
      }
      else
      {
        optionForm.ShowDialog(Tabs.RowColumns);
      }
    }

    private void OnRequestContextMenuOpening(object sender, System.ComponentModel.CancelEventArgs e)
    {
      //m_cmdCopyRequest.Enabled = (m_gridRequests.SelectedCells.Count > 0);
      m_cmdGotoIdRequest.Enabled = (m_requestCollection != null && m_requestCollection.Count > 1);
      m_cmdClearFilterRequest.Enabled = (m_requestCollection != null && m_requestCollection.IsFiltered);

      DataGridViewCell cell = m_requestFilterGrid.ActiveCell;
      m_cmdFilterBy.Enabled = cell != null && cell.Value != null && m_requestFilterGrid.IsPropertyFilterable(cell.OwningColumn.DataPropertyName);
      if (m_cmdFilterBy.Enabled)
      {
        string value = cell.Value.ToString();
        if (cell.OwningColumn.DataPropertyName.Equals(Constants.COLUMNS.TOTAL_TIME_PROPERTY_NAME, StringComparison.OrdinalIgnoreCase))
        {
          value = ((DateTime)cell.Value).ToString(Constants.COLUMNS.TOTAL_TIME_FORMAT);
        }

        if (value.Length > Utilities.MAX_LENGTH_FOR_FILTER_VALUE)
        {
          value = value.Substring(0, Utilities.MAX_LENGTH_FOR_FILTER_VALUE);
        }
        string filter = cell.OwningColumn.DataPropertyName + FilterConfig.KEY_VALUE_SEPARATOR + value;
        m_cmdFilterBy.Text = "Filter by ->" + filter;
        m_cmdFilterBy.Tag = filter;
      }
      else
      {
        m_cmdFilterBy.Text = "Filter by ...";
        m_cmdFilterBy.Tag = null;
      }
    }

    private void OnRowContextMenuOpening(object sender, System.ComponentModel.CancelEventArgs e)
    {
      m_cmdSourceRow.Enabled = (m_request != null && m_request.Count > 0);
      m_cmdGotoIndexRow.Enabled = (m_request != null && m_request.Count > 1);
      m_cmdClearFilterRow.Enabled = (m_request != null && m_request.IsFiltered);


      DataGridViewCell cell = m_subRequestFilterGrid.ActiveCell;
      m_cmdFilterBy1.Enabled = m_cmdFilterBy2.Enabled = (cell != null && cell.Value != null && m_subRequestFilterGrid.IsPropertyFilterable(cell.OwningColumn.DataPropertyName));
      if (m_cmdFilterBy1.Enabled)
      {
        string value = cell.Value.ToString();
        if (cell.OwningColumn.DataPropertyName.Equals(Constants.COLUMNS.TOTAL_TIME_PROPERTY_NAME, StringComparison.OrdinalIgnoreCase))
        {
          value = ((DateTime)cell.Value).ToString(Constants.COLUMNS.TOTAL_TIME_FORMAT);
        }

        if (value.Length > Utilities.MAX_LENGTH_FOR_FILTER_VALUE)
        {
          value = value.Substring(0, Utilities.MAX_LENGTH_FOR_FILTER_VALUE);
        }

        string filter1 = "#" + cell.OwningColumn.DataPropertyName + FilterConfig.KEY_VALUE_SEPARATOR + value;
        m_cmdFilterBy1.Text = "Filter by ->" + filter1;
        m_cmdFilterBy1.Tag = filter1;

        string filter2 = cell.OwningColumn.DataPropertyName + FilterConfig.KEY_VALUE_SEPARATOR + value;
        m_cmdFilterBy2.Text = "Filter by ->  " + filter2;
        m_cmdFilterBy2.Tag = filter2;
      }
      else
      {
        m_cmdFilterBy1.Text = "Filter by # ...";
        m_cmdFilterBy1.Tag = null;

        m_cmdFilterBy2.Text = "Filter by ...";
        m_cmdFilterBy2.Tag = null;
      }
    }

    private void OnCmnSourceRowClick(object sender, EventArgs e)
    {
      string source = m_subRequestFilterGrid.FocusedObject<LogSubRequest>().Source;
      Helpers.IOUtilities.OpenFile(source);
    }

    private void OnCmnGotoIndexClick(object sender, EventArgs e)
    {
      if (sender == m_cmdGotoIdRequest)
      {
        if (m_requestCollection == null || m_requestCollection.Count < 2)
          return;
        GotoId(m_requestCollection, m_requestFilterGrid);
      }
      else
      {
        if (m_request == null || m_request.Count < 2)
          return;
        GotoId(m_request, m_subRequestFilterGrid);
      }
    }

    private void GotoId(IFilterableBindingList source, FilterGridControl gridControl)
    {
      if (m_gotoIdDialog == null)
        m_gotoIdDialog = new GotoIdDialog();

      int minId = int.MaxValue;
      int maxId = int.MinValue;
      int tempId;
      foreach (ISupportId supportId in source)
      {
        tempId = supportId.Id;
        if (minId > tempId)
        {
          minId = tempId;
        }
        if (maxId < tempId)
        {
          maxId = tempId;
        }
      }

      DialogResult dr = m_gotoIdDialog.ShowDialog(minId, maxId);
      if (dr != DialogResult.OK)
        return;

      int gotoIndex = source.GetIndexById(m_gotoIdDialog.GotoId);
      if (gotoIndex == -1)
      {
        Helpers.FormUtilities.ShowMessage(string.Format("Id <{0}> isn't in filter", m_gotoIdDialog.GotoId));
      }
      else
      {
        gridControl.ScrollToRow(gotoIndex);
      }
    }

    private void OnRequestFilterGridFilterChanged(object sender, EventArgs e)
    {
      if (m_requestCollection.Count == 0)
      {
        //empty rows and message
        m_subRequestFilterGrid.DataSource = null;
        m_txtMessage.Text = string.Empty;
      }

      if (m_requestCollection.IsFiltered && m_requestFilterGrid.FilterConfig.SubFilterString != string.Empty)
      {
        m_subRequestFilterGrid.Text = m_requestFilterGrid.FilterConfig.SubFilterString;
      }
    }

    private void OnCmdFilterByClick(object sender, EventArgs e)
    {
      string temp = string.Empty;
      if (m_requestFilterGrid.Text.Length > 0)
      {
        temp = "; ";
      }

      string filter = (string)((ToolStripItem)sender).Tag;
      if (filter.Length > Utilities.MAX_LENGTH_FOR_FILTER_VALUE)
      {
        filter = filter.Substring(0, Utilities.MAX_LENGTH_FOR_FILTER_VALUE);
      }

      temp += filter;
      m_requestFilterGrid.Text += temp;

    }

    private void OnCmdFilterBy1Click(object sender, EventArgs e)
    {
      string temp = string.Empty;
      if (m_requestFilterGrid.Text.Length > 0)
      {
        temp = "; ";
      }

      string filter = (string)((ToolStripItem)sender).Tag;
      if (filter.Length > Utilities.MAX_LENGTH_FOR_FILTER_VALUE)
      {
        filter = filter.Substring(0, Utilities.MAX_LENGTH_FOR_FILTER_VALUE);
      }

      temp += filter;
      m_requestFilterGrid.Text += temp;
    }

    private void OnCmdFilterBy2Click(object sender, EventArgs e)
    {
      string temp = string.Empty;

      if (m_subRequestFilterGrid.Text.Length > 0)
      {
        temp = "; ";
      }

      string filter = (string)((ToolStripItem)sender).Tag;
      if (filter.Length > Utilities.MAX_LENGTH_FOR_FILTER_VALUE)
      {
        filter = filter.Substring(0, Utilities.MAX_LENGTH_FOR_FILTER_VALUE);
      }

      temp += filter;
      m_subRequestFilterGrid.Text += temp;
    }

    #endregion


  }
}
