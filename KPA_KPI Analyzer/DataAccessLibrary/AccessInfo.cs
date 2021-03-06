﻿using System.Data.OleDb;

namespace DataAccessLibrary
{
    public class AccessInfo
    {
        /// <summary>
        /// File path of where the data should be imported
        /// </summary>
        public string Path { get; set; }





        /// <summary>
        /// The name of the table we are importing to.
        /// </summary>
        public string TableName { get; set; }








        /// <summary>
        /// Indexer enumeration used to index through mainTableNames
        /// </summary>
        public enum MainTables
        {
            US_PRPO,
            MX_PRPO,
        }






        /// <summary>
        /// The names of the main tables that will hold all of the excel data
        /// </summary>
        public static string[] mainTableNames =
        {
            "US_PRPO", "MX_PRPO",
        };



        public AccessInfo(string _path)
        {
            Path = _path;
        }





        /// <summary>
        /// This function will will build and return the connection string for connecting to the access
        /// database.
        /// </summary>
        public string connectionString()
        {
            OleDbConnectionStringBuilder connStrBldr = new OleDbConnectionStringBuilder()
            {
                Provider = "Microsoft.ACE.OLEDB.12.0",
                DataSource = Path
            };

            return connStrBldr.ConnectionString;
        }
    }
}
