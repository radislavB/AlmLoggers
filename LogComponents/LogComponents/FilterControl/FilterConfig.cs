using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Collections.Specialized;

namespace LogComponents.FilterControl
{
  public class FilterConfig
  {
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private NameValueCollection m_mainFilter;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private NameValueCollection m_subItemFilter;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string m_subFilterString;

    private Dictionary<string, string> m_filterablePropertiesNameMap;

    public static char KEY_VALUE_SEPARATOR = '=';
    public static char PROPERTY_SEPARATOR = ';';
    private static char[] s_splitterChars = new char[] { PROPERTY_SEPARATOR };
    private static char[] s_trimChars = new char[] { ' ', PROPERTY_SEPARATOR };
    private static string s_searchSubItemsValue = "#";
    public static string EMPTY_PROPERTY = string.Empty;

    public FilterConfig()
    {
      ClearFilter();
    }

    public NameValueCollection MainFilter
    {
      get { return m_mainFilter; }
    }

    public NameValueCollection SubItemFilter
    {
      get { return m_subItemFilter; }
    }

    public void ClearFilter()
    {
      m_mainFilter = new NameValueCollection();
      m_subItemFilter = new NameValueCollection();
      m_subFilterString = string.Empty;
    }

    public string SubFilterString
    {
      get
      {
        return m_subFilterString;
      }
    }

    private void CreateSubFilterString(NameValueCollection filters)
    {
      StringBuilder sb = new StringBuilder();

      foreach (string filterKey in filters.Keys)
      {
        foreach (string filterValue in filters.GetValues(filterKey))
        {
          sb.Append(filterKey);
          if (filterKey != EMPTY_PROPERTY)
          {
            sb.Append(KEY_VALUE_SEPARATOR);
          }

          sb.Append(filterValue);
          sb.Append(s_splitterChars[0]);
          sb.Append(" ");
        }
      }

      m_subFilterString = sb.ToString();
    }

    public void SetFilter(string text)
    {
      ClearFilter();

      NameValueCollection filterTargetDictionary = m_mainFilter;
      string[] filters = text.Split(s_splitterChars, StringSplitOptions.RemoveEmptyEntries);
      foreach (string filter in filters)
      {
        string trimmedFilter = filter.Trim();
        if (trimmedFilter.StartsWith(s_searchSubItemsValue))
        {
          filterTargetDictionary = m_subItemFilter;
          trimmedFilter = trimmedFilter.Substring(s_searchSubItemsValue.Length).Trim();
        }
        else
        {
          filterTargetDictionary = m_mainFilter;
        }

        int propertySeparatorIndex = trimmedFilter.IndexOf(KEY_VALUE_SEPARATOR);
        string propertyName = EMPTY_PROPERTY;
        if (propertySeparatorIndex > -1)
        {
          {
            string propertyKey = trimmedFilter.Substring(0, propertySeparatorIndex).ToLower().Trim();
            if (m_filterablePropertiesNameMap.ContainsKey(propertyKey))
            {
              propertyName = m_filterablePropertiesNameMap[propertyKey];
            }
          }
        }

        if (propertyName == string.Empty)
        {
          if (trimmedFilter.Length > 0)
          {
            filterTargetDictionary.Add(String.Empty, trimmedFilter);
          }
        }
        else
        {
          string propertyValue = trimmedFilter.Substring(propertySeparatorIndex + 1).Trim();
          if (propertyValue.Length > 0)
          {
            filterTargetDictionary.Add(propertyName, propertyValue);
          }
        }
      }

      CreateSubFilterString(m_subItemFilter);
    }

    public bool IsPropertyFilterable(string property)
    {
      return m_filterablePropertiesNameMap.ContainsKey(property.ToLower());
    }

    public bool IsEmpty
    {
      get
      {
        return m_mainFilter.Count == 0 && m_subItemFilter.Count == 0;
      }
    }

    /// <summary>
    /// Map of column text to property name
    /// </summary>
    /// <param name="filterablePropertiesNameMap"></param>
    internal void Initialize(Dictionary<string, string> filterablePropertiesNameMap)
    {
      //copy to m_filterablePropertiesNameMap and set keys to be low case
      m_filterablePropertiesNameMap = new Dictionary<string, string>();
      foreach (KeyValuePair<string, string> item in filterablePropertiesNameMap)
      {
        m_filterablePropertiesNameMap[item.Key.ToLower()] = item.Value;
      }

      ClearFilter();
    }
  }
}
