

namespace Reporting.KeyPerformanceIndicators.Plan
{
    public sealed class CurrentPlanDateTo2ndLvlReleaseDateVsCodedLead : KeyPerformanceIndicator
    {



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
