using System;
using System.Collections.Generic;
using System.Text;

namespace ServerLogger.Parser
{
	public abstract class AbsParserWithVersion : Parser1000
	{
		// Zero based
		private const int TITLE_LINE_NUMBER = 119;

		// Zero based
		private const int LOG_FORMAT_VERSION_LINE_NUMBER = 120;
		private const int FIRST_ROW = 219;

		private const string LOG_FORMAT_VERSION_ROW_TEXT_PREFIX = "<tr><td class =\"filter\">Log file format version</td><td class =\"filter\">";
		private const string LOG_FORMAT_VERSION_ROW_TEXT_SUFFIX = "</td></tr>";
		private const string ROW_BEFORE_FIRST_ROW_TEXT = "</tr>";

		private static IDictionary<int, COLUMN_INDEXES> columnIndexesToTypesMap;

		static AbsParserWithVersion()
		{
			columnIndexesToTypesMap = new Dictionary<int, COLUMN_INDEXES>();

			columnIndexesToTypesMap.Add(0, COLUMN_INDEXES.DB_DATETIME);
			columnIndexesToTypesMap.Add(1, COLUMN_INDEXES.DATETIME);
			columnIndexesToTypesMap.Add(2, COLUMN_INDEXES.THREAD);
			columnIndexesToTypesMap.Add(3, COLUMN_INDEXES.LOGIN);
			columnIndexesToTypesMap.Add(4, COLUMN_INDEXES.IP);
			columnIndexesToTypesMap.Add(5, COLUMN_INDEXES.TYPE);
			columnIndexesToTypesMap.Add(6, COLUMN_INDEXES.METHOD);
			columnIndexesToTypesMap.Add(7, COLUMN_INDEXES.MESSAGE);
		}

		protected virtual int TitleLineNumber
		{
			get { return TITLE_LINE_NUMBER; }
		}

		protected abstract string TitleRowText
		{
			get;
		}

		protected virtual string RowBeforeFirstRowText
		{
			get { return ROW_BEFORE_FIRST_ROW_TEXT; }
		}

		protected virtual int LogFormatVersionLineNumber
		{
			get { return LOG_FORMAT_VERSION_LINE_NUMBER; }
		}

		protected abstract string LogFormatVersionValue
		{
			get;
		}

		private static string ParseLogFormatVersionValue(string logFormatVersionLine)
		{
			string parsedVersion = logFormatVersionLine.Substring(LOG_FORMAT_VERSION_ROW_TEXT_PREFIX.Length);
			parsedVersion = parsedVersion.Substring(0, parsedVersion.Length - LOG_FORMAT_VERSION_ROW_TEXT_SUFFIX.Length);
			return parsedVersion;
		}

		public override bool IsValidLog(IList<string> lines)
		{
			if (lines.Count <= TitleLineNumber)
			{
				return false;
			}

			if (!lines[TitleLineNumber].StartsWith(TitleRowText) &&
				!lines[TitleLineNumber + 1].StartsWith(TitleRowText))
			{
				return false;
			}

			// It might be, that there is a row (link to previous log)
			// Then all the row numbers are shifted down by 1
			// For example: <a href="SaServerLog_2012_12_18_11_03_50_474.html" >Go to previous log</a>
			int logFormatVersionLineNumber = LogFormatVersionLineNumber;
			if (lines[TitleLineNumber + 1].StartsWith(TitleRowText))
				logFormatVersionLineNumber++;

			bool isOk = lines[logFormatVersionLineNumber].StartsWith(LOG_FORMAT_VERSION_ROW_TEXT_PREFIX) &&
				  ParseLogFormatVersionValue(lines[logFormatVersionLineNumber]).StartsWith(LogFormatVersionValue);
            LogVersion = ParseLogFormatVersionValue(lines[logFormatVersionLineNumber]);
			return isOk;
		}

		protected override int FirstRow(IList<string> lines)
		{
			if (lines[FIRST_ROW].StartsWith(RowBeforeFirstRowText))
				return FIRST_ROW + 1;
			return FIRST_ROW;
		}

		public override string ParserLogVersion
		{
			get { return LogFormatVersionValue; }
		}

		protected override int ColumnCount
		{
			get { return columnIndexesToTypesMap.Count; }
		}

		protected COLUMN_INDEXES GetColumnIndexType(int columnIndex)
		{
			return columnIndexesToTypesMap[columnIndex];
		}

		protected void HandleDBDateTimeColumn(string columnContent, LogSubRequest logRow)
		{
			logRow.DbStartDate = DateTime.ParseExact(columnContent, TIME_PATTERN, EN_CULTURE_INFO);
		}

		private void HandleColumn(COLUMN_INDEXES columnType, string columnContent, LogSubRequest logRow)
		{
			switch (columnType)
			{
				case COLUMN_INDEXES.DATETIME:
					HandleDateTimeColumn(columnContent, logRow);
					break;
				case COLUMN_INDEXES.DB_DATETIME:
					HandleDBDateTimeColumn(columnContent, logRow);
					break;
				case COLUMN_INDEXES.IP:
					HandleIpColumn(columnContent, logRow);
					break;
				case COLUMN_INDEXES.LOGIN:
					HandleLoginColumn(columnContent, logRow);
					break;
				case COLUMN_INDEXES.MESSAGE:
					HandleMessageColumn(columnContent, logRow);
					break;
				case COLUMN_INDEXES.METHOD:
					HandleMethodColumn(columnContent, logRow);
					break;
				case COLUMN_INDEXES.THREAD:
					HandleThreadColumn(columnContent, logRow);
					break;
				case COLUMN_INDEXES.TYPE:
					HandleTypeColumn(columnContent, logRow);
					break;
			}

		}

		protected override void HandleColumn(int columnIndex, string columnContent, LogSubRequest logRow)
		{
			if (columnIndex >= ColumnCount)
				throw new ApplicationException("Wrong number of columns");

			HandleColumn(GetColumnIndexType(columnIndex), columnContent, logRow);
		}

	}
}
