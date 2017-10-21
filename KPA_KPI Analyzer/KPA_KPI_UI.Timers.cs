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
        Thread KPA_ExcessStock_Stock;
        Thread KPA_ExcessStock_OpenOrders;
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
            ms_applicaitonMenuStrip.Enabled = false;
            try
            {
                if (!Importer.importStarted)
                {
                    Importer.importStarted = true;
                    NavigationLocked = true; // Lock the navigation bar
                                             // load loading screen
                    if (ExcelInfo.USUpdated)
                    {
                        settings.reportSettings.PrpoUsReportFileName = DragDropUtils.US_PRPO_FilePath;

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
                        settings.reportSettings.PrpoMxReportFileName = DragDropUtils.MX_PRPO_FilePath;

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
                        lbl_topPanelNavPrpoDate.Text = dt.ToString("MMMM dd, yyyy");
                        settings.reportSettings.PrpoUsDate = month.ToString() + " " + day.ToString() + " " + year.ToString();
                        settings.reportSettings.PrpoUsReportLoaded = true;
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
                        lbl_topPanelNavPrpoDate.Text = dt.ToString("MMMM dd, yyyy");
                        settings.reportSettings.PrpoMxDate = month.ToString() + " " + day.ToString() + " " + year.ToString();
                        settings.reportSettings.PrpoMxReportLoaded = true;
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
                    lbl_Country.Text = Values.Globals.countries[(int)Values.Globals.Countries.UnitedStates];
                    Values.Globals.SelectedCountry = AccessInfo.MainTables.US_PRPO;
                    InitializeDataLoadProcess();
                }
                else // only the mexico file exists.
                {
                    lbl_Country.Text = Values.Globals.countries[(int)Values.Globals.Countries.Mexico];
                    Values.Globals.SelectedCountry = AccessInfo.MainTables.MX_PRPO;
                    InitializeDataLoadProcess();
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void CreateThreads()
        {
            KPA_PlanThread = new Thread(() => { try { overallData.kpa.plan.LoadData(); } catch (ThreadInterruptedException) { ShowPage(Pages.DragDropDash); } });
            KPA_PurchThread = new Thread(() => { try { overallData.kpa.purch.LoadData(); } catch (ThreadInterruptedException) { ShowPage(Pages.DragDropDash); } });
            KPA_PurchSubThread = new Thread(() => { try { overallData.kpa.purchSub.LoadData(); } catch (ThreadInterruptedException) { ShowPage(Pages.DragDropDash); } });
            KPA_PurchTotalThread = new Thread(() => { try { overallData.kpa.purchTotal.LoadData(); } catch (ThreadInterruptedException) { ShowPage(Pages.DragDropDash); } });
            KPA_FollowUpThread = new Thread(() => { try { overallData.kpa.followUp.LoadData(); } catch (ThreadInterruptedException) { ShowPage(Pages.DragDropDash); } });
            KPA_HotJobs = new Thread(() => { try { overallData.kpa.hotJobs.LoadData(); } catch (ThreadInterruptedException) { ShowPage(Pages.DragDropDash); } });
            KPA_ExcessStock_Stock = new Thread(() => { try { overallData.kpa.excessStockStock.LoadData(); } catch (ThreadInterruptedException) { ShowPage(Pages.DragDropDash); } });
            KPA_ExcessStock_OpenOrders = new Thread(() => { try { overallData.kpa.excessStockOpenOrders.LoadData(); } catch (ThreadInterruptedException) { ShowPage(Pages.DragDropDash); } });
            KPA_CurrPlanVsActualThread = new Thread(() => { try { overallData.kpa.currPlanVsActual.LoadData(); } catch (ThreadInterruptedException) { ShowPage(Pages.DragDropDash); } });

            tableLoadThread = new Thread(() => { try { PRPO_DB_Utils.LoadKPITables(); } catch (ThreadInterruptedException) { ShowPage(Pages.DragDropDash); } });
            KPI_PlanThread = new Thread(() => { try { overallData.kpi.plan.LoadData(); } catch (ThreadInterruptedException) { ShowPage(Pages.DragDropDash); } });
            KPI_PurchThread = new Thread(() => { try { overallData.kpi.purch.LoadData(); } catch (ThreadInterruptedException) { ShowPage(Pages.DragDropDash); } });
            KPI_FollowUpThread = new Thread(() => { try { overallData.kpi.followUp.LoadData(); } catch (ThreadInterruptedException) { ShowPage(Pages.DragDropDash); } });
            KPI_PurchTwoThread = new Thread(() => { try { overallData.kpi.purchTwo.LoadData(); } catch (ThreadInterruptedException) { ShowPage(Pages.DragDropDash); } });
            KPI_PurchSubThread = new Thread(() => { try { overallData.kpi.purchSub.LoadData(); } catch (ThreadInterruptedException) { ShowPage(Pages.DragDropDash); } });
            KPI_PurchTotalThread = new Thread(() => { try { overallData.kpi.purchTotal.LoadData(); } catch (ThreadInterruptedException) { ShowPage(Pages.DragDropDash); } });
            KPI_PurchPlanThread = new Thread(() => { try { overallData.kpi.purchPlan.LoadData(); } catch (ThreadInterruptedException) { ShowPage(Pages.DragDropDash); } });
            KPI_OtherThread = new Thread(() => { try { overallData.kpi.other.LoadData(); } catch (ThreadInterruptedException) { ShowPage(Pages.DragDropDash); } });
        }



        /// <summary>
        /// Starts the threads that will load perform the calculations on the data.
        /// </summary>
        /// <param name="_startKpaThreads">Indicates whether or not the KPA threads should be started.</param>
        /// <param name="_startKpiThreads">Indicates whether or not the KPI threads should be started.</param>
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
                KPA_ExcessStock_Stock.Start();
                KPA_ExcessStock_OpenOrders.Start();
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
                PRPO_DB_Utils.ScheduledDataLoads = 18;
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
                PRPO_DB_Utils.ReleaseKPITables();

                if (!ColumnFiltersApplied && !DateFiltersApplied)
                {
                    DataReader.SaveOverallData(overallData);
                    InitializeFilterLoadProcess();
                }
                else
                {
                    ShowPage(Pages.Filters);
                    EnableClearFiltersButton();
                    NavigationLocked = false;
                    ms_applicaitonMenuStrip.Enabled = true;
                }

                if (Values.Globals.SelectedCountry == AccessInfo.MainTables.US_PRPO)
                {
                    // Populate Dashboard with PRPO report date.
                    DateTime dt = GetLoadedUsPrpoReportDate();
                    settings.reportSettings.PrpoUsLastLoadedDate = DateTime.Now.Month.ToString() + " " + DateTime.Now.Day.ToString() + " " + DateTime.Now.Year.ToString();
                    lbl_dashboardDate.Text = dt.ToString("MMMM dd, yyyy");
                    lbl_topPanelNavPrpoDate.Text = dt.ToString("MMMM dd, yyyy");
                    Values.Globals.PrpoGenerationDate = lbl_topPanelNavPrpoDate.Text;
                }
                else
                {
                    // Populate Dashboard with PRPO report da.te
                    DateTime dt = GetLoadedMxPrpoReportDate();
                    settings.reportSettings.PrpoMxLastLoadedDate = DateTime.Now.Month.ToString() + " " + DateTime.Now.Day.ToString() + " " + DateTime.Now.Year.ToString();
                    lbl_dashboardDate.Text = dt.ToString("MMMM dd, yyyy");
                    lbl_topPanelNavPrpoDate.Text = dt.ToString("MMMM dd, yyyy");
                    Values.Globals.PrpoGenerationDate = lbl_topPanelNavPrpoDate.Text;
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
                settings.Save(settings);
                ShowPage(Pages.Dashboard);
                ms_applicaitonMenuStrip.Enabled = true;
                NavigationLocked = false;
            }
        }
    }
}
