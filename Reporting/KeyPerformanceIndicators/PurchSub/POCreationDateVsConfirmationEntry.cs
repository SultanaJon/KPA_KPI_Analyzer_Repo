using Reporting.Interfaces;

namespace Reporting.KeyPerformanceIndicators.PurchSub
{
    public sealed class POCreationDateVsConfirmationEntry : KeyPerformanceIndicator, ISelectiveVThree
    {
        #region ISelectiveVThree Properties

        public double SelectiveAverage { get; set; }
        public int SelectiveTotalRecords { get; set; }
        public double SelectivePercentUnconfirmed { get; set; }
        public double SelectivePercentFavorable { get; set; }

        #endregion



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
