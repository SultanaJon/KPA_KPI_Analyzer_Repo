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
        internal List<KeyPerformanceAction> Actions { get; set; }
        internal List<KeyPerformanceIndicator> Indicators { get; set; }

        public Report()
        {
            Actions = new List<KeyPerformanceAction>();
            Indicators = new List<KeyPerformanceIndicator>();
        }
    }
}
