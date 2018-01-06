using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.Overall.TemplateTwo
{
    public class TemplateTwoPacket : OverallDataPacket
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
        /// Calculates the average for this KPA
        /// </summary>
        internal void CalculateAverage(double _totalDays)
        {
            try
            {
                OverallAverage = Math.Round(_totalDays / OverallTotalRecords, 2);
                if (double.IsNaN(OverallAverage))
                    OverallAverage = 0;
            }
            catch (DivideByZeroException)
            {
                OverallAverage = 0;
            }
        }



        /// <summary>
        /// Run the supplied elspased days against the time span conditions
        /// </summary>
        /// <param name="_elapsedDays">The number of days elapsed</param>
        internal override void TimeSpanDump(double _elapsedDays)
        {
            // need to convert the elapsed days to weeks for this template
            int weeks = 0;
            if (_elapsedDays < 0)
                weeks = (int)Math.Floor(_elapsedDays / 7);
            else if (_elapsedDays == 0)
                weeks = 0;
            else // elapsed days > 0
                weeks = (int)Math.Ceiling(_elapsedDays / 7);

            OverallTotalRecords++;

            if (weeks < (-3))
            {
                LessthanNegThreeWeeks++;
            }
            else if (weeks >= (-3) && weeks < (-2))
            {
                GreaterThanEqualToNegThreeWeeks++;
            }
            else if (weeks >= (-2) && weeks < (-1))
            {
                GreaterThanEqualToNegTwoWeeks++;
            }
            else if (weeks >= (-1) && weeks < 0)
            {
                GreaterThanEqualNegOneWeek++;
            }
            else if (weeks == 0)
            {
                ZeroWeeks++;
            }
            else if (weeks > 0 && weeks <= 1)
            {
                LessThanEqualToOneWeek++;
            }
            else if (weeks > 1 && weeks <= 2)
            {
                LessThanEqualToTwoWeeks++;
            }
            else if (weeks > 2 && weeks <= 3)
            {
                LessThanEqualToThreeWeeks++;
            }
            else // Greater than 3 weeks
            {
                GreaterThanThreeWeeks++;
            }
        }
    }
}
