using System;
using System.Collections.Generic;

namespace Reporting.TimeSpans.Templates
{
    public sealed class TemplateThree : Template, ITemplateThree
    {
        public double Average { get; set; }
        public int TotalRecords { get; set; }
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
        /// Returns the template data as a list of strings.
        /// </summary>
        /// <returns></returns>
        public override List<string> GetTemplateData()
        {
            List<string> temp = new List<string>();
            temp.Add(string.Format("{0:n}", Average));
            temp.Add(string.Format("{0:n0}", LessThanEqualToNegTwentyTwoDays));
            temp.Add(string.Format("{0:n0}", NegTwentyOneToNegFifteenDays));
            temp.Add(string.Format("{0:n0}", NegFourteenToNegEightDays));
            temp.Add(string.Format("{0:n0}", NegSevenToNegOneDays));
            temp.Add(string.Format("{0:n0}", ZeroDays));
            temp.Add(string.Format("{0:n0}", OneToSevenDays));
            temp.Add(string.Format("{0:n0}", EightToFourteenDays));
            temp.Add(string.Format("{0:n0}", FifteenToTwentyOneDays));
            temp.Add(string.Format("{0:n0}", GreaterThanEqualToTwentyTwoDays));
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
            // We are dealing with both negative and positive time spand so we need to round either up or down
            if (_elapsedDays < 0)
                _elapsedDays = Math.Floor(_elapsedDays);

            if (_elapsedDays > 0)
                _elapsedDays = Math.Ceiling(_elapsedDays);

            _elapsedDays = (int)_elapsedDays;


            // Increment the total number of records that satisfy this KPI
            TotalRecords++;


            // Apply the elapsed days against the time span conditions
            if (_elapsedDays <= (-22))
            {
                LessThanEqualToNegTwentyTwoDays++;
            }
            else if (_elapsedDays > (-22) && _elapsedDays <= (-15))
            {
                NegTwentyOneToNegFifteenDays++;
            }
            else if (_elapsedDays > (-15) && _elapsedDays <= (-8))
            {
                NegFourteenToNegEightDays++;
            }
            else if (_elapsedDays > (-8) && _elapsedDays <= (-1))
            {
                NegSevenToNegOneDays++;
            }
            else if (_elapsedDays == 0)
            {
                ZeroDays++;
            }
            else if (_elapsedDays >= 1 && _elapsedDays <= 7)
            {
                OneToSevenDays++;
            }
            else if (_elapsedDays >= 8 && _elapsedDays <= 14)
            {
                EightToFourteenDays++;
            }
            else if (_elapsedDays >= 15 && _elapsedDays <= 21)
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
