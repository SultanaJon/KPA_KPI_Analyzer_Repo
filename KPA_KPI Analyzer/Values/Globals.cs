using DataImporter.Access;

namespace KPA_KPI_Analyzer.Values
{
    internal static class Globals
    {
        /// <summary>
        /// The SelectedCountry that the user selected to load into the application.
        /// </summary>
        public static AccessInfo.MainTables SelectedCountry { get; set; }



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
    }
}
