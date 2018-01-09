

using DataAccessLibrary;
using Reporting.Overall;


using Reporting.Selective;
using System;
using System.Collections.Generic;
using System.Data;

namespace Reporting.KeyPerformanceIndicators.Other
{
    public sealed class PRsReleased : KeyPerformanceIndicator, ITemplateFive
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
        /// Returns the template that this KPA or KPI fall under
        /// </summary>
        public ITemplateFive Template
        {
            get
            {
                return this;
            }
        }






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
        public PRsReleased()
        {
            Section = "Other";
            Name = "PRs Released";

            // set the selective strategy context
            SelectiveContext = new SelectiveStrategyContext(new SelectiveDataTypeOne());
        }




        /// <summary>
        /// Returns the template one data for this KPA
        /// </summary>
        /// <returns></returns>
        public List<string> GetTemplateData()
        {
            List<string> row = new List<string>();

            // Add the Template three data
            row.Add(Section);
            row.Add(Name);
            row.Add(string.Format("{0:n}", "$" + TotalValue));
            row.Add(string.Format("{0:n0}", GreaterThanEqualToZeroWeeks));
            row.Add(string.Format("{0:n0}", GreaterThanEqualToNegOneWeek));
            row.Add(string.Format("{0:n0}", GreaterThanEqualToNegTwoWeeks));
            row.Add(string.Format("{0:n0}", GreaterThanEqualToNegThreeWeeks));
            row.Add(string.Format("{0:n0}", GreaterThanEqualToNegFourWeeks));
            row.Add(string.Format("{0:n0}", GreaterThanEqualToNegFiveWeeks));
            row.Add(string.Format("{0:n0}", GreaterThanEqualToNegSixWeeks));
            row.Add(string.Format("{0:n0}", GreaterThanEqualToNegSevenWeeks));
            row.Add(string.Format("{0:n0}", GreaterThanEqualToNegEightWeeks));
            row.Add(string.Format("{0:n0}", LessThanNegEightWeeks));
            row.Add(string.Format("{0:n0}", TotalRecords));

            //return the template one data for this KPA
            return row;
        }




        /// <summary>
        /// Method to apply the elapsed days against the KPA or KPIs time span conditions
        /// </summary>
        public void TimeSpanDump(double _weeks)
        {
            // Increment the total number of records that satisfy this KPI
            TotalRecords++;


            // Apply the elapsed days agaisnt the timespan conditions
            if (_weeks >= 0)
            {
                GreaterThanEqualToZeroWeeks++;
            }
            else if (_weeks >= (-1) && _weeks < 0)
            {
                GreaterThanEqualToNegOneWeek++;
            }
            else if (_weeks >= (-2) && _weeks < (-1))
            {
                GreaterThanEqualToNegTwoWeeks++;
            }
            else if (_weeks >= (-3) && _weeks < (-2))
            {
                GreaterThanEqualToNegThreeWeeks++;
            }
            else if (_weeks >= (-4) && _weeks < (-3))
            {
                GreaterThanEqualToNegFourWeeks++;
            }
            else if (_weeks >= (-5) && _weeks < (-4))
            {
                GreaterThanEqualToNegFiveWeeks++;
            }
            else if (_weeks >= (-6) && _weeks < (-5))
            {
                GreaterThanEqualToNegSixWeeks++;
            }
            else if (_weeks >= (-7) && _weeks < (-6))
            {
                GreaterThanEqualToNegSevenWeeks++;
            }
            else if (_weeks >= (-8) && _weeks < (-7))
            {
                GreaterThanEqualToNegEightWeeks++;
            }
            else if (_weeks < (-8))
            {
                LessThanNegEightWeeks++;
            }
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
            foreach (DataRow dr in DatabaseManager.pr2ndLvlRelDateDt.Rows)
            {
                //Check if the datarow meets the conditions of any applied filters.
                if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                {
                    // This datarow dos not meet the conditions of the filters applied.
                    continue;
                }


                #region EVASO_BUT_NOT_FULLY_RELEASED_CHECK

                string[] strPrFullyRelDate = (dr["PR Fully Rel Date"].ToString()).Split('/');
                int prFullyRelYear = int.Parse(strPrFullyRelDate[2]);
                int prFullyRelMonth = int.Parse(strPrFullyRelDate[0]);
                int prFullyRelDay = int.Parse(strPrFullyRelDate[1]);


                if (prFullyRelYear == 0 && prFullyRelMonth == 0 && prFullyRelDay == 0)
                {
                    // This PR line or PR in general might have been delted
                    continue;
                }


                #endregion

                DateTime prFullyRelDt = new DateTime(prFullyRelYear, prFullyRelMonth, prFullyRelDay);
                TotalValue += decimal.Parse(dr["PR Pos#Value"].ToString());

                DateTime today = DateTime.Now.Date;
                double elapsedDays = (prFullyRelDt - today).TotalDays;
                double weeks = Math.Floor(elapsedDays / 7);


                // Apply the weeks against the time span conditions
                TimeSpanDump(weeks);
            }
        }
    }
}
