using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using LogComponents;
using System.IO;

namespace WebGateLogger
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
        Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.ThreadException += OnThreadException;
        AppDomain.CurrentDomain.UnhandledException += OnDomainException;
        Application.Run(new MainForm());
      }
      catch (Exception e)//exception on loading and not handled by Application.ThreadException
      {
        MessageBox.Show(e.Message, Application.ProductName);
      }
    }

    static void OnException(Exception e)
    {
      DialogResult dr = DialogResult.None;
      try
      {
        string message = e.Message + Environment.NewLine + "Do you want to continue?";
        dr = MessageBox.Show(message, Application.ProductName, MessageBoxButtons.YesNo);
        Helpers.IOUtilities.LogException(e);

      }
      catch
      {
      }
      finally
      {
        if (dr != DialogResult.Yes)
        {
          Application.Exit();
        }
      }
    }

    static void OnThreadException(object sender, ThreadExceptionEventArgs e)
    {
      OnException(e.Exception);
    }

    static void OnDomainException(object sender, UnhandledExceptionEventArgs e)
    {
      Exception ex = e.ExceptionObject as Exception;
      if (ex != null)
      {
        OnException(ex);
      }
    }
  }
}
