namespace Reporting.KeyPerformanceIndicators
{
    public enum KpiOption
    {
        Plan_CurrentPlanDateVsPrPlanDate,
        Plan_OrigPlanDateMinusPrFullReleaseDateVsCodedLead,
        Plan_CurrentPlanDateMinusPrFullReleaseDateVsCodedLead,
        Purch_InitialConfirmationDateVsPrPlanDate,
        FollowUp_CurrentConfirmationDateVsPrPlanDate,
        FollowUp_FinalConfirmationDateVsInitialConfirmationDate,
        FollowUp_ReceiptDateVsCurrentPlanDate,
        FollowUp_ReceiptDateVsOriginalConfirmationDate,
        FollowUp_ReceiptDateVsCurrentConfirmationDate,
        PlanTwo_MaterialDueOriginalPlannedDate,
        PlanTwo_MaterialDueFinalPlannedDate,
        PurchTwo_PrFullyReleaseDateVsPoReleaseDate,
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
        /// The section that this KPI belongs under
        /// </summary>
        public string Section { get; set; }


        /// <summary>
        /// The name of this specific KPI
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Method to calculate the selective report for this Key Performance Indicator (KPI)
        /// </summary>
        public abstract void RunSelectiveReport(string uniqueFilters);
    }
}
