﻿

using DataAccessLibrary;
using Filters;
using Reporting.Overall;

using Reporting.Selective;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Reporting.KeyPerformanceActions.HotJobs
{
    public sealed class LateToConfirmed : KeyPerformanceAction, ITemplateOne
    {
        #region ITemplateOne Properties

        public double Average { get; set; }
        public int TotalRecords { get; set; }
        public int LessThanEqualToZeroDays { get; set; }
        public int OneToThreeDays { get; set; }
        public int FourToSevenDays { get; set; }
        public int EightToFourteenDays { get; set; }
        public int FifteenToTwentyOneDays { get; set; }
        public int TwentyTwoToTwentyEightDays { get; set; }
        public int TwentyNinePlusDays { get; set; }

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
        public LateToConfirmed()
        {
            Section = "Hot Jobs";
            Name = "Late to Confirmed";

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

            // Add the Template one data
            row.Add(Section);
            row.Add(Name);
            row.Add(string.Format("{0:n0}", LessThanEqualToZeroDays));
            row.Add(string.Format("{0:n0}", OneToThreeDays));
            row.Add(string.Format("{0:n0}", FourToSevenDays));
            row.Add(string.Format("{0:n0}", EightToFourteenDays));
            row.Add(string.Format("{0:n0}", FifteenToTwentyOneDays));
            row.Add(string.Format("{0:n0}", TwentyTwoToTwentyEightDays));
            row.Add(string.Format("{0:n0}", TwentyNinePlusDays));
            row.Add(string.Format("{0:n}", Average));
            row.Add(string.Format("{0:n0}", TotalRecords));

            //return the template one data for this KPA
            return row;
        }



        /// <summary>
        /// Method to apply the elapsed days against the KPA or KPIs time span conditions
        /// </summary>
        public void TimeSpanDump(double _elapsedDays)
        {
            // Increment the total number of records that satisfy this KPA or KPi
            TotalRecords++;


            // Apply the elapsed days against the timespan conditions
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
            else // 29+
            {
                TwentyNinePlusDays++;
            }
        }






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
                MessageBox.Show("An argument out of range exception was thrown", "Hot Jobs -> Late To Confirmed Date - Average Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                DataTable dt = KpaUtils.HotJobsQueries.GetLateToConfirmed();
                double totalDays = 0;

                foreach (DataRow dr in dt.Rows)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }

                    string[] strDate = (dr["Latest Conf#Dt"].ToString()).Split('/');
                    int year = int.Parse(strDate[2]);
                    int month = int.Parse(strDate[0].TrimStart('0'));
                    int day = int.Parse(strDate[1].TrimStart('0'));

                    DateTime delConfDate = new DateTime(year, month, day);
                    DateTime today = DateTime.Now.Date;

                    if (!(delConfDate < today))
                        continue;

                    double elapsedDays = (today - delConfDate).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;

                    // Apply the elapsed days agains the time span conditions
                    TimeSpanDump(elapsedDays);
                }

                // Calculate the average
                CalculateAverage(totalDays);

                dt.Rows.Clear();
                dt = null;
                GC.Collect();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("An argument out of range exception was thrown", "Hot Jobs -> Late To Confirmed Date - Overall Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }            
        }
    }
}
