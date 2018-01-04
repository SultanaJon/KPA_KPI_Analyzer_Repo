

using DataAccessLibrary;
using Filters;
using Reporting.Selective;
using System;
using System.Data;

namespace Reporting.KeyPerformanceActions.HotJobs
{
    public sealed class PRsNotOnPO : KeyPerformanceAction
    {
        /// <summary>
        /// The Selective Strategy Context that holds the selective data for reporting
        /// </summary>
        private SelectiveStrategyContext selectiveContext;




        /// <summary>
        /// Property to return the selective data for this KPA
        /// </summary>
        public SelectiveStrategyContext SelectiveContext
        {
            get
            {
                return selectiveContext;
            }
            private set
            {
                if (value != null)
                {
                    this.selectiveContext = value;
                }
            }
        }


        /// <summary>
        /// Default Constructor
        /// </summary>
        public PRsNotOnPO()
        {
            Section = "Hot Jobs";
            Name = "PRs (Not on PO)";

            // set the selective strategy context
            SelectiveContext = new SelectiveStrategyContext(new SelectiveDataTypeOne());
        }


        /// <summary>
        /// Calculates the selective report for this KPA
        /// </summary>
        public override void RunSelectiveReport(string uniqueFilters)
        {
            // Get the instance of the selective data for reporting
            SelectiveDataTypeOne data = SelectiveContext.Data as SelectiveDataTypeOne;

            // Get the data from the database for this KPA
            DataTable dt = KpaUtils.HotJobsQueries.GetPrsNotOnPo();

            // used for calculating the average
            double totalDays = 0;

            foreach (DataRow dr in dt.Rows)
            {
                //Check if the datarow meets the conditions of any applied filters.
                if (!FilterUtils.EvaluateAgainstFilters(dr))
                {
                    // This datarow dos not meet the conditions of the filters applied.
                    continue;
                }

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

                // Find the difference between today's date and the date the PR was fully released
                DateTime prFullyRelDt = new DateTime(prFullyRelYear, prFullyRelMonth, prFullyRelDay);
                DateTime today = DateTime.Now.Date;
                double elapsedDays = (today - prFullyRelDt).TotalDays;
                totalDays += elapsedDays;
                elapsedDays = (int)elapsedDays;

                // Increment the total for this selective report
                data.TotalRecords++;
            }

            // Calculate the average for this report
            data.CalculateAverage(totalDays);
        }



        /// <summary>
        /// Calculates the overall report for this KPA
        /// </summary>
        public override void RunOverallReport()
        {

        }
    }
}
