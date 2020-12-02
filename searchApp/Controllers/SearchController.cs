using System;
using System.Collections.Generic;
using System.Linq;
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
            _searchService = searchService;
        }


        [HttpGet("{query}")]
        public IActionResult Get(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return BadRequest();
            }

            var result = _searchService.GetResult(query);

            if(result != null)
            {
                return Ok(query);
            }
            return NoContent();

        }
    }
}