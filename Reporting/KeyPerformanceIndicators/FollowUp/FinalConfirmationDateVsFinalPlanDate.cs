using Reporting.Interfaces;

namespace Reporting.KeyPerformanceIndicators.FollowUp
{
    public sealed class FinalConfirmationDateVsFinalPlanDate : KeyPerformanceIndicator, ISelectiveVThree
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
        public FinalConfirmationDateVsFinalPlanDate()
        {
            Section = "Follow Up";
            Name = "Final Confirmation Date vs Final Plan Date";
        }



        /// <summary>
        /// Calculates the selective report for this KPI
        /// </summary>
        public override void RunSelectiveReport(string uniqueFilters)
        {

        }
    }
}
