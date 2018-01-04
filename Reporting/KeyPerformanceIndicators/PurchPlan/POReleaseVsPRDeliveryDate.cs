

namespace Reporting.KeyPerformanceIndicators.PurchPlan
{
    public sealed class POReleaseVsPRDeliveryDate : KeyPerformanceIndicator
    {


        /// <summary>
        /// Default Constructor
        /// </summary>
        public POReleaseVsPRDeliveryDate()
        {
            Section = "Purch Plan";
            Name = "PO Release vs PR Delivery Date";
        }


        /// <summary>
        /// Calculates the selective report for this KPA
        /// </summary>
        public override void RunSelectiveReport(string uniqueFilters)
        {

        }
    }
}
