using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Reflection;
using LogComponents.FilterControl;
using System.Collections.Generic;

namespace ServerLogger
{
	public class LogRequest : FilterableBindingList<LogSubRequest>, ISupportWarnTypes, ISupportId
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		LogSubRequest m_initializedRow;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		bool m_initialized;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		int m_id;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		bool m_isErrType;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		bool m_isWrnType;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		DateTime m_totalTime;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		static Regex s_totalTimeRegex = new Regex(@"\d+");

		public bool IsWrnType
		{
			get { return m_isWrnType; }
			set { m_isWrnType = value; }
		}

		public bool IsErrType
		{
			get { return m_isErrType; }
			set { m_isErrType = value; }
		}

		public DateTime TotalTime
		{
			get { return m_totalTime; }
		}

		public int Id
		{
			get { return m_id; }
			set
			{
				m_id = value;
				//this set is done then all rows are inserted, lets verify here totalTime
				if (m_totalTime.Ticks == 0)
				{
					TimeSpan span = FinishDate.Subtract(StartDate);
					m_totalTime = new DateTime(span.Ticks);
				}
			}
		}

		public DateTime StartDate
		{
			get
			{
				return GetItem(0, true).StartDate;
			}
		}

		public DateTime FinishDate
		{
			get { return GetItem(Count - 1, true).StartDate; }
		}

		public string LoginId
		{
			get
			{
				if (!m_initialized)
					return string.Empty;

				return m_initializedRow.LoginId;
			}
		}

		public string RequestType
		{

			get
			{
				if (!m_initialized)
					return string.Empty;

				return m_initializedRow.RequestType;
			}
		}

		public string IP
		{
			get
			{
				if (!m_initialized)
					return string.Empty;

				return m_initializedRow.IP;
			}
		}

		public string ConnectId
		{
			get
			{
				if (!m_initialized)
					return string.Empty;

				return m_initializedRow.ConnectId;
			}
		}

		public string CallId
		{
			get
			{
				if (!m_initialized)
					return string.Empty;

				return m_initializedRow.CallId;
			}
		}

		public string User
		{
			get
			{
				if (!m_initialized)
					return string.Empty;

				return m_initializedRow.User;
			}
		}

		public string Request
		{
			get
			{
				if (!m_initialized)
					return string.Empty;

				return m_initializedRow.Request;
			}
		}

		public string Thread
		{
			get
			{
				if (!m_initialized)
					return string.Empty;

				return m_initializedRow.Thread;
			}
		}

		internal bool TryAdd(LogSubRequest newRow)
		{
			//skip unrecognizable rows
			if (newRow.Request == string.Empty)
				return true;

			if (!m_initialized)
			{
				Add(newRow);
				Initialize(newRow);
				return true;
			}

			if (!m_initialized)
				throw new ApplicationException("Failed to initialize LogRequest");

			if (IsBelong(newRow))
			{
				Add(newRow);
				return true;
			}

			return false;
		}

		private bool IsBelong(LogSubRequest newRow)
		{

			bool basicDefinitionBelong = m_initializedRow.Request == newRow.Request &&
			m_initializedRow.LoginId == newRow.LoginId &&
			m_initializedRow.CallId == newRow.CallId &&
			m_initializedRow.Thread == newRow.Thread &&
			m_initializedRow.IP == newRow.IP;

			if (basicDefinitionBelong)
			{
				TimeSpan ts = m_initializedRow.StartDate.Subtract(newRow.StartDate);
				//one request could not long more that 12 hour
				if (ts.TotalHours > 12)
				{
					return false;
				}
			}

			return basicDefinitionBelong;

		}

		private void Initialize(LogSubRequest newRow)
		{
			if (string.IsNullOrEmpty(newRow.Request) || m_initialized || newRow.IsRequestFirstRow)
				return;

			m_initializedRow = newRow;
			m_initialized = true;
		}

		public override string ToString()
		{
			return string.Format("{0} : {1}", Id, Request);
		}

		public override bool MatchingFilter(int index, string property, string value)
		{
			LogSubRequest item = this.FullList[index];
			if (property == FilterConfig.EMPTY_PROPERTY)
			{
				return (item.Method.IndexOf(value, StringComparison.OrdinalIgnoreCase) != -1 ||
					item.Message.IndexOf(value, StringComparison.OrdinalIgnoreCase) != -1 ||
					item.Type.IndexOf(value, StringComparison.OrdinalIgnoreCase) != -1
					);
			}
			else if (property.Equals(Constants.COLUMNS.TOTAL_TIME_PROPERTY_NAME, StringComparison.OrdinalIgnoreCase))
			{
				try
				{
					TimeSpan dateTimeValue = DateTime.ParseExact(value, Constants.COLUMNS.TOTAL_TIME_FORMAT, null).TimeOfDay;
					return item.TotalTime.TimeOfDay >= dateTimeValue;
				}
				catch
				{
					return false;
				}
			}
			else
			{
				return IsContainsPropertyValue(item, property, value);
			}
		}

		public override void Add(LogSubRequest value)
		{
			base.Add(value);
			if (value.IsErrType)
				IsErrType = true;
			else if (value.IsWrnType)
				IsWrnType = true;

			value.Parent = this;
			if (this.Count > 1)
			{
				LogSubRequest prevLogRow = GetItem(this.Count - 2);
				long ticks = value.StartDate.Subtract(prevLogRow.StartDate).Ticks;
				if (ticks > 0)
				{
					prevLogRow.TotalTime = new DateTime(ticks);
				}
			}

			if (value.IsRequestLastRow)
			{
				int milliseconds = int.Parse(s_totalTimeRegex.Match(value.Message).Value);

				m_totalTime = new DateTime(TimeSpan.TicksPerMillisecond * milliseconds);
			}

			//complete execution time for SQL logs
			if (Count > 1)
			{
				LogSubRequest prevLog = this.GetItem(this.Count - 2);
				if (prevLog.ContainsSQL && prevLog.DbTime == null)
				{
					//prevLog.DbTime = (int)value.StartDate.Subtract(prevLog.StartDate).TotalMilliseconds;
				}
			}
		}

		public bool Initialized
		{
			get { return m_initialized; }
		}
	}
}
