

namespace Reporting.KeyPerformanceIndicators.Purch
{
    public sealed class InitialConfirmationDateVsPRPlanDate : KeyPerformanceIndicator
    {



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
