

namespace Reporting.KeyPerformanceIndicators.Other
{
    public sealed class HotJobPRs : KeyPerformanceIndicator
    {


        /// <summary>
        /// Default Constructor
        /// </summary>
        public HotJobPRs()
        {
            Section = "Other";
            Name = "Hot Jobs PRs";
        }


        /// <summary>
        /// Calculates the selective report for this KPA
        /// </summary>
        public override void RunSelectiveReport(string uniqueFilters)
        {

        }
    }
}
