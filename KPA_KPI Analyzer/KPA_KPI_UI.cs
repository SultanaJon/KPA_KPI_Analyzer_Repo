//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//          Project: KPA-KPI Analysis Application
//          Company: Comau North America
//
//          Developer: Jonathan Michael Sultana
//          Date: 06/09/2017
//          
//          "Once you stop learning you start dying" - Albert Einstein
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


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
using System.Data.OleDb;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer
{
    public partial class KPA_KPI_UI : Form
    {
        private FormData frmData = new FormData();
        private static readonly List<string> errorList = new List<string>();
        private Overall overallData = new Overall();
        private UserControl activeTemplate = new UserControl();






        /// <summary>
        /// The initital constructor of the main ui
        /// </summary>
        public KPA_KPI_UI()
        {
            InitializeComponent();
            NavigationLocked = true;
            PRPO_DB_Utils.AI = AccessUtils.AI;
        }






        /// <summary>
        /// The custom constructor of the main user interface. This constructor takes a database conenection that will be used
        /// to connect to and read data from.
        /// </summary>
        /// <param name="conn">The database connection that was established in the splash scree.</param>
        public KPA_KPI_UI(OleDbConnection conn)
        {
            InitializeComponent();

            // Configure the database Utilities class.
            PRPO_DB_Utils.AI = AccessUtils.AI;
            PRPO_DB_Utils.DatabaseConnection = new OleDbConnection(conn.ConnectionString);
        }






        /// <summary>
        /// This function will be called when the form loads.
        /// </summary>
        /// <param name="sender">The form</param>
        /// <param name="e">The load event</param>
        private void KPA_KPI_UI_Load(object sender, EventArgs e)
        {
            mainNavActiveBtn = btn_Dashboard; // set the active button as the first button (Dashboard)
            FilterUtils.UpdateFilter += UpdateFilters;


            if (PRPO_DB_Utils.DatabaseConnection != null)
            {
                try
                {
                    PRPO_DB_Utils.ConnectToDatabase();
                    //btn_DatabaseConnectionStatus.Image = Properties.Resources.databaseConn_Connected_Icon;
                    Logger.Log(AppDirectoryUtils.LogFiles.DbConnectionEvents, "Successfully Connected to MS Access Database");

                    if (AccessUtils.US_PRPO_TableExists && AccessUtils.MX_PRPO_TableExists)
                    {
                        NavigationLocked = true;
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
                    else // There is a Mexico table within the database.
                    {
                        Overall.SelectedCountry = AccessInfo.MainTables.MX_PRPO;
                        PRPO_DB_Utils.DataLoadProcessStarted = false;
                        PRPO_DB_Utils.DataLoaded = false;
                        PRPO_DB_Utils.CompletedDataLoads = 0;
                        PRPO_DB_Utils.ScheduledDataLoads = 0;
                        DataLoaderTimer.Start();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Application load error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            else
            {
                pnl_loadingScreen.Visible = false;
                tblpnl_DragDrop.BringToFront();
            }

        }






        /// <summary>
        /// This form prevents flickering of the UI when it repaints.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED
                handleParam.Style &= ~0x2000000; // Turn off WS_CLIPCHILDREN
                return handleParam;
            }
        }






        /////////////////////////////////////////////////// UI DIALOGS //////////////////////////////////////////////////
        //
        //  here we can control the behavior of the form.
        // 
        //  These functions perform the following
        //  1) minimize the form into the taskbar.
        //  2) maximize the form to the size of the screen and min down to normal size.
        //  3) close the application.
        //
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region UI_Dialogs
        /// <summary>
        /// This event will change the button background image while the user has their cursor over it.
        /// </summary>
        /// <param name="sender">The button</param>
        /// <param name="e">The Mouse Hover Event</param>
        private void btn_Expand_MouseHover(object sender, EventArgs e)
        {
            pnl_Maximize.BackgroundImage = Properties.Resources.Maximize_Hover_icon;
        }






        /// <summary>
        /// This event will change the background of the image back to the original image.
        /// </summary>
        /// <param name="sender">the button</param>
        /// <param name="e">the Mouse Leave Event</param>
        private void btn_Expand_MouseLeave(object sender, EventArgs e)
        {
            pnl_Maximize.BackgroundImage = Properties.Resources.Maximize;
        }






        /// <summary>
        /// This event will trigger when the user clicks the expand button and the form will expand.
        /// </summary>
        /// <param name="sender">The expand button</param>
        /// <param name="e">The click event.</param>
        private void btn_Expand_Click(object sender, EventArgs e)
        {
            FormSizer();
        }






        /// <summary>
        /// This event will change the background of the button when the user hovers over it.
        /// </summary>
        /// <param name="sender">the button</param>
        /// <param name="e">The Mouse Enter Event</param>
        private void btn_Minimize_MouseEnter(object sender, EventArgs e)
        {
            pnl_Minimize.BackgroundImage = Properties.Resources.Minimize_Hover_Icon;
        }






        /// <summary>
        /// This event will change the background of the image back to the original image.
        /// </summary>
        /// <param name="sender">the button</param>
        /// <param name="e">the Mouse Leave event</param>
        private void btn_Minimize_MouseLeave(object sender, EventArgs e)
        { 
            pnl_Minimize.BackgroundImage = Properties.Resources.Minimize;
        }






        /// <summary>
        /// This event will trigger when the user clicks the minimize button. The form will minimize into the taskbar.
        /// </summary>
        /// <param name="sender">The minimize button</param>
        /// <param name="e">The click event.</param>
        private void btn_Minimize_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;






        /// <summary>
        /// This event will change the background of the button when the user hovers over it.
        /// </summary>
        /// <param name="sender">the button</param>
        /// <param name="e">The Mouse Over event</param>
        private void btn_Close_MouseHover(object sender, EventArgs e)
        {
            pnl_Close.BackgroundImage = Properties.Resources.Close_Hover_icon;
        }






        /// <summary>
        /// This event will change the background of the button back to the original background image.
        /// </summary>
        /// <param name="sender">the close button</param>
        /// <param name="e">The MouseLeave event</param>
        private void btn_Close_MouseLeave(object sender, EventArgs e)
        {
            pnl_Close.BackgroundImage = Properties.Resources.Close;
        }






        /// <summary>
        /// This event will close the entire application (process)
        /// </summary>
        /// <param name="sender">The Close button</param>
        /// <param name="e">The click event</param>
        private void btn_Close_Click(object sender, EventArgs e) => Application.Exit();
        #endregion






        /////////////////////////////////////////////////// TOP PANEL //////////////////////////////////////////////////
        //
        //  Here we can control the behavior of the for with the top panel.
        // 
        //  These functions perform the following.
        //  1) size the form to the size of the screen when double clicked.
        //
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region Top_Panel
        /// <summary>
        /// This event will trigger when the user double clicks the top panel of the the UI. This will max out the size of 
        /// the screen based on the size of the working area of the computer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnl_TopPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSizer();
        }








        /// <summary>
        /// This function will expand or minimize to original window size.
        /// </summary>
        private void FormSizer()
        {
            Screen screen = Screen.FromControl(this);

            if (Width == screen.WorkingArea.Width && Height == screen.WorkingArea.Height)
            {
                Width = Constants.minFormWidth;
                Height = Constants.minFormHeight;
                WindowState = FormWindowState.Normal;
                Left = frmData.FrmX;
                Top = frmData.FrmY;
            }
            else
            {
                frmData.FrmX = Left;
                frmData.FrmY = Top;
                Left = screen.WorkingArea.Left;
                Top = screen.WorkingArea.Top;
                Width = screen.WorkingArea.Width;
                Height = screen.WorkingArea.Height;
            }
            RefreshTemplate();
        }
        #endregion






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
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "Import Function Error");
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

                if (PRPO_DB_Utils.DatabaseConnection != null & PRPO_DB_Utils.DatabaseConnection.State == System.Data.ConnectionState.Open)
                {
                    //btn_DatabaseConnectionStatus.Image = Properties.Resources.databaseConn_Connected_Icon;
                }
                else
                {
                    MessageBox.Show("There was an error while attempting to connect to the database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }




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

                // TODO: pnl_activePage.Controls.Clear();
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


            if(PRPO_DB_Utils.KPITablesLoaded)
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


            if(FilterUtils.FiltersLoaded)
            {
                pnl_loadingScreen.Visible = false;
                FilterUtils.FiltersLoaded = false;
                FiltersTimer.Stop();
                tblpnl_DashbaordPage.BringToFront();
                NavigationLocked = false;
            }
        }






        /// <summary>
        /// Loads either the KPA or KPI overall data template depending on what navigation button was pressed.
        /// </summary>
        private void LoadOverallTemplate()
        {
            if(int.Parse(mainNavActiveBtn.Tag.ToString()) == 1)
            {
                // TODO: pnl_activePage.Controls.Clear();
                // TODO: pnl_activePage.BringToFront();
                KPAOverall kpaOverall = new KPAOverall();
                // TODO: kpaOverall.Dock = DockStyle.Fill;
                kpaOverall.Anchor = AnchorStyles.Bottom;
                kpaOverall.Anchor = AnchorStyles.Top;
                kpaOverall.Anchor = AnchorStyles.Right;
                kpaOverall.Anchor = AnchorStyles.Left;

                kpaOverall.LoadTemplate(overallData);
                pnl_activePage.Controls.Add(kpaOverall);
            }
            else
            {
                // TODO: pnl_activePage.Controls.Clear();
                // TODO: pnl_activePage.BringToFront();
                KPIOverall kpiOverall = new KPIOverall();
                // TODO: kpiOverall.Dock = DockStyle.Fill;
                kpiOverall.Anchor = AnchorStyles.Bottom;
                kpiOverall.Anchor = AnchorStyles.Top;
                kpiOverall.Anchor = AnchorStyles.Right;
                kpiOverall.Anchor = AnchorStyles.Left;

                kpiOverall.LoadTemplate(overallData);
                pnl_activePage.Controls.Add(kpiOverall);
            }
        }






        /// <summary>
        /// Loads the data coming soon template.
        /// </summary>
        private void LoadDataComingSoonTemplate()
        {
            // TODO: pnl_activePage.Controls.Clear();
            // TODO: pnl_activePage.BringToFront();
            DataComingSoon comingSoon = new DataComingSoon();
            // TODO:comingSoon.Dock = DockStyle.Fill;
            comingSoon.Anchor = AnchorStyles.Bottom;
            comingSoon.Anchor = AnchorStyles.Top;
            comingSoon.Anchor = AnchorStyles.Right;
            comingSoon.Anchor = AnchorStyles.Left;
            pnl_activePage.Controls.Add(comingSoon);
        }









        /// <summary>
        /// Triggered when a controls is added to the active page panel (pnl_activePage). depending on
        /// what control was added, that templates data will be loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnl_activePage_ControlAdded(object sender, ControlEventArgs e)
        {
            if(e.Control is UserControl)
            {
                int tag = int.Parse(activeSectionBtn.Tag.ToString());

                switch (tag)
                {
                    case 1:
                        KPAPlanTemplate kpaPlan = (KPAPlanTemplate)e.Control;
                        kpaPlan.LoadPanel(overallData);
                        activeTemplate = kpaPlan;
                        break;
                    case 2:
                        KPAPurchTemplate kpaPurch = (KPAPurchTemplate)e.Control;
                        kpaPurch.LoadPanel(overallData);
                        activeTemplate = kpaPurch;
                        break;
                    case 3:
                        KPAPurchSubTemplate kpaPurchSub = (KPAPurchSubTemplate)e.Control;
                        kpaPurchSub.LoadPanel(overallData);
                        activeTemplate = kpaPurchSub;
                        break;
                    case 4:
                        KPAPurchTotalTemplate kpaPurchTotal = (KPAPurchTotalTemplate)e.Control;
                        kpaPurchTotal.LoadPanel(overallData);
                        activeTemplate = kpaPurchTotal;
                        break;
                    case 6:
                        KPAFollowUpTemplate kpaFollowUp = (KPAFollowUpTemplate)e.Control;
                        kpaFollowUp.LoadPanel(overallData);
                        activeTemplate = kpaFollowUp;
                        break;
                    case 9:
                        KPAHotJobsTemplate kpaHotJobs = (KPAHotJobsTemplate)e.Control;
                        kpaHotJobs.LoadPanel(overallData);
                        activeTemplate = kpaHotJobs;
                        break;
                    case 12:
                        KPACurrentPlanActualTemplate kpaCurrPlanActual = (KPACurrentPlanActualTemplate)e.Control;
                        kpaCurrPlanActual.LoadPanel(overallData);
                        activeTemplate = kpaCurrPlanActual;
                        break;
                    case 15:
                        KPIPlanTemplate kpiPlan = (KPIPlanTemplate)e.Control;
                        kpiPlan.LoadPanel(overallData);
                        activeTemplate = kpiPlan;
                        break;
                    case 16:
                        KPIPurchTemplate kpiPurch = (KPIPurchTemplate)e.Control;
                        kpiPurch.LoadPanel(overallData);
                        activeTemplate = kpiPurch;
                        break;
                    case 17:
                        KPIFollowUpTemplate kpiFollowUp = (KPIFollowUpTemplate)e.Control;
                        kpiFollowUp.LoadPanel(overallData);
                        activeTemplate = kpiFollowUp;
                        break;
                    case 19:
                        KPIPurchTwoTemplate kpiPurchTwo = (KPIPurchTwoTemplate)e.Control;
                        kpiPurchTwo.LoadPanel(overallData);
                        activeTemplate = kpiPurchTwo;
                        break;
                    case 20:
                        KPIPurchSubTemplate kpiPurchSub = (KPIPurchSubTemplate)e.Control;
                        kpiPurchSub.LoadPanel(overallData);
                        activeTemplate = kpiPurchSub;
                        break;
                    case 21:
                        KPIPurchTotalTemplate kpiPurchTotal = (KPIPurchTotalTemplate)e.Control;
                        kpiPurchTotal.LoadPanel(overallData);
                        activeTemplate = kpiPurchTotal;
                        break;
                    case 22:
                        KPIPurchPlanTemplate kpiPurchPlan = (KPIPurchPlanTemplate)e.Control;
                        kpiPurchPlan.LoadPanel(overallData);
                        activeTemplate = kpiPurchPlan;
                        break;
                    case 24:
                        KPIOtherTemplate kpiOther = (KPIOtherTemplate)e.Control;
                        kpiOther.LoadPanel(overallData);
                        activeTemplate = kpiOther;
                        break;
                    default:
                        break;
                }
            }
        }







        /// <summary>
        /// Refreshes the active template that is within pnl_activePage. This is called when the 
        /// application is made full screen and normal size. This is for the column chart located
        /// on each template.
        /// </summary>
        public void RefreshTemplate()
        {
            if(activeSectionBtn.Tag != null)
            {
                int tag = int.Parse(activeSectionBtn.Tag.ToString());


                switch (tag)
                {
                    case 1:
                        KPAPlanTemplate kpaPlan = (KPAPlanTemplate)activeTemplate;
                        kpaPlan.RefreshTemplate();
                        break;
                    case 2:
                        KPAPurchTemplate kpaPurch = (KPAPurchTemplate)activeTemplate;
                        kpaPurch.RefreshTemplate();
                        break;
                    case 3:
                        KPAPurchSubTemplate kpaPurchSub = (KPAPurchSubTemplate)activeTemplate;
                        kpaPurchSub.RefreshTemplate();
                        break;
                    case 4:
                        KPAPurchTotalTemplate kpaPurchTotal = (KPAPurchTotalTemplate)activeTemplate;
                        kpaPurchTotal.RefreshTemplate();
                        break;
                    case 6:
                        KPAFollowUpTemplate kpaFollowUp = (KPAFollowUpTemplate)activeTemplate;
                        kpaFollowUp.RefreshTemplate();
                        break;
                    case 9:
                        KPAHotJobsTemplate kpaHotJobs = (KPAHotJobsTemplate)activeTemplate;
                        kpaHotJobs.RefreshTemplate();
                        break;
                    case 12:
                        KPACurrentPlanActualTemplate kpaCurrPlanActual = (KPACurrentPlanActualTemplate)activeTemplate;
                        kpaCurrPlanActual.RefreshTemplate();
                        break;
                    case 15:
                        KPIPlanTemplate kpiPlan = (KPIPlanTemplate)activeTemplate;
                        kpiPlan.RefreshTemplate();
                        break;
                    case 16:
                        KPIPurchTemplate kpiPurch = (KPIPurchTemplate)activeTemplate;
                        kpiPurch.RefreshTemplate();
                        break;
                    case 17:
                        KPIFollowUpTemplate kpiFollowUp = (KPIFollowUpTemplate)activeTemplate;
                        kpiFollowUp.RefreshTemplate();
                        break;
                    case 19:
                        KPIPurchTwoTemplate kpiPurchTwo = (KPIPurchTwoTemplate)activeTemplate;
                        kpiPurchTwo.RefreshTemplate();
                        break;
                    case 20:
                        KPIPurchSubTemplate kpiPurchSub = (KPIPurchSubTemplate)activeTemplate;
                        kpiPurchSub.RefreshTemplate();
                        break;
                    case 21:
                        KPIPurchTotalTemplate kpiPurchTotal = (KPIPurchTotalTemplate)activeTemplate;
                        kpiPurchTotal.RefreshTemplate();
                        break;
                    case 22:
                        KPIPurchPlanTemplate kpiPurchPlan = (KPIPurchPlanTemplate)activeTemplate;
                        kpiPurchPlan.RefreshTemplate();
                        break;
                    case 24:
                        KPIOtherTemplate kpiOther = (KPIOtherTemplate)activeTemplate;
                        kpiOther.RefreshTemplate();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}