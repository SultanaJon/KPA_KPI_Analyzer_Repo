using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.Selective
{
    class KpiSelectiveReport : Report
    {
        /// <summary>
        /// A list of the filters the user would like to create a 
        /// kpa report of.
        /// </summary>
        List<string> selection;
    }
}
