using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KPA_KPI_Analyzer.Interfaces;

namespace KPA_KPI_Analyzer.Data.Kpa.Sections.Categories.CurrentPlanVsActual
{
    public class CurrentPlanVsCurrentConfirmedHotJobs : ITemplateTwo, IFavorable, ICalculatable
    {
        #region ITemplateTwo Interface Properties

        public double Average { get; set; }
        public int LessThanMinusThree { get; set; }
        public int GreaterThanEqualMinusThree { get; set; }
        public int GreaterThanEqualMinusTwo { get; set; }
        public int GreaterThanEqualMinusOne { get; set; }
        public int ZeroWeeks { get; set; }
        public int LessThanEqualOneWeek { get; set; }
        public int LessThanEqualTwoWeeks { get; set; }
        public int LessThanEqualThreeWeeks { get; set; }
        public int GreaterThanThreeWeeks { get; set; }
        public int Total { get; set; }

        #endregion

        #region IFavorable Interface Properties

        /// <summary>
        /// Percentage of records that are favorable
        /// </summary>
        public double PercentFavorable { get; set; }

        #endregion

        /// <summary>
        /// Default Constructor
        /// </summary>
        public CurrentPlanVsCurrentConfirmedHotJobs()
        {

        }

        #region ITemplateTwo Interface Methods

        /// <summary>
        /// Get the data within this specific KPA
        /// </summary>
        /// <returns>Returns the list of string values contained within temptwo of overall data. returns null if an error occured and must be handled.</returns>
        public List<string> GetData()
        {
            return new List<string>();
        }

        #endregion

        #region IFavorable Methods

        /// <summary>
        /// Calculates the percentage of favorable records
        /// </summary>
        public void CalculatePercentFavorable()
        {

        }

        #endregion

        #region ICalclatable Interface Methods


        /// <summary>
        /// Calculates the data for thid KPA
        /// </summary>
        public void Calculate()
        {

        }

        #endregion
    }
}
