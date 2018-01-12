using DataAccessLibrary;
using Reporting.Interfaces;
using Reporting.Overall;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Reporting.KeyPerformanceIndicators.PurchPlan
{
    public sealed class POReleaseVsPRDeliveryDate : KeyPerformanceIndicator, ISelective,  ITemplateFour
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
        public POReleaseVsPRDeliveryDate()
        {
            Section = "Purch Plan";
            Name = "PO Release vs PR Delivery Date";
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
            row.Add(string.Format("{0:n0}", LessThanEqualToZeroDays));
            row.Add(string.Format("{0:n0}", OneToThreeDays));
            row.Add(string.Format("{0:n0}", FourToSevenDays));
            row.Add(string.Format("{0:n0}", EightToFourteenDays));
            row.Add(string.Format("{0:n0}", FifteenToTwentyOneDays));
            row.Add(string.Format("{0:n0}", TwentyTwoToTwentyEightDays));
            row.Add(string.Format("{0:n0}", TwentyNineToThirtyFiveDays));
            row.Add(string.Format("{0:n0}", ThirtySixtoFourtyTwoDays));
            row.Add(string.Format("{0:n0}", FourtyThreeToFourtyNineDays));
            row.Add(string.Format("{0:n0}", FiftyToFiftySixDays));
            row.Add(string.Format("{0:n0}", FiftySevenPlusDays));
            row.Add(string.Format("{0:n0}", TotalRecords));

            //return the template data for this KPA
            return row;
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


                    string[] strPoLineFirstRelDate = (dr["PO Line 1st Rel Dt"].ToString()).Split('/');
                    int poLineFirstRelYear = int.Parse(strPoLineFirstRelDate[2]);
                    int poLineFirstRelMonth = int.Parse(strPoLineFirstRelDate[0]);
                    int poLineFirstRelDay = int.Parse(strPoLineFirstRelDate[1]);

                    if (poLineFirstRelYear == 0 && poLineFirstRelMonth == 0 && poLineFirstRelDay == 0)
                    {
                        continue;
                    }
                    else
                    {
                        poLineFirstRelYear = int.Parse(strPoLineFirstRelDate[2]);
                        poLineFirstRelMonth = int.Parse(strPoLineFirstRelDate[0].TrimStart('0'));
                        poLineFirstRelDay = int.Parse(strPoLineFirstRelDate[1].TrimStart('0'));
                    }

                    DateTime poLineFirstRelDate = new DateTime(poLineFirstRelYear, poLineFirstRelMonth, poLineFirstRelDay);

                    string[] strPRDelDate = (dr["PR Delivery Date"].ToString()).Split('/');
                    int prDelYear = int.Parse(strPRDelDate[2]);
                    int prDelMonth = int.Parse(strPRDelDate[0].TrimStart('0'));
                    int prDelDay = int.Parse(strPRDelDate[1].TrimStart('0'));

                    DateTime prDelDate = new DateTime(prDelYear, prDelMonth, prDelDay);
                    double elapsedDays = (prDelDate - poLineFirstRelDate).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;

                    // Apply the elapsed days against the time span conditions
                    TimeSpanDump(elapsedDays);
                }


                // Calculate the average for this KPI
                CalculateAverage(totalDays);
            }
            catch (Exception)
            {
                MessageBox.Show("An argument out of range exception was thrown", "KPI - PUrch/Plan -> PO Release vs PR Delivery Date - Overall Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}
