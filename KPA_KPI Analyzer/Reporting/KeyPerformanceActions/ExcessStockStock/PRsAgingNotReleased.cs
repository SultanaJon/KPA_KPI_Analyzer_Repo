﻿

using DataAccessLibrary;
using Filters;
using Reporting.TimeSpans.Templates;
using System;
using System.Data;
using System.Windows.Forms;

namespace Reporting.KeyPerformanceActions.ExcessStockStock
{
    public sealed class PRsAgingNotReleased : KeyPerformanceAction
    {
        /// <summary>
        /// Template to access the data.
        /// </summary>
        TemplateOne template;






        /// <summary>
        /// Default Constructor
        /// </summary>
        public PRsAgingNotReleased()
        {
            // Create a new template object
            TemplateBlock = new TemplateOne();
            template = TemplateBlock as TemplateOne;

            Section = "Excess Stock - Stock";
            Name = "PRs Aging (Not Released)";
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
                DataTable dt = KpaUtils.ExcessStockStockQueries.GetPrsAgingNotReleased();
                double totalDays = 0;

                // remove any apostraphe's from the filter as an exception will be thrown.
                CleanFilter(ref _filter);

                // Get the fitlered data rows from the datatable
                DataRow[] filteredResult = dt.Select(FilterOptions.GetSelectStatement(_filterOption, _filter));

                foreach (DataRow dr in filteredResult)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }

                    string[] reqCreationDate = (dr["Requisn Date"].ToString()).Split('/');
                    int year = int.Parse(reqCreationDate[2]);
                    int month = int.Parse(reqCreationDate[0].TrimStart('0'));
                    int day = int.Parse(reqCreationDate[1].TrimStart('0'));

                    DateTime reqDate = new DateTime(year, month, day);
                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (today - reqDate).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;

                    // Apply the elapsed days against the time span conditions
                    template.TimeSpanDump(elapsedDays);
                }


                // Calculate the average for this KPA
                template.CalculateAverage(totalDays);

                dt.Rows.Clear();
                dt = null;
                GC.Collect();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("An argument out of range exception was thrown", "Excess Stock - Stock -> PRs Aging (Not Released) - Comparison Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }




        /// <summary>
        /// Calculates the overall report for this KPA
        /// </summary>
        public override void RunOverall()
        {
            try
            {
                DataTable dt = KpaUtils.ExcessStockStockQueries.GetPrsAgingNotReleased();
                double totalDays = 0;

                foreach (DataRow dr in dt.Rows)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }

                    string[] reqCreationDate = (dr["Requisn Date"].ToString()).Split('/');
                    int year = int.Parse(reqCreationDate[2]);
                    int month = int.Parse(reqCreationDate[0].TrimStart('0'));
                    int day = int.Parse(reqCreationDate[1].TrimStart('0'));

                    DateTime reqDate = new DateTime(year, month, day);
                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (today - reqDate).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;

                    // Apply the elapsed days against the time span conditions
                    template.TimeSpanDump(elapsedDays);
                }

                // Calculate the average for this KPA
                template.CalculateAverage(totalDays);

                dt.Rows.Clear();
                dt = null;
                GC.Collect();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("An argument out of range exception was thrown", "Excess Stock - Stock -> PRs Aging (Not Released) - Overall Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}
