using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.Overall
{
    public interface ITemplateOne
    {
        double Average { get; set; }
        int TotalRecords { get; set; }
        int LessThanEqualToZeroDays { get; set; }
        int OneToThreeDays { get; set; }
        int FourToSevenDays { get; set; }
        int EightToFourteenDays { get; set; }
        int FifteenToTwentyOneDays { get; set; }
        int TwentyTwoToTwentyEightDays { get; set; }
        int TwentyNinePlusDays { get; set; }
    }
}
