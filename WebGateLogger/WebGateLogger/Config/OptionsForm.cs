using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;
using LogComponents;
using System.Deployment.Application;

namespace WebGateLogger
{
  public enum Tabs { Any, Columns };
  public partial class OptionsForm : Form
  {
    Options m_options;
    bool m_needRefresh;
    OptionColors m_optionColors;
    Dictionary<Control, object> m_needReloadAfterModifyControls = new Dictionary<Control, object>();

    public OptionsForm()
    {
      InitializeComponent();
      m_options = Options.GetInstance;
      m_optionColors = new OptionColors();
      m_optionColors.Modify += OnModify;
      m_logConfigurationView.OnModify += OnModify;
      m_propColors.SelectedObject = m_optionColors;
      m_cmbShortcutFolders.SelectedIndex = 1;

      PopulateOptions();
      PopulateAbout();

      InitialNeedReloadAfterModifyControls();
    }

    private void InitialNeedReloadAfterModifyControls()
    {
      m_needReloadAfterModifyControls.Add(m_nmrDontIndentateResponceLargeThan, null);
      m_needReloadAfterModifyControls.Add(m_chkLazyParsing, null);
    }

    public void InitializeColumns(DataGridViewColumnCollection columns)
    {
      m_columnsControl.Initialize(m_options, columns);
    }

    private void PopulateOptions()
    {
      Application.DoEvents();
      m_chkLoadOnStart.Checked = m_options.LoadOnStart;
      m_chkScrollToBottomOnLoad.Checked = m_options.ScrollToBottomOnLoad;

      m_nmrMaximalResponseLength.Value = m_options.ParseMaximalResponseLength;
      m_nmrDontIndentateResponceLargeThan.Value = m_options.DontIndentateResponceBiggerThanSize;

      m_chkRemoveOldFiles.Checked = m_options.RemoveOldFiles;
      m_nmrOldFilesThreshold.Value = m_options.OldFilesThreshold;
      m_chkStayOnRowOnRefresh.Checked = m_options.StayOnSameRowOnRefresh;

      m_chkLoadFollowingSessionFiles.Checked = m_options.LoadFollowingSessionFiles;

      m_nmrOldFilesThreshold.Enabled = m_chkRemoveOldFiles.Checked;

      m_chkAddToContextMenuOfExplorer.Checked = m_options.AddToContextMenuOfExplorer;
      SetOpenWithContextMenuEnabled(m_chkAddToContextMenuOfExplorer.Checked);

      m_gridExcludedFrecs.Rows.Clear();
      foreach (string value in m_options.ExcludedFrecs)
      {
        m_gridExcludedFrecs.Rows.Add(value);
      }

      m_txtRepository.Text = Helpers.IOUtilities.GetPathToApplicationRepository();
      m_chkLazyParsing.Checked = m_options.LazyParsing;

      m_optionColors.PopulateColors();
      m_propColors.Refresh();

      m_btnApply.Enabled = false;
      m_needRefresh = false;
    }

    private void SaveOptions()
    {
      m_options.LoadOnStart = m_chkLoadOnStart.Checked;
      m_options.ScrollToBottomOnLoad = m_chkScrollToBottomOnLoad.Checked;

      m_options.ParseMaximalResponseLength = (int)m_nmrMaximalResponseLength.Value;
      m_options.RemoveOldFiles = m_chkRemoveOldFiles.Checked;
      m_options.OldFilesThreshold = (int)m_nmrOldFilesThreshold.Value;
      m_options.StayOnSameRowOnRefresh = m_chkStayOnRowOnRefresh.Checked;
      m_options.DontIndentateResponceBiggerThanSize = (int)m_nmrDontIndentateResponceLargeThan.Value;

      m_options.LoadFollowingSessionFiles = m_chkLoadFollowingSessionFiles.Checked;

      m_options.ExcludedFrecs.Clear();
      foreach (DataGridViewRow row in m_gridExcludedFrecs.Rows)
      {
        if (row.IsNewRow || row.Cells[0].Value == null)
        {
          continue;
        }

        string cellContent = ((string)row.Cells[0].Value).Trim();
        if (cellContent.Length > 0)
        {
          m_options.ExcludedFrecs.Add(cellContent);
        }
      }

      m_options.LazyParsing = m_chkLazyParsing.Checked;

      if (m_options.AddToContextMenuOfExplorer != m_chkAddToContextMenuOfExplorer.Checked)
      {
        SetOpenWithContextMenuEnabled(m_chkAddToContextMenuOfExplorer.Checked);
        m_options.AddToContextMenuOfExplorer = m_chkAddToContextMenuOfExplorer.Checked;
      }

      m_optionColors.SaveChanges();
      m_logConfigurationView.SaveChanges();
      m_btnApply.Enabled = false;
      m_needRefresh = false;

      RaiseOnSaveOptions();
    }

    private void SetOpenWithContextMenuEnabled(bool isEnabled)
    {
      if (isEnabled)
      {
        Helpers.RegistryUtilities.AddContextMenuItem(
          Constants.INPUT_FILES_EXTENSION,
          ExecutingAssembly.ProductName,
          "Open with &" + ExecutingAssembly.ProductName,
          Application.ExecutablePath);
      }
      else
      {
        Helpers.RegistryUtilities.RemoveFromContextMenuItem(
         Constants.INPUT_FILES_EXTENSION,
         ExecutingAssembly.ProductName);
      }
    }

    private void RaiseOnSaveOptions()
    {
      m_options.RaiseOnSaved(this);
    }

    private void PopulateAbout()
    {
      //  Initialize the AboutBox to display the product information from the assembly information.
      //  Change assembly information settings for your application through either:
      //  - Project->Properties->Application->Assembly Information
      //  - AssemblyInfo.cs
      this.m_lblProductName.Text = ExecutingAssembly.ProductName;
      this.m_lblVersion.Text = String.Format("Version {0}", ExecutingAssembly.Version);
      this.m_lblCopyright.Text = ExecutingAssembly.Copyright;
      this.m_lblCompanyName.Text = ExecutingAssembly.Company;
      this.m_txtProductDescription.Text = ExecutingAssembly.Description;

      if (ApplicationDeployment.IsNetworkDeployed)
      {
        ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
        this.m_txtProductDescription.Text = this.m_txtProductDescription.Text +
           Environment.NewLine + Environment.NewLine +
           "Installed from : " + ad.UpdateLocation.LocalPath;
      }
    }

    public void ShowDialog(Tabs tab)
    {
      switch (tab)
      {
        case Tabs.Columns:
          m_tabControl.SelectedTab = m_tabColumns;
          break;
      }

      this.ShowDialog();
    }

    protected override void OnShown(EventArgs e)
    {
      m_columnsControl.SortByDisplayIndex();
      base.OnShown(e);
    }

    #region Events

    private void OnRestoreClick(object sender, EventArgs e)
    {
      string message = "Are you sure you want restore default options";
      if (Helpers.FormUtilities.ShowMessage(message, MessageBoxButtons.YesNo) != DialogResult.Yes)
        return;

      m_options.SetDefault();
      PopulateOptions();
      RaiseOnSaveOptions();
    }

    private void OnApplyClick(object sender, EventArgs e)
    {
      if (m_needRefresh)
      {
        Helpers.FormUtilities.ShowMessage("Applying some of the changes require refresh of the file.");
      }

      SaveOptions();
    }

    private void OnOkClick(object sender, EventArgs e)
    {
      OnApplyClick(sender, e);
      DialogResult = DialogResult.OK;
    }

    private void OnCancelClick(object sender, EventArgs e)
    {
      if (m_btnApply.Enabled)
      {
        PopulateOptions();
      }
    }

    private void OnLoad(object sender, EventArgs e)
    {
      m_needRefresh = false;
    }

    private void OnModify(object sender, EventArgs e)
    {
      Control senderControl = sender as Control;
      if (senderControl != null && m_needReloadAfterModifyControls.ContainsKey(senderControl))
      {
        m_needRefresh = true;
      }

      if (sender == m_chkRemoveOldFiles)
      {
        m_nmrOldFilesThreshold.Enabled = m_chkRemoveOldFiles.Checked;
      }

      m_btnApply.Enabled = true;
    }

    private void OnGridExcludedFrecsUserRowAction(object sender, DataGridViewRowEventArgs e)
    {
      OnModify(sender, EventArgs.Empty);
    }

    private void OnGridExcludedFrecsCellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      OnModify(sender, EventArgs.Empty);
    }

    private void OnBtnOpenRepositoryClick(object sender, EventArgs e)
    {
      Process process = new Process();
      process.StartInfo.UseShellExecute = true;
      process.StartInfo.FileName = m_txtRepository.Text;
      process.Start();
    }

    private void OnBtnShortcutInCustomFolderClick(object sender, EventArgs e)
    {
      string folder = null;
      switch (m_cmbShortcutFolders.SelectedIndex)
      {
        case 1://desktop
          folder = Helpers.IOUtilities.GetPathToDesktop();
          break;
        case 2://quick toolbar
          folder = Helpers.IOUtilities.GetPathToQuickToolbar();
          break;
        default:
          FolderBrowserDialog fbDialog = new FolderBrowserDialog();
          if (fbDialog.ShowDialog() == DialogResult.OK)
          {
            folder = fbDialog.SelectedPath;
          }
          break;
      }

      if (!string.IsNullOrEmpty(folder))
      {
        Helpers.ShortcutUtilities.CreateShortcut(folder);
        Helpers.FormUtilities.ShowMessage("Shortcut created successfully.");
      }
    }

    #endregion

  }
}
