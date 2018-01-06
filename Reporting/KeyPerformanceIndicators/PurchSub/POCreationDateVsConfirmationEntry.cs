using Reporting.Overall;
using Reporting.Selective;
using Reporting.Interfaces;
using System;
using System.Data;
using DataAccessLibrary;

namespace Reporting.KeyPerformanceIndicators.PurchSub
{
    public sealed class POCreationDateVsConfirmationEntry : KeyPerformanceIndicator, ITemplateFour, IUnconfirmed
    {
        #region IUnconfirmed Properties

        /// <summary>
        /// The percent of unconfirmed records within the KPA or KPI
        /// </summary>
        public double PercentUnconfirmed { get; set; }

        #endregion



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
        public POCreationDateVsConfirmationEntry()
        {
            Section = "Purch Sub";
            Name = "PO Creation Date vs Confirmation Entry";

            // set the selective strategy context
            SelectiveContext = new SelectiveStrategyContext(new SelectiveDataTypeTwo());
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
            int percentUnconfTotal = 0;
            double totalDays = 0;

            foreach (DataRow dr in DatabaseManager.prsOnPOsDt.Rows)
            {
                //Check if the datarow meets the conditions of any applied filters.
                if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                {
                    // This datarow dos not meet the conditions of the filters applied.
                    continue;
                }

                string[] strFirstConfCreateDate = (dr["1st Conf Creation Da"].ToString()).Split('/');
                int poLineFirstConfCreateYear = int.Parse(strFirstConfCreateDate[2]);
                int poLineFirstConfCreateMonth = int.Parse(strFirstConfCreateDate[0]);
                int poLineFirstConfCreateDay = int.Parse(strFirstConfCreateDate[1]);

                if (poLineFirstConfCreateYear == 0 && poLineFirstConfCreateMonth == 0 && poLineFirstConfCreateDay == 0)
                {
                    percentUnconfTotal++;
                    TotalRecords++;
                    continue;
                }
                else
                {
                    poLineFirstConfCreateYear = int.Parse(strFirstConfCreateDate[2]);
                    poLineFirstConfCreateMonth = int.Parse(strFirstConfCreateDate[0]);
                    poLineFirstConfCreateDay = int.Parse(strFirstConfCreateDate[1]);
                }


                DateTime initialConfCreateDate = new DateTime(poLineFirstConfCreateYear, poLineFirstConfCreateMonth, poLineFirstConfCreateDay);

                string[] strPOLineCreateDt = (dr["PO Line Creat#DT"].ToString()).Split('/');
                int poLineCreateYear = int.Parse(strPOLineCreateDt[2]);
                int poLineCreateMonth = int.Parse(strPOLineCreateDt[0].TrimStart('0'));
                int poLineCreateDay = int.Parse(strPOLineCreateDt[1].TrimStart('0'));

                DateTime poLineItemCreateDate = new DateTime(poLineCreateYear, poLineCreateMonth, poLineCreateDay);

                double elapsedDays = (initialConfCreateDate - poLineItemCreateDate).TotalDays;
                totalDays += elapsedDays;
                elapsedDays = (int)elapsedDays;

                // Apply the elapsed days against the time span conditions
                TimeSpanDump(elapsedDays);
            }


            // Calculate the average for this KPI
            CalculateAverage(totalDays);

            // Calculate the percent unconfirmed for this KPI
            CalculatePercentUnconfirmed(percentUnconfTotal);
        }
    }
}
