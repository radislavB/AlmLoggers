
namespace WebGateLogger
{
  public static class Constants
  {
    public static string[] LOG_FILE_FILTER = new string[] { "*.html","!LoaderLog" };

    public static string[] LOADER_LOG_FILE_FILTER = new string[] { "LoaderLog*.html" };

    public const int MIN_LOG_FILE_SIZE = 950;

    public const string LOG_FILE_FILTER_REGEX = @".html$";

    public const string LOG_FILE_DIALOG_FILTER = "WebGateLog files (*.html)|*.html|All files (*.*)|*.*";

    public const string INPUT_FILES_EXTENSION = ".html";
  }

}
