namespace Reporting.KeyPerformanceActions
{
    public abstract class KeyPerformanceAction
    {
        /// <summary>
        /// The section that this KPA belongs under
        /// </summary>
        public string Section { get; set; }


        /// <summary>
        /// The name of this specific KPA
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Method to calculate the selective report for this Key Performance Action KPA
        /// </summary>
        public abstract void RunSelectiveReport(string filter);
    }
}
