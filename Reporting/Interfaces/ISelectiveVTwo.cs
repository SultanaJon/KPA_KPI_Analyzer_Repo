using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.Interfaces
{
    public interface ISelectiveVTwo
    {
        double SelectiveAverage { get; set; }
        int SelectiveTotalRecords { get; set; }
        double SelectivePercentFavorable { get; set; }
    }
}
