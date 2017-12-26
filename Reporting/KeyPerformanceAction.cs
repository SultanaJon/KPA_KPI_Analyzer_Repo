using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting
{
    public abstract class KeyPerformanceAction
    {
        public string ActionSection { get; set; }
        public string ActionCategory { get; set; }
        public string TooltipOne { get; set; }
        public string TooltipTwo { get; set; }


        public abstract void CalculateSelectiveReport(string filter);
    }
}
