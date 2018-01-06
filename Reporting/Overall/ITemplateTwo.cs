using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.Overall
{
    public interface ITemplateTwo
    {
        double OverallAverage { get; set; }
        int OverallTotalRecords { get; set; }
        int LessthanNegThreeWeeks { get; set; }
        int GreaterThanEqualToNegThreeWeeks { get; set; }
        int GreaterThanEqualToNegTwoWeeks { get; set; }
        int GreaterThanEqualNegOneWeek { get; set; }
        int ZeroWeeks { get; set; }
        int LessThanEqualToOneWeek { get; set; }
        int LessThanEqualToTwoWeeks { get; set; }
        int LessThanEqualToThreeWeeks { get; set; }
        int GreaterThanThreeWeeks { get; set; }
    }
}
