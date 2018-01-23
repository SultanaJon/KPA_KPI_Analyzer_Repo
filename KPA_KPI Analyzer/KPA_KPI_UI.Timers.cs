using DataAccessLibrary;
using DataAccessLibrary.Importing;
using ExcelLibrary;
using Filters;
using KPA_KPI_Analyzer.Values;
using Reporting;
using Reporting.Reports;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer
{
    public partial class KPA_KPI_UI : Form
    {
        #region EVENTS

        /// <summary>
        /// When the user has successfully dropped PRPO files into the application, this timer will initiate.
        /// The import process will then begin, importing all the data contained within the PRPO report into the
        /// Acces Database located in the resources folder.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Importer.ImportComplete)
                {
                    Importer.ImportComplete = false;
                    ImportTimer.Stop();

                    BeginDataRemovalProcess();

                    foreach(var file in processedFiles)
                    {
                        if(file is ExcelFiles.UsPrpoExcelFile)
                        {
                            if(AccessDatabaseUtils.US_PRPO_TableExists)
                            {
                                DateTime dt = file.Date;
                                reportSettings.PrpoUsDate = dt.Month.ToString() + " " + dt.Day.ToString() + " " + dt.Year.ToString();
                                reportSettings.PrpoUsReportLoaded = true;
                            }
                        }

                        if(file is ExcelFiles.MxPrpoExcelFile)
                        {
                            if(AccessDatabaseUtils.MX_PRPO_TableExists)
                            {
                                DateTime dt = file.Date;
                                reportSettings.PrpoMxDate = dt.Month.ToString() + " " + dt.Day.ToString() + " " + dt.Year.ToString();
                                reportSettings.PrpoMxReportLoaded = true;
                            }
                        }

                        // Save the report settings
                        reportSettings.Save();
                    }
                }
            }
            catch (DataImporter.Importing.Exceptions.ImportExceptions.InvalidDataFileException)
            {
                ShowPage(Pages.DragDropDash);
            }
        }
        


        /// <summary>
        /// Once the data is loaded into the application this timer will begin. This timer event will begin
        /// running condition checks and then making a call to remove the data that is not needed from the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataRemovalTimer_Tick(object sender, EventArgs e)
        {
            if (DatabaseDataRemovalUtils.DataRemoved)
            {
                DatabaseDataRemovalUtils.DataRemoved = false;
                DataRemovalTimer.Stop();

                if (AccessDatabaseUtils.US_PRPO_TableExists && AccessDatabaseUtils.MX_PRPO_TableExists)
                {
                    ShowPage(Pages.CountrySelector);
                }
                else if (AccessDatabaseUtils.US_PRPO_TableExists)
                {
                    ConfigureToUnitedStates();
                    BeginDataLoadProcess();
                }
                else // only the mexico file exists.
                {
                    ConfigureToMexico();
                    BeginDataLoadProcess();
                }
            }
        }




        private async void LoadOverallData()
        {
            // Lock the navigation functionality
            navigationSettings.Status = Navigation.Functionality.Locked;

            // A task to load the KPA Overall Data
            Task kpaTask = new Task((reports[ReportingType.KpaOverall] as KpaOverallReport).RunReport);

            // A task to load the KPA 
            Task kpiTask = new Task((reports[ReportingType.KpiOverall] as KpiOverallReport).RunReport);

            // A task to load the KPI tables
            Task kpiTableTask = new Task(DatabaseManager.LoadKPITables);

            // Start loading the KPI Tables
            kpiTableTask.Start();

            // Start the KPA Overall Report calculations
            kpaTask.Start();


            // Wait until the KPI Tables have been loaded then start loading the KPI Overall Data
            await kpiTableTask;

            // Start loading the KPI Overall Data
            kpiTask.Start();

            // Wait until the KPI Overall Data has been loaded.
            await kpiTask;



            // Release the KPI table back to the free store
            DatabaseManager.ReleaseKPITables();

            if (!FilterData.ColumnFilters.Applied && !FilterData.DateFilters.Applied && !FilterData.AdvancedFilters.Applied)
            {
                // Save the overall data to a JSON file.
                (reports[ReportingType.KpaOverall] as KpaOverallReport).Save();
                (reports[ReportingType.KpiOverall] as KpiOverallReport).Save();


                // Start the loading of fitlers.
                BegingFilterLoadProcess();
            }
            else
            {
                ShowPage(Pages.Filters);
                EnableClearFiltersButton();

                // Lock the navigation functionality
                navigationSettings.Status = Navigation.Functionality.Unlocked;


                ms_applicaitonMenuStrip.Enabled = true;
            }

            if (ReportingCountry.TargetCountry == Country.UnitedStates)
            {
                // Populate Dashboard with PRPO report date.
                DateTime dt = GetLoadedUsPrpoReportDate();
                reportSettings.PrpoUsLastLoadedDate = DateTime.Now.Month.ToString() + " " + DateTime.Now.Day.ToString() + " " + DateTime.Now.Year.ToString();
                topHandleBarModel.ReportGenerationDate = dt.ToString("MMMM dd, yyyy");
            }
            else
            {
                // Populate Dashboard with PRPO report date
                DateTime dt = GetLoadedMxPrpoReportDate();
                reportSettings.PrpoMxLastLoadedDate = DateTime.Now.Month.ToString() + " " + DateTime.Now.Day.ToString() + " " + DateTime.Now.Year.ToString();
                topHandleBarModel.ReportGenerationDate = dt.ToString("MMMM dd, yyyy");
            }
        }



        /// <summary>
        /// This timer will begin when the data has been imported or loaded. This event will check certain conditions
        /// and call functions that will load the unique data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FiltersTimer_Tick(object sender, EventArgs e)
        {
            if (!FilterUtils.FilterLoadProcessStarted)
            {
                FilterUtils.FilterLoadProcessStarted = true;
                Thread filtersThread = new Thread(() => {
                    LoadFilters();
                });
                filtersThread.Start();
            }


            if (Filters.FilterUtils.FiltersLoaded)
            {
                Filters.FilterUtils.FiltersLoaded = false;
                FiltersTimer.Stop();

                // Save the settings
                reportSettings.Save();

                // Show the dashboard
                ShowPage(Pages.Dashboard);
                ms_applicaitonMenuStrip.Enabled = true;

                // Lock the navigation functionality
                navigationSettings.Status = Navigation.Functionality.Unlocked;
            }
        }

        #endregion


        #region HELPER FUNCTIONS

        /// <summary>
        /// Begins the import process
        /// </summary>
        public void BeginImportProcess()
        {
            // Bring the loading screen to the front
            ActivateLoadingScreen("Importing Data...");

            // Update the top handle bar model
            topHandleBarModel.Update("Loading...", "Loading...");

            // Create a new instance of the overall reports
            CreateReport(ReportingType.KpaOverall);
            CreateReport(ReportingType.KpiOverall);


            if (AccessDatabaseUtils.US_PRPO_TableExists || AccessDatabaseUtils.MX_PRPO_TableExists)
                DatabaseManager.DropCreateDb();
            else
                DatabaseManager.CreateAccessDB();


            // Start the timer to check if the import has completed.
            ImportTimer.Start();


            foreach (var file in processedFiles)
            {
                if (file is ExcelFiles.UsPrpoExcelFile)
                {
                    // This file is a US PRPO file.
                    // Start importing the Report
                    ImportPrpoExcelFile(file);
                }
                else if(file is ExcelFiles.MxPrpoExcelFile)
                {
                    // This file is a MX PRPO file.
                    // Start importing the report
                    ImportPrpoExcelFile(file);
                }
            }
        }


        /// <summary>
        /// Starts the threads to import the PRPO reports.
        /// </summary>
        /// <param name="_excelFile"></param>
        private void ImportPrpoExcelFile(ExcelFiles.PrpoExcelFile _excelFile)
        {
            ApplicationIOLibarary.ApplicationFiles.FileUtils fileUtils = new ApplicationIOLibarary.ApplicationFiles.FileUtils();

            ms_applicaitonMenuStrip.Enabled = false;

            // Lock the navigation functionality
            navigationSettings.Status = Navigation.Functionality.Locked;


            if (_excelFile is ExcelFiles.UsPrpoExcelFile)
            {
                reportSettings.PrpoUsReportFileName = _excelFile.Path;

                // import only the US PRPO file
                Importer usImport = new Importer(
                    new ExcelInfo()
                    {
                        FileName = _excelFile.Path,
                        HasHeaders = true,
                        SheetName = ExcelInfo.sheetName[(int)ExcelInfo.SheetNames.US_PRPO]
                    },
                    new AccessInfo(fileUtils.DbPath)
                    {
                        TableName = AccessInfo.mainTableNames[(int)AccessInfo.MainTables.US_PRPO]
                    }
                );

                usThread = new Thread((mainThread) =>
                {
                    try
                    {
                        usImport.Run();
                    }
                    catch (ThreadInterruptedException)
                    {
                        ShowPage(Pages.DragDropDash);
                    }
                });

                usThread.Name = "US";
                usThread.Start(Thread.CurrentThread);
            }


            if (_excelFile is ExcelFiles.MxPrpoExcelFile)
            {
                reportSettings.PrpoMxReportFileName = _excelFile.Path;

                // Import only the MX PRPO file.
                Importer mxImport = new Importer(
                    new ExcelInfo()
                    {
                        FileName = _excelFile.Path,
                        HasHeaders = true,
                        SheetName = ExcelInfo.sheetName[(int)ExcelInfo.SheetNames.MX_PRPO]
                    },
                    new AccessInfo(fileUtils.DbPath)
                    {
                        TableName = AccessInfo.mainTableNames[(int)AccessInfo.MainTables.MX_PRPO]
                    }
                );


                mxThread = new Thread((mainThread) =>
                {
                    try
                    {
                        mxImport.Run();
                    }
                    catch (ThreadInterruptedException)
                    {
                        ShowPage(Pages.DragDropDash);
                    }
                });

                mxThread.Name = "MX";
                mxThread.Start(Thread.CurrentThread);
            }
        }


        /// <summary>
        /// Begins the Data removal process.
        /// </summary>
        public void BeginDataRemovalProcess()
        {
            ActivateLoadingScreen("Cleaning Data...");

            DatabaseDataRemovalUtils.DataRemoved = false;
            DatabaseDataRemovalUtils.CompletedDataRemovals = 0;
            DatabaseDataRemovalUtils.ScheduledDataRemovals = 0;

            DataRemovalTimer.Start();
            RemovePrpoData();
        }


        /// <summary>
        /// Starts the threads that removes the uneeded data from the PRPO database.
        /// </summary>
        private void RemovePrpoData()
        {
            if (AccessDatabaseUtils.US_PRPO_TableExists)
            {
                DatabaseDataRemovalUtils.ScheduledDataRemovals++;
                usThread = new Thread(() =>
                {
                    DatabaseManager.RemoveData(DatabaseTables.DatabaseTable.UnitedStates);
                });
                usThread.Start();
            }

            if (AccessDatabaseUtils.MX_PRPO_TableExists)
            {
                DatabaseDataRemovalUtils.ScheduledDataRemovals++;

                mxThread = new Thread(() =>
                {
                    DatabaseManager.RemoveData(DatabaseTables.DatabaseTable.Mexico);
                });
                mxThread.Start();
            }
        }


        /// <summary>
        /// This function sets up variables to their default state before begining the data load process.
        /// </summary>
        public void BeginDataLoadProcess()
        {
            // Bring the loading screen to the front
            ActivateLoadingScreen("Loading Data...");

            // Create the report or recreate the overall report
            CreateReport(ReportingType.KpaOverall);
            CreateReport(ReportingType.KpiOverall);

            // Start loading the overall data
            LoadOverallData();
        }



        /// <summary>
        /// Start the loading of the filters.
        /// </summary>
        public void BegingFilterLoadProcess()
        {
            DateTime today = DateTime.Now.Date;
            dp_PRFromDate.Value = today;
            dp_PRToDate.Value = today;
            dp_POFromDate.Value = today;
            dp_POToDate.Value = today;
            dp_finalReceiptFromDate.Value = today;
            dp_finalReciptToDate.Value = today;

            // Bring the loading screen to the front.
            ActivateLoadingScreen("Loading Filters...");

            ms_applicaitonMenuStrip.Enabled = false;
            FilterUtils.FiltersLoaded = false;
            FilterUtils.FilterLoadProcessStarted = false;
            FiltersTimer.Start();
        }

        #endregion
    }
}
