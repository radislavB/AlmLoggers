using System;
using System.Collections.Generic;
using System.Text;

namespace ServerLogger.Parser
{
    class Parser1152SA : AbsSAParserWithVersion
    {
        const string VERSION = "ALM 11.52";

        protected override string LogFormatVersionValue
        {
            get { return VERSION; }
        }
    }
}
