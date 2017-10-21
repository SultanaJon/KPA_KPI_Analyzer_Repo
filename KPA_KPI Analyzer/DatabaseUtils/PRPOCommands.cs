using KPA_KPI_Analyzer.FilterFeeature;

namespace KPA_KPI_Analyzer.DatabaseUtils
{
    public static class PRPOCommands
    {
        /// <summary>
        /// The tables that will be created througout the lifespan of the application.
        /// </summary>
        public struct DatabaseTables
        {
            /// <summary>
            /// The main tables that will hold all of the data from when the excel files were imported.
            /// </summary>
            public enum MainTables
            {
                US_PRPO,
                MX_PRPO,
            }






            /// <summary>
            /// Indexers to the list of United States KPA table names
            /// </summary>
            public enum TableNames
            {
                // Used for KPIs
                AllPOs,
                POLinesUnconfirmed,
                POLinesRecComplete,
                POLinesRecComplete_Unconf,
                PR_2ndLvlRel,
                AllData,

                // Used for KPAs
                KPA_Plan_PRsAgingNotRel,
                KPA_Plan_MaterialDue,
                KPA_Purch_PRsAgingRel,
                KPA_Purch_POFirstRelease,
                KPA_Purch_POPrevRelease,
                KPA_Purch_NoConfirmation,
                KPA_PurchSub_PRReleasePORelease,
                KPA_PurchSub_POCreationCOnfEntry,
                KPA_PurchTotal_PRRelConfEntry,
                KPA_FollowUp_ConfPlanDate,
                KPA_FollowUp_ConfDateUpcomingDel,
                KPA_FollowUp_LateToConfirmedDate,
                KPA_HotJobs_PrsNotonPO,
                KPA_HotJobs_NoConfirmations,
                KPA_HotJobs_LateToConfirmed,
                KPA_ExcessStock_Stock_PrsAgingNotRel,
                KPA_ExcessStock_Stock_PrsAgingRel,
                KPA_ExcessStock_Stock_PoCreateToConfEntry,
                KPA_ExcessStock_OpenOrders_PrsAgingNotRel,
                KPA_ExcessStock_OpenOrders_PrsAgingRel,
                KPA_ExcessStock_OpenOrders_PoCreateToConfEntry,
                KPA_CurrPlanActual_CurrPlanDateCurrConfDateOpenPO,
                KPA_CurrPlanActual_CurrPlanDateCurrConfDateOpenPOHotJobs
            }
        }






        /// <summary>
        /// The names of the main tables that will hold all of the excel data
        /// </summary>
        public static string[] mainTableNames =
        {
                "US_PRPO", "MX_PRPO"
        };




        // This query will remove the data that we do not want to fall under our calculations.
        public static string removableData = "DELETE * FROM " + Values.Globals.SelectedCountry + " WHERE " + "(" + Values.Globals.SelectedCountry + ".[Open PR Qty] = 0 AND " + Values.Globals.SelectedCountry + ".[Qty Ordered] = 0)";






        /// <summary>
        /// An array of queries for both KPA and KPIs.
        /// </summary>
        public static string[] Queries =
        {
            // KPIs
            "SELECT * FROM " + Values.Globals.SelectedCountry + " WHERE " + "(" + Values.Globals.SelectedCountry + ".[Qty Ordered] > 0)", // All POs
            "SELECT * FROM " + Values.Globals.SelectedCountry + " WHERE " + "(" + Values.Globals.SelectedCountry + ".[Qty Ordered] > 0 AND " + Values.Globals.SelectedCountry + ".[Del#Conf#Date] = '00/00/0000')", // total pos with no confirmation
            "SELECT * FROM " + Values.Globals.SelectedCountry + " WHERE " + "(" + Values.Globals.SelectedCountry + ".[Escaped] IS NOT NULL)",
            "SELECT * FROM " + Values.Globals.SelectedCountry + " WHERE " + "(" + Values.Globals.SelectedCountry + ".[Escaped] IS NOT NULL AND " + Values.Globals.SelectedCountry + ".[Del#Conf#Date] = '00/00/0000')",
            "SELECT * FROM " + Values.Globals.SelectedCountry + " WHERE " + "(" + Values.Globals.SelectedCountry + ".[Release ind#] = 2)",
            "SELECT * FROM " + Values.Globals.SelectedCountry,
            
            // KPA -> Plan
            "SELECT * FROM " + Values.Globals.SelectedCountry + " WHERE " + "(" + Values.Globals.SelectedCountry + ".[Open PR Qty] > 0 AND " + Values.Globals.SelectedCountry + ".[Release Ind#] <> 2)" + Filters.FilterQuery,
            "SELECT * FROM " + Values.Globals.SelectedCountry + " WHERE " + "(" + Values.Globals.SelectedCountry + ".[Open PR Qty] > 0 AND " + Values.Globals.SelectedCountry + ".[Release Ind#] = 2)" + Filters.FilterQuery, 
                 
            // KPA -> Purch
            "SELECT * FROM " + Values.Globals.SelectedCountry + " WHERE " + "(" + Values.Globals.SelectedCountry + ".[Open PR Qty] > 0 AND " + Values.Globals.SelectedCountry + ".[Release Ind#] = 2)" + Filters.FilterQuery,
            "SELECT * FROM " + Values.Globals.SelectedCountry + " WHERE " + "(" + Values.Globals.SelectedCountry + ".[Qty Ordered] > 0 AND " + Values.Globals.SelectedCountry + ".[PO Line 1st Rel Dt] = '00/00/0000')" + Filters.FilterQuery,
            "SELECT * FROM " + Values.Globals.SelectedCountry + " WHERE " + "(" + Values.Globals.SelectedCountry + ".[Qty Ordered] > 0 AND " + Values.Globals.SelectedCountry + ".[PO Line 1st Rel Dt] <> '00/00/0000' AND " + Values.Globals.SelectedCountry + ".[PO Sign Date] = '00/00/0000' AND "+ Values.Globals.SelectedCountry +".[Escaped] IS NULL)" + Filters.FilterQuery, // KPA -> Purch -> PO Prev Release
            "SELECT * FROM " + Values.Globals.SelectedCountry + " WHERE " + "(" + Values.Globals.SelectedCountry + ".[Qty Ordered] > 0 AND " + Values.Globals.SelectedCountry + ".[PO Line 1st Rel Dt] <> '00/00/0000' AND " + Values.Globals.SelectedCountry + ".[Del#Conf#Date] = '00/00/0000' AND "+ Values.Globals.SelectedCountry +".[Escaped] IS NULL)" + Filters.FilterQuery,

            // KPA -> Purch Sub
            "SELECT * FROM " + Values.Globals.SelectedCountry + " WHERE " + "(" + Values.Globals.SelectedCountry + ".[PO Line 1st Rel Dt] = '00/00/0000' AND " + Values.Globals.SelectedCountry + ".[Release Ind#] = 2)" + Filters.FilterQuery,
            "SELECT * FROM " + Values.Globals.SelectedCountry + " WHERE " + "(" + Values.Globals.SelectedCountry + ".[Qty Ordered] > 0 AND " + Values.Globals.SelectedCountry + ".[Del#Conf#Date] = '00/00/0000' AND " + Values.Globals.SelectedCountry + ".[Escaped] IS NULL)" + Filters.FilterQuery,
                
            // KPA -> Purch Total
            "SELECT * FROM " + Values.Globals.SelectedCountry + " WHERE " + "(" + Values.Globals.SelectedCountry + ".[Release Ind#] = 2 AND " + Values.Globals.SelectedCountry + ".[Del#Conf#Date] = '00/00/0000' AND " + Values.Globals.SelectedCountry + ".[Escaped] IS NULL)" + Filters.FilterQuery,
                
            // KPA -> Purch/Plan Total

            // KPA -> Follow Up
            "SELECT * FROM " + Values.Globals.SelectedCountry + " WHERE " + "(" + Values.Globals.SelectedCountry + ".[Qty Ordered] > 0 AND " + Values.Globals.SelectedCountry + ".[Del#Conf#Date] <> '00/00/0000' AND " + Values.Globals.SelectedCountry + ".[Escaped] IS NULL)" + Filters.FilterQuery,
            "SELECT * FROM " + Values.Globals.SelectedCountry + " WHERE " + "(" + Values.Globals.SelectedCountry + ".[Qty Ordered] > 0 AND " + Values.Globals.SelectedCountry + ".[Del#Conf#Date] <> '00/00/0000' AND " + Values.Globals.SelectedCountry + ".[Escaped] IS NULL)" + Filters.FilterQuery,
            "SELECT * FROM " + Values.Globals.SelectedCountry + " WHERE " + "(" + Values.Globals.SelectedCountry + ".[Qty Ordered] > 0 AND " + Values.Globals.SelectedCountry + ".[Del#Conf#Date] <> '00/00/0000' AND " + Values.Globals.SelectedCountry + ".[Escaped] IS NULL)" + Filters.FilterQuery,

            // KPA -> Cancellations

            // KPA -> NCRs

            // KPA -> Hot Jobs
            "SELECT * FROM " + Values.Globals.SelectedCountry + " WHERE " + "(" + Values.Globals.SelectedCountry + ".[PO Date] = '00/00/0000' AND " + Values.Globals.SelectedCountry + ".[PR 2° Rel# Date] <> '00/00/0000' AND " + Values.Globals.SelectedCountry + ".[Purch# Group] = 'UHJ')" + Filters.FilterQuery,
            "SELECT * FROM " + Values.Globals.SelectedCountry + " WHERE " + "(" + Values.Globals.SelectedCountry + ".[Qty Ordered] > 0 AND " + Values.Globals.SelectedCountry + ".[Del#Conf#Date] = '00/00/0000' AND " + Values.Globals.SelectedCountry + ".[PO Line Creat#DT] <> '00/00/0000' AND " + Values.Globals.SelectedCountry + ".[Purch# Group] = 'UHJ' AND " + Values.Globals.SelectedCountry + ".[Escaped] IS NULL)" + Filters.FilterQuery,
            "SELECT * FROM " + Values.Globals.SelectedCountry + " WHERE " + "(" + Values.Globals.SelectedCountry + ".[Qty Ordered] > 0 AND " + Values.Globals.SelectedCountry + ".[Del#Conf#Date] <> '00/00/0000' AND " + Values.Globals.SelectedCountry + ".[Purch# Group] = 'UHJ' AND " + Values.Globals.SelectedCountry + ".[Escaped] IS NULL)" + Filters.FilterQuery,

            // KPA -> Excess Stock - Stock
            "SELECT * FROM " + Values.Globals.SelectedCountry + " WHERE " + "(" + Values.Globals.SelectedCountry + ".[Open PR Qty] > 0 AND " + Values.Globals.SelectedCountry + ".[Release Ind#] = 2 AND " + Values.Globals.SelectedCountry + ".[Gen# Stock On Hand] > 0 AND " + Values.Globals.SelectedCountry + ".[Project Stk On Hand] > 0)" + Filters.FilterQuery,
            "SELECT * FROM " + Values.Globals.SelectedCountry + " WHERE " + "(" + Values.Globals.SelectedCountry + ".[Open PR Qty] > 0 AND " + Values.Globals.SelectedCountry + ".[Release Ind#] = 2 AND " + Values.Globals.SelectedCountry + ".[Gen# Stock On Hand] > 0 AND " + Values.Globals.SelectedCountry + ".[Project Stk On Hand] > 0)" + Filters.FilterQuery,
            "SELECT * FROM " + Values.Globals.SelectedCountry + " WHERE " + "(" + Values.Globals.SelectedCountry + ".[Qty Ordered] > 0 AND " + Values.Globals.SelectedCountry + ".[Del#Conf#Date] = '00/00/0000' AND " + Values.Globals.SelectedCountry + ".[Escaped] IS NULL AND " + Values.Globals.SelectedCountry + ".[Gen# Stock On Hand] > 0 AND " + Values.Globals.SelectedCountry + ".[Project Stk On Hand] > 0)" + Filters.FilterQuery,

            // KPA -> Excess Stock - Open Order
            "SELECT * FROM " + Values.Globals.SelectedCountry + " WHERE " + "(" + Values.Globals.SelectedCountry + ".[Open PR Qty] > 0 AND " + Values.Globals.SelectedCountry + ".[Release Ind#] = 2 AND " + Values.Globals.SelectedCountry + ".[General Stock On Ord] > 0 AND " + Values.Globals.SelectedCountry + ".[Project Stock On Ord] > 0)" + Filters.FilterQuery,
            "SELECT * FROM " + Values.Globals.SelectedCountry + " WHERE " + "(" + Values.Globals.SelectedCountry + ".[Open PR Qty] > 0 AND " + Values.Globals.SelectedCountry + ".[Release Ind#] = 2 AND " + Values.Globals.SelectedCountry + ".[General Stock On Ord] > 0 AND " + Values.Globals.SelectedCountry + ".[Project Stock On Ord] > 0)" + Filters.FilterQuery,
            "SELECT * FROM " + Values.Globals.SelectedCountry + " WHERE " + "(" + Values.Globals.SelectedCountry + ".[Qty Ordered] > 0 AND " + Values.Globals.SelectedCountry + ".[Del#Conf#Date] = '00/00/0000' AND " + Values.Globals.SelectedCountry + ".[Escaped] IS NULL AND " + Values.Globals.SelectedCountry + ".[General Stock On Ord] > 0 AND " + Values.Globals.SelectedCountry + ".[Project Stock On Ord] > 0)" + Filters.FilterQuery,

            // KPA -> Current Plan vs Actual
            "SELECT * FROM " + Values.Globals.SelectedCountry + " WHERE " + "(" + Values.Globals.SelectedCountry + ".[Qty Ordered] > 0 AND " + Values.Globals.SelectedCountry + ".[Del#Conf#Date] <> '00/00/0000' AND " + Values.Globals.SelectedCountry + ".[Escaped] IS NULL)" + Filters.FilterQuery,
            "SELECT * FROM " + Values.Globals.SelectedCountry + " WHERE " + "(" + Values.Globals.SelectedCountry + ".[Qty Ordered] > 0 AND " + Values.Globals.SelectedCountry + ".[Del#Conf#Date] <> '00/00/0000' AND " + Values.Globals.SelectedCountry + ".[Purch# Group]  = 'UHJ' AND " + Values.Globals.SelectedCountry + ".[Escaped] IS NULL)" + Filters.FilterQuery,
        };
    }
}
