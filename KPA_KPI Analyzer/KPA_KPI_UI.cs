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


using DataImporter.Access;
using KPA_KPI_Analyzer.DatabaseUtils;
using KPA_KPI_Analyzer.FilterFeeature;
using KPA_KPI_Analyzer.Diagnostics;
using KPA_KPI_Analyzer.KPA_KPI_Overall;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
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
            PRPO_DB_Utils.RenewDataLoadTimer += RenewDataLoadTimer;
            DateTime today = DateTime.Now.Date;
            dp_PRFromDate.Value = today;
            dp_PRToDate.Value = today;
            dp_POFromDate.Value = today;
            dp_POToDate.Value = today;

            if (PRPO_DB_Utils.DatabaseConnection != null)
            {
                try
                {
                    PRPO_DB_Utils.ConnectToDatabase();
                    Logger.Log(Diagnostics.AppDirectoryUtils.LogFiles.DbConnectionEvents, "Successfully Connected to MS Access Database");

                    if (AccessUtils.US_PRPO_TableExists && AccessUtils.MX_PRPO_TableExists)
                    {
                        NavigationLocked = true;
                        ShowPage(Pages.CountrySelector);
                    }
                    else if (AccessUtils.US_PRPO_TableExists)
                    {
                        lbl_Country.Text = "United States";
                        Overall.SelectedCountry = AccessInfo.MainTables.US_PRPO;
                        InitializeDataLoadProcess();
                        RenewDataLoadTimer();
                        DataLoaderTimer.Start();
                    }
                    else // There is a Mexico table within the database.
                    {
                        lbl_Country.Text = "Mexico";
                        Overall.SelectedCountry = AccessInfo.MainTables.MX_PRPO;
                        InitializeDataLoadProcess();
                        CreateThreads();
                        RenewDataLoadTimer();
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
                ShowPage(Pages.DragDropDash);
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

            if (Width == screen.WorkingArea.Width && Height == screen.WorkingArea.Height) // the form is maxed
            {
                Width = Constants.minFormWidth;
                Height = Constants.minFormHeight;
                Left = frmData.FrmX;
                Top = frmData.FrmY;
            }
            else // the form is its default size
            {
                frmData.FrmX = Left;
                frmData.FrmY = Top;
                Left = screen.WorkingArea.Left;
                Top = screen.WorkingArea.Top;
                Height = screen.WorkingArea.Height;
                Width = screen.WorkingArea.Width;

            }
            RefreshTemplate();
        }
        #endregion













        /// <summary>
        /// The pages that can be displayed in the active page panel.
        /// </summary>
        public enum Pages
        {
            Dashboard,
            DragDropDash,
            Filters,
            LoadingScreen,
            CountrySelector
        }




        /// <summary>
        /// This event will display the request page in the active page panel.
        /// </summary>
        /// <param name="page">The page to be displayed</param>
        private void ShowPage(Pages page)
        {
            HidePages();
            switch((int)page)
            {
                case 0:
                    tblpnl_DashbaordPage.Visible = true;
                    tblpnl_DashbaordPage.BringToFront();
                    break;
                case 1:
                    tblpnl_DragDrop.Visible = true;
                    tblpnl_DragDrop.BringToFront();
                    break;
                case 2:
                    tblpnl_Filters.Visible = true;
                    tblpnl_Filters.BringToFront();
                    break;
                case 3:
                    pnl_loadingScreen.Visible = true;
                    pnl_loadingScreen.BringToFront();
                    break;
                case 4:
                    pnl_CountrySelector.Visible = true;
                    pnl_CountrySelector.BringToFront();
                    break;
                default:
                    break;  
            }
        }






        /// <summary>
        /// 
        /// </summary>
        private void HidePages()
        {
            tblpnl_DashbaordPage.Visible = false;
            tblpnl_DragDrop.Visible = false;
            tblpnl_Filters.Visible = false;
            pnl_CountrySelector.Visible = false;
            pnl_loadingScreen.Visible = false;
        }








        /// <summary>
        /// This function sets up variables to their default state before begining the data load process.
        /// </summary>
        internal void InitializeDataLoadProcess()
        {
            overallData = new Overall();
            PRPO_DB_Utils.DataLoadProcessStarted = false;
            PRPO_DB_Utils.DataLoaded = false;
            PRPO_DB_Utils.KPITablesLoaded = false;
            PRPO_DB_Utils.CompletedDataLoads = 0;
            PRPO_DB_Utils.ScheduledDataLoads = 0;
            CreateThreads();
        }






        /// <summary>
        /// This event will resubscribe the DataLoaderTimer.Tick event.
        /// </summary>
        /// <remarks>
        /// This had to be done because after the DataLoaderTimer would run a couple of times its event would no longer fire as if it was unsubscribed somehow.
        /// </remarks>
        internal void RenewDataLoadTimer()
        {
            DataLoaderTimer.Tick -= DataLoaderTimer_Tick;
            DataLoaderTimer.Tick += DataLoaderTimer_Tick;
        }
    }
}