using System;
using System.Collections.Generic;
using System.Text;

namespace LogComponents
{
  /// <summary>
  /// This attribute says that value of the option is overrided by default value if option file is ccreated before supplied version 
  /// </summary>
  public class OverrideValueFromVersionAttribute : Attribute
  {
    Version m_version;

    public Version Version
    {
      get { return m_version; }
      private set { m_version = value; }
    }

    public OverrideValueFromVersionAttribute(string versionString)
    {
      Version = new Version(versionString);
    }
  }
}
