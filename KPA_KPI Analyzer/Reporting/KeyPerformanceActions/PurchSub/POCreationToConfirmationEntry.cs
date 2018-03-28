using DataAccessLibrary;
using Filters;
using Reporting.TimeSpans.Templates;
using System;
using System.Data;
using System.Windows.Forms;

namespace Reporting.KeyPerformanceActions.PurchSub
{
    public sealed class POCreationToConfirmationEntry : KeyPerformanceAction
    {
        /// <summary>
        /// Template to access the data.
        /// </summary>
        TemplateOne template;






        /// <summary>
        /// Default Constructor
        /// </summary>
        public POCreationToConfirmationEntry()
        {
            // Create a new template object
            TemplateBlock = new TemplateOne();
            template = TemplateBlock as TemplateOne;

            Section = "Purch Sub";
            Name = "PO Creation To Confirmation Entry";
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
                DataTable dt = KpaUtils.PurchSubQueries.GetPoCreationToConfirmationEntry();
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

                    string[] strDate = (dr["PO Line Creat#DT"].ToString()).Split('/');
                    int year = int.Parse(strDate[2]);
                    int month = int.Parse(strDate[0]);
                    int day = int.Parse(strDate[1]);

                    //////////////////////////////////////////////////////////////////////////////
                    //
                    // The below if statement was added on 03/27/2018.
                    // -----------------------------------------------
                    // There was some issues with a few POs that conatined dates of 00/00/0000
                    // that were causing erros. This if else statement ignores those files.
                    //
                    //////////////////////////////////////////////////////////////////////////////
                    if (day == 0 && month == 0 && year == 0)
                    {
                        // This situation is a SAP issue. We should never have POs that dont
                        // have a PO creation date.
                        // Skip these records
                        continue;
                    }
                    else
                    {
                        // trim the zeros off of month and day if there is any.
                        month = int.Parse(strDate[0].Trim('0'));
                        day = int.Parse(strDate[1].Trim('0'));
                    }

                    DateTime date = new DateTime(year, month, day);
                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (today - date).TotalDays;
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
                MessageBox.Show("An argument out of range exception was thrown", "Purch Sub -> PO Creation to Confirmation Entry - Comparison Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }        }




        /// <summary>
        /// Calculates the overall report for this KPA
        /// </summary>
        public override void RunOverall()
        {
            try
            {
                DataTable dt = KpaUtils.PurchSubQueries.GetPoCreationToConfirmationEntry();
                double totalDays = 0;


                foreach (DataRow dr in dt.Rows)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }

                    string[] strDate = (dr["PO Line Creat#DT"].ToString()).Split('/');
                    int year = int.Parse(strDate[2]);
                    int month = int.Parse(strDate[0]);
                    int day = int.Parse(strDate[1]);

                    //////////////////////////////////////////////////////////////////////////////
                    //
                    // The below if statement was added on 03/27/2018.
                    // -----------------------------------------------
                    // There was some issues with a few POs that conatined dates of 00/00/0000
                    // that were causing erros. This if else statement ignores those files.
                    //
                    //////////////////////////////////////////////////////////////////////////////
                    if (day == 0 && month == 0 && year == 0)
                    {
                        // This situation is a SAP issue. We should never have POs that dont
                        // have a PO creation date.
                        // Skip these records
                        continue;
                    }
                    else
                    {
                        // trim the zeros off of month and day if there is any.
                        month = int.Parse(strDate[0].Trim('0'));
                        day = int.Parse(strDate[1].Trim('0'));
                    }

                    DateTime date = new DateTime(year, month, day);
                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (today - date).TotalDays;
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
                MessageBox.Show("An argument out of range exception was thrown", "Purch Sub -> PO Creation to Confirmation Entry - Overall Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}
