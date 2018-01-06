

using Reporting.Overall;


using Reporting.Selective;

namespace Reporting.KeyPerformanceIndicators.Other
{
    public sealed class PRsReleased : KeyPerformanceIndicator, ITemplateFive
    {
        #region ITemplateFive Properties

        public decimal TotalValue { get; set; }
        public int TotalRecords { get; set; }
        public decimal GreaterThanEqualToZeroWeeks { get; set; }
        public decimal GreaterThanEqualToNegOneWeek { get; set; }
        public decimal GreaterThanEqualToNegTwoWeeks { get; set; }
        public decimal GreaterThanEqualToNegThreeWeeks { get; set; }
        public decimal GreaterThanEqualToNegFourWeeks { get; set; }
        public decimal GreaterThanEqualToNegFiveWeeks { get; set; }
        public decimal GreaterThanEqualToNegSixWeeks { get; set; }
        public decimal GreaterThanEqualToNegSevenWeeks { get; set; }
        public decimal GreaterThanEqualToNegEightWeeks { get; set; }
        public decimal LessThanNegEightWeeks { get; set; }

        #endregion



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
        public PRsReleased()
        {
            Section = "Other";
            Name = "PRs Released";

            // set the selective strategy context
            SelectiveContext = new SelectiveStrategyContext(new SelectiveDataTypeOne());
        }







        /// <summary>
        /// Method to apply the elapsed days against the KPA or KPIs time span conditions
        /// </summary>
        public void TimeSpanDump(double _weeks)
        {
            // Increment the total number of records that satisfy this KPI
            TotalRecords++;


            // Apply the elapsed days agaisnt the timespan conditions
            if (_weeks >= 0)
            {
                GreaterThanEqualToZeroWeeks++;
            }
            else if (_weeks >= (-1) && _weeks < 0)
            {
                GreaterThanEqualToNegOneWeek++;
            }
            else if (_weeks >= (-2) && _weeks < (-1))
            {
                GreaterThanEqualToNegTwoWeeks++;
            }
            else if (_weeks >= (-3) && _weeks < (-2))
            {
                GreaterThanEqualToNegThreeWeeks++;
            }
            else if (_weeks >= (-4) && _weeks < (-3))
            {
                GreaterThanEqualToNegFourWeeks++;
            }
            else if (_weeks >= (-5) && _weeks < (-4))
            {
                GreaterThanEqualToNegFiveWeeks++;
            }
            else if (_weeks >= (-6) && _weeks < (-5))
            {
                GreaterThanEqualToNegSixWeeks++;
            }
            else if (_weeks >= (-7) && _weeks < (-6))
            {
                GreaterThanEqualToNegSevenWeeks++;
            }
            else if (_weeks >= (-8) && _weeks < (-7))
            {
                GreaterThanEqualToNegEightWeeks++;
            }
            else if (_weeks < (-8))
            {
                LessThanNegEightWeeks++;
            }
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
