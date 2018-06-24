using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Xml;

namespace LogComponents
{
  public static class Helpers
  {
    public static class RegistryUtilities
    {
      public static bool IsKeyExist(RegistryKey start, string subKey)
      {
        RegistryKey registryKey = start.OpenSubKey(subKey);
        return (registryKey != null);
      }

      public static void CreateKey(RegistryKey start, string subKey)
      {
        RegistryKey key = start.CreateSubKey(subKey);
        Debug.Assert(key != null);
      }

      public static T GetValue<T>(RegistryKey start, string subKey, string node)
      {
        T value = default(T);
        RegistryKey registryKey = start.OpenSubKey(subKey);
        if (registryKey != null)
        {
          object obj = registryKey.GetValue(node);
          if (obj != null)
          {
            value = (T)obj;

          }

          registryKey.Close();
        }

        return value;
      }

      public static void DeleteNode(RegistryKey start, string subKey, string node)
      {
        RegistryKey registryKey = start.OpenSubKey(subKey, true);
        if (registryKey != null)
        {
          registryKey.DeleteValue(node, false);
          registryKey.Close();
        }
      }

      public static void SetValue<T>(RegistryKey start, string subKey, string node, T value)
      {
        RegistryKey registryKey = start.OpenSubKey(subKey, true);
        if (registryKey == null)
        {
          registryKey.OpenSubKey(node);
        }

        registryKey.SetValue(node, value);
        registryKey.Close();
      }


      const string DEFAULT_VALUE_KEY = "";
      const string SHELL_COMMAND_FORMAT = "shell\\{0}\\command";

      /// <summary>
      /// 
      /// </summary>
      /// <param name="extension">Extension of the file (.zip, .txt etc.) to be executed with command</param>
      /// <param name="menuName">Name for the menu item (Play, Open etc.)</param>
      /// <param name="menuDescription">The actual text that will be shown</param>
      /// <param name="menuCommand">Path to executable</param>
      public static void AddContextMenuItem(string extension, string menuName, string description,
        string executablePath)
      {
        //Extension key handling
        string extString = GetExtensionDescription(extension);

        //program key handling
        RegistryKey programKey = Registry.ClassesRoot.CreateSubKey(extString);
        string str = string.Format(SHELL_COMMAND_FORMAT, menuName);
        RegistryKey subKey = programKey.CreateSubKey(str);

        string command = executablePath + " %1";
        subKey.SetValue(DEFAULT_VALUE_KEY, command);
        subKey.Close();

        str = string.Format("shell\\{0}", menuName);
        subKey = programKey.OpenSubKey(str, true);
        subKey.SetValue(DEFAULT_VALUE_KEY, description);
        subKey.Close();

        programKey.Close();
      }

      public static void RemoveFromContextMenuItem(string extension, string menuName)
      {
        //Extension key handling
        string extString = GetExtensionDescription(extension);

        //program key handling
        RegistryKey regKey = Registry.ClassesRoot.OpenSubKey(extString);
        regKey = regKey.OpenSubKey("shell", true);
        if (regKey.OpenSubKey(menuName) != null)
        {
          regKey.DeleteSubKeyTree(menuName);
        }
        regKey.Close();
      }

      public static bool IsExistInContextMenu(string extension, string menuName, string executablePath)
      {
        string extString = GetExtensionDescription(extension);
        RegistryKey programKey = Registry.ClassesRoot.OpenSubKey(extString);
        if (programKey != null)
        {
          string str = string.Format(SHELL_COMMAND_FORMAT, menuName);
          RegistryKey subKey = programKey.OpenSubKey(str);
          if (subKey != null)
          {
            string command = executablePath + " %1";
            object value = subKey.GetValue(DEFAULT_VALUE_KEY, command);
            return command.Equals(value);
          }
        }

        return false;
      }

      private static string GetExtensionDescription(string extension)
      {
        RegistryKey extKey = Registry.ClassesRoot.CreateSubKey(extension);
        string extDesc = extKey.GetValue(DEFAULT_VALUE_KEY) as string;
        if (string.IsNullOrEmpty(extDesc))
        {
          //setting from .ext=>extfile
          extDesc = extension.Substring(1) + "file";
          extKey.SetValue(DEFAULT_VALUE_KEY, extDesc);
        }
        extKey.Close();
        return extDesc;
      }

    }

    public static class IOUtilities
    {
      public static IList<Char> GetIllegalCharacters(string text)
      {
        IList<char> chars = new List<char>();
        foreach (char character in text)
        {
          if (!XmlConvert.IsXmlChar(character))
          {
            //11 - \v
            //25 - EM - End of Medium
            //28 - FS – File separator 
            //29 – GS – Group separator
            //30 – RS – Record separator
            //31 – US – Unit separator
            if (character == 11 || character == 25 || (character >= 28 && character <= 31))
            {
              continue;
            }
            chars.Add(character);
          }
        }
        return chars;
      }

      public static int DeleteOldFiles(string directory, IList<string> filters, int dayThreshold)
      {
        if (dayThreshold < 0)
          throw new ArgumentException("DayThreshold can't be negatice number");

        if (!Directory.Exists(directory))
          return 0;

        int deleteCounter = 0;

        IList<FileInfo> files = Helpers.IOUtilities.GetFileInfos(directory, filters, SearchOption.TopDirectoryOnly, 0);
        DateTime thresholdDate = DateTime.Now.Date.AddDays(-dayThreshold);
        foreach (FileInfo fileInfo in files)
        {
          if (fileInfo.LastWriteTime < thresholdDate)
          {
            fileInfo.Delete();
            deleteCounter++;
          }
        }

        return deleteCounter;
      }

      public static string GetPathToQuickToolbar()
      {
        string quickToolbar = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        quickToolbar += @"\Microsoft\Internet Explorer\Quick Launch";
        return quickToolbar;
      }

      public static string GetPathToDesktop()
      {
        return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
      }

      public static string GetPathToApplicationRepository()
      {
        string parentFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        string path = parentFolder + Path.AltDirectorySeparatorChar + ExecutingAssembly.ProductName;
        if (!Directory.Exists(path))
        {
          Directory.CreateDirectory(path);
        }

        return path;
      }

      public static void LogException(Exception e)
      {
        string exeptionFileName = GetPathToApplicationRepository() + Path.AltDirectorySeparatorChar + "Exceptions.txt";
        FileStream fs = null;
        StreamWriter sw = null;

        try
        {
          fs = new FileStream(exeptionFileName, FileMode.Append, FileAccess.Write);
          sw = new StreamWriter(fs);

          sw.Write("Product         : ");
          sw.Write(ExecutingAssembly.ProductName);
          sw.Write(", ");
          sw.WriteLine(ExecutingAssembly.Version);

          sw.Write("Time            : ");
          sw.WriteLine(DateTime.Now);

          sw.Write("Message         : ");
          sw.WriteLine(e.Message);

          sw.Write("Exception type  : ");
          sw.WriteLine(e.GetType().Name);

          sw.Write("Inner exception : ");
          sw.WriteLine(e.InnerException);

          sw.WriteLine("Stack trace     : ");
          sw.WriteLine(e.StackTrace);

          sw.WriteLine();
          sw.WriteLine("============================================================================================================");
          sw.WriteLine();
          sw.WriteLine();
        }

        catch
        {
        }
        finally
        {
          if (sw != null)
          {
            sw.Flush();
            sw.Close();
          }

          if (fs != null)
          {
            fs.Close();
          }
        }
      }

      public static IList<string> GetLinesFromFile(string fileName, out bool isLocked)
      {
        isLocked = false;
        IList<string> lines = null;


        try
        {
          lines = File.ReadAllLines(fileName);
        }
        catch (IOException)
        {
          lines = new List<string>();
          FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, GetSharingState(fileName));
          StreamReader sr = new StreamReader(fs);
          while (!sr.EndOfStream)
          {
            lines.Add(sr.ReadLine());
          }

          sr.Close();
          fs.Close();
          isLocked = true;
        }

        return lines;
      }

      public static string GetContentFromFile(string fileName, out bool isLocked)
      {
        isLocked = false;
        string content = null;
        FileStream fs = null;
        StreamReader sr = null;

        try
        {
          content = File.ReadAllText(fileName);
        }
        catch (IOException)
        {
          FileShare fileShareState = GetSharingState(fileName);
          fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, fileShareState);
          sr = new StreamReader(fs);
          content = sr.ReadToEnd();
          isLocked = true;
        }
        finally
        {
          if (sr != null)
          {
            sr.Close();
          }
          if (fs != null)
          {
            fs.Close();
          }
        }


        return content;
      }

      public static IList<FileInfo> GetFileInfos(string directory, IList<string> searchPatterns, SearchOption searchOption, int minSize)
      {
        string EXCLUDE_INDICATOR = "!";
        DirectoryInfo dInfo = new DirectoryInfo(directory);
        IList<FileInfo> fileInfos = new List<FileInfo>();
        IList<string> excludeFilters = new List<string>();
        IList<string> includeFilters = new List<string>();
        foreach (string searchPattern in searchPatterns)
        {
          if (searchPattern.StartsWith(EXCLUDE_INDICATOR))
          {
            excludeFilters.Add(searchPattern.Substring(EXCLUDE_INDICATOR.Length));
          }
          else
          {
            includeFilters.Add(searchPattern);
          }
        }

        //check if need to add "All files" filter
        if (includeFilters.Count == 0 && excludeFilters.Count > 0)
        {
          includeFilters.Add("*.*");
        }

        foreach (string includePattern in includeFilters)
        {
          FileInfo[] tempFileInfos = dInfo.GetFiles(includePattern, searchOption);
          foreach (FileInfo fileInfo in tempFileInfos)
          {
            bool isExcluded = false;
            if (fileInfo.Length >= minSize)
            {
              foreach (string excludePattern in excludeFilters)
              {
                if (fileInfo.Name.Contains(excludePattern))
                {
                  isExcluded = true;
                  break;
                }
              }

              if (!isExcluded)
              {
                fileInfos.Add(fileInfo);
              }
            }
          }

        }

        return fileInfos;
      }

      public static IList<string> GetFileNames(string directory, IList<string> searchPatterns, SearchOption searchOption)
      {
        DirectoryInfo dInfo = new DirectoryInfo(directory);
        List<string> fileNames = new List<string>();
        foreach (string pattern in searchPatterns)
        {
          string[] tempFileNames = Directory.GetFiles(directory, pattern, searchOption);
          fileNames.AddRange(tempFileNames);

        }
        return fileNames;
      }

      public static string GetLastModifiedFile(string directory, IList<string> searchPatterns, int minSize)
      {
        IList<FileInfo> fileInfos = GetFileInfos(directory, searchPatterns, SearchOption.TopDirectoryOnly, minSize);

        FileInfo lastModified = null;

        for (int i = 0; i < fileInfos.Count; i++)
        {
          if (fileInfos[i].Length < minSize)
            continue;

          if (lastModified == null || lastModified.LastWriteTime < fileInfos[i].LastWriteTime)
          {
            lastModified = fileInfos[i];
          }
        }

        if (lastModified == null)
        {
          return null;
        }
        return lastModified.FullName;
      }

      public static void GetPrevNextFiles(string currentFile, IList<string> patterns, int minSize, out string prevFile, out string nextFile)
      {
        prevFile = nextFile = null;

        //find current
        DirectoryInfo di = new DirectoryInfo(Path.GetDirectoryName(currentFile));
        FileInfo current = (di.GetFiles(Path.GetFileName(currentFile)))[0];
        if (current == null)
        {
          return;
        }

        //get additional files
        IList<FileInfo> fileInfos = GetFileInfos(Path.GetDirectoryName(currentFile), patterns, SearchOption.TopDirectoryOnly, minSize);
        if (fileInfos.Count <= 1)
        {
          return;
        }

        //init prev, next
        FileInfo prev = null;
        FileInfo next = null;
        FileInfo temp;


        //find prev, next
        for (int i = 0; i < fileInfos.Count; i++)
        {
          temp = fileInfos[i];
          if (temp.Name == current.Name)
            continue;

          if (temp.Length < minSize)
            continue;

          if ((prev == null && temp.LastWriteTime < current.LastWriteTime) ||
          (prev != null && prev.LastWriteTime < temp.LastWriteTime && temp.LastWriteTime < current.LastWriteTime))
          {
            prev = temp;
            continue;
          }

          if ((next == null && current.LastWriteTime < temp.LastWriteTime) ||
            (next != null && current.LastWriteTime < temp.LastWriteTime && temp.LastWriteTime < next.LastWriteTime))
          {
            next = temp;
            continue;
          }
        }

        if (prev != null)
          prevFile = prev.FullName;

        if (next != null)
          nextFile = next.FullName;
      }

      static FileShare[] FileShareStates = new FileShare[] { FileShare.Write, FileShare.ReadWrite, FileShare.Read, FileShare.None };

      public static FileShare GetSharingState(string fileName)
      {

        foreach (FileShare state in FileShareStates)
        {
          if (TryOpenFile(state, fileName))
          {
            return state;
          }
        }

        return FileShare.None;
      }

      private static bool TryOpenFile(FileShare fileShare, string fileName)
      {
        FileStream fs = null;
        try
        {
          fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, fileShare);
          return true;
        }
        catch
        {
          return false;
        }
        finally
        {
          if (fs != null)
            fs.Close();
        }
      }

      public static bool IsDirectory(string path)
      {
        return Directory.Exists(path);
      }

      public static void OpenFile(string fileName)
      {
        if (File.Exists(fileName))
        {
          Process.Start(fileName);
        }
        else
        {
          Helpers.FormUtilities.ShowMessage(string.Format("File <{0}> is not found.", fileName));
        }
      }


      static string[] SIZE_NAMES = new[] { "bytes", "KB", "MB", "GB" };
      static double KB = 1024;
      public static string GetShortFileSize(int bytes)
      {
        double prevSize = bytes;
        double size = bytes;
        int index = 0;
        for (index = 0; index < SIZE_NAMES.Length && size > 0.9; index++)
        {
          prevSize = size;
          size = size / KB;
        }

        size = prevSize;
        return size.ToString("N1") + " " + SIZE_NAMES[index - 1];

      }
    }

    public static class ProcessUtilities
    {
      public static bool IsSingleProcess()
      {
        Process[] processes = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
        return (processes.Length == 1);
      }

      public static bool IsRunOnLocalPath()
      {

        string str = Assembly.GetExecutingAssembly().Location;
        if (str.StartsWith("\\"))
        {
          FormUtilities.ShowMessage(@"Application cannot run on network. Take it to local machine (for example c:/)");
          return false;
        }
        return true;

      }

    }

    public static class FormUtilities
    {
      public static DialogResult ShowMessage(string message, MessageBoxButtons messageBoxButtons)
      {
        return MessageBox.Show(message, ExecutingAssembly.ProductName, messageBoxButtons);
      }

      public static void ShowMessage(string message)
      {
        MessageBox.Show(message, ExecutingAssembly.ProductName);
      }

      public static void ShowException(Exception e)
      {
        IOUtilities.LogException(e);
        MessageBox.Show(e.Message, ExecutingAssembly.ProductName);
      }

      public static void RegisterRecursiveDragDropEvent(Control control, DragEventHandler dragDropHandler, DragEventHandler dragEnterHandler)
      {
        if (control is WebBrowser)
        {
          //drop on web browser just load file in webbrowser
          ((WebBrowser)control).AllowWebBrowserDrop = false;
        }
        else
        {
          control.AllowDrop = true;
        }

        control.DragDrop += dragDropHandler;
        control.DragEnter += dragEnterHandler;

        foreach (Control subControl in control.Controls)
        {
          RegisterRecursiveDragDropEvent(subControl, dragDropHandler, dragEnterHandler);
        }
      }

      public static void RegisterRecursiveKeyDownEvent(Control control, KeyEventHandler keyDownEventHandler)
      {
        control.KeyDown += keyDownEventHandler;

        foreach (Control subControl in control.Controls)
        {
          RegisterRecursiveKeyDownEvent(subControl, keyDownEventHandler);
        }
      }
    }

    public static class FrecUtilities
    {
      private static string GET_VALUE_FORMAT = @"\b{0}:(?<VALUE>[\w\.]+)\b";

      public static string GetValue(string source, string key)
      {
        string pattern = string.Format(GET_VALUE_FORMAT, key);
        Match match = Regex.Match(source, pattern);
        if (match.Success)
        {
          return match.Groups[1].Value;
        }
        return null;
      }

      public static int GetValueAsInt(string source, string key)
      {
        string value = GetValue(source, key);
        return int.Parse(value);
      }

    }

    public static class ShortcutUtilities
    {
      private static string ExtractSubPart(string fullString, string prefix, string endWith)
      {
        string regexStr = string.Format("(?<VALUE>{0}.*?){1}", prefix, endWith);
        Match match = Regex.Match(fullString, regexStr);
        if (match.Success)
        {
          return match.Groups["VALUE"].Value;
        }
        else
        {
          return string.Empty;
        }
      }
      private static string GetShortcutValueForClickOnce()
      {
        ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
        string splitter = ", ";
        string fullString = ad.UpdatedApplicationFullName;
        string file = ExtractSubPart(fullString, "file", splitter);
        string culture = "Culture=neutral";
        string publicKeyToken = ExtractSubPart(fullString, "PublicKeyToken", splitter);
        string processorArchitecture = "processorArchitecture=msil";
        string shortcutValue = string.Format("{1}{0}{2}{0}{3}{0}{4}", splitter, file, culture, publicKeyToken, processorArchitecture);
        return shortcutValue;
      }
      private static bool IsClickOnceDeployment()
      {
        return ApplicationDeployment.IsNetworkDeployed;
      }

      public static void CreateShortcut(string directory)
      {
        string fileName = Application.ProductName;
        if (IsClickOnceDeployment())
        {
          string shortcutValue = GetShortcutValueForClickOnce();
          string fileExtension = "appref-ms";
          string fullPath = string.Format("{0}{1}{2}.{3}", directory, Path.DirectorySeparatorChar, fileName, fileExtension);
          System.IO.File.WriteAllText(fullPath, shortcutValue, Encoding.Unicode);
        }
        else
        {

          MessageBox.Show("You can create shortcut only after installation of click once");
        }
      }
    }
  }
}
