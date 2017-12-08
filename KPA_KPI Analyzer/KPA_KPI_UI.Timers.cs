using DataImporter.Access;
using DataImporter.Excel;
using DataImporter.Importing;
using KPA_KPI_Analyzer.Database;
using KPA_KPI_Analyzer.FileProcessing;
using KPA_KPI_Analyzer.Filters;
using KPA_KPI_Analyzer.Overall_Data;
using KPA_KPI_Analyzer.Values;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer
{
    public partial class KPA_KPI_UI : Form
    {
        #region FIELD DATA

        Thread KPA_PlanThread;
        Thread KPA_PurchThread;
        Thread KPA_PurchSubThread;
        Thread KPA_PurchTotalThread;
        Thread KPA_FollowUpThread;
        Thread KPA_HotJobs;
        Thread KPA_ExcessStock_Stock;
        Thread KPA_ExcessStock_OpenOrders;
        Thread KPA_CurrPlanVsActualThread;
        Thread tableLoadThread;
        Thread KPI_PlanThread;
        Thread KPI_PurchThread;
        Thread KPI_FollowUpThread;
        Thread KPI_PlanTwoThread;
        Thread KPI_PurchTwoThread;
        Thread KPI_PurchSubThread;
        Thread KPI_PurchTotalThread;
        Thread KPI_PurchPlanThread;
        Thread KPI_OtherThread;

        #endregion


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
                            if(AccessUtils.US_PRPO_TableExists)
                            {
                                DateTime dt = file.Date;
                                settings.reportSettings.PrpoUsDate = dt.Month.ToString() + " " + dt.Day.ToString() + " " + dt.Year.ToString();
                                settings.reportSettings.PrpoUsReportLoaded = true;
                            }
                        }

                        if(file is ExcelFiles.MxPrpoExcelFile)
                        {
                            if(AccessUtils.MX_PRPO_TableExists)
                            {
                                DateTime dt = file.Date;
                                settings.reportSettings.PrpoMxDate = dt.Month.ToString() + " " + dt.Day.ToString() + " " + dt.Year.ToString();
                                settings.reportSettings.PrpoMxReportLoaded = true;
                            }
                        }
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
            if (DatabaseUtils.DataRemoved)
            {
                DatabaseUtils.DataRemoved = false;
                DataRemovalTimer.Stop();

                if (AccessUtils.US_PRPO_TableExists && AccessUtils.MX_PRPO_TableExists)
                {
                    ShowPage(Pages.CountrySelector);
                }
                else if (AccessUtils.US_PRPO_TableExists)
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



        /// <summary>
        /// Once an import, filter apply and filter removal occur, this timer will initiate. The data contained within
        /// the access database will then be loaded into the application where calculations will occur.        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataLoaderTimer_Tick(object sender, EventArgs e)
        {
            NavigationLocked = true;

            if (!DatabaseUtils.DataLoadProcessStarted)
            {
                DatabaseUtils.DataLoadProcessStarted = true;
                DatabaseUtils.KPITablesLoaded = false;
                DatabaseUtils.ScheduledDataLoads = 19;
                StartThreads(true, false);
            }


            if (DatabaseUtils.KPITablesLoaded)
            {
                DatabaseUtils.KPITablesLoaded = false;
                StartThreads(false, true);
            }

            if (DatabaseUtils.DataLoaded)
            {
                DatabaseUtils.DataLoaded = false;
                DataLoaderTimer.Stop();
                DatabaseUtils.ReleaseKPITables();

                if (!FilterData.ColumnFilters.Applied 
                    && !FilterData.DateFilters.Applied 
                    && !FilterData.AdvancedFilters.Applied)
                {
                    // Save the overall data to a JSON file.
                    overallData.Save();

                    InitializeFilterLoadProcess();
                }
                else
                {
                    ShowPage(Pages.Filters);
                    EnableClearFiltersButton();
                    NavigationLocked = false;
                    ms_applicaitonMenuStrip.Enabled = true;
                }

                if (Globals.TargetCountry == Values.Countries.Country.UnitedStates)
                {
                    // Populate Dashboard with PRPO report date.
                    DateTime dt = GetLoadedUsPrpoReportDate();
                    settings.reportSettings.PrpoUsLastLoadedDate = DateTime.Now.Month.ToString() + " " + DateTime.Now.Day.ToString() + " " + DateTime.Now.Year.ToString();
                    lbl_dashboardDate.Text = dt.ToString("MMMM dd, yyyy");
                    lbl_topPanelNavPrpoDate.Text = dt.ToString("MMMM dd, yyyy");
                    Globals.PrpoGenerationDate = lbl_topPanelNavPrpoDate.Text;
                }
                else
                {
                    // Populate Dashboard with PRPO report date
                    DateTime dt = GetLoadedMxPrpoReportDate();
                    settings.reportSettings.PrpoMxLastLoadedDate = DateTime.Now.Month.ToString() + " " + DateTime.Now.Day.ToString() + " " + DateTime.Now.Year.ToString();
                    lbl_dashboardDate.Text = dt.ToString("MMMM dd, yyyy");
                    lbl_topPanelNavPrpoDate.Text = dt.ToString("MMMM dd, yyyy");
                    Globals.PrpoGenerationDate = lbl_topPanelNavPrpoDate.Text;
                }
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
                    FilterUtils.LoadFilters(filters);
                });
                filtersThread.Start();
            }


            if (FilterUtils.FiltersLoaded)
            {
                FilterUtils.FiltersLoaded = false;
                FiltersTimer.Stop();

                // Save the settings
                settings.Save();
                ShowPage(Pages.Dashboard);
                ms_applicaitonMenuStrip.Enabled = true;
                NavigationLocked = false;
            }
        }

        #endregion


        #region HELPER FUNCTIONS

        /// <summary>
        /// Create the threads that will load the data into the application
        /// </summary>
        private void CreateThreads()
        {
            KPA_PlanThread = new Thread(() => { try { overallData.kpa.plan.LoadData(); } catch (Exception) { ShowPage(Pages.DragDropDash); } });
            KPA_PurchThread = new Thread(() => { try { overallData.kpa.purch.LoadData(); } catch (Exception) { ShowPage(Pages.DragDropDash); } });
            KPA_PurchSubThread = new Thread(() => { try { overallData.kpa.purchSub.LoadData(); } catch (Exception) { ShowPage(Pages.DragDropDash); } });
            KPA_PurchTotalThread = new Thread(() => { try { overallData.kpa.purchTotal.LoadData(); } catch (Exception) { ShowPage(Pages.DragDropDash); } });
            KPA_FollowUpThread = new Thread(() => { try { overallData.kpa.followUp.LoadData(); } catch (Exception) { ShowPage(Pages.DragDropDash); } });
            KPA_HotJobs = new Thread(() => { try { overallData.kpa.hotJobs.LoadData(); } catch (Exception) { ShowPage(Pages.DragDropDash); } });
            KPA_ExcessStock_Stock = new Thread(() => { try { overallData.kpa.excessStockStock.LoadData(); } catch (Exception) { ShowPage(Pages.DragDropDash); } });
            KPA_ExcessStock_OpenOrders = new Thread(() => { try { overallData.kpa.excessStockOpenOrders.LoadData(); } catch (Exception) { ShowPage(Pages.DragDropDash); } });
            KPA_CurrPlanVsActualThread = new Thread(() => { try { overallData.kpa.currPlanVsActual.LoadData(); } catch (Exception) { ShowPage(Pages.DragDropDash); } });

            tableLoadThread = new Thread(() => { try { DatabaseUtils.LoadKPITables(); } catch (Exception) { ShowPage(Pages.DragDropDash); } });
            KPI_PlanThread = new Thread(() => { try { overallData.kpi.plan.LoadData(); } catch (Exception) { ShowPage(Pages.DragDropDash); } });
            KPI_PurchThread = new Thread(() => { try { overallData.kpi.purch.LoadData(); } catch (Exception) { ShowPage(Pages.DragDropDash); } });
            KPI_FollowUpThread = new Thread(() => { try { overallData.kpi.followUp.LoadData(); } catch (Exception) { ShowPage(Pages.DragDropDash); } });
            KPI_PlanTwoThread = new Thread(() => { try { overallData.kpi.planTwo.LoadData(); } catch (Exception) { ShowPage(Pages.DragDropDash); } });
            KPI_PurchTwoThread = new Thread(() => { try { overallData.kpi.purchTwo.LoadData(); } catch (Exception) { ShowPage(Pages.DragDropDash); } });
            KPI_PurchSubThread = new Thread(() => { try { overallData.kpi.purchSub.LoadData(); } catch (Exception) { ShowPage(Pages.DragDropDash); } });
            KPI_PurchTotalThread = new Thread(() => { try { overallData.kpi.purchTotal.LoadData(); } catch (Exception) { ShowPage(Pages.DragDropDash); } });
            KPI_PurchPlanThread = new Thread(() => { try { overallData.kpi.purchPlan.LoadData(); } catch (Exception) { ShowPage(Pages.DragDropDash); } });
            KPI_OtherThread = new Thread(() => { try { overallData.kpi.other.LoadData(); } catch (Exception) { ShowPage(Pages.DragDropDash); } });
        }

        
        /// <summary>
        /// Starts the threads that will load perform the calculations on the data.
        /// </summary>
        /// <param name="_startKpaThreads">Indicates whether or not the KPA threads should be started.</param>
        /// <param name="_startKpiThreads">Indicates whether or not the KPI threads should be started.</param>
        private void StartThreads(bool _startKpaThreads, bool _startKpiThreads)
        {
            if (_startKpaThreads)
            {
                KPA_PlanThread.Start();
                KPA_PurchThread.Start();
                KPA_PurchSubThread.Start();
                KPA_PurchTotalThread.Start();
                KPA_FollowUpThread.Start();
                KPA_HotJobs.Start();
                KPA_ExcessStock_Stock.Start();
                KPA_ExcessStock_OpenOrders.Start();
                KPA_CurrPlanVsActualThread.Start();
                tableLoadThread.Start();
            }


            if (_startKpiThreads)
            {
                KPI_PlanThread.Start();
                KPI_PurchThread.Start();
                KPI_FollowUpThread.Start();
                KPI_PlanTwoThread.Start();
                KPI_PurchTwoThread.Start();
                KPI_PurchSubThread.Start();
                KPI_PurchTotalThread.Start();
                KPI_PurchPlanThread.Start();
                KPI_OtherThread.Start();
            }
        }


        /// <summary>
        /// Begins the import process
        /// </summary>
        public void BeginImportProcess()
        {
            lbl_Country.Text = "Loading...";
            lbl_topPanelNavPrpoDate.Text = "Loading...";
            overallData = new Overall_Data.Overall();

            if (AccessUtils.US_PRPO_TableExists || AccessUtils.MX_PRPO_TableExists)
                DatabaseUtils.DropCreateDb();
            else
                AccessUtils.CreateAccessDB();

            ShowPage(Pages.LoadingScreen);
            cpb_loadingScreenCircProgBar.Text = "Importing Data...";


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
        private void ImportPrpoExcelFile(ExcelFiles.IPrpoExcelFile _excelFile)
        {
            ms_applicaitonMenuStrip.Enabled = false;
            NavigationLocked = true; // Lock the navigation bar

            if (_excelFile is ExcelFiles.UsPrpoExcelFile)
            {
                settings.reportSettings.PrpoUsReportFileName = _excelFile.Path;

                // import only the US PRPO file
                Importer usImport = new Importer(
                    new ExcelInfo()
                    {
                        FileName = _excelFile.Path,
                        HasHeaders = true,
                        SheetName = ExcelInfo.sheetName[(int)ExcelInfo.SheetNames.US_PRPO]
                    },
                    new AccessInfo()
                    {
                        FileName = Configuration.DbPath,
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
                settings.reportSettings.PrpoMxReportFileName = _excelFile.Path;

                // Import only the MX PRPO file.
                Importer mxImport = new Importer(
                    new ExcelInfo()
                    {
                        FileName = _excelFile.Path,
                        HasHeaders = true,
                        SheetName = ExcelInfo.sheetName[(int)ExcelInfo.SheetNames.MX_PRPO]
                    },
                    new AccessInfo()
                    {
                        FileName = Configuration.DbPath,
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
            DatabaseUtils.DataRemoved = false;
            DatabaseUtils.CompletedDataRemovals = 0;
            DatabaseUtils.ScheduledDataRemovals = 0;
            DatabaseUtils.ConnectToDatabase();


            DataRemovalTimer.Start();
            RemovePrpoData();
        }


        /// <summary>
        /// Starts the threads that removes the uneeded data from the PRPO database.
        /// </summary>
        private void RemovePrpoData()
        {
            if (AccessUtils.US_PRPO_TableExists)
            {
                DatabaseUtils.ScheduledDataRemovals++;
                usThread = new Thread(() =>
                {
                    DatabaseUtils.RemoveData(Values.Countries.Country.UnitedStates);
                });
                usThread.Start();
            }

            if (AccessUtils.MX_PRPO_TableExists)
            {
                DatabaseUtils.ScheduledDataRemovals++;

                mxThread = new Thread(() =>
                {
                    DatabaseUtils.RemoveData(Values.Countries.Country.Mexico);
                });
                mxThread.Start();
            }
        }


        /// <summary>
        /// This function sets up variables to their default state before begining the data load process.
        /// </summary>
        public void BeginDataLoadProcess()
        {
            ShowPage(Pages.LoadingScreen);
            cpb_loadingScreenCircProgBar.Text = "Loading Data...";
            ms_applicaitonMenuStrip.Enabled = false;
            overallData = new Overall();
            DatabaseUtils.DataLoadProcessStarted = false;
            DatabaseUtils.DataLoaded = false;
            DatabaseUtils.KPITablesLoaded = false;
            DatabaseUtils.CompletedDataLoads = 0;
            DatabaseUtils.ScheduledDataLoads = 0;
            CreateThreads();
            RenewDataLoadTimer();
            DataLoaderTimer.Start();
        }

        #endregion
    }
}
