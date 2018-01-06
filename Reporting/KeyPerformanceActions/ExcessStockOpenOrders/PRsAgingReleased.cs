


using DataAccessLibrary;
using Filters;
using Reporting.Overall;
using Reporting.Overall.TemplateOne;
using Reporting.Selective;
using System;
using System.Data;

namespace Reporting.KeyPerformanceActions.ExcessStockOpenOrders
{
    public sealed class PRsAgingReleased : KeyPerformanceAction
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
        /// The overall data that holds the overall reporting data
        /// </summary>
        private OverallDataPacket overallDataPacket;




        /// <summary>
        /// Propert to return the overall data for this KPA
        /// </summary>
        public TemplateOnePacket OverallPacket
        {
            get
            {
                // Return the overall data packet as a template one packet
                return overallDataPacket as TemplateOnePacket;
            }
            set
            {
                if (value != null)
                {
                    this.overallDataPacket = value;
                }
            }
        }





        /// <summary>
        /// Default Constructor
        /// </summary>
        public PRsAgingReleased()
        {
            Section = "Excess Stock - Open Orders";
            Name = "PRs Aging (Released)";

            // set the selective strategy context
            SelectiveContext = new SelectiveStrategyContext(new SelectiveDataTypeOne());

            // Create a new instance of the overall data packet
            overallDataPacket = new TemplateOnePacket();
        }




        /// <summary>
        /// Returns the number of elapsed days based on certain conditions for this KPA
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private double GetElapsedDays(DateTime _todaysDate, DateTime _prFullReleaseDate)
        {
            // Find the difference between today's date and the date the PR was fully released
            double elapsedDays = (_todaysDate - _prFullReleaseDate).TotalDays;
            elapsedDays = (int)elapsedDays;

            // Return the calculated elapsed days
            return elapsedDays;
        }




        /// <summary>
        /// Calculates the selective report for this KPA
        /// </summary>
        public override void RunSelectiveReport(string uniqueFilters)
        {
            // Get the instance of the selective data for reporting
            SelectiveDataTypeOne data = SelectiveContext.Data as SelectiveDataTypeOne;

            // Get the data from the database for this KPA
            DataTable dt = KpaUtils.ExcessStockOpenOrdersQueries.GetPrsAgingReleased();

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

                // Find the difference between today's date the date the PR was fully released
                DateTime prFullyRelDt = new DateTime(prFullyRelYear, prFullyRelMonth, prFullyRelDay);
                DateTime today = DateTime.Now.Date;


                // Add the elapsed days to the total number of days
                totalDays += GetElapsedDays(today, prFullyRelDt);

                // increment the total number of records for this selective KPA
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
            // Get the data from the database for this KPA
            DataTable dt = KpaUtils.ExcessStockOpenOrdersQueries.GetPrsAgingReleased();

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

                // create date time objects for both today and the pr full release date.
                DateTime prFullyRelDt = new DateTime(prFullyRelYear, prFullyRelMonth, prFullyRelDay);
                DateTime today = DateTime.Now.Date;


                // Get the elapsed days for this KPA
                double elapsedDays = GetElapsedDays(today, prFullyRelDt);

                // Increment the total number of days
                totalDays += elapsedDays;

                // Run the elapsed days against the timespan conditions
                overallDataPacket.TimeSpanDump(elapsedDays);
            }

            // Calculate the average number of days
            OverallPacket.CalculateAverage(totalDays);
        }
    }
}
