using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LogComponents.FilterControl;

namespace ServerLogger
{
  public partial class PlainView : Form
  {
    public PlainView()
    {
      InitializeComponent();
      SetColumns(m_filterGridControl.Columns);
    }

    public FilterableBindingList<LogSubRequest> DataSource
    {
      set
      {
        m_filterGridControl.DataSource = value;
      }
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
      column.Width = 50;
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
      // clmMethod
      // 
      column = new DataGridViewTextBoxColumn();
      columns.Add(column);
      column.DataPropertyName = "Method";
      column.HeaderText = "Method";
      column.Name = "plainClmMethod";
      column.Width = 350;
      // 
      // clmSchema
      // 
      column = new DataGridViewTextBoxColumn();
      columns.Add(column);
      column.DataPropertyName = "DbSchema";
      column.HeaderText = "DbSchema";
      column.Name = "plainClmSchema";
      // 
      // clmMessage
      // 
      column = new DataGridViewTextBoxColumn();
      columns.Add(column);
      column.DataPropertyName = "Message";
      column.HeaderText = "Message";
      column.Name = "plainClmMessage";
    }
  }
}
