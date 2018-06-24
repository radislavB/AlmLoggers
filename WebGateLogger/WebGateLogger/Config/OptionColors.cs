using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using LogComponents;

namespace WebGateLogger
{
  public class OptionColors
  {
    Options m_options;

    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    Color m_requestBackColor;
    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    Color m_requestForeColor;
    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    Font m_requestFont;

    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    Color m_responseBackColor;
    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    Color m_responseForeColor;
    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    Color m_responceErrorForeColor;
    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    Font m_responceFont;

    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    Color m_selectionBackColor;
    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    Color m_selectionForeColor;
    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    Font m_selectionFont;

    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    Color m_gridMainRequestColor;
    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    Color m_gridSecondaryRequestColor;

    public event EventHandler Modify;

    [DefaultValue(typeof(Color), "Control")]
    [Category("Request")]
    [DisplayName("BackColor")]
    public Color RequestBackColor
    {
      get
      {
        return m_requestBackColor;
      }
      set
      {
        m_requestBackColor = value;
        OnModify();
      }
    }

    [DefaultValue(typeof(Color), "WindowText")]
    [Category("Request")]
    [DisplayName("ForeColor")]
    public Color RequestForeColor
    {
      get
      {
        return m_requestForeColor;
      }
      set
      {
        m_requestForeColor = value;
        OnModify();
      }
    }

    [DefaultValue(typeof(Font), "Microsoft Sans Serif, 8.25pt")]
    [Category("Request")]
    [DisplayName("Font")]
    public Font RequestFont
    {
      get
      {
        return m_requestFont;
      }
      set
      {
        m_requestFont = value;
        OnModify();
      }
    }

    [DefaultValue(typeof(Color), "WindowText")]
    [Category("Response")]
    [DisplayName("ForeColor")]
    public Color ResponseForeColor
    {
      get
      {
        return m_responseForeColor;
      }
      set
      {
        m_responseForeColor = value;
        OnModify();
      }
    }

    [DefaultValue(typeof(Color), "Control")]
    [Category("Response")]
    [DisplayName("BackColor")]
    public Color ResponseBackColor
    {
      get
      {
        return m_responseBackColor;
      }
      set
      {
        m_responseBackColor = value;
        OnModify();
      }
    }

    [DefaultValue(typeof(Color), "Red")]
    [Category("Response")]
    [DisplayName("Error ForeColor")]
    public Color ResponceErrorForeColor
    {
      get
      {
        return m_responceErrorForeColor;
      }
      set
      {
        m_responceErrorForeColor = value;
        OnModify();
      }
    }

    [DefaultValue(typeof(Font), "Microsoft Sans Serif, 8.25pt")]
    [Category("Response")]
    [DisplayName("Font")]
    public Font ResponceFont
    {
      get
      {
        return m_responceFont;
      }
      set
      {
        m_responceFont = value;
        OnModify();
      }
    }

    [DefaultValue(typeof(Color), "Fuchsia")]
    [Category("Selection")]
    [DisplayName("BackColor")]
    public Color SelectionBackColor
    {
      get
      {
        return m_selectionBackColor;
      }
      set
      {
        m_selectionBackColor = value;
        OnModify();
      }
    }

    [DefaultValue(typeof(Color), "WindowText")]
    [Category("Selection")]
    [DisplayName("ForeColor")]
    public Color SelectionForeColor
    {
      get
      {
        return m_selectionForeColor;
      }
      set
      {
        m_selectionForeColor = value;
        OnModify();
      }
    }

    [DefaultValue(typeof(Font), "Microsoft Sans Serif, 8.25pt")]
    [Category("Selection")]
    [DisplayName("Font")]
    public Font SelectionFont
    {
      get
      {
        return m_selectionFont;
      }
      set
      {
        m_selectionFont = value;
        OnModify();
      }
    }


    //****GRID********//
    [DefaultValue(typeof(Color), "NavajoWhite")]
    [Category("Grid")]
    [DisplayName("Main request color")]
    public Color GridMainRequestColor
    {
      get
      {
        return m_gridMainRequestColor;
      }
      set
      {
        m_gridMainRequestColor = value;
        OnModify();
      }
    }

    [DefaultValue(typeof(Color), "SeaShell")]
    [Category("Grid")]
    [DisplayName("Secondary request color")]
    public Color GridSecondaryRequestColor
    {
      get
      {
        return m_gridSecondaryRequestColor;
      }
      set
      {
        m_gridSecondaryRequestColor = value;
        OnModify();
      }
    }


    public OptionColors()
    {
      m_options = Options.GetInstance;
    }

    public void PopulateColors()
    {
      m_requestBackColor = m_options.RequestBackColor;
      m_requestForeColor = m_options.RequestForeColor;
      m_requestFont = m_options.RequestFont;

      m_responseBackColor = m_options.ResponseBackColor;
      m_responseForeColor = m_options.ResponseForeColor;
      m_responceErrorForeColor = m_options.ResponceErrorForeColor;
      m_responceFont = m_options.ResponceFont;

      m_selectionBackColor = m_options.SelectionBackColor;
      m_selectionForeColor = m_options.SelectionForeColor;
      m_selectionFont = m_options.SelectionFont;

      m_gridMainRequestColor = m_options.GridMainRequestColor;
      m_gridSecondaryRequestColor = m_options.GridSecondaryRequestColor;
    }

    public void SaveChanges()
    {
      m_options.RequestBackColor = m_requestBackColor;
      m_options.RequestForeColor = m_requestForeColor;
      m_options.RequestFont = m_requestFont;

      m_options.ResponseBackColor = m_responseBackColor;
      m_options.ResponseForeColor = m_responseForeColor;
      m_options.ResponceErrorForeColor = m_responceErrorForeColor;
      m_options.ResponceFont = m_responceFont;

      m_options.SelectionBackColor = m_selectionBackColor;
      m_options.SelectionForeColor = m_selectionForeColor;
      m_options.SelectionFont = m_selectionFont;

      m_options.GridMainRequestColor = m_gridMainRequestColor;
      m_options.GridSecondaryRequestColor = m_gridSecondaryRequestColor;
    }

    private void OnModify()
    {
      if (Modify != null)
      {
        Modify(this, EventArgs.Empty);
      }
    }
  }
}
