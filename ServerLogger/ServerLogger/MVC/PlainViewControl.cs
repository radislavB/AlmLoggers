using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LogComponents.MVC;
using LogComponents.FilterControl;

namespace ServerLogger.Mvc
{
	public partial class PlainViewControl : MvcControl
	{
		public PlainViewControl()
		{
			InitializeComponent();
		}

		public override void Initialize()
		{
			base.Initialize();

			SetColumns(m_filterGridControl.Columns);
			m_filterGridControl.ImageStatusDelegate = Utilities.GetWarnTypeImageDelegate;
			m_filterGridControl.BackColorDelegate = Utilities.BackColorDelegate;
			m_filterGridControl.Initialize(Options, Utilities.GetRequestFilterablePropertiesNames());

			m_txtMessage.Initialize((Options)Options, m_filterGridControl);
			((Options)Options).OnSaved += OnOptionsSaved;
		}

		public override int Order
		{
			get
			{
				return 20;
			}
		}

		public override string Caption
		{
			get
			{
				return "Plain view";
			}
		}

		protected override void OnMvcContextChanged()
		{
			base.OnMvcContextChanged();
			m_txtMessage.Text = null;
			m_filterGridControl.DataSource = ((LogRequestCollection)MvcContext).Logs;
		}

		private void SetColumns(DataGridViewColumnCollection columns)
		{
			DataGridViewColumn column;
			DataGridViewCellStyle style;
			//
			//Index 
			//
			column = new DataGridViewTextBoxColumn();
			columns.Add(column);
			column.DataPropertyName = "Id";
			column.HeaderText = "Id";
			column.Name = "plainClmRequestId";
			column.Width = 40;
			// 
			// clmRowIndex
			// 
			column = new DataGridViewTextBoxColumn();
			columns.Add(column);
			column.DataPropertyName = "ParentId";
			column.HeaderText = "RequestId";
			column.Name = "plainClmRequestId";
			column.Width = 70;
			//
			//Request
			//
			column = new DataGridViewTextBoxColumn();
			columns.Add(column);
			column.DataPropertyName = "Request";
			column.HeaderText = "Request";
			column.Name = "plainClmRequest";
			column.Width = 150;
			//
			//RequestType
			//
			column = new DataGridViewTextBoxColumn();
			columns.Add(column);
			column.DataPropertyName = "RequestType";
			column.HeaderText = "Type";
			column.Name = "plainClmRequestType";
			column.Width = 70;
			//
			// DB Start DateTime
			// 
			column = new DataGridViewTextBoxColumn();
			columns.Add(column);
			style = new DataGridViewCellStyle();
			style.Format = "MMM dd, HH:mm:ss.fff";
			column.DataPropertyName = "DbStartDate";
			column.DefaultCellStyle = style;
			column.HeaderText = "DB Start";
			column.Name = "plainClmDbStart";
			column.Width = 110;
			//
			// Start
			// 
			column = new DataGridViewTextBoxColumn();
			columns.Add(column);
			style = new DataGridViewCellStyle();
			style.Format = "MMM dd, HH:mm:ss.fff";
			column.DataPropertyName = "StartDate";
			column.DefaultCellStyle = style;
			column.HeaderText = "Start";
			column.Name = "plainClmStart";
			column.Width = 110;
			//
			//IP
			//
			column = new DataGridViewTextBoxColumn();
			columns.Add(column);
			column.DataPropertyName = "IP";
			column.HeaderText = "IP";
			column.Name = "plainClmIP";
			column.Width = 80;
			// 
			// clmConnectId
			// 
			column = new DataGridViewTextBoxColumn();
			columns.Add(column);
			column.DataPropertyName = "ConnectId";
			column.HeaderText = "ConnectId";
			column.Name = "plainClmConnectId";
			column.Width = 70;
			// 
			// clmLoginId
			// 
			column = new DataGridViewTextBoxColumn();
			columns.Add(column);
			column.DataPropertyName = "LoginId";
			column.HeaderText = "LoginId";
			column.Name = "plainClmLoginId";
			column.Width = 70;
			// 
			// clmCallId
			// 
			column = new DataGridViewTextBoxColumn();
			columns.Add(column);
			column.DataPropertyName = "CallId";
			column.HeaderText = "CallId";
			column.Name = "plainClmCallId";
			column.Width = 70;
			// 
			// clmUserName
			// 
			column = new DataGridViewTextBoxColumn();
			columns.Add(column);
			column.DataPropertyName = "User";
			column.HeaderText = "User";
			column.Name = "plainClmUserName";
			column.Width = 70;
			// 
			// clmThreadName
			// 
			column = new DataGridViewTextBoxColumn();
			columns.Add(column);
			column.DataPropertyName = "Thread";
			column.HeaderText = "Thread";
			column.Name = "plainClmThreadName";
			// 
			// clmType
			//
			column = new DataGridViewTextBoxColumn();
			columns.Add(column);
			column.DataPropertyName = "Type";
			column.HeaderText = "Type";
			column.Name = "plainClmType";
			column.Width = 40;
			// 
			// clmExecutionTime
			// 
			column = new DataGridViewTextBoxColumn();
			columns.Add(column);
			style = new DataGridViewCellStyle();
			style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			column.DataPropertyName = "DbTime";
			column.DefaultCellStyle = style;
			column.HeaderText = "DbTime(ms)";
			column.Name = "plainClmDbTime";
			column.Width = 80;
			// 
			// clmRowAffected
			// 
			column = new DataGridViewTextBoxColumn();
			columns.Add(column);
			style = new DataGridViewCellStyle();
			style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			column.DataPropertyName = "RowAffected";
			column.DefaultCellStyle = style;
			column.HeaderText = "Affected rows";
			column.Name = "plainClmRowAffected";
			// 
			// clmSchema
			// 
			column = new DataGridViewTextBoxColumn();
			columns.Add(column);
			column.DataPropertyName = "DbSchema";
			column.HeaderText = "DbSchema";
			column.Name = "plainClmSchema";
			// 
			// clmContainsSQL
			// 
			column = new DataGridViewTextBoxColumn();
			columns.Add(column);
			column.DataPropertyName = "ContainsSQL";
			column.HeaderText = "SQL";
			column.Name = "plainClmContainsSQL";
			column.Visible = false;
			// 
			// clmMethod
			// 
			column = new DataGridViewTextBoxColumn();
			columns.Add(column);
			column.DataPropertyName = "Method";
			column.HeaderText = "Method";
			column.Name = "plainClmMethod";
			column.Width = 350;
			// 
			// clmMessage
			// 
			column = new DataGridViewTextBoxColumn();
			columns.Add(column);
			column.DataPropertyName = "Message";
			column.HeaderText = "Message";
			column.Name = "plainClmMessage";
		}

		private void OnContextMenuOpening(object sender, CancelEventArgs e)
		{
			m_cmdGotoIdRequest.Enabled = (m_filterGridControl.DataSource != null && m_filterGridControl.DataSource.Count > 1);
			m_cmdClearFilterRequest.Enabled = (m_filterGridControl.DataSource != null && m_filterGridControl.DataSource.IsFiltered);

			DataGridViewCell cell = m_filterGridControl.ActiveCell;
			m_cmdFilterBy.Enabled = cell != null && cell.Value != null && m_filterGridControl.IsPropertyFilterable(cell.OwningColumn.DataPropertyName);
			if (m_cmdFilterBy.Enabled)
			{
				string value = cell.Value.ToString();

				if (value.Length > Utilities.MAX_LENGTH_FOR_FILTER_VALUE)
				{
					value = value.Substring(0, Utilities.MAX_LENGTH_FOR_FILTER_VALUE);
				}
				string filter = cell.OwningColumn.DataPropertyName + FilterConfig.KEY_VALUE_SEPARATOR + value;
				m_cmdFilterBy.Text = "Filter by ->" + filter;
				m_cmdFilterBy.Tag = filter;
			}
			else
			{
				m_cmdFilterBy.Text = "Filter by ...";
				m_cmdFilterBy.Tag = null;
			}
		}

		private void OnCmdFilterByClick(object sender, EventArgs e)
		{
			string temp = string.Empty;
			if (m_filterGridControl.Text.Length > 0)
			{
				temp = "; ";
			}

			string filter = (string)((ToolStripItem)sender).Tag;
			if (filter.Length > Utilities.MAX_LENGTH_FOR_FILTER_VALUE)
			{
				filter = filter.Substring(0, Utilities.MAX_LENGTH_FOR_FILTER_VALUE);
			}

			temp += filter;
			m_filterGridControl.Text += temp;
		}

		private void OnCmdClearFilterClick(object sender, EventArgs e)
		{
			m_filterGridControl.ClearFilter();
		}

		private void OnOptionsSaved(object sender, EventArgs e)
		{
			m_filterGridControl.Invalidate(true);
		}

		private void OnCmdCopyClick(object sender, EventArgs e)
		{
			DataObject dataObj = m_filterGridControl.GetClipboardContent();
			if (dataObj != null)
				Clipboard.SetDataObject(dataObj);
			else
				Clipboard.Clear();
		}
	}
}
