using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting
{
    public sealed class SelectiveReport : PerformanceTrack
    {
        public SelectiveReport()
        {

        }

        internal override void AddActions()
        {
            actions.Add(new KeyPerformanceActions.Plan.PRsAgingNotReleased());
            actions.Add(new KeyPerformanceActions.Plan.MaterialDue());
            actions.Add(new KeyPerformanceActions.Purch.PRsAgingReleased());
            actions.Add(new KeyPerformanceActions.Purch.POFirstRelease());
            actions.Add(new KeyPerformanceActions.Purch.POPrevRelease());
            actions.Add(new KeyPerformanceActions.Purch.NoConfirmations());
            actions.Add(new KeyPerformanceActions.PurchSub.PRReleaseToPORelease());
            actions.Add(new KeyPerformanceActions.PurchSub.POCreationToConfirmationEntry());
            actions.Add(new KeyPerformanceActions.PurchTotal.PRReleaseToConfirmationEntry());
            actions.Add(new KeyPerformanceActions.FollowUp.ConfirmedDateVsPlanDate());
            actions.Add(new KeyPerformanceActions.FollowUp.ConfirmedDateForUpcomingDeliveries());
            actions.Add(new KeyPerformanceActions.FollowUp.DueTodayOrLateToConfirmed());
            actions.Add(new KeyPerformanceActions.HotJobs.PRsNotOnPO());
            actions.Add(new KeyPerformanceActions.HotJobs.NoConfirmations());
            actions.Add(new KeyPerformanceActions.HotJobs.LateToConfirmed());
            actions.Add(new KeyPerformanceActions.ExcessStockStock.PRsAgingNotReleased());
            actions.Add(new KeyPerformanceActions.ExcessStockStock.PRsAgingReleased());
            actions.Add(new KeyPerformanceActions.ExcessStockStock.POCreationThruDelivery());
            actions.Add(new KeyPerformanceActions.ExcessStockOpenOrders.PRsAgingNotReleased());
            actions.Add(new KeyPerformanceActions.ExcessStockOpenOrders.PRsAgingReleased());
            actions.Add(new KeyPerformanceActions.ExcessStockOpenOrders.POCreationThruDelivery());
            actions.Add(new KeyPerformanceActions.CurrentPlanVsActual.CurrentPlanDateVsCurrentConfirmationDate());
            actions.Add(new KeyPerformanceActions.CurrentPlanVsActual.CurrentPlanDateVsCurrentConfirmationDateForHotJobs());
        }
    }
}
