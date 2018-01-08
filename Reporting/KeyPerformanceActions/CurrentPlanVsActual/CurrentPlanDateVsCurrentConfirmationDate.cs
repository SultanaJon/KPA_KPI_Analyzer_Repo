﻿using DataAccessLibrary;
using Filters;
using Reporting.Overall;
using Reporting.Selective;
using System;
using System.Data;
using Reporting.Interfaces;
using System.Windows.Forms;

namespace Reporting.KeyPerformanceActions.CurrentPlanVsActual
{
    public sealed class CurrentPlanDateVsCurrentConfirmationDate : KeyPerformanceAction, ITemplateTwo, IFavorable
    {
        #region IFavorable Properties

        /// <summary>
        /// The percent favorable for the KPA or KPI it is attached to.
        /// </summary>
        public double PercentFavorable { get; set; }

        #endregion




        #region ITemplateOne Properties

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
        public CurrentPlanDateVsCurrentConfirmationDate()
        {
            Section = "Current Plan vs Actual";
            Name = "Current Plan Date vs Current Confirmation Date";

            // set the selective strategy context
            SelectiveContext = new SelectiveStrategyContext(new SelectiveDataTypeThree());
        }




        /// <summary>
        /// Method to apply the elapsed days against the KPA or KPIs time span conditions
        /// </summary>
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





        #region IFavorable Method

        /// <summary>
        /// Calculates the percent favorable for the specific KPA or KPI it is attached to
        /// </summary>
        public void CalculatePercentFavorable()
        {
            try
            {
                if (TotalRecords != 0)
                {
                    double favorableTimeSpanCounts = LessthanNegThreeWeeks + GreaterThanEqualToNegThreeWeeks + GreaterThanEqualToNegTwoWeeks + GreaterThanEqualNegOneWeek + ZeroWeeks;

                    // calculate the Percent Favorable
                    PercentFavorable = Math.Round((favorableTimeSpanCounts / TotalRecords) * 100, 2);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("An argument out of range exception was thrown", "Current Plan Date vs Curren Confirmation date for Hot Jobs Favorable Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        #endregion






        /// <summary>
        /// Method to calculate the averate for this KPA
        /// </summary>
        internal override void CalculateAverage(double _totalDays)
        {
            try
            {
                Average = Math.Round(_totalDays / TotalRecords, 2);
                if (double.IsNaN(Average))
                    Average = 0;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("An argument out of range exception was thrown", "Current Plan Date vs Curren Confirmation date Average Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            catch (DivideByZeroException)
            {
                Average = 0;
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
                DataTable dt = KpaUtils.CurrentPlanVsActualQueries.GetCurrentPlanDateVsCurrentConfirmationDate();
                double totalDays = 0;

                foreach (DataRow dr in dt.Rows)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }

                    string[] strDate = (dr["Latest Conf#Dt"].ToString()).Split('/');
                    int year = int.Parse(strDate[2]);
                    int month = int.Parse(strDate[0].TrimStart('0'));
                    int day = int.Parse(strDate[1].TrimStart('0'));

                    DateTime confDate = new DateTime(year, month, day);


                    string[] strCurrPlanDate = (dr["Rescheduling date"].ToString()).Split('/');
                    int currConfYear = int.Parse(strCurrPlanDate[2]);
                    int currConfMonth = int.Parse(strCurrPlanDate[0]);
                    int currConfDay = int.Parse(strCurrPlanDate[1]);

                    if (currConfYear == 0 && currConfMonth == 0 && currConfDay == 0)
                    {
                        string[] strNewCurrConfDate = (dr["Delivery Date"].ToString()).Split('/');
                        currConfYear = int.Parse(strNewCurrConfDate[2]);
                        currConfMonth = int.Parse(strNewCurrConfDate[0].TrimStart('0'));
                        currConfDay = int.Parse(strNewCurrConfDate[1].TrimStart('0'));
                    }
                    else
                    {
                        currConfYear = int.Parse(strCurrPlanDate[2]);
                        currConfMonth = int.Parse(strCurrPlanDate[0].TrimStart('0'));
                        currConfDay = int.Parse(strCurrPlanDate[1].TrimStart('0'));
                    }

                    DateTime currPlanDate = new DateTime(currConfYear, currConfMonth, currConfDay);
                    double elapsedDays = (confDate - currPlanDate).TotalDays;

                    // Our time spans are in weeks but we want to catch the average amount of days.
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;


                    // Apply the elapsed days against the time span conditions
                    TimeSpanDump(elapsedDays);
                }

                // Calculate the average for this KPA
                CalculateAverage(totalDays);

                // Calcualte the Percent Favorable for this KPA
                CalculatePercentFavorable();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("An argument out of range exception was thrown", "Current Plan Date vs Curren Confirmation date Overall Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}
