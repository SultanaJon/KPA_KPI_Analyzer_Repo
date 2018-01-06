using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.Overall.TemplateFive
{
    public class TemplateFivePacket : OverallDataPacket
    {
        public override double OverallAverage { get; set; }
        public override int OverallTotalRecords { get; set; }
        int GreaterThanEqualToZeroWeeks { get; set; }
        int GreaterThanEqualToNegOneWeek { get; set; }
        int GreaterThanEqualToNegTwoWeeks { get; set; }
        int GreaterThanEqualToNegThreeWeeks { get; set; }
        int GreaterThanEqualToNegFourWeeks { get; set; }
        int GreaterThanEqualToNegFiveWeeks { get; set; }
        int GreaterThanEqualToNegSixWeeks { get; set; }
        int GreaterThanEqualToNegSevenWeeks { get; set; }
        int GreaterThanEqualToNegEightWeeks { get; set; }
        int LessThanNegEightWeeks { get; set; }



        /// <summary>
        /// Run the supplied elspased days against the time span conditions
        /// </summary>
        /// <param name="_elapsedDays">The number of days elapsed</param>
        internal override void TimeSpanDump(double _elapsedDays)
        {
            double weeks = Math.Floor(_elapsedDays / 7);

            OverallTotalRecords++;


            if (weeks >= 0)
            {
                GreaterThanEqualToZeroWeeks++;
            }
            else if (weeks >= (-1) && weeks < 0)
            {
                GreaterThanEqualToNegOneWeek++;
            }
            else if (weeks >= (-2) && weeks < (-1))
            {
                GreaterThanEqualToNegTwoWeeks++;
            }
            else if (weeks >= (-3) && weeks < (-2))
            {
                GreaterThanEqualToNegThreeWeeks++;
            }
            else if (weeks >= (-4) && weeks < (-3))
            {
                GreaterThanEqualToNegFourWeeks++;
            }
            else if (weeks >= (-5) && weeks < (-4))
            {
                GreaterThanEqualToNegFiveWeeks++;
            }
            else if (weeks >= (-6) && weeks < (-5))
            {
                GreaterThanEqualToNegSixWeeks++;
            }
            else if (weeks >= (-7) && weeks < (-6))
            {
                GreaterThanEqualToNegSevenWeeks++;
            }
            else if (weeks >= (-8) && weeks < (-7))
            {
                GreaterThanEqualToNegEightWeeks++;
            }
            else if (weeks < (-8))
            {
                LessThanNegEightWeeks++;
            }
        }
    }
}
