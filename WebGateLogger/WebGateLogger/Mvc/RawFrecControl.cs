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
  public partial class RawFrecControl : MvcControl
  {
    public RawFrecControl()
    {
      InitializeComponent();
      
    }

    public override void Initialize()
    {
      webBrowser1.DocumentText = "";
    }

    public override string Caption
    {
      get
      {
        return "Raw frec";
      }
    }

    public override int Order
    {
      get
      {
        return 20;
      }
    }

    protected override void OnMvcContextChanged()
    {
      Frec frec = (Frec)MvcContext;

      if (frec != null)
      {
        //in this way we "disable" click sound
        string content = frec.GetRawFrec();
        webBrowser1.Document.OpenNew(true);
        webBrowser1.Document.Write(content);
      }
      else
      {
        //if no frec the only way to clear browser
        //is to use this way ,though it do "Click" sound
        webBrowser1.DocumentText = "";
      }
    }
  }
}
