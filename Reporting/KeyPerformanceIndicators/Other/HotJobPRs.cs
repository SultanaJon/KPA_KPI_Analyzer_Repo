

using DataAccessLibrary;
using Reporting.Overall;


using Reporting.Selective;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Reporting.KeyPerformanceIndicators.Other
{
    public sealed class HotJobPRs : KeyPerformanceIndicator, ITemplateFive
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
        public HotJobPRs()
        {
            Section = "Other";
            Name = "Hot Jobs PRs";

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
            try
            {
                foreach (DataRow dr in DatabaseManager.AllDataDt.Rows)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }

                    // Check if this record is a hot job
                    if (dr["Purch# Group"].ToString() != "UHJ")
                        continue;

                    string[] strPrReqDt = (dr["Requisn Date"].ToString()).Split('/');
                    int reqDateYear = int.Parse(strPrReqDt[2]);
                    int reqDateMonth = int.Parse(strPrReqDt[0].TrimStart('0'));
                    int reqDateDay = int.Parse(strPrReqDt[1].TrimStart('0'));

                    DateTime prReqDate = new DateTime(reqDateYear, reqDateMonth, reqDateDay);

                    // Get the total value for this line item
                    TotalValue += decimal.Parse(dr["PR Pos#Value"].ToString());

                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (prReqDate - today).TotalDays;
                    double weeks = Math.Floor(elapsedDays / 7);

                    // Apply the weeks against the time span conditions
                    TimeSpanDump(weeks);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An argument out of range exception was thrown", "Other -> Hot Job PRs - Overall Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}
