using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.Overall.TemplateThree
{
    public class TemplateThreePacket : OverallDataPacket
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
        internal override void TimeSpanDump(double __elapsedDays)
        {
            // Float the elapsed days to the floor or ceiling based on the below conditions
            if (__elapsedDays < 0)
                __elapsedDays = Math.Floor(__elapsedDays);

            if (__elapsedDays > 0)
                __elapsedDays = Math.Ceiling(__elapsedDays);

            // Increment the total overall records
            OverallTotalRecords++;

            // Increment the count of the met condition timespan
            if (__elapsedDays <= (-22))
            {
                LessThanEqualToNegTwentyTwoDays++;
            }
            else if (__elapsedDays > (-22) && __elapsedDays <= (-15))
            {
                NegTwentyOneToNegFifteenDays++;
            }
            else if (__elapsedDays > (-15) && __elapsedDays <= (-8))
            {
                NegFourteenToNegEightDays++;
            }
            else if (__elapsedDays > (-8) && __elapsedDays <= (-1))
            {
                NegSevenToNegOneDays++;
            }
            else if (__elapsedDays == 0)
            {
                ZeroDays++;
            }
            else if (__elapsedDays >= 1 && __elapsedDays <= 7)
            {
                OneToSevenDays++;
            }
            else if (__elapsedDays >= 8 && __elapsedDays <= 14)
            {
                EightToFourteenDays++;
            }
            else if (__elapsedDays >= 15 && __elapsedDays <= 21)
            {
                FifteenToTwentyOneDays++;
            }
            else // 22 Days or greater
            {
                GreaterThanEqualToTwentyTwoDays++;
            }
        }
    }
}
