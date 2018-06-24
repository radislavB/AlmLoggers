using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace LogComponents.MVC
{
  public partial class MvcTabPage : TabPage
  {
    private MvcManager m_mvcManager;
    private MvcControl m_mvcControl;
    private bool m_visible = true;

    internal new event EventHandler VisibleChanged;

    public MvcTabPage(MvcManager parent, MvcControl mvcControl)
    {
      InitializeComponent();
      m_mvcControl = mvcControl;
      m_mvcManager = parent;

      m_mvcControl.Dock = DockStyle.Fill;
      Controls.Add(m_mvcControl);
      Text = m_mvcControl.Caption;
    }

    private MvcTabPage(IContainer container)
    {
      container.Add(this);

      InitializeComponent();
    }

    public void Initialize()
    {    
      m_mvcControl.Initialize(this);
    }

    public MvcManager MvcManager
    {
      get { return m_mvcManager; }
    }

    public MvcControl MvcControl
    {
      get { return m_mvcControl; }
    }

    public new bool Visible
    {
      get
      { return m_visible; }
      set
      {
        if (m_visible != value)
        {
          m_visible = value;
          if (VisibleChanged != null)
          {
            VisibleChanged(this, EventArgs.Empty);
          }
        }

      }
    }

    public int Order
    {
      get
      {
        return MvcControl.Order;
      }
    }

    public void SaveState()
    {
      MvcControl.SaveState();
    }

    public void SetMvcContext(IMvcContext context, bool forceRefresh)
    {
      MvcControl.SetMvcContext(context, forceRefresh);
    }

    public bool isVisibleForContext(IMvcContext context)
    {
      return MvcControl.isVisibleForContext(context);
    }

  }
}
