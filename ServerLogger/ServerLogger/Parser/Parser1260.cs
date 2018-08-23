using System;
using System.Collections.Generic;
using System.Text;

namespace ServerLogger.Parser
{
	class Parser1260 : Parser1200
	{
		protected override string TitleRowText
		{
			get
			{
				return "<h2>Micro Focus ALM Server log</h2><table>";
			}
		}

	}
}
