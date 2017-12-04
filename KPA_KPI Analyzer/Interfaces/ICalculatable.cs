using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPA_KPI_Analyzer.Interfaces
{
    interface ICalculatable
    {
        /// <summary>
        /// Calculates the specific KPA or KPI
        /// </summary>
        void Calculate();
    }
}
