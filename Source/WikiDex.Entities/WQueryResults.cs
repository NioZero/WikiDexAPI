namespace WikiDex.Entities
{
    /// <summary>
    /// WQueryResults
    /// </summary>
    public class WQueryResults
    {
        /// <summary>
        /// batchcomplete
        /// </summary>
        public string batchcomplete { get; set; }

        /// <summary>
        /// continue
        /// </summary>
        public WQueryContinue @continue { get; set; }

        /// <summary>
        /// query
        /// </summary>
        public WQuery query { get; set; }
    }
}
