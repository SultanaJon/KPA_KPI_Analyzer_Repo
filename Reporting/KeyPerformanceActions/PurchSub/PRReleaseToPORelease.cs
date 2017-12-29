﻿using Reporting.Interfaces;


namespace Reporting.KeyPerformanceActions.PurchSub
{
    public sealed class PRReleaseToPORelease : KeyPerformanceAction, ISelectiveVOne
    {
        #region ISelectiveVOne Properties

        /// <summary>
        /// The Average Days for the Selective Calculation
        /// </summary>
        public double SelectiveAverage { get; set; }


        /// <summary>
        /// The total amount of records for the Selective Calculation
        /// </summary>
        public int SelectiveTotalRecords { get; set; }

        #endregion


        public PRReleaseToPORelease()
        {
            Section = "Purch Sub";
            Name = "PR Release To PO Release";
        }


        /// <summary>
        /// Calculates the selective report for this KPA
        /// </summary>
        public override void RunSelectiveReport(string uniqueFilters)
        {

        }
    }
}
