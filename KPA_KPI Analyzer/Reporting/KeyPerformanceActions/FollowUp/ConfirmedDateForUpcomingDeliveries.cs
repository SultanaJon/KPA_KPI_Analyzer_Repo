

using DataAccessLibrary;
using Filters;
using Reporting.Interfaces;
using Reporting.TimeSpans.Templates;
using System;
using System.Data;
using System.Windows.Forms;

namespace Reporting.KeyPerformanceActions.FollowUp
{
    public sealed class ConfirmedDateForUpcomingDeliveries : KeyPerformanceAction, IFavorable
    {
        /// <summary>
        /// Template to access the data.
        /// </summary>
        TemplateOne template;






        #region IFavorable Properties

        /// <summary>
        /// The percent favorable for the KPA or KPI it is attached to.
        /// </summary>
        public double PercentFavorable { get; set; }

        #endregion



        /// <summary>
        /// Data from another KPA. Needed in this KPA to calculate percent favorable
        /// </summary>
        public int DueTodayLateToConfirmedLessThanZeroDueToday { get; set; }





        /// <summary>
        /// Default Constructor
        /// </summary>
        public ConfirmedDateForUpcomingDeliveries()
        {
            // Create a new template object
            TemplateBlock = new TemplateOne();
            template = TemplateBlock as TemplateOne;

            Section = "Follow Up";
            Name = "Confirmed Date for Upcoming Deliveries";
        }






        #region IFavorable Method

        /// <summary>
        /// Calculates the percent favorable for the specific KPA or KPI it is attached to
        /// </summary>
        public void CalculatePercentFavorable()
        {
            try
            {
                if (template.TotalRecords != 0)
                {
                    double favorableTimeSpanCounts = template.OneToThreeDays + template.FourToSevenDays + template.EightToFourteenDays + template.FifteenToTwentyOneDays
                        + template.TwentyTwoToTwentyEightDays + template.TwentyNinePlusDays;

                    double totalFavorable = favorableTimeSpanCounts + DueTodayLateToConfirmedLessThanZeroDueToday;

                    // calculate the Percent Favorable
                    PercentFavorable = Math.Round((totalFavorable / template.TotalRecords) * 100, 2);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An argument out of range exception was thrown", "Folow Up -> Confirmed Date for Upcoming Deliveries - Favorable Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
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
            try
            {
                DataTable dt = KpaUtils.FollowUpQueries.GetConfrimedDateForUpcomingDeliveries();
                double totalDays = 0;

                // remove any apostraphe's from the filter as an exception will be thrown.
                CleanFilter(ref _filter);

                // Get the fitlered data rows from the datatable
                DataRow[] filteredResult = dt.Select(FilterOptions.GetColumnNames(_filterOption, _filter));

                foreach (DataRow dr in filteredResult)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }

                    string[] strDate = (dr["Latest Conf#Dt"].ToString()).Split('/');
                    int year = int.Parse(strDate[2]);
                    int month = int.Parse(strDate[0].TrimStart('0'));
                    int day = int.Parse(strDate[1].TrimStart('0'));

                    DateTime date = new DateTime(year, month, day);
                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (date - today).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;

                    // Apply the elapsed days against the time spand conditions
                    template.TimeSpanDump(elapsedDays);
                }

                // Calculate the average for this KPA
                template.CalculateAverage(totalDays);

                // Calculate the favorable percentage for this KPA
                CalculatePercentFavorable();

                dt.Rows.Clear();
                dt = null;
                GC.Collect();
            }
            catch (Exception)
            {
                MessageBox.Show("An argument out of range exception was thrown", "Folow Up -> Due Today or Late to Confirmed - Overall Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }




        /// <summary>
        /// Calculates the overall report for this KPA
        /// </summary>
        public override void RunOverall()
        {
            try
            {
                DataTable dt = KpaUtils.FollowUpQueries.GetConfrimedDateForUpcomingDeliveries();
                double totalDays = 0;

                foreach (DataRow dr in dt.Rows)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }

                    string[] strDate = (dr["Latest Conf#Dt"].ToString()).Split('/');
                    int year = int.Parse(strDate[2]);
                    int month = int.Parse(strDate[0].TrimStart('0'));
                    int day = int.Parse(strDate[1].TrimStart('0'));

                    DateTime date = new DateTime(year, month, day);
                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (date - today).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;

                    // Apply the elapsed days against the time spand conditions
                    template.TimeSpanDump(elapsedDays);
                }

                // Calculate the average for this KPA
                template.CalculateAverage(totalDays);

                // Calculate the favorable percentage for this KPA
                CalculatePercentFavorable();

                dt.Rows.Clear();
                dt = null;
                GC.Collect();
            }
            catch (Exception)
            {
                MessageBox.Show("An argument out of range exception was thrown", "Folow Up -> Due Today or Late to Confirmed - Overall Run Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}
