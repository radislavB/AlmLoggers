using System;
using System.Collections.Generic;
using System.Text;

namespace ServerLogger.Parser
{
  public class Parser1100Patch10 : Parser1100
  {
    const string VERSION = "ALM 11.0 - Maya Patch 10+";
    const int RECOGNITION_LINE1 = 16;

    const string RECOGNITION_STRING1 = "<h2>HP ALM Server log</h2><table>";


    const int FIRST_ROW = 111;

    public override string ParserLogVersion
    {
      get { return VERSION; }
    }

    public override bool IsValidLog(IList<string> lines)
    {
      if (lines.Count < RECOGNITION_LINE1)
      {
        return false;
      }

      return (
        lines[RECOGNITION_LINE1].StartsWith(RECOGNITION_STRING1)

        );
    }

    protected override int FirstRow(IList<string> lines)
    {
      return FIRST_ROW;
    }
  }
}
