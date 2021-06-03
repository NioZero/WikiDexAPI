using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WikiDex.Business.Interfaces;
using WikiDexAPI.Model;

namespace WikiDexAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly ILogger<ArticlesController> _logger;

        private readonly IMapper _mapper;

        private readonly IArticlesService _articlesService;

        public ArticlesController(ILogger<ArticlesController> logger, IMapper mapper, IArticlesService articlesService)
        {
            _logger = logger;
            _mapper = mapper;
            _articlesService = articlesService;
        }

        [HttpGet("Search/{search}")]
        public async Task<ActionResult> Search(string search)
        {
            _logger.LogTrace($"Search(search='{search}')");

            var results = _articlesService.SearchArticles(search);

            if (results == null)
                return NoContent();

            return Ok(_mapper.Map<SearchResultModel>(results));
        }
    }
}
