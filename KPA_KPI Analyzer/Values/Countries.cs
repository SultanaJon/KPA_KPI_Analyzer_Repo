using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPA_KPI_Analyzer.Values
{
    public static class Countries
    {
        /// <summary>
        /// Index values for the handled coutries.
        /// </summary>
        public enum Country
        {
            UnitedStates,
            Mexico
        }


        // Array of countries that the application handles.
        public static string[] countries =
        {
            "United States",
            "Mexico"
        };
    }
}
