using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.Overall.TemplateFive
{
    public abstract class TemplateFivePacket : OverallDataPacket
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
        /// 
        /// </summary>
        internal void TimeSpanDump()
        {

        }
    }
}
