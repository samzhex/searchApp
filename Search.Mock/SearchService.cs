using System;
using System.Collections.Generic;
using System.Linq;

namespace Search.Mock
{
    public class SearchService : ISearchService
    {
        private readonly ICollection<SearchItem> _items;

        public SearchService()
        {
            _items = Initialize();
        }

        public SearchService(ICollection<SearchItem> items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }

        public ICollection<SearchItem> GetResult(string query)
        {
            query = query ?? throw new ArgumentNullException(nameof(query));
            if (query.Length == 0)
            {
                throw new ArgumentException("Query can not be empty", nameof(query));
            }

            var res = _items.Where(i => i.Text
                    .Contains(query, StringComparison.InvariantCultureIgnoreCase)).ToList();
            return res;
        }

        private static ICollection<SearchItem> Initialize()
        {
            return new[]
            {
                new SearchItem { Id = 1, Text = "Chop Suey"},
                new SearchItem { Id = 2, Text = "Toxicity" },
                new SearchItem { Id = 2, Text = "ATWA" },
                new SearchItem { Id = 2, Text = "Aerials" },
            };
        }
    }
}