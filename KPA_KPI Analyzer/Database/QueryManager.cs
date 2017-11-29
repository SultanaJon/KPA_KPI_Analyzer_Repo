using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KPA_KPI_Analyzer.Values;

namespace KPA_KPI_Analyzer.Database
{
    public static class QueryManager
    {
        /// <summary>
        /// The target database table.
        /// </summary>
        private static string table;


        /// <summary>
        /// Query that removes unessessary United States data from the database.
        /// </summary>
        public static string GetUsRemovableDataQuery()
        {
            return "DELETE * FROM US_PRPO WHERE " + "(US_PRPO.[Open PR Qty] = 0 AND US_PRPO.[Qty Ordered] = 0)";
        }


        /// <summary>
        /// Query that removes unessessary Mexico data from the database.
        /// </summary>
        /// <returns></returns>
        public static string GetMxRemovableDataQuery()
        {
            return "DELETE * FROM MX_PRPO WHERE " + "(MX_PRPO.[Open PR Qty] = 0 AND MX_PRPO.[Qty Ordered] = 0)";
        }


        /// <summary>
        /// Sets the target database table
        /// </summary>
        /// <param name="_country"></param>
        public static void SetDatabaseTable(Countries.Country _country)
        {
            if (_country == Countries.Country.UnitedStates)
                table = DatabaseTables.databaseTables[(int)DatabaseTables.DatabaseTable.UnitedStates];
            else
                table = DatabaseTables.databaseTables[(int)DatabaseTables.DatabaseTable.Mexico];
        }




        /// <summary>
        /// returns the name of the table that the application is targeting in the database.
        /// </summary>
        /// <returns></returns>
        public static string GetDatabaseTableName()
        {
            return table;
        }







        /// <summary>
        /// Queries used to get KPA data.
        /// </summary>
        public static class KpaQueries
        {
            public static class PlanQueries
            {
           
                public static string GetPrsAgingNotReleased()
                {
                    return "SELECT * FROM " + table + " WHERE " + "(" + table + ".[Open PR Qty] > 0 AND " + table + ".[Release Ind#] <> 2)";
                }


                public static string GetMaterialDue()
                {
                    return "SELECT * FROM " + table + " WHERE " + "(" + table + ".[Open PR Qty] > 0 AND " + table + ".[Release Ind#] = 2)";
                }
            }


            public static class PurchQueries
            {
            
                public static string GetPrsAgingReleased()
                {
                    return "SELECT * FROM " + table + " WHERE " + "(" + table + ".[Open PR Qty] > 0 AND " + table + ".[Release Ind#] = 2)";
                }

                public static string GetPoFirstRelease()
                {
                    return "SELECT * FROM " + table + " WHERE " + "(" + table + ".[Qty Ordered] > 0 AND " + table + ".[PO Line 1st Rel Dt] = '00/00/0000')";
                }



                public static string GetPoPrevRelease()
                {
                    return "SELECT * FROM " + table + " WHERE " + "(" + table + ".[Qty Ordered] > 0 AND " + table + ".[PO Line 1st Rel Dt] <> '00/00/0000' AND " + table + ".[PO Sign Date] = '00/00/0000' AND " + table + ".[Escaped] IS NULL)";
                }



                public static string GetNoConfirmations()
                {
                    return "SELECT * FROM " + table + " WHERE " + "(" + table + ".[Qty Ordered] > 0 AND " + table + ".[PO Line 1st Rel Dt] <> '00/00/0000' AND " + table + ".[Del#Conf#Date] = '00/00/0000' AND " + table + ".[Escaped] IS NULL)";
                }
            }



            public static class PurchSubQueries
            {
           
                public static string GetPrReleaseToPoRelease()
                {
                    return "SELECT * FROM " + table + " WHERE " + "(" + table + ".[PO Line 1st Rel Dt] = '00/00/0000' AND " + table + ".[Release Ind#] = 2)";
                }

                public static string GetPoCreationToConfirmationEntry()
                {
                    return "SELECT * FROM " + table + " WHERE " + "(" + table + ".[Qty Ordered] > 0 AND " + table + ".[Del#Conf#Date] = '00/00/0000' AND " + table + ".[Escaped] IS NULL)";
                }
            }



            public static class PurchTotalQueries
            {
                public static string GetPrReleaseToConfirmationEntry()
                {
                    return "SELECT * FROM " + table + " WHERE " + "(" + table + ".[Release Ind#] = 2 AND " + table + ".[Del#Conf#Date] = '00/00/0000' AND " + table + ".[Escaped] IS NULL)";
                }
            }



            public static class FollowUpQueries
            {
            
                public static string GetConfirmedDateVsPlanDate()
                {
                    return "SELECT * FROM " + table + " WHERE " + "(" + table + ".[Qty Ordered] > 0 AND " + table + ".[Del#Conf#Date] <> '00/00/0000' AND " + table + ".[Escaped] IS NULL)";
                }

                public static string GetConfrimedDateForUpcomingDeliveries()
                {
                    return "SELECT * FROM " + table + " WHERE " + "(" + table + ".[Qty Ordered] > 0 AND " + table + ".[Del#Conf#Date] <> '00/00/0000' AND " + table + ".[Escaped] IS NULL)";
                }


                public static string GetDueTodayOrLateToConfirmed()
                {
                    return "SELECT * FROM " + table + " WHERE " + "(" + table + ".[Qty Ordered] > 0 AND " + table + ".[Del#Conf#Date] <> '00/00/0000' AND " + table + ".[Escaped] IS NULL)";
                }
            }



            public static class HotJobsQueries
            {
            
                public static string GetPrsNotOnPo()
                {
                    return "SELECT * FROM " + table + " WHERE " + "(" + table + ".[PO Date] = '00/00/0000' AND " + table + ".[PR 2° Rel# Date] <> '00/00/0000' AND " + table + ".[Purch# Group] = 'UHJ')";

                }

                public static string GetNoConfirmations()
                {
                    return "SELECT * FROM " + table + " WHERE " + "(" + table + ".[Qty Ordered] > 0 AND " + table + ".[Del#Conf#Date] = '00/00/0000' AND " + table + ".[PO Line Creat#DT] <> '00/00/0000' AND " + table + ".[Purch# Group] = 'UHJ' AND " + table + ".[Escaped] IS NULL)";

                }



                public static string GetLateToConfirmed()
                {
                    return "SELECT * FROM " + table + " WHERE " + "(" + table + ".[Qty Ordered] > 0 AND " + table + ".[Del#Conf#Date] <> '00/00/0000' AND " + table + ".[Purch# Group] = 'UHJ' AND " + table + ".[Escaped] IS NULL)";

                }
            }


            public static class ExcessStockStockQueries
            {
           
                public static string GetPrsAgingNotReleased()
                {
                    return "SELECT * FROM " + table + " WHERE " + "(" + table + ".[Open PR Qty] > 0 AND " + table + ".[Release Ind#] <> 2 AND (" + table + ".[Gen# Stock On Hand] > 0 OR " + table + ".[Project Stk On Hand] > 0))";

                }


                public static string GetPrsAgingReleased()
                {
                    return "SELECT * FROM " + table + " WHERE " + "(" + table + ".[Open PR Qty] > 0 AND " + table + ".[Release Ind#] = 2 AND (" + table + ".[Gen# Stock On Hand] > 0 OR " + table + ".[Project Stk On Hand] > 0))";

                }



                public static string GetPoCreationThruDelivery()
                {
                    return "SELECT * FROM " + table + " WHERE " + "(" + table + ".[Qty Ordered] > 0 AND " + table + ".[Escaped] IS NULL AND (" + table + ".[Gen# Stock On Hand] > 0 OR " + table + ".[Project Stk On Hand] > 0))";

                }
            }



            public static class ExcessStockOpenOrdersQueries
            {
           
                public static string GetPrsAgingNotReleased()
                {
                    return "SELECT * FROM " + table + " WHERE " + "(" + table + ".[Open PR Qty] > 0 AND " + table + ".[Release Ind#] <> 2 AND (" + table + ".[General Stock On Ord] > 0 OR " + table + ".[Project Stock On Ord] > 0))";

                }


                public static string GetPrsAgingReleased()
                {
                    return "SELECT * FROM " + table + " WHERE " + "(" + table + ".[Open PR Qty] > 0 AND " + table + ".[Release Ind#] = 2 AND (" + table + ".[General Stock On Ord] > 0 OR " + table + ".[Project Stock On Ord] > 0))";

                }



                public static string GetPoCreationThruDelivery()
                {
                    return "SELECT * FROM " + table + " WHERE " + "(" + table + ".[Qty Ordered] > 0 AND " + table + ".[Escaped] IS NULL AND (" + table + ".[General Stock On Ord] > 0 OR " + table + ".[Project Stock On Ord] > 0))";

                }
            }



            public static class CurrentPlanVsActualQueries
            {

                public static string GetCurrentPlanDateVsCurrentConfirmationDate()
                {
                    return "SELECT * FROM " + table + " WHERE " + "(" + table + ".[Qty Ordered] > 0 AND " + table + ".[Del#Conf#Date] <> '00/00/0000' AND " + table + ".[Escaped] IS NULL)";

                }

                public static string GetCurrentPlanDateVsCurrentConfirmationDateForHotJobs()
                {
                    return "SELECT * FROM " + table + " WHERE " + "(" + table + ".[Qty Ordered] > 0 AND " + table + ".[Del#Conf#Date] <> '00/00/0000' AND " + table + ".[Purch# Group]  = 'UHJ' AND " + table + ".[Escaped] IS NULL)";
                }
            }
        }


        /// <summary>
        /// Queries used to get KPI data.
        /// </summary>
        public static class KpiQueries
        {
            public static string GetAllPOs()
            {
                return "SELECT * FROM " + table + " WHERE " + "(" + table + ".[Qty Ordered] > 0)";
            }


            public static string GetPoLinesUnconfirmed()
            {
                return "SELECT * FROM " + table + " WHERE " + "(" + table + ".[Qty Ordered] > 0 AND " + table + ".[Del#Conf#Date] = '00/00/0000')";
            }


            public static string GetPoLinesReceivedComplete()
            {
                return "SELECT * FROM " + table + " WHERE " + "(" + table + ".[Escaped] IS NOT NULL)";

            }


            public static string GetUnconfirmedReceivedCompletePoLines()
            {
                return "SELECT * FROM " + table + " WHERE " + "(" + table + ".[Escaped] IS NOT NULL AND " + table + ".[Del#Conf#Date] = '00/00/0000')";

            }


            public static string GetPr2ndLevelRelease()
            {
                return "SELECT * FROM " + table + " WHERE " + "(" + table + ".[Release ind#] = 2)";

            }

            public static string GetAllData()
            {
                return "SELECT * FROM " + table;
            }
        }
    }
}