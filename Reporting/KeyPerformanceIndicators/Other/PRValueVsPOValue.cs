

using Reporting.Overall;


using Reporting.Selective;
using System.Data;

namespace Reporting.KeyPerformanceIndicators.Other
{
    public sealed class PRValueVsPOValue : KeyPerformanceIndicator, ITemplateFive
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
        public PRValueVsPOValue()
        {
            Section = "Other";
            Name = "PR Value vs PO Value";

            // set the selective strategy context
            SelectiveContext = new SelectiveStrategyContext(new SelectiveDataTypeOne());
        }







        /// <summary>
        /// Method to apply the elapsed days against the KPA or KPIs time span conditions
        /// </summary>
        public void TimeSpanDump(double _weeks, DataRow dr)
        {
            // Increment the total number of records that satisfy this KPI
            TotalRecords++;

            // Apply the number of weeks against the time span conditions
            if (_weeks >= 0)
            {
                GreaterThanEqualToZeroWeeks += (decimal.Parse(dr["PO Value"].ToString()) - decimal.Parse(dr["PR Pos#Value"].ToString()));
            }
            else if (_weeks >= (-1) && _weeks < 0)
            {
                GreaterThanEqualToNegOneWeek += (decimal.Parse(dr["PO Value"].ToString()) - decimal.Parse(dr["PR Pos#Value"].ToString()));
            }
            else if (_weeks >= (-2) && _weeks < (-1))
            {
                GreaterThanEqualToNegTwoWeeks += (decimal.Parse(dr["PO Value"].ToString()) - decimal.Parse(dr["PR Pos#Value"].ToString()));
            }
            else if (_weeks >= (-3) && _weeks < (-2))
            {
                GreaterThanEqualToNegThreeWeeks += (decimal.Parse(dr["PO Value"].ToString()) - decimal.Parse(dr["PR Pos#Value"].ToString()));
            }
            else if (_weeks >= (-4) && _weeks < (-3))
            {
                GreaterThanEqualToNegFourWeeks += (decimal.Parse(dr["PO Value"].ToString()) - decimal.Parse(dr["PR Pos#Value"].ToString()));
            }
            else if (_weeks >= (-5) && _weeks < (-4))
            {
                GreaterThanEqualToNegFiveWeeks += (decimal.Parse(dr["PO Value"].ToString()) - decimal.Parse(dr["PR Pos#Value"].ToString()));
            }
            else if (_weeks >= (-6) && _weeks < (-5))
            {
                GreaterThanEqualToNegSixWeeks += (decimal.Parse(dr["PO Value"].ToString()) - decimal.Parse(dr["PR Pos#Value"].ToString()));
            }
            else if (_weeks >= (-7) && _weeks < (-6))
            {
                GreaterThanEqualToNegSevenWeeks += (decimal.Parse(dr["PO Value"].ToString()) - decimal.Parse(dr["PR Pos#Value"].ToString()));
            }
            else if (_weeks >= (-8) && _weeks < (-7))
            {
                GreaterThanEqualToNegEightWeeks += (decimal.Parse(dr["PO Value"].ToString()) - decimal.Parse(dr["PR Pos#Value"].ToString()));
            }
            else if (_weeks < (-8))
            {
                LessThanNegEightWeeks += (decimal.Parse(dr["PO Value"].ToString()) - decimal.Parse(dr["PR Pos#Value"].ToString()));
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
