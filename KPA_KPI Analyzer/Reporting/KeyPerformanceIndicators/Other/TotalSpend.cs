﻿using DataAccessLibrary;
using Filters;
using Reporting.TimeSpans.Templates;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Reporting.KeyPerformanceIndicators.Other
{
    public sealed class TotalSpend : KeyPerformanceIndicator
    {
        /// <summary>
        /// Interface to access the template data.
        /// </summary>
        TemplateFive template;



        /// <summary>
        /// Default Constructor
        /// </summary>
        public TotalSpend()
        {
            // Create a new template object
            TemplateBlock = new TemplateFive();
            template = TemplateBlock as TemplateFive;

            Section = "Other";
            Name = "Total Spend";
        }




        /// <summary>
        /// This KPI need its own GetTemplateData method because all values are currency except the total number of records.
        /// </summary>
        /// <returns>The list of template data</returns>
        public List<string> GetTemplateData()
        {
            List<string> temp = new List<string>();
            temp.Add(string.Format("{0:n}", "$" + template.TotalValue));
            temp.Add(string.Format("{0:n}", "$" + template.GreaterThanEqualToZeroWeeks));
            temp.Add(string.Format("{0:n}", "$" + template.GreaterThanEqualToNegOneWeek));
            temp.Add(string.Format("{0:n}", "$" + template.GreaterThanEqualToNegTwoWeeks));
            temp.Add(string.Format("{0:n}", "$" + template.GreaterThanEqualToNegThreeWeeks));
            temp.Add(string.Format("{0:n}", "$" + template.GreaterThanEqualToNegFourWeeks));
            temp.Add(string.Format("{0:n}", "$" +  template.GreaterThanEqualToNegFiveWeeks));
            temp.Add(string.Format("{0:n}", "$" +  template.GreaterThanEqualToNegSixWeeks));
            temp.Add(string.Format("{0:n}", "$" +  template.GreaterThanEqualToNegSevenWeeks));
            temp.Add(string.Format("{0:n}", "$" +  template.GreaterThanEqualToNegEightWeeks));
            temp.Add(string.Format("{0:n}", "$" + template.LessThanNegEightWeeks));
            temp.Add(string.Format("{0:n0}", template.TotalRecords));
            return temp;
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
                DataRow[] filteredResult = DatabaseManager.prsOnPOsDt.Select(FilterOptions.GetSelectStatement(_filterOption, _filter));

                foreach (DataRow dr in filteredResult)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }

                    string[] strPoCreateDt = (dr["PO Line Creat#DT"].ToString()).Split('/');
                    int poCreateDtYear = int.Parse(strPoCreateDt[2]);
                    int poCreateDtMonth = int.Parse(strPoCreateDt[0]);
                    int poCreateDtDay = int.Parse(strPoCreateDt[1]);

                    //////////////////////////////////////////////////////////////////////////////
                    //
                    // The below if statement was added on 03/27/2018.
                    // -----------------------------------------------
                    // There was some issues with a few POs that conatined dates of 00/00/0000
                    // that were causing erros. This if else statement ignores those files.
                    //
                    //////////////////////////////////////////////////////////////////////////////
                    if (poCreateDtDay == 0 && poCreateDtMonth == 0 && poCreateDtYear == 0)
                    {
                        // This situation is a SAP issue. We should never have POs that dont
                        // have a PO creation date.
                        // Skip these records
                        continue;
                    }
                    else
                    {
                        // trim the zeros off of month and day if there is any.
                        poCreateDtMonth = int.Parse(strPoCreateDt[0].Trim('0'));
                        poCreateDtDay = int.Parse(strPoCreateDt[1].Trim('0'));
                    }


                    DateTime poCreateDate = new DateTime(poCreateDtYear, poCreateDtMonth, poCreateDtDay);

                    template.TotalValue += decimal.Parse(dr["PO Value"].ToString());

                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (poCreateDate - today).TotalDays;
                    double weeks = Math.Floor(elapsedDays / 7);

                    // apply the weeks against the time span conditions
                    template.TimeSpanDumpV2(weeks, dr);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An argument out of range exception was thrown", "Other -> Total Spend - Comparison Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                foreach (DataRow dr in DatabaseManager.prsOnPOsDt.Rows)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }

                    string[] strPoCreateDt = (dr["PO Line Creat#DT"].ToString()).Split('/');
                    int poCreateDtYear = int.Parse(strPoCreateDt[2]);
                    int poCreateDtMonth = int.Parse(strPoCreateDt[0]);
                    int poCreateDtDay = int.Parse(strPoCreateDt[1]);

                    //////////////////////////////////////////////////////////////////////////////
                    //
                    // The below if statement was added on 03/27/2018.
                    // -----------------------------------------------
                    // There was some issues with a few POs that conatined dates of 00/00/0000
                    // that were causing erros. This if else statement ignores those files.
                    //
                    //////////////////////////////////////////////////////////////////////////////
                    if (poCreateDtDay == 0 && poCreateDtMonth == 0 && poCreateDtYear == 0)
                    {
                        // This situation is a SAP issue. We should never have POs that dont
                        // have a PO creation date.
                        // Skip these records
                        continue;
                    }
                    else
                    {
                        // trim the zeros off of month and day if there is any.
                        poCreateDtMonth = int.Parse(strPoCreateDt[0].Trim('0'));
                        poCreateDtDay = int.Parse(strPoCreateDt[1].Trim('0'));
                    }


                    DateTime poCreateDate = new DateTime(poCreateDtYear, poCreateDtMonth, poCreateDtDay);

                    template.TotalValue += decimal.Parse(dr["PO Value"].ToString());

                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (poCreateDate - today).TotalDays;
                    double weeks = Math.Floor(elapsedDays / 7);

                    // apply the weeks against the time span conditions
                    template.TimeSpanDumpV2(weeks, dr);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An argument out of range exception was thrown", "Other -> Total Spend - Overall Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}
