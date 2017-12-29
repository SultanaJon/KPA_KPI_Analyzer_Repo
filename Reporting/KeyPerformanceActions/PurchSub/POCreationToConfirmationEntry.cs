﻿using Reporting.Interfaces;


namespace Reporting.KeyPerformanceActions.PurchSub
{
    public sealed class POCreationToConfirmationEntry : KeyPerformanceAction, ISelectiveVOne
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


        public POCreationToConfirmationEntry()
        {
            Section = "Purch Sub";
            Name = "PO Creation To Confirmation Entry";
        }


        /// <summary>
        /// Calculates the selective report for this KPA
        /// </summary>
        public override void RunSelectiveReport(string uniqueFilters)
        {

        }
    }
}
