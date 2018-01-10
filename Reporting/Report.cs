using Reporting.KeyPerformanceActions;
using Reporting.KeyPerformanceIndicators;
using System.Collections.Generic;

namespace Reporting
{
    public enum ReportType : byte
    {
        KpaReport,
        KpiReport
    }

    public abstract class Report
    {
        /// <summary>
        /// A list of Key Performance Actions (KPAs) used by reports
        /// </summary>
        public static List<KeyPerformanceAction> Actions { get; set; }


        /// <summary>
        /// A list of Key Performance Indicators (KPIs) used by report
        /// </summary>
        public static List<KeyPerformanceIndicator> Indicators { get; set; }


        /// <summary>
        /// Boolean indicating whether or not the actions have been set (created)
        /// </summary>
        public static bool ActionsSet { get; set; }


        /// <summary>
        /// Boolean indicating whether or not the Indicators have been set (created)
        /// </summary>
        public static bool IndicatorsSet { get; set; }


        /// <summary>
        /// Default Constructor
        /// </summary>
        public Report()
        {
            if(Actions == null && Indicators == null)
            {
                Actions = new List<KeyPerformanceAction>();
                Indicators = new List<KeyPerformanceIndicator>();
            }
        }



        /// <summary>
        /// Abstract method to run the specific report
        /// </summary>
        public abstract void RunReport();
    }
}
