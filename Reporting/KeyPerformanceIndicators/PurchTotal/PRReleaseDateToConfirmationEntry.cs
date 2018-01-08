using Reporting.Overall;
using Reporting.Selective;
using Reporting.Interfaces;
using System;
using System.Data;
using DataAccessLibrary;

namespace Reporting.KeyPerformanceIndicators.PurchTotal
{
    public sealed class PRReleaseDateToConfirmationEntry : KeyPerformanceIndicator, ITemplateFour, IUnconfirmed
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
        public PRReleaseDateToConfirmationEntry()
        {
            Section = "Purch Total";
            Name = "PR Release Date to Confirmation Entry";

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

                string[] strfirstConfCreateDt = (dr["1st Conf Creation Da"].ToString()).Split('/');
                int firstConfCreateYear = int.Parse(strfirstConfCreateDt[2]);
                int firstConfCreateMonth = int.Parse(strfirstConfCreateDt[0]);
                int firstConfCreateDay = int.Parse(strfirstConfCreateDt[1]);

                if (firstConfCreateYear == 0 && firstConfCreateMonth == 0 & firstConfCreateDay == 0)
                {
                    percentUnconfTotal++;
                    TotalRecords++;
                    continue;
                }
                else
                {
                    firstConfCreateYear = int.Parse(strfirstConfCreateDt[2]);
                    firstConfCreateMonth = int.Parse(strfirstConfCreateDt[0].TrimStart('0'));
                    firstConfCreateDay = int.Parse(strfirstConfCreateDt[1].TrimStart('0'));
                }

                DateTime poLineConfCreateDate = new DateTime(firstConfCreateYear, firstConfCreateMonth, firstConfCreateDay);

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
                double elapsedDays = (poLineConfCreateDate - prFullyRelDt).TotalDays;
                totalDays += elapsedDays;
                elapsedDays = (int)elapsedDays;


                // Apply the elapsed days against the time span conditions
                TimeSpanDump(elapsedDays);

            }

            // Calculate the percent uncofirmed for this KPI
            CalculatePercentUnconfirmed(percentUnconfTotal);

            // Calculate the average for this KPI
            CalculateAverage(totalDays);
        }
    }
}
