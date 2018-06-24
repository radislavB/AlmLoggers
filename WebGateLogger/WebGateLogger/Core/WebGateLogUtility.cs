using System.IO;
using LogComponents;
using Microsoft.Win32;

namespace WebGateLogger
{
  public static class WebGateLogUtility
  {
    private static string REGISTRY_KEY = @"SOFTWARE\Mercury Interactive\TestDirector\WEB_CLNT_DEBUG";
    private static string REGISTRY_PATH_NODE = "PATH";
    private static string REGISTRY_MASK_NODE = "MASK";
    private static string REGISTRY_MAX_LINES_NODE = "MAX_LINES";

    private static string REGISTRY_VALUE_ALL = "ALL";
    private static string REGISTRY_VALUE_NONE = "NONE";

    private static RegistryKey REGISTRY_START;

    static WebGateLogUtility()
    {

      REGISTRY_START = Registry.CurrentUser;
      if (!Helpers.RegistryUtilities.IsKeyExist(REGISTRY_START, REGISTRY_KEY))
      {
        Helpers.RegistryUtilities.CreateKey(REGISTRY_START, REGISTRY_KEY);

        Helpers.RegistryUtilities.SetValue(REGISTRY_START, REGISTRY_KEY, "DEBUG", REGISTRY_VALUE_ALL);
        Helpers.RegistryUtilities.SetValue(REGISTRY_START, REGISTRY_KEY, REGISTRY_MASK_NODE, REGISTRY_VALUE_NONE);
        Helpers.RegistryUtilities.SetValue(REGISTRY_START, REGISTRY_KEY, REGISTRY_MAX_LINES_NODE, 10000);
        Helpers.RegistryUtilities.SetValue(REGISTRY_START, REGISTRY_KEY, REGISTRY_PATH_NODE, @"c:\WebGateLogs");
        Helpers.RegistryUtilities.SetValue(REGISTRY_START, REGISTRY_KEY, "STYLE", "HTML");
      }
    }

    public static string LogPath
    {
      get
      {
        return Helpers.RegistryUtilities.GetValue<string>(REGISTRY_START, REGISTRY_KEY, REGISTRY_PATH_NODE);
      }
      set
      {
        if (!Directory.Exists(value))
        {
          Directory.CreateDirectory(value);
        }
        Helpers.RegistryUtilities.SetValue(REGISTRY_START, REGISTRY_KEY, REGISTRY_PATH_NODE, value);
      }
    }

    public static int MaxLines
    {
      get
      {
        int lines = Helpers.RegistryUtilities.GetValue<int>(REGISTRY_START, REGISTRY_KEY, REGISTRY_MAX_LINES_NODE);

        return lines;
      }
      set
      {
        if (value == 0)
        {
          Helpers.RegistryUtilities.DeleteNode(REGISTRY_START, REGISTRY_KEY, REGISTRY_MAX_LINES_NODE);
        }
        else
        {
          Helpers.RegistryUtilities.SetValue(REGISTRY_START, REGISTRY_KEY, REGISTRY_MAX_LINES_NODE, value);
        }
      }
    }

    public static bool IsActivated
    {
      get
      {
        string mask = Helpers.RegistryUtilities.GetValue<string>(REGISTRY_START, REGISTRY_KEY, REGISTRY_MASK_NODE);
        return REGISTRY_VALUE_ALL == mask;
      }
      set
      {
        string mask = value ? REGISTRY_VALUE_ALL : REGISTRY_VALUE_NONE;
        Helpers.RegistryUtilities.SetValue(REGISTRY_START, REGISTRY_KEY, REGISTRY_MASK_NODE, mask);
      }
    }
  }
}
