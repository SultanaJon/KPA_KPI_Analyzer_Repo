using DataAccessLibrary;
using Filters;
using Reporting.TimeSpans.Templates;
using System;
using System.Data;
using System.Windows.Forms;

namespace Reporting.KeyPerformanceIndicators.PlanTwo
{
    public sealed class MaterialDueOriginalPlannedDate : KeyPerformanceIndicator
    {
        /// <summary>
        /// Interface to access the template data.
        /// </summary>
        TemplateFour template;




        /// <summary>
        /// Default Constructor
        /// </summary>
        public MaterialDueOriginalPlannedDate()
        {
            // Create a new template object
            TemplateBlock = new TemplateFour();
            template = TemplateBlock as TemplateFour;

            Section = "Plan II";
            Name = "Material Due (Original Planned Date)";
        }







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



                    string[] strOrigPlanDate = (dr["PR Delivery Date"].ToString()).Split('/');
                    int origPlanYear = int.Parse(strOrigPlanDate[2]);
                    int origPlanMonth = int.Parse(strOrigPlanDate[0]);
                    int origPlanDay = int.Parse(strOrigPlanDate[1]);

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
                    DateTime origPlanDate = new DateTime(origPlanYear, origPlanMonth, origPlanDay);

                    double elapsedDays = (origPlanDate - prFullyRelDt).TotalDays;
                    totalDays += elapsedDays;

                    // Apply the elapsed days against the time span conditions
                    template.TimeSpanDump(elapsedDays);
                }


                // Calculate the average for this KPI
                template.CalculateAverage(totalDays);
            }
            catch (Exception)
            {
                MessageBox.Show("An argument out of range exception was thrown", "KPI - Plan II -> Material Due (Original Planned Date) - Overall Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}
