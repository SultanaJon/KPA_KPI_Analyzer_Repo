using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.Overall.TemplateOne
{
    public class TemplateOnePacket : OverallDataPacket
    {
        public override double OverallAverage { get; set; }
        public override int OverallTotalRecords { get; set; }
        public int LessThanEqualToZeroDays { get; set; }
        public int OneToThreeDays { get; set; }
        public int FourToSevenDays { get; set; }
        public int EightToFourteenDays { get; set; }
        public int FifteenToTwentyOneDays { get; set; }
        public int TwentyTwoToTwentyEightDays { get; set; }
        public int TwentyNinePlusDays { get; set; }





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
            OverallTotalRecords++;

            if (_elapsedDays <= 0)
            {
                LessThanEqualToZeroDays++;
            }
            else if (_elapsedDays >= 1 && _elapsedDays <= 3)
            {
                OneToThreeDays++;
            }
            else if (_elapsedDays >= 4 && _elapsedDays <= 7)
            {
                FourToSevenDays++;
            }
            else if (_elapsedDays >= 8 && _elapsedDays <= 14)
            {
                EightToFourteenDays++;
            }
            else if (_elapsedDays >= 15 && _elapsedDays <= 21)
            {
                FifteenToTwentyOneDays++;
            }
            else if (_elapsedDays >= 22 && _elapsedDays <= 28)
            {
                TwentyTwoToTwentyEightDays++;
            }
            else // 29+
            {
                TwentyNinePlusDays++;
            }
        }
    }
}
