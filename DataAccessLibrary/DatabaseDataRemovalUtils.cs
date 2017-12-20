namespace AccessDatabaseLibrary
{
    public static class DatabaseDataRemovalUtils
    {
        /// <summary>
        /// Boolean indicating whether or not the data has been removed.
        /// </summary>
        public static bool DataRemoved { get; set; }


        /// <summary>
        /// Number of completed table data removals.
        /// </summary>
        public static int CompletedDataRemovals { get; set; }


        /// <summary>
        /// Number of scheduled data removals to be performed.
        /// </summary>
        public static int ScheduledDataRemovals { get; set; }
    }
}
