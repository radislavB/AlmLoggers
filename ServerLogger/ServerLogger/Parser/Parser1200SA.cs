using System.Collections.Generic;
using System.Text;

namespace ServerLogger.Parser
{
	class Parser1200SA : AbsParser1200
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
				return "<h2>Site Admin Server log</h2><table>";
			}
		}

	}
}
