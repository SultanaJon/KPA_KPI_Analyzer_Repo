using DataAccessLibrary;
using Reporting.Interfaces;
using Reporting.TimeSpans.Templates;
using System;
using System.Data;
using System.Windows.Forms;

namespace Reporting.KeyPerformanceIndicators.FollowUp
{
    public sealed class ReceiptDateVsCurrentConfirmationDate : KeyPerformanceIndicator, IUnconfirmed, IFavorable
    {
        /// <summary>
        /// Interface to access the template data.
        /// </summary>
        TemplateThree template;


        #region IFavorable Properties

        /// <summary>
        /// The percent favorable for the KPA or KPI it is attached to.
        /// </summary>
        public double PercentFavorable { get; set; }

        #endregion




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
        public ReceiptDateVsCurrentConfirmationDate()
        {
            // Create a new template object
            TemplateBlock = new TemplateThree();
            template = TemplateBlock as TemplateThree;

            Section = "Follow Up";
            Name = "Receipt Date vs Current Confirmation Date";
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





        #region IFavorable Method

        /// <summary>
        /// Calculates the percent favorable for the specific KPA or KPI it is attached to
        /// </summary>
        public void CalculatePercentFavorable()
        {
            if (template.TotalRecords != 0)
            {
                // Sum up the favorable time spans
                double favorableTimeSpans = template.LessThanEqualToNegTwentyTwoDays + template.NegTwentyOneToNegFifteenDays + template.NegFourteenToNegEightDays + template.NegSevenToNegOneDays + template.ZeroDays;

                // calculate the Percent Favorable
                PercentFavorable = Math.Round((favorableTimeSpans / template.TotalRecords) * 100, 2);
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
                foreach (DataRow dr in DatabaseManager.posRecCompDt.Rows)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
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


                    DateTime lastPORecDate = new DateTime(lastPORecDtYear, lastPORecDtMonth, lastPORecDtDay);

                    string[] strCurrConfDate = (dr["Latest Conf#Dt"].ToString()).Split('/');
                    int currConfYear = int.Parse(strCurrConfDate[2]);
                    int currConfMonth = int.Parse(strCurrConfDate[0]);
                    int currConfDay = int.Parse(strCurrConfDate[1]);

                    if (currConfYear == 0 && currConfMonth == 0 && currConfDay == 0)
                    {
                        UnconfirmedTotal++;
                        template.TotalRecords++;
                        continue;
                    }
                    else
                    {
                        currConfYear = int.Parse(strCurrConfDate[2]);
                        currConfMonth = int.Parse(strCurrConfDate[0].TrimStart('0'));
                        currConfDay = int.Parse(strCurrConfDate[1].TrimStart('0'));
                    }

                    DateTime currConfDate = new DateTime(currConfYear, currConfMonth, currConfDay);
                    double elapsedDays = (lastPORecDate - currConfDate).TotalDays;
                    totalDays += elapsedDays;

                    // Apply the elpased days against the time span conditions
                    template.TimeSpanDump(elapsedDays);
                }


                // Caclualte the percent unconfirmed
                CalculatePercentUnconfirmed(UnconfirmedTotal);


                // Calculate the average for this KPI
                template.CalculateAverage(totalDays);

                // Calculate percent favorable
                CalculatePercentFavorable();
            }
            catch (Exception)
            {
                MessageBox.Show("An argument out of range exception was thrown", "Follow Up -> Receipt Date vs Current Confirmation Date - Overall Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}
