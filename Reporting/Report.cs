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
            List<KeyPerformanceIndicator> indicators = new List<KeyPerformanceIndicator>();

            // Add the indicators
            indicators.Add(new KeyPerformanceIndicators.Plan.CurrentPlanDateVsPRPlanDate());
            indicators.Add(new KeyPerformanceIndicators.Plan.OriginalPlanDateTo2ndLvlReleaseDateVsCodedLead());
            indicators.Add(new KeyPerformanceIndicators.Plan.CurrentPlanDateTo2ndLvlReleaseDateVsCodedLead());
            indicators.Add(new KeyPerformanceIndicators.Purch.InitialConfirmationDateVsPRPlanDate());
            indicators.Add(new KeyPerformanceIndicators.FollowUp.CurrentConfirmationDateVsInitialConfirmationDate());
            indicators.Add(new KeyPerformanceIndicators.FollowUp.FinalConfirmationDateVsFinalPlanDate());
            indicators.Add(new KeyPerformanceIndicators.FollowUp.ReceiptDateVsCurrentPlanDate());
            indicators.Add(new KeyPerformanceIndicators.FollowUp.ReceiptDateVsOriginalConfirmationDate());
            indicators.Add(new KeyPerformanceIndicators.FollowUp.ReceiptDateVsCurrentConfirmationDate());
            indicators.Add(new KeyPerformanceIndicators.PlanTwo.MaterialDueOriginalPlannedDate());
            indicators.Add(new KeyPerformanceIndicators.PlanTwo.MaterialDueFinalPlannedDate());
            indicators.Add(new KeyPerformanceIndicators.PlanTwo.PrReleaseVsPrCreation());
            indicators.Add(new KeyPerformanceIndicators.PurchTwo.PR2ndLvlReleaseDateVsPOCreationDate());
            indicators.Add(new KeyPerformanceIndicators.PurchTwo.POCreationDateVsPOReleaseDate());
            indicators.Add(new KeyPerformanceIndicators.PurchTwo.POReleaseDateVsPOConfirmationDate());
            indicators.Add(new KeyPerformanceIndicators.PurchSub.PRReleaseDateVsPOReleaseDate());
            indicators.Add(new KeyPerformanceIndicators.PurchSub.POCreationDateVsConfirmationEntry());
            indicators.Add(new KeyPerformanceIndicators.PurchTotal.PRReleaseDateToConfirmationEntry());
            indicators.Add(new KeyPerformanceIndicators.PurchPlan.POReleaseVsPRDeliveryDate());
            indicators.Add(new KeyPerformanceIndicators.Other.PRsCreated());
            indicators.Add(new KeyPerformanceIndicators.Other.PRsReleased());
            indicators.Add(new KeyPerformanceIndicators.Other.TotalSpend());
            indicators.Add(new KeyPerformanceIndicators.Other.PRValueVsPOValue());
            indicators.Add(new KeyPerformanceIndicators.Other.HotJobPRs());

            // Return the list of indicators
            return indicators;
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
