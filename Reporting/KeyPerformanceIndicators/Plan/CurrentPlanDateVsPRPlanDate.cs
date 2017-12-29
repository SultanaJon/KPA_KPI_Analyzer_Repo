using Reporting.Interfaces;

namespace Reporting.KeyPerformanceIndicators.Plan
{
    public sealed class CurrentPlanDateVsPRPlanDate : KeyPerformanceIndicator, ISelectiveVTwo
    {
        #region ISelectiveVTwo Properties

        public double SelectiveAverage { get; set; }
        public int SelectiveTotalRecords { get; set; }
        public double SelectivePercentFavorable { get; set; }

        #endregion



        /// <summary>
        /// Default Constructor
        /// </summary>
        public CurrentPlanDateVsPRPlanDate()
        {
            Section = "Plan";
            Name = "Current Plan Date vs PR Plan Date";
        }



        /// <summary>
        /// Calculates the selective report for this KPI
        /// </summary>
        public override void RunSelectiveReport(string uniqueFilters)
        {

        }
    }
}
