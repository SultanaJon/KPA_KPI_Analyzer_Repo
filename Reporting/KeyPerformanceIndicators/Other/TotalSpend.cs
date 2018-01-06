using DataAccessLibrary;
using Reporting.Overall;
using Reporting.Selective;
using System;
using System.Data;

namespace Reporting.KeyPerformanceIndicators.Other
{
    public sealed class TotalSpend : KeyPerformanceIndicator, ITemplateFive
    {
        #region ITemplateFive Properties

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

        #endregion



        /// <summary>
        /// The Selective Strategy Context that holds the selective data for reporting
        /// </summary>
        private SelectiveStrategyContext selectiveContext;



        /// <summary>
        /// Property to return the selective data for this KPA
        /// </summary>
        public SelectiveStrategyContext SelectiveContext
        {
            get
            {
                return selectiveContext;
            }
            private set
            {
                if (value != null)
                {
                    this.selectiveContext = value;
                }
            }
        }





        /// <summary>
        /// Default Constructor
        /// </summary>
        public TotalSpend()
        {
            Section = "Other";
            Name = "Total Spend";

            // set the selective strategy context
            SelectiveContext = new SelectiveStrategyContext(new SelectiveDataTypeOne());
        }







        /// <summary>
        /// Method to apply the elapsed days against the KPA or KPIs time span conditions
        /// </summary>
        public void TimeSpanDump(double _weeks, DataRow dr)
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






        /// <summary>
        /// Calculates the selective report for this KPA
        /// </summary>
        private double GetElapsedDays()
        {
            return 1;
        }




        /// <summary>
        /// Calculates the selective report for this KPA
        /// </summary>
        public override void RunSelectiveReport(string uniqueFilters)
        {

        }



        /// <summary>
        /// Calculates the overall report for this KPA
        /// </summary>
        public override void RunOverallReport()
        {
            foreach (DataRow dr in DatabaseManager.prsOnPOsDt.Rows)
            {
                //Check if the datarow meets the conditions of any applied filters.
                if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                {
                    // This datarow dos not meet the conditions of the filters applied.
                    continue;
                }

                string[] strPoCreateDt = (dr["PO Line Creat#DT"].ToString()).Split('/');
                int poCreateDtYear = int.Parse(strPoCreateDt[2]);
                int poCreateDtMonth = int.Parse(strPoCreateDt[0].TrimStart('0'));
                int poCreateDtDay = int.Parse(strPoCreateDt[1].TrimStart('0'));

                DateTime poCreateDate = new DateTime(poCreateDtYear, poCreateDtMonth, poCreateDtDay);

                TotalValue += decimal.Parse(dr["PO Value"].ToString());

                DateTime today = DateTime.Now.Date;
                double elapsedDays = (poCreateDate - today).TotalDays;
                double weeks = Math.Floor(elapsedDays / 7);

                // apply the weeks against the time span conditions
                TimeSpanDump(weeks, dr);
            }
        }
    }
}
