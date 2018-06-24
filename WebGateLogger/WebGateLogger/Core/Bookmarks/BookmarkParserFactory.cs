using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;
using LogComponents;

namespace WebGateLogger
{
  public static class BookmarkParserFactory
  {
    static Dictionary<string, BaseBookmarkParser> m_map = new Dictionary<string, BaseBookmarkParser>();
    static BookmarkParserFactory()
    {
      BuildMap();
    }
    static string ERROR_FREC = "ErrorFrec";

    private static void BuildMap()
    {
      Type[] types = Assembly.GetExecutingAssembly().GetTypes();
      Type baseType = typeof(BaseBookmarkParser);
      BaseBookmarkParser parser;
      foreach (Type type in types)
      {
        if (!type.IsSubclassOf(baseType))
        {
          continue;
        }
        if (type.IsAbstract)
        {
          continue;
        }

        parser = (BaseBookmarkParser)Activator.CreateInstance(type);

        object[] attributes = type.GetCustomAttributes(typeof(ParserAttribute), false);
        foreach (ParserAttribute attr in attributes)
        {
          m_map[attr.FrecName] = parser;
        }
      }

      //add error parser
      m_map[ERROR_FREC] = new ErrorFrecBookmarkParser();
    }

    public static BaseBookmarkParser GetParser(Frec frec)
    {
      if (frec.IsFailed)
      {
        return m_map[ERROR_FREC];
      }

      else if (m_map.ContainsKey(frec.Title))
      {
        return m_map[frec.Title];
      }

      return m_map["GetSimpleKeyEntity"];
    }
  }

  public abstract class BaseBookmarkParser
  {
    public static string TEST_TABLE = "TEST";
    public static string RESPONCE_ATTRIBUTE_TABLE = ",\r\n\tTABLE_NAME:";
    public static string ID_REGEX_STRING = @"\bID:(?<ID>-?\d+)";
    public static string VC_TEST_ID_REGEX_STRING = @"TS_TEST_ID:(?<ID>\d+)";
    public static string TABLE_NAME_REGEX_STRING = @"TABLE_NAME:(?<TABLE>\w+)";
    public static string FILE_NAME_REGEX_STRING = @"NAME:(?<FILE_NAME>(\w*[ \.\w])+)";
    public static string TABLE_NAME_STRING = "TABLE_NAME:";
    public static string VC_NUMBER_REGEX_STRING = @"\w{1,4}_VC_VERSION_NUMBER:(?<ID>\d+)";
    public static string ERROR_NUMBER_REGEX_STRING = @"pint:(?<ID>-?\d+)";
    public static int COMErrorMask = 0x0000ffff;

    public abstract IList<BaseBookmark> GetBookmarks(Frec frec);
  }

  [AttributeUsageAttribute(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
  class ParserAttribute : Attribute
  {
    string m_frecName;
    string m_context;

    public string Context
    {
      get { return m_context; }
      set { m_context = value; }
    }

    public string FrecName
    {
      get { return m_frecName; }
      set { m_frecName = value; }
    }

    public ParserAttribute(string frecName)
    {
      m_frecName = frecName;
    }

    public ParserAttribute(string frecName, string context)
    {
      m_frecName = frecName;
      m_context = context;
    }

    public override string ToString()
    {
      return m_frecName + " " + m_context;
    }
  }

  [Parser("GetProjectCustomizationData", "LISTS")]
  class EmptyBookmarkParser : BaseBookmarkParser
  {
    public override IList<BaseBookmark> GetBookmarks(Frec frec)
    {
      return new List<BaseBookmark>();
    }
  }

  class ErrorFrecBookmarkParser : BaseBookmarkParser
  {
    public override IList<BaseBookmark> GetBookmarks(Frec frec)
    {

      try
      {
        List<BaseBookmark> list = new List<BaseBookmark>();
        BaseBookmark bookmark = new BaseBookmark();
        bookmark.Title = "ERROR_CODE";
        bookmark.Bookmark = frec.ErrorCode.ToString();
        list.Add(bookmark);
        return list;
      }
      catch
      {
        return null;
      }


    }
  }

  [Parser("GetSimpleKeyEntity")]
  class SimpleKeyEntityBookmarkParser : BaseBookmarkParser
  {

    public override IList<BaseBookmark> GetBookmarks(Frec frec)
    {

      List<BaseBookmark> list = new List<BaseBookmark>();

      BaseBookmark bookmark;
      string tableNameFromRequest = GetMainTableName(frec);
      string regex = GetResponceRegexMatcher(frec);
      MatchCollection matches = Regex.Matches(frec.Response, regex);

      foreach (Match match in matches)
      {
        bookmark = new BaseBookmark();

        int countOfCharsForFind = Math.Min(frec.Response.Length - match.Index, TABLE_NAME_STRING.Length + 20);
        if (frec.Response.IndexOf(TABLE_NAME_STRING, match.Index, countOfCharsForFind) > 0)
        {
          bookmark.Title = GetExternalTableFromResponce(frec, match.Index);
          bookmark.IsInjected = true;
        }
        else
        {
          bookmark.Title = tableNameFromRequest;
        }

        bookmark.Bookmark = match.Value;
        list.Add(bookmark);
      }

      return list;
    }

    protected virtual string GetResponceRegexMatcher(Frec frec)
    {
      return ID_REGEX_STRING;
    }

    public virtual string GetMainTableName(Frec frec)
    {
      return frec.TableName;
    }

    protected string GetExternalTableFromResponce(Frec frec, int startIndex)
    {
      Match match = Regex.Match(frec.Response.Substring(startIndex), TABLE_NAME_REGEX_STRING);
      return match.Groups[1].Value;
    }
  }


  [Parser("GetDomainsProperties", @"DOMAIN_NAME:(?<VALUE>\w+)")]
  [Parser("GetProjectsProperties", @"PROJECT_NAME:(?<VALUE>\w+)")]
  [Parser("GetTDUsersProperties", @"USER_NAME:(?<VALUE>.+)")]
  [Parser("PasteData", @"SOURCE_ID:(?<ID>\d+)")]
  [Parser("Login", @"PARAM_NAME:(?<VALUE>\w+)")]
  [Parser("GetPolicyStatus", @"USER_NAME:(?<VALUE>\w+)")]
  class GetCustomRegexMatcherBookmarkParser : SimpleKeyEntityBookmarkParser
  {
    Dictionary<string, string> m_mapTitle2RegexMatcher = new Dictionary<string, string>();
    public GetCustomRegexMatcherBookmarkParser()
    {
      object[] attributes = this.GetType().GetCustomAttributes(typeof(ParserAttribute), false);
      foreach (ParserAttribute attr in attributes)
      {
        m_mapTitle2RegexMatcher[attr.FrecName] = attr.Context;
      }
    }

    public override string GetMainTableName(Frec frec)
    {
      if (!string.IsNullOrEmpty(frec.TableName))
      {
        return frec.TableName;
      }
      else
      {
        string name = m_mapTitle2RegexMatcher[frec.Title];
        int index = name.IndexOf(":");
        return name.Substring(0, index);
      }

    }

    protected override string GetResponceRegexMatcher(Frec frec)
    {
      return m_mapTitle2RegexMatcher[frec.Title];
    }
  }

  [Parser("GetVersions")]
  [Parser("GetVersionsEx2")]
  class GetVersionsBookmarkParser : SimpleKeyEntityBookmarkParser
  {
    protected override string GetResponceRegexMatcher(Frec frec)
    {
      return VC_NUMBER_REGEX_STRING;
    }
  }

  [Parser("ListRepositoryFiles")]
  class ListReposityFilesBookmarkParser : SimpleKeyEntityBookmarkParser
  {
    public override string GetMainTableName(Frec frec)
    {
      return "FILE";
    }

    protected override string GetResponceRegexMatcher(Frec frec)
    {
      return FILE_NAME_REGEX_STRING;
    }
  }

  [Parser("GetCommonSetting")]
  class GetCommonSettingBookmarkParser : SimpleKeyEntityBookmarkParser
  {
    const string regexString = @"(?<CATEGORY>CATEGORY:[\w- ]+)";

    public override string GetMainTableName(Frec frec)
    {
      string isPublicRegexString = @"Private:(\w)";
      Match match = Regex.Match(frec.Request, isPublicRegexString);
      string value = match.Groups[1].Value;
      if (match.Groups[1].Value == "Y")
      {
        return "PRIVATE";
      }
      else
      {
        return "PUBLIC";
      }
    }

    protected override string GetResponceRegexMatcher(Frec frec)
    {
      return regexString;
    }
  }

  [Parser("CheckInAndOverrideLastVersion")]
  [Parser("GetCurrentVersion")]
  [Parser("AddObjectToVcs")]
  [Parser("RefreshVcsInfo")]
  [Parser("CheckIn")]
  [Parser("CheckOut")]
  [Parser("UndoCheckout")]
  [Parser("GetCheckoutOrVersionInfo")]
  [Parser("GetVersionsEx")]
  class GetVCActionBookmarkParser : SimpleKeyEntityBookmarkParser
  {
    protected override string GetResponceRegexMatcher(Frec frec)
    {
      if (frec.TableName == TEST_TABLE)
      {
        return VC_TEST_ID_REGEX_STRING;
      }
      else
      {
        return base.GetResponceRegexMatcher(frec);
      }
    }
  }

  [Parser("CrossDrillDown")]
  [Parser("BuildGraph")]
  class BuildGraphBookmarkParser : SimpleKeyEntityBookmarkParser
  {
    Dictionary<int, string> m_mapNumber2GraphName = new Dictionary<int, string>();
    public BuildGraphBookmarkParser()
    {
      m_mapNumber2GraphName.Add(0, "SUMMARY");
      m_mapNumber2GraphName.Add(1, "AGE");
      m_mapNumber2GraphName.Add(2, "PROGRESS");
      m_mapNumber2GraphName.Add(3, "TREND");
      m_mapNumber2GraphName.Add(5, "COVERAGE");
      m_mapNumber2GraphName.Add(6, "KPI_PROGRESS");
      m_mapNumber2GraphName.Add(7, "SCORECARD");
      m_mapNumber2GraphName.Add(8, "KPI_BREAKDOWN");
      m_mapNumber2GraphName.Add(9, "KPI_BREAKDOWN_PROGRESS");
    }

    public override IList<BaseBookmark> GetBookmarks(Frec frec)
    {
      List<BaseBookmark> list = new List<BaseBookmark>();
      try
      {
        BaseBookmark bookmark = new BaseBookmark();
        bookmark.Title = frec.TableName;

        int graphNumber = Helpers.FrecUtilities.GetValueAsInt(frec.Request, "ChartGroup");
        bookmark.Bookmark = "GRAPH_TYPE: " + m_mapNumber2GraphName[graphNumber];
        list.Add(bookmark);
      }
      catch
      {
      }

      return list;
    }
  }

  [Parser("GetBugValue")]
  class GetBugValueBookmarkParser : SimpleKeyEntityBookmarkParser
  {
    private static string RELEASE_RECOGNIZER = ID_REGEX_STRING + @",\r\n.*RELEASES:";

    public override IList<BaseBookmark> GetBookmarks(Frec frec)
    {
      IList<BaseBookmark> bookmarks = base.GetBookmarks(frec);
      if (bookmarks != null && bookmarks.Count > 1)
      {
        //recognize release ids
        MatchCollection matches = Regex.Matches(frec.Response, RELEASE_RECOGNIZER);
        foreach (Match match in matches)
        {
          for (int i = bookmarks.Count - 1; i >= 1; i--)
          {
            if (match.Value.StartsWith(bookmarks[i].Bookmark))
            {
              bookmarks[i].Title = "RELEASES";
              bookmarks[i].IsInjected = true;
              break;
            }
          }
        }
      }

      return bookmarks;
    }
  }


  [Parser("GetStepValue")]
  class GetStepValueBookmarkParser : SimpleKeyEntityBookmarkParser
  {
    private static string TEST_RECOGNIZER = @"\bTEST:{.*" + ID_REGEX_STRING;

    public override IList<BaseBookmark> GetBookmarks(Frec frec)
    {
      IList<BaseBookmark> bookmarks = base.GetBookmarks(frec);
      if (bookmarks != null && bookmarks.Count > 1)
      {
        //recognize release ids
        MatchCollection matches = Regex.Matches(frec.Response, TEST_RECOGNIZER, RegexOptions.Singleline);
        foreach (Match match in matches)
        {
          for (int i = bookmarks.Count - 1; i >= 1; i--)
          {
            if (match.Value.EndsWith(bookmarks[i].Bookmark))
            {
              bookmarks[i].Title = TEST_TABLE;
              bookmarks[i].IsInjected = true;
              break;
            }
          }
        }
      }

      return bookmarks;
    }
  }
  
}
