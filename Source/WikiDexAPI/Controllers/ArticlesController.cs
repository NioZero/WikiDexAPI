using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using WikiDex.Business.Interfaces;

namespace WikiDexAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly ILogger<ArticlesController> _logger;

        private readonly IArticlesService _articlesService;

        public ArticlesController(ILogger<ArticlesController> logger, IArticlesService articlesService)
        {
            _logger = logger;
            _articlesService = articlesService;
        }

        [HttpGet("Search/{search}")]
        public IEnumerable<string> Search(string search)
        {
            _logger.LogTrace($"Search(search='{search}')");

            var results = _articlesService.SearchArticles(search);

            if (results == null)
                yield break;

            foreach (var result in results.OtherMatches)
            {
                yield return result;
            }
        }
    }
}
