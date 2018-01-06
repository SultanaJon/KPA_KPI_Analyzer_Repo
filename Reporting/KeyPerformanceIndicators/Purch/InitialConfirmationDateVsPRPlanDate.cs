

using DataAccessLibrary;
using Filters;
using Reporting.Interfaces;
using Reporting.Overall;
using Reporting.Overall.TemplateThree;
using Reporting.Selective;
using System;
using System.Data;

namespace Reporting.KeyPerformanceIndicators.Purch
{
    public sealed class InitialConfirmationDateVsPRPlanDate : KeyPerformanceIndicator
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
        public TemplateThreePacket OverallPacket
        {
            get
            {
                // Return the overall data packet as a template three packet
                return overallDataPacket as TemplateThreePacket;
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
        public InitialConfirmationDateVsPRPlanDate()
        {
            Section = "Purch";
            Name = "Initial Confirmation Date vs PR Plan Date";

            // set the selective strategy context
            SelectiveContext = new SelectiveStrategyContext(new SelectiveDataTypeFour());

            // Create a new instance of the overall data packet
            overallDataPacket = new TemplateThreePacket();
        }



        /// <summary>
        /// Returns the number of elapsed days based on certain conditions for this KPA
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private double GetElapsedDays()
        {
            return 1;
        }




        /// <summary>
        /// Calculates the selective report for this KPA
        /// </summary>
        public override void RunSelectiveReport(string uniqueFilters)
        {

        }



        /// <summary>
        /// Calculates the overall report for this KPA
        /// </summary>
        public override void RunOverallReport()
        {

        }
    }
}
