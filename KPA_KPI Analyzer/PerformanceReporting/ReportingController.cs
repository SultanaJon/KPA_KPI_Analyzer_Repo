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
        private ISelectiveReportingWidgetView selectiveReportingView;
        private IComparisonReportingWidgetView comparisonReportingView;


        #region Selective IReportingController Properties

        /// <summary>
        /// Returns the type of report the user would like to base the selective report off of.
        /// </summary>
        public ReportingType SelectiveReportingType
        {
            get { return selectiveReportingView.PerformanceReportType; }
        }




        /// <summary>
        /// The filter option to be used in the selective report
        /// </summary>
        public FilterOptions.Options SelectiveFilterOption
        {
            get { return selectiveReportingView.FilteringOption; }
        }

        #endregion

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
        public ReportingController(ISelectiveReportingWidgetView _selectiveView, IComparisonReportingWidgetView _comparisonView)
        {
            // Assign the views to the controllers views
            selectiveReportingView = _selectiveView;
            comparisonReportingView = _comparisonView;
        }




        /// <summary>
        /// Assigns the Generate Report event handler of the selective report view
        /// </summary>
        /// <param name="_handler">Method to invoke</param>
        public void RegisterSelectiveReportGenerationEvents(EventHandler _handler)
        {
            selectiveReportingView.RegisterReportGenerationHandler(_handler);
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
