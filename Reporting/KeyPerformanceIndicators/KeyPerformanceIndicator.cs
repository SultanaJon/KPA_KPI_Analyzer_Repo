using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.KeyPerformanceIndicators
{
    public enum Section
    {
        Plan,
        Purch,
        FollowUp,
        PlanTwo,
        PurchTwo,
        PurchSub,
        PurchTotal,
        PurchPlan,
        Other
    }



    public abstract class KeyPerformanceIndicator
    {
        /// <summary>
        /// The section that this KPI belongs under
        /// </summary>
        public Section Section { get; set; }


        /// <summary>
        /// The name of this specific KPI
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Method to calculate the selective report for this Key Performance Indicator (KPI)
        /// </summary>
        public abstract void CalculateSelectiveReport(string uniqueFilters);
    }
}
