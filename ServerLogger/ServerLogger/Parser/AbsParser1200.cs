using System;
using System.Collections.Generic;
using System.Text;

namespace ServerLogger.Parser
{
	abstract class AbsParser1200 : AbsSAParserWithVersion
	{

		protected override string LogFormatVersionValue
		{
			get { return "ALM 12"; }
		}

		protected override int TitleLineNumber
		{
			get
			{
				return 124;
			}
		}

		protected override int LogFormatVersionLineNumber
		{
			get
			{
				return 125;
			}
		}

		protected override int FirstRow(IList<string> lines)
		{
			return 231;
		}

		protected override int ColumnCount
		{
			get
			{
				return 9;
			}
		}

		protected override void HandleColumn(int columnIndex, string columnContent, LogSubRequest logRow)
		{
			switch (columnIndex)
			{
				case 0:
					HandleDBDateTimeColumn(columnContent, logRow);
					break;
				case 1:
					HandleDateTimeColumn(columnContent, logRow);
					break;
				case 2:
					HandleThreadColumn(columnContent, logRow);
					break;
				case 3:
					HandleRequestTypeColumn(columnContent, logRow);
					break;
				case 4:
					HandleLoginColumn(columnContent, logRow);
					break;
				case 5:
					HandleIpColumn(columnContent, logRow);
					break;
				case 6:
					HandleTypeColumn(columnContent, logRow);
					break;
				case 7:
					HandleMethodColumn(columnContent, logRow);
					break;
				case 8:
					HandleMessageColumn(columnContent, logRow);
					break;
			}
		}

		protected void HandleRequestTypeColumn(string columnContent, LogSubRequest logRow)
		{
			logRow.RequestType = columnContent;
		}


	}
}
