using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.Overall
{
    public abstract class OverallDataPacket
    {
        public abstract double OverallAverage { get; set; }
        public abstract int OverallTotalRecords { get; set; }


        /// <summary>
        /// Dfeault Constructor
        /// </summary>
        public OverallDataPacket()
        {

        }


        /// <summary>
        /// Abstract method to run elapsed days for specific KPA OR KPI against time span conditions.
        /// </summary>
        /// <param name="_elapsedDays">The number of elapsed days</param>
        internal abstract void TimeSpanDump(double _elapsedDays);
    }
}
