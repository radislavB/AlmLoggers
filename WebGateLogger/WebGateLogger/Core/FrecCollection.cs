using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using LogComponents;
using LogComponents.FilterControl;

namespace WebGateLogger
{
  public class FrecCollection : FilterableBindingList<Frec>
  {
    #region Private members

    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    private string m_fileName;
    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    private string m_fileContent;
    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    private bool m_inProcess;
    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    private string m_mainThread;
    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    private string m_connectionURL;
    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    private Dictionary<string, object> m_performance = new Dictionary<string, object>();

    private Dictionary<Frec, IList<BaseBookmark>> m_bookmarks;

    #endregion

    #region Constructor

    private FrecCollection(string fileName)
    {
      m_fileName = fileName;

      //READ CONTENT
      m_fileContent = FrecHelper.GetFileContent(fileName, Options.GetInstance.LoadFollowingSessionFiles, out m_inProcess);


      //PARSE HEADERS
      List<Frec> frecList = FrecHelper.ParseFrecsHeaders(this, m_fileContent, Options.GetInstance.ExcludedFrecs.Clone());

      m_connectionURL = FrecHelper.GetConnectionURL(m_fileContent);

      m_bookmarks = new Dictionary<Frec, IList<BaseBookmark>>();

      if (!Options.GetInstance.LazyParsing)
      {
        FrecHelper.ParseFrecsContent(m_fileContent, frecList);
      }

      base.Reload(frecList);
    }

    public static FrecCollection LoadCollection(string fileName)
    {
      FrecCollection frecColl = new FrecCollection(fileName);
      
      return frecColl;
    }

    #endregion

    public IList<BaseBookmark> GetBookmarks(Frec frec)
    {
      if (!m_bookmarks.ContainsKey(frec))
      {
        BaseBookmarkParser parser = BookmarkParserFactory.GetParser(frec);
        if (parser != null)
        {
          m_bookmarks[frec] = parser.GetBookmarks(frec);
        }
        else
        {
          m_bookmarks[frec] = null;
        }

      }

      return m_bookmarks[frec];
    }

    public override bool MatchingFilter(int index, string property, string value)
    {

      Frec frec = FullList[index];

      if (property == FilterConfig.EMPTY_PROPERTY)
      {
        return (
        frec.Title.IndexOf(value, StringComparison.OrdinalIgnoreCase) > -1 ||
        frec.Request.IndexOf(value, StringComparison.OrdinalIgnoreCase) > -1 ||
        frec.Response.IndexOf(value, StringComparison.OrdinalIgnoreCase) > -1);

      }
      else if (property.Equals(Consts.FrecProperty.ID, StringComparison.OrdinalIgnoreCase))
      {
        int minId;
        if (int.TryParse(value, out minId))
        {
          return frec.Id >= minId;
        }
      }
      else if (property.IndexOf(Consts.FrecProperty.WAIT, StringComparison.OrdinalIgnoreCase) > -1)
      {
        int minWait;
        if (int.TryParse(value, out minWait))
        {
          return frec.ResponceWaitTimeSpan.TotalSeconds >= minWait;
        }
      }
      else if (property.IndexOf(Consts.FrecProperty.PARSE_DURATION, StringComparison.OrdinalIgnoreCase) > -1)
      {
        int duration;
        if (int.TryParse(value, out duration))
        {
          return frec.ParseDuration >= duration;
        }
      }
      else
      {
        return IsContainsPropertyValue(frec, property, value);
      }
      return false;
    }

    private string FindMainThread()
    {
      if (FullCount == 0)
      {
        return string.Empty;
      }

      if (FullCount < 8)
      {
        return GetItem(0, true).Thread;
      }


      Dictionary<string, int> threadMap = new Dictionary<string, int>();
      foreach (Frec frec in FullList)
      {
        if (!threadMap.ContainsKey(frec.Thread))
        {
          threadMap[frec.Thread] = 0;
        }

        threadMap[frec.Thread]++;
      }

      int maxCount = 0;
      string thread = string.Empty;
      foreach (KeyValuePair<string, int> pair in threadMap)
      {
        if (pair.Value > maxCount)
        {
          maxCount = pair.Value;
          thread = pair.Key;
        }
      }

      return thread;
    }

    private Frec FindFrec(string title, string thread)
    {
      foreach (Frec frec in FullList)
      {
        if (frec.Title == title && frec.Thread == thread)
        {
          return frec;
        }
      }

      return null;
    }

    public ConnectionInfo GetConnectionInfo()
    {
      Frec loginFrec = FindFrec("Login", MainThread);
      Frec connectProjFrec = FindFrec("ConnectProject", MainThread);
      ConnectionInfo connectionInfo = new ConnectionInfo();
      if (connectProjFrec != null && loginFrec != null)
      {
        connectionInfo.Domain = Helpers.FrecUtilities.GetValue(connectProjFrec.Request, "DOMAIN_NAME");
        connectionInfo.Project = Helpers.FrecUtilities.GetValue(connectProjFrec.Request, "PROJECT_NAME");
        connectionInfo.User = Helpers.FrecUtilities.GetValue(loginFrec.Request, "USER_NAME");
        connectionInfo.QcVersion = Helpers.FrecUtilities.GetValue(connectProjFrec.Response, "VERSION");
        connectionInfo.Server = Helpers.FrecUtilities.GetValue(connectProjFrec.Response, "SERVER");
        connectionInfo.Vcs = Helpers.FrecUtilities.GetValue(connectProjFrec.Response, "VCS");

        connectionInfo.ConnectionURL = m_connectionURL;
      }

      connectionInfo.FilePath = m_fileName;
      connectionInfo.FileSize = Helpers.IOUtilities.GetShortFileSize(m_fileContent.Length);

      return connectionInfo;
    }

    #region Custom properties

    public string MainThread
    {
      get
      {
        if (m_mainThread == null)
        {
          m_mainThread = FindMainThread();

        }
        return m_mainThread;
      }

    }

    [Browsable(false)]
    public string FileContent
    {
      get { return m_fileContent; }
    }

    [DisplayName("Log file")]
    public string LogFile
    {
      get
      {
        return Path.GetFileName(m_fileName);
      }
    }

    [Browsable(false)]
    public string FullFileName
    {
      get
      {
        return m_fileName;
      }
    }

    [DisplayName("In process")]
    public bool InProcess
    {
      get
      {
        return m_inProcess;
      }
    }

    public override bool SupportsSorting
    {
      get
      {
        return false;
      }
    }

    #endregion
  }
}
