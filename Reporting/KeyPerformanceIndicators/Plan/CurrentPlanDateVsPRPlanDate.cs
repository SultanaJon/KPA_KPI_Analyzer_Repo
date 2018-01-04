

namespace Reporting.KeyPerformanceIndicators.Plan
{
    public sealed class CurrentPlanDateVsPRPlanDate : KeyPerformanceIndicator
    {



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
