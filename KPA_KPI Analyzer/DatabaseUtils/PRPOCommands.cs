using KPA_KPI_Analyzer.Values;

namespace KPA_KPI_Analyzer.DatabaseUtils
{
    public class PRPOCommands
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
        public static string removableUSDataQuery = "DELETE * FROM US_PRPO WHERE " + "(US_PRPO.[Open PR Qty] = 0 AND US_PRPO.[Qty Ordered] = 0)";
        public static string removableMXDataQuery = "DELETE * FROM MX_PRPO WHERE " + "(MX_PRPO.[Open PR Qty] = 0 AND MX_PRPO.[Qty Ordered] = 0)";






        /// <summary>
        /// An array of queries for both KPA and KPIs.
        /// </summary>
        public static string[] usQueries =
        {
            // KPIs
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Qty Ordered] > 0)", // All POs
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Qty Ordered] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Del#Conf#Date] = '00/00/0000')", // total pos with no confirmation
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Escaped] IS NOT NULL)",
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Escaped] IS NOT NULL AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Del#Conf#Date] = '00/00/0000')",
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Release ind#] = 2)",
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO],
            
            // KPA -> Plan
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Open PR Qty] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Release Ind#] <> 2)" ,
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Open PR Qty] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Release Ind#] = 2)" , 
                 
            // KPA -> Purch
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Open PR Qty] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Release Ind#] = 2)" ,
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Qty Ordered] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[PO Line 1st Rel Dt] = '00/00/0000')" ,
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Qty Ordered] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[PO Line 1st Rel Dt] <> '00/00/0000' AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[PO Sign Date] = '00/00/0000' AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Escaped] IS NULL)" , // KPA -> Purch -> PO Prev Release
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Qty Ordered] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[PO Line 1st Rel Dt] <> '00/00/0000' AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Del#Conf#Date] = '00/00/0000' AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Escaped] IS NULL)" ,

            // KPA -> Purch Sub
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[PO Line 1st Rel Dt] = '00/00/0000' AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Release Ind#] = 2)" ,
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Qty Ordered] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Del#Conf#Date] = '00/00/0000' AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Escaped] IS NULL)" ,
                
            // KPA -> Purch Total
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Release Ind#] = 2 AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Del#Conf#Date] = '00/00/0000' AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Escaped] IS NULL)" ,
                
            // KPA -> Purch/Plan Total

            // KPA -> Follow Up
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Qty Ordered] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Del#Conf#Date] <> '00/00/0000' AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Escaped] IS NULL)" ,
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Qty Ordered] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Del#Conf#Date] <> '00/00/0000' AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Escaped] IS NULL)" ,
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Qty Ordered] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Del#Conf#Date] <> '00/00/0000' AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Escaped] IS NULL)" ,

            // KPA -> Cancellations

            // KPA -> NCRs

            // KPA -> Hot Jobs
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[PO Date] = '00/00/0000' AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[PR 2° Rel# Date] <> '00/00/0000' AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Purch# Group] = 'UHJ')" ,
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Qty Ordered] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Del#Conf#Date] = '00/00/0000' AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[PO Line Creat#DT] <> '00/00/0000' AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Purch# Group] = 'UHJ' AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Escaped] IS NULL)" ,
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Qty Ordered] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Del#Conf#Date] <> '00/00/0000' AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Purch# Group] = 'UHJ' AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Escaped] IS NULL)" ,

            // KPA -> Excess Stock - Stock
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Open PR Qty] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Release Ind#] = 2 AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Gen# Stock On Hand] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Project Stk On Hand] > 0)" ,
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Open PR Qty] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Release Ind#] = 2 AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Gen# Stock On Hand] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Project Stk On Hand] > 0)" ,
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Qty Ordered] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Del#Conf#Date] = '00/00/0000' AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Escaped] IS NULL AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Gen# Stock On Hand] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Project Stk On Hand] > 0)" ,

            // KPA -> Excess Stock - Open Order
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Open PR Qty] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Release Ind#] = 2 AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[General Stock On Ord] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Project Stock On Ord] > 0)" ,
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Open PR Qty] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Release Ind#] = 2 AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[General Stock On Ord] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Project Stock On Ord] > 0)" ,
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Qty Ordered] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Del#Conf#Date] = '00/00/0000' AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Escaped] IS NULL AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[General Stock On Ord] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Project Stock On Ord] > 0)" ,

            // KPA -> Current Plan vs Actual
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Qty Ordered] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Del#Conf#Date] <> '00/00/0000' AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Escaped] IS NULL)" ,
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Qty Ordered] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Del#Conf#Date] <> '00/00/0000' AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Purch# Group]  = 'UHJ' AND " + mainTableNames[(int)DatabaseTables.MainTables.US_PRPO] + ".[Escaped] IS NULL)" ,
        };



        /// <summary>
        /// An array of queries for both KPA and KPIs.
        /// </summary>
        public static string[] mxQueries =
        {
            // KPIs
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Qty Ordered] > 0)", // All POs
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Qty Ordered] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Del#Conf#Date] = '00/00/0000')", // total pos with no confirmation
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Escaped] IS NOT NULL)",
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Escaped] IS NOT NULL AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Del#Conf#Date] = '00/00/0000')",
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Release ind#] = 2)",
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + "",
            
            // KPA -> Plan
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Open PR Qty] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Release Ind#] <> 2)" ,
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Open PR Qty] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Release Ind#] = 2)" , 
                 
            // KPA -> Purch
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Open PR Qty] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Release Ind#] = 2)" ,
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Qty Ordered] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[PO Line 1st Rel Dt] = '00/00/0000')" ,
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Qty Ordered] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[PO Line 1st Rel Dt] <> '00/00/0000' AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[PO Sign Date] = '00/00/0000' AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Escaped] IS NULL)" , // KPA -> Purch -> PO Prev Release
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Qty Ordered] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[PO Line 1st Rel Dt] <> '00/00/0000' AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Del#Conf#Date] = '00/00/0000' AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Escaped] IS NULL)" ,

            // KPA -> Purch Sub
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[PO Line 1st Rel Dt] = '00/00/0000' AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Release Ind#] = 2)" ,
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Qty Ordered] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Del#Conf#Date] = '00/00/0000' AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Escaped] IS NULL)" ,
                
            // KPA -> Purch Total
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Release Ind#] = 2 AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Del#Conf#Date] = '00/00/0000' AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Escaped] IS NULL)" ,
                
            // KPA -> Purch/Plan Total

            // KPA -> Follow Up
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Qty Ordered] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Del#Conf#Date] <> '00/00/0000' AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Escaped] IS NULL)" ,
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Qty Ordered] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Del#Conf#Date] <> '00/00/0000' AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Escaped] IS NULL)" ,
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Qty Ordered] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Del#Conf#Date] <> '00/00/0000' AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Escaped] IS NULL)" ,

            // KPA -> Cancellations

            // KPA -> NCRs

            // KPA -> Hot Jobs
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[PO Date] = '00/00/0000' AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[PR 2° Rel# Date] <> '00/00/0000' AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Purch# Group] = 'UHJ')" ,
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Qty Ordered] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Del#Conf#Date] = '00/00/0000' AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[PO Line Creat#DT] <> '00/00/0000' AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Purch# Group] = 'UHJ' AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Escaped] IS NULL)" ,
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Qty Ordered] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Del#Conf#Date] <> '00/00/0000' AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Purch# Group] = 'UHJ' AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Escaped] IS NULL)" ,

            // KPA -> Excess Stock - Stock
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Open PR Qty] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Release Ind#] = 2 AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Gen# Stock On Hand] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Project Stk On Hand] > 0)" ,
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Open PR Qty] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Release Ind#] = 2 AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Gen# Stock On Hand] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Project Stk On Hand] > 0)" ,
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Qty Ordered] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Del#Conf#Date] = '00/00/0000' AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Escaped] IS NULL AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Gen# Stock On Hand] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Project Stk On Hand] > 0)" ,

            // KPA -> Excess Stock - Open Order
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Open PR Qty] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Release Ind#] = 2 AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[General Stock On Ord] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Project Stock On Ord] > 0)" ,
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Open PR Qty] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Release Ind#] = 2 AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[General Stock On Ord] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Project Stock On Ord] > 0)" ,
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Qty Ordered] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Del#Conf#Date] = '00/00/0000' AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Escaped] IS NULL AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[General Stock On Ord] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Project Stock On Ord] > 0)" ,

            // KPA -> Current Plan vs Actual
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Qty Ordered] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Del#Conf#Date] <> '00/00/0000' AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Escaped] IS NULL)" ,
            "SELECT * FROM " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + " WHERE " + "(" + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Qty Ordered] > 0 AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Del#Conf#Date] <> '00/00/0000' AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Purch# Group]  = 'UHJ' AND " + mainTableNames[(int)DatabaseTables.MainTables.MX_PRPO] + ".[Escaped] IS NULL)" ,
        };




        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static string GetQuery(DatabaseTables.TableNames tableName)
        {
            if (Globals.FocusedCountry == Globals.Countries.UnitedStates)
                return usQueries[(int)tableName];
            else
                return mxQueries[(int)tableName];
        }
    }
}
