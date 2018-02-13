using DataAccessLibrary;
using Filters;
using Reporting.Interfaces;
using Reporting.TimeSpans.Templates;
using System;
using System.Data;
using System.Windows.Forms;

namespace Reporting.KeyPerformanceIndicators.FollowUp
{
    public sealed class FinalConfirmationDateVsFinalPlanDate : KeyPerformanceIndicator, IUnconfirmed, IFavorable
    {
        /// <summary>
        /// Interface to access the template data.
        /// </summary>
        TemplateThree template;


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




        /// <summary>
        /// Default Constructor
        /// </summary>
        public FinalConfirmationDateVsFinalPlanDate()
        {
            // Create a new template object
            TemplateBlock = new TemplateThree();
            template = TemplateBlock as TemplateThree;

            Section = "Follow Up";
            Name = "Final Confirmation Date vs Final Plan Date";
        }





        #region IUnconfirmed Methods

        /// <summary>
        /// Calculated the percentage of unconfirmed records
        /// </summary>
        public void CalculatePercentUnconfirmed(int _unconfirmedTotal)
        {
            try
            {
                PercentUnconfirmed = Math.Round(((double)_unconfirmedTotal / template.TotalRecords) * 100, 2);
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
            if (template.TotalRecords != 0)
            {
                // Sum up the favorable time spans
                double favorableTimeSpans = template.LessThanEqualToNegTwentyTwoDays + template.NegTwentyOneToNegFifteenDays + template.NegFourteenToNegEightDays + template.NegSevenToNegOneDays + template.ZeroDays;

                // calculate the Percent Favorable
                PercentFavorable = Math.Round((favorableTimeSpans / template.TotalRecords) * 100, 2);
            }
        }

        #endregion







        /// <summary>
        /// Runs the comparison report against the supplied filter
        /// </summary>
        /// <param name="_fitler">The filter we want to run against this KPA</param>
        /// <param name="_option">The filter option where this fitler was obtained</param>
        public override void RunComparison(string _filter, FilterOptions.Options _filterOption)
        {

        }




        /// <summary>
        /// Calculates the overall report for this KPA
        /// </summary>
        public override void Run()
        {
            double totalDays = 0;

            try
            {
                foreach (DataRow dr in DatabaseManager.posRecCompDt.Rows)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }

                    string[] strDelConfDate = (dr["Latest Conf#Dt"].ToString()).Split('/');
                    int delConfYear = int.Parse(strDelConfDate[2]);
                    int delConfMonth = int.Parse(strDelConfDate[0]);
                    int delConfDay = int.Parse(strDelConfDate[1]);

                    if (delConfYear == 0 && delConfMonth == 0 && delConfDay == 0)
                    {
                        UnconfirmedTotal++;
                        template.TotalRecords++;
                        continue;
                    }
                    else
                    {
                        delConfYear = int.Parse(strDelConfDate[2]);
                        delConfMonth = int.Parse(strDelConfDate[0].TrimStart('0'));
                        delConfDay = int.Parse(strDelConfDate[1].TrimStart('0'));
                    }

                    DateTime delConfDate = new DateTime(delConfYear, delConfMonth, delConfDay);


                    string[] strDelDate = (dr["Delivery Date"].ToString()).Split('/');
                    int delYear = int.Parse(strDelDate[2]);
                    int delMonth = int.Parse(strDelDate[0].TrimStart('0'));
                    int delDay = int.Parse(strDelDate[1].TrimStart('0'));

                    DateTime delDate = new DateTime(delYear, delMonth, delDay);
                    double elapsedDays = (delConfDate - delDate).TotalDays;
                    totalDays += elapsedDays;

                    // Apply the elpased days against the time span conditions
                    template.TimeSpanDump(elapsedDays);
                }


                // Caclualte the percent unconfirmed
                CalculatePercentUnconfirmed(UnconfirmedTotal);


                // Calculate the average for this KPI
                template.CalculateAverage(totalDays);

                // Calculate percent favorable
                CalculatePercentFavorable();
            }
            catch (Exception)
            {
                MessageBox.Show("An argument out of range exception was thrown", "Follow Up -> Final Confirmation Date vs Final Plan Date - Overall Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}
