using Reporting.KeyPerformanceActions;
using Reporting.KeyPerformanceIndicators;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Reporting
{
    public class ComparisonReport : Report
    {

        /// <summary>
        /// A dictionary to act as a comparison report
        /// </summary>
        Dictionary<string, Performance> report;




        /// <summary>
        /// Default constructor
        /// </summary>
        public ComparisonReport()
        {
            report = new Dictionary<string, Performance>();
        }



        /// <summary>
        /// Adds the actions to the report
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
        /// Adds the indicators to the report.
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
        /// Creates the comparison report with Key Performance actions (KPA)
        /// </summary>
        /// <param name="_filters">The list of filters being applied to the report</param>
        /// <param name="_kpa">The Key Performance Action (KPA) the user would like to run the filters against</param>
        public void CreateKpaComparisonReport(List<string> _filters, KpaOption _kpa)
        {
            try
            {
                // Get the performance object for the report
                 Performance performance = GetKpaPerformance(_kpa);
                foreach (string filter in _filters)
                {
                    report.Add(filter, performance);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("There was an error getting the selected KPA performance", "KPA Comparison Report Generation Error");
                return;
            }
        }





        /// <summary>
        /// Creates the comparison report with Key Performance Indicators (KPI)
        /// </summary>
        /// <param name="_filters">The list of filters being applied to the report</param>
        /// <param name="_kpa">The Key Performance Action (KPA) the user would like to run the filters against</param>
        public void CreateKpiComparisonReport(List<string> _filters, KpiOption _kpi)
        {
            try
            {
                // Get the performance object for the report
                Performance performance = GetKpiPerformance(_kpi);
                foreach (string filter in _filters)
                {
                    report.Add(filter, performance);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error getting the selected KPI performance", "KPI Comparison Report Generation Error");
                return;
            }
        }





        /// <summary>
        /// Gets the Key Performance Action (KPA) as a Performance object for the comparison report
        /// </summary>
        /// <param name="_kpaOption">The performance option the user would like to run the filters against.</param>
        /// <returns></returns>
        /// <exception cref="Exception">An exeption is thrown if the KPA Option does not fall in range</exception>
        private Performance GetKpaPerformance(KpaOption _kpaOption)
        {
            // Run against the specific KPA option
            switch (_kpaOption)
            {
                case KpaOption.Plan_PrsAgingNotReleased:
                    return Actions[(int)KpaOption.Plan_PrsAgingNotReleased];
                case KpaOption.Plan_MaterialDue:
                    return Actions[(int)KpaOption.Plan_MaterialDue];
                case KpaOption.Purch_PRsAgingReleased:
                    return Actions[(int)KpaOption.Purch_PRsAgingReleased];
                case KpaOption.Purch_PoFirstRelease:
                    return Actions[(int)KpaOption.Purch_PoFirstRelease];
                case KpaOption.Purch_PoPrevRelease:
                    return Actions[(int)KpaOption.Purch_PoPrevRelease];
                case KpaOption.Purch_NoConfirmation:
                    return Actions[(int)KpaOption.Purch_NoConfirmation];
                case KpaOption.PurchSub_PrReleaseToPoRelease:
                    return Actions[(int)KpaOption.PurchSub_PrReleaseToPoRelease];
                case KpaOption.PurchSub_PoCreationToConfirmationEntry:
                    return Actions[(int)KpaOption.PurchSub_PoCreationToConfirmationEntry];
                case KpaOption.PurchTotal_PrReleaseToConfirmationEntry:
                    return Actions[(int)KpaOption.PurchTotal_PrReleaseToConfirmationEntry];
                case KpaOption.FollowUp_ConfirmedDateVsPlanDate:
                    return Actions[(int)KpaOption.FollowUp_ConfirmedDateVsPlanDate];
                case KpaOption.FollowUp_ConfirmedDateForUpcomingDeliveries:
                    return Actions[(int)KpaOption.FollowUp_ConfirmedDateForUpcomingDeliveries];
                case KpaOption.FollowUp_DueTodayOrLateToConfirmed:
                    return Actions[(int)KpaOption.FollowUp_DueTodayOrLateToConfirmed];
                case KpaOption.HotJobs_PrsNotOnPo:
                    return Actions[(int)KpaOption.HotJobs_PrsNotOnPo];
                case KpaOption.HotJobs_NoConfirmations:
                    return Actions[(int)KpaOption.HotJobs_NoConfirmations];
                case KpaOption.HotJobs_LateToConfirmed:
                    return Actions[(int)KpaOption.HotJobs_LateToConfirmed];
                case KpaOption.ExcessStockStock_PrsAgingNotReleased:
                    return Actions[(int)KpaOption.ExcessStockStock_PrsAgingNotReleased];
                case KpaOption.ExcessStockStock_PrsAgingReleased:
                    return Actions[(int)KpaOption.ExcessStockStock_PrsAgingReleased];
                case KpaOption.ExcessStockStock_PoCreationTruDelivery:
                    return Actions[(int)KpaOption.ExcessStockStock_PoCreationTruDelivery];
                case KpaOption.ExcessStockOpenOrders_PrsAgingNotReleased:
                    return Actions[(int)KpaOption.ExcessStockOpenOrders_PrsAgingNotReleased];
                case KpaOption.ExcessStockOpenOrders_PrsAgingReleased:
                    return Actions[(int)KpaOption.ExcessStockOpenOrders_PrsAgingReleased];
                case KpaOption.ExcessStockOpenOrders_PoCreationTruDelivery:
                    return Actions[(int)KpaOption.ExcessStockOpenOrders_PoCreationTruDelivery];
                case KpaOption.CurrentPlanVsActual_CurrentPlanDateVsCurrentConfirmationDate:
                    return Actions[(int)KpaOption.CurrentPlanVsActual_CurrentPlanDateVsCurrentConfirmationDate];
                case KpaOption.CurrentPlanVsActual_CurrentPlanDateVsCurrentConfirmationDateForHotJobs:
                    return Actions[(int)KpaOption.CurrentPlanVsActual_CurrentPlanDateVsCurrentConfirmationDateForHotJobs];
                default:
                    throw new Exception();
            }
        }





        /// <summary>
        /// Gets the Key Performance Indicator (KPI) as a Performance object for the comparison report
        /// </summary>
        /// <param name="_kpaOption">The performance option the user would like to run the filters against.</param>
        /// <returns></returns>
        private Performance GetKpiPerformance(KpiOption _kpiOption)
        {
            // Run again the specific KPI option
            switch (_kpiOption)
            {
                case KpiOption.Plan_CurrentPlanDateVsPrPlanDate:
                    return Indicators[(int)KpiOption.Plan_CurrentPlanDateVsPrPlanDate];
                case KpiOption.Plan_OrigPlanDateMinusPrFullReleaseDateVsCodedLead:
                    return Indicators[(int)KpiOption.Plan_OrigPlanDateMinusPrFullReleaseDateVsCodedLead];
                case KpiOption.Plan_CurrentPlanDateMinusPrFullReleaseDateVsCodedLead:
                    return Indicators[(int)KpiOption.Plan_CurrentPlanDateMinusPrFullReleaseDateVsCodedLead];
                case KpiOption.Purch_InitialConfirmationDateVsPrPlanDate:
                    return Indicators[(int)KpiOption.Purch_InitialConfirmationDateVsPrPlanDate];
                case KpiOption.FollowUp_CurrentConfirmationDateVsInitialConfirmationDate:
                    return Indicators[(int)KpiOption.FollowUp_CurrentConfirmationDateVsInitialConfirmationDate];
                case KpiOption.FollowUp_FinalConfirmationDateVsInitialConfirmationDate:
                    return Indicators[(int)KpiOption.FollowUp_FinalConfirmationDateVsInitialConfirmationDate];
                case KpiOption.FollowUp_ReceiptDateVsCurrentPlanDate:
                    return Indicators[(int)KpiOption.FollowUp_ReceiptDateVsCurrentPlanDate];
                case KpiOption.FollowUp_ReceiptDateVsOriginalConfirmationDate:
                    return Indicators[(int)KpiOption.FollowUp_ReceiptDateVsOriginalConfirmationDate];
                case KpiOption.FollowUp_ReceiptDateVsCurrentConfirmationDate:
                    return Indicators[(int)KpiOption.FollowUp_ReceiptDateVsCurrentConfirmationDate];
                case KpiOption.PlanTwo_MaterialDueOriginalPlannedDate:
                    return Indicators[(int)KpiOption.PlanTwo_MaterialDueOriginalPlannedDate];
                case KpiOption.PlanTwo_MaterialDueFinalPlannedDate:
                    return Indicators[(int)KpiOption.PlanTwo_MaterialDueFinalPlannedDate];
                case KpiOption.PurchTwo_PrFullyReleaseDateVsPoCreationDate:
                    return Indicators[(int)KpiOption.PurchTwo_PrFullyReleaseDateVsPoCreationDate];
                case KpiOption.PurchTwo_PoCreationDateVsPoReleaseDate:
                    return Indicators[(int)KpiOption.PurchTwo_PoCreationDateVsPoReleaseDate];
                case KpiOption.PurchTwo_PoReleaseDateVsPoConfirmationDate:
                    return Indicators[(int)KpiOption.PurchTwo_PoReleaseDateVsPoConfirmationDate];
                case KpiOption.PurchSub_PrReleaseVsPoReleaseDate:
                    return Indicators[(int)KpiOption.PurchSub_PrReleaseVsPoReleaseDate];
                case KpiOption.PurchSub_PoCreationDateVsConfirmationEntryDate:
                    return Indicators[(int)KpiOption.PurchSub_PoCreationDateVsConfirmationEntryDate];
                case KpiOption.PurchTotal_PrReleaseDateToConfirmationEntryDate:
                    return Indicators[(int)KpiOption.PurchTotal_PrReleaseDateToConfirmationEntryDate];
                case KpiOption.PurchPlan_PoReleaseVsPrDeliveryDate:
                    return Indicators[(int)KpiOption.PurchPlan_PoReleaseVsPrDeliveryDate];
                case KpiOption.Other_PrsCreated:
                    return Indicators[(int)KpiOption.Other_PrsCreated];
                case KpiOption.Other_PrsReleased:
                    return Indicators[(int)KpiOption.Other_PrsReleased];
                case KpiOption.Other_TotalSpend:
                    return Indicators[(int)KpiOption.Other_TotalSpend];
                case KpiOption.Other_PrValueVsPoValue:
                    return Indicators[(int)KpiOption.Other_PrValueVsPoValue];
                case KpiOption.Other_HotJobPRs:
                    return Indicators[(int)KpiOption.Other_HotJobPRs];
                default:
                    throw new Exception();
            }
        }



        /// <summary>
        /// Method that generates the overall report.
        /// </summary>
        public override void RunReport()
        {
            throw new NotImplementedException();
        }
    }
}
