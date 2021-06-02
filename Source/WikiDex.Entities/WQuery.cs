using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiDex.Entities
{
    public class WQuery
    {
        /// <summary>
        /// SearchInfo
        /// </summary>
        public class SearchInfo
        {
            /// <summary>
            /// totalhits
            /// </summary>
            public int totalhits { get; set; }

            /// <summary>
            /// suggestion
            /// </summary>
            public string suggestion { get; set; }

            /// <summary>
            /// suggestionsnippet
            /// </summary>
            public string suggestionsnippet { get; set; }
        }

        /// <summary>
        /// pages
        /// </summary>
        public Dictionary<string, WPage> pages { get; set; }

        /// <summary>
        /// search info
        /// </summary>
        public SearchInfo searchinfo { get; set; }

        /// <summary>
        /// search
        /// </summary>
        public WSearch[] search { get; set; }

        /// <summary>
        /// allimages
        /// </summary>
        public WImageInfo[] allimages { get; set; }
    }
}
