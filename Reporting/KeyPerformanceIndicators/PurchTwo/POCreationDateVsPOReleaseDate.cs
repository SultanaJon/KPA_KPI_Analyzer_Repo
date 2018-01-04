

namespace Reporting.KeyPerformanceIndicators.PurchTwo
{
    public sealed class POCreationDateVsPOReleaseDate : KeyPerformanceIndicator
    {


        /// <summary>
        /// Default Constructor
        /// </summary>
        public POCreationDateVsPOReleaseDate()
        {
            Section = "Purch II";
            Name = "PO Creation Date vs PO Release Date";
        }


        /// <summary>
        /// Calculates the selective report for this KPA
        /// </summary>
        public override void RunSelectiveReport(string uniqueFilters)
        {

        }
    }
}
