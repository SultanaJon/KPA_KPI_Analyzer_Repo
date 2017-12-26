using AccessDatabaseLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace AccessDatabaseLibrary
{
    public static class DatabaseManager
    {
        public static DataTable prsOnPOsDt;
        public static DataTable posRecCompDt;
        public static DataTable pr2ndLvlRelDateDt;
        public static DataTable AllDt;
        public static DataSet ds;


        // Call back function to renew the data loader timer.
        public delegate void RenewDataLoadTimerHandler();
        public static event RenewDataLoadTimerHandler RenewDataLoadTimer;



        // Callback function to display the drag drop feature.
        public delegate void DisplayDragDropPageHandler();
        public static event DisplayDragDropPageHandler DisplayDragDropPage;



        public static volatile object _updateDataLoadLock = new object();
        public static volatile object locker = new object();




        /// <summary>
        /// Information regarding the Access databse file.
        /// </summary>
        public static AccessInfo AI { get; private set; }




        /// <summary>
        /// The connection to the access database.
        /// </summary>
        private static OleDbConnection DatabaseConnection { get; set; }





        /// <summary>
        /// Returns the connection to the database
        /// </summary>
        /// <returns></returns>
        public static OleDbConnection GetDatabaseConnection()
        {
            return DatabaseConnection;
        }




        /// <summary>
        /// Accepts the passed in AccessInfo object that it uses to build a connection string
        /// used to create an instance of an OleDbConnection.
        /// </summary>
        /// <param name="ai">An instance of an AccessInfo object</param>
        public static void Configure(AccessInfo ai)
        {
            if(ai != null)
            {
                AI = ai;
                DatabaseConnection = new OleDbConnection(AI.connectionString());
            }
        }



        /// <summary>
        /// Callback function to update the progress of a data removal process.
        /// </summary>
        public static void UpdateDataRemovalProgress()
        {

            if (DatabaseDataRemovalUtils.ScheduledDataRemovals == DatabaseDataRemovalUtils.CompletedDataRemovals)
            {
                DatabaseDataRemovalUtils.DataRemoved = true;
            }
        }




        /// <summary>
        /// Callback funcion to update the progress of a data load process.
        /// </summary>
        public static void UpdateDataLoadProgress()
        {
            lock (_updateDataLoadLock)
            {
                if (DatabaseLoadingUtils.ScheduledDataLoads == DatabaseLoadingUtils.CompletedDataLoads)
                {
                    RenewDataLoadTimer();
                    DatabaseLoadingUtils.DataLoaded = true;
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
                DatabaseLoadingUtils.CompletedDataLoads++;
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

                // Delete the database
                File.Delete(AI.Path);

                // Create the new database
                CreateAccessDB();

                // Connect to the new database
                ConnectToDatabase();

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
                if(DatabaseConnection != null)
                {
                    DatabaseConnection.Open();
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch(InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Invalid Operation Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            catch(OleDbException ex)
            {
                MessageBox.Show(ex.Message, "OleDbException", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            return result;
        }





        /// <summary>
        /// Diconnnects the connection between the applciation and the databse.
        /// </summary>
        /// <returns></returns>
        public static bool DisconnectFromDatabase()
        {
            bool result = false;

            if (DatabaseConnection != null)
            {
                DatabaseConnection.Close();
                result = true;
            }
            else
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
        public static bool RemoveData(DatabaseTables.DatabaseTable _table)
        {
            bool result = false;

            try
            {
                if (_table == DatabaseTables.DatabaseTable.UnitedStates)
                {
                    OleDbCommand cmd;
                    cmd = new OleDbCommand(Queries.GetUsRemovableDataQuery(), DatabaseConnection);
                    cmd.ExecuteNonQuery();
                    result = true;
                    DatabaseDataRemovalUtils.CompletedDataRemovals++;
                    UpdateDataRemovalProgress();
                }
                else
                {
                    OleDbCommand cmd;
                    cmd = new OleDbCommand(Queries.GetMxRemovableDataQuery(), DatabaseConnection);
                    cmd.ExecuteNonQuery();
                    result = true;
                    DatabaseDataRemovalUtils.CompletedDataRemovals++;
                    UpdateDataRemovalProgress();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Data Deletion Error");

                // Recreate the database
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



                        DatabaseLoadingUtils.KPITablesLoaded = true;
                        UpdateLoadProgress();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPI Data Load");
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
        /// Checks if the database contains a table. if it does this means that the data might be from the 
        /// day before. If there is a table we want to delete it and create a new one with todays PRPO data.
        /// </summary>
        /// <returns>
        /// Returns wheather or not the access database contains a table.
        /// </returns>
        public static bool CheckForTables()
        {
            string[] restrictionValue = new string[4] { null, null, null, "TABLE" };
            List<string> dbTableName = new List<string>();
            bool result = false;

            AccessDatabaseUtils.DatabaseExists = true;
            AccessDatabaseUtils.US_PRPO_TableExists = false;
            AccessDatabaseUtils.MX_PRPO_TableExists = false;

            DataTable schemaInformation = DatabaseConnection.GetSchema("Tables", restrictionValue);
              
            // Check if the access tables exist in the database.
            if (schemaInformation.Rows.Count != 0)
            {
                foreach (DataRow row in schemaInformation.Rows)
                {
                    dbTableName.Add(row.ItemArray[2].ToString());
                }

                // Loop throught the tables within the database and make sure the names are correct.
                foreach (var name in dbTableName)
                {
                    if (name != AccessInfo.mainTableNames[(int)AccessInfo.MainTables.US_PRPO] & name != AccessInfo.mainTableNames[(int)AccessInfo.MainTables.MX_PRPO])
                    {
                        result = false;
                    }
                    else
                    {
                        if (name == AccessInfo.mainTableNames[(int)AccessInfo.MainTables.US_PRPO])
                        {
                            AccessDatabaseUtils.US_PRPO_TableExists = true;
                            result = true;
                        }


                        if (name == AccessInfo.mainTableNames[(int)AccessInfo.MainTables.MX_PRPO])
                        {
                            AccessDatabaseUtils.MX_PRPO_TableExists = true;
                            result = true;
                        }
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;
        }





        /// <summary>
        /// This function will drop the MS Access table that exists.
        /// </summary>
        /// <param name="connStr"> The conenction string to the access database file</param>
        /// <param name="tblName"> The table name in the access file.</param>
        /// <returns></returns>
        public static bool DropTable(string connStr, string tableName)
        {
            bool result = false;

            try
            {
                using(OleDbCommand cmd = new OleDbCommand() { Connection = DatabaseConnection })
                {
                    cmd.CommandText = "DROP TABLE [" + tableName + "]";
                    cmd.ExecuteNonQuery();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Drop Table Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }





        /// <summary>
        /// This function will create the database that will be used for retreiving the PRPO data.
        /// </summary>
        /// <exception cref="DatabaseCreationFailureException"></exception>
        /// <returns>
        /// A boolean value indicating whether or not he database was created.
        /// </returns>
        public static bool CreateAccessDB()
        {
            bool result = false;

            ADOX.Catalog cat = new ADOX.Catalog();

            if (!File.Exists(AI.Path))
            {
                try
                {
                    cat.Create(AI.connectionString());
                    ADODB.Connection con = cat.ActiveConnection as ADODB.Connection;
                    if (con != null)
                    {
                        con.Close();
                    }
                    result = true;
                    AccessDatabaseUtils.US_PRPO_TableExists = false;
                    AccessDatabaseUtils.MX_PRPO_TableExists = false;
                }
                catch (Exception)
                {
                    throw new DatabaseCreationFailureException("There was an error while creating the MS Access Database.");
                }
            }
            return result;
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
        //                cmd.CommandText = "SELECT " + Queries.GetDatabaseTableName() + ".[" + Correlation.CorrelationHeaders.correlationQueryHeaders[(int)index] + "], " + Queries.GetDatabaseTableName() + ".[" + Correlation.CorrelationHeaders.correlationDateRangeFilters[(int)Correlation.CorrelationHeaders.CorrelationDateRangeFilters.RequisitionDate] + "], " + Queries.GetDatabaseTableName() + ".[" + Correlation.CorrelationHeaders.correlationDateRangeFilters[(int)Correlation.CorrelationHeaders.CorrelationDateRangeFilters.PoLineCreateDate] + "], " + Queries.GetDatabaseTableName() + ".[" + Correlation.CorrelationHeaders.correlationDateRangeFilters[(int)Correlation.CorrelationHeaders.CorrelationDateRangeFilters.QtyOrdered] + "] FROM " + Queries.GetDatabaseTableName();
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
