namespace DAL
{
    public static class AccessDatabaseUtils
    {
        /// <summary>
        /// Boolean value indicating wheather or not the US PRPO table exists
        /// </summary>
        public static bool US_PRPO_TableExists { get; set; }



        /// <summary>
        /// Boolean vlue indicating whether or not the MX PRPO table exists
        /// </summary>
        public static bool MX_PRPO_TableExists { get; set; }



        /// <summary>
        /// Boolean value indicating whether or not the database exists
        /// </summary>
        public static bool DatabaseExists { get; set; }
    }
}
