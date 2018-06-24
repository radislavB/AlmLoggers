using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Collections;
using LogComponents.FilterControl;
using LogComponents.MVC;

namespace WebGateLogger
{
  public class Frec : ISupportId, IMvcContext
  {
    private int m_id;
    private string m_title;
    private TimeSpan m_time;
    private TimeSpan m_responceTime;
    private string m_request = string.Empty;
    private string m_response = string.Empty;
    private Match m_match;
    private string m_thread;
    private string m_tableName;
    private string m_requestId;
    private int m_errorCode = -1;
    private bool m_isInitialized = false;
    private int m_parseDuration;
    private string m_responcePerformanceData;
    private string m_server;
    private string m_sessionId;
    private HashSet<int> m_illegalCharacters = new HashSet<int>();

    private FrecCollection m_parent;

    public Frec(FrecCollection parent, string title, string thread, TimeSpan time, Match match)
    {
      m_parent = parent;
      m_title = title;
      m_time = time;
      m_match = match;
      m_thread = thread;
    }

    public int ParseDuration
    {
      get { return m_parseDuration; }
      set { m_parseDuration = value; }
    }

    public bool IsInitialized
    {
      get
      {
        return m_isInitialized;
      }
      set
      {
        m_isInitialized = value;
      }
    }

    public string SessionId
    {
      get
      {
        AssertIsInitialized();
        return m_sessionId;
      }

      set { m_sessionId = value; }
    }

    public bool HasIllegalCharacters
    {
      get
      {
        AssertIsInitialized();
        return m_illegalCharacters.Count > 0;
      }
    }

    public ICollection<int> IllegalCharacters
    {
      get
      {
        AssertIsInitialized();
        return m_illegalCharacters;
      }
    }

    public void AddIllegalCharacters(IList<char> illegalchars)
    {
      foreach(char c in illegalchars){
        m_illegalCharacters.Add(c);
      }     
    }

    public string RequestId
    {
      get
      {
        AssertIsInitialized();
        return m_requestId;
      }
      set { m_requestId = value; }
    }

    public string Thread
    {
      get { return m_thread; }
      set { m_thread = value; }
    }

    public int ErrorCode
    {
      get
      {
        AssertIsInitialized();
        return m_errorCode;
      }
      set { m_errorCode = value; }
    }

    public string Title
    {
      get
      {
        return m_title;
      }
    }

    public TimeSpan Time
    {
      get
      {
        AssertIsInitialized();
        return m_time;
      }
    }

    public String TimeString
    {
      get
      {
        AssertIsInitialized();
        string result = String.Format("{0:D02}:{1:D02}:{2:D02}.{3:D03}", m_time.Hours, m_time.Minutes, m_time.Seconds, m_time.Milliseconds);

        return result;
      }
    }

    public TimeSpan ResponceTime
    {
      get
      {
        AssertIsInitialized();
        return m_responceTime;
      }
      set { m_responceTime = value; }
    }

    public TimeSpan ResponceWaitTimeSpan
    {
      get
      {
        AssertIsInitialized();
        if (m_responceTime == TimeSpan.Zero)
          return TimeSpan.Zero;

        return m_responceTime - m_time;
      }
    }

    public string ResponceWaitTime
    {
      get
      {
        AssertIsInitialized();
        if (m_responceTime == TimeSpan.Zero)
          return null;

        TimeSpan span = m_responceTime - m_time;
        string result = String.Format("{0:D02}:{1:D02}.{2:D03}", span.Minutes, span.Seconds, span.Milliseconds);
        return result;
      }
    }

    public Match Match
    {
      get
      {
        return m_match;
      }
    }

    public string Request
    {
      get
      {
        AssertIsInitialized();
        return m_request;
      }
      set
      {
        m_request = value;
      }
    }

    public string Response
    {
      get
      {
        AssertIsInitialized();
        return m_response;
      }
      set
      {
        m_response = value;
      }
    }

    public string ResponcePerformanceData
    {
      get
      {
        AssertIsInitialized();
        return m_responcePerformanceData;
      }
      set { m_responcePerformanceData = value; }
    }

    public override string ToString()
    {
      AssertIsInitialized();
      return string.Format("{0} : {1} - {2}", m_id, m_title, m_time);
    }

    public bool IsFailed
    {
      get
      {
        return ErrorCode != -1;
      }
    }

    public string TableName
    {
      get
      {
        if (m_tableName == null)
        {
          BaseTableNameParser parser = TableNameParserFactory.GetParser(this);
          if (parser != null)
          {
            m_tableName = parser.GetTableName(this);
          }
          else
          {
            m_tableName = string.Empty;
          }

        }

        return m_tableName;
      }

    }

    private void AssertIsInitialized()
    {
      if (!IsInitialized)
      {
        FrecHelper.InitializeFrecContent(m_parent.FileContent, this);
      }
    }

    public string GetRawFrec()
    {
      AssertIsInitialized();
      int startFrec = m_match.Index;
      int endFrec = FrecHelper.FindEndOfFrec(m_parent.FileContent, this);
      return m_parent.FileContent.Substring(startFrec, endFrec - startFrec);
    }

    public FrecCollection Parent
    {
      get { return m_parent; }
    }

    public string Server
    {
      get { return m_server; }
      set { m_server = value; }
    }

    #region ISupportId Members

    public int Id
    {
      get { return m_id; }
      set { m_id = value; }
    }

    #endregion

  }
}
