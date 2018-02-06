using DataAccessLibrary;
using Filters;
using Reporting.TimeSpans.Templates;
using System;
using System.Data;
using System.Windows.Forms;

namespace Reporting.KeyPerformanceActions.HotJobs
{
    public sealed class LateToConfirmed : KeyPerformanceAction
    {
        /// <summary>
        /// Template to access the data.
        /// </summary>
        TemplateOne template;






        /// <summary>
        /// Default Constructor
        /// </summary>
        public LateToConfirmed()
        {
            // Create a new template object
            TemplateBlock = new TemplateOne();
            template = TemplateBlock as TemplateOne;

            Section = "Hot Jobs";
            Name = "Late to Confirmed";
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
                DataTable dt = KpaUtils.HotJobsQueries.GetLateToConfirmed();
                double totalDays = 0;

                // Get the fitlered data rows from the datatable
                DataRow[] filteredResult = dt.Select(FilterOptions.GetColumnNames(_filterOption, _filter));

                foreach (DataRow dr in filteredResult)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }

                    string[] strDate = (dr["Latest Conf#Dt"].ToString()).Split('/');
                    int year = int.Parse(strDate[2]);
                    int month = int.Parse(strDate[0].TrimStart('0'));
                    int day = int.Parse(strDate[1].TrimStart('0'));

                    DateTime delConfDate = new DateTime(year, month, day);
                    DateTime today = DateTime.Now.Date;

                    if (!(delConfDate < today))
                        continue;

                    double elapsedDays = (today - delConfDate).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;

                    // Apply the elapsed days agains the time span conditions
                    template.TimeSpanDump(elapsedDays);
                }

                // Calculate the average
                template.CalculateAverage(totalDays);

                dt.Rows.Clear();
                dt = null;
                GC.Collect();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("An argument out of range exception was thrown", "Hot Jobs -> Late To Confirmed Date - Overall Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                DataTable dt = KpaUtils.HotJobsQueries.GetLateToConfirmed();
                double totalDays = 0;

                foreach (DataRow dr in dt.Rows)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }

                    string[] strDate = (dr["Latest Conf#Dt"].ToString()).Split('/');
                    int year = int.Parse(strDate[2]);
                    int month = int.Parse(strDate[0].TrimStart('0'));
                    int day = int.Parse(strDate[1].TrimStart('0'));

                    DateTime delConfDate = new DateTime(year, month, day);
                    DateTime today = DateTime.Now.Date;

                    if (!(delConfDate < today))
                        continue;

                    double elapsedDays = (today - delConfDate).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;

                    // Apply the elapsed days agains the time span conditions
                    template.TimeSpanDump(elapsedDays);
                }

                // Calculate the average
                template.CalculateAverage(totalDays);

                dt.Rows.Clear();
                dt = null;
                GC.Collect();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("An argument out of range exception was thrown", "Hot Jobs -> Late To Confirmed Date - Overall Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }            
        }
    }
}
