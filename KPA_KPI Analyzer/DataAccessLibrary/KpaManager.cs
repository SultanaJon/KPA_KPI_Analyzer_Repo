using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace DataAccessLibrary
{
    public static class KpaUtils
    {
        public static class PlanQueries
        {
            /// <summary>
            /// KPA -> Plan -> Gets all PRs aging that have not been released.
            /// </summary>
            /// <returns>A data table containing the results.</returns>
            public static DataTable GetPrsAgingNotReleased()
            {
                DataTable dt = new DataTable();

                try
                {
                    OleDbConnection conn = DatabaseManager.GetDatabaseConnection();
                    string cmdString = "SELECT * FROM " + DatabaseManager.TargetTable +
                                       " WHERE " + "(" + DatabaseManager.TargetTable + ".[Open PR Qty] > 0 AND " +
                                       DatabaseManager.TargetTable + ".[Release Ind#] <> 2)" + DatabaseManager.Filters;

                    OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                    da.Fill(dt);

                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Invalid Operation Exception was thrown", "Plan - Get PRs Aging Not Released Error", MessageBoxButtons.OK);
                }

                return dt;
            }





            /// <summary>
            /// KPA -> PLan -> Gets all PRs that have material due.
            /// </summary>
            /// <returns>A Data table containing the data.</returns>
            public static DataTable GetMaterialDue()
            {
                DataTable dt = new DataTable();

                try
                {
                    OleDbConnection conn = DatabaseManager.GetDatabaseConnection();
                    string cmdString = "SELECT * FROM " + DatabaseManager.TargetTable + 
                                       " WHERE " + "(" + DatabaseManager.TargetTable + ".[Open PR Qty] > 0 AND " + 
                                       DatabaseManager.TargetTable + ".[Release Ind#] = 2)" + DatabaseManager.Filters;

                    OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                    da.Fill(dt);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Invalid Operation Exception was thrown", "Plan - Get Material Due Error", MessageBoxButtons.OK);
                }

                return dt;
            }
        }


        public static class PurchQueries
        {
            /// <summary>
            /// KPA -> Purch -> Gets all PRs that have been release and are aging.
            /// </summary>
            /// <returns>Returns a data table containing the data.</returns>
            public static DataTable GetPrsAgingReleased()
            {
                DataTable dt = new DataTable();

                try
                {
                    OleDbConnection conn = DatabaseManager.GetDatabaseConnection();
                    string cmdString =  "SELECT * FROM " + DatabaseManager.TargetTable + 
                                        " WHERE " + "(" + DatabaseManager.TargetTable + ".[Open PR Qty] > 0 AND " + 
                                        DatabaseManager.TargetTable + ".[Release Ind#] = 2)" + DatabaseManager.Filters;


                    OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                    da.Fill(dt);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Invalid Operation Exception was thrown", "Purch - Get PRs Aging Released Error", MessageBoxButtons.OK);
                }

                return dt;
            }




            /// <summary>
            /// KPA -> Purch -> Gets all POs that have been released at least once.
            /// </summary>
            /// <returns>A data table containing the data</returns>
            public static DataTable GetPoFirstRelease()
            {
                DataTable dt = new DataTable();

                try
                {
                    OleDbConnection conn = DatabaseManager.GetDatabaseConnection();
                    string cmdString = "SELECT * FROM " + DatabaseManager.TargetTable + 
                                       " WHERE " + "(" + DatabaseManager.TargetTable + ".[Qty Ordered] > 0 AND " + 
                                       DatabaseManager.TargetTable + ".[PO Line 1st Rel Dt] = '00/00/0000')" + DatabaseManager.Filters;



                    OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                    da.Fill(dt);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Invalid Operation Exception was thrown", "Purch - Get PRs Aging Not Released Error", MessageBoxButtons.OK);
                }

                return dt;
            }




            /// <summary>
            /// KPA -> Purch -> Gets all POs that have not been released at least once.
            /// </summary>
            /// <returns>A data table containingthe data.</returns>
            public static DataTable GetPoPrevRelease()
            {
                DataTable dt = new DataTable();

                try
                {
                    OleDbConnection conn = DatabaseManager.GetDatabaseConnection();
                    string cmdString = "SELECT * FROM " + DatabaseManager.TargetTable + 
                                       " WHERE " + "(" + DatabaseManager.TargetTable + ".[Qty Ordered] > 0 AND " + 
                                       DatabaseManager.TargetTable + ".[PO Line 1st Rel Dt] <> '00/00/0000' AND " + 
                                       DatabaseManager.TargetTable + ".[PO Sign Date] = '00/00/0000' AND " + 
                                       DatabaseManager.TargetTable + ".[Escaped] IS NULL)" + DatabaseManager.Filters;



                    OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                    da.Fill(dt);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Invalid Operation Exception was thrown", "Purch - Get PRs Aging Not Released Error", MessageBoxButtons.OK);
                }

                return dt;
            }




            /// <summary>
            /// KPA -> Purch -> Gets all POs that have not been released and do not have a confirmation date.
            /// </summary>
            /// <returns>A data table containing the data.</returns>
            public static DataTable GetNoConfirmations()
            {
                DataTable dt = new DataTable();

                try
                {
                    OleDbConnection conn = DatabaseManager.GetDatabaseConnection();
                    string cmdString = "SELECT * FROM " + DatabaseManager.TargetTable + 
                                       " WHERE " + "(" + DatabaseManager.TargetTable + ".[Qty Ordered] > 0 AND " + 
                                       DatabaseManager.TargetTable + ".[PO Line 1st Rel Dt] <> '00/00/0000' AND " +
                                       DatabaseManager.TargetTable + ".[Del#Conf#Date] = '00/00/0000' AND " + 
                                       DatabaseManager.TargetTable + ".[Escaped] IS NULL)" + DatabaseManager.Filters;

                    OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                    da.Fill(dt);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Invalid Operation Exception was thrown", "Purch - Get PRs Aging Not Released Error", MessageBoxButtons.OK);
                }

                return dt;
            }
        }



        public static class PurchSubQueries
        {
            /// <summary>
            /// KPA -> Purch Sub -> Gets all records where there is no original PO release date and a PR release indicator of 2.
            /// </summary>
            /// <returns>A data table containing the data.</returns>
            public static DataTable GetPrReleaseToPoRelease()
            {
                DataTable dt = new DataTable();

                try
                {
                    OleDbConnection conn = DatabaseManager.GetDatabaseConnection();
                    string cmdString = "SELECT * FROM " + DatabaseManager.TargetTable + 
                                       " WHERE " + "(" + DatabaseManager.TargetTable + ".[PO Line 1st Rel Dt] = '00/00/0000' AND " + 
                                       DatabaseManager.TargetTable + ".[Release Ind#] = 2)" + DatabaseManager.Filters;

                    OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                    da.Fill(dt);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Invalid Operation Exception was thrown", "Purch Sub - Get PRs Aging Not Released Error", MessageBoxButtons.OK);
                }

                return dt;
            }



            /// <summary>
            /// KPA -> Purch Sub -> Gets all POs that have no delivery confirmationd date and have no been received complete.
            /// </summary>
            /// <returns>A data table containing the data.</returns>
            public static DataTable GetPoCreationToConfirmationEntry()
            {
                DataTable dt = new DataTable();

                try
                {
                    OleDbConnection conn = DatabaseManager.GetDatabaseConnection();
                    string cmdString = "SELECT * FROM " + DatabaseManager.TargetTable + 
                                       " WHERE " + "(" + DatabaseManager.TargetTable + ".[Qty Ordered] > 0 AND " + 
                                       DatabaseManager.TargetTable + ".[Del#Conf#Date] = '00/00/0000' AND " + 
                                       DatabaseManager.TargetTable + ".[Escaped] IS NULL)" + DatabaseManager.Filters;


                    OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                    da.Fill(dt);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Invalid Operation Exception was thrown", "Purch Sub - Get PRs Aging Not Released Error", MessageBoxButtons.OK);
                }

                return dt;
            }
        }



        public static class PurchTotalQueries
        {
            /// <summary>
            /// KPA -> Purch Total -> Gets all PRs that have been fully released, have not been received complete and have no delviery confirmation date.
            /// </summary>
            /// <returns>A data table containing the data.</returns>
            public static DataTable GetPrReleaseToConfirmationEntry()
            {
                DataTable dt = new DataTable();

                try
                {
                    OleDbConnection conn = DatabaseManager.GetDatabaseConnection();
                    string cmdString = "SELECT * FROM " + DatabaseManager.TargetTable + 
                                       " WHERE " + "(" + DatabaseManager.TargetTable + ".[Release Ind#] = 2 AND " + 
                                       DatabaseManager.TargetTable + ".[Del#Conf#Date] = '00/00/0000' AND " + 
                                       DatabaseManager.TargetTable + ".[Escaped] IS NULL)" + DatabaseManager.Filters;

                    OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                    da.Fill(dt);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Invalid Operation Exception was thrown", "Purch Total - Get PRs Aging Not Released Error", MessageBoxButtons.OK);
                }

                return dt;
            }
        }



        public static class FollowUpQueries
        {
            /// <summary>
            /// KPA -> Follow Up -> Gets all the POs that have a qty ordered > 0, and delivery confirmation date that is not 00/00/0000, and have not been receive complete.
            /// </summary>
            /// <returns>A data table containging the data.</returns>
            public static DataTable GetConfirmedDateVsPlanDate()
            {
                DataTable dt = new DataTable();

                try
                {
                    OleDbConnection conn = DatabaseManager.GetDatabaseConnection();
                    string cmdString = "SELECT * FROM " + DatabaseManager.TargetTable + 
                                       " WHERE " + "(" + DatabaseManager.TargetTable + ".[Qty Ordered] > 0 AND " + 
                                       DatabaseManager.TargetTable + ".[Del#Conf#Date] <> '00/00/0000' AND " + 
                                       DatabaseManager.TargetTable + ".[Escaped] IS NULL)" + DatabaseManager.Filters;

                    OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                    da.Fill(dt);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Invalid Operation Exception was thrown", "Follow Up - Get PRs Aging Not Released Error", MessageBoxButtons.OK);
                }

                return dt;
            }



            /// <summary>
            /// KPA -> Follow Up -> Get all the POs where the qty ordered is greater than 0, its has been confirmed for delivery, and has no been received complete.
            /// </summary>
            /// <returns>A data table containing the data.</returns>
            public static DataTable GetConfrimedDateForUpcomingDeliveries()
            {
                DataTable dt = new DataTable();

                try
                {
                    OleDbConnection conn = DatabaseManager.GetDatabaseConnection();
                    string cmdString = "SELECT * FROM " + DatabaseManager.TargetTable + 
                                       " WHERE " + "(" + DatabaseManager.TargetTable + ".[Qty Ordered] > 0 AND " + 
                                       DatabaseManager.TargetTable + ".[Del#Conf#Date] <> '00/00/0000' AND " + 
                                       DatabaseManager.TargetTable + ".[Escaped] IS NULL)" + DatabaseManager.Filters;

                    OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                    da.Fill(dt);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Invalid Operation Exception was thrown", "Follow Up - Get PRs Aging Not Released Error", MessageBoxButtons.OK);
                }

                return dt;
            }



            /// <summary>
            /// KPA -> Follow Up -> Get all the POs that have a delivery confirmation date, and have not been receive complete.
            /// </summary>
            /// <returns>A data table containging the data.</returns>
            public static DataTable GetDueTodayOrLateToConfirmed()
            {
                DataTable dt = new DataTable();

                try
                {
                    OleDbConnection conn = DatabaseManager.GetDatabaseConnection();
                    string cmdString = "SELECT * FROM " + DatabaseManager.TargetTable + 
                                       " WHERE " + "(" + DatabaseManager.TargetTable + ".[Qty Ordered] > 0 AND " + 
                                       DatabaseManager.TargetTable + ".[Del#Conf#Date] <> '00/00/0000' AND " + 
                                       DatabaseManager.TargetTable + ".[Escaped] IS NULL)" + DatabaseManager.Filters;


                    OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                    da.Fill(dt);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Invalid Operation Exception was thrown", "Follow Up - Get PRs Aging Not Released Error", MessageBoxButtons.OK);
                }

                return dt;
            }
        }



        public static class HotJobsQueries
        {
            /// <summary>
            /// KPA -> Hot Jobs -> Get all hot job PRs where there is no PO date and has been release to the second level.
            /// </summary>
            /// <returns>A data table containing the data.</returns>
            public static DataTable GetPrsNotOnPo()
            {
                DataTable dt = new DataTable();

                try
                {
                    OleDbConnection conn = DatabaseManager.GetDatabaseConnection();
                    string cmdString = "SELECT * FROM " + DatabaseManager.TargetTable + " WHERE " + "(" + 
                                       DatabaseManager.TargetTable + ".[PO Date] = '00/00/0000' AND " + 
                                       DatabaseManager.TargetTable + ".[PR 2° Rel# Date] <> '00/00/0000' AND " + 
                                       DatabaseManager.TargetTable + ".[Purch# Group] = 'UHJ')" + DatabaseManager.Filters;

                    OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                    da.Fill(dt);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Invalid Operation Exception was thrown", "Hot Jobs - Get PRs Aging Not Released Error", MessageBoxButtons.OK);
                }

                return dt;
            }



            /// <summary>
            /// KPA -> Hot Jobs -> Get all hot job POs that have not been confirmed for delivery and has not been received complete.
            /// </summary>
            /// <returns>A data table containing the data.</returns>
            public static DataTable GetNoConfirmations()
            {
                DataTable dt = new DataTable();

                try
                {
                    OleDbConnection conn = DatabaseManager.GetDatabaseConnection();
                    string cmdString = "SELECT * FROM " + DatabaseManager.TargetTable + " WHERE " + "(" + 
                                        DatabaseManager.TargetTable + ".[Qty Ordered] > 0 AND " + 
                                        DatabaseManager.TargetTable + ".[Del#Conf#Date] = '00/00/0000' AND " + 
                                        DatabaseManager.TargetTable + ".[PO Line Creat#DT] <> '00/00/0000' AND " + 
                                        DatabaseManager.TargetTable + ".[Purch# Group] = 'UHJ' AND " + 
                                        DatabaseManager.TargetTable + ".[Escaped] IS NULL)" + DatabaseManager.Filters;


                    OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                    da.Fill(dt);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Invalid Operation Exception was thrown", "Hot Jobs - Get PRs Aging Not Released Error", MessageBoxButtons.OK);
                }

                return dt;
            }



            /// <summary>
            /// KPA -> Hot Jobs -> Gets all hot job POs where there is no confirmation for delivery and has not been receive complete.
            /// </summary>
            /// <returns>A data table containing the data.</returns>
            public static DataTable GetLateToConfirmed()
            {
                DataTable dt = new DataTable();

                try
                {
                    OleDbConnection conn = DatabaseManager.GetDatabaseConnection();
                    string cmdString = "SELECT * FROM " + DatabaseManager.TargetTable + 
                                        " WHERE " + "(" + DatabaseManager.TargetTable + ".[Qty Ordered] > 0 AND " + 
                                        DatabaseManager.TargetTable + ".[Del#Conf#Date] <> '00/00/0000' AND " + 
                                        DatabaseManager.TargetTable + ".[Purch# Group] = 'UHJ' AND " + 
                                        DatabaseManager.TargetTable + ".[Escaped] IS NULL)" + DatabaseManager.Filters;


                    OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                    da.Fill(dt);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Invalid Operation Exception was thrown", "Hot Jobs - Get PRs Aging Not Released Error", MessageBoxButtons.OK);
                }

                return dt;
            }
        }


        public static class ExcessStockStockQueries
        {
            /// <summary>
            /// KPA -> Excess Stock - Stock -> Gets all PRs that have not been released to the second level, the general stock on hand is greater than 0 and the project stock on hand is greater than 0.
            /// </summary>
            /// <returns>A data table containing the data.</returns>
            public static DataTable GetPrsAgingNotReleased()
            {
                DataTable dt = new DataTable();

                try
                {
                    OleDbConnection conn = DatabaseManager.GetDatabaseConnection();
                    string cmdString = "SELECT * FROM " + DatabaseManager.TargetTable + " WHERE " + "(" + 
                                        DatabaseManager.TargetTable + ".[Open PR Qty] > 0 AND " + 
                                        DatabaseManager.TargetTable + ".[Release Ind#] <> 2 AND (" + 
                                        DatabaseManager.TargetTable + ".[Gen# Stock On Hand] > 0 OR " + 
                                        DatabaseManager.TargetTable + ".[Project Stk On Hand] > 0))" + DatabaseManager.Filters;


                    OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                    da.Fill(dt);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Invalid Operation Exception was thrown", "Excess Stock (Stock) - Get PRs Aging Not Released Error", MessageBoxButtons.OK);
                }

                return dt;
            }




            /// <summary>
            /// KPA -> Excess Stock - Stock -> Gets all PRs w/ a release indicator of 2, the general stock on hand is > 0 and the project stock on hand is > 0.
            /// </summary>
            /// <returns>A data table containing the data</returns>
            public static DataTable GetPrsAgingReleased()
            {
                DataTable dt = new DataTable();

                try
                {
                    OleDbConnection conn = DatabaseManager.GetDatabaseConnection();
                    string cmdString = "SELECT * FROM " + DatabaseManager.TargetTable + 
                                        " WHERE " + "(" + DatabaseManager.TargetTable + ".[Open PR Qty] > 0 AND " + 
                                        DatabaseManager.TargetTable + ".[Release Ind#] = 2 AND (" + 
                                        DatabaseManager.TargetTable + ".[Gen# Stock On Hand] > 0 OR " + 
                                        DatabaseManager.TargetTable + ".[Project Stk On Hand] > 0))" + DatabaseManager.Filters;

                    OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                    da.Fill(dt);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Invalid Operation Exception was thrown", "Excess Stock (Stock) - Get PRs Aging Not Released Error", MessageBoxButtons.OK);
                }

                return dt;
            }




            /// <summary>
            /// KPA -> Excess Stock -Stock -> Gets all the POs that have not been receive complete, the general stock on hand is greater than 0, and the project stock on hand is > 0.
            /// </summary>
            /// <returns>A data table containgin the data.</returns>
            public static DataTable GetPoCreationThruDelivery()
            {
                DataTable dt = new DataTable();

                try
                {
                    OleDbConnection conn = DatabaseManager.GetDatabaseConnection();
                    string cmdString = "SELECT * FROM " + DatabaseManager.TargetTable + 
                                        " WHERE " + "(" + DatabaseManager.TargetTable + ".[Qty Ordered] > 0 AND " + 
                                        DatabaseManager.TargetTable + ".[Escaped] IS NULL AND (" + 
                                        DatabaseManager.TargetTable + ".[Gen# Stock On Hand] > 0 OR " + 
                                        DatabaseManager.TargetTable + ".[Project Stk On Hand] > 0))" + DatabaseManager.Filters;


                    OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                    da.Fill(dt);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Invalid Operation Exception was thrown", "Excess Stock (Stock) - Get PRs Aging Not Released Error", MessageBoxButtons.OK);
                }

                return dt;
            }
        }



        public static class ExcessStockOpenOrdersQueries
        {
            /// <summary>
            /// KPA -> Excess Stock - Open Orders -> Gets all the PRs that have not been released to the second level AND (the general stock on order is greater than 0 OR the project stock con order is greater 0)
            /// </summary>
            /// <returns>A data table containing the data.</returns>
            public static DataTable GetPrsAgingNotReleased()
            {
                DataTable dt = new DataTable();

                try
                {
                    OleDbConnection conn = DatabaseManager.GetDatabaseConnection();
                    string cmdString = "SELECT * FROM " + DatabaseManager.TargetTable + 
                                        " WHERE " + "(" + DatabaseManager.TargetTable + ".[Open PR Qty] > 0 AND " + 
                                        DatabaseManager.TargetTable + ".[Release Ind#] <> 2 AND (" + 
                                        DatabaseManager.TargetTable + ".[General Stock On Ord] > 0 OR " + 
                                        DatabaseManager.TargetTable + ".[Project Stock On Ord] > 0))" + DatabaseManager.Filters;


                    OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                    da.Fill(dt);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Invalid Operation Exception was thrown", "Excess Stock (Open Orders) - Get PRs Aging Not Released Error", MessageBoxButtons.OK);
                }

                return dt;
            }




            /// <summary>
            /// KPA -> Excess Stock - Open Orders -> Gets all the PRs that have been released to the 2nd level, and (general stock on order > 0 or the project stock on order is > 0)
            /// </summary>
            /// <returns></returns>
            public static DataTable GetPrsAgingReleased()
            {
                DataTable dt = new DataTable();

                try
                {
                    OleDbConnection conn = DatabaseManager.GetDatabaseConnection();
                    string cmdString = "SELECT * FROM " + DatabaseManager.TargetTable + 
                                        " WHERE " + "(" + DatabaseManager.TargetTable + ".[Open PR Qty] > 0 AND " + 
                                        DatabaseManager.TargetTable + ".[Release Ind#] = 2 AND (" + 
                                        DatabaseManager.TargetTable + ".[General Stock On Ord] > 0 OR " + 
                                        DatabaseManager.TargetTable + ".[Project Stock On Ord] > 0))" + DatabaseManager.Filters;

                    OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                    da.Fill(dt);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Invalid Operation Exception was thrown", "Excess Stock (Open Orders) - Get PRs Aging Not Released Error", MessageBoxButtons.OK);
                }

                return dt;
            }




            /// <summary>
            /// KPA -> Excess Stock - Open Orders -> Gets all POs that have not been received complete AND have a general stock on order > 0 OR a project stock on order > 0
            /// </summary>
            /// <returns></returns>
            public static DataTable GetPoCreationThruDelivery()
            {
                DataTable dt = new DataTable();

                try
                {
                    OleDbConnection conn = DatabaseManager.GetDatabaseConnection();
                    string cmdString = "SELECT * FROM " + DatabaseManager.TargetTable + 
                                        " WHERE " + "(" + DatabaseManager.TargetTable + ".[Qty Ordered] > 0 AND " + 
                                        DatabaseManager.TargetTable + ".[Escaped] IS NULL AND (" + 
                                        DatabaseManager.TargetTable + ".[General Stock On Ord] > 0 OR " + 
                                        DatabaseManager.TargetTable + ".[Project Stock On Ord] > 0))" + DatabaseManager.Filters;


                    OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                    da.Fill(dt);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Invalid Operation Exception was thrown", "Excess Stock (Open Orders) - Get PRs Aging Not Released Error", MessageBoxButtons.OK);
                }

                return dt;
            }
        }



        public static class CurrentPlanVsActualQueries
        {
            /// <summary>
            /// KPA -> Current Plan vs Actual -> Gers all teh POs where there is a confirmation for delivery and has not been received complete.
            /// </summary>
            /// <returns></returns>
            public static DataTable GetCurrentPlanDateVsCurrentConfirmationDate()
            {
                DataTable dt = new DataTable();

                try
                {
                    OleDbConnection conn = DatabaseManager.GetDatabaseConnection();
                    string cmdString = "SELECT * FROM " + DatabaseManager.TargetTable + 
                                        " WHERE " + "(" + DatabaseManager.TargetTable + ".[Qty Ordered] > 0 AND " + 
                                        DatabaseManager.TargetTable + ".[Del#Conf#Date] <> '00/00/0000' AND " + 
                                        DatabaseManager.TargetTable + ".[Escaped] IS NULL)" + DatabaseManager.Filters;


                    OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                    da.Fill(dt);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Invalid Operation Exception was thrown", "Current Plan vs Actual - Get PRs Aging Not Released Error", MessageBoxButtons.OK);
                }

                return dt;
            }



            /// <summary>
            /// KPA -> Current Plan vs Actual -> Gets all hot job POs where there is a confirmation for delivery and has not been received complete.
            /// </summary>
            /// <returns></returns>
            public static DataTable GetCurrentPlanDateVsCurrentConfirmationDateForHotJobs()
            {
                DataTable dt = new DataTable();

                try
                {
                    OleDbConnection conn = DatabaseManager.GetDatabaseConnection();
                    string cmdString = "SELECT * FROM " + DatabaseManager.TargetTable + 
                                        " WHERE " + "(" + DatabaseManager.TargetTable + ".[Qty Ordered] > 0 AND " + 
                                        DatabaseManager.TargetTable + ".[Del#Conf#Date] <> '00/00/0000' AND " + 
                                        DatabaseManager.TargetTable + ".[Purch# Group]  = 'UHJ' AND " + 
                                        DatabaseManager.TargetTable + ".[Escaped] IS NULL)" + DatabaseManager.Filters;


                    OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                    da.Fill(dt);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Invalid Operation Exception was thrown", "Current Plan vs Actual - Get PRs Aging Not Released Error", MessageBoxButtons.OK);
                }

                return dt;
            }
        }
    }
}
