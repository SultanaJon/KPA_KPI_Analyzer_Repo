

namespace Reporting.KeyPerformanceIndicators.PlanTwo
{
    public sealed class MaterialDueFinalPlannedDate : KeyPerformanceIndicator
    {



        /// <summary>
        /// Default Constructor
        /// </summary>
        public MaterialDueFinalPlannedDate()
        {
            Section = "Plan II";
            Name = "Material Due (Final Planned Date)";
        }



        /// <summary>
        /// Calculates the selective report for this KPA
        /// </summary>
        public override void RunSelectiveReport(string uniqueFilters)
        {

        }
    }
}
