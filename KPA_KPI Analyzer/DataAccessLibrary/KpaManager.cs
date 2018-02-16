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
