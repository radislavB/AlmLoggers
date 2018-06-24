using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using LogComponents;

namespace ServerLogger
{
  public class OptionColors
  {
    Options m_options;

    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    Color m_backColorDBG;
    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    Color m_backColorFLW;
    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    Color m_backColorWRN;
    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    Color m_backColorERR;

    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    Color m_gridBackColor;
    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    Color m_requestRowColor;

    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    Color m_messageBackColor;
    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    Font m_messageFont;
    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    Color m_messageForeColor;
    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    Color m_messageErrorForeColor;

    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    Color m_sqlForeColor;
    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    Color m_sqlBackColor;
    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    Font m_sqlFont;

    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    Color m_customForeColor;
    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    Color m_customBackColor;
    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    Font m_customFont;
    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    StringList m_customWords;

    public event EventHandler Modify;

    //**************************************************************************
    [DefaultValue(typeof(Color), "Cornsilk")]
    [Category("1.Type background")]
    [DisplayName("DBG")]
    public Color BackColorDBG
    {
      get
      {
        return m_backColorDBG;
      }
      set
      {
        m_backColorDBG = value;
        OnModify();
      }
    }

    [DefaultValue(typeof(Color), "PowderBlue")]
    [Category("1.Type background")]
    [DisplayName("FLW")]
    public Color BackColorFLW
    {
      get
      {
        return m_backColorFLW;
      }
      set
      {
        m_backColorFLW = value;
        OnModify();
      }
    }

    [DefaultValue(typeof(Color), "GreenYellow")]
    [Category("1.Type background")]
    [DisplayName("WRN")]
    public Color BackColorWRN
    {
      get
      {
        return m_backColorWRN;
      }
      set
      {
        m_backColorWRN = value;
        OnModify();
      }
    }

    [DefaultValue(typeof(Color), "Bisque")]
    [Category("1.Type background")]
    [DisplayName("ERR")]
    public Color BackColorERR
    {
      get
      {
        return m_backColorERR;
      }
      set
      {
        m_backColorERR = value;
        OnModify();
      }
    }

    //**************************************************************************
    [DefaultValue(typeof(Color), "AppWorkspace")]
    [Category("0.Grid")]
    [DisplayName("Grid background")]
    public Color GridBackColor
    {
      get
      {
        return m_gridBackColor;
      }
      set
      {
        m_gridBackColor = value;
        OnModify();
      }
    }

    [DefaultValue(typeof(Color), "NavajoWhite")]
    [Category("0.Grid")]
    [DisplayName("Request row color")]
    public Color RequestRowColor
    {
      get
      {
        return m_requestRowColor;
      }
      set
      {
        m_requestRowColor = value;
        OnModify();
      }
    }
    
    //**************************************************************************
    [DefaultValue(typeof(Color), "Control")]
    [Category("2.Message textbox")]
    [DisplayName("Background color")]
    public Color MessageBackColor
    {
      get
      {
        return m_messageBackColor;
      }
      set
      {
        m_messageBackColor = value;
        OnModify();
      }
    }

    [DefaultValue(typeof(Color), "Black")]
    [Category("2.Message textbox")]
    [DisplayName("Fore color")]
    public Color MessageForeColor
    {
      get
      {
        return m_messageForeColor;
      }
      set
      {
        m_messageForeColor = value;
        OnModify();
      }
    }

    [DefaultValue(typeof(Color), "Red")]
    [Category("2.Message textbox")]
    [DisplayName("Error fore color")]
    public Color MessageErrorForeColor
    {
      get
      {
        return m_messageErrorForeColor;
      }
      set
      {
        m_messageErrorForeColor = value;
        OnModify();
      }
    }

    [DefaultValue(typeof(Font), "Microsoft Sans Serif, 8.25pt")]
    [Category("2.Message textbox")]
    [DisplayName("Font")]
    public Font MessageFont
    {
      get
      {
        return m_messageFont;
      }
      set
      {
        m_messageFont = value;
        OnModify();
      }
    }

    //**************************************************************************
    [DefaultValue(typeof(Color), "Control")]
    [Category("3.SQL words")]
    [DisplayName("Background color")]
    public Color SqlBackColor
    {
      get
      {
        return m_sqlBackColor;
      }
      set
      {
        m_sqlBackColor = value;
        OnModify();
      }
    }

    [DefaultValue(typeof(Color), "Black")]
    [Category("3.SQL words")]
    [DisplayName("Fore color")]
    public Color SqlForeColor
    {
      get
      {
        return m_sqlForeColor;
      }
      set
      {
        m_sqlForeColor = value;
        OnModify();
      }
    }

    [DefaultValue(typeof(Font), "Microsoft Sans Serif, 8.25pt, style=Bold")]
    [Category("3.SQL words")]
    [DisplayName("Font")]
    public Font SqlFont
    {
      get
      {
        return m_sqlFont;
      }
      set
      {
        m_sqlFont = value;
        OnModify();
      }
    }


    //**************************************************************************
    [DefaultValue(typeof(Color), "Yellow")]
    [Category("4.Custom words")]
    [DisplayName("Background color")]
    public Color CustomBackColor
    {
      get
      {
        return m_customBackColor;
      }
      set
      {
        m_customBackColor = value;
        OnModify();
      }
    }

    [DefaultValue(typeof(Color), "Red")]
    [Category("4.Custom words")]
    [DisplayName("Fore color")]
    public Color CustomForeColor
    {
      get
      {
        return m_customForeColor;
      }
      set
      {
        m_customForeColor = value;
        OnModify();
      }
    }

    [DefaultValue(typeof(Font), "Microsoft Sans Serif, 8.25pt, style=Bold")]
    [Category("4.Custom words")]
    [DisplayName("Font")]
    public Font CustomFont
    {
      get
      {
        return m_customFont;
      }
      set
      {
        m_customFont = value;
        OnModify();
      }
    }

    [DefaultValue(typeof(StringList), "/*VC TABLE NAME SQL*/|/*VC TEST SQL*/")]
    [Category("4.Custom words")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Editor(
        "System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
        "System.Drawing.Design.UITypeEditor,System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    public StringList Words
    {
      get
      {
        return m_customWords;
      }
      set
      {
        m_customWords = value;
        OnModify();
      }
    }

    //**************************************************************************
    public OptionColors()
    {
      m_options = Options.GetInstance;
    }

    public void Populate()
    {
      m_backColorDBG = m_options.BackColorDBG;
      m_backColorFLW = m_options.BackColorFLW;
      m_backColorWRN = m_options.BackColorWRN;
      m_backColorERR = m_options.BackColorERR;

      m_gridBackColor = m_options.GridBackColor;
      m_requestRowColor = m_options.RequestRowColor;

      m_messageBackColor = m_options.MessageBackColor;
      m_messageFont = m_options.MessageFont;
      m_messageForeColor = m_options.MessageForeColor;
      m_messageErrorForeColor = m_options.MessageErrorForeColor;

      m_sqlForeColor = m_options.SqlForeColor;
      m_sqlBackColor = m_options.SqlBackColor;
      m_sqlFont = m_options.SqlFont;

      m_customForeColor = m_options.CustomForeColor;
      m_customBackColor = m_options.CustomBackColor;
      m_customFont = m_options.CustomFont;
      m_customWords = m_options.CustomSelectedWords;
    }

    public void SaveChanges()
    {
      m_options.BackColorDBG = m_backColorDBG;
      m_options.BackColorFLW = m_backColorFLW;
      m_options.BackColorWRN = m_backColorWRN;
      m_options.BackColorERR = m_backColorERR;

      m_options.GridBackColor = m_gridBackColor;
      m_options.RequestRowColor = m_requestRowColor;

      m_options.MessageBackColor = m_messageBackColor;
      m_options.MessageFont = m_messageFont;
      m_options.MessageForeColor = m_messageForeColor;
      m_options.MessageErrorForeColor = m_messageErrorForeColor;

      m_options.SqlForeColor = m_sqlForeColor;
      m_options.SqlBackColor = m_sqlBackColor;
      m_options.SqlFont = m_sqlFont;

      m_options.CustomForeColor = m_customForeColor;
      m_options.CustomBackColor = m_customBackColor;
      m_options.CustomFont = m_customFont;
      m_options.CustomSelectedWords = m_customWords;
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
