namespace WikiDex.Entities
{
    /// <summary>
    /// WMainsnak
    /// </summary>
    public class WSnak
    {
        /// <summary>
        /// DataValue
        /// </summary>
        public class DataValue
        {
            /// <summary>
            /// value
            /// </summary>
            public dynamic value { get; set; }

            /// <summary>
            /// type
            /// </summary>
            public string type { get; set; }
        }

        /// <summary>
        /// snaktype
        /// </summary>
        public string snaktype { get; set; }

        /// <summary>
        /// property
        /// </summary>
        public string property { get; set; }

        /// <summary>
        /// datavalue
        /// </summary>
        public DataValue datavalue { get; set; }

        /// <summary>
        /// datatype
        /// </summary>
        public string datatype { get; set; }
    }
}
