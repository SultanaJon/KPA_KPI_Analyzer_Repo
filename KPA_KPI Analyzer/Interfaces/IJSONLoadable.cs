using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPA_KPI_Analyzer.Interfaces
{
    public interface IJSONLoadable<T>
    {
        /// <summary>
        /// Loads the JSON file into the application and stores it into a T object
        /// </summary>
        /// <param name="obj">The object to be loaded.</param>
        /// <returns>Boolean value indicating whether or not the Load operation was successful.</returns>
        void Load(ref T obj);
    }
}