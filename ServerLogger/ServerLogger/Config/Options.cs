using System;
using System.ComponentModel;
using System.Drawing;
using LogComponents;

namespace ServerLogger
{

  public class Options : ConfigBase
  {

    static Options m_instance = new Options();


    private Options()
    {

    }

    #region Events

    /// <summary>
    /// On saved event
    /// </summary>
    public event EventHandler OnSaved;

    public void RaiseOnSaved(object sender)
    {
      if (OnSaved != null)
      {
        OnSaved(sender, EventArgs.Empty);
      }
    }

    #endregion


    public static Options GetInstance
    {
      get
      {
        return m_instance;
      }
    }

    /// <summary>
    /// Point whether to load file on start
    /// </summary>
    [DefaultValue("C:/")]
    public string LastOpenedFolder
    {
      get
      {
        return Get<string>(PROPS.LAST_OPENED_FOLDER);
      }
      set
      {
        Set(PROPS.LAST_OPENED_FOLDER, value);
      }
    }

    [DefaultValue(410)]
    public int MainSplitter
    {
      get
      {
        return Get<int>(PROPS.MAIN_SPLITTER);
      }
      set
      {
        Set(PROPS.MAIN_SPLITTER, value);
      }
    }

    [DefaultValue(350)]
    public int RightSplitter
    {
      get
      {
        return Get<int>(PROPS.RIGHT_SPLITTER);
      }
      set
      {
        Set(PROPS.RIGHT_SPLITTER, value);
      }
    }

    [DefaultValue(typeof(Size), "870,610")]
    public Size WindowSize
    {
      get
      {
        return Get<Size>(PROPS.WINDOW_SIZE);
      }
      set
      {
        Set(PROPS.WINDOW_SIZE, value);
      }
    }

    [DefaultValue(false)]
    public bool WindowMaximized
    {
      get
      {
        return Get<bool>(PROPS.WINDOW_MAXIMIZED);
      }
      set
      {
        Set(PROPS.WINDOW_MAXIMIZED, value);
      }
    }

    //**************************************************************************
    [DefaultValue(typeof(Color), "Cornsilk")]
    public Color BackColorDBG
    {
      get
      {
        return Get<Color>(PROPS.BACK_COLOR_DBG);
      }
      set
      {
        Set(PROPS.BACK_COLOR_DBG, value);
      }
    }

    [DefaultValue(typeof(Color), "PowderBlue")]
    public Color BackColorFLW
    {
      get
      {
        return Get<Color>(PROPS.BACK_COLOR_FLW);
      }
      set
      {
        Set(PROPS.BACK_COLOR_FLW, value);
      }
    }

    [DefaultValue(typeof(Color), "GreenYellow")]
    public Color BackColorWRN
    {
      get
      {
        return Get<Color>(PROPS.BACK_COLOR_WRN);
      }
      set
      {
        Set(PROPS.BACK_COLOR_WRN, value);
      }
    }

    [DefaultValue(typeof(Color), "Bisque")]
    public Color BackColorERR
    {
      get
      {
        return Get<Color>(PROPS.BACK_COLOR_ERR);
      }
      set
      {
        Set(PROPS.BACK_COLOR_ERR, value);
      }
    }

    //**************************************************************************

    [DefaultValue(typeof(Color), "AppWorkspace")]
    public Color GridBackColor
    {
      get
      {
        return Get<Color>(PROPS.GRID_BACK_COLOR);
      }
      set
      {
        Set(PROPS.GRID_BACK_COLOR, value);
      }
    }

    [DefaultValue(typeof(Color), "NavajoWhite")]
    public Color RequestRowColor
    {
      get
      {
        return Get<Color>(PROPS.REQUEST_ROW_COLOR);
      }
      set
      {
        Set(PROPS.REQUEST_ROW_COLOR, value);
      }
    }

    //**************************************************************************
    [DefaultValue(typeof(Color), "Control")]
    public Color MessageBackColor
    {
      get
      {
        return Get<Color>(PROPS.MESSAGE_BACK_COLOR);
      }
      set
      {
        Set(PROPS.MESSAGE_BACK_COLOR, value);
      }
    }

    [DefaultValue(typeof(Color), "Black")]
    public Color MessageForeColor
    {
      get
      {
        return Get<Color>(PROPS.MESSAGE_FORE_COLOR);
      }
      set
      {
        Set(PROPS.MESSAGE_FORE_COLOR, value);
      }
    }

    [DefaultValue(typeof(Color), "Red")]
    public Color MessageErrorForeColor
    {
      get
      {
        return Get<Color>(PROPS.MESSAGE_ERROR_FORE_COLOR);
      }
      set
      {
        Set(PROPS.MESSAGE_ERROR_FORE_COLOR, value);
      }
    }

    [DefaultValue(typeof(Font), "Microsoft Sans Serif, 8.25pt")]
    public Font MessageFont
    {
      get
      {
        return Get<Font>(PROPS.MESSAGE_FONT);
      }
      set
      {
        Set(PROPS.MESSAGE_FONT, value);
      }
    }

    //**************************************************************************
    [DefaultValue(typeof(Color), "Control")]
    public Color SqlBackColor
    {
      get
      {
        return Get<Color>(PROPS.SQL_BACK_COLOR);
      }
      set
      {
        Set(PROPS.SQL_BACK_COLOR, value);
      }
    }

    [DefaultValue(typeof(Color), "Black")]
    public Color SqlForeColor
    {
      get
      {
        return Get<Color>(PROPS.SQL_FORE_COLOR);
      }
      set
      {
        Set(PROPS.SQL_FORE_COLOR, value);
      }
    }

    [DefaultValue(typeof(Font), "Microsoft Sans Serif, 8.25pt, style=Bold")]
    public Font SqlFont
    {
      get
      {
        return Get<Font>(PROPS.SQL_FONT);
      }
      set
      {
        Set(PROPS.SQL_FONT, value);
      }
    }

    //**************************************************************************
    [DefaultValue(typeof(Color), "Yellow")]
    public Color CustomBackColor
    {
      get
      {
        return Get<Color>(PROPS.CUSTOM_BACK_COLOR);
      }
      set
      {
        Set(PROPS.CUSTOM_BACK_COLOR, value);
      }
    }

    [DefaultValue(typeof(Color), "Red")]
    public Color CustomForeColor
    {
      get
      {
        return Get<Color>(PROPS.CUSTOM_FORE_COLOR);
      }
      set
      {
        Set(PROPS.CUSTOM_FORE_COLOR, value);
      }
    }

    [DefaultValue(typeof(Font), "Microsoft Sans Serif, 8.25pt, style=Bold")]
    public Font CustomFont
    {
      get
      {
        return Get<Font>(PROPS.CUSTOM_FONT);
      }
      set
      {
        Set(PROPS.CUSTOM_FONT, value);
      }
    }

    [DefaultValue(typeof(StringList), "/*VC TABLE NAME SQL*/|/*VC TEST SQL*/")]
    [Category("Custom words")]
    public StringList CustomSelectedWords
    {
      get
      {
        return Get<StringList>(PROPS.CUSTOM_WORDS); ;
      }
      set
      {
        Set(PROPS.CUSTOM_WORDS, value);
      }
    }

    //**************************************************************************
    [Category("Purging")]
    [DefaultValue(false)]
    public bool RemoveOldFiles
    {
      get
      {
        return Get<bool>(PROPS.REMOVE_OLD_FILES);
      }
      set
      {
        Set(PROPS.REMOVE_OLD_FILES, value);
      }
    }

    [Category("Purging")]
    [DefaultValue(7)]
    public int OldFilesThreshold
    {
      get
      {
        return Get<int>(PROPS.OLD_FILE_THRESHOLD);
      }
      set
      {
        Set(PROPS.OLD_FILE_THRESHOLD, value);
      }
    }

    [Category("Purging")]
    [DefaultValue("")]
    public string PurgingFolder
    {
      get
      {
        return Get<string>(PROPS.PURGING_FOLDER);
      }
      set
      {
        Set(PROPS.PURGING_FOLDER, value);
      }
    }
    

    //**************************************************************************
    private static class PROPS
    {
      public static string PURGING_FOLDER = "PurgingFolder";
      public static string REMOVE_OLD_FILES = "RemoveOldFiles";
      public static string OLD_FILE_THRESHOLD = "OldFilesThreshold";

      public static string CUSTOM_WORDS = "CustomWords";
      public static string CUSTOM_FONT = "CustomFont";
      public static string CUSTOM_FORE_COLOR = "CustomForeColor";
      public static string CUSTOM_BACK_COLOR = "CustomBackColor";

      public static string SQL_FONT = "SqlFont";
      public static string SQL_FORE_COLOR = "SqlForeColor";
      public static string SQL_BACK_COLOR = "SqlBackColor";

      public static string MESSAGE_FONT = "MessageFont";
      public static string MESSAGE_ERROR_FORE_COLOR = "MessageErrorForeColor";
      public static string MESSAGE_FORE_COLOR = "MessageForeColor";
      public static string MESSAGE_BACK_COLOR = "MessageBackColor";

      public static string GRID_BACK_COLOR = "GridBackColor";
      public static string REQUEST_ROW_COLOR = "RequestRowColor";

      public static string BACK_COLOR_DBG = "BackColorDBG";
      public static string BACK_COLOR_FLW = "BackColorFLW";
      public static string BACK_COLOR_WRN = "BackColorWRN";
      public static string BACK_COLOR_ERR = "BackColorERR";


      public static string LAST_OPENED_FOLDER = "LastOpenedFolder";
      public static string MAIN_SPLITTER = "MainSplitter";
      public static string RIGHT_SPLITTER = "RightSplitter";
      public static string WINDOW_SIZE = "WindowSize";
      public static string WINDOW_MAXIMIZED = "WindowMaximized";
    }
  }
}
