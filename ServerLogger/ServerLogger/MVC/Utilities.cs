using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using ServerLogger.Properties;
using LogComponents;

namespace ServerLogger.Mvc
{
  public static class Utilities
  {
    static Options s_options;

    private static Dictionary<String, String> m_supportTypeMap;

    static Utilities()
    {
      s_options = Options.GetInstance;

      m_supportTypeMap = new Dictionary<string, string>();
      m_supportTypeMap.Add("ERROR", "ERR");
      m_supportTypeMap.Add("FLOW", "FLW");
      m_supportTypeMap.Add("WARN", "WRN");
      m_supportTypeMap.Add("DEBUG", "DBG");

      m_supportTypeMap.Add("ERR", "ERR");
      m_supportTypeMap.Add("FLW", "FLW");
      m_supportTypeMap.Add("WRN", "WRN");
      m_supportTypeMap.Add("DBG", "DBG");
    }



    public static int MAX_LENGTH_FOR_FILTER_VALUE = 60;

    public static string[] SqlReservedWords = new string[] { "SELECT", "FROM", "WHERE", "INSERT", "UPDATE", 
      "SET","INTO", "DELETE", "EXISTS","JOIN" , "ORDER BY", "ASC","AND", "DESC","UNION","GROUP BY", "HAVING", "COUNT", "DISTINCT",
       "LIKE"};


    /// <summary>
    /// Get map of column text to request property names
    /// </summary>
    /// <returns></returns>
    public static Dictionary<string, string> GetRequestFilterablePropertiesNames()
    {
      Dictionary<string, string> map = new Dictionary<string, string>();
      map.Add("Id", "Id");
      map.Add("ParentId", "ParentId");
      map.Add("RequestId", "ParentId");
      map.Add("Request", "Request");
      map.Add("IP", "IP");
      map.Add("TotalTime", "TotalTime");
      map.Add("ConnectId", "ConnectId");
      map.Add("LoginId", "LoginId");
      map.Add("CallId", "CallId");
      map.Add("User", "User");
      map.Add("Thread", "Thread");
      map.Add("Type", "Type");
      map.Add("RowAffected", "RowAffected");
      map.Add("Method", "Method");
      map.Add("DbSchema", "DbSchema");
      map.Add("Message", "Message");
      map.Add("SQL", "ContainsSQL");
      map.Add("ContainsSQL", "ContainsSQL");

      return map;
    }

    public static ImageStatus GetWarnTypeImageDelegate(object item)
    {
      ISupportWarnTypes supportFailed = item as ISupportWarnTypes;
      if (supportFailed != null)
      {
        if (supportFailed.IsErrType)
        {
          return ImageStatus.Create(Resources.breakpoint);
        }
        else if (supportFailed.IsWrnType)
        {
          return ImageStatus.Create(Resources.warning);
        }
      }

      return null;
    }

    public static Color BackColorDelegate(object item)
    {
      ISupportType supportType = item as ISupportType;
      if (supportType != null)
      {
        String type = supportType.Type;
        if (m_supportTypeMap.ContainsKey(type))
        {
          type = m_supportTypeMap[type];
        }
        return s_options.Get<Color>("BackColor" + type);
      }
      else if (item is LogRequest)
      {
        return s_options.RequestRowColor;
      }

      return Color.White;
    }

  }
}
