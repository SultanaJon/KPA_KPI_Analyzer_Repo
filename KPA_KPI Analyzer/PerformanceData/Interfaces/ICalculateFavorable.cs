using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPA_KPI_Analyzer.PerformanceData.Interfaces
{
    public interface ICalculateFavorable
    {
        /// <summary>
        /// The Percent of favorable records.
        /// </summary>
        double PercentFavorable { get; set; }

        /// <summary>
        /// Calculates the percentage of favorable records.
        /// </summary>
        void CalculatePercentFavorable();
    }
}
