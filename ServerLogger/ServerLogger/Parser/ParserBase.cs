using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using System.Diagnostics;

namespace ServerLogger.Parser
{
  public abstract class ParserBase
  {
    #region Const

    private const string ROW_START = "<tr";
    private const string END_ROW1 = "</tr>";
    private const string END_ROW2 = "</tr> ";
    private const string COLUMN_START = "<td>";
    private const string COLUMN_END = "</td>";

    public static readonly CultureInfo EN_CULTURE_INFO;

    protected const string STR_LOGIN_ID = "login_id:";
    protected const string STR_CALL_ID = "call_id:";
    protected const string STR_USER_NAME = "user_name:";
    protected const string STR_CONNECT_ID = "connect_id:";
    protected const string STR_FUNCTION_NAME = "func_name:";
    protected const string STR_JOB = "Job:";
    protected const string STR_DB_MESSENGER = "DBMessenger for:";
    protected const string STR_REMOTE_CALL_ID = "RemoteCallID:";
    protected const string STR_FUNC = "Func:";
    protected const string STR_REMOTE_PROXY = "Remote Proxy";
    protected const string STR_REMOTE_DISPATCHER = "Remote Dispatcher";


    protected const string REQUEST_END = "Request end:";
    protected const string REQUEST_START = "Request start: ";
    protected const string THREAD_START1 = "pool-";
    protected const string THREAD_START2 = "Thread-";

    private const int MINIMAL_GAPE_PERCENT_FOR_EVENT = 6;

    #endregion

    private int m_lastPercentEvented;
    private bool m_cancel;
    private String m_logVersion;

    public String LogVersion
    {
        get { return m_logVersion == null ? ParserLogVersion : m_logVersion; }
        set { m_logVersion = value; }
    }

    static ParserBase()
    {
      EN_CULTURE_INFO = CultureInfo.CreateSpecificCulture("en-US");
    }

    public event EventHandler<ParsePercentageEventArgs> ParseProgress;


    public abstract bool IsValidLog(IList<string> lines);

    public List<LogSubRequest> Parse(string sourceFile, IList<string> lines)
    {
      int firstRow = FirstRow(lines);
      int lastRow = LastRow(lines);
      m_cancel = false;
      m_lastPercentEvented = -MINIMAL_GAPE_PERCENT_FOR_EVENT;

      List<LogSubRequest> logs = new List<LogSubRequest>();
      LogSubRequest logRow;
      int columnIndex, columnStart, columnEnd;
      string columnContent;
      int currentPercent;
      bool needEvent;
      for (int i = firstRow; i <= lastRow && !m_cancel; i++)
      {
        if (lines[i] == string.Empty || !lines[i].StartsWith(ROW_START))
          continue;

        //if line is divided to several rows - join that rows
        if (!lines[i].EndsWith(END_ROW1))
          HandleBrokenLine(lines, i);

        //read columns
        logRow = new LogSubRequest();
        columnIndex = 0;
        columnStart = columnEnd = 0;
        while (!m_cancel)//read columns
        {
          columnStart = lines[i].IndexOf(COLUMN_START, columnEnd);
          if (columnStart == -1)
            break;
          else
            columnStart += COLUMN_START.Length;

          //find end of column
          if (columnIndex + 1 == ColumnCount)//if it last column, it can be computed rather simply by decreasing 10
            columnEnd = lines[i].Length - 10;
          else
          {
            columnEnd = lines[i].IndexOf(COLUMN_END, columnStart);
            if (columnEnd == -1)
            {
              columnEnd = lines[i].Length - 1;
            }
          }

          columnContent = lines[i].Substring(columnStart, columnEnd - columnStart);
          HandleColumn(columnIndex, columnContent, logRow);
          columnIndex++;
        }

        //if date isn't recognized - continue
        if (logRow.StartDate.Ticks == 0)
          continue;

        //try complete request field
        TryCompleteRequestIfMissing(logRow);

        //add to collection
        if (!OnBeforeAdd(logs, logRow))
          continue;

        logRow.CompareIndex = logs.Count;
        logRow.Source = sourceFile;

        logs.Add(logRow);

        //parse event 
        if (ParseProgress != null)
        {
          currentPercent = i * 100 / lines.Count;
          needEvent = (currentPercent - m_lastPercentEvented > MINIMAL_GAPE_PERCENT_FOR_EVENT);
          if (needEvent)
          {
            ParseProgress(this, new ParsePercentageEventArgs(currentPercent));
            m_lastPercentEvented = currentPercent;
          }
        }
      }

      return logs;
    }

    protected abstract void HandleColumn(int columnIndex, string columnContent, LogSubRequest logRow);

    protected virtual int FirstRow(IList<string> lines)
    {
      for (int i = 0; i < lines.Count; i++)
      {
        if (lines[i].StartsWith(ROW_START))
          return i;
      }

      return lines.Count;
    }

    protected virtual int LastRow(IList<string> lines)
    {
      for (int i = lines.Count - 1; i >= 0; i--)
      {
        if (lines[i].StartsWith(ROW_START))
          return i;
      }
      throw new ApplicationException("Not found last row");
    }

    protected abstract int ColumnCount { get; }

    /// <summary>
    /// Return true if row should be added and false if row shouldn't be added to collection
    /// </summary>
    /// <param name="logs"></param>
    /// <param name="newRow"></param>
    /// <returns></returns>
    protected virtual bool OnBeforeAdd(List<LogSubRequest> logs, LogSubRequest newRow)
    {
      return true;
    }

    private void TryCompleteRequestIfMissing(LogSubRequest newRow)
    {
      if (!string.IsNullOrEmpty(newRow.Request))
        return;

      if (newRow.Message.StartsWith(REQUEST_START))
      {
        newRow.IsRequestFirstRow = true;
        newRow.Request = newRow.Message.Substring(REQUEST_START.Length);
      }
      else if (newRow.Thread.StartsWith(THREAD_START1) || newRow.Thread.StartsWith(THREAD_START2))
        newRow.Request = newRow.Thread;
    }

    private static void HandleBrokenLine(IList<string> lines, int index)
    {
      if (lines[index].EndsWith(END_ROW1) || lines[index].EndsWith(END_ROW2))
        return;

      for (int i = index + 1; i < lines.Count - 1; i++)
      {
        double rowLenght = lines[i].Length / 1000000d;
        if (lines[i].Length > 1000000)
        {
          //commented temporary
          //Debug.Fail("There is extreme row with index " + index + " , size of " + rowLenght.ToString("N1") + " million characters");
          return;
        }

        lines[index] = lines[index] + lines[i];
        lines[i] = string.Empty;

        if (lines[index].EndsWith(END_ROW1) || lines[index].EndsWith(END_ROW2))
          return;
      }
    }

    private static int FindLine(string startWith, IList<string> lines, int startIndex)
    {
      while (startIndex < lines.Count && !lines[startIndex].StartsWith(startWith))
        startIndex++;

      if (startIndex == lines.Count)
        startIndex = -1;

      return startIndex;
    }

    public abstract string ParserLogVersion { get; }

    public void Stop()
    {
      m_cancel = true;
    }

  }
}
