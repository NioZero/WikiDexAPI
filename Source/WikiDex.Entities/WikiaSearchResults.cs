namespace WikiDex.Entities
{
    /// <summary>
    /// WikiaSearchResults
    /// </summary>
    public class WikiaSearchResults
    {
        /// <summary>
        /// BestMatch
        /// </summary>
        public string BestMatch { get; set; }

        /// <summary>
        /// OtherMatches
        /// </summary>
        public string[] OtherMatches { get; set; }
    }
}
