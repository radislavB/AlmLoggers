using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Reflection;

namespace LogComponents.FilterControl
{
  public abstract class FilterableBindingList<T> : IFilterableBindingList, IEnumerable<T>
    where T : ISupportId
  {
    private List<T> m_fullList;
    private List<T> m_filteredList;
    private bool m_sorted;
    private PropertyDescriptor m_sortProperty;
    private ListSortDirection m_sortDirection;
    private FilterConfig m_filterConfig = new FilterConfig();

    public FilterableBindingList()
      : this(null) { }

    public FilterableBindingList(IEnumerable<T> source)
    {
      Reload(source);
    }

    protected void Reload(IEnumerable<T> source)
    {
      if (source == null)
      {
        m_filteredList = m_fullList = new List<T>();
      }
      else
      {
        m_filteredList = m_fullList = new List<T>(source);
      }
    }

    public event ListChangedEventHandler ListChanged;

    [Browsable(false)]
    public bool SupportsChangeNotification
    {
      get { return true; }
    }

    public virtual void Add(T value)
    {
      m_fullList.Add(value);
    }

    [Browsable(false)]
    public int Count
    {
      get { return m_filteredList.Count; }
    }

    [Browsable(false)]
    public int FullCount
    {
      get { return m_fullList.Count; }
    }

    [Browsable(false)]
    public bool IsFiltered
    {
      get
      {
        return m_fullList != m_filteredList;
      }
    }

    public object this[int index]
    {
      get
      {
        return m_filteredList[index];
      }
      set
      {
        throw new NotImplementedException();
      }
    }

    public System.Collections.IEnumerator GetEnumerator()
    {
      return m_filteredList.GetEnumerator();
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
      return m_filteredList.GetEnumerator();
    }

    [Browsable(false)]
    public IList<T> FullList
    {
      get
      {
        return m_fullList;
      }
    }

    public T GetItem(int index)
    {
      return m_filteredList[index];
    }

    public T GetItem(int index, bool fromFullList)
    {
      if (fromFullList)
      {
        return m_fullList[index];
      }
      else
      {
        return m_filteredList[index];
      }
    }

    public int GetIndexById(int id)
    {
      for (int i = 0; i < Count; i++)
      {
        if (m_filteredList[i].Id == id)
          return i;
      };
      return -1;
    }

    public void SetFilter(FilterConfig filterConfig)
    {
      try
      {
        InternalSetFilter(filterConfig);
      }
      catch (Exception e)
      {
        InternalSetFilter(new FilterConfig());
        throw e;
      }
    }

    public FilterConfig FilterConfig
    {
      get
      {
        return m_filterConfig;
      }
    }

    private void InternalSetFilter(FilterConfig filterConfig)
    {
      m_filterConfig = filterConfig;
      if (filterConfig.IsEmpty)
      {
        //no filter word - clear filter
        ClearFilter();
        return;
      }

      m_filteredList = new List<T>();
      bool isMatching;
      NameValueCollection mainFilters = filterConfig.MainFilter;
      for (int i = 0; i < m_fullList.Count; i++)
      {
        isMatching = true;
        foreach (string filterKey in mainFilters.Keys)
        {
          foreach (string filterValue in mainFilters.GetValues(filterKey))
          {
            if (!MatchingFilter(i, filterKey, filterValue))
            {
              isMatching = false;
              break;
            }
          }
        }

        if (isMatching)
        {
          foreach (string filterKey in filterConfig.SubItemFilter.Keys)
          {
            foreach (string filterValue in filterConfig.SubItemFilter.GetValues(filterKey))
            {
              if (!MatchingFilterSubItems(m_fullList[i], filterKey, filterValue))
              {
                isMatching = false;
                break;
              }
            }
          }
        }

        if (isMatching)
        {
          m_filteredList.Add(m_fullList[i]);
        }
      }


      OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
    }

    protected bool MatchingFilterSubItems(T item, string property, string value)
    {
      IFilterableBindingList myItem = item as IFilterableBindingList;
      if (myItem == null)
        return false;

      for (int i = 0; i < myItem.FullCount; i++)
      {
        if (myItem.MatchingFilter(i, property, value))
          return true;
      }
      return false;
    }

    public void ClearFilter()
    {
      m_filteredList = m_fullList;
      OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
    }

    private void OnListChanged(ListChangedEventArgs e)
    {
      if (ListChanged != null)
      {
        ListChanged(this, e);
      }
    }

    public virtual bool MatchingFilter(int index, string property, string value)
    {
      return false;
    }

    protected bool IsContainsPropertyValue(T item, string propertyName, string value)
    {
      PropertyInfo pi = item.GetType().GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
      if (pi == null)
      {
        throw new ArgumentException("Property <" + propertyName + "> not found.");
      }

      Object piValue = pi.GetValue(item, null);
      if (piValue == null)
      {
        return value == null;
      }
      else
      {
        string realValue = piValue.ToString();
        return realValue.IndexOf(value, StringComparison.OrdinalIgnoreCase) > -1;
      }
    }

    public bool AllowEdit
    {
      get { return false; }
    }

    public int IndexOf(object value)
    {
      return IndexOf((T)value);
    }

    public int IndexOf(T value)
    {
      return IndexOf(value, false);
    }

    public int IndexOf(T value, bool fullList)
    {
      if (fullList)
      {
        return m_fullList.IndexOf(value);
      }
      else
      {
        return m_filteredList.IndexOf(value);
      }

    }

    #region Sorting

    public virtual bool SupportsSorting
    {
      get { return true; }
    }

    public void ApplySort(PropertyDescriptor property, ListSortDirection direction)
    {
      IComparer<T> comparer = new PropertyComparer<T>(property.Name, direction == ListSortDirection.Ascending);
      m_filteredList.Sort(comparer);

      m_sorted = true;
      m_sortDirection = direction;
      m_sortProperty = property;
      OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
    }

    [Browsable(false)]
    public ListSortDirection SortDirection
    {
      get
      {
        return m_sortDirection;
      }
    }

    [Browsable(false)]
    public PropertyDescriptor SortProperty
    {
      get
      {
        return m_sortProperty;
      }
    }

    [Browsable(false)]
    public bool IsSorted
    {
      get
      {
        return m_sorted;
      }
    }

    #endregion

    #region Not implemented

    public void AddIndex(PropertyDescriptor property)
    {
      throw new NotImplementedException();
    }

    public object AddNew()
    {
      throw new NotImplementedException();
    }

    [Browsable(false)]
    public bool AllowNew
    {
      get { throw new NotImplementedException(); }
    }

    [Browsable(false)]
    public bool AllowRemove
    {
      get { throw new NotImplementedException(); }
    }

    public int Find(PropertyDescriptor property, object key)
    {
      throw new NotImplementedException();
    }

    public void RemoveIndex(PropertyDescriptor property)
    {
      throw new NotImplementedException();
    }

    public void RemoveSort()
    {
      throw new NotImplementedException();
    }

    [Browsable(false)]
    public bool SupportsSearching
    {
      get { throw new NotImplementedException(); }
    }

    public int Add(object value)
    {
      throw new NotImplementedException();
    }

    public void Clear()
    {
      throw new NotImplementedException();
    }

    public bool Contains(object value)
    {
      throw new NotImplementedException();
    }

    public void Insert(int index, object value)
    {
      throw new NotImplementedException();
    }

    [Browsable(false)]
    public bool IsFixedSize
    {
      get { throw new NotImplementedException(); }
    }

    [Browsable(false)]
    public bool IsReadOnly
    {
      get { throw new NotImplementedException(); }
    }

    public void Remove(object value)
    {
      throw new NotImplementedException();
    }

    public void RemoveAt(int index)
    {
      throw new NotImplementedException();
    }

    public void CopyTo(Array array, int index)
    {
      throw new NotImplementedException();
    }

    [Browsable(false)]
    public bool IsSynchronized
    {
      get { throw new NotImplementedException(); }
    }

    [Browsable(false)]
    public object SyncRoot
    {
      get { throw new NotImplementedException(); }
    }

    #endregion
  }
}
