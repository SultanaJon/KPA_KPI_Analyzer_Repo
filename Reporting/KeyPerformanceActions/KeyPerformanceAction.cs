namespace Reporting.KeyPerformanceActions
{
    public enum KpaOption
    {
        Plan_PrsAgingNotReleased,
        Plan_MaterialDue,
        Purch_PRsAgingReleased,
        Purch_PoFirstRelease,
        Purch_PoPrevRelease,
        Purch_NoConfirmation,
        PurchSub_PrReleaseToPoRelease,
        PurchSub_PoCreationToConfirmationEntry,
        PurchTotal_PrReleaseToConfirmationEntry,
        FollowUp_ConfirmedDateVsPlanDate,
        FollowUp_ConfirmedDateForUpcomingDeliveries,
        FollowUp_DueTodayOrLateToConfirmed,
        HotJobs_PrsNotOnPo,
        HotJobs_NoConfirmations,
        HotJobs_LateToConfirmed,
        ExcessStockStock_PrsAgingNotReleased,
        ExcessStockStock_PrsAgingReleased,
        ExcessStockStock_PoCreationTruDelivery,
        ExcessStockOpenOrders_PrsAgingNotReleased,
        ExcessStockOpenOrders_PrsAgingReleased,
        ExcessStockOpenOrders_PoCreationTruDelivery,
        CurrentPlanVsActual_CurrentPlanDateVsCurrentConfirmationDate,
        CurrentPlanVsActual_CurrentPlanDateVsCurrentConfirmationDateForHotJobs
    }


    public abstract class KeyPerformanceAction : Performance
    {
        public static string[] options =
        {
            "Plan - PRs Aging (Not Released)",
            "Plan - Material Due",
            "Purch - PRs Aging (Released)",
            "Purch - PO First Release",
            "Purch - PO Prev Release",
            "Purch - No Confirmation",
            "Purch Sub - PR Release to PO Release",
            "Purch Sub - PO Creation to Confirmation Entry",
            "Purch Total - PR Release to Confirmation Entry",
            "Follow Up - Confirmed Date vs Plan Date",
            "Follow Up - Confirmed Date for Upcoming Deliveries",
            "Follow Up - Due Today or Late to Confirmed",
            "Hot Jobs - PRs (Not on PO) - Hot Jobs Only",
            "Hot Jobs - No Confirmations - Hot Jobs Only",
            "Hot Jobs - Late to Confirmed - Hot Jobs Only",
            "Excess Stock - Stock - Prs Aging (Not Released)",
            "Excess Stock - Stock - PRs Aging (Released)",
            "Excess Stock - Stock - PO Creation Thru Delivery",
            "Excess Stock - Open Orders - Prs Aging (Not Released)",
            "Excess Stock - Open Orders - PRs Aging (Released)",
            "Excess Stock - Open Orders - PO Creation Thru Delivery",
            "Current Plan vs Actual - Current Plan Date vs Current Confirmation Date",
            "Current Plan vs Actual - Current Plan Date vs Current Confirmation Date for Hot Jobs"
        };



        /// <summary>
        /// The section that this KPA belongs under
        /// </summary>
        public string Section { get; set; }


        /// <summary>
        /// The name of this specific KPA
        /// </summary>
        public string Name { get; set; }



        /// <summary>
        /// Default Constructor
        /// </summary>
        public KeyPerformanceAction()
        {
            if(1 == 1)
            {
                ;
            }
        }


        /// <summary>
        /// Method to calculate the selective report for this Key Performance Action (KPA)
        /// </summary>
        public abstract void RunSelectiveReport(string filter);


        /// <summary>
        /// Method to calculate the overall report this Key Performance Action (KPA)
        /// </summary>
        public abstract void RunOverallReport();



        /// <summary>
        /// Abstract method to calculate the average of the KPA
        /// </summary>
        internal abstract void CalculateAverage(double _totalDays, int _totalRecords);
    }
}
