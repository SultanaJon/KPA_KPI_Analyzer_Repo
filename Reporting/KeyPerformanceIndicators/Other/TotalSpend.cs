

namespace Reporting.KeyPerformanceIndicators.Other
{
    public sealed class TotalSpend : KeyPerformanceIndicator
    {


        /// <summary>
        /// Default Constructor
        /// </summary>
        public TotalSpend()
        {
            Section = "Other";
            Name = "Total Spend";
        }


        /// <summary>
        /// Calculates the selective report for this KPA
        /// </summary>
        public override void RunSelectiveReport(string uniqueFilters)
        {

        }
    }
}
