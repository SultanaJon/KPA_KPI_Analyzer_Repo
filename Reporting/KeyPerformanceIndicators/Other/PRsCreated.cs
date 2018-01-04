

namespace Reporting.KeyPerformanceIndicators.Other
{
    public sealed class PRsCreated : KeyPerformanceIndicator
    {


        /// <summary>
        /// Default Constructor
        /// </summary>
        public PRsCreated()
        {
            Section = "Other";
            Name = "PRs Created";
        }


        /// <summary>
        /// Calculates the selective report for this KPA
        /// </summary>
        public override void RunSelectiveReport(string uniqueFilters)
        {

        }
    }
}
