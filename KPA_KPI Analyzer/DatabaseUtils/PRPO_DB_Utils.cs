using DataImporter.Access;
using KPA_KPI_Analyzer.Diagnostics;
using KPA_KPI_Analyzer.FilterFeeature;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.DatabaseUtils
{
    public static class PRPO_DB_Utils
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




        #region PROPERTIES
        /// <summary>
        /// The table targeted depending on the focused country (the country table loaded)
        /// </summary>
        public static string TargetCountryTable { get; set; }


        /// <summary>s
        /// data used to check the state of a data removal process.
        /// </summary>
        public static bool DataRemovalProcessStarted { get; set; }
        public static bool DataRemoved { get; set; }
        public static int CompletedDataRemovals { get; set; }
        public static int ScheduledDataRemovals { get; set; }



        /// <summary>
        /// Data used to check the state of a data load process.
        /// </summary>
        public static bool DataLoadProcessStarted { get; set; }
        public static bool DataLoaded { get; set; }
        public static int CompletedDataLoads { get; set; }
        public static int ScheduledDataLoads { get; set; }



        /// <summary>
        /// Boolean used to indicate whether or not the KPI tables are loaded.
        /// </summary>
        public static bool KPITablesLoaded { get; set; }



        /// <summary>
        /// The connection to the access database.
        /// </summary>
        public static OleDbConnection DatabaseConnection { get; set; }




        /// <summary>
        /// Information regarding the Access databse file.
        /// </summary>
        public static AccessInfo AI { get; set; }
        #endregion




        /// <summary>
        /// Callback function to update the progress of a data removal process.
        /// </summary>
        public static void UpdateDataRemovalProgress()
        {

            if(ScheduledDataRemovals == CompletedDataRemovals)
            {
                DataRemoved = true;
            }
        }




        /// <summary>
        /// Callback funcion to update the progress of a data load process.
        /// </summary>
        public static void UpdateDataLoadProgress()
        {
            lock(_updateDataLoadLock)
            {
                if (ScheduledDataLoads == CompletedDataLoads)
                {
                    RenewDataLoadTimer();
                    DataLoaded = true;
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
                PRPO_DB_Utils.CompletedDataLoads++;
                MethodInvoker del = delegate
                {
                    PRPO_DB_Utils.UpdateDataLoadProgress();
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
                if(DatabaseConnection != null)
                    DatabaseConnection.Close();

                Logger.Log(AppDirectoryUtils.LogFile.DbConnectionEvents, "Import Process Started. Database connection dropped.");

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
            catch(Exception)
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
        public static bool RemoveData()
        {
            bool result = false;

            try
            {
                OleDbCommand cmd;
                cmd = new OleDbCommand(Values.StringUtils.removableDataQuery, DatabaseConnection);
                cmd.ExecuteNonQuery();
                result = true;
                CompletedDataRemovals++;
                UpdateDataRemovalProgress();

                #region DELETE
                //if (country == PRPOCommands.DatabaseTables.MainTables.US_PRPO)
                //{
                //    OleDbCommand cmd;
                //    cmd = new OleDbCommand(PRPOCommands.removableUSDataQuery, DatabaseConnection);
                //    cmd.ExecuteNonQuery();
                //    result = true;
                //    CompletedDataRemovals++;
                //    UpdateDataRemovalProgress();
                //}
                //else
                //{
                //    OleDbCommand cmd;
                //    cmd = new OleDbCommand(PRPOCommands.removableMXDataQuery, DatabaseConnection);
                //    cmd.ExecuteNonQuery();
                //    result = true;
                //    CompletedDataRemovals++;
                //    UpdateDataRemovalProgress();
                //}
                #endregion
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
        public static void LoadKPITables()
        {
            prsOnPOsDt = new DataTable();
            posRecCompDt = new DataTable();
            pr2ndLvlRelDateDt = new DataTable();
            AllDt = new DataTable();

            try
            {
                using (OleDbCommand cmd = new OleDbCommand() { Connection = PRPO_DB_Utils.DatabaseConnection })
                {
                    using (OleDbDataAdapter da = new OleDbDataAdapter())
                    {
                        cmd.CommandText = Values.StringUtils.KpiStringUtils.queries[(int)Values.StringUtils.KpiStringUtils.Query.AllPOs] + Filters.FilterQuery;
                        da.SelectCommand = cmd;
                        da.Fill(prsOnPOsDt);

                        cmd.CommandText = Values.StringUtils.KpiStringUtils.queries[(int)Values.StringUtils.KpiStringUtils.Query.POLinesRecComplete] + Filters.FilterQuery;
                        da.SelectCommand = cmd;
                        da.Fill(posRecCompDt);

                        cmd.CommandText = Values.StringUtils.KpiStringUtils.queries[(int)Values.StringUtils.KpiStringUtils.Query.PR_2ndLvlRel] + Filters.FilterQuery;
                        da.SelectCommand = cmd;
                        da.Fill(pr2ndLvlRelDateDt);


                        if (Filters.FilterQuery == string.Empty)
                            cmd.CommandText = Values.StringUtils.KpiStringUtils.queries[(int)Values.StringUtils.KpiStringUtils.Query.AllData];
                        else
                            cmd.CommandText = Values.StringUtils.KpiStringUtils.queries[(int)Values.StringUtils.KpiStringUtils.Query.AllData] + " WHERE " + Filters.SecondaryFilterQuery;

                        da.SelectCommand = cmd;
                        da.Fill(AllDt);



                        KPITablesLoaded = true;
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
        public static void LoadCorrelationFields()
        {
            DataTable tempDt = new DataTable();
            ds = new DataSet();


            using (OleDbCommand cmd = new OleDbCommand() { Connection = PRPO_DB_Utils.DatabaseConnection })
            {
                using (OleDbDataAdapter da = new OleDbDataAdapter())
                {
                    foreach (Values.StringUtils.CorrelationStringUtils.CorrelationMatrixIndexer index in Enum.GetValues(typeof(Values.StringUtils.CorrelationStringUtils.CorrelationMatrixIndexer)))
                    {
                        tempDt = new DataTable();
                        cmd.CommandText = "SELECT " + TargetCountryTable + ".[" + Values.StringUtils.CorrelationStringUtils.correlationQueryHeaders[(int)index] + "], " + TargetCountryTable + ".[" + Values.StringUtils.CorrelationStringUtils.correlationDateRangeFilters[(int)Values.StringUtils.CorrelationStringUtils.CorrelationDateRangeFilters.RequisitionDate] + "], " + TargetCountryTable + ".[" + Values.StringUtils.CorrelationStringUtils.correlationDateRangeFilters[(int)Values.StringUtils.CorrelationStringUtils.CorrelationDateRangeFilters.PoLineCreateDate] + "], " + TargetCountryTable + ".[" + Values.StringUtils.CorrelationStringUtils.correlationDateRangeFilters[(int)Values.StringUtils.CorrelationStringUtils.CorrelationDateRangeFilters.QtyOrdered] + "] FROM " + TargetCountryTable;
                        da.SelectCommand = cmd;
                        da.Fill(tempDt);
                        tempDt.TableName = Values.StringUtils.CorrelationStringUtils.correlationHeaders[(int)index];
                        if (!ds.Tables.Contains(Values.StringUtils.CorrelationStringUtils.correlationHeaders[(int)index]))
                        {
                            ds.Tables.Add(tempDt);
                        }
                    }
                }
            }
            Correlation.CorrelationLoaderUtils.TablesLoaded = true;
        }
    }
}
