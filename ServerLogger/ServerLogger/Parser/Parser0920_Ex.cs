using System;
using System.Collections.Generic;

namespace ServerLogger.Parser
{
  public class Parser0920_Ex : Parser1100
  {
    const string VERSION = "QC 9.2 EX";
    const int RECOGNITION_LINE1 = 119;
    const int RECOGNITION_LINE2 = 120;
    const string RECOGNITION_STRING = "<h2>Quality Center Java Server</h2><table>";
    const int FIRST_ROW = 214;


    public override bool IsValidLog(IList<string> lines)
    {
      if (lines.Count < RECOGNITION_LINE1)
      {
        return false;
      }

      return (lines[RECOGNITION_LINE1] == RECOGNITION_STRING || lines[RECOGNITION_LINE2] == RECOGNITION_STRING);
    }

    protected override int FirstRow(IList<string> lines)
    {
      return FIRST_ROW;
    }

    public override string ParserLogVersion
    {
      get { return VERSION; }
    }


    protected override void HandleColumn(int columnIndex, string columnContent, LogSubRequest logRow)
    {
      switch (columnIndex)
      {
        case 0:
        case 1:
        case 2:
        case 3:
        case 4:
        case 6:
          base.HandleColumn(columnIndex, columnContent, logRow);
          break;
        case 5:
          Parser0920.HandleMethodColumn(columnContent, logRow);
          break;
        default:
          throw new ApplicationException("Wrong number of columns");
      }
    }

  }
}
