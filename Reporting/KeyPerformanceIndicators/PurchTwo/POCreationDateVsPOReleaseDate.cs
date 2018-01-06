﻿using DataAccessLibrary;
using Reporting.Overall;
using Reporting.Selective;
using System;
using System.Data;

namespace Reporting.KeyPerformanceIndicators.PurchTwo
{
    public sealed class POCreationDateVsPOReleaseDate : KeyPerformanceIndicator, ITemplateFour
    {
        #region ITemplateFour Properties

        public double Average { get; set; }
        public int TotalRecords { get; set; }
        public int LessThanEqualToZeroDays { get; set; }
        public int OneToThreeDays { get; set; }
        public int FourToSevenDays { get; set; }
        public int EightToFourteenDays { get; set; }
        public int FifteenToTwentyOneDays { get; set; }
        public int TwentyTwoToTwentyEightDays { get; set; }
        public int TwentyNineToThirtyFiveDays { get; set; }
        public int ThirtySixtoFourtyTwoDays { get; set; }
        public int FourtyThreeToFourtyNineDays { get; set; }
        public int FiftyToFiftySixDays { get; set; }
        public int FiftySevenPlusDays { get; set; }

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
        public POCreationDateVsPOReleaseDate()
        {
            Section = "Purch II";
            Name = "PO Creation Date vs PO Release Date";

            // set the selective strategy context
            SelectiveContext = new SelectiveStrategyContext(new SelectiveDataTypeOne());
        }







        /// <summary>
        /// Method to apply the elapsed days against the KPA or KPIs time span conditions
        /// </summary>
        public void TimeSpanDump(double _elapsedDays)
        {
            // Increment the total number of records that satisfy this KPI
            TotalRecords++;


            // Apply the elapsed days against the time span conditions
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
            else if (_elapsedDays >= 29 && _elapsedDays <= 35)
            {
                TwentyNineToThirtyFiveDays++;
            }
            else if (_elapsedDays >= 36 && _elapsedDays <= 42)
            {
                ThirtySixtoFourtyTwoDays++;
            }
            else if (_elapsedDays >= 43 && _elapsedDays <= 49)
            {
                FourtyThreeToFourtyNineDays++;
            }
            else if (_elapsedDays >= 50 && _elapsedDays <= 56)
            {
                FiftyToFiftySixDays++;
            }
            else // elapsed days is >= 57
            {
                FiftySevenPlusDays++;
            }
        }






        /// <summary>
        /// Method to calculate the averate for this KPA
        /// </summary>
        private void CalculateAverage(double _totalDays)
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
            double totalDays = 0;

            foreach (DataRow dr in DatabaseManager.prsOnPOsDt.Rows)
            {
                //Check if the datarow meets the conditions of any applied filters.
                if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                {
                    // This datarow dos not meet the conditions of the filters applied.
                    continue;
                }

                string[] strPOLine1stRelDt = (dr["PO Line 1st Rel Dt"].ToString()).Split('/');
                int poLine1stRelDtYear = int.Parse(strPOLine1stRelDt[2]);
                int poLine1stRelDtMonth = int.Parse(strPOLine1stRelDt[0]);
                int poLine1stRelDtDay = int.Parse(strPOLine1stRelDt[1]);

                if (poLine1stRelDtYear == 0 && poLine1stRelDtMonth == 0 && poLine1stRelDtDay == 0)
                {

                    continue;
                }
                else
                {
                    poLine1stRelDtYear = int.Parse(strPOLine1stRelDt[2]);
                    poLine1stRelDtMonth = int.Parse(strPOLine1stRelDt[0].TrimStart('0'));
                    poLine1stRelDtDay = int.Parse(strPOLine1stRelDt[1].TrimStart('0'));
                }

                DateTime poLine1stRelDate = new DateTime(poLine1stRelDtYear, poLine1stRelDtMonth, poLine1stRelDtDay);

                string[] strPOLineCreateDt = (dr["PO Line Creat#DT"].ToString()).Split('/');
                int poOLineCreateDtYear = int.Parse(strPOLineCreateDt[2]);
                int poOLineCreateDtMonth = int.Parse(strPOLineCreateDt[0].TrimStart('0'));
                int poOLineCreateDtDay = int.Parse(strPOLineCreateDt[1].TrimStart('0'));

                DateTime poCreateDate = new DateTime(poOLineCreateDtYear, poOLineCreateDtMonth, poOLineCreateDtDay);
                double elapsedDays = (poLine1stRelDate - poCreateDate).TotalDays;
                totalDays += elapsedDays;
                elapsedDays = (int)elapsedDays;

                // Apply the elapsed days to the time span conditions
                TimeSpanDump(elapsedDays);
            }


            // Calcualte the average for this KPI
            CalculateAverage(TotalRecords);
        }
    }
}
