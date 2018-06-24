using System;
using System.Collections.Generic;
using System.Text;

namespace ServerLogger.Parser
{
    public abstract class AbsALMParserWithVersion : AbsParserWithVersion
    {
        const string TITLE_ROW_TEXT = "<h2>HP ALM Server log</h2><table>";

        protected override string TitleRowText
        {
            get { return TITLE_ROW_TEXT; }
        }

    }
}
