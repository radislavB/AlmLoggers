using System;
using System.Collections.Generic;
using System.Text;

namespace ServerLogger.Parser
{
  public class Parser0920SA : Parser0920
  {
    const string VERSION = "SA 9.2";
    const int RECOGNITION_LINE1 = 113;
    const int RECOGNITION_LINE2 = 114;

    const string RECOGNITION_STRING = "<h2>Site Admin Java Server</h2><table>";

    const int FIRST_ROW = 198;

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
  }
}
