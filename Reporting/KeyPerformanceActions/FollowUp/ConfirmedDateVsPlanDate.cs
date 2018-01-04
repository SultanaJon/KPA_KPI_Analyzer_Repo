

using DataAccessLibrary;
using Filters;
using Reporting.Overall;
using Reporting.Overall.TemplateOne;
using Reporting.Selective;
using System;
using System.Data;

namespace Reporting.KeyPerformanceActions.FollowUp
{
    public sealed class ConfirmedDateVsPlanDate : KeyPerformanceAction
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
        public ConfirmedDateVsPlanDate()
        {
            Section = "Follow Up";
            Name = "Confirmed Date Vs Plan Date";

            // set the selective strategy context
            SelectiveContext = new SelectiveStrategyContext(new SelectiveDataTypeThree());
        }


        /// <summary>
        /// Calculates the selective report for this KPA
        /// </summary>
        public override void RunSelectiveReport(string uniqueFilters)
        {
            // Get the instance of the selective data for reporting
            SelectiveDataTypeThree data = SelectiveContext.Data as SelectiveDataTypeThree;

            // Get the data from the database for this KPA
            DataTable dt = KpaUtils.FollowUpQueries.GetConfirmedDateVsPlanDate();

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


                // Get the latest confirmation date from the data row.
                string[] strCurrConfDate = (dr["Latest Conf#Dt"].ToString()).Split('/');
                int delConfYear = int.Parse(strCurrConfDate[2]);
                int delConfMonth = int.Parse(strCurrConfDate[0].TrimStart('0'));
                int delConfDay = int.Parse(strCurrConfDate[1].TrimStart('0'));

                DateTime delConfDate = new DateTime(delConfYear, delConfMonth, delConfDay);


                // Get the resecheduling date from the data row.
                string[] strCurrPlanDate = (dr["Rescheduling date"].ToString()).Split('/');
                int currConfYear = int.Parse(strCurrPlanDate[2]);
                int currConfMonth = int.Parse(strCurrPlanDate[0]);
                int currConfDay = int.Parse(strCurrPlanDate[1]);

                // If the rescheduling date is 00/00/0000, get the delivery confirmation date
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

                // Find the difference between the delivery confirmation date and the current plan date (rescheduling date)
                DateTime currPlanDate = new DateTime(currConfYear, currConfMonth, currConfDay);
                double elapsedDays = (delConfDate - currPlanDate).TotalDays;
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
