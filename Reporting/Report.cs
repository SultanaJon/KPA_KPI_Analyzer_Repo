using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting
{
    public abstract class Report
    {
        /// <summary>
        /// List of Key Performance Actions (KPA) contained within the report
        /// </summary>
        internal List<KeyPerformanceAction> Actions { get; set; }

        /// <summary>
        /// List of Key Performance Indicators (KPI) contained within the report
        /// </summary>
        internal List<KeyPerformanceIndicator> Indicators { get; set; }




        /// <summary>
        /// Default constructor
        /// </summary>
        public Report()
        {
            this.AddActions();
            this.AddIndicators();
        }



        /// <summary>
        /// Abstract method inherited by the child class to add the Key Performance Actions
        /// to the report.
        /// </summary>
        internal abstract void AddActions();



        /// <summary>
        /// Abstract method inherited by the child class to add the Key Performance Indicators
        /// to the report.
        /// </summary>
        internal abstract void AddIndicators();
    }
}
