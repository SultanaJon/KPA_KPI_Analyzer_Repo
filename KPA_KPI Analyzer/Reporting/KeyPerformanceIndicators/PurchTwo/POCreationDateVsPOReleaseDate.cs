﻿using DataAccessLibrary;
using Reporting.TimeSpans.Templates;
using System;
using System.Data;
using System.Windows.Forms;

namespace Reporting.KeyPerformanceIndicators.PurchTwo
{
    public sealed class POCreationDateVsPOReleaseDate : KeyPerformanceIndicator
    {
        /// <summary>
        /// Interface to access the template data.
        /// </summary>
        TemplateFour template;




        /// <summary>
        /// Default Constructor
        /// </summary>
        public POCreationDateVsPOReleaseDate()
        {
            // Create a new template object
            TemplateBlock = new TemplateFour();
            template = TemplateBlock as TemplateFour;

            Section = "Purch II";
            Name = "PO Creation Date vs PO Release Date";
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

                    string[] strPOLine1stRelDt = (dr["PO Line 1st Rel Dt"].ToString()).Split('/');
                    int poLine1stRelDtYear = int.Parse(strPOLine1stRelDt[2]);
                    int poLine1stRelDtMonth = int.Parse(strPOLine1stRelDt[0]);
                    int poLine1stRelDtDay = int.Parse(strPOLine1stRelDt[1]);

                    if (poLine1stRelDtYear == 0 && poLine1stRelDtMonth == 0 && poLine1stRelDtDay == 0)
                    {

                        continue;
                    }
                    else
                    {
                        poLine1stRelDtYear = int.Parse(strPOLine1stRelDt[2]);
                        poLine1stRelDtMonth = int.Parse(strPOLine1stRelDt[0].TrimStart('0'));
                        poLine1stRelDtDay = int.Parse(strPOLine1stRelDt[1].TrimStart('0'));
                    }

                    DateTime poLine1stRelDate = new DateTime(poLine1stRelDtYear, poLine1stRelDtMonth, poLine1stRelDtDay);

                    string[] strPOLineCreateDt = (dr["PO Line Creat#DT"].ToString()).Split('/');
                    int poOLineCreateDtYear = int.Parse(strPOLineCreateDt[2]);
                    int poOLineCreateDtMonth = int.Parse(strPOLineCreateDt[0].TrimStart('0'));
                    int poOLineCreateDtDay = int.Parse(strPOLineCreateDt[1].TrimStart('0'));

                    DateTime poCreateDate = new DateTime(poOLineCreateDtYear, poOLineCreateDtMonth, poOLineCreateDtDay);
                    double elapsedDays = (poLine1stRelDate - poCreateDate).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;

                    // Apply the elapsed days to the time span conditions
                    template.TimeSpanDump(elapsedDays);
                }


                // Calcualte the average for this KPI
                template.CalculateAverage(totalDays);
            }
            catch (Exception)
            {
                MessageBox.Show("An argument out of range exception was thrown", "KPI - Purch II -> PO Creation Date vs PO Release Date - Overall Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}