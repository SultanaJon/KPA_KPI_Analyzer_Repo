using DataAccessLibrary;
using Filters;
using Reporting.Interfaces;
using Reporting.TimeSpans.Templates;
using System;
using System.Data;
using System.Windows.Forms;

namespace Reporting.KeyPerformanceIndicators.Plan
{
    public sealed class CurrentPlanDateTo2ndLvlReleaseDateVsCodedLead : KeyPerformanceIndicator, IFavorable
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
        public CurrentPlanDateTo2ndLvlReleaseDateVsCodedLead()
        {
            // Create a new template object
            TemplateBlock = new TemplateThree();
            template = TemplateBlock as TemplateThree;

            Section = "Plan";
            Name = "(Current Plan Date - 2nd Lvl Release Date) vs Coded Lead-Time";
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
            double totalDays = 0;

            try
            {
                // Remove any apostrophe's from the filter or an exception will be thrown
                CleanFilter(ref _filter);

                // Get the filtered data rows from the datatable
                DataRow[] filteredResult = DatabaseManager.pr2ndLvlRelDateDt.Select(FilterOptions.GetSelectStatement(_filterOption, _filter));

                foreach (DataRow dr in filteredResult)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!FilterUtils.EvaluateAgainstFilters(dr))
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


                    string[] strCurrPlanDate = (dr["Rescheduling date"].ToString()).Split('/');
                    int currPlanYear = int.Parse(strCurrPlanDate[2]);
                    int currPlanMonth = int.Parse(strCurrPlanDate[0]);
                    int currPlanDay = int.Parse(strCurrPlanDate[1]);

                    if (currPlanYear == 0 && currPlanMonth == 0 && currPlanDay == 0)
                    {
                        string[] strNewCurrPlanDelDate = (dr["Delivery Date"].ToString()).Split('/');
                        currPlanYear = int.Parse(strNewCurrPlanDelDate[2]);
                        currPlanMonth = int.Parse(strNewCurrPlanDelDate[0]);
                        currPlanDay = int.Parse(strNewCurrPlanDelDate[1]);

                        if (currPlanYear == 0 && currPlanMonth == 0 && currPlanDay == 0)
                        {
                            string[] strNewCurrPlanPrDelDate = (dr["PR Delivery Date"].ToString()).Split('/');
                            currPlanYear = int.Parse(strNewCurrPlanPrDelDate[2]);
                            currPlanMonth = int.Parse(strNewCurrPlanPrDelDate[0].TrimStart('0'));
                            currPlanDay = int.Parse(strNewCurrPlanPrDelDate[1].TrimStart('0'));
                        }
                        else
                        {
                            currPlanYear = int.Parse(strNewCurrPlanDelDate[2]);
                            currPlanMonth = int.Parse(strNewCurrPlanDelDate[0].TrimStart('0'));
                            currPlanDay = int.Parse(strNewCurrPlanDelDate[1].TrimStart('0'));
                        }
                    }
                    else
                    {
                        currPlanYear = int.Parse(strCurrPlanDate[2]);
                        currPlanMonth = int.Parse(strCurrPlanDate[0].TrimStart('0'));
                        currPlanDay = int.Parse(strCurrPlanDate[1].TrimStart('0'));
                    }

                    DateTime currPlanDate = new DateTime(currPlanYear, currPlanMonth, currPlanDay);
                    int commCodedLeadTime = int.Parse(dr["Pl# Deliv# Time"].ToString());

                    double elapsedDays = (currPlanDate - prFullyRelDt).TotalDays;
                    elapsedDays -= commCodedLeadTime;
                    totalDays += elapsedDays;


                    // Apply the elapsed days against the time span dump
                    template.TimeSpanDump(elapsedDays);
                }


                // Calculate the average for this KPI
                template.CalculateAverage(totalDays);

                // Calculate the percent favorable for this KPI
                CalculatePercentFavorable();
            }
            catch (Exception)
            {
                MessageBox.Show("An argument out of range exception was thrown", "KPI - Plan -> (Current Plan Date - 2nd Lvl Release Date) vs Coded Lead-Time - Comparison Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
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


                    string[] strCurrPlanDate = (dr["Rescheduling date"].ToString()).Split('/');
                    int currPlanYear = int.Parse(strCurrPlanDate[2]);
                    int currPlanMonth = int.Parse(strCurrPlanDate[0]);
                    int currPlanDay = int.Parse(strCurrPlanDate[1]);

                    if (currPlanYear == 0 && currPlanMonth == 0 && currPlanDay == 0)
                    {
                        string[] strNewCurrPlanDelDate = (dr["Delivery Date"].ToString()).Split('/');
                        currPlanYear = int.Parse(strNewCurrPlanDelDate[2]);
                        currPlanMonth = int.Parse(strNewCurrPlanDelDate[0]);
                        currPlanDay = int.Parse(strNewCurrPlanDelDate[1]);

                        if (currPlanYear == 0 && currPlanMonth == 0 && currPlanDay == 0)
                        {
                            string[] strNewCurrPlanPrDelDate = (dr["PR Delivery Date"].ToString()).Split('/');
                            currPlanYear = int.Parse(strNewCurrPlanPrDelDate[2]);
                            currPlanMonth = int.Parse(strNewCurrPlanPrDelDate[0].TrimStart('0'));
                            currPlanDay = int.Parse(strNewCurrPlanPrDelDate[1].TrimStart('0'));
                        }
                        else
                        {
                            currPlanYear = int.Parse(strNewCurrPlanDelDate[2]);
                            currPlanMonth = int.Parse(strNewCurrPlanDelDate[0].TrimStart('0'));
                            currPlanDay = int.Parse(strNewCurrPlanDelDate[1].TrimStart('0'));
                        }
                    }
                    else
                    {
                        currPlanYear = int.Parse(strCurrPlanDate[2]);
                        currPlanMonth = int.Parse(strCurrPlanDate[0].TrimStart('0'));
                        currPlanDay = int.Parse(strCurrPlanDate[1].TrimStart('0'));
                    }

                    DateTime currPlanDate = new DateTime(currPlanYear, currPlanMonth, currPlanDay);
                    int commCodedLeadTime = int.Parse(dr["Pl# Deliv# Time"].ToString());

                    double elapsedDays = (currPlanDate - prFullyRelDt).TotalDays;
                    elapsedDays -= commCodedLeadTime;
                    totalDays += elapsedDays;


                    // Apply the elapsed days against the time span dump
                    template.TimeSpanDump(elapsedDays);
                }


                // Calculate the average for this KPI
                template.CalculateAverage(totalDays);

                // Calculate the percent favorable for this KPI
                CalculatePercentFavorable();
            }
            catch (Exception)
            {
                MessageBox.Show("An argument out of range exception was thrown", "KPI - Plan -> (Current Plan Date - 2nd Lvl Release Date) vs Coded Lead-Time - Overall Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}
