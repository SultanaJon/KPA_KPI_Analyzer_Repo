﻿

using DataAccessLibrary;
using Filters;
using Reporting.Overall;
using Reporting.Overall.TemplateOne;
using Reporting.Selective;
using System;
using System.Data;

namespace Reporting.KeyPerformanceActions.FollowUp
{
    public sealed class ConfirmedDateForUpcomingDeliveries : KeyPerformanceAction
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
        public ConfirmedDateForUpcomingDeliveries()
        {
            Section = "Follow Up";
            Name = "Confirmed Date for Upcoming Deliveries";

            // set the selective strategy context
            SelectiveContext = new SelectiveStrategyContext(new SelectiveDataTypeThree());

            // Create a new instance of the overall data packet
            overallDataPacket = new TemplateOnePacket();
        }




        /// <summary>
        /// Returns the number of elapsed days based on certain conditions for this KPA
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private double GetElapsedDays(DataRow dr)
        {
            // Get the latest confirmation date from the data row.
            string[] strDate = (dr["Latest Conf#Dt"].ToString()).Split('/');
            int year = int.Parse(strDate[2]);
            int month = int.Parse(strDate[0].TrimStart('0'));
            int day = int.Parse(strDate[1].TrimStart('0'));

            // Find the difference between the latest confirmation date and today.
            DateTime latestConfrimationDate = new DateTime(year, month, day);
            DateTime today = DateTime.Now.Date;
            double elapsedDays = (latestConfrimationDate - today).TotalDays;
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
            DataTable dt = KpaUtils.FollowUpQueries.GetConfrimedDateForUpcomingDeliveries();

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
            DataTable dt = KpaUtils.FollowUpQueries.GetConfrimedDateForUpcomingDeliveries();

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
