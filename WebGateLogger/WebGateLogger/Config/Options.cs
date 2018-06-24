using System.ComponentModel;
using System;
using System.Reflection;
using System.IO;
using System.Drawing;
using LogComponents;


namespace WebGateLogger
{

  public class Options : ConfigBase
  {
    #region Singelton

    static Options m_instance = new Options();

    private Options()
    {

    }

    public static Options GetInstance
    {
      get
      {
        return m_instance;
      }
    }

    #endregion

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

    /// <summary>
    /// Point whether to load file on start
    /// </summary>
    [DefaultValue("True")]
    public bool LoadOnStart
    {
      get
      {
        return Get<bool>(PROPS.LOAD_ON_START);
      }
      set
      {
        Set(PROPS.LOAD_ON_START, value);
      }
    }

    [DefaultValue("True")]
    public bool ScrollToBottomOnLoad
    {
      get
      {
        return Get<bool>(PROPS.SCROLL_TO_BOTTOM_ON_LOAD);
      }
      set
      {
        Set(PROPS.SCROLL_TO_BOTTOM_ON_LOAD, value);
      }
    }

    [DefaultValue("False")]
    public bool StayOnSameRowOnRefresh
    {
      get
      {
        return Get<bool>(PROPS.STAY_ON_SAME_ROW_ON_REFRESH);
      }
      set
      {
        Set(PROPS.STAY_ON_SAME_ROW_ON_REFRESH, value);
      }
    }

    [DefaultValue("False")]
    public bool AddToContextMenuOfExplorer
    {
      get
      {
        return Get<bool>(PROPS.ADD_TO_CONTEXT_MENU_OF_EXPLORER);
      }
      set
      {
        Set(PROPS.ADD_TO_CONTEXT_MENU_OF_EXPLORER, value);
      }
    }

    [DefaultValue(15000)]
    public int ParseMaximalResponseLength
    {
      get
      {
        return Get<int>(PROPS.PARSE_MAXIMAL_RESPONCE_LENGTH);
      }
      set
      {
        Set(PROPS.PARSE_MAXIMAL_RESPONCE_LENGTH, value);
      }
    }

    [DefaultValue(100000)]
    public int DontIndentateResponceBiggerThanSize
    {
      get
      {
        return Get<int>(PROPS.DONT_INDENTATE_RESPONCE_BIGGER_THAN_SIZE);
      }
      set
      {
        Set(PROPS.DONT_INDENTATE_RESPONCE_BIGGER_THAN_SIZE, value);
      }
    }

    [OverrideValueFromVersionAttribute("2.0.10.2")]
    [DefaultValue(false)]
    public bool LoadFollowingSessionFiles
    {
      get
      {
        return Get<bool>(PROPS.LOAD_FOLLOWING_SESSION_FILES);
      }
      set
      {
        Set(PROPS.LOAD_FOLLOWING_SESSION_FILES, value);
      }
    }

    [DefaultValue("False")]
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

    [DefaultValue(7)]
    public int OldFilesThreshold
    {
      get
      {
        return Get<int>(PROPS.OLD_FILES_THRESHOLD);
      }
      set
      {
        Set(PROPS.OLD_FILES_THRESHOLD, value);
      }
    }

    public string AdditionalDataSelectedTab
    {
      get
      {
        return Get<string>(PROPS.ADDITIONAL_DATA_SELECTED_TAB);
      }
      set
      {
        Set(PROPS.ADDITIONAL_DATA_SELECTED_TAB, value);
      }
    }

    [DefaultValue(155)]
    public int SplitterRightPanel
    {
      get
      {
        return Get<int>(PROPS.SPLITTER_RIGHT_PANEL);
      }
      set
      {
        Set(PROPS.SPLITTER_RIGHT_PANEL, value);
      }
    }

    [DefaultValue(520)]
    public int SplitterMainPanel
    {
      get
      {
        return Get<int>(PROPS.SPLITTER_MAIN_PANEL);
      }
      set
      {
        Set(PROPS.SPLITTER_MAIN_PANEL, value);
      }
    }

    [DefaultValue(360)]
    public int SplitterLeftPanel
    {
      get
      {
        return Get<int>(PROPS.SPLITTER_LEFT_PANEL);
      }
      set
      {
        Set(PROPS.SPLITTER_LEFT_PANEL, value);
      }
    }

    //**************************************************************************

    [DefaultValue(typeof(Size), "860, 630")]
    public Size FormSize
    {
      get
      {
        return Get<Size>(PROPS.FORM_SIZE);
      }
      set
      {
        Set(PROPS.FORM_SIZE, value);
      }
    }

    [DefaultValue(false)]
    public bool FormMaximized
    {
      get
      {
        return Get<bool>(PROPS.FORM_MAXIMIZED);
      }
      set
      {
        Set(PROPS.FORM_MAXIMIZED, value);
      }
    }

    //**************************************************************************

    [DefaultValue(true)]
    public bool LazyParsing
    {
      get
      {
        return Get<bool>(PROPS.LAZY_PARSING);
      }
      set
      {
        Set(PROPS.LAZY_PARSING, value);
      }
    }

    [OverrideValueFromVersionAttribute("2.0.10.10")]
    [DefaultValue("TdapiInitEx|TdapiRelease|TdapiInit|Processing answer|PingThread: preparing ping request...|PingToServer|TJWebRemApiLink (TD Webgate) finalization|TJWebDomApi (SA Webgate) finalization|TJWebDomApi (SA Webgate) initialization|TJWebRemApiLink (TD Webgate) Initialization|TPingThr.SendPingRequest|")]
    public StringList ExcludedFrecs
    {
      get
      {
        StringList list = Get<StringList>(PROPS.EXCLUDED_FRECS);
        list.Sort();
        return list;
      }
      set
      {
        Set(PROPS.EXCLUDED_FRECS, value);
      }
    }

    //**************************************************************************

    #region Request and font options

    [DefaultValue(typeof(Color), "Control")]
    public Color RequestBackColor
    {
      get
      {
        return Get<Color>(PROPS.REQUEST_BACK_COLOR);
      }
      set
      {
        Set(PROPS.REQUEST_BACK_COLOR, value);
      }
    }

    [DefaultValue(typeof(Color), "WindowText")]
    public Color RequestForeColor
    {
      get
      {
        return Get<Color>(PROPS.REQUEST_FORE_COLOR);
      }
      set
      {
        Set(PROPS.REQUEST_FORE_COLOR, value);
      }
    }

    [DefaultValue(typeof(Font), "Microsoft Sans Serif, 8.25pt")]
    public Font RequestFont
    {
      get
      {
        return Get<Font>(PROPS.REQUEST_FONT);
      }
      set
      {
        Set(PROPS.REQUEST_FONT, value);
      }
    }

    //**************************************************************************

    [DefaultValue(typeof(Color), "Control")]
    public Color ResponseBackColor
    {
      get
      {
        return Get<Color>(PROPS.RESPONSE_BACK_COLOR);
      }
      set
      {
        Set(PROPS.RESPONSE_BACK_COLOR, value);
      }
    }

    [DefaultValue(typeof(Color), "WindowText")]
    public Color ResponseForeColor
    {
      get
      {
        return Get<Color>(PROPS.RESPONSE_FORE_COLOR);
      }
      set
      {
        Set(PROPS.RESPONSE_FORE_COLOR, value);
      }
    }

    [DefaultValue(typeof(Color), "Red")]
    public Color ResponceErrorForeColor
    {
      get
      {
        return Get<Color>(PROPS.RESPONCE_ERROR_FORE_COLOR);
      }
      set
      {
        Set(PROPS.RESPONCE_ERROR_FORE_COLOR, value);
      }
    }

    [DefaultValue(typeof(Font), "Microsoft Sans Serif, 8.25pt")]
    public Font ResponceFont
    {
      get
      {
        return Get<Font>(PROPS.RESPONCE_FONT);
      }
      set
      {
        Set(PROPS.RESPONCE_FONT, value);
      }
    }

    //**************************************************************************

    [DefaultValue(typeof(Color), "Fuchsia")]
    public Color SelectionBackColor
    {
      get
      {
        return Get<Color>(PROPS.SELECTION_BACK_COLOR);
      }
      set
      {
        Set(PROPS.SELECTION_BACK_COLOR, value);
      }
    }

    [DefaultValue(typeof(Color), "WindowText")]
    public Color SelectionForeColor
    {
      get
      {
        return Get<Color>(PROPS.SELECTION_FORE_COLOR);
      }
      set
      {
        Set(PROPS.SELECTION_FORE_COLOR, value);
      }
    }

    [DefaultValue(typeof(Font), "Microsoft Sans Serif, 8.25pt")]
    public Font SelectionFont
    {
      get
      {
        return Get<Font>(PROPS.SELECTION_FONT);
      }
      set
      {
        Set(PROPS.SELECTION_FONT, value);
      }
    }

    //**************************************************************************

    [DefaultValue(typeof(Color), "NavajoWhite")]
    public Color GridMainRequestColor
    {
      get
      {
        return Get<Color>(PROPS.GRID_MAIN_REQUEST_COLOR);
      }
      set
      {
        Set(PROPS.GRID_MAIN_REQUEST_COLOR, value);
      }
    }

    [DefaultValue(typeof(Color), "SeaShell")]
    public Color GridSecondaryRequestColor
    {
      get
      {
        return Get<Color>(PROPS.GRID_SECONDARY_REQUEST_COLOR);
      }
      set
      {
        Set(PROPS.GRID_SECONDARY_REQUEST_COLOR, value);
      }
    }

    #endregion

    private static class PROPS
    {

      public static string LAZY_PARSING = "LazyParsing";
      public static string EXCLUDED_FRECS = "ExcludedFrecs";

      public static string SPLITTER_LEFT_PANEL = "SplitterLeftPanel";
      public static string SPLITTER_MAIN_PANEL = "SplitterMainPanel";
      public static string SPLITTER_RIGHT_PANEL = "SplitterRightPanel";

      public static string GRID_SECONDARY_REQUEST_COLOR = "GridSecondaryRequestColor";
      public static string GRID_MAIN_REQUEST_COLOR = "GridMainRequestColor";

      public static string LOAD_FOLLOWING_SESSION_FILES = "LoadFollowingSessionFiles";
      public static string ADDITIONAL_DATA_SELECTED_TAB = "AdditionalDataSelectedTab";
      public static string FORM_MAXIMIZED = "FormMaximized";
      public static string FORM_SIZE = "FormSize";
      public static string LOAD_ON_START = "LoadOnStart";
      public static string SCROLL_TO_BOTTOM_ON_LOAD = "ScrollToBottomOnLoad";
      public static string STAY_ON_SAME_ROW_ON_REFRESH = "StayOnSameRowOnRefresh";
      public static string ADD_TO_CONTEXT_MENU_OF_EXPLORER = "AddToContextMenuOfExplorer";
      public static string PARSE_MAXIMAL_RESPONCE_LENGTH = "ParseMaximalResponseLength";
      public static string DONT_INDENTATE_RESPONCE_BIGGER_THAN_SIZE = "DontIndentateResponceBiggerThanSize";
      public static string REMOVE_OLD_FILES = "RemoveOldFiles";
      public static string OLD_FILES_THRESHOLD = "OldFilesThreshold";

      public static string REQUEST_BACK_COLOR = "RequestBackColor";
      public static string REQUEST_FORE_COLOR = "RequestForeColor";
      public static string REQUEST_FONT = "RequestFont";

      public static string RESPONCE_FONT = "ResponceFont";
      public static string RESPONSE_BACK_COLOR = "ResponseBackColor";
      public static string RESPONSE_FORE_COLOR = "ResponseForeColor";
      public static string RESPONCE_ERROR_FORE_COLOR = "ResponceErrorForeColor";

      public static string SELECTION_FONT = "SelectionFont";
      public static string SELECTION_FORE_COLOR = "SelectionForeColor";
      public static string SELECTION_BACK_COLOR = "SelectionBackColor";
    }
  }
}
