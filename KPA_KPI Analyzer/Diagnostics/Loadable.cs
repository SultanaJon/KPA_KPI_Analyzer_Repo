using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPA_KPI_Analyzer.Diagnostics
{
    interface Loadable<T>
    {
        /// <summary>
        /// Loads the supplied parameter from a JSON file.
        /// </summary>
        /// <param name="obj">The object to hold the loaded data</param>
        /// <returns>returns a boolean indicating whether or not the load completed without errors.</returns>
        bool Load(T obj);
    }
}
