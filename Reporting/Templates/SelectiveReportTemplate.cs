using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.Templates
{
    class SelectiveReportTemplate
    {
        public double Average { get; set; }
        public int Total { get; set; }



        public SelectiveReportTemplate()
        {
            Average = default(double);
            Total = default(int);
        }
    }
}
