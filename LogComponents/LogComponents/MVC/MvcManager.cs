using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace LogComponents.MVC
{
  public partial class MvcManager : TabControl
  {

    #region Private members

    IMvcContext m_mvcContext;
    ConfigBase m_options;
    bool m_isInitialized = false;
    IList<MvcTabPage> m_tabPages = new List<MvcTabPage>();

    #endregion

    #region Ctor

    public MvcManager()
    {
      InitializeComponent();
      SelectedIndexChanged += OnSelectedIndexChanged;
    }

    #endregion

    #region Public properties

    public ConfigBase Options
    {
      get
      {
        return m_options;
      }
    }

    public IMvcContext MvcContext
    {
      get
      {
        return m_mvcContext;
      }
    }

    #endregion

    #region Public methods

    public void Initialize(ConfigBase options)
    {
      Debug.Assert(!m_isInitialized, "Already initialized");

      m_isInitialized = true;
      m_options = options;
    }

    public void AddTab(MvcControl mvcControl)
    {
      Debug.Assert(m_isInitialized, "Still not initialized");

      MvcTabPage tabPage = new MvcTabPage(this, mvcControl);
      
      tabPage.VisibleChanged += OnTabVisibleChanged;
      int index = FindIndexToInsert(tabPage);
      TabPages.Insert(index, tabPage);
      tabPage.Initialize();
      
      

      m_tabPages.Add(tabPage);
    }

    public void SetMvcContext(IMvcContext mvcContext)
    {
      m_mvcContext = mvcContext;
      SetMvcContextToSelectedTab(false);
      //UpdateTabVisibility();currently this feature isn't in use
    }

    public void SaveState()
    {
      foreach (MvcTabPage tabPage in m_tabPages)
      {
        tabPage.SaveState();
      }
    }

    public MvcControl SetActiveTabByCaption(string caption)
    {
      MvcTabPage tabPage = FindTabByCaption(caption);
      if (tabPage != null)
      {
        SelectedTab = tabPage;
        return tabPage.MvcControl;
      }

      return null;
    }

    public void UpdateContent()
    {
      for (int i=0; i < TabPages.Count; i++)
      {
        if (SelectedTab == TabPages[i])
        {
          ((MvcTabPage)SelectedTab).SetMvcContext(m_mvcContext, true);
        }
        else
        {
          ((MvcTabPage)TabPages[i]).SetMvcContext(null, false);
        }
      }
    }

    #endregion

    #region Private methods

    private MvcTabPage FindTabByCaption(string caption)
    {
      foreach (MvcTabPage tabPage in TabPages)
      {
        if (tabPage.Text == caption)
        {
          return tabPage;
        }
      }
      return null;
    }

    private void OnSelectedIndexChanged(object sender, EventArgs e)
    {
      SetMvcContextToSelectedTab(false);
    }

    private void UpdateTabVisibility()
    {
      foreach (MvcTabPage tabPage in m_tabPages)
      {
        tabPage.Visible = tabPage.isVisibleForContext(m_mvcContext);
      }
    }

    private void SetMvcContextToSelectedTab(bool forceRefresh)
    {
      if (DesignMode)
      {
        return;
      }

      ((MvcTabPage)SelectedTab).SetMvcContext(m_mvcContext, forceRefresh);
    }

    private void OnTabVisibleChanged(object sender, EventArgs e)
    {
      Debug.Assert(sender != null && sender is MvcTabPage);
      MvcTabPage tabPage = (MvcTabPage)sender;
      if (!tabPage.Visible)
      {
        TabPages.Remove(tabPage);
      }
      else //from non visible to  visible: need to insert
      {
        int index = FindIndexToInsert(tabPage);

        TabPages.Insert(index, tabPage);

      }

    }

    private int FindIndexToInsert(MvcTabPage tabPage)
    {
      int i = 0;
      for (; i < TabPages.Count; i++)
      {
        if (((MvcTabPage)TabPages[i]).Order > tabPage.Order)
        {
          break;
        }
      }
      return i;
    }

    #endregion
  }
}
