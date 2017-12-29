using Reporting.Interfaces;

namespace Reporting.KeyPerformanceIndicators.PurchPlan
{
    public sealed class POReleaseVsPRDeliveryDate : KeyPerformanceIndicator, ISelectiveVOne
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
