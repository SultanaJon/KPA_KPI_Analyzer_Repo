using Reporting.Interfaces;

namespace Reporting.KeyPerformanceIndicators.FollowUp
{
    public sealed class ReceiptDateVsOriginalConfirmationDate : KeyPerformanceIndicator, ISelectiveVThree
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
        public ReceiptDateVsOriginalConfirmationDate()
        {
            Section = "Follow Up";
            Name = "Receipt Date vs Original Confirmation Date";
        }



        /// <summary>
        /// Calculates the selective report for this KPI
        /// </summary>
        public override void RunSelectiveReport(string uniqueFilters)
        {

        }
    }
}
