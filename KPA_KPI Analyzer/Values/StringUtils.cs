using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPA_KPI_Analyzer.Values
{
    public static class StringUtils
    {
        /// <summary>
        /// Index values for the handled coutries.
        /// </summary>
        public enum Country
        {
            UnitedStates,
            Mexico
        }

        
        // Array of countries that the application handles.
        public static string[] countries =
        {
            "United States",
            "Mexico"
        };


        /// <summary>
        /// The names of the main tables that will hold all of the excel data
        /// </summary>
        public static string[] databaseTableNames =
        {
            "US_PRPO",
            "MX_PRPO"
        };


        /// <summary>
        /// Query that removes data that is not needed in the calculations.
        /// </summary>
        public static string removableDataQuery = "DELETE * FROM " + DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + " WHERE " + "(" + DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Open PR Qty] = 0 AND " + DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Qty Ordered] = 0)";


        /// <summary>
        /// Utilities for the KPA performance.
        /// </summary>
        public static class KpaStringUtils
        {
            /// <summary>
            /// Index values of the sections contained within KPAs
            /// </summary>
            public enum Section
            {
                Plan,
                Purch,
                PurchSub,
                PurchTotal,
                FollowUp,
                HotJobs,
                ExcessStock_Stock,
                ExcessStock_OpenOrders,
                CurrPlanActual
            }


            /// <summary>
            /// Array of the names of KPA sections
            /// </summary>
            public static string[] sections = {
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


            /// <summary>
            /// structure of enumerations of all KPA categories
            /// </summary>
            public struct Category
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
            public static string[][] cateogories =
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
            /// An array of queries for KPAs.
            /// </summary>
            public static string[][] queries =
            {
                // KPA -> Plan
                new string[] {
                    "SELECT * FROM " + DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + " WHERE " + "(" +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Open PR Qty] > 0 AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Release Ind#] <> 2)" ,
                    "SELECT * FROM " + DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + " WHERE " + "(" +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Open PR Qty] > 0 AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Release Ind#] = 2)" ,
                },

                // KPA -> Purch
                new string[] {
                    "SELECT * FROM " + DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + " WHERE " + "(" +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Open PR Qty] > 0 AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Release Ind#] = 2)" ,
                    "SELECT * FROM " + DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + " WHERE " + "(" +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Qty Ordered] > 0 AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[PO Line 1st Rel Dt] = '00/00/0000')" ,
                    "SELECT * FROM " + DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + " WHERE " + "(" +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Qty Ordered] > 0 AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[PO Line 1st Rel Dt] <> '00/00/0000' AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[PO Sign Date] = '00/00/0000' AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Escaped] IS NULL)" ,
                    "SELECT * FROM " + DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + " WHERE " + "(" +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Qty Ordered] > 0 AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[PO Line 1st Rel Dt] <> '00/00/0000' AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Del#Conf#Date] = '00/00/0000' AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Escaped] IS NULL)" ,
                },

                // KPA -> Purch Sub
                new string[] {
                    "SELECT * FROM " + DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + " WHERE " + "(" +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[PO Line 1st Rel Dt] = '00/00/0000' AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Release Ind#] = 2)" ,
                    "SELECT * FROM " + DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + " WHERE " + "(" +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Qty Ordered] > 0 AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Del#Conf#Date] = '00/00/0000' AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Escaped] IS NULL)" ,
                },

                // KPA -> Purch Total
                new string[] {
                    "SELECT * FROM " + DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + " WHERE " + "(" +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Release Ind#] = 2 AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Del#Conf#Date] = '00/00/0000' AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Escaped] IS NULL)" ,
                },

                // KPA -> Follow Up
                new string[] {
                    "SELECT * FROM " + DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + " WHERE " + "(" +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Qty Ordered] > 0 AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Del#Conf#Date] <> '00/00/0000' AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Escaped] IS NULL)" ,
                    "SELECT * FROM " + DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + " WHERE " + "(" +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Qty Ordered] > 0 AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Del#Conf#Date] <> '00/00/0000' AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Escaped] IS NULL)" ,
                    "SELECT * FROM " + DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + " WHERE " + "(" +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Qty Ordered] > 0 AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Del#Conf#Date] <> '00/00/0000' AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Escaped] IS NULL)" ,
                },

                // KPA -> Hot Jobs
                new string[] {
                    "SELECT * FROM " + DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + " WHERE " + "(" +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[PO Date] = '00/00/0000' AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[PR 2° Rel# Date] <> '00/00/0000' AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Purch# Group] = 'UHJ')" ,
                    "SELECT * FROM " + DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + " WHERE " + "(" +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Qty Ordered] > 0 AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Del#Conf#Date] = '00/00/0000' AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[PO Line Creat#DT] <> '00/00/0000' AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Purch# Group] = 'UHJ' AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Escaped] IS NULL)" ,
                    "SELECT * FROM " + DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + " WHERE " + "(" +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Qty Ordered] > 0 AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Del#Conf#Date] <> '00/00/0000' AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Purch# Group] = 'UHJ' AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Escaped] IS NULL)" ,
                },

                // KPA -> Excess Stock - Stock
                new string[] {
                    "SELECT * FROM " + DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + " WHERE " + "(" +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Open PR Qty] > 0 AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Release Ind#] <> 2 AND (" +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Gen# Stock On Hand] > 0 OR " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Project Stk On Hand] > 0))" ,
                    "SELECT * FROM " + DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + " WHERE " + "(" +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Open PR Qty] > 0 AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Release Ind#] = 2 AND (" +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Gen# Stock On Hand] > 0 OR " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Project Stk On Hand] > 0))" ,
                    "SELECT * FROM " + DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + " WHERE " + "(" +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Qty Ordered] > 0 AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Escaped] IS NULL AND (" +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Gen# Stock On Hand] > 0 OR " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Project Stk On Hand] > 0))" ,
                },

                // KPA -> Excess Stock - Open Order
                new string[] {
                    "SELECT * FROM " + DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + " WHERE " + "(" +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Open PR Qty] > 0 AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Release Ind#] <> 2 AND (" +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[General Stock On Ord] > 0 OR " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Project Stock On Ord] > 0))" ,
                    "SELECT * FROM " + DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + " WHERE " + "(" +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Open PR Qty] > 0 AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Release Ind#] = 2 AND (" +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[General Stock On Ord] > 0 OR " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Project Stock On Ord] > 0))" ,
                    "SELECT * FROM " + DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + " WHERE " + "(" +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Qty Ordered] > 0 AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Escaped] IS NULL AND (" +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[General Stock On Ord] > 0 OR " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Project Stock On Ord] > 0))" ,
                },

                // KPA -> Current Plan vs Actual
                new string[] {
                    "SELECT * FROM " + DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + " WHERE " + "(" +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Qty Ordered] > 0 AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Del#Conf#Date] <> '00/00/0000' AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Escaped] IS NULL)" ,
                    "SELECT * FROM " + DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + " WHERE " + "(" +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Qty Ordered] > 0 AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Del#Conf#Date] <> '00/00/0000' AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Purch# Group]  = 'UHJ' AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Escaped] IS NULL)"
                },
            };
        }



        /// <summary>
        /// Utilities for the KPI performance
        /// </summary>
        public static class KpiStringUtils
        {
            /// <summary>
            /// Index values of the sections contained within KPAs
            /// </summary>
            public enum Section
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


            /// <summary>
            /// Array of the names of KPA sections
            /// </summary>
            public static string[] sections =
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


            /// <summary>
            /// structure of enumerations of all KPA categories
            /// </summary>
            public struct Category
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
            public static string[][] categories =
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
            /// Query indexers for KPI query strings
            /// </summary>
            public enum Query
            {
                AllPOs,
                POLinesUnconfirmed,
                POLinesRecComplete,
                POLinesRecComplete_Unconf,
                PR_2ndLvlRel,
                AllData,
            }



            /// <summary>
            /// An array of queries for KPIs.
            /// </summary>
            public static string[] queries =
            {
                // KPIs
                "SELECT * FROM " + DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + " WHERE " + "(" +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Qty Ordered] > 0)", // All POs
                "SELECT * FROM " + DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + " WHERE " + "(" +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Qty Ordered] > 0 AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Del#Conf#Date] = '00/00/0000')", // total pos with no confirmation
                "SELECT * FROM " + DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + " WHERE " + "(" +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Escaped] IS NOT NULL)",
                "SELECT * FROM " + DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + " WHERE " + "(" +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Escaped] IS NOT NULL AND " +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Del#Conf#Date] = '00/00/0000')",
                "SELECT * FROM " + DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + " WHERE " + "(" +DatabaseUtils.PRPO_DB_Utils.TargetCountryTable + ".[Release ind#] = 2)",
                "SELECT * FROM " + DatabaseUtils.PRPO_DB_Utils.TargetCountryTable
            };

        }



        /// <summary>
        /// Utilities for the correlation feature.
        /// </summary>
        public static class CorrelationStringUtils
        {
            /// <summary>
            /// The Correlation Index Matric Header names
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
            /// The list of correlation header names.
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
            /// The list of correlation Query header names. These string are used to query the data because they contain special characters
            /// needed to get proper results from the query.
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



            /// <summary>
            /// Correlation index date range filter names
            /// </summary>
            public enum CorrelationDateRangeFilters
            {
                RequisitionDate,
                PoLineCreateDate,
                QtyOrdered
            }



            /// <summary>
            /// The correlation date range query header names.
            /// </summary>
            public static string[] correlationDateRangeFilters =
            {
                "Requisn Date",
                "PO Line Creat#DT",
                "Qty Ordered"
            };
        }
    }
}



