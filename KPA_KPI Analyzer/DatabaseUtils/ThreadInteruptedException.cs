using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPA_KPI_Analyzer.DatabaseUtils
{
    class ThreadInteruptedException : Exception
    {
        public ThreadInteruptedException() { }
        public ThreadInteruptedException(string message) : base(message) { }
    }
}
