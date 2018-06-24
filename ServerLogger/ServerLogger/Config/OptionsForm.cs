using System;
using System.Diagnostics;
using System.Windows.Forms;
using LogComponents;

namespace ServerLogger
{
    public enum Tabs { Any, RequestColumns, RowColumns };
    public partial class OptionsForm : Form
    {
        Options m_options;
        bool m_needRefresh;
        OptionColors m_optionColors;
        FolderBrowserDialog m_openFolderDialog;

        public OptionsForm()
        {
            InitializeComponent();
            m_options = Options.GetInstance;
            m_optionColors = new OptionColors();
            m_optionColors.Modify += OnModify;

            m_cmbShortcutFolders.SelectedIndex = 1;

            PopulateOptions();

            PopulateAbout();

            m_propColors.SelectedObject = m_optionColors;
        }

        private void PopulateOptions()
        {
            m_txtRepository.Text = Helpers.IOUtilities.GetPathToApplicationRepository();

            m_txtPurgeFolder.Text = m_options.PurgingFolder;
            m_chkRemoveOldFiles.Checked = m_options.RemoveOldFiles;
            m_nmrOldFilesThreshold.Value = m_options.OldFilesThreshold;
            m_nmrOldFilesThreshold.Enabled = m_chkRemoveOldFiles.Checked;

            m_optionColors.Populate();
            m_propColors.Refresh();

            m_btnApply.Enabled = false;
            m_needRefresh = false;
        }

        private void SaveOptions()
        {
            m_options.PurgingFolder = m_txtPurgeFolder.Text;
            m_options.RemoveOldFiles = m_chkRemoveOldFiles.Checked;
            m_options.OldFilesThreshold = (int)m_nmrOldFilesThreshold.Value;

            m_optionColors.SaveChanges();

            m_btnApply.Enabled = false;
            m_needRefresh = false;

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
        }

        public void InitializeColumns(DataGridViewColumnCollection requestColumns, DataGridViewColumnCollection rowColumns)
        {
            m_ucRequestColumns.Initialize(m_options, requestColumns);
            m_ucRowColumns.Initialize(m_options, rowColumns);
        }

        #region Events

        private void OnRestoreClick(object sender, EventArgs e)
        {
            string message = "Are you sure you want restore default options";
            if (Helpers.FormUtilities.ShowMessage(message, MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            m_options.SetDefault();
            PopulateOptions();
            m_options.RaiseOnSaved(this);
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
            if (sender == m_chkRemoveOldFiles)
            {
                m_nmrOldFilesThreshold.Enabled = m_chkRemoveOldFiles.Checked;
            }

            m_btnApply.Enabled = true;
        }

        #endregion

        public void ShowDialog(Tabs tab)
        {
            switch (tab)
            {
                case Tabs.RequestColumns:
                    m_tabControl.SelectedTab = m_tabRequestColumns;
                    break;
                case Tabs.RowColumns:
                    m_tabControl.SelectedTab = m_tabRowColumns;
                    break;
            }

            this.ShowDialog();
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

        private void OnBtnOpenRepositoryClick(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.FileName = m_txtRepository.Text;
            process.Start();
        }

        private void OnBtnDefinePurgeFolderClick(object sender, EventArgs e)
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
                m_options.PurgingFolder =
                  m_txtPurgeFolder.Text = m_openFolderDialog.SelectedPath;

            }
        }

        private void OnShown(object sender, EventArgs e)
        {
            m_ucRequestColumns.SortByDisplayIndex();
            m_ucRowColumns.SortByDisplayIndex();
        }
    }
}
