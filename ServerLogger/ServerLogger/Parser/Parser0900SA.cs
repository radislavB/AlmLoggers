using System.Collections.Generic;

namespace ServerLogger.Parser
{
  //parser for patch 26
  public class Parser0900SA : Parser0900
  {
    const string VERSION = "SA 9.0";
    const int RECOGNITION_LINE1 = 118;
    const int RECOGNITION_LINE2 = 119;

    const string RECOGNITION_STRING = "<b>Site Admin Java Server</b>";

    const int FIRST_ROW = 162;

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

    protected override int ColumnCount
    {
      get { return 6; }
    }
  }
}
