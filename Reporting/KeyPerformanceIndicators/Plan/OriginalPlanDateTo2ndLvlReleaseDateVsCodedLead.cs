

namespace Reporting.KeyPerformanceIndicators.Plan
{
    public sealed class OriginalPlanDateTo2ndLvlReleaseDateVsCodedLead : KeyPerformanceIndicator
    {



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
