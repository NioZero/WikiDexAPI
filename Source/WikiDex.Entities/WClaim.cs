namespace WikiDex.Entities
{
    /// <summary>
    /// WClaim
    /// </summary>
    public class WClaim
    {
        /// <summary>
        /// mainsnak
        /// </summary>
        public WSnak mainsnak { get; set; }

        /// <summary>
        /// type
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// id
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// rank
        /// </summary>
        public string rank { get; set; }

        /// <summary>
        /// references
        /// </summary>
        public WReference[] references { get; set; }
    }
}
