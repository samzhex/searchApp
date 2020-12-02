using System.Collections.Generic;

namespace Search
{
    public interface ISearchService
    {
        IEnumerable<SearchItem> GetResult(string query);
    }
}
