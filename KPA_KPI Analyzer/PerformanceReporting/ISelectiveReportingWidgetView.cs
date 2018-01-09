using Filters;
using Reporting;
using System;

namespace KPA_KPI_Analyzer.PerformanceReporting
{
    public interface ISelectiveReportingWidgetView
    {
        /// <summary>
        /// The Performance the comparison report will track
        /// </summary>
        ReportType PerformanceReportType { get; set; }


        /// <summary>
        /// The filter option nthe comparison report will use.
        /// </summary>
        FilterOptions.Options FilteringOption { get; set; }


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
