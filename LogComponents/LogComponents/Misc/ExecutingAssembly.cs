using System;
using System.IO;
using System.Reflection;

namespace LogComponents
{
  public static class ExecutingAssembly
  {
    private static string s_executingDirectory;

    private static Assembly MainAssembly
    {
      get
      {
        return Assembly.GetEntryAssembly();
      }
    }

    public static Version Version
    {
      get
      {
        return MainAssembly.GetName().Version;
      }
    }

    public static string Description
    {
      get
      {
        // Get all Description attributes on this assembly
        object[] attributes = MainAssembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
        // If there aren't any Description attributes, return an empty string
        if (attributes.Length == 0)
          return "";
        // If there is a Description attribute, return its value
        return ((AssemblyDescriptionAttribute)attributes[0]).Description;
      }
    }

    public static string ProductName
    {
      get
      {
        // Get all Product attributes on this assembly
        object[] attributes = MainAssembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false);
        // If there aren't any Product attributes, return an empty string
        if (attributes.Length == 0)
          return "";
        // If there is a Product attribute, return its value
        return ((AssemblyProductAttribute)attributes[0]).Product;
      }
    }

    public static string Copyright
    {
      get
      {
        // Get all Copyright attributes on this assembly
        object[] attributes = MainAssembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
        // If there aren't any Copyright attributes, return an empty string
        if (attributes.Length == 0)
          return "";
        // If there is a Copyright attribute, return its value
        return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
      }
    }

    public static string Company
    {
      get
      {
        // Get all Company attributes on this assembly
        object[] attributes = MainAssembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
        // If there aren't any Company attributes, return an empty string
        if (attributes.Length == 0)
          return "";
        // If there is a Company attribute, return its value
        return ((AssemblyCompanyAttribute)attributes[0]).Company;
      }
    }

    public static string AssemblyName
    {
      get
      {
        return Path.GetFileNameWithoutExtension(Assembly.GetCallingAssembly().Location);
      }
    }

    public static string ExecutingDirectory
    {
      get
      {
        if (s_executingDirectory == null)
          s_executingDirectory = Path.GetDirectoryName(MainAssembly.Location) + "\\";
        return s_executingDirectory;
      }
    }
  }
}
