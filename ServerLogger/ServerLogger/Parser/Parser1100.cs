using System;
using System.Collections.Generic;
using System.Text;

namespace ServerLogger.Parser
{
  public class Parser1100 : Parser1000
  {
    const string VERSION = "QC 11.0 - Maya";
    const int RECOGNITION_LINE1 = 119;
    const int RECOGNITION_LINE2 = 120;

    const string RECOGNITION_STRING1 = "<h2>Quality Center Server log</h2><table>";
    const string RECOGNITION_STRING2 = "<h2>HP ALM Server log</h2><table>";


    const int FIRST_ROW = 198;

    public override bool IsValidLog(IList<string> lines)
    {
      if (lines.Count < RECOGNITION_LINE2)
      {
        return false;
      }

      return (
        lines[RECOGNITION_LINE1].StartsWith(RECOGNITION_STRING1) ||
        lines[RECOGNITION_LINE2].StartsWith(RECOGNITION_STRING1) ||

        lines[RECOGNITION_LINE1].StartsWith(RECOGNITION_STRING2) ||
        lines[RECOGNITION_LINE2].StartsWith(RECOGNITION_STRING2)

        );
    }

    protected override int FirstRow(IList<string> lines)
    {
      return FIRST_ROW;
    }

    public override string ParserLogVersion
    {
      get { return VERSION; }
    }

    protected override int ColumnCount
    {
      get { return 7; }
    }

    protected override void HandleColumn(int columnIndex, string columnContent, LogSubRequest logRow)
    {
      switch (columnIndex)
      {
        case 0:
          base.HandleColumn((int)COLUMN_INDEXES.DATETIME, columnContent, logRow);
          break;
        case 1:
          base.HandleColumn((int)COLUMN_INDEXES.THREAD, columnContent, logRow);
          break;
        case 2:
          base.HandleColumn((int)COLUMN_INDEXES.LOGIN, columnContent, logRow);
          break;
        case 3:
          base.HandleColumn((int)COLUMN_INDEXES.IP, columnContent, logRow);
          break;
        case 4:
          base.HandleColumn((int)COLUMN_INDEXES.TYPE, columnContent, logRow);
          break;
        case 5:
          base.HandleColumn((int)COLUMN_INDEXES.METHOD, columnContent, logRow);
          break;
        case 6:
          base.HandleColumn((int)COLUMN_INDEXES.MESSAGE, columnContent, logRow);
          break;
        default:
          throw new ApplicationException("Wrong number of columns");

      }
    }
  }
}
