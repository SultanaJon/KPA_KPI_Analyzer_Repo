using DataAccessLibrary;
using Filters;
using Reporting.Interfaces;
using Reporting.TimeSpans.Templates;
using System;
using System.Data;
using System.Windows.Forms;

namespace Reporting.KeyPerformanceIndicators.Plan
{
    public sealed class OriginalPlanDateTo2ndLvlReleaseDateVsCodedLead : KeyPerformanceIndicator, IFavorable
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



        /// <summary>
        /// Default Constructor
        /// </summary>
        public OriginalPlanDateTo2ndLvlReleaseDateVsCodedLead()
        {
            // Create a new template object
            TemplateBlock = new TemplateThree();
            template = TemplateBlock as TemplateThree;

            Section = "Plan";
            Name = "(Original Plan Date - 2nd Lvl Release Date) vs Coded Lead-Time";
        }







        #region IFavorable Method

        /// <summary>
        /// Calculates the percent favorable for the specific KPA or KPI it is attached to
        /// </summary>
        public void CalculatePercentFavorable()
        {
            if (template.TotalRecords != 0)
            {
                // Get the favorable timespans
                double favorableTimeSpans = template.ZeroDays + template.OneToSevenDays + template.EightToFourteenDays + template.FifteenToTwentyOneDays + template.GreaterThanEqualToTwentyTwoDays;

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
                foreach (DataRow dr in DatabaseManager.pr2ndLvlRelDateDt.Rows)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }



                    string[] strPrPlanDate = (dr["PR Delivery Date"].ToString()).Split('/');
                    int delConfYear = int.Parse(strPrPlanDate[2]);
                    int delConfMonth = int.Parse(strPrPlanDate[0].TrimStart('0'));
                    int delConfDay = int.Parse(strPrPlanDate[1].TrimStart('0'));



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
                    DateTime prPlanDate = new DateTime(delConfYear, delConfMonth, delConfDay);
                    int commCodeLeadTime = int.Parse(dr["Pl# Deliv# Time"].ToString());

                    double elapsedDays = (prPlanDate - prFullyRelDt).TotalDays;
                    elapsedDays -= commCodeLeadTime;
                    totalDays += elapsedDays;

                    // Apply the elapsed days against the time span conditions
                    template.TimeSpanDump(elapsedDays);
                }

                // Calculate the average for this KPI
                template.CalculateAverage(totalDays);

                // Calculate the percent facvorable for this KPI
                CalculatePercentFavorable();
            }
            catch (Exception)
            {
                MessageBox.Show("An argument out of range exception was thrown", "KPI - Plan -> (Original Plan Date - 2nd Lvl Release Date) vs Coded Lead-Time - Overall Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}
