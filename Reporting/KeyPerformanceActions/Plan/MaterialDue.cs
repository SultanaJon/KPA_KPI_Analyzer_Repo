﻿using DataAccessLibrary;
using Filters;
using Reporting.TimeSpans.Templates;
using System;
using System.Data;
using System.Windows.Forms;

namespace Reporting.KeyPerformanceActions.Plan
{
    public sealed class MaterialDue : KeyPerformanceAction
    {
        /// <summary>
        /// Template to access the data.
        /// </summary>
        TemplateOne template;






        /// <summary>
        /// Default Constructor
        /// </summary>
        public MaterialDue()
        {
            // Create a new template object
            TemplateBlock = new TemplateOne();
            template = TemplateBlock as TemplateOne;

            Section = "Plan";
            Name = "Material Due";
        }




        /// <summary>
        /// Calculates the overall report for this KPA
        /// </summary>
        public override void Run()
        {
            try
            {
                DataTable dt = KpaUtils.PlanQueries.GetMaterialDue();
                double totalDays = 0;

                foreach (DataRow dr in dt.Rows)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }

                    string[] strCurrReqDate = (dr["PR Delivery Date"].ToString()).Split('/');
                    int year = int.Parse(strCurrReqDate[2]);
                    int month = int.Parse(strCurrReqDate[0].TrimStart('0'));
                    int day = int.Parse(strCurrReqDate[1].TrimStart('0'));

                    DateTime currReqDate = new DateTime(year, month, day);
                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (currReqDate - today).TotalDays;
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
            catch (Exception)
            {
                MessageBox.Show("An argument out of range exception was thrown", "Plan -> Material Due - Overall Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}
