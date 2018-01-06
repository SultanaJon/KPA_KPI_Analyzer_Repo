using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.Overall
{
    public interface ITemplateFour
    {
        double OverallAverage { get; set; }
        int OverallTotalRecords { get; set; }
        int LessThanEqualToZeroDays { get; set; }
        int OneToThreeDays { get; set; }
        int FourToSevenDays { get; set; }
        int EightToFourteenDays { get; set; }
        int FifteenToTwentyOneDays { get; set; }
        int TwentyTwoToTwentyEightDays { get; set; }
        int TwentyNineToThirtyFiveDays { get; set; }
        int ThirtySixtoFourtyTwoDays { get; set; }
        int FourtyThreeToFourtyNineDays { get; set; }
        int FiftyToFiftySixDays { get; set; }
        int FiftySevenPlusDays { get; set; }
    }
}
