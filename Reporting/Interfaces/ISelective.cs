using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.Interfaces
{
    public interface ISelective
    {
        /// <summary>
        /// The selective average for the filter applied against the specific KPA or KPI
        /// </summary>
        double SelectiveAverage { get; set; }

        /// <summary>
        /// The selective total fo the filter applied against the specific KPA or KPI
        /// </summary>
        int SelectiveTotal { get; set; }
    }
}
