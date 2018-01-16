﻿

using DataAccessLibrary;
using Reporting.TimeSpans.Templates;
using System;
using System.Data;
using System.Windows.Forms;

namespace Reporting.KeyPerformanceActions.HotJobs
{
    public sealed class NoConfirmations : KeyPerformanceAction
    {
        /// <summary>
        /// Template to access the data.
        /// </summary>
        TemplateOne template;






        /// <summary>
        /// Default Constructor
        /// </summary>
        public NoConfirmations()
        {
            // Create a new template object
            TemplateBlock = new TemplateOne();
            template = TemplateBlock as TemplateOne;

            Section = "Hot Jobs";
            Name = "No Confirmations";
        }



        /// <summary>
        /// Calculates the overall report for this KPA
        /// </summary>
        public override void Run()
        {
            try
            {
                DataTable dt = KpaUtils.HotJobsQueries.GetNoConfirmations();
                double totalDays = 0;


                foreach (DataRow dr in dt.Rows)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }

                    string[] strDate = (dr["PO Line Creat#DT"].ToString()).Split('/');
                    int year = int.Parse(strDate[2]);
                    int month = int.Parse(strDate[0].TrimStart('0'));
                    int day = int.Parse(strDate[1].TrimStart('0'));

                    DateTime date = new DateTime(year, month, day);
                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (today - date).TotalDays;
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
            catch (Exception)
            {
                MessageBox.Show("An argument out of range exception was thrown", "Hot Jobs -> No Confirmations - Overall Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}
