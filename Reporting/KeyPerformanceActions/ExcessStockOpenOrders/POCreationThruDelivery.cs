using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.Interfaces;;


namespace Reporting.KeyPerformanceActions.ExcessStockOpenOrders
{
    public sealed class POCreationThruDelivery : KeyPerformanceAction, ISelectiveVOne
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


        public POCreationThruDelivery()
        {
            Section = Section.ExcessStockOpenOrders;
            Name = "PO Creation Thru Delivery";
        }


        /// <summary>
        /// Calculates the selective report for this KPA
        /// </summary>
        public override void CalculateSelectiveReport(string uniqueFilters)
        {

        }
    }
}
