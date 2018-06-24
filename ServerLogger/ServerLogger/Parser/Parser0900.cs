using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ServerLogger.Parser
{
  //parser for patch 26
  public class Parser0900 : ParserBase
  {
    const string VERSION = "QC 9.0";
    const int RECOGNITION_LINE1 = 118;
    const int RECOGNITION_LINE2 = 119;

    const string RECOGNITION_STRING = "<b>Quality Center Java Server</b><br><pre><br><b>";

    const int FIRST_ROW = 162;

    const string TIME_PATTERN = "MMM dd HH:mm:ss.fff";

    const string SQL_METHOD = "execute";
    const string BEFORE_SCHEMA_STRING = "] on ";

    const string SQL_ROW_START = @"/*~~QC*/ ";

    public override bool IsValidLog(IList<string> lines)
    {
      if (lines.Count < RECOGNITION_LINE2)
      {
        return false;
      }

      return (lines[RECOGNITION_LINE1].StartsWith(RECOGNITION_STRING) ||
        lines[RECOGNITION_LINE2].StartsWith(RECOGNITION_STRING));
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
          HandleClassColumn(columnContent, logRow);
          break;
        case 4:
          HandleMethodColumn(columnContent, logRow);
          break;
        case 5:
          HandleMessageColumn(columnContent, logRow);
          break;
        default:
          throw new ApplicationException("Wrong number of columns");

      }
    }

    private void HandleClassColumn(string columnContent, LogSubRequest logRow)
    {
      int start = columnContent.IndexOf('C');
      if (start == -1)
        start = 0;
      logRow.Method = columnContent.Substring(start);
    }

    private void HandleMessageColumn(string columnContent, LogSubRequest logRow)
    {
      logRow.Message = columnContent;
      if (logRow.ContainsSQL)
      {
        logRow.Message = logRow.Message.Replace(SQL_ROW_START, string.Empty);
      }

      logRow.IsRequestLastRow = logRow.Message.StartsWith(REQUEST_END);
    }

    private void HandleMethodColumn(string columnContent, LogSubRequest logRow)
    {
      if (columnContent.StartsWith(SQL_METHOD))
      {
        logRow.ContainsSQL = true;

        //schema
        int schemaStart = columnContent.IndexOf(BEFORE_SCHEMA_STRING);
        if (schemaStart == -1)
          return;
        else
          schemaStart += BEFORE_SCHEMA_STRING.Length;

        int schemaEnd = columnContent.IndexOf(' ', schemaStart + 1);
        logRow.DbSchema = columnContent.Substring(schemaStart, schemaEnd - schemaStart);
      }
      else
      {
        //concat method to class
        logRow.Method += '.' + columnContent;
      }
    }

    private void HandleTypeColumn(string columnContent, LogSubRequest logRow)
    {
      logRow.Type = columnContent;
    }

    private void HandleThreadColumn(string columnContent, LogSubRequest logRow)
    {
      //thread name
      int threadStart, threadEnd;
      threadStart = columnContent.IndexOf('\'');
      if (threadStart == -1)
      {
        threadStart = 0;

        //try find end by ' ' or by '['
        threadEnd = columnContent.IndexOf(' ');

        if (threadEnd == -1)
          threadEnd = columnContent.IndexOf('[');

        if (threadEnd == -1)
          threadEnd = columnContent.Length;
      }
      else //case : thread is surronded with ' xxxx '
      {
        threadStart++;//add lenth of '
        threadEnd = columnContent.IndexOf('\'', threadStart + 1);
      }

      logRow.Thread = columnContent.Substring(threadStart, threadEnd - threadStart);

      //other parts
      int start;
      int end = threadEnd;
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
        else if (subContent.StartsWith(STR_FUNCTION_NAME))
          logRow.Request = subContent.Substring(STR_FUNCTION_NAME.Length);
        else if (subContent.StartsWith(STR_JOB))
          logRow.Request = subContent.Substring(STR_JOB.Length);
        else if (subContent.StartsWith(STR_REMOTE_CALL_ID))
          logRow.CallId = subContent.Substring(STR_REMOTE_CALL_ID.Length);
        else if (subContent.StartsWith(STR_FUNC))
          logRow.Request = subContent.Substring(STR_FUNC.Length);
        else if (subContent.StartsWith(STR_DB_MESSENGER))
          continue;
        else if (subContent.StartsWith(STR_REMOTE_PROXY) || subContent.StartsWith(STR_REMOTE_DISPATCHER))
          continue;
        else//
          Debug.Fail(string.Format("Unrecognizable content '{0}' in Thread column", subContent));
      }
    }

    private void HandleDateTimeColumn(string columnContent, LogSubRequest logRow)
    {
      logRow.StartDate = DateTime.ParseExact(columnContent, TIME_PATTERN, EN_CULTURE_INFO);

    }


    public override string ParserLogVersion
    {
      get { return VERSION; }
    }

    protected override int ColumnCount
    {
      get { return 6; }
    }
  }
}
