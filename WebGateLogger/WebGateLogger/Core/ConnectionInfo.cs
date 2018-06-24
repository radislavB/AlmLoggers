using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.ComponentModel;

namespace WebGateLogger
{
  public class ConnectionInfo
  {
    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    private static string NOT_AVAILABLE = "Not  available";

    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    private string m_qcVersion = NOT_AVAILABLE;
    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    private string m_domain = NOT_AVAILABLE;
    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    private string m_project = NOT_AVAILABLE;
    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    private string m_user = NOT_AVAILABLE;
    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    private string m_server = NOT_AVAILABLE;
    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    private string m_connectionURL = NOT_AVAILABLE;
    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    private string m_vcs = NOT_AVAILABLE;
    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    private string m_filePath;
    [DebuggerBrowsableAttribute(DebuggerBrowsableState.Never)]
    private string m_fileSize;

    [Category("3.File")]
    [ReadOnly(true)]
    [DisplayName("File path")]
    public string FilePath
    {
      get { return m_filePath; }
      set { m_filePath = value; }
    }

    [Category("3.File")]
    [ReadOnly(true)]
    [DisplayName("File size")]
    public string FileSize
    {
      get { return m_fileSize; }
      set { m_fileSize = value; }
    }


    [Category("1.Server")]
    [ReadOnly(true)]
    public string QcVersion
    {
      get { return m_qcVersion; }
      set { m_qcVersion = value; }
    }

    [Category("1.Server")]
    [ReadOnly(true)]
    public string ConnectionURL
    {
      get { return m_connectionURL; }
      set { m_connectionURL = value; }
    }

    [Category("1.Server")]
    [ReadOnly(true)]
    public string Server
    {
      get { return m_server; }
      set { m_server = value; }
    }

    [Category("2.Project")]
    [ReadOnly(true)]
    public string Domain
    {
      get { return m_domain; }
      set { m_domain = value; }
    }

    [Category("2.Project")]
    [ReadOnly(true)]
    public string Project
    {
      get { return m_project; }
      set { m_project = value; }
    }

    [Category("2.Project")]
    [ReadOnly(true)]
    public string User
    {
      get { return m_user; }
      set { m_user = value; }
    }

    [Category("2.Project")]
    [ReadOnly(true)]
    [DisplayName("Version Control")]
    public string Vcs
    {
      get { return m_vcs; }
      set { m_vcs = value; }
    }

    public bool IsProjectDataAvailable()
    {
      return m_project != NOT_AVAILABLE;
    }

    public override string ToString()
    {
      if (!IsProjectDataAvailable())
      {
        return "Project data isn't available";
      }

      return string.Format("User: {0} ; Domain: {1} ; Project: {2} ; URL: {3} ", User, Domain, Project, ConnectionURL);
    }
  }
}
