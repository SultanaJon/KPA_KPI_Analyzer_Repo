

namespace Reporting.KeyPerformanceIndicators.PurchSub
{
    public sealed class POCreationDateVsConfirmationEntry : KeyPerformanceIndicator
    {



        /// <summary>
        /// Default Constructor
        /// </summary>
        public POCreationDateVsConfirmationEntry()
        {
            Section = "Purch Sub";
            Name = "PO Creation Date vs Confirmation Entry";
        }



        /// <summary>
        /// Calculates the selective report for this KPI
        /// </summary>
        public override void RunSelectiveReport(string uniqueFilters)
        {

        }
    }
}
