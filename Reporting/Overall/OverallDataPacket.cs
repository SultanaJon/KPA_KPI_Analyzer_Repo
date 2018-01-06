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

        internal abstract void TimeSpanDump(double _elapsedDays);
    }
}
