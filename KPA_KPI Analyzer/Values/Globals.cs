namespace KPA_KPI_Analyzer.Values
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
            "Follow Up",
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

            public enum FollowUp
            {
                ConfPlanDate,
                ConfDateUpcomingDel,
                DueTodayLateConf,
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
            // Plan
            new string[] { "Planned Order Aging", "PRs Aging (Not Released)", "Material Due"},
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
            "Other",
        };




        public struct KPI_Categories
        {
            public enum Plan
            {
                CurrentPlanDateVsPrPlanDate,
                OriginalPlanDate2ndLvlReleaseDatevsCodedLeadTime,
                CurrentPlanDate2ndLvlReleaseDatevsCodedLeadTime
            }

            public enum Purch
            {
                InitialConfirmationDatevsPRPlanDate
            }

            public enum FollowUp
            {
                CurrentConfDateVsInitialConfDate,
                FinalConfirmationDatevsFinalPlanDate,
                ReceiptDatevsCurrentPlanDate,
                ReceiptDatevsOriginalConfirmationDate,
                ReceiptDatevsCurrentConfirmationDate
            }

            public enum PlanTwo
            {
                MaterialDueOriginalPlanDate,
                MaterialDueFinalPlannedDate
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
                POReleasevsPRDeliveryDate
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
