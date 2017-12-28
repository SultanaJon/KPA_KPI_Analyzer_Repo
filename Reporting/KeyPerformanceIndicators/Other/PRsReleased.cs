using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.Interfaces;

namespace Reporting.KeyPerformanceIndicators.Other
{
    public sealed class PRsReleased : KeyPerformanceIndicator, ISelectiveVOne
    {
        #region ISelectiveVOne Properties

        /// <summary>
        /// The Average Days for the Selective Calculation
        /// </summary>
        public double SelectiveAverage { get; set; }


        /// <summary>
        /// The total amount of records for the Selective Calculation
        /// </summary>
        public int SelectiveTotalRecords { get; set; }

        #endregion


        /// <summary>
        /// Calculates the selective report for this KPA
        /// </summary>
        public override void CalculateSelectiveReport(string uniqueFilters)
        {

        }
    }
}
