using System;
using System.Collections.Generic;
using System.Text;

namespace ServerLogger.Parser
{
  public class Parser0920SA_Ex : Parser1100
  {
    const string VERSION = "SA 9.2 Ex";
    const int RECOGNITION_LINE1 = 119;
    const int RECOGNITION_LINE2 = 120;

    const string RECOGNITION_STRING = "<h2>Site Admin Java Server</h2><table>";

    const int FIRST_ROW = 214;

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
