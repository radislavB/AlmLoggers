using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace LogComponents.FilterControl
{
  [TypeConverter(typeof(StringListTypeConverter<HistoryCollection>))]
  public class HistoryCollection : IList<string>
  {
    List<string> m_collection;
    int m_capacity;
    bool m_modified = true;

    public HistoryCollection()
      : this(15)
    {

    }

    public HistoryCollection(int capacity)
    {
      m_capacity = capacity;
      m_collection = new List<string>();

    }

    public void Add(string value)
    {
      if (value.Length < 2)
        return;

      m_collection.Remove(value);
      if (m_collection.Count > 0 && value.StartsWith(m_collection[0]))
        m_collection[0] = value;
      else if (m_collection.Count > 0 && m_collection[0].StartsWith(value))
      {
        //skip insert if new value is lesser that first item (case \b)
      }
      else
        m_collection.Insert(0, value);
      ShrinkToCapacity();

      m_modified = true;
    }

    private void ShrinkToCapacity()
    {
      while (m_collection.Count > m_capacity)
      {
        m_collection.RemoveAt(m_collection.Count - 1);
      }

      m_modified = true;
    }

    public bool Modified
    {
      get { return m_modified; }
      set { m_modified = value; }
    }

    public int Capacity
    {
      get
      {
        return m_capacity;
      }
      set
      {
        if (m_capacity < 4 || m_capacity > 50)
        {
          Debug.Fail("Illegal capacity");
          return;
        }

        //remove excessing items
        m_capacity = value;
        ShrinkToCapacity();
      }
    }

    public int Count
    {
      get
      {
        return m_collection.Count;
      }
    }


    public void Clear()
    {
      m_collection.Clear();
    }

    public string this[int index]
    {
      get
      {
        return m_collection[index];
      }
      set
      {
        throw new NotImplementedException();
      }
    }

    public int IndexOf(string item)
    {
      return m_collection.IndexOf(item);
    }

    public bool Contains(string item)
    {
      return m_collection.Contains(item);
    }

    public void CopyTo(string[] array, int arrayIndex)
    {
      m_collection.CopyTo(array, arrayIndex);
    }

    public IEnumerator<string> GetEnumerator()
    {
      return m_collection.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return m_collection.GetEnumerator();
    }

    public bool IsReadOnly
    {
      get { return false; }
    }

    public void Insert(int index, string item)
    {
      throw new NotImplementedException();
    }

    public void RemoveAt(int index)
    {
      throw new NotImplementedException();
    }

    public bool Remove(string item)
    {
      throw new NotImplementedException();
    }
  }
}
