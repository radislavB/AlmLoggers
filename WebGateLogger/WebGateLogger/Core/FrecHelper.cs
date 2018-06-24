using System;

using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using LogComponents;

namespace WebGateLogger
{
  public static class FrecHelper
  {
    private static Dictionary<string, string> s_specialResponcePatterns;
    private static Dictionary<string, string> s_specialErrors;


    static FrecHelper()
    {
      s_specialResponcePatterns = new Dictionary<string, string>();
      s_specialResponcePatterns.Add("RunQuery", WebGateConst.PATTERN_RESPONSE_QUERY_CONTENT);

      s_specialErrors = new Dictionary<string, string>();
      s_specialErrors.Add(WebGateConst.DISCONNECTION_MESSAGE, WebGateConst.DISCONNECTION_MESSAGE);
    }

    public static string GetConnectionURL(string fileContent)
    {
      Match match = Regex.Match(fileContent, WebGateConst.PATTERN_CONNECTION_URL, RegexOptions.Multiline);
      if (match.Success)
      {
        return match.Groups[1].Value;
      }

      return null;
    }

    public static string GetFileContent(string fileName, bool loadFollowingSessionFiles, out bool inProcess)
    {
      string fullContent = string.Empty;
      inProcess = false;

      string fileToLoad = fileName;

      while (fileToLoad != null)
      {
        string content = Helpers.IOUtilities.GetContentFromFile(fileToLoad, out inProcess);
        fileToLoad = null;

        //optimization - avoid concatenation on the start
        if (fullContent == "")
        {
          fullContent = content;
        }
        else
        {
          fullContent += content;
        }


        if (loadFollowingSessionFiles && content.EndsWith("</a>\r\n"))//has continue
        {
          int start = content.LastIndexOf("<br>");
          Regex regex = new Regex("continue in next file:.*?>(?<NEXT_FILE>.*?)<");
          Match match = regex.Match(content, start);
          if (match.Success)
          {
            string nextFile = match.Groups["NEXT_FILE"].Value;
            if (File.Exists(nextFile))
            {
              fileToLoad = nextFile;
            }
          }
        }
      }

      return fullContent;
    }

    public static List<Frec> ParseFrecsHeaders(FrecCollection frecParent, string fileContent, IList<string> excludedFrecs)
    {
      Regex startExtractorRegex = new Regex(WebGateConst.PATTERN_START, RegexOptions.Multiline | RegexOptions.Compiled);
      MatchCollection matchCollection = startExtractorRegex.Matches(fileContent);

      int defaultSize = 200;
      List<Frec> list = new List<Frec>(defaultSize);
      foreach (Match match in matchCollection)
      {
        string frecName = match.Groups[PatternGroup.FREC_NAME].Value;
        if (excludedFrecs.Contains(frecName))
        {
          continue;
        }


        string strTime = match.Groups[PatternGroup.TIME].Value;

        Frec frec = new Frec(
          frecParent,
          frecName,
          match.Groups[PatternGroup.THREAD_ID].Value,
          TimeSpan.Parse(strTime),
           match);

        list.Add(frec);
        frec.Id = list.Count;
      }
      return list;
    }

    public static int FindEndOfFrec(string fileContent, Frec frec)
    {
      int startFrecIndex = frec.Match.Index;
      string endPattern = string.Format(WebGateConst.END_FORMAT, frec.Title);
      int endFrecIndex = fileContent.IndexOf(endPattern, startFrecIndex);
      if (endFrecIndex == -1)
      {
        endFrecIndex = fileContent.Length;
      }
      else
      {
        endFrecIndex += endPattern.Length;
      }
      return endFrecIndex;
    }

    public static void InitializeFrecContent(string fileContent, Frec frec)
    {
      Debug.Assert(!frec.IsInitialized);
      Stopwatch stopWatch = new Stopwatch();
      stopWatch.Start();
      try
      {
        frec.IsInitialized = true;

        //get start and end
        int startFrecIndex = frec.Match.Index + frec.Match.Length;
        int endFrecIndex = FindEndOfFrec(fileContent, frec);

        //parse content
        ParseRequestContent(fileContent, frec, startFrecIndex, endFrecIndex);
        ParseResponceContent(fileContent, frec, startFrecIndex, endFrecIndex);
        ParseQcSensePerformanceData(fileContent, frec, startFrecIndex, endFrecIndex);
      }
      finally
      {
        stopWatch.Stop();
        frec.ParseDuration = (int)stopWatch.ElapsedMilliseconds;
      }
    }

    private static void ParseRequestContent(string fileContent, Frec frec, int startFrecIndex, int endFrecIndex)
    {
      //Parse prefix
      Regex prefixRegex = new Regex(WebGateConst.PATTERN_REQUEST_PREFIX + frec.Title, RegexOptions.Singleline);
      Match prefixMatch = prefixRegex.Match(fileContent, startFrecIndex, endFrecIndex - startFrecIndex);
      if (prefixMatch.Success)
      {
        frec.RequestId = prefixMatch.Groups[PatternGroup.REQUEST_ID].Value;
        frec.Server = prefixMatch.Groups[PatternGroup.SERVER].Value;
      }
      else
      {
        //no request
        return;
      }

      //parse content
      int prefixEndIndex = prefixMatch.Index + prefixMatch.Length;
      //first try with session
      Regex lengthRegex = new Regex(WebGateConst.PATTERN_REQUEST_CONTENT_LENGTH_WITH_SESSION, RegexOptions.Singleline);
      Match match = lengthRegex.Match(fileContent, prefixEndIndex, endFrecIndex - prefixEndIndex);
      //try without session
      if (!match.Success)
      {
        lengthRegex = new Regex(WebGateConst.PATTERN_REQUEST_CONTENT_LENGTH, RegexOptions.Singleline);
        match = lengthRegex.Match(fileContent, prefixEndIndex, endFrecIndex - prefixEndIndex);
      }

      if (match.Success)
      {
        bool isTruncated;
        frec.Request = ExtractContentByLength(fileContent, match);
        //frec.AddIllegalCharacters(Helpers.IOUtilities.GetIllegalCharacters(frec.Request));
        frec.Request = TruncateIfRequired(frec.Request, int.MaxValue, out isTruncated);
        frec.Request = RemoveUnnessessoryCharacters(frec.Request, int.MaxValue);
        frec.SessionId = match.Groups["SESSION"].Value;
      }
      else
      {
        //no content
        return;
      }
    }

    private static string ExtractContentByLength(string fileContent, Match lengthMatch)
    {
      Debug.Assert(lengthMatch.Success);
      Debug.Assert(lengthMatch.Groups[PatternGroup.LENGTH].Value != null);

      string lengthHexStr = lengthMatch.Groups[PatternGroup.LENGTH].Value;
      int length = int.Parse(lengthHexStr, System.Globalization.NumberStyles.HexNumber);
      int lengthMatchEndIndex = lengthMatch.Index + lengthMatch.Length;

      //responce start after second :
      //after length going string like that "500:str:", so the real content come after second ':'
      int contentStartIndex = fileContent.IndexOf(":", lengthMatchEndIndex);
      contentStartIndex = fileContent.IndexOf(":", contentStartIndex + 1) + 1;


      int contentEndIndex = lengthMatchEndIndex + length;
      int contentActualLength = contentEndIndex - contentStartIndex;

      //validate - request might be not be written yet fully
      if (contentStartIndex + contentActualLength > fileContent.Length)
      {
        contentActualLength = fileContent.Length - contentStartIndex;
      }

      String content = fileContent.Substring(contentStartIndex, contentActualLength);
      return content;
    }

    private static String TruncateIfRequired(string text, int maxLength, out bool isTruncated)
    {
      isTruncated = false;

      if (text.Length > maxLength)
      {
        isTruncated = true;
        text = text.Substring(0, maxLength);
      }
      return text;
    }

    private static void ParseResponceContent(string fileContent, Frec frec, int startSearchIndex, int endFrecIndex)
    {
      string prefixString = ReplaceGroupReference(WebGateConst.PATTERN_RESPONSE_PREFIX, PatternGroup.REQUEST_ID, frec.RequestId);
      Regex prefixRegex = new Regex(prefixString, RegexOptions.Singleline);
      Match prefixMatch = prefixRegex.Match(fileContent, startSearchIndex, endFrecIndex - startSearchIndex);
      if (!prefixMatch.Success)
      {
        //not contains responce
        //try to retrieve time
        Regex endRegex = new Regex(string.Format(WebGateConst.END_PATTERN, frec.Thread, frec.Title), RegexOptions.Multiline);
        Match endMatch = endRegex.Match(fileContent, startSearchIndex, endFrecIndex - startSearchIndex);
        if (endMatch.Success)
        {
          string strTime = endMatch.Groups[PatternGroup.TIME].Value;
          frec.ResponceTime = TimeSpan.Parse(strTime);
        }

        //check error patterns
        Regex inlineErrorRegex = new Regex(WebGateConst.INLINE_ERROR_PATTERN, RegexOptions.Singleline | RegexOptions.IgnoreCase);
        Match inlineErrorMatch = inlineErrorRegex.Match(fileContent, startSearchIndex, endFrecIndex - startSearchIndex);
        if (inlineErrorMatch.Success)
        {
          frec.ErrorCode = 0;
          frec.Response = inlineErrorMatch.Groups[PatternGroup.MESSAGE].Value;
        }
        else //check special errors
        {
          foreach (KeyValuePair<string, string> errorPattern in s_specialErrors)
          {
            if (fileContent.IndexOf(errorPattern.Key, startSearchIndex, endFrecIndex - startSearchIndex) > 0)
            {
              frec.ErrorCode = 0;
              frec.Response = errorPattern.Value;
            }
          }
        }


        return;
      }
      else
      {
        string strTime = prefixMatch.Groups[PatternGroup.TIME].Value;
        frec.ResponceTime = TimeSpan.Parse(strTime);
      }

      //********************************************************
      //Extract common content
      int prefixEndIndex = prefixMatch.Index + prefixMatch.Length;
      Regex lengthRegex = new Regex(WebGateConst.PATTERN_RESPONSE_CONTENT_LENGTH, RegexOptions.Singleline);
      int maxSearchForLengthMatch = Math.Min(40, endFrecIndex - prefixEndIndex);
      Match lengthMatch = lengthRegex.Match(fileContent, prefixEndIndex, maxSearchForLengthMatch);
      if (lengthMatch.Success)
      {
        bool isTruncated;
        frec.Response = ExtractContentByLength(fileContent, lengthMatch);
        frec.AddIllegalCharacters(Helpers.IOUtilities.GetIllegalCharacters(frec.Response));
        frec.Response = TruncateIfRequired(frec.Response, int.MaxValue, out isTruncated);

        frec.Response = RemoveUnnessessoryCharacters(frec.Response, Options.GetInstance.DontIndentateResponceBiggerThanSize);
        return;
      }

      //********************************************************
      //handle specific cases
      //choose extract pattern
      startSearchIndex = prefixEndIndex;
      int failedIndex = fileContent.IndexOf(WebGateConst.RESPONCE_ERROR_MESSAGE_START, startSearchIndex, endFrecIndex - startSearchIndex);
      string responceContentString;
      if (failedIndex > -1)
      {
        responceContentString = WebGateConst.PATTERN_RESPONSE_ERROR;
      }
      else if (s_specialResponcePatterns.ContainsKey(frec.Title))
      {
        responceContentString = s_specialResponcePatterns[frec.Title];
      }
      else
      {
        //Inline exception is possible
        Regex inlineErrorRegex = new Regex(WebGateConst.INLINE_ERROR_PATTERN, RegexOptions.Singleline | RegexOptions.IgnoreCase);
        Match inlineErrorMatch = inlineErrorRegex.Match(fileContent, startSearchIndex, endFrecIndex - startSearchIndex);
        if (inlineErrorMatch.Success)
        {
          frec.ErrorCode = 0;
          frec.Response = inlineErrorMatch.Groups[PatternGroup.MESSAGE].Value;
        }


        //no content
        return;
      }


      Regex responceContentRegex = new Regex(responceContentString, RegexOptions.Singleline);
      Match responceContentMatch = responceContentRegex.Match(fileContent, startSearchIndex, endFrecIndex - startSearchIndex);
      if (responceContentMatch.Success)
      {
        frec.Response = responceContentMatch.Groups[PatternGroup.RESPONSE].Value;
        if (failedIndex > -1)
        {
          string errorCodeStr = responceContentMatch.Groups[PatternGroup.ERROR_CODE].Value;
          int errorCode = int.Parse(errorCodeStr);
          frec.ErrorCode = errorCode & WebGateConst.COMErrorMask;
        }
        else
        {
          frec.Response = RemoveUnnessessoryCharacters(frec.Response, Options.GetInstance.DontIndentateResponceBiggerThanSize);
        }
      }
    }

    private static void ParseQcSensePerformanceData(string fileContent, Frec frec, int startSearchIndex, int endFrecIndex)
    {
      frec.ResponcePerformanceData = string.Empty;
      int responseStartIndex = fileContent.IndexOf(WebGateConst.RESPONSE_INDICATION, startSearchIndex, endFrecIndex - startSearchIndex);
      if (responseStartIndex > 0)
      {
        Regex regex = new Regex(WebGateConst.RESPONSE_PERFORMANCE_DATA);

        Match match = regex.Match(fileContent, responseStartIndex, endFrecIndex - responseStartIndex);
        if (match.Success)
        {
          frec.ResponcePerformanceData = match.Groups[PatternGroup.PERFORMANCE].Value;
        }
      }
    }


    public static void ParseFrecsContent(string fileContent, List<Frec> frecList)
    {
      foreach (Frec frec in frecList)
      {
        InitializeFrecContent(fileContent, frec);
      }
    }

    private static string ReplaceGroupReference(string pattern, string groupName, string replacement)
    {
      StringBuilder replacementSB = new StringBuilder(replacement);
      replacementSB.Replace("[", @"\[");
      replacementSB.Replace("]", @"\]");

      string wrappedGroupName = string.Format(WebGateConst.GROUP_WRAPPER_FORMAT, groupName);

      return pattern.Replace(wrappedGroupName, replacementSB.ToString());
    }

    private static string RemoveUnnessessoryCharacters(string str, int maxSize)
    {
      string temp = str;
      temp = RemoveLengthIndications(temp);

      if (temp.Length < maxSize)
      {
        temp = RemoveFirstParenthesis(temp);
        temp = InsertIndentation(temp);
      }

      return temp;
    }

    private static string InsertIndentation(string str)
    {
      if (string.IsNullOrEmpty(str))
        return str;

      StringBuilder sb = new StringBuilder(str.Length * 2);
      sb.Append(str);
      int tabCounter = 0;
      string tabs = string.Empty;
      string temp3chars;
      for (int i = 0; i < sb.Length; i++)
      {
        if (sb[i] == '{')
        {
          tabCounter++;
          tabs = new string('\t', tabCounter);
        }
        else if (sb[i] == '}' && i + 4 < sb.Length)//defence agains cutting
        {
          tabCounter--;
          if (tabCounter > -1)
          {
            tabs = new string('\t', tabCounter);

            temp3chars = sb.ToString(i + 1, 3);
            if (temp3chars == "\r\n,")
            {
              sb.Remove(i + 1, 3);
            }
            else if (temp3chars == "\r\n{")
            {
              sb.Remove(i + 1, 2);
            }
          }
        }
        else if (sb[i] == '\n')
        {
          if (tabCounter > 0)
          {
            sb.Insert(i + 1, tabs);
            i += tabCounter;
          }
        }

        //remove prev \t
        if (sb[i] == '}' && sb[i - 1] == '\t')
        {
          sb.Remove(i - 1, 1);
          i--;
        }
      }

      //remove prev \t if required
      if (sb[sb.Length - 1] == '}' && sb[sb.Length - 2] == '\t')
      {
        sb.Remove(sb.Length - 2, 1);
      }

      //remove white spaces from end
      while (sb.Length > 0 && char.IsWhiteSpace(sb[sb.Length - 1]))
      {
        sb.Remove(sb.Length - 1, 1);
      }

      //return 
      return sb.ToString();
    }

    private static string RemoveFirstParenthesis(string str)
    {
      int start = str.IndexOf('{');
      int end = str.LastIndexOf('}');

      if (start == -1 || end == -1)
      {
        return str;
      }
      if ((str.Length - end) > 5)//truncated
      {
        return str;
      }

      if (end - start < 4)//case :  {/n}
        return string.Empty;

      //Remove first parenthesis if there no other parenthesis
      string subStr = str;
      if (FirstParenthesisCanBeRemoved(str, start, end))
      {
        start += 3;
        end -= 1;
        subStr = str.Substring(start, end - start);
      }

      return subStr;
    }

    /// <summary>
    /// remove length indication like : \0000001f\
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    private static string RemoveLengthIndications(string str)
    {
      string temp = Regex.Replace(str, WebGateConst.LENGTH_INDICATION, string.Empty);
      return temp;
    }

    private static bool FirstParenthesisCanBeRemoved(string str, int start, int end)
    {
      int count = 0;
      for (int i = start; i < end; i++)
      {
        if (str[i] == '{')
        {
          count++;
        }
        else if (str[i] == '}')
        {
          count--;
          if (count == 0)
            return false;
        }
      }

      return true;
    }

    #region Private constant classes

    private static class PatternGroup
    {
      public const string FREC_NAME = "FREC_NAME";
      public const string TIME = "TIME";
      public const string THREAD_ID = "THREAD_ID";
      public const string REQUEST = "REQUEST";
      public const string REQUEST_ID = "REQUEST_ID";
      public const string SERVER = "SERVER";
      public const string RESPONSE = "RESPONSE";
      public const string ERROR_CODE = "ERROR_CODE";
      public const string PERFORMANCE = "PERFORMANCE";
      public const string LENGTH = "LENGTH";
      public const string MESSAGE = "MESSAGE";
    }

    private static class WebGateConst
    {
      // public static string PATTERN_START = @"(<B>\r\n[\d\.]+)-(?<TIME>.*)>(?<THREAD_ID>.*?)> (?<FREC_NAME>.+) Started:";
      public static string PATTERN_START = @"(?:<B>\r\n[\d\.]+)-(?<TIME>.*)>(?<THREAD_ID>.*?)> (?:(?:\[(?<FREC_NAME>.*?)\].*?)|(?<FREC_NAME>.*?)) Started:";

      public static string PATTERN_REQUEST_PREFIX = @">(?<REQUEST_ID>(Http|FileTransfer)[^\n]*?)> posting : https?://(?<SERVER>.*?):?\d{0,5}/.*?";

      public static string PATTERN_REQUEST_CONTENT_LENGTH_WITH_SESSION = @",\r\n5.*?0:int:(?<SESSION>[-0-9]+).*?: \\(?<LENGTH>[0-9A-Fa-f]*?)\\";
      public static string PATTERN_REQUEST_CONTENT_LENGTH = @",\r\n5.*?: \\(?<LENGTH>[0-9A-Fa-f]*?)\\";
      //@",\r\n5.*?: \\(?<LENGTH>[0-9A-Fa-f]*?)\\"
      //",\r\n5: \"0:int:(?<SESSION>[0-9]+)\", 6: \\(?<LENGTH>[0-9A-Fa-f]*?)\\";
      //5: "0:int:3706", 6: \0000005E\0:conststr

      public static string PATTERN_RESPONSE_PREFIX = @"-(?<TIME>[\d.:]{5,12})>\<REQUEST_ID>> THttpThr Response: {";
      public static string PATTERN_RESPONSE_CONTENT_LENGTH = @"\r\n0:\\(?<LENGTH>[0-9A-Fa-f]*?)\\";

      public static string PATTERN_RESPONSE_ERROR = @"\[ERR_SEP\]Messages:\n(?<RESPONSE>.*?)\n,.*?(?<ERROR_CODE>-\d+)\r\n}";
      public static string PATTERN_RESPONSE_QUERY_CONTENT = "str:(?<RESPONSE>{.*}),\r\n.*?3:[^\n]*:str";//@"2:.*?str:(?<RESPONSE>{.*?}\r\n}),\r\n3:.*?:str:{";

      public static string INLINE_ERROR_PATTERN = @"failed:<br>\r\n.*> (?<MESSAGE>.*)<br>\r\n";
      public static string DISCONNECTION_MESSAGE = "Your Quality Center session has been disconnected.";

      public static string END_PATTERN = @"-(?<TIME>[\d:]+)>{0}> {1} Ended:";
      public static string END_FORMAT = @"{0} Ended:";
      public static string GROUP_WRAPPER_FORMAT = @"\<{0}>";

      public static string LENGTH_INDICATION = @"\\0[\da-fA-F]{7}\\";
      public static string RESPONCE_ERROR_MESSAGE_START = "[ERR_SEP]Messages:\n";


      public static string RESPONSE_INDICATION = "THttpThr Response";
      public static string RESPONSE_PERFORMANCE_DATA = "str:(?<PERFORMANCE><.*/>)";

      public static string PATTERN_CONNECTION_URL = @"posting : (?<URL>https?://(?<SERVER>.*):\d+/qcbin)";

      public static int COMErrorMask = 0x0000ffff;
    }

    #endregion
  }
}
