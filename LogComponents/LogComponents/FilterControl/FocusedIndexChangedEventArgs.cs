using System;
using System.Collections.Generic;
using System.Text;

namespace LogComponents.FilterControl
{
  public class FocusedIndexChangedEventArgs : EventArgs
  {
    public readonly int FocusedIndex;

    public FocusedIndexChangedEventArgs(int focusedIndex)
    {
      FocusedIndex = focusedIndex;
    }
  }
}
