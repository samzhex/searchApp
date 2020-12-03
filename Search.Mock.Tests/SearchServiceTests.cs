using System;
using Search.Mock;
using Xunit;

namespace Search.App.Tests
{
    public class SearchServiceTests
    {
        [Fact]
        public void CheckConstructor()
        {
            var controller = new SearchService();
            Assert.Throws<ArgumentNullException>(() => new SearchService(null));
            Assert.NotNull(controller);
        }

        [Fact]
        public void CheckSearchService()
        {
            var mock = new[]
            {
                new SearchItem {Id = 1, Text = "Chop Suey"},
                new SearchItem {Id = 2, Text = "Toxicity"},
                new SearchItem {Id = 2, Text = "ATWA"},
                new SearchItem {Id = 2, Text = "Aerials"},
            };
            var searchService = new SearchService(mock);
            Assert.NotNull(searchService);
            Assert.Throws<ArgumentNullException>(() => new SearchService(null));
        }
    }
}
