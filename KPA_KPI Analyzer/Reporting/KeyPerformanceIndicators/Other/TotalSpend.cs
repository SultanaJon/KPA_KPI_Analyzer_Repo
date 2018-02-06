using DataAccessLibrary;
using Reporting.TimeSpans.Templates;
using System;
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
        /// Calculates the overall report for this KPA
        /// </summary>
        public override void Run()
        {
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

                    string[] strPoCreateDt = (dr["PO Line Creat#DT"].ToString()).Split('/');
                    int poCreateDtYear = int.Parse(strPoCreateDt[2]);
                    int poCreateDtMonth = int.Parse(strPoCreateDt[0].TrimStart('0'));
                    int poCreateDtDay = int.Parse(strPoCreateDt[1].TrimStart('0'));

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
