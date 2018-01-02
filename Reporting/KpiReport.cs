using Reporting.KeyPerformanceIndicators;
using System.Collections.Generic;

namespace Reporting
{
    public class KpiReport : Report
    {
        Dictionary<string, List<KeyPerformanceIndicator>> report;


        /// <summary>
        /// Default Constructor
        /// </summary>
        public KpiReport()
        {
            report = new Dictionary<string, List<KeyPerformanceIndicator>>();

            // Add the Key Performance Actions to the report
            AddIndicators();
        }



        /// <summary>
        /// Builds the KPA report so it can be created (calculated)
        /// </summary>
        private void AddIndicators()
        {
            Indicators.Add(new KeyPerformanceIndicators.Plan.CurrentPlanDateVsPRPlanDate());
            Indicators.Add(new KeyPerformanceIndicators.Plan.OriginalPlanDateTo2ndLvlReleaseDateVsCodedLead());
            Indicators.Add(new KeyPerformanceIndicators.Plan.CurrentPlanDateTo2ndLvlReleaseDateVsCodedLead());
            Indicators.Add(new KeyPerformanceIndicators.Purch.InitialConfirmationDateVsPRPlanDate());
            Indicators.Add(new KeyPerformanceIndicators.FollowUp.CurrentConfirmationDateVsInitialConfirmationDate());
            Indicators.Add(new KeyPerformanceIndicators.FollowUp.FinalConfirmationDateVsFinalPlanDate());
            Indicators.Add(new KeyPerformanceIndicators.FollowUp.ReceiptDateVsCurrentPlanDate());
            Indicators.Add(new KeyPerformanceIndicators.FollowUp.ReceiptDateVsOriginalConfirmationDate());
            Indicators.Add(new KeyPerformanceIndicators.FollowUp.ReceiptDateVsCurrentConfirmationDate());
            Indicators.Add(new KeyPerformanceIndicators.PlanTwo.MaterialDueOriginalPlannedDate());
            Indicators.Add(new KeyPerformanceIndicators.PlanTwo.MaterialDueFinalPlannedDate());
            Indicators.Add(new KeyPerformanceIndicators.PurchTwo.PR2ndLvlReleaseDateVsPOCreationDate());
            Indicators.Add(new KeyPerformanceIndicators.PurchTwo.POCreationDateVsPOReleaseDate());
            Indicators.Add(new KeyPerformanceIndicators.PurchTwo.POReleaseDateVsPOConfirmationDate());
            Indicators.Add(new KeyPerformanceIndicators.PurchSub.PRReleaseDateVsPOReleaseDate());
            Indicators.Add(new KeyPerformanceIndicators.PurchSub.POCreationDateVsConfirmationEntry());
            Indicators.Add(new KeyPerformanceIndicators.PurchTotal.PRReleaseDateToConfirmationEntry());
            Indicators.Add(new KeyPerformanceIndicators.PurchPlan.POReleaseVsPRDeliveryDate());
            Indicators.Add(new KeyPerformanceIndicators.Other.PRsCreated());
            Indicators.Add(new KeyPerformanceIndicators.Other.PRsReleased());
            Indicators.Add(new KeyPerformanceIndicators.Other.TotalSpend());
            Indicators.Add(new KeyPerformanceIndicators.Other.PRValueVsPOValue());
            Indicators.Add(new KeyPerformanceIndicators.Other.HotJobPRs());
        }




        /// <summary>
        /// Creates the KPA Report
        /// </summary>
        /// <param name="filters"></param>
        public void SetKpiReport(List<string> filters)
        {
            foreach (string filter in filters)
            {
                report.Add(filter, Indicators);
            }
        }





        /// <summary>
        /// Runs the report based on the filter given
        /// </summary>
        public void RunReport()
        {
            if (report.Count > 0)
            {
                foreach (string filter in report.Keys)
                {
                    foreach (KeyPerformanceIndicator action in report[filter])
                    {
                        action.RunSelectiveReport(filter);
                    }
                }
            }
        }
    }
}
