using System.Collections.Generic;

namespace WikiDex.Entities
{
    /// <summary>
    /// WEntity
    /// </summary>
    public class WEntity
    {
        /// <summary>
        /// type
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// id
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// claims
        /// </summary>
        public Dictionary<string, WClaim[]> claims { get; set; }

    }
}
