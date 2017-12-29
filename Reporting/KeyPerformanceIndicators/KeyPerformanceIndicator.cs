namespace Reporting.KeyPerformanceIndicators
{
    public abstract class KeyPerformanceIndicator
    {
        /// <summary>
        /// The section that this KPI belongs under
        /// </summary>
        public string Section { get; set; }


        /// <summary>
        /// The name of this specific KPI
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Method to calculate the selective report for this Key Performance Indicator (KPI)
        /// </summary>
        public abstract void RunSelectiveReport(string uniqueFilters);
    }
}
