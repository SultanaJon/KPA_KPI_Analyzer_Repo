

namespace Reporting.KeyPerformanceIndicators.FollowUp
{
    public sealed class ReceiptDateVsCurrentPlanDate : KeyPerformanceIndicator
    {



        /// <summary>
        /// Default Constructor
        /// </summary>
        public ReceiptDateVsCurrentPlanDate()
        {
            Section = "Follow Up";
            Name = "Receipt Date vs Current Plan Date";
        }



        /// <summary>
        /// Calculates the selective report for this KPI
        /// </summary>
        public override void RunSelectiveReport(string uniqueFilters)
        {

        }
    }
}
