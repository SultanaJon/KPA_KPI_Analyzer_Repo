using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataImporter.Access;

namespace KPA_KPI_Analyzer.Values
{
    internal static class Globals
    {
        /// <summary>
        /// The SelectedCountry that the user selected to load into the application.
        /// </summary>
        public static AccessInfo.MainTables SelectedCountry { get; set; }

    }
}
