using System;

namespace WikiDex.Entities
{
    /// <summary>
    /// WImageInfo
    /// </summary>
    public class WImageInfo
    {
        /// <summary>
        /// name
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// timestamp
        /// </summary>
        public DateTime timestamp { get; set; }

        /// <summary>
        /// url
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// descriptionurl
        /// </summary>
        public string descriptionurl { get; set; }

        /// <summary>
        /// descriptionshorturl
        /// </summary>
        public string descriptionshorturl { get; set; }

        /// <summary>
        /// ns
        /// </summary>
        public int ns { get; set; }

        /// <summary>
        /// title
        /// </summary>
        public string title { get; set; }
    }
}
