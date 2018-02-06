using System.Collections.Generic;
using System.Data;

namespace Reporting.TimeSpans.Templates
{
    public sealed class TemplateFive : Template, ITemplateFive
    {
        public decimal TotalValue { get; set; }
        public int TotalRecords { get; set; }
        public decimal GreaterThanEqualToZeroWeeks { get; set; }
        public decimal GreaterThanEqualToNegOneWeek { get; set; }
        public decimal GreaterThanEqualToNegTwoWeeks { get; set; }
        public decimal GreaterThanEqualToNegThreeWeeks { get; set; }
        public decimal GreaterThanEqualToNegFourWeeks { get; set; }
        public decimal GreaterThanEqualToNegFiveWeeks { get; set; }
        public decimal GreaterThanEqualToNegSixWeeks { get; set; }
        public decimal GreaterThanEqualToNegSevenWeeks { get; set; }
        public decimal GreaterThanEqualToNegEightWeeks { get; set; }
        public decimal LessThanNegEightWeeks { get; set; }





        /// <summary>
        /// Returns the template data as a list of strings.
        /// </summary>
        /// <returns></returns>
        public List<string> GetTemplateData()
        {
            List<string> temp = new List<string>();
            temp.Add(string.Format("{0:n}", "$" + TotalValue));
            temp.Add(string.Format("{0:n0}", GreaterThanEqualToZeroWeeks));
            temp.Add(string.Format("{0:n0}", GreaterThanEqualToNegOneWeek));
            temp.Add(string.Format("{0:n0}", GreaterThanEqualToNegTwoWeeks));
            temp.Add(string.Format("{0:n0}", GreaterThanEqualToNegThreeWeeks));
            temp.Add(string.Format("{0:n0}", GreaterThanEqualToNegFourWeeks));
            temp.Add(string.Format("{0:n0}", GreaterThanEqualToNegFiveWeeks));
            temp.Add(string.Format("{0:n0}", GreaterThanEqualToNegSixWeeks));
            temp.Add(string.Format("{0:n0}", GreaterThanEqualToNegSevenWeeks));
            temp.Add(string.Format("{0:n0}", GreaterThanEqualToNegEightWeeks));
            temp.Add(string.Format("{0:n0}", LessThanNegEightWeeks));
            temp.Add(string.Format("{0:n0}", TotalRecords));
            return temp;
        }




        /// <summary>
        /// Drops the elapsed weeks value into a timespand bucket for the specific KPA or KPI
        /// </summary>
        /// <param name="_elapsedDays">The number of elapsed weeks</param>
        public void TimeSpanDump(double _elapsedWeeks)
        {
            // Increment the total number of records that satisfy this KPI
            TotalRecords++;


            // Apply the elapsed days agaisnt the timespan conditions
            if (_elapsedWeeks >= 0)
            {
                GreaterThanEqualToZeroWeeks++;
            }
            else if (_elapsedWeeks >= (-1) && _elapsedWeeks < 0)
            {
                GreaterThanEqualToNegOneWeek++;
            }
            else if (_elapsedWeeks >= (-2) && _elapsedWeeks < (-1))
            {
                GreaterThanEqualToNegTwoWeeks++;
            }
            else if (_elapsedWeeks >= (-3) && _elapsedWeeks < (-2))
            {
                GreaterThanEqualToNegThreeWeeks++;
            }
            else if (_elapsedWeeks >= (-4) && _elapsedWeeks < (-3))
            {
                GreaterThanEqualToNegFourWeeks++;
            }
            else if (_elapsedWeeks >= (-5) && _elapsedWeeks < (-4))
            {
                GreaterThanEqualToNegFiveWeeks++;
            }
            else if (_elapsedWeeks >= (-6) && _elapsedWeeks < (-5))
            {
                GreaterThanEqualToNegSixWeeks++;
            }
            else if (_elapsedWeeks >= (-7) && _elapsedWeeks < (-6))
            {
                GreaterThanEqualToNegSevenWeeks++;
            }
            else if (_elapsedWeeks >= (-8) && _elapsedWeeks < (-7))
            {
                GreaterThanEqualToNegEightWeeks++;
            }
            else if (_elapsedWeeks < (-8))
            {
                LessThanNegEightWeeks++;
            }
        }




        /// <summary>
        /// Method to apply the elapsed days against the KPA or KPIs time span conditions
        /// </summary>
        public void TimeSpanDump(double _weeks, DataRow dr)
        {
            // Increment the total number of records that satisfy this KPI
            TotalRecords++;

            // Apply the number of weeks against the time span conditions
            if (_weeks >= 0)
            {
                GreaterThanEqualToZeroWeeks += (decimal.Parse(dr["PO Value"].ToString()) - decimal.Parse(dr["PR Pos#Value"].ToString()));
            }
            else if (_weeks >= (-1) && _weeks < 0)
            {
                GreaterThanEqualToNegOneWeek += (decimal.Parse(dr["PO Value"].ToString()) - decimal.Parse(dr["PR Pos#Value"].ToString()));
            }
            else if (_weeks >= (-2) && _weeks < (-1))
            {
                GreaterThanEqualToNegTwoWeeks += (decimal.Parse(dr["PO Value"].ToString()) - decimal.Parse(dr["PR Pos#Value"].ToString()));
            }
            else if (_weeks >= (-3) && _weeks < (-2))
            {
                GreaterThanEqualToNegThreeWeeks += (decimal.Parse(dr["PO Value"].ToString()) - decimal.Parse(dr["PR Pos#Value"].ToString()));
            }
            else if (_weeks >= (-4) && _weeks < (-3))
            {
                GreaterThanEqualToNegFourWeeks += (decimal.Parse(dr["PO Value"].ToString()) - decimal.Parse(dr["PR Pos#Value"].ToString()));
            }
            else if (_weeks >= (-5) && _weeks < (-4))
            {
                GreaterThanEqualToNegFiveWeeks += (decimal.Parse(dr["PO Value"].ToString()) - decimal.Parse(dr["PR Pos#Value"].ToString()));
            }
            else if (_weeks >= (-6) && _weeks < (-5))
            {
                GreaterThanEqualToNegSixWeeks += (decimal.Parse(dr["PO Value"].ToString()) - decimal.Parse(dr["PR Pos#Value"].ToString()));
            }
            else if (_weeks >= (-7) && _weeks < (-6))
            {
                GreaterThanEqualToNegSevenWeeks += (decimal.Parse(dr["PO Value"].ToString()) - decimal.Parse(dr["PR Pos#Value"].ToString()));
            }
            else if (_weeks >= (-8) && _weeks < (-7))
            {
                GreaterThanEqualToNegEightWeeks += (decimal.Parse(dr["PO Value"].ToString()) - decimal.Parse(dr["PR Pos#Value"].ToString()));
            }
            else if (_weeks < (-8))
            {
                LessThanNegEightWeeks += (decimal.Parse(dr["PO Value"].ToString()) - decimal.Parse(dr["PR Pos#Value"].ToString()));
            }
        }


        /// <summary>
        /// Method to apply the elapsed days against the KPA or KPIs time span conditions
        /// </summary>
        public void TimeSpanDumpV2(double _weeks, DataRow dr)
        {
            // Increment the total number of records that satisfy this KPI
            TotalRecords++;


            // Apply the weeks against the time span conditions
            if (_weeks >= 0)
            {
                GreaterThanEqualToZeroWeeks += decimal.Parse(dr["PO Value"].ToString());
            }
            else if (_weeks >= (-1) && _weeks < 0)
            {
                GreaterThanEqualToNegOneWeek += decimal.Parse(dr["PO Value"].ToString());
            }
            else if (_weeks >= (-2) && _weeks < (-1))
            {
                GreaterThanEqualToNegTwoWeeks += decimal.Parse(dr["PO Value"].ToString());
            }
            else if (_weeks >= (-3) && _weeks < (-2))
            {
                GreaterThanEqualToNegThreeWeeks += decimal.Parse(dr["PO Value"].ToString());
            }
            else if (_weeks >= (-4) && _weeks < (-3))
            {
                GreaterThanEqualToNegFourWeeks += decimal.Parse(dr["PO Value"].ToString());
            }
            else if (_weeks >= (-5) && _weeks < (-4))
            {
                GreaterThanEqualToNegFiveWeeks += decimal.Parse(dr["PO Value"].ToString());
            }
            else if (_weeks >= (-6) && _weeks < (-5))
            {
                GreaterThanEqualToNegSixWeeks += decimal.Parse(dr["PO Value"].ToString());
            }
            else if (_weeks >= (-7) && _weeks < (-6))
            {
                GreaterThanEqualToNegSevenWeeks += decimal.Parse(dr["PO Value"].ToString());
            }
            else if (_weeks >= (-8) && _weeks < (-7))
            {
                GreaterThanEqualToNegEightWeeks += decimal.Parse(dr["PO Value"].ToString());
            }
            else if (_weeks < (-8))
            {
                LessThanNegEightWeeks += decimal.Parse(dr["PO Value"].ToString());
            }
        }
    }
}
