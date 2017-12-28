using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.Interfaces;;


namespace Reporting.KeyPerformanceActions.CurrentPlanVsActual
{
    public sealed class CurrentPlanDateVsCurrentConfirmationDate : KeyPerformanceAction, ISelectiveVTwo
    {
        #region ISelectiveTemplateTwo Properties

        /// <summary>
        /// The Average Weeks for the Selective Calculation
        /// </summary>
        public double SelectiveAverage { get; set; }


        /// <summary>
        /// The total records for the Selective Calculation
        /// </summary>
        public int SelectiveTotalRecords { get; set; }


        /// <summary>
        /// The Percentage of favorable records for the Selective Calculation
        /// </summary>
        public double SelectivePercentFavorable { get; set; }

        #endregion


        public CurrentPlanDateVsCurrentConfirmationDate()
        {
            Section = Section.CurrentPlanVsActual;
            Name = "Current Plan Date vs Current Confirmation Date";
        }


        /// <summary>
        /// Calculates the selective report for this KPA
        /// </summary>
        public override void CalculateSelectiveReport(string uniqueFilters)
        {

        }
    }
}
