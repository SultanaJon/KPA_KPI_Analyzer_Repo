

namespace Reporting.KeyPerformanceIndicators.PlanTwo
{
    public sealed class MaterialDueOriginalPlannedDate : KeyPerformanceIndicator
    {



        /// <summary>
        /// Default Constructor
        /// </summary>
        public MaterialDueOriginalPlannedDate()
        {
            Section = "Plan II";
            Name = "Material Due (Original Planned Date)";
        }



        /// <summary>
        /// Calculates the selective report for this KPA
        /// </summary>
        public override void RunSelectiveReport(string uniqueFilters)
        {

        }
    }
}
