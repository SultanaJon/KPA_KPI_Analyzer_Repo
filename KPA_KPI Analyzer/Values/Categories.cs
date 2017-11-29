using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPA_KPI_Analyzer.Values
{
    public static class Categories
    {
        /// <summary>
        /// structure of enumerations of all KPA categories
        /// </summary>
        public struct KpaCategory
        {
            public enum Plan : byte
            {
                PRsAgingNotRel,
                MaterialDue,
            }

            public enum Purch : byte
            {
                PRsAgingRel,
                POFirstRelease,
                POPrevRelease,
                NoConfirmation,
            }

            public enum PurchSub : byte
            {
                PRReleasePORelease,
                POCreationCOnfEntry,
            }

            public enum PurchTotal : byte
            {
                PRRelConfEntry,

            }

            public enum FollowUp : byte
            {
                ConfPlanDate,
                ConfDateUpcomingDel,
                DueTodayLateConf,
            }

            public enum HotJobs : byte
            {
                PrsNotonPO,
                NoConfirmations,
                LateToConfirmed,
            }

            public enum ExcessStockStock : byte
            {
                PrsAgingNotRel,
                PRsAgingRel,
                POCreationThruDelivery,
            }

            public enum ExcessStockOpenOrders : byte
            {
                PrsAgingNotRel,
                PRsAgingRel,
                POCreationThruDelivery,
            }

            public enum CurrPlanVsActual : byte
            {
                CurrPlanDateCurrConfDateOpenPO,
                CurrPlanDateCurrConfDateOpenPOHotJobs
            }
        }


        /// <summary>
        /// Multidimentionaal array containing all the KPA categories.
        /// </summary>
        public static string[][] kpaCategories =
        {
            // Plan
            new string[] { "PRs Aging (Not Released)", "Material Due"},
            // Purch
            new string[] { "PRs Aging (Released)", "PO First Release", "PO Prev Release", "No Confirmation"},
            // Purch Sub
            new string[] { "PR Release to PO Release", "PO Creation to Confirmation Entry"},
            // Purch Total
            new string[] {"PR Release to Confirmation Entry"},
            // Follow Up
            new string[] { "Confirmed Date vs Plan Date", "Confirmed Date for Upcoming Deliveries", "Due Today or Late to Confirmed Date"},
            // Hot Jobs
            new string[] { "PRs (Not on PO) - Hot Jobs Only", "No Confirmations - Hot Jobs Only", "Late to Confirmed - Hot Jobs Only"},
            // Excess Stock - Stock
            new string[] { "Prs Aging (Not Released)", "PRs Aging (Released)", "PO Creation Thru Delivery"},
            // Excess Stock - Open Orders
            new string[] { "Prs Aging (Not Released)", "PRs Aging (Released)", "PO Creation Thru Delivery"},
            // Current Plan vs Actual
            new string[] { "Current Plan Date vs Current Confirmation Date", "Current Plan Date vs Current Confirmation Date - Hot Jobs Only"},
        };



        /// <summary>
        /// structure of enumerations of all KPA categories
        /// </summary>
        public struct KpiCategory
        {
            public enum Plan : byte
            {
                CurrentPlanDateVsPrPlanDate,
                OriginalPlanDate2ndLvlReleaseDatevsCodedLeadTime,
                CurrentPlanDate2ndLvlReleaseDatevsCodedLeadTime
            }

            public enum Purch : byte
            {
                InitialConfirmationDatevsPRPlanDate
            }

            public enum FollowUp : byte
            {
                CurrentConfDateVsInitialConfDate,
                FinalConfirmationDatevsFinalPlanDate,
                ReceiptDatevsCurrentPlanDate,
                ReceiptDatevsOriginalConfirmationDate,
                ReceiptDatevsCurrentConfirmationDate
            }

            public enum PlanTwo : byte
            {
                MaterialDueOriginalPlanDate,
                MaterialDueFinalPlannedDate
            }

            public enum PurchTwo : byte
            {
                PR2ndLvlReleaseDatevsPOCreationDate,
                POCreationDatevsPOReleaseDate,
                POReleaseDatevsPOConfirmationDate
            }

            public enum PurchSub : byte
            {
                PRReleaseDatevsPOReleaseDate,
                POCreationDatevsConfirmationEntryDate
            }

            public enum PurchTotal : byte
            {
                PRReleaseDatetoConfirmationEntryDate
            }

            public enum PurchPlan : byte
            {
                POReleasevsPRDeliveryDate
            }

            public enum Other : byte
            {
                PRsCreated,
                PRsReleased,
                TotalSpend,
                PRValuevsPOValue,
                HotJobPRs
            }
        }



        /// <summary>
        /// Multidimentionaal array containing all the KPA categories.
        /// </summary>
        public static string[][] kpiCategories =
        {
                // Plan One
                new string[] { "Current Plan vs PR Plan Date", "(Original Plan Date - 2nd Lvl Release Date) vs Coded Lead-Time", "(Current Plan Date - 2nd Lvl Release Date) vs Coded Lead-Time"},
                // Purch
                new string[] { "Initial Confirmation Date vs PR Plan Date"},
                // Follow Up
                new string[] { "Current Confirmation Date vs Initial Confirmation Date", "Final Confirmation Date vs Final Plan Date", "Receipt Date vs Current Plan Date", "Receipt Date vs Original Confirmation Date", "Receipt Date vs Current Confirmation Date"},
                // Plan two
                new string[] { "Material Due (Original Planned Date)", "Material Due (Final Planned Date)"},
                // Purch Two
                new string[] { "PR 2nd Lvl Release Date vs PO Creation Date", "PO Creation Date vs PO Release Date", "PO Release Date vs PO Confirmation Date"},
                // Purch Sub
                new string[] { "PR Release Date vs PO Release Date", "PO Creation Date vs Confirmation Entry Date" },
                // Purch Total
                new string[] { "PR Release Date to Confirmation Entry Date"},
                // Purch Plan
                new string[] { "PO Release vs PR Delivery Date" },
                // Other
                new string[] { "PRs Created", "PRs Released", "Total Spend", "PR Value vs PO Value", "Hot Job PRs"},
            };
    }
}
