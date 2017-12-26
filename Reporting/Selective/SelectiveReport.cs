using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.KeyPerformanceActions;

namespace Reporting.Selective
{
    class SelectiveReport : Report
    {
        Dictionary<string, List<KeyPerformanceAction>> kpaReport;
        Dictionary<string, List<KeyPerformanceIndicator>> kpiReport;



        public SelectiveReport()
        {
            kpaReport = new Dictionary<string, List<KeyPerformanceAction>>();
            kpiReport = new Dictionary<string, List<KeyPerformanceIndicator>>();
        }



        /// <summary>
        /// Adds the Key Performance Actions (KPAs) to the report.
        /// </summary>
        internal override void AddActions()
        {
            Actions.Add(new KeyPerformanceActions.Plan.PRsAgingNotReleased());
            Actions.Add(new KeyPerformanceActions.Plan.MaterialDue());
            //Actions.Add(new KeyPerformanceActions.Purch.PRsAgingReleased());
            //Actions.Add(new KeyPerformanceActions.Purch.POFirstRelease());
            //Actions.Add(new KeyPerformanceActions.Purch.POPrevRelease());
            //Actions.Add(new KeyPerformanceActions.Purch.NoConfirmation());
            //Actions.Add(new KeyPerformanceActions.PurchSub.PRReleaseToPORelease());
            //Actions.Add(new KeyPerformanceActions.PurchSub.POCreationToConfirmationEntry());
            //Actions.Add(new KeyPerformanceActions.PurchTotal.PRReleaseToCofirmationEntry());
            //Actions.Add(new KeyPerformanceActions.FollowUp.ConfirmedDateVsPlanDate());
            //Actions.Add(new KeyPerformanceActions.FollowUp.ConfirmedDateForUpcomingDeliveries());
            //Actions.Add(new KeyPerformanceActions.FollowUp.DueTodayOrLateToConfirmed());
            //Actions.Add(new KeyPerformanceActions.HotJobs.PRsNotOnPO());
            //Actions.Add(new KeyPerformanceActions.HotJobs.NoConfirmations());
            //Actions.Add(new KeyPerformanceActions.HotJobs.LateToConfirmed());
            //Actions.Add(new KeyPerformanceActions.ExcessStockStock.PRsAgingNotReleased());
            //Actions.Add(new KeyPerformanceActions.ExcessStockStock.PRsAgingReleased());
            //Actions.Add(new KeyPerformanceActions.ExcessStockStock.POCreationThruDelivery());
            //Actions.Add(new KeyPerformanceActions.ExcessStockOpenOrders.PRsAgingNotReleased());
            //Actions.Add(new KeyPerformanceActions.ExcessStockOpenOrders.PRsAgingReleased());
            //Actions.Add(new KeyPerformanceActions.ExcessStockOpenOrders.POCreationThruDelivery());
            //Actions.Add(new KeyPerformanceActions.CurrentPlanVsActual.CurrentPlanDateVsCurrenConfirmationDate());
            //Actions.Add(new KeyPerformanceActions.CurrentPlanVsActual.CurrentPlanDateVsCurrentConfrimationDateForHotJobs());

        }




        /// <summary>
        /// Adds the Key Performance Indicators (KPIs) to the report.
        /// </summary>
        internal override void AddIndicators()
        {
            //Indicators.Add(new KeyPerformanceIndicators.Plan.CurrentPlanDateVsPRPlanDate());
            //Indicators.Add(new KeyPerformanceIndicators.Plan.OrigPlanDateMinus2ndLvlReleaseDateVsCodedLead());
            //Indicators.Add(new KeyPerformanceIndicators.Plan.CurrentPlanDateMinus2ndLvlReleaseDateVsCodedLead());
            //Indicators.Add(new KeyPerformanceIndicators.Purch.InitialConfrimationDateVsPRPlanDate());
            //Indicators.Add(new KeyPerformanceIndicators.FollowUp.CurrentConfirmationDateVsInitialConfirmationDate());
            //Indicators.Add(new KeyPerformanceIndicators.FollowUp.FinalConfirmationDateVsFinalPlanDate());
            //Indicators.Add(new KeyPerformanceIndicators.FollowUp.ReceiptDateVsCurrentPlanDate());
            //Indicators.Add(new KeyPerformanceIndicators.FollowUp.ReceiptDateVsOriginalConfimationDate());
            //Indicators.Add(new KeyPerformanceIndicators.FollowUp.ReceiptDateVsCurrentConfirmationDate());
            //Indicators.Add(new KeyPerformanceIndicators.PlanTwo.MaterialDueOriginalPlanDate());
            //Indicators.Add(new KeyPerformanceIndicators.PlanTwo.MaterialDueFinalPlannedDate());
            //Indicators.Add(new KeyPerformanceIndicators.PurchTwo.PR2ndLvlReleaseDateVsPOCreationDate());
            //Indicators.Add(new KeyPerformanceIndicators.PurchTwo.POCreationDateVsPOReleaseDate());
            //Indicators.Add(new KeyPerformanceIndicators.PurchTwo.POReleaseDateVsPOConfirmationDate());
            //Indicators.Add(new KeyPerformanceIndicators.PurchSub.PRReleaseDateVsPOReleaseDate());
            //Indicators.Add(new KeyPerformanceIndicators.PurchSub.POCreationDateVsConfirmationEntry());
            //Indicators.Add(new KeyPerformanceIndicators.PurchTotal.PRReleaseDateToConfirmationEntryDate());
            //Indicators.Add(new KeyPerformanceIndicators.PurchPlan.POReleaseVsPRDeliveryDate());
            //Indicators.Add(new KeyPerformanceIndicators.Other.PRsCreated());
            //Indicators.Add(new KeyPerformanceIndicators.Other.PRsReleased());
            //Indicators.Add(new KeyPerformanceIndicators.Other.TotalSpend());
            //Indicators.Add(new KeyPerformanceIndicators.Other.PRValueVsPOValue());
            //Indicators.Add(new KeyPerformanceIndicators.Other.HotJobPRs());
        }



        /// <summary>
        /// Calcualte the selective report for each action contained within the report.
        /// </summary>
        public void CalculateSelectiveKpas(List<string> selections)
        {
            foreach(string selection in selections)
            {
                kpaReport.Add(selection, Actions);
            }


            foreach(string filter in kpaReport.Keys)
            {
                foreach(List<KeyPerformanceAction> actionList in kpaReport.Values)
                {
                    foreach(KeyPerformanceAction kpa in actionList)
                    {
                        kpa.CalculateSelectiveReport(filter);
                    }
                }
            }
        }





        /// <summary>
        /// Calculate the selective report for each indicator contained within the report.
        /// </summary>
        public void CalculateSelectiveKpis(List<string> selections)
        {
            foreach(string selection in selections)
            {
                kpiReport.Add(selection, Indicators);
            }


            foreach(KeyPerformanceIndicator indicator in Indicators)
            {
                indicator.CalculateSelectiveReport();
            }
        }
    }
}
