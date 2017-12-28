using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.KeyPerformanceActions
{
    public enum Section
    {
        Plan,
        Purch,
        PurchSub,
        PurchTotal,
        FollowUp,
        HotJobs,
        ExcessStockStock,
        ExcessStockOpenOrders,
        CurrentPlanVsActual
    }



    public abstract class KeyPerformanceAction
    {
        /// <summary>
        /// The section that this KPA belongs under
        /// </summary>
        public Section Section { get; set; }


        /// <summary>
        /// The name of this specific KPA
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Method to calculate the selective report for this Key Performance Action KPA
        /// </summary>
        public abstract void CalculateSelectiveReport(string uniqueFilters);
    }
}
