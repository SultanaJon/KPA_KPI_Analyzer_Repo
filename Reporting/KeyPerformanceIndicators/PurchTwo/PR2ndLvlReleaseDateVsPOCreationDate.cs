

namespace Reporting.KeyPerformanceIndicators.PurchTwo
{
    public sealed class PR2ndLvlReleaseDateVsPOCreationDate : KeyPerformanceIndicator
    {


        /// <summary>
        /// Default Constructor
        /// </summary>
        public PR2ndLvlReleaseDateVsPOCreationDate()
        {
            Section = "Purch II";
            Name = "PR 2nd Lvl Release Date vs PO Creation Date";
        }


        /// <summary>
        /// Calculates the selective report for this KPA
        /// </summary>
        public override void RunSelectiveReport(string uniqueFilters)
        {

        }
    }
}
