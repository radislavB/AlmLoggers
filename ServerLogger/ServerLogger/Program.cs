using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using LogComponents;

namespace ServerLogger
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      try
      {

        Thread.CurrentThread.CurrentCulture =
          Thread.CurrentThread.CurrentUICulture =
          new CultureInfo("en-US");

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.ThreadException += OnApplicationThreadException;
        Application.Run(new MainForm());
      }
      catch (Exception e)//exception on loading and not handled by Application.ThreadException
      {
        MessageBox.Show(e.Message, Application.ProductName);
      }
    }

    static void OnApplicationThreadException(object sender, ThreadExceptionEventArgs e)
    {
      Helpers.FormUtilities.ShowException(e.Exception);
    }

  }
}