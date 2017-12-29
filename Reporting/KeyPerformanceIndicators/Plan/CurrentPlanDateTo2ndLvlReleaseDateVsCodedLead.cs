using Reporting.Interfaces;

namespace Reporting.KeyPerformanceIndicators.Plan
{
    public sealed class CurrentPlanDateTo2ndLvlReleaseDateVsCodedLead : KeyPerformanceIndicator, ISelectiveVTwo
    {
        #region ISelectiveVTwo Properties

        public double SelectiveAverage { get; set; }
        public int SelectiveTotalRecords { get; set; }
        public double SelectivePercentFavorable { get; set; }

        #endregion



        /// <summary>
        /// Default Constructor
        /// </summary>
        public CurrentPlanDateTo2ndLvlReleaseDateVsCodedLead()
        {
            Section = "Plan";
            Name = "(Current Plan Date - 2nd Lvl Release Date) vs Coded Lead-Time";
        }



        /// <summary>
        /// Calculates the selective report for this KPI
        /// </summary>
        public override void RunSelectiveReport(string uniqueFilters)
        {

        }
    }
}
