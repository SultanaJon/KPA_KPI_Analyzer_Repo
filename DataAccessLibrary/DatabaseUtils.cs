using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    static class DatabaseUtils
    {
        /// <summary>s
        /// data used to check the state of a data removal process.
        /// </summary>
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
    }
}
