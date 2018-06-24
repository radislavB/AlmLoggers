using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace LogComponents
{
  public class StringListTypeConverter<T> : TypeConverter
    where T : IList<string>, new()
  {
    static char[] SEPARATOR = { '|' };

    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
      return sourceType == typeof(string);
    }

    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    {
      return destinationType is IListSource;
    }

    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
      if (value.GetType() != typeof(string))
      {
        throw new ArgumentException("Illegal type of argument");
      }

      string[] parts = ((string)value).Split(SEPARATOR, StringSplitOptions.RemoveEmptyEntries);
      T collection = new T();
      foreach (string part in parts)
      {
        string trimmedPart = part.Trim();
        if (trimmedPart.Length > 0)
        {
          collection.Add(part);
        }
      }

      return collection;

    }

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if (destinationType != typeof(string))
      {
        throw new ArgumentException("Illegal type of argument");
      }

      if (value == null)
      {
        return string.Empty;
      }

      T collection = (T)value;
      StringBuilder builder = new StringBuilder();
      foreach (string item in collection)
      {
        builder.Append(item);
        builder.Append(SEPARATOR);
      }

      if (builder.Length > 0)
      {
        builder.Remove(builder.Length - SEPARATOR.Length, SEPARATOR.Length);
      }

      return builder.ToString();
    }

  }
}
