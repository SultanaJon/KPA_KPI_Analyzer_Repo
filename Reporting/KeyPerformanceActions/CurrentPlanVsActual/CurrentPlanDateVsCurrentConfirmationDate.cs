using DataAccessLibrary;
using Filters;
using Reporting.Overall;
using Reporting.Overall.TemplateOne;
using Reporting.Overall.TemplateTwo;
using Reporting.Selective;
using System;
using System.Data;

namespace Reporting.KeyPerformanceActions.CurrentPlanVsActual
{
    public sealed class CurrentPlanDateVsCurrentConfirmationDate : KeyPerformanceAction
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
        public TemplateTwoPacket OverallPacket
        {
            get
            {
                // Return the overall data packet as a template one packet
                return overallDataPacket as TemplateTwoPacket;
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
        public CurrentPlanDateVsCurrentConfirmationDate()
        {
            Section = "Current Plan vs Actual";
            Name = "Current Plan Date vs Current Confirmation Date";

            // set the selective strategy context
            SelectiveContext = new SelectiveStrategyContext(new SelectiveDataTypeThree());

            // Create a new instance of the overall data packet
            overallDataPacket = new TemplateTwoPacket();
        }




        /// <summary>
        /// Returns the number of elapsed days based on certain conditions for this KPA
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private double GetElapsedDays(DataRow dr)
        {
            // Get the latest confirmation date from the data row
            string[] strDate = (dr["Latest Conf#Dt"].ToString()).Split('/');
            int year = int.Parse(strDate[2]);
            int month = int.Parse(strDate[0].TrimStart('0'));
            int day = int.Parse(strDate[1].TrimStart('0'));

            // Get the rescheduling date
            string[] strCurrPlanDate = (dr["Rescheduling date"].ToString()).Split('/');
            int currConfYear = int.Parse(strCurrPlanDate[2]);
            int currConfMonth = int.Parse(strCurrPlanDate[0]);
            int currConfDay = int.Parse(strCurrPlanDate[1]);

            // if the reschedule date is 00/00/0000 get the PO delivery date
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

            // Find the difference between the latest confirmation date and the current plan date
            DateTime latestConfDate = new DateTime(year, month, day);
            DateTime currPlanDate = new DateTime(currConfYear, currConfMonth, currConfDay);
            double elapsedDays = (latestConfDate - currPlanDate).TotalDays;

            // Our time spans are in weeks but we want to catch the average amount of days.
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
            SelectiveDataTypeThree data = SelectiveContext.Data as SelectiveDataTypeThree;

            // Get the data from the database for this KPA
            DataTable dt = KpaUtils.CurrentPlanVsActualQueries.GetCurrentPlanDateVsCurrentConfirmationDate();

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

                // Add the elapsed days to the total number of days
                totalDays += GetElapsedDays(dr);

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
            DataTable dt = KpaUtils.CurrentPlanVsActualQueries.GetCurrentPlanDateVsCurrentConfirmationDate();

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

                // Get the elapsed days for this KPA
                double elapsedDays = GetElapsedDays(dr);

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
