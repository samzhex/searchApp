using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Search;

namespace Search.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService ?? throw new ArgumentNullException(nameof(searchService));
        }


        [HttpGet("{query}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SearchItem>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public ActionResult<ICollection<SearchItem>> Get(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return BadRequest();
            }

            var result = _searchService.GetResult(query);

            if (result.Count != 0)
            {
                return Ok();
            }

            return NoContent();

        }
    }
}