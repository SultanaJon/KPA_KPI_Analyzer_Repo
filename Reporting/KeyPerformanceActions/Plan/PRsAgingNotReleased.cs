using System;
using System.Data;
using DataAccessLibrary;
using Filters;
using Reporting.Selective;
using Reporting.Overall.TemplateOne;
using Reporting.Overall;

namespace Reporting.KeyPerformanceActions.Plan
{
    public sealed class PRsAgingNotReleased : KeyPerformanceAction
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
                if(value != null)
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
            private set
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
        public PRsAgingNotReleased()
        {
            Section = "Plan";
            Name = "PRs Aging (Not Released)";

            // set the selective strategy context
            SelectiveContext = new SelectiveStrategyContext(new SelectiveDataTypeOne());

            // Create a new instance of the overall data packet
            overallDataPacket = new TemplateOnePacket();
        }



        /// <summary>
        /// Calcualte the selective report for this KPA
        /// </summary>
        /// <param name="uniqueFilter">the filter being applied against the selective report</param>
        public override void RunSelectiveReport(string uniqueFilter)
        {
            // Get the instance of the selective data for reporting
            SelectiveDataTypeOne data = SelectiveContext.Data as SelectiveDataTypeOne;

            // Get the data from the database for this KPA
            DataTable dt = KpaUtils.PlanQueries.GetPrsAgingNotReleased();
            
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

                // Get the requtiion date in this data row.
                string[] reqCreationDate = (dr["Requisn Date"].ToString()).Split('/');
                int year = int.Parse(reqCreationDate[2]);
                int month = int.Parse(reqCreationDate[0].TrimStart('0'));
                int day = int.Parse(reqCreationDate[1].TrimStart('0'));

                DateTime reqDate = new DateTime(year, month, day);
                DateTime today = DateTime.Now.Date;

                // Get the difference between todays date and the date the requisition was created
                double elapsedDays = (today - reqDate).TotalDays;
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
