

namespace Reporting.KeyPerformanceIndicators.FollowUp
{
    public sealed class CurrentConfirmationDateVsInitialConfirmationDate : KeyPerformanceIndicator
    {



        /// <summary>
        /// Default Constructor
        /// </summary>
        public CurrentConfirmationDateVsInitialConfirmationDate()
        {
            Section = "Follow Up";
            Name = "Current Confirmation Date vs Initial Confirmation Date";
        }



        /// <summary>
        /// Calculates the selective report for this KPI
        /// </summary>
        public override void RunSelectiveReport(string uniqueFilters)
        {

        }
    }
}
