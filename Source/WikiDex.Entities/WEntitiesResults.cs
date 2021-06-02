using System.Collections.Generic;

namespace WikiDex.Entities
{
    /// <summary>
    /// WEntitiesResults
    /// </summary>
    public class WEntitiesResults
    {
        /// <summary>
        /// entities
        /// </summary>
        public Dictionary<string, WEntity> entities { get; set; }

        /// <summary>
        /// success
        /// </summary>
        public int success { get; set; }
    }
}
