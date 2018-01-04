

namespace Reporting.KeyPerformanceIndicators.PurchSub
{
    public sealed class PRReleaseDateVsPOReleaseDate : KeyPerformanceIndicator
    {


        /// <summary>
        /// Default Constructor
        /// </summary>
        public PRReleaseDateVsPOReleaseDate()
        {
            Section = "Purch Sub";
            Name = "PR Release Date vs PO Release Date";
        }


        /// <summary>
        /// Calculates the selective report for this KPA
        /// </summary>
        public override void RunSelectiveReport(string uniqueFilters)
        {

        }
    }
}
