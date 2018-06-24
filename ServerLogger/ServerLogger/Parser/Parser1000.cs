using System;
using System.Collections.Generic;

namespace ServerLogger.Parser
{
  public class Parser1000 : ParserBase
  {
    const string VERSION = "QC 10.0 - Atlantis";
    const int FIRST_ROW = 198;
    const int RECOGNITION_LINE1 = 113;
    const int RECOGNITION_LINE2 = 114;
    const string RECOGNITION_STRING = "<h2>Quality Center Server log</h2><table>";
    protected const string TIME_PATTERN = "MMM dd<br>HH:mm:ss.fff";

    const string SQL_ROW_START = @"/* ~~QC */ ";
    const string SQL_DOUBLE_ROW_START = "SQL execution completed in ";
    const string MILLISECONDS = "ms";

   // When adding value to this enum, add it only at the end
    public enum COLUMN_INDEXES 
    { 
        DATETIME, 
        THREAD, 
        TYPE, 
        METHOD, 
        MESSAGE, 
        LOGIN, 
        IP, 
        DB_DATETIME
    };

    public override bool IsValidLog(IList<string> lines)
    {
      if (lines.Count < RECOGNITION_LINE2)
      {
        return false;
      }

      bool supported = (lines[RECOGNITION_LINE1] == RECOGNITION_STRING || lines[RECOGNITION_LINE2] == RECOGNITION_STRING);
      return supported;
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
        case 5:
          HandleLoginColumn(columnContent, logRow);
          break;
        case 6:
          HandleIpColumn(columnContent, logRow);
          break;
        default:
          throw new ApplicationException("Wrong number of columns");

      }
    }

    protected override bool OnBeforeAdd(List<LogSubRequest> logs, LogSubRequest newRow)
    {
      return HandleDoubleRow(logs, newRow);
    }

    protected void HandleMessageColumn(string columnContent, LogSubRequest logRow)
    {
      logRow.Message = columnContent;
      if (logRow.ContainsSQL)
      {
        logRow.Message = logRow.Message.Replace(SQL_ROW_START, string.Empty);
      }

      logRow.IsRequestLastRow = logRow.Message.StartsWith(REQUEST_END);


    }

    protected void HandleMethodColumn(string columnContent, LogSubRequest logRow)
    {
      //method
      int methodLength = columnContent.IndexOf(')') + 1;
      logRow.Method = columnContent.Substring(0, methodLength);

      //schema
      int schemaStart = columnContent.IndexOf('\'', methodLength);
      if (schemaStart == -1)
        return;
      else
        schemaStart++;//add length of '

      int schemaEnd = columnContent.IndexOf('\'', schemaStart + 1);
      logRow.DbSchema = columnContent.Substring(schemaStart, schemaEnd - schemaStart);
      logRow.ContainsSQL = true;
    }

    protected void HandleTypeColumn(string columnContent, LogSubRequest logRow)
    {
      logRow.Type = columnContent;
    }

    protected void HandleLoginColumn(string columnContent, LogSubRequest logRow)
    {
      logRow.User = columnContent;
    }

    protected void HandleIpColumn(string columnContent, LogSubRequest logRow)
    {
      logRow.IP = columnContent;
    }

    protected void HandleThreadColumn(string columnContent, LogSubRequest logRow)
    {
      //thread name
      int threadNameLength = columnContent.IndexOf(' ');
      if (threadNameLength == -1)
        threadNameLength = columnContent.Length;
      logRow.Thread = columnContent.Substring(0, threadNameLength);

      //other parts
      int start;
      int end = threadNameLength;
      string subContent;
      while (true)
      {
        start = columnContent.IndexOf('[', end);
        if (start == -1)
          break;
        else
          start++;//add length of '['

        end = columnContent.IndexOf(']', start);
        if (end == -1)
        {
          end = columnContent.Length - 1;
        }

        subContent = columnContent.Substring(start, end - start);

        if (subContent.StartsWith(STR_CALL_ID))
          logRow.CallId = subContent.Substring(STR_CALL_ID.Length);
        else if (subContent.StartsWith(STR_CONNECT_ID))
          logRow.ConnectId = subContent.Substring(STR_CONNECT_ID.Length);
        else if (subContent.StartsWith(STR_LOGIN_ID))
          logRow.LoginId = subContent.Substring(STR_LOGIN_ID.Length);
        else if (subContent.StartsWith(STR_USER_NAME))
          logRow.User = subContent.Substring(STR_USER_NAME.Length);
        else
          logRow.Request = subContent;
      }
    }

    protected void HandleDateTimeColumn(string columnContent, LogSubRequest logRow)
    {
      logRow.StartDate = DateTime.ParseExact(columnContent, TIME_PATTERN, EN_CULTURE_INFO);

    }

    /// <summary>
    /// Definition : double rows contains EXECUTION TIME and its FIRST ROW
    /// Return true if row should be added and 
    /// false row should be omitted , because : sibling row was found and was updated so we don't need this row
    /// </summary>
    /// <param name="m_logs"></param>
    /// <param name="doubleRow"></param>
    /// <returns></returns>
    private bool HandleDoubleRow(List<LogSubRequest> logs, LogSubRequest suspectRow)
    {
      if (!suspectRow.Message.StartsWith(SQL_DOUBLE_ROW_START))
      {
        return true;
      }

      int execTimeStrEnd = suspectRow.Message.IndexOf(MILLISECONDS, SQL_DOUBLE_ROW_START.Length);
      string execTimeStr = suspectRow.Message.Substring(SQL_DOUBLE_ROW_START.Length, execTimeStrEnd - SQL_DOUBLE_ROW_START.Length);
      
      int execTime=0;
      try
      {
        execTime = int.Parse(execTimeStr);
      }
      catch (OverflowException)
      {
        execTime = int.MaxValue;
      }

      DateTime firstRowStartTime = suspectRow.StartDate.AddMilliseconds(-execTime);
      firstRowStartTime = firstRowStartTime.AddMilliseconds(-100);//flexibility for 100 ms
      
      LogSubRequest tempLog;
      for (int i = logs.Count - 1; i >= 0; i--)
      {
        tempLog = logs[i];

        if (tempLog.StartDate < firstRowStartTime)
          return true;


        if (tempLog.Thread == suspectRow.Thread &&
          tempLog.CallId == suspectRow.CallId &&
          tempLog.ConnectId == suspectRow.ConnectId &&
          tempLog.LoginId == suspectRow.LoginId &&
          tempLog.Method == suspectRow.Method &&
          tempLog.Request == suspectRow.Request &&
          suspectRow.Message.Contains(tempLog.Message)
          )
        {
          tempLog.DbTime = execTime;

          //row affected : [1 rows affected]
          int rowAffectedStart = suspectRow.Message.IndexOf('[', execTimeStrEnd, 10);
          if (rowAffectedStart > 0)
          {
            rowAffectedStart++;//add length of [
            int rowAffectedEnd = suspectRow.Message.IndexOf(' ', rowAffectedStart, 10);
            tempLog.RowAffected = suspectRow.Message.Substring(rowAffectedStart, rowAffectedEnd - rowAffectedStart); ;
          }
          return false;
        }
      }
      return true;
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
