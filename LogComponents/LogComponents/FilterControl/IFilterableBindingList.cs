
using System.ComponentModel;

namespace LogComponents.FilterControl
{
  public interface IFilterableBindingList : IBindingList
  {
    int FullCount { get; }

    bool IsFiltered { get; }

    void ClearFilter();

    void SetFilter(FilterConfig filterConfig);

    bool MatchingFilter(int index,string property, string value);

    int GetIndexById(int id);
  }
}
