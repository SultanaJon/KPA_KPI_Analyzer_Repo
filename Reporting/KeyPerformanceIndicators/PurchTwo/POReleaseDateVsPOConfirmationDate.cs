

namespace Reporting.KeyPerformanceIndicators.PurchTwo
{
    public sealed class POReleaseDateVsPOConfirmationDate : KeyPerformanceIndicator
    {



        /// <summary>
        /// Default Constructor
        /// </summary>
        public POReleaseDateVsPOConfirmationDate()
        {
            Section = "Purch II";
            Name = "PO Release Date vs PO Confirmation Date";
        }



        /// <summary>
        /// Calculates the selective report for this KPI
        /// </summary>
        public override void RunSelectiveReport(string uniqueFilters)
        {

        }
    }
}
