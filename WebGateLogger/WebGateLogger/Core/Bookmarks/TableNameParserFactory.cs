using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Text.RegularExpressions;
using LogComponents;

namespace WebGateLogger
{
  public static class TableNameParserFactory
  {
    static Dictionary<string, BaseTableNameParser> m_map = new Dictionary<string, BaseTableNameParser>();
    static TableNameParserFactory()
    {
      BuildMap();
    }


    private static void BuildMap()
    {
      Type[] types = Assembly.GetExecutingAssembly().GetTypes();
      Type baseType = typeof(BaseTableNameParser);
      BaseTableNameParser parser;
      foreach (Type type in types)
      {
        if (type == baseType || type.IsSubclassOf(baseType))
        {
          parser = (BaseTableNameParser)Activator.CreateInstance(type);

          object[] attributes = type.GetCustomAttributes(typeof(ParserAttribute), false);
          foreach (ParserAttribute attr in attributes)
          {
            m_map[attr.FrecName] = parser;
          }
        }
      }
    }

    public static BaseTableNameParser GetParser(Frec frec)
    {
      if (m_map.ContainsKey(frec.Title))
      {
        return m_map[frec.Title];
      }
      else
      {
        return m_map["GetSimpleKeyEntity"];
      }
    }
  }

  [Parser("RescheduleTimePeriod")]
  [Parser("CheckIn")]
  [Parser("CheckOut")]
  [Parser("PostSimpleKeyEntity")]
  [Parser("GetSimpleKeyEntity")]
  public class BaseTableNameParser
  {
    public static string TABLE_NAME = "TABLE_NAME";
    public static string TABLE_NAME2 = "TableName";
    
    public static string OBJ_TYPE = "OBJTYPE";
    public static string TABLE = "TABLE";

    public static string TEST_OBJ_TYPE = "10";
    public static string TEST_TABLE = "TEST";
    public static string VC_PREFIX = "VC_";
    public static string HIST_PREFIX = "HIST_";

    public virtual string GetTableName(Frec frec)
    {
      string table = ParseTableName(frec, TABLE_NAME);
      if (table == string.Empty)
      {
        table = ParseTableName(frec, TABLE_NAME2);
      }
      return table;
    }

    protected string ParseTableName(Frec frec, string prefix)
    {
      string temp = Helpers.FrecUtilities.GetValue(frec.Request, prefix);
      if (temp == null)
      {
        temp = string.Empty;
      }
      return temp;
    }
  }

  [Parser("GetCheckedOutCount")]
  [Parser("CheckInAndOverrideLastVersion")]
  [Parser("GetCurrentVersion")]
  [Parser("AddObjectToVcs")]
  [Parser("RefreshVcsInfo")]
  [Parser("CheckIn")]
  [Parser("CheckOut")]
  [Parser("UndoCheckout")]
  [Parser("GetCheckoutOrVersionInfo")]
  [Parser("GetVersionsEx")]
  public class VCActionTableNameParser : BaseTableNameParser
  {
    public override string GetTableName(Frec frec)
    {
      string tableName = base.GetTableName(frec);
      if (string.IsNullOrEmpty(tableName))
      {
        string value = Helpers.FrecUtilities.GetValue(frec.Request, OBJ_TYPE);
        if (value == TEST_OBJ_TYPE)
        {
          tableName = TEST_TABLE;
        }
      }

      return tableName;
    }
  }

  [Parser("CopyAttachmentToResource", "RESOURCES")]
  [Parser("GetCoverage", "REQ_COVER")]
  [Parser("GetRequirementsSummaryStatus", "REQ_SUMMARY_STATUS")]

  [Parser("GetLinkValue", "LINK")]
  [Parser("DeleteLink", "LINK")]
  [Parser("PostLink", "LINK")]

  [Parser("CopyThresholdValuesFromKPI", "QPM_THRESHOLD_VALUES")]
  [Parser("RestoreDefaultThresholdValues ", "QPM_THRESHOLD_VALUES")]

  [Parser("DeleteAlertsByFilter", "ALERT")]
  [Parser("PostAlert", "ALERT")]
  [Parser("GetAlertValue", "ALERT")]

  [Parser("DeleteStep", "STEP")]
  [Parser("PostStep", "STEP")]
  [Parser("GetStepValue", "STEP")]

  [Parser("GetTraceValue", "REQ_TRACE")]
  [Parser("PostTrace", "REQ_TRACE")]

  [Parser("GetRunValue", "RUN")]
  [Parser("PostRun", "RUN")]
  [Parser("DeleteRun", "RUN")]
  [Parser("GetTestLastRun", "RUN")]

  [Parser("GetTestSetValue", "CYCLE")]
  [Parser("PostTestSet", "CYCLE")]

  [Parser("PostTSTest", "TESTCYCL")]
  [Parser("GetTSTestValue", "TESTCYCL")]

  [Parser("DeleteHostFromGroup", "HOST_IN_GROUP")]
  [Parser("AddHostToGroup", "HOST_IN_GROUP")]
  [Parser("GetHostsInGroup", "HOST_IN_GROUP")]

  [Parser("DeleteReq", "REQ")]
  [Parser("PostReq", "REQ")]
  [Parser("GetReqValue", "REQ")]

  [Parser("GetTreeRoot", "ALL_LIST")]
  [Parser("GetTreeNodeValue", "ALL_LIST")]
  [Parser("DeleteTreeNode", "ALL_LIST")]
  [Parser("CreateTreeNode", "ALL_LIST")]
  [Parser("MoveTreeNode", "ALL_LIST")]

  [Parser("GetHistTestValue", "TEST")]
  [Parser("PostTest", "TEST")]
  [Parser("DeleteTest", "TEST")]
  [Parser("GetTestValue", "TEST")]

  [Parser("PostBug", "BUG")]
  [Parser("GetBugValue", "BUG")]
  [Parser("DeleteBug", "BUG")]

  [Parser("GetRuleValue", "RULES")]
  [Parser("PostRule", "RULES")]
  [Parser("DeleteRule", "RULES")]

  [Parser("GetTestSetFolderValue", "CYCL_FOLD")]
  [Parser("PostTestSetFolder", "CYCL_FOLD")]
  [Parser("GetTestSetFolderMetaData", "CYCL_FOLD")]

  [Parser("AddAuditEvent", "AUDIT_LOG")]
  [Parser("GetAuditInfo", "AUDIT_LOG")]
  
  [Parser("CopyDesignSteps", "DESSTEPS")]
  [Parser("GetDesStepValue", "DESSTEPS")]
  [Parser("PostDesStep", "DESSTEPS")]
  [Parser("DeleteDesStep", "DESSTEPS")]
  [Parser("CopyStepsToTest", "DESSTEPS")]
  public class GetPredefinedTableNamesParser : BaseTableNameParser
  {
    Dictionary<string, string> m_mapTitle2TableName = new Dictionary<string, string>();
    public GetPredefinedTableNamesParser()
    {
      object[] attributes = this.GetType().GetCustomAttributes(typeof(ParserAttribute), false);
      foreach (ParserAttribute attr in attributes)
      {
        m_mapTitle2TableName[attr.FrecName] = attr.Context;
      }
    }

    public override string GetTableName(Frec frec)
    {
      return m_mapTitle2TableName[frec.Title];
    }
  }


  [Parser("GetVersions")]
  [Parser("GetVersionsEx2")]
  class GetVersionsTableNameParser : BaseTableNameParser
  {
    public override string GetTableName(Frec frec)
    {
      string table = base.GetTableName(frec);
      return VC_PREFIX + table;
    }
  }



  [Parser("DownloadRepositoryFiles")]
  [Parser("DeleteRepositoryFiles")]
  [Parser("ListRepositoryFiles")]
  [Parser("UploadRepositoryFiles")]
  class GetRepositoryTableNameParser : BaseTableNameParser
  {

    const string FILTER_SERVER_PREFIX = @"FILTER_SERVER:<\.\\";
    const string CHECKOUT_PATH_PREFIX = @"\\checkouts\\";
    const string HIST_PATH_PREFIX = @"\\hist\\";
    const string tableNameExtractorSuffix = "(?<TABLE>[a-zA-Z]*)";
    private string ExtractTableNameAfterString(string source, string regexPrefix)
    {
      Match match = Regex.Match(source, regexPrefix + tableNameExtractorSuffix);
      if (match.Success)
      {
        return match.Groups[1].Value.ToUpperInvariant();
      }

      return null;
    }

    public override string GetTableName(Frec frec)
    {
      string table = string.Empty;

      if (frec.Request.Contains("req.tds") &&
        frec.Request.Contains("testplan.tds") &&
        frec.Request.Contains("resources.tds"))
      {
        return string.Empty;
      }


      table = ExtractTableNameAfterString(frec.Request, CHECKOUT_PATH_PREFIX);
      if (table != null)
      {
        return VC_PREFIX + table;
      }

      table = ExtractTableNameAfterString(frec.Request, HIST_PATH_PREFIX);
      if (table != null)
      {
        return HIST_PREFIX + table;
      }


      if (frec.Request.IndexOf(@"\components", 0, StringComparison.OrdinalIgnoreCase) > 0)
      {
        return "COMPONENT";
      }
      else if (frec.Request.IndexOf(@"\resources", 0, StringComparison.OrdinalIgnoreCase) > 0)
      {
        return "RESOURCES";
      }
      else if (frec.Request.IndexOf(@"\req", 0, StringComparison.OrdinalIgnoreCase) > 0)
      {
        return "REQ";
      }
      else if (frec.Request.IndexOf(@"\Step", 0, StringComparison.OrdinalIgnoreCase) > 0)
      {
        return "STEP";
      }
      else if (frec.Request.IndexOf(@"\Run", 0, StringComparison.OrdinalIgnoreCase) > 0)
      {
        return "RUN";
      }
      else if (frec.Request.IndexOf(@"\Test", 0, StringComparison.OrdinalIgnoreCase) > 0)
      {
        return TEST_TABLE;
      }

      return string.Empty;
    }
  }

  [Parser("SetProjectCustomizationData")]
  [Parser("PostCommonSetting")]
  class EmptyTableNameParser : BaseTableNameParser
  {
    public override string GetTableName(Frec frec)
    {
      return string.Empty;
    }
  }

  [Parser("GetAuditPropertyInfo", "ENTITY_TYPE")]
  [Parser("CoverReq", "MAIN_TABLE")]
  [Parser("GetDownloadAssetInfo", "ASSET_TYPE")]

  [Parser("MailEntity", "TYPE")]
  [Parser("RescheduleTimePeriod", "TYPE")]
  [Parser("PasteData", "TYPE")]
  [Parser("ObjectLock", "TYPE")]
  [Parser("ObjectUnlock", "TYPE")]
  [Parser("IsObjectLocked", "TYPE")]

  [Parser("CrossDrillDown", "TableName")]
  [Parser("BuildGraph", "TableName")]
  [Parser("GetEntitiesFieldIntersection", "ENTITIES")]

  class GetCustomRegexMatcherTableNameParser : BaseTableNameParser
  {
    Dictionary<string, string> m_mapTitle2RegexMatcher = new Dictionary<string, string>();
    public GetCustomRegexMatcherTableNameParser()
    {
      object[] attributes = this.GetType().GetCustomAttributes(typeof(ParserAttribute), false);
      foreach (ParserAttribute attr in attributes)
      {
        m_mapTitle2RegexMatcher[attr.FrecName] = attr.Context;
      }
    }

    public override string GetTableName(Frec frec)
    {
      string prefix = m_mapTitle2RegexMatcher[frec.Title];
      return base.ParseTableName(frec, prefix);
    }
  }


  [Parser("CreateAttachment")]
  [Parser("HandleAttachmentUpdate")]
  [Parser("SetAttachmentValue")]
  [Parser("GetAttachmentValue")]
  [Parser("GetHistAttachmentValue")]
  [Parser("DeleteAttachment")]
  [Parser("RenameAttachment")]
  class AttachmentTableNameParser : BaseTableNameParser
  {
    public override string GetTableName(Frec frec)
    {
      return ParseTableName(frec, TABLE);
    }
  }


}
