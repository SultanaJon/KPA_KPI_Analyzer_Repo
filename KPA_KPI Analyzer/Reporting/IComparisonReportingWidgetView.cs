using Filters;
using Reporting;
using Reporting.KeyPerformanceActions;
using Reporting.KeyPerformanceIndicators;
using System;

namespace KPA_KPI_Analyzer.Reporting
{
    public interface IComparisonReportingWidgetView
    {
        /// <summary>
        /// The performance the comparison report will track
        /// </summary>
        ReportType PerformanceReportType { get; set; }


        /// <summary>
        /// The filter option the comparison report will use.
        /// </summary>

        FilterOptions.Options FilteringOption { get; set; }


        /// <summary>
        /// The KPA that the user will base the report off of.
        /// </summary>
        KpaOption KPAOption { get; set; }


        /// <summary>
        /// The KPI that the user will base the report off of.
        /// </summary>
        KpiOption KPIOption { get; set; }


        /// <summary>
        /// An event for when the user clicks generate report
        /// </summary>
        event EventHandler GenerateReport;


        /// <summary>
        /// Method to register the GenerateReport event
        /// </summary>
        /// <param name="_handler">The method to assign to the GenerateReport method.</param>
        void RegisterReportGenerationHandler(EventHandler _handler);
    }
}
