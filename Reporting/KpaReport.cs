using Reporting.KeyPerformanceActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting
{
    public class KpaReport : Report
    {
        Dictionary<string, List<KeyPerformanceAction>> actions;


        /// <summary>
        /// Default Constructor
        /// </summary>
        public KpaReport()
        {
            actions = new Dictionary<string, List<KeyPerformanceAction>>();

            // Add the Key Performance Actions to the report
            AddActions();
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
                actions.Add(filter, Actions);
            }
        }





        /// <summary>
        /// Runs the report based on the filter given
        /// </summary>
        public void RunReport()
        {
            if(actions.Count > 0)
            {
                foreach(string filter in actions.Keys)
                {
                    foreach(KeyPerformanceAction action in actions[filter])
                    {
                        action.RunSelectiveReport(filter);
                    }
                }
            }
        }
    }
}
