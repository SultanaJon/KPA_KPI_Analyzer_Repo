using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.Overall.TemplateThree
{
    public abstract class TemplateThreePacket : OverallDataPacket
    {
        public override double OverallAverage { get; set; }
        public override int OverallTotalRecords { get; set; }
        public int LessThanEqualToNegTwentyTwoDays { get; set; }
        public int NegTwentyOneToNegFifteenDays { get; set; }
        public int NegFourteenToNegEightDays { get; set; }
        public int NegSevenToNegOneDays { get; set; }
        public int ZeroDays { get; set; }
        public int OneToSevenDays { get; set; }
        public int EightToFourteenDays { get; set; }
        public int FifteenToTwentyOneDays { get; set; }
        public int GreaterThanEqualToTwentyTwoDays { get; set; }



        /// <summary>
        /// 
        /// </summary>
        internal void TimeSpanDump()
        {

        }
    }
}
