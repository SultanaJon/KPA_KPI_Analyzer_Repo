using DataImporter.Access;
using DataImporter.Classes;
using DataImporter.Excel;
using KPA_KPI_Analyzer.DatabaseUtils;
using KPA_KPI_Analyzer.Diagnostics;
using KPA_KPI_Analyzer.DragDropFeatures;
using KPA_KPI_Analyzer.FilterFeeature;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer
{
    public partial class KPA_KPI_UI : Form
    {
        Thread KPA_PlanThread;
        Thread KPA_PurchThread;
        Thread KPA_PurchSubThread;
        Thread KPA_PurchTotalThread;
        Thread KPA_FollowUpThread;
        Thread KPA_HotJobs;
        Thread KPA_CurrPlanVsActualThread;
        Thread tableLoadThread;
        Thread KPI_PlanThread;
        Thread KPI_PurchThread;
        Thread KPI_FollowUpThread;
        Thread KPI_PurchTwoThread;
        Thread KPI_PurchSubThread;
        Thread KPI_PurchTotalThread;
        Thread KPI_PurchPlanThread;
        Thread KPI_OtherThread;


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
                if (!Importer.importStarted)
                {
                    Importer.importStarted = true;
                    NavigationLocked = true; // Lock the navigation bar
                                             // load loading screen
                    if (ExcelInfo.USUpdated)
                    {
                        // import only the US PRPO file
                        Importer usImport = new Importer(
                            new ExcelInfo()
                            {
                                FileName = DragDropUtils.US_PRPO_FilePath,
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
                            catch(ThreadInterruptedException)
                            {
                                ShowPage(Pages.DragDropDash);
                            }
                        });
                        usThread.Name = "US";
                        usThread.Start(Thread.CurrentThread);
                    }


                    if (ExcelInfo.MXUpdated)
                    {
                        // Import only the MX PRPO file.
                        Importer mxImport = new Importer(
                            new ExcelInfo()
                            {
                                FileName = DragDropUtils.MX_PRPO_FilePath,
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
                            catch(ThreadInterruptedException)
                            {
                                ShowPage(Pages.DragDropDash);
                            }
                        });

                        mxThread.Name = "MX";
                        mxThread.Start(Thread.CurrentThread);
                    }
                }


                if (Importer.ImportComplete)
                {
                    Importer.ImportComplete = false;
                    ImportTimer.Stop();
                    PRPO_DB_Utils.DataRemovalProcessStarted = false;
                    PRPO_DB_Utils.DataRemoved = false;
                    PRPO_DB_Utils.CompletedDataRemovals = 0;
                    PRPO_DB_Utils.ScheduledDataRemovals = 0;
                    PRPO_DB_Utils.ConnectToDatabase();

                    if (AccessUtils.US_PRPO_TableExists)
                    {
                        string strFileName = Path.GetFileNameWithoutExtension(DragDropUtils.US_PRPO_FilePath);
                        string strMonth = strFileName[7].ToString() + strFileName[8].ToString();
                        string strday = strFileName[9].ToString() + strFileName[10].ToString();
                        string strYear = strFileName[11].ToString() + strFileName[12].ToString() + strFileName[13].ToString() + strFileName[14].ToString();

                        int month = int.Parse(strMonth.TrimStart('0'));
                        int day = int.Parse(strday.TrimStart('0'));
                        int year = int.Parse(strYear);

                        DateTime dt = new DateTime(year, month, day);
                        lbl_dashboardDate.Text = dt.ToString("MMMM dd, yyyy");
                        Logger.Log(AppDirectoryUtils.LogFiles.LoadedUSDate, lbl_dashboardDate.Text);
                    }

                    if (AccessUtils.MX_PRPO_TableExists)
                    {
                        string strFileName = Path.GetFileNameWithoutExtension(DragDropUtils.MX_PRPO_FilePath);
                        string strMonth = strFileName[7].ToString() + strFileName[8].ToString();
                        string strday = strFileName[9].ToString() + strFileName[10].ToString();
                        string strYear = strFileName[11].ToString() + strFileName[12].ToString() + strFileName[13].ToString() + strFileName[14].ToString();

                        int month = int.Parse(strMonth.TrimStart('0'));
                        int day = int.Parse(strday.TrimStart('0'));
                        int year = int.Parse(strYear);

                        DateTime dt = new DateTime(year, month, day);
                        lbl_dashboardDate.Text = dt.ToString("MMMM dd, yyyy");
                        Logger.Log(AppDirectoryUtils.LogFiles.LoadedMXDate, lbl_dashboardDate.Text);
                    }


                    if(Properties.Settings.Default.RemoveData)
                        DataRemovalTimer.Start();
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
            if (!PRPO_DB_Utils.DataRemovalProcessStarted)
            {
                PRPO_DB_Utils.DataRemovalProcessStarted = true;

                if (AccessUtils.US_PRPO_TableExists)
                {
                    PRPO_DB_Utils.ScheduledDataRemovals++;

                    usThread = new Thread(() =>
                    {
                        PRPO_DB_Utils.RemoveData(PRPOCommands.DatabaseTables.MainTables.US_PRPO);
                    });
                    usThread.Start();
                }

                if (AccessUtils.MX_PRPO_TableExists)
                {
                    PRPO_DB_Utils.ScheduledDataRemovals++;

                    mxThread = new Thread(() =>
                    {
                        PRPO_DB_Utils.RemoveData(PRPOCommands.DatabaseTables.MainTables.MX_PRPO);
                    });
                    mxThread.Start();
                }
            }


            if (PRPO_DB_Utils.DataRemoved)
            {
                PRPO_DB_Utils.DataRemoved = false;
                DataRemovalTimer.Stop();

                if (AccessUtils.US_PRPO_TableExists && AccessUtils.MX_PRPO_TableExists)
                {
                    ShowPage(Pages.CountrySelector);
                }
                else if (AccessUtils.US_PRPO_TableExists)
                {
                    lbl_Country.Text = Values.Constants.unitedStates;
                    Values.Globals.SelectedCountry = AccessInfo.MainTables.US_PRPO;
                    InitializeDataLoadProcess();
                    RenewDataLoadTimer();
                    DataLoaderTimer.Start();
                }
                else // only the mexico file exists.
                {
                    lbl_Country.Text = Values.Constants.mexico;
                    Values.Globals.SelectedCountry = AccessInfo.MainTables.MX_PRPO;
                    InitializeDataLoadProcess();
                    RenewDataLoadTimer();
                    DataLoaderTimer.Start();
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void CreateThreads()
        {
            KPA_PlanThread = new Thread(() => { overallData.kpa.plan.LoadData(); });
            KPA_PurchThread = new Thread(() =>  { overallData.kpa.purch.LoadData(); });
            KPA_PurchSubThread = new Thread(() => { overallData.kpa.purchSub.LoadData(); });
            KPA_PurchTotalThread = new Thread(() => { overallData.kpa.purchTotal.LoadData(); });
            KPA_FollowUpThread = new Thread(() => { overallData.kpa.followUp.LoadData(); });
            KPA_HotJobs = new Thread(() => { overallData.kpa.hotJobs.LoadData(); });
            KPA_CurrPlanVsActualThread = new Thread(() => { overallData.kpa.currPlanVsActual.LoadData(); });
            tableLoadThread = new Thread(() => { PRPO_DB_Utils.LoadKPITables(); });
            KPI_PlanThread = new Thread(() =>{ overallData.kpi.plan.LoadData(); });
            KPI_PurchThread = new Thread(() =>{ overallData.kpi.purch.LoadData(); });
            KPI_FollowUpThread = new Thread(() => { overallData.kpi.followUp.LoadData(); });
            KPI_PurchTwoThread = new Thread(() => { overallData.kpi.purchTwo.LoadData(); });
            KPI_PurchSubThread = new Thread(() => { overallData.kpi.purchSub.LoadData(); });
            KPI_PurchTotalThread = new Thread(() => { overallData.kpi.purchTotal.LoadData(); });
            KPI_PurchPlanThread = new Thread(() => { overallData.kpi.purchPlan.LoadData(); });
            KPI_OtherThread = new Thread(() => { overallData.kpi.other.LoadData(); });
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="_startKpaThreads"></param>
        /// <param name="_startKpiThreads"></param>
        private void StartThreads(bool _startKpaThreads, bool _startKpiThreads)
        {
            if(_startKpaThreads)
            {
                KPA_PlanThread.Start();
                KPA_PurchThread.Start();
                KPA_PurchSubThread.Start();
                KPA_PurchTotalThread.Start();
                KPA_FollowUpThread.Start();
                KPA_HotJobs.Start();
                KPA_CurrPlanVsActualThread.Start();
                tableLoadThread.Start();
            }


            if(_startKpiThreads)
            {
                KPI_PlanThread.Start();
                KPI_PurchThread.Start();
                KPI_FollowUpThread.Start();
                KPI_PurchTwoThread.Start();
                KPI_PurchSubThread.Start();
                KPI_PurchTotalThread.Start();
                KPI_PurchPlanThread.Start();
                KPI_OtherThread.Start();
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

            if (!PRPO_DB_Utils.DataLoadProcessStarted)
            {
                PRPO_DB_Utils.DataLoadProcessStarted = true;
                PRPO_DB_Utils.KPITablesLoaded = false;
                ShowPage(Pages.LoadingScreen);
                lbl_loadingStatus.Text = "Loading Data...";
                PRPO_DB_Utils.ScheduledDataLoads = 16;
                StartThreads(true, false);
            }


            if (PRPO_DB_Utils.KPITablesLoaded)
            {
                PRPO_DB_Utils.KPITablesLoaded = false;
                StartThreads(false, true);
            }

            if (PRPO_DB_Utils.DataLoaded)
            {
                PRPO_DB_Utils.DataLoaded = false;
                DataLoaderTimer.Stop();

                if (!ColumnFiltersApplied && !DateFiltersApplied)
                {
                    DataReader.SaveOverallData(overallData);
                    FilterUtils.FiltersLoaded = false;
                    FilterUtils.FilterLoadProcessStarted = false;
                    FiltersTimer.Start();
                }
                else
                {
                    ShowPage(Pages.Filters);
                    btn_clearFilters.Enabled = true;
                    NavigationLocked = false;
                }

                if (Values.Globals.SelectedCountry == AccessInfo.MainTables.US_PRPO)
                {
                    // Populate Dashboard with PRPO report date.
                    GetCurrentUsPrpoReportDate();
                }
                else
                {
                    // Populate Dashboard with PRPO report da.te
                    GetCurrentMxPrpoReportDate();
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
            ShowPage(Pages.LoadingScreen);
            lbl_loadingStatus.Text = "Loading Filters...";

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
                ShowPage(Pages.Dashboard);
                NavigationLocked = false;
            }
        }
    }
}
