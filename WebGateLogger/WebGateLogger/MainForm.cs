using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using LogComponents;
using LogComponents.Controls;
using LogComponents.FilterControl;
using WebGateLogger.Mvc;
using WebGateLogger.Properties;
using System.Globalization;

namespace WebGateLogger
{
  public partial class MainForm : Form
  {
    #region Private data members

    private string m_fileName;
    private Options m_options;
    private OptionsForm m_optionsForm;
    private FrecCollection m_frecs;
    private RefreshWatcher m_refreshWatcher;
    private RequestAndResponseControl m_requestAndResponseControl;

    private OpenFileDialog m_openLogDialog;

    private static int MAX_LENGTH_FOR_FILTER_VALUE = 60;
    private static string WAIT_COLUMN_HEADER = "Wait";

    #endregion

    #region Ctor

    public MainForm()
    {
      InitializeComponent();
    }

    #endregion

    #region Event handler

    private void OnSaveOptions(object sender, EventArgs e)
    {
      m_filterGridControl.Invalidate(true);
      m_mvcManager.UpdateContent();
    }

    private void OnLoad(object sender, EventArgs e)
    {
      InitializeForm();
    }

    private void OnBtnLoadLastLogClick(object sender, EventArgs e)
    {
      LoadFrecsFromLastLog(false);
    }

    private void OnBtnLoadSpecificLogClick(object sender, EventArgs e)
    {
      LoadFrecsWithDialog();
    }

    private void OnBtnScrollBottomClick(object sender, EventArgs e)
    {
      m_filterGridControl.FocusedIndex = m_filterGridControl.DataSource.Count - 1;
    }

    private void OnBtnScrollTopClick(object sender, EventArgs e)
    {
      m_filterGridControl.FocusedIndex = 0;
    }

    private void OnBtnLoadedSource(object sender, EventArgs e)
    {
      if (File.Exists(m_frecs.FullFileName))
      {
        Process.Start(m_frecs.FullFileName);
      }
      else
      {
        Helpers.FormUtilities.ShowMessage("Source file is not found.");
      }
    }

    private void OnBtnOptionClick(object sender, EventArgs e)
    {
      OptionsForm.ShowDialog(this);
    }

    private void OnDragDrop(object sender, DragEventArgs e)
    {
      string[] fileName = (string[])e.Data.GetData("FileNameW");
      LoadFrecs(fileName[0], false);
    }

    private void OnDragEnter(object sender, DragEventArgs e)
    {
      string[] filePath = (string[])e.Data.GetData("FileNameW");
      string fileName = Path.GetFileName(filePath[0]);

      if (Regex.IsMatch(fileName, Constants.LOG_FILE_FILTER_REGEX, RegexOptions.IgnoreCase))
        e.Effect = DragDropEffects.Copy;
      else
        e.Effect = DragDropEffects.None;

    }

    private void OnFilterFromCurrentRow(object sender, EventArgs e)
    {
      Frec focused = m_filterGridControl.FocusedObject<Frec>();
      if (focused != null)
      {
        AddToFilter(Consts.FrecProperty.ID, focused.Id.ToString());
      }
    }

    private void OnFilterFailedRows(object sender, EventArgs e)
    {
      AddToFilter(Consts.FrecProperty.ERROR, "true");
    }

    private void AddToFilter(string property, string value)
    {
      string temp = string.Empty;

      if (m_filterGridControl.Text.Trim().Length > 0)
      {
        temp = FilterConfig.PROPERTY_SEPARATOR + " ";
      }

      temp += property + FilterConfig.KEY_VALUE_SEPARATOR + value;
      m_filterGridControl.Text += temp;
    }

    private void OnClearFilter(object sender, EventArgs e)
    {
      m_filterGridControl.ClearFilter();
    }

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.F5:
          m_btnRefresh.PerformClick();
          break;
      }
    }

    private void OnBtnAutoRefreshClick(object sender, EventArgs e)
    {
      if (!CheckIfLogFolderExistAndShowShowAlertIfRequired(WebGateLogUtility.LogPath))
      {
        m_btnAutoRefresh.Checked = false;
        return;
      }

      if (m_refreshWatcher == null)
      {
        m_refreshWatcher = new RefreshWatcher(WebGateLogUtility.LogPath);
        m_refreshWatcher.Refreshed += OnRefreshWatcher;
      }

      m_refreshWatcher.EnableRaisingEvents = m_btnAutoRefresh.Checked;

    }

    private void OnRefreshWatcher(object sender, EventArgs e)
    {
      if (InvokeRequired)
      {
        Invoke(new EventHandler(OnRefreshWatcher), sender, e);
        return;
      }
      LoadFrecsFromLastLog(true);
    }

    private void OnClosing(object sender, FormClosingEventArgs e)
    {
      m_mvcManager.SaveState();

      m_options.SplitterMainPanel = m_splitMainPanel.SplitterDistance;
      m_options.SplitterLeftPanel = m_splitLeftPanel.SplitterDistance;
      m_options.AdditionalDataSelectedTab = m_tabAdditionalData.SelectedTab.Text;
      m_options.FormSize = this.Size;
      m_options.FormMaximized = (WindowState == FormWindowState.Maximized);

      m_options.Save();
    }

    private void OnBtnPrevNextClick(object sender, EventArgs e)
    {
      string path = (string)((ToolStripButton)sender).Tag;
      LoadFrecs(path, false);
    }

    private void OnCopyMenuItemClick(object sender, EventArgs e)
    {
      m_filterGridControl.CopyFromGrid();
    }

    private void OnOpenColumnsSettingsMenuItemClick(object sender, EventArgs e)
    {
      OptionsForm.ShowDialog(Tabs.Columns);
    }

    private void OnMenuFilterByClick(object sender, EventArgs e)
    {
      string temp = string.Empty;
      if (m_filterGridControl.Text.Trim().Length > 0)
      {
        temp = FilterConfig.PROPERTY_SEPARATOR.ToString() + " ";
      }

      m_filterGridControl.Text += temp + (string)m_toolMenuFilterBy.Tag;
    }

    private void OnContextMenuOpening(object sender, CancelEventArgs e)
    {

      DataGridViewCell cell = m_filterGridControl.ActiveCell;
      bool isFilterSet = false;
      if (cell != null)
      {
        string columnName = cell.OwningColumn.HeaderText;
        if (m_filterGridControl.IsPropertyFilterable(columnName))
        {
          string value = GetValueForFilter(cell);
          if (!string.IsNullOrEmpty(value))
          {
            string filter = columnName + FilterConfig.KEY_VALUE_SEPARATOR + value;
            m_toolMenuFilterBy.Tag = filter;
            if (filter.Length > MAX_LENGTH_FOR_FILTER_VALUE)
            {
              filter = filter.Substring(0, MAX_LENGTH_FOR_FILTER_VALUE);
            }
            m_toolMenuFilterBy.Text = "Filter by ->" + filter;
            m_toolMenuFilterBy.Enabled = true;
            isFilterSet = true;
          }
        }
      }

      if (!isFilterSet)
      {
        m_toolMenuFilterBy.Text = "Filter by ...";
        m_toolMenuFilterBy.Enabled = false;
        m_toolMenuFilterBy.Tag = null;
      }

      IList<Frec> selectedObjects = m_filterGridControl.GetSelectedObjects<Frec>();
    }

    private void OnBtnCloseClick(object sender, EventArgs e)
    {
      Close();
    }

    private void OnFilterChanged(object sender, EventArgs e)
    {
      m_requestAndResponseControl.UpdateFilter(m_filterGridControl.FilterConfig);
    }

    private void OnRefreshLockChanged(object sender, EventArgs e)
    {
      if (m_fileName != null)
      {
        UpdateNextPrevLogs(m_fileName);
      }
    }

    #endregion

    #region Functionality

    private string GetValueForFilter(DataGridViewCell cell)
    {
      if (cell.OwningColumn.HeaderText == WAIT_COLUMN_HEADER)
      {
        return (m_frecs.GetItem(cell.RowIndex).ResponceWaitTimeSpan.Seconds.ToString());
      }
      else
      {
        return cell.Value.ToString();
      }

    }

    private ImageStatus GetFrecStatusImage(object frecObject)
    {
      Frec frec = (Frec)frecObject;
      if (frec.IsFailed)
      {
        String message = "Error : " + frec.Response;
        return ImageStatus.Create(Resources.breakpoint, message);
      }
      else if (frec.HasIllegalCharacters)
      {
        String message = "Responce has xml illegal characters : " + String.Join<int>(";", frec.IllegalCharacters);
        return ImageStatus.Create(Resources.cube_molecule, message);
      }

      return null;
    }

    private Color BackColorDelegate(object frecObject)
    {
      Frec frec = (Frec)frecObject;
      if (frec.Thread == m_frecs.MainThread)
      {
        return m_options.GridMainRequestColor;
      }
      else
      {
        return m_options.GridSecondaryRequestColor;
      }
    }

    private void SetRequestColumns(DataGridViewColumnCollection columns)
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
      style.Format = "N0";
      column.DataPropertyName = "TotalTime";
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
      column.DataPropertyName = "UserName";
      column.HeaderText = "User";
      column.Name = "clmUserName";
      column.Visible = false;
      column.Width = 70;
      // 
      // clmThreadName
      // 
      column = new DataGridViewTextBoxColumn();
      columns.Add(column);
      column.DataPropertyName = "ThreadName";
      column.HeaderText = "Thread";
      column.Name = "clmThreadName";
      column.Visible = false;
    }

    private void InitializeForm()
    {
      if (DesignMode)
        return;

      m_options = Options.GetInstance;
      m_options.OnSaved += OnSaveOptions;


      m_filterGridControl.Initialize(m_options, GetFilterablePropertiesNames());
      m_filterGridControl.ImageStatusDelegate = GetFrecStatusImage;
      m_filterGridControl.BackColorDelegate = BackColorDelegate;

      m_cmbRefreshLock.SelectedIndex = 0;

      InitializeColumns(m_filterGridControl.Columns);
      ColumnSettings.SetColumnsSettingsFromOptions(m_options, m_filterGridControl.Columns);

      InitializeAdditionaDataTab();

      InitializeFormSize();
      InitializeTabs();

      InitializeFromOptions();
      InitializeRecursiveEvents();
    }

    private void InitializeRecursiveEvents()
    {
      Helpers.FormUtilities.RegisterRecursiveDragDropEvent(this, OnDragDrop, OnDragEnter);
      Helpers.FormUtilities.RegisterRecursiveKeyDownEvent(this, OnKeyDown);
    }

    private void InitializeFormSize()
    {
      if (m_options.FormMaximized)
      {
        this.WindowState = FormWindowState.Maximized;
      }
      else
      {
        Size tempSize = m_options.FormSize;
        if (!(tempSize.Width <= 123 || tempSize.Height <= 34))
        {
          this.Size = tempSize;
        }
      }

      try
      {
        m_splitMainPanel.SplitterDistance = m_options.SplitterMainPanel;

        if (m_options.SplitterLeftPanel > 25)
        {
          m_splitLeftPanel.SplitterDistance = m_options.SplitterLeftPanel;
        }

      }
      catch
      {
      }
    }

    private void InitializeFromOptions()
    {
      //load files
      //first try load from command line
      string[] args = Environment.GetCommandLineArgs();
      bool loadedFromCommandLine = false;
      if (args.Length == 2)
      {
        if (Path.GetExtension(args[1]) == Constants.INPUT_FILES_EXTENSION)
        {
          LoadFrecs(args[1], false);
          loadedFromCommandLine = true;
        }
      }
      if (!loadedFromCommandLine && m_options.LoadOnStart)
      {
        Application.DoEvents();
        LoadFrecsFromLastLog(false);
      }

      if (m_options.RemoveOldFiles)
      {
        ThreadPool.QueueUserWorkItem(DeleteOldFilesWaitCallback);
      }
    }

    private void InitializeColumns(DataGridViewColumnCollection columns)
    {
      columns.Clear();
      DataGridViewColumn column;

      // 
      // clmIndex
      // 
      column = new DataGridViewTextBoxColumn();
      columns.Add(column);
      column.DataPropertyName = "Id";
      column.HeaderText = "Id";
      column.Name = "clmIndex";
      column.ReadOnly = true;
      column.Width = 35;
      column.ToolTipText = "Index";
      // 
      // clmFrec
      // 
      column = new DataGridViewTextBoxColumn();
      columns.Add(column);
      column.DataPropertyName = "Title";
      column.HeaderText = "Frec";
      column.Name = "clmFrec";
      column.ReadOnly = true;
      column.Width = 166;
      column.ToolTipText = "Frec";
      // 
      // clmTime
      // 
      column = new DataGridViewTextBoxColumn();
      columns.Add(column);
      column.DataPropertyName = "TimeString";
      column.HeaderText = "Start";
      column.Name = "clmTime";
      column.ReadOnly = true;
      column.Width = 75;
      column.ToolTipText = "Start time";
      // 
      // clmWait
      // 
      column = new DataGridViewTextBoxColumn();
      columns.Add(column);
      column.DataPropertyName = "ResponceWaitTime";
      column.HeaderText = "Wait";
      column.Name = "clmWait";
      column.ReadOnly = true;
      column.Width = 60;
      column.ToolTipText = "Waiting time to responce";
      // 
      // clmTable
      // 
      column = new DataGridViewTextBoxColumn();
      columns.Add(column);
      column.DataPropertyName = "TableName";
      column.HeaderText = "Table";
      column.Name = "clmTable";
      column.ReadOnly = true;
      column.Width = 120;
      column.ToolTipText = "Table name";
      // 
      // clmSession
      // 
      column = new DataGridViewTextBoxColumn();
      columns.Add(column);
      column.DataPropertyName = "SessionId";
      column.HeaderText = "Session";
      column.Name = "clmSession";
      column.ReadOnly = true;
      column.Width = 130;
      column.ToolTipText = "Project session";
      column.Visible = false;
      // 
      // clmThread
      // 
      column = new DataGridViewTextBoxColumn();
      columns.Add(column);
      column.DataPropertyName = "Thread";
      column.HeaderText = "Thread";
      column.Name = "clmThread";
      column.ReadOnly = true;
      column.Width = 45;
      column.ToolTipText = "Thread";
      column.Visible = false;

      // 
      // clmParseDuration
      // 
      column = new DataGridViewTextBoxColumn();
      columns.Add(column);
      column.DataPropertyName = "ParseDuration";
      column.HeaderText = "Parse duration";
      column.Name = "clmParseDuration";
      column.ReadOnly = true;
      column.Width = 120;
      column.ToolTipText = "Frec parse duration";
      column.Visible = false;

      // 
      // clmServer
      // 
      column = new DataGridViewTextBoxColumn();
      columns.Add(column);
      column.DataPropertyName = "Server";
      column.HeaderText = "Server";
      column.Name = "clmServer";
      column.ReadOnly = true;
      column.Width = 120;
      column.ToolTipText = "Server";
      column.Visible = false;

    }

    private void InitializeAdditionaDataTab()
    {
      string selectedTabName = m_options.AdditionalDataSelectedTab;
      if (string.IsNullOrEmpty(selectedTabName))
      {
        return;
      }

      foreach (TabPage tab in m_tabAdditionalData.TabPages)
      {
        if (tab.Text == selectedTabName)
        {
          m_tabAdditionalData.SelectedTab = tab;
          break;
        }
      }
    }

    private void InitializeTabs()
    {
      m_mvcManager.Initialize(m_options);

      m_mvcManager.AddTab(m_requestAndResponseControl = new RequestAndResponseControl());
      m_mvcManager.AddTab(new RawFrecControl());
      m_mvcManager.AddTab(new QcSensePerformanceControl());
      m_mvcManager.AddTab(new XmlGridControl());
      //m_mvcManager.AddTab(new GridControl());

    }

    private IList<string> GetFilePatternsAccordingToLock()
    {
      IList<string> patterns = Constants.LOG_FILE_FILTER;
      switch (m_cmbRefreshLock.SelectedIndex)
      {
        case 1://server lock
          string shortFileName = Path.GetFileName(m_fileName);
          string serverName = shortFileName.Substring(0, shortFileName.IndexOf('_'));
          patterns = new string[] { serverName + "*" };
          break;
        case 2://file lock
          patterns = new string[] { Path.GetFileName(m_fileName) };
          break;
      }
      return patterns;
    }

    private void LoadFrecsFromLastLog(bool suppressParseException)
    {
      string logFolder = WebGateLogUtility.LogPath;
      bool isLogFolderExist = CheckIfLogFolderExistAndShowShowAlertIfRequired(logFolder);
      if (isLogFolderExist)
      {
        IList<string> filePatterns = GetFilePatternsAccordingToLock();
        string fileName = Helpers.IOUtilities.GetLastModifiedFile(logFolder, filePatterns, Constants.MIN_LOG_FILE_SIZE);
        if (fileName == null)
        {
          Helpers.FormUtilities.ShowMessage("There is no log file in folder");
          return;
        }
        LoadFrecs(fileName, suppressParseException);
      }
    }

    private bool CheckIfLogFolderExistAndShowShowAlertIfRequired(string path)
    {
      if (!WebGateLogUtility.IsActivated)
      {
        Helpers.FormUtilities.ShowMessage("WebGate logs isn't activated. Activation is available in Configuration->Options.");
        return false;
      }

      if (!Directory.Exists(path))
      {
        Helpers.FormUtilities.ShowMessage("Log folder doesn't exist.");
        return false;
      }

      return true;
    }


    private void LoadFrecsWithDialog()
    {
      if (m_openLogDialog == null)
      {
        m_openLogDialog = new OpenFileDialog();
        m_openLogDialog.Filter = Constants.LOG_FILE_DIALOG_FILTER;
        m_openLogDialog.ShowHelp = false;
        m_openLogDialog.Multiselect = false;
        m_openLogDialog.CheckFileExists = true;
        m_openLogDialog.CheckPathExists = true;
        m_openLogDialog.Title = "Find WebGateLog File";
        m_openLogDialog.InitialDirectory = WebGateLogUtility.LogPath;
      }

      if (m_openLogDialog.ShowDialog() == DialogResult.OK)
      {
        LoadFrecs(m_openLogDialog.FileName, false);
      }
    }

    private void LoadFrecs(string fileName, bool suppressParseException)
    {
      if (!File.Exists(fileName))
      {
        string message = string.Format("File <{0}> isn't exist", Path.GetFileName(fileName));
        Helpers.FormUtilities.ShowMessage(message);
        return;
      }


      FrecCollection temp = FrecCollection.LoadCollection(fileName);
      if (temp == null)
      {
        if (!suppressParseException)
          Helpers.FormUtilities.ShowMessage("Failed to parse file " + fileName);

        return;
      }

      m_frecs = temp;//defense against crash in ctor of FrecCollection


      bool isNewFile = (fileName != m_fileName);
      if (isNewFile)
      {

        m_fileName = fileName;
      }

      PopulateForm(isNewFile);
      Application.DoEvents();

      if (temp.Count == 0 && temp.FileContent.StartsWith("<!DOCTYPE HTML PUBLIC"))
      {
        Helpers.FormUtilities.ShowMessage("File has wrong format. It was created from IE by using \"Save As\" that changed the format of the file. Try to use the original file.");
      }
    }

    private void PopulateForm(bool isNewFile)
    {
      if (isNewFile)
      {
        UpdateNextPrevLogs(m_fileName);
      }

      int focusedRowBefore = m_filterGridControl.FocusedIndex;

      m_filterGridControl.DataSource = m_frecs;


      //Connection info
      ConnectionInfo connInfo = m_frecs.GetConnectionInfo();
      m_gridConnectionInfo.SelectedObject = connInfo;
      UpdateStatus(connInfo.ToString());

      //Update Form text
      Text = String.Format("{0} - {1}", ExecutingAssembly.ProductName, m_frecs.LogFile);
      if (m_frecs.InProcess)
      {
        Text += " (In process)";
      }

      //navigate after load
      if (!isNewFile && m_options.StayOnSameRowOnRefresh)
      {
        m_filterGridControl.FocusedIndex = focusedRowBefore;
      }
      else
      {
        ScrollAfterLoad();
      }

      UpdateContent();
    }

    private void UpdateNextPrevLogsCallBack(object fileNameObj)
    {
      string prevFile, nextFile;
      string currentFileName = (string)fileNameObj;

      IList<string> filePatterns = (IList<string>)Invoke(new GetFilePatternsDelegate(GetFilePatternsAccordingToLock));
      Helpers.IOUtilities.GetPrevNextFiles(currentFileName, filePatterns, Constants.MIN_LOG_FILE_SIZE,
        out prevFile, out  nextFile);

      Invoke(new UpdatePrevNextFilesDelegate(UpdateNextPrevLogs), prevFile, nextFile);

    }

    private void UpdateNextPrevLogs(string prevFile, string nextFile)
    {
      //set buttons
      if (nextFile != null)
      {
        m_btnNextFile.Enabled = true;
        m_btnNextFile.ToolTipText = "Load next log: " + Path.GetFileName(nextFile);
        m_btnNextFile.Tag = nextFile;
      }
      else
      {
        m_btnNextFile.Enabled = false;
        m_btnNextFile.ToolTipText = null;
        m_btnNextFile.Tag = null;
      }

      if (prevFile != null)
      {
        m_btnPrevFile.Enabled = true;
        m_btnPrevFile.ToolTipText = "Load prev log: " + Path.GetFileName(prevFile);
        m_btnPrevFile.Tag = prevFile;
      }
      else
      {
        m_btnPrevFile.Enabled = false;
        m_btnPrevFile.ToolTipText = null;
        m_btnPrevFile.Tag = null;
      }

      Application.DoEvents();
    }

    private void UpdateNextPrevLogs(string fileName)
    {
      m_btnNextFile.Enabled = false;
      m_btnNextFile.ToolTipText = "Computing";
      m_btnNextFile.Tag = null;

      m_btnPrevFile.Enabled = false;
      m_btnPrevFile.ToolTipText = "Computing";
      m_btnPrevFile.Tag = null;

      Application.DoEvents();
      ThreadPool.QueueUserWorkItem(UpdateNextPrevLogsCallBack, fileName);
    }

    private void ScrollAfterLoad()
    {

      if (m_filterGridControl.DataSource.Count == 0)
        return;

      if (m_options.ScrollToBottomOnLoad)
      {
        m_btnBottom.PerformClick();
      }
    }

    private void UpdateContent()
    {
      int currentRow = m_filterGridControl.FocusedIndex;

      int rowCount = m_filterGridControl.DataSource.Count;

      m_btnTop.Enabled = (rowCount > 0 && currentRow > 0);
      m_btnBottom.Enabled = ((rowCount > 0) && (currentRow < rowCount - 1));

      m_btnLoadedSource.Enabled = true;

      Frec focused = m_filterGridControl.FocusedObject<Frec>();

      m_mvcManager.SetMvcContext(focused);
      UpdateBookmarks(focused);
    }

    private OptionsForm OptionsForm
    {
      get
      {
        if (m_optionsForm == null)
        {
          m_optionsForm = new OptionsForm();
          m_optionsForm.InitializeColumns(m_filterGridControl.Columns);
        }
        return m_optionsForm;
      }
    }


    /// <summary>
    /// Method is used for ThreadPool to execute DeleteOldFiles
    /// </summary>
    private void DeleteOldFilesWaitCallback(object state)
    {
      int deletedCount = Helpers.IOUtilities.DeleteOldFiles(WebGateLogUtility.LogPath, Constants.LOG_FILE_FILTER, m_options.OldFilesThreshold);
      deletedCount += Helpers.IOUtilities.DeleteOldFiles(WebGateLogUtility.LogPath, Constants.LOADER_LOG_FILE_FILTER, m_options.OldFilesThreshold);

      if (deletedCount > 0)
      {
        UpdateStatus(deletedCount.ToString() + " old file(s) were deleted from log directory");
      }
    }

    private void UpdateStatus(string status)
    {
      //Delete old files is done asynchrony
      if (InvokeRequired)
      {
        Invoke(new UpdateStatusDelegate(UpdateStatus), status);
        return;
      }
      m_txtStatus.Text = status;

    }

    private void UpdateBookmarks(Frec focused)
    {
      //Bookmarks
      m_idsGrid.ColumnHeadersVisible = false;
      m_idsGrid.RowTemplate.Height = 18;
      m_idsGrid.AutoGenerateColumns = false;

      if (focused != null)
      {
        IList<BaseBookmark> ids = m_frecs.GetBookmarks(focused);
        m_txtIdsCount.Text = "Total : " + ids.Count;
        m_idsGrid.DataSource = ids;
      }
      else
      {
        m_idsGrid.DataSource = null;
        m_txtIdsCount.Text = string.Empty;
      }
    }

    private void OnGridResponceIdCellClick(object sender, DataGridViewCellEventArgs e)
    {
      BaseBookmark bookmark = (BaseBookmark)m_idsGrid.Rows[e.RowIndex].DataBoundItem;
      m_mvcManager.SetActiveTabByCaption(m_requestAndResponseControl.Caption);
      m_requestAndResponseControl.FindInResponce(bookmark);
    }

    private void OnFocusedIndexChanged(object sender, FocusedIndexChangedEventArgs e)
    {
      UpdateContent();
    }


    /// <summary>
    /// Get map of column text to Frec property name
    /// </summary>
    /// <returns></returns>
    private Dictionary<string, string> GetFilterablePropertiesNames()
    {
      Dictionary<string, string> map = new Dictionary<string, string>();
      map.Add("Id", "Id");
      map.Add("Frec", "Title");
      map.Add("wait", "Wait");
      map.Add("Wait", "Wait");
      map.Add("Table", "TableName");
      map.Add("Thread", "Thread");
      map.Add("Session", "SessionId");

      map.Add("Error", "IsFailed");
      map.Add("Fail", "IsFailed");
      map.Add("Server", "Server");
      map.Add("Parse Duration", "ParseDuration");

      return map;
    }

    #endregion

    #region Delegates

    private delegate IList<string> GetFilePatternsDelegate();

    private delegate void UpdateStatusDelegate(string status);

    private delegate void UpdatePrevNextFilesDelegate(string prevFile, string nextFile);

    #endregion

  }
}
