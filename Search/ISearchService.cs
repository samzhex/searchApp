using System.Collections.Generic;

namespace Search
{
    public interface ISearchService
    {
        ICollection<SearchItem> GetResult(string query);
    }
}
