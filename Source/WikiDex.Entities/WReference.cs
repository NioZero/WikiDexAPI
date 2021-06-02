using Newtonsoft.Json;
using System.Collections.Generic;

namespace WikiDex.Entities
{
    /// <summary>
    /// WReference
    /// </summary>
    public class WReference
    {
        /// <summary>
        /// hash
        /// </summary>
        public string hash { get; set; }

        /// <summary>
        /// snaks
        /// </summary>
        public Dictionary<string, WSnak[]> snaks { get; set; }

        /// <summary>
        /// snaks_order
        /// </summary>
        [JsonProperty("snaks-order")]
        public List<string> snaks_order { get; set; }
    }
}
