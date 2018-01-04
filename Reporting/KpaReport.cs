using Reporting.KeyPerformanceActions;
using System.Collections.Generic;

namespace Reporting
{
    public class KpaReport : Report
    {
        /// <summary>
        /// Private instance of a KPA Report
        /// </summary>
        private static KpaReport kpaReportInstance = new KpaReport();


        /// <summary>
        /// Property to return the instance of the KPA Report
        /// </summary>
        public static KpaReport KpaReportInstance { get { return kpaReportInstance; } }


        /// <summary>
        /// The contents of the KPA Report
        /// </summary>
        Dictionary<string, List<KeyPerformanceAction>> report;


        /// <summary>
        /// Default Private Constructor
        /// </summary>
        private KpaReport()
        {
            report = new Dictionary<string, List<KeyPerformanceAction>>();

            // Check if any other report have already created the actions
            if(!ActionsSet)
            {
                // Add the Key Performance Actions to the report
                AddActions();
                ActionsSet = true;
            }
        }




        /// <summary>
        /// Creates a new instance of a KPA Report
        /// </summary>
        public static void CreateNewInstance()
        {
            // Creates a new instance of the report
            kpaReportInstance = new KpaReport();
        }



        /// <summary>
        /// Builds the KPA report so it can be created (calculated)
        /// </summary>
        private void AddActions()
        {
            Actions.Add(new KeyPerformanceActions.Plan.PRsAgingNotReleased());
            Actions.Add(new KeyPerformanceActions.Plan.MaterialDue());
            Actions.Add(new KeyPerformanceActions.Purch.PRsAgingReleased());
            Actions.Add(new KeyPerformanceActions.Purch.POFirstRelease());
            Actions.Add(new KeyPerformanceActions.Purch.POPrevRelease());
            Actions.Add(new KeyPerformanceActions.Purch.NoConfirmations());
            Actions.Add(new KeyPerformanceActions.PurchSub.PRReleaseToPORelease());
            Actions.Add(new KeyPerformanceActions.PurchSub.POCreationToConfirmationEntry());
            Actions.Add(new KeyPerformanceActions.PurchTotal.PRReleaseToConfirmationEntry());
            Actions.Add(new KeyPerformanceActions.FollowUp.ConfirmedDateVsPlanDate());
            Actions.Add(new KeyPerformanceActions.FollowUp.ConfirmedDateForUpcomingDeliveries());
            Actions.Add(new KeyPerformanceActions.FollowUp.DueTodayOrLateToConfirmed());
            Actions.Add(new KeyPerformanceActions.HotJobs.PRsNotOnPO());
            Actions.Add(new KeyPerformanceActions.HotJobs.NoConfirmations());
            Actions.Add(new KeyPerformanceActions.HotJobs.LateToConfirmed());
            Actions.Add(new KeyPerformanceActions.ExcessStockStock.PRsAgingNotReleased());
            Actions.Add(new KeyPerformanceActions.ExcessStockStock.PRsAgingReleased());
            Actions.Add(new KeyPerformanceActions.ExcessStockStock.POCreationThruDelivery());
            Actions.Add(new KeyPerformanceActions.ExcessStockOpenOrders.PRsAgingNotReleased());
            Actions.Add(new KeyPerformanceActions.ExcessStockOpenOrders.PRsAgingReleased());
            Actions.Add(new KeyPerformanceActions.ExcessStockOpenOrders.POCreationThruDelivery());
            Actions.Add(new KeyPerformanceActions.CurrentPlanVsActual.CurrentPlanDateVsCurrentConfirmationDate());
            Actions.Add(new KeyPerformanceActions.CurrentPlanVsActual.CurrentPlanDateVsCurrentConfirmationDateForHotJobs());
        }




        /// <summary>
        /// Creates the KPA Report
        /// </summary>
        /// <param name="filters"></param>
        public void SetKpaReport(List<string> filters)
        {
            foreach(string filter in filters)
            {
                report.Add(filter, Actions);
            }
        }





        /// <summary>
        /// Runs the report based on the filter given
        /// </summary>
        public void RunReport()
        {
            if(report.Count > 0)
            {
                foreach(string filter in report.Keys)
                {
                    foreach(KeyPerformanceAction action in report[filter])
                    {
                        action.RunSelectiveReport(filter);
                    }
                }
            }
        }
    }
}
