using System;
using System.Threading;

namespace ServerLogger.Progress
{
  public abstract class JobBase
  {
    private ProgressForm m_progressForm;

    public event EventHandler<JobProgressEventArgs> JobProgress;
    public event EventHandler<EventArgs> JobFinished;
    protected bool m_cancel;
    private bool m_jobFailed;
    private string m_failMessage;



    protected void RaizeJobProgressEvent(JobProgressEventArgs e)
    {
      if (JobProgress != null)
        JobProgress(this, e);
    }

    protected void RaizeJobFinishedEvent(EventArgs e)
    {
      if (JobFinished != null)
        JobFinished(this, e);
    }

    protected void InitializeProgressForm(string caption, bool hasSecondaryJob)
    {
      m_progressForm = new ProgressForm();
      m_progressForm.Initialize(this);
    }

    public bool Cancel
    {
      get { return m_cancel; }
    }

    public bool JobFailed
    {
      get { return m_jobFailed; }
    }

    public string FailMessage
    {
      get { return m_failMessage; }
    }

    protected virtual void OnBeforeStart()
    {
    }

    protected virtual void OnBeforeStop()
    {
    }

    public void Start()
    {
      OnBeforeStart();
      m_cancel = false;
      m_jobFailed = false;
      m_failMessage = string.Empty;

      Thread thread = new Thread(ThreadStart);
      thread.IsBackground = true;
      thread.Start();
      m_progressForm.ShowDialog();
    }

    public void Stop()
    {
      OnBeforeStop();
      m_cancel = true;
    }

    public bool IsCanceled
    {
      get
      {
        return m_cancel;
      }
    }

    private void ThreadStart()
    {
      try
      {
        ThreadJob();
      }
      catch (Exception e)
      {
        m_jobFailed = true;
        m_failMessage = e.Message;
      }

      RaizeJobFinishedEvent(new EventArgs());
    }

    protected abstract void ThreadJob();

  }
}
