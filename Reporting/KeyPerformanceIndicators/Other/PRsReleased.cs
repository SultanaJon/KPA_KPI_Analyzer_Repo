

namespace Reporting.KeyPerformanceIndicators.Other
{
    public sealed class PRsReleased : KeyPerformanceIndicator
    {


        /// <summary>
        /// Default Constructor
        /// </summary>
        public PRsReleased()
        {
            Section = "Other";
            Name = "PRs Released";
        }


        /// <summary>
        /// Calculates the selective report for this KPA
        /// </summary>
        public override void RunSelectiveReport(string uniqueFilters)
        {

        }
    }
}
