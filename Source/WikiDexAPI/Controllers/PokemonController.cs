using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WikiDex.Business.Config;
using WikiDex.Business.Interfaces;
using WikiDexAPI.Model;

namespace WikiDexAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly ILogger<PokemonController> _logger;

        private readonly IMapper _mapper;

        private readonly IArticlesService _articlesService;

        public PokemonController(ILogger<PokemonController> logger, IMapper mapper, IArticlesService articlesService)
        {
            _logger = logger;
            _mapper = mapper;
            _articlesService = articlesService;
        }

        [HttpGet("ByName/{name}")]
        public async Task<ActionResult> GetByName(string name)
        {
            _logger.LogTrace($"GetByName(name={name})");

            var results = _articlesService.GetArticle(name);

            if (results?.query == null || results.query.pages.ContainsKey("-1"))
            {
                return NoContent();
            }

            var pagina = results.query.pages.First().Value;

            var article = new PokemonDataModel();

            article.Name = pagina.title;
            article.UrlArticle = pagina.fullurl;

            // Buscar la Imagen principal del Artículo
            var infoImagenes = _articlesService.GetImages(pagina.title);
            if (infoImagenes.Any())
            {
                var claveImagen = $"Archivo:{pagina.title}.png";
                var imagePrincipal = infoImagenes.FirstOrDefault(i => i.title.Equals(claveImagen, StringComparison.InvariantCultureIgnoreCase));
                if (imagePrincipal != null)
                {
                    article.UrlThumbnail = imagePrincipal.url;
                }
            }

            string lastRevision = _articlesService.GetLastRevision(pagina.title);

            var matchTitle = WikiRegex.RegexTitulo.Match(lastRevision);
            if (matchTitle.Success)
            {
                lastRevision = lastRevision.Substring(0, matchTitle.Index);
            }

            // Algoritmo para limpiar los {{...}} de manera recursiva
            string description;
            string clean = lastRevision;
            do
            {
                description = clean;
                clean = WikiRegex.RegexTemplate.Replace(description, string.Empty);

            } while (!clean.Equals(description, StringComparison.OrdinalIgnoreCase));

            // Limpiar los Markups [[..]] y '''...'''
            description = WikiRegex.RegexLinks.Replace(clean, "$2");
            description = WikiRegex.RegexMarkupWikipedia.Replace(description, "$1");

            article.Description = description.Trim();

            // Extraer las propiedades del articulo contenidos en el Template {{Cuadro Pokémon ... }}
            var matchStartCuadro = WikiRegex.RegexCuadroPokemonStart.Match(lastRevision);
            if (matchStartCuadro.Success)
            {
                var matchesEndCuadro = WikiRegex.RegexCuadroPokemonEnd.Matches(lastRevision);
                var matchEndCuadro = matchesEndCuadro[matchesEndCuadro.Count - 1];

                var indexStart = matchStartCuadro.Index + matchStartCuadro.Length;
                var cuadroPokemon = lastRevision.Substring(indexStart, matchEndCuadro.Index - indexStart);

                var matchesProperties = WikiRegex.RegexCuadroPokemonProperty.Matches(cuadroPokemon);
                if (matchesProperties.Count > 0)
                {
                    var properties = new Dictionary<string, string>();
                    foreach (Match match in matchesProperties)
                    {
                        properties[match.Groups[1].Value] = match.Groups[2].Value;
                    }

                    article.NationalNumber = properties.ContainsKey("númeronacional") ? int.Parse(properties["númeronacional"]) : 0;
                    article.Type1 = properties.ContainsKey("tipo1") ? properties["tipo1"] : null;
                    article.Type2 = properties.ContainsKey("tipo2") ? properties["tipo2"] : null;
                    article.Species = properties.ContainsKey("especie") ? properties["especie"] : null;
                    article.Generation = properties.ContainsKey("generación") ? properties["generación"] : null;

                    article.Weight = properties.ContainsKey("peso") ? decimal.Parse(properties["peso"], WikiRegex.CultureWikiDex) : 0;
                    article.Height = properties.ContainsKey("altura") ? decimal.Parse(properties["altura"], WikiRegex.CultureWikiDex) : 0;
                }
            }
            
            return Ok(article);
        }

        [HttpGet("ByNatNumber/{id}")]
        public async Task<ActionResult> GetByNatNumber(int id)
        {
            _logger.LogTrace($"GetByNatNumber(id={id})");

            throw new NotImplementedException();
        }
    }
}
