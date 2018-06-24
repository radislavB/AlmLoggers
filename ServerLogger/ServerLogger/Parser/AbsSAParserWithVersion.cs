using System;
using System.Collections.Generic;
using System.Text;

namespace ServerLogger.Parser
{
    public abstract class AbsSAParserWithVersion : AbsParserWithVersion
    {
        const string TITLE_ROW_TEXT = "<h2>Site Admin Server log</h2><table>";

        protected override string TitleRowText
        {
            get { return TITLE_ROW_TEXT; }
        }
    }
}
