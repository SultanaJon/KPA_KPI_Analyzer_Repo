using Excel_Access_Tools.Access;
using KPA_KPI_Analyzer.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.DatabaseUtils
{
    public static class PRPO_DB_Utils
    {
        private static readonly List<string> errorList = new List<string>();



        /// <summary>
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
            if(ScheduledDataLoads == CompletedDataLoads)
            {



                DataLoaded = true;
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
                DatabaseConnection.Close();
                Logger.Log(AppDirectoryUtils.LogFiles.DbConnectionEvents, "Import Process Started. Database connection dropped.");

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
        public static bool RemoveData(PRPOCommands.DatabaseTables.MainTables country)
        {
            bool result = false;
            if (country == PRPOCommands.DatabaseTables.MainTables.US_PRPO)
            {
                OleDbCommand cmd;
                try
                {
                    cmd = new OleDbCommand(PRPOCommands.removableData, DatabaseConnection);
                    cmd.ExecuteNonQuery();
                    result = true;
                    CompletedDataRemovals++;
                    UpdateDataRemovalProgress();                   
                }
                catch(Exception ex)
                {
                    result = false;
                    MessageBox.Show(ex.ToString(), "US Data Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                OleDbCommand cmd;

                try
                {
                    cmd = new OleDbCommand(PRPOCommands.removableData, DatabaseConnection);
                    cmd.ExecuteNonQuery();
                    result = true;
                    CompletedDataRemovals++;
                    UpdateDataRemovalProgress();
                }
                catch (Exception ex)
                {
                    result = false;
                    MessageBox.Show(ex.ToString(), "MX Data Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return result;
        }
    }
}
