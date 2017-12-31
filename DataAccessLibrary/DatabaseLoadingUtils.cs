namespace DataAccessLibrary
{
    public static class DatabaseLoadingUtils
    {
        /// <summary>
        /// Boolean indicating whether or not the data load process has been started.
        /// </summary>
        public static bool DataLoadProcessStarted { get; set; }

        /// <summary>
        /// Boolean indicating whether or not the data has been loaded.
        /// </summary>
        public static bool DataLoaded { get; set; }


        /// <summary>
        /// Number of completed data loads compared to the number of scheduled data loads.
        /// </summary>
        public static int CompletedDataLoads { get; set; }


        /// <summary>
        /// The number of scheduled data loads to be performed
        /// </summary>
        public static int ScheduledDataLoads { get; set; }

        /// <summary>
        /// Boolean used to indicate whether or not the KPI tables are loaded.
        /// </summary>
        public static bool KPITablesLoaded { get; set; }
    }
}
