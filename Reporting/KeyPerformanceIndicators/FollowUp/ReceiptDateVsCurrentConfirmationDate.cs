using Reporting.Overall;
using Reporting.Selective;
using Reporting.Interfaces;
using System;
using System.Data;
using DataAccessLibrary;

namespace Reporting.KeyPerformanceIndicators.FollowUp
{
    public sealed class ReceiptDateVsCurrentConfirmationDate : KeyPerformanceIndicator, ITemplateThree, IUnconfirmed, IFavorable
    {
        #region IFavorable Properties

        /// <summary>
        /// The percent favorable for the KPA or KPI it is attached to.
        /// </summary>
        public double PercentFavorable { get; set; }

        #endregion




        #region IUnconfirmed Properties

        /// <summary>
        /// The percent of unconfirmed records within the KPA or KPI
        /// </summary>
        public double PercentUnconfirmed { get; set; }

        #endregion




        #region ITemplateThree Properties

        public double Average { get; set; }
        public int TotalRecords { get; set; }
        public int LessThanEqualToNegTwentyTwoDays { get; set; }
        public int NegTwentyOneToNegFifteenDays { get; set; }
        public int NegFourteenToNegEightDays { get; set; }
        public int NegSevenToNegOneDays { get; set; }
        public int ZeroDays { get; set; }
        public int OneToSevenDays { get; set; }
        public int EightToFourteenDays { get; set; }
        public int FifteenToTwentyOneDays { get; set; }
        public int GreaterThanEqualToTwentyTwoDays { get; set; }

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
        public ReceiptDateVsCurrentConfirmationDate()
        {
            Section = "Follow Up";
            Name = "Receipt Date vs Current Confirmation Date";

            // set the selective strategy context
            SelectiveContext = new SelectiveStrategyContext(new SelectiveDataTypeFour());
        }







        /// <summary>
        /// Method to apply the elapsed days against the KPA or KPIs time span conditions
        /// </summary>
        public void TimeSpanDump(double _elapsedDays)
        {
            // We are dealing with both negative and positive time spand so we need to round either up or down
            if (_elapsedDays < 0)
                _elapsedDays = Math.Floor(_elapsedDays);

            if (_elapsedDays > 0)
                _elapsedDays = Math.Ceiling(_elapsedDays);


            // Increment the total number of records that satisfy this KPI
            TotalRecords++;


            // Apply the elapsed days against the time span conditions
            if (_elapsedDays <= (-22))
            {
                LessThanEqualToNegTwentyTwoDays++;
            }
            else if (_elapsedDays > (-22) && _elapsedDays <= (-15))
            {
                NegTwentyOneToNegFifteenDays++;
            }
            else if (_elapsedDays > (-15) && _elapsedDays <= (-8))
            {
                NegFourteenToNegEightDays++;
            }
            else if (_elapsedDays > (-8) && _elapsedDays <= (-1))
            {
                NegSevenToNegOneDays++;
            }
            else if (_elapsedDays == 0)
            {
                ZeroDays++;
            }
            else if (_elapsedDays >= 1 && _elapsedDays <= 7)
            {
                OneToSevenDays++;
            }
            else if (_elapsedDays >= 8 && _elapsedDays <= 14)
            {
                EightToFourteenDays++;
            }
            else if (_elapsedDays >= 15 && _elapsedDays <= 21)
            {
                FifteenToTwentyOneDays++;
            }
            else // 22 Days or greater
            {
                GreaterThanEqualToTwentyTwoDays++;
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







        #region IUnconfirmed Methods

        /// <summary>
        /// Calculated the percentage of unconfirmed records
        /// </summary>
        public void CalculatePercentUnconfirmed(int _unconfirmedTotal)
        {
            try
            {
                PercentUnconfirmed = Math.Round(((double)_unconfirmedTotal / TotalRecords) * 100, 2);
                if (double.IsNaN(PercentUnconfirmed))
                    PercentUnconfirmed = 0;

                if (double.IsInfinity(PercentUnconfirmed))
                    PercentUnconfirmed = 100;
            }
            catch (DivideByZeroException)
            {
                PercentUnconfirmed = 0;
            }
        }

        #endregion



        #region IFavorable Method

        /// <summary>
        /// Calculates the percent favorable for the specific KPA or KPI it is attached to
        /// </summary>
        public void CalculatePercentFavorable()
        {
            if (TotalRecords != 0)
            {
                // Sum up the favorable time spans
                double favorableTimeSpans = LessThanEqualToNegTwentyTwoDays + NegTwentyOneToNegFifteenDays + NegFourteenToNegEightDays + NegSevenToNegOneDays + ZeroDays;

                // calculate the Percent Favorable
                PercentFavorable = Math.Round((favorableTimeSpans / TotalRecords) * 100, 2);
            }
        }

        #endregion




        /// <summary>
        /// Returns the number of elapsed days based on certain conditions for this KPA
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
            int percentUnconfTotal = 0;
            double totalDays = 0;

            foreach (DataRow dr in DatabaseManager.posRecCompDt.Rows)
            {
                //Check if the datarow meets the conditions of any applied filters.
                if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                {
                    // This datarow dos not meet the conditions of the filters applied.
                    continue;
                }

                #region EVASO_BUT_NO_REC_DATE_CHECK

                string[] strLastPORecDate = (dr["Last PO Rec#Date"].ToString()).Split('/');
                int lastPORecDtYear = int.Parse(strLastPORecDate[2]);
                int lastPORecDtMonth = int.Parse(strLastPORecDate[0]);
                int lastPORecDtDay = int.Parse(strLastPORecDate[1]);


                if (lastPORecDtYear == 0 && lastPORecDtMonth == 0 && lastPORecDtDay == 0)
                {
                    // this po line or po in general may have been deleted.
                    continue;
                }

                #endregion


                DateTime lastPORecDate = new DateTime(lastPORecDtYear, lastPORecDtMonth, lastPORecDtDay);

                string[] strCurrConfDate = (dr["Latest Conf#Dt"].ToString()).Split('/');
                int currConfYear = int.Parse(strCurrConfDate[2]);
                int currConfMonth = int.Parse(strCurrConfDate[0]);
                int currConfDay = int.Parse(strCurrConfDate[1]);

                if (currConfYear == 0 && currConfMonth == 0 && currConfDay == 0)
                {
                    percentUnconfTotal++;
                    TotalRecords++;
                    continue;
                }
                else
                {
                    currConfYear = int.Parse(strCurrConfDate[2]);
                    currConfMonth = int.Parse(strCurrConfDate[0].TrimStart('0'));
                    currConfDay = int.Parse(strCurrConfDate[1].TrimStart('0'));
                }

                DateTime currConfDate = new DateTime(currConfYear, currConfMonth, currConfDay);
                double elapsedDays = (lastPORecDate - currConfDate).TotalDays;
                totalDays += elapsedDays;

                // Apply the elpased days against the time span conditions
                TimeSpanDump(elapsedDays);
            }


            // Caclualte the percent unconfirmed
            CalculatePercentUnconfirmed(percentUnconfTotal);


            // Calculate the average for this KPI
            CalculateAverage(totalDays);
        }
    }
}
