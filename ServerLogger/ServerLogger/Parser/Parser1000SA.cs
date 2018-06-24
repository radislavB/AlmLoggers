using System;
using System.Collections.Generic;
using System.Text;

namespace ServerLogger.Parser
{
  public class Parser1000SA : Parser1000
  {
    const string VERSION = "SA 10.0";
    const int RECOGNITION_LINE1 = 113;
    const int RECOGNITION_LINE2 = 114;

    const string RECOGNITION_STRING = "<h2>Site Admin Server log</h2><table>";

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
