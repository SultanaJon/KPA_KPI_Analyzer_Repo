using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.Overall.TemplateFour
{
    public abstract class TemplateFourPacket : OverallDataPacket
    {
        public override double OverallAverage { get; set; }
        public override int OverallTotalRecords { get; set; }
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




        /// <summary>
        /// 
        /// </summary>
        internal void TimeSpanDump()
        {

        }
    }
}
