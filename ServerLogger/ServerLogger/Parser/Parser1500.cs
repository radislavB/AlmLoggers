using System;
using System.Collections.Generic;
using System.Text;

namespace ServerLogger.Parser
{
	class Parser1500 : AbsParser1200
	{
        const string VERSION = "15";

        protected override string LogFormatVersionValue
        {
            get { return VERSION; }
        }

		protected override string TitleRowText
		{
			get
			{
                return "<h2>Micro Focus ALM Server log</h2><table>";
            }
		}

	}
}
