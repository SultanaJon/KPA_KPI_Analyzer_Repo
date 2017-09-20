using DataImporter.Access.ExceptionClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace DataImporter.Access
{
    public static class AccessUtils
    {
        /// <summary>
        /// The directory Path of the application
        /// </summary>
        public static string AppDirectoryPath { get; set; }





        /// <summary>
        /// 
        /// </summary>
        public static string DatabasePath { get; set; }






        /// <summary>
        /// Boolean value indicating wheather or not the US PRPO table exists
        /// </summary>
        public static bool US_PRPO_TableExists { get; set; }





        /// <summary>
        /// Boolean vlue indicating whether or not the MX PRPO table exists
        /// </summary>
        public static bool MX_PRPO_TableExists { get; set; }





        /// <summary>
        /// Boolean value indicating whether or not the database exists
        /// </summary>
        public static bool DatabaseExists { get; set; }





        /// <summary>
        /// Information regarding the Access databse file.
        /// </summary>
        public static AccessInfo AI { get; set; }





        /// <summary>
        /// Check the database. If the database does not exist, throw an exeption so it can be created.
        /// If the database tables do not exist, thow an exception so the program can continue.
        /// </summary>
        /// <exception cref="PRPODatabaseNotFoundException"></exception>
        public static void CheckDatabase()
        {
            if (!File.Exists(AI.FileName))
            {
                throw new PRPODatabaseNotFoundException("The PRPO Database does not exists");
            }
            else
            {
                DatabaseExists = true;
                US_PRPO_TableExists = false;
                MX_PRPO_TableExists = false;
                TablesExist();
            }
        }





        /// <summary>
        /// Checks if the database contains a table. if it does this means that the data might be from the 
        /// day before. If there is a table we want to delete it and create a new one with todays PRPO data.
        /// </summary>
        /// <exception cref="TableNameMismatchException"></exception>
        /// <exception cref="TablesDoNotExistException"></exception>
        /// <param name="connStr">The connection string to the access database</param>
        /// <returns>
        /// Returns wheather or not the access database contains a table.
        /// </returns>
        public static void TablesExist()
        {
            string[] restrictionValue = new string[4] { null, null, null, "TABLE" };
            List<string> dbTableName = new List<string>();
            AccessInfo AI = new AccessInfo() { FileName = DatabasePath };
            OleDbConnection accConn = new OleDbConnection(AI.connectionString());




            try
            {
                accConn.Open();
                DataTable schemaInformation = accConn.GetSchema("Tables", restrictionValue);



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
                            throw new TableNameMismatchException("The MS Access Tables are named incorrectly.");
                        else
                        {
                            if (name == AccessInfo.mainTableNames[(int)AccessInfo.MainTables.US_PRPO])
                            {
                                US_PRPO_TableExists = true;
                                //ExcelInfo.USUpdated = true;
                            }


                            if (name == AccessInfo.mainTableNames[(int)AccessInfo.MainTables.MX_PRPO])
                            {
                                MX_PRPO_TableExists = true;
                                //ExcelInfo.MXUpdated = true;
                            }
                        }
                    }
                }
                else
                {
                    throw new TablesDoNotExistException("The database exists but the tables do not.");
                }
            }
            catch (TablesDoNotExistException)
            {
                throw new TablesDoNotExistException("The database exists but the tables do not.");
            }
            catch (TableNameMismatchException)
            {
                throw new TableNameMismatchException("One or more of the MS Access Table are named incorrectly.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Existing Table Check");
            }
            finally
            {
                accConn.Close();
            }
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
            OleDbConnection conn = new OleDbConnection(connStr);
            OleDbCommand cmd = new OleDbCommand() { Connection = conn };

            try
            {
                using (conn)
                {
                    using (cmd)
                    {
                        conn.Open();
                        cmd.CommandText = "DROP TABLE [" + tableName + "]";
                        cmd.ExecuteNonQuery();
                        result = true;
                    }
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
            //ADOX.Table table = new ADOX.Table();

            if (!File.Exists(AI.FileName))
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
                    US_PRPO_TableExists = false;
                    MX_PRPO_TableExists = false;
                }
                catch (Exception)
                {
                    throw new DatabaseCreationFailureException("There was an error while creating the MS Access Database.");
                }
            }
            return result;
        }
    }
}
