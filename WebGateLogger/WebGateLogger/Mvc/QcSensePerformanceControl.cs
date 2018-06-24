using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LogComponents.MVC;
using System.IO;

namespace WebGateLogger.Mvc
{
  public partial class QcSensePerformanceControl : MvcControl
  {
    public QcSensePerformanceControl()
    {
      InitializeComponent();
    }

    public override string Caption
    {
      get
      {
        return "Qc sense data";
      }
    }

    public override int Order
    {
      get
      {
        return 30;
      }
    }

    protected override void OnMvcContextChanged()
    {
      dataGridView1.Rows.Clear();
      Frec frec = (Frec)MvcContext;
      if (frec == null)
      {
        return;
      }


      if (!string.IsNullOrEmpty(frec.ResponcePerformanceData))
      {
        DataSet ds = new DataSet();

        using (TextReader tr = new StringReader(frec.ResponcePerformanceData))
        {
          try
          {
            ds.ReadXml(tr);
            DataRow row = ds.Tables[0].Rows[0];
            foreach (DataColumn column in ds.Tables[0].Columns)
            {
              dataGridView1.Rows.Add(column.ColumnName, row[column]);
              dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
            }
          }
          catch (Exception e)
          {
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add("Error", e.Message);
          }
        }
      }
    }
  }
}
