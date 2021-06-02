using Newtonsoft.Json;
using System;

namespace WikiDex.Entities
{
    /// <summary>
    /// WRevision
    /// </summary>
    public class WRevision
    {
        /// <summary>
        /// user
        /// </summary>
        public string user { get; set; }

        /// <summary>
        /// timestamp
        /// </summary>
        public DateTime timestamp { get; set; }

        /// <summary>
        /// comment
        /// </summary>
        public string comment { get; set; }

        /// <summary>
        /// content
        /// </summary>
        [JsonProperty("*")]
        public string content { get; set; }

    }
}
