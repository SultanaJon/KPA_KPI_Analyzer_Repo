using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.Overall
{
    public interface ITemplateThree
    {
        double Average { get; set; }
        int TotalRecords { get; set; }
        int LessThanEqualToNegTwentyTwoDays { get; set; }
        int NegTwentyOneToNegFifteenDays { get; set; }
        int NegFourteenToNegEightDays { get; set; }
        int NegSevenToNegOneDays { get; set; }
        int ZeroDays { get; set; }
        int OneToSevenDays { get; set; }
        int EightToFourteenDays { get; set; }
        int FifteenToTwentyOneDays { get; set; }
        int GreaterThanEqualToTwentyTwoDays { get; set; }
    }
}
