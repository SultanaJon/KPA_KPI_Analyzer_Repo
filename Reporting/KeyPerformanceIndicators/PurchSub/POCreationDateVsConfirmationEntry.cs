using DataAccessLibrary;
using Reporting.Interfaces;
using Reporting.TimeSpans.Templates;
using System;
using System.Data;
using System.Windows.Forms;

namespace Reporting.KeyPerformanceIndicators.PurchSub
{
    public sealed class POCreationDateVsConfirmationEntry : KeyPerformanceIndicator, IUnconfirmed
    {
        #region IUnconfirmed Properties

        /// <summary>
        /// The total of records that are unconfirmed
        /// </summary>
        public int UnconfirmedTotal { get; set; }



        /// <summary>
        /// The percent of unconfirmed records within the KPA or KPI
        /// </summary>
        public double PercentUnconfirmed { get; set; }

        #endregion



        /// <summary>
        /// Interface to access the template data.
        /// </summary>
        TemplateFour template;




        /// <summary>
        /// Default Constructor
        /// </summary>
        public POCreationDateVsConfirmationEntry()
        {
            // Create a new template object
            TemplateBlock = new TemplateFour();
            template = TemplateBlock as TemplateFour;

            Section = "Purch Sub";
            Name = "PO Creation Date vs Confirmation Entry";
        }






        #region IUnconfirmed Methods

        /// <summary>
        /// Calculated the percentage of unconfirmed records
        /// </summary>
        public void CalculatePercentUnconfirmed(int _unconfirmedTotal)
        {
            try
            {
                PercentUnconfirmed = Math.Round(((double)_unconfirmedTotal / template.TotalRecords) * 100, 2);
                if (double.IsNaN(PercentUnconfirmed))
                    PercentUnconfirmed = 0;

                if (double.IsInfinity(PercentUnconfirmed))
                    PercentUnconfirmed = 100;
            }
            catch (DivideByZeroException)
            {
                PercentUnconfirmed = 0;
            }
        }

        #endregion





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

                    string[] strFirstConfCreateDate = (dr["1st Conf Creation Da"].ToString()).Split('/');
                    int poLineFirstConfCreateYear = int.Parse(strFirstConfCreateDate[2]);
                    int poLineFirstConfCreateMonth = int.Parse(strFirstConfCreateDate[0]);
                    int poLineFirstConfCreateDay = int.Parse(strFirstConfCreateDate[1]);

                    if (poLineFirstConfCreateYear == 0 && poLineFirstConfCreateMonth == 0 && poLineFirstConfCreateDay == 0)
                    {
                        UnconfirmedTotal++;
                        template.TotalRecords++;
                        continue;
                    }
                    else
                    {
                        poLineFirstConfCreateYear = int.Parse(strFirstConfCreateDate[2]);
                        poLineFirstConfCreateMonth = int.Parse(strFirstConfCreateDate[0]);
                        poLineFirstConfCreateDay = int.Parse(strFirstConfCreateDate[1]);
                    }


                    DateTime initialConfCreateDate = new DateTime(poLineFirstConfCreateYear, poLineFirstConfCreateMonth, poLineFirstConfCreateDay);

                    string[] strPOLineCreateDt = (dr["PO Line Creat#DT"].ToString()).Split('/');
                    int poLineCreateYear = int.Parse(strPOLineCreateDt[2]);
                    int poLineCreateMonth = int.Parse(strPOLineCreateDt[0].TrimStart('0'));
                    int poLineCreateDay = int.Parse(strPOLineCreateDt[1].TrimStart('0'));

                    DateTime poLineItemCreateDate = new DateTime(poLineCreateYear, poLineCreateMonth, poLineCreateDay);

                    double elapsedDays = (initialConfCreateDate - poLineItemCreateDate).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;

                    // Apply the elapsed days against the time span conditions
                    template.TimeSpanDump(elapsedDays);
                }


                // Calculate the average for this KPI
                template.CalculateAverage(totalDays);

                // Calculate the percent unconfirmed for this KPI
                CalculatePercentUnconfirmed(UnconfirmedTotal);
            }
            catch (Exception)
            {
                MessageBox.Show("An argument out of range exception was thrown", "KPI - Purch Sub -> PO Creation vs Confirmation Entry - Overall Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}
