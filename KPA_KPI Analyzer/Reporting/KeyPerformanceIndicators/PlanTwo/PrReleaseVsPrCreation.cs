﻿using DataAccessLibrary;
using Reporting.TimeSpans.Templates;
using System;
using System.Data;
using System.Windows.Forms;

namespace Reporting.KeyPerformanceIndicators.PlanTwo
{
    public sealed class PrReleaseVsPrCreation : KeyPerformanceIndicator
    {
        /// <summary>
        /// Interface to access the template data.
        /// </summary>
        TemplateFour template;


        #region IFavorable Properties

        /// <summary>
        /// The percent favorable for the KPA or KPI it is attached to.
        /// </summary>
        public double PercentFavorable { get; set; }

        #endregion




        /// <summary>
        /// Default Constructor
        /// </summary>
        public PrReleaseVsPrCreation()
        {
            // Create a new template object
            TemplateBlock = new TemplateFour();
            template = TemplateBlock as TemplateFour;

            Section = "Plan II";
            Name = "PR Release Date vs PR Creation Date";
        }





        /// <summary>
        /// Calculates the overall report for this KPA
        /// </summary>
        public override void Run()
        {
            double totalDays = 0;

            try
            {
                foreach (DataRow dr in DatabaseManager.prFullyReleasedDt.Rows)
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
                        // This PR line or PR in general might have been deleted
                        continue;
                    }

                    #endregion

                    // Get the Requisition date and seperate the date into year, month, and day integers
                    string[] strReqCreateDate = (dr["Requisn Date"].ToString()).Split('/');
                    int reqCreateYear = int.Parse(strReqCreateDate[2]);
                    int reqCreateMonth = int.Parse(strReqCreateDate[0].TrimStart('0'));
                    int reqCreateDay = int.Parse(strReqCreateDate[1].TrimStart('0'));

                    // Create the date objects
                    DateTime reqCreateDate = new DateTime(reqCreateYear, reqCreateMonth, reqCreateDay);
                    DateTime prFullReleaseDate = new DateTime(prFullyRelYear, prFullyRelMonth, prFullyRelDay);

                    double elapsedDays = (prFullReleaseDate - reqCreateDate).TotalDays;
                    totalDays += elapsedDays;

                    // Apply the elapsed days against the time span dump
                    template.TimeSpanDump(elapsedDays);
                }

                // Calculate the average for this KPI
                template.CalculateAverage(totalDays);
            }
            catch (Exception)
            {
                MessageBox.Show("An argument out of range exception was thrown", "KPI - Plan II -> PR Release Date vs PR Creation Date - Overall Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}
