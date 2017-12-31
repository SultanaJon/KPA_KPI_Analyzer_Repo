﻿using Reporting.Interfaces;
using System.Data;
using DataAccessLibrary;
using System;

namespace Reporting.KeyPerformanceActions.Plan
{
    public sealed class PRsAgingNotReleased : KeyPerformanceAction, ISelectiveVOne
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


        public PRsAgingNotReleased()
        {
            Section = "Plan";
            Name = "PRs Aging (Not Released)";
        }



        /// <summary>
        /// 
        /// </summary>
        public override void RunSelectiveReport(string uniqueFilters)
        {

        }
    }
}
