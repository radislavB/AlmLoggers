using System;
using System.Collections.Generic;
using System.Text;

namespace WebGateLogger
{
  public class BaseBookmark
  {
    private string m_title;

    public string Title
    {
      get { return m_title; }
      set { m_title = value; }
    }
    private string m_bookmark;

    public string Bookmark
    {
      get { return m_bookmark; }
      set { m_bookmark = value; }
    }

    private bool m_isInjected;

    public bool IsInjected
    {
      get { return m_isInjected; }
      set { m_isInjected = value; }
    }

    public override string ToString()
    {
      return m_title + ", " + m_bookmark;
    }

  }
}
