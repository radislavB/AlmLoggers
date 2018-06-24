using System;
using System.Collections.Generic;
using System.Reflection;
using LogComponents.FilterControl;
using LogComponents.MVC;

namespace ServerLogger
{
  public class LogRequestCollection : FilterableBindingList<LogRequest>, IMvcContext
  {
    private LogSubRequestCollection m_logRowCollection;
    static private Dictionary<string, object> s_excludeRequests;

    static LogRequestCollection()
    {
      s_excludeRequests = new Dictionary<string, object>();
      s_excludeRequests.Add("PingToServer", null);
      s_excludeRequests.Add("pingSession", null);
    }

    public LogRequestCollection(LogSubRequestCollection logs)
    {
      m_logRowCollection = logs;

      LogRequest logRequest;
      List<LogSubRequest> myLogs = new List<LogSubRequest>(logs);
      myLogs.Reverse();

      int index = 0;
      bool added, isLast;
      while (myLogs.Count != 0)
      {
        index = myLogs.Count - 1;
        logRequest = new LogRequest();
        isLast = false;
        while (!isLast && index > -1)
        {
          added = logRequest.TryAdd(myLogs[index]);
          if (added)
          {
            isLast = myLogs[index].IsRequestLastRow;
            myLogs.RemoveAt(index);
          }
          index--;
        }

        //add only initialized requests
        if (!logRequest.Initialized)
          continue;

        //exclude requests
        if (s_excludeRequests.ContainsKey(logRequest.Request))
          continue;

        Add(logRequest);
        logRequest.Id = Count;
      }
    }

    public IList<string> FileNames
    {
      get
      {
        return m_logRowCollection.FileNames;
      }
    }

    public override bool MatchingFilter(int index, string property, string value)
    {
      LogRequest item = this.FullList[index];
      if (property == FilterConfig.EMPTY_PROPERTY)
      {
        bool hasValue = item.Request.IndexOf(value, StringComparison.OrdinalIgnoreCase) != -1;
        return hasValue;
      }
      else if (property.Equals(Constants.COLUMNS.TOTAL_TIME_PROPERTY_NAME, StringComparison.OrdinalIgnoreCase))
      {
        try
        {
          TimeSpan dateTimeValue = DateTime.ParseExact(value, Constants.COLUMNS.TOTAL_TIME_FORMAT, null).TimeOfDay;
          return item.TotalTime.TimeOfDay >= dateTimeValue;
        }
        catch
        {
          return false;
        }
      }
      else
      {
        return IsContainsPropertyValue(item, property, value);
      }

    }

    public bool IsFileLocked
    {
      get
      {
        return m_logRowCollection.IsFileLocked;
      }
    }

    public string LogVersion
    {
      get
      {
        return m_logRowCollection.LogVersion;
      }
    }

    public LogSubRequestCollection Logs
    {
      get
      {
        return m_logRowCollection;
      }
    }
  }
}
