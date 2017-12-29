using Reporting.Interfaces;

namespace Reporting.KeyPerformanceIndicators.Plan
{
    public sealed class OriginalPlanDateTo2ndLvlReleaseDateVsCodedLead : KeyPerformanceIndicator, ISelectiveVTwo
    {
        #region ISelectiveVTwo Properties

        public double SelectiveAverage { get; set; }
        public int SelectiveTotalRecords { get; set; }
        public double SelectivePercentFavorable { get; set; }

        #endregion



        /// <summary>
        /// Default Constructor
        /// </summary>
        public OriginalPlanDateTo2ndLvlReleaseDateVsCodedLead()
        {
            Section = "Plan";
            Name = "(Original Plan Date - 2nd Lvl Release Date) vs Coded Lead-Time";
        }



        /// <summary>
        /// Calculates the selective report for this KPI
        /// </summary>
        public override void RunSelectiveReport(string uniqueFilters)
        {

        }
    }
}
