using System.Globalization;
using System.Text.RegularExpressions;

namespace WikiDex.Business.Config
{
    public static class WikiRegex
    {
        public static readonly CultureInfo CultureWikiDex = CultureInfo.GetCultureInfo("es");

        private const string _patronTitulo = @"==+[^=]+==+";

        /// <summary>
        /// RegexMarkupWikipedia
        /// </summary>
        public static readonly Regex RegexTitulo = new Regex(_patronTitulo, RegexOptions.Compiled | RegexOptions.Multiline);

        private const string _patronTemplate = @"\{\{[^\{\}]+\}\}";

        /// <summary>
        /// RegexTemplateWikipedia
        /// </summary>
        public static readonly Regex RegexTemplate = new Regex(_patronTemplate, RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private const string _patronLinks = @"\[\[([^|\]]*\|)?([^]']*)\]\]";

        /// <summary>
        /// RegexMarkupWikipedia
        /// </summary>
        public static readonly Regex RegexLinks = new Regex(_patronLinks, RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private const string _patronMarkup = @"'+([^']+)'+";

        /// <summary>
        /// RegexMarkupWikipedia
        /// </summary>
        public static readonly Regex RegexMarkupWikipedia = new Regex(_patronMarkup, RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private const string _patronCuadroPokemonInicio = @"^\{\{(Cuadro)";

        /// <summary>
        /// RegexMarkupWikipedia
        /// </summary>
        public static readonly Regex RegexCuadroPokemonStart = new Regex(_patronCuadroPokemonInicio, RegexOptions.Compiled | RegexOptions.Multiline);

        private const string _patronCuadroPokemonFin = @"\}\}$";

        /// <summary>
        /// RegexMarkupWikipedia
        /// </summary>
        public static readonly Regex RegexCuadroPokemonEnd = new Regex(_patronCuadroPokemonFin, RegexOptions.Compiled | RegexOptions.Multiline);

        private const string _patronCuadroPokemonPropiedad = @"\| ([^=]+) = (.+)";

        /// <summary>
        /// RegexMarkupWikipedia
        /// </summary>
        public static readonly Regex RegexCuadroPokemonProperty = new Regex(_patronCuadroPokemonPropiedad, RegexOptions.Compiled | RegexOptions.IgnoreCase);
    }
}
