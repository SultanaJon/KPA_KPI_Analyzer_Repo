using Reporting.Interfaces;

namespace Reporting.KeyPerformanceIndicators.Other
{
    public sealed class PRValueVsPOValue : KeyPerformanceIndicator, ISelectiveVOne
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
        public PRValueVsPOValue()
        {
            Section = "Other";
            Name = "PR Value vs PO Value";
        }


        /// <summary>
        /// Calculates the selective report for this KPA
        /// </summary>
        public override void RunSelectiveReport(string uniqueFilters)
        {

        }
    }
}
