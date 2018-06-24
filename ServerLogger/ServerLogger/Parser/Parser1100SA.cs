using System;
using System.Collections.Generic;
using System.Text;

namespace ServerLogger.Parser
{
  public class Parser1100SA : Parser1100
  {
    const string VERSION = "SA 11.0";
    const int RECOGNITION_LINE1 = 119;
    const int RECOGNITION_LINE2 = 120;

    const string RECOGNITION_STRING = "<h2>Site Admin Server log</h2><table>";

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

  }
}
