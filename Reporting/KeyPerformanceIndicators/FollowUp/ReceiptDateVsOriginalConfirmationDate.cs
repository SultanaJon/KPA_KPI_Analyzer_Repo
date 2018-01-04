

namespace Reporting.KeyPerformanceIndicators.FollowUp
{
    public sealed class ReceiptDateVsOriginalConfirmationDate : KeyPerformanceIndicator
    {



        /// <summary>
        /// Default Constructor
        /// </summary>
        public ReceiptDateVsOriginalConfirmationDate()
        {
            Section = "Follow Up";
            Name = "Receipt Date vs Original Confirmation Date";
        }



        /// <summary>
        /// Calculates the selective report for this KPI
        /// </summary>
        public override void RunSelectiveReport(string uniqueFilters)
        {

        }
    }
}
