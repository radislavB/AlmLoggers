using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Reflection;

namespace LogComponents.FilterControl
{
  public class PropertyComparer<T> : IComparer<T>
    where T : ISupportId
  {

    PropertyInfo m_propertyInfo;
    int m_multiplier =1;

    public PropertyComparer(string property, bool asc)
    {
      m_propertyInfo = typeof(T).GetProperty(property, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

      if (m_propertyInfo == null)
      {
        throw new ApplicationException("Property not found : " + property);
      }

      if (!asc)
      {
        m_multiplier = -1;
      }

    }

    #region IComparer<T> Members

    public int Compare(T x, T y)
    {
      object value1 = m_propertyInfo.GetValue(x, null);
      object value2 = m_propertyInfo.GetValue(y, null);
      int comparison = Comparer.Default.Compare(value1, value2);

      if (comparison == 0)
      {
        int id1 = (x as ISupportId).Id;
        int id2 = (y as ISupportId).Id;

        comparison = id1.CompareTo(id2);
      }

      return m_multiplier * comparison;

    }

    #endregion
  }
}
