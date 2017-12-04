using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPA_KPI_Analyzer.Interfaces
{
    interface IFavorable
    {
        /// <summary>
        /// Percentage of records that are favorable
        /// </summary>
        double PercentFavorable { get; set; }

        /// <summary>
        /// Calculates the percentage of favorable records
        /// </summary>
        void CalculatePercentFavorable();
    }
}
