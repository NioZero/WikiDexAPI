using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WikiDex.Business.Interfaces;
using WikiDex.Business.Web;
using WikiDex.Entities;

namespace WikiDex.Business
{
    public class ArticlesService : IArticlesService
    {
        public WikiaSearchResults FindArticles(string search)
        {
            var parametros = new QueryStringParameters();
            parametros["format"] = "json";
            parametros["action"] = "opensearch";
            parametros["search"] = search;

            /*string url = string.Format("{0}?{1}", ConstantesWebClient.UrlWikiDexAPI, parametros.BuildQueryString(false));

            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;

                string json = client.DownloadString(url);

                var jArr = JArray.Parse(json);

                var results = new WikiaSearchResults();
                results.BestMatch = jArr[0].ToObject<string>();
                results.OtherMatches = jArr[1].ToObject<List<string>>();

                return results;
            }*/

            return new WikiaSearchResults();
        }
    }
}
