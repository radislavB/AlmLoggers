
namespace ServerLogger
{
  public static class Constants
  {
    public const string OPEN_FILE_DIALOG_FILTER = "QcServer logs (*.html)|*.html";
    public const string INITIAL_LOG_FOLDER = @"c:\";
    public const string DRAG_DROP_FILTER_REGEX = @"(.*\.html$|.*\.html$)";
    public static string[] FILE_FILTER = new string[] { "*.html" };
    public const int MIN_LOG_FILE_SIZE = 9500;

    public class COLUMNS
    {
      public static string TOTAL_TIME_FORMAT = "mm:ss.fff";
      public static string TOTAL_TIME_PROPERTY_NAME = "TotalTime";

    }
  }
}
