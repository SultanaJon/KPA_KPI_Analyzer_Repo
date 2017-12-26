using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting
{
    class ReportingCategories
    {
        public enum ReportingCategory
        {
            PRsAgingNotReleased,
            MaterialDue,
            PRsAgingReleased,
            POFirstRelease,
            POPrevRelease,
            NoConfirmation,
            PRReleaseToPORelease,
            POCreationTOConfirmationEntry,
            PRReleaseToConfirmationEntry,
            ConfirmedDateVsPlanDate,
            ConfirmedDateForUpcomingDeliveries,
            DueTodayOrLateToCofirmed,
            PRsNotOnPO,
            LateToConfirmed,
            POCreationThruDelivery,
            CurrentPlanDateVsCurrentConfirmationDate,
            CurrentPlandDateVsCurrentConfirmationDateForHotJobs,
            CurrentPlanDateVsPRPlanDate,
            OriginalPlanDateTo2ndLvlRelDateVsCodedLead,
            CurrentPlanDateTo2ndLvlRelDateVsCodedLead,
            InitialConfirmationDateVsPRPlanDate,
            CurrentConfirmationDateVsInitialConfirmationDate,
            FinalConfirmationDateVsFinalPlanDate,
            ReceiptDateVsCurrentPlanDate,
            ReceiptDateVsOriginalConfirmationDate,
            ReceiptDateVsCurrentConfirmationDate,
            MaterialDueOriginalPlannedDate,
            MaterialDueFinalPlannedDate,
            PR2ndLvlReleaseDateVsPOCreationDate,
            POCreationDateVsPOReleaseDate,
            POReleaseDateVsPOConfirmationDate,
            PRReleaseDateVsPOReleaseDate,
            POCreationDateVsConfirmationEntryDate,
            POReleaseDateToConfirmationEntryDate,
            POReleaseVsPRDeliveryDate,
            PRCreated,
            PRsReleased,
            TotalSpend,
            PRValueVsPOValue,
            HotJobPRs
        }


        public static string[] reportingCategories =
        {
            "PRs Aging Not Released",
            "Material Due",
            "PRs Aging Released",
            "PO First Release",
            "PO Prev Release",
            "No Confirmation",
            "PR Release to PO Release",
            "PO Creation to Confirmation Entry",
            "PR Release to Confirmation Entry",
            "Confirmed Date Vs Plan Date",
            "Confirmed Date for Upcoming Deliveries",
            "Due Today or Late to Confirmed",
            "PRs Not on PO",
            "Late to Confirmed",
            "PO Creation Thru Delivery",
            "Current Plan Date Vs Current Confirmation Date",
            "Current Plan Date Vs Current Confirmation Date For Hot Jobs",
            "Current Plan Date Vs PR Plan Date",
            "(Original Plan Date - 2nd Lvl Release Date) vs Coded Lead-Time",
            "(Current Plan Date - 2nd Lvl Release Date) vs Coded Lead-Time",
            "Initial Confirmation Date vs PR Plan Date",
            "Current Confirmation Date vs Initial Confirmation Date",
            "Final Confirmation Date vs Final Plan Date",
            "Receipt Date vs Current Plan Date",
            "Receipt Date vs Original Confirmation Date",
            "Receipt Date vs Current Confirmation Date",
            "Material Due (Original Planned Date)",
            "Material Due (Final Planned Ddate)",
            "PR 2nd Lvl Release Date vs PO Release Date",
            "PO Creation Date vs PO Release Date",
            "PO Release Date vs PO Confirmation Date",
            "PR Release Date vs PO Release Date",
            "PO Creation Date vs Confirmation Entry Date",
            "PR Release Date to Confirmation Entry Date",
            "PR Release vs PR Delivery Date",
            "PRs Created",
            "PRs Released",
            "Total Spend",
            "PR Value vs PO Value",
            "Hot Job PRs"
        };
    }
}
