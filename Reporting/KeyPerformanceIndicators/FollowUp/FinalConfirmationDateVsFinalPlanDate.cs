

namespace Reporting.KeyPerformanceIndicators.FollowUp
{
    public sealed class FinalConfirmationDateVsFinalPlanDate : KeyPerformanceIndicator
    {



        /// <summary>
        /// Default Constructor
        /// </summary>
        public FinalConfirmationDateVsFinalPlanDate()
        {
            Section = "Follow Up";
            Name = "Final Confirmation Date vs Final Plan Date";
        }



        /// <summary>
        /// Calculates the selective report for this KPI
        /// </summary>
        public override void RunSelectiveReport(string uniqueFilters)
        {

        }
    }
}
