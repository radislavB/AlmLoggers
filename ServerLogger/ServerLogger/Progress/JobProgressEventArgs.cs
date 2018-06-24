using System;

namespace ServerLogger.Progress
{
  public class JobProgressEventArgs : EventArgs
  {
    public readonly int MainJobProgress;
    public readonly string MainJobCaption;
    public readonly int SecondaryJobProgress;
    public readonly string SecondaryJobCaption;

    public JobProgressEventArgs(string mainJobCaption, int mainJobProgress)
    {
      MainJobProgress = mainJobProgress;
      MainJobCaption = mainJobCaption;
      SecondaryJobProgress = -1;
      SecondaryJobCaption = null;
    }

    public JobProgressEventArgs(string mainJobCaption, int mainJobProgress,
       string secondaryJobCaption, int secondaryJobProgress)
    {
      MainJobProgress = mainJobProgress;
      MainJobCaption = mainJobCaption;
      SecondaryJobProgress = secondaryJobProgress;
      SecondaryJobCaption = secondaryJobCaption;
    }



  }
}
