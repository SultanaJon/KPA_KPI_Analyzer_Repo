using Filters;
using Reporting;

namespace KPA_KPI_Analyzer.PerformanceReporting
{
    public interface IReportingController
    {
        /// <summary>
        /// The type of performance to track in the selective report
        /// </summary>
        ReportingType SelectiveReportingType { get; }


        /// <summary>
        /// The filter to be used in the selective report
        /// </summary>
        FilterOptions.Options SelectiveFilterOption { get; }


        /// <summary>
        /// The type of performance to track in the comparison report
        /// </summary>
        ReportingType ComparisonReportingType { get; }



        /// <summary>
        /// The filter to be used in the selective report
        /// </summary>
        FilterOptions.Options ComparisonFilterOption { get; }
    }
}
