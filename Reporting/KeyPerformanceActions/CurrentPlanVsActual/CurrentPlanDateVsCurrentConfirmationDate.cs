using DataAccessLibrary;
using Filters;
using Reporting.Interfaces;
using Reporting.Overall;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Reporting.KeyPerformanceActions.CurrentPlanVsActual
{
    public sealed class CurrentPlanDateVsCurrentConfirmationDate : KeyPerformanceAction, ISelective,  ITemplateTwo, IFavorable
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
        public CurrentPlanDateVsCurrentConfirmationDate()
        {
            Section = "Current Plan vs Actual";
            Name = "Current Plan Date vs Current Confirmation Date";
        }




        /// <summary>
        /// Returns the template one data for this KPA
        /// </summary>
        /// <returns></returns>
        public List<string> GetTemplateData()
        {
            List<string> row = new List<string>();

            // Add the Template one data
            row.Add(Section);
            row.Add(Name);
            row.Add(string.Format("{0:n}", Average));
            row.Add(string.Format("{0:n0}", LessthanNegThreeWeeks));
            row.Add(string.Format("{0:n0}", GreaterThanEqualToNegThreeWeeks));
            row.Add(string.Format("{0:n0}", GreaterThanEqualToNegTwoWeeks));
            row.Add(string.Format("{0:n0}", GreaterThanEqualNegOneWeek));
            row.Add(string.Format("{0:n0}", ZeroWeeks));
            row.Add(string.Format("{0:n0}", LessThanEqualToOneWeek));
            row.Add(string.Format("{0:n0}", LessThanEqualToTwoWeeks));
            row.Add(string.Format("{0:n0}", LessThanEqualToThreeWeeks));
            row.Add(string.Format("{0:n0}", GreaterThanThreeWeeks));
            row.Add(string.Format("{0:n0}", TotalRecords));
            row.Add(string.Format("{0:n0}", PercentFavorable + "%"));

            //return the template one data for this KPA
            return row;
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
            catch (Exception)
            {
                MessageBox.Show("An argument out of range exception was thrown", "Current Plan Date vs Curren Confirmation date for Hot Jobs Favorable Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        #endregion






        /// <summary>
        /// Method to calculate the averate for this KPA
        /// </summary>
        internal override void CalculateAverage(double _totalDays, int _totalRecords)
        {
            try
            {
                Average = Math.Round(_totalDays / _totalRecords, 2);
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
        public override void RunSelectiveReport(string uniqueFilter)
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
                CalculateAverage(totalDays, TotalRecords);

                // Calcualte the Percent Favorable for this KPA
                CalculatePercentFavorable();

                dt.Rows.Clear();
                dt = null;
                GC.Collect();
            }
            catch (Exception)
            {
                MessageBox.Show("An argument out of range exception was thrown", "Current Plan Date vs Curren Confirmation date Overall Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
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
                CalculateAverage(totalDays, TotalRecords);

                // Calcualte the Percent Favorable for this KPA
                CalculatePercentFavorable();

                dt.Rows.Clear();
                dt = null;
                GC.Collect();
            }
            catch (Exception)
            {
                MessageBox.Show("An argument out of range exception was thrown", "Current Plan Date vs Curren Confirmation date Overall Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}
