using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPA_KPI_Analyzer.Diagnostics
{
    interface Storable<T>
    {
        /// <summary>
        /// Save stores the supplied paramter object into a JSON file.
        /// </summary>
        /// <param name="obj">The object to be saved to a JSON file.</param>
        /// <returns>Returns a boolean indicating whether or not the save operation completed without error.</returns>
        bool Save(T obj);
    }
}
