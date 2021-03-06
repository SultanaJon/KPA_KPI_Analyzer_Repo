﻿using DataAccessLibrary;
using Filters;
using KPA_KPI_Analyzer.ExcelLibrary;
using KPA_KPI_Analyzer.PerformanceReporting;
using Reporting;
using Reporting.Reports;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer
{
    public partial class KPA_KPI_UI : Form
    {
        /// <summary>
        /// A list of reports used in the application for reporting purposes.
        /// </summary>
        Dictionary<ReportingType, Report> reports = new Dictionary<ReportingType, Report>();


        /// <summary>
        /// Controller used to interact with the reporting widgets (KPA & KPI reporting widget & Comparison Reporting Widget)
        /// </summary>
        ReportingController reportingWidgetsController;


        /// <summary>
        /// Adds report to the list of report used for reporting purposes.
        /// </summary>
        /// <param name="_reportType">The type of report that needs to be created</param>
        public void CreateReport(ReportingType _reportType)
        {
            switch (_reportType)
            {
                case ReportingType.KpaOverall:
                    // Create the KPA Overall Report
                    try
                    {

                        reports.Add(_reportType, KpaOverallReport.KpaOverallReportInstance);
                    }
                    catch (ArgumentNullException)
                    {
                        MessageBox.Show("Argumment Null Exception was thrown.", "KPA Report Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (ArgumentException)
                    {
                        // Create a new instance of a KPA Overall Report
                        KpaOverallReport.CreateNewInstance();

                        // Assign that instance to the list of reports
                        reports[ReportingType.KpaOverall] = KpaOverallReport.KpaOverallReportInstance;
                    }
                    break;
                case ReportingType.KpiOverall:
                    // Create the KPI Overall Report
                    try
                    {

                        reports.Add(_reportType, KpiOverallReport.KpiOverallReportInstance);
                    }
                    catch (ArgumentNullException)
                    {
                        MessageBox.Show("Argumment Null Exception was thrown.", "KPI Report Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (ArgumentException)
                    {
                        // Create a new instance of a KPI Overall Report
                        KpiOverallReport.CreateNewInstance();

                        // Assign that instance to the list of reports
                        reports[ReportingType.KpiOverall] = KpiOverallReport.KpiOverallReportInstance;
                    }
                    break;
                case ReportingType.KpaComparisonReport:
                    // Create the KPA Report
                    try
                    {
                        reports.Add(_reportType, KpaComparisonReport.KpaComparisonReportInstance);
                    }
                    catch (ArgumentNullException)
                    {
                        MessageBox.Show("Argumment Null Exception was thrown.", "KPA Comparison Report Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (ArgumentException)
                    {
                        // Create a new instance of a KPI Overall Report
                        KpaComparisonReport.CreateNewInstance();

                        // Assign that instance to the list of reports
                        reports[ReportingType.KpaComparisonReport] = KpaComparisonReport.KpaComparisonReportInstance;
                    }
                    break;
                case ReportingType.KpiComparisonReport:
                    // Create the KPI Report
                    try
                    {
                        reports.Add(_reportType, KpiComparisonReport.KpiComparisonReportInstance);
                    }
                    catch (ArgumentNullException)
                    {
                        MessageBox.Show("Argumment Null Exception was thrown.", "KPI Comparison Report Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (ArgumentException)
                    {
                        // Create a new instance of a KPI Overall Report
                        KpiComparisonReport.CreateNewInstance();

                        // Assign that instance to the list of reports
                        reports[ReportingType.KpiComparisonReport] = KpiComparisonReport.KpiComparisonReportInstance;
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
            // Set the model indicating that there is currently no KPA or KPI being viewed.
            topHandleBarModel.Update("N/A", "N/A", "N/A");

            FlowLayoutPanel wrapPanel = new FlowLayoutPanel()
            {
                Name = "Reports",
                Dock = DockStyle.Fill
            };

            Control[] reportingControls = new Control[]
            {
                new ComparisonReportingWidget() { Margin = new Padding(10, 10, 0, 0) }
            };


            // Add the controls to the wrap panel
            wrapPanel.Controls.AddRange(reportingControls);

            pnl_activePage.Controls.Add(wrapPanel);
            wrapPanel.BringToFront();

            // Lock the navigation functionality
            navigationSettings.Visible = Navigation.Visibility.Open;

            // Create and register the reporting controller
            reportingWidgetsController = new ReportingController(reportingControls[0] as IComparisonReportingWidgetView);
            reportingWidgetsController.RegisterComparisonReportGenerationEvents(ComparisonReportGeneration);
        }




        /// <summary>
        /// Event listener for when the user wants to generate a Comparison report
        /// </summary>
        /// <param name="sender">The Generate report button</param>
        /// <param name="e">The click event</param>
        private async void ComparisonReportGeneration(object sender, EventArgs e)
        {
            switch (reportingWidgetsController.ComparisonReportingType)
            {
                case ReportingType.KpaComparisonReport:
                    // Create the comparison report
                    CreateReport(ReportingType.KpaComparisonReport);
                    KpaComparisonReport kpaComparisonReport = (reports[ReportingType.KpaComparisonReport] as KpaComparisonReport);

                    // The user wants to create a KPA Comparison Report.
                    Task<bool> kpaComparisonReportTask = new Task<bool>(GenerateKpaComparisonReport);
                    kpaComparisonReportTask.Start();

                    if(await kpaComparisonReportTask)
                    {
                        ActivateLoadingScreen("Loading Report...");

                        // The report has finished creating now run it.
                        Task calculateComparisonReportTask = new Task(()=> { kpaComparisonReport.RunReport(reportingWidgetsController.ComparisonFilterOption); });
                        calculateComparisonReportTask.Start();
                        await calculateComparisonReportTask;

                        // Beging to export the comparison report to excel.
                        Task comparisonReportExport = new Task(() => 
                        {
                            ComparisonReportExcelFile xlFile = new ComparisonReportExcelFile(kpaComparisonReport.TemplateStructure)
                            {
                                Filter = FilterOptions.options[(int)reportingWidgetsController.ComparisonFilterOption],
                                Country = ReportingCountry.countries[(int)ReportingCountry.TargetCountry],
                                ReportGenerationDate = $"{DateTime.Now:D}"
                            };

                            Exporter xporter = new Exporter();
                            xporter.ExportComparisonReport(xlFile);
                        });
                        comparisonReportExport.Start();

                        // Wait for the report to finish exporting
                        await comparisonReportExport;

                        // Hide any pages that might be visible
                        HidePages();
                        
                        // Unclock the navigation and the menu strip.
                        navigationSettings.Status = Navigation.Functionality.Unlocked;
                        ms_applicaitonMenuStrip.Enabled = true;
                    }
                    else
                    {
                        // The report did not successfully create
                        MessageBox.Show("The report failed to generate!", "KPA Comparison Report Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case ReportingType.KpiComparisonReport:
                    // Create the comparison report
                    CreateReport(ReportingType.KpiComparisonReport);
                    KpiComparisonReport kpiComparisonReport = (reports[ReportingType.KpiComparisonReport] as KpiComparisonReport);

                    // The user wants to create a KPI Comparison Report.
                    Task<bool> kpiComparisonReportTask = new Task<bool>(GenerateKpiComparisonReport);
                    kpiComparisonReportTask.Start();

                    if (await kpiComparisonReportTask)
                    {
                        ActivateLoadingScreen("Loading Report...");

                        // Start loading the KPI table and wait for the table to finish loading before running the comparison report.
                        Task kpaTableTask = new Task(DatabaseManager.LoadKPITables);
                        kpaTableTask.Start();
                        await kpaTableTask;

                        // The report has finished creating now run it.
                        Task calculateComparisonReportTask = new Task(() => { kpiComparisonReport.RunReport(reportingWidgetsController.ComparisonFilterOption); });
                        calculateComparisonReportTask.Start();
                        await calculateComparisonReportTask;

                        // Beging to export the comparison report to excel.
                        Task comparisonReportExport = new Task(() =>
                        {
                            ComparisonReportExcelFile xlFile = new ComparisonReportExcelFile(kpiComparisonReport.TemplateStructure)
                            {
                                Filter = FilterOptions.options[(int)reportingWidgetsController.ComparisonFilterOption],
                                Country = ReportingCountry.countries[(int)ReportingCountry.TargetCountry],
                                ReportGenerationDate = $"{DateTime.Now:D}"
                            };

                            Exporter xporter = new Exporter();
                            xporter.ExportComparisonReport(xlFile);
                        });
                        comparisonReportExport.Start();

                        // Wait for the report to finish exporting
                        await comparisonReportExport;

                        // Hide any pages that might be visible
                        HidePages();

                        // Unclock the navigation and the menu strip.
                        navigationSettings.Status = Navigation.Functionality.Unlocked;
                        ms_applicaitonMenuStrip.Enabled = true;

                        // Release the KPI tables
                        DatabaseManager.ReleaseKPITables();
                    }
                    else
                    {
                        // The report did not successfully create
                        MessageBox.Show("The report failed to generate!", "KPI Comparison Report Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                default:
                    MessageBox.Show("Could not determine the type of comparison Report", "Comparison Report Failure");
                    break;
            }
        }




        /// <summary>
        /// Get the filters associated with the filter option passed in.
        /// </summary>
        /// <param name="_filterOption">The filter being requested.</param>
        /// <returns>The unique list of filters.</returns>
        private List<string> GetFilters(FilterOptions.Options _filterOption)
        {
            List<string> tempFilterList = new List<string>();

            switch (_filterOption)
            {
                case FilterOptions.Options.ProjectNumber:
                    return new List<string>(FilterManager.GetUniqueProjectNumber());
                case FilterOptions.Options.WBSElement:
                    return new List<string>(FilterManager.GetUniqueWbsElement());
                case FilterOptions.Options.Material:
                    return new List<string>(FilterManager.GetUniqueMaterial());
                case FilterOptions.Options.MaterialGroup:
                    return new List<string>(FilterManager.GetUniqueMaterialGroup());
                case FilterOptions.Options.Vendor:
                    return new List<string>(FilterManager.GetUniqueVendor());
                case FilterOptions.Options.VendorDescription:
                    return  new List<string>(FilterManager.GetUniqueVendorDescription());
                case FilterOptions.Options.PRPurchaseGroup:
                    return  new List<string>(FilterManager.GetUniquePrPurchaseGroup());
                case FilterOptions.Options.POPurchaseGroup:
                    return  new List<string>(FilterManager.GetUniquePoPurchaseGroup());
                case FilterOptions.Options.IRSuppName:
                    return  new List<string>(FilterManager.GetUniqueIrSuppName());
                case FilterOptions.Options.FxdSuppName:
                    return new List<string>(FilterManager.GetUniqueFxdSuppName());
                case FilterOptions.Options.DsrdSuppName:
                    return  new List<string>(FilterManager.GetUniqueDsrdSuppName());
                case FilterOptions.Options.CommodityCategory:
                    return  new List<string>(FilterManager.GetUniqueCommodityCategory());
                case FilterOptions.Options.PODocumentType:
                    return  new List<string>(FilterManager.GetUniquePoDocumentType());
                case FilterOptions.Options.ProductionOrderMaterial:
                    return  new List<string>(FilterManager.GetUniqueProductionOrderMaterial());
                case FilterOptions.Options.StorageLocation:
                    return new List<string>(FilterManager.GetUniqueStorageLocation());
            }

            return tempFilterList;
        }






        /// <summary>
        /// Creates a Comparison Report and runs it based on the KPA option selected
        /// </summary>
        private bool GenerateKpaComparisonReport()
        {
            // Get the filter option that the user wants for the report
            List<string> fitlers = GetFilters(reportingWidgetsController.ComparisonFilterOption);

            // Finish creating the Comparison report
            if((reports[ReportingType.KpaComparisonReport] as KpaComparisonReport)
                .GenerateReport(fitlers, reportingWidgetsController.ComparisonKpaOption))
            {
                // The report was successfuly created. Start running the report.
                return true;
            }
            else
            {
                // The report failed to create
                return false;
            }
        }




        /// <summary>
        /// Creates a comparison report and runs it based on the KPI option selected
        /// </summary>
        private bool GenerateKpiComparisonReport()
        {
            // Get the filter option that the user wants for the report
            List<string> filtersTaskResult = GetFilters(reportingWidgetsController.ComparisonFilterOption);

            // Finish creating the Comparison report
            if ((reports[ReportingType.KpiComparisonReport] as KpiComparisonReport)
                .GenerateReport(filtersTaskResult, reportingWidgetsController.ComparisonKpiOption))
            {
                // The report was successfuly created. Start running the report.
                return true;
            }
            else
            {
                // The report failed to create
                return false;
            }
        }
    }
}