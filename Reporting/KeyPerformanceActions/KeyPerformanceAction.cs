using Filters;
using Reporting.TimeSpans.Templates;
using System.Collections.Generic;

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


    public abstract class KeyPerformanceAction
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
        /// Property to access the template data
        /// </summary>
        public Template TemplateBlock { get; set; }



        /// <summary>
        /// The section that this KPA belongs under
        /// </summary>
        public string Section { get; set; }



        /// <summary>
        /// The name of this specific KPA
        /// </summary>
        public string Name { get; set; }



        /// <summary>
        /// Returns the details of the KPA
        /// </summary>
        public List<string> Details
        {
            get
            {
                List<string> temp = new List<string>();
                temp.Add(Section);
                temp.Add(Name);
                return temp;
            }
        }




        /// <summary>
        /// Default Constructor
        /// </summary>
        public KeyPerformanceAction()
        {
            
        }


        /// <summary>
        /// Method to calculate the comparison of this KPA
        /// </summary>
        public abstract void RunComparison(string _filter, FilterOptions.Options _filterOption);


        /// <summary>
        /// Method to calculate of the KPA
        /// </summary>
        public abstract void RunOverall();
    }
}
