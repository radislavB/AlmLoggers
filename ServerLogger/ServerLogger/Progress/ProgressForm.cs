using System;
using System.Windows.Forms;

namespace ServerLogger.Progress
{
  public partial class ProgressForm : Form
  {
    EventHandler<JobProgressEventArgs> m_jobProgressDelegate;
    EventHandler<EventArgs> m_jobFinishedDelegate;
    JobBase m_job;
    DateTime m_startTime;

    public ProgressForm()
    {
      InitializeComponent();

    }

    public void Initialize(JobBase job)
    {
      m_jobProgressDelegate = new EventHandler<JobProgressEventArgs>(OnJobProgress);
      m_jobFinishedDelegate = new EventHandler<EventArgs>(OnJobFinished);
      m_job = job;
      job.JobProgress += m_jobProgressDelegate;
      job.JobFinished += m_jobFinishedDelegate;
    }

    private void OnJobFinished(object sender, EventArgs e)
    {
      if (InvokeRequired)
      {
        Invoke(m_jobFinishedDelegate, sender, e);
        return;
      }
      JobBase job = (JobBase)sender;
      job.JobProgress -= m_jobProgressDelegate;
      job.JobFinished -= OnJobFinished;
      this.Close();
    }

    private void OnJobProgress(object sender, JobProgressEventArgs e)
    {
      if (InvokeRequired)
      {
        Invoke(m_jobProgressDelegate, sender, e);
        return;
      }

      if (!string.IsNullOrEmpty(e.MainJobCaption))
        lblMainJob.Text = e.MainJobCaption;

      if (e.MainJobProgress != -1)
        progMainJob.Value = e.MainJobProgress;

      if (!string.IsNullOrEmpty(e.SecondaryJobCaption))
        lblSecondaryJob.Text = e.SecondaryJobCaption;

      if (e.SecondaryJobProgress != -1)
        progSecondaryJob.Value = e.SecondaryJobProgress;
    }

    private void OnCancelLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      m_job.Stop();
    }

    private void OnShown(object sender, EventArgs e)
    {
      m_startTime = DateTime.Now;
      timer1.Start();

    }

    private void OnTimerTick(object sender, EventArgs e)
    {
      this.Text = string.Format("Progress ... ({0})", DateTime.Now.Subtract(m_startTime).ToString().Substring(0, 8));
    }

    private void OnClosing(object sender, FormClosingEventArgs e)
    {
      timer1.Stop();
    }

  }
}
