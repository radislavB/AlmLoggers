using System;

namespace ServerLogger.Parser
{
  public class ParsePercentageEventArgs : EventArgs
  {
    readonly public int ParsedPercent;

    public ParsePercentageEventArgs(int parsedPercent)
    {
      ParsedPercent = parsedPercent;
    }
  }
}
