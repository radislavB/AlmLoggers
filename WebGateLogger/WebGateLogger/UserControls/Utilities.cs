using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Win32;
using System;

namespace WebGateLogger
{
  internal static class Utilities
  {
    public static string GetLastModifiedLogFile(string directory)
    {
      return GetLastModifiedFile(directory, Constants.LOG_FILE_FILTER, SearchOption.TopDirectoryOnly);
    }

    public static string GetLastModifiedFile(string directory, string searchPattern, SearchOption searchOption)
    {
      DirectoryInfo dInfo = new DirectoryInfo(directory);
      FileInfo[] fileInfos = dInfo.GetFiles(searchPattern, searchOption);
      if (fileInfos.Length == 0)
        return null;

      FileInfo lastModified;
      lastModified = fileInfos[0];
      for (int i = 1; i < fileInfos.Length; i++)
      {
        if (lastModified.LastWriteTime < fileInfos[i].LastWriteTime)
        {
          lastModified = fileInfos[i];
        }
      }

      return lastModified.FullName;
    }

    public static string GetWebLogFolder()
    {
      if (Environment.UserName == "Radislav")
        return @"C:\ProjectsC#\Limudim\Projects\WebGateLogger\logs";

      RegistryKey start = Registry.CurrentUser;
      string key = @"SOFTWARE\Mercury Interactive\TestDirector\WEB_CLNT_DEBUG";
      string node = "PATH";
      return GetRegistryValue(start, key, node);
    }

    public static string GetRegistryValue(RegistryKey start, string subKey, string node)
    {
      string value = null;
      RegistryKey registryKey = start.OpenSubKey(subKey);
      if (registryKey != null)
      {
        value = registryKey.GetValue(node) as string;
        registryKey.Close();
      }

      return value;
    }

    public static string GetContentFromFile(string fileName, out bool isLocked)
    {
      isLocked = false;
      if (!File.Exists(fileName))
        return null;

      string content = null;


      try
      {
        content = File.ReadAllText(fileName);
      }
      catch (IOException)
      {
        FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        StreamReader sr = new StreamReader(fs);
        content = sr.ReadToEnd();
        sr.Close();
        fs.Close();
        isLocked = true;
      }

      return content;
    }

    public static DialogResult ShowMessage(string message,MessageBoxButtons messageBoxButtons)
    {
      return MessageBox.Show(message, Product.Name, messageBoxButtons);
    }

    public static void ShowMessage(string message)
    {
      MessageBox.Show(message, Product.Name);
    }

    public static void ShowError(string message)
    {
      MessageBox.Show(message, "Error");
    }

    public static int DeleteOldFiles(string directory, string fileFilter, int dayThreshold)
    {
      if (dayThreshold < 0)
        throw new ArgumentException("DayThreshold can't be negatice number");

      if (!Directory.Exists(directory))
        return 0;

      int deleteCounter = 0;
      DirectoryInfo dirInfo = new DirectoryInfo(directory);
      FileInfo[] files = dirInfo.GetFiles(fileFilter);
      foreach (FileInfo fileInfo in files)
      {
        if(fileInfo.LastWriteTime.AddDays(dayThreshold)<DateTime.Now)
        {
          fileInfo.Delete();
          deleteCounter++;
        }
      }

      return deleteCounter;
    }
  }

  internal static class Product
  {
    public static string Title
    {
      get
      {
        // Get all Title attributes on this assembly
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
        // If there is at least one Title attribute
        if (attributes.Length > 0)
        {
          // Select the first one
          AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
          // If it is not an empty string, return it
          if (titleAttribute.Title != "")
            return titleAttribute.Title;
        }
        // If there was no Title attribute, or if the Title attribute was the empty string, return the .exe name
        return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
      }
    }

    public static string Version
    {
      get
      {
        return Assembly.GetExecutingAssembly().GetName().Version.ToString();
      }
    }

    public static string Description
    {
      get
      {
        // Get all Description attributes on this assembly
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
        // If there aren't any Description attributes, return an empty string
        if (attributes.Length == 0)
          return "";
        // If there is a Description attribute, return its value
        return ((AssemblyDescriptionAttribute)attributes[0]).Description;
      }
    }

    public static string Name
    {
      get
      {
        // Get all Product attributes on this assembly
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
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
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
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
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
        // If there aren't any Company attributes, return an empty string
        if (attributes.Length == 0)
          return "";
        // If there is a Company attribute, return its value
        return ((AssemblyCompanyAttribute)attributes[0]).Company;
      }
    }
  }

}
