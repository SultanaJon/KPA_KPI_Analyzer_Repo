

namespace Reporting.KeyPerformanceIndicators.FollowUp
{
    public sealed class ReceiptDateVsCurrentConfirmationDate : KeyPerformanceIndicator
    {



        /// <summary>
        /// Default Constructor
        /// </summary>
        public ReceiptDateVsCurrentConfirmationDate()
        {
            Section = "Follow Up";
            Name = "Receipt Date vs Current Confirmation Date";
        }



        /// <summary>
        /// Calculates the selective report for this KPI
        /// </summary>
        public override void RunSelectiveReport(string uniqueFilters)
        {

        }
    }
}
