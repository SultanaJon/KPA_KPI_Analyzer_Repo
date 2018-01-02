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
        public List<KeyPerformanceAction> Actions { get; set; }
        public List<KeyPerformanceIndicator> Indicators { get; set; }

        public Report()
        {
            Actions = new List<KeyPerformanceAction>();
            Indicators = new List<KeyPerformanceIndicator>();
        }
    }
}
