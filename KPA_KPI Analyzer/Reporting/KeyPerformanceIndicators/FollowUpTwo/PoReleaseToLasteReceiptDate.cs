using DataAccessLibrary;
using Filters;
using Reporting.Interfaces;
using Reporting.KeyPerformanceIndicators;
using Reporting.TimeSpans.Templates;
using System;
using System.Data;
using System.Windows.Forms;

namespace Reporting.KeyPerformanceIndicators.FollowUpTwo
{
    public sealed class PoReleaseToLasteReceiptDate : KeyPerformanceIndicator, IUnconfirmed
    {
        /// <summary>
        /// Interface to access the template data.
        /// </summary>
        TemplateFour template;




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
        /// Default Constructor
        /// </summary>
        public PoReleaseToLasteReceiptDate()
        {
            TemplateBlock = new TemplateFour();
            template = TemplateBlock as TemplateFour;

            Section = "Follow Up II";
            Name = "Release Date to Last Receipt Date";
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
                // Remove any apostraphe's from the filter or an exception will be thrown
                CleanFilter(ref _filter);

                // Get the fitlered data rows from the datatable
                DataRow[] filteredResult = DatabaseManager.posRecCompDt.Select(FilterOptions.GetSelectStatement(_filterOption, _filter));

                foreach (DataRow dr in filteredResult)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }


                    #region EVASO_BUT_NO_REC_DATE_CHECK

                    string[] strLastPORecDate = (dr["Last PO Rec#Date"].ToString()).Split('/');
                    int lastPORecDtYear = int.Parse(strLastPORecDate[2]);
                    int lastPORecDtMonth = int.Parse(strLastPORecDate[0]);
                    int lastPORecDtDay = int.Parse(strLastPORecDate[1]);


                    if (lastPORecDtYear == 0 && lastPORecDtMonth == 0 && lastPORecDtDay == 0)
                    {
                        // this po line or po in general may have been deleted.
                        continue;
                    }

                    #endregion


                    string[] strDate = (dr["PO Line 1st Rel Dt"].ToString()).Split('/');
                    int poLine1stRelDateYear = int.Parse(strDate[2]);
                    int poLine1stRelDateMonth = int.Parse(strDate[0]);
                    int poLine1stRelDateDay = int.Parse(strDate[1]);

                    if (poLine1stRelDateYear == 0 && poLine1stRelDateMonth == 0 && poLine1stRelDateDay == 0)
                    {
                        // this po line or po in general may have been deleted.
                        continue;
                    }




                    string[] strPOLineFirstConfCreateDate = (dr["1st Conf Creation Da"].ToString()).Split('/');
                    int poLineFirstConfCreateYear = int.Parse(strPOLineFirstConfCreateDate[2]);
                    int poLineFirstConfCreateMonth = int.Parse(strPOLineFirstConfCreateDate[0]);
                    int poLineFirstConfCreateDay = int.Parse(strPOLineFirstConfCreateDate[1]);


                    if (poLineFirstConfCreateYear == 0 && poLineFirstConfCreateMonth == 0 && poLineFirstConfCreateDay == 0)
                    {
                        UnconfirmedTotal++;
                        template.TotalRecords++;
                        continue;
                    }

                    DateTime lastPORecDate = new DateTime(lastPORecDtYear, lastPORecDtMonth, lastPORecDtDay);
                    DateTime firstRelDate = new DateTime(poLine1stRelDateYear, poLine1stRelDateMonth, poLine1stRelDateDay);

                    double elapsedDays = (lastPORecDate - firstRelDate).TotalDays;
                    totalDays += elapsedDays;

                    // Apply the elpased days against the time span conditions
                    template.TimeSpanDump(elapsedDays);
                }

                // Calculate the average for this KPI
                template.CalculateAverage(totalDays);

                // Calcualte the percent unconfrimed for this KPI
                CalculatePercentUnconfirmed(UnconfirmedTotal);
            }
            catch (Exception)
            {
                MessageBox.Show("An argument out of range exception was thrown", "Follow Up II -> PO Release Date to Last PO Receipt Date - Comparison Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                foreach (DataRow dr in DatabaseManager.posRecCompDt.Rows)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }


                    #region EVASO_BUT_NO_REC_DATE_CHECK

                    string[] strLastPORecDate = (dr["Last PO Rec#Date"].ToString()).Split('/');
                    int lastPORecDtYear = int.Parse(strLastPORecDate[2]);
                    int lastPORecDtMonth = int.Parse(strLastPORecDate[0]);
                    int lastPORecDtDay = int.Parse(strLastPORecDate[1]);


                    if (lastPORecDtYear == 0 && lastPORecDtMonth == 0 && lastPORecDtDay == 0)
                    {
                        // this po line or po in general may have been deleted.
                        continue;
                    }

                    #endregion


                    string[] strDate = (dr["PO Line 1st Rel Dt"].ToString()).Split('/');
                    int poLine1stRelDateYear = int.Parse(strDate[2]);
                    int poLine1stRelDateMonth = int.Parse(strDate[0]);
                    int poLine1stRelDateDay = int.Parse(strDate[1]);

                    if (poLine1stRelDateYear == 0 && poLine1stRelDateMonth == 0 && poLine1stRelDateDay == 0)
                    {
                        // this po line or po in general may have been deleted.
                        continue;
                    }




                    string[] strPOLineFirstConfCreateDate = (dr["1st Conf Creation Da"].ToString()).Split('/');
                    int poLineFirstConfCreateYear = int.Parse(strPOLineFirstConfCreateDate[2]);
                    int poLineFirstConfCreateMonth = int.Parse(strPOLineFirstConfCreateDate[0]);
                    int poLineFirstConfCreateDay = int.Parse(strPOLineFirstConfCreateDate[1]);


                    if (poLineFirstConfCreateYear == 0 && poLineFirstConfCreateMonth == 0 && poLineFirstConfCreateDay == 0)
                    {
                        UnconfirmedTotal++;
                        template.TotalRecords++;
                        continue;
                    }


                    DateTime lastPORecDate = new DateTime(lastPORecDtYear, lastPORecDtMonth, lastPORecDtDay);
                    DateTime firstRelDate = new DateTime(poLine1stRelDateYear, poLine1stRelDateMonth, poLine1stRelDateDay);

                    double elapsedDays = (lastPORecDate - firstRelDate).TotalDays;
                    totalDays += elapsedDays;

                    // Apply the elpased days against the time span conditions
                    template.TimeSpanDump(elapsedDays);
                }

                // Calculate the average for this KPI
                template.CalculateAverage(totalDays);

                // Calcualte the percent unconfrimed for this KPI
                CalculatePercentUnconfirmed(UnconfirmedTotal);
            }
            catch (Exception)
            {
                MessageBox.Show("An argument out of range exception was thrown", "Follow Up II -> PO Release Date to Last PO Receipt Date - Overall Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}
