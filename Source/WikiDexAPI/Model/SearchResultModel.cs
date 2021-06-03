namespace WikiDexAPI.Model
{
    public class SearchResultModel
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
