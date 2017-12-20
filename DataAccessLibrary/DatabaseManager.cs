using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAccessLibrary
{
    class DatabaseManager
    {
        public static DataTable prsOnPOsDt;
        public static DataTable posRecCompDt;
        public static DataTable pr2ndLvlRelDateDt;
        public static DataTable AllDt;
        public static DataSet ds;

        private static readonly List<string> errorList = new List<string>();


        // Call back function to renew the data loader timer.
        public delegate void RenewDataLoadTimerHandler();
        public static event RenewDataLoadTimerHandler RenewDataLoadTimer;

        // Callback function to display the drag drop feature.
        public delegate void DisplayDragDropPageHandler();
        public static event DisplayDragDropPageHandler DisplayDragDropPage;


        public static volatile object _updateDataLoadLock = new object();
        public static volatile object locker = new object();




        /// <summary>
        /// The connection to the access database.
        /// </summary>
        public static OleDbConnection DatabaseConnection { get; set; }




        /// <summary>
        /// Information regarding the Access databse file.
        /// </summary>
        public static AccessInfo AI { get; set; }



        /// <summary>
        /// Callback function to update the progress of a data removal process.
        /// </summary>
        public static void UpdateDataRemovalProgress()
        {

            if (DatabaseUtils.ScheduledDataRemovals == DatabaseUtils.CompletedDataRemovals)
            {
                DatabaseUtils.DataRemoved = true;
            }
        }




        /// <summary>
        /// Callback funcion to update the progress of a data load process.
        /// </summary>
        public static void UpdateDataLoadProgress()
        {
            lock (_updateDataLoadLock)
            {
                if (DatabaseUtils.ScheduledDataLoads == DatabaseUtils.CompletedDataLoads)
                {
                    RenewDataLoadTimer();
                    DatabaseUtils.DataLoaded = true;
                }
            }
        }





        /// <summary>
        /// Checks the status of the data loading.
        /// </summary>
        public static void UpdateLoadProgress()
        {
            lock (locker)
            {
                DatabaseUtils.CompletedDataLoads++;
                MethodInvoker del = delegate
                {
                    UpdateDataLoadProgress();
                };
                del.Invoke();
            }
        }





        /// <summary>
        /// Check certain conditions and drops the access database every time PRPO reports are imported. This is
        /// important becauase the database will continue to grow in size.
        /// </summary>
        public static bool DropCreateDb()
        {
            bool result = false;

            // delete the database because after so many imports, the database will continue to get larger and take up space.
            try
            {
                if (DatabaseConnection != null)
                    DatabaseConnection.Close();

                File.Delete(Configuration.DbPath);
                AccessUtils.CreateAccessDB();
                result = true;
            }
            catch (Exception ex)
            {
                // Something happened while deleting the file
                MessageBox.Show(ex.Message, "Database Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            return result;
        }




        /// <summary>
        /// Connect to the database. If the connection does not exist, create one and connect to it.
        /// </summary>
        public static bool ConnectToDatabase()
        {
            bool result = false;

            try
            {
                if (DatabaseConnection != null)
                {
                    DatabaseConnection.Open();
                }
                else
                {
                    DatabaseConnection = new OleDbConnection(AI.connectionString());
                    DatabaseConnection.Open();
                }
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }



        /// <summary>
        /// When the data removal timer is started under KPA_KPI_UI.cs, this function will be called. This function
        /// will remove the data that is no needed and we do not want to fall into our calculations.
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static bool RemoveData(Countries.Country _country)
        {
            bool result = false;

            try
            {
                if (_country == Countries.Country.UnitedStates)
                {
                    OleDbCommand cmd;
                    cmd = new OleDbCommand(Queries.GetUsRemovableDataQuery(), DatabaseConnection);
                    cmd.ExecuteNonQuery();
                    result = true;
                    DatabaseUtils.CompletedDataRemovals++;
                    UpdateDataRemovalProgress();
                }
                else
                {
                    OleDbCommand cmd;
                    cmd = new OleDbCommand(Queries.GetMxRemovableDataQuery(), DatabaseConnection);
                    cmd.ExecuteNonQuery();
                    result = true;
                    DatabaseUtils.CompletedDataRemovals++;
                    UpdateDataRemovalProgress();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("The data being imported seems to contain incorrect or no data. Please check to see if the data is corrupted. If the report contains corrupted data, please contact your SAP Administrator.", "Corrupted Data Detection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DropCreateDb();
                DisplayDragDropPage();
            }
            return result;
        }



        /// <summary>
        /// Loads the data that will be used in the KPI sections for data calculations
        /// </summary>
        public static void LoadKPITables(string filters, string secondaryFilters)
        {
            prsOnPOsDt = new DataTable();
            posRecCompDt = new DataTable();
            pr2ndLvlRelDateDt = new DataTable();
            AllDt = new DataTable();

            try
            {
                using (OleDbCommand cmd = new OleDbCommand() { Connection = DatabaseConnection })
                {
                    using (OleDbDataAdapter da = new OleDbDataAdapter())
                    {
                        cmd.CommandText = Queries.KpiQueries.GetAllPOs() + filters;
                        da.SelectCommand = cmd;
                        da.Fill(prsOnPOsDt);

                        cmd.CommandText = Queries.KpiQueries.GetPoLinesReceivedComplete() + filters;
                        da.SelectCommand = cmd;
                        da.Fill(posRecCompDt);

                        cmd.CommandText = Queries.KpiQueries.GetPr2ndLevelRelease() + filters;
                        da.SelectCommand = cmd;
                        da.Fill(pr2ndLvlRelDateDt);


                        if (filters == string.Empty)
                            cmd.CommandText = Queries.KpiQueries.GetAllData();
                        else
                            cmd.CommandText = Queries.KpiQueries.GetAllData() + " WHERE " + secondaryFilters;

                        da.SelectCommand = cmd;
                        da.Fill(AllDt);



                        DatabaseUtils.KPITablesLoaded = true;
                        UpdateLoadProgress();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPI Data Load");
                throw new ThreadInteruptedException();
            }
        }




        /// <summary>
        /// Free the KPI tables back to the free store
        /// </summary>
        public static void ReleaseKPITables()
        {
            prsOnPOsDt.Clear();
            prsOnPOsDt = null;
            posRecCompDt.Clear();
            posRecCompDt = null;
            pr2ndLvlRelDateDt.Clear();
            pr2ndLvlRelDateDt = null;
            AllDt.Clear();
            AllDt = null;
            GC.Collect();
        }




        /// <summary>
        /// Loads the correlation columns into a dataset.
        /// </summary>
        //public static void LoadCorrelationFields()
        //{
        //    DataTable tempDt = new DataTable();
        //    ds = new DataSet();


        //    using (OleDbCommand cmd = new OleDbCommand() { Connection = DatabaseConnection })
        //    {
        //        using (OleDbDataAdapter da = new OleDbDataAdapter())
        //        {
        //            foreach (Correlation.CorrelationHeaders.CorrelationMatrixIndexer index in Enum.GetValues(typeof(Correlation.CorrelationHeaders.CorrelationMatrixIndexer)))
        //            {
        //                tempDt = new DataTable();
        //                cmd.CommandText = "SELECT " + Database.QueryManager.GetDatabaseTableName() + ".[" + Correlation.CorrelationHeaders.correlationQueryHeaders[(int)index] + "], " + Database.QueryManager.GetDatabaseTableName() + ".[" + Correlation.CorrelationHeaders.correlationDateRangeFilters[(int)Correlation.CorrelationHeaders.CorrelationDateRangeFilters.RequisitionDate] + "], " + Database.QueryManager.GetDatabaseTableName() + ".[" + Correlation.CorrelationHeaders.correlationDateRangeFilters[(int)Correlation.CorrelationHeaders.CorrelationDateRangeFilters.PoLineCreateDate] + "], " + Database.QueryManager.GetDatabaseTableName() + ".[" + Correlation.CorrelationHeaders.correlationDateRangeFilters[(int)Correlation.CorrelationHeaders.CorrelationDateRangeFilters.QtyOrdered] + "] FROM " + Database.QueryManager.GetDatabaseTableName();
        //                da.SelectCommand = cmd;
        //                da.Fill(tempDt);
        //                tempDt.TableName = Correlation.CorrelationHeaders.correlationHeaders[(int)index];
        //                if (!ds.Tables.Contains(Correlation.CorrelationHeaders.correlationHeaders[(int)index]))
        //                {
        //                    ds.Tables.Add(tempDt);
        //                }
        //            }
        //        }
        //    }
        //    Correlation.CorrelationLoaderUtils.TablesLoaded = true;
        //}
    }
}
