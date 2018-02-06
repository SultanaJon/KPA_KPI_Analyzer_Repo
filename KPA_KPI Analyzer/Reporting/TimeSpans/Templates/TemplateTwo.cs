using System;
using System.Collections.Generic;

namespace Reporting.TimeSpans.Templates
{
    public sealed class TemplateTwo : Template, ITemplateTwo
    {
        public double Average { get; set; }
        public int TotalRecords { get; set; }
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
        /// Returns the template data as a list of strings.
        /// </summary>
        /// <returns></returns>
        public List<string> GetTemplateData()
        {
            List<string> temp = new List<string>();
            temp.Add(string.Format("{0:n}", Average));
            temp.Add(string.Format("{0:n0}", LessthanNegThreeWeeks));
            temp.Add(string.Format("{0:n0}", GreaterThanEqualToNegThreeWeeks));
            temp.Add(string.Format("{0:n0}", GreaterThanEqualToNegTwoWeeks));
            temp.Add(string.Format("{0:n0}", GreaterThanEqualNegOneWeek));
            temp.Add(string.Format("{0:n0}", ZeroWeeks));
            temp.Add(string.Format("{0:n0}", LessThanEqualToOneWeek));
            temp.Add(string.Format("{0:n0}", LessThanEqualToTwoWeeks));
            temp.Add(string.Format("{0:n0}", LessThanEqualToThreeWeeks));
            temp.Add(string.Format("{0:n0}", GreaterThanThreeWeeks));
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
        /// <param name="_elapsedDays"></param>
        public void TimeSpanDump(double _elapsedDays)
        {
            // Because the time spans are listed in weeks, we need to convert the elapsed days to weeks.
            int weeks = 0;
            if (_elapsedDays < 0)
                weeks = (int)Math.Floor(_elapsedDays / 7);
            else if (_elapsedDays == 0)
                weeks = 0;
            else // elapsed days > 0
                weeks = (int)Math.Ceiling(_elapsedDays / 7);

            // Increment the total number of records that apply to this KPA
            TotalRecords++;


            // Apply the number of weeks against the time span conditions
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
