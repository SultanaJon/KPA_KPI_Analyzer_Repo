using KPA_KPI_Analyzer.FilterFeeature;
using KPA_KPI_Analyzer.KPA_KPI_Overall;

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
                KPA_HotJobs_PrsNotonPO,
                KPA_HotJobs_NoConfirmations,
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
        public static string removableData = "DELETE * FROM " + Overall.SelectedCountry + " WHERE " + "(" + Overall.SelectedCountry + ".[Open PR Qty] = 0 AND " + Overall.SelectedCountry + ".[Qty Ordered] = 0)";






        /// <summary>
        /// An array of queries for both KPA and KPIs.
        /// </summary>
        public static string[] Queries =
        {
            // KPIs
            "SELECT * FROM " + Overall.SelectedCountry + " WHERE " + "(" + Overall.SelectedCountry + ".[Qty Ordered] > 0)", // All POs
            "SELECT * FROM " + Overall.SelectedCountry + " WHERE " + "(" + Overall.SelectedCountry + ".[Qty Ordered] > 0 AND " + Overall.SelectedCountry + ".[Del#Conf#Date] = '00/00/0000')", // total pos with no confirmation
            "SELECT * FROM " + Overall.SelectedCountry + " WHERE " + "(" + Overall.SelectedCountry + ".[Escaped] IS NOT NULL)",
            "SELECT * FROM " + Overall.SelectedCountry + " WHERE " + "(" + Overall.SelectedCountry + ".[Escaped] IS NOT NULL AND " + Overall.SelectedCountry + ".[Del#Conf#Date] = '00/00/0000')",
            "SELECT * FROM " + Overall.SelectedCountry + " WHERE " + "(" + Overall.SelectedCountry + ".[PR 2° Rel# Date] <> '00/00/0000')",
            "SELECT * FROM " + Overall.SelectedCountry,
            
            // KPA -> Plan
            "SELECT * FROM " + Overall.SelectedCountry + " WHERE " + "(" + Overall.SelectedCountry + ".[Open PR Qty] > 0 AND " + Overall.SelectedCountry + ".[Release Ind#] = 1)" + Filters.FilterQuery,
            "SELECT * FROM " + Overall.SelectedCountry + " WHERE " + "(" + Overall.SelectedCountry + ".[Open PR Qty] > 0 AND " + Overall.SelectedCountry + ".[Release Ind#] = 2)" + Filters.FilterQuery, 
                 
            // KPA -> Purch
            "SELECT * FROM " + Overall.SelectedCountry + " WHERE " + "(" + Overall.SelectedCountry + ".[Open PR Qty] > 0 AND " + Overall.SelectedCountry + ".[Release Ind#] = 2)" + Filters.FilterQuery,
            "SELECT * FROM " + Overall.SelectedCountry + " WHERE " + "(" + Overall.SelectedCountry + ".[Qty Ordered] > 0 AND " + Overall.SelectedCountry + ".[PO Line 1st Rel Dt] = '00/00/0000')" + Filters.FilterQuery,
            "SELECT * FROM " + Overall.SelectedCountry + " WHERE " + "(" + Overall.SelectedCountry + ".[Qty Ordered] > 0 AND " + Overall.SelectedCountry + ".[PO Line 1st Rel Dt] <> '00/00/0000' AND " + Overall.SelectedCountry + ".[PO Sign Date] = '00/00/0000' AND "+ Overall.SelectedCountry +".[Escaped] IS NULL)" + Filters.FilterQuery, // KPA -> Purch -> PO Prev Release
            "SELECT * FROM " + Overall.SelectedCountry + " WHERE " + "(" + Overall.SelectedCountry + ".[Qty Ordered] > 0 AND " + Overall.SelectedCountry + ".[PO Line 1st Rel Dt] <> '00/00/0000' AND " + Overall.SelectedCountry + ".[Del#Conf#Date] = '00/00/0000' AND "+ Overall.SelectedCountry +".[Escaped] IS NULL)" + Filters.FilterQuery,

            // KPA -> Purch Sub
            "SELECT * FROM " + Overall.SelectedCountry + " WHERE " + "(" + Overall.SelectedCountry + ".[Open PR Qty] > 0 AND " + Overall.SelectedCountry + ".[PR 2° Rel# Date] <> '00/00/0000' OR " + Overall.SelectedCountry + ".[Qty Ordered] > 0 AND " + Overall.SelectedCountry + ".[PO Line 1st Rel Dt] ='00/00/0000')" + Filters.FilterQuery,
            "SELECT * FROM " + Overall.SelectedCountry + " WHERE " + "(" + Overall.SelectedCountry + ".[Qty Ordered] > 0 AND " + Overall.SelectedCountry + ".[Del#Conf#Date] = '00/00/0000' AND " + Overall.SelectedCountry + ".[Escaped] IS NULL)" + Filters.FilterQuery,
                
            // KPA -> Purch Total
            "SELECT * FROM " + Overall.SelectedCountry + " WHERE " + "(" + Overall.SelectedCountry + ".[PR 2° Rel# Date] <> '00/00/0000' AND " + Overall.SelectedCountry + ".[Qty Ordered] > 0 AND " + Overall.SelectedCountry + ".[Del#Conf#Date] = '00/00/0000' AND " + Overall.SelectedCountry + ".[Escaped] IS NULL)" + Filters.FilterQuery,
                
            // KPA -> Purch/Plan Total

            // KPA -> Follow Up
            "SELECT * FROM " + Overall.SelectedCountry + " WHERE " + "(" + Overall.SelectedCountry + ".[Qty Ordered] > 0 AND " + Overall.SelectedCountry + ".[Del#Conf#Date] <> '00/00/0000' AND " + Overall.SelectedCountry + ".[Escaped] IS NULL)" + Filters.FilterQuery,
            "SELECT * FROM " + Overall.SelectedCountry + " WHERE " + "(" + Overall.SelectedCountry + ".[Qty Ordered] > 0 AND " + Overall.SelectedCountry + ".[Del#Conf#Date] <> '00/00/0000' AND " + Overall.SelectedCountry + ".[Escaped] IS NULL)" + Filters.FilterQuery,
               
            // KPA -> Cancellations

            // KPA -> NCRs

            // KPA -> Hot Jobs
            "SELECT * FROM " + Overall.SelectedCountry + " WHERE " + "(" + Overall.SelectedCountry + ".[PO Date] = '00/00/0000' AND " + Overall.SelectedCountry + ".[PR 2° Rel# Date] <> '00/00/0000' AND " + Overall.SelectedCountry + ".[Purch# Group] = 'UHJ')" + Filters.FilterQuery,
            "SELECT * FROM " + Overall.SelectedCountry + " WHERE " + "(" + Overall.SelectedCountry + ".[Qty Ordered] > 0 AND " + Overall.SelectedCountry + ".[PO Line 1st Rel Dt] <> '00/00/0000' AND "  + Overall.SelectedCountry + ".[Del#Conf#Date] = '00/00/0000' AND " + Overall.SelectedCountry + ".[Purch# Group] = 'UHJ' AND " + Overall.SelectedCountry + ".[Escaped] IS NULL)" + Filters.FilterQuery,

            // KPA -> Excess Stock - Stock

            // KPA -> Excess Stock - Open Order

            // KPA -> Current Plan vs Actual
            "SELECT * FROM " + Overall.SelectedCountry + " WHERE " + "(" + Overall.SelectedCountry + ".[Qty Ordered] > 0 AND " + Overall.SelectedCountry + ".[Del#Conf#Date] <> '00/00/0000' AND " + Overall.SelectedCountry + ".[Escaped] IS NULL)" + Filters.FilterQuery,
            "SELECT * FROM " + Overall.SelectedCountry + " WHERE " + "(" + Overall.SelectedCountry + ".[Qty Ordered] > 0 AND " + Overall.SelectedCountry + ".[Del#Conf#Date] <> '00/00/0000' AND " + Overall.SelectedCountry + ".[Purch# Group]  = 'UHJ' AND " + Overall.SelectedCountry + ".[Escaped] IS NULL)" + Filters.FilterQuery,

        };
    }
}
