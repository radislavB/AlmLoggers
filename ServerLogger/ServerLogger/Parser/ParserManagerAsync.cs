using System;
using System.Collections.Generic;
using System.IO;
using ServerLogger.Progress;
using LogComponents;

namespace ServerLogger.Parser
{
  public class ParserManagerAsync : JobBase
  {
    ParserFactory parserFactory = new ParserFactory();
    ParserBase m_parser;
    bool m_fileLocked;
    string m_logVersion;
    IList<string> m_fileNames;
    LogRequestCollection m_logRequestCollection;



    static Dictionary<string, List<LogSubRequest>> m_fileCache = new Dictionary<string, List<LogSubRequest>>();

    int m_parsedFileCount;

    public LogRequestCollection LogRequestCollection
    {
      get { return m_logRequestCollection; }
    }

    public IList<string> FileNames
    {
      get { return m_fileNames; }
      set
      {
        m_fileNames = value;
      }
    }

    protected override void OnBeforeStart()
    {
      InitializeProgressForm("Parsing...", false);
    }

    protected override void OnBeforeStop()
    {
      m_parser.Stop();
    }

    protected override void ThreadJob()
    {
      List<LogSubRequest> allLogs = new List<LogSubRequest>();
      List<LogSubRequest> logs;
      bool fileLocked;
      for (int i = 0; i < m_fileNames.Count && !Cancel; i++)
      {
        if (m_fileCache.ContainsKey(m_fileNames[i]))
        {
          logs = m_fileCache[m_fileNames[i]];
        }
        else
        {
          m_parsedFileCount = i;

          RaizeJobProgressEvent(
            new JobProgressEventArgs(
              string.Format("Parsing...  ({0}/{1})", i + 1, m_fileNames.Count),
              i * 100 / m_fileNames.Count,
              string.Empty,
              0));

          IList<string> lines = Helpers.IOUtilities.GetLinesFromFile(m_fileNames[i], out fileLocked);
          if (fileLocked)
            m_fileLocked = true;
          
          RaizeJobProgressEvent(
            new JobProgressEventArgs(
            string.Empty,
            -1,
            string.Format("{0} ({1} lines)", Path.GetFileName(m_fileNames[i]), lines.Count),
            0));

          m_parser = parserFactory.GetParser(m_fileNames[i], lines);
          m_parser.ParseProgress += OnParseProgress;
          m_logVersion = m_parser.LogVersion;

          logs = m_parser.Parse(m_fileNames[i],lines);

          m_parser.ParseProgress -= OnParseProgress;

          if (!fileLocked)
            m_fileCache.Add(m_fileNames[i], logs);
        }
        allLogs.AddRange(logs);
        GC.Collect();
      }

      if (m_fileNames.Count > 1)
        allLogs.Sort();

      string caption = (m_fileNames.Count == 1 ? Path.GetFileName(m_fileNames[0]) : "Merge ");
      LogSubRequestCollection logRowCollection = new LogSubRequestCollection(allLogs, m_logVersion, m_fileLocked, m_fileNames);
      m_logRequestCollection = new LogRequestCollection(logRowCollection);
    }

    private void OnParseProgress(object sender, ParsePercentageEventArgs e)
    {
      RaizeJobProgressEvent(new JobProgressEventArgs(
        string.Empty,
        (m_parsedFileCount * 100 + e.ParsedPercent) / m_fileNames.Count,
        string.Empty,
        e.ParsedPercent));
    }

  }
}
