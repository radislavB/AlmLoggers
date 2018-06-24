using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace LogComponents.MVC
{
  public partial class MvcControl : UserControl
  {
    private IMvcContext m_mvcContext;
    private MvcTabPage m_mvcTabPage;

    public MvcControl()
    {
      InitializeComponent();
    }

    internal void Initialize(MvcTabPage parent)
    {
      m_mvcTabPage = parent;
      Initialize();
    }

    public virtual void Initialize()
    {
    }

    protected virtual void OnMvcContextChanged()
    {
    }

    /// <summary>
    /// Get caption of the control
    /// </summary>
    public virtual string Caption
    {
      get
      {
        throw new NotImplementedException("Caption property isn't implemented in " + GetType().Name);
      }
    }

    public virtual int Order
    {
      get
      {
        throw new NotImplementedException("Order property isn't implemented in " + GetType().Name);
      }
    }

    internal void SetMvcContext(IMvcContext mvcContext, bool forceRefresh)
    {
      if (forceRefresh || m_mvcContext != mvcContext)
      {
        m_mvcContext = mvcContext;
        OnMvcContextChanged();
      }
    }


    /// <summary>
    /// Get existing mvc context
    /// </summary>
    public IMvcContext MvcContext
    {
      get
      {
        return m_mvcContext;
      }
    }

    public ConfigBase Options
    {
      get
      {
        return m_mvcTabPage.MvcManager.Options;
      }
    }

    public virtual void SaveState()
    {
    }

    public virtual bool isVisibleForContext(IMvcContext context)
    {
      return true;
    }

  }
}
