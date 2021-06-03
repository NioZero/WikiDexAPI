using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using WikiDex.Business.Config;
using WikiDex.Business.Interfaces;
using WikiDex.Business.Web;
using WikiDex.Entities;

namespace WikiDex.Business
{
    /// <summary>
    /// WikiDex Article Service
    /// </summary>
    /// <seealso cref="IArticlesService" />
    public class ArticlesService : IArticlesService
    {
        private readonly ILogger<ArticlesService> _logger;

        private readonly IConfiguration _configuration;

        private readonly WikiDexSettings _settings;

        public ArticlesService(ILogger<ArticlesService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;

            _settings = new WikiDexSettings();
            _configuration.GetSection(WikiDexSettings.Key).Bind(_settings);
        }

        /// <summary>
        /// Finds the articles.
        /// </summary>
        /// <param name="search">The search query</param>
        /// <returns></returns>
        public WikiaSearchResults SearchArticles(string search)
        {
            _logger.LogTrace($"SearchArticles(search='{search}')");

            var parametros = new QueryStringParameters();
            parametros["format"] = "json";
            parametros["action"] = "opensearch";
            parametros["search"] = search;

            string url = string.Format("{0}?{1}", _settings.Url, parametros.BuildQueryString(false));

            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;

                string json = client.DownloadString(url);

                var jArr = JArray.Parse(json);

                var results = new WikiaSearchResults();
                results.BestMatch = jArr[0].ToObject<string>();
                results.OtherMatches = jArr[1].ToObject<string[]>();

                return results;
            }
        }

        /// <summary>
        /// Get Article by title
        /// </summary>
        /// <param name="titles">Article title</param>
        /// <returns></returns>
        public WQueryResults GetArticle(string titles)
        {
            _logger.LogTrace($"GetArticle(titles='{titles}')");

            var parametros = new QueryStringParameters();
            parametros["format"] = "json";
            parametros["action"] = "query";
            parametros["titles"] = titles;
            parametros["prop"] = "info";
            parametros["inprop"] = "url";

            string url = string.Format("{0}?{1}", _settings.Url, parametros.BuildQueryString(false));

            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;

                string json = client.DownloadString(url);

                return JsonConvert.DeserializeObject<WQueryResults>(json);
            }
        }

        /// <summary>
        /// Get Images
        /// </summary>
        /// <param name="aifrom"></param>
        /// <returns></returns>
        public IEnumerable<WImageInfo> GetImages(string aifrom)
        {
            _logger.LogTrace($"GetImages(aifrom='{aifrom}')");

            var parametros = new QueryStringParameters();
            parametros["format"] = "json";
            parametros["action"] = "query";
            parametros["list"] = "allimages";
            parametros["aifrom"] = aifrom;

            string url = string.Format("{0}?{1}", _settings.Url, parametros.BuildQueryString(false));

            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;

                string json = client.DownloadString(url);

                var query = JsonConvert.DeserializeObject<WQueryResults>(json);

                return query?.query?.allimages;
            }

        }

        /// <summary>
        /// Get the latest revision from article
        /// </summary>
        /// <param name="pageId">The page identifier.</param>
        /// <returns></returns>
        public string GetLastRevision(string titles)
        {
            _logger.LogTrace($"GetLastRevision(titles='{titles}')");

            var parametros = new QueryStringParameters();
            parametros["format"] = "json";
            parametros["action"] = "query";
            parametros["titles"] = titles;
            parametros["prop"] = "revisions";
            parametros["rvprop"] = "content";

            string url = string.Format("{0}?{1}", _settings.Url, parametros.BuildQueryString(false));

            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;

                string json = client.DownloadString(url);

                var query = JsonConvert.DeserializeObject<WQueryResults>(json);

                return query?.query?.pages?.FirstOrDefault().Value?.revisions?.FirstOrDefault()?.content;
            }
        }
    }
}
