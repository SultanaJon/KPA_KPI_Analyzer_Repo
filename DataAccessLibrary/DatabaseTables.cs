using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    class DatabaseTables
    {
        /// <summary>
        /// 
        /// </summary>
        public enum DatabaseTable
        {
            UnitedStates,
            Mexico
        }



        /// <summary>
        /// The names of the main tables that will hold all of the excel data
        /// </summary>
        public static string[] databaseTables =
        {
            "US_PRPO",
            "MX_PRPO"
        };
    }
}
