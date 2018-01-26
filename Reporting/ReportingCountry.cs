namespace Reporting
{
    /// <summary>
    /// Index values for the handled coutries.
    /// </summary>
    public enum Country
    {
        UnitedStates,
        Mexico
    }




    public static class ReportingCountry
    {
        /// <summary>
        /// Array of countries that the application handles.
        /// </summary>
        public static string[] countries =
        {
            "United States",
            "Mexico"
        };



        /// <summary>
        /// The target country for the reporting
        /// </summary>
        public static Country TargetCountry { get; set; }
    }
}
