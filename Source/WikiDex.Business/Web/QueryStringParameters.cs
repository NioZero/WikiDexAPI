using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace WikiDex.Business.Web
{
    public class QueryStringParameters : NameValueCollection
    {
        /// <summary>
        /// Factory method to initialize an <see cref="QueryStringParameters"/> from a query string
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        public static QueryStringParameters FromQueryString(string queryString)
            => new QueryStringParameters
                {
                    HttpUtility.ParseQueryString(queryString)
                };

        /// <summary>
        /// Build a query string using the parameters collection
        /// </summary>
        /// <param name="applyUrlEncode">If <c>true</c> the string will be encoded before</param>
        /// <returns></returns>
        public string BuildQueryString(bool applyUrlEncode = true)
            => string.Join("&", applyUrlEncode
                                        ? Array.ConvertAll(AllKeys, key => string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(this[key])))
                                        : Array.ConvertAll(AllKeys, key => string.Format("{0}={1}", key, this[key])));

        /// <summary>
        /// Convert the current collection into a Dictionary
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, string> ToDictionary() => AllKeys.ToDictionary(k => k, k => this[k]);
    }
}
