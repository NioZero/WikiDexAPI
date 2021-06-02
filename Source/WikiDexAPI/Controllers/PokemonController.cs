using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WikiDex.Business.Interfaces;
using WikiDexAPI.Model;

namespace WikiDexAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly ILogger<PokemonController> _logger;

        private readonly IArticlesService _articlesService;

        public PokemonController(ILogger<PokemonController> logger, IArticlesService articlesService)
        {
            _logger = logger;
            _articlesService = articlesService;
        }

        // GET api/<PokemonController>/5
        [HttpGet("ByNatNumber/{id}")]
        public PokemonDataModel GetByNatNumber(int id)
        {
            _logger.LogTrace($"GetByNatNumber(id={id})");

            // This is temporary
            return new PokemonDataModel()
            {
                NationalNumber = 25,
                Name = "Pikachu",
                Description = "Pikachu es un Pokémon de tipo eléctrico introducido en la primera generación.",
                Types = new[] { "Eléctrico" }
            };
        }
    }
}
