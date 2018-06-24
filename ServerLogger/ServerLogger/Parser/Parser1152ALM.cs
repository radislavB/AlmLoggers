using System;
using System.Collections.Generic;
using System.Text;

namespace ServerLogger.Parser
{
    public class Parser1152ALM : AbsALMParserWithVersion
    {
        const string VERSION = "ALM 11.52";

        protected override string LogFormatVersionValue
        {
            get { return VERSION; }
        }
    }
}
