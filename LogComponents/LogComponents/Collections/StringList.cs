using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using LogComponents;

namespace LogComponents
{
  [TypeConverter(typeof(StringListTypeConverter<StringList>))]
  public class StringList : List<string>
  {
    public StringList()
    {

    }

    public StringList(IEnumerable<string> strings):base(strings)
    {
    }

    public StringList Clone()
    {
      return new StringList(this);
    }
  }
}
