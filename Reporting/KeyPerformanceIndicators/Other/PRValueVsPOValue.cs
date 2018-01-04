

namespace Reporting.KeyPerformanceIndicators.Other
{
    public sealed class PRValueVsPOValue : KeyPerformanceIndicator
    {

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PRValueVsPOValue()
        {
            Section = "Other";
            Name = "PR Value vs PO Value";
        }


        /// <summary>
        /// Calculates the selective report for this KPA
        /// </summary>
        public override void RunSelectiveReport(string uniqueFilters)
        {

        }
    }
}
