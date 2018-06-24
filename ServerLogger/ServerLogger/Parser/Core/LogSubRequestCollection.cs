using System;
using System.Collections.Generic;
using LogComponents.FilterControl;

namespace ServerLogger
{
  public class LogSubRequestCollection : FilterableBindingList<LogSubRequest>
  {
    private IList<string> m_fileNames;

    private bool m_isFileLocked;
    private string m_logVersion;

    public LogSubRequestCollection(List<LogSubRequest> logs, string logVersion, bool isFileLocked, IList<string> fileNames)
      : base(logs)
    {
      m_logVersion = logVersion;
      m_isFileLocked = isFileLocked;
      m_fileNames = fileNames;

      for (int i = 0; i < logs.Count; i++)
      {
        logs[i].Id = i + 1;
      }
    }

    public IList<string> FileNames
    {
      get { return m_fileNames; }
    }

    public bool IsFileLocked
    {
      get { return m_isFileLocked; }
    }

    public string LogVersion
    {
      get { return m_logVersion; }
      set { m_logVersion = value; }
    }

    public override bool MatchingFilter(int index, string property, string value)
    {
      LogSubRequest item = this.FullList[index];

      if (property == FilterConfig.EMPTY_PROPERTY)
      {
        return (

          item.Request.IndexOf(value, StringComparison.OrdinalIgnoreCase) != -1 ||
          item.User.IndexOf(value, StringComparison.OrdinalIgnoreCase) != -1 ||
          item.Method.IndexOf(value, StringComparison.OrdinalIgnoreCase) != -1 ||
          item.Message.IndexOf(value, StringComparison.OrdinalIgnoreCase) != -1 ||
          item.Type.IndexOf(value, StringComparison.OrdinalIgnoreCase) != -1
          );

      }
      else
      {
        return IsContainsPropertyValue(item, property, value);
      }
    }
  }
}
