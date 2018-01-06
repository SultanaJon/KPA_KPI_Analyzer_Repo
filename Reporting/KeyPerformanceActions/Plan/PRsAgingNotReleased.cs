﻿using System;
using System.Data;
using DataAccessLibrary;
using Filters;
using Reporting.Selective;

using Reporting.Overall;

namespace Reporting.KeyPerformanceActions.Plan
{
    public sealed class PRsAgingNotReleased : KeyPerformanceAction, ITemplateOne
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
                if(value != null)
                {
                    this.selectiveContext = value;
                }
            }
        }




        /// <summary>
        /// Default Constructor
        /// </summary>
        public PRsAgingNotReleased()
        {
            Section = "Plan";
            Name = "PRs Aging (Not Released)";

            // set the selective strategy context
            SelectiveContext = new SelectiveStrategyContext(new SelectiveDataTypeOne());
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
            DataTable dt = KpaUtils.PlanQueries.GetPrsAgingNotReleased();
            double totalDays = 0;

            foreach (DataRow dr in dt.Rows)
            {
                //Check if the datarow meets the conditions of any applied filters.
                if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                {
                    // This datarow dos not meet the conditions of the filters applied.
                    continue;
                }

                string[] reqCreationDate = (dr["Requisn Date"].ToString()).Split('/');
                int year = int.Parse(reqCreationDate[2]);
                int month = int.Parse(reqCreationDate[0].TrimStart('0'));
                int day = int.Parse(reqCreationDate[1].TrimStart('0'));

                DateTime reqDate = new DateTime(year, month, day);
                DateTime today = DateTime.Now.Date;
                double elapsedDays = (today - reqDate).TotalDays;
                totalDays += elapsedDays;
                elapsedDays = (int)elapsedDays;


                // Apply the elapsed days against the time span conditions
                TimeSpanDump(elapsedDays);
            }

            // Calculate the average for this KPA
            CalculateAverage(totalDays);
        }
    }
}
