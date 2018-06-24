using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace WebGateLogger
{
  public class FrecCollectionEventArgs :EventArgs
  {
    public readonly FrecCollection Frecs;

    public FrecCollectionEventArgs(FrecCollection frecs)
    {
      Debug.Assert(frecs != null, "frecs!=null");
      Frecs = frecs;
    }
  }
}
