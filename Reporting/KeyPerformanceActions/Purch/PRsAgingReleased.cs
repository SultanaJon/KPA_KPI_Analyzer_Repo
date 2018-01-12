using DataAccessLibrary;
using Reporting.Interfaces;
using Reporting.Overall;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Reporting.KeyPerformanceActions.Purch
{
    public sealed class PRsAgingReleased : KeyPerformanceAction, ISelective,  ITemplateOne
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
        public PRsAgingReleased()
        {
            Section = "Purch";
            Name = "PRs Aging (Released)";
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
                MessageBox.Show("An argument out of range exception was thrown", "Purch -> PRs Aging (Released) - Average Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        }



        /// <summary>
        /// Calculates the overall report for this KPA
        /// </summary>
        public override void RunOverallReport()
        {
            try
            {
                DataTable dt = KpaUtils.PurchQueries.GetPrsAgingReleased();
                double totalDays = 0;

                foreach (DataRow dr in dt.Rows)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }

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
                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (today - prFullyRelDt).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;


                    // Apply the elapsed days against the time span dump
                    TimeSpanDump(elapsedDays);
                }


                // Calculate the average for this KPA
                CalculateAverage(totalDays, TotalRecords);

                dt.Rows.Clear();
                dt = null;
                GC.Collect();
            }
            catch (Exception)
            {
                MessageBox.Show("An argument out of range exception was thrown", "Purch -> PRs Aging (Released) - Overall Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}
