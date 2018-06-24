using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Security.Permissions;

namespace WebGateLogger
{
  public class RefreshWatcher
  {

    private Timer m_timer;
    private static int WAIT_TIME = 2000;
    private string m_path;
    DateTime m_lastChangeDate;

    public RefreshWatcher(string path)
    {
      m_path = path;
      m_timer = new Timer(TimerCallbackMethod);
    }


    private void TimerCallbackMethod(object status)
    {
      DateTime currentLastChangeDate = GetLastChange();
      if (currentLastChangeDate > m_lastChangeDate)
      {
        m_lastChangeDate = currentLastChangeDate;

        if (Refreshed != null)
        {
          Refreshed(this, EventArgs.Empty);
        }
      }
    }


    private void PrepareMonitoring()
    {
      m_lastChangeDate = GetLastChange();
    }

    private DateTime GetLastChange()
    {
      DirectoryInfo dr = new DirectoryInfo(m_path);
      FileInfo[] fileInfos = dr.GetFiles();
      DateTime lastDate = new DateTime(0); 
      foreach (FileInfo fi in fileInfos)
      {
        if (fi.LastWriteTime > lastDate)
        {
          lastDate = fi.LastWriteTime;
        }
      }

      return lastDate;
    }



    public bool EnableRaisingEvents
    {
      set
      {
        if (value)
        {
          PrepareMonitoring();
          m_timer.Change(WAIT_TIME, WAIT_TIME);//start timer
        }
        else
        {
          m_timer.Change(Timeout.Infinite, 0);//stop timer;
        }
      }
    }

    public event EventHandler<EventArgs> Refreshed;


  }
}
