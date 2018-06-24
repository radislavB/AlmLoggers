using System;
using System.Collections.Generic;
using System.Text;

namespace ServerLogger.Parser
{
	class Parser1200 : AbsParser1200
	{
        const string VERSION = "12";

        protected override string LogFormatVersionValue
        {
            get { return VERSION; }
        }

		protected override string TitleRowText
		{
			get
			{
				return "<h2>HP ALM Server log</h2><table>";
			}
		}

	}
}
