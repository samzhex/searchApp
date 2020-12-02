using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace searchApp.Controllers
{ 
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<Search> Get()
        {
            return new[] {
                new Search { Id = 1, Name = "Chop Suey"},
                new Search { Id = 2, Name = "Toxicity" }
            };
        }

        [HttpGet("{query}")]
        public IActionResult Get(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return BadRequest();
            }

            var items = Get();
            var result = items.Any(i => i.Name.ToLower() == query.ToLower());

            if(result)
            {
                return Ok(query);
            }
            return NotFound();

        }
    }
}
