using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Xml;
using System.IO;

namespace LogComponents
{
  /// <summary>
  /// Base for config files. 
  /// Class use name of calling property as key for dictionaries, so as no need to pass key
  /// </summary>
  public class ConfigBase
  {
    #region Private data members

    private Dictionary<Type, IDictionary> m_collections = new Dictionary<Type, IDictionary>();
    private string m_fileName;
    private Version m_version = new Version();

    #endregion

    #region Constructor

    /// <summary>
    /// Create new instance of <see cref="ConfigBase"/>.
    /// </summary>
    public ConfigBase()
    {
      m_fileName = Helpers.IOUtilities.GetPathToApplicationRepository() + Path.AltDirectorySeparatorChar + "config.xml";
      LoadXml();
    }

    #endregion

    #region Public methods

    /// <summary>
    /// Load config file from xml file
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    private void LoadXml()
    {

      string typeDefinition = null;
      Type type = null;
      TypeConverter converter = null;
      IDictionary collection = null;
      string value = null;
      string key = null;

      if (!File.Exists(m_fileName))
      {
        return;
      }

      XmlDocument doc = new XmlDocument();
      try
      {
        doc.Load(m_fileName);

        //version
        XmlNode rootNode = doc.SelectSingleNode(Constants.ROOT);
        string versionString = rootNode.Attributes[Constants.VERSION].InnerText.Trim();
        m_version = new Version(versionString);

        //parameters
        XmlNodeList list = doc.SelectNodes(Constants.ROOT + "/" + Constants.TYPE);

        foreach (XmlNode typeNode in list)
        {
          typeDefinition = typeNode.Attributes[Constants.VALUE].InnerText.Trim();

          try
          {
            type = Type.GetType(typeDefinition, true, true);
          }
          catch (FileLoadException e)
          {
            Debug.Fail(e.Message);
            LogComponents.Helpers.IOUtilities.LogException(e);
            continue;
          }

          converter = TypeDescriptor.GetConverter(type);
          collection = GetOptionCollection(type);

          foreach (XmlNode parameterNode in typeNode.ChildNodes)
          {
            key = parameterNode.Attributes[Constants.KEY].InnerText.Trim();
            value = parameterNode.Attributes[Constants.VALUE].InnerText.Trim();
            if (converter.CanConvertFrom(typeof(string)))
            {
              collection[key] = converter.ConvertFromInvariantString(value);
            }
          }
        }
      }
      catch (TypeLoadException e)
      {
        Debug.Fail(e.Message);
        LogComponents.Helpers.IOUtilities.LogException(e);
      }
      catch (Exception e)
      {
        if (e is NotSupportedException)
        {
          Debug.Fail("Reading of file is failed. New collection is returned.");
        }

        collection.Clear();
        LogComponents.Helpers.IOUtilities.LogException(e);
      }
    }

    /// <summary>
    /// Save config to xml file
    /// </summary>
    /// <param name="fileName"></param>
    public void Save()
    {
      InnerSave();
    }

    private void InnerSave()
    {
      XmlDocument doc = new XmlDocument();
      TypeConverter converter;
      XmlNode rootNode;
      XmlNode typeNode;
      XmlNode parameterNode;
      XmlAttribute attribute;
      IDictionary dictionary;

      doc.AppendChild(doc.CreateXmlDeclaration(Constants.XML_VERSION, null, null));

      //root
      rootNode = doc.CreateElement(Constants.ROOT);
      doc.AppendChild(rootNode);

      //root attributes
      attribute = doc.CreateAttribute(Constants.APPLICATION);
      attribute.InnerText = ExecutingAssembly.ProductName;
      rootNode.Attributes.Append(attribute);

      attribute = doc.CreateAttribute(Constants.VERSION);
      attribute.InnerText = ExecutingAssembly.Version.ToString();
      rootNode.Attributes.Append(attribute);

      attribute = doc.CreateAttribute(Constants.SAVETIME);
      attribute.InnerText = DateTime.Now.ToString();
      rootNode.Attributes.Append(attribute);

      //types
      foreach (Type type in m_collections.Keys)
      {
        dictionary = m_collections[type];
        if (dictionary.Count == 0)
          continue;

        typeNode = doc.CreateElement(Constants.TYPE);
        rootNode.AppendChild(typeNode);

        attribute = doc.CreateAttribute(Constants.VALUE);
        attribute.InnerText = (type.Module.ScopeName == Constants.CLR || type.Module.Assembly == Assembly.GetCallingAssembly()) ?
            type.FullName : type.AssemblyQualifiedName;

        typeNode.Attributes.Append(attribute);
        converter = TypeDescriptor.GetConverter(type);
        foreach (string key in dictionary.Keys)
        {
          object value = dictionary[key];
          if (value == null)
          {
            continue;
          }

          parameterNode = doc.CreateElement(Constants.PARAM);
          typeNode.AppendChild(parameterNode);

          attribute = doc.CreateAttribute(Constants.KEY);
          attribute.InnerText = key;
          parameterNode.Attributes.Append(attribute);

          attribute = doc.CreateAttribute(Constants.VALUE);

          attribute.InnerText = converter.ConvertToInvariantString(value);
          parameterNode.Attributes.Append(attribute);
        }
      }
      doc.Save(m_fileName);
    }

    public void Set<T>(string key, T value)
    {
      OptionDictionary<T> optionDictionary = GetOptionCollection<T>();
      T oldValue;
      if (optionDictionary.TryGetValue(key, out oldValue))
      {
        if (oldValue != null && oldValue.Equals(value))
        {
          return;
        }
      }

      optionDictionary[key] = value;
    }

    public T Get<T>(string key)
    {
      OptionDictionary<T> options = GetOptionCollection<T>();

      if (!options.ContainsKey(key) || IsOverrideIsRequired(key))
      {
        T value = GetDefaultValue<T>(key);
        options[key] = value;
      }

      return options[key];
    }

    private bool IsOverrideIsRequired(string propertyName)
    {
      PropertyInfo property = GetType().GetProperty(propertyName);
      if (property != null && property.IsDefined(typeof(OverrideValueFromVersionAttribute), false))
      {
        object[] attributes = property.GetCustomAttributes(typeof(OverrideValueFromVersionAttribute), false);
        Version overrideVersion = ((OverrideValueFromVersionAttribute)attributes[0]).Version;

        return overrideVersion > m_version;
      }

      return false;
    }

    public void SetDefault()
    {
      m_collections.Clear();
    }

    #endregion

    #region Private methods



    /// <summary>
    /// Get default value of type, if possible return empty constructor
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    private T GetDefaultValue<T>()
    {
      if (typeof(T).IsValueType)
        return default(T);


      ConstructorInfo ctor = typeof(T).GetConstructor(new Type[0]);
      if (ctor != null)
      {
        return (T)ctor.Invoke(null);
      }
      else
      {
        return default(T);
      }
    }

    private T GetDefaultValue<T>(string propertyName)
    {
      PropertyInfo property = GetType().GetProperty(propertyName);
      Debug.Assert(propertyName.EndsWith("History") || propertyName.StartsWith("clm") || property != null,
        "Property <" + propertyName + "> doesn't exist in option file.");

      T value = default(T);

      if (property != null && property.IsDefined(typeof(DefaultValueAttribute), false))
      {
        object[] attributes = property.GetCustomAttributes(typeof(DefaultValueAttribute), false);
        object defaultAttrValue = ((DefaultValueAttribute)attributes[0]).Value;

        if (defaultAttrValue == null)//no default attribute
        {
          value = GetDefaultValue<T>();
        }
        if (defaultAttrValue is T)
        {
          value = (T)defaultAttrValue;
        }
        else
        {
          TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
          if (converter.CanConvertFrom(defaultAttrValue.GetType()))
          {
            value = (T)converter.ConvertFrom(defaultAttrValue);
          }
        }
      }
      else
      {
        value = GetDefaultValue<T>();
      }

      return value;
    }

    private OptionDictionary<T> GetOptionCollection<T>()
    {
      Type type = typeof(T);
      if (!m_collections.ContainsKey(type))
      {
        m_collections[type] = new OptionDictionary<T>();
      }
      return (OptionDictionary<T>)m_collections[type];
    }

    private IDictionary GetOptionCollection(Type genetic)
    {
      if (!m_collections.ContainsKey(genetic))
      {
        Type genericCollectionType = typeof(OptionDictionary<>).MakeGenericType(genetic);//typeof(int)
        m_collections[genetic] = (IDictionary)Activator.CreateInstance(genericCollectionType);
      }


      return m_collections[genetic];
    }

    #endregion

    #region Private types

    /// <summary>
    /// Constants for ConfigBase
    /// </summary>
    private static class Constants
    {
      public static string CLR = "CommonLanguageRuntimeLibrary";
      public static string PARAM = "param";
      public static string VALUE = "value";
      public static string KEY = "key";
      public static string TYPE = "type";
      public static string ROOT = "parameters";
      public static string XML_VERSION = "1.0";
      public static string APPLICATION = "application";
      public static string VERSION = "version";
      public static string SAVETIME = "savetime";
    }

    private class OptionDictionary<T> : Dictionary<string, T>
    {
    }

    #endregion

  }
}
