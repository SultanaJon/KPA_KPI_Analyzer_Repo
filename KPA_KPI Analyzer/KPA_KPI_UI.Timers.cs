using DataImporter.Classes;
using Excel_Access_Tools.Access;
using Excel_Access_Tools.Excel;
using KPA_KPI_Analyzer.DatabaseUtils;
using KPA_KPI_Analyzer.DragDropFeatures;
using KPA_KPI_Analyzer.FilterFeeature;
using KPA_KPI_Analyzer.IOUtils;
using KPA_KPI_Analyzer.KPA_KPI_Overall;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer
{
    public partial class KPA_KPI_UI : Form
    {






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

                        usThread = new Thread(() =>
                        {
                            usImport.Run();
                        });
                        usThread.Name = "US";
                        usThread.Start();
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


                        mxThread = new Thread(() =>
                        {
                            mxImport.Run();
                        });

                        mxThread.Name = "MX";
                        mxThread.Start();
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

                    DataRemovalTimer.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Import Function Error");
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
                DataRemovalTimer.Stop();
                PRPO_DB_Utils.DataRemoved = false;

                if (AccessUtils.US_PRPO_TableExists && AccessUtils.MX_PRPO_TableExists)
                {
                    pnl_CountrySelector.BringToFront();
                }
                else if (AccessUtils.US_PRPO_TableExists)
                {
                    Overall.SelectedCountry = AccessInfo.MainTables.US_PRPO;
                    PRPO_DB_Utils.DataLoadProcessStarted = false;
                    PRPO_DB_Utils.DataLoaded = false;
                    PRPO_DB_Utils.CompletedDataLoads = 0;
                    PRPO_DB_Utils.ScheduledDataLoads = 0;
                    DataLoaderTimer.Start();
                }
                else // only the mexico file exists.
                {
                    Overall.SelectedCountry = AccessInfo.MainTables.MX_PRPO;
                    PRPO_DB_Utils.DataLoadProcessStarted = false;
                    PRPO_DB_Utils.DataLoaded = false;
                    PRPO_DB_Utils.CompletedDataLoads = 0;
                    PRPO_DB_Utils.ScheduledDataLoads = 0;
                    DataLoaderTimer.Start();
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
            if (!PRPO_DB_Utils.DataLoadProcessStarted)
            {
                PRPO_DB_Utils.DataLoadProcessStarted = true;
                PRPO_DB_Utils.KPITablesLoaded = false;

                pnl_loadingScreen.Visible = true;
                pnl_loadingScreen.BringToFront();
                lbl_loadingStatus.Text = "Loading Data...";


                Thread KPA_PlanThread = new Thread(() =>
                {
                    overallData.kpa.plan.LoadData();
                });


                Thread KPA_PurchThread = new Thread(() =>
                {
                    overallData.kpa.purch.LoadData();
                });


                Thread KPA_PurchSubThread = new Thread(() =>
                {
                    overallData.kpa.purchSub.LoadData();
                });


                Thread KPA_PurchTotalThread = new Thread(() =>
                {
                    overallData.kpa.purchTotal.LoadData();
                });


                Thread KPA_FollowUpThread = new Thread(() =>
                {
                    overallData.kpa.followUp.LoadData();
                });


                Thread KPA_HotJobs = new Thread(() =>
                {
                    overallData.kpa.hotJobs.LoadData();
                });



                Thread KPA_CurrPlanVsActualThread = new Thread(() =>
                {
                    overallData.kpa.currPlanVsActual.LoadData();
                });



                PRPO_DB_Utils.ScheduledDataLoads = 16;

                Thread tableLoadThread = new Thread(() => {
                    overallData.LoadKPITables(Overall.SelectedCountry);
                });



                KPA_PlanThread.Start();
                KPA_PurchThread.Start();
                KPA_PurchSubThread.Start();
                KPA_PurchTotalThread.Start();
                KPA_FollowUpThread.Start();
                KPA_HotJobs.Start();
                KPA_CurrPlanVsActualThread.Start();
                tableLoadThread.Start();
            }


            if (PRPO_DB_Utils.KPITablesLoaded)
            {
                PRPO_DB_Utils.KPITablesLoaded = false;

                // KPI
                Thread KPI_PlanThread = new Thread(() =>
                {
                    overallData.kpi.plan.LoadData();
                });

                Thread KPI_PurchThread = new Thread(() =>
                {
                    overallData.kpi.purch.LoadData();
                });


                Thread KPI_FollowUpThread = new Thread(() =>
                {
                    overallData.kpi.followUp.LoadData();
                });


                Thread KPI_PurchTwoThread = new Thread(() =>
                {
                    overallData.kpi.purchTwo.LoadData();
                });


                Thread KPI_PurchSubThread = new Thread(() =>
                {
                    overallData.kpi.purchSub.LoadData();
                });


                Thread KPI_PurchTotalThread = new Thread(() =>
                {
                    overallData.kpi.purchTotal.LoadData();
                });


                Thread KPI_PurchPlanThread = new Thread(() =>
                {
                    overallData.kpi.purchPlan.LoadData();
                });

                Thread KPI_OtherThread = new Thread(() =>
                {
                    overallData.kpi.other.LoadData();
                });


                KPI_PlanThread.Start();
                KPI_PurchThread.Start();
                KPI_FollowUpThread.Start();
                KPI_PurchTwoThread.Start();
                KPI_PurchSubThread.Start();
                KPI_PurchTotalThread.Start();
                KPI_PurchPlanThread.Start();
                KPI_OtherThread.Start();
            }



            if (PRPO_DB_Utils.DataLoaded)
            {
                DataLoaderTimer.Stop();
                PRPO_DB_Utils.DataLoaded = false;

                if (!FiltersApplied)
                {
                    FilterUtils.FiltersLoaded = false;
                    FilterUtils.FilterLoadProcessStarted = false;
                    FiltersTimer.Start();
                }
                else
                {
                    pnl_loadingScreen.Visible = false;
                    tblpnl_Filters.BringToFront();
                    btn_clearFilters.Enabled = true;
                    NavigationLocked = false;
                }

                if (Overall.SelectedCountry == AccessInfo.MainTables.US_PRPO)
                {
                    using (StreamReader sr = new StreamReader(AppDirectoryUtils.logFiles[(int)AppDirectoryUtils.LogFiles.LoadedUSDate]))
                    {
                        lbl_dashboardDate.Text = sr.ReadLine();
                    }
                }
                else
                {
                    using (StreamReader sr = new StreamReader(AppDirectoryUtils.logFiles[(int)AppDirectoryUtils.LogFiles.LoadedMXDate]))
                    {
                        lbl_dashboardDate.Text = sr.ReadLine();
                    }
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
                pnl_loadingScreen.Visible = false;
                tblpnl_DashbaordPage.BringToFront();
                NavigationLocked = false;
            }
        }
    }
}
