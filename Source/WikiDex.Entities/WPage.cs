using System;

namespace WikiDex.Entities
{
    /// <summary>
    /// WPage
    /// </summary>
    public class WPage
    {
        /// <summary>
        /// pageid
        /// </summary>
        public long pageid { get; set; }

        /// <summary>
        /// ns
        /// </summary>
        public int ns { get; set; }

        /// <summary>
        /// title
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// index
        /// </summary>
        public int index { get; set; }

        /// <summary>
        /// contentmodel
        /// </summary>
        public string contentmodel { get; set; }

        /// <summary>
        /// pagelanguage
        /// </summary>
        public string pagelanguage { get; set; }

        /// <summary>
        /// pagelanguagehtmlcode
        /// </summary>
        public string pagelanguagehtmlcode { get; set; }

        /// <summary>
        /// touched
        /// </summary>
        public DateTime touched { get; set; }

        /// <summary>
        /// lastrevid
        /// </summary>
        public long lastrevid { get; set; }

        /// <summary>
        /// length
        /// </summary>
        public int length { get; set; }

        /// <summary>
        /// extract
        /// </summary>
        public string extract { get; set; }

        /// <summary>
        /// fullurl
        /// </summary>
        public string fullurl { get; set; }

        /// <summary>
        /// editurl
        /// </summary>
        public string editurl { get; set; }

        /// <summary>
        /// canonicalurl
        /// </summary>
        public string canonicalurl { get; set; }

        /// <summary>
        /// imagerepository
        /// </summary>
        public string imagerepository { get; set; }

        /// <summary>
        /// imageinfo
        /// </summary>
        public WImageInfo[] imageinfo { get; set; }

        /// <summary>
        /// invalidreason
        /// </summary>
        public string invalidreason { get; set; }

        /// <summary>
        /// invalid
        /// </summary>
        public string invalid { get; set; }

        /// <summary>
        /// revisions
        /// </summary>
        public WRevision[] revisions { get; set; }
    }
}
