using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using WikiDexAPI.Model;

namespace WikiDexAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly ILogger<PokemonController> _logger;

        public PokemonController(ILogger<PokemonController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PokemonController>/5
        [HttpGet("ByNatNumber/{id}")]
        public PokemonDataModel GetByNatNumber(int id)
        {
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
