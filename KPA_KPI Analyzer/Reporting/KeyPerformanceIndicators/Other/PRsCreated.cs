using DataAccessLibrary;
using Filters;
using Reporting.TimeSpans.Templates;
using System;
using System.Data;
using System.Windows.Forms;

namespace Reporting.KeyPerformanceIndicators.Other
{
    public sealed class PRsCreated : KeyPerformanceIndicator
    {
        /// <summary>
        /// Interface to access the template data.
        /// </summary>
        TemplateFive template;



        /// <summary>
        /// Default Constructor
        /// </summary>
        public PRsCreated()
        {
            // Create a new template object
            TemplateBlock = new TemplateFive();
            template = TemplateBlock as TemplateFive;

            Section = "Other";
            Name = "PRs Created";
        }







        /// <summary>
        /// Runs the comparison report against the supplied filter
        /// </summary>
        /// <param name="_fitler">The filter we want to run against this KPA</param>
        /// <param name="_option">The filter option where this fitler was obtained</param>
        public override void RunComparison(string _filter, FilterOptions.Options _filterOption)
        {
            try
            {
                // Remove any apostrophe's from the filter or an exception will be thrown
                CleanFilter(ref _filter);

                // Get the filtered data rows from the datatable
                DataRow[] filteredResult = DatabaseManager.AllDataDt.Select(FilterOptions.GetColumnNames(_filterOption, _filter));

                foreach (DataRow dr in filteredResult)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }

                    string[] strReqDate = (dr["Requisn Date"].ToString()).Split('/');
                    int reqDateYear = int.Parse(strReqDate[2]);
                    int reqDateMonth = int.Parse(strReqDate[0].TrimStart('0'));
                    int reqDateDay = int.Parse(strReqDate[1].TrimStart('0'));

                    DateTime requiDate = new DateTime(reqDateYear, reqDateMonth, reqDateDay);

                    template.TotalValue += decimal.Parse(dr["PR Pos#Value"].ToString());

                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (requiDate - today).TotalDays;
                    double weeks = Math.Floor(elapsedDays / 7);

                    // Apply the weeks against the time span dump
                    template.TimeSpanDump(weeks);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An argument out of range exception was thrown", "Other -> PRs Created - Comparison Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
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

                    string[] strReqDate = (dr["Requisn Date"].ToString()).Split('/');
                    int reqDateYear = int.Parse(strReqDate[2]);
                    int reqDateMonth = int.Parse(strReqDate[0].TrimStart('0'));
                    int reqDateDay = int.Parse(strReqDate[1].TrimStart('0'));

                    DateTime requiDate = new DateTime(reqDateYear, reqDateMonth, reqDateDay);

                    template.TotalValue += decimal.Parse(dr["PR Pos#Value"].ToString());

                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (requiDate - today).TotalDays;
                    double weeks = Math.Floor(elapsedDays / 7);

                    // Apply the weeks against the time span dump
                    template.TimeSpanDump(weeks);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An argument out of range exception was thrown", "Other -> PRs Created - Overall Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}
