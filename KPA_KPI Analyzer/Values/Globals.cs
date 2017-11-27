namespace KPA_KPI_Analyzer.Values
{
    public static class Globals
    {
        /// <summary>
        ///  What country the application is currently displaying data for.
        /// </summary>
        public static StringUtils.Country FocusedCountry { get; set; }


        /// <summary>
        /// Current selected country to display in the data viewer
        /// </summary>
        public static string CurrCountry { get; set; }


        /// <summary>
        /// Current selected performance to display in the data viewer
        /// </summary>
        public static string CurrPerformance { get; set; }


        /// <summary>
        /// Current selected section to display in the data viewer
        /// </summary>
        public static string CurrSection { get; set; }


        /// <summary>
        /// Current selected category to display in the data viewer
        /// </summary>
        public static string CurrCategory { get; set; }


        /// <summary>
        /// The date the loaded PRPO report was generated.
        /// </summary>
        public static string PrpoGenerationDate { get; set; }
    }
}
