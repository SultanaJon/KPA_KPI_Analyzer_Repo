using Reporting.Interfaces;

namespace Reporting.KeyPerformanceIndicators.Purch
{
    public sealed class InitialConfirmationDateVsPRPlanDate : KeyPerformanceIndicator, ISelectiveVThree
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
        public InitialConfirmationDateVsPRPlanDate()
        {
            Section = "Purch";
            Name = "Initial Confirmation Date vs PR Plan Date";
        }



        /// <summary>
        /// Calculates the selective report for this KPI
        /// </summary>
        public override void RunSelectiveReport(string uniqueFilters)
        {

        }
    }
}
