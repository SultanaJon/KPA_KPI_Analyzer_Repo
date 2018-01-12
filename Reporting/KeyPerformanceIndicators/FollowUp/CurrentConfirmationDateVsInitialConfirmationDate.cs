using DataAccessLibrary;
using Reporting.Interfaces;
using Reporting.Overall;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Reporting.KeyPerformanceIndicators.FollowUp
{
    public sealed class CurrentConfirmationDateVsInitialConfirmationDate : KeyPerformanceIndicator, ISelective,  ITemplateThree, IUnconfirmed, IFavorable
    {
        #region IFavorable Properties

        /// <summary>
        /// The percent favorable for the KPA or KPI it is attached to.
        /// </summary>
        public double PercentFavorable { get; set; }

        #endregion




        #region IUnconfirmed Properties

        /// <summary>
        /// The total of records that are unconfirmed
        /// </summary>
        public int UnconfirmedTotal { get; set; }


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
        public CurrentConfirmationDateVsInitialConfirmationDate()
        {
            Section = "Follow Up";
            Name = "Current Confirmation Date vs Initial Confirmation Date";
        }




        /// <summary>
        /// Returns the template one data for this KPA
        /// </summary>
        /// <returns></returns>
        public List<string> GetTemplateData()
        {
            List<string> row = new List<string>();

            // Create template row data
            row.Add(Section);
            row.Add(Name);
            row.Add(string.Format("{0:n}", Average));
            row.Add(string.Format("{0:n0}", LessThanEqualToNegTwentyTwoDays));
            row.Add(string.Format("{0:n0}", NegTwentyOneToNegFifteenDays));
            row.Add(string.Format("{0:n0}", NegFourteenToNegEightDays));
            row.Add(string.Format("{0:n0}", NegSevenToNegOneDays));
            row.Add(string.Format("{0:n0}", ZeroDays));
            row.Add(string.Format("{0:n0}", OneToSevenDays));
            row.Add(string.Format("{0:n0}", EightToFourteenDays));
            row.Add(string.Format("{0:n0}", FifteenToTwentyOneDays));
            row.Add(string.Format("{0:n0}", GreaterThanEqualToTwentyTwoDays));
            row.Add(string.Format("{0:n0}", TotalRecords));
            row.Add(string.Format("{0:n0}", PercentUnconfirmed + "%"));
            row.Add(string.Format("{0:n0}", PercentFavorable + "%"));

            //return the template data for this KPA
            return row;
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
                Average = Math.Round(_totalDays / _totalRecords, 2);
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
            double totalDays = 0;

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

                    string[] strFirstConfDate = (dr["1st Conf Date"].ToString()).Split('/');
                    int firstConfYear = int.Parse(strFirstConfDate[2]);
                    int firstConfMonth = int.Parse(strFirstConfDate[0]);
                    int firstConfDay = int.Parse(strFirstConfDate[1]);


                    if (firstConfYear == 0 && firstConfMonth == 0 && firstConfDay == 0)
                    {
                        UnconfirmedTotal++;
                        TotalRecords++;
                        continue;
                    }
                    else
                    {
                        firstConfYear = int.Parse(strFirstConfDate[2]);
                        firstConfMonth = int.Parse(strFirstConfDate[0].TrimStart('0'));
                        firstConfDay = int.Parse(strFirstConfDate[1].TrimStart('0'));
                    }

                    DateTime firstConfDate = new DateTime(firstConfYear, firstConfMonth, firstConfDay);

                    string[] strDelConfDate = (dr["Latest Conf#Dt"].ToString()).Split('/');
                    int delConfYear = int.Parse(strDelConfDate[2]);
                    int delConfMonth = int.Parse(strDelConfDate[0].TrimStart('0'));
                    int delConfDay = int.Parse(strDelConfDate[1].TrimStart('0'));

                    DateTime delConfDate = new DateTime(delConfYear, delConfMonth, delConfDay);
                    double elapsedDays = (delConfDate - firstConfDate).TotalDays;
                    totalDays += elapsedDays;

                    // Apply the elpased days against the time span conditions
                    TimeSpanDump(elapsedDays);
                }


                // Caclualte the percent unconfirmed
                CalculatePercentUnconfirmed(UnconfirmedTotal);

                // Calculate the average for this KPI
                CalculateAverage(totalDays, TotalRecords);

                // Calculate percent favorable
                CalculatePercentFavorable();
            }
            catch (Exception)
            {
                MessageBox.Show("An argument out of range exception was thrown", "Follow Up -> Current Confirmation Date vs Initial Confirmation Date - Overall Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}