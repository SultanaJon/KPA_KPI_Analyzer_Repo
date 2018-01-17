using Reporting.TimeSpans.Templates;
using System.Collections.Generic;

namespace Reporting.KeyPerformanceIndicators
{
    public enum KpiOption
    {
        Plan_PrReleaseDateVsPrCreationDate,
        Plan_CurrentPlanDateVsPrPlanDate,
        Plan_OrigPlanDateMinusPrFullReleaseDateVsCodedLead,
        Plan_CurrentPlanDateMinusPrFullReleaseDateVsCodedLead,
        Purch_InitialConfirmationDateVsPrPlanDate,
        FollowUp_CurrentConfirmationDateVsInitialConfirmationDate,
        FollowUp_FinalConfirmationDateVsInitialConfirmationDate,
        FollowUp_ReceiptDateVsCurrentPlanDate,
        FollowUp_ReceiptDateVsOriginalConfirmationDate,
        FollowUp_ReceiptDateVsCurrentConfirmationDate,
        PlanTwo_MaterialDueOriginalPlannedDate,
        PlanTwo_MaterialDueFinalPlannedDate,
        PurchTwo_PrFullyReleaseDateVsPoCreationDate,
        PurchTwo_PoCreationDateVsPoReleaseDate,
        PurchTwo_PoReleaseDateVsPoConfirmationDate,
        PurchSub_PrReleaseVsPoReleaseDate,
        PurchSub_PoCreationDateVsConfirmationEntryDate,
        PurchTotal_PrReleaseDateToConfirmationEntryDate,
        PurchPlan_PoReleaseVsPrDeliveryDate,
        Other_PrsCreated,
        Other_PrsReleased,
        Other_TotalSpend,
        Other_PrValueVsPoValue,
        Other_HotJobPRs
    }



    public abstract class KeyPerformanceIndicator
    {
        public static string[] options =
        {
            "Plan - PR Release Date vs PR Creation Date",
            "Plan - Current Plan Date vs PR Plan Date",
            "Plan - (Original Plan Date - PR Fully Released Date) vs Coded Lead-Time",
            "Plan - (Current Plan Date - PR Fully Released Date) vs Coded Lead-Time",
            "Purch - Initial Confirmation Date vs PR Plan Date",
            "Follow Up - Current Confirmation Date vs Initial Confirmation Date",
            "Follow Up - Final Confirmation Date vs Final Plan Date",
            "Follow Up - Receipt Date vs Current Plan Date",
            "Follow Up - Receipt Date vs Original Confirmation Date",
            "Follow Up - Receipt Date vs Current Confirmation Date",
            "Plan II - Material Due Original Planned Date",
            "Plan II - Material Due Final Planned Date",
            "Purch II - PR Fully Released Date vs PO Creation Date",
            "Purch II - PO Creation Date vs PO Release Date",
            "Purch II - PO Release Date vs PO Confirmation Date",
            "Purch Sub - PR Release Date vs PO Release Date",
            "Purch Sub - PO Creation Date vs Confirmation Entry Date",
            "Purch Total - PR Release Date to Confirmation Entry Date",
            "Purch Plan - PO Release vs PR Delivery Date",
            "Other - PRs Created",
            "Other - PRs Released",
            "Other - Total Spend",
            "Other - PR Value vs PO Value",
            "Other - Hot Job PRs"
        };


        /// <summary>
        /// Property to access the template data
        /// </summary>
        public Template TemplateBlock { get; set; }



        /// <summary>
        /// The section that this KPI belongs under
        /// </summary>
        public string Section { get; set; }


        /// <summary>
        /// The name of this specific KPI
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
        /// Run the calculation of the KPI
        /// </summary>
        public abstract void Run();
    }
} 
