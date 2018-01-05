

using DataAccessLibrary;
using Filters;
using Reporting.Overall;
using Reporting.Overall.TemplateOne;
using Reporting.Selective;
using System;
using System.Data;

namespace Reporting.KeyPerformanceActions.ExcessStockOpenOrders
{
    public sealed class POCreationThruDelivery : KeyPerformanceAction
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
        public POCreationThruDelivery()
        {
            Section = "Excess Stock - Open Orders";
            Name = "PO Creation Thru Delivery";

            // set the selective strategy context
            SelectiveContext = new SelectiveStrategyContext(new SelectiveDataTypeOne());

            // Create a new instance of the overall data packet
            overallDataPacket = new TemplateOnePacket();
        }


        /// <summary>
        /// Calculates the selective report for this KPA
        /// </summary>
        public override void RunSelectiveReport(string uniqueFilters)
        {
            // Get the instance of the selective data for reporting
            SelectiveDataTypeOne data = SelectiveContext.Data as SelectiveDataTypeOne;

            // Get the data from the database for this KPA
            DataTable dt = KpaUtils.ExcessStockOpenOrdersQueries.GetPoCreationThruDelivery();

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

                // Get the PO line creation date from the data row
                string[] strDate = (dr["PO Line Creat#DT"].ToString()).Split('/');
                int year = int.Parse(strDate[2]);
                int month = int.Parse(strDate[0].TrimStart('0'));
                int day = int.Parse(strDate[1].TrimStart('0'));


                // Find the difference between today's date the the PO line creation date.
                DateTime date = new DateTime(year, month, day);
                DateTime today = DateTime.Now.Date;
                double elapsedDays = (today - date).TotalDays;
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
