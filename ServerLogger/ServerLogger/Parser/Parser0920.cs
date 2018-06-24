using System;
using System.Collections.Generic;

namespace ServerLogger.Parser
{
  public class Parser0920 : ParserBase
  {
    const string VERSION = "QC 9.2";
    const int FIRST_ROW = 198;
    const int RECOGNITION_LINE1 = 113;
    const int RECOGNITION_LINE2 = 114;
    const string RECOGNITION_STRING = "<h2>Quality Center Java Server</h2><table>";
    const string TIME_PATTERN = "MMM dd<br>HH:mm:ss.fff";

    const string BEFORE_SCHEMA_STRING = "] on ";
    const string SQL_ROW_START = @"/* ~~QC */ ";
    const string NOT_SQL_ROW_END = @"end;";
    const string EXECUTE_THREAD = "ExecuteThread: '";


    public override bool IsValidLog(IList<string> lines)
    {
      if (lines.Count < RECOGNITION_LINE2)
      {
        return false;
      }

      return (lines[RECOGNITION_LINE1] == RECOGNITION_STRING || lines[RECOGNITION_LINE2] == RECOGNITION_STRING);
    }

    protected override int FirstRow(IList<string> lines)
    {
      return FIRST_ROW;
    }

    protected override void HandleColumn(int columnIndex, string columnContent, LogSubRequest logRow)
    {
      switch (columnIndex)
      {
        case 0:
          HandleDateTimeColumn(columnContent, logRow);
          break;
        case 1:
          HandleThreadColumn(columnContent, logRow);
          break;
        case 2:
          HandleTypeColumn(columnContent, logRow);
          break;
        case 3:
          HandleMethodColumn(columnContent, logRow);
          break;
        case 4:
          HandleMessageColumn(columnContent, logRow);
          break;
        default:
          throw new ApplicationException("Wrong number of columns");

      }
    }

    public static void HandleMessageColumn(string columnContent, LogSubRequest logRow)
    {
      logRow.Message = columnContent;
      if (logRow.ContainsSQL)
      {
        logRow.Message = logRow.Message.Replace(SQL_ROW_START, string.Empty);
      }

      logRow.IsRequestLastRow = logRow.Message.StartsWith(REQUEST_END);
    }

    public static void HandleMethodColumn(string columnContent, LogSubRequest logRow)
    {
      //method
      int methodStart = columnContent.IndexOf('C');
      if (methodStart == -1)
        methodStart = 0;

      int methodEnd = columnContent.IndexOf(' ', methodStart + 1);
      if (methodEnd == -1)
        methodEnd = columnContent.Length;

      logRow.Method = columnContent.Substring(methodStart, methodEnd - methodStart);

      //schema
      int schemaStart = columnContent.IndexOf(BEFORE_SCHEMA_STRING, methodStart);
      if (schemaStart == -1)
        return;
      else
        schemaStart += BEFORE_SCHEMA_STRING.Length;//add length of '

      logRow.ContainsSQL = true;
      int schemaEnd = columnContent.IndexOf(' ', schemaStart + 1);
      logRow.DbSchema = columnContent.Substring(schemaStart, schemaEnd - schemaStart);
    }

    public static void HandleTypeColumn(string columnContent, LogSubRequest logRow)
    {
      logRow.Type = columnContent;
    }

    public static void HandleThreadColumn(string columnContent, LogSubRequest logRow)
    {
      //thread name
      int start = 0;
      int end = 0;

      if (columnContent.StartsWith(EXECUTE_THREAD))
      {
        start = columnContent.IndexOf('\'') + 1;
        end = columnContent.IndexOf('\'', start + 1);
      }
      else
      {
        //try find end by ' ' or by '['
        end = columnContent.IndexOf(' ');
        if (end == -1)
          end = columnContent.IndexOf('[');

        if (end == -1)
          end = columnContent.Length;
      }
      logRow.Thread = columnContent.Substring(start, end - start);

      //other parts
      string subContent;
      while (true)
      {
        start = columnContent.IndexOf('[', end);
        if (start == -1)
          break;
        else
          start++;//add length of '['

        end = columnContent.IndexOf(']', start);
        subContent = columnContent.Substring(start, end - start);

        if (subContent.StartsWith(STR_CALL_ID))
          logRow.CallId = subContent.Substring(STR_CALL_ID.Length);
        else if (subContent.StartsWith(STR_CONNECT_ID))
          logRow.ConnectId = subContent.Substring(STR_CONNECT_ID.Length);
        else if (subContent.StartsWith(STR_LOGIN_ID))
          logRow.LoginId = subContent.Substring(STR_LOGIN_ID.Length);
        else if (subContent.StartsWith(STR_USER_NAME))
          logRow.User = subContent.Substring(STR_USER_NAME.Length);
        else if (subContent.StartsWith(STR_JOB))
          logRow.Request = subContent.Substring(STR_JOB.Length);
        else if (subContent.StartsWith(STR_DB_MESSENGER))
          continue;
        else
          logRow.Request = subContent;
      }
    }

    public static void HandleDateTimeColumn(string columnContent, LogSubRequest logRow)
    {
      logRow.StartDate = DateTime.ParseExact(columnContent, TIME_PATTERN, EN_CULTURE_INFO);

    }

    public override string ParserLogVersion
    {
      get { return VERSION; }
    }

    protected override int ColumnCount
    {
      get { return 5; }
    }
  }
}
