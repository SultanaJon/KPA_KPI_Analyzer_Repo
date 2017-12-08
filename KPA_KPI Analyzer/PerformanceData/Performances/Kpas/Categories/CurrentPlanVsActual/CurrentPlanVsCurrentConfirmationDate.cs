using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KPA_KPI_Analyzer.PerformanceData.Packages;
using KPA_KPI_Analyzer.PerformanceData.Interfaces;
using System.Data;
using System.Data.OleDb;
using KPA_KPI_Analyzer.Database;

namespace KPA_KPI_Analyzer.PerformanceData.Performances.Kpas.Categories.CurrentPlanVsActual
{
    public class CurrentPlanVsCurrentConfirmationDate : TemplateTwoPackage, ICalculateFavorable
    {
        private double totalDays = 0;
        private DataTable dt;
        private OleDbCommand cmd;
        private OleDbDataAdapter da;

        /// <summary>
        /// The percent of favorable records.
        /// </summary>
        public double PercentFavorable { get; set; }


        /// <summary>
        /// Calculates the Percent of favorable records.
        /// </summary>
        public void CalculatePercentFavorable()
        {
            if (Total != 0)
            {
                double favorableTimeSpanCounts = LessThanNegThreeWeeks + GreaterThanEqualNegThreeWeeks + GreaterThanEqualNegTwoWeeks + GreaterThanEqualNegOneWeek + ZeroWeeks;

                // calculate the Percent Favorable
                PercentFavorable = Math.Round((favorableTimeSpanCounts / this.Total) * 100, 2);
            }
        }



        /// <summary>
        /// Loads the data for this specific KPA
        /// </summary>
        public void Load()
        {
            dt = new DataTable();
            cmd = new OleDbCommand(QueryManager.KpaQueries.CurrentPlanVsActualQueries.GetCurrentPlanDateVsCurrentConfirmationDate() + Filters.FilterData.FilterQuery, DatabaseUtils.DatabaseConnection);
            da = new OleDbDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                //Check if the datarow meets the conditions of any applied filters.
                if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                {
                    // This datarow dos not meet the conditions of the filters applied.
                    continue;
                }

                string[] strDate = (dr["Del#Conf#Date"].ToString()).Split('/');
                int year = int.Parse(strDate[2]);
                int month = int.Parse(strDate[0].TrimStart('0'));
                int day = int.Parse(strDate[1].TrimStart('0'));

                DateTime confDate = new DateTime(year, month, day);


                string[] strCurrPlanDate = (dr["Rescheduling date"].ToString()).Split('/');
                int currConfYear = int.Parse(strCurrPlanDate[2]);
                int currConfMonth = int.Parse(strCurrPlanDate[0]);
                int currConfDay = int.Parse(strCurrPlanDate[1]);

                if (currConfYear == 0 && currConfMonth == 0 && currConfDay == 0)
                {
                    string[] strNewCurrConfDate = (dr["Delivery Date"].ToString()).Split('/');
                    currConfYear = int.Parse(strNewCurrConfDate[2]);
                    currConfMonth = int.Parse(strNewCurrConfDate[0].TrimStart('0'));
                    currConfDay = int.Parse(strNewCurrConfDate[1].TrimStart('0'));
                }
                else
                {
                    currConfYear = int.Parse(strCurrPlanDate[2]);
                    currConfMonth = int.Parse(strCurrPlanDate[0].TrimStart('0'));
                    currConfDay = int.Parse(strCurrPlanDate[1].TrimStart('0'));
                }

                DateTime currPlanDate = new DateTime(currConfYear, currConfMonth, currConfDay);
                double elapsedDays = (confDate - currPlanDate).TotalDays;

                // Our time spans are in weeks but we want to catch the average amount of days.
                totalDays += elapsedDays;
                elapsedDays = (int)elapsedDays;

                int weeks = 0;
                if (elapsedDays < 0)
                    weeks = (int)Math.Floor(elapsedDays / 7);
                else if (elapsedDays == 0)
                    weeks = 0;
                else // elapsed days > 0
                    weeks = (int)Math.Ceiling(elapsedDays / 7);

                Total++;

                // Apply to timespans.
                TimeSpanFilter(weeks);
            }

            try
            {
                Average = Math.Round(totalDays / Total, 2);
                if (double.IsNaN(Average))
                    Average = 0;
            }
            catch (DivideByZeroException)
            {
                Average = 0;
            }

            // Calculate the percent favorable for this KPI
            CalculatePercentFavorable();

            totalDays = 0;
        }
    }
}
