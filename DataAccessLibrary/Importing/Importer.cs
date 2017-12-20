using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelLibrary;
using System.Windows.Forms;
using System.Threading;
using System.Data.OleDb;

namespace AccessDatabaseLibrary.Importing
{
    public class Importer
    {
        private int recordCount = 0;

        // delegate & event to handle the event when a thread completes an import.
        public delegate void ImportProgressHandler(int numImports, int compImports);
        public static event ImportProgressHandler ImportProgress;




        /// <summary>
        /// Information regarding the excel file used when importing
        /// </summary>
        public ExcelInfo ExcelInformation { get; set; }




        /// <summary>
        /// Access information regarding the access database we will import into.
        /// </summary>
        public AccessInfo AccessInformation { get; set; }




        /// <summary>
        /// Data used to report the progress of an import process
        /// </summary>
        public static int NumberOfImports { get; set; }
        public static int CompletedImports { get; set; }
        public static bool ImportComplete { get; set; }




        /// <summary>
        /// The number of records that were read in from the excel file.
        /// </summary>
        public int RecordCount
        {
            get
            {
                return recordCount;
            }
        }




        /// <summary>
        /// Custom constructor that takes excel Information and access information
        /// </summary>
        /// <param name="excelData">The information about the excel file being imported into access</param>
        /// <param name="accessData">The information about the access file that will hold the data.</param>
        public Importer(ExcelInfo excelData, AccessInfo accessData)
        {
            ExcelInformation = excelData;
            AccessInformation = accessData;
        }





        /// <summary>
        /// Setup the import process.
        /// </summary>
        /// <param name="_importCount">The number of file being imported</param>
        public static void SetupImportSettings(int _importCount)
        {
            NumberOfImports = _importCount;
            ImportComplete = false;
            CompletedImports = 0;
        }




        /// <summary>
        /// This function will perform the import of the excel data into access
        /// </summary>
        public void Run()
        {
            if (AccessDatabaseUtils.US_PRPO_TableExists || AccessDatabaseUtils.MX_PRPO_TableExists)
            {
                if (Thread.CurrentThread.Name == "US")
                {
                    if (AccessDatabaseUtils.US_PRPO_TableExists)
                    {
                        MethodInvoker dropUSTableDel = delegate
                        {
                            DatabaseManager.DropTable(DatabaseManager.AI.connectionString(), AccessInfo.mainTableNames[(int)AccessInfo.MainTables.US_PRPO]);
                        };
                        dropUSTableDel.Invoke();
                    }
                }

                if (Thread.CurrentThread.Name == "MX")
                {
                    if (AccessDatabaseUtils.MX_PRPO_TableExists)
                    {
                        MethodInvoker dropMXTableDel = delegate
                        {
                            DatabaseManager.DropTable(DatabaseManager.AI.connectionString(), AccessInfo.mainTableNames[(int)AccessInfo.MainTables.MX_PRPO]);
                        };
                        dropMXTableDel.Invoke();
                    }
                }
            }



            try
            {
                using (OleDbConnection conn = new OleDbConnection(ExcelInformation.connectionString()))
                {
                    using (OleDbCommand cmd = new OleDbCommand() { Connection = conn })
                    {
                        cmd.CommandText = @"SELECT * INTO [MS Access;Database=" + AccessInformation.FileName + "].[" + AccessInformation.TableName + "] FROM [" + ExcelInformation.SheetName + "]";
                        conn.Open();
                        recordCount = cmd.ExecuteNonQuery();
                        CompletedImports++;
                        conn.Close();

                        if (Thread.CurrentThread.Name == "US")
                        {
                            AccessDatabaseUtils.US_PRPO_TableExists = true;
                        }
                        if (Thread.CurrentThread.Name == "MX")
                        {
                            AccessDatabaseUtils.MX_PRPO_TableExists = true;
                        }

                        // This import was successfull. Report the progress
                        ImportProgress(NumberOfImports, CompletedImports);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error while importing the data. Please contact a KPA-KPI Analyzer administrator for assistance", "Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new ThreadInterruptedException();
            }
        }
    }
}
