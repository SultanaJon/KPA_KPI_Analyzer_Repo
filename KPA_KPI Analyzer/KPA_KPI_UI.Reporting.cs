using DataAccessLibrary;
using KPA_KPI_Analyzer.Reporting;
using Reporting;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer
{
    public enum ReportingType
    {
        Overall,
        KpaReport,
        KpiReport,
        ComparisonReport
    }


    public partial class KPA_KPI_UI : Form
    {
        /// <summary>
        /// A list of reports used in the application for reporting purposes.
        /// </summary>
        Dictionary<ReportingType, Report> reports = new Dictionary<ReportingType, Report>();

        ReportingController reportingWidgetsController;


        /// <summary>
        /// Adds report to the list of report used for reporting purposes.
        /// </summary>
        /// <param name="_reportType">The type of report that needs to be created</param>
        public void CreateReport(ReportingType _reportType)
        {
            switch (_reportType)
            {
                case ReportingType.Overall:
                    //reports.Add(ReportingType.KpaReport, new OverallReport());
                    break;
                case ReportingType.KpaReport:
                    // Create the KPA Report
                    try
                    {
                        reports.Add(_reportType, new KpaReport());
                    }
                    catch (ArgumentNullException)
                    {
                        MessageBox.Show("Argumment Null Exception was thrown.", "KPA Report Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (ArgumentException)
                    {
                        reports[ReportingType.KpaReport] = new KpaReport();
                    }
                    break;
                case ReportingType.KpiReport:
                    // Create the KPI Report
                    try
                    {
                        reports.Add(_reportType, new KpiReport());
                    }
                    catch(ArgumentNullException)
                    {
                        MessageBox.Show("Argumment Null Exception was thrown.", "KPI Report Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch(ArgumentException)
                    {
                        reports[ReportingType.KpiReport] = new KpiReport();
                    }
                    break;
                case ReportingType.ComparisonReport:
                    try
                    {
                        reports.Add(_reportType, new ComparisonReport());
                    }
                    catch (ArgumentNullException)
                    {
                        MessageBox.Show("Argumment Null Exception was thrown.", "Comparison Report Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (ArgumentException)
                    {
                        reports[ReportingType.ComparisonReport] = new ComparisonReport();
                    }
                    break;
                default:
                    break;
            }
        }



        /// <summary>
        /// Loads the report page where the user can select a report to run.
        /// </summary>
        private void CreateReportPage()
        {
            lbl_Performance.Text = "N/A";
            lbl_Section.Text = "N/A";
            lbl_Category.Text = "N/A";

            FlowLayoutPanel wrapPanel = new FlowLayoutPanel()
            {
                Name = "Reports",
                Dock = DockStyle.Fill
            };

            Control[] reportingControls = new Control[]
            {
                new SelctiveReportingWidget() { Margin = new Padding(10, 10, 0, 0) },
                new ComparisonReportingWidget() { Margin = new Padding(10, 10, 0, 0) }
            };


            // Add the controls to the wrap panel
            wrapPanel.Controls.AddRange(reportingControls);

            pnl_activePage.Controls.Add(wrapPanel);
            wrapPanel.BringToFront();
            MenuInFront = true;
            pnl_NavigationPanelMax.BringToFront();


            // Create and register the reporting controller
            reportingWidgetsController = new ReportingController(reportingControls[0] as ISelectiveReportingWidgetView, reportingControls[1] as IComparisonReportingWidgetView);
            reportingWidgetsController.RegisterSelectiveReportGenerationEvents(SelectiveReportGeneration);
            reportingWidgetsController.RegisterComparisonReportGenerationEvents(ComparisonReportGeneration);
        }





        /// <summary>
        /// Event listener for when the user wants to generate a KPA or KPI report
        /// </summary>
        /// <param name="sender">The generate report button</param>
        /// <param name="e">the click event</param>
        private void SelectiveReportGeneration(object sender, EventArgs e)
        {
            switch (reportingWidgetsController.SelectiveReportingType)
            {
                case ReportType.KpaReport:
                    // Create a KPA Report
                    CreateReport(ReportingType.KpaReport);

                    // Generate the rest of the report and build it
                    GenerateKpaReport();
                    break;
                case ReportType.KpiReport:
                    // Create a KPI Report
                    CreateReport(ReportingType.KpiReport);

                    // Generate the rest of the report and build it
                    GenerateKpiReport();
                    break;
                default:
                    break;
            }
        }







        /// <summary>
        /// Event listener for when the user wants to generate a Comparison report
        /// </summary>
        /// <param name="sender">The Generate report button</param>
        /// <param name="e">The click event</param>
        private void ComparisonReportGeneration(object sender, EventArgs e)
        {
            // Create the comparison report
            CreateReport(ReportingType.ComparisonReport);

            switch (reportingWidgetsController.SelectiveReportingType)
            {
                case ReportType.KpaReport:
                    // The user wants to create a KPA Comparison Report.
                    break;
                case ReportType.KpiReport:
                    // The user wants to create a KPI Comparison Report
                    break;
                default:
                    break;
            }
        }





        /// <summary>
        /// Get the filters associated with the filter option passed in.
        /// </summary>
        /// <param name="_filterOption">The filter being requested.</param>
        /// <returns>The unique list of filters.</returns>
        private List<string> GetFilters(Filters.FilterOptions.Options _filterOption)
        {
            List<string> tempFilterList = new List<string>();
            switch (_filterOption)
            {
                case Filters.FilterOptions.Options.ProjectNumber:
                    return new List<string>(FilterManager.GetUniqueProjectNumber());
                case Filters.FilterOptions.Options.WBSElement:
                    return new List<string>(FilterManager.GetUniqueWbsElement());
                case Filters.FilterOptions.Options.Material:
                    return new List<string>(FilterManager.GetUniqueMaterial());
                case Filters.FilterOptions.Options.MaterialGroup:
                    return new List<string>(FilterManager.GetUniqueMaterialGroup());
                case Filters.FilterOptions.Options.Vendor:
                    return new List<string>(FilterManager.GetUniqueVendor());
                case Filters.FilterOptions.Options.VendorDescription:
                    return new List<string>(FilterManager.GetUniqueVendorDescription());
                case Filters.FilterOptions.Options.PRPurchaseGroup:
                    return new List<string>(FilterManager.GetUniquePrPurchaseGroup());
                case Filters.FilterOptions.Options.POPurchaseGroup:
                    return new List<string>(FilterManager.GetUniquePoPurchaseGroup());
                case Filters.FilterOptions.Options.IRSuppName:
                    return new List<string>(FilterManager.GetUniqueIrSuppName());
                case Filters.FilterOptions.Options.DsrdSuppName:
                    return new List<string>(FilterManager.GetUniqueDsrdSuppName());
                case Filters.FilterOptions.Options.CommodityCategory:
                    return new List<string>(FilterManager.GetUniqueCommodityCategory());
                case Filters.FilterOptions.Options.PODocumentType:
                    return new List<string>(FilterManager.GetUniquePoDocumentType());
                case Filters.FilterOptions.Options.ProductionOrderMaterial:
                    return new List<string>(FilterManager.GetUniqueProductionOrderMaterial());
            }
            return tempFilterList;
        }





        /// <summary>
        /// Finishes initializing the KPA Report and begins running the report
        /// </summary>
        private void GenerateKpaReport()
        {
            // Get the filter the user want to use.
            List<string> filters = GetFilters(reportingWidgetsController.SelectiveFilterOption);

            // Pass the filters to the kpa report to use in the report generation
            (reports[ReportingType.KpaReport] as KpaReport).SetKpaReport(filters);

        }





        /// <summary>
        /// Finishes initializing the KPI Report and begins running the report.
        /// </summary>
        private void GenerateKpiReport()
        {
            // Get the filter the user want to use.
            List<string> filters = GetFilters(reportingWidgetsController.SelectiveFilterOption);

            // Pass the filters to the kpi report to use in the report generation
            (reports[ReportingType.KpiReport] as KpiReport).SetKpiReport(filters);
        }
    }
}