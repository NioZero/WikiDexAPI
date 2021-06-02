using System.Collections.Generic;
using WikiDex.Entities;

namespace WikiDex.Business.Interfaces
{
    /// <summary>
    /// Articles Service Definition
    /// </summary>
    public interface IArticlesService
    {
        /// <summary>
        /// Finds the articles.
        /// </summary>
        /// <param name="search">The search query</param>
        /// <returns></returns>
        WikiaSearchResults SearchArticles(string search);

        /// <summary>
        /// Get Article by title
        /// </summary>
        /// <param name="titles">Article title</param>
        /// <returns></returns>
        WQueryResults GetArticle(string titles);

        /// <summary>
        /// Get Images
        /// </summary>
        /// <param name="aifrom"></param>
        /// <returns></returns>
        IEnumerable<WImageInfo> GetImages(string aifrom);

        /// <summary>
        /// Get the latest revision from article
        /// </summary>
        /// <param name="pageId">The page identifier.</param>
        /// <returns></returns>
        string GetLastRevision(string titles);
    }
}
