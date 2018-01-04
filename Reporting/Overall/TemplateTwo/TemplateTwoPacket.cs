using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.Overall.TemplateTwo
{
    public abstract class TemplateTwoPacket : OverallDataPacket
    {
        public override double OverallAverage { get; set; }
        public override int OverallTotalRecords { get; set; }
        public int LessthanNegThreeWeeks { get; set; }
        public int GreaterThanEqualToNegThreeWeeks { get; set; }
        public int GreaterThanEqualToNegTwoWeeks { get; set; }
        public int GreaterThanEqualNegOneWeek { get; set; }
        public int ZeroWeeks { get; set; }
        public int LessThanEqualToOneWeek { get; set; }
        public int LessThanEqualToTwoWeeks { get; set; }
        public int LessThanEqualToThreeWeeks { get; set; }
        public int GreaterThanThreeWeeks { get; set; }


        /// <summary>
        /// 
        /// </summary>
        internal void TimeSpanDump()
        {

        }
    }
}
