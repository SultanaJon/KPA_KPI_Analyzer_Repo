using DataAccessLibrary;
using Filters;
using Reporting.TimeSpans.Templates;
using System;
using System.Data;
using System.Windows.Forms;

namespace Reporting.KeyPerformanceIndicators.Other
{
    public sealed class HotJobPRs : KeyPerformanceIndicator
    {
        /// <summary>
        /// Interface to access the template data.
        /// </summary>
        TemplateFive template;


        /// <summary>
        /// Default Constructor
        /// </summary>
        public HotJobPRs()
        {
            // Create a new template object
            TemplateBlock = new TemplateFive();
            template = TemplateBlock as TemplateFive;

            Section = "Other";
            Name = "Hot Jobs PRs";
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
            try
            {
                foreach (DataRow dr in DatabaseManager.AllDataDt.Rows)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }

                    // Check if this record is a hot job
                    if (dr["Purch# Group"].ToString() != "UHJ")
                        continue;

                    string[] strPrReqDt = (dr["Requisn Date"].ToString()).Split('/');
                    int reqDateYear = int.Parse(strPrReqDt[2]);
                    int reqDateMonth = int.Parse(strPrReqDt[0].TrimStart('0'));
                    int reqDateDay = int.Parse(strPrReqDt[1].TrimStart('0'));

                    DateTime prReqDate = new DateTime(reqDateYear, reqDateMonth, reqDateDay);

                    // Get the total value for this line item
                    template.TotalValue += decimal.Parse(dr["PR Pos#Value"].ToString());

                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (prReqDate - today).TotalDays;
                    double weeks = Math.Floor(elapsedDays / 7);

                    // Apply the weeks against the time span conditions
                    template.TimeSpanDump(weeks);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An argument out of range exception was thrown", "Other -> Hot Job PRs - Overall Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}
