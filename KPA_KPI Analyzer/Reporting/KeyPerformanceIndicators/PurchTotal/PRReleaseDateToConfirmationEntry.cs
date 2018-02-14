using DataAccessLibrary;
using Filters;
using Reporting.Interfaces;
using Reporting.TimeSpans.Templates;
using System;
using System.Data;
using System.Windows.Forms;

namespace Reporting.KeyPerformanceIndicators.PurchTotal
{
    public sealed class PRReleaseDateToConfirmationEntry : KeyPerformanceIndicator, IUnconfirmed
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
        public PRReleaseDateToConfirmationEntry()
        {
            // Create a new template object
            TemplateBlock = new TemplateFour();
            template = TemplateBlock as TemplateFour;

            Section = "Purch Total";
            Name = "PR Release Date to Confirmation Entry";
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
        /// Runs the comparison report against the supplied filter
        /// </summary>
        /// <param name="_fitler">The filter we want to run against this KPA</param>
        /// <param name="_option">The filter option where this fitler was obtained</param>
        public override void RunComparison(string _filter, FilterOptions.Options _filterOption)
        {
            double totalDays = 0;

            try
            {
                // Remove any apostrophe's from the filter or an exception will be thrown
                CleanFilter(ref _filter);

                // Get the filtered data rows from the datatable
                DataRow[] filteredResult = DatabaseManager.prsOnPOsDt.Select(FilterOptions.GetColumnNames(_filterOption, _filter));

                foreach (DataRow dr in filteredResult)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }

                    string[] strfirstConfCreateDt = (dr["1st Conf Creation Da"].ToString()).Split('/');
                    int firstConfCreateYear = int.Parse(strfirstConfCreateDt[2]);
                    int firstConfCreateMonth = int.Parse(strfirstConfCreateDt[0]);
                    int firstConfCreateDay = int.Parse(strfirstConfCreateDt[1]);

                    if (firstConfCreateYear == 0 && firstConfCreateMonth == 0 & firstConfCreateDay == 0)
                    {
                        UnconfirmedTotal++;
                        template.TotalRecords++;
                        continue;
                    }
                    else
                    {
                        firstConfCreateYear = int.Parse(strfirstConfCreateDt[2]);
                        firstConfCreateMonth = int.Parse(strfirstConfCreateDt[0].TrimStart('0'));
                        firstConfCreateDay = int.Parse(strfirstConfCreateDt[1].TrimStart('0'));
                    }

                    DateTime poLineConfCreateDate = new DateTime(firstConfCreateYear, firstConfCreateMonth, firstConfCreateDay);

                    #region EVASO_BUT_NOT_FULLY_RELEASED_CHECK

                    string[] strPrFullyRelDate = (dr["PR Fully Rel Date"].ToString()).Split('/');
                    int prFullyRelYear = int.Parse(strPrFullyRelDate[2]);
                    int prFullyRelMonth = int.Parse(strPrFullyRelDate[0]);
                    int prFullyRelDay = int.Parse(strPrFullyRelDate[1]);


                    if (prFullyRelYear == 0 && prFullyRelMonth == 0 && prFullyRelDay == 0)
                    {
                        // This PR line or PR in general might have been delted
                        continue;
                    }


                    #endregion


                    DateTime prFullyRelDt = new DateTime(prFullyRelYear, prFullyRelMonth, prFullyRelDay);
                    double elapsedDays = (poLineConfCreateDate - prFullyRelDt).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;


                    // Apply the elapsed days against the time span conditions
                    template.TimeSpanDump(elapsedDays);

                }

                // Calculate the percent uncofirmed for this KPI
                CalculatePercentUnconfirmed(UnconfirmedTotal);

                // Calculate the average for this KPI
                template.CalculateAverage(totalDays);
            }
            catch (Exception)
            {
                MessageBox.Show("An argument out of range exception was thrown", "KPI - Purch Total -> PR Release to Confirmed Entry Date - Comparison Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
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

                    string[] strfirstConfCreateDt = (dr["1st Conf Creation Da"].ToString()).Split('/');
                    int firstConfCreateYear = int.Parse(strfirstConfCreateDt[2]);
                    int firstConfCreateMonth = int.Parse(strfirstConfCreateDt[0]);
                    int firstConfCreateDay = int.Parse(strfirstConfCreateDt[1]);

                    if (firstConfCreateYear == 0 && firstConfCreateMonth == 0 & firstConfCreateDay == 0)
                    {
                        UnconfirmedTotal++;
                        template.TotalRecords++;
                        continue;
                    }
                    else
                    {
                        firstConfCreateYear = int.Parse(strfirstConfCreateDt[2]);
                        firstConfCreateMonth = int.Parse(strfirstConfCreateDt[0].TrimStart('0'));
                        firstConfCreateDay = int.Parse(strfirstConfCreateDt[1].TrimStart('0'));
                    }

                    DateTime poLineConfCreateDate = new DateTime(firstConfCreateYear, firstConfCreateMonth, firstConfCreateDay);

                    #region EVASO_BUT_NOT_FULLY_RELEASED_CHECK

                    string[] strPrFullyRelDate = (dr["PR Fully Rel Date"].ToString()).Split('/');
                    int prFullyRelYear = int.Parse(strPrFullyRelDate[2]);
                    int prFullyRelMonth = int.Parse(strPrFullyRelDate[0]);
                    int prFullyRelDay = int.Parse(strPrFullyRelDate[1]);


                    if (prFullyRelYear == 0 && prFullyRelMonth == 0 && prFullyRelDay == 0)
                    {
                        // This PR line or PR in general might have been delted
                        continue;
                    }


                    #endregion


                    DateTime prFullyRelDt = new DateTime(prFullyRelYear, prFullyRelMonth, prFullyRelDay);
                    double elapsedDays = (poLineConfCreateDate - prFullyRelDt).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;


                    // Apply the elapsed days against the time span conditions
                    template.TimeSpanDump(elapsedDays);

                }

                // Calculate the percent uncofirmed for this KPI
                CalculatePercentUnconfirmed(UnconfirmedTotal);

                // Calculate the average for this KPI
                template.CalculateAverage(totalDays);
            }
            catch (Exception)
            {
                MessageBox.Show("An argument out of range exception was thrown", "KPI - Purch Total -> PR Release to Confirmed Entry Date - Overall Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}
