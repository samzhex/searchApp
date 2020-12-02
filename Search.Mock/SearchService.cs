using System.Collections.Generic;
using System.Linq;

namespace Search.Mock
{
    public class SearchService : ISearchService
    {
        private IEnumerable<SearchItem> _items;

        public SearchService()
        {
            _items = Initialize();
        }

        private IEnumerable<SearchItem> Initialize()
        {
            return new[] {
                new SearchItem { Id = 1, Text = "Chop Suey"},
                new SearchItem { Id = 2, Text = "Toxicity" },

            };
        }

        public IEnumerable<SearchItem> GetResult(string query)
        {
            return _items.Where(i => i.Text.ToLower().Contains(query.ToLower()));
        }
    }
}