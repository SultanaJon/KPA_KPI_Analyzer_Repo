using DataAccessLibrary;
using Filters;
using Reporting.TimeSpans.Templates;
using System;
using System.Data;
using System.Windows.Forms;

namespace Reporting.KeyPerformanceIndicators.PlanTwo
{
    public sealed class MaterialDueFinalPlannedDate : KeyPerformanceIndicator
    {
        /// <summary>
        /// Interface to access the template data.
        /// </summary>
        TemplateFour template;




        /// <summary>
        /// Default Constructor
        /// </summary>
        public MaterialDueFinalPlannedDate()
        {
            // Create a new template object
            TemplateBlock = new TemplateFour();
            template = TemplateBlock as TemplateFour;

            Section = "Plan II";
            Name = "Material Due (Final Planned Date)";
        }







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
                DataRow[] filteredResult = DatabaseManager.prsOnPOsDt.Select(FilterOptions.GetColumnNames(_filterOption, _filter));

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
                    int origPlanYear = int.Parse(strCurrPlanDate[2]);
                    int origPlanMonth = int.Parse(strCurrPlanDate[0]);
                    int origPlanDay = int.Parse(strCurrPlanDate[1]);

                    if (origPlanYear == 0 && origPlanMonth == 0 && origPlanDay == 0)
                    {
                        string[] strNewCurrPlanDelDate = (dr["Delivery Date"].ToString()).Split('/');
                        origPlanYear = int.Parse(strNewCurrPlanDelDate[2]);
                        origPlanMonth = int.Parse(strNewCurrPlanDelDate[0]);
                        origPlanDay = int.Parse(strNewCurrPlanDelDate[1]);

                        if (origPlanYear == 0 && origPlanMonth == 0 && origPlanDay == 0)
                        {
                            string[] strNewCurrPlanPrDelDate = (dr["PR Delivery Date"].ToString()).Split('/');
                            origPlanYear = int.Parse(strNewCurrPlanPrDelDate[2]);
                            origPlanMonth = int.Parse(strNewCurrPlanPrDelDate[0].TrimStart('0'));
                            origPlanDay = int.Parse(strNewCurrPlanPrDelDate[1].TrimStart('0'));
                        }
                        else
                        {
                            origPlanYear = int.Parse(strNewCurrPlanDelDate[2]);
                            origPlanMonth = int.Parse(strNewCurrPlanDelDate[0].TrimStart('0'));
                            origPlanDay = int.Parse(strNewCurrPlanDelDate[1].TrimStart('0'));
                        }
                    }
                    else
                    {
                        origPlanYear = int.Parse(strCurrPlanDate[2]);
                        origPlanMonth = int.Parse(strCurrPlanDate[0].TrimStart('0'));
                        origPlanDay = int.Parse(strCurrPlanDate[1].TrimStart('0'));
                    }

                    DateTime currPlanDate = new DateTime(origPlanYear, origPlanMonth, origPlanDay);

                    double elapsedDays = (currPlanDate - prFullyRelDt).TotalDays;
                    totalDays += elapsedDays;


                    // Apply the elapsed days against the time span conditions
                    template.TimeSpanDump(elapsedDays);
                }


                // Calculate the average for this KPI
                template.CalculateAverage(totalDays);
            }
            catch (Exception)
            {
                MessageBox.Show("An argument out of range exception was thrown", "KPI - Plan II -> Material Due (Final Planned Date) - Overall Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                foreach (DataRow dr in DatabaseManager.prsOnPOsDt.Rows)
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
                    int origPlanYear = int.Parse(strCurrPlanDate[2]);
                    int origPlanMonth = int.Parse(strCurrPlanDate[0]);
                    int origPlanDay = int.Parse(strCurrPlanDate[1]);

                    if (origPlanYear == 0 && origPlanMonth == 0 && origPlanDay == 0)
                    {
                        string[] strNewCurrPlanDelDate = (dr["Delivery Date"].ToString()).Split('/');
                        origPlanYear = int.Parse(strNewCurrPlanDelDate[2]);
                        origPlanMonth = int.Parse(strNewCurrPlanDelDate[0]);
                        origPlanDay = int.Parse(strNewCurrPlanDelDate[1]);

                        if (origPlanYear == 0 && origPlanMonth == 0 && origPlanDay == 0)
                        {
                            string[] strNewCurrPlanPrDelDate = (dr["PR Delivery Date"].ToString()).Split('/');
                            origPlanYear = int.Parse(strNewCurrPlanPrDelDate[2]);
                            origPlanMonth = int.Parse(strNewCurrPlanPrDelDate[0].TrimStart('0'));
                            origPlanDay = int.Parse(strNewCurrPlanPrDelDate[1].TrimStart('0'));
                        }
                        else
                        {
                            origPlanYear = int.Parse(strNewCurrPlanDelDate[2]);
                            origPlanMonth = int.Parse(strNewCurrPlanDelDate[0].TrimStart('0'));
                            origPlanDay = int.Parse(strNewCurrPlanDelDate[1].TrimStart('0'));
                        }
                    }
                    else
                    {
                        origPlanYear = int.Parse(strCurrPlanDate[2]);
                        origPlanMonth = int.Parse(strCurrPlanDate[0].TrimStart('0'));
                        origPlanDay = int.Parse(strCurrPlanDate[1].TrimStart('0'));
                    }

                    DateTime currPlanDate = new DateTime(origPlanYear, origPlanMonth, origPlanDay);

                    double elapsedDays = (currPlanDate - prFullyRelDt).TotalDays;
                    totalDays += elapsedDays;


                    // Apply the elapsed days against the time span conditions
                    template.TimeSpanDump(elapsedDays);
                }


                // Calculate the average for this KPI
                template.CalculateAverage(totalDays);
            }
            catch (Exception)
            {
                MessageBox.Show("An argument out of range exception was thrown", "KPI - Plan II -> Material Due (Final Planned Date) - Overall Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}
