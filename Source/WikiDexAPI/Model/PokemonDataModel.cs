namespace WikiDexAPI.Model
{
    public class PokemonDataModel
    {
        public int NationalNumber { get; set; }

        public string Name { get; set; }

        public string UrlArticle { get; set; }

        public string UrlThumbnail { get; set; }

        public string Description { get; set; }

        public string Type1 { get; set; }

        public string Type2 { get; set; }

        public string Species { get; set; }

        public string Generation { get; set; }

        public decimal Weight { get; set; }

        public decimal Height { get; set; }
    }
}
