using System;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Search.App.Controllers;
using Xunit;

namespace Search.App.Tests
{
    public class SearchControllerTests
    {
        [Fact]
        public void CheckConstructor()
        {
            var moq = new Mock<ISearchService>();
            var controller = new SearchController(moq.Object);
            Assert.Throws<ArgumentNullException>(() => new SearchController(null));
            Assert.NotNull(controller);
        }

        [Fact]
        public void GetResult_ShouldReturnBadRequest()
        {
            var moq = new Mock<ISearchService>();
            moq.Setup(m => m.GetResult(It.IsAny<string>()))
                .Returns(new[] {new SearchItem {Id = 1, Text = "Chop Suey"}});
            var controller = new SearchController(moq.Object);

            var result1 = controller.Get(" ");
            var result2 = controller.Get(null);

            Assert.IsType<BadRequestResult>(result1.Result);
            Assert.IsType<BadRequestResult>(result2.Result);
        }

        [Fact]
        public void GetResult_ShouldReturnNoContent()
        {
            var moq = new Mock<ISearchService>();

            var controller = new SearchController(moq.Object);

            var result = controller.Get("fhjdhfjd");

            Assert.IsType<NoContentResult>(result.Result);
        }

        [Fact]
        public void GetResult_ShouldReturnOk()
        {
                var moq = new Mock<ISearchService>();

                moq.Setup(m => m.GetResult(It.IsAny<string>()))
                    .Returns(new[] {new SearchItem {Id = 1, Text = "Chop Suey"}});
                var controller = new SearchController(moq.Object);

                var result = controller.Get("Chop Suey");
                Assert.IsType<OkResult>(result.Result);
        }
    }
}
