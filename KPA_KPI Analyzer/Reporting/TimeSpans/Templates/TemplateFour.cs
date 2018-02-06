using System.Collections.Generic;

namespace Reporting.TimeSpans.Templates
{
    public sealed class TemplateFour : Template, ITemplateFour
    {
        public double Average { get; set; }
        public int TotalRecords { get; set; }
        public int LessThanEqualToZeroDays { get; set; }
        public int OneToThreeDays { get; set; }
        public int FourToSevenDays { get; set; }
        public int EightToFourteenDays { get; set; }
        public int FifteenToTwentyOneDays { get; set; }
        public int TwentyTwoToTwentyEightDays { get; set; }
        public int TwentyNineToThirtyFiveDays { get; set; }
        public int ThirtySixtoFourtyTwoDays { get; set; }
        public int FourtyThreeToFourtyNineDays { get; set; }
        public int FiftyToFiftySixDays { get; set; }
        public int FiftySevenPlusDays { get; set; }





        /// <summary>
        /// Returns the template data as a list of strings.
        /// </summary>
        /// <returns></returns>
        public List<string> GetTemplateData()
        {
            List<string> temp = new List<string>();
            temp.Add(string.Format("{0:n}", Average));
            temp.Add(string.Format("{0:n0}", LessThanEqualToZeroDays));
            temp.Add(string.Format("{0:n0}", OneToThreeDays));
            temp.Add(string.Format("{0:n0}", FourToSevenDays));
            temp.Add(string.Format("{0:n0}", EightToFourteenDays));
            temp.Add(string.Format("{0:n0}", FifteenToTwentyOneDays));
            temp.Add(string.Format("{0:n0}", TwentyTwoToTwentyEightDays));
            temp.Add(string.Format("{0:n0}", TwentyNineToThirtyFiveDays));
            temp.Add(string.Format("{0:n0}", ThirtySixtoFourtyTwoDays));
            temp.Add(string.Format("{0:n0}", FourtyThreeToFourtyNineDays));
            temp.Add(string.Format("{0:n0}", FiftyToFiftySixDays));
            temp.Add(string.Format("{0:n0}", FiftySevenPlusDays));
            temp.Add(string.Format("{0:n0}", TotalRecords));
            return temp;
        }




        /// <summary>
        /// Method to calculate the averate for this KPA
        /// </summary>
        public void CalculateAverage(double _totalDays)
        {
            Average = base.CalculateAverage(_totalDays, TotalRecords);
        }




        /// <summary>
        /// Drops the elapsed days value into a timespand bucket for the specific KPA or KPI
        /// </summary>
        /// <param name="_elapsedDays">The number of elapsed days</param>
        public void TimeSpanDump(double _elapsedDays)
        {
            // Increment the total number of records that satisfy this KPI
            TotalRecords++;


            // Apply the elapsed days against the time span conditions
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
            else if (_elapsedDays >= 29 && _elapsedDays <= 35)
            {
                TwentyNineToThirtyFiveDays++;
            }
            else if (_elapsedDays >= 36 && _elapsedDays <= 42)
            {
                ThirtySixtoFourtyTwoDays++;
            }
            else if (_elapsedDays >= 43 && _elapsedDays <= 49)
            {
                FourtyThreeToFourtyNineDays++;
            }
            else if (_elapsedDays >= 50 && _elapsedDays <= 56)
            {
                FiftyToFiftySixDays++;
            }
            else // elapsed days is >= 57
            {
                FiftySevenPlusDays++;
            }
        }
    }
}
