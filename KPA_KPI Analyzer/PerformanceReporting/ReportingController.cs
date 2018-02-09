using Filters;
using Reporting;
using Reporting.KeyPerformanceActions;
using Reporting.KeyPerformanceIndicators;
using System;

namespace KPA_KPI_Analyzer.PerformanceReporting
{
    class ReportingController : IReportingController
    {
        /// <summary>
        /// The selective and comparison reporting views (Widgets)
        /// </summary>
        private IComparisonReportingWidgetView comparisonReportingView;



        #region Comparison IReportingController Properties

        /// <summary>
        /// Returns the type of report the user would like to base the comparison report off of.
        /// </summary>
        public ReportingType ComparisonReportingType
        {
            get { return comparisonReportingView.PerformanceReportType; }
        }



        /// <summary>
        /// Returns the type of filter option for the comparison report
        /// </summary>
        public FilterOptions.Options ComparisonFilterOption
        {
            get { return comparisonReportingView.FilteringOption; }
        }




        /// <summary>
        /// Returns the KPA Option for the comparison report
        /// </summary>
        public KpaOption ComparisonKpaOption
        {
            get { return comparisonReportingView.KPAOption; }
        }




        /// <summary>
        /// Returns the KPI option for the comparison report
        /// </summary>
        public KpiOption ComparisonKpiOption
        {
            get { return comparisonReportingView.KPIOption; }
        }

        #endregion




        /// <summary>
        /// Custom Constructor
        /// </summary>
        /// <param name="selectiveView">The KPA & KPI Reporting widget</param>
        /// <param name="comparisonView">The Comparison Reporting widget</param>
        public ReportingController(IComparisonReportingWidgetView _comparisonView)
        {
            // Assign the views to the controllers views
            comparisonReportingView = _comparisonView;
        }




        /// <summary>
        /// Assigns the GenerateREport Event handler of the comparison report view
        /// </summary>
        /// <param name="_handler">The callback method</param>
        public void RegisterComparisonReportGenerationEvents(EventHandler _handler)
        {
            comparisonReportingView.RegisterReportGenerationHandler(_handler);
        }
    }
}
