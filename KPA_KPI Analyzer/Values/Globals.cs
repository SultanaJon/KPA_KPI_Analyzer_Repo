﻿namespace KPA_KPI_Analyzer.Values
{
    internal static class Globals
    {
        public static int ServicePOCategory = 9;


        public static Countries FocusedCountry { get; set; }

        public static string CountryTableName
        {
            get
            {
                if (FocusedCountry == Countries.UnitedStates)
                {
                    //Logger.Log(AppDirectoryUtils.LogFiles.AppEvents, "United States");
                    return DatabaseUtils.PRPOCommands.mainTableNames[(int)DatabaseUtils.PRPOCommands.DatabaseTables.MainTables.US_PRPO];
                }
                else
                {
                    //Logger.Log(AppDirectoryUtils.LogFiles.AppEvents, "Mexico");
                    return DatabaseUtils.PRPOCommands.mainTableNames[(int)DatabaseUtils.PRPOCommands.DatabaseTables.MainTables.MX_PRPO];
                }
            }
        }



        /// <summary>
        /// Current selected country to display in the data viewer
        /// </summary>
        public static string CurrCountry { get; set; }


        /// <summary>
        /// Current selected performance to display in the data viewer
        /// </summary>
        public static string CurrPerformance { get; set; }


        /// <summary>
        /// Current selected section to display in the data viewer
        /// </summary>
        public static string CurrSection { get; set; }



        /// <summary>
        /// Current selected category to display in the data viewer
        /// </summary>
        public static string CurrCategory { get; set; }




        /// <summary>
        /// The date the loaded PRPO report was generated.
        /// </summary>
        public static string PrpoGenerationDate { get; set; }



        public enum Countries
        {
            UnitedStates,
            Mexico
        }

        public static string[] countries =
        {
            "United States",
            "Mexico"
        };


        public enum KPA_Sections
        {
            Plan,
            Purch,
            PurchSub,
            PurchTotal,
            PurchPlanTotal,
            FollowUp,
            Cancellations,
            NCRs,
            HotJobs,
            ExcessStock_Stock,
            ExcessStock_OpenOrders,
            CurrPlanActual
        }


        public static string[] kpaSections = {
            "Plan",
            "Purch",
            "Purch Sub",
            "Purch Total",
            "Purch Plan Total",
            "Follow Up",
            "Cancellations",
            "NCRs",
            "Hot Jobs",
            "Excess Stock - Stock",
            "Excess Stock - Open Orders",
            "Current Plan vs Actual"
        };



        public struct KPA_Categories
        {
            public enum Plan
            {
                PlannedOrderAging,
                PRsAgingNotRel,
                MaterialDue,
            }

            public enum Purch
            {
                PRsAgingRel,
                POFirstRelease,
                POPrevRelease,
                NoConfirmation,
            }


            public enum PurchSub
            {
                PRReleasePORelease,
                POCreationCOnfEntry,
            }

            public enum PurchTotal
            {
                PRRelConfEntry,

            }


            public enum PurchPlanTotal
            {
                PurchPlanTotalAging,
            }

            public enum FollowUp
            {
                ConfPlanDate,
                ConfDateUpcomingDel,
                DueTodayLateConf,
            }


            public enum Cancellations
            {
                CancellationCount,
                CancellationValue,
            }

            public enum NCRs
            {
                OpenNCRs,
                OpenNCRValues,
            }

            public enum HotJobs
            {
                PrsNotonPO,
                NoConfirmations,
                LateToConfirmed,
            }

            public enum ExcessStockStock
            {
                PrsAgingNotRel,
                PRsAgingRel,
                POCreationThruDelivery,
            }


            public enum ExcessStockOpenOrders
            {
                PrsAgingNotRel,
                PRsAgingRel,
                POCreationThruDelivery,
            }

            public enum CurrPlanVsActual
            {
                CurrPlanDateCurrConfDateOpenPO,
                CurrPlanDateCurrConfDateOpenPOHotJobs
            }
        }

        public static string[][] kpaCategories =
        {
            new string[] { "Planned Order Aging", "PRs Aging (Not Released)", "Material Due"},
            new string[] { "PRs Aging (Released)", "PO First Release", "PO Prev Release", "No Confirmation"},
            new string[] { "PR Release to PO Release", "PO Creation to Confirmation Entry"},
            new string[] {"PR Release to Confirmation Entry"},
            new string[] {"Purchasing/Planning Total Aging"},
            new string[] { "Confirmed Date vs Plan Date", "Confirmed Date for Upcoming Deliveries", "Due Today or Late to Confirmed Date"},
            new string[] { "Cancellation Count", "Cancellation Value"},
            new string[] { "Open NCRs", "Open NCR Values"},
            new string[] { "PRs (Not on PO) - Hot Jobs Only", "No Confirmations - Hot Jobs Only", "Late to Confirmed - Hot Jobs Only"},
            new string[] { "Prs Aging (Not Released)", "PRs Aging (Released)", "PO Creation Thru Delivery"},
            new string[] { "Prs Aging (Not Released)", "PRs Aging (Released)", "PO Creation Thru Delivery"},
            new string[] { "Current Plan Date vs Current Confirmation Date", "Current Plan Date vs Current Confirmation Date - Hot Jobs Only"},
        };



        public enum KPI_Sections
        {
            Plan,
            Purch,
            FollowUp,
            PlanTwo,
            PurchTwo,
            PurchSub,
            PurchTotal,
            PurchPlan,
            PurchPlanTotal,
            Other
        }


        public static string[] kpiSection =
        {
            "Plan",
            "Purch",
            "Follow Up",
            "Plan",
            "Purch",
            "Purch Sub",
            "Purch Total",
            "Purch Plan",
            "Purch Plan Total",
            "Other",
        };




        public struct KPI_Categories
        {
            public enum Plan
            {
                PRPlanDatevsCurrentPlanDate,
                OriginalPlanDate2ndLvlReleaseDatevsCodedLeadTime,
                CurrentPlanDate2ndLvlReleaseDatevsCodedLeadTime
            }

            public enum Purch
            {
                InitialConfirmationDatevsPRPlanDate
            }

            public enum FollowUp
            {
                InitialConfirmationDatevsCurrentConfirmationDate,
                FinalConfirmationDatevsFinalPlanDate,
                ReceiptDatevsCurrentPlanDate,
                ReceiptDatevsOriginalConfirmationDate,
                ReceiptDatevsCurrentConfirmationDate
            }

            public enum PlanTwo
            {
                PRPlanDatevsPR2ndLvlReleaseDate,
                PlanOrderCreationDatevs2ndLvlReleaseDate
            }

            public enum PurchTwo
            {
                PR2ndLvlReleaseDatevsPOCreationDate,
                POCreationDatevsPOReleaseDate,
                POReleaseDatevsPOConfirmationDate
            }

            public enum PurchSub
            {
                PRReleaseDatevsPOReleaseDate,
                POCreationDatevsConfirmationEntryDate
            }
            public enum PurchTotal
            {
                PRReleaseDatetoConfirmationEntryDate
            }
            public enum PurchPlan
            {
                POReleasevsPRDeliveryDate,
                PR2ndLvlReleaseDatetoOriginalPlannedDeliveryDate
            }
            public enum PurchPlanTotal
            {
                PlannedOrderCreationDatevsConfirmationEntryDate
            }

            public enum Other
            {
                PRsCreated,
                PRsReleased,
                TotalSpend,
                PRValuevsPOValue,
                HotJobPRs
            }
        }


        public static string[][] kpiCategories =
        {
            new string[] { "PR Plan Date vs Current Plan Date", "(Original Plan Date - 2nd Lvl Release Date) vs Coded Lead-Time", "(Current Plan Date - 2nd Lvl Release Date) vs Coded Lead-Time"},
            new string[] { "Initial Confirmation Date vs PR Plan Date"},
            new string[] { "Initial Confirmation Date vs Current Confirmation Date", "Final Confirmation Date vs Final Plan Date", "Receipt Date vs Current Plan Date", "Receipt Date vs Original Confirmation Date", "Receipt Date vs Current Confirmation Date"},
            new string[] { "PR Plan Date vs PR 2nd Lvl Release Date", "Plan Order Creation Date vs 2nd Lvl Release Date"},
            new string[] { "PR 2nd Lvl Release Date vs PO Creation Date", "PO Creation Date vs PO Release Date", "PO Release Date vs PO Confirmation Date"},
            new string[] { "PR Release Date vs PO Release Date", "PO Creation Date vs Confirmation Entry Date" },
            new string[] { "PR Release Date to Confirmation Entry Date"},
            new string[] { "PO Release vs PR Delivery Date", "PR 2nd Lvl Release Date to Original Planned Delivery Date"},
            new string[] { "Planned Order Creation Date vs Confirmation Entry Date"},
            new string[] { "PRs Created", "PRs Released", "Total Spend", "PR Value vs PO Value", "Hot Job PRs"},
        };






        /// <summary>
        /// 
        /// </summary>
        public enum CorrelationMatrixIndexer
        {
            PoQty,
            PrQty,
            PrPrice,
            PrPosValue,
            PoNetPrice,
            PoValue,
            PriceUnit,
            PlDelivTime,
            QtyOrdered,
            Delivered,
            QtyConf,
            PoSourceTime,
            OpenPrQty
        }






        /// <summary>
        /// 
        /// </summary>
        public static string[] correlationHeaders =
        {
            "PO Qty",
            "PR Qty",
            "PR Price",
            "PR Pos Val",
            "PO Net Price",
            "PO Val",
            "Price Unit",
            "Plan Del Time",
            "Qty Ordered",
            "Delivered",
            "Qty Conf",
            "PO Src Time",
            "Open PR Qty"
        };






        /// <summary>
        /// 
        /// </summary>
        public static string[] correlationQueryHeaders =
        {
            "PO Qty",
            "PR Qty",
            "PR Price",
            "PR Pos#Value",
            "PO Net Price",
            "PO Value",
            "Price Unit",
            "Pl# Deliv# Time",
            "Qty Ordered",
            "Delivered",
            "Qty Conf#",
            "PO Source Time",
            "Open PR Qty"
        };




        public enum CorrelationDateRangeFilters
        {
            RequisitionDate,
            PoLineCreateDate,
            QtyOrdered
        }


        public static string[] correlationDateRangeFilters =
        {
            "Requisn Date",
            "PO Line Creat#DT",
            "Qty Ordered"
        };
    }
}
