using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using LogComponents;
using LogComponents.FilterControl;
using ServerLogger.Parser;
using ServerLogger.Properties;
using ServerLogger.Mvc;

namespace ServerLogger
{
  public partial class MainForm : Form
  {
    OpenFileDialog m_openFileDialog;
    FolderBrowserDialog m_openFolderDialog;
    GroupByRequestControl m_groupByRequestControl;

    Options m_options;
    LogRequestCollection m_requestCollection;

    ParserManagerAsync m_parserManagerAsync;

    IList<string> lastLoadedFileNames = new List<String>();

    #region Event handlers : form & menus

    public MainForm()
    {
      InitializeComponent();

      m_options = Options.GetInstance;


      m_parserManagerAsync = new ParserManagerAsync();
      m_parserManagerAsync.JobFinished += OnParserManagerAsyncJobFinished;

      PurgeOldFiles();
    }

    private void PurgeOldFiles()
    {
      if (m_options.RemoveOldFiles &&
        !string.IsNullOrEmpty(m_options.PurgingFolder) &&
        Directory.Exists(m_options.PurgingFolder))
      {
        ThreadPool.QueueUserWorkItem(DeleteOldFilesWaitCallback);
      }
    }

    /// <summary>
    /// Method is used for ThreadPool to execute DeleteOldFiles
    /// </summary>
    private void DeleteOldFilesWaitCallback(object state)
    {
      int deletedCount = Helpers.IOUtilities.DeleteOldFiles(m_options.PurgingFolder, Constants.FILE_FILTER, m_options.OldFilesThreshold);

      if (deletedCount > 0)
      {
        UpdateStatus(deletedCount.ToString() + " old file(s) were deleted from log directory");
      }
    }

    private void OnLoad(object sender, EventArgs e)
    {
      SetInitialSizes();
      InitializeTabs();

      Helpers.FormUtilities.RegisterRecursiveDragDropEvent(this, OnDragDrop, OnDragEnter);
    }

    /// <summary>
    /// Load log from single file or directory
    /// </summary>
    /// <param name="path"></param>
    private void LoadLog(string path)
    {
      if (!Directory.Exists(path))//is file
      {
        LoadLog(new string[] { path });
      }
      else //folder
      {
        IList<string> fileNames = Helpers.IOUtilities.GetFileNames(path, Constants.FILE_FILTER, SearchOption.TopDirectoryOnly);
        if (fileNames.Count == 0)
          Helpers.FormUtilities.ShowMessage("No log file is found");
        else
          LoadLog(fileNames);
      }
    }

    private void LoadLog(IList<string> fileNames)
    {
      //if its directory path, use another overload
      if (fileNames.Count == 1 && Helpers.IOUtilities.IsDirectory(fileNames[0]))
      {
        LoadLog(fileNames[0]);
        return;
      }

      m_options.LastOpenedFolder = Path.GetDirectoryName(fileNames[0]);
      m_parserManagerAsync.FileNames = fileNames;
      m_parserManagerAsync.Start();
    }

    private void OnParserManagerAsyncJobFinished(object sender, EventArgs e)
    {
      if (InvokeRequired)
      {
        Invoke(new EventHandler<EventArgs>(OnParserManagerAsyncJobFinished), sender, e);
        return;
      }

      if (m_parserManagerAsync.IsCanceled)
        return;

      if (m_parserManagerAsync.JobFailed)
      {
        Helpers.FormUtilities.ShowMessage(m_parserManagerAsync.FailMessage);
        return;
      }


      m_requestCollection = m_parserManagerAsync.LogRequestCollection;

      int focusedIndex = m_groupByRequestControl.FocusedIndex;

      PopulateForm();

      if (focusedIndex > 0 && lastLoadedFileNames.Count == 1 && m_parserManagerAsync.FileNames.Count == 1 &&
        lastLoadedFileNames[0].Equals(m_parserManagerAsync.FileNames[0]))
      {
        m_groupByRequestControl.FocusedIndex = focusedIndex;
      }

      lastLoadedFileNames = m_parserManagerAsync.FileNames;
    }

    private void PopulateForm()
    {
      m_mainMvcManager.SetMvcContext(m_requestCollection);

      //set buttons
      //isSingleFileLog
      if (m_requestCollection.FileNames.Count == 1)
      {
        UpdateNextPrevLogs(m_requestCollection.FileNames[0]);
        m_btnSourceFile.Enabled = true;
      }
      else
      {
        //disable prevFile,NextFile,OpenSource
        m_btnNextFile.Enabled = false;
        m_btnNextFile.ToolTipText = string.Empty;
        m_btnPrevFile.Enabled = false;
        m_btnPrevFile.ToolTipText = string.Empty;
        m_btnSourceFile.Enabled = false;
      }

      //set caption
      string caption;
      if (m_requestCollection.FileNames.Count == 1)
        caption = Path.GetFileName(m_requestCollection.FileNames[0]);
      else
        caption = string.Format("Merge of {0} files", m_requestCollection.FileNames.Count);

      Text = String.Format("{0} - {1} ({2}) {3}", //0-product name, 1- file name,2-version,3- file in process
        ExecutingAssembly.ProductName,
        caption,
        m_requestCollection.LogVersion,
        m_requestCollection.IsFileLocked ? " (file in process)" : string.Empty
        );
    }

    private void UpdateNextPrevLogs(string fileName)
    {
      string prev, next;
      Helpers.IOUtilities.GetPrevNextFiles(fileName, Constants.FILE_FILTER, Constants.MIN_LOG_FILE_SIZE, out prev, out next);

      //set buttons
      if (next != null)
      {
        m_btnNextFile.Enabled = true;
        m_btnNextFile.ToolTipText = "Load next log: " + Path.GetFileName(next);
        m_btnNextFile.Tag = next;
      }
      else
      {
        m_btnNextFile.Enabled = false;
        m_btnNextFile.ToolTipText = null;
        m_btnNextFile.Tag = null;
      }

      if (prev != null)
      {
        m_btnPrevFile.Enabled = true;
        m_btnPrevFile.ToolTipText = "Load prev log: " + Path.GetFileName(prev);
        m_btnPrevFile.Tag = prev;
      }
      else
      {
        m_btnPrevFile.Enabled = false;
        m_btnPrevFile.ToolTipText = null;
        m_btnPrevFile.Tag = null;
      }
    }

    private void OnBtnLoadFolderClick(object sender, EventArgs e)
    {
      if (m_openFolderDialog == null)
      {
        m_openFolderDialog = new FolderBrowserDialog();
        m_openFolderDialog.SelectedPath = m_options.LastOpenedFolder;
        m_openFolderDialog.ShowNewFolderButton = false;
      }

      DialogResult dr = m_openFolderDialog.ShowDialog(this);
      if (dr == DialogResult.OK)
      {
        LoadLog(m_openFolderDialog.SelectedPath);
      }
    }

    private void OnBtnLoadFileClick(object sender, EventArgs e)
    {
      if (m_openFileDialog == null)
      {
        m_openFileDialog = new OpenFileDialog();
        m_openFileDialog.Filter = Constants.OPEN_FILE_DIALOG_FILTER;
        m_openFileDialog.ShowHelp = false;
        m_openFileDialog.Multiselect = true;
        m_openFileDialog.CheckFileExists = true;
        m_openFileDialog.CheckPathExists = true;
        m_openFileDialog.Title = "Find Server Log File";
        m_openFileDialog.InitialDirectory = m_options.LastOpenedFolder;
        if (!Directory.Exists(m_openFileDialog.InitialDirectory))
          m_openFileDialog.InitialDirectory = Constants.INITIAL_LOG_FOLDER;
      }

      DialogResult dr = m_openFileDialog.ShowDialog(this);
      if (dr == DialogResult.OK)
      {
        LoadLog(m_openFileDialog.FileNames);
      }
    }

    private void OnBtnSourceFileClick(object sender, EventArgs e)
    {
      Helpers.IOUtilities.OpenFile(m_requestCollection.FileNames[0]);
    }

    private void OnDragDrop(object sender, DragEventArgs e)
    {
      string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
      LoadLog(fileNames);
    }

    private void OnDragEnter(object sender, DragEventArgs e)
    {
      string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
      bool isOk = true;
      if (fileNames.Length == 0)//at least one file name must exist
      {
        isOk = false;
      }
      else if (Helpers.IOUtilities.IsDirectory(fileNames[0]))//allow only one directory
      {
        isOk = (fileNames.Length == 1);
      }
      else
      {
        foreach (string fileName in fileNames)
        {
          //all files must match pattern
          if (!Regex.IsMatch(fileName, Constants.DRAG_DROP_FILTER_REGEX, RegexOptions.IgnoreCase))
          {
            isOk = false;
            break;
          }
        }
      }

      if (isOk)
        e.Effect = DragDropEffects.Copy;
      else
        e.Effect = DragDropEffects.None;
    }

    private void OnBtnPrevNextClick(object sender, EventArgs e)
    {
      string path = (string)((ToolStripButton)sender).Tag;
      LoadLog(path);
    }

    private void OnBtnLastFileClick(object sender, EventArgs e)
    {
      string lastFileName = Helpers.IOUtilities.GetLastModifiedFile(m_options.LastOpenedFolder, Constants.FILE_FILTER, Constants.MIN_LOG_FILE_SIZE);
      if (lastFileName == null)
      {
        MessageBox.Show("No appropriate QcLog file found in " + m_options.LastOpenedFolder);
      }
      else
      {
        LoadLog(lastFileName);
      }
    }

    private void OnBtnOptionsClick(object sender, EventArgs e)
    {
      OptionsForm optionForm = new OptionsForm();
      optionForm.InitializeColumns(m_groupByRequestControl.RequestCollumns, m_groupByRequestControl.SubRequestCollumns);
      optionForm.ShowDialog(this);
    }

    private void OnClosing(object sender, FormClosingEventArgs e)
    {
      m_options.WindowSize = Size;
      m_options.WindowMaximized = (WindowState == FormWindowState.Maximized);
      m_mainMvcManager.SaveState();

      m_options.Save();
    }

    #endregion

    private void InitializeTabs()
    {
      m_mainMvcManager.Initialize(m_options);
      m_mainMvcManager.AddTab(m_groupByRequestControl = new GroupByRequestControl());
      m_mainMvcManager.AddTab(new PlainViewControl());
    }

    private void SetInitialSizes()
    {
      if (m_options.WindowMaximized)
      {
        WindowState = FormWindowState.Maximized;
      }
      else
      {
        Size = m_options.WindowSize;
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

    private delegate void UpdateStatusDelegate(string status);
  }
}