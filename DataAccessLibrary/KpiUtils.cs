using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAccessLibrary
{
    public static class KpiUtils
    {
        public static class KpiQueries
        {
            public static DataTable GetAllPOs()
            {
                DataTable dt = new DataTable();

                try
                {
                    OleDbConnection conn = DatabaseManager.GetDatabaseConnection();
                    string cmdString = "SELECT * FROM " + DatabaseManager.TargetTable + 
                        " WHERE " + "(" + DatabaseManager.TargetTable + ".[Qty Ordered] > 0)" + DatabaseManager.Filters;

                    OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                    da.Fill(dt);

                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Invalid Operation Exception was thrown", "Get PRs Aging Not Released Error", MessageBoxButtons.OK);
                }

                return dt;
            }

            public static DataTable GetPoLinesUnconfirmed()
            {
                DataTable dt = new DataTable();

                try
                {
                    OleDbConnection conn = DatabaseManager.GetDatabaseConnection();
                    string cmdString = "SELECT * FROM " + DatabaseManager.TargetTable + 
                                        " WHERE " + "(" + DatabaseManager.TargetTable + ".[Qty Ordered] > 0 AND " + 
                                        DatabaseManager.TargetTable + ".[Del#Conf#Date] = '00/00/0000')" + DatabaseManager.Filters;


                    OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                    da.Fill(dt);

                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Invalid Operation Exception was thrown", "Get PRs Aging Not Released Error", MessageBoxButtons.OK);
                }

                return dt;
            }

            public static DataTable GetPoLinesReceivedComplete()
            {
                DataTable dt = new DataTable();

                try
                {
                    OleDbConnection conn = DatabaseManager.GetDatabaseConnection();
                    string cmdString = "SELECT * FROM " + DatabaseManager.TargetTable + 
                        " WHERE " + "(" + DatabaseManager.TargetTable + ".[Escaped] IS NOT NULL)" + DatabaseManager.Filters;


                    OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                    da.Fill(dt);

                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Invalid Operation Exception was thrown", "Get PRs Aging Not Released Error", MessageBoxButtons.OK);
                }

                return dt;
            }

            public static DataTable GetUnconfirmedReceivedCompletePoLines()
            {
                DataTable dt = new DataTable();

                try
                {
                    OleDbConnection conn = DatabaseManager.GetDatabaseConnection();
                    string cmdString = "SELECT * FROM " + DatabaseManager.TargetTable + " WHERE " + "(" + 
                                        DatabaseManager.TargetTable + ".[Escaped] IS NOT NULL AND " + 
                                        DatabaseManager.TargetTable + ".[Del#Conf#Date] = '00/00/0000')" + DatabaseManager.Filters;

                    OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                    da.Fill(dt);

                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Invalid Operation Exception was thrown", "Get PRs Aging Not Released Error", MessageBoxButtons.OK);
                }

                return dt;
            }

            public static DataTable GetPr2ndLevelRelease()
            {
                DataTable dt = new DataTable();

                try
                {
                    OleDbConnection conn = DatabaseManager.GetDatabaseConnection();
                    string cmdString = "SELECT * FROM " + DatabaseManager.TargetTable + 
                        " WHERE " + "(" + DatabaseManager.TargetTable + ".[Release ind#] = 2)" + DatabaseManager.Filters;


                    OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                    da.Fill(dt);

                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Invalid Operation Exception was thrown", "Get PRs Aging Not Released Error", MessageBoxButtons.OK);
                }

                return dt;
            }

            public static DataTable GetAllData()
            {
                DataTable dt = new DataTable();
                string cmdString = string.Empty;

                try
                {
                    OleDbConnection conn = DatabaseManager.GetDatabaseConnection();

                    if(DatabaseManager.Filters == string.Empty || DatabaseManager.Filters == null)
                    {
                        cmdString = "SELECT * FROM " + DatabaseManager.TargetTable;
                    }
                    else
                    {
                        cmdString = "SELECT * FROM " + DatabaseManager.TargetTable + " WHERE " + DatabaseManager.SecondaryFilters;
                    }


                    OleDbCommand cmd = new OleDbCommand(cmdString, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                    da.Fill(dt);

                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Invalid Operation Exception was thrown", "Get PRs Aging Not Released Error", MessageBoxButtons.OK);
                }

                return dt;
            }
        }
    }
}
