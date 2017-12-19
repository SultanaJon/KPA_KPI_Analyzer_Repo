using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting
{
    abstract class KeyPerformanceAction
    {
        public KeyPerformanceActionSections.Section Section { get; set; }
    }
}