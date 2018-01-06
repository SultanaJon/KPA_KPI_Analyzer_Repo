using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.Overall
{
    public interface ITemplateFive
    {
        decimal TotalValue { get; set; }
        int TotalRecords { get; set; }
        decimal GreaterThanEqualToZeroWeeks { get; set; }
        decimal GreaterThanEqualToNegOneWeek { get; set; }
        decimal GreaterThanEqualToNegTwoWeeks { get; set; }
        decimal GreaterThanEqualToNegThreeWeeks { get; set; }
        decimal GreaterThanEqualToNegFourWeeks { get; set; }
        decimal GreaterThanEqualToNegFiveWeeks { get; set; }
        decimal GreaterThanEqualToNegSixWeeks { get; set; }
        decimal GreaterThanEqualToNegSevenWeeks { get; set; }
        decimal GreaterThanEqualToNegEightWeeks { get; set; }
        decimal LessThanNegEightWeeks { get; set; }
    }
}
