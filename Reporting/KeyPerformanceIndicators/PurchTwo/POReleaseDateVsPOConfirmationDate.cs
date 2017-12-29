﻿using Reporting.Interfaces;

namespace Reporting.KeyPerformanceIndicators.PurchTwo
{
    public sealed class POReleaseDateVsPOConfirmationDate : KeyPerformanceIndicator, ISelectiveVThree
    {
        #region ISelectiveVThree Properties

        public double SelectiveAverage { get; set; }
        public int SelectiveTotalRecords { get; set; }
        public double SelectivePercentUnconfirmed { get; set; }
        public double SelectivePercentFavorable { get; set; }

        #endregion



        /// <summary>
        /// Default Constructor
        /// </summary>
        public POReleaseDateVsPOConfirmationDate()
        {
            Section = "Purch II";
            Name = "PO Release Date vs PO Confirmation Date";
        }



        /// <summary>
        /// Calculates the selective report for this KPI
        /// </summary>
        public override void RunSelectiveReport(string uniqueFilters)
        {

        }
    }
}
