using Reporting.KeyPerformanceActions;
using Reporting.KeyPerformanceIndicators;
using System.Collections.Generic;

namespace Reporting
{
    public enum ReportingType
    {
        KpaOverall,
        KpiOverall,
        KpaReport,
        KpiReport,
        ComparisonReport
    }



    public abstract class Report
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        internal Report()
        {

        }


        /// <summary>
        /// Builds the KPA report so it can be created (calculated)
        /// </summary>
        internal List<KeyPerformanceIndicator> GetIndicators()
        {
            List<KeyPerformanceIndicator> indicaters = new List<KeyPerformanceIndicator>();

            // Add the indicators
            indicaters.Add(new KeyPerformanceIndicators.Plan.CurrentPlanDateVsPRPlanDate());
            indicaters.Add(new KeyPerformanceIndicators.Plan.OriginalPlanDateTo2ndLvlReleaseDateVsCodedLead());
            indicaters.Add(new KeyPerformanceIndicators.Plan.CurrentPlanDateTo2ndLvlReleaseDateVsCodedLead());
            indicaters.Add(new KeyPerformanceIndicators.Purch.InitialConfirmationDateVsPRPlanDate());
            indicaters.Add(new KeyPerformanceIndicators.FollowUp.CurrentConfirmationDateVsInitialConfirmationDate());
            indicaters.Add(new KeyPerformanceIndicators.FollowUp.FinalConfirmationDateVsFinalPlanDate());
            indicaters.Add(new KeyPerformanceIndicators.FollowUp.ReceiptDateVsCurrentPlanDate());
            indicaters.Add(new KeyPerformanceIndicators.FollowUp.ReceiptDateVsOriginalConfirmationDate());
            indicaters.Add(new KeyPerformanceIndicators.FollowUp.ReceiptDateVsCurrentConfirmationDate());
            indicaters.Add(new KeyPerformanceIndicators.PlanTwo.MaterialDueOriginalPlannedDate());
            indicaters.Add(new KeyPerformanceIndicators.PlanTwo.MaterialDueFinalPlannedDate());
            indicaters.Add(new KeyPerformanceIndicators.PurchTwo.PR2ndLvlReleaseDateVsPOCreationDate());
            indicaters.Add(new KeyPerformanceIndicators.PurchTwo.POCreationDateVsPOReleaseDate());
            indicaters.Add(new KeyPerformanceIndicators.PurchTwo.POReleaseDateVsPOConfirmationDate());
            indicaters.Add(new KeyPerformanceIndicators.PurchSub.PRReleaseDateVsPOReleaseDate());
            indicaters.Add(new KeyPerformanceIndicators.PurchSub.POCreationDateVsConfirmationEntry());
            indicaters.Add(new KeyPerformanceIndicators.PurchTotal.PRReleaseDateToConfirmationEntry());
            indicaters.Add(new KeyPerformanceIndicators.PurchPlan.POReleaseVsPRDeliveryDate());
            indicaters.Add(new KeyPerformanceIndicators.Other.PRsCreated());
            indicaters.Add(new KeyPerformanceIndicators.Other.PRsReleased());
            indicaters.Add(new KeyPerformanceIndicators.Other.TotalSpend());
            indicaters.Add(new KeyPerformanceIndicators.Other.PRValueVsPOValue());
            indicaters.Add(new KeyPerformanceIndicators.Other.HotJobPRs());


            return indicaters;
        }






        /// <summary>
        /// Builds the KPA report so it can be created (calculated)
        /// </summary>
        internal List<KeyPerformanceAction> GetActions()
        {
            List<KeyPerformanceAction> actions = new List<KeyPerformanceAction>();

            // Add the actions to the report
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

            return actions;
        }
    }
}
