﻿using DataAccessLibrary;
using Reporting.Interfaces;
using Reporting.Overall;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Reporting.KeyPerformanceIndicators.Other
{
    public sealed class TotalSpend : KeyPerformanceIndicator, ISelective,  ITemplateFive
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





        #region ISelective Properties

        /// <summary>
        /// The selective average for the filter applied against the specific KPA or KPI
        /// </summary>
        public double SelectiveAverage { get; set; }

        /// <summary>
        /// The selective total fo the filter applied against the specific KPA or KPI
        /// </summary>
        public int SelectiveTotal { get; set; }

        #endregion




        /// <summary>
        /// Default Constructor
        /// </summary>
        public TotalSpend()
        {
            Section = "Other";
            Name = "Total Spend";
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
            row.Add(string.Format("{0:n}", "$" + GreaterThanEqualToZeroWeeks));
            row.Add(string.Format("{0:n}", "$" + GreaterThanEqualToNegOneWeek));
            row.Add(string.Format("{0:n}", "$" + GreaterThanEqualToNegTwoWeeks));
            row.Add(string.Format("{0:n}", "$" + GreaterThanEqualToNegThreeWeeks));
            row.Add(string.Format("{0:n}", "$" + GreaterThanEqualToNegFourWeeks));
            row.Add(string.Format("{0:n}", "$" + GreaterThanEqualToNegFiveWeeks));
            row.Add(string.Format("{0:n}", "$" + GreaterThanEqualToNegSixWeeks));
            row.Add(string.Format("{0:n}", "$" + GreaterThanEqualToNegSevenWeeks));
            row.Add(string.Format("{0:n}", "$" + GreaterThanEqualToNegEightWeeks));
            row.Add(string.Format("{0:n}", "$" + LessThanNegEightWeeks));
            row.Add(string.Format("{0:n0}", TotalRecords));

            //return the template one data for this KPA
            return row;
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
        public override void RunSelectiveReport(string uniqueFilter)
        {

        }



        /// <summary>
        /// Calculates the overall report for this KPA
        /// </summary>
        public override void RunOverallReport()
        {
            try
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
            catch (Exception)
            {
                MessageBox.Show("An argument out of range exception was thrown", "Other -> Total Spend - Overall Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}
