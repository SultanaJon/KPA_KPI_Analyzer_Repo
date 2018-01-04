

namespace Reporting.KeyPerformanceIndicators.PurchTotal
{
    public sealed class PRReleaseDateToConfirmationEntry : KeyPerformanceIndicator
    {



        /// <summary>
        /// Default Constructor
        /// </summary>
        public PRReleaseDateToConfirmationEntry()
        {
            Section = "Purch Total";
            Name = "PR Release Date to Confirmation Entry";
        }



        /// <summary>
        /// Calculates the selective report for this KPI
        /// </summary>
        public override void RunSelectiveReport(string uniqueFilters)
        {

        }
    }
}
