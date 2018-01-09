using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting
{
    /// <summary>
    /// Index values for the handled coutries.
    /// </summary>
    public enum Country
    {
        UnitedStates,
        Mexico
    }




    public class ReportingCountry
    {
        // Array of countries that the application handles.
        public static string[] countries =
        {
            "United States",
            "Mexico"
        };



        /// <summary>
        /// The target country for the reporting
        /// </summary>
        public static Country TargetCountry { get; set; }
    }
}
