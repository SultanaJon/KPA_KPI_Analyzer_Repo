using Reporting.Interfaces;

namespace Reporting.KeyPerformanceIndicators.PurchTwo
{
    public sealed class PR2ndLvlReleaseDateVsPOCreationDate : KeyPerformanceIndicator, ISelectiveVOne
    {
        #region ISelectiveVOne Properties

        /// <summary>
        /// The Average Days for the Selective Calculation
        /// </summary>
        public double SelectiveAverage { get; set; }


        /// <summary>
        /// The total amount of records for the Selective Calculation
        /// </summary>
        public int SelectiveTotalRecords { get; set; }

        #endregion


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
