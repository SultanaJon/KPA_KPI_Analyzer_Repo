using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.Interfaces
{
    public interface IUnconfirmed
    {
        /// <summary>
        /// The total number of records that are unconfirmed
        /// </summary>
        int PercentUnconfirmedTotal { get; set; }


        /// <summary>
        /// The percent of unconfirmed records within the KPA or KPI
        /// </summary>
        double PercentUnconfirmed { get; set; }


        /// <summary>
        /// Calculated the percentage of unconfirmed records
        /// </summary>
        void CalculatePercentUnconfirmed();
    }
}
