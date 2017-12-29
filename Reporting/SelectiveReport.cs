using Reporting.KeyPerformanceActions;
using Reporting.KeyPerformanceIndicators;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Reporting
{
    public sealed class SelectiveReport : Report
    {
        /// <summary>
        /// The type of selective report
        /// </summary>
        private ReportType Type { get; set; }



        /// <summary>
        /// The details of the KPA Report
        /// </summary>
        private Dictionary<string, List<KeyPerformanceAction>> kpaReport = new Dictionary<string, List<KeyPerformanceAction>>();



        /// <summary>
        /// Property to return the KPA Report
        /// </summary>
        public Dictionary<string, List<KeyPerformanceAction>> KpaReport { get { return kpaReport; } }



        /// <summary>
        /// The details of the KPI Report
        /// </summary>
        private Dictionary<string, List<KeyPerformanceIndicator>> kpiReport = new Dictionary<string, List<KeyPerformanceIndicator>>();



        /// <summary>
        /// Property to return the KPI Report
        /// </summary>
        public Dictionary<string, List<KeyPerformanceIndicator>> KpiReport { get { return kpiReport; } }



        /// <summary>
        /// Initializes a new instance of a SelectiveReport
        /// </summary>
        /// <param name="reportType">The Performance this report will be targeting</param>
        public SelectiveReport(ReportType reportType)
        {

            // The type of selectie report
            Type = reportType;
        }




        /// <summary>
        /// Initializes a new instance of a SelectiveReport
        /// </summary>
        /// <param name="reportType">The Performance this report will be targeting</param>
        /// <param name="filters">The fitlers being applied against the data</param>
        public SelectiveReport(ReportType reportType, List<string> filters)
        {
            // The type of selective report
            Type = reportType;

            // Build the report based on the report type
            if(Type == ReportType.KpaReport)
            {
                BuildKpaReport(filters);
            }
            else
            {
                BuildKpiReport(filters);
            }
        }



        /// <summary>
        /// Builds the KPA report so it can be created (calculated)
        /// </summary>
        internal override void AddActions()
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
        /// Builds the KPI report so it can be created (calculated)
        /// </summary>
        internal override void AddIndicators()
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
        /// Builds the KPA Report based on the filter supplied
        /// </summary>
        /// <param name="filters">The filters chosen by the user</param>
        public void BuildKpaReport(List<string> filters)
        {
            foreach(string filter in filters)
            {
                kpaReport.Add(filter, Actions);
            }
        }




        /// <summary>
        /// Builds the KPI report based on the filters supplied
        /// </summary>
        /// <param name="filters">The filters chosen by the user</param>
        public void BuildKpiReport(List<string> filters)
        {
            foreach(string filter in filters)
            {
                kpiReport.Add(filter, Indicators);
            }
        }




        /// <summary>
        /// Initiates each 
        /// </summary>
        /// <param name="reportType"></param>
        public void RunReport()
        {
            try
            {
                if (Type == ReportType.KpaReport)
                {
                    if (kpaReport.Count > 0)
                    {
                        foreach (string filter in kpaReport.Keys)
                        {
                            foreach (KeyPerformanceAction action in kpaReport[filter])
                            {
                                // Create a new thread to run the calculations and run it.
                                Thread thread = new Thread(() =>
                                {
                                    action.RunSelectiveReport(filter);
                                });

                                thread.Start();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("The KPA Report is not initialized!", "Selective Reporting Error");
                        return;
                    }
                }
                else // The reporting type is KpiReport
                {
                    if (kpiReport.Count > 0)
                    {
                        foreach (string filter in kpaReport.Keys)
                        {
                            foreach (KeyPerformanceIndicator indicator in kpiReport[filter])
                            {
                                // Create a new thread to run the calculations and run it.
                                Thread thread = new Thread(() =>
                                {
                                    indicator.RunSelectiveReport(filter);
                                });
                                thread.Start();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("The KPA Report is not initialized!", "Selective Reporting Error");
                        return;
                    }
                }
            }
            catch(ThreadStateException)
            {
                MessageBox.Show("Thread State Exception was thrown", "Report Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(OutOfMemoryException)
            {
                MessageBox.Show("Out of Memory Exception was thrown", "Report Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
