using System;
using System.Diagnostics;
using System.Text;
using LogComponents.FilterControl;
using System.Collections.Generic;

namespace ServerLogger
{
	public class LogSubRequest : ISupportWarnTypes, ISupportType, ISupportId, IComparable<LogSubRequest>
	{
		static IList<String> ERR_TYPE = new String[] { "ERR", "ERROR" };

		static IList<String> WRN_TYPE = new String[] { "WRN", "WARN" };

		#region private members

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		int m_index;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		int m_compareIndex;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		DateTime m_startDate;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		DateTime? m_dbStartDate;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		int? m_dbTime;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		DateTime m_totalTime;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		string m_rowAffected;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		string m_loginId;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		string m_connectId;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		string m_callId;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		string m_method;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		string m_userName;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		string m_message;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		string m_type;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		string m_request;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		string m_ip;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		string m_threadName;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		string m_dbSchema;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		bool m_containsSQL;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		bool m_isRequestLastRow;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		bool m_isRequestFirstRow;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		string m_source;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		LogRequest m_parent;

		#endregion

		public LogSubRequest()
		{
			m_dbSchema =
				m_threadName =
				m_request =
				m_type =
				m_message =
				m_userName =
				m_method =
				m_loginId =
				m_connectId =
				m_rowAffected = string.Empty;
		}

		public LogRequest Parent
		{
			get { return m_parent; }
			set { m_parent = value; }
		}

		public int? ParentId
		{
			get
			{
				if (m_parent == null)
					return null;

				return m_parent.Id;
			}
		}

		public bool ContainsSQL
		{
			get { return m_containsSQL && !IsErrType; }
			set { m_containsSQL = value; }
		}

		public string Thread
		{
			get { return m_threadName; }
			set { m_threadName = value; }
		}

		public string Request
		{
			get { return m_request; }
			set { m_request = value; }
		}

		public string IP
		{
			get { return m_ip; }
			set { m_ip = value; }
		}

		public string Type
		{
			get { return m_type; }
			set { m_type = value; }
		}

		public int Id
		{
			get { return m_index; }
			set { m_index = value; }
		}

		public DateTime StartDate
		{
			get { return m_startDate; }
			set { m_startDate = value; }
		}

		public DateTime? DbStartDate
		{
			get { return m_dbStartDate; }
			set { m_dbStartDate = value; }
		}

		public int? DbTime
		{
			get { return m_dbTime; }
			set { m_dbTime = value; }
		}

		public string RowAffected
		{
			get { return m_rowAffected; }
			set { m_rowAffected = value; }
		}

		public string LoginId
		{
			get { return m_loginId; }
			set { m_loginId = value; }
		}

		public string ConnectId
		{
			get { return m_connectId; }
			set { m_connectId = value; }
		}

		public string CallId
		{
			get { return m_callId; }
			set { m_callId = value; }
		}

		public string User
		{
			get { return m_userName; }
			set { m_userName = value; }
		}

		public string Method
		{
			get { return m_method; }
			set { m_method = value; }
		}

		public string Message
		{
			get { return m_message; }
			set
			{
				StringBuilder sb = new StringBuilder(value);
				sb.Replace("<br>", "\n");
				sb.Replace("&nbsp", string.Empty);
				sb.Replace("<p>", "\n");
				sb.Replace("&lt;", "<");
				sb.Replace("&gt;", ">");
				m_message = sb.ToString();
			}
		}

		public string DbSchema
		{
			get { return m_dbSchema; }
			set { m_dbSchema = value; }
		}

		public string Source
		{
			get { return m_source; }
			set { m_source = value; }
		}

		public bool IsErrType
		{
			get { return ERR_TYPE.Contains(m_type); }
		}

		public bool IsWrnType
		{
			get { return WRN_TYPE.Contains(m_type); }
		}

		public bool IsRequestLastRow
		{
			get { return m_isRequestLastRow; }
			set { m_isRequestLastRow = value; }
		}

		public bool IsRequestFirstRow
		{
			get { return m_isRequestFirstRow; }
			set { m_isRequestFirstRow = value; }
		}

		/// <summary>
		/// Used for comparison for multifile log
		/// </summary>
		public int CompareIndex
		{
			get { return m_compareIndex; }
			set { m_compareIndex = value; }
		}

		public int CompareTo(LogSubRequest other)
		{
			if (this.StartDate == other.StartDate)
				return m_compareIndex - other.m_compareIndex;


			return this.StartDate.CompareTo(other.StartDate);
		}

		public DateTime TotalTime
		{
			get
			{
				return m_totalTime;
			}
			set
			{
				m_totalTime = value;
			}
		}


		public string RequestType { get; set; }
	}
}
