﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.Interfaces;;


namespace Reporting.KeyPerformanceActions.FollowUp
{
    public sealed class ConfirmedDateVsPlanDate : KeyPerformanceAction, ISelectiveVOne
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


        public ConfirmedDateVsPlanDate()
        {
            Section = Section.FollowUp;
            Name = "Confirmed Date Vs Plan Date";
        }


        /// <summary>
        /// Calculates the selective report for this KPA
        /// </summary>
        public override void CalculateSelectiveReport(string uniqueFilters)
        {

        }
    }
}